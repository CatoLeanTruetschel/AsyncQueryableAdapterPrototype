// License
// --------------------------------------------------------------------------------------------------------------------
// (C) Copyright 2021 Cato Léan Trütschel and contributors
// (github.com/CatoLeanTruetschel/AsyncQueryableAdapterPrototype)
//
// Licensed under the Apache License, Version 2.0 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// --------------------------------------------------------------------------------------------------------------------

/*
 * GroupBy is a very special case, as it is the only chain-able operation (i.e. an operation that itself returns
 * a query-able type that has not the same result-type in the synchronous (IQueryable) and asynchronous case
 * (IAsyncQueryable).
 * All other operations can be put into one of two groups:
 * (1) Non-chainable operation (i.e. an operation that returns a non query-able type, like int, double, Array<T>, etc.)
 *     These operations typically return ValueTask<T> in the asynchronous case and T in the synchronous case. But this
 *     isn't even a necessary condition, as these operations cannot be chained anyway, the result has to be processed
 *     in-memory after query-execution by the caller.
 * (2) Chainable operation that return IAsyncQueryable<T> in the asynchronous case and IQueryable<T> in the synchronous
 *     case.
 *     
 * The GroupBy operation (as the only operation) does not belong to any of these two groups of operations, as it is a
 * chain-able operation that returns IAsyncQueryable<IAsyncGrouping<TKEy, TElement>> in the asynchronous case
 * and IQueryable<IGrouping<TKey, TElement>> in the synchronous case.  
 * 
 * To implement a translation for the operation, we have to possible options:
 * 
 * (1) We have to translate the asynchronous GroupBy operation to 
 * a synchronous GroupBy operation followed by a Select operation that transforms the synchronous 
 * IGrouping<TKey, TElement> results into asynchronous IAsyncGrouping<TKey, TElement> results by using a wrapper type.
 * As we do not expect this operation to be supported by any database driver, we translate the operation only to a 
 * synchronous GroupBy operation, executing the query and perform the translation in-memory.
 * This has the MAJOR drawback, as all chained operations, i.e. all operations that work on the result of the GroupBy
 * operation needs to be performed in-memory.
 * 
 * (2) We translate the asynchronous GroupBy operation to a synchronous GroupBy operation and put a special result into
 * the expression tree instead of the TranslatedQueryable that is used in the case of all other chain-able operations.
 * All chained operations (including any possible chained GroupBy operations themselves) need to respect this special 
 * condition and act accordingly, by passing the "wrong" translated type down the expression tree.
 * This needs an excessive amount of tests and the recognition of the special case in all other translators.
 * 
 * Currently, option (2) is implemented due to perf reasons.
 * 
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class GroupByMethodTranslatorBuilder : IMethodTranslatorBuilder
    {
        private static string OperationName => "GroupBy";
        private static string OperationMethod => OperationName;
        //private static string OperationAwaitMethod => OperationName + "AwaitAsync";
        //private static string OperationAwaitWithCancellationMethod => OperationName + "AwaitWithCancellationAsync";

        public bool TryBuildMethodTranslator(MethodInfo method, [NotNullWhen(true)] out IMethodTranslator? result)
        {
            result = null;

            if (method is null)
                throw new ArgumentNullException(nameof(method));

            if (method.IsGenericMethod)
            {
                method = method.GetGenericMethodDefinition();
            }

            if (method.DeclaringType != typeof(System.Linq.AsyncQueryable))
            {
                return false;
            }

            var methodName = method.Name;

            // (1) IAsyncQueryable<IAsyncGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
            //         this IAsyncQueryable<TSource> source,
            //         Expression<Func<TSource, TKey>> keySelector)

            // TODO: Implement all the other overloads

            if (methodName != OperationMethod)
                return false;

            if (!method.IsGenericMethod)
                return false;

            var genericArguments = method.GetGenericArguments();

            if (genericArguments.Length is not 2)
                return false;

            var sourceType = genericArguments[0];
            var keyType = genericArguments[1];
            var returnType = method.ReturnType;
            var parameters = method.GetParameters();

            // IAsyncQueryable<IAsyncGrouping<TKey, TSource>>
            var expectedReturnType = TypeHelper.GetAsyncQueryableType(
                TypeHelper.GetAsyncGroupingType(keyType, sourceType));

            if (returnType != expectedReturnType)
                return false;

            if (parameters.Length is not 2)
                return false;

            if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                return false;

            var expectedKeySelectorType = TypeHelper.GetFuncExpressionType(sourceType, keyType);

            if (parameters[1].ParameterType != expectedKeySelectorType)
                return false;

            result = new GroupByMethodTranslator();
            return true;
        }
    }

    internal sealed class GroupByMethodTranslator : IMethodTranslator
    {
        [ThreadStatic]
        private static List<Expression>? _argumentsBuffer;

        public bool TryTranslate(
            in MethodTranslationContext translationContext,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            result = null;

            if (!translationContext.Arguments[0].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                return false;

            if (translatedQueryable is null)
                return false;

            var keySelector = translationContext.Arguments[1];

            // TODO: Can we get the type from somewhere else cheaper?
            var keyType = translationContext.Method.GetGenericArguments()[1];

            result = ProcessOperation(translatedQueryable, keyType, keySelector);
            return true;
        }

        // System.Linq.Queryable.IQueryable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
        //     IQueryable<TSource> source,
        //     Expression<Func<TSource, TKey>> keySelector)
        private static readonly MethodInfo _groupByMethodDefinition =
            new GroupByMethod<object, object>(System.Linq.Queryable.GroupBy).Method.GetGenericMethodDefinition();

        private delegate IQueryable<IGrouping<TKey, TSource>> GroupByMethod<TKey, TSource>(
           IQueryable<TSource> source,
           Expression<Func<TSource, TKey>> keySelector);

        private static ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Type keyType,
            Expression keySelector)
        {
            var translatedArguments = _argumentsBuffer ??= new List<Expression>();
            translatedArguments.Clear();

            translatedArguments.Add(translatedQueryable.Expression);
            translatedArguments.Add(keySelector);

            var translatedExpression = Expression.Call(
                instance: null,
                _groupByMethodDefinition.MakeGenericMethod(translatedQueryable.ElementType, keyType),
                translatedArguments);

            // The result element type is the same as the source element type. This is NOT the grouping type!
            var elementType = translatedQueryable.ElementType;

            var resultTranslatedQueryable = new TranslatedGroupByQueryable(
                translatedQueryable.QueryAdapter,
                keyType,
                elementType,
                translatedExpression,
                translatedQueryable.QueryProvider);

            return Expression.Constant(resultTranslatedQueryable);
        }
    }
}
