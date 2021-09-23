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
    internal sealed class LambdaParameterEvaluator : ParameterEvaluatorBase
    {
        public LambdaParameterEvaluator(
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

            var asyncParameterIsExpression = true;
            var syncParameterIsExpression = true;
            Type? asyncDelegateType, syncDelegateType;

            if (TypeHelper.IsDelegate(asyncParamType))
            {
                asyncDelegateType = asyncParamType;
                asyncParameterIsExpression = false;
            }
            else if (!TypeHelper.IsLambdaExpression(asyncParamType, out asyncDelegateType))
            {
                return false;
            }

            if (TypeHelper.IsDelegate(syncParamType))
            {
                syncDelegateType = syncParamType;
                syncParameterIsExpression = false;
            }
            else if (!TypeHelper.IsLambdaExpression(syncParamType, out syncDelegateType))
            {
                return false;
            }

            var singleDefinition = asyncDelegateType == syncDelegateType && asyncParameterIsExpression == syncParameterIsExpression;

            if (!TryConstructDelegateOrLambdaExpression(
                sourceType,
                syncDelegateType,
                prefix: null,
                syncParameterIsExpression,
                syncParameter.Name!,
                operationName,
                singleDefinition ? identifierBuilder : null,
                out var syncParamDefinition))
            {
                return false;
            }

            Parameter? asyncParamDefinition;

            // We only need a single variable definition
            if (singleDefinition)
            {
                asyncParamDefinition = syncParamDefinition;
                syncParamDefinition = Parameter.Default(asyncParamDefinition.Name);
            }
            else if (!TryConstructDelegateOrLambdaExpression(
                sourceType,
                asyncDelegateType,
                prefix: "async",
                asyncParameterIsExpression,
                asyncParameter.Name!,
                 operationName,
                identifierBuilder,
                out asyncParamDefinition))
            {
                return false;
            }

            result = new ParameterPair(asyncParamDefinition, syncParamDefinition);
            return true;
        }

        private bool TryConstructDelegateOrLambdaExpression(
           Type sourceType,
           Type delegateType,
           string? prefix,
           bool isExpression,
           string paramName,
           string operationName,
           UniqueIdentifierBuilder? identifierBuilder,
           [NotNullWhen(true)] out Parameter? result)
        {
            var builder = new LambdaParameterBuilder(
                KnownNamespaces, sourceType, delegateType, prefix, isExpression, paramName, operationName, identifierBuilder);

            return builder.TryBuild(out result);

            //result = null;

            //var method = delegateType.GetMethod("Invoke")!;
            //var returnType = method.ReturnType;
            //var parameters = method.GetParameters();
            //var isAsync = true;

            //if (!TypeHelper.IsValueTaskType(returnType, out var resultType))
            //{
            //    resultType = returnType;
            //    isAsync = false;
            //}

            //var parameterTypes = parameters.Select(p => p.ParameterType).ToArray();
            //var parameterTypesWithoutCancellation = parameterTypes;
            //var hasCancellation = false;

            //if (isAsync && parameterTypes.Length > 0 && parameterTypes[^1] == typeof(CancellationToken))
            //{
            //    parameterTypesWithoutCancellation = parameterTypes[..^1];
            //    hasCancellation = true;
            //}

            //var variableType = isExpression ? TypeHelper.GetExpressionType(delegateType) : delegateType;

            //Type? elementType;

            // We support delegates and lambda expressions that fall into one of the following buckets
            // where (1) to (3) can have an index parameter

            // (1)   Predicate (source [, index]) -> bool
            // (1.1) Expression<Func<TSource, bool>> predicate
            // (1.2) Expression<Func<TSource, int, bool>> predicate

            // (2)   Ordinary selector (source [, index]) -> result
            // (2.1) Expression<Func<TSource, TResult>> selector
            // /2.2) Expression<Func<TSource, int, TResult>> selector

            // (3)   Multi values selector (source [, index]) -> collection
            // (3.1) Expression<Func<TSource, IAsyncEnumerable<TResult>>> selector
            // (3.2) Expression<Func<TSource, int, IAsyncEnumerable<TResult>>> selector

            // (4) Group selector (key, collection) -> group
            //     Expression<Func<TKey, IAsyncEnumerable<TSource>, TResult>> resultSelector

            // (5) Ordinary selector with 2 inputs (source1, source2) -> result
            //     Expression<Func<TFirst, TSecond, TResult>> selector

            //if (resultType == typeof(bool) && parameterTypesWithoutCancellation.Length > 0)
            //{
            //    var hasIndex = parameterTypesWithoutCancellation.Length > 1
            //        && parameterTypesWithoutCancellation[1] == typeof(int);

            //    var predicateSourceType = parameterTypesWithoutCancellation[0];
            //    string resultValue;

            //    if (TypeHelper.IsIntegratedNumericType(predicateSourceType))
            //    {
            //        resultValue = "p > 3";
            //    }
            //    else if (TypeHelper.IsNullableIntegratedNumericType(predicateSourceType, out var underlyingType))
            //    {
            //        resultValue = "p != null && p > 3";
            //    }
            //    else
            //    {
            //        return false; // TODO: Check if this is another type of delegate.
            //    }

            //    if (hasIndex)
            //    {
            //        resultValue = resultValue + "&& i < 10";
            //    }

            //    identifierBuilder?.WithParameter(paramName, hasIndex ? "WithIndexed" : string.Empty);
            //    result = new LambdaParameter(
            //        KnownNamespaces,
            //        paramName,
            //        resultType,
            //        delegateType,
            //        isAsync,
            //        hasCancellation,
            //        hasIndex,
            //        isExpression,
            //        builder => builder.Append(resultValue));

            //}

            // Predicate
            //if (resultType == typeof(bool)
            //    && parameterTypesWithoutCancellation.Length is 1
            //    && parameterTypesWithoutCancellation[0] == sourceType)
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(p > 3);").ConfigureAwait(false);
            //        });

            //        return true;
            //    }

            //    if (TypeHelper.IsNullableType(sourceType, out var underlyingType) && TypeHelper.IsIntegratedNumericType(underlyingType))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(p != null && p > 3);").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Predicate with index
            //if (resultType == typeof(bool)
            //    && parameterTypesWithoutCancellation.Length is 2
            //    && parameterTypesWithoutCancellation[0] == sourceType
            //    && parameterTypesWithoutCancellation[1] == typeof(int))
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType))
            //    {
            //        identifierBuilder?.WithParameter(paramName, "WithIndexed");

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p, i{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(p > 3 && i < 10);").ConfigureAwait(false);
            //        });

            //        return true;
            //    }

            //    if (TypeHelper.IsNullableType(sourceType, out var underlyingType) && TypeHelper.IsIntegratedNumericType(underlyingType))
            //    {
            //        identifierBuilder?.WithParameter(paramName, "WithIndexed");

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p, i{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(p != null && p > 3 && i < 10);").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Selector with result-type == source-type
            //if (resultType == sourceType
            //    && parameterTypesWithoutCancellation.Length is 1
            //    && parameterTypesWithoutCancellation[0] == sourceType)
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(p + 3);").ConfigureAwait(false);
            //        });

            //        return true;
            //    }

            //    if (TypeHelper.IsNullableType(sourceType, out var underlyingType) && TypeHelper.IsIntegratedNumericType(underlyingType))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(p + 3);").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Selector with fixed numeric result type
            //if (TypeHelper.IsIntegratedNumericType(resultType)
            //    && parameterTypesWithoutCancellation.Length is 1
            //    && parameterTypesWithoutCancellation[0] == sourceType)
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType))
            //    {
            //        identifierBuilder?.WithParameter(paramName, resultType.Name);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(({TypeHelper.FormatCSharpTypeName(resultType)})(p + 3));").ConfigureAwait(false);
            //        });

            //        return true;
            //    }

            //    if (TypeHelper.IsNullableType(sourceType, out var underlyingType) && TypeHelper.IsIntegratedNumericType(underlyingType))
            //    {
            //        identifierBuilder?.WithParameter(paramName, resultType.Name);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(({TypeHelper.FormatCSharpTypeName(resultType)})(p == null ? 0 : p + 3));").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Selector with fixed nullable numeric result type
            //if (TypeHelper.IsNullableIntegratedNumericType(resultType, out var primitiveType)
            //    && parameterTypesWithoutCancellation.Length is 1
            //    && parameterTypesWithoutCancellation[0] == sourceType)
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType) || TypeHelper.IsNullableIntegratedNumericType(sourceType))
            //    {
            //        identifierBuilder?.WithParameter(paramName, "Nullable" + primitiveType.Name);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(({TypeHelper.FormatCSharpTypeName(resultType)})(p + 3));").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Simple Accumulator: (TSource, TSource) -> TSource 
            //if (resultType == sourceType
            //    && parameterTypesWithoutCancellation.Length is 2
            //    && parameterTypesWithoutCancellation[0] == sourceType
            //    && parameterTypesWithoutCancellation[1] == sourceType)
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType) || TypeHelper.IsNullableIntegratedNumericType(sourceType))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p, q{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(({TypeHelper.FormatCSharpTypeName(resultType)})((p + q) / 2));").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Selector
            //if (parameterTypesWithoutCancellation.Length is 1
            //    && parameterTypesWithoutCancellation[0] == sourceType)
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType) && (TypeHelper.IsIntegratedNumericType(resultType) || TypeHelper.IsNullableIntegratedNumericType(resultType)))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(({TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)})(p + 3));").ConfigureAwait(false);
            //        });

            //        return true;
            //    }

            //    if (TypeHelper.IsNullableIntegratedNumericType(sourceType) && TypeHelper.IsNullableIntegratedNumericType(resultType))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(({TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)})(p + 3));").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Selector with index
            //if (parameterTypesWithoutCancellation.Length is 2
            //    && parameterTypesWithoutCancellation[0] == sourceType
            //    && parameterTypesWithoutCancellation[1] == typeof(int))
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType) && (TypeHelper.IsIntegratedNumericType(resultType) || TypeHelper.IsNullableIntegratedNumericType(resultType)))
            //    {
            //        identifierBuilder?.WithParameter(paramName, "WithIndexed");

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p, i,{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(({TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)})(p + 3));").ConfigureAwait(false);
            //        });

            //        return true;
            //    }

            //    if (TypeHelper.IsNullableIntegratedNumericType(sourceType) && TypeHelper.IsNullableIntegratedNumericType(resultType))
            //    {
            //        identifierBuilder?.WithParameter(paramName, "WithIndexed");

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p, i,{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(({TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)})(p + 3));").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Async Select many
            //if (TypeHelper.IsAsyncEnumerableType(resultType, out elementType)
            //    && parameterTypesWithoutCancellation.Length is 1
            //    && parameterTypesWithoutCancellation[0] == sourceType)
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType) && (TypeHelper.IsIntegratedNumericType(elementType) || TypeHelper.IsNullableIntegratedNumericType(elementType)))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {

            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(new[] {{ ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 3), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p - 1), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 1) }}.ToAsyncEnumerable());").ConfigureAwait(false);
            //        });

            //        return true;
            //    }

            //    if (TypeHelper.IsNullableIntegratedNumericType(sourceType) && TypeHelper.IsNullableIntegratedNumericType(elementType))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(new[] {{ ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 3), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p - 1), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 1) }}.ToAsyncEnumerable());").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Async Select many with index
            //if (TypeHelper.IsAsyncEnumerableType(resultType, out elementType)
            //    && parameterTypesWithoutCancellation.Length is 2
            //    && parameterTypesWithoutCancellation[0] == sourceType
            //    && parameterTypesWithoutCancellation[1] == typeof(int))
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType) && (TypeHelper.IsIntegratedNumericType(elementType) || TypeHelper.IsNullableIntegratedNumericType(elementType)))
            //    {
            //        identifierBuilder?.WithParameter(paramName, "WithIndexed");

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p, i,{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(new[] {{ ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 3), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p - 1), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 1) }}.ToAsyncEnumerable());").ConfigureAwait(false);
            //        });

            //        return true;
            //    }

            //    if (TypeHelper.IsNullableIntegratedNumericType(sourceType) && TypeHelper.IsNullableIntegratedNumericType(elementType))
            //    {
            //        identifierBuilder?.WithParameter(paramName, "WithIndexed");

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p, i,{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(new[] {{ ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 3), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p - 1), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 1) }}.ToAsyncEnumerable());").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Sync Select many
            //if (TypeHelper.IsEnumerableType(resultType, out elementType)
            //    && parameterTypesWithoutCancellation.Length is 1
            //    && parameterTypesWithoutCancellation[0] == sourceType)
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType) && (TypeHelper.IsIntegratedNumericType(elementType) || TypeHelper.IsNullableIntegratedNumericType(elementType)))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {

            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(new[] {{ ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 3), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p - 1), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 1) }}.ToEnumerable());").ConfigureAwait(false);
            //        });

            //        return true;
            //    }

            //    if (TypeHelper.IsNullableIntegratedNumericType(sourceType) && TypeHelper.IsNullableIntegratedNumericType(elementType))
            //    {
            //        identifierBuilder?.WithParameter(paramName);

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(new[] {{ ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 3), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p - 1), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 1) }}.ToEnumerable());").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //// Sync Select many with index
            //if (TypeHelper.IsEnumerableType(resultType, out elementType)
            //    && parameterTypesWithoutCancellation.Length is 2
            //    && parameterTypesWithoutCancellation[0] == sourceType
            //    && parameterTypesWithoutCancellation[1] == typeof(int))
            //{
            //    if (TypeHelper.IsIntegratedNumericType(sourceType) && (TypeHelper.IsIntegratedNumericType(elementType) || TypeHelper.IsNullableIntegratedNumericType(elementType)))
            //    {
            //        identifierBuilder?.WithParameter(paramName, "WithIndexed");

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p, i,{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(new[] {{ ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 3), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p - 1), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 1) }}.ToAsyncEnumerable());").ConfigureAwait(false);
            //        });

            //        return true;
            //    }

            //    if (TypeHelper.IsNullableIntegratedNumericType(sourceType) && TypeHelper.IsNullableIntegratedNumericType(elementType))
            //    {
            //        identifierBuilder?.WithParameter(paramName, "WithIndexed");

            //        result = Parameter.Default(paramName, prefix, async (writer, variableName) =>
            //        {
            //            await writer.WriteLineAsync($"            {TypeHelper.FormatCSharpTypeName(variableType, KnownNamespaces.Namespaces)} {variableName} = (p, i,{(hasCancellation ? ", cancellation" : "")}) => {(isAsync ? $"new ValueTask<{TypeHelper.FormatCSharpTypeName(resultType, KnownNamespaces.Namespaces)}>" : "")}(new[] {{ ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 3), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p - 1), ({TypeHelper.FormatCSharpTypeName(elementType, KnownNamespaces.Namespaces)})(p + 1) }}.ToAsyncEnumerable());").ConfigureAwait(false);
            //        });

            //        return true;
            //    }
            //}

            //return false;
        }
    }
}
