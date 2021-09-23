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

using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace System
{
    internal static partial class StringExtension
    {
        public static bool EndsWith(this string str, ReadOnlySpan<char> value, StringComparison comparisonType)
        {
            return str.AsSpan().EndsWith(value, comparisonType);
        }

        public static bool Equals(this string str, ReadOnlySpan<char> other, StringComparison comparisonType)
        {
            return str.AsSpan().Equals(other, comparisonType);
        }

#if !SUPPORTS_STRING_REPLACE_WITH_COMPARISON
        public static string Replace(this string str, string oldValue, string newValue, StringComparison comparisonType)
        {
            var index = 0;

            while ((index = str.IndexOf(oldValue, index, comparisonType)) >= 0)
            {
                var newStr = new string('\0', str.Length - oldValue.Length + newValue.Length);

                var newStrBuffer = MemoryMarshal.AsMemory(newStr.AsMemory());
                var strBuffer = str.AsMemory();

                strBuffer[..index].CopyTo(newStrBuffer);
                newValue.AsMemory().CopyTo(newStrBuffer[index..]);
                strBuffer[(index + oldValue.Length)..].CopyTo(newStrBuffer[(index + newValue.Length)..]);

                str = newStr;
            }

            return str;
        }
#endif

        [return: NotNullIfNotNull("str")]
        public static string? FirstRuneToUpperCase(this string? str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            var result = Rune.DecodeFromUtf16(str.AsSpan(), out var rune, out var charsConsumed);

            if (result != OperationStatus.Done || Rune.IsUpper(rune))
                return str;

            return Rune.ToUpperInvariant(rune) + str[charsConsumed..];
        }

        [return: NotNullIfNotNull("str")]
        public static string? FirstRuneToLowerCase(this string? str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            var result = Rune.DecodeFromUtf16(str.AsSpan(), out var rune, out var charsConsumed);

            if (result != OperationStatus.Done || Rune.IsLower(rune))
                return str;

            return Rune.ToLowerInvariant(rune) + str[charsConsumed..];
        }
    }
}
