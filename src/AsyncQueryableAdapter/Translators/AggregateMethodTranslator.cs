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
    internal sealed class AggregateMethodTranslatorBuilder : IMethodTranslatorBuilder
    {
        private static string OperationName => "Aggregate";
        private static string OperationMethod => OperationName + "Async";
        private static string OperationAwaitMethod => OperationName + "AwaitAsync";
        private static string OperationAwaitWithCancellationMethod => OperationName + "AwaitWithCancellationAsync";

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
            var sourceType = genericArguments[0];
            var returnType = method.ReturnType;
            var parameters = method.GetParameters();

            if (parameters[^1].ParameterType != typeof(CancellationToken))
                return false;

            if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                return false;

            // Handled method overloads:
            // (1) ValueTask<TSource> AggregateAsync<TSource>(IAsyncQueryable<TSource>, Expression<Func<TSource, TSource, TSource>>, CancellationToken)
            // (2) ValueTask<TAccumulate> AggregateAsync<TSource, TAccumulate>(IAsyncQueryable<TSource>, TAccumulate, Expression<Func<TAccumulate, TSource, TAccumulate>>, CancellationToken)
            // (3) ValueTask<TResult> AggregateAsync<TSource, TAccumulate, TResult>(IAsyncQueryable<TSource>, TAccumulate, Expression<Func<TAccumulate, TSource, TAccumulate>>, Expression<Func<TAccumulate, TResult>>, CancellationToken)
            // (4) ValueTask<TSource> AggregateAwaitAsync<TSource>(IAsyncQueryable<TSource>, Expression<Func<TSource, TSource, ValueTask<TSource>>>, CancellationToken)
            // (5) ValueTask<TAccumulate> AggregateAwaitAsync<TSource, TAccumulate>(IAsyncQueryable<TSource>, TAccumulate, Expression<Func<TAccumulate, TSource, ValueTask<TAccumulate>>>, CancellationToken)
            // (6) ValueTask<TResult> AggregateAwaitAsync<TSource, TAccumulate, TResult>(IAsyncQueryable<TSource>, TAccumulate, Expression<Func<TAccumulate, TSource, ValueTask<TAccumulate>>>, Expression<Func<TAccumulate, ValueTask<TResult>>>, CancellationToken)
            // (7) ValueTask<TSource> AggregateAwaitWithCancellationAsync<TSource>(IAsyncQueryable<TSource>, Expression<Func<TSource, TSource, CancellationToken, ValueTask<TSource>>>, CancellationToken)
            // (8) ValueTask<TAccumulate> AggregateAwaitWithCancellationAsync<TSource, TAccumulate>(IAsyncQueryable<TSource>, TAccumulate, Expression<Func<TAccumulate, TSource, CancellationToken, ValueTask<TAccumulate>>>, CancellationToken)
            // (9) ValueTask<TResult> AggregateAwaitWithCancellationAsync<TSource, TAccumulate, TResult>(IAsyncQueryable<TSource>, TAccumulate, Expression<Func<TAccumulate, TSource, CancellationToken, ValueTask<TAccumulate>>>, Expression<Func<TAccumulate, CancellationToken, ValueTask<TResult>>>, CancellationToken)

            bool asyncFunctions, withCancellation;

            if (string.Equals(methodName, OperationMethod, StringComparison.Ordinal)) // Cases 1 to 3
            {
                asyncFunctions = false;
                withCancellation = false;
            }
            else if (string.Equals(methodName, OperationAwaitMethod, StringComparison.Ordinal)) // Cases 4 to 6
            {
                asyncFunctions = true;
                withCancellation = false;
            }
            else if (string.Equals(methodName, OperationAwaitWithCancellationMethod, StringComparison.Ordinal)) // Cases 7 to 9
            {
                asyncFunctions = true;
                withCancellation = true;
            }
            else
            {
                return false;
            }

            if (genericArguments.Length is 1) // Cases 1, 4, 7
            {
                if (returnType != TypeHelper.GetValueTaskType(genericArguments[0]))
                    return false;

                if (parameters.Length is not 3)
                    return false;

                Type accumulatorType;

                if (!asyncFunctions)
                {
                    // Expression<Func<TSource, TSource, TSource>>
                    accumulatorType = TypeHelper.GetFuncExpressionType(
                        genericArguments[0], genericArguments[0], genericArguments[0]);
                }
                else if (!withCancellation)
                {
                    // Expression<Func<TSource, TSource, ValueTask<TSource>>>
                    accumulatorType = TypeHelper.GetFuncExpressionType(
                        genericArguments[0], genericArguments[0], TypeHelper.GetValueTaskType(genericArguments[0]));
                }
                else
                {
                    // Expression<Func<TSource, TSource, CancellationToken, ValueTask<TSource>>>
                    accumulatorType = TypeHelper.GetFuncExpressionType(
                        genericArguments[0],
                        genericArguments[0],
                        typeof(CancellationToken),
                        TypeHelper.GetValueTaskType(genericArguments[0]));
                }

                if (parameters[1].ParameterType != accumulatorType)
                    return false;
            }
            else
            {
                if (genericArguments.Length is 2) // Cases 2, 5, 8
                {
                    if (returnType != TypeHelper.GetValueTaskType(genericArguments[1]))
                        return false;

                    if (parameters.Length is not 4)
                        return false;
                }
                else if (genericArguments.Length is 3) // Cases 3, 6, 9
                {
                    if (returnType != TypeHelper.GetValueTaskType(genericArguments[2]))
                        return false;

                    if (parameters.Length is not 5)
                        return false;

                    Type resultSelectorType;

                    if (!asyncFunctions)
                    {
                        // Expression<Func<TAccumulate, TResult>>
                        resultSelectorType = TypeHelper.GetFuncExpressionType(
                            genericArguments[1], genericArguments[2]);
                    }
                    else if (!withCancellation)
                    {
                        // Expression<Func<TAccumulate, ValueTask<TResult>>>
                        resultSelectorType = TypeHelper.GetFuncExpressionType(
                            genericArguments[1], TypeHelper.GetValueTaskType(genericArguments[2]));
                    }
                    else
                    {
                        // Expression<Func<TAccumulate, CancellationToken, ValueTask<TResult>>>
                        resultSelectorType = TypeHelper.GetFuncExpressionType(
                            genericArguments[1],
                            typeof(CancellationToken),
                            TypeHelper.GetValueTaskType(genericArguments[2]));
                    }

                    if (parameters[3].ParameterType != resultSelectorType)
                        return false;
                }
                else
                {
                    return false;
                }

                if (parameters[1].ParameterType != genericArguments[1])
                    return false;

                Type accumulatorType;

                if (!asyncFunctions)
                {
                    // Expression<Func<TAccumulate, TSource, TAccumulate>>
                    accumulatorType = TypeHelper.GetFuncExpressionType(
                        genericArguments[1], genericArguments[0], genericArguments[1]);
                }
                else if (!withCancellation)
                {
                    // Expression<Func<TAccumulate, TSource, ValueTask<TAccumulate>>>
                    accumulatorType = TypeHelper.GetFuncExpressionType(
                        genericArguments[1], genericArguments[0], TypeHelper.GetValueTaskType(genericArguments[1]));
                }
                else
                {
                    // Expression<Func<TAccumulate, TSource, CancellationToken, ValueTask<TAccumulate>>>
                    accumulatorType = TypeHelper.GetFuncExpressionType(
                        genericArguments[1],
                        genericArguments[0],
                        typeof(CancellationToken),
                        TypeHelper.GetValueTaskType(genericArguments[1]));
                }

                if (parameters[2].ParameterType != accumulatorType)
                    return false;
            }

            result = new AggregateMethodTranslator(asyncFunctions);
            return true;
        }
    }

    internal sealed class AggregateMethodTranslator : IMethodTranslator
    {
        public AggregateMethodTranslator(bool asyncFunctions)
        {
            AsyncFunctions = asyncFunctions;
        }

        public bool AsyncFunctions { get; }

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

            var elementType = translatedQueryable.ElementType;
            var queryable = translatedQueryable.GetQueryable();
            var returnType = translationContext.Method.ReturnType;
            AsyncTypeAwaitable evaluationResult;

            if (translationContext.Arguments.Count is 3) // Cases 1, 4, 7
            {
                var accumulator = translationContext.Arguments[1];

                if (AsyncFunctions && !ExpressionTranslator.TryTranslateExpressionToSync(
                    accumulator,
                    elementType,
                    elementType,
                    elementType,
                    out accumulator))
                {
                    return false;
                }

                evaluationResult = translatedQueryable.QueryAdapter.AggregateAsync(
                    elementType,
                    queryable,
                    accumulator,
                    cancellationToken);
            }
            else
            {
                var resultTypeDescriptor = AwaitableTypeDescriptor.GetTypeDescriptor(returnType);
                var resultType = resultTypeDescriptor.ResultType;

                Type accumulateType;
                Expression? resultSelector = null;

                if (translationContext.Arguments.Count is 5) // Cases 3, 6, 9
                {
                    // TODO: Can we access this without requesting the generic arguments for perf reasons?
                    accumulateType = translationContext.Method.GetGenericArguments()[1];

                    resultSelector = translationContext.Arguments[3];

                    if (AsyncFunctions && !ExpressionTranslator.TryTranslateExpressionToSync(
                        resultSelector,
                        accumulateType,
                        resultType,
                        out resultSelector))
                    {
                        return false;
                    }
                }
                else if (translationContext.Arguments.Count is 4) // Cases 2, 5, 8
                {
                    accumulateType = resultType;
                }
                else
                {
                    return false;
                }

                var seed = translationContext.Arguments[1].Evaluate();
                var accumulator = translationContext.Arguments[2];

                if (AsyncFunctions && !ExpressionTranslator.TryTranslateExpressionToSync(
                    accumulator,
                    accumulateType,
                    elementType,
                    accumulateType,
                    out accumulator))
                {
                    return false;
                }

                if (translationContext.Arguments.Count is 4) // Cases 3, 6, 9
                {
                    evaluationResult = translatedQueryable.QueryAdapter.AggregateAsync(
                        elementType,
                        accumulateType,
                        queryable,
                        seed,
                        accumulator,
                        cancellationToken);
                }
                else // Cases 2, 5, 8
                {
                    evaluationResult = translatedQueryable.QueryAdapter.AggregateAsync(
                        elementType,
                        accumulateType,
                        resultType,
                        queryable,
                        seed,
                        accumulator,
                        resultSelector!, // TODO: Refactor me pls.
                        cancellationToken);
                }
            }

            result = Expression.Constant(evaluationResult.Instance, returnType);
            return true;
        }
    }
}
