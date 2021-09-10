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
using System.Linq.Expressions;
using System.Reflection;

namespace AsyncQueryableAdapter.Translators
{
    internal readonly struct ReadOnlyArgumentDescriptor
    {
        private readonly Expression? _argument;
        private readonly ParameterInfo? _parameter;
        private readonly ParameterInfo? _methodDefinitionParameter;

        public ReadOnlyArgumentDescriptor(
            Expression argument,
            ParameterInfo parameter,
            ParameterInfo methodDefinitionParameter)
        {
            _argument = argument;
            _parameter = parameter;
            _methodDefinitionParameter = methodDefinitionParameter;
        }

        public Expression Argument => _argument
            ?? throw new InvalidOperationException(); // TODO: Add not initialized message
        public ParameterInfo Parameter => _parameter
            ?? throw new InvalidOperationException(); // TODO: Add not initialized message
        public ParameterInfo MethodDefinitionParameter => _methodDefinitionParameter
            ?? throw new InvalidOperationException(); // TODO: Add not initialized message
    }
}
