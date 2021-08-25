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
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using AsyncQueryableAdapter.Translators;
using AsyncQueryableAdapter.Utils;
using Microsoft.Extensions.Options;

namespace AsyncQueryableAdapter
{
    // TODO: Rename
    internal class MethodProcessor
    {
        [ThreadStatic]
        private static List<Expression>? _argumentsBuffer;

        private readonly IOptions<AsyncQueryableOptions> _options;
        private readonly IMethodTranslatorBuilder _methodTranslatorBuilder;

        public MethodProcessor(IOptions<AsyncQueryableOptions> options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            _options = options;
            _methodTranslatorBuilder = options.Value.MethodTranslators.CreateMethodTranslatorBuilder();
        }

        public Expression ProcessMethod(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            ReadOnlySpan<int> translatedQueryableArgumentIndices)
        {
            var hasNonDefaultTranslator = false;

            // Try to translate the complete method call.
            if (_methodTranslatorBuilder.TryBuildMethodTranslator(method, out var methodTranslator))
            {
                hasNonDefaultTranslator = methodTranslator is not DefaultMethodTranslator;

                if (methodTranslator.TryTranslate(method, instance, arguments, translatedQueryableArgumentIndices, out var result))
                {
                    return result;
                }
            }

            // We cannot rewrite this, in order to pass this to the database provider. 
            // Evaluate this and add a post-processing step.
            return EvaluateAndPreparePostProcessing(
                method,
                instance,
                arguments,
                translatedQueryableArgumentIndices,
                hasNonDefaultTranslator);
        }

        private Expression EvaluateAndPreparePostProcessing(
            MethodInfo method,
            Expression? instance,
            ReadOnlyCollection<Expression> arguments,
            in ReadOnlySpan<int> queryableTranslationsIndices,
            bool hasNonDefaultTranslator)
        {
            var translatedArguments = _argumentsBuffer ??= new List<Expression>();
            translatedArguments.Clear();
            translatedArguments.AddRange(arguments);

            if (NeedsImplicitPostProcessing(method))
            {
                if (!_options.Value.AllowImplicitPostProcessing)
                {
                    ThrowHelper.ThrowQueryNotSupportedException();
                }

                if (hasNonDefaultTranslator && !_options.Value.AllowImplicitDefaultPostProcessing)
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
