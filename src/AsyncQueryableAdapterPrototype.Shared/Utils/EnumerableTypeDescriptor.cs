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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AsyncQueryableAdapter.Utils
{
    internal sealed class EnumerableTypeDescriptor
    {
        private static readonly MethodInfo _enumerableGetEnumeratorMethod = typeof(IEnumerable).GetMethod(
            nameof(IEnumerable.GetEnumerator), BindingFlags.Public | BindingFlags.Instance)!;

        // This is a conditional weak table to allow assembly unloading.
        private static readonly ConditionalWeakTable<Type, EnumerableTypeDescriptor> _cache = new();

        public static EnumerableTypeDescriptor GetTypeDescriptor(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            var result = _cache.GetValue(type, type => BuildTypeDescriptor(type));
            return result;
        }

        private static EnumerableTypeDescriptor BuildTypeDescriptor(Type type)
        {
            var enumerableType = type;

            var getEnumeratorMethod = enumerableType.GetMethod(
                nameof(IEnumerable.GetEnumerator),
                BindingFlags.Public | BindingFlags.Instance,
                Type.DefaultBinder,
                Type.EmptyTypes,
                modifiers: null);

            if (getEnumeratorMethod is null || getEnumeratorMethod.ReturnType == typeof(void))
            {
                var interfaces = enumerableType.GetInterfaces();
                Type? genericEnumerableType = null;
                var hasEnumerableImplementation = false;

                for (var i = 0; i < interfaces.Length; i++)
                {
                    if (interfaces[i].IsGenericType && interfaces[i].GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    {
                        // Multiple IEnumerable<T> implementations => Cannot use a foreach loop.
                        if (genericEnumerableType is not null)
                        {
                            return new EnumerableTypeDescriptor(type);
                        }

                        genericEnumerableType = interfaces[i];
                    }
                    else if (interfaces[i] == typeof(IEnumerable))
                    {
                        hasEnumerableImplementation = true;
                    }
                }

                if (genericEnumerableType is not null)
                {
                    getEnumeratorMethod = genericEnumerableType.GetMethod(
                        nameof(IEnumerable.GetEnumerator), BindingFlags.Public | BindingFlags.Instance);
                    Debug.Assert(getEnumeratorMethod is not null);

                }
                else if (hasEnumerableImplementation)
                {
                    getEnumeratorMethod = _enumerableGetEnumeratorMethod;
                }
                else
                {
                    return new EnumerableTypeDescriptor(type);
                }
            }

            var enumeratorType = getEnumeratorMethod.ReturnType;
            var currentProperty = enumeratorType.GetProperty(
                    nameof(IEnumerator.Current), BindingFlags.Public | BindingFlags.Instance);
            MethodInfo? moveNextMethod;

            // TODO: Currently we use a special case, but it would be better to use a generic implementation that walks
            // up the type hierarchy and searches for a matching methods. We have to mimic what the C# compiler would do.
            if (enumeratorType.IsGenericType && enumeratorType.GetGenericTypeDefinition() == typeof(IEnumerator<>))
            {
                moveNextMethod = typeof(IEnumerator).GetMethod(
                    nameof(IEnumerator.MoveNext),
                    BindingFlags.Public | BindingFlags.Instance,
                    Type.DefaultBinder,
                    Type.EmptyTypes,
                    modifiers: null);
            }
            else
            {
                moveNextMethod = enumeratorType.GetMethod(
                    nameof(IEnumerator.MoveNext),
                    BindingFlags.Public | BindingFlags.Instance,
                    Type.DefaultBinder,
                    Type.EmptyTypes,
                    modifiers: null);
            }

            if (currentProperty is null)
            {
                return new EnumerableTypeDescriptor(type);
            }

            if (moveNextMethod is null || moveNextMethod.ReturnType != typeof(bool))
            {
                return new EnumerableTypeDescriptor(type);
            }

            var isDisposable = enumeratorType.IsAssignableTo(typeof(IDisposable));

            return new EnumerableTypeDescriptor(
                enumerableType, enumeratorType, getEnumeratorMethod, currentProperty, moveNextMethod);
        }

        private readonly Type? _enumerableType;

        private EnumerableTypeDescriptor(
            Type enumerableType,
            Type enumeratorType,
            MethodInfo getEnumeratorMethod,
            PropertyInfo currentProperty,
            MethodInfo moveNextMethod)
        {
            _enumerableType = enumerableType;
            EnumeratorType = enumeratorType;
            GetEnumeratorMethod = getEnumeratorMethod;
            CurrentProperty = currentProperty;
            MoveNextMethod = moveNextMethod;
            IsEnumerable = true;
        }

        private EnumerableTypeDescriptor(Type enumerableType)
        {
            _enumerableType = enumerableType;
            EnumeratorType = null;
            GetEnumeratorMethod = null;
            CurrentProperty = null;
            MoveNextMethod = null;
            IsEnumerable = false;
        }

        [MemberNotNullWhen(true, nameof(EnumeratorType))]
        [MemberNotNullWhen(true, nameof(GetEnumeratorMethod))]
        [MemberNotNullWhen(true, nameof(CurrentProperty))]
        [MemberNotNullWhen(true, nameof(MoveNextMethod))]
        public bool IsEnumerable { get; }

        public Type EnumerableType => _enumerableType ?? typeof(object);

        public Type? EnumeratorType { get; }

        public MethodInfo? GetEnumeratorMethod { get; }

        public PropertyInfo? CurrentProperty { get; }

        public MethodInfo? MoveNextMethod { get; }
    }
}
