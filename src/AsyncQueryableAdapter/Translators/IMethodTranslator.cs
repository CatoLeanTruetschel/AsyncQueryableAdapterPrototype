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

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Linq;

namespace AsyncQueryableAdapter.Translators
{
    /// <summary>
    /// Represents a method translator that is responsible for translating a specific subset of asynchronous LINQ 
    /// methods to their synchronous counterparts.
    /// </summary>
    public interface IMethodTranslator
    {
        /// <summary>
        /// Tries to translate a synchronous LINQ method as specified by the translation context.
        /// </summary>
        /// <param name="translationContext">The translation context that specifies the method to translate.</param>
        /// <param name="result">
        /// Contains a <see cref="ConstantExpression"/> that represents the translation result of the translation is 
        /// successful.
        /// </param>
        /// <returns>True if the method was translated successfully, false otherwise.</returns>
        /// <remarks>
        /// The <see cref="ConstantExpression"/> returned contains an instance of type <see cref="TranslatedQueryable"/>
        /// if the translated method is a chain-able method (i.e. the translated method returns 
        /// <see cref="IAsyncQueryable{T}"/> or <see cref="IOrderedAsyncQueryable{T}"/>) or a value of exactly the same 
        /// type as the return type of the translated method otherwise.
        /// See the call post-condition in <see cref="MethodProcessor.ProcessMethod(in MethodTranslationContext)"/>.
        /// </remarks>
        public abstract bool TryTranslate(
            in MethodTranslationContext translationContext,
            [NotNullWhen(true)] out ConstantExpression? result);
    }
}
