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

using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal abstract class PredicateAggregateTranslatorBuilder : IMethodTranslatorBuilder
    {
        protected abstract string OperationName { get; }

        protected string OperationMethod => OperationName + "Async";
        protected string OperationAwaitMethod => OperationName + "AwaitAsync";
        protected string OperationAwaitWithCancellationMethod => OperationName + "AwaitWithCancellationAsync";

        protected abstract bool PredicateRequired { get; }

        protected abstract Type ResultType { get; }

        protected abstract IMethodTranslator BuildMethodTranslator(bool asyncPredicate);

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

            if (!method.IsGenericMethod)
                return false;

            var genericArguments = method.GetGenericArguments();

            if (genericArguments.Length is not 1)
                return false;

            var sourceType = genericArguments[0];
            var returnType = method.ReturnType;
            var parameters = method.GetParameters();

            if (returnType != TypeHelper.GetValueTaskType(ResultType))
                return false;

            if (parameters.Length is < 2 or > 3)
                return false;

            if (PredicateRequired && parameters.Length is not 3)
                return false;

            // Last parameter is of type CancellationToken
            if (parameters[^1].ParameterType != typeof(CancellationToken))
                return false;

            // First parameter is of type IAsyncQueryable<TSource>
            if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                return false;

            bool asyncPredicate;

            if (parameters.Length is 3)
            {
                var predicateParameterType = parameters[1].ParameterType;
                Type expectedPredicateType;

                if (string.Equals(methodName, OperationMethod, StringComparison.Ordinal))
                {
                    // Sync predicate
                    expectedPredicateType = TypeHelper.GetFuncExpressionType(sourceType, typeof(bool));

                    if (predicateParameterType != expectedPredicateType)
                        return false;

                    asyncPredicate = false;
                }
                else if (string.Equals(methodName, OperationAwaitMethod, StringComparison.Ordinal))
                {
                    // Async predicate
                    expectedPredicateType = TypeHelper.GetFuncExpressionType(sourceType, typeof(ValueTask<bool>));

                    if (predicateParameterType != expectedPredicateType)
                        return false;

                    asyncPredicate = true;
                }
                else if (string.Equals(methodName, OperationAwaitWithCancellationMethod, StringComparison.Ordinal))
                {
                    // Async predicate with cancellation
                    expectedPredicateType = TypeHelper.GetFuncExpressionType(
                        sourceType,
                        typeof(CancellationToken),
                        typeof(ValueTask<bool>));

                    if (predicateParameterType != expectedPredicateType)
                        return false;

                    asyncPredicate = true;
                }
                else
                {
                    return false;
                }
            }
            else if (PredicateRequired)
            {
                return false;
            }
            else // if(parameters.Length is 2)
            {
                // No predicate
                if (!string.Equals(methodName, OperationMethod, StringComparison.Ordinal))
                    return false;

                asyncPredicate = false;
            }

            result = BuildMethodTranslator(asyncPredicate);
            return true;
        }
    }

    internal abstract class PredicateAggregateTranslator : IMethodTranslator
    {
        protected PredicateAggregateTranslator(bool asyncPredicate)
        {
            AsyncPredicate = asyncPredicate;
        }

        protected bool AsyncPredicate { get; }

        protected abstract ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Expression? predicate,
            CancellationToken cancellation);

        public bool TryTranslate(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            [NotNullWhen(true)] out Expression? result)
        {
            result = null;

            if (!arguments[0].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                return false;

            if (translatedQueryable is null)
                return false;

            if (!arguments[^1].TryEvaluate<CancellationToken>(out var cancellationToken))
                return false;

            // No predicate
            if (arguments.Count is 2)
            {
                result = ProcessOperation(
                    translatedQueryable, null, cancellationToken);

                return true;
            }

            var selector = arguments[1];

            if (AsyncPredicate && !selector.TryTranslateExpressionToSync(
              translatedQueryable.ElementType, typeof(bool), out selector))
            {
                return false;
            }

            result = ProcessOperation(translatedQueryable, selector, cancellationToken);
            return true;
        }
    }
}
