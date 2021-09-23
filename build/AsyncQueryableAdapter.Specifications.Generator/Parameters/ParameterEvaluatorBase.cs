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
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Specifications.Generator.Parameters
{
    internal abstract class ParameterEvaluatorBase : IParameterEvaluator
    {
        protected ParameterEvaluatorBase(
            KnownNamespaces knownNamespaces,
            KnownCollectionTypes knownCollectionTypes)
        {
            if (knownNamespaces is null)
                throw new ArgumentNullException(nameof(knownNamespaces));

            if (knownCollectionTypes is null)
                throw new ArgumentNullException(nameof(knownCollectionTypes));

            KnownNamespaces = knownNamespaces;

            KnownCollectionTypes = knownCollectionTypes;
        }

        protected KnownNamespaces KnownNamespaces { get; }

        protected KnownCollectionTypes KnownCollectionTypes { get; }

        public abstract bool TryEvaluate(
            Type sourceType,
            string operationName,
            ParameterInfo asyncParameter,
            ParameterInfo syncParameter,
            UniqueIdentifierBuilder identifierBuilder, [NotNullWhen(true)] out ParameterPair? result);

        protected static string FormatVariableDefinition(string name, string value)
        {
            return $"            var {name} = {value};";
        }

        protected string FormatVariableDefinition(string name, string value, Type type)
        {
            return $"            {TypeHelper.FormatCSharpTypeName(type, KnownNamespaces.Namespaces)} {name} = {value};";
        }
    }
}
