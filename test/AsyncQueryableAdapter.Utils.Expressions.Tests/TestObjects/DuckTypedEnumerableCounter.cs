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

// Based on
// --------------------------------------------------------------------------------------------------------------------
// Mono.Linq.Expressions
// https://github.com/jbevain/mono.linq.expressions
// (C) 2010 Novell, Inc. (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following tests:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace AsyncQueryableAdapter.Utils.Expressions.Tests.TestObjects
{
    public class DuckTypedEnumerableCounter : IEnumerable<int>, IEnumerator<int>
    {
        private readonly int _low;
        private readonly int _high;

        public int Count { get; private set; }

        public bool Disposed { get; private set; }

        public bool DisposedIncorrectly { get; private set; }

        public int Current { get; private set; }

        int IEnumerator<int>.Current => throw new Exception(); // TODO: Set flag instead

        object IEnumerator.Current => throw new Exception(); // TODO: Set flag instead

        public DuckTypedEnumerableCounter(int low, int high)
        {
            _low = low;
            _high = high;
        }

        public void Hit()
        {
            Count++;
        }

        public DuckTypedEnumerableCounter GetEnumerator()
        {
            return this;
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            throw new Exception(); // TODO: Set flag instead
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new Exception(); // TODO: Set flag instead
        }

        public bool MoveNext()
        {
            if (Current == -1)
            {
                Current = _low;
                return true;
            }

            if (Current == _high)
                return false;

            Current++;
            return true;
        }

        bool IEnumerator.MoveNext()
        {
            throw new Exception(); // TODO: Set flag instead
        }

        void IEnumerator.Reset()
        {
            Current = -1;
        }

        public void Dispose()
        {
            Disposed = true;
        }

        void IDisposable.Dispose()
        {
            DisposedIncorrectly = true;
        }

        public void DisposeIncorrectly()
        {
            DisposedIncorrectly = true;
        }
    }
}
