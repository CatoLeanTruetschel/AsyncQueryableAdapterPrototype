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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class SequenceEqualMethodTranslatorBuilder : IMethodTranslatorBuilder
    {
        private string OperationName { get; } = "SequenceEqual";
        private string OperationMethod => OperationName + "Async";

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

            if (!string.Equals(methodName, OperationMethod, StringComparison.Ordinal))
                return false;

            if (!method.IsGenericMethod)
                return false;

            var genericArguments = method.GetGenericArguments();

            if (genericArguments.Length is not 1)
                return false;

            var sourceType = genericArguments[0];
            var returnType = method.ReturnType;
            var parameters = method.GetParameters();

            if (returnType != typeof(ValueTask<bool>))
                return false;

            if (parameters.Length is < 3 or > 4)
                return false;

            // Last parameter is of type CancellationToken
            if (parameters[^1].ParameterType != typeof(CancellationToken))
                return false;

            // First parameter is of type IAsyncQueryable<TSource>
            if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                return false;

            // Second parameter is of type IAsyncEnumerable<TSource>
            if (parameters[1].ParameterType != TypeHelper.GetAsyncEnumerableType(sourceType))
                return false;

            // If there are 4 parameters, the third parameter is of type IEqualityComparer<TSource>
            if (parameters.Length is 4
                && parameters[2].ParameterType != TypeHelper.GetEqualityComparerType(sourceType))
            {
                return false;
            }

            result = new SequenceEqualMethodTranslator();
            return true;
        }
    }

    internal sealed class SequenceEqualMethodTranslator : IMethodTranslator
    {
        public bool TryTranslate(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            [NotNullWhen(true)] out Expression? result)
        {
            result = null;

            var hasEqualityComparer = arguments.Count is 4;

            if (!arguments[^1].TryEvaluate<CancellationToken>(out var cancellationToken))
                return false;

            if (!arguments[0].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                return false;

            if (translatedQueryable is null)
                return false;

            var elementType = translatedQueryable.ElementType;
            var queryable = translatedQueryable.GetQueryable();
            var untypedSecond = arguments[1].Evaluate();

            if (untypedSecond is null)
                return false;

            ValueTask<bool> evaluationResult;
            var comparer = hasEqualityComparer ? arguments[2].Evaluate() : null;

            if (untypedSecond is TranslatedQueryable translatedSecond)
            {
                if (translatedSecond.QueryAdapter != translatedQueryable.QueryAdapter)
                {
                    // TODO: We can support this, with pre-evaluation of second.
                    //       This should be protected with a flag in the options however.
                    throw new NotSupportedException("Unable to combine queries of different query-adapters."); // TODO
                }

                var secondQueryable = translatedSecond.GetQueryable();

                evaluationResult = translatedQueryable.QueryAdapter.SequenceEqualAsync(
                    elementType,
                    queryable,
                    secondQueryable,
                    comparer,
                    cancellationToken);
            }
            else
            {
                Debug.Assert(untypedSecond.GetType().IsAssignableTo(TypeHelper.GetAsyncEnumerableType(elementType)));

                if (untypedSecond is not IAsyncEnumerable<object> second)
                {
                    second = AsyncEnumerableExtension.Cast<object>(untypedSecond, elementType);
                }

                evaluationResult = translatedQueryable.QueryAdapter.SequenceEqualAsync(
                    elementType,
                    queryable,
                    second,
                    comparer,
                    cancellationToken);
            }

            result = Expression.Constant(evaluationResult, typeof(ValueTask<bool>));
            return true;
        }
    }
}
