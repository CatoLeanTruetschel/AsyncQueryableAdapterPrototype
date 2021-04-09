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
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncQueryableAdapter
{
    partial class QueryAdapterBase
    {
        private static readonly Type _nonGenericElementTypeQueryAdapterTypeDefinition
          = typeof(NonGenericElementTypeQueryAdapter<>);

        private static readonly ConditionalWeakTable<Type, INonGenericElementTypeQueryAdapter> _nonGenericAdapters = new();
        private static readonly ConditionalWeakTable<Type, INonGenericElementTypeQueryAdapter>.CreateValueCallback _buildNonGenericAdapter
            = BuildNonGenericAdapter;

        private static INonGenericElementTypeQueryAdapter BuildNonGenericAdapter(Type elementType)
        {
            var type = _nonGenericElementTypeQueryAdapterTypeDefinition.MakeGenericType(elementType);
            return (INonGenericElementTypeQueryAdapter)Activator.CreateInstance(type)!;
        }

        private static INonGenericElementTypeQueryAdapter GetNonGenericAdapter(Type elementType)
        {
            return _nonGenericAdapters.GetValue(elementType, _buildNonGenericAdapter);
        }

        private partial interface INonGenericElementTypeQueryAdapter
        {
            Type ElementType { get; }

            IQueryable GetQueryable(QueryAdapterBase queryAdapter);

            IAsyncEnumerable<object?> EvaluateAsync(
                QueryAdapterBase queryAdapter,
                IQueryable queryable,
                CancellationToken cancellation);
        }

#pragma warning disable CA1812
        private sealed partial class NonGenericElementTypeQueryAdapter<T> : INonGenericElementTypeQueryAdapter
#pragma warning restore CA1812
        {
            public Type ElementType => typeof(T);

            public INonGenericElementResultTypeQueryAdapter GetElementResultTypeQueryAdapter(Type resultType)
            {
                return _nonGenericAdapters.GetValue(resultType, _buildNonGenericAdapter);
            }

            public IQueryable GetQueryable(QueryAdapterBase queryAdapter)
            {
                return queryAdapter.GetQueryable<T>();
            }

            public IAsyncEnumerable<object?> EvaluateAsync(
                QueryAdapterBase queryAdapter, IQueryable queryable, CancellationToken cancellation)
            {
                if (queryable is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = queryable.Cast<T>();
                }

                var typedEnumerable = queryAdapter.EvaluateAsync(typedQueryable, cancellation);

                if (typedEnumerable.GetType().IsAssignableTo(typeof(IAsyncEnumerable<object>)))
                {
                    return (IAsyncEnumerable<object>)typedEnumerable;
                }

                return typedEnumerable.Cast<T, object?>();
            }
        }
    }
}
