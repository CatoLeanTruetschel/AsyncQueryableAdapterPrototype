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

        #region ElementAtAsyncWithNullableDoubleSourceWithIndex tests

        [Fact]
        public async Task ElementAtAsyncWithNullableDoubleSourceWithIndexIsEquivalentToElementAtTest()
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
            var expectedResult = Enumerable.ElementAt<double?>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtAsync<double?>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtAsyncWithNullableDoubleSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<double?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtAsyncWithNullableDoubleSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<double?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtAsyncWithDoubleSourceWithIndex tests

        [Fact]
        public async Task ElementAtAsyncWithDoubleSourceWithIndexIsEquivalentToElementAtTest()
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
            var expectedResult = Enumerable.ElementAt<double>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtAsync<double>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtAsyncWithDoubleSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<double>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtAsyncWithDoubleSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<double>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtAsyncWithDecimalSourceWithIndex tests

        [Fact]
        public async Task ElementAtAsyncWithDecimalSourceWithIndexIsEquivalentToElementAtTest()
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
            var expectedResult = Enumerable.ElementAt<decimal>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtAsync<decimal>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtAsyncWithDecimalSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<decimal>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtAsyncWithDecimalSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<decimal>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtAsyncWithNullableDecimalSourceWithIndex tests

        [Fact]
        public async Task ElementAtAsyncWithNullableDecimalSourceWithIndexIsEquivalentToElementAtTest()
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
            var expectedResult = Enumerable.ElementAt<decimal?>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtAsync<decimal?>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtAsyncWithNullableDecimalSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<decimal?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtAsyncWithNullableDecimalSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<decimal?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtAsyncWithNullableSingleSourceWithIndex tests

        [Fact]
        public async Task ElementAtAsyncWithNullableSingleSourceWithIndexIsEquivalentToElementAtTest()
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
            var expectedResult = Enumerable.ElementAt<float?>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtAsync<float?>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtAsyncWithNullableSingleSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<float?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtAsyncWithNullableSingleSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<float?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtAsyncWithSingleSourceWithIndex tests

        [Fact]
        public async Task ElementAtAsyncWithSingleSourceWithIndexIsEquivalentToElementAtTest()
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
            var expectedResult = Enumerable.ElementAt<float>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtAsync<float>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtAsyncWithSingleSourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<float>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtAsyncWithSingleSourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<float>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtAsyncWithInt64SourceWithIndex tests

        [Fact]
        public async Task ElementAtAsyncWithInt64SourceWithIndexIsEquivalentToElementAtTest()
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
            var expectedResult = Enumerable.ElementAt<long>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtAsync<long>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtAsyncWithInt64SourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<long>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtAsyncWithInt64SourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<long>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtAsyncWithInt32SourceWithIndex tests

        [Fact]
        public async Task ElementAtAsyncWithInt32SourceWithIndexIsEquivalentToElementAtTest()
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
            var expectedResult = Enumerable.ElementAt<int>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtAsync<int>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtAsyncWithInt32SourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<int>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtAsyncWithInt32SourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<int>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtAsyncWithNullableInt64SourceWithIndex tests

        [Fact]
        public async Task ElementAtAsyncWithNullableInt64SourceWithIndexIsEquivalentToElementAtTest()
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
            var expectedResult = Enumerable.ElementAt<long?>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtAsync<long?>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtAsyncWithNullableInt64SourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<long?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtAsyncWithNullableInt64SourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<long?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ElementAtAsyncWithNullableInt32SourceWithIndex tests

        [Fact]
        public async Task ElementAtAsyncWithNullableInt32SourceWithIndexIsEquivalentToElementAtTest()
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
            var expectedResult = Enumerable.ElementAt<int?>(source, index);

            // Act
            var result = await AsyncQueryable.ElementAtAsync<int?>(asyncSource, index, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ElementAtAsyncWithNullableInt32SourceWithIndexCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<int?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ElementAtAsyncWithNullableInt32SourceWithIndexNullSourceThrowsArgumentNullExceptionTest()
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
                await AsyncQueryable.ElementAtAsync<int?>(asyncSource, index, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion
    }
}
