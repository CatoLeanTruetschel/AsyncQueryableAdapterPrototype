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

namespace AsyncQueryableAdapter.Specifications.Generator
{
    public readonly struct UniqueIdentifier : IEquatable<UniqueIdentifier>
    {
        private readonly string? _value;

        public UniqueIdentifier(string value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            _value = value;
        }

        public override string ToString()
        {
            return _value ?? string.Empty;
        }

        public bool Equals(UniqueIdentifier other)
        {
            return StringComparer.Ordinal.Equals(ToString(), other.ToString());
        }

        public override bool Equals(object? obj)
        {
            return obj is UniqueIdentifier uniqueIdentifier && Equals(uniqueIdentifier);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(ToString());
        }

        public static bool operator ==(UniqueIdentifier left, UniqueIdentifier right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UniqueIdentifier left, UniqueIdentifier right)
        {
            return !left.Equals(right);
        }
    }
}
