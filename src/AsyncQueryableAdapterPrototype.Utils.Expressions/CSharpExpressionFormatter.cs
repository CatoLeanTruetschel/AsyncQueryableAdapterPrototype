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
// Mono.Linq.Expressions
// https://github.com/jbevain/mono.linq.expressions
// (C) 2010 Novell, Inc. (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following tests:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq.Expressions;
using AsyncQueryableAdapter.Utils;
using AsyncQueryableAdapter.Utils.Expressions;

namespace AsyncQueryableAdapterPrototype.Utils.Expressions
{
    internal sealed class CSharpExpressionFormatter : ExpressionVisitor
    {
        private readonly IFormatter _formatter;
#if SUPPORTS_READ_ONLY_SET
        private readonly IReadOnlySet<string>? _knownNamespaces;
#else
        private readonly IEnumerable<string>? _knownNamespaces;
#endif
        private readonly Dictionary<ParameterExpression, string> _uniqueNames = new();
        private int _uniqueSeed;

        public CSharpExpressionFormatter(IFormatter formatter, IEnumerable<string>? knownNamespaces = null)
        {
            if (formatter is null)
                throw new ArgumentNullException(nameof(formatter));

            _formatter = formatter;

#if SUPPORTS_READ_ONLY_SET
            _knownNamespaces = knownNamespaces as IReadOnlySet<string> ?? knownNamespaces?.ToImmutableHashSet();
#else
            _knownNamespaces = knownNamespaces;
#endif

        }

#if SUPPORTS_READ_ONLY_SET
        public CSharpExpressionFormatter(IFormatter formatter, IReadOnlySet<string>? knownNamespaces)
        {
            if (formatter is null)
                throw new ArgumentNullException(nameof(formatter));

            _formatter = formatter;
            _knownNamespaces = knownNamespaces;
        }
#endif

        protected override Expression VisitExtension(Expression node)
        {
            if (node is WhileExpression whileExpression)
            {
                return VisitWhileExpression(whileExpression);
            }
            else if (node is UsingExpression usingExpression)
            {
                return VisitUsingExpression(usingExpression);
            }
            else if (node is DoWhileExpression doWhileExpression)
            {
                return VisitDoWhileExpression(doWhileExpression);
            }
            else if (node is ForExpression forExpression)
            {
                return VisitForExpression(forExpression);
            }
            else if (node is ForEachExpression forEachExpression)
            {
                return VisitForEachExpression(forEachExpression);
            }

            return base.VisitExtension(node);
        }

        public void Write(Expression expression)
        {
            Visit(expression);
        }

        public void Write(ElementInit initializer)
        {
            VisitElementInit(initializer);
        }

        public void Write(MemberBinding binding)
        {
            VisitMemberBinding(binding);
        }

        public void Write(CatchBlock block)
        {
            VisitCatchBlock(block);
        }

        public void Write(SwitchCase @case)
        {
            VisitSwitchCase(@case);
        }

        public void Write(LabelTarget target)
        {
            VisitLabelTarget(target);
        }

        public void Write(LambdaExpression expression)
        {
            VisitLambdaSignature(expression);
            VisitLambdaBody(expression);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            VisitParameters(node);
            _formatter.WriteSpace();
            _formatter.WriteToken("=>");
            _formatter.WriteLine();

            VisitLambdaBody(node);

            return node;
        }

        private void VisitLambdaSignature(LambdaExpression node)
        {
            VisitType(node.ReturnType);
            _formatter.WriteSpace();
            _formatter.WriteIdentifier(node.Name, node);
            VisitParameters(node);

            _formatter.WriteLine();
        }

        private void VisitParameters(LambdaExpression node)
        {
            VisitParenthesizedList(node.Parameters, parameter =>
            {
                VisitType(parameter.Type);
                _formatter.WriteSpace();
                _formatter.WriteIdentifier(NameFor(parameter), parameter);
            });
        }

        private string NameFor(ParameterExpression parameter)
        {
            if (!string.IsNullOrEmpty(parameter.Name))
                return parameter.Name;

            var name = GeneratedNameFor(parameter);
            if (name is not null)
                return name;

            name = "var_$" + _uniqueSeed++;
            _uniqueNames.Add(parameter, name);
            return name;
        }

