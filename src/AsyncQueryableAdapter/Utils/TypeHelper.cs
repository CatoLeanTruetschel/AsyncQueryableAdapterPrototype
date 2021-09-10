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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncQueryableAdapter.Utils
{
    internal static class TypeHelper
    {
        [ThreadStatic]
        private static Type[]? _1EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _2EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _3EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _4EntryTypeBuffer;

        public static Type GetPredicateType(Type sourceType)
        {
            return GetFuncExpressionType(sourceType, typeof(bool));
        }

        public static Type GetAsyncPredicateType(Type sourceType)
        {
            return GetFuncExpressionType(sourceType, typeof(ValueTask<bool>));
        }

        public static Type GetAsyncPredicateWithCancellationType(Type sourceType)
        {
            _3EntryTypeBuffer ??= new Type[3];
            _3EntryTypeBuffer[0] = sourceType;
            _3EntryTypeBuffer[1] = typeof(CancellationToken);
            _3EntryTypeBuffer[2] = typeof(ValueTask<bool>);
            var selectorType = typeof(Func<,,>).MakeGenericType(_3EntryTypeBuffer);

            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = selectorType;
            var selectorExpressionType = typeof(Expression<>).MakeGenericType(_1EntryTypeBuffer);

            return selectorExpressionType;
        }

        public static Type GetFuncExpressionType(Type sourceType, Type resultType)
        {
            _2EntryTypeBuffer ??= new Type[2];
            _2EntryTypeBuffer[0] = sourceType;
            _2EntryTypeBuffer[1] = resultType;
            var selectorType = typeof(Func<,>).MakeGenericType(_2EntryTypeBuffer);

            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = selectorType;
            var selectorExpressionType = typeof(Expression<>).MakeGenericType(_1EntryTypeBuffer);

            return selectorExpressionType;
        }

        public static Type GetFuncExpressionType(Type sourceType1, Type sourceType2, Type resultType)
        {
            _3EntryTypeBuffer ??= new Type[3];
            _3EntryTypeBuffer[0] = sourceType1;
            _3EntryTypeBuffer[1] = sourceType2;
            _3EntryTypeBuffer[2] = resultType;
            var selectorType = typeof(Func<,,>).MakeGenericType(_3EntryTypeBuffer);

            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = selectorType;
            var selectorExpressionType = typeof(Expression<>).MakeGenericType(_1EntryTypeBuffer);

            return selectorExpressionType;
        }

        public static Type GetFuncExpressionType(Type sourceType1, Type sourceType2, Type sourceType3, Type resultType)
        {
            _4EntryTypeBuffer ??= new Type[4];
            _4EntryTypeBuffer[0] = sourceType1;
            _4EntryTypeBuffer[1] = sourceType2;
            _4EntryTypeBuffer[2] = sourceType3;
            _4EntryTypeBuffer[3] = resultType;
            var selectorType = typeof(Func<,,,>).MakeGenericType(_4EntryTypeBuffer);

            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = selectorType;
            var selectorExpressionType = typeof(Expression<>).MakeGenericType(_1EntryTypeBuffer);

            return selectorExpressionType;
        }

        public static Type GetAsyncQueryableType(Type sourceType)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = sourceType;
            return typeof(IAsyncQueryable<>).MakeGenericType(_1EntryTypeBuffer);
        }

        public static Type GetAsyncEnumerableType(Type sourceType)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = sourceType;
            return typeof(IAsyncEnumerable<>).MakeGenericType(_1EntryTypeBuffer);
        }

        public static Type GetGroupingType(Type keyType, Type elementType)
        {
            _2EntryTypeBuffer ??= new Type[2];
            _2EntryTypeBuffer[0] = keyType;
            _2EntryTypeBuffer[1] = elementType;
            return typeof(IGrouping<,>).MakeGenericType(_2EntryTypeBuffer);
        }

        public static Type GetAsyncGroupingType(Type keyType, Type elementType)
        {
            _2EntryTypeBuffer ??= new Type[2];
            _2EntryTypeBuffer[0] = keyType;
            _2EntryTypeBuffer[1] = elementType;
            return typeof(IAsyncGrouping<,>).MakeGenericType(_2EntryTypeBuffer);
        }

        public static Type GetValueTaskType(Type type)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = type;
            return typeof(ValueTask<>).MakeGenericType(_1EntryTypeBuffer);
        }

        public static Type GetEqualityComparerType(Type sourceType)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = sourceType;
            return typeof(IEqualityComparer<>).MakeGenericType(_1EntryTypeBuffer);
        }

        public static bool IsAsyncQueryableType(Type type, bool allowNonGeneric = false)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (type.IsGenericType)
            {
                var typeDefinition = type.GetGenericTypeDefinition();

                if (typeDefinition == typeof(IAsyncQueryable<>) || typeDefinition == typeof(IOrderedAsyncQueryable<>))
                {
                    return true;
                }
            }
            else if (allowNonGeneric)
            {
                return type == typeof(IAsyncQueryable) || type == typeof(IOrderedAsyncQueryable);
            }

            return false;
        }

        public static bool IsAsyncQueryableType(
            Type type,
            [NotNullWhen(true)] out Type? elementType)
        {
            return IsAsyncQueryableType(type, out elementType);
        }

        public static bool IsAsyncQueryableType(
            Type type,
            bool allowNonGeneric,
            [NotNullWhen(true)] out Type? elementType)
        {
            elementType = null;

            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (type.IsGenericType)
            {
                var typeDefinition = type.GetGenericTypeDefinition();

                if (typeDefinition == typeof(IAsyncQueryable<>) || typeDefinition == typeof(IOrderedAsyncQueryable<>))
                {
                    var genericArguments = type.GetGenericArguments();
                    elementType = genericArguments[0];
                    return true;
                }
            }
            else if (allowNonGeneric && (type == typeof(IAsyncQueryable) || type == typeof(IOrderedAsyncQueryable)))
            {
                elementType = typeof(object);
                return true;
            }

            return false;
        }
    }
}
