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
using AsyncQueryableAdapter.Specifications.Generator.Parameters;

namespace AsyncQueryableAdapter.Specifications.Generator.Tests
{
    internal sealed class EquivalenceTestCaseGenerator : ITestCaseGenerator
    {
        private readonly KnownNamespaces _knownNamespaces;
        private readonly OptionsResolver _optionsResolver;

        public EquivalenceTestCaseGenerator(KnownNamespaces knownNamespaces, OptionsResolver optionsResolver)
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
            // For now only build a single test case, later we can add variations to the parameters

            var testCase = new EquivalenceTestCase(
                methods,
                parameters,
                _knownNamespaces,
                _optionsResolver,
                uniqueIdentifier);

            return new[] { testCase };
        }
    }
}
