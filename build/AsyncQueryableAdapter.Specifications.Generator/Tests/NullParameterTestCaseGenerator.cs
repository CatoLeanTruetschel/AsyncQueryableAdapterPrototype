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
using AsyncQueryableAdapter.Specifications.Generator.Parameters;
using AsyncQueryableAdapter.Utils;
using Namotion.Reflection;

namespace AsyncQueryableAdapter.Specifications.Generator.Tests
{
    internal sealed class NullParameterTestCaseGenerator : ITestCaseGenerator
    {
        private readonly KnownNamespaces _knownNamespaces;
        private readonly OptionsResolver _optionsResolver;

        public NullParameterTestCaseGenerator(KnownNamespaces knownNamespaces, OptionsResolver optionsResolver)
        {
            if (knownNamespaces is null)
                throw new ArgumentNullException(nameof(knownNamespaces));

            if (optionsResolver is null)
                throw new ArgumentNullException(nameof(optionsResolver));

            _knownNamespaces = knownNamespaces;
            _optionsResolver = optionsResolver;
        }

        public IEnumerable<TestCase> GenerateTestCases(
            MethodPair methods,
            ParameterListPair parameters,
            UniqueIdentifier uniqueIdentifier)
        {
            var testCases = ImmutableList.CreateBuilder<TestCase>();
            var asyncParameters = methods.AsyncMethod.GetParameters();

            // Validate throws if parameter is null test cases
            for (var i = 0; i < asyncParameters.Length; i++)
            {
                if (!asyncParameters[i].ParameterType.IsValueType)
                {
                    // Check if the type is annotated as nullable
                    var contextualParameter = asyncParameters[i].ToContextualParameter();
                    if (contextualParameter.Nullability == Nullability.NotNullable)
                    {
                        var parameterType = asyncParameters[i].ParameterType;

                        testCases.Add(new NullParameterTestCase(
                            methods.AsyncMethod,
                            asyncParameters[i],
                            new ParameterList(parameters.AsyncParameters.Parameters.SetItem(
                                i,
                                Parameter.Default(parameters.AsyncParameters.Parameters[i].Name, async (writer, variableName) =>
                                {
                                    await writer.WriteLineAsync($"            { TypeHelper.FormatCSharpTypeName(parameterType, _knownNamespaces.Namespaces) } { variableName } = null!;").ConfigureAwait(false);
                                }))),
                            _knownNamespaces,
                            _optionsResolver,
                           uniqueIdentifier));
                    }
                }
            }

            return testCases.ToImmutable();
        }
    }
}
