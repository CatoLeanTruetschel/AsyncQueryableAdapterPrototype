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
