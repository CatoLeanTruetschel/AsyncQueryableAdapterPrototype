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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter;
using AsyncQueryableAdapterPrototype.Tests.Utils;
using Microsoft.Extensions.Options;

namespace AsyncQueryableAdapterPrototype.Tests
{
    public abstract partial class QueryAdapterSpecificationV2
    {
        private static readonly ImmutableDictionary<Type, IEnumerable> _dataSets = BuildDataSets();

        //private static partial ImmutableDictionary<Type, IEnumerable> BuildDataSets()
        //{
        //    var builder = ImmutableDictionary.CreateBuilder<Type, IEnumerable>();
        //    return builder.ToImmutable();
        //}

        private static partial ImmutableDictionary<Type, IEnumerable> BuildDataSets();

        private async ValueTask SeedAsync(ISeedHelper seedHelper, CancellationToken cancellation)
        {
            var seedMethodDefinition = new Func<ISeedHelper, IEnumerable, CancellationToken, ValueTask>(
                SeedAsync<object>).Method.GetGenericMethodDefinition();

            foreach (var (type, dataSet) in _dataSets)
            {
                var method = seedMethodDefinition.MakeGenericMethod(type);
                await (ValueTask)method.Invoke(this, new object[] { seedHelper, dataSet, CancellationToken.None });
            }
        }

        private async ValueTask SeedAsync<T>(
            ISeedHelper seedHelper,
            IEnumerable dataSet,
            CancellationToken cancellation)
        {
            var typedDataSet = (IEnumerable<T>)dataSet;

            foreach (var entry in typedDataSet)
            {
                await seedHelper.AddAsync(entry, cancellation);
            }
        }

        protected abstract ValueTask<QueryAdapterBase> GetQueryAdapterAsync(
            IOptions<AsyncQueryableOptions> options,
            Func<ISeedHelper, CancellationToken, ValueTask> seed);

        private ValueTask<QueryAdapterBase> GetQueryAdapterAsync(IOptions<AsyncQueryableOptions> options)
        {
            return GetQueryAdapterAsync(options, SeedAsync);
        }

        private ValueTask<QueryAdapterBase> GetQueryAdapterAsync()
        {
            return GetQueryAdapterAsync(Options.Create(AsyncQueryableOptions.Default));
        }

        private IQueryable<T> GetQueryable<T>()
        {
            if (_dataSets.TryGetValue(typeof(T), out var dataSet))
            {
                return ((IEnumerable<T>)dataSet).AsQueryable();
            }

            return Enumerable.Empty<T>().AsQueryable();
        }
    }
}
