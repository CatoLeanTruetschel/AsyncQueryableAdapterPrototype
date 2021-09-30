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
        public void For()
        {
            var counter = new Counter();

            var c = Expression.Parameter(typeof(Counter), "c");
            var l = Expression.Parameter(typeof(int), "l");

            var i = Expression.Variable(typeof(int), "i");

            var hitcounter = Expression.Lambda<Action<Counter, int>>(
                ExpressionEx.For(
                    i,
                    Expression.Constant(0),
                    Expression.LessThan(i, l),
                    Expression.PreIncrementAssign(i),
                    Expression.Call(c, typeof(Counter).GetMethod("Hit", Type.EmptyTypes))),
                c, l).Compile();

            hitcounter(counter, 10);

            Assert.Equal(10, counter.Count);
        }

        [Fact]
        public void Never()
        {
            var counter = new Counter();

            var c = Expression.Parameter(typeof(Counter), "c");
            var l = Expression.Parameter(typeof(int), "l");

            var i = Expression.Variable(typeof(int), "i");

            var hitcounter = Expression.Lambda<Action<Counter, int>>(
                ExpressionEx.For(
                    i,
                    Expression.Constant(0),
                    Expression.LessThan(i, l),
                    Expression.PreIncrementAssign(i),
                    Expression.Call(c, typeof(Counter).GetMethod("Hit", Type.EmptyTypes))),
                c, l).Compile();

            hitcounter(counter, 0);

            Assert.Equal(0, counter.Count);
        }

        [Fact]
        public void ForBreak()
        {
            var counter = new Counter();

            var c = Expression.Parameter(typeof(Counter), "c");
            var l = Expression.Parameter(typeof(int), "l");

            var i = Expression.Variable(typeof(int), "i");
            var for_break = Expression.Label("for_break");

            var hitcounter = Expression.Lambda<Action<Counter, int>>(
                ExpressionEx.For(
                    i,
                    Expression.Constant(0),
                    Expression.LessThan(i, l),
                    Expression.PreIncrementAssign(i),
                    Expression.Block(
                        Expression.Condition(
                            Expression.LessThan(i, Expression.Constant(10)),
                            Expression.Call(c, typeof(Counter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Goto(for_break))),
                    for_break),
                c, l).Compile();

            hitcounter(counter, 100);

            Assert.Equal(10, counter.Count);
        }

        [Fact]
        public void ForContinue()
        {
            var counter = new Counter();

            var c = Expression.Parameter(typeof(Counter), "c");
            var l = Expression.Parameter(typeof(int), "l");

            var i = Expression.Variable(typeof(int), "i");
            var for_break = Expression.Label("for_break");
            var for_continue = Expression.Label("for_continue");

            var hitcounter = Expression.Lambda<Action<Counter, int>>(
                ExpressionEx.For(
                    i,
                    Expression.Constant(0),
                    Expression.LessThan(i, l),
                    Expression.PreIncrementAssign(i),
                    Expression.Block(
                        Expression.Condition(
                            Expression.Equal(Expression.Modulo(i, Expression.Constant(2)), Expression.Constant(0)),
                            Expression.Call(c, typeof(Counter).GetMethod("Hit", Type.EmptyTypes)),
                            Expression.Goto(for_continue))),
                    for_break,
                    for_continue),
                c, l).Compile();

            hitcounter(counter, 10);

            Assert.Equal(5, counter.Count);
        }
    }
}
