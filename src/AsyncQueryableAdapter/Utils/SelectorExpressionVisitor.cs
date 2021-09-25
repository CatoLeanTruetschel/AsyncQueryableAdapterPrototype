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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter
{
    // TODO: Pool me pls
    internal sealed class SelectorExpressionVisitor : ExpressionVisitor
    {
        private const string VALUE_TASK_FROM_RESULT_METHOD_NAME = "FromResult";

        private static readonly MethodInfo? VALUE_TASK_FROM_RESULT_METHOD_DEFINITION
            = GetValueTaskFromResultMethodDefintion();

        private static MethodInfo? GetValueTaskFromResultMethodDefintion()
        {
            var methods = typeof(ValueTask).GetMethods(BindingFlags.Public | BindingFlags.Static);

            for (var i = 0; i < methods.Length; i++)
            {
                ref var method = ref methods[i];

                if (!method.Name.Equals(VALUE_TASK_FROM_RESULT_METHOD_NAME, StringComparison.Ordinal))
                    continue;

                if (!method.IsGenericMethodDefinition)
                    continue;

                var genericArguments = method.GetGenericArguments();

                if (genericArguments.Length is not 1)
                    continue;

                var parameters = method.GetParameters();

                if (parameters.Length is not 1)
                    continue;

                if (parameters[0].ParameterType != genericArguments[0])
                    continue;

                var returnType = method.ReturnType;

                if (!returnType.IsGenericType)
                    continue;

                if (returnType.GetGenericTypeDefinition() != typeof(ValueTask<>))
                    continue;

                var returnTypeGenericArguments = returnType.GetGenericArguments();

                if (returnTypeGenericArguments[0] != genericArguments[0])
                    continue;

                return method;
            }

            return null;
        }

        private static readonly ConditionalWeakTable<Type, ValueTaskMethodCacheEntry> _valueTaskMethodsCache = new();
        private static readonly ConditionalWeakTable<Type, ValueTaskMethodCacheEntry>.CreateValueCallback _buildValueTaskMethodCacheEntry
            = BuildValueTaskMethodCacheEntry;

        private static ValueTaskMethodCacheEntry BuildValueTaskMethodCacheEntry(Type type)
        {
            return new ValueTaskMethodCacheEntry(type);
        }

        private static ValueTaskMethodCacheEntry GetValueTaskMethodCacheEntry(Type type)
        {
            return _valueTaskMethodsCache.GetValue(type, _buildValueTaskMethodCacheEntry);
        }

        private readonly Type _targetType;
        private bool _allowTranslateCurrent = true;
        private bool _allowTranslate = true;

        private HashSet<ParameterExpression>? _parameters;

        // TODO: This is required to be ordered!
        public ISet<ParameterExpression> Parameters
            => _parameters ?? (ISet<ParameterExpression>)ImmutableHashSet<ParameterExpression>.Empty;

        public SelectorExpressionVisitor(Type targetType)
        {
            _targetType = targetType;
        }

        [return: NotNullIfNotNull("node")]
        public override Expression? Visit(Expression? node)
        {
            if (node is not null)
            {
                // Set allow translate to false when descending by default
                var allowTranslateCurrent = _allowTranslateCurrent;
                var allowTranslate = _allowTranslate;
                _allowTranslateCurrent = false;
                _allowTranslate = allowTranslate & allowTranslateCurrent;

                node = base.Visit(node);

                // Reset allow translate to the original value
                _allowTranslateCurrent = allowTranslateCurrent;
                _allowTranslate = allowTranslate;
            }

            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            _parameters ??= new HashSet<ParameterExpression>();
            _parameters.Add(node);
            return base.VisitParameter(node);
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Quote)
            {
                _allowTranslateCurrent = true;
                return base.VisitUnary(node);
            }

            return base.VisitUnary(node);
        }

        protected override Expression VisitNew(NewExpression node)
        {
            if (_allowTranslate && TryTranslateValueTaskConstruction(node, out var result))
            {
                return result;
            }

            return base.VisitNew(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (_allowTranslate && TryTranslateValueTaskFactoryMethodCall(node, out var result))
            {
                return result;
            }

            return base.VisitMethodCall(node);
        }

        protected override Expression VisitConditional(ConditionalExpression node)
        {
            if (_allowTranslate)
            {
                var test = node.Test;
                test = ExpressionOptimizer.visit(test);
                test = Visit(test);

                _allowTranslateCurrent = true;

                if (test.Unquote() is not ConstantExpression constantExpression)
                {
                    var ifTrue = Visit(node.IfTrue);
                    var ifFalse = Visit(node.IfFalse);

                    if (ifTrue.Type == _targetType && ifFalse.Type == _targetType)
                    {
                        return Expression.Condition(test, ifTrue, ifFalse);
                    }
                }

                // Tree shaking: If the condition is constant, we only need to evaluate one path.
                else if ((bool)constantExpression.Value!)
                {
                    var ifTrue = Visit(node.IfTrue);

                    if (ifTrue.Type == _targetType)
                    {
                        return ifTrue;
                    }
                }
                else
                {
                    var ifFalse = Visit(node.IfFalse);

                    if (ifFalse.Type == _targetType)
                    {
                        return ifFalse;
                    }
                }
            }

            _allowTranslateCurrent = false;
            return base.VisitConditional(node);
        }

        private bool TryTranslateValueTaskConstruction(
          NewExpression node,
          [NotNullWhen(true)] out Expression? result)
        {
            result = null;

            var methodsCacheEntry = GetValueTaskMethodCacheEntry(_targetType);
            var ctor = methodsCacheEntry.ValueTaskFromResultConstructor;

            if (node.Constructor != ctor)
                return false;

            Debug.Assert(node.Arguments.Count is 1);
            Debug.Assert(node.Arguments.First().Type == _targetType);

            result = Visit(node.Arguments.First());
            return true;
        }

        private bool TryTranslateValueTaskFactoryMethodCall(
            MethodCallExpression node,
            [NotNullWhen(true)] out Expression? result)
        {
            result = null;

            if (VALUE_TASK_FROM_RESULT_METHOD_DEFINITION is null)
                return false;

            var methodsCacheEntry = GetValueTaskMethodCacheEntry(_targetType);
            var factoryMethod = methodsCacheEntry.ValueTaskFromResultMethod;

            if (node.Method != factoryMethod)
                return false;

            Debug.Assert(node.Arguments.Count is 1);
            Debug.Assert(node.Arguments.First().Type == _targetType);

            result = Visit(node.Arguments.First());
            return true;
        }

        private sealed class ValueTaskMethodCacheEntry
        {
            public MethodInfo? ValueTaskFromResultMethod { get; }
            public ConstructorInfo ValueTaskFromResultConstructor { get; }

            public ValueTaskMethodCacheEntry(Type type)
            {
                Debug.Assert(type is not null);

                if (VALUE_TASK_FROM_RESULT_METHOD_DEFINITION is not null)
                    ValueTaskFromResultMethod = VALUE_TASK_FROM_RESULT_METHOD_DEFINITION.MakeGenericMethod(type);

                var valueTaskFromResultConstructor = TypeHelper.GetValueTaskType(type).GetConstructor(type);

                Debug.Assert(valueTaskFromResultConstructor is not null);
                ValueTaskFromResultConstructor = valueTaskFromResultConstructor;
            }
        }
    }
}
