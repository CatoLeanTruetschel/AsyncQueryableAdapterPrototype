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

        #region OfTypeWithNullableDoubleResult tests

        [Fact]
        public async Task OfTypeWithNullableDoubleResultIsEquivalentToOfTypeTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var sourcePart1 = GetQueryable<double?>().Select(p => (object)p);
            var sourcePart2 = GetQueryable<double>().Select(p => (object)p);
            var sourcePart3 = GetQueryable<decimal>().Select(p => (object)p);
            var sourcePart4 = GetQueryable<decimal?>().Select(p => (object)p);
            var sourcePart5 = GetQueryable<float?>().Select(p => (object)p);
            var sourcePart6 = GetQueryable<float>().Select(p => (object)p);
            var sourcePart7 = GetQueryable<long>().Select(p => (object)p);
            var sourcePart8 = GetQueryable<int>().Select(p => (object)p);
            var sourcePart9 = GetQueryable<long?>().Select(p => (object)p);
            var sourcePart10 = GetQueryable<int?>().Select(p => (object)p);
            var source = sourcePart1.Concat(sourcePart2).Concat(sourcePart3).Concat(sourcePart4).Concat(sourcePart5).Concat(sourcePart6).Concat(sourcePart7).Concat(sourcePart8).Concat(sourcePart9).Concat(sourcePart10);

            // Arrange 'asyncSource' parameter
            var asyncSourcePart1 = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);
            var asyncSourcePart2 = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);
            var asyncSourcePart3 = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);
            var asyncSourcePart4 = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);
            var asyncSourcePart5 = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);
            var asyncSourcePart6 = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);
            var asyncSourcePart7 = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);
            var asyncSourcePart8 = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);
            var asyncSourcePart9 = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);
            var asyncSourcePart10 = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);
            var asyncSource = asyncSourcePart1.Concat(asyncSourcePart2).Concat(asyncSourcePart3).Concat(asyncSourcePart4).Concat(asyncSourcePart5).Concat(asyncSourcePart6).Concat(asyncSourcePart7).Concat(asyncSourcePart8).Concat(asyncSourcePart9).Concat(asyncSourcePart10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OfType<double?>(source);

            // Act
            var result = await AsyncQueryable.OfType<double?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OfTypeWithNullableDoubleResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OfType<double?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OfTypeWithDoubleResult tests

        [Fact]
        public async Task OfTypeWithDoubleResultIsEquivalentToOfTypeTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var sourcePart1 = GetQueryable<double?>().Select(p => (object)p);
            var sourcePart2 = GetQueryable<double>().Select(p => (object)p);
            var sourcePart3 = GetQueryable<decimal>().Select(p => (object)p);
            var sourcePart4 = GetQueryable<decimal?>().Select(p => (object)p);
            var sourcePart5 = GetQueryable<float?>().Select(p => (object)p);
            var sourcePart6 = GetQueryable<float>().Select(p => (object)p);
            var sourcePart7 = GetQueryable<long>().Select(p => (object)p);
            var sourcePart8 = GetQueryable<int>().Select(p => (object)p);
            var sourcePart9 = GetQueryable<long?>().Select(p => (object)p);
            var sourcePart10 = GetQueryable<int?>().Select(p => (object)p);
            var source = sourcePart1.Concat(sourcePart2).Concat(sourcePart3).Concat(sourcePart4).Concat(sourcePart5).Concat(sourcePart6).Concat(sourcePart7).Concat(sourcePart8).Concat(sourcePart9).Concat(sourcePart10);

            // Arrange 'asyncSource' parameter
            var asyncSourcePart1 = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);
            var asyncSourcePart2 = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);
            var asyncSourcePart3 = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);
            var asyncSourcePart4 = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);
            var asyncSourcePart5 = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);
            var asyncSourcePart6 = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);
            var asyncSourcePart7 = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);
            var asyncSourcePart8 = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);
            var asyncSourcePart9 = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);
            var asyncSourcePart10 = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);
            var asyncSource = asyncSourcePart1.Concat(asyncSourcePart2).Concat(asyncSourcePart3).Concat(asyncSourcePart4).Concat(asyncSourcePart5).Concat(asyncSourcePart6).Concat(asyncSourcePart7).Concat(asyncSourcePart8).Concat(asyncSourcePart9).Concat(asyncSourcePart10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OfType<double>(source);

            // Act
            var result = await AsyncQueryable.OfType<double>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OfTypeWithDoubleResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OfType<double>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OfTypeWithDecimalResult tests

        [Fact]
        public async Task OfTypeWithDecimalResultIsEquivalentToOfTypeTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var sourcePart1 = GetQueryable<double?>().Select(p => (object)p);
            var sourcePart2 = GetQueryable<double>().Select(p => (object)p);
            var sourcePart3 = GetQueryable<decimal>().Select(p => (object)p);
            var sourcePart4 = GetQueryable<decimal?>().Select(p => (object)p);
            var sourcePart5 = GetQueryable<float?>().Select(p => (object)p);
            var sourcePart6 = GetQueryable<float>().Select(p => (object)p);
            var sourcePart7 = GetQueryable<long>().Select(p => (object)p);
            var sourcePart8 = GetQueryable<int>().Select(p => (object)p);
            var sourcePart9 = GetQueryable<long?>().Select(p => (object)p);
            var sourcePart10 = GetQueryable<int?>().Select(p => (object)p);
            var source = sourcePart1.Concat(sourcePart2).Concat(sourcePart3).Concat(sourcePart4).Concat(sourcePart5).Concat(sourcePart6).Concat(sourcePart7).Concat(sourcePart8).Concat(sourcePart9).Concat(sourcePart10);

            // Arrange 'asyncSource' parameter
            var asyncSourcePart1 = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);
            var asyncSourcePart2 = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);
            var asyncSourcePart3 = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);
            var asyncSourcePart4 = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);
            var asyncSourcePart5 = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);
            var asyncSourcePart6 = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);
            var asyncSourcePart7 = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);
            var asyncSourcePart8 = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);
            var asyncSourcePart9 = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);
            var asyncSourcePart10 = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);
            var asyncSource = asyncSourcePart1.Concat(asyncSourcePart2).Concat(asyncSourcePart3).Concat(asyncSourcePart4).Concat(asyncSourcePart5).Concat(asyncSourcePart6).Concat(asyncSourcePart7).Concat(asyncSourcePart8).Concat(asyncSourcePart9).Concat(asyncSourcePart10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OfType<decimal>(source);

            // Act
            var result = await AsyncQueryable.OfType<decimal>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OfTypeWithDecimalResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OfType<decimal>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OfTypeWithNullableDecimalResult tests

        [Fact]
        public async Task OfTypeWithNullableDecimalResultIsEquivalentToOfTypeTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var sourcePart1 = GetQueryable<double?>().Select(p => (object)p);
            var sourcePart2 = GetQueryable<double>().Select(p => (object)p);
            var sourcePart3 = GetQueryable<decimal>().Select(p => (object)p);
            var sourcePart4 = GetQueryable<decimal?>().Select(p => (object)p);
            var sourcePart5 = GetQueryable<float?>().Select(p => (object)p);
            var sourcePart6 = GetQueryable<float>().Select(p => (object)p);
            var sourcePart7 = GetQueryable<long>().Select(p => (object)p);
            var sourcePart8 = GetQueryable<int>().Select(p => (object)p);
            var sourcePart9 = GetQueryable<long?>().Select(p => (object)p);
            var sourcePart10 = GetQueryable<int?>().Select(p => (object)p);
            var source = sourcePart1.Concat(sourcePart2).Concat(sourcePart3).Concat(sourcePart4).Concat(sourcePart5).Concat(sourcePart6).Concat(sourcePart7).Concat(sourcePart8).Concat(sourcePart9).Concat(sourcePart10);

            // Arrange 'asyncSource' parameter
            var asyncSourcePart1 = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);
            var asyncSourcePart2 = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);
            var asyncSourcePart3 = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);
            var asyncSourcePart4 = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);
            var asyncSourcePart5 = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);
            var asyncSourcePart6 = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);
            var asyncSourcePart7 = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);
            var asyncSourcePart8 = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);
            var asyncSourcePart9 = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);
            var asyncSourcePart10 = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);
            var asyncSource = asyncSourcePart1.Concat(asyncSourcePart2).Concat(asyncSourcePart3).Concat(asyncSourcePart4).Concat(asyncSourcePart5).Concat(asyncSourcePart6).Concat(asyncSourcePart7).Concat(asyncSourcePart8).Concat(asyncSourcePart9).Concat(asyncSourcePart10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OfType<decimal?>(source);

            // Act
            var result = await AsyncQueryable.OfType<decimal?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OfTypeWithNullableDecimalResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OfType<decimal?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OfTypeWithNullableSingleResult tests

        [Fact]
        public async Task OfTypeWithNullableSingleResultIsEquivalentToOfTypeTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var sourcePart1 = GetQueryable<double?>().Select(p => (object)p);
            var sourcePart2 = GetQueryable<double>().Select(p => (object)p);
            var sourcePart3 = GetQueryable<decimal>().Select(p => (object)p);
            var sourcePart4 = GetQueryable<decimal?>().Select(p => (object)p);
            var sourcePart5 = GetQueryable<float?>().Select(p => (object)p);
            var sourcePart6 = GetQueryable<float>().Select(p => (object)p);
            var sourcePart7 = GetQueryable<long>().Select(p => (object)p);
            var sourcePart8 = GetQueryable<int>().Select(p => (object)p);
            var sourcePart9 = GetQueryable<long?>().Select(p => (object)p);
            var sourcePart10 = GetQueryable<int?>().Select(p => (object)p);
            var source = sourcePart1.Concat(sourcePart2).Concat(sourcePart3).Concat(sourcePart4).Concat(sourcePart5).Concat(sourcePart6).Concat(sourcePart7).Concat(sourcePart8).Concat(sourcePart9).Concat(sourcePart10);

            // Arrange 'asyncSource' parameter
            var asyncSourcePart1 = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);
            var asyncSourcePart2 = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);
            var asyncSourcePart3 = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);
            var asyncSourcePart4 = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);
            var asyncSourcePart5 = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);
            var asyncSourcePart6 = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);
            var asyncSourcePart7 = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);
            var asyncSourcePart8 = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);
            var asyncSourcePart9 = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);
            var asyncSourcePart10 = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);
            var asyncSource = asyncSourcePart1.Concat(asyncSourcePart2).Concat(asyncSourcePart3).Concat(asyncSourcePart4).Concat(asyncSourcePart5).Concat(asyncSourcePart6).Concat(asyncSourcePart7).Concat(asyncSourcePart8).Concat(asyncSourcePart9).Concat(asyncSourcePart10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OfType<float?>(source);

            // Act
            var result = await AsyncQueryable.OfType<float?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OfTypeWithNullableSingleResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OfType<float?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OfTypeWithSingleResult tests

        [Fact]
        public async Task OfTypeWithSingleResultIsEquivalentToOfTypeTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var sourcePart1 = GetQueryable<double?>().Select(p => (object)p);
            var sourcePart2 = GetQueryable<double>().Select(p => (object)p);
            var sourcePart3 = GetQueryable<decimal>().Select(p => (object)p);
            var sourcePart4 = GetQueryable<decimal?>().Select(p => (object)p);
            var sourcePart5 = GetQueryable<float?>().Select(p => (object)p);
            var sourcePart6 = GetQueryable<float>().Select(p => (object)p);
            var sourcePart7 = GetQueryable<long>().Select(p => (object)p);
            var sourcePart8 = GetQueryable<int>().Select(p => (object)p);
            var sourcePart9 = GetQueryable<long?>().Select(p => (object)p);
            var sourcePart10 = GetQueryable<int?>().Select(p => (object)p);
            var source = sourcePart1.Concat(sourcePart2).Concat(sourcePart3).Concat(sourcePart4).Concat(sourcePart5).Concat(sourcePart6).Concat(sourcePart7).Concat(sourcePart8).Concat(sourcePart9).Concat(sourcePart10);

            // Arrange 'asyncSource' parameter
            var asyncSourcePart1 = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);
            var asyncSourcePart2 = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);
            var asyncSourcePart3 = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);
            var asyncSourcePart4 = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);
            var asyncSourcePart5 = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);
            var asyncSourcePart6 = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);
            var asyncSourcePart7 = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);
            var asyncSourcePart8 = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);
            var asyncSourcePart9 = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);
            var asyncSourcePart10 = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);
            var asyncSource = asyncSourcePart1.Concat(asyncSourcePart2).Concat(asyncSourcePart3).Concat(asyncSourcePart4).Concat(asyncSourcePart5).Concat(asyncSourcePart6).Concat(asyncSourcePart7).Concat(asyncSourcePart8).Concat(asyncSourcePart9).Concat(asyncSourcePart10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OfType<float>(source);

            // Act
            var result = await AsyncQueryable.OfType<float>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OfTypeWithSingleResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OfType<float>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OfTypeWithInt64Result tests

        [Fact]
        public async Task OfTypeWithInt64ResultIsEquivalentToOfTypeTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var sourcePart1 = GetQueryable<double?>().Select(p => (object)p);
            var sourcePart2 = GetQueryable<double>().Select(p => (object)p);
            var sourcePart3 = GetQueryable<decimal>().Select(p => (object)p);
            var sourcePart4 = GetQueryable<decimal?>().Select(p => (object)p);
            var sourcePart5 = GetQueryable<float?>().Select(p => (object)p);
            var sourcePart6 = GetQueryable<float>().Select(p => (object)p);
            var sourcePart7 = GetQueryable<long>().Select(p => (object)p);
            var sourcePart8 = GetQueryable<int>().Select(p => (object)p);
            var sourcePart9 = GetQueryable<long?>().Select(p => (object)p);
            var sourcePart10 = GetQueryable<int?>().Select(p => (object)p);
            var source = sourcePart1.Concat(sourcePart2).Concat(sourcePart3).Concat(sourcePart4).Concat(sourcePart5).Concat(sourcePart6).Concat(sourcePart7).Concat(sourcePart8).Concat(sourcePart9).Concat(sourcePart10);

            // Arrange 'asyncSource' parameter
            var asyncSourcePart1 = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);
            var asyncSourcePart2 = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);
            var asyncSourcePart3 = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);
            var asyncSourcePart4 = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);
            var asyncSourcePart5 = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);
            var asyncSourcePart6 = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);
            var asyncSourcePart7 = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);
            var asyncSourcePart8 = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);
            var asyncSourcePart9 = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);
            var asyncSourcePart10 = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);
            var asyncSource = asyncSourcePart1.Concat(asyncSourcePart2).Concat(asyncSourcePart3).Concat(asyncSourcePart4).Concat(asyncSourcePart5).Concat(asyncSourcePart6).Concat(asyncSourcePart7).Concat(asyncSourcePart8).Concat(asyncSourcePart9).Concat(asyncSourcePart10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OfType<long>(source);

            // Act
            var result = await AsyncQueryable.OfType<long>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OfTypeWithInt64ResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OfType<long>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OfTypeWithInt32Result tests

        [Fact]
        public async Task OfTypeWithInt32ResultIsEquivalentToOfTypeTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var sourcePart1 = GetQueryable<double?>().Select(p => (object)p);
            var sourcePart2 = GetQueryable<double>().Select(p => (object)p);
            var sourcePart3 = GetQueryable<decimal>().Select(p => (object)p);
            var sourcePart4 = GetQueryable<decimal?>().Select(p => (object)p);
            var sourcePart5 = GetQueryable<float?>().Select(p => (object)p);
            var sourcePart6 = GetQueryable<float>().Select(p => (object)p);
            var sourcePart7 = GetQueryable<long>().Select(p => (object)p);
            var sourcePart8 = GetQueryable<int>().Select(p => (object)p);
            var sourcePart9 = GetQueryable<long?>().Select(p => (object)p);
            var sourcePart10 = GetQueryable<int?>().Select(p => (object)p);
            var source = sourcePart1.Concat(sourcePart2).Concat(sourcePart3).Concat(sourcePart4).Concat(sourcePart5).Concat(sourcePart6).Concat(sourcePart7).Concat(sourcePart8).Concat(sourcePart9).Concat(sourcePart10);

            // Arrange 'asyncSource' parameter
            var asyncSourcePart1 = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);
            var asyncSourcePart2 = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);
            var asyncSourcePart3 = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);
            var asyncSourcePart4 = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);
            var asyncSourcePart5 = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);
            var asyncSourcePart6 = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);
            var asyncSourcePart7 = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);
            var asyncSourcePart8 = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);
            var asyncSourcePart9 = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);
            var asyncSourcePart10 = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);
            var asyncSource = asyncSourcePart1.Concat(asyncSourcePart2).Concat(asyncSourcePart3).Concat(asyncSourcePart4).Concat(asyncSourcePart5).Concat(asyncSourcePart6).Concat(asyncSourcePart7).Concat(asyncSourcePart8).Concat(asyncSourcePart9).Concat(asyncSourcePart10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OfType<int>(source);

            // Act
            var result = await AsyncQueryable.OfType<int>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OfTypeWithInt32ResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OfType<int>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OfTypeWithNullableInt64Result tests

        [Fact]
        public async Task OfTypeWithNullableInt64ResultIsEquivalentToOfTypeTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var sourcePart1 = GetQueryable<double?>().Select(p => (object)p);
            var sourcePart2 = GetQueryable<double>().Select(p => (object)p);
            var sourcePart3 = GetQueryable<decimal>().Select(p => (object)p);
            var sourcePart4 = GetQueryable<decimal?>().Select(p => (object)p);
            var sourcePart5 = GetQueryable<float?>().Select(p => (object)p);
            var sourcePart6 = GetQueryable<float>().Select(p => (object)p);
            var sourcePart7 = GetQueryable<long>().Select(p => (object)p);
            var sourcePart8 = GetQueryable<int>().Select(p => (object)p);
            var sourcePart9 = GetQueryable<long?>().Select(p => (object)p);
            var sourcePart10 = GetQueryable<int?>().Select(p => (object)p);
            var source = sourcePart1.Concat(sourcePart2).Concat(sourcePart3).Concat(sourcePart4).Concat(sourcePart5).Concat(sourcePart6).Concat(sourcePart7).Concat(sourcePart8).Concat(sourcePart9).Concat(sourcePart10);

            // Arrange 'asyncSource' parameter
            var asyncSourcePart1 = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);
            var asyncSourcePart2 = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);
            var asyncSourcePart3 = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);
            var asyncSourcePart4 = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);
            var asyncSourcePart5 = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);
            var asyncSourcePart6 = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);
            var asyncSourcePart7 = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);
            var asyncSourcePart8 = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);
            var asyncSourcePart9 = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);
            var asyncSourcePart10 = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);
            var asyncSource = asyncSourcePart1.Concat(asyncSourcePart2).Concat(asyncSourcePart3).Concat(asyncSourcePart4).Concat(asyncSourcePart5).Concat(asyncSourcePart6).Concat(asyncSourcePart7).Concat(asyncSourcePart8).Concat(asyncSourcePart9).Concat(asyncSourcePart10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OfType<long?>(source);

            // Act
            var result = await AsyncQueryable.OfType<long?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OfTypeWithNullableInt64ResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OfType<long?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OfTypeWithNullableInt32Result tests

        [Fact]
        public async Task OfTypeWithNullableInt32ResultIsEquivalentToOfTypeTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'source' parameter
            var sourcePart1 = GetQueryable<double?>().Select(p => (object)p);
            var sourcePart2 = GetQueryable<double>().Select(p => (object)p);
            var sourcePart3 = GetQueryable<decimal>().Select(p => (object)p);
            var sourcePart4 = GetQueryable<decimal?>().Select(p => (object)p);
            var sourcePart5 = GetQueryable<float?>().Select(p => (object)p);
            var sourcePart6 = GetQueryable<float>().Select(p => (object)p);
            var sourcePart7 = GetQueryable<long>().Select(p => (object)p);
            var sourcePart8 = GetQueryable<int>().Select(p => (object)p);
            var sourcePart9 = GetQueryable<long?>().Select(p => (object)p);
            var sourcePart10 = GetQueryable<int?>().Select(p => (object)p);
            var source = sourcePart1.Concat(sourcePart2).Concat(sourcePart3).Concat(sourcePart4).Concat(sourcePart5).Concat(sourcePart6).Concat(sourcePart7).Concat(sourcePart8).Concat(sourcePart9).Concat(sourcePart10);

            // Arrange 'asyncSource' parameter
            var asyncSourcePart1 = queryAdapter.GetAsyncQueryable<double?>().Select(p => (object)p);
            var asyncSourcePart2 = queryAdapter.GetAsyncQueryable<double>().Select(p => (object)p);
            var asyncSourcePart3 = queryAdapter.GetAsyncQueryable<decimal>().Select(p => (object)p);
            var asyncSourcePart4 = queryAdapter.GetAsyncQueryable<decimal?>().Select(p => (object)p);
            var asyncSourcePart5 = queryAdapter.GetAsyncQueryable<float?>().Select(p => (object)p);
            var asyncSourcePart6 = queryAdapter.GetAsyncQueryable<float>().Select(p => (object)p);
            var asyncSourcePart7 = queryAdapter.GetAsyncQueryable<long>().Select(p => (object)p);
            var asyncSourcePart8 = queryAdapter.GetAsyncQueryable<int>().Select(p => (object)p);
            var asyncSourcePart9 = queryAdapter.GetAsyncQueryable<long?>().Select(p => (object)p);
            var asyncSourcePart10 = queryAdapter.GetAsyncQueryable<int?>().Select(p => (object)p);
            var asyncSource = asyncSourcePart1.Concat(asyncSourcePart2).Concat(asyncSourcePart3).Concat(asyncSourcePart4).Concat(asyncSourcePart5).Concat(asyncSourcePart6).Concat(asyncSourcePart7).Concat(asyncSourcePart8).Concat(asyncSourcePart9).Concat(asyncSourcePart10);

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OfType<int?>(source);

            // Act
            var result = await AsyncQueryable.OfType<int?>(asyncSource).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OfTypeWithNullableInt32ResultNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<object> asyncSource = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OfType<int?>(asyncSource).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
