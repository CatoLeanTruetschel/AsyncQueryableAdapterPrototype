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

        #region TakeWithNullableDoubleSourceWithCount tests

        [Fact]
        public async Task TakeWithNullableDoubleSourceWithCountIsEquivalentToTakeTest()
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
            var expectedResult = Enumerable.Take<double?>(source, count);

            // Act
            var result = await AsyncQueryable.Take<double?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWithNullableDoubleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Take<double?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWithDoubleSourceWithCount tests

        [Fact]
        public async Task TakeWithDoubleSourceWithCountIsEquivalentToTakeTest()
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
            var expectedResult = Enumerable.Take<double>(source, count);

            // Act
            var result = await AsyncQueryable.Take<double>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWithDoubleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Take<double>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWithDecimalSourceWithCount tests

        [Fact]
        public async Task TakeWithDecimalSourceWithCountIsEquivalentToTakeTest()
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
            var expectedResult = Enumerable.Take<decimal>(source, count);

            // Act
            var result = await AsyncQueryable.Take<decimal>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWithDecimalSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Take<decimal>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWithNullableDecimalSourceWithCount tests

        [Fact]
        public async Task TakeWithNullableDecimalSourceWithCountIsEquivalentToTakeTest()
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
            var expectedResult = Enumerable.Take<decimal?>(source, count);

            // Act
            var result = await AsyncQueryable.Take<decimal?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWithNullableDecimalSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Take<decimal?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWithNullableSingleSourceWithCount tests

        [Fact]
        public async Task TakeWithNullableSingleSourceWithCountIsEquivalentToTakeTest()
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
            var expectedResult = Enumerable.Take<float?>(source, count);

            // Act
            var result = await AsyncQueryable.Take<float?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWithNullableSingleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Take<float?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWithSingleSourceWithCount tests

        [Fact]
        public async Task TakeWithSingleSourceWithCountIsEquivalentToTakeTest()
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
            var expectedResult = Enumerable.Take<float>(source, count);

            // Act
            var result = await AsyncQueryable.Take<float>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWithSingleSourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Take<float>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWithInt64SourceWithCount tests

        [Fact]
        public async Task TakeWithInt64SourceWithCountIsEquivalentToTakeTest()
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
            var expectedResult = Enumerable.Take<long>(source, count);

            // Act
            var result = await AsyncQueryable.Take<long>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWithInt64SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Take<long>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWithInt32SourceWithCount tests

        [Fact]
        public async Task TakeWithInt32SourceWithCountIsEquivalentToTakeTest()
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
            var expectedResult = Enumerable.Take<int>(source, count);

            // Act
            var result = await AsyncQueryable.Take<int>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWithInt32SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Take<int>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWithNullableInt64SourceWithCount tests

        [Fact]
        public async Task TakeWithNullableInt64SourceWithCountIsEquivalentToTakeTest()
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
            var expectedResult = Enumerable.Take<long?>(source, count);

            // Act
            var result = await AsyncQueryable.Take<long?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWithNullableInt64SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Take<long?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWithNullableInt32SourceWithCount tests

        [Fact]
        public async Task TakeWithNullableInt32SourceWithCountIsEquivalentToTakeTest()
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
            var expectedResult = Enumerable.Take<int?>(source, count);

            // Act
            var result = await AsyncQueryable.Take<int?>(asyncSource, count).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWithNullableInt32SourceWithCountNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Take<int?>(asyncSource, count).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
