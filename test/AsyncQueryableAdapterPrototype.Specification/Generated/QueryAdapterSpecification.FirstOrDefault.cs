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

        #region FirstOrDefaultAsyncWithNullableDoubleSource tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDoubleSourceIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<double?>(source);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDoubleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDoubleSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithDoubleSource tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithDoubleSourceIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<double>(source);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithDoubleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithDoubleSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithDecimalSource tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithDecimalSourceIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<decimal>(source);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithDecimalSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithDecimalSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithNullableDecimalSource tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDecimalSourceIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<decimal?>(source);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDecimalSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDecimalSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithNullableSingleSource tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableSingleSourceIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<float?>(source);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableSingleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableSingleSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithSingleSource tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithSingleSourceIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<float>(source);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithSingleSourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithSingleSourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithInt64Source tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt64SourceIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<long>(source);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt64SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt64SourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithInt32Source tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt32SourceIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<int>(source);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt32SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt32SourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithNullableInt64Source tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt64SourceIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<long?>(source);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt64SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt64SourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithNullableInt32Source tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt32SourceIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<int?>(source);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt32SourceCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt32SourceNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDoubleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithDoubleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithDecimalSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDecimalSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableSingleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithSingleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt64SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt32SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt64SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAsyncWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt32SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAsyncWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitAsyncWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableDoubleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitAsyncWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithDoubleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitAsyncWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithDecimalSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitAsyncWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableDecimalSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitAsyncWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableSingleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitAsyncWithSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithSingleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitAsyncWithInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithInt64SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitAsyncWithInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithInt32SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitAsyncWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableInt64SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitAsyncWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableInt32SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitAsyncWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<double?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<double?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitWithCancellationAsyncWithDoubleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithDoubleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<double>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithDoubleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithDoubleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithDoubleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<double>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitWithCancellationAsyncWithDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithDecimalSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<decimal>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<decimal>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<decimal?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableDecimalSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<decimal?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<float?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<float?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitWithCancellationAsyncWithSingleSourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithSingleSourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<float>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithSingleSourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithSingleSourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithSingleSourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<float>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitWithCancellationAsyncWithInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithInt64SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<long>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<long>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitWithCancellationAsyncWithInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithInt32SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<int>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<int>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<long?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableInt64SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<long?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region FirstOrDefaultAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicate tests

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateIsEquivalentToFirstOrDefaultTest()
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
            var expectedResult = Enumerable.FirstOrDefault<int?>(source, predicate);

            // Act
            var result = await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task FirstOrDefaultAwaitWithCancellationAsyncWithNullableInt32SourceWithPredicateNullPredicateThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync<int?>(asyncSource, asyncPredicate, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion
    }
}
