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
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    partial class AverageMethodTranslator
    {
        [ThreadStatic]
        private static ParameterExpression[]? _1EntryParameterExpressionBuffer;

        private static Expression TranslateSelector(LambdaExpression expression)
        {
            var nonNullReturnType = expression.ReturnType;
            var isNullable = false;

            if (TypeHelper.IsNullableType(expression.ReturnType, out var underlyingType))
            {
                nonNullReturnType = underlyingType;
                isNullable = true;
            }

            if (nonNullReturnType == typeof(int) || nonNullReturnType == typeof(long))
            {
                var expectedReturnType = isNullable ? typeof(double?) : typeof(double);

                var parameters = expression.Parameters;
                var body = expression.Body;
                var del = expression.Type;
                var sourceType = del.GetMethod("Invoke")!.GetParameters()[0].ParameterType;

                body = Expression.Convert(body, expectedReturnType);
                del = TypeHelper.GetFuncType(sourceType, expectedReturnType);

                return Expression.Quote(Expression.Lambda(del, body, parameters));
            }

            return expression;
        }

        private static bool NeedsSelector(Type sourceType, [NotNullWhen(true)] out Expression? selector)
        {
            var nonNullSource = sourceType;
            var isNullable = false;

            if (TypeHelper.IsNullableType(sourceType, out var underlyingType))
            {
                nonNullSource = underlyingType;
                isNullable = true;
            }

            if (nonNullSource == typeof(int) || nonNullSource == typeof(long))
            {
                var resultType = isNullable ? typeof(double?) : typeof(double);
                var del = TypeHelper.GetFuncType(sourceType, resultType);
                var param = Expression.Parameter(sourceType, "p");
                var convert = Expression.Convert(param, resultType);

                _1EntryParameterExpressionBuffer ??= new ParameterExpression[1];
                _1EntryParameterExpressionBuffer[0] = param;

                var lambda = Expression.Lambda(del, convert, _1EntryParameterExpressionBuffer);
                selector = Expression.Quote(lambda);
                return true;
            }

            selector = null;
            return false;
        }
    }
}
