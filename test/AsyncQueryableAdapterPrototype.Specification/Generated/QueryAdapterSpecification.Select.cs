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

        #region SelectWithNullableDoubleSourceWithWithIndexedNullableDoubleSelector tests

        [Fact]
        public async Task SelectWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, int, double?> selector = (p, i) => i % 3 == 0 ? ((double)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, double?>> asyncSelector = (p, i) => i % 3 == 0 ? ((double)3) : (p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, double?>> asyncSelector = (p, i) => i % 3 == 0 ? ((double)3) : (p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, double?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithDoubleSourceWithWithIndexedDoubleSelector tests

        [Fact]
        public async Task SelectWithDoubleSourceWithWithIndexedDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, int, double> selector = (p, i) => i % 3 == 0 ? 3D : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, double>> asyncSelector = (p, i) => i % 3 == 0 ? 3D : (p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithDoubleSourceWithWithIndexedDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, double>> asyncSelector = (p, i) => i % 3 == 0 ? 3D : (p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithDoubleSourceWithWithIndexedDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, double>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithDecimalSourceWithWithIndexedDecimalSelector tests

        [Fact]
        public async Task SelectWithDecimalSourceWithWithIndexedDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, int, decimal> selector = (p, i) => i % 3 == 0 ? 3M : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, decimal>> asyncSelector = (p, i) => i % 3 == 0 ? 3M : (p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithDecimalSourceWithWithIndexedDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, decimal>> asyncSelector = (p, i) => i % 3 == 0 ? 3M : (p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithDecimalSourceWithWithIndexedDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, decimal>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithNullableDecimalSourceWithWithIndexedNullableDecimalSelector tests

        [Fact]
        public async Task SelectWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, int, decimal?> selector = (p, i) => i % 3 == 0 ? ((decimal)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, decimal?>> asyncSelector = (p, i) => i % 3 == 0 ? ((decimal)3) : (p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, decimal?>> asyncSelector = (p, i) => i % 3 == 0 ? ((decimal)3) : (p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, decimal?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithNullableSingleSourceWithWithIndexedNullableSingleSelector tests

        [Fact]
        public async Task SelectWithNullableSingleSourceWithWithIndexedNullableSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, int, float?> selector = (p, i) => i % 3 == 0 ? ((float)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, float?>> asyncSelector = (p, i) => i % 3 == 0 ? ((float)3) : (p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, float?>> asyncSelector = (p, i) => i % 3 == 0 ? ((float)3) : (p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, float?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithSingleSourceWithWithIndexedSingleSelector tests

        [Fact]
        public async Task SelectWithSingleSourceWithWithIndexedSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, int, float> selector = (p, i) => i % 3 == 0 ? 3F : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, float>> asyncSelector = (p, i) => i % 3 == 0 ? 3F : (p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithSingleSourceWithWithIndexedSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, float>> asyncSelector = (p, i) => i % 3 == 0 ? 3F : (p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithSingleSourceWithWithIndexedSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, float>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithInt64SourceWithWithIndexedInt64Selector tests

        [Fact]
        public async Task SelectWithInt64SourceWithWithIndexedInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, int, long> selector = (p, i) => i % 3 == 0 ? 3L : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, long>> asyncSelector = (p, i) => i % 3 == 0 ? 3L : (p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithInt64SourceWithWithIndexedInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, long>> asyncSelector = (p, i) => i % 3 == 0 ? 3L : (p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithInt64SourceWithWithIndexedInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, long>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithInt32SourceWithWithIndexedInt32Selector tests

        [Fact]
        public async Task SelectWithInt32SourceWithWithIndexedInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, int, int> selector = (p, i) => i % 3 == 0 ? 3 : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, int>> asyncSelector = (p, i) => i % 3 == 0 ? 3 : (p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithInt32SourceWithWithIndexedInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, int>> asyncSelector = (p, i) => i % 3 == 0 ? 3 : (p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithInt32SourceWithWithIndexedInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, int>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithNullableInt64SourceWithWithIndexedNullableInt64Selector tests

        [Fact]
        public async Task SelectWithNullableInt64SourceWithWithIndexedNullableInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, int, long?> selector = (p, i) => i % 3 == 0 ? ((long)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, long?>> asyncSelector = (p, i) => i % 3 == 0 ? ((long)3) : (p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, long?>> asyncSelector = (p, i) => i % 3 == 0 ? ((long)3) : (p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, long?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithNullableInt32SourceWithWithIndexedNullableInt32Selector tests

        [Fact]
        public async Task SelectWithNullableInt32SourceWithWithIndexedNullableInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, int, int?> selector = (p, i) => i % 3 == 0 ? ((int)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, int?>> asyncSelector = (p, i) => i % 3 == 0 ? ((int)3) : (p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, int?>> asyncSelector = (p, i) => i % 3 == 0 ? ((int)3) : (p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, int?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithNullableDoubleSourceWithNullableDoubleSelector tests

        [Fact]
        public async Task SelectWithNullableDoubleSourceWithNullableDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, double?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?>> asyncSelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithNullableDoubleSourceWithNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?>> asyncSelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithNullableDoubleSourceWithNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithDoubleSourceWithDoubleSelector tests

        [Fact]
        public async Task SelectWithDoubleSourceWithDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, double> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double>> asyncSelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithDoubleSourceWithDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double>> asyncSelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithDoubleSourceWithDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithDecimalSourceWithDecimalSelector tests

        [Fact]
        public async Task SelectWithDecimalSourceWithDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, decimal> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal>> asyncSelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithDecimalSourceWithDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal>> asyncSelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithDecimalSourceWithDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithNullableDecimalSourceWithNullableDecimalSelector tests

        [Fact]
        public async Task SelectWithNullableDecimalSourceWithNullableDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, decimal?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncSelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithNullableDecimalSourceWithNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncSelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithNullableDecimalSourceWithNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithNullableSingleSourceWithNullableSingleSelector tests

        [Fact]
        public async Task SelectWithNullableSingleSourceWithNullableSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, float?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?>> asyncSelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithNullableSingleSourceWithNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?>> asyncSelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithNullableSingleSourceWithNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithSingleSourceWithSingleSelector tests

        [Fact]
        public async Task SelectWithSingleSourceWithSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, float> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float>> asyncSelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithSingleSourceWithSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float>> asyncSelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithSingleSourceWithSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithInt64SourceWithInt64Selector tests

        [Fact]
        public async Task SelectWithInt64SourceWithInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, long> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long>> asyncSelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithInt64SourceWithInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long>> asyncSelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithInt64SourceWithInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithInt32SourceWithInt32Selector tests

        [Fact]
        public async Task SelectWithInt32SourceWithInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, int> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int>> asyncSelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithInt32SourceWithInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int>> asyncSelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithInt32SourceWithInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithNullableInt64SourceWithNullableInt64Selector tests

        [Fact]
        public async Task SelectWithNullableInt64SourceWithNullableInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, long?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?>> asyncSelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithNullableInt64SourceWithNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?>> asyncSelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithNullableInt64SourceWithNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectWithNullableInt32SourceWithNullableInt32Selector tests

        [Fact]
        public async Task SelectWithNullableInt32SourceWithNullableInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, int?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?>> asyncSelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.Select<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectWithNullableInt32SourceWithNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?>> asyncSelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectWithNullableInt32SourceWithNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Select<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleSelector tests

        [Fact]
        public async Task SelectAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, int, double?> selector = (p, i) => i % 3 == 0 ? ((double)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, ValueTask<double?>>> asyncSelector = (p, i) => new ValueTask<double?>(i % 3 == 0 ? ((double)3) : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, ValueTask<double?>>> asyncSelector = (p, i) => new ValueTask<double?>(i % 3 == 0 ? ((double)3) : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, ValueTask<double?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithDoubleSourceWithWithIndexedDoubleSelector tests

        [Fact]
        public async Task SelectAwaitWithDoubleSourceWithWithIndexedDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, int, double> selector = (p, i) => i % 3 == 0 ? 3D : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, ValueTask<double>>> asyncSelector = (p, i) => new ValueTask<double>(i % 3 == 0 ? 3D : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithDoubleSourceWithWithIndexedDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, ValueTask<double>>> asyncSelector = (p, i) => new ValueTask<double>(i % 3 == 0 ? 3D : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithDoubleSourceWithWithIndexedDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, ValueTask<double>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithDecimalSourceWithWithIndexedDecimalSelector tests

        [Fact]
        public async Task SelectAwaitWithDecimalSourceWithWithIndexedDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, int, decimal> selector = (p, i) => i % 3 == 0 ? 3M : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, ValueTask<decimal>>> asyncSelector = (p, i) => new ValueTask<decimal>(i % 3 == 0 ? 3M : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithDecimalSourceWithWithIndexedDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, ValueTask<decimal>>> asyncSelector = (p, i) => new ValueTask<decimal>(i % 3 == 0 ? 3M : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithDecimalSourceWithWithIndexedDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, ValueTask<decimal>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalSelector tests

        [Fact]
        public async Task SelectAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, int, decimal?> selector = (p, i) => i % 3 == 0 ? ((decimal)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, ValueTask<decimal?>>> asyncSelector = (p, i) => new ValueTask<decimal?>(i % 3 == 0 ? ((decimal)3) : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, ValueTask<decimal?>>> asyncSelector = (p, i) => new ValueTask<decimal?>(i % 3 == 0 ? ((decimal)3) : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, ValueTask<decimal?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithNullableSingleSourceWithWithIndexedNullableSingleSelector tests

        [Fact]
        public async Task SelectAwaitWithNullableSingleSourceWithWithIndexedNullableSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, int, float?> selector = (p, i) => i % 3 == 0 ? ((float)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, ValueTask<float?>>> asyncSelector = (p, i) => new ValueTask<float?>(i % 3 == 0 ? ((float)3) : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, ValueTask<float?>>> asyncSelector = (p, i) => new ValueTask<float?>(i % 3 == 0 ? ((float)3) : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, ValueTask<float?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithSingleSourceWithWithIndexedSingleSelector tests

        [Fact]
        public async Task SelectAwaitWithSingleSourceWithWithIndexedSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, int, float> selector = (p, i) => i % 3 == 0 ? 3F : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, ValueTask<float>>> asyncSelector = (p, i) => new ValueTask<float>(i % 3 == 0 ? 3F : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithSingleSourceWithWithIndexedSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, ValueTask<float>>> asyncSelector = (p, i) => new ValueTask<float>(i % 3 == 0 ? 3F : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithSingleSourceWithWithIndexedSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, ValueTask<float>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithInt64SourceWithWithIndexedInt64Selector tests

        [Fact]
        public async Task SelectAwaitWithInt64SourceWithWithIndexedInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, int, long> selector = (p, i) => i % 3 == 0 ? 3L : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, ValueTask<long>>> asyncSelector = (p, i) => new ValueTask<long>(i % 3 == 0 ? 3L : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithInt64SourceWithWithIndexedInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, ValueTask<long>>> asyncSelector = (p, i) => new ValueTask<long>(i % 3 == 0 ? 3L : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithInt64SourceWithWithIndexedInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, ValueTask<long>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithInt32SourceWithWithIndexedInt32Selector tests

        [Fact]
        public async Task SelectAwaitWithInt32SourceWithWithIndexedInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, int, int> selector = (p, i) => i % 3 == 0 ? 3 : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncSelector = (p, i) => new ValueTask<int>(i % 3 == 0 ? 3 : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithInt32SourceWithWithIndexedInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncSelector = (p, i) => new ValueTask<int>(i % 3 == 0 ? 3 : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithInt32SourceWithWithIndexedInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithNullableInt64SourceWithWithIndexedNullableInt64Selector tests

        [Fact]
        public async Task SelectAwaitWithNullableInt64SourceWithWithIndexedNullableInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, int, long?> selector = (p, i) => i % 3 == 0 ? ((long)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, ValueTask<long?>>> asyncSelector = (p, i) => new ValueTask<long?>(i % 3 == 0 ? ((long)3) : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, ValueTask<long?>>> asyncSelector = (p, i) => new ValueTask<long?>(i % 3 == 0 ? ((long)3) : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, ValueTask<long?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithNullableInt32SourceWithWithIndexedNullableInt32Selector tests

        [Fact]
        public async Task SelectAwaitWithNullableInt32SourceWithWithIndexedNullableInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, int, int?> selector = (p, i) => i % 3 == 0 ? ((int)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, ValueTask<int?>>> asyncSelector = (p, i) => new ValueTask<int?>(i % 3 == 0 ? ((int)3) : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, ValueTask<int?>>> asyncSelector = (p, i) => new ValueTask<int?>(i % 3 == 0 ? ((int)3) : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, ValueTask<int?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithNullableDoubleSourceWithNullableDoubleSelector tests

        [Fact]
        public async Task SelectAwaitWithNullableDoubleSourceWithNullableDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, double?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithNullableDoubleSourceWithNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncSelector = (p) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithNullableDoubleSourceWithNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithDoubleSourceWithDoubleSelector tests

        [Fact]
        public async Task SelectAwaitWithDoubleSourceWithDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, double> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithDoubleSourceWithDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncSelector = (p) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithDoubleSourceWithDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithDecimalSourceWithDecimalSelector tests

        [Fact]
        public async Task SelectAwaitWithDecimalSourceWithDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, decimal> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithDecimalSourceWithDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncSelector = (p) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithDecimalSourceWithDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithNullableDecimalSourceWithNullableDecimalSelector tests

        [Fact]
        public async Task SelectAwaitWithNullableDecimalSourceWithNullableDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, decimal?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithNullableDecimalSourceWithNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithNullableDecimalSourceWithNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithNullableSingleSourceWithNullableSingleSelector tests

        [Fact]
        public async Task SelectAwaitWithNullableSingleSourceWithNullableSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, float?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithNullableSingleSourceWithNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncSelector = (p) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithNullableSingleSourceWithNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithSingleSourceWithSingleSelector tests

        [Fact]
        public async Task SelectAwaitWithSingleSourceWithSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, float> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithSingleSourceWithSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncSelector = (p) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithSingleSourceWithSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithInt64SourceWithInt64Selector tests

        [Fact]
        public async Task SelectAwaitWithInt64SourceWithInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, long> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithInt64SourceWithInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncSelector = (p) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithInt64SourceWithInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithInt32SourceWithInt32Selector tests

        [Fact]
        public async Task SelectAwaitWithInt32SourceWithInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, int> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithInt32SourceWithInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncSelector = (p) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithInt32SourceWithInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithNullableInt64SourceWithNullableInt64Selector tests

        [Fact]
        public async Task SelectAwaitWithNullableInt64SourceWithNullableInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, long?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithNullableInt64SourceWithNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncSelector = (p) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithNullableInt64SourceWithNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithNullableInt32SourceWithNullableInt32Selector tests

        [Fact]
        public async Task SelectAwaitWithNullableInt32SourceWithNullableInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, int?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithNullableInt32SourceWithNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncSelector = (p) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithNullableInt32SourceWithNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwait<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, double?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithDoubleSourceWithDoubleSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithDoubleSourceWithDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, double> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithDoubleSourceWithDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncSelector = (p, c) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithDoubleSourceWithDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithDecimalSourceWithDecimalSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithDecimalSourceWithDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, decimal> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithDecimalSourceWithDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithDecimalSourceWithDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, decimal?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithNullableSingleSourceWithNullableSingleSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableSingleSourceWithNullableSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, float?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableSingleSourceWithNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableSingleSourceWithNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithSingleSourceWithSingleSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithSingleSourceWithSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, float> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithSingleSourceWithSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncSelector = (p, c) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithSingleSourceWithSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithInt64SourceWithInt64Selector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt64SourceWithInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, long> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt64SourceWithInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncSelector = (p, c) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt64SourceWithInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithInt32SourceWithInt32Selector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt32SourceWithInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, int> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt32SourceWithInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncSelector = (p, c) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt32SourceWithInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithNullableInt64SourceWithNullableInt64Selector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt64SourceWithNullableInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, long?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt64SourceWithNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt64SourceWithNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithNullableInt32SourceWithNullableInt32Selector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt32SourceWithNullableInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, int?> selector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt32SourceWithNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt32SourceWithNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'selector' parameter
            Func<double?, int, double?> selector = (p, i) => i % 3 == 0 ? ((double)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<double?>>> asyncSelector = (p, i, c) => new ValueTask<double?>(i % 3 == 0 ? ((double)3) : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double?, double?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<double?>>> asyncSelector = (p, i, c) => new ValueTask<double?>(i % 3 == 0 ? ((double)3) : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<double?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<double?, double?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'selector' parameter
            Func<double, int, double> selector = (p, i) => i % 3 == 0 ? 3D : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<double>>> asyncSelector = (p, i, c) => new ValueTask<double>(i % 3 == 0 ? 3D : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<double, double>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<double>>> asyncSelector = (p, i, c) => new ValueTask<double>(i % 3 == 0 ? 3D : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithDoubleSourceWithWithIndexedDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<double>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<double, double>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'selector' parameter
            Func<decimal, int, decimal> selector = (p, i) => i % 3 == 0 ? 3M : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<decimal>>> asyncSelector = (p, i, c) => new ValueTask<decimal>(i % 3 == 0 ? 3M : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal, decimal>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<decimal>>> asyncSelector = (p, i, c) => new ValueTask<decimal>(i % 3 == 0 ? 3M : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithDecimalSourceWithWithIndexedDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<decimal>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<decimal, decimal>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'selector' parameter
            Func<decimal?, int, decimal?> selector = (p, i) => i % 3 == 0 ? ((decimal)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<decimal?>>> asyncSelector = (p, i, c) => new ValueTask<decimal?>(i % 3 == 0 ? ((decimal)3) : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<decimal?, decimal?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<decimal?>>> asyncSelector = (p, i, c) => new ValueTask<decimal?>(i % 3 == 0 ? ((decimal)3) : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<decimal?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'selector' parameter
            Func<float?, int, float?> selector = (p, i) => i % 3 == 0 ? ((float)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<float?>>> asyncSelector = (p, i, c) => new ValueTask<float?>(i % 3 == 0 ? ((float)3) : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float?, float?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<float?>>> asyncSelector = (p, i, c) => new ValueTask<float?>(i % 3 == 0 ? ((float)3) : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableSingleSourceWithWithIndexedNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<float?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<float?, float?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithSingleSourceWithWithIndexedSingleSelector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithSingleSourceWithWithIndexedSingleSelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'selector' parameter
            Func<float, int, float> selector = (p, i) => i % 3 == 0 ? 3F : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<float>>> asyncSelector = (p, i, c) => new ValueTask<float>(i % 3 == 0 ? 3F : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<float, float>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithSingleSourceWithWithIndexedSingleSelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<float>>> asyncSelector = (p, i, c) => new ValueTask<float>(i % 3 == 0 ? 3F : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithSingleSourceWithWithIndexedSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<float>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<float, float>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithInt64SourceWithWithIndexedInt64Selector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt64SourceWithWithIndexedInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'selector' parameter
            Func<long, int, long> selector = (p, i) => i % 3 == 0 ? 3L : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<long>>> asyncSelector = (p, i, c) => new ValueTask<long>(i % 3 == 0 ? 3L : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long, long>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt64SourceWithWithIndexedInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<long>>> asyncSelector = (p, i, c) => new ValueTask<long>(i % 3 == 0 ? 3L : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt64SourceWithWithIndexedInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<long>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<long, long>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithInt32SourceWithWithIndexedInt32Selector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt32SourceWithWithIndexedInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'selector' parameter
            Func<int, int, int> selector = (p, i) => i % 3 == 0 ? 3 : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncSelector = (p, i, c) => new ValueTask<int>(i % 3 == 0 ? 3 : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int, int>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt32SourceWithWithIndexedInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncSelector = (p, i, c) => new ValueTask<int>(i % 3 == 0 ? 3 : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithInt32SourceWithWithIndexedInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<int, int>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64Selector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'selector' parameter
            Func<long?, int, long?> selector = (p, i) => i % 3 == 0 ? ((long)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<long?>>> asyncSelector = (p, i, c) => new ValueTask<long?>(i % 3 == 0 ? ((long)3) : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<long?, long?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<long?>>> asyncSelector = (p, i, c) => new ValueTask<long?>(i % 3 == 0 ? ((long)3) : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt64SourceWithWithIndexedNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<long?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<long?, long?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SelectAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32Selector tests

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32SelectorIsEquivalentToSelectTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'selector' parameter
            Func<int?, int, int?> selector = (p, i) => i % 3 == 0 ? ((int)3) : (p + 3);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<int?>>> asyncSelector = (p, i, c) => new ValueTask<int?>(i % 3 == 0 ? ((int)3) : (p + 3));

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Select<int?, int?>(source, selector);

            // Act
            var result = await AsyncQueryable.SelectAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<int?>>> asyncSelector = (p, i, c) => new ValueTask<int?>(i % 3 == 0 ? ((int)3) : (p + 3));

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SelectAwaitWithCancellationWithNullableInt32SourceWithWithIndexedNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<int?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SelectAwaitWithCancellation<int?, int?>(asyncSource, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
