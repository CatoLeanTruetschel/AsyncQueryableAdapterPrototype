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
using System.Globalization;
using Xunit;

namespace AsyncQueryableAdapterPrototype.Tests.Utils
{
    public static class AssertHelper
    {
        private const decimal DEFAULT_TOLERANCE = 0.0001M;

        public static bool AreEqualWithTolerance(decimal d1, decimal d2, decimal tolerance = DEFAULT_TOLERANCE)
        {
            return Math.Abs(d1 - d2) < Math.Abs(tolerance);
        }

        public static bool AreEqualWithTolerance(decimal? d1, decimal? d2, decimal tolerance = DEFAULT_TOLERANCE)
        {
            if (d1 is null)
            {
                return d2 is null;
            }

            if (d2 is null)
                return false;

            return AreEqualWithTolerance(d1.Value, d2.Value, tolerance);
        }

        public static void Equal(
            decimal expected,
            decimal actual,
            decimal tolerance = DEFAULT_TOLERANCE)
        {
            Assert.True(
                AreEqualWithTolerance(expected, actual, tolerance),
                $"Expected: {expected.ToString(CultureInfo.InvariantCulture)}, Actual: {actual.ToString(CultureInfo.InvariantCulture)}");
        }

        public static void Equal(
            decimal? expected,
            decimal? actual,
            decimal tolerance = DEFAULT_TOLERANCE)
        {
            Assert.True(
                AreEqualWithTolerance(expected, actual, tolerance),
                $"Expected: {(expected is null ? "null" : expected.Value.ToString(CultureInfo.InvariantCulture))}, Actual: {(actual is null ? "null" : actual.Value.ToString(CultureInfo.InvariantCulture))}");
        }

        public static bool AreEqualWithTolerance(double d1, double d2, double tolerance = (double)DEFAULT_TOLERANCE)
        {
            if (double.IsNaN(d1))
            {
                return double.IsNaN(d2);
            }

            if (double.IsNaN(d2))
                return false;

            if (double.IsInfinity(d1))
            {
                return double.IsInfinity(d2) && (d1 < 0 && d2 < 0 || d1 > 0 && d2 > 0);
            }

            if (double.IsInfinity(d2))
                return false;

            return Math.Abs(d1 - d2) < Math.Abs(tolerance);
        }

        public static bool AreEqualWithTolerance(double? d1, double? d2, double tolerance = (double)DEFAULT_TOLERANCE)
        {
            if (d1 is null)
            {
                return d2 is null;
            }

            if (d2 is null)
                return false;

            return AreEqualWithTolerance(d1.Value, d2.Value, tolerance);
        }

        public static void Equal(
            double expected,
            double actual,
            double tolerance = (double)DEFAULT_TOLERANCE)
        {
            Assert.True(
                AreEqualWithTolerance(expected, actual, tolerance),
                $"Expected: {expected.ToString(CultureInfo.InvariantCulture)}, Actual: {actual.ToString(CultureInfo.InvariantCulture)}");
        }

        public static void Equal(
           double? expected,
           double? actual,
           double tolerance = (double)DEFAULT_TOLERANCE)
        {
            Assert.True(
                AreEqualWithTolerance(expected, actual, tolerance),
                $"Expected: {(expected is null ? "null" : expected.Value.ToString(CultureInfo.InvariantCulture))}, Actual: {(actual is null ? "null" : actual.Value.ToString(CultureInfo.InvariantCulture))}");
        }

        public static bool AreEqualWithTolerance(float d1, float d2, float tolerance = (float)DEFAULT_TOLERANCE)
        {
            if (float.IsNaN(d1))
            {
                return float.IsNaN(d2);
            }

            if (float.IsNaN(d2))
                return false;

            if (float.IsInfinity(d1))
            {
                return float.IsInfinity(d2) && (d1 < 0 && d2 < 0 || d1 > 0 && d2 > 0);
            }

            if (float.IsInfinity(d2))
                return false;

#if SUPPORTS_MATH_F
            return MathF.Abs(d1 - d2) < MathF.Abs(tolerance);
#else
            return Math.Abs(d1 - d2) < Math.Abs(tolerance);
#endif
        }

        public static bool AreEqualWithTolerance(float? d1, float? d2, float tolerance = (float)DEFAULT_TOLERANCE)
        {
            if (d1 is null)
            {
                return d2 is null;
            }

            if (d2 is null)
                return false;

            return AreEqualWithTolerance(d1.Value, d2.Value, tolerance);
        }

        public static void Equal(
            float expected,
            float actual,
            float tolerance = (float)DEFAULT_TOLERANCE)
        {
            Assert.True(
                AreEqualWithTolerance(expected, actual, tolerance),
                $"Expected: {expected.ToString(CultureInfo.InvariantCulture)}, Actual: {actual.ToString(CultureInfo.InvariantCulture)}");
        }

        public static void Equal(
           float? expected,
           float? actual,
           float tolerance = (float)DEFAULT_TOLERANCE)
        {
            Assert.True(
                AreEqualWithTolerance(expected, actual, tolerance),
                $"Expected: {(expected is null ? "null" : expected.Value.ToString(CultureInfo.InvariantCulture))}, Actual: {(actual is null ? "null" : actual.Value.ToString(CultureInfo.InvariantCulture))}");
        }
    }
}
