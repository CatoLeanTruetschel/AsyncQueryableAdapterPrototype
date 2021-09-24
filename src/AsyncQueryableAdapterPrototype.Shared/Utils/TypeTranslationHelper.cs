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
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;

namespace AsyncQueryableAdapter.Utils
{
    internal static partial class TypeTranslationHelper
    {
        public static bool IsEquivalentAsyncType(
            Type syncType,
            Type asyncType,
            EquivalentTypeMatch typeMatch = EquivalentTypeMatch.ExactMatch)
        {
            if (IsEquivalentAsyncTypeBaseCase(syncType, asyncType, typeMatch))
            {
                return true;
            }

            Type? syncElementType, asyncElementType;

            if (TypeHelper.IsGroupingType(syncType, out var syncKeyType, out syncElementType)
                && TypeHelper.IsAsyncGroupingType(asyncType, out var asyncKeyType, out asyncElementType))
            {
                if (IsEquivalentAsyncType(syncElementType, asyncElementType, typeMatch)
                    && IsEquivalentAsyncType(syncKeyType, asyncKeyType, typeMatch))
                {
                    return true;
                }
            }

            if (TypeHelper.IsQueryableType(syncType, allowNonGeneric: true, out syncElementType))
            {
                if (TypeHelper.IsAsyncQueryableType(asyncType, allowNonGeneric: true, out asyncElementType))
                {
                    if (IsEquivalentAsyncType(syncElementType, asyncElementType, typeMatch))
                    {
                        return true;
                    }
                }
                else if (typeMatch == EquivalentTypeMatch.AllowMoreSpecificSyncType
                    && TypeHelper.IsAsyncEnumerableType(asyncType, out asyncElementType))
                {
                    if (IsEquivalentAsyncType(syncElementType, asyncElementType, typeMatch))
                    {
                        return true;
                    }
                }
            }

            if (TypeHelper.IsEnumerableType(syncType, allowNonGeneric: true, out syncElementType))
            {
                if (TypeHelper.IsAsyncEnumerableType(asyncType, out asyncElementType))
                {
                    if (IsEquivalentAsyncType(syncElementType, asyncElementType, typeMatch))
                    {
                        return true;
                    }
                }
                else if (typeMatch == EquivalentTypeMatch.AllowMoreSpecificAsyncType
                    && TypeHelper.IsAsyncQueryableType(asyncType, allowNonGeneric: true, out asyncElementType))
                {
                    if (IsEquivalentAsyncType(syncElementType, asyncElementType, typeMatch))
                    {
                        return true;
                    }
                }
            }

            if (TypeHelper.IsValueTaskType(asyncType, out var resultType))
            {
                if (IsEquivalentAsyncType(syncType, resultType, typeMatch))
                {
                    return true;
                }
            }

            return IsEquivalentLambdaExpressionType(syncType, asyncType, typeMatch);
        }

        private static bool IsEquivalentAsyncTypeBaseCase(
            Type syncType,
            Type asyncType,
            EquivalentTypeMatch typeMatch)
        {
            if (syncType == asyncType)
            {
                return true;
            }

            if (typeMatch == EquivalentTypeMatch.AllowMoreSpecificAsyncType && asyncType.IsAssignableTo(syncType))
            {
                return true;
            }

            if (typeMatch == EquivalentTypeMatch.AllowMoreSpecificSyncType && syncType.IsAssignableTo(asyncType))
            {
                return true;
            }

            return false;
        }

        private static bool IsEquivalentLambdaExpressionType(
            Type syncType,
            Type asyncType,
            EquivalentTypeMatch typeMatch)
        {
            if (!TypeHelper.IsLambdaExpression(syncType, out var syncDelegateType))
            {
                if (typeMatch == EquivalentTypeMatch.AllowMoreSpecificAsyncType && TypeHelper.IsDelegate(syncType))
                {
                    syncDelegateType = syncType;
                }
                else
                {
                    return false;
                }
            }

            if (!TypeHelper.IsLambdaExpression(asyncType, out var asyncDelegateType))
            {
                if (typeMatch == EquivalentTypeMatch.AllowMoreSpecificSyncType && TypeHelper.IsDelegate(asyncType))
                {
                    asyncDelegateType = asyncType;
                }
                else
                {
                    return false;
                }
            }

            var syncMethod = syncDelegateType.GetMethod("Invoke")!;
            var asyncMethod = asyncDelegateType.GetMethod("Invoke")!;

            if (!IsEquivalentAsyncType(syncMethod.ReturnType, asyncMethod.ReturnType, typeMatch))
            {
                return false;
            }

            var syncParameters = syncMethod.GetParameters();
            var asyncParameters = asyncMethod.GetParameters();

            if (syncParameters.Length != asyncParameters.Length)
            {
                if (asyncParameters.Length != syncParameters.Length + 1
                    || asyncParameters[^1].ParameterType != typeof(CancellationToken))
                {
                    return false;
                }
            }

            var parameterTypeMatch = typeMatch switch
            {
                EquivalentTypeMatch.AllowMoreSpecificAsyncType => EquivalentTypeMatch.AllowMoreSpecificSyncType,
                EquivalentTypeMatch.AllowMoreSpecificSyncType => EquivalentTypeMatch.AllowMoreSpecificAsyncType,
                _ => EquivalentTypeMatch.ExactMatch,
            };

            for (var i = 0; i < syncParameters.Length; i++)
            {
                var parameterIsEquivalent = IsEquivalentAsyncType(
                    syncParameters[i].ParameterType,
                    asyncParameters[i].ParameterType,
                    parameterTypeMatch);

                if (!parameterIsEquivalent)
                {
                    return false;
                }
            }

            return true;
        }

        public enum EquivalentTypeMatch
        {
            ExactMatch = 0,
            AllowMoreSpecificSyncType,
            AllowMoreSpecificAsyncType,
        }

        public static bool AreArgumentsCompatible(MethodInfo method, IReadOnlyList<Expression> arguments)
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));

            if (arguments is null)
                throw new ArgumentNullException(nameof(arguments));

            var isCompatible = true;
            var parameters = method.GetParameters();

            if (parameters.Length != arguments.Count)
            {
                return false;
            }

            for (var i = 0; i < parameters.Length; i++)
            {
                if (arguments[i] is null)
                {
                    ThrowHelper.ThrowCollectionMustNotContainNullEntries(nameof(arguments));
                }

                var parameterType = parameters[i].ParameterType;
                var argument = arguments[i];
                var type = argument.Type;

                // TODO: Why was this necessary? The test all pass without this.
                //if (type.IsAssignableTo(typeof(TranslatedQueryable)))
                //{
                //    if (!arguments[i].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                //        return false;

                //    type = translatedQueryable.Expression.Type;
                //}

                if (!type.IsAssignableTo(parameterType))
                {
                    isCompatible = false;
                    break;
                }
            }

            return isCompatible;
        }
    }
}
