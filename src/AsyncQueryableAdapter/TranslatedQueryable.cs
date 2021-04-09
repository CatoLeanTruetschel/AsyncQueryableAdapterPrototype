using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace AsyncQueryableAdapter
{
    internal sealed class TranslatedQueryable
    {
        public TranslatedQueryable(QueryAdapterBase queryAdapter, Type elementType, Expression expression, IQueryProvider queryProvider)
        {
            Debug.Assert(queryAdapter is not null);
            Debug.Assert(elementType is not null);
            Debug.Assert(expression is not null);
            Debug.Assert(expression.Type.IsAssignableTo(typeof(IQueryable<>).MakeGenericType(elementType)));
            Debug.Assert(queryProvider is not null);

            QueryAdapter = queryAdapter;
            ElementType = elementType;
            Expression = expression;
            QueryProvider = queryProvider;
        }

        public TranslatedQueryable(QueryAdapterBase queryAdapter, Expression expression, IQueryProvider queryProvider)
        {
            Debug.Assert(queryAdapter is not null);
            Debug.Assert(expression is not null);
            Debug.Assert(expression.Type.IsConstructedGenericType && expression.Type.GetGenericTypeDefinition() == typeof(IQueryable<>)); // TODO: Can we lower this restriction?
            Debug.Assert(queryProvider is not null);
            
            QueryAdapter = queryAdapter;
            ElementType = expression.Type.GetGenericArguments().First(); 
            Expression = expression;
            QueryProvider = queryProvider;
        }

        public QueryAdapterBase QueryAdapter { get; }

        public Type ElementType { get; }

        public Expression Expression { get; }

        public IQueryProvider QueryProvider { get; }

        public IQueryable GetQueryable()
        {
            return QueryProvider.CreateQuery(Expression);
        }
    }
}
