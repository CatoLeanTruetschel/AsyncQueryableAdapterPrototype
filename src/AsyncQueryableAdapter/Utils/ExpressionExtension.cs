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

using System.Diagnostics.CodeAnalysis;
using AsyncQueryableAdapter.Utils;

namespace System.Linq.Expressions
{
    internal static class ExpressionExtension
    {
        [ThreadStatic]
        private static Type[]? _2EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _3EntryTypeBuffer;

        [ThreadStatic]
        private static ParameterExpression[]? _1EntryParameterExpressionBuffer;

        [ThreadStatic]
        private static ParameterExpression[]? _2EntryParameterExpressionBuffer;

        public static Expression ConvertRespectNullReferences<T>(this Expression expression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            var sourceType = expression.Type;
            var targetType = typeof(T);

            if (!sourceType.IsAssignableTo(targetType))
                throw new ArgumentException(
                    $"The type of the expression must be assignable to { targetType }.",
                    nameof(expression));

            Expression result = Expression.Convert(expression, targetType);

            if (sourceType.CanContainNull())
            {
                var nullSourceExpression = Expression.Constant(null, sourceType);
                var nullTargetExpression = Expression.Constant(default(T), targetType);
                var isNullExpression = Expression.Equal(expression, nullSourceExpression);
                result = Expression.Condition(isNullExpression, nullTargetExpression, result);
            }

            return result;
        }

        public static object? Evaluate(this Expression expression, bool preferInterpretation = false)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (expression is UnaryExpression unaryExpression && expression.NodeType == ExpressionType.Quote)
            {
                expression = unaryExpression.Operand;
            }

            if (expression is ConstantExpression constantExpression)
            {
                return constantExpression.Value;
            }

            if (expression is LambdaExpression lambdaExpression)
            {
                return lambdaExpression.Compile(preferInterpretation);
            }

            var lambda = Expression.Lambda<Func<object?>>(expression.ConvertRespectNullReferences<object?>());
            var executor = lambda.Compile(preferInterpretation);

            return executor();
        }

        public static bool TryEvaluate<T>(
            this Expression expression,
            [NotNullWhen(true)] out T? result,
            bool preferInterpretation = false)
        {
            var value = Evaluate(expression, preferInterpretation);

            if (value is T t)
            {
                result = t;
                return true;
            }

            result = default;
            return false;
        }

        public static Expression Unquote(this Expression expression)
        {
            if (expression is not UnaryExpression unaryExpression)
            {
                return expression;
            }

            if (unaryExpression.NodeType != ExpressionType.Quote)
            {
                return expression;
            }

            return unaryExpression.Operand;
        }

        public static bool TryTranslateExpressionToSync(
           this Expression expression,
           Type sourceType,
           Type targetType,
           [NotNullWhen(true)] out Expression? translatedExpression)
        {
            translatedExpression = null;

            // If expression is of form: Expression<Func<TSource, ValueTask<TResult>>>
            // Or of form: Expression<Func<TSource, CancellationToken, ValueTask<TResult>>>
            // Translate it to form Expression<Func<TSource, TResult>> if possible

            var selectorExpressionVisitor = new SelectorExpressionVisitor(targetType);

            if (expression.Unquote() is not LambdaExpression lambdaExpression)
                return false;

            var body = lambdaExpression.Body;
            var translatedBody = selectorExpressionVisitor.Visit(body).Unquote();

            if (translatedBody.Type != targetType)
                return false;

            if (selectorExpressionVisitor.Parameters.Count > 1)
                return false;

            var sourceParameter = selectorExpressionVisitor.Parameters.FirstOrDefault();

            if (sourceParameter is not null && sourceParameter.Type != sourceType)
                return false;

            sourceParameter ??= Expression.Parameter(sourceType);

            _2EntryTypeBuffer ??= new Type[2];
            _2EntryTypeBuffer[0] = sourceType;
            _2EntryTypeBuffer[1] = targetType;

            var selectorType = typeof(Func<,>).MakeGenericType(_2EntryTypeBuffer);

            var parameters = _1EntryParameterExpressionBuffer ??= new ParameterExpression[1];
            parameters[0] = sourceParameter;

            translatedExpression = Expression.Lambda(selectorType, translatedBody, parameters);

            return true;
        }

        public static bool TryTranslateExpressionToSync(
           this Expression expression,
           Type sourceType1,
           Type sourceType2,
           Type targetType,
           [NotNullWhen(true)] out Expression? translatedExpression)
        {
            translatedExpression = null;

            // If expression is of form: Expression<Func<TSource1, TSource2, ValueTask<TResult>>>
            // Or of form: Expression<Func<TSource1, TSource2, CancellationToken, ValueTask<TResult>>>
            // Translate it to form Expression<Func<TSource1, TSource2, TResult>> if possible

            var selectorExpressionVisitor = new SelectorExpressionVisitor(targetType);

            if (expression.Unquote() is not LambdaExpression lambdaExpression)
                return false;

            var body = lambdaExpression.Body;
            var translatedBody = selectorExpressionVisitor.Visit(body).Unquote();

            if (translatedBody.Type != targetType)
                return false;

            if (selectorExpressionVisitor.Parameters.Count > 2)
                return false;

            var source1Parameter = selectorExpressionVisitor.Parameters.FirstOrDefault();
            var source2Parameter = selectorExpressionVisitor.Parameters.Skip(1).FirstOrDefault();

            if (source1Parameter is not null && source1Parameter.Type != sourceType1)
                return false;

            if (source2Parameter is not null && source2Parameter.Type != sourceType2)
                return false;

            source1Parameter ??= Expression.Parameter(sourceType1);
            source2Parameter ??= Expression.Parameter(sourceType2);

            _3EntryTypeBuffer ??= new Type[3];
            _3EntryTypeBuffer[0] = sourceType1;
            _3EntryTypeBuffer[1] = sourceType2;
            _3EntryTypeBuffer[2] = targetType;

            var selectorType = typeof(Func<,,>).MakeGenericType(_3EntryTypeBuffer);

            var parameters = _2EntryParameterExpressionBuffer ??= new ParameterExpression[2];
            parameters[0] = source1Parameter;
            parameters[1] = source2Parameter;

            translatedExpression = Expression.Lambda(selectorType, translatedBody, parameters);

            return true;
        }
    }
}
