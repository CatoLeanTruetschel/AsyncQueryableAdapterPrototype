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
    internal sealed class IntegratedNumericTypeParameterEvaluator : ParameterEvaluatorBase
    {
        public IntegratedNumericTypeParameterEvaluator(
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

            if (!TypeHelper.IsIntegratedNumericType(asyncParamType)
                && !TypeHelper.IsNullableIntegratedNumericType(asyncParamType))
            {
                return false;
            }

            if (!TypeHelper.IsIntegratedNumericType(syncParamType)
                && !TypeHelper.IsNullableIntegratedNumericType(syncParamType))
            {
                return false;
            }

            identifierBuilder.WithParameter(asyncParameter.Name!);

            var syncParamDefinition = Parameter.Default(syncParameter.Name!, async (writer, variableName) =>
            {
                await writer.WriteLineAsync($"            var {variableName} = 5;").ConfigureAwait(false);
            });

            Parameter asyncParamDefinition;

            // We only need a single variable definition
            if (asyncParamType == syncParamType)
            {
                asyncParamDefinition = syncParamDefinition;
                syncParamDefinition = Parameter.Default(asyncParamDefinition.Name);
            }
            else
            {
                asyncParamDefinition = Parameter.Default(asyncParameter.Name!, "async", async (writer, variableName) =>
                {
                    await writer.WriteLineAsync($"            var {variableName} = 5;").ConfigureAwait(false);
                });
            }

            result = new ParameterPair(asyncParamDefinition, syncParamDefinition);
            return true;
        }
    }
}
