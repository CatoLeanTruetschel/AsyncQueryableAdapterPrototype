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
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncQueryableAdapter
{
    internal sealed class AsyncQueryableResultEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly ValueTask<IAsyncEnumerable<T>> _enumerableTask;
        private readonly CancellationToken _cancellation;

#pragma warning disable CA2213, IDE0079
        private IAsyncEnumerator<T>? _enumerator;
#pragma warning restore CA2213, IDE0079
        private bool _isDisposed;

        public AsyncQueryableResultEnumerator(ValueTask<IAsyncEnumerable<T>> enumerableTask, CancellationToken cancellation)
        {
            _enumerableTask = enumerableTask;
            _cancellation = cancellation;
        }

        public ValueTask<bool> MoveNextAsync()
        {
            // Do not allocate a state machine box, if not necessary.
            // This ensures, we are initialized AND NOT disposed.
            if (_enumerator is not null)
            {
                return _enumerator.MoveNextAsync();
            }

            // We are disposed
            ThrowIfDisposed();

            // We are not initialized

            return MoveNextCoreAsync();
        }

        private async ValueTask<bool> MoveNextCoreAsync()
        {
            // We MUST NOT await the value task '_enumerableTask' multiple time, as this is not guaranteed
            // to succeed for the ValueTask type. Also this would break the enumeration, as this will reset
            // the enumerator, although it shouldn't have been reset.
            Debug.Assert(_enumerator is null);
            var enumerable = await _enumerableTask.ConfigureAwait(false);
            _enumerator = enumerable.GetAsyncEnumerator(_cancellation);

            return await _enumerator.MoveNextAsync().ConfigureAwait(false);
        }

        public T Current
        {
            get
            {
                // We are either not initialized or disposed.
                if (_enumerator is null)
                {
                    ThrowIfDisposed();

                    throw new InvalidOperationException(
                        $"Cannot access the {nameof(Current)} property in the current state.");
                }

                return _enumerator.Current;
            }
        }

        public ValueTask DisposeAsync()
        {
            if (_isDisposed)
                return default;

            _isDisposed = true;

            // Setting the numerator to null saves as a null check in the Current property and in the 
            // MoveNextAsync method. 
            // We only check for enumerator not being null, and can skip the disposed check on the hot path.
            var enumerator = Interlocked.Exchange(ref _enumerator, null);

            return enumerator is not null ? enumerator.DisposeAsync() : default;
        }

        private void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }
}
