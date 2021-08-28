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
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using AsyncQueryableAdapter.Translators;
using AsyncQueryableAdapter.Utils;
using Microsoft.Extensions.Options;

namespace AsyncQueryableAdapter
{
    /// <summary>
    /// Represents a LINQ method processor that is responsible for processing a single asynchronous method call by 
    /// either translating it to an equivalent synchronous method call or an implicit post-processing step.
    /// </summary>
    internal class MethodProcessor
    {
        [ThreadStatic]
        private static List<Expression>? _argumentsBuffer;

        private readonly IOptions<AsyncQueryableOptions> _optionsAccessor;
        private readonly IMethodTranslatorBuilder _methodTranslatorBuilder;

        /// <summary>
        /// Creates a new instance of the <see cref="MethodProcessor"/> type with the specified options.
        /// </summary>
        /// <param name="optionsAccessor">
        /// An <see cref="IOptions{AsyncQueryableOptions}"/> instance that is used to access the options configured.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="optionsAccessor"/> is <c>null</c>.
        /// </exception>
        public MethodProcessor(IOptions<AsyncQueryableOptions> optionsAccessor)
        {
            if (optionsAccessor is null)
                throw new ArgumentNullException(nameof(optionsAccessor));

            _optionsAccessor = optionsAccessor;
            _methodTranslatorBuilder = optionsAccessor.Value.MethodTranslators.CreateMethodTranslatorBuilder();
        }

        public Expression ProcessMethod(
            in MethodTranslationContext translationContext)
        {
            var hasNonDefaultTranslator = false;

            // Try to translate the complete method call.
            if (_methodTranslatorBuilder.TryBuildMethodTranslator(translationContext.Method, out var methodTranslator))
            {
                hasNonDefaultTranslator = methodTranslator is not DefaultMethodTranslator;

                if (methodTranslator.TryTranslate(translationContext, out var result))
                {
                    // As per spec:
                    // The <see cref="ConstantExpression"/> returned contains an instance of type TranslatedQueryable
                    // if the translated method is a chain-able method (i.e. the translated method returns 
                    // IAsyncQueryable{T} or IOrderedAsyncQueryable) or a value of exactly the same type as the return
                    // type of the translated method otherwise.
#if DEBUG
                    if (TypeHelper.IsAsyncQueryableType(translationContext.Method.ReturnType, allowNonGeneric: false))
                    {
                        Debug.Assert(result.Value is TranslatedQueryable);
                    }
                    else
                    {
                        if (result.Value is not null)
                        {
                            Debug.Assert(result.Value.GetType() == translationContext.Method.ReturnType);
                        }
                        else
                        {
                            Debug.Assert(translationContext.Method.ReturnType.CanContainNull());
                        }
                    }
#endif

                    return result;
                }
            }

            // We cannot rewrite this, in order to pass this to the database provider. 
            // Evaluate this and add a post-processing step.
            return EvaluateAndPreparePostProcessing(
                translationContext,
                hasNonDefaultTranslator);
        }

        private Expression EvaluateAndPreparePostProcessing(
            in MethodTranslationContext translationContext,
            bool hasNonDefaultTranslator)
        {
            var translatedArguments = _argumentsBuffer ??= new List<Expression>();
            translatedArguments.Clear();
            translatedArguments.AddRange(translationContext.Arguments);

            if (NeedsImplicitPostProcessing(translationContext.Method))
            {
                if (!_optionsAccessor.Value.AllowImplicitPostProcessing)
                {
                    ThrowHelper.ThrowQueryNotSupportedException();
                }

                if (hasNonDefaultTranslator && !_optionsAccessor.Value.AllowImplicitDefaultPostProcessing)
                {
                    ThrowHelper.ThrowQueryNotSupportedException();
                }
            }

            for (var i = 0; i < translationContext.TranslatedQueryableArgumentIndices.Length; i++)
            {
                var argIdx = translationContext.TranslatedQueryableArgumentIndices[i];

                if (!translatedArguments[argIdx].TryEvaluate<TranslatedQueryable>(out var translatedQueryable))
                {
                    throw new Exception(); // TODO
                }

                if (translatedQueryable is null)
                {
                    throw new Exception(); // TODO
                }

                var queryable = translatedQueryable.QueryProvider.CreateQuery(translatedQueryable.Expression);
                IAsyncEnumerable<object?> asyncEnumerable;
                Type elementType;

                if (translatedQueryable is TranslatedGroupByQueryable translatedGroupByQueryable)
                {
                    asyncEnumerable = translatedQueryable.QueryAdapter.EvaluateAsync(
                        translatedGroupByQueryable.GroupingType,
                        queryable,
                        CancellationToken.None); // TODO: Where do we get the cancellation token from?

                    asyncEnumerable = GroupSequenceConverter.Convert(
                        translatedGroupByQueryable.KeyType,
                        translatedGroupByQueryable.ElementType,
                        asyncEnumerable);

                    elementType = translatedGroupByQueryable.AsyncGroupingType;
                }
                else
                {

                    asyncEnumerable = translatedQueryable.QueryAdapter.EvaluateAsync(
                        translatedQueryable.ElementType,
                        queryable,
                        CancellationToken.None); // TODO: Where do we get the cancellation token from?

                    elementType = translatedQueryable.ElementType;
                }

                translatedArguments[argIdx] = Expression.Constant(
                        asyncEnumerable.AsAsyncQueryable(elementType));
            }

            return Expression.Call(translationContext.Instance, translationContext.Method, translatedArguments);
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
