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
