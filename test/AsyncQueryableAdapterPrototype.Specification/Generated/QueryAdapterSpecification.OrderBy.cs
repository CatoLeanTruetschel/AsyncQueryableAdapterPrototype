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

        #region OrderByWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderBy<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByWithDoubleSourceWithDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderBy<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByWithDecimalSourceWithDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderBy<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderBy<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderBy<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task OrderByWithSingleSourceWithSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderBy<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task OrderByWithInt64SourceWithInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderBy<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task OrderByWithInt32SourceWithInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderBy<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderBy<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderBy<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderBy<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, double?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderBy<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, double>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderBy<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, decimal>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderBy<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, decimal?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderBy<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, float?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task OrderByWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderBy<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, float>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task OrderByWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderBy<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, long>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task OrderByWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderBy<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, int>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderBy<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, long?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderBy<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = (p) => p + 3;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, int?>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderBy<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwait<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithDoubleSourceWithDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwait<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithDecimalSourceWithDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwait<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwait<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwait<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithSingleSourceWithSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwait<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithInt64SourceWithInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwait<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithInt32SourceWithInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwait<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwait<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwait<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwait<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = (p) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwait<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = (p) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwait<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = (p) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwait<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = (p) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwait<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = (p) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwait<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = (p) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwait<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = (p) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwait<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = (p) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwait<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = (p) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwait<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = (p) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwait<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double?, double?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDoubleSourceWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithDoubleSourceWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDoubleSourceWithDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double, double>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDoubleSourceWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDoubleSourceWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithDecimalSourceWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDecimalSourceWithDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal, decimal>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDecimalSourceWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDecimalSourceWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal?, decimal?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDecimalSourceWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithNullableSingleSourceWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableSingleSourceWithNullableSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float?, float?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableSingleSourceWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableSingleSourceWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithSingleSourceWithSingleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithSingleSourceWithSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float, float>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithSingleSourceWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithSingleSourceWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithInt64SourceWithInt64KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt64SourceWithInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long, long>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt64SourceWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt64SourceWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithInt32SourceWithInt32KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt32SourceWithInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int, int>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt32SourceWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt32SourceWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithNullableInt64SourceWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt64SourceWithNullableInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long?, long?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt64SourceWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt64SourceWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithNullableInt32SourceWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt32SourceWithNullableInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int?, int?>(source, keySelector);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt32SourceWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt32SourceWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = null!;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double?, double?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = (p, c) => new ValueTask<double?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDoubleSourceWithComparerWithNullableDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double?, CancellationToken, ValueTask<double?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<double?, double?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithDoubleSourceWithComparerWithDoubleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDoubleSourceWithComparerWithDoubleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<double, double>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDoubleSourceWithComparerWithDoubleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<double> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = (p, c) => new ValueTask<double>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDoubleSourceWithComparerWithDoubleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<double>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<double, CancellationToken, ValueTask<double>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<double>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<double, double>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithDecimalSourceWithComparerWithDecimalKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDecimalSourceWithComparerWithDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal, decimal>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDecimalSourceWithComparerWithDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = (p, c) => new ValueTask<decimal>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithDecimalSourceWithComparerWithDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal, CancellationToken, ValueTask<decimal>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<decimal, decimal>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<decimal?, decimal?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<decimal?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = (p, c) => new ValueTask<decimal?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableDecimalSourceWithComparerWithNullableDecimalKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<decimal?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<decimal?, CancellationToken, ValueTask<decimal?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<decimal?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<decimal?, decimal?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithNullableSingleSourceWithComparerWithNullableSingleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float?, float?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = (p, c) => new ValueTask<float?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableSingleSourceWithComparerWithNullableSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float?, CancellationToken, ValueTask<float?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<float?, float?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithSingleSourceWithComparerWithSingleKeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithSingleSourceWithComparerWithSingleKeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<float, float>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithSingleSourceWithComparerWithSingleKeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<float> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = (p, c) => new ValueTask<float>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithSingleSourceWithComparerWithSingleKeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<float>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<float, CancellationToken, ValueTask<float>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<float>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<float, float>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithInt64SourceWithComparerWithInt64KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt64SourceWithComparerWithInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long, long>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt64SourceWithComparerWithInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = (p, c) => new ValueTask<long>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt64SourceWithComparerWithInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long, CancellationToken, ValueTask<long>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<long, long>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithInt32SourceWithComparerWithInt32KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt32SourceWithComparerWithInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int, int>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt32SourceWithComparerWithInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = (p, c) => new ValueTask<int>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithInt32SourceWithComparerWithInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int, CancellationToken, ValueTask<int>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<int, int>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithNullableInt64SourceWithComparerWithNullableInt64KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<long?, long?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<long?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = (p, c) => new ValueTask<long?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt64SourceWithComparerWithNullableInt64KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<long?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<long?, CancellationToken, ValueTask<long?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<long?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<long?, long?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion

        #region OrderByAwaitWithCancellationWithNullableInt32SourceWithComparerWithNullableInt32KeySelector tests

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorIsEquivalentToOrderByTest()
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

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Arrange 'expectedResult' parameter
            var expectedResult = Enumerable.OrderBy<int?, int?>(source, keySelector, comparer);

            // Act
            var result = await AsyncQueryable.OrderByAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullSourceThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            IAsyncQueryable<int?> asyncSource = null!;

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = (p, c) => new ValueTask<int?>(p + 3);

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }

        [Fact]
        public async Task OrderByAwaitWithCancellationWithNullableInt32SourceWithComparerWithNullableInt32KeySelectorNullKeySelectorThrowsArgumentNullExceptionTest()
        {
            // Arrange

            // Arrange 'queryAdapter' parameter
            var queryAdapter = await GetQueryAdapterAsync();

            // Arrange 'asyncSource' parameter
            var asyncSource = queryAdapter.GetAsyncQueryable<int?>();

            // Arrange 'asyncKeySelector' parameter
            Expression<Func<int?, CancellationToken, ValueTask<int?>>> asyncKeySelector = null!;

            // Arrange 'comparer' parameter
            var comparer = Comparer<int?>.Default;

            // Act
            // -

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await AsyncQueryable.OrderByAwaitWithCancellation<int?, int?>(asyncSource, asyncKeySelector, comparer).ToListAsync().ConfigureAwait(false);
            });
        }
        #endregion
    }
}
