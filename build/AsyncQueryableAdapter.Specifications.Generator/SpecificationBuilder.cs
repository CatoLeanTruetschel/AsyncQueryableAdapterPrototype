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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Specifications.Generator.Parameters;
using AsyncQueryableAdapter.Specifications.Generator.Resources;
using AsyncQueryableAdapter.Specifications.Generator.Tests;
using AsyncQueryableAdapter.Utils;
using Microsoft.Extensions.Options;
using Nito.AsyncEx;
using static AsyncQueryableAdapter.Utils.TypeTranslationHelper;

namespace AsyncQueryableAdapter.Specifications.Generator
{
    internal sealed class SpecificationBuilder
    {
        private readonly KnownNamespaces _knownNamespaces;
        private readonly KnownCollectionTypes _knownCollectionTypes;
        private readonly ParametersBuilder _parametersBuilder;
        private readonly IOptions<ApplicationOptions> _optionsAccessor;
        private readonly IEnumerable<ITestCaseGenerator> _testCaseGenerators;
        private readonly Dictionary<string, StreamWriter> _writers = new();
        private readonly AsyncLazy<string> _specificationHeader;
        private readonly AsyncLazy<string> _specificationFooter;

        public SpecificationBuilder(
            KnownNamespaces knownNamespaces,
            KnownCollectionTypes knownCollectionTypes,
            ParametersBuilder parametersBuilder,
            IOptions<ApplicationOptions> optionsAccessor,
            IEnumerable<ITestCaseGenerator> testCaseGenerators)
        {
            if (knownNamespaces is null)
                throw new ArgumentNullException(nameof(knownNamespaces));

            if (knownCollectionTypes is null)
                throw new ArgumentNullException(nameof(knownCollectionTypes));

            if (parametersBuilder is null)
                throw new ArgumentNullException(nameof(parametersBuilder));

            if (optionsAccessor is null)
                throw new ArgumentNullException(nameof(optionsAccessor));

            if (testCaseGenerators is null)
                throw new ArgumentNullException(nameof(testCaseGenerators));

            if (testCaseGenerators.Any(p => p is null))
            {
                ThrowHelper.ThrowCollectionMustNotContainNullEntries(nameof(testCaseGenerators));
            }

            _knownNamespaces = knownNamespaces;
            _knownCollectionTypes = knownCollectionTypes;
            _parametersBuilder = parametersBuilder;
            _optionsAccessor = optionsAccessor;
            _testCaseGenerators = testCaseGenerators;
            _specificationHeader = new AsyncLazy<string>(
              () => ResourceHelper.ReadResourceAsync("SpecificationFileHeader.txt"));

            _specificationFooter = new AsyncLazy<string>(
                () => ResourceHelper.ReadResourceAsync("SpecificationFileFooter.txt"));
        }

        private async Task<StreamWriter> GetWriterAsync(string? operationName)
        {
            operationName ??= string.Empty;

            if (!_writers.TryGetValue(operationName, out var writer))
            {
                var fileName = "QueryAdapterSpecification.cs";

                if (operationName.Length > 0)
                {
                    fileName = $"QueryAdapterSpecification.{operationName}.cs";
                }

                var fileStream = new FileStream(
                    Path.Combine(_optionsAccessor.Value.OutputDirectory, fileName),
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    bufferSize: 4096,
                    useAsync: true);

                writer = new StreamWriter(fileStream);

                var specificationHeader = await _specificationHeader.ConfigureAwait(false);
                var knownNamespacesText = new StringBuilder();

                foreach (var knownNamespace in _knownNamespaces.Namespaces)
                {
                    knownNamespacesText.AppendLine($"using {knownNamespace};");
                }

                specificationHeader = specificationHeader.Replace(
                    "{0}", knownNamespacesText.ToString(), StringComparison.Ordinal);

                await writer.WriteAsync(specificationHeader).ConfigureAwait(false);

                _writers.Add(operationName, writer);
            }

            return writer;
        }

