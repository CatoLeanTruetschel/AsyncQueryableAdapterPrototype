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
using System.Linq;
using System.Linq.Expressions;

namespace AsyncQueryableAdapter.Utils
{
    internal partial class ExpressionEqualityComparer
    {
        internal sealed class ParameterDictionary : IReadOnlyDictionary<ParameterExpression, ParameterExpression>
        {
            private readonly ParameterDictionary? _parent;
            private readonly Dictionary<ParameterExpression, ParameterExpression> _entries;

            public ParameterDictionary(
                ParameterDictionary? parent,
                IEnumerable<KeyValuePair<ParameterExpression, ParameterExpression>> values)
            {
                if (values is null)
                    throw new ArgumentNullException(nameof(values));

                if (values.Any(p => p.Value is null))
                {
                    // TODO: Is this the correct exception?
                    //       The pair is never null, as it is a struct, but the value of the pair can be.
                    ThrowHelper.ThrowCollectionMustNotContainNullEntries(nameof(values));
                }

                _parent = parent;

#if SUPPORTS_DICTIONARY_INITIALIZATION_FROM_ENUMERABLE
                _entries = new Dictionary<ParameterExpression, ParameterExpression>(values);
#else
            if (values is IDictionary<ParameterExpression, ParameterExpression> valuesDic)
            {
                _entries = new Dictionary<ParameterExpression, ParameterExpression>(valuesDic);
            }
            else
            {
                _entries = new();

                foreach (var (key, value) in values)
                {
                    _entries.Add(key, value);
                }
            }
#endif
            }

            public ParameterDictionary(ParameterDictionary? parent)
            {
                _parent = parent;
                _entries = new();
            }

            public ParameterDictionary()
            {
                _entries = new();
            }

            public bool TryAdd(ParameterExpression key, ParameterExpression value)
            {
                if (key is null)
                    throw new ArgumentNullException(nameof(key));

                if (value is null)
                    throw new ArgumentNullException(nameof(value));

                return _entries.TryAdd(key, value);
            }

            public void Add(ParameterExpression key, ParameterExpression value)
            {
                if (!TryAdd(key, value))
                {
                    throw new ArgumentException("An entry with the specified key already exists.");
                }
            }

            public bool ContainsKey(ParameterExpression key)
            {
                if (_entries.ContainsKey(key))
                {
                    return true;
                }

                return _parent is not null && _parent.ContainsKey(key);
            }

#if NETSTD21
#pragma warning disable CS8767
#endif
            public bool TryGetValue(ParameterExpression key, [NotNullWhen(true)] out ParameterExpression? value)
#if NETSTD21
#pragma warning restore CS8767
#endif
            {
                if (key is null)
                    throw new ArgumentNullException(nameof(key));

                if (_entries.TryGetValue(key, out value))
                {
                    return true;
                }

                if (_parent is null)
                {
                    value = null;
                    return false;
                }

                return _parent.TryGetValue(key, out value);
            }

            public ParameterExpression this[ParameterExpression key]
            {
                get
                {
                    if (key is null)
                        throw new ArgumentNullException(nameof(key));

                    if (TryGetValue(key, out var value))
                    {
                        return value;
                    }

                    throw new KeyNotFoundException("An entry with the specified key was not found.");
                }
                set
                {
                    if (key is null)
                        throw new ArgumentNullException(nameof(key));

                    if (value is null)
                        throw new ArgumentNullException(nameof(value));

                    _entries[key] = value;
                }
            }

            private void RecordKeys(ISet<ParameterExpression> keys)
            {
                keys.UnionWith(_entries.Keys);

                if (_parent is not null)
                {
                    _parent.RecordKeys(keys);
                }
            }

            private void RecordValues(ISet<ParameterExpression> keys)
            {
                keys.UnionWith(_entries.Values);

                if (_parent is not null)
                {
                    _parent.RecordValues(keys);
                }
            }

            private void RecordEntries(IDictionary<ParameterExpression, ParameterExpression> entries)
            {
                foreach (var (key, value) in _entries)
                {
                    entries.Add(key, value);
                }

                if (_parent is not null)
                {
                    _parent.RecordEntries(entries);
                }
            }

            public IEnumerable<ParameterExpression> Keys
            {
                get
                {
                    var set = new HashSet<ParameterExpression>();
                    RecordKeys(set);

                    return set;
                }
            }

            public IEnumerable<ParameterExpression> Values
            {
                get
                {
                    var set = new HashSet<ParameterExpression>();
                    RecordValues(set);

                    return set;
                }
            }

            public int Count => _entries.Count + (_parent?.Count ?? 0);

            public IEnumerator<KeyValuePair<ParameterExpression, ParameterExpression>> GetEnumerator()
            {
                var entries = new Dictionary<ParameterExpression, ParameterExpression>();
                RecordEntries(entries);
                return entries.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
