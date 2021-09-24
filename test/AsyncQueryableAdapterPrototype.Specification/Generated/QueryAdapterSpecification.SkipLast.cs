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

        #region SkipLastWithDoubleSourceWithCount tests

        [Fact]
        public async Task SkipLastWithDoubleSourceWithCountIsEquivalentToSkipLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .SkipLast<double>(source, count);

            // Act
            var result = await AsyncQueryable.SkipLast<double>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipLastWithDoubleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SkipLast<double>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipLastWithNullableDecimalSourceWithCount tests

        [Fact]
        public async Task SkipLastWithNullableDecimalSourceWithCountIsEquivalentToSkipLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .SkipLast<decimal?>(source, count);

            // Act
            var result = await AsyncQueryable.SkipLast<decimal?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipLastWithNullableDecimalSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SkipLast<decimal?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipLastWithNullableSingleSourceWithCount tests

        [Fact]
        public async Task SkipLastWithNullableSingleSourceWithCountIsEquivalentToSkipLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .SkipLast<float?>(source, count);

            // Act
            var result = await AsyncQueryable.SkipLast<float?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipLastWithNullableSingleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SkipLast<float?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipLastWithNullableDoubleSourceWithCount tests

        [Fact]
        public async Task SkipLastWithNullableDoubleSourceWithCountIsEquivalentToSkipLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .SkipLast<double?>(source, count);

            // Act
            var result = await AsyncQueryable.SkipLast<double?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipLastWithNullableDoubleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SkipLast<double?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipLastWithDecimalSourceWithCount tests

        [Fact]
        public async Task SkipLastWithDecimalSourceWithCountIsEquivalentToSkipLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .SkipLast<decimal>(source, count);

            // Act
            var result = await AsyncQueryable.SkipLast<decimal>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipLastWithDecimalSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SkipLast<decimal>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipLastWithSingleSourceWithCount tests

        [Fact]
        public async Task SkipLastWithSingleSourceWithCountIsEquivalentToSkipLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .SkipLast<float>(source, count);

            // Act
            var result = await AsyncQueryable.SkipLast<float>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipLastWithSingleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SkipLast<float>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipLastWithNullableInt64SourceWithCount tests

        [Fact]
        public async Task SkipLastWithNullableInt64SourceWithCountIsEquivalentToSkipLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .SkipLast<long?>(source, count);

            // Act
            var result = await AsyncQueryable.SkipLast<long?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipLastWithNullableInt64SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SkipLast<long?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipLastWithNullableInt32SourceWithCount tests

        [Fact]
        public async Task SkipLastWithNullableInt32SourceWithCountIsEquivalentToSkipLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .SkipLast<int?>(source, count);

            // Act
            var result = await AsyncQueryable.SkipLast<int?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipLastWithNullableInt32SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SkipLast<int?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipLastWithInt64SourceWithCount tests

        [Fact]
        public async Task SkipLastWithInt64SourceWithCountIsEquivalentToSkipLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .SkipLast<long>(source, count);

            // Act
            var result = await AsyncQueryable.SkipLast<long>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipLastWithInt64SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SkipLast<long>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipLastWithInt32SourceWithCount tests

        [Fact]
        public async Task SkipLastWithInt32SourceWithCountIsEquivalentToSkipLastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'count' parameter
            var count = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            EnumerableExtension
            .SkipLast<int>(source, count);

            // Act
            var result = await AsyncQueryable.SkipLast<int>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipLastWithInt32SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'count' parameter
            var count = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SkipLast<int>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
