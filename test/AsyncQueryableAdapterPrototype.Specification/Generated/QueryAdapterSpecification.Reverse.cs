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

        #region ReverseWithNullableDoubleSource tests

        [Fact]
        public async Task ReverseWithNullableDoubleSourceIsEquivalentToReverseTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Reverse<double?>(source);

            // Act
            var result = await AsyncQueryable.Reverse<double?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ReverseWithNullableDoubleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Reverse<double?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ReverseWithDoubleSource tests

        [Fact]
        public async Task ReverseWithDoubleSourceIsEquivalentToReverseTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Reverse<double>(source);

            // Act
            var result = await AsyncQueryable.Reverse<double>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ReverseWithDoubleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Reverse<double>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ReverseWithDecimalSource tests

        [Fact]
        public async Task ReverseWithDecimalSourceIsEquivalentToReverseTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Reverse<decimal>(source);

            // Act
            var result = await AsyncQueryable.Reverse<decimal>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ReverseWithDecimalSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Reverse<decimal>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ReverseWithNullableDecimalSource tests

        [Fact]
        public async Task ReverseWithNullableDecimalSourceIsEquivalentToReverseTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Reverse<decimal?>(source);

            // Act
            var result = await AsyncQueryable.Reverse<decimal?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ReverseWithNullableDecimalSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Reverse<decimal?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ReverseWithNullableSingleSource tests

        [Fact]
        public async Task ReverseWithNullableSingleSourceIsEquivalentToReverseTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Reverse<float?>(source);

            // Act
            var result = await AsyncQueryable.Reverse<float?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ReverseWithNullableSingleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Reverse<float?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ReverseWithSingleSource tests

        [Fact]
        public async Task ReverseWithSingleSourceIsEquivalentToReverseTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Reverse<float>(source);

            // Act
            var result = await AsyncQueryable.Reverse<float>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ReverseWithSingleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Reverse<float>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ReverseWithInt64Source tests

        [Fact]
        public async Task ReverseWithInt64SourceIsEquivalentToReverseTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Reverse<long>(source);

            // Act
            var result = await AsyncQueryable.Reverse<long>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ReverseWithInt64SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Reverse<long>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ReverseWithInt32Source tests

        [Fact]
        public async Task ReverseWithInt32SourceIsEquivalentToReverseTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Reverse<int>(source);

            // Act
            var result = await AsyncQueryable.Reverse<int>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ReverseWithInt32SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Reverse<int>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ReverseWithNullableInt64Source tests

        [Fact]
        public async Task ReverseWithNullableInt64SourceIsEquivalentToReverseTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Reverse<long?>(source);

            // Act
            var result = await AsyncQueryable.Reverse<long?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ReverseWithNullableInt64SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Reverse<long?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ReverseWithNullableInt32Source tests

        [Fact]
        public async Task ReverseWithNullableInt32SourceIsEquivalentToReverseTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Reverse<int?>(source);

            // Act
            var result = await AsyncQueryable.Reverse<int?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ReverseWithNullableInt32SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Reverse<int?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
