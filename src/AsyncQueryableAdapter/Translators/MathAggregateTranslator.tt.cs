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
using System.Linq.Expressions;
using System.Threading;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class MinMethodTranslatorBuilder : MathAggregateTranslatorBuilder
    {
        protected override string OperationName => "Min";

        protected override IMethodTranslator BuildMethodTranslator(bool asyncSelector)
        {
            return new MinMethodTranslator(asyncSelector);
        }
    }

    internal sealed class MinMethodTranslator : MathAggregateTranslator
    {
        public MinMethodTranslator(bool asyncSelector) : base(asyncSelector) { }

        protected override ConstantExpression ProcessOperation(
            Type resultType,
            TranslatedQueryable translatedQueryable,
            Expression? selector,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(resultType);
            AsyncTypeAwaitable evaluationResult;

            if (selector is null)
            {
                evaluationResult = translatedQueryable.QueryAdapter.MinAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    cancellation);
            }
            else
            {
                evaluationResult = translatedQueryable.QueryAdapter.MinAsync(
                    elementType,
                    resultType,
                    translatedQueryable.GetQueryable(),
                    selector,
                    cancellation);
            }

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
    internal sealed class MaxMethodTranslatorBuilder : MathAggregateTranslatorBuilder
    {
        protected override string OperationName => "Max";

        protected override IMethodTranslator BuildMethodTranslator(bool asyncSelector)
        {
            return new MaxMethodTranslator(asyncSelector);
        }
    }

    internal sealed class MaxMethodTranslator : MathAggregateTranslator
    {
        public MaxMethodTranslator(bool asyncSelector) : base(asyncSelector) { }

        protected override ConstantExpression ProcessOperation(
            Type resultType,
            TranslatedQueryable translatedQueryable,
            Expression? selector,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(resultType);
            AsyncTypeAwaitable evaluationResult;

            if (selector is null)
            {
                evaluationResult = translatedQueryable.QueryAdapter.MaxAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    cancellation);
            }
            else
            {
                evaluationResult = translatedQueryable.QueryAdapter.MaxAsync(
                    elementType,
                    resultType,
                    translatedQueryable.GetQueryable(),
                    selector,
                    cancellation);
            }

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
    internal sealed class SumMethodTranslatorBuilder : MathAggregateTranslatorBuilder
    {
        protected override string OperationName => "Sum";

        protected override IMethodTranslator BuildMethodTranslator(bool asyncSelector)
        {
            return new SumMethodTranslator(asyncSelector);
        }
    }

    internal sealed class SumMethodTranslator : MathAggregateTranslator
    {
        public SumMethodTranslator(bool asyncSelector) : base(asyncSelector) { }

        protected override ConstantExpression ProcessOperation(
            Type resultType,
            TranslatedQueryable translatedQueryable,
            Expression? selector,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(resultType);
            AsyncTypeAwaitable evaluationResult;

            if (selector is null)
            {
                evaluationResult = translatedQueryable.QueryAdapter.SumAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    cancellation);
            }
            else
            {
                evaluationResult = translatedQueryable.QueryAdapter.SumAsync(
                    elementType,
                    resultType,
                    translatedQueryable.GetQueryable(),
                    selector,
                    cancellation);
            }

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
    internal sealed class AverageMethodTranslatorBuilder : MathAggregateTranslatorBuilder
    {
        protected override string OperationName => "Average";

        protected override IMethodTranslator BuildMethodTranslator(bool asyncSelector)
        {
            return new AverageMethodTranslator(asyncSelector);
        }
    }

    internal sealed class AverageMethodTranslator : MathAggregateTranslator
    {
        public AverageMethodTranslator(bool asyncSelector) : base(asyncSelector) { }

        protected override ConstantExpression ProcessOperation(
            Type resultType,
            TranslatedQueryable translatedQueryable,
            Expression? selector,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(resultType);
            AsyncTypeAwaitable evaluationResult;

            if (selector is null)
            {
                evaluationResult = translatedQueryable.QueryAdapter.AverageAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    cancellation);
            }
            else
            {
                evaluationResult = translatedQueryable.QueryAdapter.AverageAsync(
                    elementType,
                    resultType,
                    translatedQueryable.GetQueryable(),
                    selector,
                    cancellation);
            }

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
}
