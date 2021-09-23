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

        #region PrependWithNullableDoubleSourceWithElement tests

        [Fact]
        public async Task PrependWithNullableDoubleSourceWithElementIsEquivalentToPrependTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double?>();

            // Arrange 'element' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Prepend<double?>(source, element);

            // Act
            var result = await AsyncQueryable.Prepend<double?>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PrependWithNullableDoubleSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Prepend<double?>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region PrependWithDoubleSourceWithElement tests

        [Fact]
        public async Task PrependWithDoubleSourceWithElementIsEquivalentToPrependTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<double>();

            // Arrange 'element' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Prepend<double>(source, element);

            // Act
            var result = await AsyncQueryable.Prepend<double>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PrependWithDoubleSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Prepend<double>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region PrependWithDecimalSourceWithElement tests

        [Fact]
        public async Task PrependWithDecimalSourceWithElementIsEquivalentToPrependTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>();

            // Arrange 'element' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Prepend<decimal>(source, element);

            // Act
            var result = await AsyncQueryable.Prepend<decimal>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PrependWithDecimalSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Prepend<decimal>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region PrependWithNullableDecimalSourceWithElement tests

        [Fact]
        public async Task PrependWithNullableDecimalSourceWithElementIsEquivalentToPrependTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>();

            // Arrange 'element' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Prepend<decimal?>(source, element);

            // Act
            var result = await AsyncQueryable.Prepend<decimal?>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PrependWithNullableDecimalSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Prepend<decimal?>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region PrependWithNullableSingleSourceWithElement tests

        [Fact]
        public async Task PrependWithNullableSingleSourceWithElementIsEquivalentToPrependTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float?>();

            // Arrange 'element' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Prepend<float?>(source, element);

            // Act
            var result = await AsyncQueryable.Prepend<float?>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PrependWithNullableSingleSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Prepend<float?>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region PrependWithSingleSourceWithElement tests

        [Fact]
        public async Task PrependWithSingleSourceWithElementIsEquivalentToPrependTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<float>();

            // Arrange 'element' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Prepend<float>(source, element);

            // Act
            var result = await AsyncQueryable.Prepend<float>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PrependWithSingleSourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Prepend<float>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region PrependWithInt64SourceWithElement tests

        [Fact]
        public async Task PrependWithInt64SourceWithElementIsEquivalentToPrependTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long>();

            // Arrange 'element' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Prepend<long>(source, element);

            // Act
            var result = await AsyncQueryable.Prepend<long>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PrependWithInt64SourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Prepend<long>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region PrependWithInt32SourceWithElement tests

        [Fact]
        public async Task PrependWithInt32SourceWithElementIsEquivalentToPrependTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int>();

            // Arrange 'element' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Prepend<int>(source, element);

            // Act
            var result = await AsyncQueryable.Prepend<int>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PrependWithInt32SourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Prepend<int>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region PrependWithNullableInt64SourceWithElement tests

        [Fact]
        public async Task PrependWithNullableInt64SourceWithElementIsEquivalentToPrependTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<long?>();

            // Arrange 'element' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Prepend<long?>(source, element);

            // Act
            var result = await AsyncQueryable.Prepend<long?>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PrependWithNullableInt64SourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Prepend<long?>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region PrependWithNullableInt32SourceWithElement tests

        [Fact]
        public async Task PrependWithNullableInt32SourceWithElementIsEquivalentToPrependTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var source = GetQueryable<int?>();

            // Arrange 'element' parameter

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'element' parameter
            var element = 5;

            // Arrange 'expectedResult' parameter
            var expectedResult =
            Enumerable
            .Prepend<int?>(source, element);

            // Act
            var result = await AsyncQueryable.Prepend<int?>(asyncSource, element).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task PrependWithNullableInt32SourceWithElementNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'element' parameter
            var element = 5;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Prepend<int?>(asyncSource, element).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
