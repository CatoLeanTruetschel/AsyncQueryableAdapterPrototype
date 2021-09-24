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

        #region TakeWhileWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileWithDoubleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileWithNullableDecimalSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileWithNullableSingleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileWithNullableDoubleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileWithDecimalSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithSingleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileWithSingleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileWithNullableInt64SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileWithNullableInt32SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithInt64SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileWithInt64SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithInt32SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileWithInt32SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileWithDoubleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithNullableDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileWithNullableDecimalSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithNullableDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithNullableDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithNullableSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileWithNullableSingleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithNullableSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithNullableSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithNullableDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileWithNullableDoubleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithNullableDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithNullableDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileWithDecimalSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileWithSingleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithNullableInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileWithNullableInt64SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithNullableInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithNullableInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithNullableInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileWithNullableInt32SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithNullableInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithNullableInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileWithInt64SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileWithInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileWithInt32SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileWithInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileWithInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithDoubleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithNullableDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithNullableDecimalSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithNullableSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithNullableSingleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithNullableDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithNullableDoubleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithDecimalSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithSingleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithNullableInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt64SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithNullableInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt32SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithInt64SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithInt32SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithDoubleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithNullableDecimalSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithNullableSingleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithNullableDoubleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithDecimalSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithSingleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithSingleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt64SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt32SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithInt64SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithInt64SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithInt32SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithInt32SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDoubleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDecimalSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableSingleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDoubleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDecimalSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithSingleSourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithSingleSourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt64SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt32SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithInt64SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt64SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithInt32SourceWithPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt32SourceWithPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithSingleSourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt64SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region TakeWhileAwaitWithCancellationWithInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt32SourceWithWithIndexedPredicateIsEquivalentToTakeWhileTest()
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
            var expectedResult = Enumerable.TakeWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.TakeWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task TakeWhileAwaitWithCancellationWithInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.TakeWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
