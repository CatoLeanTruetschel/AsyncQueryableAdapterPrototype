using System;
using System.Collections.Immutable;

namespace AsyncQueryableAdapter.Utils
{
    internal static partial class FuncTypeHelper
    {
        private static partial ImmutableList<Type> BuildFuncTypeDefinitions()
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

        [ThreadStatic]
        private static Type[]? _1EntryTypeBuffer;

        public static Type GetFuncType(
            Type resultType)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = resultType;
            return typeof(Func<>).MakeGenericType(_1EntryTypeBuffer);
        }

        [ThreadStatic]
        private static Type[]? _2EntryTypeBuffer;

        public static Type GetFuncType(
            Type t1,
            Type resultType)
        {
            _2EntryTypeBuffer ??= new Type[2];
            _2EntryTypeBuffer[0] = t1;
            _2EntryTypeBuffer[1] = resultType;
            return typeof(Func<,>).MakeGenericType(_2EntryTypeBuffer);
        }

        [ThreadStatic]
        private static Type[]? _3EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _4EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _5EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _6EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _7EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _8EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _9EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _10EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _11EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _12EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _13EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _14EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _15EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _16EntryTypeBuffer;

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

        [ThreadStatic]
        private static Type[]? _17EntryTypeBuffer;

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

            types.CopyTo(arr.AsSpan()[..^1]);
            arr[^1] = resultType;

            return _funcTypeDefinitions[types.Length].MakeGenericType(arr);
        }
    }
}