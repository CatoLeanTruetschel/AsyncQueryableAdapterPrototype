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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter
{
    public abstract partial class QueryAdapterBase
    {
        public AsyncQueryableOptions Options { get; }

        protected QueryAdapterBase(AsyncQueryableOptions options)
        {
            Options = options;
        }

        public IAsyncQueryable<T> GetAsyncQueryable<T>()
        {
            return new AsyncQueryable<T>(this);
        }

        protected abstract IQueryable<T> GetQueryable<T>();

        internal IQueryable GetQueryable(Type elementType)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).GetQueryable(this);
        }

        protected abstract IAsyncEnumerable<T> EvaluateAsync<T>(
            IQueryable<T> queryable,
            CancellationToken cancellation);

        internal IAsyncEnumerable<object?> EvaluateAsync(
           Type elementType,
           IQueryable queryable,
           CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).EvaluateAsync(this, queryable, cancellation);
        }

        protected virtual ValueTask<TSource> AggregateAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, TSource, TSource>> accumulator,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (accumulator is null)
                throw new ArgumentNullException(nameof(accumulator));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source, cancellation);
            return inMemoryCollection.AggregateAsync(accumulator.Compile(), cancellation);
        }

        protected virtual ValueTask<TAccumulate> AggregateAsync<TSource, TAccumulate>(
            IQueryable<TSource> source,
            TAccumulate seed,
            Expression<Func<TAccumulate, TSource, TAccumulate>> accumulator,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (accumulator is null)
                throw new ArgumentNullException(nameof(accumulator));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source, cancellation);
            return inMemoryCollection.AggregateAsync(seed, accumulator.Compile(), cancellation);
        }

        protected virtual ValueTask<TResult> AggregateAsync<TSource, TAccumulate, TResult>(
            IQueryable<TSource> source,
            TAccumulate seed,
            Expression<Func<TAccumulate, TSource, TAccumulate>> accumulator,
            Expression<Func<TAccumulate, TResult>> resultSelector,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (accumulator is null)
                throw new ArgumentNullException(nameof(accumulator));

            if (resultSelector is null)
                throw new ArgumentNullException(nameof(resultSelector));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source, cancellation);

            return inMemoryCollection.AggregateAsync(
                seed, accumulator.Compile(), resultSelector.Compile(), cancellation);
        }

        protected virtual async ValueTask<bool> AllAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellation)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            predicate = Expression.Lambda<Func<TSource, bool>>(Expression.Not(predicate.Body), predicate.Parameters);
            var notResult = await AnyAsync(source, predicate, cancellation).ConfigureAwait(false);
            return !notResult;
        }

        protected virtual ValueTask<bool> AnyAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return EvaluateAsync(source.Take(1), cancellation).AnyAsync(cancellation);
        }

        protected virtual ValueTask<bool> AnyAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return EvaluateAsync(source.Where(predicate).Take(1), cancellation).AnyAsync(cancellation);
        }

        protected virtual ValueTask<TSource> AverageAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source, cancellation);

            if (typeof(TSource) == typeof(double))
            {
                var result = ((IAsyncEnumerable<double>)inMemoryCollection).AverageAsync(cancellation);
                return Unsafe.As<ValueTask<double>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(float))
            {
                var result = ((IAsyncEnumerable<float>)inMemoryCollection).AverageAsync(cancellation);
                return Unsafe.As<ValueTask<float>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(decimal))
            {
                var result = ((IAsyncEnumerable<decimal>)inMemoryCollection).AverageAsync(cancellation);
                return Unsafe.As<ValueTask<decimal>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(double?))
            {
                var result = ((IAsyncEnumerable<double?>)inMemoryCollection).AverageAsync(cancellation);
                return Unsafe.As<ValueTask<double?>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(float?))
            {
                var result = ((IAsyncEnumerable<float?>)inMemoryCollection).AverageAsync(cancellation);
                return Unsafe.As<ValueTask<float?>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(decimal?))
            {
                var result = ((IAsyncEnumerable<decimal?>)inMemoryCollection).AverageAsync(cancellation);
                return Unsafe.As<ValueTask<decimal?>, ValueTask<TSource>>(ref result);
            }
            else
            {
                throw new NotSupportedException(); // TODO: Exception message
            }
        }

        internal AsyncTypeAwaitable AverageAsync(
            Type elementType,
            IQueryable source,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).AverageAsync(this, source, cancellation);
        }

        protected virtual ValueTask<TResult> AverageAsync<TSource, TResult>(
            IQueryable<TSource> source,
            Expression<Func<TSource, TResult>> selector,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var compiledSelector = selector.Compile();
            var inMemoryCollection = EvaluateAsync(source, cancellation);

            if (typeof(TResult) == typeof(double))
            {
                var result = inMemoryCollection.AverageAsync(
                    (Func<TSource, double>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<double>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(float))
            {
                var result = inMemoryCollection.AverageAsync(
                   (Func<TSource, float>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<float>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(decimal))
            {
                var result = inMemoryCollection.AverageAsync(
                    (Func<TSource, decimal>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<decimal>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(double?))
            {
                var result = inMemoryCollection.AverageAsync(
                    (Func<TSource, double?>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<double?>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(float?))
            {
                var result = inMemoryCollection.AverageAsync(
                    (Func<TSource, float?>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<float?>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(decimal?))
            {
                var result = inMemoryCollection.AverageAsync(
                   (Func<TSource, decimal?>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<decimal?>, ValueTask<TResult>>(ref result);
            }
            else
            {
                throw new NotSupportedException(); // TODO: Exception message
            }
        }

        internal AsyncTypeAwaitable AverageAsync(
            Type elementType,
            Type resultType,
            IQueryable source,
            Expression selector,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            if (resultType is null)
                throw new ArgumentNullException(nameof(resultType));

            return BuildQueryAdapter(elementType, resultType).AverageAsync(this, source, selector, cancellation);
        }

        protected virtual ValueTask<bool> ContainsAsync<TSource>(
            IQueryable<TSource> source,
            TSource value,
            CancellationToken cancellation)
        {
            // TODO: Build an expression tree that support null values for entries and for value and 
            //       that calls the correct equals method (equality operator, IEquatable, default Equals)
            return AnyAsync(source, p => p!.Equals(value), cancellation);
        }

        protected virtual ValueTask<bool> ContainsAsync<TSource>(
            IQueryable<TSource> source,
            TSource value,
            IEqualityComparer<TSource>? comparer,
            CancellationToken cancellation)
        {
            if (comparer is null)
            {
                return ContainsAsync(source, value, cancellation);
            }

            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source, cancellation);
            return inMemoryCollection.ContainsAsync(value, cancellation);
        }

        protected virtual ValueTask<int> CountAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source.Select(p => 1), cancellation);
            return inMemoryCollection.CountAsync(cancellation);
        }

        protected virtual ValueTask<int> CountAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source.Where(predicate).Select(p => 1), cancellation);
            return inMemoryCollection.CountAsync(cancellation);
        }

        protected virtual ValueTask<TSource> ElementAtAsync<TSource>(
            IQueryable<TSource> source,
            int index,
            CancellationToken cancellation)
        {
            // TODO: Does this throw the correct type of exception, if the index is out of range?
            return FirstAsync(source.Skip(index), cancellation);
        }

        protected virtual ValueTask<TSource?> ElementAtOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            int index,
            CancellationToken cancellation)
        {
            // TODO: Does this correctly return the default value, if the index is out of range?
            return FirstOrDefaultAsync(source.Skip(index), cancellation);
        }

        protected virtual ValueTask<TSource> FirstAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = EvaluateAsync(source.Take(1), cancellation);
            return enumerable.FirstAsync(cancellation);
        }

        internal AsyncTypeAwaitable FirstAsync(
            Type elementType,
            IQueryable source,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).FirstAsync(this, source, cancellation);
        }

        protected virtual ValueTask<TSource> FirstAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = EvaluateAsync(source.Where(predicate).Take(1), cancellation);
            return enumerable.FirstAsync(cancellation);
        }

        internal AsyncTypeAwaitable FirstAsync(
            Type elementType,
            IQueryable source,
            Expression predicate,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).FirstAsync(this, source, predicate, cancellation);
        }

        protected virtual ValueTask<TSource?> FirstOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = EvaluateAsync(source.Take(1), cancellation);
            return enumerable.FirstOrDefaultAsync(cancellation);
        }

        internal AsyncTypeAwaitable FirstOrDefaultAsync(
            Type elementType,
            IQueryable source,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).FirstOrDefaultAsync(this, source, cancellation);
        }

        protected virtual ValueTask<TSource?> FirstOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = EvaluateAsync(source.Where(predicate).Take(1), cancellation);
            return enumerable.FirstOrDefaultAsync(cancellation);
        }

        internal AsyncTypeAwaitable FirstOrDefaultAsync(
            Type elementType,
            IQueryable source,
            Expression predicate,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).FirstOrDefaultAsync(this, source, predicate, cancellation);
        }

        protected virtual ValueTask<TSource> LastAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

