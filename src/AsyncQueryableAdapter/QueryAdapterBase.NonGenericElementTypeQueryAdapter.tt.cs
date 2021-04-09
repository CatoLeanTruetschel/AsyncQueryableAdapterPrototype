﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter
{
    partial class QueryAdapterBase
    {
        partial interface INonGenericElementTypeQueryAdapter
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

        }

        partial class NonGenericElementTypeQueryAdapter<T>
        {
            public AsyncTypeAwaitable MinAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task =  queryAdapter.MinAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable MaxAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task =  queryAdapter.MaxAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable SumAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task =  queryAdapter.SumAsync(typedQueryable, cancellation);
                return task.AsTypeAwaitable();
            }

            public AsyncTypeAwaitable AverageAsync(QueryAdapterBase queryAdapter, IQueryable source, CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                var task =  queryAdapter.AverageAsync(typedQueryable, cancellation);
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

        }
    }
}
