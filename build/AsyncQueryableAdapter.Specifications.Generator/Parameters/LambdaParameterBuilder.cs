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
using System.Threading;
using AsyncQueryableAdapter.Utils;
using AsyncQueryableAdapterPrototype.Tests.TestTypes;

namespace AsyncQueryableAdapter.Specifications.Generator.Parameters
{
    internal sealed class LambdaParameterBuilder
    {
        private readonly KnownNamespaces _knownNamespaces;

        private readonly Type _variableType;
        private readonly ReadOnlyMemory<Type> _parameterTypes;
        private readonly bool _hasCancellation;
        private readonly Type _resultType;
        private readonly bool _isAsync;

        public LambdaParameterBuilder(
           KnownNamespaces knownNamespaces,
           Type sourceType,
           Type delegateType,
           string? prefix,
           bool isExpression,
           string paramName,
           string operationName,
           UniqueIdentifierBuilder? identifierBuilder)
        {
            if (knownNamespaces is null)
                throw new ArgumentNullException(nameof(knownNamespaces));

            _knownNamespaces = knownNamespaces;
            SourceType = sourceType;
            DelegateType = delegateType;
            Prefix = prefix;
            IsExpression = isExpression;
            ParamName = paramName;
            OperationName = operationName;
            IdentifierBuilder = identifierBuilder;

            var method = delegateType.GetMethod("Invoke")!;
            var returnType = method.ReturnType;
            var parameters = method.GetParameters();
            _isAsync = true;

            if (!TypeHelper.IsValueTaskType(returnType, out var resultType))
            {
                resultType = returnType;
                _isAsync = false;
            }

            _resultType = resultType;

            var parameterTypes = parameters.Select(p => p.ParameterType).ToArray();
            var parameterTypesWithoutCancellation = parameterTypes;
            _hasCancellation = false;

            if (_isAsync && parameterTypes.Length > 0 && parameterTypes[^1] == typeof(CancellationToken))
            {
                parameterTypesWithoutCancellation = parameterTypes[..^1];
                _hasCancellation = true;
            }

            _variableType = isExpression ? TypeHelper.GetExpressionType(delegateType) : delegateType;
            _parameterTypes = parameterTypesWithoutCancellation;
        }

        public Type SourceType { get; }

        public Type DelegateType { get; }

        public string? Prefix { get; }

        public bool IsExpression { get; }

        public string ParamName { get; }

        public string VariableName
            => string.IsNullOrEmpty(Prefix) ? ParamName : Prefix + ParamName.FirstRuneToUpperCase();

        public string OperationName { get; }

        public UniqueIdentifierBuilder? IdentifierBuilder { get; }

        public bool TryBuild([NotNullWhen(true)] out Parameter? result)
        {
            // We support delegates and lambda expressions that fall into one of the following buckets
            // where (1) to (3) can have an index parameter

            // (1)   Predicate (source [, index]) -> bool
            // (1.1) Expression<Func<TSource, bool>> predicate
            // (1.2) Expression<Func<TSource, int, bool>> predicate

            // (2)   Ordinary selector (source [, index]) -> result
            // (2.1) Expression<Func<TSource, TResult>> selector
            // (2.2) Expression<Func<TSource, int, TResult>> selector

            // (3)   Multi values selector (source [, index]) -> collection
            // (3.1) Expression<Func<TSource, IAsyncEnumerable<TResult>>> selector
            // (3.2) Expression<Func<TSource, int, IAsyncEnumerable<TResult>>> selector

            // (4) Group selector (key, collection) -> group
            //     Expression<Func<TKey, IAsyncEnumerable<TSource>, TResult>> resultSelector

            // (5) Ordinary selector with 2 inputs (source1, source2) -> result
            //     Expression<Func<TFirst, TSecond, TResult>> selector

            if (TryBuildPredicate(out result))
            {
                return true;
            }

            if (TryBuildSelector(out result))
            {
                return true;
            }

            if (TryBuildMultiValuesSelector(out result))
            {
                return true;
            }

            if (TryBuildGroupSelector(out result))
            {
                return true;
            }

            if (TryBuildMultiSourceSelector(out result))
            {
                return true;
            }

            return false;
        }

