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

        #region LastAsyncWithNullableDoubleSource tests

        [Fact]
        public async Task LastAsyncWithNullableDoubleSourceIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<double?>(source);

            // Act
            var result = await AsyncQueryable.LastAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithNullableDoubleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableDoubleSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithDoubleSource tests

        [Fact]
        public async Task LastAsyncWithDoubleSourceIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<double>(source);

            // Act
            var result = await AsyncQueryable.LastAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithDoubleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithDoubleSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithDecimalSource tests

        [Fact]
        public async Task LastAsyncWithDecimalSourceIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<decimal>(source);

            // Act
            var result = await AsyncQueryable.LastAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithDecimalSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithDecimalSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithNullableDecimalSource tests

        [Fact]
        public async Task LastAsyncWithNullableDecimalSourceIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<decimal?>(source);

            // Act
            var result = await AsyncQueryable.LastAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithNullableDecimalSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableDecimalSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithNullableSingleSource tests

        [Fact]
        public async Task LastAsyncWithNullableSingleSourceIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<float?>(source);

            // Act
            var result = await AsyncQueryable.LastAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithNullableSingleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableSingleSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithSingleSource tests

        [Fact]
        public async Task LastAsyncWithSingleSourceIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<float>(source);

            // Act
            var result = await AsyncQueryable.LastAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithSingleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithSingleSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithInt64Source tests

        [Fact]
        public async Task LastAsyncWithInt64SourceIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<long>(source);

            // Act
            var result = await AsyncQueryable.LastAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithInt64SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithInt64SourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithInt32Source tests

        [Fact]
        public async Task LastAsyncWithInt32SourceIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<int>(source);

            // Act
            var result = await AsyncQueryable.LastAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithInt32SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithInt32SourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithNullableInt64Source tests

        [Fact]
        public async Task LastAsyncWithNullableInt64SourceIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<long?>(source);

            // Act
            var result = await AsyncQueryable.LastAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithNullableInt64SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableInt64SourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithNullableInt32Source tests

        [Fact]
        public async Task LastAsyncWithNullableInt32SourceIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<int?>(source);

            // Act
            var result = await AsyncQueryable.LastAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithNullableInt32SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableInt32SourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task LastAsyncWithNullableDoubleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithNullableDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task LastAsyncWithDoubleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task LastAsyncWithDecimalSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task LastAsyncWithNullableDecimalSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithNullableDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task LastAsyncWithNullableSingleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithNullableSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithSingleSourceWithPredicate tests

        [Fact]
        public async Task LastAsyncWithSingleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithInt64SourceWithPredicate tests

        [Fact]
        public async Task LastAsyncWithInt64SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithInt32SourceWithPredicate tests

        [Fact]
        public async Task LastAsyncWithInt32SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task LastAsyncWithNullableInt64SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithNullableInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAsyncWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task LastAsyncWithNullableInt32SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAsyncWithNullableInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAsyncWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitAsyncWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitAsyncWithNullableDoubleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitAsyncWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitAsyncWithDoubleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitAsyncWithDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitAsyncWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitAsyncWithDecimalSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitAsyncWithDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitAsyncWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitAsyncWithNullableDecimalSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitAsyncWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitAsyncWithNullableSingleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitAsyncWithSingleSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitAsyncWithSingleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitAsyncWithSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitAsyncWithInt64SourceWithPredicate tests

        [Fact]
        public async Task LastAwaitAsyncWithInt64SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitAsyncWithInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitAsyncWithInt32SourceWithPredicate tests

        [Fact]
        public async Task LastAwaitAsyncWithInt32SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitAsyncWithInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitAsyncWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task LastAwaitAsyncWithNullableInt64SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitAsyncWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task LastAwaitAsyncWithNullableInt32SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitAsyncWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitWithCancellationAsyncWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithDoubleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitWithCancellationAsyncWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithDecimalSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitWithCancellationAsyncWithSingleSourceWithPredicate tests

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithSingleSourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitWithCancellationAsyncWithInt64SourceWithPredicate tests

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithInt64SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitWithCancellationAsyncWithInt32SourceWithPredicate tests

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithInt32SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region LastAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateIsEquivalentToLastTest()
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
            var expectedResult = Enumerable.Last<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.LastAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task LastAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.LastAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion
    }
}
