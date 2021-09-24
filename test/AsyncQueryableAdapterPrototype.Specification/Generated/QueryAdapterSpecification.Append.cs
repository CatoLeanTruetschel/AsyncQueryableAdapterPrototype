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

        #region AppendWithDoubleSourceWithElement tests

        [Fact]
        public async Task AppendWithDoubleSourceWithElementIsEquivalentToAppendTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Append<double>(source, element);

            // Act
            var result = await AsyncQueryable.Append<double>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AppendWithDoubleSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Append<double>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region AppendWithNullableDecimalSourceWithElement tests

        [Fact]
        public async Task AppendWithNullableDecimalSourceWithElementIsEquivalentToAppendTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Append<decimal?>(source, element);

            // Act
            var result = await AsyncQueryable.Append<decimal?>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AppendWithNullableDecimalSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Append<decimal?>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region AppendWithNullableSingleSourceWithElement tests

        [Fact]
        public async Task AppendWithNullableSingleSourceWithElementIsEquivalentToAppendTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Append<float?>(source, element);

            // Act
            var result = await AsyncQueryable.Append<float?>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AppendWithNullableSingleSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Append<float?>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region AppendWithNullableDoubleSourceWithElement tests

        [Fact]
        public async Task AppendWithNullableDoubleSourceWithElementIsEquivalentToAppendTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Append<double?>(source, element);

            // Act
            var result = await AsyncQueryable.Append<double?>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AppendWithNullableDoubleSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Append<double?>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region AppendWithDecimalSourceWithElement tests

        [Fact]
        public async Task AppendWithDecimalSourceWithElementIsEquivalentToAppendTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Append<decimal>(source, element);

            // Act
            var result = await AsyncQueryable.Append<decimal>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AppendWithDecimalSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Append<decimal>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region AppendWithSingleSourceWithElement tests

        [Fact]
        public async Task AppendWithSingleSourceWithElementIsEquivalentToAppendTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Append<float>(source, element);

            // Act
            var result = await AsyncQueryable.Append<float>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AppendWithSingleSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Append<float>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region AppendWithNullableInt64SourceWithElement tests

        [Fact]
        public async Task AppendWithNullableInt64SourceWithElementIsEquivalentToAppendTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Append<long?>(source, element);

            // Act
            var result = await AsyncQueryable.Append<long?>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AppendWithNullableInt64SourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Append<long?>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region AppendWithNullableInt32SourceWithElement tests

        [Fact]
        public async Task AppendWithNullableInt32SourceWithElementIsEquivalentToAppendTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Append<int?>(source, element);

            // Act
            var result = await AsyncQueryable.Append<int?>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AppendWithNullableInt32SourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Append<int?>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region AppendWithInt64SourceWithElement tests

        [Fact]
        public async Task AppendWithInt64SourceWithElementIsEquivalentToAppendTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Append<long>(source, element);

            // Act
            var result = await AsyncQueryable.Append<long>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AppendWithInt64SourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Append<long>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region AppendWithInt32SourceWithElement tests

        [Fact]
        public async Task AppendWithInt32SourceWithElementIsEquivalentToAppendTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Append<int>(source, element);

            // Act
            var result = await AsyncQueryable.Append<int>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task AppendWithInt32SourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Append<int>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
