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

        #region GroupJoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, IEnumerable<double?>, double?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, IEnumerable<double>, double> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, IEnumerable<decimal>, decimal> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, IEnumerable<decimal?>, decimal?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, IEnumerable<float?>, float?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task GroupJoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, IEnumerable<float>, float> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, IEnumerable<long>, long> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, IEnumerable<int>, int> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, IEnumerable<long?>, long?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, IEnumerable<int?>, int?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = (p, elements) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, IEnumerable<double?>, double?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, double?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, double?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, double?>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, IEnumerable<double>, double> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, double>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, double>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, double>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, IEnumerable<decimal>, decimal> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, decimal>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, IEnumerable<decimal?>, decimal?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, decimal?>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, IEnumerable<float?>, float?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, float?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, float?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, float?>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task GroupJoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, IEnumerable<float>, float> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, float>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, float>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, float>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, IEnumerable<long>, long> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, long>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, long>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, long>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, IEnumerable<int>, int> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, int>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, int>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, int>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, IEnumerable<long?>, long?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, long?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, long?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, long?>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, IEnumerable<int?>, int?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, int?>> asyncOuterKeySelector = (p) => p + 3;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, int?>> asyncInnerKeySelector = (p) => p + 3;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, int?>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoin<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, IEnumerable<double?>, double?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = (p, elements) => new ValueTask<double?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = (p, elements) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = (p, elements) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = (p, elements) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = (p, elements) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, IEnumerable<double>, double> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = (p, elements) => new ValueTask<double>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = (p, elements) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = (p, elements) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = (p, elements) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = (p, elements) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, IEnumerable<decimal>, decimal> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = (p, elements) => new ValueTask<decimal>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = (p, elements) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = (p, elements) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = (p, elements) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = (p, elements) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, IEnumerable<decimal?>, decimal?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = (p, elements) => new ValueTask<decimal?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = (p, elements) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = (p, elements) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = (p, elements) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = (p, elements) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, IEnumerable<float?>, float?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = (p, elements) => new ValueTask<float?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = (p, elements) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = (p, elements) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = (p, elements) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = (p, elements) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, IEnumerable<float>, float> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = (p, elements) => new ValueTask<float>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = (p, elements) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = (p, elements) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = (p, elements) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = (p, elements) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, IEnumerable<long>, long> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = (p, elements) => new ValueTask<long>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = (p, elements) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = (p, elements) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = (p, elements) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = (p, elements) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, IEnumerable<int>, int> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = (p, elements) => new ValueTask<int>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = (p, elements) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = (p, elements) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = (p, elements) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = (p, elements) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, IEnumerable<long?>, long?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = (p, elements) => new ValueTask<long?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = (p, elements) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = (p, elements) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = (p, elements) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = (p, elements) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, IEnumerable<int?>, int?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = (p, elements) => new ValueTask<int?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = (p, elements) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = (p, elements) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = (p, elements) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = (p, elements) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, IEnumerable<double?>, double?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = (p, elements) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = (p, elements) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = (p, elements) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = (p, elements) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = (p, elements) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncOuterKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncInnerKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, ValueTask<double?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, IEnumerable<double>, double> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = (p, elements) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = (p, elements) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = (p, elements) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = (p, elements) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = (p, elements) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncOuterKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncInnerKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, ValueTask<double>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, IEnumerable<decimal>, decimal> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = (p, elements) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = (p, elements) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = (p, elements) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = (p, elements) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = (p, elements) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncOuterKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncInnerKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, ValueTask<decimal>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, IEnumerable<decimal?>, decimal?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = (p, elements) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = (p, elements) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = (p, elements) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = (p, elements) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = (p, elements) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncOuterKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncInnerKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, IEnumerable<float?>, float?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = (p, elements) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = (p, elements) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = (p, elements) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = (p, elements) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = (p, elements) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncOuterKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncInnerKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, ValueTask<float?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, IEnumerable<float>, float> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = (p, elements) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = (p, elements) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = (p, elements) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = (p, elements) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = (p, elements) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncOuterKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncInnerKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, ValueTask<float>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, IEnumerable<long>, long> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = (p, elements) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = (p, elements) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = (p, elements) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = (p, elements) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = (p, elements) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncOuterKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncInnerKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, ValueTask<long>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, IEnumerable<int>, int> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = (p, elements) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = (p, elements) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = (p, elements) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = (p, elements) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = (p, elements) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncOuterKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncInnerKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, ValueTask<int>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, IEnumerable<long?>, long?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = (p, elements) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = (p, elements) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = (p, elements) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = (p, elements) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = (p, elements) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncOuterKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncInnerKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, ValueTask<long?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, IEnumerable<int?>, int?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = (p, elements) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = (p, elements) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = (p, elements) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = (p, elements) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = (p, elements) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncOuterKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncInnerKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, ValueTask<int?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwait<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, IEnumerable<double?>, double?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, elements, c) => new ValueTask<double?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, elements, c) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, elements, c) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, elements, c) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, elements, c) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, IEnumerable<double>, double> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, elements, c) => new ValueTask<double>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, elements, c) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, elements, c) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, elements, c) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, elements, c) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, IEnumerable<decimal>, decimal> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, IEnumerable<decimal?>, decimal?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, IEnumerable<float?>, float?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, elements, c) => new ValueTask<float?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, elements, c) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, elements, c) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, elements, c) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, elements, c) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, IEnumerable<float>, float> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, elements, c) => new ValueTask<float>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, elements, c) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, elements, c) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, elements, c) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, elements, c) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, IEnumerable<long>, long> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, elements, c) => new ValueTask<long>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, elements, c) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, elements, c) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, elements, c) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, elements, c) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, IEnumerable<int>, int> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, elements, c) => new ValueTask<int>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, elements, c) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, elements, c) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, elements, c) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, elements, c) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, IEnumerable<long?>, long?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, elements, c) => new ValueTask<long?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, elements, c) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, elements, c) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, elements, c) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, elements, c) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, IEnumerable<int?>, int?> resultSelector = (p, elements) => p + 3;

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, elements, c) => new ValueTask<int?>(p + 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, elements, c) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, elements, c) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, elements, c) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, elements, c) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double?>();

            // Arrange 'outerKeySelector' parameter
            Func<double?, double?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double?, double?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double?, IEnumerable<double?>, double?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, elements, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double?, double?, double?, double?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, elements, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, elements, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, elements, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, elements, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDoubleSourceWithComparerWithInnerWithNullableDoubleInnerKeySelectorWithOuterWithNullableDoubleOuterKeySelectorWithNullableDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncOuterKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncInnerKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, IAsyncEnumerable<double?>, CancellationToken, ValueTask<double?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double?, double?, double?, double?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<double>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<double>();

            // Arrange 'outerKeySelector' parameter
            Func<double, double> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<double, double> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<double, IEnumerable<double>, double> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, elements, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<double, double, double, double>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<double> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, elements, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<double> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, elements, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, elements, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, elements, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDoubleSourceWithComparerWithInnerWithDoubleInnerKeySelectorWithOuterWithDoubleOuterKeySelectorWithDoubleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncOuterKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncInnerKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, IAsyncEnumerable<double>, CancellationToken, ValueTask<double>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<double, double, double, double>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal, decimal> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal, decimal> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal, IEnumerable<decimal>, decimal> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal, decimal, decimal, decimal>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithDecimalSourceWithComparerWithInnerWithDecimalInnerKeySelectorWithOuterWithDecimalOuterKeySelectorWithDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, IAsyncEnumerable<decimal>, CancellationToken, ValueTask<decimal>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal, decimal, decimal, decimal>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<decimal?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<decimal?>();

            // Arrange 'outerKeySelector' parameter
            Func<decimal?, decimal?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<decimal?, decimal?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<decimal?, IEnumerable<decimal?>, decimal?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<decimal?, decimal?, decimal?, decimal?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<decimal?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<decimal?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, elements, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableDecimalSourceWithComparerWithInnerWithNullableDecimalInnerKeySelectorWithOuterWithNullableDecimalOuterKeySelectorWithNullableDecimalResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncOuterKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncInnerKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, IAsyncEnumerable<decimal?>, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<decimal?, decimal?, decimal?, decimal?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float?>();

            // Arrange 'outerKeySelector' parameter
            Func<float?, float?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float?, float?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float?, IEnumerable<float?>, float?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, elements, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float?, float?, float?, float?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, elements, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, elements, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, elements, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, elements, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableSingleSourceWithComparerWithInnerWithNullableSingleInnerKeySelectorWithOuterWithNullableSingleOuterKeySelectorWithNullableSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncOuterKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncInnerKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, IAsyncEnumerable<float?>, CancellationToken, ValueTask<float?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float?, float?, float?, float?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<float>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<float>();

            // Arrange 'outerKeySelector' parameter
            Func<float, float> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<float, float> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<float, IEnumerable<float>, float> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, elements, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<float, float, float, float>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<float> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, elements, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<float> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, elements, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, elements, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, elements, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithSingleSourceWithComparerWithInnerWithSingleInnerKeySelectorWithOuterWithSingleOuterKeySelectorWithSingleResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncOuterKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncInnerKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, IAsyncEnumerable<float>, CancellationToken, ValueTask<float>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<float, float, float, float>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long>();

            // Arrange 'outerKeySelector' parameter
            Func<long, long> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long, long> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long, IEnumerable<long>, long> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, elements, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long, long, long, long>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, elements, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, elements, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, elements, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, elements, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt64SourceWithComparerWithInnerWithInt64InnerKeySelectorWithOuterWithInt64OuterKeySelectorWithInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncOuterKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncInnerKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, IAsyncEnumerable<long>, CancellationToken, ValueTask<long>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long, long, long, long>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int>();

            // Arrange 'outerKeySelector' parameter
            Func<int, int> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int, int> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int, IEnumerable<int>, int> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, elements, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int, int, int, int>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, elements, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, elements, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, elements, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, elements, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithInt32SourceWithComparerWithInnerWithInt32InnerKeySelectorWithOuterWithInt32OuterKeySelectorWithInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncOuterKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncInnerKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, IAsyncEnumerable<int>, CancellationToken, ValueTask<int>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int, int, int, int>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<long?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<long?>();

            // Arrange 'outerKeySelector' parameter
            Func<long?, long?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<long?, long?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<long?, IEnumerable<long?>, long?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, elements, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<long?, long?, long?, long?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<long?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, elements, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<long?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, elements, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, elements, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, elements, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt64SourceWithComparerWithInnerWithNullableInt64InnerKeySelectorWithOuterWithNullableInt64OuterKeySelectorWithNullableInt64ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncOuterKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncInnerKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, IAsyncEnumerable<long?>, CancellationToken, ValueTask<long?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<long?, long?, long?, long?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region GroupJoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelector tests

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorIsEquivalentToGroupJoinTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'outer' parameter
            var outer = GetQueryable<int?>();

            // Arrange 'inner' parameter
            var inner = GetQueryable<int?>();

            // Arrange 'outerKeySelector' parameter
            Func<int?, int?> outerKeySelector = (p) => p + 3;

            // Arrange 'innerKeySelector' parameter
            Func<int?, int?> innerKeySelector = (p) => p + 3;

            // Arrange 'resultSelector' parameter
            Func<int?, IEnumerable<int?>, int?> resultSelector = (p, elements) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, elements, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.GroupJoin<int?, int?, int?, int?>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

            // Act
            var result = await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            IAsyncQueryable<int?> asyncOuter = null!;

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, elements, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            IAsyncEnumerable<int?> asyncInner = null!;

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, elements, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullOuterKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = null!;

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, elements, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullInnerKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, elements, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task GroupJoinAwaitWithCancellationWithNullableInt32SourceWithComparerWithInnerWithNullableInt32InnerKeySelectorWithOuterWithNullableInt32OuterKeySelectorWithNullableInt32ResultSelectorNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncOuter' parameter
            var asyncOuter = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncInner' parameter
            var asyncInner = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncOuterKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncOuterKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncInnerKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncInnerKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, IAsyncEnumerable<int?>, CancellationToken, ValueTask<int?>>> asyncResultSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.GroupJoinAwaitWithCancellation<int?, int?, int?, int?>(asyncOuter, asyncInner, asyncOuterKeySelector, asyncInnerKeySelector, asyncResultSelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
