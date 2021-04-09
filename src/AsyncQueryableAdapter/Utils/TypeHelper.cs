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

        public static Type GetAsyncQueryableType(Type sourceType)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = sourceType;
            return typeof(IAsyncQueryable<>).MakeGenericType(_1EntryTypeBuffer);
        }

        public static Type GetValueTaskType(Type type)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = type;
            return typeof(ValueTask<>).MakeGenericType(_1EntryTypeBuffer);
        }
    }
}
