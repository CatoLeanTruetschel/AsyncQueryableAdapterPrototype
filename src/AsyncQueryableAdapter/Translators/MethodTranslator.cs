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

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal abstract class MethodTranslator
    {
        public abstract bool TryTranslate(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            [NotNullWhen(true)] out Expression? result);

        [ThreadStatic]
        private static List<Expression>? _argumentsBuffer;

        private static readonly DefaultTranslator _defaultTranslator = new();
        private static readonly AggregateMethodTranslator _aggregateMethodTranslator = new();
        private static readonly AllMethodTranslator _allMethodTranslator = new();
        private static readonly AnyMethodTranslator _anyMethodTranslator = new();
        private static readonly AverageMethodTranslator _averageMethodTranslator = new();
        private static readonly ContainsMethodTranslator _containsMethodTranslator = new();
        private static readonly CountMethodTranslator _countMethodTranslator = new();
        private static readonly ElementAtMethodTranslator _elementAtMethodTranslator = new();
        private static readonly FirstMethodTranslator _firstMethodTranslator = new();
        private static readonly GroupByMethodTranslator _groupByMethodTranslator = new();
        private static readonly LastMethodTranslator _lastMethodTranslator = new();
        private static readonly LongCountMethodTranslator _longCountMethodTranslator = new();
        private static readonly MaxMethodTranslator _maxMethodTranslator = new();
        private static readonly MinMethodTranslator _minMethodTranslator = new();
        private static readonly SequenceEqualMethodTranslator _sequenceEqualMethodTranslator = new();
        private static readonly SingleMethodTranslator _singleMethodTranslator = new();
        private static readonly SumMethodTranslator _sumMethodTranslator = new();

        private static readonly ImmutableDictionary<string, MethodTranslator> _translators
            = new Dictionary<string, MethodTranslator>()
            {
                [nameof(System.Linq.AsyncQueryable.AggregateAsync)] = _aggregateMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AggregateAwaitAsync)] = _aggregateMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AggregateAwaitWithCancellationAsync)] = _aggregateMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AllAsync)] = _allMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AllAwaitAsync)] = _allMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AllAwaitWithCancellationAsync)] = _allMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AnyAsync)] = _anyMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AnyAwaitAsync)] = _anyMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AnyAwaitWithCancellationAsync)] = _anyMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AverageAsync)] = _averageMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AverageAwaitAsync)] = _averageMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.AverageAwaitWithCancellationAsync)] = _averageMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.ContainsAsync)] = _containsMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.CountAsync)] = _countMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.CountAwaitAsync)] = _countMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.CountAwaitWithCancellationAsync)] = _countMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.ElementAtAsync)] = _elementAtMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.ElementAtOrDefaultAsync)] = _elementAtMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.FirstAsync)] = _firstMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.FirstAwaitAsync)] = _firstMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.FirstAwaitWithCancellationAsync)] = _firstMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.FirstOrDefaultAsync)] = _firstMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.FirstOrDefaultAwaitAsync)] = _firstMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.FirstOrDefaultAwaitWithCancellationAsync)] = _firstMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.GroupBy)] = _groupByMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.GroupByAwait)] = _groupByMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.GroupByAwaitWithCancellation)] = _groupByMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.LastAsync)] = _lastMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.LastAwaitAsync)] = _lastMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.LastAwaitWithCancellationAsync)] = _lastMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.LastOrDefaultAsync)] = _lastMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.LastOrDefaultAwaitAsync)] = _lastMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.LastOrDefaultAwaitWithCancellationAsync)] = _lastMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.LongCountAsync)] = _longCountMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.LongCountAwaitAsync)] = _longCountMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.LongCountAwaitWithCancellationAsync)] = _longCountMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.MaxAsync)] = _maxMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.MaxAwaitAsync)] = _maxMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.MaxAwaitWithCancellationAsync)] = _maxMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.MinAsync)] = _minMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.MinAwaitAsync)] = _minMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.MinAwaitWithCancellationAsync)] = _minMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.SequenceEqualAsync)] = _sequenceEqualMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.SingleAsync)] = _singleMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.SingleAwaitAsync)] = _singleMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.SingleAwaitWithCancellationAsync)] = _singleMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.SingleOrDefaultAsync)] = _singleMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.SingleOrDefaultAwaitAsync)] = _singleMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.SingleOrDefaultAwaitWithCancellationAsync)] = _singleMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.SumAsync)] = _sumMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.SumAwaitAsync)] = _sumMethodTranslator,
                [nameof(System.Linq.AsyncQueryable.SumAwaitWithCancellationAsync)] = _sumMethodTranslator,

            }.ToImmutableDictionary(StringComparer.Ordinal);

        public static Expression TranslateMethod(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices,
            in AsyncQueryableOptions options)
        {
            // Try to translate the complete method call.
            var translator = GetTranslator(method);

            if (translator.TryTranslate(method, instance, arguments, translatedQueryableArgumentIndices, out var result))
            {
                return result;
            }

            // We cannot rewrite this, in order to pass this to the database provider. 
            // Evaluate this and add a post-processing step.
            return EvaluateAndPreparePostProcessing(
                method,
                instance,
                arguments,
                translatedQueryableArgumentIndices,
                options,
                hasSpecializedTranslator: translator is not DefaultTranslator);
        }

        private static MethodTranslator GetTranslator(MethodInfo method)
        {
            if (!_translators.TryGetValue(method.Name, out var translator))
            {
                translator = _defaultTranslator;
            }

            return translator;
        }

        private static Expression EvaluateAndPreparePostProcessing(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            in ReadOnlySpan<int> queryableTranslationsIndices,
            in AsyncQueryableOptions options,
            bool hasSpecializedTranslator)
        {
            var translatedArguments = _argumentsBuffer ??= new List<Expression>();
            translatedArguments.Clear();
            translatedArguments.AddRange(arguments);

            if (NeedsImplicitPostProcessing(method))
            {
                if (!options.AllowImplicitPostProcessing)
                {
                    ThrowHelper.ThrowQueryNotSupportedException();
                }

                if (hasSpecializedTranslator && !options.AllowImplicitDefaultPostProcessing)
                {
                    ThrowHelper.ThrowQueryNotSupportedException();
                }
            }

            for (var i = 0; i < queryableTranslationsIndices.Length; i++)
            {
                if (!translatedArguments[i].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                {
                    throw new Exception(); // TODO
                }

                if (translatedQueryable is null)
                {
                    throw new Exception(); // TODO
                }

                var queryable = translatedQueryable.QueryProvider.CreateQuery(translatedQueryable.Expression);
                var asyncEnumerable = translatedQueryable.QueryAdapter.EvaluateAsync(
                    translatedQueryable.ElementType,
                    queryable,
                    CancellationToken.None); // TODO: Where do we get the cancellation token from?

                translatedArguments[i] = Expression.Constant(
                    asyncEnumerable.AsAsyncQueryable(translatedQueryable.ElementType));
            }

            return Expression.Call(instance, method, translatedArguments);
        }

        private static bool NeedsImplicitPostProcessing(MethodInfo method)
        {
            // Everything that returns IAsyncQueryable, like Select, Where, OrderBy, etc. need post-processing,
            // if not translatable.
            if (method.ReturnType.IsAssignableTo<IAsyncQueryable>())
                return true;

            // Conversion methods do not need implicit post-processing, because the transferal of entries
            // from the database to the main-memory is made explicit via .ToXYZAsync() calls.

            // There is no conscious way of actually detecting whether a method is a conversion method other then
            // listing all available conversion method. This approach is not very future proof, if the 
            // System.Linq.AsyncQueryable type gets added new conversion operations.

            // We implement this by detecting a pattern in the method names. The methods are named To[ResultType]Async
            // Which makes it clear in the API call that this is not an implicit copy-all instruction.
            if (method.Name.StartsWith("To", StringComparison.Ordinal)
             && method.Name.EndsWith("Async", StringComparison.Ordinal))
            {
                return false;
            }

            return true;
        }
    }
}