        private string GeneratedNameFor(ParameterExpression parameter)
        {
            if (!_uniqueNames.TryGetValue(parameter, out var name))
                return null;

            return name;
        }

        private void VisitLambdaBody(LambdaExpression node)
        {
            if (node.Body.NodeType != ExpressionType.Block)
                VisitSingleExpressionBody(node);
            else
                VisitBlockExpressionBody(node);
        }

        private void VisitBlockExpressionBody(LambdaExpression node)
        {
            VisitBlockExpression((BlockExpression)node.Body);
        }

        private static bool IsStatement(Expression expression)
        {
#pragma warning disable IDE0066
            switch (expression.NodeType)
#pragma warning restore IDE0066
            {
                case ExpressionType.Conditional:
                    return !IsTernaryConditional((ConditionalExpression)expression);

                case ExpressionType.Try:
                case ExpressionType.Loop:
                case ExpressionType.Switch:
                    return true;

                case ExpressionType.Extension:
                    if (expression is WhileExpression or UsingExpression or DoWhileExpression or ForExpression or ForEachExpression)
                        return true;

                    return false;

                default:
                    return false;
            }
        }

        private static bool IsActualStatement(Expression expression)
        {
            return expression.NodeType switch
            {
                ExpressionType.Label => false,
                ExpressionType.Conditional => IsTernaryConditional((ConditionalExpression)expression),
                ExpressionType.Try or ExpressionType.Loop or ExpressionType.Switch => false,
                _ => true,
            };
        }

        private void VisitSingleExpressionBody(LambdaExpression node)
        {
            VisitBlock(() =>
            {
                if (node.ReturnType != typeof(void) && !IsStatement(node.Body))
                {
                    _formatter.WriteKeyword("return");
                    _formatter.WriteSpace();
                }

                Visit(node.Body);

                if (!IsStatement(node.Body))
                {
                    _formatter.WriteToken(";");
                    _formatter.WriteLine();
                }
            });
        }

        private void VisitType(Type type)
        {
            TypeHelper.FormatCSharpTypeName(type, _formatter, _knownNamespaces);
        }

        private void VisitGenericArguments(Type[] genericArguments)
        {
            VisitList(genericArguments, "<", VisitType, ">");
        }

        protected override Expression VisitBlock(BlockExpression node)
        {
            // Check if node describes one of the higher level language constructs

            VisitBlockExpression(node);

            return node;
        }

        private void VisitBlock(Action action)
        {
            _formatter.WriteToken("{");
            _formatter.WriteLine();
            _formatter.Indent();

            action();

            _formatter.Dedent();
            _formatter.WriteToken("}");
        }

        private void VisitBlockExpression(BlockExpression node)
        {
            VisitBlock(() =>
            {
                VisitBlockVariables(node);
                VisitBlockExpressions(node);
            });
        }

        private void VisitBlockExpressions(BlockExpression node)
        {
            for (var i = 0; i < node.Expressions.Count; i++)
            {
                var expression = node.Expressions[i];

                if (IsActualStatement(expression) && RequiresExplicitReturn(node, i, node.Type != typeof(void)))
                {
                    _formatter.WriteKeyword("return");
                    _formatter.WriteSpace();
                }

                Write(expression);

                if (!IsActualStatement(expression))
                    continue;

                _formatter.WriteToken(";");
                _formatter.WriteLine();
            }
        }

        private void VisitBlockVariables(BlockExpression node)
        {
            foreach (var variable in node.Variables)
            {
                VisitType(variable.Type);
                _formatter.WriteSpace();
                _formatter.WriteIdentifier(NameFor(variable), variable);
                _formatter.WriteToken(";");
                _formatter.WriteLine();
            }
        }