        public async Task GenerateTestCasesAsync()
        {
            await AddPrimitiveCollectionAccessorsAsync().ConfigureAwait(false);

            var asyncQueryableType = typeof(AsyncQueryable);
            var asyncQueryableMethods = asyncQueryableType.GetMethods(BindingFlags.Public | BindingFlags.Static);

            foreach (var method in asyncQueryableMethods)
            {
                await ProcessMethodAsync(method).ConfigureAwait(false);
            }

            var specificationFooter = await _specificationFooter.ConfigureAwait(false);

            foreach (var writer in _writers.Values)
            {
                await writer.WriteAsync(specificationFooter).ConfigureAwait(false);
                await writer.DisposeAsync().ConfigureAwait(false);
            }

            _writers.Clear();
        }

        private async Task AddPrimitiveCollectionAccessorsAsync()
        {
            var writer = await GetWriterAsync(null).ConfigureAwait(false);
            var rootSpecification = await ResourceHelper.ReadResourceAsync("RootSpecification.txt")
                .ConfigureAwait(false);

            var buildDataSet = new StringBuilder();

            BuildDataSet(buildDataSet);

            rootSpecification = rootSpecification.Replace(
                "{0}", buildDataSet.ToString(), StringComparison.Ordinal);

            await writer.WriteLineAsync(rootSpecification).ConfigureAwait(false);

        }

        private void BuildDataSet(StringBuilder dataSet)
        {
            foreach (var originalType in _knownCollectionTypes.CollectionTypes)
            {
                dataSet.AppendLine();
                dataSet.AppendLine($"            // {TypeHelper.FormatCSharpTypeName(originalType)} data-set");

                var primitiveType = originalType;
                var isNullable = false;

                if (TypeHelper.IsNullableType(originalType, out var underlyingType))
                {
                    isNullable = true;
                    primitiveType = underlyingType;
                }

                var dataSetName = $"{primitiveType.Name}DataSet";

                if (isNullable)
                {
                    dataSetName = "nullable" + dataSetName;
                }
                else
                {
                    dataSetName = dataSetName.FirstRuneToLowerCase();
                }

                dataSet.AppendLine($"            var {dataSetName} = ImmutableList.CreateBuilder<{TypeHelper.FormatCSharpTypeName(originalType, _knownNamespaces.Namespaces)}>();");

                var curr = -25.234324d;

                for (var i = 0; i < 25; i++)
                {
                    var currInCorrectType = Convert.ChangeType(curr, primitiveType, CultureInfo.InvariantCulture);
                    var formattedCurrInCorrectType = ((IFormattable)currInCorrectType).ToString(null, CultureInfo.InvariantCulture);

                    var suffix = TypeHelper.GetIntegratedNumericTypeSuffix(primitiveType);

                    if (suffix is not null)
                    {
                        dataSet.AppendLine($"            {dataSetName}.Add({formattedCurrInCorrectType}{suffix});");
                    }
                    else
                    {
                        dataSet.AppendLine($"            {dataSetName}.Add(({TypeHelper.FormatCSharpTypeName(primitiveType, _knownNamespaces.Namespaces)}){formattedCurrInCorrectType});");
                    }

                    if (isNullable && i % 4 == 0)
                    {
                        dataSet.AppendLine($"            {dataSetName}.Add(null);");
                    }

                    curr += 2.3457325d;
                }

                dataSet.AppendLine($"            builder.Add(typeof({TypeHelper.FormatCSharpTypeName(originalType, _knownNamespaces.Namespaces)}), {dataSetName}.ToImmutable());");
            }
        }

        private Task ProcessMethodAsync(MethodInfo method)
        {
            if (!method.IsGenericMethod)
            {
                return ProcessNonGenericMethodAsync(method);
            }
            else
            {
                return ProcessGenericMethodDefinitionAsync(method);
            }
        }

        private async Task ProcessNonGenericMethodAsync(MethodInfo method)
        {
            // Get the equivalent method in the System.Linq.Queryable type
            var syncMethod = GetEquivalentMethod(method);

            if (syncMethod is null)
            {
                throw new InvalidOperationException("Cannot handle method.");
            }

            var identifierBuilder = new UniqueIdentifierBuilder(method.Name);
            await ProcessNonGenericMethodAsync(method, syncMethod, identifierBuilder).ConfigureAwait(false);
        }

