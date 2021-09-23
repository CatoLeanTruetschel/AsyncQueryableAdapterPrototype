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
    internal sealed class ComparerParameterEvaluator : ParameterEvaluatorBase
    {
        public ComparerParameterEvaluator(
            KnownNamespaces knownNamespaces,
            KnownCollectionTypes knownCollectionTypes)
            : base(knownNamespaces, knownCollectionTypes)
        {
        }

        public override bool TryEvaluate(
            Type sourceType,
            string operationName,
            ParameterInfo asyncParameter,
            ParameterInfo syncParameter,
            UniqueIdentifierBuilder identifierBuilder, [NotNullWhen(true)] out ParameterPair? result)
        {
            result = null;

            var asyncParamType = asyncParameter.ParameterType;
            var syncParamType = syncParameter.ParameterType;

            if (!TypeHelper.IsComparerType(asyncParamType, out var asyncComparisonType))
                return false;

            if (!TypeHelper.IsComparerType(syncParamType, out var syncComparisonType))
                return false;

            identifierBuilder.WithParameter(asyncParameter.Name!);

            Parameter asyncParamDefinition, syncParamDefinition;

            if (syncComparisonType == typeof(string))
            {
                syncParamDefinition = Parameter.Default(syncParameter.Name!, async (writer, variableName) =>
                {
                    await writer.WriteLineAsync($"            var {variableName} = StringComparer.Ordinal;").ConfigureAwait(false);
                });
            }
            else
            {
                syncParamDefinition = Parameter.Default(syncParameter.Name!, async (writer, variableName) =>
                {
                    await writer.WriteLineAsync($"            var {variableName} = Comparer<{TypeHelper.FormatCSharpTypeName(syncComparisonType, KnownNamespaces.Namespaces)}>.Default;").ConfigureAwait(false);
                });
            }

            // We only need a single variable definition
            if (string.Equals(asyncParameter.Name, syncParameter.Name, StringComparison.Ordinal)
                && asyncComparisonType == syncComparisonType)
            {
                asyncParamDefinition = syncParamDefinition;
                syncParamDefinition = Parameter.Default(syncParamDefinition.Name);
            }
            else if (asyncComparisonType == typeof(string))
            {
                asyncParamDefinition = Parameter.Default(asyncParameter.Name!, async (writer, variableName) =>
                {
                    await writer.WriteLineAsync($"            var {variableName} = StringComparer.Ordinal;").ConfigureAwait(false);
                });
            }
            else
            {
                asyncParamDefinition = Parameter.Default(asyncParameter.Name!, async (writer, variableName) =>
                {
                    await writer.WriteLineAsync($"            var {variableName} = Comparer<{TypeHelper.FormatCSharpTypeName(asyncComparisonType, KnownNamespaces.Namespaces)}>.Default;").ConfigureAwait(false);
                });
            }

            result = new ParameterPair(asyncParamDefinition, syncParamDefinition);
            return true;
        }
    }
}
