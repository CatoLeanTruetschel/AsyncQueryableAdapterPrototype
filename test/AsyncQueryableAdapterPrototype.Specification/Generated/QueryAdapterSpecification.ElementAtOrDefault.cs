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

        #region ElementAtOrDefaultAsyncWithNullableDoubleSourceWithIndex tests

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableDoubleSourceWithIndexIsEquivalentToElementAtOrDefaultTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'index' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ElementAtOrDefault<double?>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtOrDefaultAsync<double?>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableDoubleSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<double?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableDoubleSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<double?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtOrDefaultAsyncWithDoubleSourceWithIndex tests

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithDoubleSourceWithIndexIsEquivalentToElementAtOrDefaultTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'index' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ElementAtOrDefault<double>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtOrDefaultAsync<double>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithDoubleSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<double>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithDoubleSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<double>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtOrDefaultAsyncWithDecimalSourceWithIndex tests

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithDecimalSourceWithIndexIsEquivalentToElementAtOrDefaultTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'index' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ElementAtOrDefault<decimal>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtOrDefaultAsync<decimal>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithDecimalSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<decimal>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithDecimalSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<decimal>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtOrDefaultAsyncWithNullableDecimalSourceWithIndex tests

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableDecimalSourceWithIndexIsEquivalentToElementAtOrDefaultTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'index' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ElementAtOrDefault<decimal?>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtOrDefaultAsync<decimal?>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableDecimalSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<decimal?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableDecimalSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<decimal?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtOrDefaultAsyncWithNullableSingleSourceWithIndex tests

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableSingleSourceWithIndexIsEquivalentToElementAtOrDefaultTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'index' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ElementAtOrDefault<float?>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtOrDefaultAsync<float?>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableSingleSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<float?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableSingleSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<float?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtOrDefaultAsyncWithSingleSourceWithIndex tests

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithSingleSourceWithIndexIsEquivalentToElementAtOrDefaultTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'index' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ElementAtOrDefault<float>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtOrDefaultAsync<float>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithSingleSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<float>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithSingleSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<float>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtOrDefaultAsyncWithInt64SourceWithIndex tests

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithInt64SourceWithIndexIsEquivalentToElementAtOrDefaultTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'index' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ElementAtOrDefault<long>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtOrDefaultAsync<long>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithInt64SourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<long>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithInt64SourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<long>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtOrDefaultAsyncWithInt32SourceWithIndex tests

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithInt32SourceWithIndexIsEquivalentToElementAtOrDefaultTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'index' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ElementAtOrDefault<int>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtOrDefaultAsync<int>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithInt32SourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<int>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithInt32SourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<int>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtOrDefaultAsyncWithNullableInt64SourceWithIndex tests

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableInt64SourceWithIndexIsEquivalentToElementAtOrDefaultTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'index' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ElementAtOrDefault<long?>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtOrDefaultAsync<long?>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableInt64SourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<long?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableInt64SourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<long?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtOrDefaultAsyncWithNullableInt32SourceWithIndex tests

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableInt32SourceWithIndexIsEquivalentToElementAtOrDefaultTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'index' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ElementAtOrDefault<int?>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtOrDefaultAsync<int?>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableInt32SourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<int?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtOrDefaultAsyncWithNullableInt32SourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'index' parameter
            var index = 5;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ElementAtOrDefaultAsync<int?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion
    }
}
