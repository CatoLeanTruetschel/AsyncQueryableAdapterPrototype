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
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal abstract class PredicateAggregateTranslator : MethodTranslator
    {
        private readonly CompiledDictionary<MethodInfo, MethodCallEvaluator> _evaluators;

        protected PredicateAggregateTranslator()
        {
            _evaluators = BuildEvaluators();
        }

        protected abstract string OperationName { get; }

        protected abstract bool PredicateRequired { get; }

        protected abstract Type ResultType { get; }

        private CompiledDictionary<MethodInfo, MethodCallEvaluator> BuildEvaluators()
        {
            var operationMethod = OperationName + "Async";
            var operationAwaitMethod = OperationName + "AwaitAsync";
            var operationAwaitWithCancellationMethod = OperationName + "AwaitWithCancellationAsync";

            var asyncQueryableType = typeof(System.Linq.AsyncQueryable);
            var methods = asyncQueryableType.GetMethods(BindingFlags.Static | BindingFlags.Public);
            var resultBuilder = CompiledDictionary.CreateBuilder<MethodInfo, MethodCallEvaluator>();

            MethodCallEvaluator? evaluateSyncPredicate = null;
            MethodCallEvaluator? evaluateAsyncPredicate = null;

            foreach (var method in methods)
            {
                var methodName = method.Name;

                if (!method.IsGenericMethod)
                    continue;

                var genericArguments = method.GetGenericArguments();

                if (genericArguments.Length is not 1)
                    continue;

                var sourceType = genericArguments[0];
                var returnType = method.ReturnType;
                var parameters = method.GetParameters();

                if (returnType != TypeHelper.GetValueTaskType(ResultType))
                    continue;

                if (parameters.Length is < 2 or > 3)
                    continue;

                if (PredicateRequired && parameters.Length is not 3)
                    continue;

                // Last parameter is of type CancellationToken
                if (parameters[^1].ParameterType != typeof(CancellationToken))
                    continue;

                // First parameter is of type IAsyncQueryable<TSource>
                if (parameters[0].ParameterType != TypeHelper.GetAsyncQueryableType(sourceType))
                    continue;

                if (parameters.Length is 3)
                {
                    var predicateParameterType = parameters[1].ParameterType;
                    Type expectedPredicateType;

                    if (string.Equals(methodName, operationMethod, StringComparison.Ordinal))
                    {
                        // Sync predicate
                        expectedPredicateType = TypeHelper.GetFuncExpressionType(sourceType, typeof(bool));

                        if (predicateParameterType != expectedPredicateType)
                            continue;

                        evaluateSyncPredicate ??= TryEvaluateSyncPredicate;
                        resultBuilder.Add(method, evaluateSyncPredicate);
                    }
                    else if (string.Equals(methodName, operationAwaitMethod, StringComparison.Ordinal))
                    {
                        // Async predicate
                        expectedPredicateType = TypeHelper.GetFuncExpressionType(sourceType, typeof(ValueTask<bool>));

                        if (predicateParameterType != expectedPredicateType)
                            continue;

                        evaluateAsyncPredicate ??= TryEvaluateAsyncPredicate;
                        resultBuilder.Add(method, evaluateAsyncPredicate);
                    }
                    else if (string.Equals(methodName, operationAwaitWithCancellationMethod, StringComparison.Ordinal))
                    {
                        // Async predicate with cancellation
                        expectedPredicateType = TypeHelper.GetFuncExpressionType(
                            sourceType,
                            typeof(CancellationToken),
                            typeof(ValueTask<bool>));

                        if (predicateParameterType != expectedPredicateType)
                            continue;

                        evaluateAsyncPredicate ??= TryEvaluateAsyncPredicate;
                        resultBuilder.Add(method, evaluateAsyncPredicate);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (PredicateRequired)
                {
                    continue;
                }
                else // if(parameters.Length is 2)
                {
                    // No predicate
                    if (!string.Equals(methodName, operationMethod, StringComparison.Ordinal))
                        continue;

                    evaluateSyncPredicate ??= TryEvaluateSyncPredicate;
                    resultBuilder.Add(method, evaluateSyncPredicate);
                }
            }

            return resultBuilder.Build();
        }

        private bool TryEvaluateSyncPredicate(
            ReadOnlyCollection<Expression> arguments,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            return TryEvaluate(arguments, processAsyncPredicate: false, out result);
        }

        private bool TryEvaluateAsyncPredicate(
            ReadOnlyCollection<Expression> arguments,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            return TryEvaluate(arguments, processAsyncPredicate: true, out result);
        }

        private bool TryEvaluate(
            ReadOnlyCollection<Expression> arguments,
            bool processAsyncPredicate,
            [NotNullWhen(true)] out ConstantExpression? result)
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
                    translatedQueryable, cancellationToken);

                return true;
            }

            var selector = arguments[1];

            if (processAsyncPredicate && !selector.TryTranslateExpressionToSync(
              translatedQueryable.ElementType, typeof(bool), out selector))
            {
                return false;
            }

            result = ProcessOperation(translatedQueryable, selector, cancellationToken);
            return true;
        }

        protected abstract ConstantExpression ProcessOperation(
          TranslatedQueryable translatedQueryable,
          CancellationToken cancellation);

        protected abstract ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Expression predicate,
            CancellationToken cancellation);

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
    }
}
