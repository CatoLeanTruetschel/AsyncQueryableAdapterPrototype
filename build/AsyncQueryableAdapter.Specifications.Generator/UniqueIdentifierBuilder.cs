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
using System.Text;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Specifications.Generator
{
    public sealed class UniqueIdentifierBuilder
    {
        private Type? _sourceType;
        private Type? _returnType;
        private readonly Dictionary<string, string?> _parameterModifiers = new(StringComparer.Ordinal);
        private readonly List<string> _modifiers = new();
        private readonly string _methodName;

        public UniqueIdentifierBuilder(string methodName)
        {
            if (methodName is null)
                throw new ArgumentNullException(nameof(methodName));

            _methodName = methodName.FirstRuneToUpperCase();
        }

        public void WithSourceType(Type sourceType)
        {
            _sourceType = sourceType;
        }

        public void Returns(Type returnType)
        {
            _returnType = returnType;
        }

        public void WithParameter(string name)
        {
            _parameterModifiers[name.FirstRuneToUpperCase()] = null;
        }

        public void WithParameter(string name, string modifier)
        {
            _parameterModifiers[name.FirstRuneToUpperCase()] = modifier;
        }

        public void WithModifier(string modifier)
        {
            _modifiers.Add(modifier.FirstRuneToUpperCase());
        }

        public UniqueIdentifier Build()
        {
            var builder = new StringBuilder(_methodName);

            if (_sourceType is not null)
            {
                var sourceType = StringifyType(_sourceType);

                if (sourceType is not null)
                {
                    builder.Append($"With{sourceType}Source");
                }
            }

            if (_returnType is not null)
            {
                var returnType = StringifyType(_returnType);

                if (returnType is not null)
                {
                    builder.Append($"With{returnType}Result");
                }
            }

            foreach (var (parameter, mod) in _parameterModifiers.OrderBy(p => p.Key))
            {
                if (mod is not null)
                {
                    builder.Append($"With{mod}{parameter}");
                }
                else
                {
                    builder.Append($"With{parameter}");
                }
            }

            foreach (var modifier in _modifiers.OrderBy(p => p))
            {
                builder.Append(modifier);
            }

            return new UniqueIdentifier(builder.ToString());
        }

        private static string? StringifyType(Type type)
        {
            if (TypeHelper.IsIntegratedNumericType(type))
            {
                return type.Name;
            }

            if (TypeHelper.IsNullableType(type, out var underlyingType))
            {
                return "Nullable" + StringifyType(underlyingType);
            }

            if (type.IsArray)
            {
                return StringifyType(type.GetElementType()!) + "Array";
            }

            // TODO
            return null;
        }
    }
}
