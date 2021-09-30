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
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

#if ENABLE_EXPRESSION_DISPOSE_BY_EXTENSION
using System.IO;
using System.Runtime.CompilerServices;
#endif

namespace AsyncQueryableAdapter.Utils.Expressions
{
    internal static partial class ExpressionEx
    {
        public static UsingExpression Using(Expression disposable, Expression body)
        {
            CheckUsingArgs(variable: null, disposable, body);
            return UsingUnchecked(null, disposable, body);
        }

        public static UsingExpression Using(ParameterExpression? variable, Expression disposable, Expression body)
        {
            CheckUsingArgs(variable, disposable, body);
            return UsingUnchecked(variable, disposable, body);
        }

        private static void CheckUsingArgs(ParameterExpression? variable, Expression disposable, Expression body)
        {
            if (disposable is null)
                throw new ArgumentNullException(nameof(disposable));

            if (body is null)
                throw new ArgumentNullException(nameof(body));

            if (variable is not null && !disposable.Type.IsAssignableTo(variable.Type))
            {
                throw new ArgumentException(
                    $"The type of { nameof(disposable) } must be assignable to the type of { nameof(variable) }.");
            }
        }

        private static UsingExpression UsingUnchecked(ParameterExpression? variable, Expression disposable, Expression body)
        {
            return new UsingExpression(variable, disposable, body);
        }
    }

    internal sealed class UsingExpression : Expression
    {
        private static readonly MethodInfo _disposableDisposeMethod = typeof(IDisposable)
            .GetMethod(nameof(IDisposable.Dispose), BindingFlags.Public | BindingFlags.Instance);

        private readonly MethodInfo _disposeMethod;

        internal UsingExpression(ParameterExpression? variable, Expression disposable, Expression body)
        {
            if (variable is null)
                variable = Expression.Parameter(disposable.Type);

            if (!TryFindDisposeMethod(disposable, out _disposeMethod!))
            {
                throw new ArgumentException("The value must be disposable", nameof(disposable));
            }

            Variable = variable;
            Disposable = disposable;
            Body = body;
        }

        private static bool TryFindDisposeMethod(
            Expression disposable,
            [NotNullWhen(true)] out MethodInfo? disposeMethod)
        {
            var disposableType = disposable.Type;

            if (typeof(IDisposable).IsAssignableFrom(disposableType))
            {
                disposeMethod = _disposableDisposeMethod;
                return true;
            }

            if (TryFindInstanceDisposeMethod(disposableType, out disposeMethod))
            {
                return true;
            }

#if ENABLE_EXPRESSION_DISPOSE_BY_EXTENSION
            return TryFindExtensionDisposeMethod(disposableType, out disposeMethod);
#else
            return false;
#endif
        }

        private static bool TryFindInstanceDisposeMethod(
            Type disposableType,
            [NotNullWhen(true)] out MethodInfo? disposeMethod)
        {
            disposeMethod = disposableType.GetMethod(
                nameof(IDisposable.Dispose),
                BindingFlags.Public | BindingFlags.Instance, // TODO: Use also internal dispose methods?
                System.Type.DefaultBinder,
                System.Type.EmptyTypes,
                modifiers: null);

            return disposeMethod is not null;
        }

#if ENABLE_EXPRESSION_DISPOSE_BY_EXTENSION

        private static bool TryFindExtensionDisposeMethod(
            Type disposableType,
            [NotNullWhen(true)] out MethodInfo? disposeMethod)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!assembly.IsDefined(typeof(ExtensionAttribute)))
                {
                    continue;
                }

                Type[] types;

                try
                {
                    types = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException exc)
                when (exc.LoaderExceptions.Length > 0 && exc.LoaderExceptions[0] is FileNotFoundException)
                {
                    continue;
                }