        private bool TryBuildPredicate([NotNullWhen(true)] out Parameter? result)
        {
            result = null;

            if (!IsPredicate(out var hasIndex))
            {
                return false;
            }

            var sourceType = _parameterTypes.Span[0];
            string resultValue;

            if (TypeHelper.IsIntegratedNumericType(sourceType))
            {
                resultValue = "p > 3";
            }
            else if (TypeHelper.IsNullableIntegratedNumericType(sourceType, out var underlyingType))
            {
                resultValue = "p != null && p > 3";
            }
            else
            {
                return false; // TODO: Check if this is another type of delegate.
            }

            if (hasIndex)
            {
                resultValue = resultValue + "&& i < 10";
            }

            IdentifierBuilder?.WithParameter(ParamName, hasIndex ? "WithIndexed" : string.Empty);
            result = new LambdaParameter(
                _knownNamespaces,
                VariableName,
                _resultType,
                DelegateType,
                _isAsync,
                _hasCancellation,
                hasIndex,
                IsExpression,
                builder => builder.Append(resultValue));

            return true;

        }

        private bool IsPredicate(out bool hasIndex)
        {
            hasIndex = false;

            if (_resultType != typeof(bool))
                return false;

            if (!string.Equals(ParamName, "predicate", StringComparison.Ordinal))
                return false;

            if (_parameterTypes.Length is 1)
                return true;

            hasIndex = true;

            if (_parameterTypes.Length is not 2)
                return false;

            if (_parameterTypes.Span[1] != typeof(int))
                return false;

            return true;
        }

        private bool TryBuildSelector([NotNullWhen(true)] out Parameter? result)
        {
            result = null;

            if (!IsSelector(out var hasIndex))
            {
                return false;
            }

            var sourceType = _parameterTypes.Span[0];
            var underlyingSourceType = sourceType;
            var isNullableSourceType = false;

            if (TypeHelper.IsNullableType(sourceType, out var underlyingType))
            {
                underlyingSourceType = underlyingType;
                isNullableSourceType = true;
            }

            var underlyingResultType = _resultType;
            var isNullableResultType = false;

            if (TypeHelper.IsNullableType(_resultType, out underlyingType))
            {
                underlyingResultType = underlyingType;
                isNullableResultType = true;
            }

            string resultValue;
            if (TypeHelper.IsIntegratedNumericType(underlyingSourceType)
                && TypeHelper.IsIntegratedNumericType(underlyingResultType))
            {
                resultValue = "p + 3";

                if (isNullableSourceType && !isNullableResultType)
                {
                    resultValue = $"p == null ? {FormatLiteral(7)} : ({TypeHelper.FormatCSharpTypeName(underlyingResultType, _knownNamespaces.Namespaces)})({resultValue})";
                }

                if (hasIndex)
                {
                    resultValue = $"i % 3 == 0 ? {FormatLiteral(3)} : ({resultValue})";
                }
            }
            else
            {
                return false;
            }

            resultValue = TransformToTargetType(resultValue, sourceType);

            var parameterModifier = hasIndex ? "WithIndexed" : string.Empty;
            parameterModifier += (isNullableResultType ? "Nullable" : "") + underlyingResultType.Name;

            IdentifierBuilder?.WithParameter(ParamName, parameterModifier);
            result = new LambdaParameter(
                _knownNamespaces,
                VariableName,
                _resultType,
                DelegateType,
                _isAsync,
                _hasCancellation,
                hasIndex,
                IsExpression,
                builder => builder.Append(resultValue));

            return true;
        }

