using System;
using System.Linq;
using System.Threading.Tasks;
using AsyncQueryableAdapter;
using Xunit;

namespace AsyncQueryableAdapterPrototype.Tests
{
    partial class QueryAdapterSpecification
    {
        private AsyncQueryableOptions ElementAtOptions =>
            DisallowImplicitPostProcessing;

        [Fact]
        public async Task WhereElementAtNegativeIndexThrowsArgumentOutOfRangeExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(ElementAtOptions);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await personQueryable.Where(p => p.Age == 21).ElementAtAsync(-1);
            });
        }

        [Fact]
        public async Task WhereElementAtFoundTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(ElementAtOptions);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Where(p => p.Age == 21).ElementAt(0);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).ElementAtAsync(0);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task WhereElementAtNotFoundThrowsArgumentOutOfRangeExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(ElementAtOptions);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await personQueryable.Where(p => p.Age == 21).ElementAtAsync(100);
            });
        }

        [Fact]
        public async Task WhereElementAtOrDefaultNegativeIndexYieldsDefaultValueTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(ElementAtOptions);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).ElementAtOrDefaultAsync(-1);

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereElementAtOrDefaultFoundTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(ElementAtOptions);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Where(p => p.Age == 21).ElementAtOrDefault(0);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).ElementAtOrDefaultAsync(0);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task WhereElementAtOrDefaultNotFoundYieldsDefaultValueTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(ElementAtOptions);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).ElementAtOrDefaultAsync(100);

            // Assert
            Assert.Equal(default, queryResult);
        }
    }
}