        private static bool RequiresExplicitReturn(BlockExpression node, int index, bool returnLast)
        {
            if (!returnLast)
                return false;

            var lastIndex = node.Expressions.Count - 1;
            if (index != lastIndex)
                return false;

            var last = node.Expressions[lastIndex];
            if (last.NodeType == ExpressionType.Goto && ((GotoExpression)last).Kind == GotoExpressionKind.Return)
                return false;

            return true;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (IsChecked(node.NodeType))
                VisitCheckedBinary(node);
            else if (node.NodeType == ExpressionType.Assign)
                VisitAssign(node);
            else if (IsPower(node.NodeType))
                VisitPower(node);
            else if (node.NodeType == ExpressionType.ArrayIndex)
                VisitArrayIndex(node);
            else
                VisitSimpleBinary(node);

            return node;
        }

        private void VisitArrayIndex(BinaryExpression node)
        {
            Visit(node.Left);
            _formatter.WriteToken("[");
            Visit(node.Right);
            _formatter.WriteToken("]");
        }

        private void VisitAssign(BinaryExpression node)
        {
            Visit(node.Left);
            _formatter.WriteSpace();
            _formatter.WriteToken(GetBinaryOperator(node.NodeType));
            _formatter.WriteSpace();
            Visit(node.Right);
        }

        private void VisitPower(BinaryExpression node)
        {
            var pow = Expression.Call(typeof(System.Math).GetMethod("Pow"), node.Left, node.Right);

            if (node.NodeType == ExpressionType.Power)
                Visit(pow);
            else if (node.NodeType == ExpressionType.PowerAssign)
                Visit(Expression.Assign(node.Left, pow));
        }

        private static bool IsPower(ExpressionType type)
        {
            return type is ExpressionType.Power or ExpressionType.PowerAssign;
        }

        private void VisitSimpleBinary(BinaryExpression node)
        {
            VisitParenthesizedExpression(node.Left);
            _formatter.WriteSpace();
            _formatter.WriteToken(GetBinaryOperator(node.NodeType));
            _formatter.WriteSpace();
            VisitParenthesizedExpression(node.Right);
        }

        private void VisitParenthesizedExpression(Expression expression)
        {
            if (RequiresParentheses(expression))
            {
                _formatter.WriteToken("(");
                Visit(expression);
                _formatter.WriteToken(")");
                return;
            }

            Visit(expression);
        }

        private static bool RequiresParentheses(Expression expression)
        {
#pragma warning disable IDE0066
            switch (expression.NodeType)
#pragma warning restore IDE0066
            {
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Coalesce:
                case ExpressionType.Decrement:
                case ExpressionType.Divide:
                case ExpressionType.Equal:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Increment:
                case ExpressionType.LeftShift:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.Modulo:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Negate:
                case ExpressionType.Not:
                case ExpressionType.NotEqual:
                case ExpressionType.OnesComplement:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.Power:
                case ExpressionType.RightShift:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.UnaryPlus:
                    return true;
                default:
                    return false;
            }
        }

        private void VisitCheckedBinary(BinaryExpression node)
        {
            VisitChecked(() => VisitSimpleBinary(node));
        }

        private void VisitChecked(Action action)
        {
            _formatter.WriteKeyword("checked");
            _formatter.WriteSpace();
            _formatter.WriteToken("{");

            _formatter.WriteSpace();

            action();

            _formatter.WriteSpace();

            _formatter.WriteToken("}");
        }

        private static string GetBinaryOperator(ExpressionType type)
        {
            return type switch
            {
                ExpressionType.Add or ExpressionType.AddChecked => "+",
                ExpressionType.AddAssign or ExpressionType.AddAssignChecked => "+=",
                ExpressionType.And => "&",
                ExpressionType.AndAlso => "&&",
                ExpressionType.AndAssign => "&=",
                ExpressionType.Assign => "=",
                ExpressionType.Coalesce => "??",
                ExpressionType.Divide => "/",
                ExpressionType.DivideAssign => "/=",
                ExpressionType.Equal => "==",
                ExpressionType.ExclusiveOr => "^",
                ExpressionType.ExclusiveOrAssign => "^=",
                ExpressionType.GreaterThan => ">",
                ExpressionType.GreaterThanOrEqual => ">=",
                ExpressionType.LeftShift => "<<",
                ExpressionType.LeftShiftAssign => "<<=",
                ExpressionType.LessThan => "<",
                ExpressionType.LessThanOrEqual => "<=",
                ExpressionType.Modulo => "%",
                ExpressionType.ModuloAssign => "%=",
                ExpressionType.Multiply or ExpressionType.MultiplyChecked => "*",
                ExpressionType.MultiplyAssign or ExpressionType.MultiplyAssignChecked => "*=",
                ExpressionType.NotEqual => "!=",
                ExpressionType.Or => "|",
                ExpressionType.OrAssign => "|=",
                ExpressionType.OrElse => "||",
                ExpressionType.RightShift => ">>",
                ExpressionType.RightShiftAssign => ">>=",
                ExpressionType.Subtract or ExpressionType.SubtractChecked => "-",
                ExpressionType.SubtractAssign or ExpressionType.SubtractAssignChecked => "-=",
                _ => throw new NotImplementedException(type.ToString()),
            };
        }

