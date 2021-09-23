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

        #region SequenceEqualAsyncWithNullableDoubleSourceWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDoubleSourceWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double?>();

            // Arrange 'second' parameter
            var second = GetQueryable<double?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<double?>(first, second);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<double?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDoubleSourceWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDoubleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDoubleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double?> asyncSecond = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithDoubleSourceWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithDoubleSourceWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double>();

            // Arrange 'second' parameter
            var second = GetQueryable<double>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<double>(first, second);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<double>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDoubleSourceWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDoubleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDoubleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double> asyncSecond = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithDecimalSourceWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithDecimalSourceWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<decimal>(first, second);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<decimal>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDecimalSourceWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDecimalSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDecimalSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal> asyncSecond = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithNullableDecimalSourceWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDecimalSourceWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal?>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<decimal?>(first, second);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<decimal?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDecimalSourceWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDecimalSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDecimalSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal?> asyncSecond = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithNullableSingleSourceWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithNullableSingleSourceWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float?>();

            // Arrange 'second' parameter
            var second = GetQueryable<float?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<float?>(first, second);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<float?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableSingleSourceWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableSingleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableSingleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float?> asyncSecond = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithSingleSourceWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithSingleSourceWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float>();

            // Arrange 'second' parameter
            var second = GetQueryable<float>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<float>(first, second);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<float>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithSingleSourceWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithSingleSourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithSingleSourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float> asyncSecond = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithInt64SourceWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithInt64SourceWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long>();

            // Arrange 'second' parameter
            var second = GetQueryable<long>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<long>(first, second);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<long>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt64SourceWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt64SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt64SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long> asyncSecond = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithInt32SourceWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithInt32SourceWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int>();

            // Arrange 'second' parameter
            var second = GetQueryable<int>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<int>(first, second);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<int>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt32SourceWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt32SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt32SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int> asyncSecond = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithNullableInt64SourceWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt64SourceWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long?>();

            // Arrange 'second' parameter
            var second = GetQueryable<long?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<long?>(first, second);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<long?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt64SourceWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt64SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt64SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long?> asyncSecond = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithNullableInt32SourceWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt32SourceWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int?>();

            // Arrange 'second' parameter
            var second = GetQueryable<int?>();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<int?>(first, second);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<int?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt32SourceWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt32SourceWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt32SourceWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int?> asyncSecond = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int?>(asyncFirst, asyncSecond, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithNullableDoubleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDoubleSourceWithComparerWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double?>();

            // Arrange 'second' parameter
            var second = GetQueryable<double?>();

            // Arrange 'comparer' parameter

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<double?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<double?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDoubleSourceWithComparerWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDoubleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDoubleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double?> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithDoubleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithDoubleSourceWithComparerWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<double>();

            // Arrange 'second' parameter
            var second = GetQueryable<double>();

            // Arrange 'comparer' parameter

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<double>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<double>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDoubleSourceWithComparerWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDoubleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<double> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDoubleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<double> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<double>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithDecimalSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithDecimalSourceWithComparerWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal>();

            // Arrange 'comparer' parameter

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<decimal>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<decimal>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDecimalSourceWithComparerWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDecimalSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithDecimalSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithNullableDecimalSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDecimalSourceWithComparerWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<decimal?>();

            // Arrange 'second' parameter
            var second = GetQueryable<decimal?>();

            // Arrange 'comparer' parameter

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<decimal?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<decimal?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDecimalSourceWithComparerWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDecimalSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<decimal?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableDecimalSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<decimal?> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<decimal?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithNullableSingleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithNullableSingleSourceWithComparerWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float?>();

            // Arrange 'second' parameter
            var second = GetQueryable<float?>();

            // Arrange 'comparer' parameter

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<float?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<float?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableSingleSourceWithComparerWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableSingleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableSingleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float?> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithSingleSourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithSingleSourceWithComparerWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<float>();

            // Arrange 'second' parameter
            var second = GetQueryable<float>();

            // Arrange 'comparer' parameter

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<float>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<float>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithSingleSourceWithComparerWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithSingleSourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<float> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithSingleSourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<float> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<float>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithInt64SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithInt64SourceWithComparerWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long>();

            // Arrange 'second' parameter
            var second = GetQueryable<long>();

            // Arrange 'comparer' parameter

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<long>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<long>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt64SourceWithComparerWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt64SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt64SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithInt32SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithInt32SourceWithComparerWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int>();

            // Arrange 'second' parameter
            var second = GetQueryable<int>();

            // Arrange 'comparer' parameter

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<int>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<int>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt32SourceWithComparerWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt32SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithInt32SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithNullableInt64SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt64SourceWithComparerWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<long?>();

            // Arrange 'second' parameter
            var second = GetQueryable<long?>();

            // Arrange 'comparer' parameter

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<long?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<long?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt64SourceWithComparerWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt64SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<long?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt64SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<long?> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<long?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region SequenceEqualAsyncWithNullableInt32SourceWithComparerWithFirstWithSecond tests

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt32SourceWithComparerWithFirstWithSecondIsEquivalentToSequenceEqualTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'first' parameter
            var first = GetQueryable<int?>();

            // Arrange 'second' parameter
            var second = GetQueryable<int?>();

            // Arrange 'comparer' parameter

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.SequenceEqual<int?>(first, second, comparer);

            // Act
            var result = await AsyncQueryable.SequenceEqualAsync<int?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt32SourceWithComparerWithFirstWithSecondCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt32SourceWithComparerWithFirstWithSecondNullFirstThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            IAsyncQueryable<int?> asyncFirst = null!;

            // Arrange 'asyncSecond' parameter
            var asyncSecond = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task SequenceEqualAsyncWithNullableInt32SourceWithComparerWithFirstWithSecondNullSecondThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncFirst' parameter
            var asyncFirst = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncSecond' parameter
            IAsyncEnumerable<int?> asyncSecond = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.SequenceEqualAsync<int?>(asyncFirst, asyncSecond, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion
    }
}
