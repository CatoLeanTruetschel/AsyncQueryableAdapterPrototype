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
using System.Linq.Expressions;
using System.Reflection;

namespace AsyncQueryableAdapter.Utils.Expressions
{
    internal static partial class ExpressionEx
    {
        public static ForEachExpression ForEach(ParameterExpression variable, Expression enumerable, Expression body)
        {
            CheckForEachArgs(variable, enumerable, body, continueTarget: null);
            return ForEachUnchecked(variable, enumerable, body, breakTarget: null, continueTarget: null);
        }

        public static ForEachExpression ForEach(
            ParameterExpression variable,
            Expression enumerable,
            Expression body,
            LabelTarget? breakTarget)
        {
            CheckForEachArgs(variable, enumerable, body, continueTarget: null);
            return ForEachUnchecked(variable, enumerable, body, breakTarget, continueTarget: null);
        }

        public static ForEachExpression ForEach(
            ParameterExpression variable,
            Expression enumerable,
            Expression body,
            LabelTarget? breakTarget,
            LabelTarget? continueTarget)
        {
            CheckForEachArgs(variable, enumerable, body, continueTarget);
            return ForEachUnchecked(variable, enumerable, body, breakTarget, continueTarget);
        }

        private static void CheckForEachArgs
            (ParameterExpression variable,
            Expression enumerable,
            Expression body,
            LabelTarget? continueTarget)
        {
            if (variable is null)
                throw new ArgumentNullException(nameof(variable));

            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));

            if (body is null)
                throw new ArgumentNullException(nameof(body));

            if (continueTarget is not null && continueTarget.Type != typeof(void))
                throw new ArgumentException("Continue label target must be void", nameof(continueTarget));
        }

        public static ForEachExpression ForEachUnchecked(
            ParameterExpression variable,
            Expression enumerable,
            Expression body,
            LabelTarget? breakTarget,
            LabelTarget? continueTarget)
        {
            return new ForEachExpression(variable, enumerable, body, breakTarget, continueTarget);
        }
    }

    public sealed class ForEachExpression : Expression
    {
        private readonly EnumerableTypeDescriptor _enumerableTypeDescriptor;

        internal ForEachExpression(
            ParameterExpression variable,
            Expression enumerable,
            Expression body,
            LabelTarget? breakTarget,
            LabelTarget? continueTarget)
        {
            _enumerableTypeDescriptor = EnumerableTypeDescriptor.GetTypeDescriptor(enumerable.Type);

            if (!_enumerableTypeDescriptor.IsEnumerable)
            {
                throw new ArgumentException("The specified argument is not enumerable.", nameof(enumerable));
            }

            Variable = variable;
            Enumerable = enumerable;
            Body = body;
            BreakTarget = breakTarget ?? Expression.Label("break");
            ContinueTarget = continueTarget ?? Expression.Label("continue");
        }

        public override ExpressionType NodeType => ExpressionType.Extension;

        public override Type Type
        {
            get
            {
                if (BreakTarget != null)
                    return BreakTarget.Type;

                return typeof(void);
            }
        }

        public override bool CanReduce => true;

        public new ParameterExpression Variable { get; }

        public Expression Enumerable { get; }

        public Expression Body { get; }

        public LabelTarget BreakTarget { get; }

        public LabelTarget ContinueTarget { get; }

        public override Expression Reduce()
        {
            if (Enumerable.Type.IsArray)
            {
                return ReduceForArray();
            }

            return ReduceForEnumerable();
        }

        private Expression ReduceForArray()
        {
            var innerLoopBreak = Expression.Label("INNER_LOOP_BREAK");
            var innerLoopContinue = Expression.Label("INNER_LOOP_CONTINUE");
            var @continue = ContinueTarget;
            var @break = BreakTarget;
            var index = Expression.Variable(typeof(int), "i");

            return Expression.Block(
                new[] { index, Variable },
                Expression.Assign(index, Expression.Constant(0)),
                Expression.Loop(
                    Expression.Block(
                        Expression.IfThen(
                            Expression.IsFalse(
                                Expression.LessThan(
                                    index,
                                    Expression.ArrayLength(Enumerable))),
                            Expression.Break(innerLoopBreak)),
                        Expression.Assign(
                            Variable,
                            Expression.Convert(Expression.ArrayIndex(
                                Enumerable,
                                index), Variable.Type)),
                        Body,
                        Expression.Label(@continue),
                        Expression.PreIncrementAssign(index)),
                    innerLoopBreak,
                    innerLoopContinue),
                Expression.Label(@break));
        }

        private Expression ReduceForEnumerable()
        {
            var enumerator = Expression.Variable(_enumerableTypeDescriptor.EnumeratorType);

            var innerLoopContinue = Expression.Label("inner_loop_continue");
            var innerLoopBreak = Expression.Label("inner_loop_break");
            var @continue = ContinueTarget;
            var @break = BreakTarget;

            Expression variableInitializer;

            if (_enumerableTypeDescriptor.CurrentProperty.PropertyType.IsAssignableTo(Variable.Type))
            {
                variableInitializer = Expression.Property(enumerator, _enumerableTypeDescriptor.CurrentProperty);
            }
            else
            {
                variableInitializer = Expression.Convert(
                    Expression.Property(enumerator, _enumerableTypeDescriptor.CurrentProperty),
                    Variable.Type);
            }

            Expression loop = Expression.Block(
                new[] { Variable },
                Expression.Goto(@continue),
                Expression.Loop(
                    Expression.Block(
                        Expression.Assign(Variable, variableInitializer),
                        Body,
                        Expression.Label(@continue),
                        Expression.Condition(
                            Expression.Call(enumerator, _enumerableTypeDescriptor.MoveNextMethod),
                            Expression.Goto(innerLoopContinue),
                            Expression.Goto(innerLoopBreak))),
                    innerLoopBreak,
                    innerLoopContinue),
                Expression.Label(@break));

            // CSharp only disposes of the enumerator, if it implicitly implements IDisposable.
            if (_enumerableTypeDescriptor.EnumeratorType.IsAssignableTo(typeof(IDisposable)))
            {
                MethodInfo? disposeMethod;

                // TODO: Currently we use a special case, but it would be better to use a generic implementation that walks
                // up the type hierarchy and searches for a matching methods. We have to mimic what the C# compiler would do.
                if (_enumerableTypeDescriptor.EnumeratorType == typeof(IEnumerator)
                    || _enumerableTypeDescriptor.EnumeratorType.IsGenericType
                    && _enumerableTypeDescriptor.EnumeratorType.GetGenericTypeDefinition() == typeof(IEnumerator<>))
                {
                    disposeMethod = typeof(IDisposable).GetMethod(
                        nameof(IDisposable.Dispose),
                        BindingFlags.Instance | BindingFlags.Public,
                        Type.DefaultBinder,
                        Type.EmptyTypes,
                        modifiers: null);
                }
                else
                {
                    disposeMethod = _enumerableTypeDescriptor.EnumeratorType.GetMethod(
                        nameof(IDisposable.Dispose),
                        BindingFlags.Instance | BindingFlags.Public,
                        Type.DefaultBinder,
                        Type.EmptyTypes,
                        modifiers: null);
                }

                if (disposeMethod is not null && disposeMethod.ReturnType == typeof(void))
                {
                    var dispose = Expression.Call(enumerator, disposeMethod);
                    loop = Expression.TryFinally(loop, dispose);
                }
            }

            return Expression.Block(
                new[] { enumerator },
                Expression.Assign(enumerator, Expression.Call(Enumerable, _enumerableTypeDescriptor.GetEnumeratorMethod)),
                loop);
        }
    }
}
