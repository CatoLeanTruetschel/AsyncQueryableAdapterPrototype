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
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using AsyncQueryableAdapter.Utils;
using AsyncQueryableAdapterPrototype.Utils;

namespace AsyncQueryableAdapter.Specifications.Generator.Parameters
{
    internal class ParametersBuilder
    {
        private readonly IEnumerable<IParameterEvaluator> _evaluators;
        private readonly KnownNamespaces _knownNamespaces;

        public ParametersBuilder(IEnumerable<IParameterEvaluator> evaluators, KnownNamespaces knownNamespaces)
        {
            if (evaluators is null)
                throw new ArgumentNullException(nameof(evaluators));

            if (knownNamespaces is null)
                throw new ArgumentNullException(nameof(knownNamespaces));

            if (evaluators.Any(p => p is null))
            {
                ThrowHelper.ThrowCollectionMustNotContainNullEntries(nameof(evaluators));
            }

            _evaluators = evaluators as ImmutableList<IParameterEvaluator> ?? evaluators.ToImmutableList();
            _knownNamespaces = knownNamespaces;
        }

        public ParameterListPair BuildParameters(
            Type sourceType,
            MethodInfo asyncMethod,
            MethodInfo syncMethod,
            UniqueIdentifierBuilder identifierBuilder)
        {
            Debug.Assert(sourceType is not null);
            Debug.Assert(asyncMethod is not null);
            Debug.Assert(syncMethod is not null);
            Debug.Assert(identifierBuilder is not null);

            var operationName = OperationNameHelper.GetOperationName(asyncMethod);
            var asyncParameters = asyncMethod.GetParameters();
            var syncParameters = syncMethod.GetParameters();

            Debug.Assert(asyncParameters.Length == syncParameters.Length
                || asyncParameters.Length == syncParameters.Length + 1
                    && asyncParameters[^1].ParameterType == typeof(CancellationToken));

            var asyncParametersBuilder = ImmutableList.CreateBuilder<Parameter>();
            var syncParametersBuilder = ImmutableList.CreateBuilder<Parameter>();

            for (var i = 0; i < syncParameters.Length; i++)
            {
                var asyncParameter = asyncParameters[i];
                var syncParameter = syncParameters[i];

                var (constructedAsyncParam, constructedSyncParam) = BuildParameter(
                    sourceType,
                    operationName,
                    asyncParameter,
                    syncParameter,
                    identifierBuilder);

                asyncParametersBuilder.Add(constructedAsyncParam);
                syncParametersBuilder.Add(constructedSyncParam);
            }

            if (asyncParameters.Length == syncParameters.Length + 1
                && asyncParameters[^1].ParameterType == typeof(CancellationToken))
            {
                asyncParametersBuilder.Add(Parameter.Default(asyncParameters[^1].Name!, async (writer, variableName) =>
                {
                    await writer.WriteLineAsync(
                        FormatVariableDefinition(variableName, "CancellationToken.None")).ConfigureAwait(false);
                }));
            }

            return new ParameterListPair(
                new ParameterList(asyncParametersBuilder.ToImmutable()),
                new ParameterList(syncParametersBuilder.ToImmutable()));
        }

        private ParameterPair BuildParameter(
            Type sourceType,
            string operationName,
            ParameterInfo asyncParameter,
            ParameterInfo syncParameter,
            UniqueIdentifierBuilder identifierBuilder)
        {

            foreach (var evaluator in _evaluators)
            {
                if (evaluator.TryEvaluate(sourceType, operationName, asyncParameter, syncParameter, identifierBuilder, out var result))
                {
                    return result.Value;
                }
            }

            throw new InvalidOperationException(
                $"Unable to construct a parameter pair for async type { TypeHelper.FormatCSharpTypeName(asyncParameter.ParameterType) } and sync type { TypeHelper.FormatCSharpTypeName(syncParameter.ParameterType) }.");
        }

        private static string FormatVariableDefinition(string name, string value)
        {
            return $"            var {name} = {value};";
        }

        private string FormatVariableDefinition(string name, string value, Type type)
        {
            return $"            {TypeHelper.FormatCSharpTypeName(type, _knownNamespaces.Namespaces)} {name} = {value};";
        }
    }
}
