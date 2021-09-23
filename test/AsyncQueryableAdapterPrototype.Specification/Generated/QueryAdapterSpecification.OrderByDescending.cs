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

        #region OrderByDescendingAwaitWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithDoubleSourceWithDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithDecimalSourceWithDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithSingleSourceWithSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithInt64SourceWithInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithInt32SourceWithInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwait<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwait<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDoubleSourceWithDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDecimalSourceWithDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithSingleSourceWithSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt64SourceWithInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt32SourceWithInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingAwaitWithCancellationWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingAwaitWithCancellationWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescendingAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescending<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithDoubleSourceWithDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescending<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithDecimalSourceWithDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescending<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescending<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescending<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithSingleSourceWithSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescending<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingWithInt64SourceWithInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescending<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingWithInt32SourceWithInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescending<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescending<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByDescending<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescending<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescending<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescending<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescending<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescending<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task OrderByDescendingWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescending<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescending<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescending<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByDescendingWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescending<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByDescendingWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByDescendingWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToOrderByDescendingTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderByDescending<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByDescending<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByDescendingWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByDescendingWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByDescending<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
