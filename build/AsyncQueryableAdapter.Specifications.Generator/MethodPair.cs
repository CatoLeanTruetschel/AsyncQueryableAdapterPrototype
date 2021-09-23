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
using System.Reflection;

namespace AsyncQueryableAdapter.Specifications.Generator
{
    // Non-defaultable // TODO: Can we verify this?
    internal struct MethodPair
    {
        public MethodPair(MethodInfo asyncMethod, MethodInfo syncMethod)
        {
            if (asyncMethod is null)
                throw new ArgumentNullException(nameof(asyncMethod));

            if (syncMethod is null)
                throw new ArgumentNullException(nameof(syncMethod));

            AsyncMethod = asyncMethod;
            SyncMethod = syncMethod;
        }

        public MethodInfo AsyncMethod { get; }

        public MethodInfo SyncMethod { get; }

        public void Deconstruct(out MethodInfo asyncMethod, out MethodInfo syncMethod)
        {
            asyncMethod = AsyncMethod;
            syncMethod = SyncMethod;
        }
    }
}
