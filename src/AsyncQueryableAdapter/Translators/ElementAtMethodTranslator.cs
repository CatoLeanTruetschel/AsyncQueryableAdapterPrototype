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
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class ElementAtMethodTranslatorBuilder : IMethodTranslatorBuilder
    {
        private static string OperationName => "ElementAt";

        private static string OperationNameOrDefault => OperationName + "OrDefault";

        private static string OperationMethod => OperationName + "Async";

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
            var returnDefaultOnNoMatch = false;

            if (methodName.StartsWith(OperationNameOrDefault, StringComparison.Ordinal))
            {
                methodName = OperationName + methodName[OperationNameOrDefault.Length..];
                returnDefaultOnNoMatch = true;
            }

            if (methodName != OperationMethod)
                return false;

            if (!method.IsGenericMethod)
                return false;

            var genericArguments = method.GetGenericArguments();

            if (genericArguments.Length is not 1)
                return false;

            var sourceType = genericArguments[0];
            var returnType = method.ReturnType;
            var parameters = method.GetParameters();

            if (returnType != TypeHelper.GetValueTaskType(sourceType))
                return false;

            if (parameters.Length is not 3)
                return false;

            if (parameters[^1].ParameterType != typeof(CancellationToken))
                return false;

            if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                return false;

            if (parameters[1].ParameterType != typeof(int))
                return false;

            result = new ElementAtMethodTranslator(returnDefaultOnNoMatch);
            return true;
        }
    }

    internal sealed class ElementAtMethodTranslator : IMethodTranslator
    {
        public ElementAtMethodTranslator(bool returnDefaultOnNoMatch)
        {
            ReturnDefaultOnNoMatch = returnDefaultOnNoMatch;
        }

        public bool ReturnDefaultOnNoMatch { get; }

        public bool TryTranslate(
            in MethodTranslationContext translationContext,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            result = null;

            if (!translationContext.Arguments[0].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                return false;

            if (translatedQueryable is null)
                return false;

            if (!translationContext.Arguments[1].TryEvaluate<int>(out var index))
                return false;

            if (!translationContext.Arguments[^1].TryEvaluate<CancellationToken>(out var cancellationToken))
                return false;

            result = ProcessOperation(translatedQueryable, index, cancellationToken);
            return true;
        }

        private ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            int index,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var queryable = translatedQueryable.GetQueryable();
            var resultType = TypeHelper.GetValueTaskType(elementType);

            AsyncTypeAwaitable evaluationResult;

            if (ReturnDefaultOnNoMatch)
            {
                evaluationResult = translatedQueryable.QueryAdapter.ElementAtOrDefaultAsync(
                    elementType, queryable, index, cancellation);
            }
            else
            {
                evaluationResult = translatedQueryable.QueryAdapter.ElementAtAsync(
                    elementType, queryable, index, cancellation);
            }

            return Expression.Constant(evaluationResult.Instance, resultType);
        }
    }
}
