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
