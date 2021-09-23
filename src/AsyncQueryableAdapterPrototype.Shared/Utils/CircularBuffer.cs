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
using System.Diagnostics.CodeAnalysis;

namespace AsyncQueryableAdapterPrototype.Utils
{
    internal sealed class CircularBuffer<T> : IReadOnlyList<T>
    {
        private readonly Memory<T?> _buffer;
        private int _enqueueIdx;
        private int _stateToken;

        public CircularBuffer(Memory<T?> buffer)
        {
            _buffer = buffer;
        }

        public CircularBuffer(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            _buffer = new T[capacity];
        }

        public int Capacity => _buffer.Length;

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                var bufferIndex = _enqueueIdx - Count + index;

                if (bufferIndex < 0)
                {
                    bufferIndex += Capacity;
                }

                return _buffer.Span[bufferIndex]!;
            }
        }

        public bool TryEnqueue(T item)
        {
            if (Count == Capacity)
                return false;

            _buffer.Span[_enqueueIdx] = item;
            Count++;
            _enqueueIdx++;

            if (_enqueueIdx > Capacity)
            {
                _enqueueIdx -= Capacity;
            }

            unchecked
            {
                _stateToken++;
            }

            return true;
        }

        public void Enqueue(T item)
        {
            if (!TryEnqueue(item))
            {
                throw new InvalidOperationException("The buffer is full.");
            }
        }

        public bool TryDequeue([NotNullWhen(true)] out T? item)
        {
            item = default;

            if (Count == 0)
                return false;

            var dequeueIdx = _enqueueIdx - Count;

            if (dequeueIdx < 0)
            {
                dequeueIdx += Capacity;
            }

            item = _buffer.Span[dequeueIdx]!;
            _buffer.Span[dequeueIdx] = default; // Clear this, so it can be collected, if necessary!
            Count--;

            unchecked
            {
                _stateToken++;
            }

            return true;
        }

        public T Dequeue()
        {
            if (!TryDequeue(out var result))
            {
                throw new InvalidOperationException("The buffer is empty.");
            }

            return result;
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            private readonly CircularBuffer<T>? _owner;
            private readonly int _stateToken;
            private int _index;

            public Enumerator(CircularBuffer<T> owner)
            {
                if (owner is null)
                    throw new ArgumentNullException(nameof(owner));

                _stateToken = owner._stateToken;
                _owner = owner;
                _index = -1;
            }

            public T Current
            {
                get
                {
                    if (_owner is null || _index < 0 || _index >= _owner.Count)
                    {
                        throw new InvalidOperationException(
                            $"Accessing {nameof(Current)} is not allowed in the current state.");
                    }

                    if (_owner._stateToken != _stateToken)
                    {
                        throw new InvalidOperationException(
                            "Modification of the collection are not supported while enumerating it.");
                    }

                    return _owner[_index];
                }
            }

            public bool MoveNext()
            {
                if (_owner is null)
                {
                    return false;
                }

                if (_owner._stateToken != _stateToken)
                {
                    throw new InvalidOperationException(
                        "Modification of the collection are not supported while enumerating it.");
                }

                _index = Math.Min(_index + 1, _owner.Count);
                return _index < _owner.Count;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            object? IEnumerator.Current => Current;

            public void Dispose() { }
        }
    }
}
