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
using System.Buffers;
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

        [ThreadStatic]
        private static Type[]? _1EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _2EntryTypeBuffer;

        public static bool TryTranslate(
            Expression expression,
            Type sourceType,
            Type targetType,
            [NotNullWhen(true)] out Expression? translatedExpression)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = sourceType;

            return TryTranslate(expression, _1EntryTypeBuffer, targetType, out translatedExpression);
        }

        public static bool TryTranslate(
            Expression expression,
            Type sourceType1,
            Type sourceType2,
            Type targetType,
            [NotNullWhen(true)] out Expression? translatedExpression)
        {
            _2EntryTypeBuffer ??= new Type[2];
            _2EntryTypeBuffer[0] = sourceType1;
            _2EntryTypeBuffer[1] = sourceType2;

            return TryTranslate(expression, _2EntryTypeBuffer, targetType, out translatedExpression);
        }

        public static bool TryTranslate(
            Expression expression,
            ReadOnlySpan<Type> sourceTypes,
            Type targetType,
            [NotNullWhen(true)] out Expression? translatedExpression)
        {
            if (!TryTranslate(expression, targetType, out translatedExpression))
            {
                return false;
            }

            var translatedParams = ((LambdaExpression)translatedExpression.Unquote()).Parameters;

            if (translatedParams.Count != sourceTypes.Length)
            {
                translatedExpression = null;
                return false;
            }

            for (var i = 0; i < translatedParams.Count; i++)
            {
                if (translatedParams[i].Type != sourceTypes[i])
                {
                    translatedExpression = null;
                    return false;
                }
            }

            return true;
        }

        public static bool TryTranslate(
            Expression expression,
            Type targetType,
            [NotNullWhen(true)] out Expression? translatedExpression)
        {
            if (!TryTranslate(expression, out translatedExpression))
            {
                return false;
            }

            if (((LambdaExpression)translatedExpression.Unquote()).ReturnType != targetType)
            {
                translatedExpression = null;
                return false;
            }

            return true;
        }

        public static bool TryTranslate(
            Expression expression,
            [NotNullWhen(true)] out Expression? translatedExpression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            translatedExpression = null;

            if (expression.Unquote() is not LambdaExpression lambdaExpression)
                return false;

            if (!TypeHelper.IsValueTaskType(lambdaExpression.ReturnType, out var targetType))
            {
                return false;
            }

            IReadOnlyList<ParameterExpression> parameters = lambdaExpression.Parameters;

            // If expression is of form: Expression<Func<TSource1, ... , TSourceN, ValueTask<TResult>>>
            // Or of form: Expression<Func<TSource1, ... , TSourceN, CancellationToken, ValueTask<TResult>>>
            // Translate it to form Expression<Func<TSource1, ... , TSourceN, TResult>> if possible

#if DISABLE_EXPRESSION_TRANSLATOR_POOLING
            var bodyVisitor = new BodyVisitor();
#else
            var bodyVisitor = _bodyVisitorPool.Get();
#endif

            try
            {
                bodyVisitor.Init(targetType);

                var body = lambdaExpression.Body;
                var translatedBody = bodyVisitor.Visit(body).Unquote();

                if (translatedBody.Type != targetType)
                    return false;

                parameters = BuildParameters(parameters);

                var delegateType = BuildDelegateType(parameters, targetType);
                translatedExpression = Expression.Lambda(delegateType, translatedBody, parameters);

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

        private static IReadOnlyList<ParameterExpression> BuildParameters(IReadOnlyList<ParameterExpression> parameters)
        {
            if (parameters.Count <= 0 || parameters[^1].Type != typeof(CancellationToken))
            {
                return parameters;
            }

            ParameterExpression[] newParameters;

            if (parameters.Count is 1)
            {
                newParameters = Array.Empty<ParameterExpression>();
            }
            else if (parameters.Count is 2)
            {
                _1EntryParameterExpressionBuffer ??= new ParameterExpression[1];
                newParameters = _1EntryParameterExpressionBuffer;
            }
            else if (parameters.Count is 3)
            {
                _2EntryParameterExpressionBuffer ??= new ParameterExpression[2];
                newParameters = _2EntryParameterExpressionBuffer;
            }
            else
            {
                newParameters = new ParameterExpression[parameters.Count - 1]; // TODO
            }

            for (var i = 0; i < newParameters.Length; i++)
            {
                newParameters[i] = parameters[i];
            }

            return newParameters;
        }

        private static Type BuildDelegateType(IReadOnlyList<ParameterExpression> parameters, Type targetType)
        {
            Type delegateType;

            if (parameters.Count is 0)
            {
                delegateType = TypeHelper.GetFuncType(targetType);
            }
            else if (parameters.Count is 1)
            {
                delegateType = TypeHelper.GetFuncType(parameters[0].Type, targetType);
            }
            else if (parameters.Count is 2)
            {
                delegateType = TypeHelper.GetFuncType(parameters[0].Type, parameters[1].Type, targetType);
            }
            else
            {
                var rentedParameterTypes = ArrayPool<Type>.Shared.Rent(parameters.Count);

                try
                {
                    var parameterTypes = rentedParameterTypes.AsSpan(0, parameters.Count);

                    for (var i = 0; i < parameters.Count; i++)
                    {
                        parameterTypes[i] = parameters[i].Type;
                    }

                    delegateType = TypeHelper.GetFuncType(parameterTypes, targetType);
                }
                finally
                {
                    ArrayPool<Type>.Shared.Return(rentedParameterTypes);
                }
            }

            return delegateType;
        }
    }
}
