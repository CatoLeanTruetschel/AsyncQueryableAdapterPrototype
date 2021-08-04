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
using System.Runtime.CompilerServices;
using System.Threading;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal abstract class SingleEntryQueryMethodTranslator : MethodTranslator
    {
        private readonly CompiledDictionary<MethodInfo, MethodCallEvaluator> _evaluators;

        public SingleEntryQueryMethodTranslator()
        {
            _evaluators = BuildEvaluators();
        }

        protected abstract string OperationName { get; }

        private CompiledDictionary<MethodInfo, MethodCallEvaluator> BuildEvaluators()
        {
            var operationNameOrDefault = OperationName + "OrDefault";
            var operationMethod = OperationName + "Async";
            var operationAwaitMethod = OperationName + "AwaitAsync";
            var operationAwaitWithCancellationMethod = OperationName + "AwaitWithCancellationAsync";
            var resultBuilder = CompiledDictionary.CreateBuilder<MethodInfo, MethodCallEvaluator>();
            var asyncQueryableType = typeof(System.Linq.AsyncQueryable);
            var methods = asyncQueryableType.GetMethods(BindingFlags.Static | BindingFlags.Public);

            MethodCallEvaluator? evaluateSyncPredicate = null;
            MethodCallEvaluator? evaluateSyncPredicateOrDefault = null;
            MethodCallEvaluator? evaluateAsyncPredicate = null;
            MethodCallEvaluator? evaluateAyncPredicateOrDefault = null;

            foreach (var method in methods)
            {
                var methodName = method.Name;
                var returnsDefaultOnNoMatch = false;

                if (methodName.StartsWith(operationNameOrDefault, StringComparison.Ordinal))
                {
                    methodName = OperationName + methodName.Substring(operationNameOrDefault.Length);
                    returnsDefaultOnNoMatch = true;
                }

                if (!method.IsGenericMethod)
                    continue;

                var genericArguments = method.GetGenericArguments();

                if (genericArguments.Length is not 1)
                    continue;

                var sourceType = genericArguments[0];
                var returnType = method.ReturnType;
                var parameters = method.GetParameters();

                if (returnType != TypeHelper.GetValueTaskType(sourceType))
                    continue;

                if (parameters.Length is < 2 or > 3)
                    continue;

                if (parameters[^1].ParameterType != typeof(CancellationToken))
                    continue;

                if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                    continue;

                if (methodName == operationAwaitMethod)
                {
                    if (parameters.Length is not 3)
                    {
                        continue;
                    }

                    // typeof(Expression<Func<TSource, ValueTask<bool>>>)
                    var predicateExpressionType = TypeHelper.GetAsyncPredicateType(sourceType);

                    if (parameters[1].ParameterType != predicateExpressionType)
                        continue;

                    if (!returnsDefaultOnNoMatch)
                    {
                        evaluateAsyncPredicate ??= TryEvaluateAsyncPredicate;
                        resultBuilder.Add(method, evaluateAsyncPredicate);
                    }
                    else
                    {
                        evaluateAyncPredicateOrDefault ??= TryEvaluateAsyncPredicateOrDefault;
                        resultBuilder.Add(method, evaluateAyncPredicateOrDefault);
                    }
                }
                else if (methodName == operationAwaitWithCancellationMethod)
                {
                    if (parameters.Length is not 3)
                    {
                        continue;
                    }

                    // typeof(Expression<Func<TSource, ValueTask<bool>>>)
                    var selectorExpressionType = TypeHelper.GetAsyncPredicateWithCancellationType(sourceType);

                    if (parameters[1].ParameterType != selectorExpressionType)
                        continue;

                    if (!returnsDefaultOnNoMatch)
                    {
                        evaluateAsyncPredicate ??= TryEvaluateAsyncPredicate;
                        resultBuilder.Add(method, evaluateAsyncPredicate);
                    }
                    else
                    {
                        evaluateAyncPredicateOrDefault ??= TryEvaluateAsyncPredicateOrDefault;
                        resultBuilder.Add(method, evaluateAyncPredicateOrDefault);
                    }
                }
                else if (methodName == operationMethod)
                {
                    if (parameters.Length is 3)
                    {
                        // typeof(Expression<Func<TSource, bool>>)
                        var selectorExpressionType = TypeHelper.GetPredicateType(sourceType);

                        if (parameters[1].ParameterType != selectorExpressionType)
                            continue;
                    }

                    if (!returnsDefaultOnNoMatch)
                    {
                        evaluateSyncPredicate ??= TryEvaluateSyncPredicate;
                        resultBuilder.Add(method, evaluateSyncPredicate);
                    }
                    else
                    {
                        evaluateSyncPredicateOrDefault ??= TryEvaluateSyncPredicateOrDefault;
                        resultBuilder.Add(method, evaluateSyncPredicateOrDefault);
                    }
                }
            }

            return resultBuilder.Build();
        }

        public override bool TryTranslate(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            [NotNullWhen(true)] out Expression? result)
        {
            if (method.IsGenericMethod)
            {
                method = method.GetGenericMethodDefinition();
            }

            result = null;

            return _evaluators.TryGetValue(method, out var evaluator)
                && evaluator(arguments, out Unsafe.As<Expression, ConstantExpression>(ref result!)!);
        }

        protected abstract ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            bool returnDefaultOnNoMatch,
            Expression? predicate,
            CancellationToken cancellation);

        private bool TryEvaluateSyncPredicate(
            ReadOnlyCollection<Expression> arguments,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            return TryEvaluate(arguments, processAsyncPredicate: false, returnDefaultOnNoMatch: false, out result);
        }

        private bool TryEvaluateSyncPredicateOrDefault(
            ReadOnlyCollection<Expression> arguments,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            return TryEvaluate(arguments, processAsyncPredicate: false, returnDefaultOnNoMatch: true, out result);
        }

        private bool TryEvaluateAsyncPredicate(
            ReadOnlyCollection<Expression> arguments,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            return TryEvaluate(arguments, processAsyncPredicate: true, returnDefaultOnNoMatch: false, out result);
        }

        private bool TryEvaluateAsyncPredicateOrDefault(
            ReadOnlyCollection<Expression> arguments,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            return TryEvaluate(arguments, processAsyncPredicate: true, returnDefaultOnNoMatch: true, out result);
        }

        private bool TryEvaluate(
            ReadOnlyCollection<Expression> arguments,
            bool processAsyncPredicate,
            bool returnDefaultOnNoMatch,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            result = null;

            if (!arguments[0].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                return false;

            if (translatedQueryable is null)
                return false;

            if (!arguments[^1].TryEvaluate<CancellationToken>(out var cancellationToken))
                return false;

            if (arguments.Count is 2)
            {
                result = ProcessOperation(
                    translatedQueryable, returnDefaultOnNoMatch, predicate: null, cancellationToken);

                return true;
            }

            var predicate = arguments[1];

            if (processAsyncPredicate && !predicate.TryTranslateExpressionToSync(
                translatedQueryable.ElementType, typeof(bool), out predicate))
            {
                return false;
            }

            result = ProcessOperation(
                    translatedQueryable, returnDefaultOnNoMatch, predicate, cancellationToken);

            return true;
        }
    }
}
