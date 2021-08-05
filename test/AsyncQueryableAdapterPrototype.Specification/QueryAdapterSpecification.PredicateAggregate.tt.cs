/* License
 * --------------------------------------------------------------------------------------------------------------------
 * (C) Copyright 2021 Cato Léan Trütschel and contributors 
 * (https://github.com/CatoLeanTruetschel/AsyncQueryableAdapterPrototype)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * --------------------------------------------------------------------------------------------------------------------
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AsyncQueryableAdapterPrototype.Tests
{
    partial class QueryAdapterSpecification
    {

        //
        // Test cases for the All Operation
        //
        [Fact]
        public async Task AllWithPredicateTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.AllAsync(p => p.Age > 42);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAllAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => true).AllAwaitAsync(p => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task AllAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.AllAwaitAsync(p => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAllAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            var constConditionalPredicate = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AllAwaitAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAllAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AllAwaitAsync(p => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task AllAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .AllAwaitAsync(p => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAllAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AllAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAllAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            var constConditionalPredicate = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AllAwaitWithCancellationAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAllAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AllAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task AllAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .AllAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereAllAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AllAwaitAsync(p => ValueTask.FromResult(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAllAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AllAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        [Fact]
        public async Task WhereAllAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => true).AllAwaitAsync(p => CreateValueTaskAsync(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAllAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true).AllAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitAllTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.All(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(true)).AllAsync(p => p.Age > 42);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        //
        // Test cases for the Any Operation
        //
        [Fact]
        public async Task WhereSelectAnyTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.Age).AnyAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task AnyWithPredicateTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.AnyAsync(p => p.Age > 42);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAnyAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => true).AnyAwaitAsync(p => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task AnyAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.AnyAwaitAsync(p => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAnyAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            var constConditionalPredicate = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AnyAwaitAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAnyAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AnyAwaitAsync(p => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task AnyAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .AnyAwaitAsync(p => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAnyAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AnyAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAnyAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            var constConditionalPredicate = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AnyAwaitWithCancellationAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAnyAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AnyAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task AnyAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .AnyAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereAnyAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AnyAwaitAsync(p => ValueTask.FromResult(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAnyAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .AnyAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        [Fact]
        public async Task WhereAnyAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => true).AnyAwaitAsync(p => CreateValueTaskAsync(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAnyAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true).AnyAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitAnyTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Any(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(true)).AnyAsync(p => p.Age > 42);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        //
        // Test cases for the Count Operation
        //
        [Fact]
        public async Task WhereSelectCountTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.Age).CountAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task CountWithPredicateTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.CountAsync(p => p.Age > 42);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereCountAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => true).CountAwaitAsync(p => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task CountAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.CountAwaitAsync(p => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereCountAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            var constConditionalPredicate = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .CountAwaitAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereCountAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .CountAwaitAsync(p => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task CountAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .CountAwaitAsync(p => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereCountAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .CountAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereCountAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            var constConditionalPredicate = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .CountAwaitWithCancellationAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereCountAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .CountAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task CountAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .CountAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereCountAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .CountAwaitAsync(p => ValueTask.FromResult(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereCountAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .CountAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        [Fact]
        public async Task WhereCountAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => true).CountAwaitAsync(p => CreateValueTaskAsync(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereCountAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true).CountAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitCountTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Count(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(true)).CountAsync(p => p.Age > 42);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        //
        // Test cases for the LongCount Operation
        //
        [Fact]
        public async Task WhereSelectLongCountTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.Age).LongCountAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task LongCountWithPredicateTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.LongCountAsync(p => p.Age > 42);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLongCountAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => true).LongCountAwaitAsync(p => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task LongCountAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.LongCountAwaitAsync(p => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLongCountAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            var constConditionalPredicate = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .LongCountAwaitAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLongCountAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .LongCountAwaitAsync(p => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task LongCountAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .LongCountAwaitAsync(p => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLongCountAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .LongCountAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLongCountAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            var constConditionalPredicate = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .LongCountAwaitWithCancellationAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLongCountAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .LongCountAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task LongCountAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .LongCountAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.Age > 42) : new ValueTask<bool>(false));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereLongCountAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .LongCountAwaitAsync(p => ValueTask.FromResult(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLongCountAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true)
                .LongCountAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        [Fact]
        public async Task WhereLongCountAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.Where(p => true).LongCountAwaitAsync(p => CreateValueTaskAsync(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLongCountAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable
                .Where(p => true).LongCountAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.Age > 42));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitLongCountTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.LongCount(p => p.Age > 42);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(true)).LongCountAsync(p => p.Age > 42);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
    }
}