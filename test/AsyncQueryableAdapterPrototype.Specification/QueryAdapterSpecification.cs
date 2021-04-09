using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter;
using AsyncQueryableAdapterPrototype.Tests.Utils;
using Xunit;

namespace AsyncQueryableAdapterPrototype.Tests
{
    public abstract partial class QueryAdapterSpecification
    {
        private static readonly ImmutableList<PersonEntry> _personEntries = BuildPersonEntries();
        private static readonly ImmutableList<RelationshipEntry> _relationshipEntries = BuildRelationshipEntries();

        private static ImmutableList<PersonEntry> BuildPersonEntries()
        {
            return new[]
            {
                new PersonEntry("Christopher", "Wagner", 22),
                new PersonEntry("Juana", "Martinez", 30),
                new PersonEntry("David", "Estes", 53),
                new PersonEntry("Ash", "Sapp", 21),

                new PersonEntry("Jason", "Randolph", 46),
                new PersonEntry("Patricia", "Stone", 48),

                new PersonEntry("Julie", "Daniels", 29),
                new PersonEntry("Deborah", "Ferguson", 31),

                new PersonEntry("Lewis", "Adams", 46),
                new PersonEntry("Ronda", "Belle", 41),

                new PersonEntry("Robert", "Phillips", 36),
                new PersonEntry("Meghan", "Phillips", 34),
            }.ToImmutableList();
        }

        private static ImmutableList<RelationshipEntry> BuildRelationshipEntries()
        {
            return new[]
            {
                new RelationshipEntry(_personEntries[4], _personEntries[5]),
                new RelationshipEntry(_personEntries[6], _personEntries[7]),
                new RelationshipEntry(_personEntries[8], _personEntries[9]),
                new RelationshipEntry(_personEntries[10], _personEntries[11])
            }.ToImmutableList();
        }

        protected abstract ValueTask<QueryAdapterBase> GetQueryAdapterAsync(
            AsyncQueryableOptions options,
            Func<ISeedHelper, CancellationToken, ValueTask> seed);

        private ValueTask<QueryAdapterBase> GetQueryAdapterAsync(AsyncQueryableOptions options)
        {
            return GetQueryAdapterAsync(options, SeedAsync);
        }

        private async ValueTask SeedAsync(ISeedHelper seedHelper, CancellationToken cancellation)
        {
            foreach (var personEntry in _personEntries)
            {
                await seedHelper.AddAsync(personEntry, cancellation);
            }

            foreach (var relationshipEntry in _relationshipEntries)
            {
                await seedHelper.AddAsync(relationshipEntry, cancellation);
            }
        }

        private static readonly AsyncQueryableOptions DisallowImplicitPostProcessing = new AsyncQueryableOptions
        {
            AllowImplicitPostProcessing = false,
            AllowImplicitDefaultPostProcessing = false
        };

        private static readonly AsyncQueryableOptions AllowImplicitPostProcessing = new AsyncQueryableOptions
        {
            AllowImplicitPostProcessing = true,
            AllowImplicitDefaultPostProcessing = false
        };

        private static readonly AsyncQueryableOptions AllowImplicitDefaultPostProcessing = new AsyncQueryableOptions
        {
            AllowImplicitPostProcessing = true,
            AllowImplicitDefaultPostProcessing = true
        };

        // Tests on a single set that are fully convertible to sync queryable calls
        [Fact]
        public async Task WhereSelectTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Select(p => p.FirstName);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.FirstName);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        // TODO: Add tests

        // Tests on a single set that are not fully convertible to sync queryable calls, 
        // hence need an async in-memory post processing

