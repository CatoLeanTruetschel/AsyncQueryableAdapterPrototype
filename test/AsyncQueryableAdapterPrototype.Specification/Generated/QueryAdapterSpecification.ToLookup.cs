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

        #region ToLookupAsyncWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithComparerWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithComparerWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithComparerWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double, double, double>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?, decimal?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float?, float?, float?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double?, double?, double?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal, decimal, decimal>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float, float, float>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long?, long?, long?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int?, int?, int?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long, long, long>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int, int, int>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double, double, double>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?, decimal?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float?, float?, float?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double?, double?, double?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal, decimal, decimal>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float, float, float>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long?, long?, long?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int?, int?, int?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long, long, long>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int, int, int>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double, double, double>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?, decimal?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float?, float?, float?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double?, double?, double?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal, decimal, decimal>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float, float, float>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long?, long?, long?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int?, int?, int?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long, long, long>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int, int, int>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double, double, double>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?, decimal?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float?, float?, float?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double?, double?, double?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal, decimal, decimal>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float, float, float>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long?, long?, long?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int?, int?, int?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long, long, long>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int, int, int>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'keySelector' parameter
            Func<double, double> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'keySelector' parameter
            Func<decimal?, decimal?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'keySelector' parameter
            Func<float?, float?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'keySelector' parameter
            Func<double?, double?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'keySelector' parameter
            Func<decimal, decimal> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'keySelector' parameter
            Func<float, float> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'keySelector' parameter
            Func<long?, long?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'keySelector' parameter
            Func<int?, int?> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'keySelector' parameter
            Func<long, long> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'keySelector' parameter
            Func<int, int> keySelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int>(asyncSource, asyncKeySelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double, double, double>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?, decimal?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float?, float?, float?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<double?, double?, double?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<decimal, decimal, decimal>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<float, float, float>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long?, long?, long?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int?, int?, int?>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<long, long, long>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
            var expectedResult = Enumerable.ToLookup<int, int, int>(source, keySelector, elementSelector);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double, double, double>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDoubleSourceWithComparerWithDoubleElementSelectorWithDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double, double, double>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal?, decimal?, decimal?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDecimalSourceWithComparerWithNullableDecimalElementSelectorWithNullableDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float?, float?, float?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableSingleSourceWithComparerWithNullableSingleElementSelectorWithNullableSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<double?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<double?, double?, double?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableDoubleSourceWithComparerWithNullableDoubleElementSelectorWithNullableDoubleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<decimal>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<decimal, decimal, decimal>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithDecimalSourceWithComparerWithDecimalElementSelectorWithDecimalKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<float>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<float, float, float>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithSingleSourceWithComparerWithSingleElementSelectorWithSingleKeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<float, float, float>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long?, long?, long?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt64SourceWithComparerWithNullableInt64ElementSelectorWithNullableInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int?>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int?, int?, int?>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithNullableInt32SourceWithComparerWithNullableInt32ElementSelectorWithNullableInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<long>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<long, long, long>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt64SourceWithComparerWithInt64ElementSelectorWithInt64KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<long, long, long>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelector tests

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorIsEquivalentToToLookupTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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

            // Arrange 'comparer' parameter
            var comparer = EqualityComparer<int>.Default;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.ToLookup<int, int, int>(source, keySelector, elementSelector, comparer);

            // Act
            var result = await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task ToLookupAwaitWithCancellationAsyncWithInt32SourceWithComparerWithInt32ElementSelectorWithInt32KeySelectorNullElementSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

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
                await AsyncQueryable.ToLookupAwaitWithCancellationAsync<int, int, int>(asyncSource, asyncKeySelector, asyncElementSelector, comparer, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion
    }
}