        private static bool IsChecked(ExpressionType type)
        {
#pragma warning disable IDE0066
            switch (type)
#pragma warning restore IDE0066
            {
                case ExpressionType.AddAssignChecked:
                case ExpressionType.AddChecked:
                case ExpressionType.MultiplyAssignChecked:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.NegateChecked:
                case ExpressionType.SubtractAssignChecked:
                case ExpressionType.SubtractChecked:
                    return true;
                default:
                    return false;
            }
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (IsChecked(node.NodeType))
            {
                VisitCheckedUnary(node);
                return node;
            }

            switch (node.NodeType)
            {
                case ExpressionType.Throw:
                    VisitThrow(node);
                    break;
                case ExpressionType.IsTrue:
                    VisitIsTrue(node);
                    break;
                case ExpressionType.IsFalse:
                    VisitIsFalse(node);
                    break;
                case ExpressionType.ArrayLength:
                    VisitArrayLength(node);
                    break;
                case ExpressionType.TypeAs:
                    VisitTypeAs(node);
                    break;
                case ExpressionType.Increment:
                    VisitIncrement(node);
                    break;
                case ExpressionType.Decrement:
                    VisitDecrement(node);
                    break;
                case ExpressionType.PreDecrementAssign:
                    VisitPreDecrementAssign(node);
                    break;
                case ExpressionType.PostDecrementAssign:
                    VisitPostDecrementAssign(node);
                    break;
                case ExpressionType.PreIncrementAssign:
                    VisitPreIncrementAssign(node);
                    break;
                case ExpressionType.PostIncrementAssign:
                    VisitPostIncrementAssign(node);
                    break;
                case ExpressionType.ConvertChecked:
                    VisitConvertChecked(node);
                    break;
                case ExpressionType.Convert:
                case ExpressionType.Unbox:
                    VisitConvert(node);
                    break;
                case ExpressionType.Quote:
                    Visit(node.Operand);
                    break;
                default:
                    VisitSimpleUnary(node);
                    break;
            }

            return node;
        }

        private void VisitConvert(UnaryExpression node)
        {
            _formatter.WriteToken("(");
            VisitType(node.Type);
            _formatter.WriteToken(")");

            VisitParenthesizedExpression(node.Operand);
        }

        private void VisitConvertChecked(UnaryExpression node)
        {
            VisitChecked(() => VisitConvert(node));
        }

        private void VisitPostIncrementAssign(UnaryExpression node)
        {
            Visit(node.Operand);
            _formatter.WriteToken("++");
        }

        private void VisitPreIncrementAssign(UnaryExpression node)
        {
            _formatter.WriteToken("++");
            Visit(node.Operand);
        }

        private void VisitPostDecrementAssign(UnaryExpression node)
        {
            Visit(node.Operand);
            _formatter.WriteToken("--");
        }

        private void VisitPreDecrementAssign(UnaryExpression node)
        {
            _formatter.WriteToken("--");
            Visit(node.Operand);
        }

        private void VisitDecrement(UnaryExpression node)
        {
            Visit(Expression.Subtract(node.Operand, Expression.Constant(1)));
        }

        private void VisitIncrement(UnaryExpression node)
        {
            Visit(Expression.Add(node.Operand, Expression.Constant(1)));
        }

        private void VisitIsTrue(UnaryExpression node)
        {
            Visit(Expression.Equal(node.Operand, Expression.Constant(true)));
        }

