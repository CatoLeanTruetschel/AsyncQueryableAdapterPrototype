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

using System.Linq.Expressions;
using System.Threading;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class FirstMethodTranslatorBuilder : SingleEntryQueryMethodTranslatorBuilder
    {
        protected override string OperationName => "First";

        protected override IMethodTranslator BuildMethodTranslator(bool asyncPredicate, bool returnDefaultOnNoMatch)
        {
            return new FirstMethodTranslator(asyncPredicate, returnDefaultOnNoMatch);
        }
    }

    internal sealed class FirstMethodTranslator : SingleEntryQueryMethodTranslator
    {
        public FirstMethodTranslator(bool asyncPredicate, bool returnDefaultOnNoMatch)
            : base(asyncPredicate, returnDefaultOnNoMatch) { }

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Expression? predicate,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(elementType);
            var queryable = translatedQueryable.GetQueryable();
            AsyncTypeAwaitable evaluationResult;

            if (predicate is null)
            {
                // TODO: Why are there overloads without a predicate, if we can just pass null in the more general 
                //       overload?
                if (ReturnDefaultOnNoMatch)
                {
                    evaluationResult = translatedQueryable.QueryAdapter.FirstOrDefaultAsync(
                       elementType,
                       queryable,
                       cancellation);
                }
                else
                {
                    evaluationResult = translatedQueryable.QueryAdapter.FirstAsync(
                         elementType,
                         queryable,
                         cancellation);
                }
            }
            else
            {
                if (ReturnDefaultOnNoMatch)
                {
                    evaluationResult = translatedQueryable.QueryAdapter.FirstOrDefaultAsync(
                       elementType,
                       queryable,
                       predicate,
                       cancellation);
                }
                else
                {
                    evaluationResult = translatedQueryable.QueryAdapter.FirstAsync(
                      elementType,
                      queryable,
                      predicate,
                      cancellation);
                }
            }

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
    internal sealed class LastMethodTranslatorBuilder : SingleEntryQueryMethodTranslatorBuilder
    {
        protected override string OperationName => "Last";

        protected override IMethodTranslator BuildMethodTranslator(bool asyncPredicate, bool returnDefaultOnNoMatch)
        {
            return new LastMethodTranslator(asyncPredicate, returnDefaultOnNoMatch);
        }
    }

    internal sealed class LastMethodTranslator : SingleEntryQueryMethodTranslator
    {
        public LastMethodTranslator(bool asyncPredicate, bool returnDefaultOnNoMatch)
            : base(asyncPredicate, returnDefaultOnNoMatch) { }

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Expression? predicate,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(elementType);
            var queryable = translatedQueryable.GetQueryable();
            AsyncTypeAwaitable evaluationResult;

            if (predicate is null)
            {
                // TODO: Why are there overloads without a predicate, if we can just pass null in the more general 
                //       overload?
                if (ReturnDefaultOnNoMatch)
                {
                    evaluationResult = translatedQueryable.QueryAdapter.LastOrDefaultAsync(
                       elementType,
                       queryable,
                       cancellation);
                }
                else
                {
                    evaluationResult = translatedQueryable.QueryAdapter.LastAsync(
                         elementType,
                         queryable,
                         cancellation);
                }
            }
            else
            {
                if (ReturnDefaultOnNoMatch)
                {
                    evaluationResult = translatedQueryable.QueryAdapter.LastOrDefaultAsync(
                       elementType,
                       queryable,
                       predicate,
                       cancellation);
                }
                else
                {
                    evaluationResult = translatedQueryable.QueryAdapter.LastAsync(
                      elementType,
                      queryable,
                      predicate,
                      cancellation);
                }
            }

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
    internal sealed class SingleMethodTranslatorBuilder : SingleEntryQueryMethodTranslatorBuilder
    {
        protected override string OperationName => "Single";

        protected override IMethodTranslator BuildMethodTranslator(bool asyncPredicate, bool returnDefaultOnNoMatch)
        {
            return new SingleMethodTranslator(asyncPredicate, returnDefaultOnNoMatch);
        }
    }

    internal sealed class SingleMethodTranslator : SingleEntryQueryMethodTranslator
    {
        public SingleMethodTranslator(bool asyncPredicate, bool returnDefaultOnNoMatch)
            : base(asyncPredicate, returnDefaultOnNoMatch) { }

        protected override ConstantExpression ProcessOperation(
            TranslatedQueryable translatedQueryable,
            Expression? predicate,
            CancellationToken cancellation)
        {
            var elementType = translatedQueryable.ElementType;
            var returnType = TypeHelper.GetValueTaskType(elementType);
            var queryable = translatedQueryable.GetQueryable();
            AsyncTypeAwaitable evaluationResult;

            if (predicate is null)
            {
                // TODO: Why are there overloads without a predicate, if we can just pass null in the more general 
                //       overload?
                if (ReturnDefaultOnNoMatch)
                {
                    evaluationResult = translatedQueryable.QueryAdapter.SingleOrDefaultAsync(
                       elementType,
                       queryable,
                       cancellation);
                }
                else
                {
                    evaluationResult = translatedQueryable.QueryAdapter.SingleAsync(
                         elementType,
                         queryable,
                         cancellation);
                }
            }
            else
            {
                if (ReturnDefaultOnNoMatch)
                {
                    evaluationResult = translatedQueryable.QueryAdapter.SingleOrDefaultAsync(
                       elementType,
                       queryable,
                       predicate,
                       cancellation);
                }
                else
                {
                    evaluationResult = translatedQueryable.QueryAdapter.SingleAsync(
                      elementType,
                      queryable,
                      predicate,
                      cancellation);
                }
            }

            return Expression.Constant(evaluationResult.Instance, returnType);
        }
    }
}