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

namespace AsyncQueryableAdapter.Utils
{
    internal static partial class ThrowHelper
    {
        [DoesNotReturn]
        public static void ThrowQueryNotSupportedException()
        {
            // TODO: Exception message: Describe the method that is not supported.
            throw new NotSupportedException("The current query is not supported by the query provider.");
        }

        [DoesNotReturn]
        public static void ThrowSubqueriesWithDifferentQueryProvidersUnsupported(string? paramName = null)
        {
            throw new ArgumentException("Subqueries from different query-providers are unsupported.", paramName);
        }

        [DoesNotReturn]
        public static void ThrowUnableToExtractTranslatedQueryableFromArgument()
        {
            throw new InvalidOperationException(
                    "Unable to extract the translated queryable object from the argument.");
        }

        [DoesNotReturn]
        public static void ThrowArgumentsMustContainATranslatedQueryable(string? paramName = null)
        {
            throw new ArgumentException(
                "The arguments must contains at least one translated queryable.",
                paramName);
        }

        [DoesNotReturn]
        public static void ThrowMustBeOfType<TElement>(string? paramName = null)
        {
            var message = $"The value must be of type {typeof(TElement)}.";

            if (paramName is null)
            {
                throw new ArgumentException(message, paramName);
            }

            throw new ArgumentException(message);
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

        [DoesNotReturn]
        public static void ThrowMustNonGenericOrConstructedGenericMethod(string? paramName = null)
        {
            throw new ArgumentException(
                    "The argument must be a non-generic or a constructed generic method.",
                    paramName);
        }

        [DoesNotReturn]
        public static void ThrowMustBeAGenericMethodDefinition(string? paramName = null)
        {
            throw new ArgumentException(
                   "The argument must be a generic method definition.",
                   paramName);
        }

        [DoesNotReturn]
        public static void ThrowCollectionMustNotContainNullEntries(string? paramName = null)
        {
            throw new ArgumentException("The collection must not contain null entries", paramName);
        }
    }
}
