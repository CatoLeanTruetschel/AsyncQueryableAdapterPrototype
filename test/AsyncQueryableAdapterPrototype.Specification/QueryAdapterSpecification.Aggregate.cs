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
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsyncQueryableAdapterPrototype.Tests
{
    partial class QueryAdapterSpecification
    {
        private const string StringSeed = "abc";
        private StringBuilder StringBuilderSeed => new("abc");

        [Fact]
        public async Task AggregateEmptySequenceThrowsInvalidOperationExceptionTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await personQueryable.Select(p => p.FirstName).Where(p => false).AggregateAsync((e, n) => e + n);
            });
        }

        [Fact]
        public async Task SelectAggregateTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            // Act
            var queryResult = await personQueryable.Select(p => p.FirstName).AggregateAsync((e, n) => e + n);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateWithSeedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAsync(StringSeed, (e, n) => e + n);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateWithSeedAndResultSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAsync(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync((e, n) => CreateValueTaskAsync(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync((e, n) => new ValueTask<string>(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

#if SUPPORTS_VALUE_TASK_FROM_RESULT
        [Fact]
        public async Task SelectAggregateAwaitTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync((e, n) => ValueTask.FromResult(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }
#endif

        [Fact]
        public async Task SelectAggregateAwaitTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            var constConditionalAccumulator = BuildAsyncConstConditionalAccessExpression(
                (string e, string n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(constConditionalAccumulator);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync((e, n) => trueValue ? new ValueTask<string>(e + n) : new ValueTask<string>("x"));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithSeedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(StringSeed, (e, n) => CreateValueTaskAsync(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithSeedTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(StringSeed, (e, n) => new ValueTask<string>(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

#if SUPPORTS_VALUE_TASK_FROM_RESULT
        [Fact]
        public async Task SelectAggregateAwaitWithSeedTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(StringSeed, (e, n) => ValueTask.FromResult(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }
#endif

        [Fact]
        public async Task SelectAggregateAwaitWithSeedTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            var constConditionalAccumulator = BuildAsyncConstConditionalAccessExpression(
                (string e, string n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(StringSeed, constConditionalAccumulator);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithSeedTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(
                StringSeed,
                (e, n) => trueValue ? new ValueTask<string>(e + n) : new ValueTask<string>("x"));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithSeedAndResultSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(
                    StringBuilderSeed,
                    (e, n) => CreateValueTaskAsync(e.Append(n)),
                    p => CreateValueTaskAsync(p.ToString()));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithSeedAndResultSelectorTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(
                    StringBuilderSeed,
                    (e, n) => new ValueTask<StringBuilder>(e.Append(n)),
                    p => new ValueTask<string>(p.ToString()));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

#if SUPPORTS_VALUE_TASK_FROM_RESULT
[Fact]
        public async Task SelectAggregateAwaitWithSeedAndResultSelectorTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(
                    StringBuilderSeed,
                    (e, n) => ValueTask.FromResult(e.Append(n)),
                    p => ValueTask.FromResult(p.ToString()));

            // Assert
            Assert.Equal(comparison, queryResult);
        }
#endif

        [Fact]
        public async Task SelectAggregateAwaitWithSeedAndResultSelectorTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            var constConditionalAccumulator = BuildAsyncConstConditionalAccessExpression(
                (StringBuilder e, string n) => e.Append(n));

            var constConditionalResultSelector = BuildAsyncConstConditionalAccessExpression(
                (StringBuilder p) => p.ToString());

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(
                    StringBuilderSeed,
                    constConditionalAccumulator,
                    constConditionalResultSelector);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithSeedAndResultSelectorTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitAsync(
                StringBuilderSeed,
                (e, n) => trueValue
                    ? new ValueTask<StringBuilder>(e.Append(n))
                    : new ValueTask<StringBuilder>(new StringBuilder("x")),
                p => trueValue
                    ? new ValueTask<string>(p.ToString())
                    : new ValueTask<string>("x"));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync((e, n, c) => CreateValueTaskAsync(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync((e, n, c) => new ValueTask<string>(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

#if SUPPORTS_VALUE_TASK_FROM_RESULT
        [Fact]
        public async Task SelectAggregateAwaitWithCancellationTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync((e, n, c) => ValueTask.FromResult(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }
#endif

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            var constConditionalAccumulator = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (string e, string n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(constConditionalAccumulator);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate((e, n) => e + n);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync((e, n, c) => trueValue
                    ? new ValueTask<string>(e + n)
                    : new ValueTask<string>("x"));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationWithSeedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(StringSeed, (e, n, c) => CreateValueTaskAsync(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationWithSeedTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(StringSeed, (e, n, c) => new ValueTask<string>(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

#if SUPPORTS_VALUE_TASK_FROM_RESULT
        [Fact]
        public async Task SelectAggregateAwaitWithCancellationWithSeedTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(StringSeed, (e, n, c) => ValueTask.FromResult(e + n));

            // Assert
            Assert.Equal(comparison, queryResult);
        }
#endif

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationWithSeedTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            var constConditionalAccumulator = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (string e, string n) => e + n);

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(StringSeed, constConditionalAccumulator);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationWithSeedTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Select(p => p.FirstName).Aggregate(StringSeed, (e, n) => e + n);

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(
                StringSeed,
                (e, n, c) => trueValue ? new ValueTask<string>(e + n) : new ValueTask<string>("x"));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationWithSeedAndResultSelectorTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitDefaultPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(
                    StringBuilderSeed,
                    (e, n, c) => CreateValueTaskAsync(e.Append(n)),
                    (p, c) => CreateValueTaskAsync(p.ToString()));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationWithSeedAndResultSelectorTranslatableTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(
                    StringBuilderSeed,
                    (e, n, c) => new ValueTask<StringBuilder>(e.Append(n)),
                    (p, c) => new ValueTask<string>(p.ToString()));

            // Assert
            Assert.Equal(comparison, queryResult);
        }

#if SUPPORTS_VALUE_TASK_FROM_RESULT
[Fact]
        public async Task SelectAggregateAwaitWithCancellationWithSeedAndResultSelectorTranslatableValueTaskFactoryMethodTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(
                    StringBuilderSeed,
                    (e, n, c) => ValueTask.FromResult(e.Append(n)),
                    (p, c) => ValueTask.FromResult(p.ToString()));

            // Assert
            Assert.Equal(comparison, queryResult);
        }
#endif

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationWithSeedAndResultSelectorTranslatableConditionalConstTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            var constConditionalAccumulator = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (StringBuilder e, string n) => e.Append(n));

            var constConditionalResultSelector = BuildAsyncConstConditionalAccessWithCancellationExpression(
                (StringBuilder p) => p.ToString());

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(
                    StringBuilderSeed,
                    constConditionalAccumulator,
                    constConditionalResultSelector);

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task SelectAggregateAwaitWithCancellationWithSeedAndResultSelectorTranslatableConditionalCapturedTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowInMemoryEvaluation);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Select(p => p.FirstName)
                .Aggregate(StringBuilderSeed, (e, n) => e.Append(n), p => p.ToString());

            var trueValue = true;

            // Act
            var queryResult = await personQueryable
                .Select(p => p.FirstName)
                .AggregateAwaitWithCancellationAsync(
                StringBuilderSeed,
                (e, n, c) => trueValue
                    ? new ValueTask<StringBuilder>(e.Append(n))
                    : new ValueTask<StringBuilder>(new StringBuilder("x")),
                (p, c) => trueValue
                    ? new ValueTask<string>(p.ToString())
                    : new ValueTask<string>("x"));

            // Assert
            Assert.Equal(comparison, queryResult);
        }
    }
}