        private void VisitIsFalse(UnaryExpression node)
        {
            Visit(Expression.Equal(node.Operand, Expression.Constant(false)));
        }

        private void VisitArrayLength(UnaryExpression node)
        {
            Visit(Expression.Property(node.Operand, "Length"));
        }

        private void VisitTypeAs(UnaryExpression node)
        {
            Visit(node.Operand);
            _formatter.WriteSpace();
            _formatter.WriteKeyword("as");
            _formatter.WriteSpace();
            VisitType(node.Type);
        }

        private void VisitThrow(UnaryExpression node)
        {
            _formatter.WriteKeyword("throw");
            _formatter.WriteSpace();
            Visit(node.Operand);
        }

        private void VisitCheckedUnary(UnaryExpression node)
        {
            VisitChecked(() => VisitSimpleUnary(node));
        }

        private void VisitSimpleUnary(UnaryExpression node)
        {
            _formatter.WriteToken(GetUnaryOperator(node.NodeType));
            VisitParenthesizedExpression(node.Operand);
        }

        private static string GetUnaryOperator(ExpressionType type)
        {
            return type switch
            {
                ExpressionType.UnaryPlus => "+",
                ExpressionType.Not => "!",
                ExpressionType.Negate or ExpressionType.NegateChecked => "-",
                ExpressionType.OnesComplement => "~",
                _ => throw new NotImplementedException(type.ToString()),
            };
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            _formatter.WriteIdentifier(NameFor(node), node);

            return node;
        }

        protected override Expression VisitConditional(ConditionalExpression node)
        {
            if (IsTernaryConditional(node))
                VisitConditionalExpression(node);
            else
                VisitConditionalStatement(node);

            return node;
        }

        private void VisitConditionalExpression(ConditionalExpression node)
        {
            Visit(node.Test);
            _formatter.WriteSpace();
            _formatter.WriteToken("?");
            _formatter.WriteSpace();
            Visit(node.IfTrue);
            _formatter.WriteSpace();
            _formatter.WriteToken(":");
            _formatter.WriteSpace();
            Visit(node.IfFalse);
        }

        private void VisitConditionalStatement(ConditionalExpression node)
        {
            _formatter.WriteKeyword("if");
            _formatter.WriteSpace();
            _formatter.WriteToken("(");

            Visit(node.Test);

            _formatter.WriteToken(")");
            _formatter.WriteLine();

            VisitAsBlock(node.IfTrue);

            if (node.IfFalse is not null)
            {
                _formatter.WriteKeyword("else");
                _formatter.WriteLine();

                VisitAsBlock(node.IfFalse);
            }
        }

        private static bool IsTernaryConditional(ConditionalExpression node)
        {
            return node.Type != typeof(void) && (node.IfTrue.NodeType != ExpressionType.Block
                || (node.IfFalse is not null && node.IfFalse.NodeType != ExpressionType.Block));
        }

        protected override Expression VisitGoto(GotoExpression node)
        {
            switch (node.Kind)
            {
                case GotoExpressionKind.Return:
                    _formatter.WriteKeyword("return");
                    _formatter.WriteSpace();
                    Visit(node.Value);
                    break;
                case GotoExpressionKind.Break:
                    _formatter.WriteKeyword("break");
                    break;
                case GotoExpressionKind.Continue:
                    _formatter.WriteKeyword("continue");
                    break;
                case GotoExpressionKind.Goto:
                    _formatter.WriteKeyword("goto");
                    _formatter.WriteSpace();
                    Visit(node.Value);
                    break;
                default:
                    throw new NotSupportedException();
            }

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            _formatter.WriteLiteral(GetLiteral(node.Value));

            return node;
        }

        private static string GetLiteral(object value)
        {
            if (value is null)
                return "null";

            if (value.GetType().IsEnum)
                return GetEnumLiteral(value);

            return Type.GetTypeCode(value.GetType()) switch
            {
                TypeCode.Boolean => ((bool)value) ? "true" : "false",
                TypeCode.Char => "'" + ((char)value) + "'",
                TypeCode.String => "\"" + ((string)value) + "\"",
                TypeCode.Int32 => ((IFormattable)value).ToString(null, System.Globalization.CultureInfo.InvariantCulture),
                _ => value.ToString(),
            };
        }

