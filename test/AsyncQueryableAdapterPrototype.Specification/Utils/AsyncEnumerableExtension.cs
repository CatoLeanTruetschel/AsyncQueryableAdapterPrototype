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

using System.Threading.Tasks;
using System.Linq;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    internal static class AsyncEnumerableExtension
    {
        public static async ValueTask<IEnumerable<T>> EvaluateAsync<T>(this IAsyncEnumerable<T> asyncEnumerable)
        {
            if (asyncEnumerable is null)
                throw new ArgumentNullException(nameof(asyncEnumerable));

            return await asyncEnumerable.ToArrayAsync();
        }

        public static ValueTaskAwaiter<IEnumerable<T>> GetAwaiter<T>(this IAsyncEnumerable<T> asyncEnumerable)
        {
            if (asyncEnumerable is null)
                throw new ArgumentNullException(nameof(asyncEnumerable));

            return asyncEnumerable.EvaluateAsync().GetAwaiter();
        }
    }
}
