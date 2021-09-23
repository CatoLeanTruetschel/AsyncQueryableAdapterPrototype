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
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using AsyncQueryableAdapter.Specifications.Generator.Parameters;

namespace AsyncQueryableAdapter.Specifications.Generator.Tests
{
    internal sealed class CanceledTestCaseGenerator : ITestCaseGenerator
    {
        private readonly KnownNamespaces _knownNamespaces;

        public CanceledTestCaseGenerator(KnownNamespaces knownNamespaces)
        {
            if (knownNamespaces is null)
                throw new ArgumentNullException(nameof(knownNamespaces));

            _knownNamespaces = knownNamespaces;
        }

        public IEnumerable<TestCase> GenerateTestCases(
            MethodPair methods,
            ParameterListPair parameters,
            UniqueIdentifier uniqueIdentifier)
        {
            var testCases = ImmutableList.CreateBuilder<TestCase>();
            var asyncParameters = methods.AsyncMethod.GetParameters();

            for (var i = 0; i < asyncParameters.Length; i++)
            {
                if (asyncParameters[i].ParameterType == typeof(CancellationToken))
                {
                    // Check if the type is annotated as nullable
                    testCases.Add(new CanceledTestCase(
                        methods.AsyncMethod,
                        asyncParameters[i],
                        new ParameterList(parameters.AsyncParameters.Parameters.SetItem(
                            i,
                            Parameter.Default(parameters.AsyncParameters.Parameters[i].Name!, async (writer, variableName) =>
                            {
                                await writer.WriteLineAsync($"            using var { variableName }Source = new CancellationTokenSource();").ConfigureAwait(false);
                                await writer.WriteLineAsync($"            var { variableName } = { variableName }Source.Token;").ConfigureAwait(false);
                                await writer.WriteLineAsync($"            { variableName }Source.Cancel();").ConfigureAwait(false);
                            }))),
                            _knownNamespaces,
                           uniqueIdentifier));
                }
            }

            return testCases.ToImmutable();
        }
    }
}
