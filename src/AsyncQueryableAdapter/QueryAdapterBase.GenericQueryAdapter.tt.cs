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
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter
{
    partial class QueryAdapterBase
    {
        partial interface IGenericElementTypeQueryAdapter
        {
            AsyncTypeAwaitable MinAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            AsyncTypeAwaitable MaxAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            AsyncTypeAwaitable SumAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            AsyncTypeAwaitable AverageAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            AsyncTypeAwaitable FirstAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            AsyncTypeAwaitable FirstAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation);

            AsyncTypeAwaitable FirstOrDefaultAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            AsyncTypeAwaitable FirstOrDefaultAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation);

            AsyncTypeAwaitable LastAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            AsyncTypeAwaitable LastAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation);

            AsyncTypeAwaitable LastOrDefaultAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            AsyncTypeAwaitable LastOrDefaultAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation);

            AsyncTypeAwaitable SingleAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            AsyncTypeAwaitable SingleAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation);

            AsyncTypeAwaitable SingleOrDefaultAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            AsyncTypeAwaitable SingleOrDefaultAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation);

            ValueTask<System.Boolean> AnyAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            ValueTask<System.Boolean> AnyAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation);

            ValueTask<System.Boolean> AllAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation);

            ValueTask<System.Int32> CountAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            ValueTask<System.Int32> CountAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation);

            ValueTask<System.Int64> LongCountAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation);

            ValueTask<System.Int64> LongCountAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation);

        }

        partial class GenericQueryAdapter<T>
        {
            public AsyncTypeAwaitable MinAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task = queryAdapter.MinAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable MaxAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task = queryAdapter.MaxAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable SumAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task = queryAdapter.SumAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable AverageAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task = queryAdapter.AverageAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable FirstAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task = queryAdapter.FirstAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable FirstAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression predicate,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (predicate is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    predicate = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                var task = queryAdapter.FirstAsync(typedQueryable, (Expression<Func<T, bool>>)predicate, cancellation);
                return task.AsTypeAwaitable();
            }
            public AsyncTypeAwaitable FirstOrDefaultAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task = queryAdapter.FirstOrDefaultAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable FirstOrDefaultAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression predicate,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (predicate is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    predicate = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                var task = queryAdapter.FirstOrDefaultAsync(typedQueryable, (Expression<Func<T, bool>>)predicate, cancellation);
                return task.AsTypeAwaitable();
            }
            public AsyncTypeAwaitable LastAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task = queryAdapter.LastAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable LastAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression predicate,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (predicate is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    predicate = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                var task = queryAdapter.LastAsync(typedQueryable, (Expression<Func<T, bool>>)predicate, cancellation);
                return task.AsTypeAwaitable();
            }
            public AsyncTypeAwaitable LastOrDefaultAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task = queryAdapter.LastOrDefaultAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable LastOrDefaultAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression predicate,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (predicate is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    predicate = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                var task = queryAdapter.LastOrDefaultAsync(typedQueryable, (Expression<Func<T, bool>>)predicate, cancellation);
                return task.AsTypeAwaitable();
            }
            public AsyncTypeAwaitable SingleAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task = queryAdapter.SingleAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable SingleAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression predicate,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (predicate is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    predicate = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                var task = queryAdapter.SingleAsync(typedQueryable, (Expression<Func<T, bool>>)predicate, cancellation);
                return task.AsTypeAwaitable();
            }
            public AsyncTypeAwaitable SingleOrDefaultAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task = queryAdapter.SingleOrDefaultAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable SingleOrDefaultAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                Expression predicate,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (predicate is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    predicate = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                var task = queryAdapter.SingleOrDefaultAsync(typedQueryable, (Expression<Func<T, bool>>)predicate, cancellation);
                return task.AsTypeAwaitable();
            }

            public ValueTask<System.Boolean> AnyAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                return queryAdapter.AnyAsync(typedQueryable, cancellation);
            }

            public ValueTask<System.Boolean> AnyAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (predicate is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    predicate = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                return queryAdapter.AnyAsync(typedQueryable, (Expression<Func<T, bool>>)predicate, cancellation);
            }
            public ValueTask<System.Boolean> AllAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (predicate is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    predicate = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                return queryAdapter.AllAsync(typedQueryable, (Expression<Func<T, bool>>)predicate, cancellation);
            }

            public ValueTask<System.Int32> CountAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                return queryAdapter.CountAsync(typedQueryable, cancellation);
            }

            public ValueTask<System.Int32> CountAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (predicate is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    predicate = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                return queryAdapter.CountAsync(typedQueryable, (Expression<Func<T, bool>>)predicate, cancellation);
            }

            public ValueTask<System.Int64> LongCountAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                return queryAdapter.LongCountAsync(typedQueryable, cancellation);
            }

            public ValueTask<System.Int64> LongCountAsync(QueryAdapterBase queryAdapter, IQueryable source, Expression predicate, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (predicate is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Quote)
                {
                    predicate = unaryExpression.Operand;
                }

                // TODO: Can we convert the selector if it is not of the appropriate type?
                return queryAdapter.LongCountAsync(typedQueryable, (Expression<Func<T, bool>>)predicate, cancellation);
            }
        }

        partial interface IGenericElementResultTypeQueryAdapter
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

        partial class GenericQueryAdapter<TSource, TResult>
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
