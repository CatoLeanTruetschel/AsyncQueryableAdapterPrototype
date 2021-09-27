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
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AsyncQueryableAdapter.Utils;
using Xunit;

namespace AsyncQueryablePrototype.Shared.Tests
{
    public sealed class ExpressionComparerTests
    {
        private static readonly ImmutableList<MethodInfo> _createMethods =
            typeof(ExpressionComparerTests)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Where(p => p.Name.StartsWith("Create", StringComparison.Ordinal))
            .ToImmutableList();

        public static Expression<Func<int>> Create()
        {
            return () => 0;
        }

        public delegate int CustomDelegate();

        public static Expression<CustomDelegate> CreateWithCustomDelegateType()
        {
            return () => 0;
        }

        public static Expression<Func<int, int, int>> CreateWithParameters()
        {
            return (p, q) => 0;
        }

        public static Expression<Func<int, int, int>> CreateBinaryAddition()
        {
            return (p, q) => p + q;
        }

        public static Expression<Func<int, int, int>> CreateBinarySubtraction()
        {
            return (p, q) => p - q;
        }

        public static Expression<Func<int, int, int>> CreateUnaryPlus()
        {
            return (p, q) => +q;
        }

        public static Expression<Func<int, int, int>> CreateUnaryNegation()
        {
            return (p, q) => -q;
        }

        public static Expression<Func<bool, int>> CreateConditional()
        {
            return (b) => b ? 0 : 1;
        }

        private static readonly Tuple<int, int> _tuple = new(1, 2);

        public static Expression<Func<int>> CreateMember()
        {
            return () => _tuple.Item1;
        }

        public static Expression<Func<int>> CreateOtherMember()
        {
            return () => _tuple.Item2;
        }

        public static Expression<Func<string, string>> CreateCall()
        {
            return (s) => s.ToString();
        }

        public static Expression<Func<string, string>> CreateOtherCall()
        {
            return (s) => s.Substring(1);
        }

        public static Expression<Func<int[]>> CreateNewArray()
        {
            return () => new[] { 0, 1, 2 };
        }

        public static Expression<Func<string>> CreateNewObj()
        {
            return () => new string((char[])null);
        }

        public static Expression<Func<string>> CreateOtherNewObj()
        {
            return () => new string('1', 2);
        }

        public static Expression<Func<string, object, bool>> CreateTypeIs()
        {
            return (s, o) => s is string;
        }

        public static Expression<Func<string, object, bool>> CreateOtherTypeIs()
        {
            return (s, o) => o is string;
        }

        public static Expression<Func<string, object, bool>> CreateYetAnotherTypeIs()
        {
            return (s, o) => o is object;
        }

        public static Expression<Func<int, Func<int, int, int>>> CreateNestedLambda()
        {
            return (p) => (q, w) => 0;
        }

        public static Expression<Func<int, Func<int, int, int>>> CreateNestedLambdaWithSameParameterNameInNestedScope()
        {
            return (p) => (q, p) => 4;
        }

        public static Expression CreateInvocation()
        {
            return Expression.Invoke(CreateCall(), Expression.Constant("abc"));
        }

        public static Expression CreateOtherInvocation()
        {
            return Expression.Invoke(CreateOtherCall(), Expression.Constant("abc"));
        }

        public static Expression CreateYetAnotherInvocation()
        {
            return Expression.Invoke(CreateCall(), Expression.Constant("def"));
        }

        public static Expression<Func<Tuple<int, int>>> CreateNewObjWithMembers()
        {
            var newExpression = Expression.New(
                typeof(Tuple<int, int>)
                .GetConstructor(new[] { typeof(int), typeof(int) }),
                new[] { Expression.Constant(1), Expression.Constant(2) },
                new[] { typeof(Tuple<int, int>).GetProperty("Item1"), typeof(Tuple<int, int>).GetProperty("Item1") });

            return Expression.Lambda<Func<Tuple<int, int>>>(newExpression);
        }

        public static Expression<Func<Tuple<int, int>>> CreateOtherNewObjWithMembers()
        {
            return () => new Tuple<int, int>(1, 2);
        }

        public static Expression<Func<List<int>>> CreateListInit()
        {
            return () => new List<int> { 0, 1, 2 };
        }

        public static Expression<Func<List<int>>> CreateOtherListInit()
        {
            return () => new List<int> { 0, 1, 3 };
        }

