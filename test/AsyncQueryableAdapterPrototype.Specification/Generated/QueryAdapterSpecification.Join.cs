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

        #region JoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task JoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task JoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task JoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task JoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task JoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task JoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task JoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task JoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task JoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, double>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task JoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, float?>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, double?>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task JoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, decimal>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task JoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, float>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task JoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, long?>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task JoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, int?>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task JoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, long>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task JoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = (p, q) => p + 3 - q;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, int>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Join<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, double, double> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?, decimal?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, float?, float?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, double?, double?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal, decimal> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, float, float> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, long?, long?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, int?, int?> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, long, long> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region JoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, int, int> resultSelector = (p, q) => p + 3 - q;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Join<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task JoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.JoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
