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

namespace AsyncQueryableAdapter.Translators
{
    internal readonly ref struct GenericArgumentsDescriptor
    {
        public GenericArgumentsDescriptor(
            Span<Type> genericArguments,
            Span<TranslatedGenericArgument> translatedGenericArguments,
            ReadOnlySpan<Type> methodDefinitionGenericArguments)
        {
            GenericArguments = genericArguments;
            TranslatedGenericArguments = translatedGenericArguments;
            MethodDefinitionGenericArguments = methodDefinitionGenericArguments;
        }

        public Span<Type> GenericArguments { get; }

        public Span<TranslatedGenericArgument> TranslatedGenericArguments { get; }

        public ReadOnlySpan<Type> MethodDefinitionGenericArguments { get; }

        public static implicit operator ReadOnlyGenericArgumentsDescriptor(
            in GenericArgumentsDescriptor descriptor)
        {
            return new ReadOnlyGenericArgumentsDescriptor(
                descriptor.GenericArguments,
                descriptor.TranslatedGenericArguments,
                descriptor.MethodDefinitionGenericArguments);
        }
    }
}