        private bool IsSelector(out bool hasIndex)
        {
            hasIndex = false;

            if (IsPredicate(out _))
                return false;

            if (_parameterTypes.Length is 1)
                return true;

            hasIndex = true;

            // If the selector is indexed, the index must be of type Int32 and the operation name must be
            // "Select" such that we can differentiate between cases (2.2) and (5)
            if (_parameterTypes.Length is not 2)
                return false;

            if (_parameterTypes.Span[1] != typeof(int))
                return false;

            if (!string.Equals(OperationName, "Select", StringComparison.Ordinal))
                return false;

            return true;
        }

        private bool TryBuildMultiValuesSelector([NotNullWhen(true)] out Parameter? result)
        {
            result = null;

            if (!IsMultiValuesSelector(out var resultElementType, out var isAsyncEnumerable, out var hasIndex))
            {
                return false;
            }

            // 99% the same as in the selector case
            var sourceType = _parameterTypes.Span[0];
            var underlyingSourceType = sourceType;
            var isNullableSourceType = false;

            if (TypeHelper.IsNullableType(sourceType, out var underlyingType))
            {
                underlyingSourceType = underlyingType;
                isNullableSourceType = true;
            }

            var underlyingResultType = resultElementType;
            var isNullableResultType = false;

            if (TypeHelper.IsNullableType(resultElementType, out underlyingType))
            {
                underlyingResultType = underlyingType;
                isNullableResultType = true;
            }

            string resultValue;
            if (TypeHelper.IsIntegratedNumericType(underlyingSourceType))
            {
                if (TypeHelper.IsIntegratedNumericType(underlyingResultType))
                {
                    resultValue = $"new {TypeHelper.FormatCSharpTypeName(resultElementType, _knownNamespaces.Namespaces)}[] {{ { TransformToTargetType("p + 3", sourceType, resultType: resultElementType) }, { TransformToTargetType("p - 1", sourceType, resultType: resultElementType) }, { TransformToTargetType("p + 1", sourceType, resultType: resultElementType) } }}";
                }
                else
                {
                    return false;
                }

                if (isNullableSourceType && !isNullableResultType)
                {
                    resultValue = $"p == null ? new {TypeHelper.FormatCSharpTypeName(resultElementType, _knownNamespaces.Namespaces)}[] {{ { FormatLiteral(7, underlyingResultType) } }} : ({resultValue})";
                }

                if (hasIndex)
                {
                    resultValue = $"i % 3 == 0 ? new {TypeHelper.FormatCSharpTypeName(resultElementType, _knownNamespaces.Namespaces)}[] {{ { FormatLiteral(3, underlyingResultType) } }} : ({resultValue})";
                }
            }
            else
            {
                return false;
            }

            if (isAsyncEnumerable)
            {
                resultValue = $"({resultValue}).ToAsyncEnumerable()";
            }

            var parameterModifier = hasIndex ? "WithIndexed" : string.Empty;
            parameterModifier += (isNullableResultType ? "Nullable" : "") + underlyingResultType.Name;

            IdentifierBuilder?.WithParameter(ParamName, parameterModifier);
            result = new LambdaParameter(
                _knownNamespaces,
                VariableName,
                _resultType,
                DelegateType,
                _isAsync,
                _hasCancellation,
                hasIndex,
                IsExpression,
                builder => builder.Append(resultValue));

            return true;
        }

        private bool IsMultiValuesSelector(
            [NotNullWhen(true)] out Type? resultElementType,
            out bool isAsyncEnumerable,
            out bool hasIndex)
        {
            hasIndex = false;
            isAsyncEnumerable = true;

            if (!TypeHelper.IsAsyncEnumerableType(_resultType, out resultElementType))
            {
                isAsyncEnumerable = false;

                if (!TypeHelper.IsEnumerableType(_resultType, out resultElementType))
                {
                    return false;
                }
            }

            if (_parameterTypes.Length is 1)
                return true;

            hasIndex = true;

            if (_parameterTypes.Length is not 2)
                return false;

            if (_parameterTypes.Span[1] != typeof(int))
                return false;

            return true;
        }