        public sealed record IntDummy
        {
            public List<int> List { get; set; } = new();

            public int Int { get; set; }

            public int Int2 { get; set; }
        }

        public sealed record ListDummy
        {
            public List<int> List { get; set; } = new();
            public List<int> List2 { get; set; } = new();
        }

        public sealed record IntDummyDummy
        {
            public IntDummy Dummy { get; } = new();
            public IntDummy Dummy2 { get; } = new();
        }

        public static Expression<Func<IntDummy>> CreateMemberBinding()
        {
            return () => new IntDummy { Int = 1 };
        }

        public static Expression<Func<IntDummy>> CreateOtherMemberBinding()
        {
            return () => new IntDummy { Int2 = 1 };
        }

        public static Expression<Func<IntDummy>> CreateYetanotherMemberBinding()
        {
            return () => new IntDummy { Int = 2 };
        }

        public static Expression<Func<ListDummy>> CreateMemberListBinding()
        {
            return () => new ListDummy { List = { 0, 1, 2 } };
        }

        public static Expression<Func<ListDummy>> CreateOtherMemberListBinding()
        {
            return () => new ListDummy { List2 = { 0, 1, 2 } };
        }

        public static Expression<Func<ListDummy>> CreateYetAnotherMemberListBinding()
        {
            return () => new ListDummy { List = { 0, 1, 3 } };
        }

        public static Expression<Func<IntDummyDummy>> CreateMemberMemberBinding()
        {
            return () => new IntDummyDummy { Dummy = { Int = 1 } };
        }

        public static Expression<Func<IntDummyDummy>> CreateOtherMemberMemberBinding()
        {
            return () => new IntDummyDummy { Dummy2 = { Int = 1 } };
        }

        public static Expression<Func<IntDummyDummy>> CreateYetAnotherMemberMemberBinding()
        {
            return () => new IntDummyDummy { Dummy = { Int = 2 } };
        }

        public static Expression<Func<IntDummyDummy>> CreateOtherBindingTypeInMemberMemberBinding()
        {
            return () => new IntDummyDummy { Dummy = { List = { 0, 1, 3 } } };
        }

        private sealed class EqualExpressionsTestData : TheoryData<Expression, Expression>
        {
            public EqualExpressionsTestData()
            {
                // Add the exact same expression instance twice for each expression type
                for (var i = 0; i < _createMethods.Count; i++)
                {
                    var expression = (Expression)_createMethods[i].Invoke(null, null);

                    Add(expression, expression);
                }

                // Add equal expressions but not the same instance
                for (var i = 0; i < _createMethods.Count; i++)
                {
                    var expression1 = (Expression)_createMethods[i].Invoke(null, null);
                    var expression2 = (Expression)_createMethods[i].Invoke(null, null);

                    Add(expression1, expression2);
                }
            }
        }

        private sealed class NotEqualExpressionsTestData : TheoryData<Expression, Expression>
        {
            public NotEqualExpressionsTestData()
            {
                for (var i = 0; i < _createMethods.Count; i++)
                {
                    var expression1 = (Expression)_createMethods[i].Invoke(null, null);

                    for (var j = 0; j < _createMethods.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        var expression2 = (Expression)_createMethods[j].Invoke(null, null);
                        Add(expression1, expression2);
                    }
                }
            }
        }

        [Theory]
        [ClassData(typeof(EqualExpressionsTestData))]
        public void AreEqualTests(Expression left, Expression right)
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create();

            // Act
            var areEqual = comparer.Equals(left, right);

            // Assert
            Assert.True(areEqual);
        }

        [Theory]
        [ClassData(typeof(EqualExpressionsTestData))]
        public void HaveSameHashCodeTests(Expression left, Expression right)
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create();

            // Act
            var leftHashCode = comparer.GetHashCode(left);
            var rightHashCode = comparer.GetHashCode(right);

