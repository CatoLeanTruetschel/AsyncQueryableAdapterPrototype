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

namespace AsyncQueryableAdapter.Specifications.Generator
{
    internal sealed class NamespaceComparer : IComparer<string>
    {
        public static NamespaceComparer Instance { get; } = new NamespaceComparer();

        private NamespaceComparer() { }

        public int Compare(string? x, string? y)
        {
            // returns
            // negative value if x < y
            //          zero if x == y
            // positive value if x > y
            if (x is not null && y is not null)
            {
                var xStartsWithSystem = x.StartsWith("System", StringComparison.Ordinal);
                var yStartsWithSystem = y.StartsWith("System", StringComparison.Ordinal);

                if (xStartsWithSystem && !yStartsWithSystem)
                {
                    // x < y
                    return -1;
                }

                if (!xStartsWithSystem && yStartsWithSystem)
                {
                    // x > y
                    return 1;
                }
            }

            return StringComparer.Ordinal.Compare(x, y);
        }
    }
}
