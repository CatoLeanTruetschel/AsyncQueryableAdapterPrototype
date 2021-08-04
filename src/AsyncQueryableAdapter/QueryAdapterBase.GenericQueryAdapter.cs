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
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter
{
    partial class QueryAdapterBase
    {
        private static readonly Type _elementTypeQueryAdapterTypeDefinition
         = typeof(GenericQueryAdapter<>);

        private static readonly Type _elementResultTypeQueryAdapterTypeDefinition
              = typeof(GenericQueryAdapter<,>);

        private static readonly ConditionalWeakTable<Type, IGenericElementTypeQueryAdapter> _nonGenericAdapters = new();
        private static readonly ConditionalWeakTable<Type, IGenericElementTypeQueryAdapter>.CreateValueCallback _buildQueryAdapter
            = BuildQueryAdapter;

        private static IGenericElementTypeQueryAdapter BuildQueryAdapter(Type elementType)
        {
            var type = _elementTypeQueryAdapterTypeDefinition.MakeGenericType(elementType);
            return (IGenericElementTypeQueryAdapter)Activator.CreateInstance(type)!;
        }

        private static IGenericElementTypeQueryAdapter GetQueryAdapter(Type elementType)
        {
            return _nonGenericAdapters.GetValue(elementType, _buildQueryAdapter);
        }

        private static IGenericElementResultTypeQueryAdapter BuildQueryAdapter(Type elementType, Type resultType)
        {
            return GetQueryAdapter(elementType).GetQueryAdapter(resultType);
        }

        partial interface IGenericElementTypeQueryAdapter
        {
            IGenericElementResultTypeQueryAdapter GetQueryAdapter(Type resultType);

            Type ElementType { get; }

            IQueryable GetQueryable(QueryAdapterBase queryAdapter);

            IAsyncEnumerable<object?> EvaluateAsync(
                QueryAdapterBase queryAdapter,
                IQueryable queryable,
                CancellationToken cancellation);

            ValueTask<bool> SequenceEqualAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                IAsyncEnumerable<object> second,
                object? comparer,
                CancellationToken cancellation);

            ValueTask<bool> SequenceEqualAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                IQueryable second,
                object? comparer,
                CancellationToken cancellation);
        }

        private partial interface IGenericElementResultTypeQueryAdapter
        {
            Type ElementType { get; }

            Type ResultType { get; }
        }

#pragma warning disable CA1812
        private sealed partial class GenericQueryAdapter<T> : IGenericElementTypeQueryAdapter
#pragma warning restore CA1812
        {
            private static readonly ConditionalWeakTable<Type, IGenericElementResultTypeQueryAdapter> _queryAdapters
                = new();
            private static readonly ConditionalWeakTable<Type, IGenericElementResultTypeQueryAdapter>.CreateValueCallback _buildQueryAdapter
                = BuildQueryAdapter;

            private static IGenericElementResultTypeQueryAdapter BuildQueryAdapter(Type resultType)
            {
                var type = _elementResultTypeQueryAdapterTypeDefinition.MakeGenericType(
                    typeof(T), resultType);

                return (IGenericElementResultTypeQueryAdapter)Activator.CreateInstance(type)!;
            }

            public Type ElementType => typeof(T);

            public IGenericElementResultTypeQueryAdapter GetQueryAdapter(Type resultType)
            {
                return _queryAdapters.GetValue(resultType, _buildQueryAdapter);
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

            public ValueTask<bool> SequenceEqualAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                IAsyncEnumerable<object> second,
                object? comparer,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedQueryable)
                {
                    typedQueryable = source.Cast<T>();
                }

                if (second is not IAsyncEnumerable<T> typedSecond)
                {
                    typedSecond = second.Cast<T>();
                }

                var typedComparer = comparer as IEqualityComparer<T>;

                if (comparer is not null && typedComparer is null)
                {
                    ThrowHelper.ThrowComparerMustBeOfType<T>(nameof(comparer));
                }

                return queryAdapter.SequenceEqualAsync(
                    typedQueryable,
                    typedSecond,
                    typedComparer,
                    cancellation);
            }

            public ValueTask<bool> SequenceEqualAsync(
                QueryAdapterBase queryAdapter,
                IQueryable source,
                IQueryable second,
                object? comparer,
                CancellationToken cancellation)
            {
                if (source is not IQueryable<T> typedFirst)
                {
                    typedFirst = source.Cast<T>();
                }

                if (second is not IQueryable<T> typedSecond)
                {
                    typedSecond = source.Cast<T>();
                }

                var typedComparer = comparer as IEqualityComparer<T>;

                if (comparer is not null && typedComparer is null)
                {
                    ThrowHelper.ThrowComparerMustBeOfType<T>(nameof(comparer));
                }

                return queryAdapter.SequenceEqualAsync(
                    typedFirst,
                    typedSecond,
                    typedComparer,
                    cancellation);
            }
        }

#pragma warning disable CA1812
        private sealed partial class GenericQueryAdapter<TSource, TResult>
#pragma warning restore CA1812
            : IGenericElementResultTypeQueryAdapter
        {
            public Type ElementType => typeof(TSource);

            public Type ResultType => typeof(TResult);
        }
    }
}
