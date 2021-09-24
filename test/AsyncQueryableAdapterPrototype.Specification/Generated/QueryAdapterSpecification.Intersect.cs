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

        #region IntersectWithNullableDoubleSourceWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithNullableDoubleSourceWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<double?>(first, second);

            // Act
            var result = await AsyncQueryable.Intersect<double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithNullableDoubleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithNullableDoubleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithDoubleSourceWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithDoubleSourceWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<double>(first, second);

            // Act
            var result = await AsyncQueryable.Intersect<double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithDoubleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithDoubleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithDecimalSourceWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithDecimalSourceWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<decimal>(first, second);

            // Act
            var result = await AsyncQueryable.Intersect<decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithDecimalSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithDecimalSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithNullableDecimalSourceWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithNullableDecimalSourceWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<decimal?>(first, second);

            // Act
            var result = await AsyncQueryable.Intersect<decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithNullableDecimalSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithNullableDecimalSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithNullableSingleSourceWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithNullableSingleSourceWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<float?>(first, second);

            // Act
            var result = await AsyncQueryable.Intersect<float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithNullableSingleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithNullableSingleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithSingleSourceWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithSingleSourceWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<float>(first, second);

            // Act
            var result = await AsyncQueryable.Intersect<float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithSingleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithSingleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithInt64SourceWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithInt64SourceWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<long>(first, second);

            // Act
            var result = await AsyncQueryable.Intersect<long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithInt64SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithInt64SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithInt32SourceWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithInt32SourceWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<int>(first, second);

            // Act
            var result = await AsyncQueryable.Intersect<int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithInt32SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithInt32SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithNullableInt64SourceWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithNullableInt64SourceWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<long?>(first, second);

            // Act
            var result = await AsyncQueryable.Intersect<long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithNullableInt64SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithNullableInt64SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithNullableInt32SourceWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithNullableInt32SourceWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<int?>(first, second);

            // Act
            var result = await AsyncQueryable.Intersect<int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithNullableInt32SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithNullableInt32SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithNullableDoubleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithNullableDoubleSourceWithComparerWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<double?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Intersect<double?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithNullableDoubleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<double?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithNullableDoubleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<double?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithDoubleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithDoubleSourceWithComparerWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<double>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Intersect<double>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithDoubleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<double>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithDoubleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<double>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithDecimalSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithDecimalSourceWithComparerWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<decimal>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Intersect<decimal>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithDecimalSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<decimal>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithDecimalSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<decimal>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithNullableDecimalSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithNullableDecimalSourceWithComparerWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<decimal?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Intersect<decimal?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithNullableDecimalSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<decimal?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithNullableDecimalSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<decimal?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithNullableSingleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithNullableSingleSourceWithComparerWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<float?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Intersect<float?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithNullableSingleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<float?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithNullableSingleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<float?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithSingleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithSingleSourceWithComparerWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<float>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Intersect<float>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithSingleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<float>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithSingleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<float>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithInt64SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithInt64SourceWithComparerWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<long>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Intersect<long>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithInt64SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<long>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithInt64SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<long>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithInt32SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithInt32SourceWithComparerWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<int>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Intersect<int>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithInt32SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<int>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithInt32SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<int>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithNullableInt64SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithNullableInt64SourceWithComparerWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<long?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Intersect<long?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithNullableInt64SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<long?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithNullableInt64SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<long?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region IntersectWithNullableInt32SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task IntersectWithNullableInt32SourceWithComparerWithFirstWithSecondIsEquivalentToIntersectTest()
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
            var expectedResult = Enumerable.Intersect<int?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.Intersect<int?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task IntersectWithNullableInt32SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<int?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task IntersectWithNullableInt32SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Intersect<int?>(asyncFirst, asyncSecond, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