        [Fact]
        public async Task WhereAwaitSelectTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Select(p => p.FirstName);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(p.Age > 42)).Select(p => p.FirstName);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSelectAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Select(p => p.FirstName);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).SelectAwait(p => CreateValueTaskAsync(p.FirstName));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        // TODO: Add tests

        // Tests on a single set that are fully convertible to sync queryable calls
        // except for the last call which results in a scalar, which is supported by the query adapter



        // TODO: Add tests

        // Tests on a single set that are fully convertible to sync queryable calls
        // except for the last call which results in a scalar, which is non-supported by the query adapter,
        // hence need an async in-memory post processing

        // TODO: Add tests

        // Tests on a single set that are not fully convertible to sync queryable calls, 
        // hence need an async in-memory post processing and a last call which results in a scalar

        // TODO: Add tests

        // TODO: Specify and add tests on multiple sets, both from the same one and from different query adapters
        // TODO: Specify and add tests that contain convertible and non-convertible inner queries.

        // Test conversion operations for convertible and non-convertible queries

        [Fact]
        public async Task WhereSelectToListTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Select(p => p.FirstName);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.FirstName).ToListAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSelectToArrayTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Select(p => p.FirstName);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.FirstName).ToArrayAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitSelectToListTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Select(p => p.FirstName);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(p.Age > 42)).Select(p => p.FirstName).ToListAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitSelectToArrayTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Select(p => p.FirstName);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(p.Age > 42)).Select(p => p.FirstName).ToListAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        // TODO: Other conversion operations like ToObservable, ToLookup, ToDictionary, etc.

        private static readonly MethodInfo CREATE_VALUE_TASK_METHOD_DEFINITION
            = new Func<object, ValueTask<object>>(CreateValueTaskAsync).Method.GetGenericMethodDefinition();

#pragma warning disable CS1998
        private static async ValueTask<T> CreateValueTaskAsync<T>(T t)
#pragma warning restore CS1998
        {
            return t;
        }

        private static Expression<Func<TSource, ValueTask<TTarget>>> BuildAsyncConstConditionalAccessExpression<TSource, TTarget>(
            Expression<Func<TSource, TTarget>> accessExpression)
        {
            // Build the expression tree by hand, because the C# compiler optimizes away conditional, based on a const
            // Build the expression: p => true ? new ValueTask<int>(p.Age) : CreateValueTaskAsync(p.Age)

            var sourceParameter = accessExpression.Parameters.First();
            var memberAccess = accessExpression.Body;

            var valueTaskCtor = typeof(ValueTask<TTarget>).GetConstructor(new[] { typeof(TTarget) });
            var valueTaskCtorCall = Expression.New(valueTaskCtor, memberAccess);

            var createValueTaskMethod = CREATE_VALUE_TASK_METHOD_DEFINITION.MakeGenericMethod(typeof(TTarget));
            var createValueTaskMethodCall = Expression.Call(createValueTaskMethod, memberAccess);

            // Build a complex expression that, when evaluated is constant
            var xExpression = Expression.Constant(5);
            var yExpression = Expression.Constant(10);
            var xYSumExpression = Expression.Add(xExpression, yExpression);
            var zExpression = Expression.Constant(15);
            var comparison = Expression.Equal(xYSumExpression, zExpression);

            var conditional = Expression.Condition(comparison, valueTaskCtorCall, createValueTaskMethodCall);
            return Expression.Lambda<Func<TSource, ValueTask<TTarget>>>(conditional, sourceParameter);
        }

        private static Expression<Func<TSource, CancellationToken, ValueTask<TTarget>>> BuildAsyncConstConditionalAccessWithCancellationExpression<TSource, TTarget>(
            Expression<Func<TSource, TTarget>> accessExpression)
        {
            // Build the expression tree by hand, because the C# compiler optimizes away conditional, based on a const
            // Build the expression: (p, c) => true ? new ValueTask<int>(p.Age) : CreateValueTaskAsync(p.Age)
            var result = BuildAsyncConstConditionalAccessExpression(accessExpression);

            var sourceParameter = result.Parameters.First();
            var body = result.Body;
            var cancellationParameter = Expression.Parameter(typeof(CancellationToken), "cancellation");

            return Expression.Lambda<Func<TSource, CancellationToken, ValueTask<TTarget>>>(
                body, sourceParameter, cancellationParameter);
        }
    }
}
