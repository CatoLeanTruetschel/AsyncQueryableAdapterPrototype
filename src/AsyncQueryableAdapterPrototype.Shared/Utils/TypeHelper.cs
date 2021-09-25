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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncQueryableAdapter.Utils
{
    internal static partial class TypeHelper
    {
        [ThreadStatic]
        private static Type[]? _1EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _2EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _3EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _4EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _5EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _6EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _7EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _8EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _9EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _10EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _11EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _12EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _13EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _14EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _15EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _16EntryTypeBuffer;

        [ThreadStatic]
        private static Type[]? _17EntryTypeBuffer;

        private static readonly ImmutableList<Type> _funcTypeDefinitions = BuildFuncTypeDefinitions();
        private static readonly ImmutableHashSet<Type> _funcTypeLookpups = _funcTypeDefinitions.ToImmutableHashSet();

        private static ImmutableList<Type> BuildFuncTypeDefinitions()
        {
            var builder = ImmutableList.CreateBuilder<Type>();

            builder.Add(typeof(Func<>));
            builder.Add(typeof(Func<,>));
            builder.Add(typeof(Func<,,>));
            builder.Add(typeof(Func<,,,>));
            builder.Add(typeof(Func<,,,,>));
            builder.Add(typeof(Func<,,,,,>));
            builder.Add(typeof(Func<,,,,,,>));
            builder.Add(typeof(Func<,,,,,,,>));
            builder.Add(typeof(Func<,,,,,,,,>));
            builder.Add(typeof(Func<,,,,,,,,,>));
            builder.Add(typeof(Func<,,,,,,,,,,>));
            builder.Add(typeof(Func<,,,,,,,,,,,>));
            builder.Add(typeof(Func<,,,,,,,,,,,,>));
            builder.Add(typeof(Func<,,,,,,,,,,,,,>));
            builder.Add(typeof(Func<,,,,,,,,,,,,,,>));
            builder.Add(typeof(Func<,,,,,,,,,,,,,,,>));
            builder.Add(typeof(Func<,,,,,,,,,,,,,,,,>));

            return builder.ToImmutable();
        }

        public static Type GetFuncType(
            Type resultType)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = resultType;
            return typeof(Func<>).MakeGenericType(_1EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type resultType)
        {
            _2EntryTypeBuffer ??= new Type[2];
            _2EntryTypeBuffer[0] = t1;
            _2EntryTypeBuffer[1] = resultType;
            return typeof(Func<,>).MakeGenericType(_2EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type resultType)
        {
            _3EntryTypeBuffer ??= new Type[3];
            _3EntryTypeBuffer[0] = t1;
            _3EntryTypeBuffer[1] = t2;
            _3EntryTypeBuffer[2] = resultType;
            return typeof(Func<,,>).MakeGenericType(_3EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type resultType)
        {
            _4EntryTypeBuffer ??= new Type[4];
            _4EntryTypeBuffer[0] = t1;
            _4EntryTypeBuffer[1] = t2;
            _4EntryTypeBuffer[2] = t3;
            _4EntryTypeBuffer[3] = resultType;
            return typeof(Func<,,,>).MakeGenericType(_4EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type resultType)
        {
            _5EntryTypeBuffer ??= new Type[5];
            _5EntryTypeBuffer[0] = t1;
            _5EntryTypeBuffer[1] = t2;
            _5EntryTypeBuffer[2] = t3;
            _5EntryTypeBuffer[3] = t4;
            _5EntryTypeBuffer[4] = resultType;
            return typeof(Func<,,,,>).MakeGenericType(_5EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type resultType)
        {
            _6EntryTypeBuffer ??= new Type[6];
            _6EntryTypeBuffer[0] = t1;
            _6EntryTypeBuffer[1] = t2;
            _6EntryTypeBuffer[2] = t3;
            _6EntryTypeBuffer[3] = t4;
            _6EntryTypeBuffer[4] = t5;
            _6EntryTypeBuffer[5] = resultType;
            return typeof(Func<,,,,,>).MakeGenericType(_6EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type resultType)
        {
            _7EntryTypeBuffer ??= new Type[7];
            _7EntryTypeBuffer[0] = t1;
            _7EntryTypeBuffer[1] = t2;
            _7EntryTypeBuffer[2] = t3;
            _7EntryTypeBuffer[3] = t4;
            _7EntryTypeBuffer[4] = t5;
            _7EntryTypeBuffer[5] = t6;
            _7EntryTypeBuffer[6] = resultType;
            return typeof(Func<,,,,,,>).MakeGenericType(_7EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type t7,
            Type resultType)
        {
            _8EntryTypeBuffer ??= new Type[8];
            _8EntryTypeBuffer[0] = t1;
            _8EntryTypeBuffer[1] = t2;
            _8EntryTypeBuffer[2] = t3;
            _8EntryTypeBuffer[3] = t4;
            _8EntryTypeBuffer[4] = t5;
            _8EntryTypeBuffer[5] = t6;
            _8EntryTypeBuffer[6] = t7;
            _8EntryTypeBuffer[7] = resultType;
            return typeof(Func<,,,,,,,>).MakeGenericType(_8EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type t7,
            Type t8,
            Type resultType)
        {
            _9EntryTypeBuffer ??= new Type[9];
            _9EntryTypeBuffer[0] = t1;
            _9EntryTypeBuffer[1] = t2;
            _9EntryTypeBuffer[2] = t3;
            _9EntryTypeBuffer[3] = t4;
            _9EntryTypeBuffer[4] = t5;
            _9EntryTypeBuffer[5] = t6;
            _9EntryTypeBuffer[6] = t7;
            _9EntryTypeBuffer[7] = t8;
            _9EntryTypeBuffer[8] = resultType;
            return typeof(Func<,,,,,,,,>).MakeGenericType(_9EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type t7,
            Type t8,
            Type t9,
            Type resultType)
        {
            _10EntryTypeBuffer ??= new Type[10];
            _10EntryTypeBuffer[0] = t1;
            _10EntryTypeBuffer[1] = t2;
            _10EntryTypeBuffer[2] = t3;
            _10EntryTypeBuffer[3] = t4;
            _10EntryTypeBuffer[4] = t5;
            _10EntryTypeBuffer[5] = t6;
            _10EntryTypeBuffer[6] = t7;
            _10EntryTypeBuffer[7] = t8;
            _10EntryTypeBuffer[8] = t9;
            _10EntryTypeBuffer[9] = resultType;
            return typeof(Func<,,,,,,,,,>).MakeGenericType(_10EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type t7,
            Type t8,
            Type t9,
            Type t10,
            Type resultType)
        {
            _11EntryTypeBuffer ??= new Type[11];
            _11EntryTypeBuffer[0] = t1;
            _11EntryTypeBuffer[1] = t2;
            _11EntryTypeBuffer[2] = t3;
            _11EntryTypeBuffer[3] = t4;
            _11EntryTypeBuffer[4] = t5;
            _11EntryTypeBuffer[5] = t6;
            _11EntryTypeBuffer[6] = t7;
            _11EntryTypeBuffer[7] = t8;
            _11EntryTypeBuffer[8] = t9;
            _11EntryTypeBuffer[9] = t10;
            _11EntryTypeBuffer[10] = resultType;
            return typeof(Func<,,,,,,,,,,>).MakeGenericType(_11EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type t7,
            Type t8,
            Type t9,
            Type t10,
            Type t11,
            Type resultType)
        {
            _12EntryTypeBuffer ??= new Type[12];
            _12EntryTypeBuffer[0] = t1;
            _12EntryTypeBuffer[1] = t2;
            _12EntryTypeBuffer[2] = t3;
            _12EntryTypeBuffer[3] = t4;
            _12EntryTypeBuffer[4] = t5;
            _12EntryTypeBuffer[5] = t6;
            _12EntryTypeBuffer[6] = t7;
            _12EntryTypeBuffer[7] = t8;
            _12EntryTypeBuffer[8] = t9;
            _12EntryTypeBuffer[9] = t10;
            _12EntryTypeBuffer[10] = t11;
            _12EntryTypeBuffer[11] = resultType;
            return typeof(Func<,,,,,,,,,,,>).MakeGenericType(_12EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type t7,
            Type t8,
            Type t9,
            Type t10,
            Type t11,
            Type t12,
            Type resultType)
        {
            _13EntryTypeBuffer ??= new Type[13];
            _13EntryTypeBuffer[0] = t1;
            _13EntryTypeBuffer[1] = t2;
            _13EntryTypeBuffer[2] = t3;
            _13EntryTypeBuffer[3] = t4;
            _13EntryTypeBuffer[4] = t5;
            _13EntryTypeBuffer[5] = t6;
            _13EntryTypeBuffer[6] = t7;
            _13EntryTypeBuffer[7] = t8;
            _13EntryTypeBuffer[8] = t9;
            _13EntryTypeBuffer[9] = t10;
            _13EntryTypeBuffer[10] = t11;
            _13EntryTypeBuffer[11] = t12;
            _13EntryTypeBuffer[12] = resultType;
            return typeof(Func<,,,,,,,,,,,,>).MakeGenericType(_13EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type t7,
            Type t8,
            Type t9,
            Type t10,
            Type t11,
            Type t12,
            Type t13,
            Type resultType)
        {
            _14EntryTypeBuffer ??= new Type[14];
            _14EntryTypeBuffer[0] = t1;
            _14EntryTypeBuffer[1] = t2;
            _14EntryTypeBuffer[2] = t3;
            _14EntryTypeBuffer[3] = t4;
            _14EntryTypeBuffer[4] = t5;
            _14EntryTypeBuffer[5] = t6;
            _14EntryTypeBuffer[6] = t7;
            _14EntryTypeBuffer[7] = t8;
            _14EntryTypeBuffer[8] = t9;
            _14EntryTypeBuffer[9] = t10;
            _14EntryTypeBuffer[10] = t11;
            _14EntryTypeBuffer[11] = t12;
            _14EntryTypeBuffer[12] = t13;
            _14EntryTypeBuffer[13] = resultType;
            return typeof(Func<,,,,,,,,,,,,,>).MakeGenericType(_14EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type t7,
            Type t8,
            Type t9,
            Type t10,
            Type t11,
            Type t12,
            Type t13,
            Type t14,
            Type resultType)
        {
            _15EntryTypeBuffer ??= new Type[15];
            _15EntryTypeBuffer[0] = t1;
            _15EntryTypeBuffer[1] = t2;
            _15EntryTypeBuffer[2] = t3;
            _15EntryTypeBuffer[3] = t4;
            _15EntryTypeBuffer[4] = t5;
            _15EntryTypeBuffer[5] = t6;
            _15EntryTypeBuffer[6] = t7;
            _15EntryTypeBuffer[7] = t8;
            _15EntryTypeBuffer[8] = t9;
            _15EntryTypeBuffer[9] = t10;
            _15EntryTypeBuffer[10] = t11;
            _15EntryTypeBuffer[11] = t12;
            _15EntryTypeBuffer[12] = t13;
            _15EntryTypeBuffer[13] = t14;
            _15EntryTypeBuffer[14] = resultType;
            return typeof(Func<,,,,,,,,,,,,,,>).MakeGenericType(_15EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type t7,
            Type t8,
            Type t9,
            Type t10,
            Type t11,
            Type t12,
            Type t13,
            Type t14,
            Type t15,
            Type resultType)
        {
            _16EntryTypeBuffer ??= new Type[16];
            _16EntryTypeBuffer[0] = t1;
            _16EntryTypeBuffer[1] = t2;
            _16EntryTypeBuffer[2] = t3;
            _16EntryTypeBuffer[3] = t4;
            _16EntryTypeBuffer[4] = t5;
            _16EntryTypeBuffer[5] = t6;
            _16EntryTypeBuffer[6] = t7;
            _16EntryTypeBuffer[7] = t8;
            _16EntryTypeBuffer[8] = t9;
            _16EntryTypeBuffer[9] = t10;
            _16EntryTypeBuffer[10] = t11;
            _16EntryTypeBuffer[11] = t12;
            _16EntryTypeBuffer[12] = t13;
            _16EntryTypeBuffer[13] = t14;
            _16EntryTypeBuffer[14] = t15;
            _16EntryTypeBuffer[15] = resultType;
            return typeof(Func<,,,,,,,,,,,,,,,>).MakeGenericType(_16EntryTypeBuffer);
        }

        public static Type GetFuncType(
            Type t1,
            Type t2,
            Type t3,
            Type t4,
            Type t5,
            Type t6,
            Type t7,
            Type t8,
            Type t9,
            Type t10,
            Type t11,
            Type t12,
            Type t13,
            Type t14,
            Type t15,
            Type t16,
            Type resultType)
        {
            _17EntryTypeBuffer ??= new Type[17];
            _17EntryTypeBuffer[0] = t1;
            _17EntryTypeBuffer[1] = t2;
            _17EntryTypeBuffer[2] = t3;
            _17EntryTypeBuffer[3] = t4;
            _17EntryTypeBuffer[4] = t5;
            _17EntryTypeBuffer[5] = t6;
            _17EntryTypeBuffer[6] = t7;
            _17EntryTypeBuffer[7] = t8;
            _17EntryTypeBuffer[8] = t9;
            _17EntryTypeBuffer[9] = t10;
            _17EntryTypeBuffer[10] = t11;
            _17EntryTypeBuffer[11] = t12;
            _17EntryTypeBuffer[12] = t13;
            _17EntryTypeBuffer[13] = t14;
            _17EntryTypeBuffer[14] = t15;
            _17EntryTypeBuffer[15] = t16;
            _17EntryTypeBuffer[16] = resultType;
            return typeof(Func<,,,,,,,,,,,,,,,,>).MakeGenericType(_17EntryTypeBuffer);
        }

        public static Type GetFuncType(ReadOnlySpan<Type> types, Type resultType)
        {
            Type[] arr;

            switch (types.Length)
            {
                case 0:
                    _1EntryTypeBuffer ??= new Type[1];
                    arr = _1EntryTypeBuffer;
                    break;
                case 1:
                    _2EntryTypeBuffer ??= new Type[2];
                    arr = _2EntryTypeBuffer;
                    break;
                case 2:
                    _3EntryTypeBuffer ??= new Type[3];
                    arr = _3EntryTypeBuffer;
                    break;
                case 3:
                    _4EntryTypeBuffer ??= new Type[4];
                    arr = _4EntryTypeBuffer;
                    break;
                case 4:
                    _5EntryTypeBuffer ??= new Type[5];
                    arr = _5EntryTypeBuffer;
                    break;
                case 5:
                    _6EntryTypeBuffer ??= new Type[6];
                    arr = _6EntryTypeBuffer;
                    break;
                case 6:
                    _7EntryTypeBuffer ??= new Type[7];
                    arr = _7EntryTypeBuffer;
                    break;
                case 7:
                    _8EntryTypeBuffer ??= new Type[8];
                    arr = _8EntryTypeBuffer;
                    break;
                case 8:
                    _9EntryTypeBuffer ??= new Type[9];
                    arr = _9EntryTypeBuffer;
                    break;
                case 9:
                    _10EntryTypeBuffer ??= new Type[10];
                    arr = _10EntryTypeBuffer;
                    break;
                case 10:
                    _11EntryTypeBuffer ??= new Type[11];
                    arr = _11EntryTypeBuffer;
                    break;
                case 11:
                    _12EntryTypeBuffer ??= new Type[12];
                    arr = _12EntryTypeBuffer;
                    break;
                case 12:
                    _13EntryTypeBuffer ??= new Type[13];
                    arr = _13EntryTypeBuffer;
                    break;
                case 13:
                    _14EntryTypeBuffer ??= new Type[14];
                    arr = _14EntryTypeBuffer;
                    break;
                case 14:
                    _15EntryTypeBuffer ??= new Type[15];
                    arr = _15EntryTypeBuffer;
                    break;
                case 15:
                    _16EntryTypeBuffer ??= new Type[16];
                    arr = _16EntryTypeBuffer;
                    break;
                case 16:
                    _17EntryTypeBuffer ??= new Type[17];
                    arr = _17EntryTypeBuffer;
                    break;
                default:
                    throw new ArgumentException("A Func type for the specified amount of parameters is not defined.");
            }

            types.CopyTo(arr.AsSpan());
            arr[^1] = resultType;

            return _funcTypeDefinitions[types.Length].MakeGenericType(arr);
        }

        public static Type GetFuncType(IReadOnlyList<Type> types, Type resultType)
        {
            Type[] arr;

            switch (types.Count)
            {
                case 0:
                    _1EntryTypeBuffer ??= new Type[1];
                    arr = _1EntryTypeBuffer;
                    break;
                case 1:
                    _2EntryTypeBuffer ??= new Type[2];
                    arr = _2EntryTypeBuffer;
                    break;
                case 2:
                    _3EntryTypeBuffer ??= new Type[3];
                    arr = _3EntryTypeBuffer;
                    break;
                case 3:
                    _4EntryTypeBuffer ??= new Type[4];
                    arr = _4EntryTypeBuffer;
                    break;
                case 4:
                    _5EntryTypeBuffer ??= new Type[5];
                    arr = _5EntryTypeBuffer;
                    break;
                case 5:
                    _6EntryTypeBuffer ??= new Type[6];
                    arr = _6EntryTypeBuffer;
                    break;
                case 6:
                    _7EntryTypeBuffer ??= new Type[7];
                    arr = _7EntryTypeBuffer;
                    break;
                case 7:
                    _8EntryTypeBuffer ??= new Type[8];
                    arr = _8EntryTypeBuffer;
                    break;
                case 8:
                    _9EntryTypeBuffer ??= new Type[9];
                    arr = _9EntryTypeBuffer;
                    break;
                case 9:
                    _10EntryTypeBuffer ??= new Type[10];
                    arr = _10EntryTypeBuffer;
                    break;
                case 10:
                    _11EntryTypeBuffer ??= new Type[11];
                    arr = _11EntryTypeBuffer;
                    break;
                case 11:
                    _12EntryTypeBuffer ??= new Type[12];
                    arr = _12EntryTypeBuffer;
                    break;
                case 12:
                    _13EntryTypeBuffer ??= new Type[13];
                    arr = _13EntryTypeBuffer;
                    break;
                case 13:
                    _14EntryTypeBuffer ??= new Type[14];
                    arr = _14EntryTypeBuffer;
                    break;
                case 14:
                    _15EntryTypeBuffer ??= new Type[15];
                    arr = _15EntryTypeBuffer;
                    break;
                case 15:
                    _16EntryTypeBuffer ??= new Type[16];
                    arr = _16EntryTypeBuffer;
                    break;
                case 16:
                    _17EntryTypeBuffer ??= new Type[17];
                    arr = _17EntryTypeBuffer;
                    break;
                default:
                    throw new ArgumentException("A Func type for the specified amount of parameters is not defined.");
            }

            if (types is Type[] array)
            {
                array.CopyTo(arr.AsSpan());
            }
            else if (types is ICollection<Type> collection)
            {
                collection.CopyTo(arr, arrayIndex: 0);
            }
            else
            {
                for (var i = 0; i < types.Count; i++)
                {
                    arr[i] = types[i];
                }
            }

            arr[^1] = resultType;

            return _funcTypeDefinitions[types.Count].MakeGenericType(arr);
        }

        public static bool IsFuncType(
            Type type,
            [NotNullWhen(true)] out Type? returnType,
            [NotNullWhen(true)] out ParameterInfo[]? parameters)
        {
            returnType = null;
            parameters = null;

            if (!IsFuncType(type))
            {
                return false;
            }

            var method = type.GetMethod("Invoke")!;

            returnType = method.ReturnType;
            parameters = method.GetParameters();

            return true;
        }

        public static bool IsFuncType(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsGenericType)
                return false;

            var typeDefinitions = type.GetGenericTypeDefinition();
            return _funcTypeLookpups.Contains(typeDefinitions);
        }

        public static bool IsFuncType<T>()
        {
            return IsFuncType(typeof(T));
        }

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
            var delegateType = typeof(Func<,,>).MakeGenericType(_3EntryTypeBuffer);
            var delegateExpressionType = GetExpressionType(delegateType);

            return delegateExpressionType;
        }

        public static Type GetExpressionType(Type delegateType)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = delegateType;
            var result = typeof(Expression<>).MakeGenericType(_1EntryTypeBuffer);

            return result;
        }

        public static Type GetFuncExpressionType(Type sourceType, Type resultType)
        {
            _2EntryTypeBuffer ??= new Type[2];
            _2EntryTypeBuffer[0] = sourceType;
            _2EntryTypeBuffer[1] = resultType;
            var delegateType = typeof(Func<,>).MakeGenericType(_2EntryTypeBuffer);
            var delegateExpressionType = GetExpressionType(delegateType);

            return delegateExpressionType;
        }

        public static Type GetFuncExpressionType(Type sourceType1, Type sourceType2, Type resultType)
        {
            _3EntryTypeBuffer ??= new Type[3];
            _3EntryTypeBuffer[0] = sourceType1;
            _3EntryTypeBuffer[1] = sourceType2;
            _3EntryTypeBuffer[2] = resultType;
            var delegateType = typeof(Func<,,>).MakeGenericType(_3EntryTypeBuffer);
            var delegateExpressionType = GetExpressionType(delegateType);

            return delegateExpressionType;
        }

        public static Type GetFuncExpressionType(Type sourceType1, Type sourceType2, Type sourceType3, Type resultType)
        {
            _4EntryTypeBuffer ??= new Type[4];
            _4EntryTypeBuffer[0] = sourceType1;
            _4EntryTypeBuffer[1] = sourceType2;
            _4EntryTypeBuffer[2] = sourceType3;
            _4EntryTypeBuffer[3] = resultType;
            var delegateType = typeof(Func<,,,>).MakeGenericType(_4EntryTypeBuffer);
            var delegateExpressionType = GetExpressionType(delegateType);

            return delegateExpressionType;
        }

        public static Type GetQueryableType(Type elementType)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = elementType;
            return typeof(IQueryable<>).MakeGenericType(_1EntryTypeBuffer);
        }

        public static Type GetAsyncQueryableType(Type elementType)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = elementType;
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

        private static bool HasCovariantConversion(Type originalType, Type derivedType)
        {
            if (originalType.IsValueType)
            {
                return false;
            }

            if (derivedType.IsValueType)
            {
                return false;
            }

            return derivedType.IsSubclassOf(originalType);
        }

        public static bool IsComparerType(Type type)
        {
            if (!type.IsGenericType)
            {
                return false;
            }

            if (type.GetGenericTypeDefinition() != typeof(IComparer<>))
            {
                return false;
            }

            return true;
        }

        public static bool IsComparerType(Type type, [NotNullWhen(true)] out Type? comparisonType)
        {
            if (!IsComparerType(type))
            {
                comparisonType = null;
                return false;
            }

            comparisonType = type.GetGenericArguments()[0];
            return true;
        }

        public static bool IsEqualityComparerType(Type type)
        {
            if (!type.IsGenericType)
            {
                return false;
            }

            if (type.GetGenericTypeDefinition() != typeof(IEqualityComparer<>))
            {
                return false;
            }

            return true;
        }

        public static bool IsEqualityComparerType(Type type, [NotNullWhen(true)] out Type? comparisonType)
        {
            if (!IsEqualityComparerType(type))
            {
                comparisonType = null;
                return false;
            }

            comparisonType = type.GetGenericArguments()[0];
            return true;
        }

        public static bool IsDelegate(Type type)
        {
            return typeof(MulticastDelegate).IsAssignableFrom(type.BaseType);
        }

        public static bool IsLambdaExpression(Type type)
        {
            return type.IsAssignableTo(typeof(LambdaExpression));
        }

        public static bool IsLambdaExpression(Type type, [NotNullWhen(true)] out Type? delegateType)
        {
            if (!IsLambdaExpression(type))
            {
                delegateType = null;
                return false;
            }

            delegateType = typeof(Delegate);

            if (type.IsGenericType)
            {
                Debug.Assert(type.GetGenericTypeDefinition() == typeof(Expression<>));

                delegateType = type.GetGenericArguments()[0];
            }

            return true;
        }

        public static bool IsGroupingType(Type type)
        {
            if (!type.IsGenericType)
            {
                return false;
            }

            if (type.GetGenericTypeDefinition() != typeof(IGrouping<,>))
            {
                return false;
            }

            return true;
        }

        public static bool IsGroupingType(
            Type type,
            [NotNullWhen(true)] out Type? keyType,
            [NotNullWhen(true)] out Type? elementType)
        {
            if (!IsGroupingType(type))
            {
                keyType = null;
                elementType = null;
                return false;
            }

            var genericArguments = type.GetGenericArguments();
            keyType = genericArguments[0];
            elementType = genericArguments[1];
            return true;
        }

        public static bool IsAsyncGroupingType(Type type)
        {
            if (!type.IsGenericType)
            {
                return false;
            }

            if (type.GetGenericTypeDefinition() != typeof(IAsyncGrouping<,>))
            {
                return false;
            }

            return true;
        }

        public static bool IsAsyncGroupingType(Type type, Type keyType, Type elementType, bool exactMatch = true)
        {
            if (!IsAsyncGroupingType(type, out var actualKeyType, out var actualElementType))
                return false;

            if (actualKeyType != keyType && (exactMatch || !HasCovariantConversion(keyType, actualKeyType)))
                return false;

            if (actualElementType != elementType
                && (exactMatch || !HasCovariantConversion(elementType, actualElementType)))
                return false;

            return true;
        }

        public static bool IsAsyncGroupingType(
            Type type,
            [NotNullWhen(true)] out Type? keyType,
            [NotNullWhen(true)] out Type? elementType)
        {
            if (!IsAsyncGroupingType(type))
            {
                keyType = null;
                elementType = null;
                return false;
            }

            var genericArguments = type.GetGenericArguments();
            keyType = genericArguments[0];
            elementType = genericArguments[1];
            return true;
        }

        public static bool IsAsyncEnumerableType(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (type.IsGenericType)
            {
                var typeDefinition = type.GetGenericTypeDefinition();

                if (typeDefinition == typeof(IAsyncEnumerable<>) || typeDefinition == typeof(IOrderedAsyncEnumerable<>))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsAsyncEnumerableType(
            Type type,
            [NotNullWhen(true)] out Type? elementType)
        {
            elementType = null;

            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (type.IsGenericType)
            {
                var typeDefinition = type.GetGenericTypeDefinition();

                if (typeDefinition == typeof(IAsyncEnumerable<>) || typeDefinition == typeof(IOrderedAsyncEnumerable<>))
                {
                    var genericArguments = type.GetGenericArguments();
                    elementType = genericArguments[0];
                    return true;
                }
            }

            return false;
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
            return IsAsyncQueryableType(type, allowNonGeneric: false, out elementType);
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

        public static bool IsEnumerableType(Type type, bool allowNonGeneric = false)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (type.IsGenericType)
            {
                var typeDefinition = type.GetGenericTypeDefinition();

                if (typeDefinition == typeof(IEnumerable<>) || typeDefinition == typeof(IOrderedEnumerable<>))
                {
                    return true;
                }
            }
            else if (allowNonGeneric)
            {
                return type == typeof(IEnumerable);
            }

            return false;
        }

        public static bool IsEnumerableType(
            Type type,
            [NotNullWhen(true)] out Type? elementType)
        {
            return IsEnumerableType(type, allowNonGeneric: false, out elementType);
        }

        public static bool IsEnumerableType(
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

                if (typeDefinition == typeof(IEnumerable<>) || typeDefinition == typeof(IOrderedEnumerable<>))
                {
                    var genericArguments = type.GetGenericArguments();
                    elementType = genericArguments[0];
                    return true;
                }
            }
            else if (allowNonGeneric && (type == typeof(IEnumerable)))
            {
                elementType = typeof(object);
                return true;
            }

            return false;
        }

        public static bool IsQueryableType(Type type, bool allowNonGeneric = false)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (type.IsGenericType)
            {
                var typeDefinition = type.GetGenericTypeDefinition();

                if (typeDefinition == typeof(IQueryable<>) || typeDefinition == typeof(IOrderedQueryable<>))
                {
                    return true;
                }
            }
            else if (allowNonGeneric)
            {
                return type == typeof(IQueryable) || type == typeof(IOrderedQueryable);
            }

            return false;
        }

        public static bool IsQueryableType(
            Type type,
            [NotNullWhen(true)] out Type? elementType)
        {
            return IsQueryableType(type, allowNonGeneric: false, out elementType);
        }

        public static bool IsQueryableType(
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

                if (typeDefinition == typeof(IQueryable<>) || typeDefinition == typeof(IOrderedQueryable<>))
                {
                    var genericArguments = type.GetGenericArguments();
                    elementType = genericArguments[0];
                    return true;
                }
            }
            else if (allowNonGeneric && (type == typeof(IQueryable) || type == typeof(IOrderedQueryable)))
            {
                elementType = typeof(object);
                return true;
            }

            return false;
        }

        public static bool IsValueTaskType(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsGenericType)
            {
                return type == typeof(ValueTask);
            }

            return type.GetGenericTypeDefinition() == typeof(ValueTask<>);

        }

        public static bool IsValueTaskType(Type type, [NotNullWhen(true)] out Type? resultType)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsGenericType)
            {
                resultType = typeof(void);
                return type == typeof(ValueTask);
            }

            if (type.GetGenericTypeDefinition() == typeof(ValueTask<>))
            {
                resultType = type.GetGenericArguments()[0];
                return true;
            }

            resultType = null;
            return false;
        }

        public static bool IsNullableType(Type type)
        {
            return type.IsValueType
                && type.IsConstructedGenericType
                && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static bool IsNullableType(Type type, [NotNullWhen(true)] out Type? underlyingType)
        {
            underlyingType = Nullable.GetUnderlyingType(type);
            return underlyingType is not null;
        }

        public static bool IsNullableIntegratedNumericType(Type type)
        {
            if (!IsNullableType(type, out var underlyingType))
            {
                return false;
            }

            return IsIntegratedNumericType(underlyingType);
        }

        public static bool IsNullableIntegratedNumericType(Type type, [NotNullWhen(true)] out Type? underlyingType)
        {
            if (!IsNullableType(type, out underlyingType))
            {
                return false;
            }

            return IsIntegratedNumericType(underlyingType);
        }

        public static bool IsIntegratedNumericType(Type type)
        {
            if (type == typeof(byte))
            {
                return true;
            }

            if (type == typeof(sbyte))
            {
                return true;
            }

            if (type == typeof(decimal))
            {
                return true;
            }

            if (type == typeof(double))
            {
                return true;
            }

            if (type == typeof(float))
            {
                return true;
            }

            if (type == typeof(int))
            {
                return true;
            }

            if (type == typeof(uint))
            {
                return true;
            }

            if (type == typeof(nint))
            {
                return true;
            }

            if (type == typeof(nuint))
            {
                return true;
            }

            if (type == typeof(long))
            {
                return true;
            }

            if (type == typeof(ulong))
            {
                return true;
            }

            if (type == typeof(short))
            {
                return true;
            }

            if (type == typeof(ushort))
            {
                return true;
            }

            return false;
        }

        public static string? GetIntegratedNumericTypeSuffix(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            string? suffix = null;

            if (type == typeof(long))
            {
                suffix = "L";
            }
            else if (type == typeof(double))
            {
                suffix = "D";
            }
            else if (type == typeof(float))
            {
                suffix = "F";
            }
            else if (type == typeof(decimal))
            {
                suffix = "M";
            }
            else if (type == typeof(uint))
            {
                suffix = "U";
            }
            else if (type == typeof(ulong))
            {
                suffix = "UL";
            }
            else if (type == typeof(int))
            {
                suffix = string.Empty;
            }

            return suffix;
        }

        public static Type? IntegratedNumericTypeArithmeticOperationResult(Type type1, Type type2)
        {
            if (type1 == typeof(byte) || type1 == typeof(sbyte) || type1 == typeof(ushort) || type1 == typeof(short))
            {
                type1 = typeof(int);
            }

            if (type1 == typeof(float) || type2 == typeof(float))
            {
                return typeof(float);
            }
            else if (type1 == typeof(double) || type2 == typeof(double))
            {
                return typeof(double);
            }
            else if (type1 == typeof(decimal) || type2 == typeof(decimal))
            {
                return typeof(decimal);
            }

            if (!IsIntegratedNumericType(type1) || !IsIntegratedNumericType(type2))
            {
                return null;
            }

            if (type1 == type2)
            {
                return type1;
            }

            if (type1 == typeof(int) && type2 == typeof(nint) || type1 == typeof(nint) && type2 == typeof(int))
            {
                return typeof(nint);
            }

            if (type1 == typeof(uint) && type2 == typeof(nuint) || type1 == typeof(nuint) && type2 == typeof(uint))
            {
                return typeof(nuint);
            }

            if (type1 == typeof(int) && type2 == typeof(uint)
                || type1 == typeof(uint) && type2 == typeof(int)
                || type1 == typeof(long) && type2 == typeof(int)
                || type1 == typeof(int) && type2 == typeof(long)
                || type1 == typeof(nint) && type2 == typeof(uint)
                || type1 == typeof(uint) && type2 == typeof(nint)
                || type1 == typeof(long) && type2 == typeof(uint)
                || type1 == typeof(uint) && type2 == typeof(long)
                || type1 == typeof(long) && type2 == typeof(nint)
                || type1 == typeof(nint) && type2 == typeof(long))
            {
                return typeof(long);
            }

            if (type1 == typeof(ulong) && type2 == typeof(uint)
                || type1 == typeof(uint) && type2 == typeof(ulong)
                || type1 == typeof(ulong) && type2 == typeof(nuint)
                || type1 == typeof(nuint) && type2 == typeof(ulong))
            {
                return typeof(ulong);
            }

            return null;
        }

#if SUPPORTS_READ_ONLY_SET
        public static string FormatCSharpTypeName(Type type, IEnumerable<string>? knownNamespaces)
        {
            if (knownNamespaces is null)
            {
                return FormatCSharpTypeName(type, null as IReadOnlySet<string>);
            }

            if (knownNamespaces is IReadOnlySet<string> readOnlySet)
            {
                return FormatCSharpTypeName(type, readOnlySet);
            }

            return FormatCSharpTypeName(type, knownNamespaces.ToImmutableHashSet());
        }

        public static string FormatCSharpTypeName(Type type, IReadOnlySet<string>? knownNamespaces = null)
#else
        public static string FormatCSharpTypeName(Type type, IEnumerable<string>? knownNamespaces = null)
#endif
        {
            if (type == typeof(void))
            {
                throw new ArgumentException("Cannot represent System.Void in C# Syntax in this context.");
            }

            if (IsSpecialCSharpTypeAlias(type, out var alias))
            {
                return alias;
            }

            var builder = new StringBuilder();
            FormatCSharpTypeName(type, builder, knownNamespaces);
            return builder.ToString();

        }

        private static bool IsSpecialCSharpTypeAlias(Type type, [NotNullWhen(true)] out string? alias)
        {
            if (type == typeof(bool))
            {
                alias = "bool";
                return true;
            }

            if (type == typeof(byte))
            {
                alias = "byte";
                return true;
            }

            if (type == typeof(sbyte))
            {
                alias = "sbyte";
                return true;
            }

            if (type == typeof(char))
            {
                alias = "char";
                return true;
            }

            if (type == typeof(decimal))
            {
                alias = "decimal";
                return true;
            }

            if (type == typeof(double))
            {
                alias = "double";
                return true;
            }

            if (type == typeof(float))
            {
                alias = "float";
                return true;
            }

            if (type == typeof(int))
            {
                alias = "int";
                return true;
            }

            if (type == typeof(uint))
            {
                alias = "uint";
                return true;
            }

            if (type == typeof(nint))
            {
                alias = "nint";
                return true;
            }

            if (type == typeof(nuint))
            {
                alias = "nuint";
                return true;
            }

            if (type == typeof(long))
            {
                alias = "long";
                return true;
            }

            if (type == typeof(ulong))
            {
                alias = "ulong";
                return true;
            }

            if (type == typeof(short))
            {
                alias = "short";
                return true;
            }

            if (type == typeof(ushort))
            {
                alias = "ushort";
                return true;
            }

            if (type == typeof(object))
            {
                alias = "object";
                return true;
            }

            if (type == typeof(void))
            {
                alias = "void";
                return true;
            }

            alias = null;
            return false;
        }

#if SUPPORTS_READ_ONLY_SET
        private static void FormatCSharpTypeName(
            Type type,
            StringBuilder builder,
            IReadOnlySet<string>? knownNamespaces)
#else
        private static void FormatCSharpTypeName(
            Type type,
            StringBuilder builder,
            IEnumerable<string>? knownNamespaces)
#endif
        {
            if (IsSpecialCSharpTypeAlias(type, out var alias))
            {
                builder.Append(alias);
            }
            else if (type.IsArray)
            {
                // TODO: This does not handle the case of a non SZ array with 1 rank or a non SZ array with a lower bound
                // that is not 0
                var arrayRank = type.GetArrayRank();
                var elementType = type.GetElementType();

                FormatCSharpTypeName(elementType!, builder, knownNamespaces);
                builder.Append('[');
                builder.Append(',', arrayRank - 1);
                builder.Append(']');
            }
            else if (type.IsPointer)
            {
                var elementType = type.GetElementType();
                FormatCSharpTypeName(elementType!, builder, knownNamespaces);
                builder.Append('*');
            }
            else if (type.IsByRef)
            {
                var elementType = type.GetElementType();
                builder.Append("ref ");
                FormatCSharpTypeName(elementType!, builder, knownNamespaces);
            }
            else if (type.IsGenericType)
            {
                var typeDef = type.GetGenericTypeDefinition();
                var genericArgs = type.GetGenericArguments();

                if (type.IsConstructedGenericType && typeDef == typeof(Nullable<>))
                {
                    FormatCSharpTypeName(genericArgs[0], builder, knownNamespaces);
                    builder.Append('?');
                }
                else
                {
                    var hasPrefix = FormatCSharpTypeNamespace(typeDef, builder, knownNamespaces);

                    if (hasPrefix)
                    {
                        builder.Append('.');
                    }

                    builder.Append(typeDef.Name.Substring(0, typeDef.Name.IndexOf("`", StringComparison.Ordinal)));
                    builder.Append('<');

                    if (type.IsGenericTypeDefinition)
                    {
                        builder.Append(',', genericArgs.Length - 1);
                    }
                    else if (type.IsConstructedGenericType)
                    {
                        for (var i = 0; i < genericArgs.Length; i++)
                        {
                            FormatCSharpTypeName(genericArgs[i], builder, knownNamespaces);

                            if (i < genericArgs.Length - 1)
                            {
                                builder.Append(',');
                                builder.Append(' ');
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Cannot represent a partially constructed generic type in C# syntax.");
                    }

                    builder.Append('>');
                }
            }
            else
            {
                var hasPrefix = FormatCSharpTypeNamespace(type, builder, knownNamespaces);

                if (hasPrefix)
                {
                    builder.Append('.');
                }

                builder.Append(type.Name);
            }
        }

#if SUPPORTS_READ_ONLY_SET
        private static bool FormatCSharpTypeNamespace(
            Type type,
            StringBuilder builder,
            IReadOnlySet<string>? knownNamespaces)
#else
        private static bool FormatCSharpTypeNamespace(
            Type type,
            StringBuilder builder,
            IEnumerable<string>? knownNamespaces)
#endif
        {
            if (type.DeclaringType is null)
            {
                if (type.Namespace is not null
                    && knownNamespaces is not null
                    && knownNamespaces.Contains(type.Namespace))
                {
                    return false;
                }

                builder.Append(type.Namespace);
                return !string.IsNullOrEmpty(type.Namespace);
            }

            var hasPrefix = FormatCSharpTypeNamespace(type.DeclaringType, builder, knownNamespaces);

            if (hasPrefix)
            {
                builder.Append('.');
            }

            if (type.DeclaringType.IsGenericType)
            {
                if (type.DeclaringType.IsConstructedGenericType)
                {
                    throw new ArgumentException(
                        "Cannot represent the nested type of a partially constructed generic type in C# syntax.");
                }

                builder.Append(
                    type.DeclaringType.Name.Substring(
                        0,
                        type.DeclaringType.Name.IndexOf("`", StringComparison.Ordinal)));
            }
            else
            {
                builder.Append(type.DeclaringType.Name);
            }

            return true;
        }
    }
}
