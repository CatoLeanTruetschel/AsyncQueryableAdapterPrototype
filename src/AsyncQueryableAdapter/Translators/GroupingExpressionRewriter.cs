﻿// License
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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using AsyncQueryableAdapter.Utils;

namespace AsyncQueryableAdapter.Translators
{
    internal sealed class GroupingExpressionRewriter : ExpressionVisitor
    {
        [ThreadStatic]
        private static GroupingExpressionRewriter? _instance;

        public static bool TryRewriteLamdaExpression(
            LambdaExpression lambdaExpression,
            Dictionary<ParameterExpression, (Type groupingType, Type asyncGroupingType)> lambdaParamsToRewrite,
            [NotNullWhen(true)] out LambdaExpression? translatedArg)
        {
            _instance ??= new GroupingExpressionRewriter();
            _instance._lambdaParamsToRewrite = lambdaParamsToRewrite;
            _instance._success = true;

            translatedArg = (LambdaExpression)_instance.Visit(lambdaExpression);
            _instance._rewrittenLamdaParameters.Clear();
            return _instance._success;
        }

        private Dictionary<ParameterExpression, (Type groupingType, Type asyncGroupingType)> _lambdaParamsToRewrite;
        private readonly Dictionary<ParameterExpression, ParameterExpression> _rewrittenLamdaParameters;
        private bool _success;

        public GroupingExpressionRewriter()
        {
            _lambdaParamsToRewrite = new();
            _rewrittenLamdaParameters = new();
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (_success && _lambdaParamsToRewrite.TryGetValue(node, out var groupingTranslation))
            {
                return RewriteParameterExpression(node, groupingTranslation);
            }

            return base.VisitParameter(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (_success)
            {
                if (node.Expression is ParameterExpression parameterExpression
                    && _lambdaParamsToRewrite.TryGetValue(parameterExpression, out var groupingTranslation))
                {
                    var member = node.Member;

                    // TODO: Check whether the member was found
                    // TODO: Perf
                    var asyncGroupingKeyMember = groupingTranslation.asyncGroupingType.GetProperty("Key");

                    if (member != asyncGroupingKeyMember)
                    {
                        _success = false;
                        return base.VisitMember(node);
                    }

                    var expression = RewriteParameterExpression(parameterExpression, groupingTranslation);

                    // TODO: Check whether the member was found
                    // TODO: Perf
                    member = groupingTranslation.groupingType.GetProperty("Key");

                    return Expression.MakeMemberAccess(expression, member!); // TODO: Check whether the member was found
                }
            }

            return base.VisitMember(node);
        }

        protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
        {
            // TODO: It is possible to translate this, if the member is the Key
            if (node.Expression is ParameterExpression parameterExpression
                && _lambdaParamsToRewrite.ContainsKey(parameterExpression))
            {
                _success = false;
            }

            return base.VisitMemberAssignment(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Object is ParameterExpression parameterExpression
               && _lambdaParamsToRewrite.ContainsKey(parameterExpression))
            {
                _success = false;
            }

            return base.VisitMethodCall(node);
        }

        protected override Expression VisitSwitch(SwitchExpression node)
        {
            if (node.SwitchValue is ParameterExpression parameterExpression
               && _lambdaParamsToRewrite.ContainsKey(parameterExpression))
            {
                _success = false;
            }

            return base.VisitSwitch(node);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            if (!FuncTypeHelper.IsFuncType<T>())
            {
                _success = false;
                return node;
            }

            List<ParameterExpression>? translatedArgs = null;

            for (var i = 0; i < node.Parameters.Count; i++)
            {
                var parameter = node.Parameters[i];

                if (_lambdaParamsToRewrite.TryGetValue(parameter, out var groupingTranslation))
                {
                    parameter = RewriteParameterExpression(parameter, groupingTranslation);

                    if (translatedArgs is null)
                    {
                        translatedArgs = new();
                        for (var j = 0; j < i; j++)
                        {
                            translatedArgs[j] = node.Parameters[j];
                        }
                    }
                }

                if (translatedArgs is not null)
                {
                    translatedArgs.Add(parameter);
                }
            }

            var body = Visit(node.Body);

            if (translatedArgs is not null)
            {
                Span<Type> funcTypes = translatedArgs.Select(p => p.Type).ToArray(); // TODO: Perf
                return Expression.Lambda(FuncTypeHelper.GetFuncType(funcTypes, body.Type), body, translatedArgs);
            }
            else if (!ReferenceEquals(body, node.Body))
            {
                return Expression.Lambda<T>(body, node.Parameters);
            }

            return base.VisitLambda(node);
        }

        private ParameterExpression RewriteParameterExpression(
            ParameterExpression parameter,
            (Type groupingType, Type asyncGroupingType) groupingTranslation)
        {
            if (!_rewrittenLamdaParameters.TryGetValue(parameter, out var rewrittenNode))
            {
                rewrittenNode = Expression.Parameter(groupingTranslation.groupingType, parameter.Name);
                _rewrittenLamdaParameters.Add(parameter, rewrittenNode);
            }

            return rewrittenNode;
        }
    }
}