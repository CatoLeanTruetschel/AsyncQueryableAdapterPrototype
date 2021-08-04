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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace AsyncQueryableAdapter
{
    // This MUST be internal to prevent public APIs that accept this type instead of arguments of type IQueryable or 
    // IQueryable<T>. This would lead to problems when translating a subtree of a query to IQuerable<T> that has to be 
    // evaluated, which results in a type IAsyncEnumerable<T>. This can be converted quite easily to IAsyncQueryable<T> 
    // but not to AsyncQueryable. We had to derive from this type which breaks encapsulation and is quite messy.
    internal abstract class AsyncQueryable : IOrderedAsyncQueryable
    {
        private Expression? _expression;

        protected AsyncQueryable(
            Type elementType,
            AsyncQueryProvider provider,
            Expression expression) : this(elementType, provider)
        {
            Debug.Assert(expression is not null);
            Debug.Assert(expression.Type.IsAssignableTo(typeof(IAsyncQueryable<>).MakeGenericType(elementType)));

            _expression = expression;
        }

        protected AsyncQueryable(Type elementType, AsyncQueryProvider provider)
        {
            Debug.Assert(elementType is not null);
            Debug.Assert(provider is not null);

            ElementType = elementType;
            Provider = provider;
        }

        public Type ElementType { get; }

        public Expression Expression => _expression ??= Expression.Constant(this);

        public AsyncQueryProvider Provider { get; }

        public QueryAdapterBase QueryAdapter => Provider.QueryAdapter;

        IAsyncQueryProvider IAsyncQueryable.Provider => Provider;

        public static AsyncQueryable<T> Create<T>(QueryAdapterBase queryAdapter)
        {
            return new AsyncQueryable<T>(queryAdapter);
        }
    }

    // This MUST be internal to prevent public APIs that accept this type instead of arguments of type IQueryable or 
    // IQueryable<T>. This would lead to problems when translating a subtree of a query to IQuerable<T> that has to be 
    // evaluated, which results in a type IAsyncEnumerable<T>. This can be converted quite easily to IAsyncQueryable<T> 
    // but not to AsyncQueryable. We had to derive from this type which breaks encapsulation and is quite messy.
    internal class AsyncQueryable<T> : AsyncQueryable, IOrderedAsyncQueryable<T>
    {
        public AsyncQueryable(QueryAdapterBase queryAdapter)
            : base(typeof(T), new AsyncQueryProvider(queryAdapter)) { }

        public AsyncQueryable(AsyncQueryProvider provider, Expression expression)
            : base(typeof(T), provider, expression) { }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            var enumerableTask = Provider.ExecuteAsync<IAsyncEnumerable<T>>(Expression, cancellationToken);
            return new AsyncQueryableResultEnumerator<T>(enumerableTask, cancellationToken);
        }
    }
}
