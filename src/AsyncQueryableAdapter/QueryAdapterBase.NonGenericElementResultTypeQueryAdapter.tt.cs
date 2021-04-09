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
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter
{
    partial class QueryAdapterBase
    {
        partial interface INonGenericElementResultTypeQueryAdapter
        {
            AsyncTypeAwaitable MinAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression selector,
                CancellationToken cancellation);

            AsyncTypeAwaitable MaxAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression selector,
                CancellationToken cancellation);

            AsyncTypeAwaitable SumAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression selector,
                CancellationToken cancellation);

            AsyncTypeAwaitable AverageAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression selector,
                CancellationToken cancellation);

        }

        partial class NonGenericElementResultTypeQueryAdapter<TSource, TResult>
        {
            public AsyncTypeAwaitable MinAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression selector,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<TSource> typedQueryable)
                {
                    typedQueryable = source.Cast<TSource>();
                }

                if (selector is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    selector = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                var task = queryAdapter.MinAsync(typedQueryable, (Expression<Func<TSource, TResult>>)selector, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable MaxAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression selector,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<TSource> typedQueryable)
                {
                    typedQueryable = source.Cast<TSource>();
                }

                if (selector is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    selector = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                var task = queryAdapter.MaxAsync(typedQueryable, (Expression<Func<TSource, TResult>>)selector, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable SumAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression selector,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<TSource> typedQueryable)
                {
                    typedQueryable = source.Cast<TSource>();
                }

                if (selector is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    selector = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                var task = queryAdapter.SumAsync(typedQueryable, (Expression<Func<TSource, TResult>>)selector, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable AverageAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression selector,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<TSource> typedQueryable)
                {
                    typedQueryable = source.Cast<TSource>();
                }

                if (selector is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    selector = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                var task = queryAdapter.AverageAsync(typedQueryable, (Expression<Func<TSource, TResult>>)selector, cancellation);
                return task.AsTypeAwaitable();
            }

      
        }
    }
}
