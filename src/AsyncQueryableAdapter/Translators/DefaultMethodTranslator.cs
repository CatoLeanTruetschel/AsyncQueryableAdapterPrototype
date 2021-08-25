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
using System.Collections.ObjectModel;
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
// * GroupBy (Default case) <-- This will be a special case probably, due to the special return type (IAsyncGrouping)
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
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            [NotNullWhen(true)] out Expression? result)
        {
            result = null;

            var constructedTranslationTarget = ConstructTranslationTarget(method);

            if (constructedTranslationTarget is null)
                return false;

            if (!IsCompatible(arguments, constructedTranslationTarget))
                return false;

            var translatedArguments = _argumentsBuffer ??= new List<Expression>();
            translatedArguments.Clear();
            translatedArguments.AddRange(arguments);

            QueryAdapterBase? queryAdapter = null;
            IQueryProvider? queryProvider = null;
            for (var i = 0; i < translatedQueryableArgumentIndices.Length; i++)
            {
                if (!translatedArguments[i].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                {
                    return false;
                }

                if (translatedQueryable is null)
                {
                    return false;
                }

                if (i == 0)
                {
                    queryAdapter = translatedQueryable.QueryAdapter;
                    queryProvider = translatedQueryable.QueryProvider;
                }
                else
                {
                    // Check whether the query adapter is the same as for the other translated 
                    // queryables, to ensure that all translated queryables refer to the same underlying
                    // database provider.
                    if (translatedQueryable.QueryAdapter != queryAdapter)
                    {
                        // TODO: Either throw, or process the rest in memory as post processing step.
                        // TODO: Exception message
                        throw new InvalidOperationException();
                    }
                }

                translatedArguments[i] = translatedQueryable.Expression;
            }

            Debug.Assert(queryAdapter is not null);
            Debug.Assert(queryProvider is not null);

            var translatedExpression = Expression.Call(instance, constructedTranslationTarget, translatedArguments);
            // TODO: Not every call results in a queryable type. There may also be scalar results.
            var resultTranslatedQueryable = new TranslatedQueryable(
                queryAdapter, translatedExpression, queryProvider);

            result = Expression.Constant(resultTranslatedQueryable);
            return true;
        }

        private MethodInfo? ConstructTranslationTarget(MethodInfo method)
        {
            var methodDefinition = method;
            var translatedMethod = _translatedMethod;

            if (methodDefinition.IsGenericMethod)
            {
                methodDefinition = methodDefinition.GetGenericMethodDefinition();
            }

            if (methodDefinition != _targetMethod)
            {
                return null;
            }

            if (translatedMethod.IsGenericMethod)
            {
                translatedMethod = translatedMethod.MakeGenericMethod(method.GetGenericArguments());
            }

            return translatedMethod;
        }

        private static bool IsCompatible(ReadOnlyCollection<Expression> arguments, MethodInfo translatedMethod)
        {
            var isCompatible = true;
            var parameters = translatedMethod.GetParameters();

            Debug.Assert(parameters.Length == arguments.Count);

            for (var i = 0; i < parameters.Length; i++)
            {
                var type = arguments[i].Type;

                if (type == typeof(TranslatedQueryable))
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
