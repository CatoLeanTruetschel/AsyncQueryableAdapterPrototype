/* License
 * --------------------------------------------------------------------------------------------------------------------
 * (C) Copyright 2021 Cato Léan Trütschel and contributors 
 * (https://github.com/CatoLeanTruetschel/AsyncQueryableAdapterPrototype)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * --------------------------------------------------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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
    internal sealed class DefaultTranslator : MethodTranslator
    {
        [ThreadStatic]
        private static List<Expression>? _argumentsBuffer;

        public override bool TryTranslate(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            [NotNullWhen(true)] out Expression? result)
        {
            result = null;

            if (method.DeclaringType != typeof(System.Linq.AsyncQueryable))
                return false;

            // Try to find a method with the same signature in the System.Linq.Queryable type that works
            // on the type IQueryable (or IQueryable<T>) instead.
            if (!TryFindSyncQueryableMethod(method, out var translatedMethod))
                return false;

            if (!IsCompatible(arguments, translatedMethod))
                return false;

            result = TranslateMethod(instance, arguments, translatedQueryableArgumentIndices, translatedMethod);
            return true;
        }

        private static ConstantExpression TranslateMethod(
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            MethodInfo translatedMethod)
        {
            var translatedArguments = _argumentsBuffer ??= new List<Expression>();
            translatedArguments.Clear();
            translatedArguments.AddRange(arguments);

            QueryAdapterBase? queryAdapter = null;
            IQueryProvider? queryProvider = null;
            for (var i = 0; i < translatedQueryableArgumentIndices.Length; i++)
            {
                if (!translatedArguments[i].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                {
                    throw new Exception(); // TODO
                }

                if (translatedQueryable is null)
                {
                    throw new Exception(); // TODO
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

            var translatedExpression = Expression.Call(instance, translatedMethod, translatedArguments);
            // TODO: Not every call results in a queryable type. There may also be scalar results.
            var resultTranslatedQueryable = new TranslatedQueryable(
                queryAdapter, translatedExpression, queryProvider);

            return Expression.Constant(resultTranslatedQueryable);
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

        private static bool TryFindSyncQueryableMethod(
           MethodInfo asyncQueryableMethod,
           [NotNullWhen(true)] out MethodInfo? queryableMethod)
        {
            var asyncGenericArguments = asyncQueryableMethod.GetGenericArguments();
            var asyncParameters = asyncQueryableMethod.GetParameters();

            var methods = typeof(System.Linq.Queryable).GetMethods(BindingFlags.Public | BindingFlags.Static);

            for (var i = 0; i < methods.Length; i++)
            {
                var method = methods[i];

                if (!method.Name.Equals(asyncQueryableMethod.Name, StringComparison.Ordinal))
                {
                    continue;
                }

                if (!method.IsGenericMethodDefinition)
                {
                    continue;
                }

                if (method.GetGenericArguments().Length != asyncGenericArguments.Length)
                {
                    continue;
                }

                var genericMethod = method.MakeGenericMethod(asyncGenericArguments);
                var parameters = genericMethod.GetParameters();
                var argumentMatch = true;

                if (parameters.Length != asyncParameters.Length)
                {
                    continue;
                }

                for (var j = 0; j < parameters.Length; j++)
                {
                    var asyncParameter = asyncParameters[j];
                    var parameter = parameters[j];

                    if (!AreCompatibleTypes(parameter.ParameterType, asyncParameter.ParameterType))
                    {
                        argumentMatch = false;
                        break;
                    }
                }

                if (!argumentMatch)
                {
                    continue;
                }

                if (!AreCompatibleTypes(genericMethod.ReturnType, asyncQueryableMethod.ReturnType))
                {
                    continue;
                }

                queryableMethod = genericMethod;
                return true;
            }

            queryableMethod = null;
            return false;
        }

        private static bool AreCompatibleTypes(Type type, Type asyncType)
        {
            if (type.IsAssignableTo<IQueryable>() && !asyncType.IsAssignableTo<IQueryable>())
            {
                if (!asyncType.IsAssignableTo<IAsyncQueryable>())
                {
                    return false;
                }

                // Assume for now that this is the IQueryable<T> interface directly
                //TODO: Add some checks and implement a more general solution.
                Debug.Assert(type.IsGenericType);
                var elementType = type.GetGenericArguments().First();

                // Assume for now that this is the IAsyncQueryable<T> interface directly
                //TODO: Add some checks and implement a more general solution.
                Debug.Assert(asyncType.IsGenericType);
                var asyncElementType = type.GetGenericArguments().First();

                return elementType == asyncElementType;
            }

            return type == asyncType;
        }
    }
}
