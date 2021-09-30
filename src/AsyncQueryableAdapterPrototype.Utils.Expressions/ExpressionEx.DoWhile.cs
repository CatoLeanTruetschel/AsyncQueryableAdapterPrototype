﻿// License
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

namespace AsyncQueryableAdapter.Utils.Expressions
{
    internal static partial class ExpressionEx
    {
        public static Expression DoWhile(Expression test, Expression body)
        {
            CheckDoWhileArgs(test, body, continueTarget: null);
            return DoWhileUnchecked(test, body, breakTarget: null, continueTarget: null);
        }

        public static Expression DoWhile(Expression test, Expression body, LabelTarget? breakTarget)
        {
            CheckDoWhileArgs(test, body, continueTarget: null);
            return DoWhileUnchecked(test, body, breakTarget, continueTarget: null);
        }

        public static Expression DoWhile(
            Expression test,
            Expression body,
            LabelTarget? breakTarget,
            LabelTarget? continueTarget)
        {
            CheckDoWhileArgs(test, body, continueTarget);
            return DoWhileUnchecked(test, body, breakTarget, continueTarget);
        }

        private static void CheckDoWhileArgs(Expression test, Expression body, LabelTarget? continueTarget)
        {
            if (test is null)
                throw new ArgumentNullException(nameof(test));

            if (body is null)
                throw new ArgumentNullException(nameof(body));

            if (test.Type != typeof(bool))
                throw new ArgumentException("Test must be a boolean expression", nameof(test));

            if (continueTarget is not null && continueTarget.Type != typeof(void))
                throw new ArgumentException("Continue label target must be void", nameof(continueTarget));
        }

        public static Expression DoWhileUnchecked(
            Expression test,
            Expression body,
            LabelTarget? breakTarget,
            LabelTarget? continueTarget)
        {
            var innerLoopBreak = Expression.Label("inner_loop_break");
            var innerLoopContinue = Expression.Label("inner_loop_continue");

            var @continue = continueTarget ?? Expression.Label("continue");
            var @break = breakTarget ?? Expression.Label("break");

            return Expression.Block(
                Expression.Loop(
                    Expression.Block(
                        Expression.Label(@continue),
                        body,
                        Expression.Condition(
                            test,
                            Expression.Goto(innerLoopContinue),
                            Expression.Goto(innerLoopBreak))),
                    innerLoopBreak,
                    innerLoopContinue),
                Expression.Label(@break));
        }
    }
}
