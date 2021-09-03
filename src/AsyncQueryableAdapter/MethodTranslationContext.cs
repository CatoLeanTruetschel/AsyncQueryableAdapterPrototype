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
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace AsyncQueryableAdapter
{
    public readonly ref struct MethodTranslationContext
    {
        private static readonly ReadOnlyCollection<Expression> _emptyArguments = new(Array.Empty<Expression>());
        private static readonly MethodInfo _noMethod = new Action(Nop).Method;

        private readonly ReadOnlyCollection<Expression>? _arguments;

        private static void Nop() { }

        private readonly MethodInfo? _method;

        public MethodTranslationContext(
            Expression? instance,
            MethodInfo method,
            ReadOnlyCollection<Expression> arguments)
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));

            Instance = instance;
            _method = method;
            _arguments = arguments;
        }

        public MethodTranslationContext(MethodInfo method, ReadOnlyCollection<Expression> arguments)
            : this(null, method, arguments)
        { }

        public Expression? Instance { get; }

        public MethodInfo Method => _method ?? _noMethod;

        public ReadOnlyCollection<Expression> Arguments => _arguments ?? _emptyArguments;
    }
}
