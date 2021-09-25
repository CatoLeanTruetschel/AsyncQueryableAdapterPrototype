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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter
{
    internal static partial class ExpressionTranslator

    {
        [ThreadStatic]
        private static ParameterExpression[]? _1EntryParameterExpressionBuffer;

        [ThreadStatic]
        private static ParameterExpression[]? _2EntryParameterExpressionBuffer;

        public static bool TryTranslateExpressionToSync(
           Expression expression,
           Type sourceType,
           Type targetType,
           [NotNullWhen(true)] out Expression? translatedExpression)
        {
            translatedExpression = null;

            // If expression is of form: Expression<Func<TSource, ValueTask<TResult>>>
            // Or of form: Expression<Func<TSource, CancellationToken, ValueTask<TResult>>>
            // Translate it to form Expression<Func<TSource, TResult>> if possible

#if DISABLE_EXPRESSION_TRANSLATOR_POOLING
            var bodyVisitor = new BodyVisitor();
#else
            var bodyVisitor = _bodyVisitorPool.Get();
#endif

            try
            {
                bodyVisitor.Init(targetType);

                if (expression.Unquote() is not LambdaExpression lambdaExpression)
                    return false;

                var body = lambdaExpression.Body;
                var translatedBody = bodyVisitor.Visit(body).Unquote();

                if (translatedBody.Type != targetType)
                    return false;

                if (lambdaExpression.Parameters.Count > 1)
                {
                    if (lambdaExpression.Parameters.Count != 2)
                    {
                        return false;
                    }

                    if (lambdaExpression.Parameters[1].Type != typeof(CancellationToken))
                    {
                        return false;
                    }
                }

                var sourceParameter = lambdaExpression.Parameters[0];

                if (sourceParameter is not null && sourceParameter.Type != sourceType)
                    return false;

                sourceParameter ??= Expression.Parameter(sourceType);

                var selectorType = TypeHelper.GetFuncType(sourceType, targetType);
                var parameters = _1EntryParameterExpressionBuffer ??= new ParameterExpression[1];
                parameters[0] = sourceParameter;

                translatedExpression = Expression.Lambda(selectorType, translatedBody, parameters);

                return true;
            }
            finally
            {
#if !DISABLE_EXPRESSION_TRANSLATOR_POOLING
                bodyVisitor.Reset();
                _bodyVisitorPool.Return(bodyVisitor);
#endif
            }
        }

        public static bool TryTranslateExpressionToSync(
            Expression expression,
            Type sourceType1,
            Type sourceType2,
            Type targetType,
            [NotNullWhen(true)] out Expression? translatedExpression)
        {
            translatedExpression = null;

            // If expression is of form: Expression<Func<TSource1, TSource2, ValueTask<TResult>>>
            // Or of form: Expression<Func<TSource1, TSource2, CancellationToken, ValueTask<TResult>>>
            // Translate it to form Expression<Func<TSource1, TSource2, TResult>> if possible

#if DISABLE_EXPRESSION_TRANSLATOR_POOLING
            var bodyVisitor = new BodyVisitor();
#else
            var bodyVisitor = _bodyVisitorPool.Get();
#endif

            try
            {
                bodyVisitor.Init(targetType);

                if (expression.Unquote() is not LambdaExpression lambdaExpression)
                    return false;

                var body = lambdaExpression.Body;
                var translatedBody = bodyVisitor.Visit(body).Unquote();

                if (translatedBody.Type != targetType)
                    return false;

                if (lambdaExpression.Parameters.Count > 2)
                {
                    if (lambdaExpression.Parameters.Count != 3)
                    {
                        return false;
                    }

                    if (lambdaExpression.Parameters[2].Type != typeof(CancellationToken))
                    {
                        return false;
                    }
                }

                var source1Parameter = lambdaExpression.Parameters[0];
                var source2Parameter = lambdaExpression.Parameters[1];

                if (source1Parameter is not null && source1Parameter.Type != sourceType1)
                    return false;

                if (source2Parameter is not null && source2Parameter.Type != sourceType2)
                    return false;

                source1Parameter ??= Expression.Parameter(sourceType1);
                source2Parameter ??= Expression.Parameter(sourceType2);

                var selectorType = TypeHelper.GetFuncType(sourceType1, sourceType2, targetType);

                var parameters = _2EntryParameterExpressionBuffer ??= new ParameterExpression[2];
                parameters[0] = source1Parameter;
                parameters[1] = source2Parameter;

                translatedExpression = Expression.Lambda(selectorType, translatedBody, parameters);

                return true;
            }
            finally
            {
#if !DISABLE_EXPRESSION_TRANSLATOR_POOLING
                bodyVisitor.Reset();
                _bodyVisitorPool.Return(bodyVisitor);
#endif
            }
        }

        public static bool TryTranslateExpressionToSync(
            Expression expression,
            IReadOnlyList<Type> sourceTypes,
            Type targetType,
            [NotNullWhen(true)] out Expression? translatedExpression)
        {
            if (sourceTypes.Count is 1)
            {
                return TryTranslateExpressionToSync(expression, sourceTypes[0], targetType, out translatedExpression);
            }

            if (sourceTypes.Count is 2)
            {
                return TryTranslateExpressionToSync(
                    expression, sourceTypes[0], sourceTypes[1], targetType, out translatedExpression);
            }

            translatedExpression = null;
            return false;
        }
    }
}
