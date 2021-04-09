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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal abstract class MathAggregateTranslator : MethodTranslator
    {
        private readonly CompiledDictionary<MethodInfo, MethodCallEvaluator<Type>> _evaluators;

        public MathAggregateTranslator()
        {
            _evaluators = BuildEvaluators();
        }

        protected abstract string OperationName { get; }

        private CompiledDictionary<MethodInfo, MethodCallEvaluator<Type>> BuildEvaluators()
        {
            var operationMethod = OperationName + "Async";
            var operationAwaitMethod = OperationName + "AwaitAsync";
            var operationAwaitWithCancellationMethod = OperationName + "AwaitWithCancellationAsync";

            var resultBuilder = CompiledDictionary.CreateBuilder<MethodInfo, MethodCallEvaluator<Type>>();
            var asyncQueryableType = typeof(System.Linq.AsyncQueryable);
            var methods = asyncQueryableType.GetMethods(BindingFlags.Static | BindingFlags.Public);

            MethodCallEvaluator<Type>? evaluateSyncSelector = null;
            MethodCallEvaluator<Type>? evaluateAsyncSelector = null;

            foreach (var method in methods)
            {
                var returnType = method.ReturnType;
                var parameters = method.GetParameters();

                if (!returnType.IsConstructedGenericType)
                    continue;

                if (returnType.GetGenericTypeDefinition() != typeof(ValueTask<>))
                    continue;

                if (parameters[^1].ParameterType != typeof(CancellationToken))
                    continue;

                var resultType = returnType.GetGenericArguments().First();

                if (method.Name.Equals(operationMethod, StringComparison.Ordinal))
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
                            continue;

                        // We are in case 3 or 4.
                        if (parameters.Length is 3)
                        {
                            // We are in case 4
                            if (genericArguments.Length is 2 && genericArguments[1] != resultType)
                                continue;

                            if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                                continue;

                            var selectorExpressionType = TypeHelper.GetFuncExpressionType(sourceType, resultType);

                            if (parameters[1].ParameterType != selectorExpressionType)
                                continue;

                            evaluateSyncSelector ??= TryEvaluateSyncSelector;
                            resultBuilder.Add(method, evaluateSyncSelector);
                        }

                        // We are in case 2
                        if (genericArguments[0] != resultType)
                            continue;
                    }

                    // We are in case 1 or 2
                    if (parameters.Length is not 2)
                        continue;

                    if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(resultType))
                        continue;

                    evaluateSyncSelector ??= TryEvaluateSyncSelector;
                    resultBuilder.Add(method, evaluateSyncSelector);
                }
                else if (method.Name.Equals(operationAwaitMethod, StringComparison.Ordinal)
                    || method.Name.Equals(operationAwaitWithCancellationMethod, StringComparison.Ordinal))
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
                        continue;

                    var genericArguments = method.GetGenericArguments();
                    var sourceType = genericArguments[0];

                    if (genericArguments.Length is < 1 or > 2)
                        continue;

                    if (genericArguments.Length is 2 && genericArguments[1] != resultType)
                        continue;

                    if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                        continue;

                    var selectorReturnType = TypeHelper.GetValueTaskType(resultType);
                    Type selectorExpressionType;

                    if (method.Name.Equals(operationAwaitMethod, StringComparison.Ordinal))
                    {
                        selectorExpressionType = TypeHelper.GetFuncExpressionType(sourceType, selectorReturnType);
                    }
                    else
                    {
                        selectorExpressionType = TypeHelper.GetFuncExpressionType(
                            sourceType, typeof(CancellationToken), selectorReturnType);
                    }

                    if (parameters[1].ParameterType != selectorExpressionType)
                        continue;

                    evaluateAsyncSelector ??= TryEvaluateAsyncSelector;
                    resultBuilder.Add(method, evaluateAsyncSelector);
                }
            }

            return resultBuilder.Build();
        }

        public sealed override bool TryTranslate(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            [NotNullWhen(true)] out Expression? result)
        {
            var resultType = method.ReturnType;
            var resultTypeDescriptor = AwaitableTypeDescriptor.GetTypeDescriptor(resultType);

            if (method.IsGenericMethod)
            {
                method = method.GetGenericMethodDefinition();
            }

            result = null;

            return _evaluators.TryGetValue(method, out var evaluator) && evaluator(
                arguments, 
                resultTypeDescriptor.ResultType, 
                out Unsafe.As<Expression, ConstantExpression>(ref result!)!);
        }

        private bool TryEvaluateSyncSelector(
            ReadOnlyCollection<Expression> arguments,
            Type resultType,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            return TryEvaluate(arguments, processAsyncSelector: false, resultType, out result);
        }

        private bool TryEvaluateAsyncSelector(
           ReadOnlyCollection<Expression> arguments,
           Type resultType,
           [NotNullWhen(true)] out ConstantExpression? result)
        {
            return TryEvaluate(arguments, processAsyncSelector: true, resultType, out result);
        }

        private bool TryEvaluate(
            ReadOnlyCollection<Expression> arguments,
            bool processAsyncSelector,
            Type resultType,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            result = null;

            if (!arguments[0].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                return false;

            if (translatedQueryable is null)
                return false;

            if (!arguments[^1].TryEvaluate<CancellationToken>(out var cancellationToken))
                return false;

            // No selector
            if (arguments.Count is 2)
            {
                result = ProcessOperation(
                    translatedQueryable, cancellationToken);

                return true;
            }

            var selector = arguments[1];

            if (processAsyncSelector && !selector.TryTranslateExpressionToSync(
                translatedQueryable.ElementType, resultType, out selector))
            {
                return false;
            }

            result = ProcessOperation(resultType, translatedQueryable, selector, cancellationToken);
            return true;
        }

        protected abstract ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            CancellationToken cancellation);

        protected abstract ConstantExpression ProcessOperation(
            Type resultType,
            TranslatedQueryable translatedQueryable,
            Expression selector,
            CancellationToken cancellation);
    }
}
