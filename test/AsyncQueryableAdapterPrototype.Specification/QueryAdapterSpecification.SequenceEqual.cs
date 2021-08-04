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
        public async Task WhereSequenceEqualAreEqualTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparisonSequence = _personEntries.Where(p => p.Age == 21).ToAsyncEnumerable();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).SequenceEqualAsync(comparisonSequence);

            // Assert
            Assert.True(queryResult);
        }

        [Fact]
        public async Task WhereSequenceEqualAreNotEqualTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparisonSequence = _personEntries.Where(p => p.Age != 21).ToAsyncEnumerable();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).SequenceEqualAsync(comparisonSequence);

            // Assert
            Assert.False(queryResult);
        }

        [Fact]
        public async Task WhereSequenceEqualWithEqualConditionAreEqualTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparisonSequence = personQueryable.Where(p => p.Age == 21);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).SequenceEqualAsync(comparisonSequence);

            // Assert
            Assert.True(queryResult);
        }

        [Fact]
        public async Task WhereSequenceEqualWithNullSecondArgumentThrowsArgumentNullExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await personQueryable.Where(p => p.Age == 21).SequenceEqualAsync(null);
            });
        }

        [Fact]
        public async Task WhereSequenceEqualNullComparerAreEqualTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparisonSequence = _personEntries.Where(p => p.Age == 21).ToAsyncEnumerable();

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age == 21)
                .SequenceEqualAsync(comparisonSequence, null);

            // Assert
            Assert.True(queryResult);
        }

        [Fact]
        public async Task WhereSequenceEqualNullComparerAreNotEqualTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparisonSequence = _personEntries.Where(p => p.Age != 21).ToAsyncEnumerable();

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age == 21)
                .SequenceEqualAsync(comparisonSequence, null);

            // Assert
            Assert.False(queryResult);
        }

        [Fact]
        public async Task WhereSequenceEqualNullComparerWithEqualConditionAreEqualTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparisonSequence = personQueryable.Where(p => p.Age == 21);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age == 21)
                .SequenceEqualAsync(comparisonSequence, null);

            // Assert
            Assert.True(queryResult);
        }

        [Fact]
        public async Task WhereSequenceEqualNullComparerWithNullSecondArgumentThrowsArgumentNullExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await personQueryable.Where(p => p.Age == 21).SequenceEqualAsync(null, null);
            });
        }

        [Fact]
        public async Task WhereSequenceEqualWithComparerAreEqualTest()
        {
            // Arrange
            var equalityComparer = new PersonEntryByLastNameEqualityComparer();
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparisonSequence = _personEntries.Where(p => p.Age == 21).ToAsyncEnumerable();

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age == 21)
                .SequenceEqualAsync(comparisonSequence, equalityComparer);

            // Assert
            Assert.True(queryResult);
        }

        [Fact]
        public async Task WhereSequenceEqualWithComparerAreNotEqualTest()
        {
            // Arrange
            var equalityComparer = new PersonEntryByLastNameEqualityComparer();
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparisonSequence = _personEntries.Where(p => p.Age != 21).ToAsyncEnumerable();

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age == 21)
                .SequenceEqualAsync(comparisonSequence, equalityComparer);

            // Assert
            Assert.False(queryResult);
        }

        [Fact]
        public async Task WhereSequenceEqualWithComparerWithEqualConditionAreEqualTest()
        {
            // Arrange
            var equalityComparer = new PersonEntryByLastNameEqualityComparer();
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparisonSequence = personQueryable.Where(p => p.Age == 21);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age == 21)
                .SequenceEqualAsync(comparisonSequence, equalityComparer);

            // Assert
            Assert.True(queryResult);
        }

        [Fact]
        public async Task WhereSequenceEqualWithComparerWithNullSecondArgumentThrowsArgumentNullExceptionTest()
        {
            // Arrange
            var equalityComparer = new PersonEntryByLastNameEqualityComparer();
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await personQueryable.Where(p => p.Age == 21).SequenceEqualAsync(null, equalityComparer);
            });
        }
    }
}