        private bool TryBuildGroupSelector([NotNullWhen(true)] out Parameter? result)
        {
            result = null;

            if (!IsGroupSelector(out var sourceElementType, out var isAsyncEnumerable))
            {
                return false;
            }

            var keyType = _parameterTypes.Span[0];

            if (TypeHelper.IsAsyncGroupingType(_resultType, keyType, sourceElementType, exactMatch: false)
                || _resultType == typeof(CustomGrouping<,>).MakeGenericType(keyType, sourceElementType))
            {
                IdentifierBuilder?.WithParameter(ParamName);
                result = new LambdaParameter(
                    _knownNamespaces,
                    VariableName,
                    _resultType,
                    DelegateType,
                    _isAsync,
                    _hasCancellation,
                    hasIndex: false,
                    IsExpression,
                    builder => builder.Append("(p, elements) => CustomGrouping.Create(p, elements)"),
                    new[] { "elements" });

                return true;
            }

            var underlyingKeyType = keyType;
            var isNullableKeyType = false;

            if (TypeHelper.IsNullableType(keyType, out var underlyingType))
            {
                underlyingKeyType = underlyingType;
                isNullableKeyType = true;
            }

            var underlyingResultType = _resultType;
            var isNullableResultType = false;

            if (TypeHelper.IsNullableType(_resultType, out underlyingType))
            {
                underlyingResultType = underlyingType;
                isNullableResultType = true;
            }

            // TODO Can we somehow use the values from the collection?

            string resultValue;
            if (TypeHelper.IsIntegratedNumericType(underlyingKeyType)
                && TypeHelper.IsIntegratedNumericType(underlyingResultType))
            {
                resultValue = "p + 3";

                if (isNullableKeyType && !isNullableResultType)
                {
                    resultValue = $"p == null ? {FormatLiteral(7)} : ({resultValue})";
                }
            }
            else
            {
                return false;
            }

            resultValue = TransformToTargetType(resultValue, keyType);

            var parameterModifier = (isNullableResultType ? "Nullable" : "") + underlyingResultType.Name;

            IdentifierBuilder?.WithParameter(ParamName, parameterModifier);
            result = new LambdaParameter(
                _knownNamespaces,
                VariableName,
                _resultType,
                DelegateType,
                _isAsync,
                _hasCancellation,
                hasIndex: false,
                IsExpression,
                builder => builder.Append(resultValue),
                new[] { "elements" });

            return true;
        }

        private bool IsGroupSelector([NotNullWhen(true)] out Type? sourceElementType, out bool isAsyncEnumerable)
        {
            sourceElementType = null;
            isAsyncEnumerable = true;

            if (_parameterTypes.Length is not 2)
                return false;

            if (!TypeHelper.IsAsyncEnumerableType(_parameterTypes.Span[1], out sourceElementType))
            {
                isAsyncEnumerable = false;

                if (!TypeHelper.IsEnumerableType(_parameterTypes.Span[1], out sourceElementType))
                {
                    return false;
                }
            }

            return true;
        }

