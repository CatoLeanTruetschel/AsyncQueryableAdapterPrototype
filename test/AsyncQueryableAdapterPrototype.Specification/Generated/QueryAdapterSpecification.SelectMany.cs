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

#pragma warning disable VSTHRD200

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter;
using AsyncQueryableAdapterPrototype.Tests.Utils;
using Microsoft.Extensions.Options;
using Xunit;

using AsyncQueryable = System.Linq.AsyncQueryable;

namespace AsyncQueryableAdapterPrototype.Tests
{
    public abstract partial class QueryAdapterSpecificationV2
    {

        #region SelectManyWithNullableDoubleSourceWithNullableDoubleSelector tests

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithNullableDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, IEnumerable<double?>> selector = (p) => new double?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>>> asyncSelector = (p) => (new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>>> asyncSelector = (p) => (new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithDoubleSourceWithDoubleSelector tests

        [Fact]
        public async Task SelectManyWithDoubleSourceWithDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, IEnumerable<double>> selector = (p) => new double[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>>> asyncSelector = (p) => (new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithDoubleSourceWithDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>>> asyncSelector = (p) => (new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDoubleSourceWithDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithDecimalSourceWithDecimalSelector tests

        [Fact]
        public async Task SelectManyWithDecimalSourceWithDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, IEnumerable<decimal>> selector = (p) => new decimal[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>>> asyncSelector = (p) => (new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithDecimalSourceWithDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>>> asyncSelector = (p) => (new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDecimalSourceWithDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableDecimalSourceWithNullableDecimalSelector tests

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithNullableDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, IEnumerable<decimal?>> selector = (p) => new decimal?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>>> asyncSelector = (p) => (new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>>> asyncSelector = (p) => (new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableSingleSourceWithNullableSingleSelector tests

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithNullableSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, IEnumerable<float?>> selector = (p) => new float?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>>> asyncSelector = (p) => (new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>>> asyncSelector = (p) => (new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithSingleSourceWithSingleSelector tests

        [Fact]
        public async Task SelectManyWithSingleSourceWithSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, IEnumerable<float>> selector = (p) => new float[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>>> asyncSelector = (p) => (new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithSingleSourceWithSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>>> asyncSelector = (p) => (new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithSingleSourceWithSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithInt64SourceWithInt64Selector tests

        [Fact]
        public async Task SelectManyWithInt64SourceWithInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, IEnumerable<long>> selector = (p) => new long[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>>> asyncSelector = (p) => (new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithInt64SourceWithInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>>> asyncSelector = (p) => (new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt64SourceWithInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithInt32SourceWithInt32Selector tests

        [Fact]
        public async Task SelectManyWithInt32SourceWithInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, IEnumerable<int>> selector = (p) => new int[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>>> asyncSelector = (p) => (new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithInt32SourceWithInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>>> asyncSelector = (p) => (new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt32SourceWithInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableInt64SourceWithNullableInt64Selector tests

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithNullableInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, IEnumerable<long?>> selector = (p) => new long?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>>> asyncSelector = (p) => (new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>>> asyncSelector = (p) => (new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableInt32SourceWithNullableInt32Selector tests

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithNullableInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, IEnumerable<int?>> selector = (p) => new int?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>>> asyncSelector = (p) => (new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>>> asyncSelector = (p) => (new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableDoubleSourceWithWithIndexedNullableDoubleSelector tests

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, int, IEnumerable<double?>> selector = (p, i) => i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, IAsyncEnumerable<double?>>> asyncSelector = (p, i) => (i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, IAsyncEnumerable<double?>>> asyncSelector = (p, i) => (i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, IAsyncEnumerable<double?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithDoubleSourceWithWithIndexedDoubleSelector tests

        [Fact]
        public async Task SelectManyWithDoubleSourceWithWithIndexedDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, int, IEnumerable<double>> selector = (p, i) => i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, IAsyncEnumerable<double>>> asyncSelector = (p, i) => (i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithDoubleSourceWithWithIndexedDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, IAsyncEnumerable<double>>> asyncSelector = (p, i) => (i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDoubleSourceWithWithIndexedDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, IAsyncEnumerable<double>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithDecimalSourceWithWithIndexedDecimalSelector tests

        [Fact]
        public async Task SelectManyWithDecimalSourceWithWithIndexedDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, int, IEnumerable<decimal>> selector = (p, i) => i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, IAsyncEnumerable<decimal>>> asyncSelector = (p, i) => (i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithDecimalSourceWithWithIndexedDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, IAsyncEnumerable<decimal>>> asyncSelector = (p, i) => (i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDecimalSourceWithWithIndexedDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, IAsyncEnumerable<decimal>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableDecimalSourceWithWithIndexedNullableDecimalSelector tests

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, int, IEnumerable<decimal?>> selector = (p, i) => i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, IAsyncEnumerable<decimal?>>> asyncSelector = (p, i) => (i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, IAsyncEnumerable<decimal?>>> asyncSelector = (p, i) => (i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, IAsyncEnumerable<decimal?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableSingleSourceWithWithIndexedNullableSingleSelector tests

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithWithIndexedNullableSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, int, IEnumerable<float?>> selector = (p, i) => i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, IAsyncEnumerable<float?>>> asyncSelector = (p, i) => (i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, IAsyncEnumerable<float?>>> asyncSelector = (p, i) => (i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, IAsyncEnumerable<float?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithSingleSourceWithWithIndexedSingleSelector tests

        [Fact]
        public async Task SelectManyWithSingleSourceWithWithIndexedSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, int, IEnumerable<float>> selector = (p, i) => i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, IAsyncEnumerable<float>>> asyncSelector = (p, i) => (i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithSingleSourceWithWithIndexedSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, IAsyncEnumerable<float>>> asyncSelector = (p, i) => (i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithSingleSourceWithWithIndexedSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, IAsyncEnumerable<float>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithInt64SourceWithWithIndexedInt64Selector tests

        [Fact]
        public async Task SelectManyWithInt64SourceWithWithIndexedInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, int, IEnumerable<long>> selector = (p, i) => i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, IAsyncEnumerable<long>>> asyncSelector = (p, i) => (i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithInt64SourceWithWithIndexedInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, IAsyncEnumerable<long>>> asyncSelector = (p, i) => (i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt64SourceWithWithIndexedInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, IAsyncEnumerable<long>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithInt32SourceWithWithIndexedInt32Selector tests

        [Fact]
        public async Task SelectManyWithInt32SourceWithWithIndexedInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, int, IEnumerable<int>> selector = (p, i) => i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, IAsyncEnumerable<int>>> asyncSelector = (p, i) => (i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithInt32SourceWithWithIndexedInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, IAsyncEnumerable<int>>> asyncSelector = (p, i) => (i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt32SourceWithWithIndexedInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, IAsyncEnumerable<int>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableInt64SourceWithWithIndexedNullableInt64Selector tests

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithWithIndexedNullableInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, int, IEnumerable<long?>> selector = (p, i) => i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, IAsyncEnumerable<long?>>> asyncSelector = (p, i) => (i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, IAsyncEnumerable<long?>>> asyncSelector = (p, i) => (i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, IAsyncEnumerable<long?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableInt32SourceWithWithIndexedNullableInt32Selector tests

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithWithIndexedNullableInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, int, IEnumerable<int?>> selector = (p, i) => i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, IAsyncEnumerable<int?>>> asyncSelector = (p, i) => (i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectMany<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, IAsyncEnumerable<int?>>> asyncSelector = (p, i) => (i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, IAsyncEnumerable<int?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'collectionSelector' parameter
            Func<double?, IEnumerable<double?>> collectionSelector = (p) => new double?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>>> asyncCollectionSelector = (p) => (new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?, double?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>>> asyncCollectionSelector = (p) => (new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>>> asyncCollectionSelector = (p) => (new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelector tests

        [Fact]
        public async Task SelectManyWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'collectionSelector' parameter
            Func<double, IEnumerable<double>> collectionSelector = (p) => new double[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>>> asyncCollectionSelector = (p) => (new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double, double>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>>> asyncCollectionSelector = (p) => (new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>>> asyncCollectionSelector = (p) => (new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelector tests

        [Fact]
        public async Task SelectManyWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'collectionSelector' parameter
            Func<decimal, IEnumerable<decimal>> collectionSelector = (p) => new decimal[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>>> asyncCollectionSelector = (p) => (new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal, decimal>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>>> asyncCollectionSelector = (p) => (new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>>> asyncCollectionSelector = (p) => (new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'collectionSelector' parameter
            Func<decimal?, IEnumerable<decimal?>> collectionSelector = (p) => new decimal?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>>> asyncCollectionSelector = (p) => (new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?, decimal?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>>> asyncCollectionSelector = (p) => (new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>>> asyncCollectionSelector = (p) => (new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'collectionSelector' parameter
            Func<float?, IEnumerable<float?>> collectionSelector = (p) => new float?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>>> asyncCollectionSelector = (p) => (new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?, float?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>>> asyncCollectionSelector = (p) => (new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>>> asyncCollectionSelector = (p) => (new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelector tests

        [Fact]
        public async Task SelectManyWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'collectionSelector' parameter
            Func<float, IEnumerable<float>> collectionSelector = (p) => new float[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>>> asyncCollectionSelector = (p) => (new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float, float>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>>> asyncCollectionSelector = (p) => (new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>>> asyncCollectionSelector = (p) => (new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelector tests

        [Fact]
        public async Task SelectManyWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'collectionSelector' parameter
            Func<long, IEnumerable<long>> collectionSelector = (p) => new long[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>>> asyncCollectionSelector = (p) => (new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long, long>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>>> asyncCollectionSelector = (p) => (new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>>> asyncCollectionSelector = (p) => (new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelector tests

        [Fact]
        public async Task SelectManyWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'collectionSelector' parameter
            Func<int, IEnumerable<int>> collectionSelector = (p) => new int[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>>> asyncCollectionSelector = (p) => (new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int, int>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>>> asyncCollectionSelector = (p) => (new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>>> asyncCollectionSelector = (p) => (new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'collectionSelector' parameter
            Func<long?, IEnumerable<long?>> collectionSelector = (p) => new long?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>>> asyncCollectionSelector = (p) => (new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?, long?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>>> asyncCollectionSelector = (p) => (new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>>> asyncCollectionSelector = (p) => (new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'collectionSelector' parameter
            Func<int?, IEnumerable<int?>> collectionSelector = (p) => new int?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>>> asyncCollectionSelector = (p) => (new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?, int?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>>> asyncCollectionSelector = (p) => (new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>>> asyncCollectionSelector = (p) => (new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'collectionSelector' parameter
            Func<double?, int, IEnumerable<double?>> collectionSelector = (p, i) => i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, IAsyncEnumerable<double?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?, double?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, IAsyncEnumerable<double?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, IAsyncEnumerable<double?>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, IAsyncEnumerable<double?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelector tests

        [Fact]
        public async Task SelectManyWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'collectionSelector' parameter
            Func<double, int, IEnumerable<double>> collectionSelector = (p, i) => i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, IAsyncEnumerable<double>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double, double>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, IAsyncEnumerable<double>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, IAsyncEnumerable<double>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, IAsyncEnumerable<double>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelector tests

        [Fact]
        public async Task SelectManyWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'collectionSelector' parameter
            Func<decimal, int, IEnumerable<decimal>> collectionSelector = (p, i) => i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, IAsyncEnumerable<decimal>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal, decimal>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, IAsyncEnumerable<decimal>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, IAsyncEnumerable<decimal>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, IAsyncEnumerable<decimal>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'collectionSelector' parameter
            Func<decimal?, int, IEnumerable<decimal?>> collectionSelector = (p, i) => i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, IAsyncEnumerable<decimal?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?, decimal?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, IAsyncEnumerable<decimal?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, IAsyncEnumerable<decimal?>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, IAsyncEnumerable<decimal?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'collectionSelector' parameter
            Func<float?, int, IEnumerable<float?>> collectionSelector = (p, i) => i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, IAsyncEnumerable<float?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?, float?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, IAsyncEnumerable<float?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, IAsyncEnumerable<float?>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, IAsyncEnumerable<float?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelector tests

        [Fact]
        public async Task SelectManyWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'collectionSelector' parameter
            Func<float, int, IEnumerable<float>> collectionSelector = (p, i) => i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, IAsyncEnumerable<float>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float, float>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, IAsyncEnumerable<float>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, IAsyncEnumerable<float>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, IAsyncEnumerable<float>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelector tests

        [Fact]
        public async Task SelectManyWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'collectionSelector' parameter
            Func<long, int, IEnumerable<long>> collectionSelector = (p, i) => i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, IAsyncEnumerable<long>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long, long>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, IAsyncEnumerable<long>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, IAsyncEnumerable<long>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, IAsyncEnumerable<long>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelector tests

        [Fact]
        public async Task SelectManyWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'collectionSelector' parameter
            Func<int, int, IEnumerable<int>> collectionSelector = (p, i) => i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, IAsyncEnumerable<int>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int, int>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, IAsyncEnumerable<int>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, IAsyncEnumerable<int>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, IAsyncEnumerable<int>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'collectionSelector' parameter
            Func<long?, int, IEnumerable<long?>> collectionSelector = (p, i) => i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, IAsyncEnumerable<long?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?, long?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, IAsyncEnumerable<long?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, IAsyncEnumerable<long?>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, IAsyncEnumerable<long?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'collectionSelector' parameter
            Func<int?, int, IEnumerable<int?>> collectionSelector = (p, i) => i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, IAsyncEnumerable<int?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?, int?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectMany<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, IAsyncEnumerable<int?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, IAsyncEnumerable<int?>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, IAsyncEnumerable<int?>>> asyncCollectionSelector = (p, i) => (i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable();

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectMany<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, int, IEnumerable<double?>> selector = (p, i) => i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<double?>>((i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<double?>>((i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithDoubleSourceWithWithIndexedDoubleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithWithIndexedDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, int, IEnumerable<double>> selector = (p, i) => i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<double>>((i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithWithIndexedDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<double>>((i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithWithIndexedDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithDecimalSourceWithWithIndexedDecimalSelector tests

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithWithIndexedDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, int, IEnumerable<decimal>> selector = (p, i) => i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<decimal>>((i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithWithIndexedDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<decimal>>((i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithWithIndexedDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, int, IEnumerable<decimal?>> selector = (p, i) => i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<decimal?>>((i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<decimal?>>((i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableSingleSourceWithWithIndexedNullableSingleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithWithIndexedNullableSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, int, IEnumerable<float?>> selector = (p, i) => i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<float?>>((i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<float?>>((i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithSingleSourceWithWithIndexedSingleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithWithIndexedSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, int, IEnumerable<float>> selector = (p, i) => i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<float>>((i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithWithIndexedSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<float>>((i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithWithIndexedSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithInt64SourceWithWithIndexedInt64Selector tests

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithWithIndexedInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, int, IEnumerable<long>> selector = (p, i) => i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<long>>((i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithWithIndexedInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<long>>((i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithWithIndexedInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithInt32SourceWithWithIndexedInt32Selector tests

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithWithIndexedInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, int, IEnumerable<int>> selector = (p, i) => i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<int>>((i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithWithIndexedInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<int>>((i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithWithIndexedInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableInt64SourceWithWithIndexedNullableInt64Selector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithWithIndexedNullableInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, int, IEnumerable<long?>> selector = (p, i) => i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<long?>>((i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<long?>>((i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableInt32SourceWithWithIndexedNullableInt32Selector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithWithIndexedNullableInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, int, IEnumerable<int?>> selector = (p, i) => i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<int?>>((i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = (p, i) => new ValueTask<IAsyncEnumerable<int?>>((i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableDoubleSourceWithNullableDoubleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithNullableDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, IEnumerable<double?>> selector = (p) => new double?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<double?>>((new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<double?>>((new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithDoubleSourceWithDoubleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, IEnumerable<double>> selector = (p) => new double[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<double>>((new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<double>>((new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithDecimalSourceWithDecimalSelector tests

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, IEnumerable<decimal>> selector = (p) => new decimal[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<decimal>>((new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<decimal>>((new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableDecimalSourceWithNullableDecimalSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithNullableDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, IEnumerable<decimal?>> selector = (p) => new decimal?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<decimal?>>((new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<decimal?>>((new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableSingleSourceWithNullableSingleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithNullableSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, IEnumerable<float?>> selector = (p) => new float?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<float?>>((new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<float?>>((new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithSingleSourceWithSingleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, IEnumerable<float>> selector = (p) => new float[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<float>>((new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<float>>((new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithInt64SourceWithInt64Selector tests

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, IEnumerable<long>> selector = (p) => new long[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<long>>((new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<long>>((new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithInt32SourceWithInt32Selector tests

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, IEnumerable<int>> selector = (p) => new int[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<int>>((new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<int>>((new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableInt64SourceWithNullableInt64Selector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithNullableInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, IEnumerable<long?>> selector = (p) => new long?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<long?>>((new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<long?>>((new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableInt32SourceWithNullableInt32Selector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithNullableInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, IEnumerable<int?>> selector = (p) => new int?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<int?>>((new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = (p) => new ValueTask<IAsyncEnumerable<int?>>((new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'collectionSelector' parameter
            Func<double?, int, IEnumerable<double?>> collectionSelector = (p, i) => i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<double?>>((i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?, double?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<double?>>((i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<double?>>((i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'collectionSelector' parameter
            Func<double, int, IEnumerable<double>> collectionSelector = (p, i) => i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<double>>((i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double, double>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<double>>((i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<double>>((i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'collectionSelector' parameter
            Func<decimal, int, IEnumerable<decimal>> collectionSelector = (p, i) => i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<decimal>>((i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal, decimal>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<decimal>>((i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<decimal>>((i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'collectionSelector' parameter
            Func<decimal?, int, IEnumerable<decimal?>> collectionSelector = (p, i) => i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<decimal?>>((i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?, decimal?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<decimal?>>((i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<decimal?>>((i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'collectionSelector' parameter
            Func<float?, int, IEnumerable<float?>> collectionSelector = (p, i) => i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<float?>>((i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?, float?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<float?>>((i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<float?>>((i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'collectionSelector' parameter
            Func<float, int, IEnumerable<float>> collectionSelector = (p, i) => i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<float>>((i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float, float>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<float>>((i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<float>>((i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'collectionSelector' parameter
            Func<long, int, IEnumerable<long>> collectionSelector = (p, i) => i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<long>>((i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long, long>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<long>>((i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<long>>((i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'collectionSelector' parameter
            Func<int, int, IEnumerable<int>> collectionSelector = (p, i) => i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<int>>((i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int, int>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<int>>((i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<int>>((i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'collectionSelector' parameter
            Func<long?, int, IEnumerable<long?>> collectionSelector = (p, i) => i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<long?>>((i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?, long?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<long?>>((i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<long?>>((i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'collectionSelector' parameter
            Func<int?, int, IEnumerable<int?>> collectionSelector = (p, i) => i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<int?>>((i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?, int?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<int?>>((i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p, i) => new ValueTask<IAsyncEnumerable<int?>>((i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'collectionSelector' parameter
            Func<double?, IEnumerable<double?>> collectionSelector = (p) => new double?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<double?>>((new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?, double?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<double?>>((new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<double?>>((new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'collectionSelector' parameter
            Func<double, IEnumerable<double>> collectionSelector = (p) => new double[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<double>>((new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double, double>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<double>>((new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<double>>((new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'collectionSelector' parameter
            Func<decimal, IEnumerable<decimal>> collectionSelector = (p) => new decimal[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<decimal>>((new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal, decimal>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<decimal>>((new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<decimal>>((new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'collectionSelector' parameter
            Func<decimal?, IEnumerable<decimal?>> collectionSelector = (p) => new decimal?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<decimal?>>((new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?, decimal?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<decimal?>>((new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<decimal?>>((new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'collectionSelector' parameter
            Func<float?, IEnumerable<float?>> collectionSelector = (p) => new float?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<float?>>((new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?, float?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<float?>>((new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<float?>>((new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'collectionSelector' parameter
            Func<float, IEnumerable<float>> collectionSelector = (p) => new float[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<float>>((new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float, float>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<float>>((new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<float>>((new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'collectionSelector' parameter
            Func<long, IEnumerable<long>> collectionSelector = (p) => new long[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<long>>((new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long, long>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<long>>((new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<long>>((new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'collectionSelector' parameter
            Func<int, IEnumerable<int>> collectionSelector = (p) => new int[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<int>>((new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int, int>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<int>>((new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<int>>((new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'collectionSelector' parameter
            Func<long?, IEnumerable<long?>> collectionSelector = (p) => new long?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<long?>>((new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?, long?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<long?>>((new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<long?>>((new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'collectionSelector' parameter
            Func<int?, IEnumerable<int?>> collectionSelector = (p) => new int?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<int?>>((new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?, int?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwait<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<int?>>((new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p) => new ValueTask<IAsyncEnumerable<int?>>((new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwait<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, IEnumerable<double?>> selector = (p) => new double?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<double?>>((new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<double?>>((new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithDoubleSourceWithDoubleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, IEnumerable<double>> selector = (p) => new double[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<double>>((new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<double>>((new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithDecimalSourceWithDecimalSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, IEnumerable<decimal>> selector = (p) => new decimal[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<decimal>>((new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<decimal>>((new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, IEnumerable<decimal?>> selector = (p) => new decimal?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<decimal?>>((new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<decimal?>>((new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableSingleSourceWithNullableSingleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithNullableSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, IEnumerable<float?>> selector = (p) => new float?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<float?>>((new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<float?>>((new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithSingleSourceWithSingleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, IEnumerable<float>> selector = (p) => new float[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<float>>((new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<float>>((new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithInt64SourceWithInt64Selector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, IEnumerable<long>> selector = (p) => new long[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<long>>((new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<long>>((new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithInt32SourceWithInt32Selector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, IEnumerable<int>> selector = (p) => new int[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<int>>((new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<int>>((new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableInt64SourceWithNullableInt64Selector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithNullableInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, IEnumerable<long?>> selector = (p) => new long?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<long?>>((new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<long?>>((new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableInt32SourceWithNullableInt32Selector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithNullableInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, IEnumerable<int?>> selector = (p) => new int?[] { p + 3, p - 1, p + 1 };

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<int?>>((new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = (p, c) => new ValueTask<IAsyncEnumerable<int?>>((new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, int, IEnumerable<double?>> selector = (p, i) => i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<double?>>((i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<double?>>((i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, int, IEnumerable<double>> selector = (p, i) => i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<double>>((i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<double>>((i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, int, IEnumerable<decimal>> selector = (p, i) => i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<decimal>>((i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<decimal>>((i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, int, IEnumerable<decimal?>> selector = (p, i) => i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<decimal?>>((i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<decimal?>>((i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, int, IEnumerable<float?>> selector = (p, i) => i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<float?>>((i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<float?>>((i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithSingleSourceWithWithIndexedSingleSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithWithIndexedSingleSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, int, IEnumerable<float>> selector = (p, i) => i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<float>>((i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithWithIndexedSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<float>>((i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithWithIndexedSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithInt64SourceWithWithIndexedInt64Selector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithWithIndexedInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, int, IEnumerable<long>> selector = (p, i) => i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<long>>((i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithWithIndexedInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<long>>((i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithWithIndexedInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithInt32SourceWithWithIndexedInt32Selector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithWithIndexedInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, int, IEnumerable<int>> selector = (p, i) => i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<int>>((i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithWithIndexedInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<int>>((i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithWithIndexedInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64Selector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, int, IEnumerable<long?>> selector = (p, i) => i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<long?>>((i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<long?>>((i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32Selector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32SelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, int, IEnumerable<int?>> selector = (p, i) => i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 });

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<int?>>((i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<int?>>((i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'collectionSelector' parameter
            Func<double?, IEnumerable<double?>> collectionSelector = (p) => new double?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<double?>>((new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?, double?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<double?>>((new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<double?>>((new double?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'collectionSelector' parameter
            Func<double, IEnumerable<double>> collectionSelector = (p) => new double[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<double>>((new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double, double>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<double>>((new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithDoubleCollectionSelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<double>>((new double[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'collectionSelector' parameter
            Func<decimal, IEnumerable<decimal>> collectionSelector = (p) => new decimal[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<decimal>>((new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal, decimal>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<decimal>>((new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithDecimalCollectionSelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<decimal>>((new decimal[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'collectionSelector' parameter
            Func<decimal?, IEnumerable<decimal?>> collectionSelector = (p) => new decimal?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<decimal?>>((new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?, decimal?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<decimal?>>((new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<decimal?>>((new decimal?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'collectionSelector' parameter
            Func<float?, IEnumerable<float?>> collectionSelector = (p) => new float?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<float?>>((new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?, float?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<float?>>((new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<float?>>((new float?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'collectionSelector' parameter
            Func<float, IEnumerable<float>> collectionSelector = (p) => new float[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<float>>((new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float, float>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<float>>((new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithSingleCollectionSelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<float>>((new float[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'collectionSelector' parameter
            Func<long, IEnumerable<long>> collectionSelector = (p) => new long[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<long>>((new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long, long>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<long>>((new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithInt64CollectionSelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<long>>((new long[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'collectionSelector' parameter
            Func<int, IEnumerable<int>> collectionSelector = (p) => new int[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<int>>((new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int, int>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<int>>((new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithInt32CollectionSelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<int>>((new int[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'collectionSelector' parameter
            Func<long?, IEnumerable<long?>> collectionSelector = (p) => new long?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<long?>>((new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?, long?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<long?>>((new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<long?>>((new long?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'collectionSelector' parameter
            Func<int?, IEnumerable<int?>> collectionSelector = (p) => new int?[] { p + 3, p - 1, p + 1 };

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<int?>>((new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?, int?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<int?>>((new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p, c) => new ValueTask<IAsyncEnumerable<int?>>((new int?[] { p + 3, p - 1, p + 1 }).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'collectionSelector' parameter
            Func<double?, int, IEnumerable<double?>> collectionSelector = (p, i) => i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<double?>>((i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double?, double?, double?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<double?>>((i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleCollectionSelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<IAsyncEnumerable<double?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<double?>>((i % 3 == 0 ? new double?[] { 3D } : (new double?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double?, double?, double?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'collectionSelector' parameter
            Func<double, int, IEnumerable<double>> collectionSelector = (p, i) => i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<double>>((i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<double, double, double>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<double>>((i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleCollectionSelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<IAsyncEnumerable<double>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<double>>((i % 3 == 0 ? new double[] { 3D } : (new double[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<double, double, double>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'collectionSelector' parameter
            Func<decimal, int, IEnumerable<decimal>> collectionSelector = (p, i) => i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<decimal>>((i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal, decimal, decimal>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<decimal>>((i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalCollectionSelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<decimal>>((i % 3 == 0 ? new decimal[] { 3M } : (new decimal[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal, decimal, decimal>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'collectionSelector' parameter
            Func<decimal?, int, IEnumerable<decimal?>> collectionSelector = (p, i) => i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<decimal?>>((i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<decimal?, decimal?, decimal?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<decimal?>>((i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalCollectionSelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<IAsyncEnumerable<decimal?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<decimal?>>((i % 3 == 0 ? new decimal?[] { 3M } : (new decimal?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'collectionSelector' parameter
            Func<float?, int, IEnumerable<float?>> collectionSelector = (p, i) => i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<float?>>((i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float?, float?, float?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<float?>>((i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleCollectionSelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<IAsyncEnumerable<float?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<float?>>((i % 3 == 0 ? new float?[] { 3F } : (new float?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float?, float?, float?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'collectionSelector' parameter
            Func<float, int, IEnumerable<float>> collectionSelector = (p, i) => i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<float>>((i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<float, float, float>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<float>>((i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithSingleSourceWithWithIndexedSingleCollectionSelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<IAsyncEnumerable<float>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<float>>((i % 3 == 0 ? new float[] { 3F } : (new float[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<float, float, float>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'collectionSelector' parameter
            Func<long, int, IEnumerable<long>> collectionSelector = (p, i) => i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<long>>((i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long, long, long>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<long>>((i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt64SourceWithWithIndexedInt64CollectionSelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<IAsyncEnumerable<long>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<long>>((i % 3 == 0 ? new long[] { 3L } : (new long[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long, long, long>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'collectionSelector' parameter
            Func<int, int, IEnumerable<int>> collectionSelector = (p, i) => i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<int>>((i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int, int, int>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<int>>((i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithInt32SourceWithWithIndexedInt32CollectionSelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<IAsyncEnumerable<int>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<int>>((i % 3 == 0 ? new int[] { 3 } : (new int[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int, int, int>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'collectionSelector' parameter
            Func<long?, int, IEnumerable<long?>> collectionSelector = (p, i) => i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<long?>>((i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<long?, long?, long?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<long?>>((i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64CollectionSelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<IAsyncEnumerable<long?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<long?>>((i % 3 == 0 ? new long?[] { 3L } : (new long?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<long?, long?, long?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectManyAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorIsEquivalentToSelectManyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'collectionSelector' parameter
            Func<int?, int, IEnumerable<int?>> collectionSelector = (p, i) => i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 });

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<int?>>((i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SelectMany<int?, int?, int?>(source, collectionSelector, resultSelector);

            // Act
            var result = await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<int?>>((i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullCollectionSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectManyAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32CollectionSelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncCollectionSelector' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<IAsyncEnumerable<int?>>>> asyncCollectionSelector = (p, i, c) => new ValueTask<IAsyncEnumerable<int?>>((i % 3 == 0 ? new int?[] { 3 } : (new int?[] { p + 3, p - 1, p + 1 })).ToAsyncEnumerable());

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectManyAwaitWithCancellation<int?, int?, int?>(asyncSource, asyncCollectionSelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