#if SUPPORTS_QUERYABLE_TAKE_LAST
            return FirstAsync(source.TakeLast(1), cancellation);
#else
            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source, cancellation);
            return inMemoryCollection.LastAsync(cancellation);
#endif
        }

        internal AsyncTypeAwaitable LastAsync(
            Type elementType,
            IQueryable source,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).LastAsync(this, source, cancellation);
        }

        protected virtual ValueTask<TSource> LastAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

#if SUPPORTS_QUERYABLE_TAKE_LAST
            return FirstAsync(source.Where(predicate).TakeLast(1), cancellation);
#else
            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source.Where(predicate), cancellation);
            return inMemoryCollection.LastAsync(cancellation);
#endif
        }

        internal AsyncTypeAwaitable LastAsync(
            Type elementType,
            IQueryable source,
            Expression predicate,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).LastAsync(this, source, predicate, cancellation);
        }

        protected virtual ValueTask<TSource?> LastOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

#if SUPPORTS_QUERYABLE_TAKE_LAST
            return FirstOrDefaultAsync(source.TakeLast(1), cancellation);
#else
            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source, cancellation);
            return inMemoryCollection.LastOrDefaultAsync(cancellation);
#endif
        }

        internal AsyncTypeAwaitable LastOrDefaultAsync(
            Type elementType,
            IQueryable source,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).LastOrDefaultAsync(this, source, cancellation);
        }

        protected virtual ValueTask<TSource?> LastOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

