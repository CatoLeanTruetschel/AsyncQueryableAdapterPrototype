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

        #region UnionWithNullableDoubleSourceWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithNullableDoubleSourceWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double?>();

            // Arrange 'second' parameter
            var second = GetQueryable<double?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<double?>(first, second);

            // Act
            var result = await AsyncQueryable.Union<double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithNullableDoubleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithNullableDoubleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double?> asyncSecond = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithDoubleSourceWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithDoubleSourceWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double>();

            // Arrange 'second' parameter
            var second = GetQueryable<double>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<double>(first, second);

            // Act
            var result = await AsyncQueryable.Union<double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithDoubleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithDoubleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double> asyncSecond = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithDecimalSourceWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithDecimalSourceWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<decimal>(first, second);

            // Act
            var result = await AsyncQueryable.Union<decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithDecimalSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithDecimalSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal> asyncSecond = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithNullableDecimalSourceWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithNullableDecimalSourceWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal?>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<decimal?>(first, second);

            // Act
            var result = await AsyncQueryable.Union<decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithNullableDecimalSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithNullableDecimalSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal?> asyncSecond = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithNullableSingleSourceWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithNullableSingleSourceWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float?>();

            // Arrange 'second' parameter
            var second = GetQueryable<float?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<float?>(first, second);

            // Act
            var result = await AsyncQueryable.Union<float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithNullableSingleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithNullableSingleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float?> asyncSecond = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithSingleSourceWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithSingleSourceWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float>();

            // Arrange 'second' parameter
            var second = GetQueryable<float>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<float>(first, second);

            // Act
            var result = await AsyncQueryable.Union<float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithSingleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithSingleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float> asyncSecond = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithInt64SourceWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithInt64SourceWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long>();

            // Arrange 'second' parameter
            var second = GetQueryable<long>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<long>(first, second);

            // Act
            var result = await AsyncQueryable.Union<long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithInt64SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithInt64SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long> asyncSecond = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithInt32SourceWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithInt32SourceWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int>();

            // Arrange 'second' parameter
            var second = GetQueryable<int>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<int>(first, second);

            // Act
            var result = await AsyncQueryable.Union<int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithInt32SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithInt32SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int> asyncSecond = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithNullableInt64SourceWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithNullableInt64SourceWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long?>();

            // Arrange 'second' parameter
            var second = GetQueryable<long?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<long?>(first, second);

            // Act
            var result = await AsyncQueryable.Union<long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithNullableInt64SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithNullableInt64SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long?> asyncSecond = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithNullableInt32SourceWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithNullableInt32SourceWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int?>();

            // Arrange 'second' parameter
            var second = GetQueryable<int?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<int?>(first, second);

            // Act
            var result = await AsyncQueryable.Union<int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithNullableInt32SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithNullableInt32SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int?> asyncSecond = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithNullableDoubleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithNullableDoubleSourceWithComparerWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double?>();

            // Arrange 'second' parameter
            var second = GetQueryable<double?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<double?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Union<double?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithNullableDoubleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<double?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithNullableDoubleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double?> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<double?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithDoubleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithDoubleSourceWithComparerWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double>();

            // Arrange 'second' parameter
            var second = GetQueryable<double>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<double>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Union<double>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithDoubleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<double>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithDoubleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<double>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithDecimalSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithDecimalSourceWithComparerWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<decimal>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Union<decimal>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithDecimalSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<decimal>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithDecimalSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<decimal>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithNullableDecimalSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithNullableDecimalSourceWithComparerWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal?>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<decimal?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Union<decimal?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithNullableDecimalSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<decimal?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithNullableDecimalSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal?> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<decimal?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithNullableSingleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithNullableSingleSourceWithComparerWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float?>();

            // Arrange 'second' parameter
            var second = GetQueryable<float?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<float?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Union<float?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithNullableSingleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<float?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithNullableSingleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float?> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<float?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithSingleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithSingleSourceWithComparerWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float>();

            // Arrange 'second' parameter
            var second = GetQueryable<float>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<float>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Union<float>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithSingleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<float>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithSingleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<float>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithInt64SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithInt64SourceWithComparerWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long>();

            // Arrange 'second' parameter
            var second = GetQueryable<long>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<long>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Union<long>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithInt64SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<long>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithInt64SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<long>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithInt32SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithInt32SourceWithComparerWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int>();

            // Arrange 'second' parameter
            var second = GetQueryable<int>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<int>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Union<int>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithInt32SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<int>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithInt32SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<int>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithNullableInt64SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithNullableInt64SourceWithComparerWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long?>();

            // Arrange 'second' parameter
            var second = GetQueryable<long?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<long?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Union<long?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithNullableInt64SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<long?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithNullableInt64SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long?> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<long?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region UnionWithNullableInt32SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task UnionWithNullableInt32SourceWithComparerWithFirstWithSecondIsEquivalentToUnionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int?>();

            // Arrange 'second' parameter
            var second = GetQueryable<int?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Union<int?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Union<int?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task UnionWithNullableInt32SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<int?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task UnionWithNullableInt32SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int?> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Union<int?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
