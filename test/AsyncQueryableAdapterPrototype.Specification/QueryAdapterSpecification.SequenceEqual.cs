using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AsyncQueryableAdapterPrototype.Tests
{
    partial class QueryAdapterSpecification
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