#if SUPPORTS_QUERYABLE_TAKE_LAST
            return FirstOrDefaultAsync(source.Where(predicate).TakeLast(1), cancellation);
#else
            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source.Where(predicate), cancellation);
            return inMemoryCollection.LastOrDefaultAsync(cancellation);
#endif
        }

        internal AsyncTypeAwaitable LastOrDefaultAsync(
            Type elementType,
            IQueryable source,
            Expression predicate,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).LastOrDefaultAsync(this, source, predicate, cancellation);
        }

        protected virtual ValueTask<long> LongCountAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source.Select(p => 1), cancellation);
            return inMemoryCollection.LongCountAsync(cancellation);
        }

        protected virtual ValueTask<long> LongCountAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source.Where(predicate).Select(p => 1), cancellation);
            return inMemoryCollection.LongCountAsync(cancellation);
        }

        protected virtual ValueTask<TSource> MaxAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            // TODO: Is throwing the correct strategy, if there are no elements?
            return FirstAsync(source.OrderByDescending(p => p), cancellation);
        }

        internal AsyncTypeAwaitable MaxAsync(
            Type elementType,
            IQueryable source,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).MaxAsync(this, source, cancellation);
        }

        protected virtual ValueTask<TResult> MaxAsync<TSource, TResult>(
            IQueryable<TSource> source,
            Expression<Func<TSource, TResult>> selector,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            // TODO: Is throwing the correct strategy, if there are no elements?
            return FirstAsync(source.Select(selector).OrderByDescending(p => p), cancellation);
        }

        internal AsyncTypeAwaitable MaxAsync(
            Type elementType,
            Type resultType,
            IQueryable source,
            Expression selector,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            if (resultType is null)
                throw new ArgumentNullException(nameof(resultType));

            return BuildQueryAdapter(elementType, resultType).MaxAsync(this, source, selector, cancellation);
        }

        protected virtual ValueTask<TSource> MinAsync<TSource>(
           IQueryable<TSource> source,
           CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            // TODO: Is throwing the correct strategy, if there are no elements?
            return FirstAsync(source.OrderBy(p => p), cancellation);
        }

        internal AsyncTypeAwaitable MinAsync(
           Type elementType,
           IQueryable source,
           CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).MinAsync(this, source, cancellation);
        }

        protected virtual ValueTask<TResult> MinAsync<TSource, TResult>(
            IQueryable<TSource> source,
            Expression<Func<TSource, TResult>> selector,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            // TODO: Is throwing the correct strategy, if there are no elements?
            return FirstAsync(source.Select(selector).OrderBy(p => p), cancellation);
        }

        internal AsyncTypeAwaitable MinAsync(
            Type elementType,
            Type resultType,
            IQueryable source,
            Expression selector,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            if (resultType is null)
                throw new ArgumentNullException(nameof(resultType));

            return BuildQueryAdapter(elementType, resultType).MinAsync(this, source, selector, cancellation);
        }

        protected virtual ValueTask<bool> SequenceEqualAsync<TSource>(
            IQueryable<TSource> first,
            IAsyncEnumerable<TSource> second,
            CancellationToken cancellation)
        {
            if (first is null)
                throw new ArgumentNullException(nameof(first));

            if (second is null)
                throw new ArgumentNullException(nameof(second));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(first, cancellation);
            return inMemoryCollection.SequenceEqualAsync(second, cancellation);
        }

        protected virtual ValueTask<bool> SequenceEqualAsync<TSource>(
            IQueryable<TSource> first,
            IAsyncEnumerable<TSource> second,
            IEqualityComparer<TSource>? comparer,
            CancellationToken cancellation)
        {
            if (comparer is null)
            {
                return SequenceEqualAsync(first, second, cancellation);
            }

            if (first is null)
                throw new ArgumentNullException(nameof(first));

            if (second is null)
                throw new ArgumentNullException(nameof(second));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(first, cancellation);
            return inMemoryCollection.SequenceEqualAsync(second, comparer, cancellation);
        }

        protected virtual ValueTask<TSource> SingleAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = EvaluateAsync(source.Take(2), cancellation);
            return enumerable.SingleAsync(cancellation);
        }

        internal AsyncTypeAwaitable SingleAsync(
            Type elementType,
            IQueryable source,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).SingleAsync(this, source, cancellation);
        }

        protected virtual ValueTask<TSource> SingleAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = EvaluateAsync(source.Where(predicate).Take(2), cancellation);
            return enumerable.SingleAsync(cancellation);
        }

        internal AsyncTypeAwaitable SingleAsync(
            Type elementType,
            IQueryable source,
            Expression predicate,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).SingleAsync(this, source, predicate, cancellation);
        }

        protected virtual ValueTask<TSource?> SingleOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = EvaluateAsync(source.Take(2), cancellation);
            return enumerable.SingleOrDefaultAsync(cancellation);
        }

        internal AsyncTypeAwaitable SingleOrDefaultAsync(
            Type elementType,
            IQueryable source,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).SingleOrDefaultAsync(this, source, cancellation);
        }

        protected virtual ValueTask<TSource?> SingleOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = EvaluateAsync(source.Where(predicate).Take(2), cancellation);
            return enumerable.SingleOrDefaultAsync(cancellation);
        }

        internal AsyncTypeAwaitable SingleOrDefaultAsync(
            Type elementType,
            IQueryable source,
            Expression predicate,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).SingleOrDefaultAsync(this, source, predicate, cancellation);
        }

        protected virtual ValueTask<TSource> SumAsync<TSource>(
           IQueryable<TSource> source,
           CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var inMemoryCollection = EvaluateAsync(source, cancellation);

            if (typeof(TSource) == typeof(int))
            {
                var result = ((IAsyncEnumerable<int>)inMemoryCollection).SumAsync(cancellation);
                return Unsafe.As<ValueTask<int>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(long))
            {
                var result = ((IAsyncEnumerable<long>)inMemoryCollection).SumAsync(cancellation);
                return Unsafe.As<ValueTask<long>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(float))
            {
                var result = ((IAsyncEnumerable<float>)inMemoryCollection).SumAsync(cancellation);
                return Unsafe.As<ValueTask<float>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(double))
            {
                var result = ((IAsyncEnumerable<double>)inMemoryCollection).SumAsync(cancellation);
                return Unsafe.As<ValueTask<double>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(decimal))
            {
                var result = ((IAsyncEnumerable<decimal>)inMemoryCollection).SumAsync(cancellation);
                return Unsafe.As<ValueTask<decimal>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(int?))
            {
                var result = ((IAsyncEnumerable<int?>)inMemoryCollection).SumAsync(cancellation);
                return Unsafe.As<ValueTask<int?>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(long?))
            {
                var result = ((IAsyncEnumerable<long?>)inMemoryCollection).SumAsync(cancellation);
                return Unsafe.As<ValueTask<long?>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(float?))
            {
                var result = ((IAsyncEnumerable<float?>)inMemoryCollection).SumAsync(cancellation);
                return Unsafe.As<ValueTask<float?>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(double?))
            {
                var result = ((IAsyncEnumerable<double?>)inMemoryCollection).SumAsync(cancellation);
                return Unsafe.As<ValueTask<double?>, ValueTask<TSource>>(ref result);
            }
            else if (typeof(TSource) == typeof(decimal?))
            {
                var result = ((IAsyncEnumerable<decimal?>)inMemoryCollection).SumAsync(cancellation);
                return Unsafe.As<ValueTask<decimal?>, ValueTask<TSource>>(ref result);
            }
            else
            {
                throw new NotSupportedException(); // TODO: Exception message
            }
        }

        internal AsyncTypeAwaitable SumAsync(
            Type elementType,
            IQueryable source,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            return GetQueryAdapter(elementType).SumAsync(this, source, cancellation);
        }

        protected virtual ValueTask<TResult> SumAsync<TSource, TResult>(
            IQueryable<TSource> source,
            Expression<Func<TSource, TResult>> selector,
            CancellationToken cancellation)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            if (!Options.AllowImplicitPostProcessing)
                ThrowHelper.ThrowQueryNotSupportedException();

            var compiledSelector = selector.Compile();
            var inMemoryCollection = EvaluateAsync(source, cancellation);

            if (typeof(TResult) == typeof(int))
            {
                var result = inMemoryCollection.SumAsync(
                    (Func<TSource, int>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<int>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(long))
            {
                var result = inMemoryCollection.SumAsync(
                    (Func<TSource, long>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<long>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(float))
            {
                var result = inMemoryCollection.SumAsync(
                    (Func<TSource, float>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<float>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(double))
            {
                var result = inMemoryCollection.SumAsync(
                    (Func<TSource, double>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<double>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(decimal))
            {
                var result = inMemoryCollection.SumAsync(
                    (Func<TSource, decimal>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<decimal>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(int?))
            {
                var result = inMemoryCollection.SumAsync(
                    (Func<TSource, int?>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<int?>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(long?))
            {
                var result = inMemoryCollection.SumAsync(
                    (Func<TSource, long?>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<long?>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(float?))
            {
                var result = inMemoryCollection.SumAsync(
                    (Func<TSource, float?>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<float?>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(double?))
            {
                var result = inMemoryCollection.SumAsync(
                    (Func<TSource, double?>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<double?>, ValueTask<TResult>>(ref result);
            }
            else if (typeof(TResult) == typeof(decimal?))
            {
                var result = inMemoryCollection.SumAsync(
                    (Func<TSource, decimal?>)(object)compiledSelector,
                    cancellation);
                return Unsafe.As<ValueTask<decimal?>, ValueTask<TResult>>(ref result);
            }
            else
            {
                throw new NotSupportedException(); // TODO: Exception message
            }
        }

        internal AsyncTypeAwaitable SumAsync(
            Type elementType,
            Type resultType,
            IQueryable source,
            Expression selector,
            CancellationToken cancellation)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            if (resultType is null)
                throw new ArgumentNullException(nameof(resultType));

            return BuildQueryAdapter(elementType, resultType).SumAsync(this, source, selector, cancellation);
        }
    }
}
