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

namespace AsyncQueryableAdapter.Specifications.Generator.Parameters
{
    // Non-defaultable // TODO: Can we verify this?
    internal readonly struct ParameterPair
    {
        public ParameterPair(Parameter asyncParameter, Parameter syncParameter)
        {
            if (asyncParameter is null)
                throw new ArgumentNullException(nameof(asyncParameter));

            if (syncParameter is null)
                throw new ArgumentNullException(nameof(syncParameter));

            AsyncParameter = asyncParameter;
            SyncParameter = syncParameter;
        }

        public Parameter AsyncParameter { get; }

        public Parameter SyncParameter { get; }

        public void Deconstruct(out Parameter asyncParameter, out Parameter syncParameter)
        {
            asyncParameter = AsyncParameter;
            syncParameter = SyncParameter;
        }
    }
}
