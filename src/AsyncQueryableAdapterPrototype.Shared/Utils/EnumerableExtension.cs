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

using System.Buffers;
using System.Linq;
using AsyncQueryableAdapterPrototype.Utils;

namespace System.Collections.Generic
{
    internal static partial class EnumerableExtension
    {
        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            var array = ArrayPool<T?>.Shared.Rent(count);
            try
            {
                using var buffer = new CircularBuffer<T>(array.AsMemory(0, count));

                foreach (var entry in source)
                {
                    if (buffer.Count == buffer.Capacity)
                    {
                        yield return buffer.Dequeue();
                    }

                    buffer.Enqueue(entry);
                }
            }
            finally
            {
                ArrayPool<T?>.Shared.Return(array);
            }
        }

        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int count)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (count == 0)
                return Enumerable.Empty<T>();

            using var buffer = new CircularBuffer<T>(count);

            foreach (var entry in source)
            {
                if (buffer.Count == buffer.Capacity)
                {
                    buffer.Dequeue();
                }

                buffer.Enqueue(entry);
            }

            return buffer.ToArray();
        }
    }
}
