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
using System.Linq;
using AsyncQueryableAdapter.Translators;

namespace AsyncQueryableAdapter
{
    public sealed class AsyncQueryableOptions
    {
        public static readonly AsyncQueryableOptions Default = new();

        /// <summary>
        /// Gets or sets a boolean value indicating whether an implicit in-process post-processing step is allowed.
        /// </summary>
        /// <remarks>
        /// Setting this to <c>true</c> enables asynchronous operations on the <see cref="IAsyncQueryable"/> but
        /// may incur a high cost, as this needs to be done in an in-memory processing that needs all
        /// prior result to be transferred from the database to the main-memory. When setting this to <c>false</c>
        /// a <see cref="NotSupportedException"/> is raised, whenever an operation on the <see cref="IAsyncQueryable"/>
        /// cannot be translated to a database call.
        /// This does not prevent the execution of explicit transferal of entries in the main-memory, like
        /// executing any of the conversion methods f.e. <see cref="System.Linq.AsyncQueryable.ToListAsync"/>.
        /// </remarks>
        public bool AllowImplicitPostProcessing { get; set; } = true;

        /// <summary>
        /// Gets or sets a boolean value indicating whether an implicit in-process post-processing step for a 
        /// non-special method when a special translator is applicable is allowed.
        /// </summary>
        /// <remarks>
        /// Setting this to <c>true</c> enables asynchronous operations on the <see cref="IAsyncQueryable"/> but
        /// may incur a high cost, as this needs to be done in an in-memory processing that needs all
        /// prior result to be transferred from the database to the main-memory. When setting this to <c>false</c>
        /// a <see cref="NotSupportedException"/> is raised, whenever an operation on the <see cref="IAsyncQueryable"/>
        /// cannot be translated to a database call.
        /// This does not prevent the execution of explicit transferal of entries in the main-memory, like
        /// executing any of the conversion methods f.e. <see cref="System.Linq.AsyncQueryable.ToListAsync"/>.
        /// </remarks>
        internal bool AllowImplicitDefaultPostProcessing { get; set; } = true; // Until we find a proper use-case
                                                                               // and name for this, this is for
                                                                               // testing-purposes only.

        /// <summary>
        /// Gets or sets a boolean value indicating whether an in-memory evaluation of (parts of) the query by the 
        /// query adapter is allowed, when the query cannot be performed natively by the underlying storage system.
        /// </summary>
        /// <remarks>
        /// Settings this to <c>true</c> enables in-memory query evaluations, when this setting is set to <c>false</c>
        /// and the query adapter cannot perform a native query via the storage system, a 
        /// <see cref="NotSupportedException"/> is raised.
        /// </remarks>
        internal bool AllowInMemoryEvaluation { get; set; } = true;

        public IMethodTranslatorRegistry MethodTranslators { get; } = BuildDefaultMethodTranslatorRegistry();

        private static MethodTranslatorRegistry BuildDefaultMethodTranslatorRegistry()
        {
            var result = new MethodTranslatorRegistry
            {
                new AggregateMethodTranslatorBuilder(),
                new ContainsMethodTranslatorBuilder(),
                new ElementAtMethodTranslatorBuilder(),
                new GroupByMethodTranslatorBuilder(),
                new MinMethodTranslatorBuilder(),
                new MaxMethodTranslatorBuilder(),
                new SumMethodTranslatorBuilder(),
                new AverageMethodTranslatorBuilder(),
                new AnyMethodTranslatorBuilder(),
                new AllMethodTranslatorBuilder(),
                new CountMethodTranslatorBuilder(),
                new LongCountMethodTranslatorBuilder(),
                new SequenceEqualMethodTranslatorBuilder(),
                new FirstMethodTranslatorBuilder(),
                new LastMethodTranslatorBuilder(),
                new SingleMethodTranslatorBuilder(),
                new DefaultMethodTranslatorBuilder()
            };
            return result;
        }
    }
}
