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
using AsyncQueryableAdapter;
using Xunit;

namespace AsyncQueryableAdapterPrototype.Tests
{
    public abstract partial class QueryAdapterSpecification
    {

        //
        // Test cases for the First Operation
        //

        // Convertible without post-processing
        [Fact]
        public async Task WhereFirstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age == 21).First();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).FirstAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable.Where(p => p.Age > 1000).FirstAsync();
            });
        }

        [Fact]
        public async Task WhereFirstWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstWithSelectorNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable.Where(p => p.Age > 1000).FirstAsync(p => p.LastName == "Higgins");
            });
        }

        [Fact]
        public async Task WhereFirstAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAwaitAsync(p => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstAwaitNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable.Where(p => p.Age > 1000).FirstAwaitAsync(p => new ValueTask<bool>(p.LastName == "Higgins"));
            });
        }

        [Fact]
        public async Task WhereFirstAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAwaitAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAwaitAsync(p => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

                [Fact]
        public async Task WhereFirstAwaitWithCancellationNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable
                    .Where(p => p.Age > 1000)
                    .FirstAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Higgins"));
            });
        }

        [Fact]
        public async Task WhereFirstAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAwaitWithCancellationAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereFirstAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAwaitAsync(p => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        // Convertible only with post-processing
        [Fact]
        public async Task WhereFirstAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAwaitAsync(p => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitFirstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).First(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .WhereAwait(p => CreateValueTaskAsync(p.Age > 42))
                .FirstAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        //
        // Test cases for the FirstOrDefault Operation
        //

        // Convertible without post-processing
        [Fact]
        public async Task WhereFirstOrDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age == 21).FirstOrDefault();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).FirstOrDefaultAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 1000).FirstOrDefaultAsync();

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultWithSelectorNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 1000).FirstOrDefaultAsync(p => p.LastName == "Higgins");

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAwaitAsync(p => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultAwaitNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 1000).FirstOrDefaultAwaitAsync(p => new ValueTask<bool>(p.LastName == "Higgins"));

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAwaitAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAwaitAsync(p => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

                [Fact]
        public async Task WhereFirstOrDefaultAwaitWithCancellationNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 1000)
                .FirstOrDefaultAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Higgins"));

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAwaitWithCancellationAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereFirstOrDefaultAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAwaitAsync(p => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        // Convertible only with post-processing
        [Fact]
        public async Task WhereFirstOrDefaultAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAwaitAsync(p => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereFirstOrDefaultAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .FirstOrDefaultAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitFirstOrDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).FirstOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .WhereAwait(p => CreateValueTaskAsync(p.Age > 42))
                .FirstOrDefaultAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        //
        // Test cases for the Last Operation
        //

        // Convertible without post-processing
        [Fact]
        public async Task WhereLastTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age == 21).Last();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).LastAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable.Where(p => p.Age > 1000).LastAsync();
            });
        }

        [Fact]
        public async Task WhereLastWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastWithSelectorNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable.Where(p => p.Age > 1000).LastAsync(p => p.LastName == "Higgins");
            });
        }

        [Fact]
        public async Task WhereLastAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAwaitAsync(p => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastAwaitNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable.Where(p => p.Age > 1000).LastAwaitAsync(p => new ValueTask<bool>(p.LastName == "Higgins"));
            });
        }

        [Fact]
        public async Task WhereLastAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAwaitAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAwaitAsync(p => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

                [Fact]
        public async Task WhereLastAwaitWithCancellationNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable
                    .Where(p => p.Age > 1000)
                    .LastAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Higgins"));
            });
        }

        [Fact]
        public async Task WhereLastAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAwaitWithCancellationAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereLastAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAwaitAsync(p => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        // Convertible only with post-processing
        [Fact]
        public async Task WhereLastAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAwaitAsync(p => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitLastTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Last(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .WhereAwait(p => CreateValueTaskAsync(p.Age > 42))
                .LastAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        //
        // Test cases for the LastOrDefault Operation
        //

        // Convertible without post-processing
        [Fact]
        public async Task WhereLastOrDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age == 21).LastOrDefault();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).LastOrDefaultAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 1000).LastOrDefaultAsync();

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultWithSelectorNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 1000).LastOrDefaultAsync(p => p.LastName == "Higgins");

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAwaitAsync(p => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultAwaitNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 1000).LastOrDefaultAwaitAsync(p => new ValueTask<bool>(p.LastName == "Higgins"));

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAwaitAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAwaitAsync(p => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

                [Fact]
        public async Task WhereLastOrDefaultAwaitWithCancellationNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 1000)
                .LastOrDefaultAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Higgins"));

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAwaitWithCancellationAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereLastOrDefaultAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAwaitAsync(p => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(
#if SUPPORTS_QUERYABLE_TAKE_LAST
				DisallowImplicitPostProcessing
#else
				AllowInMemoryEvaluation
#endif
				);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        // Convertible only with post-processing
        [Fact]
        public async Task WhereLastOrDefaultAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAwaitAsync(p => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereLastOrDefaultAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .LastOrDefaultAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitLastOrDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).LastOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .WhereAwait(p => CreateValueTaskAsync(p.Age > 42))
                .LastOrDefaultAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        //
        // Test cases for the Single Operation
        //

        // Convertible without post-processing
        [Fact]
        public async Task WhereSingleTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age == 21).Single();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).SingleAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable.Where(p => p.Age > 1000).SingleAsync();
            });
        }

        [Fact]
        public async Task WhereSingleWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleWithSelectorNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable.Where(p => p.Age > 1000).SingleAsync(p => p.LastName == "Higgins");
            });
        }

        [Fact]
        public async Task WhereSingleAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAwaitAsync(p => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleAwaitNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable.Where(p => p.Age > 1000).SingleAwaitAsync(p => new ValueTask<bool>(p.LastName == "Higgins"));
            });
        }

        [Fact]
        public async Task WhereSingleAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAwaitAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAwaitAsync(p => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

                [Fact]
        public async Task WhereSingleAwaitWithCancellationNoEntryThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act, Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            {
                await personQueryable
                    .Where(p => p.Age > 1000)
                    .SingleAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Higgins"));
            });
        }

        [Fact]
        public async Task WhereSingleAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAwaitWithCancellationAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereSingleAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAwaitAsync(p => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        // Convertible only with post-processing
        [Fact]
        public async Task WhereSingleAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAwaitAsync(p => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitSingleTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Single(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .WhereAwait(p => CreateValueTaskAsync(p.Age > 42))
                .SingleAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        //
        // Test cases for the SingleOrDefault Operation
        //

        // Convertible without post-processing
        [Fact]
        public async Task WhereSingleOrDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age == 21).SingleOrDefault();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age == 21).SingleOrDefaultAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 1000).SingleOrDefaultAsync();

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultWithSelectorNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 1000).SingleOrDefaultAsync(p => p.LastName == "Higgins");

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAwaitAsync(p => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultAwaitNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 1000).SingleOrDefaultAwaitAsync(p => new ValueTask<bool>(p.LastName == "Higgins"));

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAwaitAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAwaitAsync(p => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

                [Fact]
        public async Task WhereSingleOrDefaultAwaitWithCancellationNoEntryReturnDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 1000)
                .SingleOrDefaultAwaitWithCancellationAsync((p, c) => new ValueTask<bool>(p.LastName == "Higgins"));

            // Assert
            Assert.Equal(default, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            var constConditionalPredicate = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAwaitWithCancellationAsync(constConditionalPredicate);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<bool>(p.LastName == "Adams") : new ValueTask<bool>(p.LastName != "Tailor"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereSingleOrDefaultAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAwaitAsync(p => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        // Convertible only with post-processing
        [Fact]
        public async Task WhereSingleOrDefaultAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAwaitAsync(p => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSingleOrDefaultAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SingleOrDefaultAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.LastName == "Adams"));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitSingleOrDefaultTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).SingleOrDefault(p => p.LastName == "Adams");

            // Act
            var queryResult = await personQueryable
                .WhereAwait(p => CreateValueTaskAsync(p.Age > 42))
                .SingleOrDefaultAsync(p => p.LastName == "Adams");

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
    }
}