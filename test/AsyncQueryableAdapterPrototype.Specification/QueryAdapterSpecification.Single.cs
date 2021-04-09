using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AsyncQueryableAdapterPrototype.Tests
{
    partial class QueryAdapterSpecification
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