        private async Task ProcessNonGenericMethodAsync(
            MethodInfo method,
            MethodInfo syncMethod,
            UniqueIdentifierBuilder identifierBuilder)
        {
            var parameters = method.GetParameters();
            var sourceType = parameters[0].ParameterType.GetGenericArguments()[0];

            // Handle parameters
            var defaultParameters = BuildParameters(sourceType, method, syncMethod, identifierBuilder);
            var testCases = new List<TestCase>();

            identifierBuilder.WithSourceType(sourceType);
            var identifier = identifierBuilder.Build();

            foreach (var testCaseGenerator in _testCaseGenerators)
            {
                var generatedTestCases = testCaseGenerator.GenerateTestCases(
                    new MethodPair(method, syncMethod), defaultParameters, identifier);

                testCases.AddRange(generatedTestCases);
            }

            var operationName = GetOperationName(method);

            // TODO: We need method chains, to test this!
            if (string.Equals(operationName, "ThenByDescending", StringComparison.Ordinal)
                || string.Equals(operationName, "ThenBy", StringComparison.Ordinal))
            {
                return;
            }

            var writer = await GetWriterAsync(operationName).ConfigureAwait(false);

            await writer.WriteLineAsync().ConfigureAwait(false);
            await writer.WriteAsync("        #region ").ConfigureAwait(false);
            await writer.WriteAsync(identifier.ToString()).ConfigureAwait(false);
            await writer.WriteLineAsync(" tests").ConfigureAwait(false);

            var conditionalFlags = new List<string>();

            if (string.Equals(operationName, "Zip", StringComparison.Ordinal)
                && method.IsGenericMethod
                && method.GetGenericArguments().Length is 2)
            {
                conditionalFlags.Add("SUPPORTS_QUERYABLE_SIMPLE_ZIP");
                conditionalFlags.Add("SUPPORTS_ASYNC_QUERYABLE_SIMPLE_ZIP");
            }

            if (conditionalFlags.Count > 0)
            {
                await writer.WriteAsync("#if ").ConfigureAwait(false);

                if (conditionalFlags.Count > 1)
                {
                    await writer.WriteAsync("(").ConfigureAwait(false);
                }

                for (var i = 0; i < conditionalFlags.Count; i++)
                {
                    await writer.WriteAsync(conditionalFlags[i]).ConfigureAwait(false);

                    if (i < conditionalFlags.Count - 1)
                    {
                        await writer.WriteAsync(" && ").ConfigureAwait(false);
                    }
                }

                if (conditionalFlags.Count > 1)
                {
                    await writer.WriteAsync(")").ConfigureAwait(false);
                }

                await writer.WriteLineAsync().ConfigureAwait(false);
            }

            foreach (var testCase in testCases)
            {
                await testCase.FormatAsync(writer).ConfigureAwait(false);
            }

            if (conditionalFlags.Count > 0)
            {
                await writer.WriteLineAsync("#endif").ConfigureAwait(false);
            }

            await writer.WriteLineAsync("        #endregion").ConfigureAwait(false);
        }

