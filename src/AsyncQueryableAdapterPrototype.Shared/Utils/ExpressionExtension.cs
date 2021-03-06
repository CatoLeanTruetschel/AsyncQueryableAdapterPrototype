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

namespace System.Linq.Expressions
{
    internal static partial class ExpressionExtension
    {
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
    }
}
