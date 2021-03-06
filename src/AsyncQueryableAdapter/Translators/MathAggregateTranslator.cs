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
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal abstract class MathAggregateTranslatorBuilder : IMethodTranslatorBuilder
    {
        protected abstract string OperationName { get; }
        protected string OperationMethod => OperationName + "Async";
        protected string OperationAwaitMethod => OperationName + "AwaitAsync";
        protected string OperationAwaitWithCancellationMethod => OperationName + "AwaitWithCancellationAsync";

        protected abstract IMethodTranslator BuildMethodTranslator(bool asyncSelector);

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

            var returnType = method.ReturnType;
            var parameters = method.GetParameters();

            if (!returnType.IsConstructedGenericType)
                return false;

            if (!TypeHelper.IsValueTaskType(returnType, out var resultType))
                return false;

            if (parameters[^1].ParameterType != typeof(CancellationToken))
                return false;

            bool asyncSelector;

            if (method.Name.Equals(OperationMethod, StringComparison.Ordinal))
            {
                // TODO: Is the following true for SumAsync and AverageAsync? Does it matter?
                // {Operation}Async comes in 4 different flavors:
                //
                // A concrete type for the source and result of a set of special types, f.e.:
                // 1. ValueTask<int> {Operation}Async(IAsyncQueryable<int>, CancellationToken)
                //
                // The result and source types are generic and both are of the same type:
                // 2. ValueTask<T> {Operation}Async<T>(IAsyncQueryable<T>, CancellationToken)
                //
                // A concrete type for the result of a set of special types, a generic source type and a 
                // selector, f.e.:
                // 3. ValueTask<int> {Operation}Async<TS>(IAsyncQueryable<TS>, Expression<Func<TS, int>>, CancellationToken)
                //
                // The result and source types are generic and there is a selector:
                // 4. ValueTask<TR> {Operation}Async<TS, TR>(IAsyncQueryable<TS>, Expression<Func<TS, TR>>, CancellationToken)
                //
                // The special types for (1) and (3) are:
                // decimal, decimal?,
                // double, double?,
                // float, float?,
                // int, int?,
                // long, long?

                if (method.IsGenericMethod)
                {
                    var genericArguments = method.GetGenericArguments();
                    var sourceType = genericArguments[0];

                    if (genericArguments.Length is < 1 or > 2)
                        return false;

                    // We are in case 3 or 4.
                    if (parameters.Length is 3)
                    {
                        // We are in case 4
                        if (genericArguments.Length is 2 && genericArguments[1] != resultType)
                            return false;

                        if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                            return false;

                        if (!IsKnownSelector(
                            sourceType, resultType, parameters[1].ParameterType))
                        {
                            return false;
                        }
                    }

                    // We are in case 2
                    else if (genericArguments[0] != resultType)
                    {
                        return false;
                    }
                }
                else
                {
                    // We are in case 1 or 2
                    if (parameters.Length is not 2)
                        return false;

                    if (!TypeHelper.IsAsyncQueryableType(parameters[0].ParameterType, out var sourceType))
                    {
                        return false;
                    }

                    if (resultType != ExpectedResultType(sourceType))
                    {
                        return false;
                    }
                }

                asyncSelector = false;
            }
            else if (method.Name.Equals(OperationAwaitMethod, StringComparison.Ordinal)
                || method.Name.Equals(OperationAwaitWithCancellationMethod, StringComparison.Ordinal))
            {
                // {Operation}AwaitAsync comes in 2 different flavors:
                //
                // A concrete type for the result of a set of special types, a generic source type and a 
                // selector, f.e.:
                // 1a. ValueTask<int> {Operation}Async<TS>(IAsyncQueryable<TS>, Expression<Func<TS, ValueTask<int>>>, CancellationToken)
                //
                // The result and source types are generic and there is a selector:
                // 2a. ValueTask<TR> {Operation}Async<TS, TR>(IAsyncQueryable<TS>, Expression<Func<TS, ValueTask<TR>>>, CancellationToken)
                //
                // {Operation}AwaitWithCancellationAsync comes in 2 different flavors:
                //
                // A concrete type for the result of a set of special types, a generic source type and a 
                // selector, f.e.:
                // 1b. ValueTask<int> {Operation}AwaitWithCancellationAsync<TS>(IAsyncQueryable<TS>, Expression<Func<TS, CancellationToken, ValueTask<int>>>, CancellationToken)
                //
                // The result and source types are generic and there is a selector:
                // 2b. ValueTask<TR> {Operation}AwaitWithCancellationAsync<TS, TR>(IAsyncQueryable<TS>, Expression<Func<TS, CancellationToken, ValueTask<TR>>>, CancellationToken)
                //
                // The special types for (1a) and (1b) are:
                // decimal, decimal?,
                // double, double?,
                // float, float?,
                // int, int?,
                // long, long?

                if (!method.IsGenericMethod)
                    return false;

                var genericArguments = method.GetGenericArguments();
                var sourceType = genericArguments[0];

                if (genericArguments.Length is < 1 or > 2)
                    return false;

                if (genericArguments.Length is 2 && genericArguments[1] != resultType)
                    return false;

                if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                    return false;

                var withCancellation = true;

                if (method.Name.Equals(OperationAwaitMethod, StringComparison.Ordinal))
                {
                    withCancellation = false;
                }

                if (!IsKnownAsyncSelector(
                    sourceType, resultType, parameters[1].ParameterType, withCancellation))
                {
                    return false;
                }

                asyncSelector = true;
            }
            else
            {
                return false;
            }

            result = BuildMethodTranslator(asyncSelector);
            return true;
        }

        protected virtual Type ExpectedResultType(Type sourceType)
        {
            return sourceType;
        }

        private bool IsKnownAsyncSelector(
            Type sourceType,
            Type resultType,
            Type selectorType,
            bool withCancellation)
        {
            if (!TypeHelper.IsLambdaExpression(selectorType, out var selectorDelegateType))
            {
                return false;
            }

            if (!TypeHelper.IsFuncType(
                selectorDelegateType, out var selectorReturnType, out var selectorParameters))
            {
                return false;
            }

            if (selectorParameters.Length is not 1)
            {
                if (selectorParameters.Length is not 2)
                {
                    return false;
                }

                if (!withCancellation)
                    return false;

                if (selectorParameters[^1].ParameterType != typeof(CancellationToken))
                    return false;
            }

            if (selectorParameters[0].ParameterType != sourceType)
            {
                return false;
            }

            if (!TypeHelper.IsValueTaskType(selectorReturnType, out var selectorResultType))
            {
                return false;
            }

            var expectedResultType = ExpectedResultType(selectorResultType);

            if (expectedResultType != resultType)
            {
                return false;
            }

            return true;
        }

        private bool IsKnownSelector(Type sourceType, Type resultType, Type selectorType)
        {
            if (!TypeHelper.IsLambdaExpression(selectorType, out var selectorDelegateType))
            {
                return false;
            }

            if (!TypeHelper.IsFuncType(
                selectorDelegateType, out var selectorReturnType, out var selectorParameters))
            {
                return false;
            }

            if (selectorParameters.Length != 1)
            {
                return false;
            }

            if (selectorParameters[0].ParameterType != sourceType)
            {
                return false;
            }

            var expectedResultType = ExpectedResultType(selectorReturnType);

            if (expectedResultType != resultType)
            {
                return false;
            }

            return true;
        }
    }

    internal abstract class MathAggregateTranslator : IMethodTranslator
    {
        protected MathAggregateTranslator(bool asyncSelector)
        {
            AsyncSelector = asyncSelector;
        }

        protected bool AsyncSelector { get; }

        protected abstract ConstantExpression ProcessOperation(
            Type resultType,
            TranslatedQueryable translatedQueryable,
            Expression? selector,
            CancellationToken cancellation);

        public bool TryTranslate(
            in MethodTranslationContext translationContext,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            result = null;

            var returnType = translationContext.Method.ReturnType;
            var resultTypeDescriptor = AwaitableTypeDescriptor.GetTypeDescriptor(returnType);
            var resultType = resultTypeDescriptor.ResultType;

            if (!translationContext.Arguments[0].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                return false;

            if (translatedQueryable is null)
                return false;

            if (!translationContext.Arguments[^1].TryEvaluate<CancellationToken>(out var cancellationToken))
                return false;

            // No selector
            if (translationContext.Arguments.Count is 2)
            {
                result = ProcessOperation(
                    resultType, translatedQueryable, selector: null, cancellationToken);

                return true;
            }

            var selector = translationContext.Arguments[1];

            if (AsyncSelector)
            {
                var selectorResultType = ((LambdaExpression)selector.Unquote()).ReturnType.GetGenericArguments()[0];

#if DEBUG
                if (!ExpressionTranslator.TryTranslate(
                    selector, translatedQueryable.ElementType, selectorResultType, out selector))
#else
                if (!ExpressionTranslator.TryTranslate(selector, out selector))
#endif
                {
                    return false;
                }
            }

            result = ProcessOperation(resultType, translatedQueryable, selector, cancellationToken);
            return true;
        }
    }
}
