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
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class ContainsMethodTranslatorBuilder : IMethodTranslatorBuilder
    {
        private string OperationName { get; } = "Contains";
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

            // Second parameter is of type TSource
            if (parameters[1].ParameterType != sourceType)
                return false;

            // If there are 4 parameters, the third parameter is of type IEqualityComparer<TSource>
            if (parameters.Length is 4
                && parameters[2].ParameterType != TypeHelper.GetEqualityComparerType(sourceType))
            {
                return false;
            }

            result = new ContainsMethodTranslator();
            return true;
        }
    }

    internal sealed class ContainsMethodTranslator : IMethodTranslator
    {
        public bool TryTranslate(
            in MethodTranslationContext translationContext,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            result = null;

            var hasEqualityComparer = translationContext.Arguments.Count is 4;

            if (!translationContext.Arguments[^1].TryEvaluate<CancellationToken>(out var cancellationToken))
                return false;

            if (!translationContext.Arguments[0].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                return false;

            if (translatedQueryable is null)
                return false;

            var elementType = translatedQueryable.ElementType;
            var queryable = translatedQueryable.GetQueryable();
            var untypedValue = translationContext.Arguments[1].Evaluate();

            // TODO: Is it allowed that value is null?
            //if (untypedValue is null)
            //    return false;

            var comparer = hasEqualityComparer ? translationContext.Arguments[2].Evaluate() : null;

            var evaluationResult = translatedQueryable.QueryAdapter.ContainsAsync(
                elementType,
                queryable,
                untypedValue!,
                comparer,
                cancellationToken);

            result = Expression.Constant(evaluationResult, typeof(ValueTask<bool>));
            return true;
        }
    }
}
