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
        public static async ValueTask<IEnumerable<IGrouping<TKey, TElement>>> AwaitGroupings<TKey, TElement>(
            this IAsyncEnumerable<IAsyncGrouping<TKey, TElement>> asyncEnumerable)
        {
            if (asyncEnumerable is null)
                throw new ArgumentNullException(nameof(asyncEnumerable));

            var enumerable = await asyncEnumerable.ConfigureAwait(false);
            IEnumerable<IGrouping<TKey, TElement>> groupings;

            try
            {
                groupings = await Task.WhenAll(
                    enumerable.Select(grouping => AwaitGrouping(grouping))).ConfigureAwait(false);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentException("The enumerable must not contain null entries.");
            }

            return groupings;
        }

        private static async Task<IGrouping<TKey, TElement>> AwaitGrouping<TKey, TElement>(
            IAsyncGrouping<TKey, TElement> asyncGrouping)
        {
            if (asyncGrouping is null)
                throw new ArgumentNullException(nameof(asyncGrouping));

            var key = asyncGrouping.Key;
            var enumerable = await asyncGrouping.ConfigureAwait(false);

            return new Grouping<TKey, TElement>(key, enumerable);
        }

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

        public static ConfiguredAsyncEnumerable<T> ConfigureAwait<T>(
            this IAsyncEnumerable<T> asyncEnumerable,
            bool continueOnCapturedContext)
        {
            if (asyncEnumerable is null)
                throw new ArgumentNullException(nameof(asyncEnumerable));

            return new ConfiguredAsyncEnumerable<T>(asyncEnumerable, continueOnCapturedContext);
        }
    }

    internal class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private readonly IEnumerable<TElement> _enumerable;

        public Grouping(TKey key, IEnumerable<TElement> enumerable)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));

            Key = key;
            _enumerable = enumerable;
        }

        public TKey Key { get; }

        public IEnumerator<TElement> GetEnumerator()
        {
            return _enumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_enumerable).GetEnumerator();
        }
    }

    internal readonly struct ConfiguredAsyncEnumerable<T>
    {
        private readonly IAsyncEnumerable<T>? _asyncEnumerable;
        private readonly bool _continueOnCapturedContext;

        public ConfiguredAsyncEnumerable(IAsyncEnumerable<T> asyncEnumerable, bool continueOnCapturedContext)
        {
            if (asyncEnumerable is null)
                throw new ArgumentNullException(nameof(asyncEnumerable));

            _asyncEnumerable = asyncEnumerable;
            _continueOnCapturedContext = continueOnCapturedContext;
        }

        public ConfiguredAsyncEnumerable<T> ConfigureAwait(bool continueOnCapturedContext)
        {
            return new ConfiguredAsyncEnumerable<T>(_asyncEnumerable, continueOnCapturedContext);
        }

        private async ValueTask<IEnumerable<T>> EvaluateAsync()
        {
            return await _asyncEnumerable.ToArrayAsync().ConfigureAwait(_continueOnCapturedContext);
        }

        public ValueTaskAwaiter<IEnumerable<T>> GetAwaiter()
        {
            return EvaluateAsync().GetAwaiter();
        }
    }
}