            // Assert
            Assert.True(leftHashCode == rightHashCode);
        }

        [Theory]
        [ClassData(typeof(NotEqualExpressionsTestData))]
        public void AreNotEqualTests(Expression left, Expression right)
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create();

            // Act
            var areEqual = comparer.Equals(left, right);

            // Assert
            Assert.False(areEqual);
        }

        [Theory]
        [ClassData(typeof(NotEqualExpressionsTestData))]
        public void HaveDifferentHashCodeTests(Expression left, Expression right)
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create();

            // Act
            var leftHashCode = comparer.GetHashCode(left);
            var rightHashCode = comparer.GetHashCode(right);

            // Assert
            Assert.False(leftHashCode == rightHashCode);
        }

        [Fact]
        public void GetHashCodeNullObjectThrowsArgumentNullExceptionTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create();

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                comparer.GetHashCode(null);
            });
        }

        [Fact]
        public void EqualsBothExpressionsNullTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create();

            // Act
            var areEqual = comparer.Equals(null, null);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void EqualsXExpressionNullTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create();
            Expression? x = null;
            Expression? y = Expression.Constant(new object());

            // Act
            var areEqual = comparer.Equals(x, y);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void EqualsYExpressionNullTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create();
            Expression? x = Expression.Constant(new object());
            Expression? y = null;

            // Act
            var areEqual = comparer.Equals(x, y);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void EqualsExpressionOfDifferentNodeTypesTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create();
            Expression? x = Expression.Constant(new object());
            Expression? y = Expression.Default(typeof(int));

            // Act
            var areEqual = comparer.Equals(x, y);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void AreEqualParameterExpressionsWithDifferentNameWhenIgnoredTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create(compareParameterNames: false);
            Expression<Func<int, int>>? x = (p) => p;
            Expression<Func<int, int>>? y = (q) => q;

            // Act
            var areEqual = comparer.Equals(x, y);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void AreNotEqualParameterExpressionsWithDifferentNameWhenNotIgnoredTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create(compareParameterNames: true);
            Expression<Func<int, int>>? x = (p) => p;
            Expression<Func<int, int>>? y = (q) => q;

            // Act
            var areEqual = comparer.Equals(x, y);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void AreEqualLambdaExpressionsWithDifferentNameWhenIgnoredTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create(compareLambdaNames: false);
            Expression? x = Expression.Lambda<Func<int>>(Expression.Constant(0), "p", Enumerable.Empty<ParameterExpression>());
            Expression? y = Expression.Lambda<Func<int>>(Expression.Constant(0), "q", Enumerable.Empty<ParameterExpression>());

            // Act
            var areEqual = comparer.Equals(x, y);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void AreNotEqualLambdaExpressionsWithDifferentNameWhenNotIgnoredTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create(compareLambdaNames: true);
            Expression? x = Expression.Lambda<Func<int>>(Expression.Constant(0), "p", Enumerable.Empty<ParameterExpression>());
            Expression? y = Expression.Lambda<Func<int>>(Expression.Constant(0), "q", Enumerable.Empty<ParameterExpression>());

            // Act
            var areEqual = comparer.Equals(x, y);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void AreNotEqualLambdaExpressionsWithDifferentTailCallTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create();
            Expression? x = Expression.Lambda<Func<int>>(Expression.Constant(0), "p", tailCall: true, Enumerable.Empty<ParameterExpression>());
            Expression? y = Expression.Lambda<Func<int>>(Expression.Constant(0), "p", tailCall: false, Enumerable.Empty<ParameterExpression>());

            // Act
            var areEqual = comparer.Equals(x, y);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void AreNotEqualConstantExpressionsWithDifferentValueTest()
        {
            // Arrange
            var comparer = ExpressionEqualityComparer.Create(compareLambdaNames: true);
            Expression? x = Expression.Constant(1);
            Expression? y = Expression.Constant(-1);

            // Act
            var areEqual = comparer.Equals(x, y);

            // Assert
            Assert.False(areEqual);
        }

        private sealed class IntAbsComparer : IEqualityComparer<object>
        {
            public bool Equals(object? x, object? y)
            {
                return Math.Abs((int)x) == Math.Abs((int)y);
            }

            public int GetHashCode(object obj)
            {
                return Math.Abs((int)obj).GetHashCode();
            }
        }

        [Fact]
        public void AreEqualConstantExpressionsWithDifferentValueWithCustomComparerTest()
        {
            // Arrange
            var constComparer = new IntAbsComparer();
            var comparer = ExpressionEqualityComparer.Create(constantComparer: constComparer);
            Expression? x = Expression.Constant(1);
            Expression? y = Expression.Constant(-1);

            // Act
            var areEqual = comparer.Equals(x, y);

            // Assert
            Assert.True(areEqual);
        }
    }
}
