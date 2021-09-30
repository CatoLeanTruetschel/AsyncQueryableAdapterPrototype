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
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using AsyncQueryableAdapterPrototype.Utils.Expressions;
using Xunit;

namespace AsyncQueryableAdapter.Utils.Expressions.Tests
{
    public sealed class CSharpExpressionFormatterTests
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void AssertLambda<TDelegate>(string expected, Expression body, params ParameterExpression[] parameters) where TDelegate : class
        {
            var name = GetTestCaseName();

            AssertExpression(expected, Expression.Lambda<TDelegate>(body, name, parameters));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string GetTestCaseName()
        {
            var stackTrace = new StackTrace();
            var stackFrame = stackTrace.GetFrame(2);

            return stackFrame.GetMethod().Name;
        }

        private static void AssertExpression(string expected, LambdaExpression expression)
        {
            var knownNamespaces = new[]
            {
                "System",
                "System.Collections.Generic",
                "System.Linq.Expressions",
                typeof(CSharpExpressionFormatterTests).Namespace
            };

            var result = new StringWriter();
            var csharp = new CSharpExpressionFormatter(new TextWriterFormatter(result), knownNamespaces);

            csharp.Write(expression);

            Assert.Equal(Normalize(expected), Normalize(result.ToString()));
        }

        private static string Normalize(string @string)
        {
            return @string.Replace("\r\n", "\n").Trim();
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Add()
        {
            var x = Expression.Parameter(typeof(int), "x");
            var y = Expression.Parameter(typeof(int), "y");

            var lambda = Expression.Lambda<Func<int, int, int>>(Expression.Add(x, y), x, y);

            AssertExpression(@"
int (int x, int y)
{
	return x + y;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void AssignVariable()
        {
            var a = Expression.Parameter(typeof(int), "a");
            var b = Expression.Parameter(typeof(int), "b");

            var c = Expression.Parameter(typeof(int), "c");

            var lambda = Expression.Lambda<Func<int, int, int>>(
                Expression.Block(
                    new[] { c },
                    Expression.Assign(c, Expression.AddChecked(a, b)),
                    c),
                a, b);

            AssertExpression(@"
int (int a, int b)
{
	int c;
	c = checked { a + b };
	return c;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void PopExpression()
        {
            var a = Expression.Parameter(typeof(int), "a");
            var b = Expression.Parameter(typeof(int), "b");

            var lambda = Expression.Lambda<Action<int, int>>(Expression.Add(a, b), a, b);

            AssertExpression(@"
void (int a, int b)
{
	a + b;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void ReturnFromIfElse()
        {
            var a = Expression.Parameter(typeof(int), "a");
            var b = Expression.Parameter(typeof(int), "b");

            var c = Expression.Parameter(typeof(int), "c");
            var d = Expression.Parameter(typeof(int), "d");

            var lambda = Expression.Lambda<Func<int, int, int>>(
                Expression.Condition(
                Expression.GreaterThan(a, b),
                Expression.Block(
                    new[] { c },
                    Expression.Assign(c, Expression.Multiply(a, b)),
                    c),
                Expression.Block(
                    new[] { d },
                    Expression.Assign(d, Expression.Divide(a, b)),
                d)),
                a, b);

            AssertExpression(@"
int (int a, int b)
{
	if (a > b)
	{
		int c;
		c = a * b;
		return c;
	}
	else
	{
		int d;
		d = a / b;
		return d;
	}
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void LogicalOperators()
        {
            var a = Expression.Parameter(typeof(bool), "a");
            var b = Expression.Parameter(typeof(bool), "b");

            var lambda = Expression.Lambda<Func<bool, bool, bool>>(
                Expression.Block(
                    Expression.Assign(a, Expression.AndAlso(a, b)),
                    Expression.Assign(a, Expression.OrElse(a, b)),
                    a),
                a, b);

            AssertExpression(@"
bool (bool a, bool b)
{
	a = a && b;
	a = a || b;
	return a;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void BinaryBooleanOperators()
        {
            var a = Expression.Parameter(typeof(int), "a");
            var b = Expression.Parameter(typeof(int), "b");
            var c = Expression.Parameter(typeof(bool), "c");

            var lambda = Expression.Lambda<Func<int, int, bool>>(
                Expression.Block(
                    new[] { c },
                    Expression.Assign(c, Expression.GreaterThan(a, b)),
                    Expression.Assign(c, Expression.GreaterThanOrEqual(a, b)),
                    Expression.Assign(c, Expression.LessThan(a, b)),
                    Expression.Assign(c, Expression.LessThanOrEqual(a, b)),
                    Expression.Assign(c, Expression.Equal(a, b)),
                    Expression.Assign(c, Expression.NotEqual(a, b)),
                    c),
                a, b);

            AssertExpression(@"
bool (int a, int b)
{
	bool c;
	c = a > b;
	c = a >= b;
	c = a < b;
	c = a <= b;
	c = a == b;
	c = a != b;
	return c;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void BinaryOperators()
        {
            var a = Expression.Parameter(typeof(int), "a");
            var b = Expression.Parameter(typeof(int), "b");

            var lambda = Expression.Lambda<Func<int, int, int>>(
                Expression.Block(
                    Expression.Assign(a, Expression.Add(a, b)),
                    Expression.Assign(a, Expression.And(a, b)),
                    Expression.Assign(a, Expression.Divide(a, b)),
                    Expression.Assign(a, Expression.ExclusiveOr(a, b)),
                    Expression.Assign(a, Expression.LeftShift(a, b)),
                    Expression.Assign(a, Expression.Modulo(a, b)),
                    Expression.Assign(a, Expression.Multiply(a, b)),
                    Expression.Assign(a, Expression.Or(a, b)),
                    Expression.Assign(a, Expression.RightShift(a, b)),
                    Expression.Assign(a, Expression.Subtract(a, b)),
                    a),
                a, b);

            AssertExpression(@"
int (int a, int b)
{
	a = a + b;
	a = a & b;
	a = a / b;
	a = a ^ b;
	a = a << b;
	a = a % b;
	a = a * b;
	a = a | b;
	a = a >> b;
	a = a - b;
	return a;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void BinaryCheckedOperators()
        {
            var a = Expression.Parameter(typeof(int), "a");
            var b = Expression.Parameter(typeof(int), "b");

            var lambda = Expression.Lambda<Func<int, int, int>>(
                Expression.Block(
                    Expression.Assign(a, Expression.AddChecked(a, b)),
                    Expression.Assign(a, Expression.MultiplyChecked(a, b)),
                    Expression.Assign(a, Expression.SubtractChecked(a, b)),
                    a),
                a, b);

            AssertExpression(@"
int (int a, int b)
{
	a = checked { a + b };
	a = checked { a * b };
	a = checked { a - b };
	return a;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void BinaryAssignOperators()
        {
            var a = Expression.Parameter(typeof(int), "a");
            var b = Expression.Parameter(typeof(int), "b");

            var lambda = Expression.Lambda<Func<int, int, int>>(
                Expression.Block(
                    Expression.AddAssign(a, b),
                    Expression.AndAssign(a, b),
                    Expression.DivideAssign(a, b),
                    Expression.ExclusiveOrAssign(a, b),
                    Expression.LeftShiftAssign(a, b),
                    Expression.ModuloAssign(a, b),
                    Expression.MultiplyAssign(a, b),
                    Expression.OrAssign(a, b),
                    Expression.RightShiftAssign(a, b),
                    Expression.SubtractAssign(a, b),
                    a),
                a, b);

            AssertExpression(@"
int (int a, int b)
{
	a += b;
	a &= b;
	a /= b;
	a ^= b;
	a <<= b;
	a %= b;
	a *= b;
	a |= b;
	a >>= b;
	a -= b;
	return a;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void BinaryAssignCheckedOperators()
        {
            var a = Expression.Parameter(typeof(int), "a");
            var b = Expression.Parameter(typeof(int), "b");

            var lambda = Expression.Lambda<Func<int, int, int>>(
                Expression.Block(
                    Expression.AddAssignChecked(a, b),
                    Expression.MultiplyAssignChecked(a, b),
                    Expression.SubtractAssignChecked(a, b),
                    a),
                a, b);

            AssertExpression(@"
int (int a, int b)
{
	checked { a += b };
	checked { a *= b };
	checked { a -= b };
	return a;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void UnaryOperators()
        {
            var a = Expression.Parameter(typeof(int), "a");

            var lambda = Expression.Lambda<Func<int, int>>(
                Expression.Block(
                    Expression.Assign(a, Expression.UnaryPlus(a)),
                    Expression.Assign(a, Expression.Negate(a)),
                    Expression.Assign(a, Expression.OnesComplement(a)),
                    a),
                a);

            AssertExpression(@"
int (int a)
{
	a = +a;
	a = -a;
	a = ~a;
	return a;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void UnaryCheckedOperators()
        {
            var a = Expression.Parameter(typeof(int), "a");

            var lambda = Expression.Lambda<Func<int, int>>(
                Expression.Block(
                    Expression.Assign(a, Expression.NegateChecked(a)),
                    a),
                a);

            AssertExpression(@"
int (int a)
{
	a = checked { -a };
	return a;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void UnaryLogicalOperators()
        {
            var a = Expression.Parameter(typeof(bool), "a");

            var lambda = Expression.Lambda<Func<bool, bool>>(
                Expression.Block(
                    Expression.Assign(a, Expression.Not(a)),
                    a),
                a);

            AssertExpression(@"
bool (bool a)
{
	a = !a;
	return a;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Power()
        {
            var d = Expression.Parameter(typeof(double), "d");
            var e = Expression.Parameter(typeof(double), "e");

            var lambda = Expression.Lambda<Func<double, double, double>>(
                Expression.Power(d, e),
                d, e);

            AssertExpression(@"
double (double d, double e)
{
	return Math.Pow(d, e);
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void PowerAssign()
        {
            var d = Expression.Parameter(typeof(double), "d");
            var e = Expression.Parameter(typeof(double), "e");

            var lambda = Expression.Lambda<Func<double, double, double>>(
                Expression.Block(
                    Expression.PowerAssign(d, e),
                    d),
                d, e);

            AssertExpression(@"
double (double d, double e)
{
	d = Math.Pow(d, e);
	return d;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Invocation()
        {
            var i = Expression.Parameter(typeof(int), "i");
            var f = Expression.Parameter(typeof(Func<int, int>), "f");

            var lambda = Expression.Lambda<Func<int, Func<int, int>, int>>(
                Expression.Invoke(f, i),
                i, f);

            AssertExpression(@"
int (int i, Func<int, int> f)
{
	return f(i);
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Coalesce()
        {
            var a = Expression.Parameter(typeof(string), "a");
            var b = Expression.Parameter(typeof(string), "b");

            var lambda = Expression.Lambda<Func<string, string, string>>(
                Expression.Coalesce(a, b),
                a, b);

            AssertExpression(@"
string (string a, string b)
{
	return a ?? b;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void ThrowNewNotSupportedException()
        {
            var lambda = Expression.Lambda<Action>(
                Expression.Throw(
                    Expression.New(typeof(NotSupportedException))));

            AssertExpression(@"
void ()
{
	throw new NotSupportedException();
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void IsTrueOrIsFalse()
        {
            var b = Expression.Parameter(typeof(bool), "b");

            var lambda = Expression.Lambda<Func<bool, bool>>(
                Expression.OrElse(
                    Expression.IsTrue(b),
                    Expression.IsFalse(b)),
                b);

            AssertExpression(@"
bool (bool b)
{
	return b == true || b == false;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void ArrayLength()
        {
            var array = Expression.Parameter(typeof(int[]), "array");

            var lambda = Expression.Lambda<Func<int[], int>>(
                Expression.ArrayLength(array),
                array);

            AssertExpression(@"
int (int[] array)
{
	return array.Length;
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void ArrayIndex()
        {
            var array = Expression.Parameter(typeof(int[]), "array");

            var lambda = Expression.Lambda<Func<int[], int>>(
                Expression.ArrayIndex(array, Expression.Constant(0)),
                array);

            AssertExpression(@"
int (int[] array)
{
	return array[0];
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void NewStruct()
        {
            var lambda = Expression.Lambda<Func<int>>(
                Expression.New(
                    typeof(int)));

            AssertExpression(@"
int ()
{
	return new int();
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void NewArrayInit()
        {
            var lambda = Expression.Lambda<Func<string[]>>(
                Expression.NewArrayInit(
                    typeof(string),
                    Expression.Constant("foo"),
                    Expression.Constant("bar"),
                    Expression.Constant("baz")));

            AssertExpression(@"
string[] ()
{
	return new string[] {""foo"", ""bar"", ""baz""};
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void NewArrayBounds()
        {
            var lambda = Expression.Lambda<Func<string[,,]>>(
                Expression.NewArrayBounds(
                    typeof(string),
                    Expression.Constant(2),
                    Expression.Constant(2),
                    Expression.Constant(2)));

            AssertExpression(@"
string[,,] ()
{
	return new string[2, 2, 2];
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Indexer()
        {
            var list = Expression.Parameter(typeof(List<string>), "list");
            var index = Expression.Parameter(typeof(int), "i");

            var lambda = Expression.Lambda<Func<List<string>, int, string>>(
                Expression.Property(list, "Item", index),
                list, index);

            AssertExpression(@"
string (List<string> list, int i)
{
	return list[i];
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void TernaryConditional()
        {
            var b = Expression.Parameter(typeof(bool), "b");

            var expression = Expression.Condition(b, Expression.Constant('t'), Expression.Constant('f'));

            AssertLambda<Func<bool, char>>(@"
char TernaryConditional(bool b)
{
	return b ? 't' : 'f';
}
", expression, b);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void ListInitList()
        {
            var listStringAdd = typeof(List<string>).GetMethod("Add");

            var expression = Expression.ListInit(
                Expression.New(typeof(List<string>)),
                Expression.ElementInit(listStringAdd, Expression.Constant("foo")),
                Expression.ElementInit(listStringAdd, Expression.Constant("bar")));

            AssertLambda<Func<List<string>>>(@"
List<string> ListInitList()
{
	return new List<string>() {""foo"", ""bar""};
}
", expression);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void ListInitDict()
        {
            var dictStringIntAdd = typeof(Dictionary<string, int>).GetMethod("Add");

            var expression = Expression.ListInit(
                Expression.New(typeof(Dictionary<string, int>)),
                Expression.ElementInit(dictStringIntAdd, Expression.Constant("foo"), Expression.Constant(1)),
                Expression.ElementInit(dictStringIntAdd, Expression.Constant("bar"), Expression.Constant(2)));

            AssertLambda<Func<Dictionary<string, int>>>(@"
Dictionary<string, int> ListInitDict()
{
	return new Dictionary<string, int>() {{""foo"", 1}, {""bar"", 2}};
}
", expression);
        }

        public class Foo
        {
            public int Bar { get; set; }
            public List<int> Baz { get; set; }
            public Gazonk Gaz { get; set; }
        }

        public class Gazonk
        {
            public int Identifier { get; set; }
            public string Name { get; set; }
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void MemberInit()
        {
            var listIntAdd = typeof(List<int>).GetMethod("Add");

            var expression = Expression.MemberInit(
                Expression.New(typeof(Foo)),
                Expression.Bind(typeof(Foo).GetProperty("Bar"), Expression.Constant(42)),
                Expression.ListBind(typeof(Foo).GetProperty("Baz"),
                    Expression.ElementInit(listIntAdd, Expression.Constant(4)),
                    Expression.ElementInit(listIntAdd, Expression.Constant(12))),
                Expression.MemberBind(typeof(Foo).GetProperty("Gaz"),
                    Expression.Bind(typeof(Gazonk).GetProperty("Identifier"), Expression.Constant(42)),
                    Expression.Bind(typeof(Gazonk).GetProperty("Name"), Expression.Constant("Gazonka"))));

            AssertLambda<Func<Foo>>(@"
CSharpExpressionFormatterTests.Foo MemberInit()
{
	return new CSharpExpressionFormatterTests.Foo()
	{
		Bar = 42,
		Baz = {4, 12},
		Gaz =
		{
			Identifier = 42,
			Name = ""Gazonka""
		}
	};
}
", expression);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void TypeAs()
        {
            var s = Expression.Parameter(typeof(string), "s");

            var expression = Expression.TypeAs(s, typeof(object));

            AssertLambda<Func<string, object>>(@"
object TypeAs(string s)
{
	return s as object;
}
", expression, s);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void TypeEqual()
        {
            var o = Expression.Parameter(typeof(object), "o");
            var expression = Expression.TypeEqual(o, typeof(List<int>));

            AssertLambda<Func<object, bool>>(@"
bool TypeEqual(object o)
{
	return o.GetType() == typeof(List<int>);
}
", expression, o);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void TypeIs()
        {
            var o = Expression.Parameter(typeof(object), "o");
            var expression = Expression.TypeIs(o, typeof(List<int>));

            AssertLambda<Func<object, bool>>(@"
bool TypeIs(object o)
{
	return o is List<int>;
}
", expression, o);
        }

        private static Expression CallWrite(object operand)
        {
            return Expression.Call(typeof(Console).GetMethod("WriteLine", new[] { operand.GetType() }), Expression.Constant(operand));
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void ExceptionHandling()
        {
            var i = Expression.Parameter(typeof(int), "i");
            var nre = Expression.Parameter(typeof(NullReferenceException), "e");

            var body = Expression.Block(
                CallWrite(0),
                Expression.MakeTry(null,
                    CallWrite(1),
                    CallWrite(4),
                    null,
                    new[] {
                        Expression.Catch (typeof (OutOfMemoryException), CallWrite (2), Expression.GreaterThan (i, Expression.Constant (10))),
                        Expression.Catch (nre, CallWrite (3))
                    }));

            AssertLambda<Action<int>>(@"
void ExceptionHandling(int i)
{
	Console.WriteLine(0);
	try
	{
		Console.WriteLine(1);
	}
	catch (OutOfMemoryException) if (i > 10)
	{
		Console.WriteLine(2);
	}
	catch (NullReferenceException e)
	{
		Console.WriteLine(3);
	}
	finally
	{
		Console.WriteLine(4);
	}
}
", body, i);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Loop()
        {
            var @break = Expression.Label();
            var @continue = Expression.Label();

            var i = Expression.Parameter(typeof(int), "i");
            var body = Expression.Block(
                new[] { i },
                Expression.Assign(i, Expression.Constant(0)),
                Expression.Loop(
                    Expression.Block(
                        Expression.Condition(
                            Expression.NotEqual(
                                Expression.Modulo(i, Expression.Constant(2)),
                                Expression.Constant(0)),
                            Expression.Continue(@continue),
                            Expression.Call(typeof(Console).GetMethod("WriteLine", new[] { typeof(int) }), i)),
                        Expression.Assign(i, Expression.Add(i, Expression.Constant(1))),
                        Expression.Condition(
                            Expression.LessThan(i, Expression.Constant(10)),
                            Expression.Continue(@continue),
                            Expression.Break(@break))),
                    @break,
                    @continue));

            AssertLambda<Action>(@"
void Loop()
{
	int i;
	i = 0;
	for (;;)
	{
		if ((i % 2) != 0)
		{
			continue;
		}
		else
		{
			Console.WriteLine(i);
		}
		i = i + 1;
		if (i < 10)
		{
			continue;
		}
		else
		{
			break;
		}
	}
}
", body);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Switch()
        {
            var i = Expression.Parameter(typeof(int), "i");

            var body = Expression.Switch(
                i,
                i,
                Expression.SwitchCase(
                    Expression.Add(i, Expression.Constant(2)),
                    Expression.Constant(0)),
                Expression.SwitchCase(
                    Expression.Multiply(i, Expression.Constant(4)),
                    Expression.Constant(2),
                    Expression.Constant(4)));

            AssertLambda<Func<int, int>>(@"
int Switch(int i)
{
	switch (i)
	{
		case 0:
		{
			return i + 2;
		}
		case 2:
		case 4:
		{
			return i * 4;
		}
		default:
		{
			return i;
		}
	}
}
", body, i);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void IncrementDecrement()
        {
            var i = Expression.Parameter(typeof(int), "i");

            var body = Expression.Block(
                Expression.Assign(i, Expression.Increment(i)),
                Expression.Assign(i, Expression.Decrement(i)),
                Expression.PreIncrementAssign(i),
                Expression.PostIncrementAssign(i),
                Expression.PreDecrementAssign(i),
                Expression.PostDecrementAssign(i),
                i);

            AssertLambda<Func<int, int>>(@"
int IncrementDecrement(int i)
{
	i = i + 1;
	i = i - 1;
	++i;
	i++;
	--i;
	i--;
	return i;
}
", body, i);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Default()
        {
            var body = Expression.Default(typeof(int));

            AssertLambda<Func<int>>(@"
int Default()
{
	return default(int);
}
", body);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Convert()
        {
            var o = Expression.Parameter(typeof(object), "o");

            var body = Expression.Convert(o, typeof(string));

            AssertLambda<Func<object, string>>(@"
string Convert(object o)
{
	return (string)o;
}
", body, o);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void ConvertChecked()
        {
            var i = Expression.Parameter(typeof(int), "i");

            var body = Expression.ConvertChecked(i, typeof(short));

            AssertLambda<Func<int, short>>(@"
short ConvertChecked(int i)
{
	return checked { (short)i };
}
", body, i);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Unbox()
        {
            var o = Expression.Parameter(typeof(object), "o");

            var body = Expression.Unbox(o, typeof(int));

            AssertLambda<Func<object, int>>(@"
int Unbox(object o)
{
	return (int)o;
}
", body, o);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void QuoteLambda()
        {
            var s = Expression.Parameter(typeof(string), "s");

            var lambda = Expression.Lambda<Func<string, Expression<Func<string>>>>(
                Expression.Quote(
                    Expression.Lambda<Func<string>>(s, new ParameterExpression[0])),
                s);

            AssertExpression(@"
Expression<Func<string>> (string s)
{
	return () =>
	{
		return s;
	};
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void For()
        {
            var l = Expression.Parameter(typeof(int), "l");

            var i = Expression.Variable(typeof(int), "i");

            var lambda = Expression.Lambda<Action<int>>(
                ExpressionEx.For(
                    i,
                    Expression.Constant(0),
                    Expression.LessThan(i, l),
                    Expression.PreIncrementAssign(i),
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new[] { typeof(int) }), i)),
                l);

            AssertExpression(@"
void (int l)
{
	for (int i = 0; i < l; ++i)
	{
		Console.WriteLine(i);
	}
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void ForEach()
        {
            var args = Expression.Parameter(typeof(string[]), "args");

            var s = Expression.Variable(typeof(string), "s");

            var lambda = Expression.Lambda<Action<string[]>>(
                ExpressionEx.ForEach(
                    s,
                    args,
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }), s)),
                args);

            AssertExpression(@"
void (string[] args)
{
	foreach (string s in args)
	{
		Console.WriteLine(s);
	}
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void Using()
        {
            var arg = Expression.Parameter(typeof(IDisposable), "arg");

            var lambda = Expression.Lambda<Action<IDisposable>>(
                ExpressionEx.Using(
                    arg,
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new[] { typeof(object) }), arg)),
                arg);

            AssertExpression(@"
void (IDisposable arg)
{
	using (arg)
	{
		Console.WriteLine(arg);
	}
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void DoWhile()
        {
            var i = Expression.Parameter(typeof(int), "i");
            var l = Expression.Parameter(typeof(int), "l");

            var lambda = Expression.Lambda<Action<int, int>>(
                ExpressionEx.DoWhile(
                    Expression.LessThan(i, l),
                    Expression.Block(
                        Expression.Call(typeof(Console).GetMethod("WriteLine", new[] { typeof(int) }), Expression.PostIncrementAssign(i)))),
                i, l);

            AssertExpression(@"
void (int i, int l)
{
	do
	{
		Console.WriteLine(i++);
	}
	while (i < l);
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void While()
        {
            var i = Expression.Parameter(typeof(int), "i");
            var l = Expression.Parameter(typeof(int), "l");

            var lambda = Expression.Lambda<Action<int, int>>(
                ExpressionEx.While(
                    Expression.LessThan(i, l),
                    Expression.Block(
                        Expression.Call(typeof(Console).GetMethod("WriteLine", new[] { typeof(int) }), Expression.PostIncrementAssign(i)))),
                i, l);

            AssertExpression(@"
void (int i, int l)
{
	while (i < l)
	{
		Console.WriteLine(i++);
	}
}
", lambda);
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void StringEmpty()
        {
            var lambda = Expression.Lambda<Func<string>>(
                Expression.Field(null, typeof(string).GetField("Empty")));

            AssertExpression(@"
string ()
{
	return string.Empty;
}
", lambda);
        }

#pragma warning disable xUnit1013, IDE0060
        public static void Fact<TFoo, TFighter>(TFoo foo, TFighter fighter)
#pragma warning restore xUnit1013, IDE0060
        {
        }

        [Fact, MethodImpl(MethodImplOptions.NoInlining)]
        public void GenericMethod()
        {
            var foo = Expression.Parameter(typeof(int), "foo");
            var fighter = Expression.Parameter(typeof(string), "fighter");

            var lambda = Expression.Lambda<Action<int, string>>(
                Expression.Call(typeof(CSharpExpressionFormatterTests), nameof(Fact), new[] { typeof(int), typeof(string) }, foo, fighter),
                foo,
                fighter);

            AssertExpression(@"
void (int foo, string fighter)
{
	CSharpExpressionFormatterTests.Fact<int, string>(foo, fighter);
}
", lambda);
        }
    }
}
