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

        #region ToArrayAsyncWithNullableDoubleSourceWithNullableDoubleArrayResult tests

        [Fact]
        public async Task ToArrayAsyncWithNullableDoubleSourceWithNullableDoubleArrayResultIsEquivalentToToArrayTest()
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
            var expectedResult = Enumerable.ToArray<double?>(source);

            // Act
            var result = await AsyncQueryable.ToArrayAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToArrayAsyncWithNullableDoubleSourceWithNullableDoubleArrayResultCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToArrayAsyncWithNullableDoubleSourceWithNullableDoubleArrayResultNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<double?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToArrayAsyncWithDoubleSourceWithDoubleArrayResult tests

        [Fact]
        public async Task ToArrayAsyncWithDoubleSourceWithDoubleArrayResultIsEquivalentToToArrayTest()
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
            var expectedResult = Enumerable.ToArray<double>(source);

            // Act
            var result = await AsyncQueryable.ToArrayAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToArrayAsyncWithDoubleSourceWithDoubleArrayResultCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToArrayAsyncWithDoubleSourceWithDoubleArrayResultNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<double>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToArrayAsyncWithDecimalSourceWithDecimalArrayResult tests

        [Fact]
        public async Task ToArrayAsyncWithDecimalSourceWithDecimalArrayResultIsEquivalentToToArrayTest()
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
            var expectedResult = Enumerable.ToArray<decimal>(source);

            // Act
            var result = await AsyncQueryable.ToArrayAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToArrayAsyncWithDecimalSourceWithDecimalArrayResultCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToArrayAsyncWithDecimalSourceWithDecimalArrayResultNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<decimal>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToArrayAsyncWithNullableDecimalSourceWithNullableDecimalArrayResult tests

        [Fact]
        public async Task ToArrayAsyncWithNullableDecimalSourceWithNullableDecimalArrayResultIsEquivalentToToArrayTest()
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
            var expectedResult = Enumerable.ToArray<decimal?>(source);

            // Act
            var result = await AsyncQueryable.ToArrayAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToArrayAsyncWithNullableDecimalSourceWithNullableDecimalArrayResultCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToArrayAsyncWithNullableDecimalSourceWithNullableDecimalArrayResultNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<decimal?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToArrayAsyncWithNullableSingleSourceWithNullableSingleArrayResult tests

        [Fact]
        public async Task ToArrayAsyncWithNullableSingleSourceWithNullableSingleArrayResultIsEquivalentToToArrayTest()
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
            var expectedResult = Enumerable.ToArray<float?>(source);

            // Act
            var result = await AsyncQueryable.ToArrayAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToArrayAsyncWithNullableSingleSourceWithNullableSingleArrayResultCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToArrayAsyncWithNullableSingleSourceWithNullableSingleArrayResultNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<float?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToArrayAsyncWithSingleSourceWithSingleArrayResult tests

        [Fact]
        public async Task ToArrayAsyncWithSingleSourceWithSingleArrayResultIsEquivalentToToArrayTest()
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
            var expectedResult = Enumerable.ToArray<float>(source);

            // Act
            var result = await AsyncQueryable.ToArrayAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToArrayAsyncWithSingleSourceWithSingleArrayResultCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToArrayAsyncWithSingleSourceWithSingleArrayResultNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<float>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToArrayAsyncWithInt64SourceWithInt64ArrayResult tests

        [Fact]
        public async Task ToArrayAsyncWithInt64SourceWithInt64ArrayResultIsEquivalentToToArrayTest()
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
            var expectedResult = Enumerable.ToArray<long>(source);

            // Act
            var result = await AsyncQueryable.ToArrayAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToArrayAsyncWithInt64SourceWithInt64ArrayResultCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToArrayAsyncWithInt64SourceWithInt64ArrayResultNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<long>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToArrayAsyncWithInt32SourceWithInt32ArrayResult tests

        [Fact]
        public async Task ToArrayAsyncWithInt32SourceWithInt32ArrayResultIsEquivalentToToArrayTest()
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
            var expectedResult = Enumerable.ToArray<int>(source);

            // Act
            var result = await AsyncQueryable.ToArrayAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToArrayAsyncWithInt32SourceWithInt32ArrayResultCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToArrayAsyncWithInt32SourceWithInt32ArrayResultNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<int>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToArrayAsyncWithNullableInt64SourceWithNullableInt64ArrayResult tests

        [Fact]
        public async Task ToArrayAsyncWithNullableInt64SourceWithNullableInt64ArrayResultIsEquivalentToToArrayTest()
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
            var expectedResult = Enumerable.ToArray<long?>(source);

            // Act
            var result = await AsyncQueryable.ToArrayAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToArrayAsyncWithNullableInt64SourceWithNullableInt64ArrayResultCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToArrayAsyncWithNullableInt64SourceWithNullableInt64ArrayResultNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<long?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToArrayAsyncWithNullableInt32SourceWithNullableInt32ArrayResult tests

        [Fact]
        public async Task ToArrayAsyncWithNullableInt32SourceWithNullableInt32ArrayResultIsEquivalentToToArrayTest()
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
            var expectedResult = Enumerable.ToArray<int?>(source);

            // Act
            var result = await AsyncQueryable.ToArrayAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToArrayAsyncWithNullableInt32SourceWithNullableInt32ArrayResultCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToArrayAsyncWithNullableInt32SourceWithNullableInt32ArrayResultNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ToArrayAsync<int?>(asyncSource, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion
    }
}
