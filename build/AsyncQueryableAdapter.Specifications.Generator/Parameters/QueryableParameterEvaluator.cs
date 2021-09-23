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
using System.Linq;
using System.Reflection;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Specifications.Generator.Parameters
{
    internal sealed class QueryableParameterEvaluator : ParameterEvaluatorBase
    {
        public QueryableParameterEvaluator(
            KnownNamespaces knownNamespaceProvider,
            KnownCollectionTypes knownCollectionTypes) : base(knownNamespaceProvider, knownCollectionTypes)
        { }

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

            int? limit = null;

            // Limit the source of Single and SingleOrDefault operations, but only if there is not predicate
            if (string.Equals(operationName, "Single", StringComparison.Ordinal)
                || string.Equals(operationName, "SingleOrDefault", StringComparison.Ordinal))
            {
                // Use the sync method, here as the async method can have a cancellation-token
                if ((syncParameter.Member as MethodInfo)!.GetParameters().Length == 1)
                {
                    limit = 1;
                }
            }

            if (TryEvaluateKnownType(
                operationName,
                asyncParamType,
                syncParamType,
                asyncParameter.Name!,
                syncParameter.Name!,
                identifierBuilder,
                transform: null,
                limit,
                out result))
            {
                return true;
            }

            if (typeof(IAsyncQueryable<object>).IsAssignableTo(asyncParamType) &&
                typeof(IQueryable<object>).IsAssignableTo(syncParamType))
            {
                if (string.Equals(operationName, "OfType", StringComparison.Ordinal))
                {
                    if (!string.Equals(asyncParameter.Name, "source", StringComparison.Ordinal))
                    {
                        identifierBuilder.WithParameter(asyncParameter.Name!);
                    }

                    var knownPrimitiveCollectionTypes = KnownCollectionTypes.CollectionTypes.ToArray();

                    var asyncParamDefinition = Parameter.Default(asyncParameter.Name!, "async", async (writer, variableName) =>
                    {
                        for (var i = 0; i < knownPrimitiveCollectionTypes.Length; i++)
                        {
                            await writer.WriteLineAsync($"            var {variableName}Part{i + 1} = queryAdapter.GetAsyncQueryable<{TypeHelper.FormatCSharpTypeName(knownPrimitiveCollectionTypes[i], KnownNamespaces.Namespaces)}>().Select(p => (object)p);").ConfigureAwait(false);
                        }

                        await writer.WriteAsync($"            var {variableName} = ").ConfigureAwait(false);

                        for (var i = 0; i < knownPrimitiveCollectionTypes.Length; i++)
                        {
                            if (i == 0)
                            {
                                await writer.WriteAsync($"{variableName}Part{i + 1}").ConfigureAwait(false);
                            }
                            else
                            {
                                await writer.WriteAsync($".Concat({variableName}Part{i + 1})").ConfigureAwait(false);
                            }
                        }

                        await writer.WriteLineAsync($";").ConfigureAwait(false);
                    });

                    var syncParamDefinition = Parameter.Default(syncParameter.Name!, async (writer, variableName) =>
                    {
                        for (var i = 0; i < knownPrimitiveCollectionTypes.Length; i++)
                        {
                            await writer.WriteLineAsync($"            var {variableName}Part{i + 1} = GetQueryable<{TypeHelper.FormatCSharpTypeName(knownPrimitiveCollectionTypes[i], KnownNamespaces.Namespaces)}>().Select(p => (object)p);").ConfigureAwait(false);
                        }

                        await writer.WriteAsync($"            var {variableName} = ").ConfigureAwait(false);

                        for (var i = 0; i < knownPrimitiveCollectionTypes.Length; i++)
                        {
                            if (i == 0)
                            {
                                await writer.WriteAsync($"{variableName}Part{i + 1}").ConfigureAwait(false);
                            }
                            else
                            {
                                await writer.WriteAsync($".Concat({variableName}Part{i + 1})").ConfigureAwait(false);
                            }
                        }

                        await writer.WriteLineAsync($";").ConfigureAwait(false);
                    });

                    result = new ParameterPair(asyncParamDefinition, syncParamDefinition);
                    return true;
                }
                else if (string.Equals(operationName, "Cast", StringComparison.Ordinal))
                {
                    // Only include the type of collection that is casted to, to prevent exceptions
                    var asyncResultType = (asyncParameter.Member as MethodInfo)!.ReturnType;
                    var syncResultType = (syncParameter.Member as MethodInfo)!.ReturnType;

                    if (TryEvaluateKnownType(
                        operationName,
                        asyncResultType,
                        syncResultType,
                        asyncParameter.Name!,
                        syncParameter.Name!,
                        identifierBuilder: null,
                        transform: "p => (object)p",
                        limit: null,
                        out result))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool TryEvaluateKnownType(
            string operationName,
            Type asyncParamType,
            Type syncParamType,
            string asyncParamName,
            string syncParamName,
            UniqueIdentifierBuilder? identifierBuilder,
            string? transform,
            int? limit,
            [NotNullWhen(true)] out ParameterPair? result)
        {
            result = null;

            if (!TypeHelper.IsAsyncQueryableType(asyncParamType, allowNonGeneric: true, out var asyncElementType)
                && !TypeHelper.IsAsyncEnumerableType(asyncParamType, out asyncElementType))
            {
                return false;
            }

            if (!TypeHelper.IsQueryableType(syncParamType, allowNonGeneric: true, out var syncElementType)
                && !TypeHelper.IsEnumerableType(syncParamType, allowNonGeneric: true, out syncElementType))
            {
                return false;
            }

            string? transform0 = null;

            if (string.Equals(operationName, "ToDictionary", StringComparison.Ordinal))
            {
                if (TypeHelper.IsNullableType(asyncElementType, out var underlyingType))
                {
                    transform0 = $"p => ({TypeHelper.FormatCSharpTypeName(asyncElementType, KnownNamespaces.Namespaces)})p";
                    asyncElementType = underlyingType;
                }

                if (TypeHelper.IsNullableType(syncElementType, out underlyingType))
                {
                    syncElementType = underlyingType;
                }
            }

            if (!KnownCollectionTypes.CollectionTypes.Contains(asyncElementType)
                || !KnownCollectionTypes.CollectionTypes.Contains(syncElementType))
            {
                return false;
            }

            if (!string.Equals(asyncParamName, "source", StringComparison.Ordinal))
            {
                identifierBuilder?.WithParameter(asyncParamName);
            }

            var asyncParamDefinition = Parameter.Default(asyncParamName, "async", async (writer, variableName) =>
            {
                var value = $"queryAdapter.GetAsyncQueryable<{TypeHelper.FormatCSharpTypeName(asyncElementType, KnownNamespaces.Namespaces)}>()";

                if (!string.IsNullOrEmpty(transform0))
                {
                    value += $".Select({transform0})";
                }

                if (!string.IsNullOrEmpty(transform))
                {
                    value += $".Select({transform})";
                }

                if (limit is not null)
                {
                    value += $".Take({limit})";
                }

                await writer.WriteLineAsync(FormatVariableDefinition(variableName, value)).ConfigureAwait(false);
            });

            var syncParamDefinition = Parameter.Default(syncParamName, async (writer, variableName) =>
            {
                var value = $"GetQueryable<{TypeHelper.FormatCSharpTypeName(syncElementType, KnownNamespaces.Namespaces)}>()";

                if (!string.IsNullOrEmpty(transform0))
                {
                    value += $".Select({transform0})";
                }

                if (!string.IsNullOrEmpty(transform))
                {
                    value += $".Select({transform})";
                }

                if (limit is not null)
                {
                    value += $".Take({limit})";
                }

                await writer.WriteLineAsync(FormatVariableDefinition(variableName, value)).ConfigureAwait(false);
            });

            result = new ParameterPair(asyncParamDefinition, syncParamDefinition);
            return true;
        }
    }
}
