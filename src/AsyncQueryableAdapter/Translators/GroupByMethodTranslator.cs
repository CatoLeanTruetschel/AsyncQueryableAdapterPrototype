﻿// License
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
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class GroupByMethodTranslatorBuilder : IMethodTranslatorBuilder
    {
        public bool TryBuildMethodTranslator(MethodInfo method, [NotNullWhen(true)] out IMethodTranslator? result)
        {
            // TODO: Implement me pls

            result = null;
            return false;
        }
    }

    internal sealed class GroupByMethodTranslator : IMethodTranslator
    {
        public bool TryTranslate(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            [NotNullWhen(true)] out Expression? result)
        {
            // TODO: Implement me pls

            result = null;
            return false;
        }
    }
}
