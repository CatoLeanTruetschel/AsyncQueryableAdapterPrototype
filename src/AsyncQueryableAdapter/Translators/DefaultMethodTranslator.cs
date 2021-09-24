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
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AsyncQueryableAdapter.Utils;
using AsyncQueryableAdapterPrototype.Utils;

// TODO: Make this handle and test the following functions 
//       (that all accept an argument of type IAsyncEnumerable)
// * Concat
// * Except
// * GroupJoin (Default case)
// * Intersect
// * Join (Default case)
// * OrderBy (Default case)
// * OrderByDescending (Default case)
// * Select (Default case)
// * SelectMany (Default case)
// * Skip
// * SkipLast
// * SkipWhile (Default case)
// * Take
// * TakeWhile (Default case)
// * ThenBy (Default case)
// * Union
// * Where (Default case)
// * Zip (Default case)
//
// TODO: Can we implement the non default cases here too, instead of in specialized translators?
//       The only difference to the default cases is the return type of the predicates and selectors 
//       (ValueTask<T> instead of T) and the CancellationToken (in the *AwaitWithCancellation methods).

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class DefaultMethodTranslatorBuilder : IMethodTranslatorBuilder
    {
        public bool TryBuildMethodTranslator(
            MethodInfo method,
            [NotNullWhen(true)] out IMethodTranslator? result)
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));

            result = null;

            if (method.DeclaringType != typeof(System.Linq.AsyncQueryable))
            {
                return false;
            }

            if (method.IsGenericMethod)
            {
                method = method.GetGenericMethodDefinition();
            }
            else
            {
                return false;
            }

            if (!TypeHelper.IsAsyncQueryableType(method.ReturnType, out var resultElementType))
            {
                return false;
            }

            // TODO: This is not met for Zip, as it returns ValueTuple<TFirst, TSecond>
            //       Either implement Zip as a special translator or make ValueTuple`2 a special known type here
            if (!method.GetGenericArguments().Any(p => p == resultElementType))
            {
                return false;
            }

            // Try to find a method with the same signature in the System.Linq.Queryable type that works
            // on the type IQueryable (or IQueryable<T>) instead.
            var translatedMethod = FindSyncQueryableMethod(method);
            if (translatedMethod is not null)
            {
                result = new DefaultMethodTranslator(method, translatedMethod);
                return true;
            }

            return false;
        }

        private static MethodInfo? FindSyncQueryableMethod(MethodInfo method)
        {
            Type[]? asyncGenericArguments = null;
            var asyncParameters = method.GetParameters();
            var operationName = OperationNameHelper.GetOperationName(method);

            var candidates = typeof(Queryable)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.Name.Equals(operationName, StringComparison.Ordinal));

            foreach (var candidate in candidates)
            {
                // If the candidate is generic, construct the candidate with the async generic args
                var constructedCandidate = candidate;

                if (constructedCandidate.IsGenericMethodDefinition)
                {
                    if (!method.IsGenericMethod)
                    {
                        continue;
                    }

                    asyncGenericArguments ??= method.GetGenericArguments();

                    if (constructedCandidate.GetGenericArguments().Length != asyncGenericArguments.Length)
                    {
                        continue;
                    }

                    constructedCandidate = candidate.MakeGenericMethod(asyncGenericArguments);
                }
                else if (method.IsGenericMethod)
                {
                    continue;
                }

                var parameters = constructedCandidate.GetParameters();
                var argumentMatch = true;

                if (parameters.Length != asyncParameters.Length)
                {
                    continue;
                }

                for (var j = 0; j < parameters.Length; j++)
                {
                    var asyncParameter = asyncParameters[j];
                    var parameter = parameters[j];

                    if (!TypeTranslationHelper.IsEquivalentAsyncType(
                        parameter.ParameterType,
                        asyncParameter.ParameterType))
                    {
                        argumentMatch = false;
                        break;
                    }
                }

                if (!argumentMatch)
                {
                    continue;
                }

                if (!TypeTranslationHelper.IsEquivalentAsyncType(
                    constructedCandidate.ReturnType,
                    method.ReturnType))
                {
                    continue;
                }

                return candidate;
            }

            return null;
        }
    }

    internal sealed class DefaultMethodTranslator : IMethodTranslator
    {
        [ThreadStatic]
        private static List<Expression>? _argumentsBuffer;

        private readonly MethodInfo _targetMethod;
        private readonly MethodInfo _translatedMethod;

        public DefaultMethodTranslator(MethodInfo targetMethod, MethodInfo translatedMethod)
        {
            if (targetMethod is null)
                throw new ArgumentNullException(nameof(targetMethod));

            if (translatedMethod is null)
                throw new ArgumentNullException(nameof(translatedMethod));
            _targetMethod = targetMethod;
            _translatedMethod = translatedMethod;
        }

        public bool TryTranslate(
            in MethodTranslationContext translationContext,
            [NotNullWhen(true)] out ConstantExpression? result)
        {
            result = null;

            // Copy the arguments to a buffer that we can work on
            // TODO: Use pooled array and Span
            var arguments = _argumentsBuffer ??= new List<Expression>();
            arguments.Clear();
            arguments.AddRange(translationContext.Arguments);

            // Extract all translated-queryable arguments, that is:
            // For all the arguments of type "TranslatedQueryable" or a derived type, replace the argument with the 
            // Expression stored in the translated-queryable.
            ExtractArguments(arguments, out var queryAdapter, out var queryProvider);

            // Get the generic arguments from the method to build the translation targets from its method definition
            var genericArguments = Array.Empty<Type>();
            var methodDefinition = translationContext.Method;
            var parameters = translationContext.Method.GetParameters();
            var methodDefinitionGenericArguments = Array.Empty<Type>();
            var methodDefinitionParameters = parameters;

            if (methodDefinition.IsGenericMethod)
            {
                genericArguments = translationContext.Method.GetGenericArguments();
                methodDefinition = methodDefinition.GetGenericMethodDefinition();
                methodDefinitionGenericArguments = methodDefinition.GetGenericArguments();
                methodDefinitionParameters = methodDefinition.GetParameters();
            }

            // Validate that we can translate the specified method.
            if (!ValidateMethodDefinition(methodDefinition))
            {
                return false;
            }

            var unprocessedArgumentsDescriptor = new ReadOnlyArgumentDescriptorCollection(
                translationContext.Arguments, parameters, methodDefinitionParameters);

            using var translatedGenericArgumentsOwner = MemoryPool<TranslatedGenericArgument>.Shared.Rent(
                genericArguments.Length);

            var translatedGenericArguments = translatedGenericArgumentsOwner.Memory[..genericArguments.Length].Span;
            translatedGenericArguments.Clear();

            var genericArgumentsDescriptor = new GenericArgumentsDescriptor(
                genericArguments, translatedGenericArguments, methodDefinitionGenericArguments);

            // Rewrite the type parameters
            if (!TranslateGenericArguments(unprocessedArgumentsDescriptor, genericArgumentsDescriptor))
            {
                return false;
            }

            var isAnyGenericArgumentTranslated = IsAnyGenericArgumentTranslated(translatedGenericArguments);

            if (isAnyGenericArgumentTranslated)
            {
                var argumentsCollection = new ArgumentDescriptorCollection(
                    arguments, parameters, methodDefinitionParameters);

                // Translate all expressions, that use the type-parameters
                if (!AdaptArgumentsToTranslatedGenericArguments(argumentsCollection, genericArgumentsDescriptor))
                {
                    return false;
                }
            }

            // Construct the translation target from its method definition using the generic arguments read from the
            // original method. 
            var constructedTranslationTarget = ConstructTranslationTarget(genericArguments);

            if (constructedTranslationTarget is null)
                return false;

            // Translate lambda arguments
            TranslateLambdaArguments(arguments, constructedTranslationTarget.GetParameters());

            // Finally check that the constructed arguments are compatible with the translation target
            if (!TypeTranslationHelper.AreArgumentsCompatible(constructedTranslationTarget, arguments))
                return false;

            Debug.Assert(queryAdapter is not null);
            Debug.Assert(queryProvider is not null);

            // Build the resulting call expression
            var translatedExpression = Expression.Call(
                translationContext.Instance,
                constructedTranslationTarget,
                arguments);

            // The result of the current method will carry-on the grouped-queryable burden (See the QueryBy translation)
            // therefore construct the special-case translated-queryable type.
            if (isAnyGenericArgumentTranslated)
            {
                // We expect the return type to be IAsyncQueryable<TResult>
                var sequenceResultTypeDefinition = methodDefinition.ReturnType.GetGenericArguments()[0];

                var isResultGrouped = IsResultGrouped(
                    genericArgumentsDescriptor,
                    sequenceResultTypeDefinition,
                    out var resultKeyType,
                    out var resultElementType);

                if (isResultGrouped)
                {
                    // TODO: Why the ! operator to prevent nullability issues here?
                    var specialCaseResultTranslatedQueryable = new TranslatedGroupByQueryable(
                      queryAdapter, resultKeyType!, resultElementType!, translatedExpression, queryProvider);
                    result = Expression.Constant(specialCaseResultTranslatedQueryable);
                    return true;
                }
            }

            // The result is an ordinary translated-queryable.
            var elementType = translatedExpression.Type.GetGenericArguments().First();
            var resultTranslatedQueryable = new TranslatedQueryable(
                queryAdapter, elementType, translatedExpression, queryProvider);
            result = Expression.Constant(resultTranslatedQueryable);

            return true;
        }

        private static void TranslateLambdaArguments(IList<Expression> arguments, ParameterInfo[] parameters)
        {
            for (var i = 0; i < arguments.Count; i++)
            {
                var parameterType = parameters[i].ParameterType;
                var argument = arguments[i].Unquote();
                var type = argument.Type;

                if (argument.NodeType == ExpressionType.Lambda
                   && TypeHelper.IsLambdaExpression(parameterType, out var parameterDelegateType))
                {
                    var delegateType = argument.Type;
                    Debug.Assert(TypeHelper.IsDelegate(delegateType));

                    if (delegateType == parameterDelegateType)
                    {
                        continue;
                    }

                    // Try translate the lambda of type 'delegateType' into a lambda of type
                    // 'parameterDelegateType'
                    var parameterDelegateMethod = parameterDelegateType.GetMethod("Invoke");

                    if (parameterDelegateMethod is null)
                    {
                        continue;
                    }

                    var expectedReturnType = parameterDelegateMethod.ReturnType;
                    var expectedParameterTypes = parameterDelegateMethod
                        .GetParameters()
                        .Select(p => p.ParameterType)
                        .ToArray(); // TODO: Do not use LINQ for perf!

                    if (ExpressionHelper.TryTranslateExpressionToSync(
                        argument, expectedParameterTypes, expectedReturnType, out var translatedExpression))
                    {
                        arguments[i] = Expression.Quote(translatedExpression);
                    }
                }
            }
        }

        /// <summary>
        /// Extracts the <see cref="TranslatedQueryable"/> expression in the specified list of arguments.
        /// </summary>
        /// <param name="arguments">The list of arguments.</param>
        /// <param name="queryAdapter">Contains the query-adapter when the operation was executed.</param>
        /// <param name="queryProvider">Contains the query-provider when the operation was executed.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="arguments"/> contains null arguments 
        /// -- OR --
        /// <paramref name="arguments"/> does not contain a <see cref="TranslatedQueryable"/> argument
        /// -- OR --
        /// <paramref name="arguments"/> contains multiple <see cref="TranslatedQueryable"/> arguments with 
        /// different query-providers.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if an argument is of type <see cref="TranslatedQueryable"/> but the instance cannot be extracted.
        /// </exception>
        public static void ExtractArguments(
            IList<Expression> arguments,
            out QueryAdapterBase queryAdapter,
            out IQueryProvider queryProvider)
        {
            queryAdapter = null!;
            queryProvider = null!;

            for (var i = 0; i < arguments.Count; i++)
            {
                var argument = arguments[i];

                if (argument is null)
                {
                    ThrowHelper.ThrowCollectionMustNotContainNullEntries(nameof(arguments));
                }

                arguments[i] = ExtractArgument(argument, out var currQueryAdapter, out var currQueryProvider);

                if (queryAdapter is not null && currQueryAdapter is not null && queryAdapter != currQueryAdapter)
                {
                    ThrowHelper.ThrowSubqueriesWithDifferentQueryProvidersUnsupported(nameof(arguments));
                }

                if (queryProvider is not null && currQueryProvider is not null && queryProvider != currQueryProvider)
                {
                    ThrowHelper.ThrowSubqueriesWithDifferentQueryProvidersUnsupported(nameof(arguments));
                }

                queryAdapter ??= currQueryAdapter!;
                queryProvider ??= currQueryProvider!;
            }

            if (queryAdapter is null || queryProvider is null)
            {
                ThrowHelper.ThrowArgumentsMustContainATranslatedQueryable(nameof(arguments));
            }
        }

        private static Expression ExtractArgument(
            Expression argument,
            out QueryAdapterBase? queryAdapter,
            out IQueryProvider? queryProvider)
        {
            queryAdapter = null;
            queryProvider = null;

            // We only process arguments that represent already translated subqueries (i.e. arguments of type
            // TranslatedQueryable or a derived type)
            if (!argument.Type.IsAssignableTo(typeof(TranslatedQueryable)))
            {
                return argument;
            }

            if (!argument.TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
            {
                ThrowHelper.ThrowUnableToExtractTranslatedQueryableFromArgument();
            }

            queryAdapter = translatedQueryable.QueryAdapter;
            queryProvider = translatedQueryable.QueryProvider;

            return translatedQueryable.Expression;
        }

        /// <summary>
        /// Returns a boolean value indicating whether the result of a method translated method call
        /// is itself a grouped queryable.
        /// </summary>
        /// <param name="methodDefinitionGenericArguments">
        /// The read-only buffer of generic arguments of the method-definition of the method to translate.
        /// </param>
        /// <param name="translatedGenericArguments">
        /// The buffer of translated generic arguments recordings to keep track which generic arguments were modified 
        /// and what the key and element types are.
        /// </param>
        /// <param name="sequenceResultTypeDefinition">
        /// The element type of the sequence result of the method-definition of the method to translate.
        /// </param>
        /// <param name="resultKeyType">
        /// Contains the grouped-queryable result key type when the result is grouped.
        /// </param>
        /// <param name="resultElementType">
        /// Contains the grouped-queryable result element type when the result is grouped.
        /// </param>
        /// <returns>True if the result is grouped, false otherwise.</returns>
        private static bool IsResultGrouped(
            in ReadOnlyGenericArgumentsDescriptor genericArguments,
            Type sequenceResultTypeDefinition,
            [NotNullWhen(true)] out Type? resultKeyType,
            [NotNullWhen(true)] out Type? resultElementType)
        {
            // We expect the sequence result type definition to be one of the generic arguments.
            // F.e. in the type definition IAsyncQueryable<TResult> XY<TSource, TResult>(...)
            // TResult is the sequence result type definition which is the TResult type parameter.

            // Iterate over all translated generic arguments and check whether it is the sequence result type def.
            for (var i = 0; i < genericArguments.TranslatedGenericArguments.Length; i++)
            {
                if (genericArguments.TranslatedGenericArguments[i].IsTranslated
                    && sequenceResultTypeDefinition == genericArguments.MethodDefinitionGenericArguments[i])
                {
                    resultKeyType = genericArguments.TranslatedGenericArguments[i].Grouping.KeyType;
                    resultElementType = genericArguments.TranslatedGenericArguments[i].Grouping.ElementType;

                    return true;
                }
            }

            resultKeyType = null;
            resultElementType = null;
            return false;
        }

        /// <summary>
        /// Validates that the translator can handle the specified method definition.
        /// </summary>
        /// <param name="methodDefinition">The method definition to check.</param>
        /// <returns>True if the translator can handle <paramref name="methodDefinition"/>, false otherwise.</returns>
        private bool ValidateMethodDefinition(MethodInfo methodDefinition) // TODO: Rename to CanHandleMethodDefinition
        {
            return methodDefinition == _targetMethod;
        }

        // TODO: Add a special type that wraps Span<TranslatedGenericArgument> and move this method there or
        //       move this to a helper type (and possibly convert it to an extension method)
        private static bool IsAnyGenericArgumentTranslated(
            ReadOnlySpan<TranslatedGenericArgument> translatedGenericArguments)
        {
            var isAnyGenericArgumentTranslated = false;

            for (var i = 0; i < translatedGenericArguments.Length; i++)
            {
                if (translatedGenericArguments[i].IsTranslated)
                {
                    isAnyGenericArgumentTranslated = true;
                    break;
                }
            }

            return isAnyGenericArgumentTranslated;
        }

        // TODO: Refactor me pls!
        private static bool AdaptArgumentsToTranslatedGenericArguments(
            in ArgumentDescriptorCollection arguments,
            in ReadOnlyGenericArgumentsDescriptor genericArguments)
        {
            foreach (var argument in arguments)
            {
                if (argument.Argument.Type.IsAssignableTo(typeof(TranslatedQueryable)))
                    continue;

                var arg = argument.Argument.Unquote();

                if (arg is not LambdaExpression lambdaExpression)
                {
                    continue;
                }

                var lamdaParams = lambdaExpression.Parameters;

                // The lambda expression is of some type
                // Expression<Func<TSource, int, TOther, TResult>>
                // We need to get the sets of parameters of the lambda expression, we need to rewrite.

                // Use the parameter of the generic method definition to find the parameters
                var methodDefinitionParameter = argument.MethodDefinitionParameter
                    .ParameterType;

                if (!methodDefinitionParameter.IsGenericType
                    || methodDefinitionParameter.GetGenericTypeDefinition() != typeof(Expression<>))
                {
                    // Just skip this. We check whether the parameters match in the end anyway, so we
                    // do not break anything.
                    continue;
                }

                var funcType = methodDefinitionParameter.GetGenericArguments()[0];

                if (!TypeHelper.IsFuncType(funcType))
                {
                    // Just skip this. We check whether the parameters match in the end anyway, so we
                    // do not break anything.
                    continue;
                }

                var funcArgs = funcType.GetGenericArguments().AsSpan()[..^1];
                Debug.Assert(funcArgs.Length == lamdaParams.Count);

                Dictionary<ParameterExpression, GroupingDescriptor>? lambdaParamsToRewrite = null;

                for (var j = 0; j < funcArgs.Length; j++)
                {
                    for (var k = 0; k < genericArguments.TranslatedGenericArguments.Length; k++)
                    {
                        if (!genericArguments.TranslatedGenericArguments[k].IsTranslated)
                            continue;

                        if (funcArgs[j] == genericArguments.MethodDefinitionGenericArguments[k])
                        {
                            var groupingsTranslation = genericArguments.TranslatedGenericArguments[k];

                            // TODO: Pool the dictionary
                            lambdaParamsToRewrite ??= new();
                            lambdaParamsToRewrite.Add(lamdaParams[j], groupingsTranslation.Grouping);
                        }
                    }
                }

                if (lambdaParamsToRewrite is not null)
                {
                    Debug.Assert(lambdaParamsToRewrite.Any());

                    if (!GroupingExpressionRewriter.TryRewriteLamdaExpression(
                        lambdaExpression, lambdaParamsToRewrite, out var translatedArg))
                    {
                        return false;
                    }

                    argument.Argument = Expression.Quote(translatedArg);
                }
            }

            return true;
        }

        private static bool TranslateGenericArguments(
            in ReadOnlyArgumentDescriptorCollection arguments,
            in GenericArgumentsDescriptor genericArguments)
        {
            foreach (var argument in arguments)
            {
                var processGroupQueryableSuccess = TranslateGenericArguments(argument, genericArguments);

                if (!processGroupQueryableSuccess)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Processes a single argument and translates the generic arguments as necessary.
        /// </summary>
        /// <param name="argument">The unprocessed argument descriptor as originally received from the context.</param>
        /// <param name="genericArguments">The generic arguments descriptor.</param>
        /// <returns>True if the operation was successful, false otherwise.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if an argument is of type <see cref="TranslatedQueryable"/> but the instance cannot be extracted.
        /// </exception>
        private static bool TranslateGenericArguments(
            in ReadOnlyArgumentDescriptor argument,
            in GenericArgumentsDescriptor genericArguments)
        {
            if (argument.Argument.Type != typeof(TranslatedGroupByQueryable))
            {
                return true;
            }

            if (!argument.Argument.TryEvaluate<TranslatedGroupByQueryable>(out var translatedQueryable))
            {
                ThrowHelper.ThrowUnableToExtractTranslatedQueryableFromArgument();
            }

            var enumerableGroupingType = TypeHelper.GetAsyncEnumerableType(translatedQueryable.AsyncGroupingType);
            var queryableGroupingType = TypeHelper.GetAsyncQueryableType(translatedQueryable.AsyncGroupingType);

            // The concrete parameter type must be of the form
            // IAsync{Enumerable, Queryable}<IAsyncGrouping<TKey, TElement>>
            // TODO: Is this true? What about co-variance? Can we test this somehow?
            if (argument.Parameter.ParameterType != enumerableGroupingType
                && argument.Parameter.ParameterType != queryableGroupingType)
            {
                // Cannot translate
                return false;
            }

            // We expect that one of the methods generic arguments represents the grouping
            // That is one generic argument fulfills the condition
            // typeof(TArg) == typeof(IAsyncGrouping<TKey, TElement>)
            // But we search for the generic parameter that supports the parameter, that is
            // the TArg that the current parameter uses as grouping type
            // IAsync{Enumerable, Queryable}<TArg>

            // The generic parameter that specifies the grouping type
            // F.e. TSource
            var groupingType = argument.MethodDefinitionParameter.ParameterType.GetGenericArguments()[0];
            var foundMatchingTypeParameter = false;

            for (var i = 0; i < genericArguments.MethodDefinitionGenericArguments.Length; i++)
            {
                if (genericArguments.MethodDefinitionGenericArguments[i] != groupingType)
                {
                    continue;
                }

                // A matching type parameter was found
                foundMatchingTypeParameter = true;

                // The type parameter is of form IAsyncGrouping<TKey, TElement>
                // TODO: What about co-variance? Can we test this somehow?

                // The type parameter was not yet translated
                if (!genericArguments.TranslatedGenericArguments[i].IsTranslated)
                {
                    var grouping = new GroupingDescriptor(translatedQueryable.KeyType, translatedQueryable.ElementType);

                    genericArguments.TranslatedGenericArguments[i] = TranslatedGenericArgument.Translated(grouping);

                    genericArguments.GenericArguments[i] = translatedQueryable.GroupingType;
                }
                // The type parameter was already transformed, check if the transformation is consistent with our
                // translation
                // TODO: What about co-variance? Can we test this somehow?
                else if (genericArguments.GenericArguments[i] != translatedQueryable.GroupingType)
                {
                    return false;
                }

                break;
            }

            // The method has a form that we cannot (or do not) translate with this algorithm.
            // This should never be the case for any of the LINQ methods as of the time of the original
            // implementation of this algorithm.
            return foundMatchingTypeParameter;
        }

        private MethodInfo ConstructTranslationTarget(Type[] genericArguments)
        {
            var translatedMethod = _translatedMethod;

            if (translatedMethod.IsGenericMethod)
            {
                translatedMethod = translatedMethod.MakeGenericMethod(genericArguments);
            }

            return translatedMethod;
        }
    }
}
