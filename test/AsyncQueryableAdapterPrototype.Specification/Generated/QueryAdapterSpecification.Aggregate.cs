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

        #region AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulator tests

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'func' parameter
            Func<double?, double?, double?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithDoubleSourceWithDoubleAccumulator tests

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'func' parameter
            Func<double, double, double> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithDecimalSourceWithDecimalAccumulator tests

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'func' parameter
            Func<decimal, decimal, decimal> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulator tests

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'func' parameter
            Func<decimal?, decimal?, decimal?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulator tests

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'func' parameter
            Func<float?, float?, float?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithSingleSourceWithSingleAccumulator tests

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'func' parameter
            Func<float, float, float> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithInt64SourceWithInt64Accumulator tests

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'func' parameter
            Func<long, long, long> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithInt32SourceWithInt32Accumulator tests

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'func' parameter
            Func<int, int, int> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableInt64SourceWithNullableInt64Accumulator tests

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'func' parameter
            Func<long?, long?, long?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableInt32SourceWithNullableInt32Accumulator tests

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'func' parameter
            Func<int?, int?, int?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'func' parameter
            Func<double?, double?, double?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double?, double?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'func' parameter
            Func<double, double, double> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double, double>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'func' parameter
            Func<decimal, decimal, decimal> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal, decimal>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'func' parameter
            Func<decimal?, decimal?, decimal?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal?, decimal?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'func' parameter
            Func<float?, float?, float?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float?, float?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'func' parameter
            Func<float, float, float> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float, float>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithInt64SourceWithInt64AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'func' parameter
            Func<long, long, long> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long, long>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithInt32SourceWithInt32AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'func' parameter
            Func<int, int, int> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int, int>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'func' parameter
            Func<long?, long?, long?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long?, long?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'func' parameter
            Func<int?, int?, int?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int?, int?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'func' parameter
            Func<double?, double?, double?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<double?, double?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double?, double?, double?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, double?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, double?>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'func' parameter
            Func<double, double, double> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<double, double> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double, double, double>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, double>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, double>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'func' parameter
            Func<decimal, decimal, decimal> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal, decimal, decimal>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, decimal>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, decimal>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'func' parameter
            Func<decimal?, decimal?, decimal?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal?, decimal?, decimal?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, decimal?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, decimal?>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'func' parameter
            Func<float?, float?, float?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<float?, float?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float?, float?, float?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, float?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, float?>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'func' parameter
            Func<float, float, float> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<float, float> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float, float, float>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, float>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, float>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'func' parameter
            Func<long, long, long> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<long, long> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long, long, long>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, long>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, long>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'func' parameter
            Func<int, int, int> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<int, int> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int, int, int>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, int>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, int>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'func' parameter
            Func<long?, long?, long?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<long?, long?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long?, long?, long?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, long?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, long?>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'func' parameter
            Func<int?, int?, int?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<int?, int?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int?, int?, int?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?>> asyncResultSelector = (p) => p + 3;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, int?>> asyncAccumulator = (p, q) => p + 3 - q;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, int?>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulator tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'func' parameter
            Func<double?, double?, double?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulator tests

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'func' parameter
            Func<double, double, double> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulator tests

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'func' parameter
            Func<decimal, decimal, decimal> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulator tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'func' parameter
            Func<decimal?, decimal?, decimal?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulator tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'func' parameter
            Func<float?, float?, float?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithSingleSourceWithSingleAccumulator tests

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'func' parameter
            Func<float, float, float> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithInt64SourceWithInt64Accumulator tests

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'func' parameter
            Func<long, long, long> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithInt32SourceWithInt32Accumulator tests

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'func' parameter
            Func<int, int, int> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64Accumulator tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'func' parameter
            Func<long?, long?, long?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32Accumulator tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'func' parameter
            Func<int?, int?, int?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'func' parameter
            Func<double?, double?, double?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double?, double?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'func' parameter
            Func<double, double, double> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double, double>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'func' parameter
            Func<decimal, decimal, decimal> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal, decimal>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'func' parameter
            Func<decimal?, decimal?, decimal?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal?, decimal?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'func' parameter
            Func<float?, float?, float?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float?, float?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'func' parameter
            Func<float, float, float> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float, float>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'func' parameter
            Func<long, long, long> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long, long>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'func' parameter
            Func<int, int, int> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int, int>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'func' parameter
            Func<long?, long?, long?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long?, long?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'func' parameter
            Func<int?, int?, int?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int?, int?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'func' parameter
            Func<double?, double?, double?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<double?, double?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncResultSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double?, double?, double?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncResultSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncResultSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncResultSelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, ValueTask<double?>>> asyncAccumulator = (p, q) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'func' parameter
            Func<double, double, double> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<double, double> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncResultSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double, double, double>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncResultSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncResultSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncResultSelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, ValueTask<double>>> asyncAccumulator = (p, q) => new ValueTask<double>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'func' parameter
            Func<decimal, decimal, decimal> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncResultSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal, decimal, decimal>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncResultSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncResultSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncResultSelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, ValueTask<decimal>>> asyncAccumulator = (p, q) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'func' parameter
            Func<decimal?, decimal?, decimal?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncResultSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal?, decimal?, decimal?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncResultSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncResultSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncResultSelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, ValueTask<decimal?>>> asyncAccumulator = (p, q) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'func' parameter
            Func<float?, float?, float?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<float?, float?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncResultSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float?, float?, float?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncResultSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncResultSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncResultSelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, ValueTask<float?>>> asyncAccumulator = (p, q) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'func' parameter
            Func<float, float, float> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<float, float> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncResultSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float, float, float>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncResultSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncResultSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncResultSelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, ValueTask<float>>> asyncAccumulator = (p, q) => new ValueTask<float>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'func' parameter
            Func<long, long, long> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<long, long> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncResultSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long, long, long>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncResultSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncResultSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncResultSelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, ValueTask<long>>> asyncAccumulator = (p, q) => new ValueTask<long>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'func' parameter
            Func<int, int, int> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<int, int> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncResultSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int, int, int>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncResultSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncResultSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncResultSelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, ValueTask<int>>> asyncAccumulator = (p, q) => new ValueTask<int>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'func' parameter
            Func<long?, long?, long?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<long?, long?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncResultSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long?, long?, long?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncResultSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncResultSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncResultSelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, ValueTask<long?>>> asyncAccumulator = (p, q) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'func' parameter
            Func<int?, int?, int?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<int?, int?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncResultSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int?, int?, int?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncResultSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncResultSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncResultSelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, ValueTask<int?>>> asyncAccumulator = (p, q) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulator tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'func' parameter
            Func<double?, double?, double?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulator tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'func' parameter
            Func<double, double, double> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulator tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'func' parameter
            Func<decimal, decimal, decimal> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulator tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'func' parameter
            Func<decimal?, decimal?, decimal?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulator tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'func' parameter
            Func<float?, float?, float?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulator tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'func' parameter
            Func<float, float, float> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64Accumulator tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'func' parameter
            Func<long, long, long> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32Accumulator tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'func' parameter
            Func<int, int, int> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64Accumulator tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'func' parameter
            Func<long?, long?, long?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32Accumulator tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'func' parameter
            Func<int?, int?, int?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int?>(source, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?>(asyncSource, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'func' parameter
            Func<double?, double?, double?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double?, double?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?, double?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'func' parameter
            Func<double, double, double> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double, double>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double, double>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'func' parameter
            Func<decimal, decimal, decimal> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal, decimal>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal, decimal>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'func' parameter
            Func<decimal?, decimal?, decimal?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal?, decimal?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?, decimal?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'func' parameter
            Func<float?, float?, float?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float?, float?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?, float?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'func' parameter
            Func<float, float, float> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float, float>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float, float>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'func' parameter
            Func<long, long, long> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long, long>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long, long>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'func' parameter
            Func<int, int, int> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int, int>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int, int>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'func' parameter
            Func<long?, long?, long?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long?, long?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?, long?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'func' parameter
            Func<int?, int?, int?> func = (p, q) => p + 3 - q;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int?, int?>(source, seed, func);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?, int?>(asyncSource, seed, asyncAccumulator, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'func' parameter
            Func<double?, double?, double?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<double?, double?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double?, double?, double?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDoubleSourceWithNullableDoubleAccumulatorWithNullableDoubleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double?, double?, CancellationToken, ValueTask<double?>>> asyncAccumulator = (p, q, c) => new ValueTask<double?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double?, double?, double?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'func' parameter
            Func<double, double, double> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<double, double> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<double, double, double>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncResultSelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDoubleSourceWithDoubleAccumulatorWithDoubleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<double, double, CancellationToken, ValueTask<double>>> asyncAccumulator = (p, q, c) => new ValueTask<double>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<double, double, double>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'func' parameter
            Func<decimal, decimal, decimal> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<decimal, decimal> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal, decimal, decimal>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithDecimalSourceWithDecimalAccumulatorWithDecimalResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal, decimal, CancellationToken, ValueTask<decimal>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal, decimal, decimal>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'func' parameter
            Func<decimal?, decimal?, decimal?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<decimal?, decimal?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<decimal?, decimal?, decimal?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableDecimalSourceWithNullableDecimalAccumulatorWithNullableDecimalResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<decimal?, decimal?, CancellationToken, ValueTask<decimal?>>> asyncAccumulator = (p, q, c) => new ValueTask<decimal?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<decimal?, decimal?, decimal?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'func' parameter
            Func<float?, float?, float?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<float?, float?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float?, float?, float?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableSingleSourceWithNullableSingleAccumulatorWithNullableSingleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float?, float?, CancellationToken, ValueTask<float?>>> asyncAccumulator = (p, q, c) => new ValueTask<float?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float?, float?, float?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'func' parameter
            Func<float, float, float> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<float, float> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<float, float, float>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            AssertHelper.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncResultSelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithSingleSourceWithSingleAccumulatorWithSingleResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<float, float, CancellationToken, ValueTask<float>>> asyncAccumulator = (p, q, c) => new ValueTask<float>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<float, float, float>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'func' parameter
            Func<long, long, long> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<long, long> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long, long, long>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncResultSelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt64SourceWithInt64AccumulatorWithInt64ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long, long, CancellationToken, ValueTask<long>>> asyncAccumulator = (p, q, c) => new ValueTask<long>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long, long, long>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'func' parameter
            Func<int, int, int> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<int, int> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int, int, int>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncResultSelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithInt32SourceWithInt32AccumulatorWithInt32ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int, int, CancellationToken, ValueTask<int>>> asyncAccumulator = (p, q, c) => new ValueTask<int>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int, int, int>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'func' parameter
            Func<long?, long?, long?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<long?, long?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<long?, long?, long?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt64SourceWithNullableInt64AccumulatorWithNullableInt64ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<long?, long?, CancellationToken, ValueTask<long?>>> asyncAccumulator = (p, q, c) => new ValueTask<long?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<long?, long?, long?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeed tests

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedIsEquivalentToAggregateTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'func' parameter
            Func<int?, int?, int?> func = (p, q) => p + 3 - q;

            // Arrange 'resultSelector' parameter
            Func<int?, int?> resultSelector = (p) => p + 3;

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Aggregate<int?, int?, int?>(source, seed, func, resultSelector);

            // Act
            var result = await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedCanceledCancellationTokenThrowsOperationCanceledExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedNullAccumulatorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = null!;

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task AggregateAwaitWithCancellationAsyncWithNullableInt32SourceWithNullableInt32AccumulatorWithNullableInt32ResultSelectorWithSeedNullResultSelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'seed' parameter
            var seed = 5;

            // Arrange 'asyncAccumulator' parameter
            Expression<Func<int?, int?, CancellationToken, ValueTask<int?>>> asyncAccumulator = (p, q, c) => new ValueTask<int?>(p + 3 - q);

            // Arrange 'asyncResultSelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncResultSelector = null!;

            // Arrange 'cancellationToken' parameter
            var cancellationToken = CancellationToken.None;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.AggregateAwaitWithCancellationAsync<int?, int?, int?>(asyncSource, seed, asyncAccumulator, asyncResultSelector, cancellationToken).ConfigureAwait(false);
            });
        }
        #endregion
    }
}
