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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapterPrototype.Tests;
using AsyncQueryableAdapterPrototype.Tests.Utils;

namespace AsyncQueryableAdapter.Tests
{
    public sealed class QueryAdapterTest : QueryAdapterSpecification
    {
        protected override async ValueTask<QueryAdapterBase> GetQueryAdapterAsync(
            AsyncQueryableOptions options,
            Func<ISeedHelper, CancellationToken, ValueTask> seed)
        {
            return await QueryAdapter.CreateAsync(options, seed);
        }
    }
}
