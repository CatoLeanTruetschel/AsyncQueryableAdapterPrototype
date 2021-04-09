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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter
{
    internal sealed class AsyncQueryProvider : IAsyncQueryProvider
    {
        public AsyncQueryProvider(QueryAdapterBase queryAdapter)
        {
            if (queryAdapter is null)
                throw new ArgumentNullException(nameof(queryAdapter));

            QueryAdapter = queryAdapter;
        }

        public QueryAdapterBase QueryAdapter { get; }

        public IAsyncQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (!expression.Type.IsAssignableTo<IAsyncQueryable<TElement>>())
            {
                throw new ArgumentException(
                    $"The expression type must be assignable to {typeof(IAsyncQueryable<TElement>)}.");
            }

            return new AsyncQueryable<TElement>(this, expression);
        }

        public async ValueTask<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken token)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            var expressionTypeDescriptor = AwaitableTypeDescriptor.GetTypeDescriptor(expression.Type);
            var expressionResultType = expressionTypeDescriptor.ResultType;

            if (!expressionResultType.IsAssignableTo<TResult>())
                throw new ArgumentException(
                    $"The expression type must either be assignable to {typeof(TResult)} or an awaitable type with a result type of {typeof(TResult)}.", nameof(expression));

            // Rewrite the recorded expression, in order to perform as many of the query processing in the database
            // engine (or the database driver) which will be highly optimized by them. Fall back to in memory processing
            // only if necessary as a post-processing step.
            var expressionVisitor = new QueryExpressionVisitor(QueryAdapter.Options);
            expression = expressionVisitor.Visit(expression);

            // Get the untyped (typeof object) result from the expression. This does not execute the query
            // in the general case but only builds the 'query-processor' that provides on of possible results:
            // 1. A constant expression of type TranslatedQueryable when the query could be translated to be database 
            //    compatible entirely.
            // 2. An IAsyncQueryable<TElement> when the query could not be translated to be database compatible entirely
            //    and includes an in-memory post-processing step.
            // 3. A Task<TResult> / ValueTask<TResult> or another awaitable type that produces a result of type TResult
            //    when a query method is executed as the last step that produces a scalar result
            var untypedResult = expression.Evaluate(); // TODO: Make preferInterpretation param configurable

            if (expression.Type == typeof(TranslatedQueryable))
            {
                if (untypedResult is not TranslatedQueryable translatedQueryable)
                {
                    throw new InvalidOperationException(); // TODO
                }

                var elementType = translatedQueryable.ElementType;

                // Due to the check above and the fact that we only translate instances of type AsyncQueryable, 
                // the type of the original expression must be one of the following: 
                // object,
                // IAsyncQueryable, IAsyncQueryable<T>,
                // IOrderedAsyncQueryable, IOrderedAsyncQueryable<T>,
                // IAsyncEnumerable<T>
                // Therefore TResult MUST be of type IAsyncEnumerable<T>
                if (!typeof(TResult).IsAssignableTo(typeof(IAsyncEnumerable<>).MakeGenericType(elementType)))
                {
                    throw new InvalidOperationException(); // TODO
                }

                // Get the queryable from the expression
                var queryable = translatedQueryable.QueryProvider.CreateQuery(translatedQueryable.Expression);

                return (TResult)QueryAdapter.EvaluateAsync(elementType, queryable, token);
            }

            // Unpack the result 
            if (expressionTypeDescriptor.IsAwaitable && untypedResult is not null)
            {
                untypedResult = await expressionTypeDescriptor.GetAwaitable(untypedResult);
            }

            if (untypedResult is null)
            {
                // TODO: What do we return if the types don't match? Throw an exception?
                //       Is the type annotation of this method even correct?
                return default!;
            }

            return (TResult)untypedResult;
        }
    }
}
