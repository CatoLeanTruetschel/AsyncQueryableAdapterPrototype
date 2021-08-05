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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AsyncQueryableAdapter.Utils
{
    internal static class ThrowHelper
    {
        [DoesNotReturn]
        public static void ThrowQueryNotSupportedException()
        {
            // TODO: Exception message: Describe the method that is not supported.
            throw new NotSupportedException("The current query is not supported by the query provider.");
        }

        [DoesNotReturn]
        public static void ThrowComparerMustBeOfType<TElement>(string? paramName = null)
        {
            var message = $"The comparer must be of type {typeof(IEqualityComparer<TElement>)}.";

            if (paramName is null)
            {
                throw new ArgumentException(message, paramName);
            }

            throw new ArgumentException(message);
        }
    }
}