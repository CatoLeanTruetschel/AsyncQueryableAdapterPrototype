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

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AsyncQueryableAdapterPrototype.Tests
{
    partial class QueryAdapterSpecification
    {
        [Fact]
        public async Task WhereGroupByTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Where(p => p.Age > 25).GroupBy(p => p.LastName);

            // Act
            var queryResult = await personQueryable.Where(p => p.Age > 25).GroupBy(p => p.LastName).AwaitGroupings();

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        [Fact]
        public async Task WhereGroupByOrderByTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(DisallowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries.Where(p => p.Age > 25).GroupBy(p => p.LastName).OrderBy(p => p.Key);

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 25)
                .GroupBy(p => p.LastName)
                .OrderBy(p => p.Key)
                .AwaitGroupings();

            // Assert
            Assert.Equal(comparison, queryResult);
        }

        // TODO: As the expression in SelectAwait is indeed recorded, we CAN translate it, but this needs a complete
        //       separate set of translators, that work on IAsyncEnumerable and IEnumerable. It is questionable
        //       whether any database driver will support this query, so just process this in-memory for now.
        [Fact]
        public async Task WhereGroupByOrderBySelectAwaitTest()
        {
            // Arrange
            var queryAdapter = await GetQueryAdapterAsync(AllowImplicitPostProcessing);
            var personQueryable = queryAdapter.GetAsyncQueryable<PersonEntry>();
            var comparison = _personEntries
                .Where(p => p.Age > 25)
                .GroupBy(p => p.LastName)
                .OrderBy(p => p.Key)
                .Select(p => p.Count());

            // Act
            var queryResult = await personQueryable
                .Where(p => p.Age > 25)
                .GroupBy(p => p.LastName)
                .OrderBy(p => p.Key)
                .SelectAwait(p => p.CountAsync(default));

            // Assert
            Assert.Equal(comparison, queryResult);
        }
    }
}
