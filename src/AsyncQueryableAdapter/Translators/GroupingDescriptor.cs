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
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal readonly struct GroupingDescriptor // TODO: Implement IEquatable
    {
        private readonly Type? _keyType;
        private readonly Type? _elementType;

        public GroupingDescriptor(Type keyType, Type elementType)
        {
            if (keyType is null)
                throw new ArgumentNullException(nameof(keyType));

            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            if (keyType.IsGenericType && !keyType.IsConstructedGenericType)
                ThrowHelper.ThrowMustNonGenericOrConstructedGenericMethod(nameof(keyType));

            if (elementType.IsGenericType && !elementType.IsConstructedGenericType)
                ThrowHelper.ThrowMustNonGenericOrConstructedGenericMethod(nameof(elementType));

            _keyType = keyType;
            _elementType = elementType;
        }

        public Type KeyType => _keyType ?? typeof(object);

        public Type ElementType => _elementType ?? typeof(object);

        public Type GroupingType => TypeHelper.GetGroupingType(KeyType, ElementType);

        public Type AsyncGroupingType => TypeHelper.GetAsyncGroupingType(KeyType, ElementType);
    }
}
