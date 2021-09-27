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
// .NET Runtime
// https://github.com/dotnet/runtime
// The MIT License (MIT)
// 
// Copyright(c).NET Foundation and Contributors
// 
// All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// --------------------------------------------------------------------------------------------------------------------

// The type is loosely based on the ExpressionVisitor type from the dotnet libraries but instead of 
// walking a single tree alone, it walks two trees in parallel, comparing node by node for equality.
// https://github.com/dotnet/runtime/blob/c344d64b05a5530fa3a633a2e993f7bb7ca163fb/src/libraries/System.Linq.Expressions/src/System/Linq/Expressions/ExpressionVisitor.cs

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AsyncQueryableAdapter.Utils
{
#pragma warning disable IDE0065
    using VisitLambdaInvoker = Func<ExpressionEqualityComparer, LambdaExpression, LambdaExpression, bool>;
#pragma warning restore IDE0065

    internal partial class ExpressionEqualityComparer : IEqualityComparer<Expression>
    {
        private static readonly MethodInfo _visitLambdaMethodDefinition
           = typeof(ExpressionEqualityComparer)
           .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
           .Single(p => p.Name == nameof(VisitLambdaInternal));

        private static readonly ConditionalWeakTable<Type, VisitLambdaInvoker> _visitLambdaInvokerCache = new();

        [ThreadStatic]
        private static ParameterExpression[]? _3EntryParameterExpressionBuffer;

        [ThreadStatic]
        private static Type[]? _1EntryTypeBuffer;

        private static VisitLambdaInvoker BuildLambdaInvoker(Type delegateType)
        {
            _1EntryTypeBuffer ??= new Type[1];
            _1EntryTypeBuffer[0] = delegateType;

            var visitLambdaMethod = _visitLambdaMethodDefinition.MakeGenericMethod(_1EntryTypeBuffer);
            var lambdaExpressionType = TypeHelper.GetExpressionType(delegateType);

            var thisParam = Expression.Parameter(typeof(ExpressionEqualityComparer), "@this");
            var xParam = Expression.Parameter(typeof(LambdaExpression), "x");
            var yParam = Expression.Parameter(typeof(LambdaExpression), "y");

            var xConvert = Expression.Convert(xParam, lambdaExpressionType);
            var yConvert = Expression.Convert(yParam, lambdaExpressionType);

            var visitLambdaMethodCall = Expression.Call(thisParam, visitLambdaMethod, xConvert, yConvert);

            _3EntryParameterExpressionBuffer ??= new ParameterExpression[3];
            _3EntryParameterExpressionBuffer[0] = thisParam;
            _3EntryParameterExpressionBuffer[1] = xParam;
            _3EntryParameterExpressionBuffer[2] = yParam;

            var lambda = Expression.Lambda<VisitLambdaInvoker>(visitLambdaMethodCall, _3EntryParameterExpressionBuffer);
            return lambda.Compile();
        }

        private static VisitLambdaInvoker GetLambdaInvoker(Type delegateType)
        {
            return _visitLambdaInvokerCache.GetValue(delegateType, delegateType => BuildLambdaInvoker(delegateType));
        }

        private readonly IEqualityComparer<object> _constantComparer;
        private readonly bool _compareLambdaNames;
        private readonly bool _compareParameterNames;
        private ParameterDictionary? _parameterMapping;

        protected ExpressionEqualityComparer(
            IEqualityComparer<object>? constantComparer,
            bool compareLambdaNames,
            bool compareParameterNames)
        {
            _constantComparer = constantComparer ?? EqualityComparer<object>.Default;
            _compareLambdaNames = compareLambdaNames;
            _compareParameterNames = compareParameterNames;
        }

        public static ExpressionEqualityComparer Create(
            IEqualityComparer<object>? constantComparer = null,
            bool compareLambdaNames = false,
            bool compareParameterNames = false)
        {
            // TODO: Implement caching
            return new ExpressionEqualityComparer(constantComparer, compareLambdaNames, compareParameterNames);
        }

        public virtual bool Equals(Expression? x, Expression? y)
        {
            return Visit(x, y);
        }

        public int GetHashCode(Expression obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            _hashCodeVisitor ??= new HashCodeExpressionVisitor(
                _constantComparer, _compareLambdaNames, _compareParameterNames);

            try
            {
                _ = _hashCodeVisitor.Visit(obj);
                return _hashCodeVisitor.HashCode.ToHashCode();
            }
            finally
            {
                _hashCodeVisitor.Reset();
            }
        }

        private bool Visit(Expression? x, Expression? y)
        {
            if (x is null)
                return y is null;

            if (y is null)
                return false;

            if (x == y)
                return true;

            if (x.NodeType != y.NodeType)
                return false;

            if (x.Type != y.Type)
                return false;

#pragma warning disable IDE0066
            switch (x.NodeType)
#pragma warning restore IDE0066
            {
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.Power:
                    return VisitBinary((BinaryExpression)x, (BinaryExpression)y);

                case ExpressionType.ArrayLength:
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                case ExpressionType.UnaryPlus:
                    return VisitUnary((UnaryExpression)x, (UnaryExpression)y);

                case ExpressionType.Call:
                    return VisitMethodCall((MethodCallExpression)x, (MethodCallExpression)y);

                case ExpressionType.Conditional:
                    return VisitConditional((ConditionalExpression)x, (ConditionalExpression)y);

                case ExpressionType.Constant:
                    return VisitConstant((ConstantExpression)x, (ConstantExpression)y);

                case ExpressionType.Invoke:
                    return VisitInvocation((InvocationExpression)x, (InvocationExpression)y);

                case ExpressionType.Lambda:
                    return VisitLambda((LambdaExpression)x, (LambdaExpression)y);

                case ExpressionType.ListInit:
                    return VisitListInit((ListInitExpression)x, (ListInitExpression)y);

                case ExpressionType.MemberAccess:
                    return VisitMember((MemberExpression)x, (MemberExpression)y);

                case ExpressionType.MemberInit:
                    return VisitMemberInit((MemberInitExpression)x, (MemberInitExpression)y);

                case ExpressionType.New:
                    return VisitNew((NewExpression)x, (NewExpression)y);

                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return VisitNewArray((NewArrayExpression)x, (NewArrayExpression)y);

                case ExpressionType.Parameter:
                    return VisitParameter((ParameterExpression)x, (ParameterExpression)y);

                case ExpressionType.TypeIs:
                    return VisitTypeBinary((TypeBinaryExpression)x, (TypeBinaryExpression)y);

                case ExpressionType.Dynamic:
                    return VisitDynamic((DynamicExpression)x, (DynamicExpression)y);

                case ExpressionType.Default:
                    return VisitDefault((DefaultExpression)x, (DefaultExpression)y);

                case ExpressionType.Assign:
                case ExpressionType.Block:
                case ExpressionType.DebugInfo:
                case ExpressionType.Decrement:
                case ExpressionType.Extension:
                case ExpressionType.Goto:
                case ExpressionType.Increment:
                case ExpressionType.Index:
                case ExpressionType.Label:
                case ExpressionType.RuntimeVariables:
                case ExpressionType.Loop:
                case ExpressionType.Switch:
                case ExpressionType.Throw:
                case ExpressionType.Try:
                case ExpressionType.Unbox:
                case ExpressionType.AddAssign:
                case ExpressionType.AndAssign:
                case ExpressionType.DivideAssign:
                case ExpressionType.ExclusiveOrAssign:
                case ExpressionType.LeftShiftAssign:
                case ExpressionType.ModuloAssign:
                case ExpressionType.MultiplyAssign:
                case ExpressionType.OrAssign:
                case ExpressionType.PowerAssign:
                case ExpressionType.RightShiftAssign:
                case ExpressionType.SubtractAssign:
                case ExpressionType.AddAssignChecked:
                case ExpressionType.MultiplyAssignChecked:
                case ExpressionType.SubtractAssignChecked:
                case ExpressionType.PreIncrementAssign:
                case ExpressionType.PreDecrementAssign:
                case ExpressionType.PostIncrementAssign:
                case ExpressionType.PostDecrementAssign:
                case ExpressionType.TypeEqual:
                case ExpressionType.OnesComplement:
                case ExpressionType.IsTrue:
                case ExpressionType.IsFalse:
                default:
                    throw new ArgumentException($"Unknown expression of type {x.NodeType}");
            }
        }
        private static bool Visit<T>(ReadOnlyCollection<T> x, ReadOnlyCollection<T> y, Func<T, T, bool> comparer)
        {
            if (x == y)
                return true;

            if (x.Count != y.Count)
                return false;

            for (var i = 0; i < x.Count; i++)
            {
                if (!comparer(x[i], y[i]))
                    return false;
            }

            return true;
        }

        private static bool VisitMembers(ReadOnlyCollection<MemberInfo>? x, ReadOnlyCollection<MemberInfo>? y)
        {
            if (x is null || x.Count is 0)
                return y is null || y.Count is 0;

            if (y is null || y.Count is 0)
                return false;

            return Visit(x, y, (x, y) => x == y);
        }

        protected virtual bool VisitBinding(MemberBinding x, MemberBinding y)
        {
            if (x == y)
                return true;

            if (x.BindingType != y.BindingType)
            {
                return false;
            }

            if (x.Member != y.Member)
            {
                return false;
            }

#pragma warning disable IDE0066
            switch (x.BindingType)
#pragma warning restore IDE0066
            {
                case MemberBindingType.Assignment:
                    return VisitMemberAssignment((MemberAssignment)x, (MemberAssignment)y);
                case MemberBindingType.MemberBinding:
                    return VisitMemberMemberBinding((MemberMemberBinding)x, (MemberMemberBinding)y);
                case MemberBindingType.ListBinding:
                    return VisitMemberListBinding((MemberListBinding)x, (MemberListBinding)y);
                default:
                    throw new ArgumentException($"Unknown member binding {x.BindingType}");
            }
        }

        protected virtual bool VisitMemberAssignment(MemberAssignment x, MemberAssignment y)
        {
            if (x.Member != y.Member)
            {
                return false;
            }

            return Visit(x.Expression, y.Expression);
        }

        protected virtual bool VisitMemberMemberBinding(MemberMemberBinding x, MemberMemberBinding y)
        {
            if (x.Member != y.Member)
            {
                return false;
            }

            return Visit(x.Bindings, y.Bindings, VisitBinding);
        }

        protected virtual bool VisitMemberListBinding(MemberListBinding x, MemberListBinding y)
        {
            if (x.Member != y.Member)
            {
                return false;
            }

            return Visit(x.Initializers, y.Initializers, VisitElementInit);
        }

        protected virtual bool VisitElementInit(ElementInit x, ElementInit y)
        {
            if (x == y)
                return true;

            if (x.AddMethod != y.AddMethod)
            {
                return false;
            }

            return Visit(x.Arguments, y.Arguments, Visit);
        }

        protected virtual bool VisitBinary(BinaryExpression x, BinaryExpression y)
        {
            // TODO: Compare CanReduce, Conversion?

            if (x.IsLifted != y.IsLifted)
            {
                return false;
            }

            if (x.IsLiftedToNull != y.IsLiftedToNull)
            {
                return false;
            }

            // TODO: The node type already contains the information about the method!
            if (x.Method != y.Method)
            {
                return false;
            }

            return Visit(x.Left, y.Left) && Visit(x.Right, y.Right);
        }

        protected virtual bool VisitBlock(BlockExpression x, BlockExpression y)
        {
            throw new NotImplementedException();
        }

        protected virtual bool VisitConditional(ConditionalExpression x, ConditionalExpression y)
        {
            return Visit(x.Test, y.Test)
                && Visit(x.IfTrue, y.IfTrue)
                && Visit(x.IfFalse, y.IfFalse);
        }

        protected virtual bool VisitConstant(ConstantExpression x, ConstantExpression y)
        {
            return _constantComparer.Equals(x.Value, y.Value);
        }

        protected virtual bool VisitDebugInfo(DebugInfoExpression x, DebugInfoExpression y)
        {
            throw new NotImplementedException();
        }

        protected virtual bool VisitDefault(DefaultExpression x, DefaultExpression y)
        {
            throw new NotImplementedException();
        }

        protected virtual bool VisitExtension(Expression x, Expression y)
        {
            throw new NotImplementedException();
        }

        protected virtual bool VisitGoto(GotoExpression x, GotoExpression y)
        {
            throw new NotImplementedException();
        }

        protected virtual bool VisitInvocation(InvocationExpression x, InvocationExpression y)
        {
            return Visit(x.Expression, y.Expression)
                && Visit(x.Arguments, y.Arguments, Visit);
        }

        protected virtual bool VisitLabel(LabelExpression x, LabelExpression y)
        {
            throw new NotImplementedException();
        }

        private bool VisitLambda(LambdaExpression x, LambdaExpression y)
        {
            var xDelegateType = GetDelegateType(x);
            var yDelegateType = GetDelegateType(y);

            if (xDelegateType != yDelegateType)
            {
                return false;
            }

            var invoker = GetLambdaInvoker(xDelegateType);
            return invoker(this, x, y);
        }

        private static Type GetDelegateType(LambdaExpression lambda)
        {
            var lambdaType = lambda.GetType();

            if (!TypeHelper.IsLambdaExpression(lambdaType, out var delegateType))
            {
                delegateType = typeof(Delegate);
            }

            return delegateType;
        }

        // This is called via reflection and is here such that the virtual dispatch works correctly.
        private bool VisitLambdaInternal<T>(Expression<T> x, Expression<T> y)
            where T : Delegate
        {
            return VisitLambda(x, y);
        }

        protected virtual bool VisitLambda<T>(Expression<T> x, Expression<T> y)
            where T : Delegate
        {
            // TODO: The delegate type is already checked
            if (x.ReturnType != y.ReturnType)
            {
                return false;
            }

            if (x.TailCall != y.TailCall)
            {
                return false;
            }

            if (_compareLambdaNames && x.Name != y.Name)
            {
                return false;
            }

            var xParameters = x.Parameters;
            var yParameters = y.Parameters;

            // TODO: The delegate type is already checked, which includes the parameter count and types
            if (xParameters.Count != yParameters.Count)
            {
                return false;
            }

            for (var i = 0; i < xParameters.Count; i++)
            {
                if (xParameters[i].Type != yParameters[i].Type)
                {
                    return false;
                }
            }

            var parameterMapping = _parameterMapping;
            _parameterMapping = new ParameterDictionary(parameterMapping);

            try
            {
                for (var i = 0; i < xParameters.Count; i++)
                {
                    _parameterMapping.Add(xParameters[i], yParameters[i]);
                }

                return Visit(x.Body, y.Body);
            }
            finally
            {
                _parameterMapping = parameterMapping;
            }
        }

        protected virtual bool VisitLoop(LoopExpression x, LoopExpression y)
        {
            throw new NotImplementedException();
        }

        protected virtual bool VisitMember(MemberExpression x, MemberExpression y)
        {
            if (x.Member != y.Member)
            {
                return false;
            }

            return Visit(x.Expression, y.Expression);
        }

        protected virtual bool VisitIndex(IndexExpression x, IndexExpression y)
        {
            throw new NotImplementedException();
        }

        protected virtual bool VisitMethodCall(MethodCallExpression x, MethodCallExpression y)
        {
            if (x.Method != y.Method)
            {
                return false;
            }

            return Visit(x.Object, y.Object)
                && Visit(x.Arguments, y.Arguments, Visit);
        }

        protected virtual bool VisitNewArray(NewArrayExpression x, NewArrayExpression y)
        {
            return Visit(x.Expressions, y.Expressions, Visit);
        }

#pragma warning disable CA1711
        protected virtual bool VisitNew(NewExpression x, NewExpression y)
#pragma warning restore CA1711
        {
            if (x.Constructor != y.Constructor)
            {
                return false;
            }

            return Visit(x.Arguments, y.Arguments, Visit)
                && VisitMembers(x.Members, y.Members);
        }

        protected virtual bool VisitParameter(ParameterExpression x, ParameterExpression y)
        {
            // TODO: If parameters are compared outside a lambda, they are never equal, except for the same instance,
            // otherwise the lambda already checks for the delegate type, which includes the ref-ness of the params.
            if (x.IsByRef != y.IsByRef)
            {
                return false;
            }

            if (_compareParameterNames && x.Name != y.Name)
            {
                return false;
            }

            if (_parameterMapping is not null)
            {
                if (_parameterMapping.TryGetValue(x, out var expectedY))
                {
                    x = expectedY;
                }
            }

            return x == y;
        }

        protected virtual bool VisitRuntimeVariables(RuntimeVariablesExpression x, RuntimeVariablesExpression y)
        {
            throw new NotImplementedException();
        }

        protected virtual bool VisitSwitch(SwitchExpression x, SwitchExpression y)
        {
            throw new NotImplementedException();
        }

        protected virtual bool VisitTry(TryExpression x, TryExpression y)
        {
            throw new NotImplementedException();
        }

        protected virtual bool VisitTypeBinary(TypeBinaryExpression x, TypeBinaryExpression y)
        {
            if (x.TypeOperand != y.TypeOperand)
            {
                return false;
            }

            return Visit(x.Expression, y.Expression);
        }

        protected virtual bool VisitUnary(UnaryExpression x, UnaryExpression y)
        {
            if (x.IsLifted != y.IsLifted)
            {
                return false;
            }

            if (x.IsLiftedToNull != y.IsLiftedToNull)
            {
                return false;
            }

            // TODO: The node type already contains the information about the method!
            if (x.Method != y.Method)
            {
                return false;
            }

            return Visit(x.Operand, y.Operand);
        }

        protected virtual bool VisitMemberInit(MemberInitExpression x, MemberInitExpression y)
        {
            return (x.NewExpression == y.NewExpression || VisitNew(x.NewExpression, y.NewExpression))
                && Visit(x.Bindings, y.Bindings, VisitBinding);
        }

        protected virtual bool VisitListInit(ListInitExpression x, ListInitExpression y)
        {
            return (x.NewExpression == y.NewExpression || VisitNew(x.NewExpression, y.NewExpression))
                && Visit(x.Initializers, y.Initializers, VisitElementInit);
        }

        protected virtual bool VisitDynamic(DynamicExpression x, DynamicExpression y)
        {
            throw new NotImplementedException();
        }
    }
}
