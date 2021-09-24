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

        #region DefaultIfEmptyWithDoubleSource tests

        [Fact]
        public async Task DefaultIfEmptyWithDoubleSourceIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<double>(source);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<double>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithDoubleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<double>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithNullableDecimalSource tests

        [Fact]
        public async Task DefaultIfEmptyWithNullableDecimalSourceIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<decimal?>(source);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<decimal?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithNullableDecimalSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<decimal?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithNullableSingleSource tests

        [Fact]
        public async Task DefaultIfEmptyWithNullableSingleSourceIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<float?>(source);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<float?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithNullableSingleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<float?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithNullableDoubleSource tests

        [Fact]
        public async Task DefaultIfEmptyWithNullableDoubleSourceIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<double?>(source);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<double?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithNullableDoubleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<double?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithDecimalSource tests

        [Fact]
        public async Task DefaultIfEmptyWithDecimalSourceIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<decimal>(source);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<decimal>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithDecimalSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<decimal>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithSingleSource tests

        [Fact]
        public async Task DefaultIfEmptyWithSingleSourceIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<float>(source);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<float>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithSingleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<float>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithNullableInt64Source tests

        [Fact]
        public async Task DefaultIfEmptyWithNullableInt64SourceIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<long?>(source);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<long?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithNullableInt64SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<long?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithNullableInt32Source tests

        [Fact]
        public async Task DefaultIfEmptyWithNullableInt32SourceIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<int?>(source);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<int?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithNullableInt32SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<int?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithInt64Source tests

        [Fact]
        public async Task DefaultIfEmptyWithInt64SourceIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<long>(source);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<long>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithInt64SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<long>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithInt32Source tests

        [Fact]
        public async Task DefaultIfEmptyWithInt32SourceIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<int>(source);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<int>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithInt32SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<int>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithDoubleSourceWithDefaultValue tests

        [Fact]
        public async Task DefaultIfEmptyWithDoubleSourceWithDefaultValueIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<double>(source, defaultValue);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<double>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithDoubleSourceWithDefaultValueNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<double>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithNullableDecimalSourceWithDefaultValue tests

        [Fact]
        public async Task DefaultIfEmptyWithNullableDecimalSourceWithDefaultValueIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<decimal?>(source, defaultValue);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<decimal?>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithNullableDecimalSourceWithDefaultValueNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<decimal?>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithNullableSingleSourceWithDefaultValue tests

        [Fact]
        public async Task DefaultIfEmptyWithNullableSingleSourceWithDefaultValueIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<float?>(source, defaultValue);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<float?>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithNullableSingleSourceWithDefaultValueNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<float?>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithNullableDoubleSourceWithDefaultValue tests

        [Fact]
        public async Task DefaultIfEmptyWithNullableDoubleSourceWithDefaultValueIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<double?>(source, defaultValue);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<double?>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithNullableDoubleSourceWithDefaultValueNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<double?>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithDecimalSourceWithDefaultValue tests

        [Fact]
        public async Task DefaultIfEmptyWithDecimalSourceWithDefaultValueIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<decimal>(source, defaultValue);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<decimal>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithDecimalSourceWithDefaultValueNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<decimal>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithSingleSourceWithDefaultValue tests

        [Fact]
        public async Task DefaultIfEmptyWithSingleSourceWithDefaultValueIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<float>(source, defaultValue);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<float>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithSingleSourceWithDefaultValueNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<float>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithNullableInt64SourceWithDefaultValue tests

        [Fact]
        public async Task DefaultIfEmptyWithNullableInt64SourceWithDefaultValueIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<long?>(source, defaultValue);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<long?>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithNullableInt64SourceWithDefaultValueNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<long?>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithNullableInt32SourceWithDefaultValue tests

        [Fact]
        public async Task DefaultIfEmptyWithNullableInt32SourceWithDefaultValueIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<int?>(source, defaultValue);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<int?>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithNullableInt32SourceWithDefaultValueNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<int?>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithInt64SourceWithDefaultValue tests

        [Fact]
        public async Task DefaultIfEmptyWithInt64SourceWithDefaultValueIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<long>(source, defaultValue);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<long>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithInt64SourceWithDefaultValueNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<long>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region DefaultIfEmptyWithInt32SourceWithDefaultValue tests

        [Fact]
        public async Task DefaultIfEmptyWithInt32SourceWithDefaultValueIsEquivalentToDefaultIfEmptyTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.DefaultIfEmpty<int>(source, defaultValue);

            // Act
            var result = await AsyncQueryable.DefaultIfEmpty<int>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task DefaultIfEmptyWithInt32SourceWithDefaultValueNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'defaultValue' parameter
            var defaultValue = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.DefaultIfEmpty<int>(asyncSource, defaultValue).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
