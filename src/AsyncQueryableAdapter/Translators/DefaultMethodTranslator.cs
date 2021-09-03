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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AsyncQueryableAdapter.Utils;

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
            var candidates = typeof(Queryable).GetMethods(BindingFlags.Public | BindingFlags.Static);

            foreach (var candidate in candidates)
            {
                if (!candidate.Name.Equals(method.Name, StringComparison.Ordinal))
                {
                    continue;
                }

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

                    if (!TypeTranslationHelper.IsCompatibleTranslationTarget(
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

                if (!TypeTranslationHelper.IsCompatibleTranslationTarget(
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

        [ThreadStatic]
        private static List<(int index, TranslatedGroupByQueryable groupQueryable)>? _groupQueryablesBuffer;

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

            var translatedArguments = _argumentsBuffer ??= new List<Expression>();
            translatedArguments.Clear();
            translatedArguments.AddRange(translationContext.Arguments);

            List<(int index, TranslatedGroupByQueryable groupQueryable)>? groupedQueryables = null;

            TranslateArguments(
                translatedArguments,
                out var queryAdapter,
                out var queryProvider,
                ref groupedQueryables);

            var methodDefinition = translationContext.Method;

            if (methodDefinition.IsGenericMethod)
            {
                methodDefinition = methodDefinition.GetGenericMethodDefinition();
            }

            if (methodDefinition != _targetMethod)
            {
                return false;
            }

            var genericArguments = translationContext.Method.GetGenericArguments();
            var processGroupedQueryablesSuccess = TryProcessGroupedQueryables(
                groupedQueryables,
                translationContext,
                genericArguments,
                translatedArguments,
                out var isResultGrouped,
                out var resultKeyType,
                out var resultElementType);

            if (!processGroupedQueryablesSuccess)
            {
                return false;
            }

            var constructedTranslationTarget = ConstructTranslationTarget(genericArguments);

            if (constructedTranslationTarget is null)
                return false;

            if (!IsCompatible(translatedArguments, constructedTranslationTarget))
                return false;

            Debug.Assert(queryAdapter is not null);
            Debug.Assert(queryProvider is not null);

            var translatedExpression = Expression.Call(
                translationContext.Instance,
                constructedTranslationTarget,
                translatedArguments);

            if (isResultGrouped)
            {
                var resultTranslatedQueryable = new TranslatedGroupByQueryable(
                      queryAdapter, resultKeyType, resultElementType, translatedExpression, queryProvider);
                result = Expression.Constant(resultTranslatedQueryable);
            }
            else
            {
                var elementType = translatedExpression.Type.GetGenericArguments().First();
                var resultTranslatedQueryable = new TranslatedQueryable(
                    queryAdapter, elementType, translatedExpression, queryProvider);
                result = Expression.Constant(resultTranslatedQueryable);
            }

            return true;
        }

        private static void TranslateArguments(
            IList<Expression> arguments,
            [NotNull] out QueryAdapterBase queryAdapter,
            [NotNull] out IQueryProvider queryProvider,
            ref List<(int index, TranslatedGroupByQueryable groupQueryable)>? groupQueryables)
        {
            queryAdapter = null!;
            queryProvider = null!;

            for (var i = 0; i < arguments.Count; i++)
            {
                var argument = arguments[i];

                TranslateArgument(
                    i,
                    ref argument,
                    ref queryAdapter!,
                    ref queryProvider!,
                    ref groupQueryables);

                arguments[i] = argument;
            }

            Debug.Assert(queryAdapter is not null);
            Debug.Assert(queryProvider is not null);
        }

        private static void TranslateArgument(
            int index,
            ref Expression argument,
            ref QueryAdapterBase? queryAdapter,
            ref IQueryProvider? queryProvider,
            ref List<(int index, TranslatedGroupByQueryable groupQueryable)>? groupQueryables)
        {
            // We only process arguments that represent already translated subqueries (i.e. arguments of type
            // TranslatedQueryable or a derived type)
            if (!argument.Type.IsAssignableTo(typeof(TranslatedQueryable)))
            {
                return;
            }

            if (!argument.TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
            {
                throw new Exception(); // TODO
            }

            if (translatedQueryable is null)
            {
                throw new Exception(); // TODO
            }

            // Special case when the sub-query contains a GroupBy query.
            if (translatedQueryable is TranslatedGroupByQueryable translatedGroupByQueryable)
            {
                if (groupQueryables is null)
                {
                    _groupQueryablesBuffer ??= new();
                    groupQueryables = _groupQueryablesBuffer;
                    groupQueryables.Clear();
                }

                groupQueryables.Add((index, translatedGroupByQueryable));
            }

            if (queryAdapter is null)
            {
                queryAdapter = translatedQueryable.QueryAdapter;
            }
            else if (queryAdapter != translatedQueryable.QueryAdapter)
            {
                ThrowHelper.ThrowSubqueriesWithDifferentQueryProvidersUnsupported();
            }

            if (queryProvider is null)
            {
                queryProvider = translatedQueryable.QueryProvider;
            }
            else if (queryProvider != translatedQueryable.QueryProvider)
            {
                ThrowHelper.ThrowSubqueriesWithDifferentQueryProvidersUnsupported();
            }

            argument = translatedQueryable.Expression;
        }

        private static bool TryProcessGroupedQueryables(
            List<(int index, TranslatedGroupByQueryable groupQueryable)>? groupedQueryables,
            in MethodTranslationContext translationContext,
            Type[] genericArguments,
            List<Expression> arguments,
            out bool isResultGrouped,
            out Type resultKeyType,
            out Type resultElementType)
        {
            isResultGrouped = false;
            resultKeyType = typeof(void);
            resultElementType = typeof(void);

            var methodDefinition = translationContext.Method;

            if (methodDefinition.IsGenericMethod)
            {
                methodDefinition = methodDefinition.GetGenericMethodDefinition();
            }

            if (groupedQueryables is null)
            {
                return true;
            }

            Debug.Assert(groupedQueryables.Any());
            var parameter = translationContext.Method.GetParameters();

            var methodDefinitionGenericArguments = methodDefinition.GetGenericArguments();
            var methodDefinitionParameters = methodDefinition.GetParameters();
            //var translatedTypeParameterIndices = new HashSet<int>();
            Dictionary<int, (Type groupingType, Type asyncGroupingType)>? translatedTypeParameters = null;

            // Rewrite the type parameters
            foreach (var (i, groupQueryable) in groupedQueryables)
            {
                // The type of the concrete parameter (The constructed generic method)
                // F.e. IAsyncEnumerable<IGrouping<int, Person>>
                var parameterType = parameter[i].ParameterType;

                // The type of the unconstructed parameter
                // F.e. IAsyncEnumerable<TSource>
                var methodDefinitionParameterType = methodDefinitionParameters[i].ParameterType;

                var enumerableGroupingType = TypeHelper.GetAsyncEnumerableType(groupQueryable.AsyncGroupingType);
                var queryableGroupingType = TypeHelper.GetAsyncQueryableType(groupQueryable.AsyncGroupingType);

                // The concrete parameter type must be of the form
                // IAsync{Enumerable, Queryable}<IAsyncGrouping<TKey, TElement>>
                // TODO: Is this true? What about co-variance? Can we test this somehow?
                if (parameterType != enumerableGroupingType && parameterType != queryableGroupingType)
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
                var groupingType = methodDefinitionParameterType.GetGenericArguments()[0];
                var foundMatchingTypeParameter = false;

                for (var j = 0; j < methodDefinitionGenericArguments.Length; j++)
                {
                    if (methodDefinitionGenericArguments[i] == groupingType)
                    {
                        // A matching type parameter was found
                        foundMatchingTypeParameter = true;

                        // The type parameter is of form IAsyncGrouping<TKey, TElement>
                        // TODO: What about co-variance? Can we test this somehow?

                        translatedTypeParameters ??= new();

                        // The type parameter was not yet translated
                        if (translatedTypeParameters.TryAdd(j, (groupQueryable.GroupingType, groupQueryable.AsyncGroupingType)))
                        {
                            genericArguments[j] = groupQueryable.GroupingType;
                        }
                        // The type parameter was already transformed, check if the transformation is consistent with our translation
                        // TODO: What about co-variance? Can we test this somehow?
                        else if (genericArguments[j] != groupQueryable.GroupingType)
                        {
                            return false;
                        }

                        break;
                    }
                }

                // The method has a form that we cannot (or do not) translate with this algorithm.
                // This should never be the case for any of the LINQ methods as of the time of the original
                // implementation of this algorithm.
                if (!foundMatchingTypeParameter)
                {
                    return false;
                }
            }

            if (translatedTypeParameters is not null)
            {
                Debug.Assert(translatedTypeParameters.Any());

                // Translate all expressions, that use the type-parameters
                for (var i = 0; i < arguments.Count; i++)
                {
                    if (arguments[i].Type.IsAssignableTo(typeof(TranslatedQueryable)))
                        continue;

                    var arg = arguments[i].Unquote();

                    if (arg is not LambdaExpression lambdaExpression)
                    {
                        continue;
                    }

                    var lamdaParams = lambdaExpression.Parameters;

                    // The lambda expression is of some type
                    // Expression<Func<TSource, int, TOther, TResult>>
                    // We need to get the sets of parameters of the lamda expression, we need to rewrite.

                    // Use the parameter of the generic method definition to find the parameters
                    var methodDefinitionParameter = methodDefinitionParameters[i]
                        .ParameterType;

                    if (!methodDefinitionParameter.IsGenericType
                        || methodDefinitionParameter.GetGenericTypeDefinition() != typeof(Expression<>))
                    {
                        // Just skip this. We check whether the parameters match in the end anyway, so we
                        // so not break anything.
                        continue;
                    }

                    var funcType = methodDefinitionParameter.GetGenericArguments()[0];

                    if (!FuncTypeHelper.IsFuncType(funcType))
                    {
                        // Just skip this. We check whether the parameters match in the end anyway, so we
                        // so not break anything.
                        continue;
                    }

                    var funcArgs = funcType.GetGenericArguments().AsSpan()[..^1];
                    Debug.Assert(funcArgs.Length == lamdaParams.Count);

                    Dictionary<ParameterExpression, (Type groupingType, Type asyncGroupingType)>? lambdaParamsToRewrite = null;

                    for (var j = 0; j < funcArgs.Length; j++)
                    {
                        foreach (var typeParamIdx in translatedTypeParameters.Keys)
                        {
                            if (funcArgs[j] == methodDefinitionGenericArguments[typeParamIdx])
                            {
                                // TODO: Perf: We can read out the kvps from the dictionary pairwise.
                                var groupingsTranslation = translatedTypeParameters[typeParamIdx];

                                lambdaParamsToRewrite ??= new();
                                lambdaParamsToRewrite.Add(lamdaParams[j], groupingsTranslation);
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

                        arguments[i] = Expression.Quote(translatedArg);
                    }
                }

                // TODO: Check that this condition holds in the builder!
                // We expect the return type to be IQueryable<TResult>

                var sequenceResultTypeDefinition = methodDefinition.ReturnType.GetGenericArguments()[0];

                // Check whether we have to pass on the group special case
                foreach (var typeParamIdx in translatedTypeParameters.Keys)
                {
                    if (sequenceResultTypeDefinition == methodDefinitionGenericArguments[typeParamIdx])
                    {
                        isResultGrouped = true;
                        var asyncGroupingType = translatedTypeParameters[typeParamIdx].asyncGroupingType;

                        // TODO: Do not store the constructed grouping types but the key and element types instead.
                        resultKeyType = asyncGroupingType.GetGenericArguments()[0];
                        resultElementType = asyncGroupingType.GetGenericArguments()[1];

                        break;
                    }
                }
            }

            return true;
        }

        private MethodInfo? ConstructTranslationTarget(Type[] genericArguments)
        {
            var translatedMethod = _translatedMethod;

            if (translatedMethod.IsGenericMethod)
            {
                translatedMethod = translatedMethod.MakeGenericMethod(genericArguments);
            }

            return translatedMethod;
        }

        private static bool IsCompatible(IReadOnlyList<Expression> arguments, MethodInfo translatedMethod)
        {
            var isCompatible = true;
            var parameters = translatedMethod.GetParameters();

            Debug.Assert(parameters.Length == arguments.Count);

            for (var i = 0; i < parameters.Length; i++)
            {
                var type = arguments[i].Type;

                if (type.IsAssignableTo(typeof(TranslatedQueryable)))
                {
                    if (!arguments[i].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                        return false;

                    if (translatedQueryable is null)
                        return false;

                    type = translatedQueryable.Expression.Type;
                }

                if (!type.IsAssignableTo(parameters[i].ParameterType))
                {
                    isCompatible = false;
                    break;
                }
            }

            return isCompatible;
        }
    }
}
