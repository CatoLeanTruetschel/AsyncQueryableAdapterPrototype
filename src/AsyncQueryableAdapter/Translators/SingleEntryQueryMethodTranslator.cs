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
    internal abstract class SingleEntryQueryMethodTranslatorBuilder : IMethodTranslatorBuilder
    {
        protected abstract string OperationName { get; }
        protected string OperationNameOrDefault => OperationName + "OrDefault";
        protected string OperationMethod => OperationName + "Async";
        protected string OperationAwaitMethod => OperationName + "AwaitAsync";
        protected string OperationAwaitWithCancellationMethod => OperationName + "AwaitWithCancellationAsync";

        protected abstract IMethodTranslator BuildMethodTranslator(bool asyncPredicate, bool returnDefaultOnNoMatch);

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

            if (parameters.Length is < 2 or > 3)
                return false;

            if (parameters[^1].ParameterType != typeof(CancellationToken))
                return false;

            if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                return false;

            bool asyncPredicate;

            if (methodName == OperationAwaitMethod)
            {
                if (parameters.Length is not 3)
                {
                    return false;
                }

                // typeof(Expression<Func<TSource, ValueTask<bool>>>)
                var predicateExpressionType = TypeHelper.GetAsyncPredicateType(sourceType);

                if (parameters[1].ParameterType != predicateExpressionType)
                    return false;

                asyncPredicate = true;
            }
            else if (methodName == OperationAwaitWithCancellationMethod)
            {
                if (parameters.Length is not 3)
                {
                    return false;
                }

                // typeof(Expression<Func<TSource, ValueTask<bool>>>)
                var selectorExpressionType = TypeHelper.GetAsyncPredicateWithCancellationType(sourceType);

                if (parameters[1].ParameterType != selectorExpressionType)
                    return false;

                asyncPredicate = true;
            }
            else if (methodName == OperationMethod)
            {
                if (parameters.Length is 3)
                {
                    // typeof(Expression<Func<TSource, bool>>)
                    var selectorExpressionType = TypeHelper.GetPredicateType(sourceType);

                    if (parameters[1].ParameterType != selectorExpressionType)
                        return false;
                }

                asyncPredicate = false;
            }
            else
            {
                return false;
            }

            result = BuildMethodTranslator(asyncPredicate, returnDefaultOnNoMatch);
            return true;
        }
    }

    internal abstract class SingleEntryQueryMethodTranslator : IMethodTranslator
    {
        public SingleEntryQueryMethodTranslator(bool asyncPredicate, bool returnDefaultOnNoMatch)
        {
            AsyncPredicate = asyncPredicate;
            ReturnDefaultOnNoMatch = returnDefaultOnNoMatch;
        }

        protected bool AsyncPredicate { get; }
        protected bool ReturnDefaultOnNoMatch { get; }

        public bool TryTranslate(
            in MethodTranslationContext translationContext,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            result = null;

            if (!translationContext.Arguments[0].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                return false;

            if (translatedQueryable is null)
                return false;

            if (!translationContext.Arguments[^1].TryEvaluate<CancellationToken>(out var cancellationToken))
                return false;

            if (translationContext.Arguments.Count is 2)
            {
                result = ProcessOperation(translatedQueryable, predicate: null, cancellationToken);

                return true;
            }

            var predicate = translationContext.Arguments[1];

            if (AsyncPredicate && !predicate.TryTranslateExpressionToSync(
                translatedQueryable.ElementType, typeof(bool), out predicate))
            {
                return false;
            }

            result = ProcessOperation(translatedQueryable, predicate, cancellationToken);

            return true;
        }

        protected abstract ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Expression? predicate,
            CancellationToken cancellation);
    }
}