        private async Task ProcessGenericMethodDefinitionAsync(MethodInfo method)
        {
            if (method.Name == "AsAsyncQueryable")
            {
                return;
            }

            // Get the equivalent method in the System.Linq.Queryable type
            var syncMethod = GetEquivalentMethod(method);

            if (syncMethod is null)
            {
                throw new InvalidOperationException("Cannot handle method.");
            }

            var identifierBuilder = new UniqueIdentifierBuilder(method.Name);

            method = method.GetGenericMethodDefinition();
            syncMethod = syncMethod.GetGenericMethodDefinition();

            var asyncGenericArgumentsDefinition = method.GetGenericArguments();
            var sourceTypes = _knownCollectionTypes.CollectionTypes;
            var operationName = GetOperationName(method);

            foreach (var sourceType in sourceTypes)
            {
                if (operationName.Equals("Min", StringComparison.Ordinal)
                    || operationName.Equals("Max", StringComparison.Ordinal)
                    || operationName.Equals("Average", StringComparison.Ordinal))
                {
                    if (asyncGenericArgumentsDefinition.Length == 1)
                    {
                        identifierBuilder.WithModifier("InGenericCase");
                    }
                    else
                    {
                        identifierBuilder.WithModifier("InGenericCaseWithTwoTypeSelector");
                    }
                }

                var allocatedGenericArguments = new Type[asyncGenericArgumentsDefinition.Length];

                for (var i = 0; i < asyncGenericArgumentsDefinition.Length; i++)
                {
                    if (i == 0)
                    {
                        // TODO: If the methods first argument is not IAsyncQueryable<TSource>, adapt the source type.
                        Debug.Assert(method.Name == "OfType" || method.Name == "Cast" || (
                            TypeHelper.IsAsyncQueryableType(
                                method.GetParameters()[0].ParameterType, out var elementType)
                            && elementType == asyncGenericArgumentsDefinition[0]));

                        allocatedGenericArguments[i] = sourceType;
                    }

                    if (i > 0)
                    {
                        // TODO: Add other variations on complex types
                        allocatedGenericArguments[i] = sourceType;
                    }
                }

                var parametrizedMethod = method.MakeGenericMethod(allocatedGenericArguments);
                var parametrizedSyncMethod = syncMethod.MakeGenericMethod(allocatedGenericArguments);

                await ProcessNonGenericMethodAsync(
                    parametrizedMethod,
                    parametrizedSyncMethod,
                    identifierBuilder).ConfigureAwait(false);
            }
        }

        private ParameterListPair BuildParameters(
            Type sourceType,
            MethodInfo asyncMethod,
            MethodInfo syncMethod,
            UniqueIdentifierBuilder identifierBuilder)
        {
            var result = _parametersBuilder.BuildParameters(sourceType, asyncMethod, syncMethod, identifierBuilder);

            if (TypeHelper.IsAsyncQueryableType(asyncMethod.ReturnType, out var resultType)
                || TypeHelper.IsAsyncEnumerableType(asyncMethod.ReturnType, out resultType)
                || TypeHelper.IsValueTaskType(asyncMethod.ReturnType, out resultType))
            {
                if (resultType != sourceType)
                {
                    identifierBuilder.Returns(resultType);
                }
            }

            return result;
        }

        // TODO: This is a 1 to 1 copy of DefaultMethodTranslatorBuilder.FindSyncQueryableMethod. Share this code!
        private static MethodInfo? GetEquivalentMethod(MethodInfo method)
        {
            Type[]? asyncGenericArguments = null;
            var operationName = GetOperationName(method);

            var asyncParameters = method.GetParameters().AsSpan();

            if (asyncParameters[^1].ParameterType == typeof(CancellationToken))
            {
                asyncParameters = asyncParameters[..^1];
            }

            IEnumerable<MethodInfo> candidates;

            //var candidates = typeof(Queryable)
            //    .GetMethods(BindingFlags.Public | BindingFlags.Static)
            //    .Where(p => p.Name.Equals(operationName, StringComparison.Ordinal));

            //foreach (var candidate in candidates)
            //{
            //    if (IsMatch(method, candidate, asyncParameters, ref asyncGenericArguments, EquivalentTypeMatch.AllowMoreSpecificAsyncType))
            //    {
            //        return candidate;
            //    }
            //}

            candidates = typeof(Enumerable)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.Name.Equals(operationName, StringComparison.Ordinal));

            foreach (var candidate in candidates)
            {
                if (IsMatch(method, candidate, asyncParameters, ref asyncGenericArguments, EquivalentTypeMatch.AllowMoreSpecificAsyncType))
                {
                    return candidate;
                }
            }

