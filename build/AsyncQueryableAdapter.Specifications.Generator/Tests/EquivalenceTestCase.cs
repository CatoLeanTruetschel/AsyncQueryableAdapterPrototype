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
using AsyncQueryableAdapter.Specifications.Generator.Parameters;
using AsyncQueryableAdapter.Utils;
using AsyncQueryableAdapterPrototype.Utils;

namespace AsyncQueryableAdapter.Specifications.Generator.Tests
{
    internal sealed class EquivalenceTestCase : TestCase
    {
        private readonly MethodPair _methods;
        private readonly ParameterListPair _parameters;
        private readonly UniqueIdentifier _uniqueIdentifier;
        private readonly KnownNamespaces _knownNamespaces;
        private readonly OptionsResolver _optionsResolver;

        public EquivalenceTestCase(
            MethodPair methods,
            ParameterListPair parameters,
            KnownNamespaces knownNamespaces,
            OptionsResolver optionsResolver,
            UniqueIdentifier uniqueIdentifier)
        {
            _methods = methods;
            _parameters = parameters;
            _uniqueIdentifier = uniqueIdentifier;
            _knownNamespaces = knownNamespaces;
            _optionsResolver = optionsResolver;
        }

        protected override string Name => $"{_uniqueIdentifier}IsEquivalentTo{_methods.SyncMethod.Name}";

        protected override async Task FormatArrangeAsync(StreamWriter writer)
        {
            var options = _optionsResolver.ResolveOptions(_methods.AsyncMethod, _parameters.AsyncParameters);

            // QueryAdapter
            await writer.WriteLineAsync().ConfigureAwait(false);
            await writer.WriteLineAsync("            // Arrange 'queryAdapter' parameter").ConfigureAwait(false);
            await writer.WriteLineAsync($"            var queryAdapter = await GetQueryAdapterAsync({options});").ConfigureAwait(false);

            await _parameters.SyncParameters.SetupParametersAsync(writer).ConfigureAwait(false);
            await _parameters.AsyncParameters.SetupParametersAsync(writer).ConfigureAwait(false);

            // ExpectedResult
            await writer.WriteLineAsync().ConfigureAwait(false);
            await writer.WriteLineAsync("            // Arrange 'expectedResult' parameter").ConfigureAwait(false);

            if (_methods.SyncMethod.Name.Equals("Append", StringComparison.Ordinal)
                || _methods.SyncMethod.Name.Equals("Prepend", StringComparison.Ordinal))
            {
                await writer.WriteLineAsync($"            var expectedResult =").ConfigureAwait(false);
                await writer.WriteLineAsync($"            Enumerable").ConfigureAwait(false);
                await writer.WriteAsync($"            .{_methods.SyncMethod.Name}").ConfigureAwait(false);
            }
            else if (_methods.SyncMethod.Name.Equals("SkipLast", StringComparison.Ordinal)
               || _methods.SyncMethod.Name.Equals("TakeLast", StringComparison.Ordinal))
            {
                await writer.WriteLineAsync($"            var expectedResult =").ConfigureAwait(false);
                await writer.WriteLineAsync($"            EnumerableExtension").ConfigureAwait(false);
                await writer.WriteAsync($"            .{_methods.SyncMethod.Name}").ConfigureAwait(false);
            }
            else
            {
                await writer.WriteAsync($"            var expectedResult = {TypeHelper.FormatCSharpTypeName(_methods.SyncMethod.DeclaringType!, _knownNamespaces.Namespaces)}.{_methods.SyncMethod.Name}").ConfigureAwait(false);
            }

            if (_methods.SyncMethod.IsGenericMethod)
            {
                await writer.WriteAsync("<").ConfigureAwait(false);
                var genericArguments = _methods.SyncMethod.GetGenericArguments();
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
            await _parameters.SyncParameters.WriteParameterListAsync(writer).ConfigureAwait(false);
            await writer.WriteLineAsync(");").ConfigureAwait(false);
        }

        protected override async Task FormatActAsync(StreamWriter writer)
        {
            await writer.WriteAsync($"            var result = await AsyncQueryable.{_methods.AsyncMethod.Name}").ConfigureAwait(false);

            if (_methods.AsyncMethod.IsGenericMethod)
            {
                await writer.WriteAsync("<").ConfigureAwait(false);
                var genericArguments = _methods.AsyncMethod.GetGenericArguments();
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
            await _parameters.AsyncParameters.WriteParameterListAsync(writer).ConfigureAwait(false);

            if (TypeHelper.IsAsyncEnumerableType(_methods.AsyncMethod.ReturnType, out var elementType)
                || TypeHelper.IsAsyncQueryableType(_methods.AsyncMethod.ReturnType, out elementType))
            {
                if (TypeHelper.IsAsyncGroupingType(elementType))
                {
                    await writer.WriteLineAsync(").AwaitGroupings().ConfigureAwait(false);").ConfigureAwait(false);
                }
                else
                {
                    await writer.WriteLineAsync(").ToListAsync().ConfigureAwait(false);").ConfigureAwait(false);
                }
            }
            else
            {
                await writer.WriteLineAsync(").ConfigureAwait(false);").ConfigureAwait(false);
            }
        }

        protected override async Task FormatAssertAsync(StreamWriter writer)
        {
            var syncResultType = _methods.SyncMethod.ReturnType;
            var asyncReturnType = _methods.AsyncMethod.ReturnType;
            var asyncResultType = AwaitableTypeDescriptor.GetTypeDescriptor(asyncReturnType).ResultType;

            var isSyncResultFPType = syncResultType == typeof(float)
                || syncResultType == typeof(float?)
                || syncResultType == typeof(double)
                || syncResultType == typeof(double?)
                || syncResultType == typeof(decimal)
                || syncResultType == typeof(decimal?);

            var isAsyncResultFPType = asyncResultType == typeof(float)
                || syncResultType == typeof(float?)
                || syncResultType == typeof(double)
                || syncResultType == typeof(double?)
                || syncResultType == typeof(decimal)
                || syncResultType == typeof(decimal?);

            // Compare with tolerance
            if (isSyncResultFPType && isAsyncResultFPType)
            {
                await writer.WriteLineAsync("            AssertHelper.Equal(expectedResult, result);").ConfigureAwait(false);
            }
            else
            {
                await writer.WriteLineAsync("            Assert.Equal(expectedResult, result);").ConfigureAwait(false);
            }
        }
    }
}
