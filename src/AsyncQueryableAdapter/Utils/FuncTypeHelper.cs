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
using System.Collections.Immutable;

namespace AsyncQueryableAdapter.Utils
{
    internal static partial class FuncTypeHelper
    {
        private static readonly ImmutableList<Type> _funcTypeDefinitions = BuildFuncTypeDefinitions();
        private static readonly ImmutableHashSet<Type> _funcTypeLookpups = _funcTypeDefinitions.ToImmutableHashSet();

        private static partial ImmutableList<Type> BuildFuncTypeDefinitions();

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
    }
}
