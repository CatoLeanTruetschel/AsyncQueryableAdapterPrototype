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
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter
{
    internal class TranslatedQueryable
    {
        public TranslatedQueryable(
            QueryAdapterBase queryAdapter,
            Type elementType,
            Expression expression,
            IQueryProvider queryProvider)
        {
            Debug.Assert(queryAdapter is not null);
            Debug.Assert(elementType is not null);
            Debug.Assert(expression is not null);
            Debug.Assert(
                this is TranslatedGroupByQueryable ||
                expression.Type.IsAssignableTo(typeof(IQueryable<>).MakeGenericType(elementType)));
            Debug.Assert(queryProvider is not null);

            QueryAdapter = queryAdapter;
            ElementType = elementType;
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

    internal class TranslatedGroupByQueryable : TranslatedQueryable
    {
        public TranslatedGroupByQueryable(
            QueryAdapterBase queryAdapter,
            Type keyType,
            Type elementType,
            Expression expression,
            IQueryProvider queryProvider) : base(queryAdapter, elementType, expression, queryProvider)
        {
            Debug.Assert(keyType is not null);
            KeyType = keyType;
        }

        public Type KeyType { get; }
        public Type GroupingType => TypeHelper.GetGroupingType(KeyType, ElementType);
        public Type AsyncGroupingType => TypeHelper.GetAsyncGroupingType(KeyType, ElementType);
    }
}
