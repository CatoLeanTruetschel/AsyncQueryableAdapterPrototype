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

        #region WhereWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task WhereWithDoubleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'predicate' parameter
            Func<double, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, bool>> asyncPredicate = (p) => p > 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task WhereWithNullableDecimalSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'predicate' parameter
            Func<decimal?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task WhereWithNullableSingleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'predicate' parameter
            Func<float?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task WhereWithNullableDoubleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'predicate' parameter
            Func<double?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task WhereWithDecimalSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'predicate' parameter
            Func<decimal, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, bool>> asyncPredicate = (p) => p > 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithSingleSourceWithPredicate tests

        [Fact]
        public async Task WhereWithSingleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'predicate' parameter
            Func<float, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, bool>> asyncPredicate = (p) => p > 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task WhereWithNullableInt64SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'predicate' parameter
            Func<long?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task WhereWithNullableInt32SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'predicate' parameter
            Func<int?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithInt64SourceWithPredicate tests

        [Fact]
        public async Task WhereWithInt64SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'predicate' parameter
            Func<long, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, bool>> asyncPredicate = (p) => p > 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithInt32SourceWithPredicate tests

        [Fact]
        public async Task WhereWithInt32SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'predicate' parameter
            Func<int, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, bool>> asyncPredicate = (p) => p > 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereWithDoubleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'predicate' parameter
            Func<double, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, int, bool>> asyncPredicate = (p, i) => p > 3&& i < 10;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, int, bool>> asyncPredicate = (p, i) => p > 3&& i < 10;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithNullableDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereWithNullableDecimalSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'predicate' parameter
            Func<decimal?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, int, bool>> asyncPredicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithNullableDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, int, bool>> asyncPredicate = (p, i) => p != null && p > 3&& i < 10;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithNullableDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithNullableSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereWithNullableSingleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'predicate' parameter
            Func<float?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, int, bool>> asyncPredicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithNullableSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, int, bool>> asyncPredicate = (p, i) => p != null && p > 3&& i < 10;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithNullableSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithNullableDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereWithNullableDoubleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'predicate' parameter
            Func<double?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, int, bool>> asyncPredicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithNullableDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, int, bool>> asyncPredicate = (p, i) => p != null && p > 3&& i < 10;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithNullableDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereWithDecimalSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'predicate' parameter
            Func<decimal, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, int, bool>> asyncPredicate = (p, i) => p > 3&& i < 10;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, int, bool>> asyncPredicate = (p, i) => p > 3&& i < 10;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereWithSingleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'predicate' parameter
            Func<float, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, int, bool>> asyncPredicate = (p, i) => p > 3&& i < 10;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, int, bool>> asyncPredicate = (p, i) => p > 3&& i < 10;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithNullableInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereWithNullableInt64SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'predicate' parameter
            Func<long?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, int, bool>> asyncPredicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithNullableInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, int, bool>> asyncPredicate = (p, i) => p != null && p > 3&& i < 10;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithNullableInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithNullableInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereWithNullableInt32SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'predicate' parameter
            Func<int?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, int, bool>> asyncPredicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithNullableInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, int, bool>> asyncPredicate = (p, i) => p != null && p > 3&& i < 10;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithNullableInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereWithInt64SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'predicate' parameter
            Func<long, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, int, bool>> asyncPredicate = (p, i) => p > 3&& i < 10;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, int, bool>> asyncPredicate = (p, i) => p > 3&& i < 10;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereWithInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereWithInt32SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'predicate' parameter
            Func<int, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, int, bool>> asyncPredicate = (p, i) => p > 3&& i < 10;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.Where<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereWithInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, int, bool>> asyncPredicate = (p, i) => p > 3&& i < 10;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereWithInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, int, bool>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Where<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithDoubleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'predicate' parameter
            Func<double, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithNullableDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithNullableDecimalSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'predicate' parameter
            Func<decimal?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithNullableDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithNullableDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithNullableSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithNullableSingleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'predicate' parameter
            Func<float?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithNullableSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithNullableSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithNullableDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithNullableDoubleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'predicate' parameter
            Func<double?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithNullableDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithNullableDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithDecimalSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'predicate' parameter
            Func<decimal, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithSingleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'predicate' parameter
            Func<float, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithNullableInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithNullableInt64SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'predicate' parameter
            Func<long?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithNullableInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithNullableInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithNullableInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithNullableInt32SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'predicate' parameter
            Func<int?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithNullableInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithNullableInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithInt64SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'predicate' parameter
            Func<long, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithInt32SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'predicate' parameter
            Func<int, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, int, ValueTask<bool>>> asyncPredicate = (p, i) => new ValueTask<bool>(p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithDoubleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'predicate' parameter
            Func<double, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithNullableDecimalSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'predicate' parameter
            Func<decimal?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithNullableSingleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'predicate' parameter
            Func<float?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithNullableDoubleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'predicate' parameter
            Func<double?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithDecimalSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'predicate' parameter
            Func<decimal, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithSingleSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithSingleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'predicate' parameter
            Func<float, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithNullableInt64SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'predicate' parameter
            Func<long?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithNullableInt32SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'predicate' parameter
            Func<int?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithInt64SourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithInt64SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'predicate' parameter
            Func<long, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithInt32SourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithInt32SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'predicate' parameter
            Func<int, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithDoubleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'predicate' parameter
            Func<double, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDecimalSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'predicate' parameter
            Func<decimal?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableSingleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'predicate' parameter
            Func<float?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDoubleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'predicate' parameter
            Func<double?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithDecimalSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'predicate' parameter
            Func<decimal, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithSingleSourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithSingleSourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'predicate' parameter
            Func<float, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt64SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'predicate' parameter
            Func<long?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt32SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'predicate' parameter
            Func<int?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithInt64SourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt64SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'predicate' parameter
            Func<long, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithInt32SourceWithPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt32SourceWithPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'predicate' parameter
            Func<int, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'predicate' parameter
            Func<double, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'predicate' parameter
            Func<decimal?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'predicate' parameter
            Func<float?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'predicate' parameter
            Func<double?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'predicate' parameter
            Func<decimal, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithSingleSourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'predicate' parameter
            Func<float, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'predicate' parameter
            Func<long?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'predicate' parameter
            Func<int?, int, bool> predicate = (p, i) => p != null && p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p != null && p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt64SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'predicate' parameter
            Func<long, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region WhereAwaitWithCancellationWithInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt32SourceWithWithIndexedPredicateIsEquivalentToWhereTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'predicate' parameter
            Func<int, int, bool> predicate = (p, i) => p > 3&& i < 10;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p > 3&& i < 10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Where<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.WhereAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, i, c) => new ValueTask<bool>(p > 3&& i < 10);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task WhereAwaitWithCancellationWithInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.WhereAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
