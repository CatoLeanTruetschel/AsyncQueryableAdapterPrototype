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

// Based on
// --------------------------------------------------------------------------------------------------------------------
// .NET Runtime (https://github.com/dotnet/runtime/tree/v5.0.9)
// The MIT License (MIT)
// 
// Copyright(c).NET Foundation and Contributors
// 
// All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// --------------------------------------------------------------------------------------------------------------------

#if !SUPPORTS_RUNE
// https://github.com/dotnet/runtime/blob/v5.0.9/src/libraries/System.Private.CoreLib/src/System/Text/Rune.cs
// https://github.com/dotnet/runtime/blob/57bfe474518ab5b7cfe6bf7424a79ce3af9d6657/src/libraries/System.Private.CoreLib/src/System/Text/UnicodeUtility.cs
// https://github.com/dotnet/runtime/blob/57bfe474518ab5b7cfe6bf7424a79ce3af9d6657/src/libraries/System.Private.CoreLib/src/System/Text/UnicodeDebug.cs
// https://github.com/dotnet/runtime/blob/v5.0.9/src/libraries/System.Private.CoreLib/src/System/Text/SpanRuneEnumerator.cs
// https://github.com/dotnet/runtime/blob/v5.0.9/src/libraries/System.Private.CoreLib/src/System/Text/StringRuneEnumerator.cs
// https://github.com/dotnet/runtime/blob/v5.0.9/src/libraries/System.Private.CoreLib/src/System/Text/Unicode/Utf16Utility.cs
// https://github.com/dotnet/runtime/blob/57bfe474518ab5b7cfe6bf7424a79ce3af9d6657/src/libraries/System.Private.CoreLib/src/System/Globalization/GlobalizationMode.cs
// https://github.com/dotnet/runtime/blob/57bfe474518ab5b7cfe6bf7424a79ce3af9d6657/src/libraries/System.Private.CoreLib/src/System/AppContextConfigHelper.cs#L13
// https://github.com/dotnet/runtime/blob/57bfe474518ab5b7cfe6bf7424a79ce3af9d6657/src/libraries/System.Private.CoreLib/src/System/Boolean.cs#L194

using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Unicode;

