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

        #region SkipWhileWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileWithDoubleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileWithNullableDecimalSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileWithNullableSingleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileWithNullableDoubleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileWithDecimalSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithSingleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileWithSingleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileWithNullableInt64SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileWithNullableInt32SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithInt64SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileWithInt64SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithInt32SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileWithInt32SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileWithDoubleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithNullableDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileWithNullableDecimalSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithNullableDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithNullableDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithNullableSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileWithNullableSingleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithNullableSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithNullableSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithNullableDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileWithNullableDoubleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithNullableDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithNullableDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileWithDecimalSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileWithSingleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithNullableInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileWithNullableInt64SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithNullableInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithNullableInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithNullableInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileWithNullableInt32SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithNullableInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithNullableInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileWithInt64SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileWithInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileWithInt32SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileWithInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileWithInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhile<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithDoubleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithNullableDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithNullableDecimalSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithNullableSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithNullableSingleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithNullableDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithNullableDoubleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithDecimalSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithSingleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithNullableInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt64SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithNullableInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt32SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithInt64SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithInt32SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithDoubleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithNullableDecimalSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithNullableSingleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithNullableDoubleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithDecimalSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithSingleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithSingleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt64SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt32SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithInt64SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithInt64SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithInt32SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithInt32SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwait<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDoubleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDecimalSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableSingleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDoubleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDecimalSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithSingleSourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithSingleSourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt64SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt32SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithInt64SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt64SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithInt32SourceWithPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt32SourceWithPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<double>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<float?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableDoubleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<double?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithDecimalSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<decimal>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithSingleSourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithSingleSourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithSingleSourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithSingleSourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<float>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<long?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithNullableInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<int?>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithInt64SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt64SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt64SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt64SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<long>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region SkipWhileAwaitWithCancellationWithInt32SourceWithWithIndexedPredicate tests

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt32SourceWithWithIndexedPredicateIsEquivalentToSkipWhileTest()
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
            var expectedResult = Enumerable.SkipWhile<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.SkipWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt32SourceWithWithIndexedPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SkipWhileAwaitWithCancellationWithInt32SourceWithWithIndexedPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.SkipWhileAwaitWithCancellation<int>(asyncSource, asyncPredicate).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
