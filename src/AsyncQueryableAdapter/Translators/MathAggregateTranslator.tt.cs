using System;
using System.Linq.Expressions;
using System.Threading;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class MinMethodTranslator : MathAggregateTranslator
    {
        protected override string OperationName => "Min";

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(elementType);
            var evaluationResult = translatedQueryable.QueryAdapter.MinAsync(
                elementType,
                translatedQueryable.GetQueryable(),
                cancellation);

            return Expression.Constant(evaluationResult.Instance, returnType);
        }

        protected override ConstantExpression ProcessOperation(
            Type resultType,
            TranslatedQueryable translatedQueryable,
            Expression selector,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(resultType);
            var evaluationResult = translatedQueryable.QueryAdapter.MinAsync(
                elementType,
                resultType,
                translatedQueryable.GetQueryable(),
                selector,
                cancellation);

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
    internal sealed class MaxMethodTranslator : MathAggregateTranslator
    {
        protected override string OperationName => "Max";

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(elementType);
            var evaluationResult = translatedQueryable.QueryAdapter.MaxAsync(
                elementType,
                translatedQueryable.GetQueryable(),
                cancellation);

            return Expression.Constant(evaluationResult.Instance, returnType);
        }

        protected override ConstantExpression ProcessOperation(
            Type resultType,
            TranslatedQueryable translatedQueryable,
            Expression selector,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(resultType);
            var evaluationResult = translatedQueryable.QueryAdapter.MaxAsync(
                elementType,
                resultType,
                translatedQueryable.GetQueryable(),
                selector,
                cancellation);

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
    internal sealed class SumMethodTranslator : MathAggregateTranslator
    {
        protected override string OperationName => "Sum";

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(elementType);
            var evaluationResult = translatedQueryable.QueryAdapter.SumAsync(
                elementType,
                translatedQueryable.GetQueryable(),
                cancellation);

            return Expression.Constant(evaluationResult.Instance, returnType);
        }

        protected override ConstantExpression ProcessOperation(
            Type resultType,
            TranslatedQueryable translatedQueryable,
            Expression selector,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(resultType);
            var evaluationResult = translatedQueryable.QueryAdapter.SumAsync(
                elementType,
                resultType,
                translatedQueryable.GetQueryable(),
                selector,
                cancellation);

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
    internal sealed class AverageMethodTranslator : MathAggregateTranslator
    {
        protected override string OperationName => "Average";

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(elementType);
            var evaluationResult = translatedQueryable.QueryAdapter.AverageAsync(
                elementType,
                translatedQueryable.GetQueryable(),
                cancellation);

            return Expression.Constant(evaluationResult.Instance, returnType);
        }

        protected override ConstantExpression ProcessOperation(
            Type resultType,
            TranslatedQueryable translatedQueryable,
            Expression selector,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(resultType);
            var evaluationResult = translatedQueryable.QueryAdapter.AverageAsync(
                elementType,
                resultType,
                translatedQueryable.GetQueryable(),
                selector,
                cancellation);

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
}
