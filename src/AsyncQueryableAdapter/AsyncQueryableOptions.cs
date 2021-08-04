/* License
 * --------------------------------------------------------------------------------------------------------------------
 * (C) Copyright 2021 Cato Léan Trütschel and contributors 
 * (https://github.com/CatoLeanTruetschel/AsyncQueryableAdapterPrototype)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * --------------------------------------------------------------------------------------------------------------------
 */

using System;
using System.Linq;

namespace AsyncQueryableAdapter
{
    public readonly struct AsyncQueryableOptions : IEquatable<AsyncQueryableOptions>
    {
        public static AsyncQueryableOptions Default => default;

        private readonly bool _disallowImplicitPostProcessing;
        private readonly bool _disallowImplicitDefaultPostProcessing;
        private readonly bool _disallowInMemoryProcessing;

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
        public bool AllowImplicitPostProcessing
        {
            get => !_disallowImplicitPostProcessing;
            init
            {
                _disallowImplicitPostProcessing = !value;
            }
        }

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
        internal bool AllowImplicitDefaultPostProcessing // Until we find a proper use-case and name for this, this is for testing-purposes only.
        {
            get => !_disallowImplicitDefaultPostProcessing;
            init
            {
                _disallowImplicitDefaultPostProcessing = !value;
            }
        }

        /// <summary>
        /// Gets or sets a boolean value indicating whether an in-memory evaluation of (parts of) the query by the 
        /// query adapter is allowed, when the query cannot be performed natively by the underlying storage system.
        /// </summary>
        /// <remarks>
        /// Settings this to <c>true</c> enables in-memory query evaluations, when this setting is set to <c>false</c>
        /// and the query adapter cannot perform a native query via the storage system, a 
        /// <see cref="NotSupportedException"/> is raised.
        /// </remarks>
        internal bool AllowInMemoryEvaluation
        {
            get => !_disallowInMemoryProcessing;
            init
            {
                _disallowInMemoryProcessing = !value;
            }
        }

        [CLSCompliant(false)]
        public bool Equals(in AsyncQueryableOptions other)
        {
            return _disallowImplicitPostProcessing == other._disallowImplicitPostProcessing;
        }

        bool IEquatable<AsyncQueryableOptions>.Equals(AsyncQueryableOptions other)
        {
            return Equals(in other);
        }

        public override bool Equals(object? obj)
        {
            return obj is AsyncQueryableOptions options && Equals(options);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_disallowImplicitPostProcessing);
        }

        public static bool operator ==(in AsyncQueryableOptions left, in AsyncQueryableOptions right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(in AsyncQueryableOptions left, in AsyncQueryableOptions right)
        {
            return !left.Equals(right);
        }
    }
}