        private bool TryBuildMultiSourceSelector([NotNullWhen(true)] out Parameter? result)
        {
            result = null;

            if (!IsMultiSourceSelector())
            {
                return false;
            }

            // 99% the same as in the selector case
            var source1Type = _parameterTypes.Span[0];
            var source2Type = _parameterTypes.Span[1];

            var underlyingSource1Type = source1Type;
            var isNullableSource1Type = false;

            if (TypeHelper.IsNullableType(source1Type, out var underlyingType))
            {
                underlyingSource1Type = underlyingType;
                isNullableSource1Type = true;
            }

            var underlyingSource2Type = source2Type;
            var isNullableSource2Type = false;

            if (TypeHelper.IsNullableType(source2Type, out underlyingType))
            {
                underlyingSource2Type = underlyingType;
                isNullableSource2Type = true;
            }

            var underlyingResultType = _resultType;
            var isNullableResultType = false;

            if (TypeHelper.IsNullableType(_resultType, out underlyingType))
            {
                underlyingResultType = underlyingType;
                isNullableResultType = true;
            }

            string resultValue;
            Type? operationResultType;
            if (TypeHelper.IsIntegratedNumericType(underlyingSource1Type)
                && TypeHelper.IsIntegratedNumericType(underlyingSource2Type))
            {
                operationResultType = TypeHelper.IntegratedNumericTypeArithmeticOperationResult(
                    underlyingSource1Type,
                    underlyingSource2Type);

                if (TypeHelper.IsIntegratedNumericType(underlyingResultType))
                {
                    resultValue = "p + 3 - q";
                }
                else
                {
                    return false;
                }

                if (isNullableSource1Type && !isNullableResultType)
                {
                    resultValue = $"p == null ? 3 - q : ({resultValue})";
                }

                if (isNullableSource2Type && !isNullableResultType)
                {
                    resultValue = $"q == null ? p + q : ({resultValue})";
                }
            }
            else
            {
                return false;
            }

            if (operationResultType is null)
            {
                return false;
            }

            resultValue = TransformToTargetType(resultValue, operationResultType);

            var parameterModifier = (isNullableResultType ? "Nullable" : "") + underlyingResultType.Name;

            IdentifierBuilder?.WithParameter(ParamName, parameterModifier);
            result = new LambdaParameter(
                _knownNamespaces,
                VariableName,
                _resultType,
                DelegateType,
                _isAsync,
                _hasCancellation,
                hasIndex: false,
                IsExpression,
                builder => builder.Append(resultValue),
                new[] { "q" });

            return true;
        }

        private bool IsMultiSourceSelector()
        {
            if (IsGroupSelector(out _, out _))
                return false;

            return _parameterTypes.Length is 2;
        }

        private string TransformToTargetType(string resultValue, Type sourceType, string? source = null, Type? resultType = null)
        {
            source ??= "p";
            resultType ??= _resultType;

            var underlyingSourceType = sourceType;
            var isNullableSourceType = false;

            if (TypeHelper.IsNullableType(sourceType, out var underlyingType))
            {
                underlyingSourceType = underlyingType;
                isNullableSourceType = true;
            }

            var underlyingResultType = resultType;
            var isNullableResultType = false;

            if (TypeHelper.IsNullableType(resultType, out underlyingType))
            {
                underlyingResultType = underlyingType;
                isNullableResultType = true;
            }

            if (isNullableResultType && isNullableSourceType)
            {
                if (!underlyingSourceType.IsAssignableTo(underlyingResultType))
                {
                    resultValue = $"{source} == null ? null : ({TypeHelper.FormatCSharpTypeName(underlyingResultType, _knownNamespaces.Namespaces)})({resultValue})";
                }
            }
            else if (!sourceType.IsAssignableTo(resultType))
            {
                resultValue = $"({TypeHelper.FormatCSharpTypeName(resultType, _knownNamespaces.Namespaces)})({resultValue})";
            }

            return resultValue;
        }

        private string FormatLiteral(int literal, Type? resultType = null)
        {
            resultType ??= _resultType;

            if (!TypeHelper.IsNullableType(resultType, out var underlyingResultType))
            {
                underlyingResultType = resultType;
            }

            var suffix = TypeHelper.GetIntegratedNumericTypeSuffix(resultType);

            if (suffix is not null)
            {
                return $"{literal}{suffix}";
            }

            return $"(({TypeHelper.FormatCSharpTypeName(underlyingResultType, _knownNamespaces.Namespaces)}){literal})";
        }
    }
}
