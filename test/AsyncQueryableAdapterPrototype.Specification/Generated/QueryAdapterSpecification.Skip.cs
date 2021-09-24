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

        #region SkipWithDoubleSourceWithCount tests

        [Fact]
        public async Task SkipWithDoubleSourceWithCountIsEquivalentToSkipTest()
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
            var expectedResult = Enumerable.Skip<double>(source, count);

            // Act
            var result = await AsyncQueryable.Skip<double>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWithDoubleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Skip<double>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWithNullableDecimalSourceWithCount tests

        [Fact]
        public async Task SkipWithNullableDecimalSourceWithCountIsEquivalentToSkipTest()
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
            var expectedResult = Enumerable.Skip<decimal?>(source, count);

            // Act
            var result = await AsyncQueryable.Skip<decimal?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWithNullableDecimalSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Skip<decimal?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWithNullableSingleSourceWithCount tests

        [Fact]
        public async Task SkipWithNullableSingleSourceWithCountIsEquivalentToSkipTest()
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
            var expectedResult = Enumerable.Skip<float?>(source, count);

            // Act
            var result = await AsyncQueryable.Skip<float?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWithNullableSingleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Skip<float?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWithNullableDoubleSourceWithCount tests

        [Fact]
        public async Task SkipWithNullableDoubleSourceWithCountIsEquivalentToSkipTest()
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
            var expectedResult = Enumerable.Skip<double?>(source, count);

            // Act
            var result = await AsyncQueryable.Skip<double?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWithNullableDoubleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Skip<double?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWithDecimalSourceWithCount tests

        [Fact]
        public async Task SkipWithDecimalSourceWithCountIsEquivalentToSkipTest()
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
            var expectedResult = Enumerable.Skip<decimal>(source, count);

            // Act
            var result = await AsyncQueryable.Skip<decimal>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWithDecimalSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Skip<decimal>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWithSingleSourceWithCount tests

        [Fact]
        public async Task SkipWithSingleSourceWithCountIsEquivalentToSkipTest()
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
            var expectedResult = Enumerable.Skip<float>(source, count);

            // Act
            var result = await AsyncQueryable.Skip<float>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWithSingleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Skip<float>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWithNullableInt64SourceWithCount tests

        [Fact]
        public async Task SkipWithNullableInt64SourceWithCountIsEquivalentToSkipTest()
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
            var expectedResult = Enumerable.Skip<long?>(source, count);

            // Act
            var result = await AsyncQueryable.Skip<long?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWithNullableInt64SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Skip<long?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWithNullableInt32SourceWithCount tests

        [Fact]
        public async Task SkipWithNullableInt32SourceWithCountIsEquivalentToSkipTest()
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
            var expectedResult = Enumerable.Skip<int?>(source, count);

            // Act
            var result = await AsyncQueryable.Skip<int?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWithNullableInt32SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Skip<int?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWithInt64SourceWithCount tests

        [Fact]
        public async Task SkipWithInt64SourceWithCountIsEquivalentToSkipTest()
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
            var expectedResult = Enumerable.Skip<long>(source, count);

            // Act
            var result = await AsyncQueryable.Skip<long>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWithInt64SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Skip<long>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWithInt32SourceWithCount tests

        [Fact]
        public async Task SkipWithInt32SourceWithCountIsEquivalentToSkipTest()
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
            var expectedResult = Enumerable.Skip<int>(source, count);

            // Act
            var result = await AsyncQueryable.Skip<int>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWithInt32SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Skip<int>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
