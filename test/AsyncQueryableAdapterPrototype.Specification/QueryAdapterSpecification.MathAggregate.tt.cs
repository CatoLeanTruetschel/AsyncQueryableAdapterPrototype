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
        // Test cases for the Min Operation
        //

        // Convertible without post-processing
        [Fact]
        public async Task WhereSelectMinTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.Age).MinAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSelectMinNonPrimitiveTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Birthday);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.Birthday).MinAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).MinAsync(p => p.Age);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinNonPrimitiveWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Birthday);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).MinAsync(p => p.Birthday);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).MinAwaitAsync(p => new ValueTask<double>(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            var constConditionalSelector = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitAsync(p => trueValue ? new ValueTask<double>(p.Age) : new ValueTask<double>(p.Age - 1));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitWithCancellationAsync((p, c) => new ValueTask<double>(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            var constConditionalSelector = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitWithCancellationAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<double>(p.Age) : new ValueTask<double>(p.Age - 1));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereMinAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitAsync(p => ValueTask.FromResult(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        [Fact]
        public async Task WhereMinAwaitNonPrimitiveTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Birthday);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).MinAwaitAsync(p => new ValueTask<DateTime>(p.Birthday));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitNonPrimitiveTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Birthday);

            var constConditionalSelector = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.Birthday);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitNonPrimitiveTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Birthday);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitAsync(p => trueValue ? new ValueTask<DateTime>(p.Birthday) : new ValueTask<DateTime>(p.Birthday.AddYears(1)));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitWithCancellationNonPrimitiveTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Birthday);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitWithCancellationAsync((p, c) => new ValueTask<DateTime>(p.Birthday));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitWithCancellationNonPrimitiveTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Birthday);

            var constConditionalSelector = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.Birthday);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitWithCancellationAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitWithCancellationNonPrimitiveTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Birthday);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<DateTime>(p.Birthday) : new ValueTask<DateTime>(p.Birthday.AddYears(1)));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereMinAwaitNonPrimitiveTranslatableFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Birthday);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitAsync(p => ValueTask.FromResult(p.Birthday));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitWithCancellationNonPrimitiveTranslatableFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Birthday);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MinAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.Birthday));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        // Convertible only with post-processing
        [Fact]
        public async Task WhereMinAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).MinAwaitAsync(p => CreateValueTaskAsync(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMinAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42).MinAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitMinTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Min(p => p.Age);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(p.Age > 42)).MinAsync(p => p.Age);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }          

        //
        // Test cases for the Max Operation
        //

        // Convertible without post-processing
        [Fact]
        public async Task WhereSelectMaxTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.Age).MaxAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSelectMaxNonPrimitiveTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Birthday);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.Birthday).MaxAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).MaxAsync(p => p.Age);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxNonPrimitiveWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Birthday);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).MaxAsync(p => p.Birthday);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).MaxAwaitAsync(p => new ValueTask<double>(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            var constConditionalSelector = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitAsync(p => trueValue ? new ValueTask<double>(p.Age) : new ValueTask<double>(p.Age - 1));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitWithCancellationAsync((p, c) => new ValueTask<double>(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            var constConditionalSelector = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitWithCancellationAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<double>(p.Age) : new ValueTask<double>(p.Age - 1));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereMaxAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitAsync(p => ValueTask.FromResult(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        [Fact]
        public async Task WhereMaxAwaitNonPrimitiveTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Birthday);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).MaxAwaitAsync(p => new ValueTask<DateTime>(p.Birthday));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitNonPrimitiveTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Birthday);

            var constConditionalSelector = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.Birthday);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitNonPrimitiveTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Birthday);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitAsync(p => trueValue ? new ValueTask<DateTime>(p.Birthday) : new ValueTask<DateTime>(p.Birthday.AddYears(1)));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitWithCancellationNonPrimitiveTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Birthday);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitWithCancellationAsync((p, c) => new ValueTask<DateTime>(p.Birthday));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitWithCancellationNonPrimitiveTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Birthday);

            var constConditionalSelector = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.Birthday);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitWithCancellationAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitWithCancellationNonPrimitiveTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Birthday);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<DateTime>(p.Birthday) : new ValueTask<DateTime>(p.Birthday.AddYears(1)));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereMaxAwaitNonPrimitiveTranslatableFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Birthday);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitAsync(p => ValueTask.FromResult(p.Birthday));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitWithCancellationNonPrimitiveTranslatableFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Birthday);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .MaxAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.Birthday));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif

        // Convertible only with post-processing
        [Fact]
        public async Task WhereMaxAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).MaxAwaitAsync(p => CreateValueTaskAsync(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereMaxAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42).MaxAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitMaxTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Max(p => p.Age);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(p.Age > 42)).MaxAsync(p => p.Age);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }          

        //
        // Test cases for the Sum Operation
        //
        [Fact]
        public async Task WhereSelectSumTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.Age).SumAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSumWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).SumAsync(p => p.Age);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSumAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).SumAwaitAsync(p => new ValueTask<double>(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSumAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            var constConditionalSelector = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SumAwaitAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSumAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SumAwaitAsync(p => trueValue ? new ValueTask<double>(p.Age) : new ValueTask<double>(p.Age - 1));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSumAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SumAwaitWithCancellationAsync((p, c) => new ValueTask<double>(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSumAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            var constConditionalSelector = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SumAwaitWithCancellationAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSumAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SumAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<double>(p.Age) : new ValueTask<double>(p.Age - 1));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereSumAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SumAwaitAsync(p => ValueTask.FromResult(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSumAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .SumAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif


        [Fact]
        public async Task WhereSumAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).SumAwaitAsync(p => CreateValueTaskAsync(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereSumAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42).SumAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitSumTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Sum(p => p.Age);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(p.Age > 42)).SumAsync(p => p.Age);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }          

        //
        // Test cases for the Average Operation
        //
        [Fact]
        public async Task WhereSelectAverageTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).Select(p => p.Age).AverageAsync();

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAverageWithSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).AverageAsync(p => p.Age);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAverageAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).AverageAwaitAsync(p => new ValueTask<double>(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAverageAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            var constConditionalSelector = BuildAsyncConstConditionalAccessExpression(
                (PersonEntry person) => person.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .AverageAwaitAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAverageAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .AverageAwaitAsync(p => trueValue ? new ValueTask<double>(p.Age) : new ValueTask<double>(p.Age - 1));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAverageAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .AverageAwaitWithCancellationAsync((p, c) => new ValueTask<double>(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAverageAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            var constConditionalSelector = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (PersonEntry person) => person.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .AverageAwaitWithCancellationAsync(constConditionalSelector);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAverageAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .AverageAwaitWithCancellationAsync((p, c) => trueValue ? new ValueTask<double>(p.Age) : new ValueTask<double>(p.Age - 1));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

#if NETCORE50
        [Fact]
        public async Task WhereAverageAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .AverageAwaitAsync(p => ValueTask.FromResult(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAverageAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42)
                .AverageAwaitWithCancellationAsync((p, c) => ValueTask.FromResult(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }
#endif


        [Fact]
        public async Task WhereAverageAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 42).AverageAwaitAsync(p => CreateValueTaskAsync(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAverageAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 42).AverageAwaitWithCancellationAsync((p, c) => CreateValueTaskAsync(p.Age));

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }

        [Fact]
        public async Task WhereAwaitAverageTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var expectedQueryResult = _personEntries.Where(p => p.Age > 42).Average(p => p.Age);

            // Act
            var queryResult = await personQueryable.WhereAwait(p => CreateValueTaskAsync(p.Age > 42)).AverageAsync(p => p.Age);

            // Assert
            Assert.Equal(expectedQueryResult, queryResult);
        }          
    }
}