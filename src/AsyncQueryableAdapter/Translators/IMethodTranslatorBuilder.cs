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
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace AsyncQueryableAdapter.Translators
{
    /// <summary>
    /// Represents a builder that can be used to construct <see cref="IMethodTranslator"/>s for a specific subset of
    /// asynchronous LINQ methods.
    /// </summary>
    public interface IMethodTranslatorBuilder
    {
        /// <summary>
        /// Tries to create a <see cref="IMethodTranslator"/> instance for the specified method.
        /// </summary>
        /// <param name="method">The <see cref="MethodInfo"/> that a method translator is requested for.</param>
        /// <param name="result">
        /// Contains the constructed <see cref="IMethodTranslator"/> if the operation is successful.
        /// </param>
        /// <returns>
        /// True if the a method translator for <paramref name="method"/> was constructed successfully, false otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="method"/> is <c>null</c>.</exception>
        bool TryBuildMethodTranslator(
            MethodInfo method,
            [NotNullWhen(true)] out IMethodTranslator? result);
    }
}
