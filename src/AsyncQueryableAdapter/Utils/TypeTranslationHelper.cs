﻿// License
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
using System.Linq;

namespace AsyncQueryableAdapter.Utils
{
    internal static class TypeTranslationHelper
    {
        public static bool IsCompatibleTranslationTarget(Type type, Type translatedType)
        {
            if (type.IsAssignableTo<IQueryable>() && !translatedType.IsAssignableTo<IQueryable>())
            {
                if (!translatedType.IsAssignableTo<IAsyncQueryable>())
                {
                    return false;
                }

                var elementType = typeof(object);

                // Assume for now that this is the IQueryable or IQueryable<T> interface directly
                //TODO: Add some checks and implement a more general solution.
                if (type.IsGenericType)
                {
                    elementType = type.GetGenericArguments().First();
                }

                // Assume for now that this is the IAsyncQueryable<T> interface directly
                //TODO: Add some checks and implement a more general solution.
                if (!translatedType.IsConstructedGenericType)
                {
                    return false;
                }

                if (translatedType.GetGenericTypeDefinition() != typeof(IAsyncQueryable<>))
                {
                    return false;
                }

                var asyncElementType = translatedType.GetGenericArguments().First();

                return elementType == asyncElementType;
            }

            return type == translatedType;
        }
    }
}
