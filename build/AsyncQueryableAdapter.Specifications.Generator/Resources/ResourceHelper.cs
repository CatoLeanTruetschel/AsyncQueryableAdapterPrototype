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

using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace AsyncQueryableAdapter.Specifications.Generator.Resources
{
    internal static class ResourceHelper
    {
        public static async Task<string> ReadResourceAsync(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = typeof(ResourceHelper).Namespace + "." + name;

            using var stream = assembly.GetManifestResourceStream(resourceName);

            if (stream is null)
            {
                return string.Empty;
            }

            using var reader = new StreamReader(stream);
            var result = await reader.ReadToEndAsync().ConfigureAwait(false);

            return result;
        }
    }
}
