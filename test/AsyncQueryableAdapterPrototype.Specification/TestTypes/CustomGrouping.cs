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
using System.Linq;
using System.Threading;

namespace AsyncQueryableAdapterPrototype.Tests.TestTypes
{
    public sealed class CustomGrouping<TKey, TElement> : IAsyncGrouping<TKey, TElement>
    {
        private readonly IAsyncEnumerable<TElement> _elements;

        public CustomGrouping(TKey key, IEnumerable<TElement> elements)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            Key = key;
            _elements = elements.ToAsyncEnumerable();
        }

        public CustomGrouping(TKey key, IAsyncEnumerable<TElement> elements)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            Key = key;
            _elements = elements;
        }

        public TKey Key { get; }

        public IAsyncEnumerator<TElement> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return _elements.GetAsyncEnumerator(cancellationToken);
        }
    }

    public static class CustomGrouping
    {
        public static CustomGrouping<TKey, TElement> Create<TKey, TElement>(TKey key, IEnumerable<TElement> elements)
        {
            return new CustomGrouping<TKey, TElement>(key, elements);
        }

        public static CustomGrouping<TKey, TElement> Create<TKey, TElement>(
            TKey key,
            IAsyncEnumerable<TElement> elements)
        {
            return new CustomGrouping<TKey, TElement>(key, elements);
        }
    }
}
