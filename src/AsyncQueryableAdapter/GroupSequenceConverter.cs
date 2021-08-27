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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncQueryableAdapter
{
    /// <summary>
    /// Converters sequences of <see cref="IGrouping{TKey, TElement}"/> to sequences of 
    /// <see cref="IAsyncGrouping{TKey, TElement}"/>.
    /// </summary>
    internal static class GroupSequenceConverter
    {
        private static readonly ConditionalWeakTable<Type, IKeyedGroupSequenceConverter> _converterCache = new();
        private static readonly ConditionalWeakTable<Type, IKeyedGroupSequenceConverter>.CreateValueCallback _buildConverter
            = BuildConverter;

        private static IKeyedGroupSequenceConverter BuildConverter(Type keyType)
        {
            return (IKeyedGroupSequenceConverter)Activator.CreateInstance(
                typeof(KeyedGroupSequenceConverter<>).MakeGenericType(keyType))!;
        }

        /// <summary>
        /// Converts the specified sequence of <see cref="IGrouping{TKey, TElement}"/> values to a sequence of
        /// <see cref="IAsyncGrouping{TKey, TElement}"/> values.
        /// </summary>
        /// <param name="keyType">The type of grouping key.</param>
        /// <param name="elementType">The type of grouping element.</param>
        /// <param name="sequence">The sequence to convert.</param>
        /// <returns>The converted sequence.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if any of <paramref name="keyType"/>, <paramref name="elementType"/> 
        /// or <paramref name="sequence"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// Thrown if the dynamic type is not cast-able to type <see cref="IAsyncEnumerable{IGrouping{TKey, TElement}}"/>
        /// with <c>typeof(TKey) == keyType</c> and <c>typeof(TElement) == elementType</c>.
        /// </exception>
#pragma warning disable VSTHRD200
        public static IAsyncEnumerable<object?> Convert(
            Type keyType,
            Type elementType,
            IAsyncEnumerable<object?> sequence)
#pragma warning restore VSTHRD200
        {
            var converter = _converterCache.GetValue(keyType, _buildConverter);
            return converter.Convert(elementType, sequence);
        }

        private interface IKeyedGroupSequenceConverter
        {
            public Type KeyType { get; }

#pragma warning disable VSTHRD200
            IAsyncEnumerable<object?> Convert(Type elementType, IAsyncEnumerable<object?> sequence);
#pragma warning restore VSTHRD200
        }

        private interface ITypedGroupSequenceConverter
        {
            public Type KeyType { get; }

            public Type ElementType { get; }

#pragma warning disable VSTHRD200
            IAsyncEnumerable<object?> Convert(IAsyncEnumerable<object?> sequence);
#pragma warning restore VSTHRD200
        }

        private sealed class KeyedGroupSequenceConverter<TKey> : IKeyedGroupSequenceConverter
        {
            private static readonly ConditionalWeakTable<Type, ITypedGroupSequenceConverter> _converterCache = new();
            private static readonly ConditionalWeakTable<Type, ITypedGroupSequenceConverter>.CreateValueCallback _buildConverter
                = BuildConverter;

            private static ITypedGroupSequenceConverter BuildConverter(Type elementType)
            {
                return (ITypedGroupSequenceConverter)Activator.CreateInstance(
                    typeof(TypedGroupSequenceConverter<,>).MakeGenericType(typeof(TKey), elementType))!;
            }

            public Type KeyType => typeof(TKey);

            public IAsyncEnumerable<object?> Convert(Type elementType, IAsyncEnumerable<object?> sequence)
            {
                var converter = _converterCache.GetValue(elementType, _buildConverter);
                return converter.Convert(sequence);
            }
        }

        private sealed class TypedGroupSequenceConverter<TKey, TElement> : ITypedGroupSequenceConverter
        {
            public Type KeyType => typeof(TKey);

            public Type ElementType => typeof(TElement);

            public IAsyncEnumerable<object?> Convert(IAsyncEnumerable<object?> sequence)
            {
                if (sequence is not IAsyncEnumerable<IGrouping<TKey, TElement>?> typedSequence)
                {
                    typedSequence = sequence.Select(
                        grouping => grouping is null ? null : (IGrouping<TKey, TElement>)grouping);
                }

                return typedSequence.Select(
                    grouping => grouping is null ? null : new AsyncWrappedGrouping<TKey, TElement>(grouping));
            }
        }
    }

    internal sealed class AsyncWrappedGrouping<TKey, TElement> : IAsyncGrouping<TKey, TElement>
    {
        private readonly IEnumerable<TElement> _enumerable;

        public AsyncWrappedGrouping(TKey key, IEnumerable<TElement> enumerable)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));

            Key = key;
            _enumerable = enumerable;
        }

        public AsyncWrappedGrouping(IGrouping<TKey, TElement> grouping)
        {
            if (grouping is null)
                throw new ArgumentNullException(nameof(grouping));

            Key = grouping.Key;
            _enumerable = grouping;
        }

        public TKey Key { get; }

        public IAsyncEnumerator<TElement> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new AsyncEnumerator(this);
        }

        private sealed class AsyncEnumerator : IAsyncEnumerator<TElement>
        {
            private readonly AsyncWrappedGrouping<TKey, TElement> _owner;
            private IEnumerator<TElement>? _enumerator;

            public AsyncEnumerator(AsyncWrappedGrouping<TKey, TElement> owner)
            {
                _owner = owner;
            }

            public ValueTask<bool> MoveNextAsync()
            {
                if (_enumerator is null)
                    _enumerator = _owner._enumerable.GetEnumerator();

                return new ValueTask<bool>(_enumerator.MoveNext());
            }

            public TElement Current
            {
                get
                {
                    if (_enumerator is null)
                        throw new NotSupportedException(
                            $"Calling {nameof(Current)} in the current state is not supported.");

                    return _enumerator.Current;
                }
            }

            public ValueTask DisposeAsync()
            {
                _enumerator?.Dispose();
                return default;
            }
        }
    }
}
