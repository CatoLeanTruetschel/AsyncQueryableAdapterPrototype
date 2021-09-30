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
using System.Linq;
using System.Linq.Expressions;
using AsyncQueryableAdapter.Utils.Expressions.Tests.TestObjects;
using Xunit;

namespace AsyncQueryableAdapter.Utils.Expressions.Tests
{
    public sealed partial class ExpressionExTests
    {
        [Fact]
        public void ForEachEnumerable()
        {
            var enumerable_counter = new EnumerableCounter(0, 10);

            var ec = Expression.Parameter(typeof(EnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");

            var hitcounter = Expression.Lambda<Action<EnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Call(ec, typeof(EnumerableCounter).GetMethod("Hit", Type.EmptyTypes))),
                ec).Compile();

            hitcounter(enumerable_counter);

            Assert.Equal(10, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
            Assert.False(enumerable_counter.DisposedIncorrectly);
        }

        [Fact]
        public void ForEachArray()
        {
            var counters = Enumerable.Range(0, 3).Select(_ => new DisposableCounter()).ToArray();

            var cs = Expression.Parameter(typeof(DisposableCounter[]), "cs");

            var c = Expression.Variable(typeof(DisposableCounter), "i");

            var hitcounter = Expression.Lambda<Action<DisposableCounter[]>>(
                ExpressionEx.ForEach(
                    c,
                    cs,
                    Expression.Call(c, typeof(DisposableCounter).GetMethod("Hit", Type.EmptyTypes))),
                cs).Compile();

            hitcounter(counters);

            foreach (var counter in counters)
                Assert.Equal(1, counter.Count);
        }

        [Fact]
        public void ForEachBreak()
        {
            var enumerable_counter = new EnumerableCounter(0, 100);

            var ec = Expression.Parameter(typeof(EnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");
            var foreachBreak = Expression.Label("foreachBreak");

            var hitcounter = Expression.Lambda<Action<EnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Block(
                        Expression.Condition(
                            Expression.LessThanOrEqual(item, Expression.Constant(10)),
                            Expression.Call(ec, typeof(EnumerableCounter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Goto(foreachBreak))),
                    foreachBreak),
                ec).Compile();

            hitcounter(enumerable_counter);

            Assert.Equal(10, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
        }

        [Fact]
        public void ForEachContinue()
        {
            var enumerable_counter = new EnumerableCounter(0, 10);

            var ec = Expression.Parameter(typeof(EnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");
            var foreachBreak = Expression.Label("foreachBreak");
            var foreachContinue = Expression.Label("foreachContinue");

            var hitcounter = Expression.Lambda<Action<EnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Block(
                        Expression.Condition(
                            Expression.Equal(Expression.Modulo(item, Expression.Constant(2)), Expression.Constant(0)),
                            Expression.Call(ec, typeof(EnumerableCounter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Goto(foreachContinue))),
                    foreachBreak,
                    foreachContinue),
                ec).Compile();

            hitcounter(enumerable_counter);

            Assert.Equal(5, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
        }

        [Fact]
        public void DuckTypedForEachEnumerable()
        {
            var enumerable_counter = new DuckTypedEnumerableCounter(0, 10);

            var ec = Expression.Parameter(typeof(DuckTypedEnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");

            var hitcounter = Expression.Lambda<Action<DuckTypedEnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Call(ec, typeof(DuckTypedEnumerableCounter).GetMethod("Hit", Type.EmptyTypes))),
                ec).Compile();

            hitcounter(enumerable_counter);

            Assert.Equal(10, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
            Assert.False(enumerable_counter.DisposedIncorrectly);
        }

        [Fact]
        public void DuckTypedForEachBreak()
        {
            var enumerable_counter = new DuckTypedEnumerableCounter(0, 100);

            var ec = Expression.Parameter(typeof(DuckTypedEnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");
            var foreachBreak = Expression.Label("foreachBreak");

            var hitcounter = Expression.Lambda<Action<DuckTypedEnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Block(
                        Expression.Condition(
                            Expression.LessThanOrEqual(item, Expression.Constant(10)),
                            Expression.Call(ec, typeof(DuckTypedEnumerableCounter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Goto(foreachBreak))),
                    foreachBreak),
                ec).Compile();

            hitcounter(enumerable_counter);

            Assert.Equal(10, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
        }

        [Fact]
        public void DuckTypedForEachContinue()
        {
            var enumerable_counter = new DuckTypedEnumerableCounter(0, 10);

            var ec = Expression.Parameter(typeof(DuckTypedEnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");
            var foreachBreak = Expression.Label("foreachBreak");
            var foreachContinue = Expression.Label("foreachContinue");

            var hitcounter = Expression.Lambda<Action<DuckTypedEnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Block(
                        Expression.Condition(
                            Expression.Equal(Expression.Modulo(item, Expression.Constant(2)), Expression.Constant(0)),
                            Expression.Call(ec, typeof(DuckTypedEnumerableCounter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Goto(foreachContinue))),
                    foreachBreak,
                    foreachContinue),
                ec).Compile();

            hitcounter(enumerable_counter);

            Assert.Equal(5, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
        }

        [Fact]
        public void StructForEachEnumerable()
        {
            var enumerable_counter = new StructEnumerableCounter(0, 10);

            var ec = Expression.Parameter(typeof(StructEnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");

            var hitcounter = Expression.Lambda<Action<StructEnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Call(ec, typeof(StructEnumerableCounter).GetMethod("Hit", Type.EmptyTypes))),
                ec).Compile();

            hitcounter(enumerable_counter);

            Assert.Equal(10, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
            Assert.False(enumerable_counter.DisposedIncorrectly);
        }

        [Fact]
        public void StructForEachBreak()
        {
            var enumerable_counter = new StructEnumerableCounter(0, 100);

            var ec = Expression.Parameter(typeof(StructEnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");
            var foreachBreak = Expression.Label("foreachBreak");

            var hitcounter = Expression.Lambda<Action<StructEnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Block(
                        Expression.Condition(
                            Expression.LessThanOrEqual(item, Expression.Constant(10)),
                            Expression.Call(ec, typeof(StructEnumerableCounter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Goto(foreachBreak))),
                    foreachBreak),
                ec).Compile();

            hitcounter(enumerable_counter);

            Assert.Equal(10, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
        }

        [Fact]
        public void StructForEachContinue()
        {
            var enumerable_counter = new StructEnumerableCounter(0, 10);

            var ec = Expression.Parameter(typeof(StructEnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");
            var foreachBreak = Expression.Label("foreachBreak");
            var foreachContinue = Expression.Label("foreachContinue");

            var hitcounter = Expression.Lambda<Action<StructEnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Block(
                        Expression.Condition(
                            Expression.Equal(Expression.Modulo(item, Expression.Constant(2)), Expression.Constant(0)),
                            Expression.Call(ec, typeof(StructEnumerableCounter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Goto(foreachContinue))),
                    foreachBreak,
                    foreachContinue),
                ec).Compile();

            hitcounter(enumerable_counter);

            Assert.Equal(5, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
        }

        class TestException : Exception
        {
        }

        [Fact]
        public void ForEachException()
        {
            var enumerable_counter = new EnumerableCounter(0, 100);

            var ec = Expression.Parameter(typeof(EnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");

            var hitcounter = Expression.Lambda<Action<EnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Block(
                        Expression.Condition(
                            Expression.LessThanOrEqual(item, Expression.Constant(10)),
                            Expression.Call(ec, typeof(EnumerableCounter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Throw(Expression.New(typeof(TestException)))))),
                ec).Compile();

            Assert.Throws<TestException>(() =>
            {
                hitcounter(enumerable_counter);
            });

            Assert.Equal(10, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
        }

        [Fact]
        public void ForEachNonGeneric()
        {
            var enumerable_counter = new NonGenericEnumerableCounter(0, 10);

            var ec = Expression.Parameter(typeof(NonGenericEnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");

            var hitcounter = Expression.Lambda<Action<NonGenericEnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Call(ec, typeof(NonGenericEnumerableCounter).GetMethod("Hit", Type.EmptyTypes))),
                ec).Compile();

            hitcounter(enumerable_counter);

            Assert.Equal(10, enumerable_counter.Count);
        }

        [Fact]
        public void ForEachStructEnumeratorImplicitMembers()
        {
            var counters = new[] { new DisposableCounter(), new DisposableCounter(), new DisposableCounter() };
            var enumerable_counter = new StructEnumerableCounterImplicitMembers(counters);

            var ec = Expression.Parameter(typeof(StructEnumerableCounterImplicitMembers), "ec");
            var item = Expression.Variable(typeof(DisposableCounter), "c");

            var hitcounter = Expression.Lambda<Action<StructEnumerableCounterImplicitMembers>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Call(item, "Hit", Type.EmptyTypes)),
                ec).Compile();

            hitcounter(enumerable_counter);

            foreach (var counter in counters)
            {
                Assert.Equal(1, counter.Count);
                Assert.True(counter.Disposed);
            }
        }

        [Fact]
        public void ForEachNonGenericStructEnumerator()
        {
            var counters = new[] { new DisposableCounter(), new DisposableCounter(), new DisposableCounter() };
            var enumerable_counter = new NonGenericStructEnumerableCounter(counters);

            var ec = Expression.Parameter(typeof(NonGenericStructEnumerableCounter), "ec");
            var item = Expression.Variable(typeof(DisposableCounter), "c");

            var hitcounter = Expression.Lambda<Action<NonGenericStructEnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Call(item, "Hit", Type.EmptyTypes)),
                ec).Compile();

            hitcounter(enumerable_counter);

            foreach (var counter in counters)
            {
                Assert.Equal(1, counter.Count);
                Assert.False(counter.Disposed);
            }
        }

        [Fact]
        public void DuckTypedForEachException()
        {
            var enumerable_counter = new DuckTypedEnumerableCounter(0, 100);

            var ec = Expression.Parameter(typeof(DuckTypedEnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");

            var hitcounter = Expression.Lambda<Action<DuckTypedEnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Block(
                        Expression.Condition(
                            Expression.LessThanOrEqual(item, Expression.Constant(10)),
                            Expression.Call(ec, typeof(DuckTypedEnumerableCounter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Throw(Expression.New(typeof(TestException)))))),
                ec).Compile();

            Assert.Throws<TestException>(() =>
            {
                hitcounter(enumerable_counter);
            });

            Assert.Equal(10, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
        }

        [Fact]
        public void StructForEachException()
        {
            var enumerable_counter = new StructEnumerableCounter(0, 100);

            var ec = Expression.Parameter(typeof(StructEnumerableCounter), "ec");

            var item = Expression.Variable(typeof(int), "i");

            var hitcounter = Expression.Lambda<Action<StructEnumerableCounter>>(
                ExpressionEx.ForEach(
                    item,
                    ec,
                    Expression.Block(
                        Expression.Condition(
                            Expression.LessThanOrEqual(item, Expression.Constant(10)),
                            Expression.Call(ec, typeof(StructEnumerableCounter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Throw(Expression.New(typeof(TestException)))))),
                ec).Compile();

            Assert.Throws<TestException>(() =>
            {
                hitcounter(enumerable_counter);
            });

            Assert.Equal(10, enumerable_counter.Count);
            Assert.True(enumerable_counter.Disposed);
        }
    }
}