namespace System.Text
{
    /// <summary>
    /// Represents a Unicode scalar value ([ U+0000..U+D7FF ], inclusive; or [ U+E000..U+10FFFF ], inclusive).
    /// </summary>
    /// <remarks>
    /// This type's constructors and conversion operators validate the input, so consumers can call the APIs
    /// assuming that the underlying <see cref="Rune"/> instance is well-formed.
    /// </remarks>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal readonly struct Rune : IComparable, IComparable<Rune>, IEquatable<Rune>
    {
        internal const int MaxUtf16CharsPerRune = 2; // supplementary plane code points are encoded as 2 UTF-16 code units
        internal const int MaxUtf8BytesPerRune = 4; // supplementary plane code points are encoded as 4 UTF-8 code units

        private const char HighSurrogateStart = '\ud800';
        private const char LowSurrogateStart = '\udc00';
        private const int HighSurrogateRange = 0x3FF;

        private const byte IsWhiteSpaceFlag = 0x80;
        private const byte IsLetterOrDigitFlag = 0x40;
        private const byte UnicodeCategoryMask = 0x1F;

        // Contains information about the ASCII character range [ U+0000..U+007F ], with:
        // - 0x80 bit if set means 'is whitespace'
        // - 0x40 bit if set means 'is letter or digit'
        // - 0x20 bit is reserved for future use
        // - bottom 5 bits are the UnicodeCategory of the character
        private static ReadOnlySpan<byte> AsciiCharInfo => new byte[]
        {
            0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x8E, 0x8E, 0x8E, 0x8E, 0x8E, 0x0E, 0x0E, // U+0000..U+000F
            0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, 0x0E, // U+0010..U+001F
            0x8B, 0x18, 0x18, 0x18, 0x1A, 0x18, 0x18, 0x18, 0x14, 0x15, 0x18, 0x19, 0x18, 0x13, 0x18, 0x18, // U+0020..U+002F
            0x48, 0x48, 0x48, 0x48, 0x48, 0x48, 0x48, 0x48, 0x48, 0x48, 0x18, 0x18, 0x19, 0x19, 0x19, 0x18, // U+0030..U+003F
            0x18, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, // U+0040..U+004F
            0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x40, 0x14, 0x18, 0x15, 0x1B, 0x12, // U+0050..U+005F
            0x1B, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, // U+0060..U+006F
            0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x14, 0x19, 0x15, 0x19, 0x0E, // U+0070..U+007F
        };

        private readonly uint _value;

        /// <summary>
        /// Creates a <see cref="Rune"/> from the provided UTF-16 code unit.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="ch"/> represents a UTF-16 surrogate code point
        /// U+D800..U+DFFF, inclusive.
        /// </exception>
        public Rune(char ch)
        {
            uint expanded = ch;
            if (UnicodeUtility.IsSurrogateCodePoint(expanded))
            {
                throw new ArgumentOutOfRangeException(nameof(ch));
            }

            _value = expanded;
        }

        /// <summary>
        /// Creates a <see cref="Rune"/> from the provided UTF-16 surrogate pair.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="highSurrogate"/> does not represent a UTF-16 high surrogate code point
        /// or <paramref name="lowSurrogate"/> does not represent a UTF-16 low surrogate code point.
        /// </exception>
        public Rune(char highSurrogate, char lowSurrogate)
            : this((uint)char.ConvertToUtf32(highSurrogate, lowSurrogate), false)
        {
        }

        /// <summary>
        /// Creates a <see cref="Rune"/> from the provided Unicode scalar value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="value"/> does not represent a value Unicode scalar value.
        /// </exception>
        public Rune(int value)
            : this((uint)value)
        {
        }

        /// <summary>
        /// Creates a <see cref="Rune"/> from the provided Unicode scalar value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="value"/> does not represent a value Unicode scalar value.
        /// </exception>
#pragma warning disable CS3021, CS3019
        [CLSCompliant(false)]
        public Rune(uint value)
#pragma warning restore CS3021, CS3019
        {
            if (!UnicodeUtility.IsValidUnicodeScalar(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            _value = value;
        }

        // non-validating ctor
#pragma warning disable CA1801
        private Rune(uint scalarValue, bool unused)
#pragma warning restore CA1801
        {
            UnicodeDebug.AssertIsValidScalar(scalarValue);
            _value = scalarValue;
        }

        public static bool operator ==(Rune left, Rune right) => left._value == right._value;

        public static bool operator !=(Rune left, Rune right) => left._value != right._value;

        public static bool operator <(Rune left, Rune right) => left._value < right._value;

        public static bool operator <=(Rune left, Rune right) => left._value <= right._value;

        public static bool operator >(Rune left, Rune right) => left._value > right._value;

        public static bool operator >=(Rune left, Rune right) => left._value >= right._value;

        // Operators below are explicit because they may throw.

        public static explicit operator Rune(char ch) => new(ch);

#pragma warning disable CS3021, CS3019
        [CLSCompliant(false)]
        public static explicit operator Rune(uint value) => new(value);
#pragma warning restore CS3021, CS3019

        public static explicit operator Rune(int value) => new(value);

        // Displayed as "'<char>' (U+XXXX)"; e.g., "'e' (U+0065)"
        private string DebuggerDisplay => FormattableString.Invariant($"U+{_value:X4} '{(IsValid(_value) ? ToString() : "\uFFFD")}'");

        /// <summary>
        /// Returns true if and only if this scalar value is ASCII ([ U+0000..U+007F ])
        /// and therefore representable by a single UTF-8 code unit.
        /// </summary>
        public bool IsAscii => UnicodeUtility.IsAsciiCodePoint(_value);

        /// <summary>
        /// Returns true if and only if this scalar value is within the BMP ([ U+0000..U+FFFF ])
        /// and therefore representable by a single UTF-16 code unit.
        /// </summary>
        public bool IsBmp => UnicodeUtility.IsBmpCodePoint(_value);

        /// <summary>
        /// Returns the Unicode plane (0 to 16, inclusive) which contains this scalar.
        /// </summary>
        public int Plane => UnicodeUtility.GetPlane(_value);

        /// <summary>
        /// A <see cref="Rune"/> instance that represents the Unicode replacement character U+FFFD.
        /// </summary>
        public static Rune ReplacementChar => UnsafeCreate(UnicodeUtility.ReplacementChar);

        /// <summary>
        /// Returns the length in code units (<see cref="char"/>) of the
        /// UTF-16 sequence required to represent this scalar value.
        /// </summary>
        /// <remarks>
        /// The return value will be 1 or 2.
        /// </remarks>
        public int Utf16SequenceLength
        {
            get
            {
                var codeUnitCount = UnicodeUtility.GetUtf16SequenceLength(_value);
                Debug.Assert(codeUnitCount is > 0 and <= MaxUtf16CharsPerRune);
                return codeUnitCount;
            }
        }

        /// <summary>
        /// Returns the length in code units of the
        /// UTF-8 sequence required to represent this scalar value.
        /// </summary>
        /// <remarks>
        /// The return value will be 1 through 4, inclusive.
        /// </remarks>
        public int Utf8SequenceLength
        {
            get
            {
                var codeUnitCount = UnicodeUtility.GetUtf8SequenceLength(_value);
                Debug.Assert(codeUnitCount is > 0 and <= MaxUtf8BytesPerRune);
                return codeUnitCount;
            }
        }

        /// <summary>
        /// Returns the Unicode scalar value as an integer.
        /// </summary>
        public int Value => (int)_value;

#if SYSTEM_PRIVATE_CORELIB
        private static Rune ChangeCaseCultureAware(Rune rune, TextInfo textInfo, bool toUpper)
        {
            Debug.Assert(!GlobalizationMode.Invariant, "This should've been checked by the caller.");
            Debug.Assert(textInfo is not null, "This should've been checked by the caller.");

            Span<char> original = stackalloc char[MaxUtf16CharsPerRune];
            Span<char> modified = stackalloc char[MaxUtf16CharsPerRune];

            int charCount = rune.EncodeToUtf16(original);
            original = original.Slice(0, charCount);
            modified = modified.Slice(0, charCount);

            if (toUpper)
            {
                textInfo.ChangeCaseToUpper(original, modified);
            }
            else
            {
                textInfo.ChangeCaseToLower(original, modified);
            }

            // We use simple case folding rules, which disallows moving between the BMP and supplementary
            // planes when performing a case conversion. The helper methods which reconstruct a Rune
            // contain debug asserts for this condition.

            if (rune.IsBmp)
            {
                return UnsafeCreate(modified[0]);
            }
            else
            {
                return UnsafeCreate(UnicodeUtility.GetScalarFromUtf16SurrogatePair(modified[0], modified[1]));
            }
        }
#else
        private static Rune ChangeCaseCultureAware(Rune rune, CultureInfo culture, bool toUpper)
        {
            Debug.Assert(!GlobalizationMode.Invariant, "This should've been checked by the caller.");
            Debug.Assert(culture is not null, "This should've been checked by the caller.");

            Span<char> original = stackalloc char[MaxUtf16CharsPerRune]; // worst case scenario = 2 code units (for a surrogate pair)
            Span<char> modified = stackalloc char[MaxUtf16CharsPerRune]; // case change should preserve UTF-16 code unit count

            var charCount = rune.EncodeToUtf16(original);
            original = original.Slice(0, charCount);
            modified = modified.Slice(0, charCount);

            if (toUpper)
            {
                MemoryExtensions.ToUpper(original, modified, culture);
            }
            else
            {
                MemoryExtensions.ToLower(original, modified, culture);
            }

            // We use simple case folding rules, which disallows moving between the BMP and supplementary
            // planes when performing a case conversion. The helper methods which reconstruct a Rune
            // contain debug asserts for this condition.

            if (rune.IsBmp)
            {
                return UnsafeCreate(modified[0]);
            }
            else
            {
                return UnsafeCreate(UnicodeUtility.GetScalarFromUtf16SurrogatePair(modified[0], modified[1]));
            }
        }
#endif

        public int CompareTo(Rune other) => Value - other.Value; // values don't span entire 32-bit domain; won't integer overflow

        /// <summary>
        /// Decodes the <see cref="Rune"/> at the beginning of the provided UTF-16 source buffer.
        /// </summary>
        /// <returns>
        /// <para>
        /// If the source buffer begins with a valid UTF-16 encoded scalar value, returns <see cref="OperationStatus.Done"/>,
        /// and outs via <paramref name="result"/> the decoded <see cref="Rune"/> and via <paramref name="charsConsumed"/> the
        /// number of <see langword="char"/>s used in the input buffer to encode the <see cref="Rune"/>.
        /// </para>
        /// <para>
        /// If the source buffer is empty or contains only a standalone UTF-16 high surrogate character, returns <see cref="OperationStatus.NeedMoreData"/>,
        /// and outs via <paramref name="result"/> <see cref="ReplacementChar"/> and via <paramref name="charsConsumed"/> the length of the input buffer.
        /// </para>
        /// <para>
        /// If the source buffer begins with an ill-formed UTF-16 encoded scalar value, returns <see cref="OperationStatus.InvalidData"/>,
        /// and outs via <paramref name="result"/> <see cref="ReplacementChar"/> and via <paramref name="charsConsumed"/> the number of
        /// <see langword="char"/>s used in the input buffer to encode the ill-formed sequence.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The general calling convention is to call this method in a loop, slicing the <paramref name="source"/> buffer by
        /// <paramref name="charsConsumed"/> elements on each iteration of the loop. On each iteration of the loop <paramref name="result"/>
        /// will contain the real scalar value if successfully decoded, or it will contain <see cref="ReplacementChar"/> if
        /// the data could not be successfully decoded. This pattern provides convenient automatic U+FFFD substitution of
        /// invalid sequences while iterating through the loop.
        /// </remarks>
        public static OperationStatus DecodeFromUtf16(ReadOnlySpan<char> source, out Rune result, out int charsConsumed)
        {
            if (!source.IsEmpty)
            {
                // First, check for the common case of a BMP scalar value.
                // If this is correct, return immediately.

                var firstChar = source[0];
                if (TryCreate(firstChar, out result))
                {
                    charsConsumed = 1;
                    return OperationStatus.Done;
                }

                // First thing we saw was a UTF-16 surrogate code point.
                // Let's optimistically assume for now it's a high surrogate and hope
                // that combining it with the next char yields useful results.

                if (1 < (uint)source.Length)
                {
                    var secondChar = source[1];
                    if (TryCreate(firstChar, secondChar, out result))
                    {
                        // Success! Formed a supplementary scalar value.
                        charsConsumed = 2;
                        return OperationStatus.Done;
                    }
                    else
                    {
                        // Either the first character was a low surrogate, or the second
                        // character was not a low surrogate. This is an error.
                        goto InvalidData;
                    }
                }
                else if (!char.IsHighSurrogate(firstChar))
                {
                    // Quick check to make sure we're not going to report NeedMoreData for
                    // a single-element buffer where the data is a standalone low surrogate
                    // character. Since no additional data will ever make this valid, we'll
                    // report an error immediately.
                    goto InvalidData;
                }
            }

            // If we got to this point, the input buffer was empty, or the buffer
            // was a single element in length and that element was a high surrogate char.

            charsConsumed = source.Length;
            result = ReplacementChar;
            return OperationStatus.NeedMoreData;

        InvalidData:

            charsConsumed = 1; // maximal invalid subsequence for UTF-16 is always a single code unit in length
            result = ReplacementChar;
            return OperationStatus.InvalidData;
        }

        /// <summary>
        /// Decodes the <see cref="Rune"/> at the beginning of the provided UTF-8 source buffer.
        /// </summary>
        /// <returns>
        /// <para>
        /// If the source buffer begins with a valid UTF-8 encoded scalar value, returns <see cref="OperationStatus.Done"/>,
        /// and outs via <paramref name="result"/> the decoded <see cref="Rune"/> and via <paramref name="bytesConsumed"/> the
        /// number of <see langword="byte"/>s used in the input buffer to encode the <see cref="Rune"/>.
        /// </para>
        /// <para>
        /// If the source buffer is empty or contains only a partial UTF-8 subsequence, returns <see cref="OperationStatus.NeedMoreData"/>,
        /// and outs via <paramref name="result"/> <see cref="ReplacementChar"/> and via <paramref name="bytesConsumed"/> the length of the input buffer.
        /// </para>
        /// <para>
        /// If the source buffer begins with an ill-formed UTF-8 encoded scalar value, returns <see cref="OperationStatus.InvalidData"/>,
        /// and outs via <paramref name="result"/> <see cref="ReplacementChar"/> and via <paramref name="bytesConsumed"/> the number of
        /// <see langword="char"/>s used in the input buffer to encode the ill-formed sequence.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The general calling convention is to call this method in a loop, slicing the <paramref name="source"/> buffer by
        /// <paramref name="bytesConsumed"/> elements on each iteration of the loop. On each iteration of the loop <paramref name="result"/>
        /// will contain the real scalar value if successfully decoded, or it will contain <see cref="ReplacementChar"/> if
        /// the data could not be successfully decoded. This pattern provides convenient automatic U+FFFD substitution of
        /// invalid sequences while iterating through the loop.
        /// </remarks>
        public static OperationStatus DecodeFromUtf8(ReadOnlySpan<byte> source, out Rune result, out int bytesConsumed)
        {
            // This method follows the Unicode Standard's recommendation for detecting
            // the maximal subpart of an ill-formed subsequence. See The Unicode Standard,
            // Ch. 3.9 for more details. In summary, when reporting an invalid subsequence,
            // it tries to consume as many code units as possible as long as those code
            // units constitute the beginning of a longer well-formed subsequence per Table 3-7.

            var index = 0;

            // Try reading input[0].

            if ((uint)index >= (uint)source.Length)
            {
                goto NeedsMoreData;
            }

            uint tempValue = source[index];
            if (!UnicodeUtility.IsAsciiCodePoint(tempValue))
            {
                goto NotAscii;
            }

        Finish:

            bytesConsumed = index + 1;
            Debug.Assert(bytesConsumed is >= 1 and <= 4); // Valid subsequences are always length [1..4]
            result = UnsafeCreate(tempValue);
            return OperationStatus.Done;

        NotAscii:

            // Per Table 3-7, the beginning of a multibyte sequence must be a code unit in
            // the range [C2..F4]. If it's outside of that range, it's either a standalone
            // continuation byte, or it's an overlong two-byte sequence, or it's an out-of-range
            // four-byte sequence.

            if (!UnicodeUtility.IsInRangeInclusive(tempValue, 0xC2, 0xF4))
            {
                goto FirstByteInvalid;
            }

            tempValue = (tempValue - 0xC2) << 6;

            // Try reading input[1].

            index++;
            if ((uint)index >= (uint)source.Length)
            {
                goto NeedsMoreData;
            }

            // Continuation bytes are of the form [10xxxxxx], which means that their two's
            // complement representation is in the range [-65..-128]. This allows us to
            // perform a single comparison to see if a byte is a continuation byte.

            int thisByteSignExtended = (sbyte)source[index];
            if (thisByteSignExtended >= -64)
            {
                goto Invalid;
            }

            tempValue += (uint)thisByteSignExtended;
            tempValue += 0x80; // remove the continuation byte marker
            tempValue += (0xC2 - 0xC0) << 6; // remove the leading byte marker

            if (tempValue < 0x0800)
            {
                Debug.Assert(UnicodeUtility.IsInRangeInclusive(tempValue, 0x0080, 0x07FF));
                goto Finish; // this is a valid 2-byte sequence
            }

            // This appears to be a 3- or 4-byte sequence. Since per Table 3-7 we now have
            // enough information (from just two code units) to detect overlong or surrogate
            // sequences, we need to perform these checks now.

            if (!UnicodeUtility.IsInRangeInclusive(tempValue, ((0xE0 - 0xC0) << 6) + (0xA0 - 0x80), ((0xF4 - 0xC0) << 6) + (0x8F - 0x80)))
            {
                // The first two bytes were not in the range [[E0 A0]..[F4 8F]].
                // This is an overlong 3-byte sequence or an out-of-range 4-byte sequence.
                goto Invalid;
            }

            if (UnicodeUtility.IsInRangeInclusive(tempValue, ((0xED - 0xC0) << 6) + (0xA0 - 0x80), ((0xED - 0xC0) << 6) + (0xBF - 0x80)))
            {
                // This is a UTF-16 surrogate code point, which is invalid in UTF-8.
                goto Invalid;
            }

            if (UnicodeUtility.IsInRangeInclusive(tempValue, ((0xF0 - 0xC0) << 6) + (0x80 - 0x80), ((0xF0 - 0xC0) << 6) + (0x8F - 0x80)))
            {
                // This is an overlong 4-byte sequence.
                goto Invalid;
            }

            // The first two bytes were just fine. We don't need to perform any other checks
            // on the remaining bytes other than to see that they're valid continuation bytes.

            // Try reading input[2].

            index++;
            if ((uint)index >= (uint)source.Length)
            {
                goto NeedsMoreData;
            }

            thisByteSignExtended = (sbyte)source[index];
            if (thisByteSignExtended >= -64)
            {
                goto Invalid; // this byte is not a UTF-8 continuation byte
            }

            tempValue <<= 6;
            tempValue += (uint)thisByteSignExtended;
            tempValue += 0x80; // remove the continuation byte marker
            tempValue -= (0xE0 - 0xC0) << 12; // remove the leading byte marker

            if (tempValue <= 0xFFFF)
            {
                Debug.Assert(UnicodeUtility.IsInRangeInclusive(tempValue, 0x0800, 0xFFFF));
                goto Finish; // this is a valid 3-byte sequence
            }

            // Try reading input[3].

            index++;
            if ((uint)index >= (uint)source.Length)
            {
                goto NeedsMoreData;
            }

            thisByteSignExtended = (sbyte)source[index];
            if (thisByteSignExtended >= -64)
            {
                goto Invalid; // this byte is not a UTF-8 continuation byte
            }

            tempValue <<= 6;
            tempValue += (uint)thisByteSignExtended;
            tempValue += 0x80; // remove the continuation byte marker
            tempValue -= (0xF0 - 0xE0) << 18; // remove the leading byte marker

            UnicodeDebug.AssertIsValidSupplementaryPlaneScalar(tempValue);
            goto Finish; // this is a valid 4-byte sequence

        FirstByteInvalid:

            index = 1; // Invalid subsequences are always at least length 1.

        Invalid:

            Debug.Assert(index is >= 1 and <= 3); // Invalid subsequences are always length 1..3
            bytesConsumed = index;
            result = ReplacementChar;
            return OperationStatus.InvalidData;

        NeedsMoreData:

            Debug.Assert(index is >= 0 and <= 3); // Incomplete subsequences are always length 0..3
            bytesConsumed = index;
            result = ReplacementChar;
            return OperationStatus.NeedMoreData;
        }

        /// <summary>
        /// Decodes the <see cref="Rune"/> at the end of the provided UTF-16 source buffer.
        /// </summary>
        /// <remarks>
        /// This method is very similar to <see cref="DecodeFromUtf16(ReadOnlySpan{char}, out Rune, out int)"/>, but it allows
        /// the caller to loop backward instead of forward. The typical calling convention is that on each iteration
        /// of the loop, the caller should slice off the final <paramref name="charsConsumed"/> elements of
        /// the <paramref name="source"/> buffer.
        /// </remarks>
        public static OperationStatus DecodeLastFromUtf16(ReadOnlySpan<char> source, out Rune result, out int charsConsumed)
        {
            var index = source.Length - 1;
            if ((uint)index < (uint)source.Length)
            {
                // First, check for the common case of a BMP scalar value.
                // If this is correct, return immediately.

                var finalChar = source[index];
                if (TryCreate(finalChar, out result))
                {
                    charsConsumed = 1;
                    return OperationStatus.Done;
                }

                if (char.IsLowSurrogate(finalChar))
                {
                    // The final character was a UTF-16 low surrogate code point.
                    // This must be preceded by a UTF-16 high surrogate code point, otherwise
                    // we have a standalone low surrogate, which is always invalid.

                    index--;
                    if ((uint)index < (uint)source.Length)
                    {
                        var penultimateChar = source[index];
                        if (TryCreate(penultimateChar, finalChar, out result))
                        {
                            // Success! Formed a supplementary scalar value.
                            charsConsumed = 2;
                            return OperationStatus.Done;
                        }
                    }

                    // If we got to this point, we saw a standalone low surrogate
                    // and must report an error.

                    charsConsumed = 1; // standalone surrogate
                    result = ReplacementChar;
                    return OperationStatus.InvalidData;
                }
            }

            // If we got this far, the source buffer was empty, or the source buffer ended
            // with a UTF-16 high surrogate code point. These aren't errors since they could
            // be valid given more input data.

            charsConsumed = (int)((uint)(-source.Length) >> 31); // 0 -> 0, all other lengths -> 1
            result = ReplacementChar;
            return OperationStatus.NeedMoreData;
        }

        /// <summary>
        /// Decodes the <see cref="Rune"/> at the end of the provided UTF-8 source buffer.
        /// </summary>
        /// <remarks>
        /// This method is very similar to <see cref="DecodeFromUtf8(ReadOnlySpan{byte}, out Rune, out int)"/>, but it allows
        /// the caller to loop backward instead of forward. The typical calling convention is that on each iteration
        /// of the loop, the caller should slice off the final <paramref name="bytesConsumed"/> elements of
        /// the <paramref name="source"/> buffer.
        /// </remarks>
        public static OperationStatus DecodeLastFromUtf8(ReadOnlySpan<byte> source, out Rune value, out int bytesConsumed)
        {
            var index = source.Length - 1;
            if ((uint)index < (uint)source.Length)
            {
                // The buffer contains at least one byte. Let's check the fast case where the
                // buffer ends with an ASCII byte.

                uint tempValue = source[index];
                if (UnicodeUtility.IsAsciiCodePoint(tempValue))
                {
                    bytesConsumed = 1;
                    value = UnsafeCreate(tempValue);
                    return OperationStatus.Done;
                }

                // If the final byte is not an ASCII byte, we may be beginning or in the middle of
                // a UTF-8 multi-code unit sequence. We need to back up until we see the start of
                // the multi-code unit sequence; we can detect the leading byte because all multi-byte
                // sequences begin with a byte whose 0x40 bit is set. Since all multi-byte sequences
                // are no greater than 4 code units in length, we only need to search back a maximum
                // of four bytes.

                if (((byte)tempValue & 0x40) != 0)
                {
                    // This is a UTF-8 leading byte. We'll do a forward read from here.
                    // It'll return invalid (if given C0, F5, etc.) or incomplete. Both are fine.

                    return DecodeFromUtf8(source.Slice(index), out value, out bytesConsumed);
                }

                // If we got to this point, the final byte was a UTF-8 continuation byte.
                // Let's check the three bytes immediately preceding this, looking for the starting byte.

                for (var i = 3; i > 0; i--)
                {
                    index--;
                    if ((uint)index >= (uint)source.Length)
                    {
                        goto Invalid; // out of data
                    }

                    // The check below will get hit for ASCII (values 00..7F) and for UTF-8 starting bytes
                    // (bits 0xC0 set, values C0..FF). In two's complement this is the range [-64..127].
                    // It's just a fast way for us to terminate the search.

                    if ((sbyte)source[index] >= -64)
                    {
                        goto ForwardDecode;
                    }
                }

            Invalid:

                // If we got to this point, either:
                // - the last 4 bytes of the input buffer are continuation bytes;
                // - the entire input buffer (if fewer than 4 bytes) consists only of continuation bytes; or
                // - there's no UTF-8 leading byte between the final continuation byte of the buffer and
                //   the previous well-formed subsequence or maximal invalid subsequence.
                //
                // In all of these cases, the final byte must be a maximal invalid subsequence of length 1.
                // See comment near the end of this method for more information.

                value = ReplacementChar;
                bytesConsumed = 1;
                return OperationStatus.InvalidData;

            ForwardDecode:

                // If we got to this point, we found an ASCII byte or a UTF-8 starting byte at position source[index].
                // Technically this could also mean we found an invalid byte like C0 or F5 at this position, but that's
                // fine since it'll be handled by the forward read. From this position, we'll perform a forward read
                // and see if we consumed the entirety of the buffer.

                source = source.Slice(index);
                Debug.Assert(!source.IsEmpty, "Shouldn't reach this for empty inputs.");

                var operationStatus = DecodeFromUtf8(source, out var tempRune, out var tempBytesConsumed);
                if (tempBytesConsumed == source.Length)
                {
                    // If this forward read consumed the entirety of the end of the input buffer, we can return it
                    // as the result of this function. It could be well-formed, incomplete, or invalid. If it's
                    // invalid and we consumed the remainder of the buffer, we know we've found the maximal invalid
                    // subsequence, which is what we wanted anyway.

                    bytesConsumed = tempBytesConsumed;
                    value = tempRune;
                    return operationStatus;
                }

                // If we got to this point, we know that the final continuation byte wasn't consumed by the forward
                // read that we just performed above. This means that the continuation byte has to be part of an
                // invalid subsequence since there's no UTF-8 leading byte between what we just consumed and the
                // continuation byte at the end of the input. Furthermore, since any maximal invalid subsequence
                // of length > 1 must have a UTF-8 leading byte as its first code unit, this implies that the
                // continuation byte at the end of the buffer is itself a maximal invalid subsequence of length 1.

                goto Invalid;
            }
            else
            {
                // Source buffer was empty.
                value = ReplacementChar;
                bytesConsumed = 0;
                return OperationStatus.NeedMoreData;
            }
        }

        /// <summary>
        /// Encodes this <see cref="Rune"/> to a UTF-16 destination buffer.
        /// </summary>
        /// <param name="destination">The buffer to which to write this value as UTF-16.</param>
        /// <returns>The number of <see cref="char"/>s written to <paramref name="destination"/>.</returns>
        /// <exception cref="ArgumentException">
        /// If <paramref name="destination"/> is not large enough to hold the output.
        /// </exception>
        public int EncodeToUtf16(Span<char> destination)
        {
            if (!TryEncodeToUtf16(destination, out var charsWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }

            return charsWritten;
        }

        /// <summary>
        /// Encodes this <see cref="Rune"/> to a UTF-8 destination buffer.
        /// </summary>
        /// <param name="destination">The buffer to which to write this value as UTF-8.</param>
        /// <returns>The number of <see cref="byte"/>s written to <paramref name="destination"/>.</returns>
        /// <exception cref="ArgumentException">
        /// If <paramref name="destination"/> is not large enough to hold the output.
        /// </exception>
        public int EncodeToUtf8(Span<byte> destination)
        {
            if (!TryEncodeToUtf8(destination, out var bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }

            return bytesWritten;
        }

        public override bool Equals(object? obj) => (obj is Rune other) && Equals(other);

        public bool Equals(Rune other) => this == other;

        public override int GetHashCode() => Value;

        /// <summary>
        /// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in
        /// string <paramref name="input"/>.
        /// </summary>
        /// <remarks>
        /// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or
        /// if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
        /// </remarks>
        public static Rune GetRuneAt(string input, int index)
        {
            var runeValue = ReadRuneFromString(input, index);
            if (runeValue < 0)
            {
                throw new ArgumentException("Cannot extract a Unicode scalar value from the specified index in the input.", nameof(index));
            }

            return UnsafeCreate((uint)runeValue);
        }

        /// <summary>
        /// Returns <see langword="true"/> iff <paramref name="value"/> is a valid Unicode scalar
        /// value, i.e., is in [ U+0000..U+D7FF ], inclusive; or [ U+E000..U+10FFFF ], inclusive.
        /// </summary>
        public static bool IsValid(int value) => IsValid((uint)value);

        /// <summary>
        /// Returns <see langword="true"/> iff <paramref name="value"/> is a valid Unicode scalar
        /// value, i.e., is in [ U+0000..U+D7FF ], inclusive; or [ U+E000..U+10FFFF ], inclusive.
        /// </summary>
#pragma warning disable CS3021, CS3019
        [CLSCompliant(false)]
        public static bool IsValid(uint value) => UnicodeUtility.IsValidUnicodeScalar(value);
#pragma warning restore CS3021, CS3019

        // returns a negative number on failure
        internal static int ReadFirstRuneFromUtf16Buffer(ReadOnlySpan<char> input)
        {
            if (input.IsEmpty)
            {
                return -1;
            }

            // Optimistically assume input is within BMP.

            uint returnValue = input[0];
            if (UnicodeUtility.IsSurrogateCodePoint(returnValue))
            {
                if (!UnicodeUtility.IsHighSurrogateCodePoint(returnValue))
                {
                    return -1;
                }

                // Treat 'returnValue' as the high surrogate.

                if (1 >= (uint)input.Length)
                {
                    return -1; // not an argument exception - just a "bad data" failure
                }

                uint potentialLowSurrogate = input[1];
                if (!UnicodeUtility.IsLowSurrogateCodePoint(potentialLowSurrogate))
                {
                    return -1;
                }

                returnValue = UnicodeUtility.GetScalarFromUtf16SurrogatePair(returnValue, potentialLowSurrogate);
            }

            return (int)returnValue;
        }

        // returns a negative number on failure
        private static int ReadRuneFromString(string input, int index)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if ((uint)index >= (uint)input!.Length)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    "Index was out of range. Must be non-negative and less than the size of the collection.");
            }

            // Optimistically assume input is within BMP.

            uint returnValue = input[index];
            if (UnicodeUtility.IsSurrogateCodePoint(returnValue))
            {
                if (!UnicodeUtility.IsHighSurrogateCodePoint(returnValue))
                {
                    return -1;
                }

                // Treat 'returnValue' as the high surrogate.
                //
                // If this becomes a hot code path, we can skip the below bounds check by reading
                // off the end of the string using unsafe code. Since strings are null-terminated,
                // we're guaranteed not to read a valid low surrogate, so we'll fail correctly if
                // the string terminates unexpectedly.

                index++;
                if ((uint)index >= (uint)input.Length)
                {
                    return -1; // not an argument exception - just a "bad data" failure
                }

                uint potentialLowSurrogate = input[index];
                if (!UnicodeUtility.IsLowSurrogateCodePoint(potentialLowSurrogate))
                {
                    return -1;
                }

                returnValue = UnicodeUtility.GetScalarFromUtf16SurrogatePair(returnValue, potentialLowSurrogate);
            }

            return (int)returnValue;
        }

        /// <summary>
        /// Returns a <see cref="string"/> representation of this <see cref="Rune"/> instance.
        /// </summary>
        public override string ToString()
        {
#if SYSTEM_PRIVATE_CORELIB
            if (IsBmp)
            {
                return string.CreateFromChar((char)_value);
            }
            else
            {
                UnicodeUtility.GetUtf16SurrogatesFromSupplementaryPlaneScalar(_value, out char high, out char low);
                return string.CreateFromChar(high, low);
            }
#else
            if (IsBmp)
            {
                return ((char)_value).ToString();
            }
            else
            {
                Span<char> buffer = stackalloc char[MaxUtf16CharsPerRune];
                UnicodeUtility.GetUtf16SurrogatesFromSupplementaryPlaneScalar(_value, out buffer[0], out buffer[1]);
                return buffer.ToString();
            }
#endif
        }

        /// <summary>
        /// Attempts to create a <see cref="Rune"/> from the provided input value.
        /// </summary>
        public static bool TryCreate(char ch, out Rune result)
        {
            uint extendedValue = ch;
            if (!UnicodeUtility.IsSurrogateCodePoint(extendedValue))
            {
                result = UnsafeCreate(extendedValue);
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Attempts to create a <see cref="Rune"/> from the provided UTF-16 surrogate pair.
        /// Returns <see langword="false"/> if the input values don't represent a well-formed UTF-16surrogate pair.
        /// </summary>
        public static bool TryCreate(char highSurrogate, char lowSurrogate, out Rune result)
        {
            // First, extend both to 32 bits, then calculate the offset of
            // each candidate surrogate char from the start of its range.

            var highSurrogateOffset = (uint)highSurrogate - HighSurrogateStart;
            var lowSurrogateOffset = (uint)lowSurrogate - LowSurrogateStart;

            // This is a single comparison which allows us to check both for validity at once since
            // both the high surrogate range and the low surrogate range are the same length.
            // If the comparison fails, we call to a helper method to throw the correct exception message.

            if ((highSurrogateOffset | lowSurrogateOffset) <= HighSurrogateRange)
            {
                // The 0x40u << 10 below is to account for uuuuu = wwww + 1 in the surrogate encoding.
                result = UnsafeCreate((highSurrogateOffset << 10) + ((uint)lowSurrogate - LowSurrogateStart) + (0x40u << 10));
                return true;
            }
            else
            {
                // Didn't have a high surrogate followed by a low surrogate.
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Attempts to create a <see cref="Rune"/> from the provided input value.
        /// </summary>
        public static bool TryCreate(int value, out Rune result) => TryCreate((uint)value, out result);

        /// <summary>
        /// Attempts to create a <see cref="Rune"/> from the provided input value.
        /// </summary>
#pragma warning disable CS3021, CS3019
        [CLSCompliant(false)]
        public static bool TryCreate(uint value, out Rune result)
#pragma warning restore CS3021, CS3019
        {
            if (UnicodeUtility.IsValidUnicodeScalar(value))
            {
                result = UnsafeCreate(value);
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Encodes this <see cref="Rune"/> to a UTF-16 destination buffer.
        /// </summary>
        /// <param name="destination">The buffer to which to write this value as UTF-16.</param>
        /// <param name="charsWritten">
        /// The number of <see cref="char"/>s written to <paramref name="destination"/>,
        /// or 0 if the destination buffer is not large enough to contain the output.</param>
        /// <returns>True if the value was written to the buffer; otherwise, false.</returns>
        /// <remarks>
        /// The <see cref="Utf16SequenceLength"/> property can be queried ahead of time to determine
        /// the required size of the <paramref name="destination"/> buffer.
        /// </remarks>
        public bool TryEncodeToUtf16(Span<char> destination, out int charsWritten)
        {
            if (destination.Length >= 1)
            {
                if (IsBmp)
                {
                    destination[0] = (char)_value;
                    charsWritten = 1;
                    return true;
                }
                else if (destination.Length >= 2)
                {
                    UnicodeUtility.GetUtf16SurrogatesFromSupplementaryPlaneScalar(_value, out destination[0], out destination[1]);
                    charsWritten = 2;
                    return true;
                }
            }

            // Destination buffer not large enough

            charsWritten = default;
            return false;
        }

        /// <summary>
        /// Encodes this <see cref="Rune"/> to a destination buffer as UTF-8 bytes.
        /// </summary>
        /// <param name="destination">The buffer to which to write this value as UTF-8.</param>
        /// <param name="bytesWritten">
        /// The number of <see cref="byte"/>s written to <paramref name="destination"/>,
        /// or 0 if the destination buffer is not large enough to contain the output.</param>
        /// <returns>True if the value was written to the buffer; otherwise, false.</returns>
        /// <remarks>
        /// The <see cref="Utf8SequenceLength"/> property can be queried ahead of time to determine
        /// the required size of the <paramref name="destination"/> buffer.
        /// </remarks>
        public bool TryEncodeToUtf8(Span<byte> destination, out int bytesWritten)
        {
            // The bit patterns below come from the Unicode Standard, Table 3-6.

            if (destination.Length >= 1)
            {
                if (IsAscii)
                {
                    destination[0] = (byte)_value;
                    bytesWritten = 1;
                    return true;
                }

                if (destination.Length >= 2)
                {
                    if (_value <= 0x7FFu)
                    {
                        // Scalar 00000yyy yyxxxxxx -> bytes [ 110yyyyy 10xxxxxx ]
                        destination[0] = (byte)((_value + (0b110u << 11)) >> 6);
                        destination[1] = (byte)((_value & 0x3Fu) + 0x80u);
                        bytesWritten = 2;
                        return true;
                    }

                    if (destination.Length >= 3)
                    {
                        if (_value <= 0xFFFFu)
                        {
                            // Scalar zzzzyyyy yyxxxxxx -> bytes [ 1110zzzz 10yyyyyy 10xxxxxx ]
                            destination[0] = (byte)((_value + (0b1110 << 16)) >> 12);
                            destination[1] = (byte)(((_value & (0x3Fu << 6)) >> 6) + 0x80u);
                            destination[2] = (byte)((_value & 0x3Fu) + 0x80u);
                            bytesWritten = 3;
                            return true;
                        }

                        if (destination.Length >= 4)
                        {
                            // Scalar 000uuuuu zzzzyyyy yyxxxxxx -> bytes [ 11110uuu 10uuzzzz 10yyyyyy 10xxxxxx ]
                            destination[0] = (byte)((_value + (0b11110 << 21)) >> 18);
                            destination[1] = (byte)(((_value & (0x3Fu << 12)) >> 12) + 0x80u);
                            destination[2] = (byte)(((_value & (0x3Fu << 6)) >> 6) + 0x80u);
                            destination[3] = (byte)((_value & 0x3Fu) + 0x80u);
                            bytesWritten = 4;
                            return true;
                        }
                    }
                }
            }

            // Destination buffer not large enough

            bytesWritten = default;
            return false;
        }

        /// <summary>
        /// Attempts to get the <see cref="Rune"/> which begins at index <paramref name="index"/> in
        /// string <paramref name="input"/>.
        /// </summary>
        /// <returns><see langword="true"/> if a scalar value was successfully extracted from the specified index,
        /// <see langword="false"/> if a value could not be extracted due to invalid data.</returns>
        /// <remarks>
        /// Throws only if <paramref name="input"/> is null or <paramref name="index"/> is out of range.
        /// </remarks>
        public static bool TryGetRuneAt(string input, int index, out Rune value)
        {
            var runeValue = ReadRuneFromString(input, index);
            if (runeValue >= 0)
            {
                value = UnsafeCreate((uint)runeValue);
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        // Allows constructing a Unicode scalar value from an arbitrary 32-bit integer without
        // validation. It is the caller's responsibility to have performed manual validation
        // before calling this method. If a Rune instance is forcibly constructed
        // from invalid input, the APIs on this type have undefined behavior, potentially including
        // introducing a security hole in the consuming application.
        //
        // An example of a security hole resulting from an invalid Rune value, which could result
        // in a stack overflow.
        //
        // public int GetMarvin32HashCode(Rune r) {
        //   Span<char> buffer = stackalloc char[r.Utf16SequenceLength];
        //   r.TryEncode(buffer, ...);
        //   return Marvin32.ComputeHash(buffer.AsBytes());
        // }

        /// <summary>
        /// Creates a <see cref="Rune"/> without performing validation on the input.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Rune UnsafeCreate(uint scalarValue) => new Rune(scalarValue, false);

        // These are analogs of APIs on System.Char

        public static double GetNumericValue(Rune value)
        {
            if (value.IsAscii)
            {
                var baseNum = value._value - '0';
                return (baseNum <= 9) ? (double)baseNum : -1;
            }
            else
            {
                // not an ASCII char; fall back to globalization table
#if SYSTEM_PRIVATE_CORELIB
                return CharUnicodeInfo.GetNumericValue(value.Value);
#else
                if (value.IsBmp)
                {
                    return CharUnicodeInfo.GetNumericValue((char)value._value);
                }
                return CharUnicodeInfo.GetNumericValue(value.ToString(), 0);
#endif
            }
        }

        public static UnicodeCategory GetUnicodeCategory(Rune value)
        {
            if (value.IsAscii)
            {
                return (UnicodeCategory)(AsciiCharInfo[value.Value] & UnicodeCategoryMask);
            }
            else
            {
                return GetUnicodeCategoryNonAscii(value);
            }
        }

        private static UnicodeCategory GetUnicodeCategoryNonAscii(Rune value)
        {
            Debug.Assert(!value.IsAscii, "Shouldn't use this non-optimized code path for ASCII characters.");
#if (!NETSTANDARD2_0 && !NETFRAMEWORK)
            return CharUnicodeInfo.GetUnicodeCategory(value.Value);
#else
            if (value.IsBmp)
            {
                return CharUnicodeInfo.GetUnicodeCategory((char)value._value);
            }
            return CharUnicodeInfo.GetUnicodeCategory(value.ToString(), 0);
#endif
        }

        // Returns true iff this Unicode category represents a letter
        private static bool IsCategoryLetter(UnicodeCategory category)
        {
            return UnicodeUtility.IsInRangeInclusive((uint)category, (uint)UnicodeCategory.UppercaseLetter, (uint)UnicodeCategory.OtherLetter);
        }

        // Returns true iff this Unicode category represents a letter or a decimal digit
        private static bool IsCategoryLetterOrDecimalDigit(UnicodeCategory category)
        {
            return UnicodeUtility.IsInRangeInclusive((uint)category, (uint)UnicodeCategory.UppercaseLetter, (uint)UnicodeCategory.OtherLetter)
                || (category == UnicodeCategory.DecimalDigitNumber);
        }

        // Returns true iff this Unicode category represents a number
        private static bool IsCategoryNumber(UnicodeCategory category)
        {
            return UnicodeUtility.IsInRangeInclusive((uint)category, (uint)UnicodeCategory.DecimalDigitNumber, (uint)UnicodeCategory.OtherNumber);
        }

        // Returns true iff this Unicode category represents a punctuation mark
        private static bool IsCategoryPunctuation(UnicodeCategory category)
        {
            return UnicodeUtility.IsInRangeInclusive((uint)category, (uint)UnicodeCategory.ConnectorPunctuation, (uint)UnicodeCategory.OtherPunctuation);
        }

        // Returns true iff this Unicode category represents a separator
        private static bool IsCategorySeparator(UnicodeCategory category)
        {
            return UnicodeUtility.IsInRangeInclusive((uint)category, (uint)UnicodeCategory.SpaceSeparator, (uint)UnicodeCategory.ParagraphSeparator);
        }

        // Returns true iff this Unicode category represents a symbol
        private static bool IsCategorySymbol(UnicodeCategory category)
        {
            return UnicodeUtility.IsInRangeInclusive((uint)category, (uint)UnicodeCategory.MathSymbol, (uint)UnicodeCategory.OtherSymbol);
        }

        public static bool IsControl(Rune value)
        {
            // Per the Unicode stability policy, the set of control characters
            // is forever fixed at [ U+0000..U+001F ], [ U+007F..U+009F ]. No
            // characters will ever be added to or removed from the "control characters"
            // group. See https://www.unicode.org/policies/stability_policy.html.

            // Logic below depends on Rune.Value never being -1 (since Rune is a validating type)
            // 00..1F (+1) => 01..20 (&~80) => 01..20
            // 7F..9F (+1) => 80..A0 (&~80) => 00..20

            return ((value._value + 1) & ~0x80u) <= 0x20u;
        }

        public static bool IsDigit(Rune value)
        {
            if (value.IsAscii)
            {
                return UnicodeUtility.IsInRangeInclusive(value._value, '0', '9');
            }
            else
            {
                return GetUnicodeCategoryNonAscii(value) == UnicodeCategory.DecimalDigitNumber;
            }
        }

        public static bool IsLetter(Rune value)
        {
            if (value.IsAscii)
            {
                return ((value._value - 'A') & ~0x20u) <= (uint)('Z' - 'A'); // [A-Za-z]
            }
            else
            {
                return IsCategoryLetter(GetUnicodeCategoryNonAscii(value));
            }
        }

        public static bool IsLetterOrDigit(Rune value)
        {
            if (value.IsAscii)
            {
                return (AsciiCharInfo[value.Value] & IsLetterOrDigitFlag) != 0;
            }
            else
            {
                return IsCategoryLetterOrDecimalDigit(GetUnicodeCategoryNonAscii(value));
            }
        }

        public static bool IsLower(Rune value)
        {
            if (value.IsAscii)
            {
                return UnicodeUtility.IsInRangeInclusive(value._value, 'a', 'z');
            }
            else
            {
                return GetUnicodeCategoryNonAscii(value) == UnicodeCategory.LowercaseLetter;
            }
        }

        public static bool IsNumber(Rune value)
        {
            if (value.IsAscii)
            {
                return UnicodeUtility.IsInRangeInclusive(value._value, '0', '9');
            }
            else
            {
                return IsCategoryNumber(GetUnicodeCategoryNonAscii(value));
            }
        }

        public static bool IsPunctuation(Rune value)
        {
            return IsCategoryPunctuation(GetUnicodeCategory(value));
        }

        public static bool IsSeparator(Rune value)
        {
            return IsCategorySeparator(GetUnicodeCategory(value));
        }

        public static bool IsSymbol(Rune value)
        {
            return IsCategorySymbol(GetUnicodeCategory(value));
        }

        public static bool IsUpper(Rune value)
        {
            if (value.IsAscii)
            {
                return UnicodeUtility.IsInRangeInclusive(value._value, 'A', 'Z');
            }
            else
            {
                return GetUnicodeCategoryNonAscii(value) == UnicodeCategory.UppercaseLetter;
            }
        }

        public static bool IsWhiteSpace(Rune value)
        {
            if (value.IsAscii)
            {
                return (AsciiCharInfo[value.Value] & IsWhiteSpaceFlag) != 0;
            }

            // Only BMP code points can be white space, so only call into CharUnicodeInfo
            // if the incoming value is within the BMP.

            return value.IsBmp &&
#if SYSTEM_PRIVATE_CORELIB
                CharUnicodeInfo.GetIsWhiteSpace((char)value._value);
#else
                char.IsWhiteSpace((char)value._value);
#endif
        }

        public static Rune ToLower(Rune value, CultureInfo culture)
        {
            if (culture is null)
            {
                throw new ArgumentNullException(nameof(culture));
            }

            // We don't want to special-case ASCII here since the specified culture might handle
            // ASCII characters differently than the invariant culture (e.g., Turkish I). Instead
            // we'll just jump straight to the globalization tables if they're available.

            if (GlobalizationMode.Invariant)
            {
                return ToLowerInvariant(value);
            }

#if SYSTEM_PRIVATE_CORELIB
            return ChangeCaseCultureAware(value, culture.TextInfo, toUpper: false);
#else
            return ChangeCaseCultureAware(value, culture, toUpper: false);
#endif
        }

        public static Rune ToLowerInvariant(Rune value)
        {
            // Handle the most common case (ASCII data) first. Within the common case, we expect
            // that there'll be a mix of lowercase & uppercase chars, so make the conversion branchless.

            if (value.IsAscii)
            {
                // It's ok for us to use the UTF-16 conversion utility for this since the high
                // 16 bits of the value will never be set so will be left unchanged.
                return UnsafeCreate(Utf16Utility.ConvertAllAsciiCharsInUInt32ToLowercase(value._value));
            }

            if (GlobalizationMode.Invariant)
            {
                // If the value isn't ASCII and if the globalization tables aren't available,
                // case changing has no effect.
                return value;
            }

            // Non-ASCII data requires going through the case folding tables.

#if SYSTEM_PRIVATE_CORELIB
            return ChangeCaseCultureAware(value, TextInfo.Invariant, toUpper: false);
#else
            return ChangeCaseCultureAware(value, CultureInfo.InvariantCulture, toUpper: false);
#endif
        }

        public static Rune ToUpper(Rune value, CultureInfo culture)
        {
            if (culture is null)
                throw new ArgumentNullException(nameof(culture));

            // We don't want to special-case ASCII here since the specified culture might handle
            // ASCII characters differently than the invariant culture (e.g., Turkish I). Instead
            // we'll just jump straight to the globalization tables if they're available.

            if (GlobalizationMode.Invariant)
            {
                return ToUpperInvariant(value);
            }

#if SYSTEM_PRIVATE_CORELIB
            return ChangeCaseCultureAware(value, culture.TextInfo, toUpper: true);
#else
            return ChangeCaseCultureAware(value, culture, toUpper: true);
#endif
        }

        public static Rune ToUpperInvariant(Rune value)
        {
            // Handle the most common case (ASCII data) first. Within the common case, we expect
            // that there'll be a mix of lowercase & uppercase chars, so make the conversion branchless.

            if (value.IsAscii)
            {
                // It's ok for us to use the UTF-16 conversion utility for this since the high
                // 16 bits of the value will never be set so will be left unchanged.
                return UnsafeCreate(Utf16Utility.ConvertAllAsciiCharsInUInt32ToUppercase(value._value));
            }

            if (GlobalizationMode.Invariant)
            {
                // If the value isn't ASCII and if the globalization tables aren't available,
                // case changing has no effect.
                return value;
            }

            // Non-ASCII data requires going through the case folding tables.

#if SYSTEM_PRIVATE_CORELIB
            return ChangeCaseCultureAware(value, TextInfo.Invariant, toUpper: true);
#else
            return ChangeCaseCultureAware(value, CultureInfo.InvariantCulture, toUpper: true);
#endif
        }

        /// <inheritdoc cref="IComparable.CompareTo" />
        int IComparable.CompareTo(object? obj)
        {
            if (obj is null)
            {
                return 1; // non-null ("this") always sorts after null
            }

            if (obj is Rune other)
            {
                return CompareTo(other);
            }

            throw new ArgumentException("Object must be of type Rune.");
        }
    }

    internal static class UnicodeUtility
    {
        /// <summary>
        /// The Unicode replacement character U+FFFD.
        /// </summary>
        public const uint ReplacementChar = 0xFFFD;

        /// <summary>
        /// Returns the Unicode plane (0 through 16, inclusive) which contains this code point.
        /// </summary>
        public static int GetPlane(uint codePoint)
        {
            UnicodeDebug.AssertIsValidCodePoint(codePoint);

            return (int)(codePoint >> 16);
        }

        /// <summary>
        /// Returns a Unicode scalar value from two code points representing a UTF-16 surrogate pair.
        /// </summary>
        public static uint GetScalarFromUtf16SurrogatePair(uint highSurrogateCodePoint, uint lowSurrogateCodePoint)
        {
            UnicodeDebug.AssertIsHighSurrogateCodePoint(highSurrogateCodePoint);
            UnicodeDebug.AssertIsLowSurrogateCodePoint(lowSurrogateCodePoint);

            // This calculation comes from the Unicode specification, Table 3-5.
            // Need to remove the D800 marker from the high surrogate and the DC00 marker from the low surrogate,
            // then fix up the "wwww = uuuuu - 1" section of the bit distribution. The code is written as below
            // to become just two instructions: shl, lea.

            return (highSurrogateCodePoint << 10) + lowSurrogateCodePoint - ((0xD800U << 10) + 0xDC00U - (1 << 16));
        }

        /// <summary>
        /// Given a Unicode scalar value, gets the number of UTF-16 code units required to represent this value.
        /// </summary>
        public static int GetUtf16SequenceLength(uint value)
        {
            UnicodeDebug.AssertIsValidScalar(value);

            value -= 0x10000;   // if value < 0x10000, high byte = 0xFF; else high byte = 0x00
            value += (2 << 24); // if value < 0x10000, high byte = 0x01; else high byte = 0x02
            value >>= 24;       // shift high byte down
            return (int)value;  // and return it
        }

        /// <summary>
        /// Decomposes an astral Unicode scalar into UTF-16 high and low surrogate code units.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetUtf16SurrogatesFromSupplementaryPlaneScalar(uint value, out char highSurrogateCodePoint, out char lowSurrogateCodePoint)
        {
            UnicodeDebug.AssertIsValidSupplementaryPlaneScalar(value);

            // This calculation comes from the Unicode specification, Table 3-5.

            highSurrogateCodePoint = (char)((value + ((0xD800u - 0x40u) << 10)) >> 10);
            lowSurrogateCodePoint = (char)((value & 0x3FFu) + 0xDC00u);
        }

        /// <summary>
        /// Given a Unicode scalar value, gets the number of UTF-8 code units required to represent this value.
        /// </summary>
        public static int GetUtf8SequenceLength(uint value)
        {
            UnicodeDebug.AssertIsValidScalar(value);

            // The logic below can handle all valid scalar values branchlessly.
            // It gives generally good performance across all inputs, and on x86
            // it's only six instructions: lea, sar, xor, add, shr, lea.

            // 'a' will be -1 if input is < 0x800; else 'a' will be 0
            // => 'a' will be -1 if input is 1 or 2 UTF-8 code units; else 'a' will be 0

            var a = ((int)value - 0x0800) >> 31;

            // The number of UTF-8 code units for a given scalar is as follows:
            // - U+0000..U+007F => 1 code unit
            // - U+0080..U+07FF => 2 code units
            // - U+0800..U+FFFF => 3 code units
            // - U+10000+       => 4 code units
            //
            // If we XOR the incoming scalar with 0xF800, the chart mutates:
            // - U+0000..U+F7FF => 3 code units
            // - U+F800..U+F87F => 1 code unit
            // - U+F880..U+FFFF => 2 code units
            // - U+10000+       => 4 code units
            //
            // Since the 1- and 3-code unit cases are now clustered, they can
            // both be checked together very cheaply.

            value ^= 0xF800u;
            value -= 0xF880u;   // if scalar is 1 or 3 code units, high byte = 0xFF; else high byte = 0x00
            value += (4 << 24); // if scalar is 1 or 3 code units, high byte = 0x03; else high byte = 0x04
            value >>= 24;       // shift high byte down

            // Final return value:
            // - U+0000..U+007F => 3 + (-1) * 2 = 1
            // - U+0080..U+07FF => 4 + (-1) * 2 = 2
            // - U+0800..U+FFFF => 3 + ( 0) * 2 = 3
            // - U+10000+       => 4 + ( 0) * 2 = 4
            return (int)value + (a * 2);
        }

        /// <summary>
        /// Returns <see langword="true"/> iff <paramref name="value"/> is an ASCII
        /// character ([ U+0000..U+007F ]).
        /// </summary>
        /// <remarks>
        /// Per http://www.unicode.org/glossary/#ASCII, ASCII is only U+0000..U+007F.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAsciiCodePoint(uint value) => value <= 0x7Fu;

        /// <summary>
        /// Returns <see langword="true"/> iff <paramref name="value"/> is in the
        /// Basic Multilingual Plane (BMP).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBmpCodePoint(uint value) => value <= 0xFFFFu;

        /// <summary>
        /// Returns <see langword="true"/> iff <paramref name="value"/> is a UTF-16 high surrogate code point,
        /// i.e., is in [ U+D800..U+DBFF ], inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsHighSurrogateCodePoint(uint value) => IsInRangeInclusive(value, 0xD800U, 0xDBFFU);

        /// <summary>
        /// Returns <see langword="true"/> iff <paramref name="value"/> is between
        /// <paramref name="lowerBound"/> and <paramref name="upperBound"/>, inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInRangeInclusive(uint value, uint lowerBound, uint upperBound) => (value - lowerBound) <= (upperBound - lowerBound);

        /// <summary>
        /// Returns <see langword="true"/> iff <paramref name="value"/> is a UTF-16 low surrogate code point,
        /// i.e., is in [ U+DC00..U+DFFF ], inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLowSurrogateCodePoint(uint value) => IsInRangeInclusive(value, 0xDC00U, 0xDFFFU);

        /// <summary>
        /// Returns <see langword="true"/> iff <paramref name="value"/> is a UTF-16 surrogate code point,
        /// i.e., is in [ U+D800..U+DFFF ], inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSurrogateCodePoint(uint value) => IsInRangeInclusive(value, 0xD800U, 0xDFFFU);

        /// <summary>
        /// Returns <see langword="true"/> iff <paramref name="codePoint"/> is a valid Unicode code
        /// point, i.e., is in [ U+0000..U+10FFFF ], inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValidCodePoint(uint codePoint) => codePoint <= 0x10FFFFU;

        /// <summary>
        /// Returns <see langword="true"/> iff <paramref name="value"/> is a valid Unicode scalar
        /// value, i.e., is in [ U+0000..U+D7FF ], inclusive; or [ U+E000..U+10FFFF ], inclusive.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValidUnicodeScalar(uint value)
        {
            // This is an optimized check that on x86 is just three instructions: lea, xor, cmp.
            //
            // After the subtraction operation, the input value is modified as such:
            // [ 00000000..0010FFFF ] -> [ FFEF0000..FFFFFFFF ]
            //
            // We now want to _exclude_ the range [ FFEFD800..FFEFDFFF ] (surrogates) from being valid.
            // After the xor, this particular exclusion range becomes [ FFEF0000..FFEF07FF ].
            //
            // So now the range [ FFEF0800..FFFFFFFF ] contains all valid code points,
            // excluding surrogates. This allows us to perform a single comparison.

            return ((value - 0x110000u) ^ 0xD800u) >= 0xFFEF0800u;
        }
    }

    internal static class UnicodeDebug
    {
        [Conditional("DEBUG")]
        internal static void AssertIsBmpCodePoint(uint codePoint)
        {
            if (!UnicodeUtility.IsBmpCodePoint(codePoint))
            {
                Debug.Fail($"The value {ToHexString(codePoint)} is not a valid BMP code point.");
            }
        }

        [Conditional("DEBUG")]
        internal static void AssertIsHighSurrogateCodePoint(uint codePoint)
        {
            if (!UnicodeUtility.IsHighSurrogateCodePoint(codePoint))
            {
                Debug.Fail($"The value {ToHexString(codePoint)} is not a valid UTF-16 high surrogate code point.");
            }
        }

        [Conditional("DEBUG")]
        internal static void AssertIsLowSurrogateCodePoint(uint codePoint)
        {
            if (!UnicodeUtility.IsLowSurrogateCodePoint(codePoint))
            {
                Debug.Fail($"The value {ToHexString(codePoint)} is not a valid UTF-16 low surrogate code point.");
            }
        }

        [Conditional("DEBUG")]
        internal static void AssertIsValidCodePoint(uint codePoint)
        {
            if (!UnicodeUtility.IsValidCodePoint(codePoint))
            {
                Debug.Fail($"The value {ToHexString(codePoint)} is not a valid Unicode code point.");
            }
        }

        [Conditional("DEBUG")]
        internal static void AssertIsValidScalar(uint scalarValue)
        {
            if (!UnicodeUtility.IsValidUnicodeScalar(scalarValue))
            {
                Debug.Fail($"The value {ToHexString(scalarValue)} is not a valid Unicode scalar value.");
            }
        }

        [Conditional("DEBUG")]
        internal static void AssertIsValidSupplementaryPlaneScalar(uint scalarValue)
        {
            if (!UnicodeUtility.IsValidUnicodeScalar(scalarValue) || UnicodeUtility.IsBmpCodePoint(scalarValue))
            {
                Debug.Fail($"The value {ToHexString(scalarValue)} is not a valid supplementary plane Unicode scalar value.");
            }
        }

        /// <summary>
        /// Formats a code point as the hex string "U+XXXX".
        /// </summary>
        /// <remarks>
        /// The input value doesn't have to be a real code point in the Unicode codespace. It can be any integer.
        /// </remarks>
        private static string ToHexString(uint codePoint)
        {
            return FormattableString.Invariant($"U+{codePoint:X4}");
        }
    }

    // An enumerator for retrieving System.Text.Rune instances from a ROS<char>.
    // Methods are pattern-matched by compiler to allow using foreach pattern.
    internal ref struct SpanRuneEnumerator
    {
        private ReadOnlySpan<char> _remaining;

        internal SpanRuneEnumerator(ReadOnlySpan<char> buffer)
        {
            _remaining = buffer;
            Current = default;
        }

        public Rune Current { get; private set; }

        public SpanRuneEnumerator GetEnumerator() => this;

        public bool MoveNext()
        {
            if (_remaining.IsEmpty)
            {
                // reached the end of the buffer
                Current = default;
                return false;
            }

            var scalarValue = Rune.ReadFirstRuneFromUtf16Buffer(_remaining);
            if (scalarValue < 0)
            {
                // replace invalid sequences with U+FFFD
                scalarValue = Rune.ReplacementChar.Value;
            }

            // In UTF-16 specifically, invalid sequences always have length 1, which is the same
            // length as the replacement character U+FFFD. This means that we can always bump the
            // next index by the current scalar's UTF-16 sequence length. This optimization is not
            // generally applicable; for example, enumerating scalars from UTF-8 cannot utilize
            // this same trick.

            Current = Rune.UnsafeCreate((uint)scalarValue);
            _remaining = _remaining.Slice(Current.Utf16SequenceLength);
            return true;
        }
    }

    // An enumerator for retrieving System.Text.Rune instances from a System.String.
    internal struct StringRuneEnumerator : IEnumerable<Rune>, IEnumerator<Rune>
    {
        private readonly string _string;
        private Rune _current;
        private int _nextIndex;

        internal StringRuneEnumerator(string value)
        {
            _string = value;
            _current = default;
            _nextIndex = 0;
        }

        public Rune Current => _current;

        public StringRuneEnumerator GetEnumerator() => this;

        public bool MoveNext()
        {
            if ((uint)_nextIndex >= _string.Length)
            {
                // reached the end of the string
                _current = default;
                return false;
            }

            if (!Rune.TryGetRuneAt(_string, _nextIndex, out _current))
            {
                // replace invalid sequences with U+FFFD
                _current = Rune.ReplacementChar;
            }

            // In UTF-16 specifically, invalid sequences always have length 1, which is the same
            // length as the replacement character U+FFFD. This means that we can always bump the
            // next index by the current scalar's UTF-16 sequence length. This optimization is not
            // generally applicable; for example, enumerating scalars from UTF-8 cannot utilize
            // this same trick.

            _nextIndex += _current.Utf16SequenceLength;
            return true;
        }

        object? IEnumerator.Current => _current;

        void IDisposable.Dispose()
        {
            // no-op
        }

        IEnumerator IEnumerable.GetEnumerator() => this;

        IEnumerator<Rune> IEnumerable<Rune>.GetEnumerator() => this;

        void IEnumerator.Reset()
        {
            _current = default;
            _nextIndex = 0;
        }
    }
}

namespace System.Text.Unicode
{
    internal static class Utf16Utility
    {
        /// <summary>
        /// Returns true iff the UInt32 represents two ASCII UTF-16 characters in machine endianness.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool AllCharsInUInt32AreAscii(uint value)
        {
            return (value & ~0x007F_007Fu) == 0;
        }

        /// <summary>
        /// Given a UInt32 that represents two ASCII UTF-16 characters, returns the invariant
        /// uppercase representation of those characters. Requires the input value to contain
        /// two ASCII UTF-16 characters in machine endianness.
        /// </summary>
        /// <remarks>
        /// This is a branchless implementation.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint ConvertAllAsciiCharsInUInt32ToUppercase(uint value)
        {
            // Intrinsified in mono interpreter
            // ASSUMPTION: Caller has validated that input value is ASCII.
            Debug.Assert(AllCharsInUInt32AreAscii(value));

            // the 0x80 bit of each word of 'lowerIndicator' will be set iff the word has value >= 'a'
            var lowerIndicator = value + 0x0080_0080u - 0x0061_0061u;

            // the 0x80 bit of each word of 'upperIndicator' will be set iff the word has value > 'z'
            var upperIndicator = value + 0x0080_0080u - 0x007B_007Bu;

            // the 0x80 bit of each word of 'combinedIndicator' will be set iff the word has value >= 'a' and <= 'z'
            var combinedIndicator = (lowerIndicator ^ upperIndicator);

            // the 0x20 bit of each word of 'mask' will be set iff the word has value >= 'a' and <= 'z'
            var mask = (combinedIndicator & 0x0080_0080u) >> 2;

            return value ^ mask; // bit flip lowercase letters [a-z] => [A-Z]
        }

        /// <summary>
        /// Given a UInt32 that represents two ASCII UTF-16 characters, returns the invariant
        /// lowercase representation of those characters. Requires the input value to contain
        /// two ASCII UTF-16 characters in machine endianness.
        /// </summary>
        /// <remarks>
        /// This is a branchless implementation.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint ConvertAllAsciiCharsInUInt32ToLowercase(uint value)
        {
            // ASSUMPTION: Caller has validated that input value is ASCII.
            Debug.Assert(AllCharsInUInt32AreAscii(value));

            // the 0x80 bit of each word of 'lowerIndicator' will be set iff the word has value >= 'A'
            var lowerIndicator = value + 0x0080_0080u - 0x0041_0041u;

            // the 0x80 bit of each word of 'upperIndicator' will be set iff the word has value > 'Z'
            var upperIndicator = value + 0x0080_0080u - 0x005B_005Bu;

            // the 0x80 bit of each word of 'combinedIndicator' will be set iff the word has value >= 'A' and <= 'Z'
            var combinedIndicator = (lowerIndicator ^ upperIndicator);

            // the 0x20 bit of each word of 'mask' will be set iff the word has value >= 'A' and <= 'Z'
            var mask = (combinedIndicator & 0x0080_0080u) >> 2;

            return value ^ mask; // bit flip uppercase letters [A-Z] => [a-z]
        }
    }
}

namespace System.Globalization
{
    internal static class GlobalizationMode
    {
        internal static bool Invariant { get; } = AppContextConfigHelper.GetBooleanConfig("System.Globalization.Invariant", "DOTNET_SYSTEM_GLOBALIZATION_INVARIANT");
    }
}

namespace System
{
    internal static class AppContextConfigHelper
    {
        internal static bool GetBooleanConfig(string switchName, string envVariable)
        {
            if (!AppContext.TryGetSwitch(switchName, out var ret))
            {
                var switchValue = Environment.GetEnvironmentVariable(envVariable);
                if (switchValue is not null)
                {
                    ret = IsTrueStringIgnoreCase(switchValue.AsSpan()) || switchValue.Equals("1", StringComparison.Ordinal);
                }
            }

            return ret;
        }

        private static bool IsTrueStringIgnoreCase(ReadOnlySpan<char> value)
        {
            return value.Length == 4 &&
                    (value[0] == 't' || value[0] == 'T') &&
                    (value[1] == 'r' || value[1] == 'R') &&
                    (value[2] == 'u' || value[2] == 'U') &&
                    (value[3] == 'e' || value[3] == 'E');
        }
    }

    internal static partial class StringExtension
    {
        public static StringRuneEnumerator EnumerateRunes(this string str)
        {
            return new StringRuneEnumerator(str);
        }
    }

    internal static partial class MemoryExtension
    {
        public static SpanRuneEnumerator EnumerateRunes(this ReadOnlySpan<char> span)
        {
            return new SpanRuneEnumerator(span);
        }

        public static SpanRuneEnumerator EnumerateRunes(this Span<char> span)
        {
            return new SpanRuneEnumerator(span);
        }
    }
}

#endif
