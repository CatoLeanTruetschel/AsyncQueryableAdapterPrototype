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

        #region TakeLastWithNullableDoubleSourceWithCount tests

        [Fact]
        public async Task TakeLastWithNullableDoubleSourceWithCountIsEquivalentToTakeLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'count' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .TakeLast<double?>(source, count);

            // Act
            var result = await AsyncQueryable.TakeLast<double?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeLastWithNullableDoubleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.TakeLast<double?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeLastWithDoubleSourceWithCount tests

        [Fact]
        public async Task TakeLastWithDoubleSourceWithCountIsEquivalentToTakeLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'count' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .TakeLast<double>(source, count);

            // Act
            var result = await AsyncQueryable.TakeLast<double>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeLastWithDoubleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.TakeLast<double>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeLastWithDecimalSourceWithCount tests

        [Fact]
        public async Task TakeLastWithDecimalSourceWithCountIsEquivalentToTakeLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'count' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .TakeLast<decimal>(source, count);

            // Act
            var result = await AsyncQueryable.TakeLast<decimal>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeLastWithDecimalSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.TakeLast<decimal>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeLastWithNullableDecimalSourceWithCount tests

        [Fact]
        public async Task TakeLastWithNullableDecimalSourceWithCountIsEquivalentToTakeLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'count' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .TakeLast<decimal?>(source, count);

            // Act
            var result = await AsyncQueryable.TakeLast<decimal?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeLastWithNullableDecimalSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.TakeLast<decimal?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeLastWithNullableSingleSourceWithCount tests

        [Fact]
        public async Task TakeLastWithNullableSingleSourceWithCountIsEquivalentToTakeLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'count' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .TakeLast<float?>(source, count);

            // Act
            var result = await AsyncQueryable.TakeLast<float?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeLastWithNullableSingleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.TakeLast<float?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeLastWithSingleSourceWithCount tests

        [Fact]
        public async Task TakeLastWithSingleSourceWithCountIsEquivalentToTakeLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'count' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .TakeLast<float>(source, count);

            // Act
            var result = await AsyncQueryable.TakeLast<float>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeLastWithSingleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.TakeLast<float>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeLastWithInt64SourceWithCount tests

        [Fact]
        public async Task TakeLastWithInt64SourceWithCountIsEquivalentToTakeLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'count' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .TakeLast<long>(source, count);

            // Act
            var result = await AsyncQueryable.TakeLast<long>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeLastWithInt64SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.TakeLast<long>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeLastWithInt32SourceWithCount tests

        [Fact]
        public async Task TakeLastWithInt32SourceWithCountIsEquivalentToTakeLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'count' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .TakeLast<int>(source, count);

            // Act
            var result = await AsyncQueryable.TakeLast<int>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeLastWithInt32SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.TakeLast<int>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeLastWithNullableInt64SourceWithCount tests

        [Fact]
        public async Task TakeLastWithNullableInt64SourceWithCountIsEquivalentToTakeLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'count' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .TakeLast<long?>(source, count);

            // Act
            var result = await AsyncQueryable.TakeLast<long?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeLastWithNullableInt64SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.TakeLast<long?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeLastWithNullableInt32SourceWithCount tests

        [Fact]
        public async Task TakeLastWithNullableInt32SourceWithCountIsEquivalentToTakeLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'count' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .TakeLast<int?>(source, count);

            // Act
            var result = await AsyncQueryable.TakeLast<int?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeLastWithNullableInt32SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.TakeLast<int?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
