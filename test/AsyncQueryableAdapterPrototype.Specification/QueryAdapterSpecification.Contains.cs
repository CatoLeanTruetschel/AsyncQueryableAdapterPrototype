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
        public async Task WhereContainsNullValueThrowsArgumentNullExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await personQueryable.Where(p => p.Age > 29).ContainsAsync(null);
            });
        }

        [Fact]
        public async Task WhereContainsContainedValueTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var value = _personEntries.First(p => p.Age > 29);
            var comparison = _personEntries.Where(p => p.Age > 29).Contains(value);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 29).ContainsAsync(value);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task WhereContainsNonContainedValueTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var value = _personEntries.First(p => p.Age <= 29);
            var comparison = _personEntries.Where(p => p.Age > 29).Contains(value);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 29).ContainsAsync(value);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task WhereContainsWithEqualityComparerNullValueThrowsArgumentNullExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var equalityComparer = new PersonEntryByLastNameEqualityComparer();
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await personQueryable.Where(p => p.Age > 29).ContainsAsync(null, equalityComparer);
            });
        }

        [Fact]
        public async Task WhereContainsWithEqualityComparerContainedValueTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var equalityComparer = new PersonEntryByLastNameEqualityComparer();
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var value = _personEntries.First(p => p.Age > 29);
            var comparison = _personEntries.Where(p => p.Age > 29).Contains(value, equalityComparer);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 29).ContainsAsync(value, equalityComparer);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task WhereContainsWithEqualityComparerNonContainedValueTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var equalityComparer = new PersonEntryByLastNameEqualityComparer();
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var value = _personEntries.First(p => p.Age <= 29);
            var comparison = _personEntries.Where(p => p.Age > 29).Contains(value, equalityComparer);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 29).ContainsAsync(value, equalityComparer);

            // Assert
            Assert.Equal(comparison, queryResult);
        }
    }
}
