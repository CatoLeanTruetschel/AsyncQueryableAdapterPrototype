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

namespace AsyncQueryableAdapterPrototype.Tests
{
    internal sealed record PersonEntry(Guid Id, string FirstName, string LastName, double Age, DateTime Birthday)
    {
        public PersonEntry(string firstName, string lastName, double age)
            : this(Guid.NewGuid(), firstName, lastName, age, DateTime.Now.AddDays(-age * 365)) { }
    }

    internal sealed class PersonEntryByLastNameEqualityComparer : IEqualityComparer<PersonEntry>
    {
        public bool Equals(PersonEntry? x, PersonEntry? y)
        {
            return string.Equals(x?.LastName, y?.LastName, StringComparison.Ordinal);
        }

        public int GetHashCode(PersonEntry obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return HashCode.Combine(obj.LastName);
        }
    }
}
