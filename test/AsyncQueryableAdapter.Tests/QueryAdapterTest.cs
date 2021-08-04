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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapterPrototype.Tests;
using AsyncQueryableAdapterPrototype.Tests.Utils;

namespace AsyncQueryableAdapter.Tests
{
    public sealed class QueryAdapterTest : QueryAdapterSpecification
    {
        protected override async ValueTask<QueryAdapterBase> GetQueryAdapterAsync(
            AsyncQueryableOptions options,
            Func<ISeedHelper, CancellationToken, ValueTask> seed)
        {
            return await QueryAdapter.CreateAsync(options, seed);
        }
    }

    internal sealed class QueryAdapter : QueryAdapterBase
    {
        private readonly ImmutableDictionary<Type, IEnumerable> _entries;

        private QueryAdapter(
            AsyncQueryableOptions options,
            ImmutableDictionary<Type, IEnumerable> entries) : base(options)
        {
            Debug.Assert(entries is not null);

            _entries = entries;
        }

        public static async ValueTask<QueryAdapter> CreateAsync(
            AsyncQueryableOptions options,
            Func<ISeedHelper, CancellationToken, ValueTask> seed)
        {
            var entriesBuilder = new QueryAdapterEntriesBuilder();
            await seed(entriesBuilder, CancellationToken.None).ConfigureAwait(false);
            var entries = entriesBuilder.GetEntries();
            return new QueryAdapter(options, entries);
        }

        protected override IQueryable<T> GetQueryable<T>()
        {
            ImmutableList<T> entries = null;

            if (!_entries.TryGetValue(typeof(T), out Unsafe.As<ImmutableList<T>, IEnumerable>(ref entries)))
            {
                entries = ImmutableList<T>.Empty;
            }

            return entries.AsQueryable();
        }

        protected override IAsyncEnumerable<T> EvaluateAsync<T>(IQueryable<T> queryable, CancellationToken cancellation)
        {
            return queryable.ToAsyncEnumerable();
        }

        private sealed class QueryAdapterEntriesBuilder : ISeedHelper
        {
            private readonly ImmutableDictionary<Type, IEnumerable>.Builder _entriesBuilder;

            public QueryAdapterEntriesBuilder()
            {
                _entriesBuilder = ImmutableDictionary.CreateBuilder<Type, IEnumerable>();
            }

            public ValueTask AddAsync<T>(T obj, CancellationToken cancellation)
            {
                ImmutableList<T> entries = null;

                if (!_entriesBuilder.TryGetValue(typeof(T), out Unsafe.As<ImmutableList<T>, IEnumerable>(ref entries)))
                {
                    entries = ImmutableList<T>.Empty;
                }

                entries = entries.Add(obj);
                _entriesBuilder[typeof(T)] = entries;

                return default;
            }

            public ImmutableDictionary<Type, IEnumerable> GetEntries()
            {
                return _entriesBuilder.ToImmutable();
            }
        }
    }
}