                foreach (var type in types)
                {
                    if (!type.IsPublic) // TODO: Use also internal types?
                    {
                        continue;
                    }

                    if (!type.IsSealed || type.IsGenericType || type.IsNested)
                    {
                        continue;
                    }

                    if (!type.IsDefined(typeof(ExtensionAttribute), inherit: false))
                    {
                        continue;
                    }

                    var methods = type.GetMethods(
                        BindingFlags.Public | BindingFlags.Static); // TODO: Use also internal dispose methods?

                    var curr = (Type?)disposableType;
                    MethodInfo? inRefDisposeMethod = null;

                    while (curr is not null)
                    {
                        foreach (var method in methods)
                        {
                            if (!method.Name.Equals(nameof(IDisposable.Dispose), StringComparison.Ordinal))
                            {
                                continue;
                            }

                            if (!method.IsDefined(typeof(ExtensionAttribute), inherit: false))
                            {
                                continue;
                            }

                            if (method.ReturnType != typeof(void))
                            {
                                continue;
                            }

                            var parameters = method.GetParameters();

                            if (parameters.Length is not 1)
                            {
                                continue;
                            }

                            if (parameters[0].ParameterType.IsByRef && parameters[0].IsIn)
                            {
                                if (inRefDisposeMethod is not null)
                                {
                                    continue;
                                }

                                if (parameters[0].ParameterType.GetElementType()! != curr)
                                {
                                    continue;
                                }

                                // Check whether there is a non in-ref method with the same signature
                                inRefDisposeMethod = method;
                            }
                            else if (parameters[0].ParameterType != curr)
                            {
                                continue;
                            }
                            else
                            {
                                disposeMethod = method;
                                return true;
                            }
                        }

                        curr = curr.BaseType;
                    }

                    if (inRefDisposeMethod is not null)
                    {
                        disposeMethod = inRefDisposeMethod;
                        return true;
                    }
                }
            }

            disposeMethod = null;
            return false;
        }

#endif

        public override ExpressionType NodeType => ExpressionType.Extension;

        public override Type Type => Body.Type;

        public override bool CanReduce => true;

        public new ParameterExpression Variable { get; }

        public Expression Disposable { get; }

        public Expression Body { get; }

        public override Expression Reduce()
        {
            var end_finally = Expression.Label("END_FINALLY");

            Expression disposeCall;

            if (_disposeMethod == _disposableDisposeMethod)
            {
                disposeCall = Expression.Call(Expression.Convert(Variable, typeof(IDisposable)), _disposeMethod);
            }
#if ENABLE_EXPRESSION_DISPOSE_BY_EXTENSION
            // Extensions method
            else if (disposeMethod.IsStatic)
            {
                disposeCall = Expression.Call(disposeMethod, variable);
            }
#endif
            // Instance method
            else
            {
                disposeCall = Expression.Call(Variable, _disposeMethod);
            }

            // TODO: Is this correct or do we have to check diposeable.Type???
            // TODO: Check for dynamic type
            if (!Variable.Type.IsValueType || TypeHelper.IsNullableType(Variable.Type))
            {
                disposeCall =
                    Expression.Condition(
                        Expression.ReferenceNotEqual(Variable, Expression.Constant(null)),
                        Expression.Block(
                            disposeCall,
                            Expression.Goto(end_finally)),
                        Expression.Goto(end_finally));
            }

            var @finally =
                Expression.Block(
                    disposeCall,
                    Expression.Label(end_finally));

            //  {
            //      [variable.Type] [variable.Name];
            //      [variable.Name] = disposable;
            //      try
            //      {
            //          [body]
            //      }
            //      finally
            //      {
            //          if ([variable.Name] is not null)
            //          {
            //              ((IDisposable)[variable.Name]).Dispose();
            //              goto END_FINALLY;
            //          }
            //          else { goto END_FINALLY; }
            //          END_FINALLY:
            //      }
            //  }
            return Expression.Block(
                new[] { Variable },
                Expression.Assign(Variable, Disposable),
                Expression.TryFinally(Body, @finally));
        }
    }
}
