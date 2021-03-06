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

using System.Reflection;

namespace System
{
    internal static partial class TypeExtension
    {
        [ThreadStatic]
        private static Type[]? _1EntryTypeBuffer;

#if !SUPPORTS_TYPE_IS_ASSIGNABLE_TO
        public static bool IsAssignableTo(this Type type, Type assignableType)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (assignableType is null)
            {
                return false;
            }

            return assignableType.IsAssignableFrom(type);
        }
#endif
        public static bool IsAssignableTo<T>(this Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            return typeof(T).IsAssignableFrom(type);
        }

        public static bool CanContainNull(this Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            return !type.IsValueType
                || type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static ConstructorInfo? GetConstructor(this Type type, Type type0)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = type0;

            return type.GetConstructor(_1EntryTypeBuffer);
        }
    }
}
