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
using System.Collections.Immutable;
using System.IO;
using System.Threading.Tasks;

namespace AsyncQueryableAdapter.Specifications.Generator.Parameters
{
    internal sealed class ParameterList
    {
        public ParameterList(IEnumerable<Parameter> parameters)
        {
            Parameters = parameters as ImmutableList<Parameter> ?? parameters.ToImmutableList();
        }

        internal ImmutableList<Parameter> Parameters { get; }

        public async Task SetupParametersAsync(StreamWriter writer)
        {
            foreach (var parameter in Parameters)
            {
                await writer.WriteLineAsync().ConfigureAwait(false);
                await writer.WriteLineAsync($"            // Arrange '{parameter.Name}' parameter").ConfigureAwait(false);
                await parameter.SetupParameterAsync(writer).ConfigureAwait(false);
            }
        }

        public async Task WriteParameterListAsync(StreamWriter writer)
        {
            for (var i = 0; i < Parameters.Count; i++)
            {
                var parameter = Parameters[i];

                await writer.WriteAsync(parameter.Name).ConfigureAwait(false);

                if (i < Parameters.Count - 1)
                {
                    await writer.WriteAsync(',').ConfigureAwait(false);
                    await writer.WriteAsync(' ').ConfigureAwait(false);
                }
            }
        }
    }
}
