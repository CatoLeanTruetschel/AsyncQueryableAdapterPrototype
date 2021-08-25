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

#pragma warning disable IDE0049

using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed partial class AnyMethodTranslatorBuilder : PredicateAggregateTranslatorBuilder
    {
        protected override string OperationName => "Any";
        protected override bool PredicateRequired => false;
        protected override Type ResultType => typeof(System.Boolean);

        protected override IMethodTranslator BuildMethodTranslator(bool asyncPredicate)
        {
            return new AnyMethodTranslator(asyncPredicate);
        }
    }

    internal sealed partial class AnyMethodTranslator : PredicateAggregateTranslator
    {
        public AnyMethodTranslator(bool asyncPredicate) : base(asyncPredicate) { }

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Expression? predicate,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = typeof(ValueTask<System.Boolean>);
            ValueTask<System.Boolean> evaluationResult;

            if (predicate is not null)
            {
                evaluationResult = translatedQueryable.QueryAdapter.AnyAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    predicate,
                    cancellation);
            }
            else
            {
                evaluationResult = translatedQueryable.QueryAdapter.AnyAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    cancellation);
            }

            return Expression.Constant(evaluationResult, returnType);
        }
    }
    internal sealed partial class AllMethodTranslatorBuilder : PredicateAggregateTranslatorBuilder
    {
        protected override string OperationName => "All";
        protected override bool PredicateRequired => true;
        protected override Type ResultType => typeof(System.Boolean);

        protected override IMethodTranslator BuildMethodTranslator(bool asyncPredicate)
        {
            return new AllMethodTranslator(asyncPredicate);
        }
    }

    internal sealed partial class AllMethodTranslator : PredicateAggregateTranslator
    {
        public AllMethodTranslator(bool asyncPredicate) : base(asyncPredicate) { }

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Expression? predicate,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = typeof(ValueTask<System.Boolean>);
            ValueTask<System.Boolean> evaluationResult;

            Debug.Assert(predicate is not null);

            {
                evaluationResult = translatedQueryable.QueryAdapter.AllAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    predicate,
                    cancellation);
            }

            return Expression.Constant(evaluationResult, returnType);
        }
    }
    internal sealed partial class CountMethodTranslatorBuilder : PredicateAggregateTranslatorBuilder
    {
        protected override string OperationName => "Count";
        protected override bool PredicateRequired => false;
        protected override Type ResultType => typeof(System.Int32);

        protected override IMethodTranslator BuildMethodTranslator(bool asyncPredicate)
        {
            return new CountMethodTranslator(asyncPredicate);
        }
    }

    internal sealed partial class CountMethodTranslator : PredicateAggregateTranslator
    {
        public CountMethodTranslator(bool asyncPredicate) : base(asyncPredicate) { }

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Expression? predicate,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = typeof(ValueTask<System.Int32>);
            ValueTask<System.Int32> evaluationResult;

            if (predicate is not null)
            {
                evaluationResult = translatedQueryable.QueryAdapter.CountAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    predicate,
                    cancellation);
            }
            else
            {
                evaluationResult = translatedQueryable.QueryAdapter.CountAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    cancellation);
            }

            return Expression.Constant(evaluationResult, returnType);
        }
    }
    internal sealed partial class LongCountMethodTranslatorBuilder : PredicateAggregateTranslatorBuilder
    {
        protected override string OperationName => "LongCount";
        protected override bool PredicateRequired => false;
        protected override Type ResultType => typeof(System.Int64);

        protected override IMethodTranslator BuildMethodTranslator(bool asyncPredicate)
        {
            return new LongCountMethodTranslator(asyncPredicate);
        }
    }

    internal sealed partial class LongCountMethodTranslator : PredicateAggregateTranslator
    {
        public LongCountMethodTranslator(bool asyncPredicate) : base(asyncPredicate) { }

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Expression? predicate,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = typeof(ValueTask<System.Int64>);
            ValueTask<System.Int64> evaluationResult;

            if (predicate is not null)
            {
                evaluationResult = translatedQueryable.QueryAdapter.LongCountAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    predicate,
                    cancellation);
            }
            else
            {
                evaluationResult = translatedQueryable.QueryAdapter.LongCountAsync(
                    elementType,
                    translatedQueryable.GetQueryable(),
                    cancellation);
            }

            return Expression.Constant(evaluationResult, returnType);
        }
    }
}
