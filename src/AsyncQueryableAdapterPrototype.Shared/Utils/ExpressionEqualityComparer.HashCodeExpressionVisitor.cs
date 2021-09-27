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
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace AsyncQueryableAdapter.Utils
{
    internal partial class ExpressionEqualityComparer
    {
        [ThreadStatic]
        private static HashCodeExpressionVisitor? _hashCodeVisitor;

        private sealed class HashCodeExpressionVisitor : ExpressionVisitor
        {
            private readonly IEqualityComparer<object> _constantComparer;
            private readonly bool _compareLambdaNames;
            private readonly bool _compareParameterNames;

            private HashCode _hashCode;

            public HashCode HashCode => _hashCode;

            public HashCodeExpressionVisitor(
                IEqualityComparer<object> constantComparer,
                bool compareLambdaNames,
                bool compareParameterNames)
            {
                _constantComparer = constantComparer;
                _compareLambdaNames = compareLambdaNames;
                _compareParameterNames = compareParameterNames;
            }

            public void Reset()
            {
                _hashCode = default;
            }

            [return: NotNullIfNotNull("node")]
            public override Expression? Visit(Expression? node)
            {
                node = base.Visit(node);

                // TODO: Add some special const code for null expressions?
                if (node is not null)
                {
                    _hashCode.Add(node.NodeType);
                    _hashCode.Add(node.Type);
                }

                return node;
            }

            protected override MemberBinding VisitMemberBinding(MemberBinding node)
            {
                _hashCode.Add(node.BindingType);
                _hashCode.Add(node.Member);

                return base.VisitMemberBinding(node);
            }

            protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
            {
                _hashCode.Add(node.Member);

                return base.VisitMemberAssignment(node);
            }

            protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
            {
                _hashCode.Add(node.Member);
                _hashCode.Add(node.Bindings.Count);

                return base.VisitMemberMemberBinding(node);
            }

            protected override MemberListBinding VisitMemberListBinding(MemberListBinding node)
            {
                _hashCode.Add(node.Member);
                _hashCode.Add(node.Initializers.Count);

                return base.VisitMemberListBinding(node);
            }

            protected override ElementInit VisitElementInit(ElementInit node)
            {
                _hashCode.Add(node.AddMethod);
                _hashCode.Add(node.Arguments.Count);

                return base.VisitElementInit(node);
            }

            protected override Expression VisitBinary(BinaryExpression node)
            {
                // TODO: Compare CanReduce, Conversion?

                _hashCode.Add(node.IsLifted);
                _hashCode.Add(node.IsLiftedToNull);
                _hashCode.Add(node.Method);

                // TODO: This includes conversion, but the EqualityComparer does not!
                if (node.Conversion is not null)
                {
                    _hashCode.Add(node.Conversion);
                }

                return base.VisitBinary(node);
            }

            protected override Expression VisitBlock(BlockExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitConstant(ConstantExpression node)
            {
                if (node.Value is not null)
                {
                    _hashCode.Add(node.Value, _constantComparer);
                }

                return base.VisitConstant(node);
            }

            protected override Expression VisitDebugInfo(DebugInfoExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitDefault(DefaultExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitExtension(Expression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitGoto(GotoExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitInvocation(InvocationExpression node)
            {
                _hashCode.Add(node.Arguments.Count);

                return base.VisitInvocation(node);
            }

            protected override Expression VisitLabel(LabelExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                var delegateType = typeof(T);

                _hashCode.Add(delegateType);
                _hashCode.Add(node.ReturnType);
                _hashCode.Add(node.TailCall);

                if (_compareLambdaNames)
                {
                    _hashCode.Add(node.Name);
                }

                _hashCode.Add(node.Parameters.Count);

                return base.VisitLambda(node);
            }

            protected override Expression VisitLoop(LoopExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                _hashCode.Add(node.Member);

                return base.VisitMember(node);
            }

            protected override Expression VisitIndex(IndexExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                _hashCode.Add(node.Method);
                _hashCode.Add(node.Arguments.Count);

                return base.VisitMethodCall(node);
            }

            protected override Expression VisitNewArray(NewArrayExpression node)
            {
                _hashCode.Add(node.Expressions.Count);

                return base.VisitNewArray(node);
            }

            protected override Expression VisitNew(NewExpression node)
            {
                _hashCode.Add(node.Constructor);
                _hashCode.Add(node.Arguments.Count);
                _hashCode.Add(node.Members?.Count ?? 0);

                if (node.Members is not null)
                {
                    for (var i = 0; i < node.Members.Count; i++)
                    {
                        _hashCode.Add(node.Members[i]);
                    }
                }

                return base.VisitNew(node);
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                _hashCode.Add(node.IsByRef);

                if (_compareParameterNames)
                {
                    _hashCode.Add(node.Name);
                }

                return base.VisitParameter(node);
            }

            protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitSwitch(SwitchExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitTry(TryExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitTypeBinary(TypeBinaryExpression node)
            {
                _hashCode.Add(node.TypeOperand);

                return base.VisitTypeBinary(node);
            }

            protected override Expression VisitUnary(UnaryExpression node)
            {
                _hashCode.Add(node.IsLifted);
                _hashCode.Add(node.IsLiftedToNull);
                _hashCode.Add(node.Method);

                return base.VisitUnary(node);
            }

            protected override Expression VisitMemberInit(MemberInitExpression node)
            {
                _hashCode.Add(node.Bindings.Count);

                return base.VisitMemberInit(node);
            }

            protected override Expression VisitListInit(ListInitExpression node)
            {
                _hashCode.Add(node.Initializers.Count);

                return base.VisitListInit(node);
            }

            protected override Expression VisitDynamic(DynamicExpression node)
            {
                throw new NotImplementedException();
            }
        }
    }
}
