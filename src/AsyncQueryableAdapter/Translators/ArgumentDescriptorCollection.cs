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
using System.Linq.Expressions;
using System.Reflection;

namespace AsyncQueryableAdapter.Translators
{
    internal readonly struct ArgumentDescriptorCollection : IReadOnlyList<ArgumentDescriptor>
    {
        private readonly IList<Expression>? _arguments;
        private readonly ReadOnlyMemory<ParameterInfo> _parameters;
        private readonly ReadOnlyMemory<ParameterInfo> _methodDefinitionParameters;

        public ArgumentDescriptorCollection(
            IList<Expression> arguments,
            ReadOnlyMemory<ParameterInfo> parameters,
            ReadOnlyMemory<ParameterInfo> methodDefinitionParameters)
        {
            if (arguments is null)
                throw new ArgumentNullException(nameof(arguments));

            if (arguments.Count != parameters.Length || arguments.Count != methodDefinitionParameters.Length)
            {
                throw new ArgumentException("The collections must have the same length.");
            }

            _arguments = arguments;
            _parameters = parameters;
            _methodDefinitionParameters = methodDefinitionParameters;
        }

        public ArgumentDescriptor this[int index]
        {
            get
            {
                if (_arguments is null || index < 0 || index >= _arguments.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return new ArgumentDescriptor(
                    _arguments,
                    index,
                    _parameters.Span[index],
                    _methodDefinitionParameters.Span[index]);
            }
        }

        public int Count => _arguments is null ? 0 : _arguments.Count;

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<ArgumentDescriptor> IEnumerable<ArgumentDescriptor>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<ArgumentDescriptor>
        {
            private readonly ArgumentDescriptorCollection _owner;
            private int _index;

            public Enumerator(in ArgumentDescriptorCollection owner)
            {
                _owner = owner;
                _index = -1;
            }

            public ArgumentDescriptor Current
            {
                get
                {
                    if (_index < 0 || _index >= _owner.Count)
                    {
                        throw new InvalidOperationException($"Cannot call {nameof(Current)} in the current state.");
                    }

                    return _owner[_index];
                }
            }

            public bool MoveNext()
            {
                _index = Math.Min(_index + 1, _owner.Count);
                return _index < _owner.Count;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
    }
}
