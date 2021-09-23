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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AsyncQueryableAdapter.Utils
{
    public sealed class CompiledDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
        where TKey : notnull
    {
        private static MethodInfo GetMethodInfo<TFunc>(Expression<TFunc> expression)
            where TFunc : Delegate
        {
            return ((MethodCallExpression)expression.Body).Method;
        }

        private static readonly MethodInfo KEY_COMPARER_GET_HASHCODE_METHOD
            = GetMethodInfo<Func<IEqualityComparer<TKey>, TKey, int>>((p, q) => p.GetHashCode(q));

        private static readonly MethodInfo KEY_COMPARER_EQUALS
            = GetMethodInfo<Func<IEqualityComparer<TKey>, TKey, TKey, bool>>((p, q, r) => p.Equals(q, r));

        private readonly IEqualityComparer<TKey>? _keyComparer;

        private readonly ImmutableArray<KeyValuePair<TKey, TValue>> _entries;
        private readonly CompiledDictionaryLookup _lookup;

#pragma warning disable CS8618, CA1000
        public static CompiledDictionary<TKey, TValue> Empty { get; } = new(null);
#pragma warning restore CS8618, CA1000

        internal CompiledDictionary(IEqualityComparer<TKey>? keyComparer)
        {
            _keyComparer = keyComparer;

            _entries = ImmutableArray<KeyValuePair<TKey, TValue>>.Empty;
            _lookup = ConstantLookupFailure;
        }

        internal CompiledDictionary(IEnumerable<KeyValuePair<TKey, TValue>> entries, IEqualityComparer<TKey>? keyComparer)
        {
            Debug.Assert(entries is not null);

            _keyComparer = keyComparer;

            _entries = entries.ToImmutableArray();
            _lookup = BuildLookup(entries, keyComparer ?? EqualityComparer<TKey>.Default);
        }

        private static Maybe<TValue> ConstantLookupFailure(TKey key)
        {
            return Maybe<TValue>.None;
        }

        private static CompiledDictionaryLookup BuildLookup(
            IEnumerable<KeyValuePair<TKey, TValue>> entries,
            IEqualityComparer<TKey> keyComparer)
        {
            var noneConstant = Expression.Constant(Maybe<TValue>.None);
            var keyParameter = Expression.Parameter(typeof(TKey), "key");
            var keyComparerConstant = Expression.Constant(keyComparer);
            var keyGetHashCodeCall = Expression.Call(
                keyComparerConstant, KEY_COMPARER_GET_HASHCODE_METHOD, keyParameter);

            var body = Expression.Switch(
                typeof(Maybe<TValue>),
                keyGetHashCodeCall,
                noneConstant,
                null,
                entries.GroupBy(p => keyComparer.GetHashCode(p.Key)).Select(p =>
                {
                    var keyHashCodeConstant = Expression.Constant(p.Key);
                    Expression switchCaseBody;

                    if (p.Count() is 1)
                    {
                        var q = p.Single();
                        var keyConstant = Expression.Constant(q.Key);
                        var valueConstant = Expression.Constant(new Maybe<TValue>(q.Value));

                        var keyEquals = Expression.Call(
                            keyComparerConstant,
                            KEY_COMPARER_EQUALS,
                            keyParameter,
                            keyConstant);

                        switchCaseBody = Expression.Condition(keyEquals, valueConstant, noneConstant);
                    }
                    else if (keyComparer == EqualityComparer<TKey>.Default)
                    {
                        switchCaseBody = Expression.Switch(
                            type: typeof(Maybe<TValue>),
                            keyParameter,
                            noneConstant,
                            null,
                            p.Select(q =>
                            {
                                var keyConstant = Expression.Constant(q.Key);
                                var valueConstant = Expression.Constant(new Maybe<TValue>(q.Value));
                                return Expression.SwitchCase(valueConstant, keyConstant);
                            }));
                    }
                    else
                    {
                        switchCaseBody = noneConstant;

                        foreach (var q in p)
                        {
                            var keyConstant = Expression.Constant(q.Key);
                            var valueConstant = Expression.Constant(new Maybe<TValue>(q.Value));

                            var keyEquals = Expression.Call(
                                keyComparerConstant,
                                KEY_COMPARER_EQUALS,
                                keyParameter,
                                keyConstant);

                            switchCaseBody = Expression.Condition(keyEquals, valueConstant, switchCaseBody);
                        }
                    }

                    return Expression.SwitchCase(switchCaseBody, keyHashCodeConstant);
                }));

            var lambda = Expression.Lambda<CompiledDictionaryLookup>(body, keyParameter);
            return lambda.Compile(preferInterpretation: false);
        }

        public bool ContainsKey(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            return TryGetValueUnchecked(key, out _);
        }
#pragma warning disable CS8767
        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
#pragma warning restore CS8767
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            return TryGetValueUnchecked(key, out value);
        }

        private bool TryGetValueUnchecked(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            var result = _lookup(key);
            return result.TryGetValue(out value);
        }

        public TValue this[TKey key]
        {
            get
            {
                if (key is null)
                    throw new ArgumentNullException(nameof(key));

                if (!TryGetValueUnchecked(key, out var value))
                {
                    throw new KeyNotFoundException($"The key { key } cannot be found.");
                }

                return value;
            }
        }

        public KeysCollection Keys => new KeysCollection(this);

        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

        public ValuesCollection Values => new ValuesCollection(this);

        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

        public int Count => _entries.Length;

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public Builder ToBuilder()
        {
            return new Builder(_entries, _keyComparer);
        }

#pragma warning disable CA1034
        public readonly struct KeysCollection : IReadOnlyCollection<TKey>, IEquatable<KeysCollection>
#pragma warning restore CA1034
        {
            private readonly CompiledDictionary<TKey, TValue>? _owner;

            internal KeysCollection(CompiledDictionary<TKey, TValue> owner)
            {
                Debug.Assert(owner is not null);
                _owner = owner;
            }

            public int Count => (_owner ?? CompiledDictionary<TKey, TValue>.Empty).Count;

            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
            {
                return GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public KeysEnumerator GetEnumerator()
            {
                return new KeysEnumerator(_owner ?? CompiledDictionary<TKey, TValue>.Empty);
            }

            public bool Equals(KeysCollection other)
            {
                return _owner == other._owner;
            }

            public override bool Equals(object? obj)
            {
                return obj is KeysCollection collection && Equals(collection);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(_owner);
            }

            public static bool operator ==(KeysCollection left, KeysCollection right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(KeysCollection left, KeysCollection right)
            {
                return !left.Equals(right);
            }
        }

        public struct KeysEnumerator : IEnumerator<TKey>
        {
            private readonly CompiledDictionary<TKey, TValue>? _owner;
            private int _index;

            internal KeysEnumerator(CompiledDictionary<TKey, TValue> owner)
            {
                Debug.Assert(owner is not null);

                _owner = owner;
                _index = -1;
            }

            public TKey Current
            {
                get
                {
                    if (_index < 0 || _owner is null || _index >= _owner.Count)
                    {
                        throw new InvalidOperationException($"Cannot access {nameof(Current)} in the current state.");
                    }

                    return _owner._entries[_index].Key;
                }
            }

            public bool MoveNext()
            {
                if (_owner is null)
                    return false;

                _index = Math.Min(_index + 1, _owner.Count);
                return _index < _owner.Count;
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }

#pragma warning disable CA1034
        public readonly struct ValuesCollection : IReadOnlyCollection<TValue>, IEquatable<ValuesCollection>
#pragma warning restore CA1034
        {
            private readonly CompiledDictionary<TKey, TValue>? _owner;

            internal ValuesCollection(CompiledDictionary<TKey, TValue> owner)
            {
                Debug.Assert(owner is not null);
                _owner = owner;
            }

            public int Count => (_owner ?? CompiledDictionary<TKey, TValue>.Empty).Count;

            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
            {
                return GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public ValuesEnumerator GetEnumerator()
            {
                return new ValuesEnumerator(_owner ?? CompiledDictionary<TKey, TValue>.Empty);
            }

            public bool Equals(ValuesCollection other)
            {
                return _owner == other._owner;
            }

            public override bool Equals(object? obj)
            {
                return obj is ValuesCollection collection && Equals(collection);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(_owner);
            }

            public static bool operator ==(ValuesCollection left, ValuesCollection right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(ValuesCollection left, ValuesCollection right)
            {
                return !left.Equals(right);
            }
        }

        public struct ValuesEnumerator : IEnumerator<TValue>
        {
            private readonly CompiledDictionary<TKey, TValue>? _owner;
            private int _index;

            internal ValuesEnumerator(CompiledDictionary<TKey, TValue> owner)
            {
                Debug.Assert(owner is not null);

                _owner = owner;
                _index = -1;
            }

            public TValue Current
            {
                get
                {
                    if (_index < 0 || _owner is null || _index >= _owner.Count)
                    {
                        throw new InvalidOperationException($"Cannot access {nameof(Current)} in the current state.");
                    }

                    return _owner._entries[_index].Value;
                }
            }

            public bool MoveNext()
            {
                if (_owner is null)
                    return false;

                _index = Math.Min(_index + 1, _owner.Count);
                return _index < _owner.Count;
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            object IEnumerator.Current => Current!;

            public void Dispose() { }
        }

        public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private readonly CompiledDictionary<TKey, TValue>? _owner;
            private int _index;

            internal Enumerator(CompiledDictionary<TKey, TValue> owner)
            {
                Debug.Assert(owner is not null);

                _owner = owner;
                _index = -1;
            }

            public KeyValuePair<TKey, TValue> Current
            {
                get
                {
                    if (_index < 0 || _owner is null || _index >= _owner.Count)
                    {
                        throw new InvalidOperationException($"Cannot access {nameof(Current)} in the current state.");
                    }

                    return _owner._entries[_index];
                }
            }

            public bool MoveNext()
            {
                if (_owner is null)
                    return false;

                _index = Math.Min(_index + 1, _owner.Count);
                return _index < _owner.Count;
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }

        internal delegate Maybe<TValue> CompiledDictionaryLookup(TKey key);

#pragma warning disable CA1710
        public sealed class Builder : IDictionary<TKey, TValue>
#pragma warning restore CA1710
        {
            private readonly Dictionary<TKey, TValue> _entries;

            internal Builder(IEqualityComparer<TKey>? keyComparer)
            {
                KeyComparer = keyComparer;
                _entries = new Dictionary<TKey, TValue>(keyComparer);
            }

            internal Builder(
                IEnumerable<KeyValuePair<TKey, TValue>> entries,
                IEqualityComparer<TKey>? keyComparer)
            {
                Debug.Assert(entries is not null);

                KeyComparer = keyComparer;

#if SUPPORTS_DICTIONARY_INITIALIZATION_FROM_ENUMERABLE
                _entries = new Dictionary<TKey, TValue>(entries, keyComparer);
#else
                if (entries is IDictionary<TKey, TValue> dictionary)
                {
                    _entries = new Dictionary<TKey, TValue>(dictionary, keyComparer);
                }
                else
                {
                    _entries = new Dictionary<TKey, TValue>(keyComparer);

                    foreach (var entry in entries)
                    {
                        _entries.Add(entry.Key, entry.Value);
                    }
                }
#endif
            }

            public IEqualityComparer<TKey>? KeyComparer { get; }

            public ICollection<TKey> Keys => _entries.Keys; // TODO: Create struct wrapper type

            public ICollection<TValue> Values => _entries.Values; // TODO: Create struct wrapper type

            public int Count => _entries.Count;

            bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

            public TValue this[TKey key]
            {
                get => _entries[key];
                set => _entries[key] = value;
            }

            public void Add(TKey key, TValue value)
            {
                _entries.Add(key, value);
            }

            public bool Remove(TKey key)
            {
                return _entries.Remove(key);
            }

            public bool ContainsKey(TKey key)
            {
                return _entries.ContainsKey(key);
            }

#pragma warning disable CS8767
            public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
#pragma warning restore CS8767
            {
                return _entries.TryGetValue(key, out value);
            }

            void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
            {
                Add(item.Key, item.Value);
            }

            public void Clear()
            {
                _entries.Clear();
            }

            bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
            {
                return ((ICollection<KeyValuePair<TKey, TValue>>)_entries).Contains(item);
            }

            void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
            {
                return ((ICollection<KeyValuePair<TKey, TValue>>)_entries).Remove(item);
            }

            IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
            {
                return GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public Enumerator GetEnumerator()
            {
                return new Enumerator(this);
            }

            public CompiledDictionary<TKey, TValue> Build()
            {
                return new CompiledDictionary<TKey, TValue>(_entries, KeyComparer);
            }

            public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>
            {
                private Dictionary<TKey, TValue>.Enumerator _enumerator;

                public Enumerator(CompiledDictionary<TKey, TValue>.Builder owner)
                {
                    Debug.Assert(owner is not null);

                    _enumerator = owner._entries.GetEnumerator();
                }

                public KeyValuePair<TKey, TValue> Current => _enumerator.Current;

                public bool MoveNext()
                {
                    return _enumerator.MoveNext();
                }

                void IEnumerator.Reset()
                {
                    throw new NotSupportedException();
                }

                object IEnumerator.Current => Current;

                public void Dispose()
                {
                    _enumerator.Dispose();
                }
            }
        }
    }

#pragma warning disable CA1711
    public static class CompiledDictionary
#pragma warning restore CA1711
    {
        public static CompiledDictionary<TKey, TValue>.Builder CreateBuilder<TKey, TValue>()
            where TKey : notnull
        {
            return new CompiledDictionary<TKey, TValue>.Builder(null);
        }

        public static CompiledDictionary<TKey, TValue>.Builder CreateBuilder<TKey, TValue>(
            IEqualityComparer<TKey>? keyComparer)
            where TKey : notnull
        {
            return new CompiledDictionary<TKey, TValue>.Builder(keyComparer);
        }

        public static CompiledDictionary<TKey, TValue> Create<TKey, TValue>()
            where TKey : notnull
        {
            return CompiledDictionary<TKey, TValue>.Empty;
        }

        public static CompiledDictionary<TKey, TValue> Create<TKey, TValue>(
            IEqualityComparer<TKey>? keyComparer)
            where TKey : notnull
        {
            if (keyComparer is null)
                return CompiledDictionary<TKey, TValue>.Empty;

            return new CompiledDictionary<TKey, TValue>(keyComparer);
        }

        public static CompiledDictionary<TKey, TValue> ToCompiledDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source)
            where TKey : notnull
        {
            return ToCompiledDictionary(source, keyComparer: null);
        }

        public static CompiledDictionary<TKey, TValue> ToCompiledDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source,
            IEqualityComparer<TKey>? keyComparer)
            where TKey : notnull
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (source is CompiledDictionary<TKey, TValue>.Builder builder
                && keyComparer == builder.KeyComparer)
            {
                return builder.Build();
            }

            return new CompiledDictionary<TKey, TValue>(source, keyComparer);
        }

        public static CompiledDictionary<TKey, TValue> ToCompiledDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector)
            where TKey : notnull
        {
            return ToCompiledDictionary(source, keySelector, elementSelector, keyComparer: null);
        }

        public static CompiledDictionary<TKey, TValue> ToCompiledDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector,
            IEqualityComparer<TKey>? keyComparer)
            where TKey : notnull
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));

            return new CompiledDictionary<TKey, TValue>(
                source.ToDictionary(keySelector, elementSelector, keyComparer),
                keyComparer);
        }

        public static CompiledDictionary<TKey, TSource> ToCompiledDictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
            where TKey : notnull
        {
            return ToCompiledDictionary(source, keySelector, keyComparer: null);
        }

        public static CompiledDictionary<TKey, TSource> ToCompiledDictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? keyComparer)
            where TKey : notnull
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            return new CompiledDictionary<TKey, TSource>(source.ToDictionary(keySelector, keyComparer), keyComparer);
        }
    }
}
