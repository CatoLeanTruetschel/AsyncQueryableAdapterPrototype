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

using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    internal static class AsyncEnumerableExtension
    {
        #region AsAsyncQueryable

        private static readonly MethodInfo _asAsyncQueryableMethodDefinition
            = new Func<IAsyncEnumerable<object?>, IAsyncQueryable<object?>>(
                AsAsyncQueryable<object?>).Method.GetGenericMethodDefinition();
        private static readonly ConditionalWeakTable<Type, Func<IAsyncEnumerable<object?>, IAsyncQueryable>> _asAsyncQueryableConversions = new();
        private static readonly ConditionalWeakTable<Type, Func<IAsyncEnumerable<object?>, IAsyncQueryable>>.CreateValueCallback _buildAsAsyncQueryableConversion
            = BuildAsAsyncQueryableConversion;

        public static IAsyncQueryable AsAsyncQueryable(this IAsyncEnumerable<object?> asyncEnumerable, Type elementType)
        {
            if (asyncEnumerable is null)
                throw new ArgumentNullException(nameof(asyncEnumerable));

            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            var asyncQueryableConversion = _asAsyncQueryableConversions.GetValue(
                elementType, _buildAsAsyncQueryableConversion);
            var asyncQueryable = asyncQueryableConversion(asyncEnumerable);

            Debug.Assert(asyncQueryable is not null);
            Debug.Assert(
                asyncQueryable.GetType().IsAssignableTo(typeof(IAsyncQueryable<>).MakeGenericType(elementType)));

            return asyncQueryable;
        }

        [ThreadStatic]
        private static ParameterExpression[]? _1EntryParameterExpressionBuffer;

        [ThreadStatic]
        private static Type[]? _1EntryTypeBuffer;

        private static Func<IAsyncEnumerable<object?>, IAsyncQueryable> BuildAsAsyncQueryableConversion(
            Type elementType)
        {
            Debug.Assert(elementType is not null);

            var elementTypeAsArray = _1EntryTypeBuffer ??= new Type[1];
            elementTypeAsArray[0] = elementType;

            var asAsyncQueryableMethod = _asAsyncQueryableMethodDefinition.MakeGenericMethod(elementTypeAsArray);

            var asyncEnumerableParameter = Expression.Parameter(typeof(IAsyncEnumerable<object?>), "asyncEnumerable");
            var callExpression = Expression.Call(asAsyncQueryableMethod, asyncEnumerableParameter);
            var convertCall = Expression.Convert(callExpression, typeof(IAsyncQueryable));

            var parameters = _1EntryParameterExpressionBuffer ??= new ParameterExpression[1];
            parameters[0] = asyncEnumerableParameter;

            var lambda = Expression.Lambda<Func<IAsyncEnumerable<object?>, IAsyncQueryable>>(convertCall, parameters);
            return lambda.Compile(preferInterpretation: false);
        }

        private static IAsyncQueryable<T> AsAsyncQueryable<T>(IAsyncEnumerable<object?> asyncEnumerable)
        {
            if(asyncEnumerable is not IAsyncEnumerable<T> typedEnumerable)
            {
                typedEnumerable = asyncEnumerable.Cast<object?, T>();
            }

            return typedEnumerable.AsAsyncQueryable();
        }

        #endregion

        #region Cast

#pragma warning disable VSTHRD200
        public static IAsyncEnumerable<TTarget> Cast<TSource, TTarget>(this IAsyncEnumerable<TSource> source)
#pragma warning restore VSTHRD200
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if(source is CastAsyncEnumerable<TTarget> original)
            {
                return original.SourceEnumerable;
            }

            return new CastAsyncEnumerable<TSource, TTarget>(source);
        }

        private abstract class CastAsyncEnumerable<TSource>
        {
            public CastAsyncEnumerable(IAsyncEnumerable<TSource> sourceEnumerable)
            {
                Debug.Assert(sourceEnumerable is not null);
                SourceEnumerable = sourceEnumerable;
            }

            public IAsyncEnumerable<TSource> SourceEnumerable { get; }
        }

        private sealed class CastAsyncEnumerable<TSource, TTarget> 
            : CastAsyncEnumerable<TSource>, IAsyncEnumerable<TTarget>
        {
            public CastAsyncEnumerable(IAsyncEnumerable<TSource> sourceEnumerable) : base(sourceEnumerable)  { }

            public IAsyncEnumerator<TTarget> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                return new CastAsyncEnumerator(SourceEnumerable.GetAsyncEnumerator(cancellationToken));
            }

            private sealed class CastAsyncEnumerator : IAsyncEnumerator<TTarget>
            {
                private readonly IAsyncEnumerator<TSource> _sourceEnumerable;

                public CastAsyncEnumerator(IAsyncEnumerator<TSource> sourceEnumerator)
                {
                    Debug.Assert(sourceEnumerator is not null);
                    _sourceEnumerable = sourceEnumerator;
                }

                public ValueTask<bool> MoveNextAsync()
                {
                    return _sourceEnumerable.MoveNextAsync();
                }

                public TTarget Current => (TTarget)(object)_sourceEnumerable.Current!;

                public ValueTask DisposeAsync()
                {
                    return _sourceEnumerable.DisposeAsync();
                }
            }
        }

        #endregion
    }
}
