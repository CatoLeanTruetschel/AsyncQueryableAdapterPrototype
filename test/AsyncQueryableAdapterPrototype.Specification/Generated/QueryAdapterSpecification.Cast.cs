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

        #region CastWithDoubleResult tests

        [Fact]
        public async Task CastWithDoubleResultIsEquivalentToCastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double>().Select(p => (object)p);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Cast<double>(source);

            // Act
            var result = await AsyncQueryable.Cast<double>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CastWithDoubleResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Cast<double>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region CastWithNullableDecimalResult tests

        [Fact]
        public async Task CastWithNullableDecimalResultIsEquivalentToCastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal?>().Select(p => (object)p);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Cast<decimal?>(source);

            // Act
            var result = await AsyncQueryable.Cast<decimal?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CastWithNullableDecimalResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Cast<decimal?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region CastWithNullableSingleResult tests

        [Fact]
        public async Task CastWithNullableSingleResultIsEquivalentToCastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float?>().Select(p => (object)p);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Cast<float?>(source);

            // Act
            var result = await AsyncQueryable.Cast<float?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CastWithNullableSingleResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Cast<float?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region CastWithNullableDoubleResult tests

        [Fact]
        public async Task CastWithNullableDoubleResultIsEquivalentToCastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<double?>().Select(p => (object)p);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Cast<double?>(source);

            // Act
            var result = await AsyncQueryable.Cast<double?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CastWithNullableDoubleResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Cast<double?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region CastWithDecimalResult tests

        [Fact]
        public async Task CastWithDecimalResultIsEquivalentToCastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<decimal>().Select(p => (object)p);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Cast<decimal>(source);

            // Act
            var result = await AsyncQueryable.Cast<decimal>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CastWithDecimalResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Cast<decimal>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region CastWithSingleResult tests

        [Fact]
        public async Task CastWithSingleResultIsEquivalentToCastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<float>().Select(p => (object)p);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Cast<float>(source);

            // Act
            var result = await AsyncQueryable.Cast<float>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CastWithSingleResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Cast<float>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region CastWithNullableInt64Result tests

        [Fact]
        public async Task CastWithNullableInt64ResultIsEquivalentToCastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long?>().Select(p => (object)p);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Cast<long?>(source);

            // Act
            var result = await AsyncQueryable.Cast<long?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CastWithNullableInt64ResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Cast<long?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region CastWithNullableInt32Result tests

        [Fact]
        public async Task CastWithNullableInt32ResultIsEquivalentToCastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int?>().Select(p => (object)p);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Cast<int?>(source);

            // Act
            var result = await AsyncQueryable.Cast<int?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CastWithNullableInt32ResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Cast<int?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region CastWithInt64Result tests

        [Fact]
        public async Task CastWithInt64ResultIsEquivalentToCastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<long>().Select(p => (object)p);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Cast<long>(source);

            // Act
            var result = await AsyncQueryable.Cast<long>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CastWithInt64ResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Cast<long>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region CastWithInt32Result tests

        [Fact]
        public async Task CastWithInt32ResultIsEquivalentToCastTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'source' parameter
            var source = GetQueryable<int>().Select(p => (object)p);

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.Cast<int>(source);

            // Act
            var result = await AsyncQueryable.Cast<int>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CastWithInt32ResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync(DisallowAll);

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.Cast<int>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
