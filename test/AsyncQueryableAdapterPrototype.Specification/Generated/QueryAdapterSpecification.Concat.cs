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

        #region ConcatWithNullableDoubleSourceWithFirstWithSecond tests

        [Fact]
        public async Task ConcatWithNullableDoubleSourceWithFirstWithSecondIsEquivalentToConcatTest()
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
            var expectedResult = Enumerable.Concat<double?>(first, second);

            // Act
            var result = await AsyncQueryable.Concat<double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ConcatWithNullableDoubleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ConcatWithNullableDoubleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ConcatWithDoubleSourceWithFirstWithSecond tests

        [Fact]
        public async Task ConcatWithDoubleSourceWithFirstWithSecondIsEquivalentToConcatTest()
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
            var expectedResult = Enumerable.Concat<double>(first, second);

            // Act
            var result = await AsyncQueryable.Concat<double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ConcatWithDoubleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ConcatWithDoubleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ConcatWithDecimalSourceWithFirstWithSecond tests

        [Fact]
        public async Task ConcatWithDecimalSourceWithFirstWithSecondIsEquivalentToConcatTest()
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
            var expectedResult = Enumerable.Concat<decimal>(first, second);

            // Act
            var result = await AsyncQueryable.Concat<decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ConcatWithDecimalSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ConcatWithDecimalSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ConcatWithNullableDecimalSourceWithFirstWithSecond tests

        [Fact]
        public async Task ConcatWithNullableDecimalSourceWithFirstWithSecondIsEquivalentToConcatTest()
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
            var expectedResult = Enumerable.Concat<decimal?>(first, second);

            // Act
            var result = await AsyncQueryable.Concat<decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ConcatWithNullableDecimalSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ConcatWithNullableDecimalSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ConcatWithNullableSingleSourceWithFirstWithSecond tests

        [Fact]
        public async Task ConcatWithNullableSingleSourceWithFirstWithSecondIsEquivalentToConcatTest()
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
            var expectedResult = Enumerable.Concat<float?>(first, second);

            // Act
            var result = await AsyncQueryable.Concat<float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ConcatWithNullableSingleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ConcatWithNullableSingleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ConcatWithSingleSourceWithFirstWithSecond tests

        [Fact]
        public async Task ConcatWithSingleSourceWithFirstWithSecondIsEquivalentToConcatTest()
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
            var expectedResult = Enumerable.Concat<float>(first, second);

            // Act
            var result = await AsyncQueryable.Concat<float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ConcatWithSingleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ConcatWithSingleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ConcatWithInt64SourceWithFirstWithSecond tests

        [Fact]
        public async Task ConcatWithInt64SourceWithFirstWithSecondIsEquivalentToConcatTest()
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
            var expectedResult = Enumerable.Concat<long>(first, second);

            // Act
            var result = await AsyncQueryable.Concat<long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ConcatWithInt64SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ConcatWithInt64SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ConcatWithInt32SourceWithFirstWithSecond tests

        [Fact]
        public async Task ConcatWithInt32SourceWithFirstWithSecondIsEquivalentToConcatTest()
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
            var expectedResult = Enumerable.Concat<int>(first, second);

            // Act
            var result = await AsyncQueryable.Concat<int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ConcatWithInt32SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ConcatWithInt32SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ConcatWithNullableInt64SourceWithFirstWithSecond tests

        [Fact]
        public async Task ConcatWithNullableInt64SourceWithFirstWithSecondIsEquivalentToConcatTest()
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
            var expectedResult = Enumerable.Concat<long?>(first, second);

            // Act
            var result = await AsyncQueryable.Concat<long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ConcatWithNullableInt64SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ConcatWithNullableInt64SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ConcatWithNullableInt32SourceWithFirstWithSecond tests

        [Fact]
        public async Task ConcatWithNullableInt32SourceWithFirstWithSecondIsEquivalentToConcatTest()
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
            var expectedResult = Enumerable.Concat<int?>(first, second);

            // Act
            var result = await AsyncQueryable.Concat<int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ConcatWithNullableInt32SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ConcatWithNullableInt32SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Concat<int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
