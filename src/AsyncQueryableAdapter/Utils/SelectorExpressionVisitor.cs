﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncQueryableAdapter.Utils
{
    // TODO: Pool me pls
    internal sealed class SelectorExpressionVisitor : ExpressionVisitor
    {
        [ThreadStatic]
        private static Type[]? _1EntryTypeBuffer;

        const string VALUE_TASK_FROM_RESULT_METHOD_NAME = "FromResult";

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
            if (_allowTranslate && TryTranslateValueTaskFactorMethodCall(node, out var result))
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

                // Tree shaking: If the condition is constant, we only needs to evaluate one path.
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

        private bool TryTranslateValueTaskFactorMethodCall(
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

                _1EntryTypeBuffer ??= new Type[1];
                _1EntryTypeBuffer[0] = type;

                var valueTaskFromResultConstructor = typeof(ValueTask<>)
                    .MakeGenericType(_1EntryTypeBuffer)
                    .GetConstructor(_1EntryTypeBuffer);

                Debug.Assert(valueTaskFromResultConstructor is not null);
                ValueTaskFromResultConstructor = valueTaskFromResultConstructor;
            }
        }
    }
}
