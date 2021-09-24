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
using System.Reflection;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Specifications.Generator.Parameters;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Specifications.Generator.Tests
{
    internal sealed class CanceledTestCase : TestCase
    {
        private readonly ParameterList _parameters;
        private readonly UniqueIdentifier _uniqueIdentifier;
        private readonly KnownNamespaces _knownNamespaces;
        private readonly OptionsResolver _optionsResolver;

        public CanceledTestCase(
            MethodInfo method,
            ParameterInfo parameter,
            ParameterList parameters,
            KnownNamespaces knownNamespaces,
            OptionsResolver optionsResolver,
            UniqueIdentifier uniqueIdentifier)
        {
            Method = method;
            Parameter = parameter;
            _parameters = parameters;
            _uniqueIdentifier = uniqueIdentifier;
            _knownNamespaces = knownNamespaces;
            _optionsResolver = optionsResolver;
        }

        public MethodInfo Method { get; }
        public ParameterInfo Parameter { get; }

        protected override string Name => $"{_uniqueIdentifier}Canceled{Parameter.Name.FirstRuneToUpperCase()}ThrowsOperationCanceledException";

        protected override async Task FormatArrangeAsync(StreamWriter writer)
        {
            var options = _optionsResolver.ResolveOptions(Method, _parameters);

            // QueryAdapter
            await writer.WriteLineAsync().ConfigureAwait(false);
            await writer.WriteLineAsync("            // Arrange 'queryAdapter' parameter").ConfigureAwait(false);
            await writer.WriteLineAsync($"            var queryAdapter = await GetQueryAdapterAsync({options});").ConfigureAwait(false);

            await _parameters.SetupParametersAsync(writer).ConfigureAwait(false);
        }

        protected override async Task FormatAssertAsync(StreamWriter writer)
        {
            await writer.WriteLineAsync($"            await Assert.ThrowsAsync<OperationCanceledException>(async () =>").ConfigureAwait(false);
            await writer.WriteLineAsync($"            {{").ConfigureAwait(false);
            await writer.WriteAsync($"                await AsyncQueryable.{Method.Name}").ConfigureAwait(false);

            if (Method.IsGenericMethod)
            {
                await writer.WriteAsync("<").ConfigureAwait(false);
                var genericArguments = Method.GetGenericArguments();
                for (var i = 0; i < genericArguments.Length; i++)
                {
                    await writer.WriteAsync(
                        TypeHelper.FormatCSharpTypeName(genericArguments[i], _knownNamespaces.Namespaces)).ConfigureAwait(false);

                    if (i < genericArguments.Length - 1)
                    {
                        await writer.WriteAsync(',').ConfigureAwait(false);
                        await writer.WriteAsync(' ').ConfigureAwait(false);
                    }
                }

                await writer.WriteAsync('>').ConfigureAwait(false);
            }

            await writer.WriteAsync('(').ConfigureAwait(false);
            await _parameters.WriteParameterListAsync(writer).ConfigureAwait(false);

            if (TypeHelper.IsAsyncEnumerableType(Method.ReturnType)
                || TypeHelper.IsAsyncQueryableType(Method.ReturnType))
            {
                await writer.WriteLineAsync(").ToListAsync().ConfigureAwait(false);").ConfigureAwait(false);
            }
            else
            {
                await writer.WriteLineAsync(").ConfigureAwait(false);").ConfigureAwait(false);
            }

            await writer.WriteLineAsync($"            }});").ConfigureAwait(false);
        }
    }
}
