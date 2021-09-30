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

namespace AsyncQueryableAdapter.Utils.Expressions.Tests.TestObjects
{
#if ENABLE_EXPRESSION_DISPOSE_BY_EXTENSION
    public readonly struct RefInExtensionDisposable
    {
        internal UnderylingDisposable UnderlyingDisposable { get; } = new();

        public bool Disposed => UnderlyingDisposable.Disposed;

        public bool RefInDisposed => UnderlyingDisposable.RefInDisposed;

        public bool Touched => UnderlyingDisposable.Touched;

        public void Touch()
        {
            UnderlyingDisposable.Touch();
        }
    }

    public static class RefInExtensionDisposableExtension
    {
        public static void Dispose(in this RefInExtensionDisposable obj)
        {
            obj.UnderlyingDisposable.RefInDispose();
        }
    }
#endif
}
