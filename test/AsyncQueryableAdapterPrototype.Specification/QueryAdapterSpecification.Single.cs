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

using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AsyncQueryableAdapterPrototype.Tests
{
    public partial class QueryAdapterSpecification
    {
        [Fact]
        public async Task WhereSingleMultipleResultThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await personQueryable.Where(p => p.Age > 21).SingleAsync();
            });
        }

        [Fact]
        public async Task WhereSingleWithSelectorMultipleResultThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await personQueryable.Where(p => p.Age > 21).SingleAsync(p => p.LastName == "Phillips");
            });
        }

        [Fact]
        public async Task WhereSingleAwaitWithSelectorMultipleResultThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await personQueryable
                .Where(p => p.Age > 21)
                .SingleAwaitAsync(p => new ValueTask<bool>(p.LastName == "Phillips"));
            });
        }

        [Fact]
        public async Task WhereSingleAwaitWithCancellationWithSelectorMultipleResultThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await personQueryable
                .Where(p => p.Age > 21)
                .SingleAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Phillips"));
            });
        }
    }
}
