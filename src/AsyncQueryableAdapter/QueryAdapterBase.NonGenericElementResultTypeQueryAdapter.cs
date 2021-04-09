/* License
 * --------------------------------------------------------------------------------------------------------------------
 * (C) Copyright 2021 Cato Léan Trütschel and contributors 
 * (https://github.com/CatoLeanTruetschel/AsyncQueryableAdapterPrototype)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * --------------------------------------------------------------------------------------------------------------------
 */

using System;
using System.Runtime.CompilerServices;

namespace AsyncQueryableAdapter
{
    partial class QueryAdapterBase
    {
        private static INonGenericElementResultTypeQueryAdapter GetNonGenericAdapter(Type elementType, Type resultType)
        {
            return GetNonGenericAdapter(elementType).GetElementResultTypeQueryAdapter(resultType);
        }

        partial interface INonGenericElementTypeQueryAdapter
        {
            INonGenericElementResultTypeQueryAdapter GetElementResultTypeQueryAdapter(Type resultType);
        }

        partial class NonGenericElementTypeQueryAdapter<T>
        {
            private static readonly Type _nonGenericElementResultTypeQueryAdapterTypeDefinition
               = typeof(NonGenericElementResultTypeQueryAdapter<,>);

            private static readonly ConditionalWeakTable<Type, INonGenericElementResultTypeQueryAdapter> _nonGenericAdapters
                = new();
            private static readonly ConditionalWeakTable<Type, INonGenericElementResultTypeQueryAdapter>.CreateValueCallback _buildNonGenericAdapter
                = BuildNonGenericElementTypeQueryAdapter;

            private static INonGenericElementResultTypeQueryAdapter BuildNonGenericElementTypeQueryAdapter(
                Type resultType)
            {
                var type = _nonGenericElementResultTypeQueryAdapterTypeDefinition.MakeGenericType(typeof(T), resultType);
                return (INonGenericElementResultTypeQueryAdapter)Activator.CreateInstance(type)!;
            }
        }

        private partial interface INonGenericElementResultTypeQueryAdapter
        {
            Type ElementType { get; }

            Type ResultType { get; }
        }

#pragma warning disable CA1812
        private sealed partial class NonGenericElementResultTypeQueryAdapter<TSource, TResult>
#pragma warning restore CA1812
            : INonGenericElementResultTypeQueryAdapter
        {
            public Type ElementType => typeof(TSource);

            public Type ResultType => typeof(TResult);
        }
    }
}
