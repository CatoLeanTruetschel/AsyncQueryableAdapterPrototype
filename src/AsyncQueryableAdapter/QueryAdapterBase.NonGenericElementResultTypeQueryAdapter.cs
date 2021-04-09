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
