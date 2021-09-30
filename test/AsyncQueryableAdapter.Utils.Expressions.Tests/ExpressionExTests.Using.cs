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
using System.Linq.Expressions;
using AsyncQueryableAdapter.Utils.Expressions.Tests.TestObjects;
using Xunit;

namespace AsyncQueryableAdapter.Utils.Expressions.Tests
{
    public sealed partial class ExpressionExTests
    {
        [Fact]
        public void Using()
        {
            var disposable = new Disposable();

            var d = Expression.Parameter(typeof(Disposable), "d");

            var disposer = Expression.Lambda<Action<Disposable>>(
                ExpressionEx.Using(
                    d,
                    Expression.Block(
                        Expression.Call(d, typeof(Disposable).GetMethod("Touch")))),
                d).Compile();

            Assert.False(disposable.Touched);
            Assert.False(disposable.Disposed);

            disposer(disposable);

            Assert.True(disposable.Touched);
            Assert.True(disposable.Disposed);
        }

        [Fact]
        public void DuckTypedUsing()
        {
            var disposable = new DuckTypedDisposable();

            var d = Expression.Parameter(typeof(DuckTypedDisposable), "d");

            var disposer = Expression.Lambda<Action<DuckTypedDisposable>>(
                ExpressionEx.Using(
                    d,
                    Expression.Block(
                        Expression.Call(d, typeof(DuckTypedDisposable).GetMethod("Touch")))),
                d).Compile();

            Assert.False(disposable.Touched);
            Assert.False(disposable.Disposed);

            disposer(disposable);

            Assert.True(disposable.Touched);
            Assert.True(disposable.Disposed);
        }

#if ENABLE_EXPRESSION_DISPOSE_BY_EXTENSION

        [Fact]
        public void ExtensionUsing()
        {
            var disposable = new ExtensionDisposable();

            var d = Expression.Parameter(typeof(ExtensionDisposable), "d");

            var disposer = Expression.Lambda<Action<ExtensionDisposable>>(
                ExpressionEx.Using(
                    d,
                    Expression.Block(
                        Expression.Call(d, typeof(ExtensionDisposable).GetMethod("Touch")))),
                d).Compile();

            Assert.False(disposable.Touched);
            Assert.False(disposable.Disposed);

            disposer(disposable);

            Assert.False(disposable.RefInDisposed);
            Assert.True(disposable.Touched);
            Assert.True(disposable.Disposed);
        }

        [Fact]
        public void RefInExtensionUsing()
        {
            var disposable = new RefInExtensionDisposable();

            var d = Expression.Parameter(typeof(RefInExtensionDisposable), "d");

            var disposer = Expression.Lambda<Action<RefInExtensionDisposable>>(
                ExpressionEx.Using(
                    d,
                    Expression.Block(
                        Expression.Call(d, typeof(RefInExtensionDisposable).GetMethod("Touch")))),
                d).Compile();

            Assert.False(disposable.Touched);
            Assert.False(disposable.Disposed);

            disposer(disposable);

            Assert.True(disposable.RefInDisposed);
            Assert.True(disposable.Touched);
            Assert.False(disposable.Disposed);
        }

#endif

        class TestUsingException : Exception
        {
        }

        [Fact]
        public void UsingException()
        {
            var disposable = new Disposable();

            var d = Expression.Parameter(typeof(Disposable), "d");

            var disposer = Expression.Lambda<Action<Disposable>>(
                ExpressionEx.Using(
                    d,
                    Expression.Block(
                        Expression.Throw(Expression.New(typeof(TestUsingException))),
                        Expression.Call(d, typeof(Disposable).GetMethod("Touch")))),
                d).Compile();

            Assert.False(disposable.Touched);
            Assert.False(disposable.Disposed);

            Assert.Throws<TestUsingException>(() =>
            {
                disposer(disposable);
            });

            Assert.False(disposable.Touched);
            Assert.True(disposable.Disposed);
        }

        [Fact]
        public void DuckTypedUsingException()
        {
            var disposable = new DuckTypedDisposable();

            var d = Expression.Parameter(typeof(DuckTypedDisposable), "d");

            var disposer = Expression.Lambda<Action<DuckTypedDisposable>>(
                ExpressionEx.Using(
                    d,
                    Expression.Block(
                        Expression.Throw(Expression.New(typeof(TestUsingException))),
                        Expression.Call(d, typeof(DuckTypedDisposable).GetMethod("Touch")))),
                d).Compile();

            Assert.False(disposable.Touched);
            Assert.False(disposable.Disposed);

            Assert.Throws<TestUsingException>(() =>
            {
                disposer(disposable);
            });

            Assert.False(disposable.Touched);
            Assert.True(disposable.Disposed);
        }

#if ENABLE_EXPRESSION_DISPOSE_BY_EXTENSION

        [Fact]
        public void ExtensionUsingException()
        {
            var disposable = new ExtensionDisposable();

            var d = Expression.Parameter(typeof(ExtensionDisposable), "d");

            var disposer = Expression.Lambda<Action<ExtensionDisposable>>(
                ExpressionEx.Using(
                    d,
                    Expression.Block(
                        Expression.Throw(Expression.New(typeof(TestUsingException))),
                        Expression.Call(d, typeof(ExtensionDisposable).GetMethod("Touch")))),
                d).Compile();

            Assert.False(disposable.Touched);
            Assert.False(disposable.Disposed);

            Assert.Throws<TestUsingException>(() =>
            {
                disposer(disposable);
            });

            Assert.False(disposable.RefInDisposed);
            Assert.False(disposable.Touched);
            Assert.True(disposable.Disposed);
        }

        [Fact]
        public void RefInExtensionUsingException()
        {
            var disposable = new RefInExtensionDisposable();

            var d = Expression.Parameter(typeof(RefInExtensionDisposable), "d");

            var disposer = Expression.Lambda<Action<RefInExtensionDisposable>>(
                ExpressionEx.Using(
                    d,
                    Expression.Block(
                        Expression.Throw(Expression.New(typeof(TestUsingException))),
                        Expression.Call(d, typeof(RefInExtensionDisposable).GetMethod("Touch")))),
                d).Compile();

            Assert.False(disposable.Touched);
            Assert.False(disposable.Disposed);

            Assert.Throws<TestUsingException>(() =>
            {
                disposer(disposable);
            });

            Assert.True(disposable.RefInDisposed);
            Assert.False(disposable.Touched);
            Assert.False(disposable.Disposed);
        }

#endif
    }
}
