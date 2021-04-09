/* License
 * --------------------------------------------------------------------------------------------------------------------
 * (C) Copyright 2021 Cato Léan Trütschel and contributors 
 * (https://github.com/CatoLeanTruetschel/AsyncQueryableAdapterPrototype)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * --------------------------------------------------------------------------------------------------------------------
 */

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using AsyncQueryableAdapter.Translators;

namespace AsyncQueryableAdapter
{
    // TODO: Pool me pls!
    internal sealed class QueryExpressionVisitor : ExpressionVisitor
    {
        private bool _isInRootMethod = true;
        private readonly AsyncQueryableOptions _options;

        public QueryExpressionVisitor(in AsyncQueryableOptions options)
        {
            _options = options;
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            // We access a lambda = a nested method, we are no longer in the root method.
            // TODO: Is this necessary? Test this! Document this.
            //       The general idea is that we enable rewrite only if we process the root method, so when 
            //       a nested method contains anything IAsyncQueryable related, we just ignore that. The chance that
            //       this happens is small, but is possible.
            var wasInRootMethod = _isInRootMethod;
            _isInRootMethod = false;

            var result = base.VisitLambda(node);
            _isInRootMethod = wasInRootMethod;
            return result;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            // TODO: Adapt comment to new TranslatedQuery type.
            // We are processing the root of the expression tree.
            // When the type of the constant (leaf node) is of known type 'AsyncQueryable', this is the entry point
            // into the database 'collection', so the raw collection of this type (f.e. the entire table).        
            // If this is the case, we translate this node in a way that it is processable by the database driver,
            // do to an instance of type IQueryable<T>, that also represents the raw collection of type T.
            if (node.Type.IsAssignableTo<AsyncQueryable>())
            {
                // Of the node value is not assignable to the type the node guarantees (which is a bug) or the value
                // is null.
                if (node.Value is not AsyncQueryable asyncQueryable)
                {
                    throw new InvalidOperationException(); // TODO: Message, exception type   
                }

                // Do the translation.
                var elementType = asyncQueryable.ElementType;
                var queryAdapter = asyncQueryable.QueryAdapter;
                var queryable = queryAdapter.GetQueryable(elementType);

                // TODO: This breaks LSP. Better test for this and if this is not the case, cast to the type.
                Debug.Assert(queryable.GetType().IsAssignableTo(typeof(IQueryable<>).MakeGenericType(elementType)));

                var translatedQuery = new TranslatedQueryable(
                    queryAdapter, elementType, queryable.Expression, queryable.Provider);
                return Expression.Constant(translatedQuery);
            }

            return base.VisitConstant(node);
        }

#if ALLOW_UNSAFE
        [SkipLocalsInit]
#endif
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var method = node.Method;
            var instance = Visit(node.Object);
            var arguments = VisitArguments(node);

            if (instance == node.Object && arguments is null)
            {
                return node;
            }

            // TODO: Adapt comment to new TranslatedQuery type.
            // If the arguments changed while visiting a deeper level, we have to check if 
            // the type of arguments changed. Deeper levels may translate their returns types from IAsyncQueryable to
            // IQueryable to make the subtree database compatible. If this is the case, we cannot use this value, as
            // the method cannot be called with it, due to a type mismatch. To resolve this, we have two options:
            // 1. If possible translate the complete method call to work on type IQueryable instead of type
            //    IAsyncQueryable, to make the current call part of the database compatible subtree
            // 2. Replace the argument with an evaluator, that evaluates the IQueryable, which result in a value of 
            //    type IAsyncEnumerable, which then is wrapped in a special type that implements IAsyncQueryable AND
            //    inherits AsyncQueryable<T> in order to be compatible with the parent method that our return value will 
            //    be an argument of.
            //    We need to inherit AsyncQueryable<T> due to the parent method is not required to have an argument type 
            //    of IAsyncQueryable<T> but may also have an argument type AsyncQueryable<T>, which is the only type
            //    that we translate.

            var queryableTranslationsCount = 0;
            Span<int> translatedQueryableArgumentIndices = stackalloc int[node.Arguments.Count]; // TODO: Possible stack-overflow
            if (arguments is not null) // TODO: We can do this already in the VisitArguments method.
            {
                if (arguments.Count != node.Arguments.Count)
                {
                    throw new InvalidOperationException(); //TODO: Message
                }

                for (var i = 0; i < arguments.Count; i++)
                {
                    // A translation only happens from type IAsyncQueryable (or IAsyncQueryable<T>)
                    if (!node.Arguments[i].Type.IsAssignableTo<IAsyncQueryable>())
                    {
                        continue;
                    }

                    // A translation only happens to type TranslatedQueryable
                    if (arguments[i].Type != typeof(TranslatedQueryable))
                    {
                        continue;
                    }

                    translatedQueryableArgumentIndices[queryableTranslationsCount] = i;
                    queryableTranslationsCount++;
                }
            }

            translatedQueryableArgumentIndices = translatedQueryableArgumentIndices[..queryableTranslationsCount];
            arguments ??= node.Arguments;

            if (queryableTranslationsCount > 0)
            {
                return MethodTranslator.TranslateMethod(
                    method, instance, arguments, translatedQueryableArgumentIndices, _options);
            }

            return Expression.Call(instance, method, arguments);
        }

        // https://github.com/dotnet/runtime/blob/d64c11eabf313cbd52c2f83f89d5a63ad91ddca2/src/libraries/System.Linq.Expressions/src/System/Dynamic/Utils/ExpressionVisitorUtils.cs#L60
        private ReadOnlyCollection<Expression>? VisitArguments(IArgumentProvider nodes)
        {
            Expression[]? newNodes = null;
            for (int i = 0, n = nodes.ArgumentCount; i < n; i++)
            {
                var curNode = nodes.GetArgument(i);
                var node = Visit(curNode);

                if (newNodes != null)
                {
                    newNodes[i] = node;
                }
                else if (!ReferenceEquals(node, curNode))
                {
                    newNodes = new Expression[n];
                    for (var j = 0; j < i; j++)
                    {
                        newNodes[j] = nodes.GetArgument(j);
                    }
                    newNodes[i] = node;
                }
            }

            if (newNodes is not null)
            {
                return new ReadOnlyCollection<Expression>(newNodes);
            }

            return null;
        }
    }
}
