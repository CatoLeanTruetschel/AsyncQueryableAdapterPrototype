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
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace AsyncQueryableAdapter
{
    public readonly ref struct MethodTranslationArguments
    {
        private static readonly ReadOnlyCollection<Expression> _emptyArguments = new List<Expression>().AsReadOnly();
        private readonly ReadOnlyCollection<Expression>? _arguments;

        public MethodTranslationArguments(ReadOnlyCollection<Expression> arguments)
        {
            if (arguments is null)
                throw new ArgumentNullException(nameof(arguments));

            _arguments = arguments;
        }

        public ReadOnlyCollection<Expression> Arguments => _arguments ?? _emptyArguments;

        public Expression this[int index] => Arguments[index];

        public int Count => Arguments.Count;

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

#pragma warning disable CA1034
        public ref struct Enumerator
#pragma warning restore CA1034
        {
            private readonly MethodTranslationArguments _owner;
            private int _index;

            public Enumerator(MethodTranslationArguments owner)
            {
                _owner = owner;
                _index = -1;
            }

            public Expression Current
            {
                get
                {
                    if (_index <= _owner.Count)
                    {
                        throw new InvalidOperationException(); // TODO: Message
                    }

                    return _owner[_index];
                }
            }

            public bool MoveNext()
            {
                _index = Math.Min(_index + 1, _owner.Count);
                return _index < _owner.Count;
            }
        }
    }
}
