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

        #region ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithComparerWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithComparerWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithComparerWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double?, double?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, double?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?, double?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, double?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, double?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, double?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, double?>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double, double> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, double>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double, double>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, double>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, double>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, double>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, double>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal, decimal> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, decimal>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal, decimal>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, decimal>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, decimal>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, decimal>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, decimal>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal?, decimal?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?, decimal?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float?, float?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, float?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?, float?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, float?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, float?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, float?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, float?>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float, float> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, float>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float, float>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, float>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, float>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, float>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, float>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long, long> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, long>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long, long>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, long>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, long>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, long>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, long>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int, int> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, int>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int, int>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, int>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, int>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, int>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, int>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long?, long?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, long?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?, long?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, long?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, long?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, long?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, long?>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int?, int?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, int?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?, int?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, int?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, int?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, int?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, int?>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double?, double?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, double?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?, double?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, double?>> asyncElementSelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, double?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, double?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, double?>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double, double> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, double>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double, double>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, double>> asyncElementSelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, double>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, double>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, double>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal, decimal> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, decimal>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal, decimal>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, decimal>> asyncElementSelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, decimal>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, decimal>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, decimal>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal?, decimal?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?, decimal?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncElementSelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float?, float?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, float?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?, float?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, float?>> asyncElementSelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, float?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, float?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, float?>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float, float> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, float>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float, float>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, float>> asyncElementSelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, float>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, float>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, float>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long, long> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, long>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long, long>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, long>> asyncElementSelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, long>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, long>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, long>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int, int> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, int>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int, int>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, int>> asyncElementSelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, int>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, int>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, int>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long?, long?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, long?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?, long?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, long?>> asyncElementSelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, long?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, long?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, long?>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int?, int?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, int?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?, int?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, int?>> asyncElementSelector = (p) => p + 3;

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
                await AsyncQueryable.ToDictionaryAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, int?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, int?>> asyncElementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, int?>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double?, double?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncElementSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?, double?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncElementSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncElementSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncElementSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double, double> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncElementSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double, double>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncElementSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncElementSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncElementSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal, decimal> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncElementSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal, decimal>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncElementSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncElementSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncElementSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal?, decimal?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncElementSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?, decimal?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncElementSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncElementSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncElementSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float?, float?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncElementSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?, float?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncElementSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncElementSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncElementSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float, float> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncElementSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float, float>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncElementSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncElementSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncElementSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long, long> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncElementSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long, long>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncElementSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncElementSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncElementSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int, int> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncElementSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int, int>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncElementSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncElementSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncElementSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long?, long?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncElementSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?, long?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncElementSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncElementSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncElementSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int?, int?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncElementSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?, int?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncElementSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncElementSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncElementSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double?, double?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncElementSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?, double?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncElementSelector = (p) => new ValueTask<double?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncElementSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncElementSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double, double> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncElementSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double, double>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncElementSelector = (p) => new ValueTask<double>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncElementSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncElementSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal, decimal> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncElementSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal, decimal>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncElementSelector = (p) => new ValueTask<decimal>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncElementSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncElementSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal?, decimal?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncElementSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?, decimal?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncElementSelector = (p) => new ValueTask<decimal?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncElementSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncElementSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float?, float?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncElementSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?, float?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncElementSelector = (p) => new ValueTask<float?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncElementSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncElementSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float, float> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncElementSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float, float>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncElementSelector = (p) => new ValueTask<float>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncElementSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncElementSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long, long> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncElementSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long, long>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncElementSelector = (p) => new ValueTask<long>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncElementSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncElementSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int, int> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncElementSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int, int>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncElementSelector = (p) => new ValueTask<int>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncElementSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncElementSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long?, long?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncElementSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?, long?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncElementSelector = (p) => new ValueTask<long?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncElementSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncElementSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int?, int?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncElementSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?, int?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncElementSelector = (p) => new ValueTask<int?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncElementSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncElementSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double?, double?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncElementSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?, double?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncElementSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncElementSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncElementSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double, double> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncElementSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double, double>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncElementSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncElementSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncElementSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal, decimal> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncElementSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal, decimal>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncElementSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncElementSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncElementSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal?, decimal?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncElementSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?, decimal?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncElementSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncElementSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncElementSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float?, float?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncElementSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?, float?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncElementSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncElementSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncElementSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float, float> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncElementSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float, float>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncElementSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncElementSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncElementSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long, long> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncElementSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long, long>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncElementSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncElementSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncElementSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int, int> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncElementSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int, int>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncElementSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncElementSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncElementSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long?, long?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncElementSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?, long?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncElementSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncElementSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncElementSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int?, int?> elementSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncElementSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?, int?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncElementSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncElementSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncElementSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncElementSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double?, double?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncElementSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double?, double?, double?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncElementSelector = (p, c) => new ValueTask<double?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncElementSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncElementSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<double, double> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncElementSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<double, double, double>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncElementSelector = (p, c) => new ValueTask<double>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncElementSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncElementSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal, decimal> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncElementSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal, decimal, decimal>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncElementSelector = (p, c) => new ValueTask<decimal>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncElementSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncElementSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<decimal?, decimal?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncElementSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<decimal?, decimal?, decimal?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncElementSelector = (p, c) => new ValueTask<decimal?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncElementSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncElementSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float?, float?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncElementSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float?, float?, float?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncElementSelector = (p, c) => new ValueTask<float?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncElementSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncElementSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<float, float> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncElementSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<float, float, float>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncElementSelector = (p, c) => new ValueTask<float>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncElementSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncElementSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long, long> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncElementSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long, long, long>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncElementSelector = (p, c) => new ValueTask<long>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncElementSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncElementSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int, int> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncElementSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int, int, int>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncElementSelector = (p, c) => new ValueTask<int>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncElementSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncElementSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<long?, long?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncElementSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<long?, long?, long?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncElementSelector = (p, c) => new ValueTask<long?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncElementSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncElementSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToDictionaryTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'elementSelector' parameter
            Func<int?, int?> elementSelector = (p) => p + 3;

            // Arrange 'comparer' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncElementSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToDictionary<int?, int?, int?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncElementSelector = (p, c) => new ValueTask<int?>(p + 3);

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
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncElementSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncElementSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToDictionaryAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'asyncElementSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncElementSelector = null!;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.ToDictionaryAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion
    }
}
