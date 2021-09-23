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

        #region FirstAsyncWithNullableDoubleSource tests

        [Fact]
        public async Task FirstAsyncWithNullableDoubleSourceIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<double?>(source);

            // Act
            var result = await AsyncQueryable.FirstAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithNullableDoubleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableDoubleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithDoubleSource tests

        [Fact]
        public async Task FirstAsyncWithDoubleSourceIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<double>(source);

            // Act
            var result = await AsyncQueryable.FirstAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithDoubleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithDoubleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithDecimalSource tests

        [Fact]
        public async Task FirstAsyncWithDecimalSourceIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<decimal>(source);

            // Act
            var result = await AsyncQueryable.FirstAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithDecimalSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithDecimalSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithNullableDecimalSource tests

        [Fact]
        public async Task FirstAsyncWithNullableDecimalSourceIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<decimal?>(source);

            // Act
            var result = await AsyncQueryable.FirstAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithNullableDecimalSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableDecimalSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithNullableSingleSource tests

        [Fact]
        public async Task FirstAsyncWithNullableSingleSourceIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<float?>(source);

            // Act
            var result = await AsyncQueryable.FirstAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithNullableSingleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableSingleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithSingleSource tests

        [Fact]
        public async Task FirstAsyncWithSingleSourceIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<float>(source);

            // Act
            var result = await AsyncQueryable.FirstAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithSingleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithSingleSourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithInt64Source tests

        [Fact]
        public async Task FirstAsyncWithInt64SourceIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<long>(source);

            // Act
            var result = await AsyncQueryable.FirstAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithInt64SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithInt64SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithInt32Source tests

        [Fact]
        public async Task FirstAsyncWithInt32SourceIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<int>(source);

            // Act
            var result = await AsyncQueryable.FirstAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithInt32SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithInt32SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithNullableInt64Source tests

        [Fact]
        public async Task FirstAsyncWithNullableInt64SourceIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<long?>(source);

            // Act
            var result = await AsyncQueryable.FirstAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithNullableInt64SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableInt64SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithNullableInt32Source tests

        [Fact]
        public async Task FirstAsyncWithNullableInt32SourceIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<int?>(source);

            // Act
            var result = await AsyncQueryable.FirstAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithNullableInt32SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableInt32SourceNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstAsyncWithNullableDoubleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'predicate' parameter
            Func<double?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithNullableDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, bool>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstAsyncWithDoubleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'predicate' parameter
            Func<double, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, bool>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstAsyncWithDecimalSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'predicate' parameter
            Func<decimal, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, bool>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstAsyncWithNullableDecimalSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'predicate' parameter
            Func<decimal?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithNullableDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, bool>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstAsyncWithNullableSingleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'predicate' parameter
            Func<float?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithNullableSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, bool>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstAsyncWithSingleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'predicate' parameter
            Func<float, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, bool>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstAsyncWithInt64SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'predicate' parameter
            Func<long, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, bool>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstAsyncWithInt32SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'predicate' parameter
            Func<int, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, bool>> asyncPredicate = (p) => p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, bool>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstAsyncWithNullableInt64SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'predicate' parameter
            Func<long?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithNullableInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, bool>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAsyncWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstAsyncWithNullableInt32SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'predicate' parameter
            Func<int?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAsyncWithNullableInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, bool>> asyncPredicate = (p) => p != null && p > 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAsyncWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, bool>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitAsyncWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitAsyncWithNullableDoubleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'predicate' parameter
            Func<double?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitAsyncWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitAsyncWithDoubleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'predicate' parameter
            Func<double, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitAsyncWithDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitAsyncWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitAsyncWithDecimalSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'predicate' parameter
            Func<decimal, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitAsyncWithDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitAsyncWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitAsyncWithNullableDecimalSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'predicate' parameter
            Func<decimal?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitAsyncWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitAsyncWithNullableSingleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'predicate' parameter
            Func<float?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitAsyncWithSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitAsyncWithSingleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'predicate' parameter
            Func<float, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitAsyncWithSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitAsyncWithInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitAsyncWithInt64SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'predicate' parameter
            Func<long, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitAsyncWithInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitAsyncWithInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitAsyncWithInt32SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'predicate' parameter
            Func<int, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitAsyncWithInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitAsyncWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitAsyncWithNullableInt64SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'predicate' parameter
            Func<long?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitAsyncWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitAsyncWithNullableInt32SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'predicate' parameter
            Func<int?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, ValueTask<bool>>> asyncPredicate = (p) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitAsyncWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'predicate' parameter
            Func<double?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double?, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitWithCancellationAsyncWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithDoubleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'predicate' parameter
            Func<double, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<double, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitWithCancellationAsyncWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithDecimalSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'predicate' parameter
            Func<decimal, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'predicate' parameter
            Func<decimal?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'predicate' parameter
            Func<float?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float?, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitWithCancellationAsyncWithSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithSingleSourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'predicate' parameter
            Func<float, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<float, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitWithCancellationAsyncWithInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithInt64SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'predicate' parameter
            Func<long, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitWithCancellationAsyncWithInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithInt32SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'predicate' parameter
            Func<int, bool> predicate = (p) => p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'predicate' parameter
            Func<long?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<long?, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateIsEquivalentToFirstTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'predicate' parameter
            Func<int?, bool> predicate = (p) => p != null && p > 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.First<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, CancellationToken, ValueTask<bool>>> asyncPredicate = (p, c) => new ValueTask<bool>(p != null && p > 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncPredicate' parameter
            Expression<Func<int?, CancellationToken, ValueTask<bool>>> asyncPredicate = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.FirstAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion
    }
}
