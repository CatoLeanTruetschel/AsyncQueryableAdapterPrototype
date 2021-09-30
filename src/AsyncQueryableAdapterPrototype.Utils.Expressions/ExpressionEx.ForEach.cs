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
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace AsyncQueryableAdapter.Utils.Expressions
{
    internal static partial class ExpressionEx
    {
        public static Expression ForEach(ParameterExpression variable, Expression enumerable, Expression body)
        {
            CheckForEachArgs(variable, enumerable, body, continueTarget: null);
            return ForEachUnchecked(variable, enumerable, body, breakTarget: null, continueTarget: null);
        }

        public static Expression ForEach(
            ParameterExpression variable,
            Expression enumerable,
            Expression body,
            LabelTarget? breakTarget)
        {
            CheckForEachArgs(variable, enumerable, body, continueTarget: null);
            return ForEachUnchecked(variable, enumerable, body, breakTarget, continueTarget: null);
        }

        public static Expression ForEach(
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

        public static Expression ForEachUnchecked(
            ParameterExpression variable,
            Expression enumerable,
            Expression body,
            LabelTarget? breakTarget,
            LabelTarget? continueTarget)
        {
            if (enumerable.Type.IsArray)
            {
                return ReduceForArray(variable, enumerable, body, breakTarget, continueTarget);
            }

            return ReduceForEnumerable(variable, enumerable, body, breakTarget, continueTarget);
        }

        private static Expression ReduceForArray(
            ParameterExpression variable,
            Expression enumerable,
            Expression body,
            LabelTarget? breakTarget,
            LabelTarget? continueTarget)
        {
            var innerLoopBreak = Expression.Label("inner_loop_break");
            var innerLoopContinue = Expression.Label("inner_loop_continue");
            var @continue = continueTarget ?? Expression.Label("continue");
            var @break = breakTarget ?? Expression.Label("break");
            var index = Expression.Variable(typeof(int), "i");

            return Expression.Block(
                new[] { index, variable },
                Expression.Assign(index, Expression.Constant(0)),
                Expression.Loop(
                    Expression.Block(
                        Expression.IfThen(
                            Expression.IsFalse(
                                Expression.LessThan(
                                    index,
                                    Expression.ArrayLength(enumerable))),
                            Expression.Break(innerLoopBreak)),
                        Expression.Assign(
                            variable,
                            Expression.Convert(Expression.ArrayIndex(
                                enumerable,
                                index), variable.Type)),
                        body,
                        Expression.Label(@continue),
                        Expression.PreIncrementAssign(index)),
                    innerLoopBreak,
                    innerLoopContinue),
                Expression.Label(@break));
        }

        private static Expression ReduceForEnumerable(
            ParameterExpression variable,
            Expression enumerable,
            Expression body,
            LabelTarget? breakTarget,
            LabelTarget? continueTarget)
        {
            var enumerableTypeDescriptor = EnumerableTypeDescriptor.GetTypeDescriptor(enumerable.Type);

            if (!enumerableTypeDescriptor.IsEnumerable)
            {
                throw new ArgumentException("The specified argument is not enumerable.", nameof(enumerable));
            }

            var enumerator = Expression.Variable(enumerableTypeDescriptor.EnumeratorType);

            var innerLoopContinue = Expression.Label("inner_loop_continue");
            var innerLoopBreak = Expression.Label("inner_loop_break");
            var @continue = continueTarget ?? Expression.Label("continue");
            var @break = breakTarget ?? Expression.Label("break");

            Expression variableInitializer;

            if (enumerableTypeDescriptor.CurrentProperty.PropertyType.IsAssignableTo(variable.Type))
            {
                variableInitializer = Expression.Property(enumerator, enumerableTypeDescriptor.CurrentProperty);
            }
            else
            {
                variableInitializer = Expression.Convert(
                    Expression.Property(enumerator, enumerableTypeDescriptor.CurrentProperty),
                    variable.Type);
            }

            Expression loop = Expression.Block(
                new[] { variable },
                Expression.Goto(@continue),
                Expression.Loop(
                    Expression.Block(
                        Expression.Assign(variable, variableInitializer),
                        body,
                        Expression.Label(@continue),
                        Expression.Condition(
                            Expression.Call(enumerator, enumerableTypeDescriptor.MoveNextMethod),
                            Expression.Goto(innerLoopContinue),
                            Expression.Goto(innerLoopBreak))),
                    innerLoopBreak,
                    innerLoopContinue),
                Expression.Label(@break));

            // CSharp only disposes of the enumerator, if it implicitly implements IDisposable.
            if (enumerableTypeDescriptor.EnumeratorType.IsAssignableTo(typeof(IDisposable)))
            {
                MethodInfo? disposeMethod;

                // TODO: Currently we use a special case, but it would be better to use a generic implementation that walks
                // up the type hierarchy and searches for a matching methods. We have to mimic what the C# compiler would do.
                if (enumerableTypeDescriptor.EnumeratorType == typeof(IEnumerator)
                    || enumerableTypeDescriptor.EnumeratorType.IsGenericType
                    && enumerableTypeDescriptor.EnumeratorType.GetGenericTypeDefinition() == typeof(IEnumerator<>))
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
                    disposeMethod = enumerableTypeDescriptor.EnumeratorType.GetMethod(
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
                Expression.Assign(enumerator, Expression.Call(enumerable, enumerableTypeDescriptor.GetEnumeratorMethod)),
                loop);
        }

        //private static void ResolveEnumerationMembers(
        //    ParameterExpression variable,
        //    Expression enumerable,
        //    out MethodInfo getEnumerator,
        //    out MethodInfo moveNext,
        //    out MethodInfo getCurrent)
        //{
        //    // TODO: foreach should not require the enumerator to implement IEnumerable

        //    Type enumerableType;
        //    Type enumeratorType;

        //    if (TryGetGenericEnumerableArgument(variable, enumerable, out var itemType))
        //    {
        //        enumerableType = typeof(IEnumerable<>).MakeGenericType(itemType);
        //        enumeratorType = typeof(IEnumerator<>).MakeGenericType(itemType);
        //    }
        //    else
        //    {
        //        enumerableType = typeof(IEnumerable);
        //        enumeratorType = typeof(IEnumerator);
        //    }

        //    moveNext = typeof(IEnumerator).GetMethod("MoveNext")!;
        //    getCurrent = enumeratorType.GetProperty("Current")!.GetGetMethod()!;
        //    getEnumerator = enumerable.Type.GetMethod("GetEnumerator", BindingFlags.Public | BindingFlags.Instance)!;

        //    //
        //    // We want to avoid unnecessarily boxing an enumerator if it's a value type.  Look
        //    // for a GetEnumerator() method that conforms to the rules of the C# 'foreach'
        //    // pattern.  If we don't find one, fall back to IEnumerable[<T>].GetEnumerator().
        //    //

        //    if (getEnumerator is null || !enumeratorType.IsAssignableFrom(getEnumerator.ReturnType))
        //    {
        //        getEnumerator = enumerableType.GetMethod("GetEnumerator")!;
        //    }
        //}

        //private static Expression? CreateDisposeOperation(
        //    Type enumeratorType,
        //    ParameterExpression enumerator)
        //{
        //    // TODO: foreach should not require the enumerator to implement IDisposable

        //    var dispose = typeof(IDisposable).GetMethod("Dispose", BindingFlags.Public | BindingFlags.Instance);

        //    if (typeof(IDisposable).IsAssignableFrom(enumeratorType))
        //    {
        //        //
        //        // We know the enumerator implements IDisposable, so skip the type check.
        //        //
        //        return Expression.Call(enumerator, dispose!);
        //    }

        //    if (enumeratorType.IsValueType)
        //    {
        //        //
        //        // The enumerator is a value type and doesn't implement IDisposable; we needn't
        //        // bother with a check at all.
        //        //
        //        return null;
        //    }

        //    //
        //    // We don't know whether the enumerator implements IDisposable or not.  Emit a
        //    // runtime check.
        //    //
        //    var disposable = Expression.Variable(typeof(IDisposable));

        //    // {
        //    //      IDisposable disposable;
        //    //      disposable = enumerator as IDisposable;
        //    //      if (!ReferenceEquals(disposable, null)) {
        //    //          disposable.Dispose();
        //    // }
        //    return Expression.Block(
        //        new[] { disposable },
        //        Expression.Assign(disposable, Expression.TypeAs(enumerator, typeof(IDisposable))),
        //        Expression.IfThen(
        //            Expression.ReferenceNotEqual(disposable, Expression.Constant(null)),
        //            Expression.Call(
        //                disposable,
        //                "Dispose",
        //                Type.EmptyTypes)));
        //}

        //private static bool TryGetGenericEnumerableArgument(
        //    ParameterExpression variable,
        //    Expression enumerable,
        //    [NotNullWhen(true)] out Type? argument)
        //{
        //    argument = null;

        //    foreach (var @interface in enumerable.Type.GetInterfaces())
        //    {
        //        if (!@interface.IsGenericType)
        //            continue;

        //        var definition = @interface.GetGenericTypeDefinition();
        //        if (definition != typeof(IEnumerable<>))
        //            continue;

        //        argument = @interface.GetGenericArguments()[0];
        //        if (variable.Type.IsAssignableFrom(argument))
        //            return true;
        //    }

        //    return false;
        //}
    }
}
