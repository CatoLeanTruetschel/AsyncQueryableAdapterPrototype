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
using System.Linq.Expressions;
using System.Reflection;

namespace AsyncQueryableAdapter.Translators
{
    internal readonly struct ArgumentDescriptor
    {
        private readonly IList<Expression>? _arguments;
        private readonly int _index;
        private readonly ParameterInfo? _parameter;
        private readonly ParameterInfo? _methodDefinitionParameter;

        internal ArgumentDescriptor(
            IList<Expression> arguments,
            int index,
            ParameterInfo parameter,
            ParameterInfo methodDefinitionParameter)
        {
            _arguments = arguments;
            _index = index;
            _parameter = parameter;
            _methodDefinitionParameter = methodDefinitionParameter;
        }

        public Expression Argument
        {
            get
            {
                if (_arguments is null)
                {
                    throw new InvalidOperationException(); // TODO: Add not initialized message
                }

                return _arguments[_index];
            }
            set
            {
                if (_arguments is null)
                {
                    throw new InvalidOperationException(); // TODO: Add not initialized message
                }

                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _arguments[_index] = value;
            }
        }
        public ParameterInfo Parameter => _parameter
            ?? throw new InvalidOperationException(); // TODO: Add not initialized message
        public ParameterInfo MethodDefinitionParameter => _methodDefinitionParameter
            ?? throw new InvalidOperationException(); // TODO: Add not initialized message

        public static implicit operator ReadOnlyArgumentDescriptor(in ArgumentDescriptor descriptor)
        {
            if (descriptor._arguments is null)
            {
                return default;
            }

            if (descriptor._parameter is null)
            {
                return default;
            }

            if (descriptor._methodDefinitionParameter is null)
            {
                return default;
            }

            return new ReadOnlyArgumentDescriptor(
                descriptor._arguments[descriptor._index],
                descriptor._parameter,
                descriptor._methodDefinitionParameter);
        }
    }
}
