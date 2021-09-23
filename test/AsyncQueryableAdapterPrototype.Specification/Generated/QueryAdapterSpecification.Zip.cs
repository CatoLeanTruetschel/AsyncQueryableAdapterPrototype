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

        #region ZipWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelector tests

        [Fact]
        public async Task ZipWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double?>();

            // Arrange 'second' parameter
            var second = GetQueryable<double?>();

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, double?>> asyncSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<double?, double?, double?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.Zip<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, double?>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, double?>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, double?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipWithDoubleSourceWithFirstWithSecondWithDoubleSelector tests

        [Fact]
        public async Task ZipWithDoubleSourceWithFirstWithSecondWithDoubleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double>();

            // Arrange 'second' parameter
            var second = GetQueryable<double>();

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, double>> asyncSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<double, double, double>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.Zip<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithDoubleSourceWithFirstWithSecondWithDoubleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, double>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithDoubleSourceWithFirstWithSecondWithDoubleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, double>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithDoubleSourceWithFirstWithSecondWithDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, double>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipWithDecimalSourceWithFirstWithSecondWithDecimalSelector tests

        [Fact]
        public async Task ZipWithDecimalSourceWithFirstWithSecondWithDecimalSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal>();

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<decimal, decimal, decimal>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.Zip<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithDecimalSourceWithFirstWithSecondWithDecimalSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithDecimalSourceWithFirstWithSecondWithDecimalSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithDecimalSourceWithFirstWithSecondWithDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelector tests

        [Fact]
        public async Task ZipWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal?>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal?>();

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<decimal?, decimal?, decimal?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.Zip<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelector tests

        [Fact]
        public async Task ZipWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float?>();

            // Arrange 'second' parameter
            var second = GetQueryable<float?>();

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, float?>> asyncSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<float?, float?, float?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.Zip<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, float?>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, float?>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, float?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipWithSingleSourceWithFirstWithSecondWithSingleSelector tests

        [Fact]
        public async Task ZipWithSingleSourceWithFirstWithSecondWithSingleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float>();

            // Arrange 'second' parameter
            var second = GetQueryable<float>();

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, float>> asyncSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<float, float, float>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.Zip<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithSingleSourceWithFirstWithSecondWithSingleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, float>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithSingleSourceWithFirstWithSecondWithSingleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, float>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithSingleSourceWithFirstWithSecondWithSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, float>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipWithInt64SourceWithFirstWithSecondWithInt64Selector tests

        [Fact]
        public async Task ZipWithInt64SourceWithFirstWithSecondWithInt64SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long>();

            // Arrange 'second' parameter
            var second = GetQueryable<long>();

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, long>> asyncSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<long, long, long>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.Zip<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithInt64SourceWithFirstWithSecondWithInt64SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, long>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithInt64SourceWithFirstWithSecondWithInt64SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, long>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithInt64SourceWithFirstWithSecondWithInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, long>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipWithInt32SourceWithFirstWithSecondWithInt32Selector tests

        [Fact]
        public async Task ZipWithInt32SourceWithFirstWithSecondWithInt32SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int>();

            // Arrange 'second' parameter
            var second = GetQueryable<int>();

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, int>> asyncSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<int, int, int>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.Zip<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithInt32SourceWithFirstWithSecondWithInt32SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, int>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithInt32SourceWithFirstWithSecondWithInt32SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, int>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithInt32SourceWithFirstWithSecondWithInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, int>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipWithNullableInt64SourceWithFirstWithSecondWithNullableInt64Selector tests

        [Fact]
        public async Task ZipWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long?>();

            // Arrange 'second' parameter
            var second = GetQueryable<long?>();

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, long?>> asyncSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<long?, long?, long?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.Zip<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, long?>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, long?>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, long?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipWithNullableInt32SourceWithFirstWithSecondWithNullableInt32Selector tests

        [Fact]
        public async Task ZipWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int?>();

            // Arrange 'second' parameter
            var second = GetQueryable<int?>();

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, int?>> asyncSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<int?, int?, int?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.Zip<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, int?>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, int?>> asyncSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, int?>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Zip<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelector tests

        [Fact]
        public async Task ZipAwaitWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double?>();

            // Arrange 'second' parameter
            var second = GetQueryable<double?>();

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<double?, double?, double?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwait<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithDoubleSourceWithFirstWithSecondWithDoubleSelector tests

        [Fact]
        public async Task ZipAwaitWithDoubleSourceWithFirstWithSecondWithDoubleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double>();

            // Arrange 'second' parameter
            var second = GetQueryable<double>();

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<double, double, double>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwait<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithDoubleSourceWithFirstWithSecondWithDoubleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithDoubleSourceWithFirstWithSecondWithDoubleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithDoubleSourceWithFirstWithSecondWithDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithDecimalSourceWithFirstWithSecondWithDecimalSelector tests

        [Fact]
        public async Task ZipAwaitWithDecimalSourceWithFirstWithSecondWithDecimalSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal>();

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<decimal, decimal, decimal>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwait<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithDecimalSourceWithFirstWithSecondWithDecimalSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithDecimalSourceWithFirstWithSecondWithDecimalSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithDecimalSourceWithFirstWithSecondWithDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelector tests

        [Fact]
        public async Task ZipAwaitWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal?>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal?>();

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<decimal?, decimal?, decimal?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwait<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelector tests

        [Fact]
        public async Task ZipAwaitWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float?>();

            // Arrange 'second' parameter
            var second = GetQueryable<float?>();

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<float?, float?, float?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwait<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithSingleSourceWithFirstWithSecondWithSingleSelector tests

        [Fact]
        public async Task ZipAwaitWithSingleSourceWithFirstWithSecondWithSingleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float>();

            // Arrange 'second' parameter
            var second = GetQueryable<float>();

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<float, float, float>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwait<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithSingleSourceWithFirstWithSecondWithSingleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithSingleSourceWithFirstWithSecondWithSingleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithSingleSourceWithFirstWithSecondWithSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithInt64SourceWithFirstWithSecondWithInt64Selector tests

        [Fact]
        public async Task ZipAwaitWithInt64SourceWithFirstWithSecondWithInt64SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long>();

            // Arrange 'second' parameter
            var second = GetQueryable<long>();

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<long, long, long>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwait<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithInt64SourceWithFirstWithSecondWithInt64SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithInt64SourceWithFirstWithSecondWithInt64SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithInt64SourceWithFirstWithSecondWithInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithInt32SourceWithFirstWithSecondWithInt32Selector tests

        [Fact]
        public async Task ZipAwaitWithInt32SourceWithFirstWithSecondWithInt32SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int>();

            // Arrange 'second' parameter
            var second = GetQueryable<int>();

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<int, int, int>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwait<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithInt32SourceWithFirstWithSecondWithInt32SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithInt32SourceWithFirstWithSecondWithInt32SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithInt32SourceWithFirstWithSecondWithInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithNullableInt64SourceWithFirstWithSecondWithNullableInt64Selector tests

        [Fact]
        public async Task ZipAwaitWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long?>();

            // Arrange 'second' parameter
            var second = GetQueryable<long?>();

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<long?, long?, long?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwait<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithNullableInt32SourceWithFirstWithSecondWithNullableInt32Selector tests

        [Fact]
        public async Task ZipAwaitWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int?>();

            // Arrange 'second' parameter
            var second = GetQueryable<int?>();

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<int?, int?, int?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwait<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwait<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithCancellationWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelector tests

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double?>();

            // Arrange 'second' parameter
            var second = GetQueryable<double?>();

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<double?, double?, double?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwaitWithCancellation<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableDoubleSourceWithFirstWithSecondWithNullableDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<double?, double?, double?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithCancellationWithDoubleSourceWithFirstWithSecondWithDoubleSelector tests

        [Fact]
        public async Task ZipAwaitWithCancellationWithDoubleSourceWithFirstWithSecondWithDoubleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double>();

            // Arrange 'second' parameter
            var second = GetQueryable<double>();

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<double, double, double>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwaitWithCancellation<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithDoubleSourceWithFirstWithSecondWithDoubleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithDoubleSourceWithFirstWithSecondWithDoubleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithDoubleSourceWithFirstWithSecondWithDoubleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<double, double, double>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithCancellationWithDecimalSourceWithFirstWithSecondWithDecimalSelector tests

        [Fact]
        public async Task ZipAwaitWithCancellationWithDecimalSourceWithFirstWithSecondWithDecimalSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal>();

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<decimal, decimal, decimal>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwaitWithCancellation<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithDecimalSourceWithFirstWithSecondWithDecimalSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithDecimalSourceWithFirstWithSecondWithDecimalSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithDecimalSourceWithFirstWithSecondWithDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<decimal, decimal, decimal>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithCancellationWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelector tests

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal?>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal?>();

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<decimal?, decimal?, decimal?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableDecimalSourceWithFirstWithSecondWithNullableDecimalSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<decimal?, decimal?, decimal?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithCancellationWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelector tests

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float?>();

            // Arrange 'second' parameter
            var second = GetQueryable<float?>();

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<float?, float?, float?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwaitWithCancellation<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableSingleSourceWithFirstWithSecondWithNullableSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<float?, float?, float?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithCancellationWithSingleSourceWithFirstWithSecondWithSingleSelector tests

        [Fact]
        public async Task ZipAwaitWithCancellationWithSingleSourceWithFirstWithSecondWithSingleSelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float>();

            // Arrange 'second' parameter
            var second = GetQueryable<float>();

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<float, float, float>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwaitWithCancellation<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithSingleSourceWithFirstWithSecondWithSingleSelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithSingleSourceWithFirstWithSecondWithSingleSelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithSingleSourceWithFirstWithSecondWithSingleSelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<float, float, float>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithCancellationWithInt64SourceWithFirstWithSecondWithInt64Selector tests

        [Fact]
        public async Task ZipAwaitWithCancellationWithInt64SourceWithFirstWithSecondWithInt64SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long>();

            // Arrange 'second' parameter
            var second = GetQueryable<long>();

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<long, long, long>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwaitWithCancellation<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithInt64SourceWithFirstWithSecondWithInt64SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithInt64SourceWithFirstWithSecondWithInt64SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithInt64SourceWithFirstWithSecondWithInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<long, long, long>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithCancellationWithInt32SourceWithFirstWithSecondWithInt32Selector tests

        [Fact]
        public async Task ZipAwaitWithCancellationWithInt32SourceWithFirstWithSecondWithInt32SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int>();

            // Arrange 'second' parameter
            var second = GetQueryable<int>();

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<int, int, int>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwaitWithCancellation<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithInt32SourceWithFirstWithSecondWithInt32SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithInt32SourceWithFirstWithSecondWithInt32SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithInt32SourceWithFirstWithSecondWithInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<int, int, int>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithCancellationWithNullableInt64SourceWithFirstWithSecondWithNullableInt64Selector tests

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long?>();

            // Arrange 'second' parameter
            var second = GetQueryable<long?>();

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<long?, long?, long?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwaitWithCancellation<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableInt64SourceWithFirstWithSecondWithNullableInt64SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<long?, long?, long?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipAwaitWithCancellationWithNullableInt32SourceWithFirstWithSecondWithNullableInt32Selector tests

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorIsEquivalentToZipTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int?>();

            // Arrange 'second' parameter
            var second = GetQueryable<int?>();

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Zip<int?, int?, int?>(first, second, resultSelector);

            // Act
            var result = await AsyncQueryable.ZipAwaitWithCancellation<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int?> asyncSecond = null!;

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipAwaitWithCancellationWithNullableInt32SourceWithFirstWithSecondWithNullableInt32SelectorNullSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ZipAwaitWithCancellation<int?, int?, int?>(asyncFirst, asyncSecond, asyncSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region ZipWithNullableDoubleSourceWithFirstWithSecond tests
#if (SUPPORTS_QUERYABLE_SIMPLE_ZIP && SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP)

        [Fact]
        public async Task ZipWithNullableDoubleSourceWithFirstWithSecondIsEquivalentToZipTest()
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
            var expectedResult = Enumerable.Zip<double?, double?>(first, second);

            // Act
            var result = await AsyncQueryable.Zip<double?, double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithNullableDoubleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<double?, double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableDoubleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<double?, double?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
#endif
        #endregion

        #region ZipWithDoubleSourceWithFirstWithSecond tests
#if (SUPPORTS_QUERYABLE_SIMPLE_ZIP && SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP)

        [Fact]
        public async Task ZipWithDoubleSourceWithFirstWithSecondIsEquivalentToZipTest()
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
            var expectedResult = Enumerable.Zip<double, double>(first, second);

            // Act
            var result = await AsyncQueryable.Zip<double, double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithDoubleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<double, double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithDoubleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<double, double>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
#endif
        #endregion

        #region ZipWithDecimalSourceWithFirstWithSecond tests
#if (SUPPORTS_QUERYABLE_SIMPLE_ZIP && SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP)

        [Fact]
        public async Task ZipWithDecimalSourceWithFirstWithSecondIsEquivalentToZipTest()
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
            var expectedResult = Enumerable.Zip<decimal, decimal>(first, second);

            // Act
            var result = await AsyncQueryable.Zip<decimal, decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithDecimalSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<decimal, decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithDecimalSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<decimal, decimal>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
#endif
        #endregion

        #region ZipWithNullableDecimalSourceWithFirstWithSecond tests
#if (SUPPORTS_QUERYABLE_SIMPLE_ZIP && SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP)

        [Fact]
        public async Task ZipWithNullableDecimalSourceWithFirstWithSecondIsEquivalentToZipTest()
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
            var expectedResult = Enumerable.Zip<decimal?, decimal?>(first, second);

            // Act
            var result = await AsyncQueryable.Zip<decimal?, decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithNullableDecimalSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<decimal?, decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableDecimalSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<decimal?, decimal?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
#endif
        #endregion

        #region ZipWithNullableSingleSourceWithFirstWithSecond tests
#if (SUPPORTS_QUERYABLE_SIMPLE_ZIP && SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP)

        [Fact]
        public async Task ZipWithNullableSingleSourceWithFirstWithSecondIsEquivalentToZipTest()
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
            var expectedResult = Enumerable.Zip<float?, float?>(first, second);

            // Act
            var result = await AsyncQueryable.Zip<float?, float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithNullableSingleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<float?, float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableSingleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<float?, float?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
#endif
        #endregion

        #region ZipWithSingleSourceWithFirstWithSecond tests
#if (SUPPORTS_QUERYABLE_SIMPLE_ZIP && SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP)

        [Fact]
        public async Task ZipWithSingleSourceWithFirstWithSecondIsEquivalentToZipTest()
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
            var expectedResult = Enumerable.Zip<float, float>(first, second);

            // Act
            var result = await AsyncQueryable.Zip<float, float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithSingleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<float, float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithSingleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<float, float>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
#endif
        #endregion

        #region ZipWithInt64SourceWithFirstWithSecond tests
#if (SUPPORTS_QUERYABLE_SIMPLE_ZIP && SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP)

        [Fact]
        public async Task ZipWithInt64SourceWithFirstWithSecondIsEquivalentToZipTest()
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
            var expectedResult = Enumerable.Zip<long, long>(first, second);

            // Act
            var result = await AsyncQueryable.Zip<long, long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithInt64SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<long, long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithInt64SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<long, long>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
#endif
        #endregion

        #region ZipWithInt32SourceWithFirstWithSecond tests
#if (SUPPORTS_QUERYABLE_SIMPLE_ZIP && SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP)

        [Fact]
        public async Task ZipWithInt32SourceWithFirstWithSecondIsEquivalentToZipTest()
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
            var expectedResult = Enumerable.Zip<int, int>(first, second);

            // Act
            var result = await AsyncQueryable.Zip<int, int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithInt32SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<int, int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithInt32SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<int, int>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
#endif
        #endregion

        #region ZipWithNullableInt64SourceWithFirstWithSecond tests
#if (SUPPORTS_QUERYABLE_SIMPLE_ZIP && SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP)

        [Fact]
        public async Task ZipWithNullableInt64SourceWithFirstWithSecondIsEquivalentToZipTest()
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
            var expectedResult = Enumerable.Zip<long?, long?>(first, second);

            // Act
            var result = await AsyncQueryable.Zip<long?, long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithNullableInt64SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<long?, long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableInt64SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<long?, long?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
#endif
        #endregion

        #region ZipWithNullableInt32SourceWithFirstWithSecond tests
#if (SUPPORTS_QUERYABLE_SIMPLE_ZIP && SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP)

        [Fact]
        public async Task ZipWithNullableInt32SourceWithFirstWithSecondIsEquivalentToZipTest()
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
            var expectedResult = Enumerable.Zip<int?, int?>(first, second);

            // Act
            var result = await AsyncQueryable.Zip<int?, int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ZipWithNullableInt32SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<int?, int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ZipWithNullableInt32SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.Zip<int?, int?>(asyncFirst, asyncSecond).ToListAsync().ConfigureAwait(false);
            });
        }
#endif
        #endregion
    }
}
