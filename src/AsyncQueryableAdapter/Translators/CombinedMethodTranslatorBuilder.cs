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
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class CombinedMethodTranslatorBuilder : IMethodTranslatorBuilder
    {
        private readonly ConditionalWeakTable<MethodInfo, IMethodTranslator?> _cache = new();
        private readonly ConditionalWeakTable<MethodInfo, IMethodTranslator?>.CreateValueCallback _buildMethodTranslator;

        private readonly ImmutableArray<IMethodTranslatorBuilder> _builders;

        public CombinedMethodTranslatorBuilder(IEnumerable<IMethodTranslatorBuilder> builders)
        {
            if (builders is null)
                throw new ArgumentNullException(nameof(builders));

            if (builders.Any(p => p is null))
                throw new ArgumentException("The collection must not contain null entries.", nameof(builders));

            _builders = builders.ToImmutableArray();
            _buildMethodTranslator = BuildMethodTranslator;
        }

        public bool TryBuildMethodTranslator(MethodInfo method, [NotNullWhen(true)] out IMethodTranslator? result)
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));

            if (method.IsGenericMethod)
            {
                method = method.GetGenericMethodDefinition();
            }

            result = _cache.GetValue(method, _buildMethodTranslator);
            return result is not null;
        }

        private IMethodTranslator? BuildMethodTranslator(MethodInfo method)
        {
            foreach (var builder in _builders)
            {
                if (builder.TryBuildMethodTranslator(method, out var translator))
                {
                    return translator;
                }
            }

            return null;
        }
    }
}
