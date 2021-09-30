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
        public void While()
        {
            var counter = new Counter();

            var c = Expression.Parameter(typeof(Counter), "c");
            var i = Expression.Parameter(typeof(int), "i");
            var l = Expression.Parameter(typeof(int), "l");

            var hitcounter = Expression.Lambda<Action<Counter, int, int>>(
                ExpressionEx.While(
                    Expression.LessThan(i, l),
                    Expression.Block(
                        Expression.Call(c, typeof(Counter).GetMethod("Hit", Type.EmptyTypes)),
                        Expression.PreIncrementAssign(i))
                    ),
                c, i, l).Compile();

            hitcounter(counter, 0, 10);

            Assert.Equal(10, counter.Count);
        }

        [Fact]
        public void WhileFalse()
        {
            var counter = new Counter();

            var c = Expression.Parameter(typeof(Counter), "c");
            var i = Expression.Parameter(typeof(int), "i");
            var l = Expression.Parameter(typeof(int), "l");

            var hitcounter = Expression.Lambda<Action<Counter, int, int>>(
                ExpressionEx.While(
                    Expression.LessThan(i, l),
                    Expression.Block(
                        Expression.Call(c, typeof(Counter).GetMethod("Hit", Type.EmptyTypes)),
                        Expression.PreIncrementAssign(i))
                    ),
                c, i, l).Compile();

            hitcounter(counter, 100, 10);

            Assert.Equal(0, counter.Count);
        }

        [Fact]
        public void WhileBreakContinue()
        {
            var counter = new Counter();

            var c = Expression.Parameter(typeof(Counter), "c");
            var i = Expression.Parameter(typeof(int), "i");
            var l = Expression.Parameter(typeof(int), "l");

            var loopBreak = Expression.Label("for_break");
            var loopContinue = Expression.Label("for_continue");

            var hitcounter = Expression.Lambda<Action<Counter, int, int>>(
                ExpressionEx.While(
                    Expression.LessThan(i, l),
                    Expression.Block(
                        Expression.Condition(
                            Expression.LessThan(i, Expression.Constant(10)),
                            Expression.Block(
                                Expression.Call(c, typeof(Counter).GetMethod("Hit", Type.EmptyTypes)),
                                Expression.PostIncrementAssign(i),
                                Expression.Goto(loopContinue)),
                            Expression.Goto(loopBreak))),
                    loopBreak,
                    loopContinue),
                c, i, l).Compile();

            hitcounter(counter, 0, 100);

            Assert.Equal(10, counter.Count);
        }
    }
}
