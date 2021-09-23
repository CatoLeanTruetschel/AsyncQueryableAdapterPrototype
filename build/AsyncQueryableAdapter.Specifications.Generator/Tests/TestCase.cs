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
using System.IO;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Specifications.Generator.Resources;

namespace AsyncQueryableAdapter.Specifications.Generator.Tests
{
    internal abstract class TestCase
    {
        protected abstract string Name { get; }

        protected virtual async Task FormatArrangeAsync(StreamWriter writer)
        {
            await writer.WriteLineAsync($"            // -").ConfigureAwait(false);
        }

        protected virtual async Task FormatActAsync(StreamWriter writer)
        {
            await writer.WriteLineAsync($"            // -").ConfigureAwait(false);
        }

        protected abstract Task FormatAssertAsync(StreamWriter writer);

        public virtual async Task FormatAsync(StreamWriter writer)
        {
            // Append the unit test method header
            var testHeader = await ResourceHelper.ReadResourceAsync("TestHeader.txt").ConfigureAwait(false);
            await writer.WriteAsync(testHeader.Replace("{0}", Name, StringComparison.Ordinal)).ConfigureAwait(false);

            // Arrange
            await writer.WriteLineAsync("            // Arrange").ConfigureAwait(false);
            await FormatArrangeAsync(writer).ConfigureAwait(false);

            // Act
            await writer.WriteLineAsync().ConfigureAwait(false);
            await writer.WriteLineAsync("            // Act").ConfigureAwait(false);
            await FormatActAsync(writer).ConfigureAwait(false);

            // Assert
            await writer.WriteLineAsync().ConfigureAwait(false);
            await writer.WriteLineAsync("            // Assert").ConfigureAwait(false);
            await FormatAssertAsync(writer).ConfigureAwait(false);

            // Append the unit test method footer
            var testFooter = await ResourceHelper.ReadResourceAsync("TestFooter.txt").ConfigureAwait(false);
            await writer.WriteAsync(testFooter).ConfigureAwait(false);
        }
    }
}