        private static string GetEnumLiteral(object value)
        {
            var type = value.GetType();
            if (Enum.IsDefined(type, value))
                return type.Name + "." + Enum.GetName(type, value);

            throw new NotSupportedException();
        }

        protected override Expression VisitLabel(LabelExpression node)
        {
            return node;
        }

        protected override LabelTarget VisitLabelTarget(LabelTarget target)
        {
            _formatter.Dedent();
            _formatter.WriteIdentifier(target.Name, target);
            _formatter.WriteToken(":");
            _formatter.WriteLine();
            _formatter.Indent();

            return target;
        }

        protected override Expression VisitInvocation(InvocationExpression node)
        {
            Visit(node.Expression);
            VisitArguments(node.Arguments);

            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var method = node.Method;

            if (node.Object is not null)
                Visit(node.Object);
            else
                VisitType(method.DeclaringType);

            _formatter.WriteToken(".");

            _formatter.WriteReference(method.Name, method);

            if (method.IsGenericMethod && !method.IsGenericMethodDefinition)
                VisitGenericArguments(method.GetGenericArguments());

            VisitArguments(node.Arguments);

            return node;
        }

        private void VisitParenthesizedList<T>(IList<T> list, Action<T> writer)
        {
            VisitList(list, "(", writer, ")");
        }

        private void VisitBracedList<T>(IList<T> list, Action<T> writer)
        {
            VisitList(list, "{", writer, "}");
        }

        private void VisitBracketedList<T>(IList<T> list, Action<T> writer)
        {
            VisitList(list, "[", writer, "]");
        }

        private void VisitList<T>(IList<T> list, string opening, Action<T> writer, string closing)
        {
            _formatter.WriteToken(opening);

            for (var i = 0; i < list.Count; i++)
            {
                if (i > 0)
                {
                    _formatter.WriteToken(",");
                    _formatter.WriteSpace();
                }

                writer(list[i]);
            }

            _formatter.WriteToken(closing);
        }

        private void VisitArguments(IList<Expression> expressions)
        {
            VisitParenthesizedList(expressions, e => Visit(e));
        }

        protected override Expression VisitNew(NewExpression node)
        {
            _formatter.WriteKeyword("new");
            _formatter.WriteSpace();
            VisitType(node.Constructor is null ? node.Type : node.Constructor.DeclaringType);
            VisitArguments(node.Arguments);

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression is not null)
                Visit(node.Expression);
            else
                VisitType(node.Member.DeclaringType);

            _formatter.WriteToken(".");
            _formatter.WriteReference(node.Member.Name, node.Member);

            return node;
        }

        protected override Expression VisitIndex(IndexExpression node)
        {
            Visit(node.Object);
            VisitBracketedList(node.Arguments, expression => Visit(expression));

            return node;
        }

        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            if (node.NodeType == ExpressionType.NewArrayInit)
                VisitNewArrayInit(node);
            else if (node.NodeType == ExpressionType.NewArrayBounds)
                VisitNewArrayBounds(node);