            // The method has a signature
            // ValueTask<RETURN_TYPE> XY(IAsyncQueryable<ELEMENT_TYPE>, CancellationToken)
            if (!method.IsGenericMethod)
            {
                if (asyncParameters.Length is not 1)
                {
                    return null;
                }

                var returnType = method.ReturnType;

                if (!TypeHelper.IsValueTaskType(returnType, out var resultType))
                {
                    return null;
                }

                if (!TypeHelper.IsAsyncQueryableType(asyncParameters[0].ParameterType, out var elementType))
                {
                    return null;
                }

                // Try to find a method with signature, if RETURN_TYPE and ELEMENT_TYPE are the same
                // RETURN_TYPE XY<RETURN_TYPE>(IQuerable<RETURN_TYPE>)
                if (resultType == elementType)
                {
                    foreach (var candidate in candidates)
                    {
                        if (!candidate.IsGenericMethodDefinition)
                        {
                            continue;
                        }

                        var genericArguments = candidate.GetGenericArguments();

                        if (genericArguments.Length is not 1)
                        {
                            continue;
                        }

                        var parameters = candidate.GetParameters();

                        if (parameters.Length is not 1)
                        {
                            continue;
                        }

                        if (parameters[0].ParameterType != TypeHelper.GetQueryableType(genericArguments[0]))
                        {
                            continue;
                        }

                        if (candidate.ReturnType != genericArguments[0])
                        {
                            continue;
                        }

                        return candidate.MakeGenericMethod(elementType);
                    }
                }

                // Try to find a method with signature, if RETURN_TYPE and ELEMENT_TYPE are the same
                // RETURN_TYPE XY<ELEMENT_TYPE, RETURN_TYPE>(IQuerable<ELEMENT_TYPE>, Expression<Func<ELEMENT_TYPE, RETURN_TYPE>>)
                // NOT IMPLEMENTED FOR NOW. DO WE NEED THIS?
            }

            return null;
        }

        private static bool IsMatch(
            MethodInfo method,
            MethodInfo candidate,
            Span<ParameterInfo> asyncParameters,
            ref Type[]? asyncGenericArguments,
            EquivalentTypeMatch typeMatch)
        {
            // If the candidate is generic, construct the candidate with the async generic args
            var constructedCandidate = candidate;

            if (constructedCandidate.IsGenericMethodDefinition)
            {
                if (!method.IsGenericMethod)
                {
                    return false;
                }

                asyncGenericArguments ??= method.GetGenericArguments();

                if (constructedCandidate.GetGenericArguments().Length != asyncGenericArguments.Length)
                {
                    return false;
                }

                constructedCandidate = candidate.MakeGenericMethod(asyncGenericArguments);
            }
            else if (method.IsGenericMethod)
            {
                return false;
            }

            var parameters = constructedCandidate.GetParameters();
            var argumentMatch = true;

            if (parameters.Length != asyncParameters.Length)
            {
                return false;
            }

            for (var j = 0; j < parameters.Length; j++)
            {
                var asyncParameter = asyncParameters[j];
                var parameter = parameters[j];

                if (!TypeTranslationHelper.IsEquivalentAsyncType(
                    parameter.ParameterType,
                    asyncParameter.ParameterType,
                    typeMatch))
                {
                    argumentMatch = false;
                    break;
                }
            }

            if (!argumentMatch)
            {
                return false;
            }

            var resultTypeMatch = typeMatch; //switch
            //{
            //    EquivalentTypeMatch.AllowMoreSpecificAsyncType => EquivalentTypeMatch.AllowMoreSpecificSyncType,
            //    EquivalentTypeMatch.AllowMoreSpecificSyncType => EquivalentTypeMatch.AllowMoreSpecificAsyncType,
            //    _ => EquivalentTypeMatch.ExactMatch,
            //};

            if (!TypeTranslationHelper.IsEquivalentAsyncType(
                constructedCandidate.ReturnType,
                method.ReturnType,
                resultTypeMatch))
            {
                return false;
            }

            return true;
        }

        private static string GetOperationName(MethodInfo method)
        {
            var operationName = method.Name;

            if (operationName.EndsWith("AwaitWithCancellationAsync", StringComparison.Ordinal))
            {
                operationName = operationName[..^"AwaitWithCancellationAsync".Length];
            }
            else if (operationName.EndsWith("AwaitAsync", StringComparison.Ordinal))
            {
                operationName = operationName[..^"AwaitAsync".Length];
            }
            else if (operationName.EndsWith("AwaitWithCancellation", StringComparison.Ordinal))
            {
                operationName = operationName[..^"AwaitWithCancellation".Length];
            }
            else if (operationName.EndsWith("Await", StringComparison.Ordinal))
            {
                operationName = operationName[..^"Await".Length];
            }
            else if (operationName.EndsWith("Async", StringComparison.Ordinal))
            {
                operationName = operationName[..^"Async".Length];
            }

            return operationName;
        }
    }

    internal class TestObject { }
}