            return node;
        }

        private void VisitNewArrayBounds(NewArrayExpression node)
        {
            _formatter.WriteKeyword("new");
            _formatter.WriteSpace();
            VisitType(node.Type.GetElementType());

            VisitBracketedList(node.Expressions, expression => Visit(expression));
        }

        private void VisitNewArrayInit(NewArrayExpression node)
        {
            _formatter.WriteKeyword("new");
            _formatter.WriteSpace();
            VisitType(node.Type);
            _formatter.WriteSpace();

            VisitBracedList(node.Expressions, expression => Visit(expression));
        }

        protected override Expression VisitListInit(ListInitExpression node)
        {
            Visit(node.NewExpression);
            _formatter.WriteSpace();

            VisitInitializers(node.Initializers);

            return node;
        }

        private void VisitInitializers(IList<ElementInit> initializers)
        {
            VisitBracedList(initializers, initializer => VisitElementInit(initializer));
        }

        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            Visit(node.NewExpression);

            VisitBindings(node.Bindings);

            return node;
        }

        private void VisitBindings(IList<MemberBinding> bindings)
        {
            _formatter.WriteLine();

            _formatter.WriteToken("{");
            _formatter.WriteLine();
            _formatter.Indent();

            for (var i = 0; i < bindings.Count; i++)
            {
                var binding = bindings[i];

                VisitMemberBinding(binding);

                if (i < bindings.Count - 1)
                    _formatter.WriteToken(",");

                _formatter.WriteLine();
            }

            _formatter.Dedent();
            _formatter.WriteToken("}");
        }

        protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
        {
            VisitMemberBindingMember(node);
            _formatter.WriteSpace();

            Visit(node.Expression);

            return node;
        }

        private void VisitMemberBindingMember(MemberBinding node)
        {
            _formatter.WriteReference(node.Member.Name, node.Member);
            _formatter.WriteSpace();
            _formatter.WriteToken("=");
        }

        protected override MemberListBinding VisitMemberListBinding(MemberListBinding node)
        {
            VisitMemberBindingMember(node);
            _formatter.WriteSpace();

            VisitInitializers(node.Initializers);

            return node;
        }

        protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
        {
            VisitMemberBindingMember(node);

            VisitBindings(node.Bindings);

            return node;
        }

        protected override ElementInit VisitElementInit(ElementInit node)
        {
            if (node.Arguments.Count == 1)
                Visit(node.Arguments[0]);
            else
                VisitBracedList(node.Arguments, expression => Visit(expression));

            return node;
        }

        protected override Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            if (node.NodeType == ExpressionType.TypeEqual)
                VisitTypeEqual(node);
            else if (node.NodeType == ExpressionType.TypeIs)
                VisitTypeIs(node);

            return node;
        }

        private void VisitTypeIs(TypeBinaryExpression node)
        {
            Visit(node.Expression);
            _formatter.WriteSpace();
            _formatter.WriteKeyword("is");
            _formatter.WriteSpace();
            VisitType(node.TypeOperand);
        }

        private void VisitTypeEqual(TypeBinaryExpression node)
        {
            Visit(Expression.Call(
                node.Expression,
                typeof(object).GetMethod("GetType", new Type[0])));

            _formatter.WriteSpace();
            _formatter.WriteToken("==");
            _formatter.WriteSpace();

            _formatter.WriteKeyword("typeof");
            _formatter.WriteToken("(");
            VisitType(node.TypeOperand);
            _formatter.WriteToken(")");
        }

        protected override Expression VisitTry(TryExpression node)
        {
            _formatter.WriteKeyword("try");
            _formatter.WriteLine();
            VisitAsBlock(node.Body);

            foreach (var handler in node.Handlers)
                VisitCatchBlock(handler);

            if (node.Fault is not null)
            {
                _formatter.WriteKeyword("fault");
                _formatter.WriteLine();
                VisitAsBlock(node.Fault);
            }

            if (node.Finally is not null)
            {
                _formatter.WriteKeyword("finally");
                _formatter.WriteLine();
                VisitAsBlock(node.Finally);
            }

            return node;
        }

        private void VisitAsBlock(Expression node)
        {
            Visit(node.NodeType == ExpressionType.Block ? node : Expression.Block(node));
            _formatter.WriteLine();
        }

        protected override CatchBlock VisitCatchBlock(CatchBlock node)
        {
            _formatter.WriteKeyword("catch");

            _formatter.WriteSpace();
            _formatter.WriteToken("(");
            VisitType(node.Test);

            if (node.Variable is not null)
            {
                _formatter.WriteSpace();
                _formatter.WriteIdentifier(NameFor(node.Variable), node.Variable);
            }

            _formatter.WriteToken(")");

            if (node.Filter is not null)
            {
                _formatter.WriteSpace();
                _formatter.WriteKeyword("if");
                _formatter.WriteSpace();
                _formatter.WriteToken("(");
                Visit(node.Filter);
                _formatter.WriteToken(")");
            }

            _formatter.WriteLine();

            VisitAsBlock(node.Body);

            return node;
        }

        protected override Expression VisitLoop(LoopExpression node)
        {
            _formatter.WriteKeyword("for");
            _formatter.WriteSpace();
            _formatter.WriteToken("(");
            _formatter.WriteToken(";");
            _formatter.WriteToken(";");
            _formatter.WriteToken(")");
            _formatter.WriteLine();

            VisitAsBlock(node.Body);

            return node;
        }

        protected override Expression VisitSwitch(SwitchExpression node)
        {
            _formatter.WriteKeyword("switch");
            _formatter.WriteSpace();
            _formatter.WriteToken("(");
            Visit(node.SwitchValue);
            _formatter.WriteToken(")");
            _formatter.WriteLine();

            VisitBlock(() =>
            {
                foreach (var @case in node.Cases)
                    VisitSwitchCase(@case);

                if (node.DefaultBody is not null)
                {
                    _formatter.WriteKeyword("default");
                    _formatter.WriteToken(":");
                    _formatter.WriteLine();

                    VisitAsBlock(node.DefaultBody);
                }
            });

            _formatter.WriteLine();

            return node;
        }

        protected override SwitchCase VisitSwitchCase(SwitchCase node)
        {
            foreach (var value in node.TestValues)
            {
                _formatter.WriteKeyword("case");
                _formatter.WriteSpace();
                Visit(value);
                _formatter.WriteToken(":");
                _formatter.WriteLine();
            }

            VisitAsBlock(node.Body);

            return node;
        }

        protected override Expression VisitDefault(DefaultExpression node)
        {
            _formatter.WriteKeyword("default");
            _formatter.WriteToken("(");
            VisitType(node.Type);
            _formatter.WriteToken(")");

            return node;
        }

        private Expression VisitForExpression(ForExpression node)
        {
            _formatter.WriteKeyword("for");
            _formatter.WriteSpace();
            _formatter.WriteToken("(");
            VisitType(node.Variable.Type);
            _formatter.WriteSpace();
            Visit(node.Variable);
            _formatter.WriteSpace();
            _formatter.WriteToken("=");
            _formatter.WriteSpace();
            Visit(node.Initializer);
            _formatter.WriteToken(";");
            _formatter.WriteSpace();
            Visit(node.Test);
            _formatter.WriteToken(";");
            _formatter.WriteSpace();
            Visit(node.Step);
            _formatter.WriteToken(")");
            _formatter.WriteLine();

            VisitAsBlock(node.Body);
            return node;
        }

        private Expression VisitForEachExpression(ForEachExpression node)
        {
            _formatter.WriteKeyword("foreach");
            _formatter.WriteSpace();
            _formatter.WriteToken("(");
            VisitType(node.Variable.Type);
            _formatter.WriteSpace();
            Visit(node.Variable);
            _formatter.WriteSpace();
            _formatter.WriteKeyword("in");
            _formatter.WriteSpace();
            Visit(node.Enumerable);
            _formatter.WriteToken(")");
            _formatter.WriteLine();

            VisitAsBlock(node.Body);
            return node;
        }

        private Expression VisitUsingExpression(UsingExpression node)
        {
            _formatter.WriteKeyword("using");
            _formatter.WriteSpace();
            _formatter.WriteToken("(");
            Visit(node.Disposable);
            _formatter.WriteToken(")");
            _formatter.WriteLine();

            VisitAsBlock(node.Body);
            return node;
        }

        private Expression VisitDoWhileExpression(DoWhileExpression node)
        {
            _formatter.WriteKeyword("do");
            _formatter.WriteLine();

            VisitAsBlock(node.Body);

            _formatter.WriteKeyword("while");
            _formatter.WriteSpace();
            _formatter.WriteToken("(");
            Visit(node.Test);
            _formatter.WriteToken(")");
            _formatter.WriteToken(";");
            _formatter.WriteLine();
            return node;
        }

        private Expression VisitWhileExpression(WhileExpression node)
        {
            _formatter.WriteKeyword("while");
            _formatter.WriteSpace();
            _formatter.WriteToken("(");
            Visit(node.Test);
            _formatter.WriteToken(")");
            _formatter.WriteLine();

            VisitAsBlock(node.Body);
            return node;
        }
    }
}
