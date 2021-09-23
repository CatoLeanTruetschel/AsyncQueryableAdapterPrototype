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

#pragma warning disable VSTHRD200

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AsyncQueryableAdapter;
using AsyncQueryableAdapterPrototype.Tests.Utils;
using Microsoft.Extensions.Options;
using Xunit;

using AsyncQueryable = System.Linq.AsyncQueryable;

namespace AsyncQueryableAdapterPrototype.Tests
{
    public abstract partial class QueryAdapterSpecificationV2
    {
        private static partial ImmutableDictionary<Type, IEnumerable> BuildDataSets()
        {
            var builder = ImmutableDictionary.CreateBuilder<Type, IEnumerable>();

            // double? data-set
            var nullableDoubleDataSet = ImmutableList.CreateBuilder<double?>();
            nullableDoubleDataSet.Add(-25.234324D);
            nullableDoubleDataSet.Add(null);
            nullableDoubleDataSet.Add(-22.8885915D);
            nullableDoubleDataSet.Add(-20.542859D);
            nullableDoubleDataSet.Add(-18.1971265D);
            nullableDoubleDataSet.Add(-15.851393999999999D);
            nullableDoubleDataSet.Add(null);
            nullableDoubleDataSet.Add(-13.505661499999999D);
            nullableDoubleDataSet.Add(-11.159928999999998D);
            nullableDoubleDataSet.Add(-8.814196499999998D);
            nullableDoubleDataSet.Add(-6.468463999999997D);
            nullableDoubleDataSet.Add(null);
            nullableDoubleDataSet.Add(-4.122731499999997D);
            nullableDoubleDataSet.Add(-1.7769989999999969D);
            nullableDoubleDataSet.Add(0.5687335000000031D);
            nullableDoubleDataSet.Add(2.914466000000003D);
            nullableDoubleDataSet.Add(null);
            nullableDoubleDataSet.Add(5.260198500000003D);
            nullableDoubleDataSet.Add(7.6059310000000036D);
            nullableDoubleDataSet.Add(9.951663500000004D);
            nullableDoubleDataSet.Add(12.297396000000004D);
            nullableDoubleDataSet.Add(null);
            nullableDoubleDataSet.Add(14.643128500000005D);
            nullableDoubleDataSet.Add(16.988861000000004D);
            nullableDoubleDataSet.Add(19.334593500000004D);
            nullableDoubleDataSet.Add(21.680326000000004D);
            nullableDoubleDataSet.Add(null);
            nullableDoubleDataSet.Add(24.026058500000005D);
            nullableDoubleDataSet.Add(26.371791000000005D);
            nullableDoubleDataSet.Add(28.717523500000006D);
            nullableDoubleDataSet.Add(31.063256000000006D);
            nullableDoubleDataSet.Add(null);
            builder.Add(typeof(double?), nullableDoubleDataSet.ToImmutable());

            // double data-set
            var doubleDataSet = ImmutableList.CreateBuilder<double>();
            doubleDataSet.Add(-25.234324D);
            doubleDataSet.Add(-22.8885915D);
            doubleDataSet.Add(-20.542859D);
            doubleDataSet.Add(-18.1971265D);
            doubleDataSet.Add(-15.851393999999999D);
            doubleDataSet.Add(-13.505661499999999D);
            doubleDataSet.Add(-11.159928999999998D);
            doubleDataSet.Add(-8.814196499999998D);
            doubleDataSet.Add(-6.468463999999997D);
            doubleDataSet.Add(-4.122731499999997D);
            doubleDataSet.Add(-1.7769989999999969D);
            doubleDataSet.Add(0.5687335000000031D);
            doubleDataSet.Add(2.914466000000003D);
            doubleDataSet.Add(5.260198500000003D);
            doubleDataSet.Add(7.6059310000000036D);
            doubleDataSet.Add(9.951663500000004D);
            doubleDataSet.Add(12.297396000000004D);
            doubleDataSet.Add(14.643128500000005D);
            doubleDataSet.Add(16.988861000000004D);
            doubleDataSet.Add(19.334593500000004D);
            doubleDataSet.Add(21.680326000000004D);
            doubleDataSet.Add(24.026058500000005D);
            doubleDataSet.Add(26.371791000000005D);
            doubleDataSet.Add(28.717523500000006D);
            doubleDataSet.Add(31.063256000000006D);
            builder.Add(typeof(double), doubleDataSet.ToImmutable());

            // decimal data-set
            var decimalDataSet = ImmutableList.CreateBuilder<decimal>();
            decimalDataSet.Add(-25.234324M);
            decimalDataSet.Add(-22.8885915M);
            decimalDataSet.Add(-20.542859M);
            decimalDataSet.Add(-18.1971265M);
            decimalDataSet.Add(-15.851394M);
            decimalDataSet.Add(-13.5056615M);
            decimalDataSet.Add(-11.159929M);
            decimalDataSet.Add(-8.8141965M);
            decimalDataSet.Add(-6.468464M);
            decimalDataSet.Add(-4.1227315M);
            decimalDataSet.Add(-1.776999M);
            decimalDataSet.Add(0.568733500000003M);
            decimalDataSet.Add(2.914466M);
            decimalDataSet.Add(5.2601985M);
            decimalDataSet.Add(7.605931M);
            decimalDataSet.Add(9.9516635M);
            decimalDataSet.Add(12.297396M);
            decimalDataSet.Add(14.6431285M);
            decimalDataSet.Add(16.988861M);
            decimalDataSet.Add(19.3345935M);
            decimalDataSet.Add(21.680326M);
            decimalDataSet.Add(24.0260585M);
            decimalDataSet.Add(26.371791M);
            decimalDataSet.Add(28.7175235M);
            decimalDataSet.Add(31.063256M);
            builder.Add(typeof(decimal), decimalDataSet.ToImmutable());

            // decimal? data-set
            var nullableDecimalDataSet = ImmutableList.CreateBuilder<decimal?>();
            nullableDecimalDataSet.Add(-25.234324M);
            nullableDecimalDataSet.Add(null);
            nullableDecimalDataSet.Add(-22.8885915M);
            nullableDecimalDataSet.Add(-20.542859M);
            nullableDecimalDataSet.Add(-18.1971265M);
            nullableDecimalDataSet.Add(-15.851394M);
            nullableDecimalDataSet.Add(null);
            nullableDecimalDataSet.Add(-13.5056615M);
            nullableDecimalDataSet.Add(-11.159929M);
            nullableDecimalDataSet.Add(-8.8141965M);
            nullableDecimalDataSet.Add(-6.468464M);
            nullableDecimalDataSet.Add(null);
            nullableDecimalDataSet.Add(-4.1227315M);
            nullableDecimalDataSet.Add(-1.776999M);
            nullableDecimalDataSet.Add(0.568733500000003M);
            nullableDecimalDataSet.Add(2.914466M);
            nullableDecimalDataSet.Add(null);
            nullableDecimalDataSet.Add(5.2601985M);
            nullableDecimalDataSet.Add(7.605931M);
            nullableDecimalDataSet.Add(9.9516635M);
            nullableDecimalDataSet.Add(12.297396M);
            nullableDecimalDataSet.Add(null);
            nullableDecimalDataSet.Add(14.6431285M);
            nullableDecimalDataSet.Add(16.988861M);
            nullableDecimalDataSet.Add(19.3345935M);
            nullableDecimalDataSet.Add(21.680326M);
            nullableDecimalDataSet.Add(null);
            nullableDecimalDataSet.Add(24.0260585M);
            nullableDecimalDataSet.Add(26.371791M);
            nullableDecimalDataSet.Add(28.7175235M);
            nullableDecimalDataSet.Add(31.063256M);
            nullableDecimalDataSet.Add(null);
            builder.Add(typeof(decimal?), nullableDecimalDataSet.ToImmutable());

            // float? data-set
            var nullableSingleDataSet = ImmutableList.CreateBuilder<float?>();
            nullableSingleDataSet.Add(-25.234324F);
            nullableSingleDataSet.Add(null);
            nullableSingleDataSet.Add(-22.888592F);
            nullableSingleDataSet.Add(-20.542858F);
            nullableSingleDataSet.Add(-18.197126F);
            nullableSingleDataSet.Add(-15.851394F);
            nullableSingleDataSet.Add(null);
            nullableSingleDataSet.Add(-13.505662F);
            nullableSingleDataSet.Add(-11.159929F);
            nullableSingleDataSet.Add(-8.814197F);
            nullableSingleDataSet.Add(-6.468464F);
            nullableSingleDataSet.Add(null);
            nullableSingleDataSet.Add(-4.1227317F);
            nullableSingleDataSet.Add(-1.776999F);
            nullableSingleDataSet.Add(0.5687335F);
            nullableSingleDataSet.Add(2.914466F);
            nullableSingleDataSet.Add(null);
            nullableSingleDataSet.Add(5.2601986F);
            nullableSingleDataSet.Add(7.605931F);
            nullableSingleDataSet.Add(9.951664F);
            nullableSingleDataSet.Add(12.297396F);
            nullableSingleDataSet.Add(null);
            nullableSingleDataSet.Add(14.643128F);
            nullableSingleDataSet.Add(16.988861F);
            nullableSingleDataSet.Add(19.334593F);
            nullableSingleDataSet.Add(21.680326F);
            nullableSingleDataSet.Add(null);
            nullableSingleDataSet.Add(24.026058F);
            nullableSingleDataSet.Add(26.371792F);
            nullableSingleDataSet.Add(28.717524F);
            nullableSingleDataSet.Add(31.063255F);
            nullableSingleDataSet.Add(null);
            builder.Add(typeof(float?), nullableSingleDataSet.ToImmutable());

            // float data-set
            var singleDataSet = ImmutableList.CreateBuilder<float>();
            singleDataSet.Add(-25.234324F);
            singleDataSet.Add(-22.888592F);
            singleDataSet.Add(-20.542858F);
            singleDataSet.Add(-18.197126F);
            singleDataSet.Add(-15.851394F);
            singleDataSet.Add(-13.505662F);
            singleDataSet.Add(-11.159929F);
            singleDataSet.Add(-8.814197F);
            singleDataSet.Add(-6.468464F);
            singleDataSet.Add(-4.1227317F);
            singleDataSet.Add(-1.776999F);
            singleDataSet.Add(0.5687335F);
            singleDataSet.Add(2.914466F);
            singleDataSet.Add(5.2601986F);
            singleDataSet.Add(7.605931F);
            singleDataSet.Add(9.951664F);
            singleDataSet.Add(12.297396F);
            singleDataSet.Add(14.643128F);
            singleDataSet.Add(16.988861F);
            singleDataSet.Add(19.334593F);
            singleDataSet.Add(21.680326F);
            singleDataSet.Add(24.026058F);
            singleDataSet.Add(26.371792F);
            singleDataSet.Add(28.717524F);
            singleDataSet.Add(31.063255F);
            builder.Add(typeof(float), singleDataSet.ToImmutable());

            // long data-set
            var int64DataSet = ImmutableList.CreateBuilder<long>();
            int64DataSet.Add(-25L);
            int64DataSet.Add(-23L);
            int64DataSet.Add(-21L);
            int64DataSet.Add(-18L);
            int64DataSet.Add(-16L);
            int64DataSet.Add(-14L);
            int64DataSet.Add(-11L);
            int64DataSet.Add(-9L);
            int64DataSet.Add(-6L);
            int64DataSet.Add(-4L);
            int64DataSet.Add(-2L);
            int64DataSet.Add(1L);
            int64DataSet.Add(3L);
            int64DataSet.Add(5L);
            int64DataSet.Add(8L);
            int64DataSet.Add(10L);
            int64DataSet.Add(12L);
            int64DataSet.Add(15L);
            int64DataSet.Add(17L);
            int64DataSet.Add(19L);
            int64DataSet.Add(22L);
            int64DataSet.Add(24L);
            int64DataSet.Add(26L);
            int64DataSet.Add(29L);
            int64DataSet.Add(31L);
            builder.Add(typeof(long), int64DataSet.ToImmutable());

            // int data-set
            var int32DataSet = ImmutableList.CreateBuilder<int>();
            int32DataSet.Add(-25);
            int32DataSet.Add(-23);
            int32DataSet.Add(-21);
            int32DataSet.Add(-18);
            int32DataSet.Add(-16);
            int32DataSet.Add(-14);
            int32DataSet.Add(-11);
            int32DataSet.Add(-9);
            int32DataSet.Add(-6);
            int32DataSet.Add(-4);
            int32DataSet.Add(-2);
            int32DataSet.Add(1);
            int32DataSet.Add(3);
            int32DataSet.Add(5);
            int32DataSet.Add(8);
            int32DataSet.Add(10);
            int32DataSet.Add(12);
            int32DataSet.Add(15);
            int32DataSet.Add(17);
            int32DataSet.Add(19);
            int32DataSet.Add(22);
            int32DataSet.Add(24);
            int32DataSet.Add(26);
            int32DataSet.Add(29);
            int32DataSet.Add(31);
            builder.Add(typeof(int), int32DataSet.ToImmutable());

            // long? data-set
            var nullableInt64DataSet = ImmutableList.CreateBuilder<long?>();
            nullableInt64DataSet.Add(-25L);
            nullableInt64DataSet.Add(null);
            nullableInt64DataSet.Add(-23L);
            nullableInt64DataSet.Add(-21L);
            nullableInt64DataSet.Add(-18L);
            nullableInt64DataSet.Add(-16L);
            nullableInt64DataSet.Add(null);
            nullableInt64DataSet.Add(-14L);
            nullableInt64DataSet.Add(-11L);
            nullableInt64DataSet.Add(-9L);
            nullableInt64DataSet.Add(-6L);
            nullableInt64DataSet.Add(null);
            nullableInt64DataSet.Add(-4L);
            nullableInt64DataSet.Add(-2L);
            nullableInt64DataSet.Add(1L);
            nullableInt64DataSet.Add(3L);
            nullableInt64DataSet.Add(null);
            nullableInt64DataSet.Add(5L);
            nullableInt64DataSet.Add(8L);
            nullableInt64DataSet.Add(10L);
            nullableInt64DataSet.Add(12L);
            nullableInt64DataSet.Add(null);
            nullableInt64DataSet.Add(15L);
            nullableInt64DataSet.Add(17L);
            nullableInt64DataSet.Add(19L);
            nullableInt64DataSet.Add(22L);
            nullableInt64DataSet.Add(null);
            nullableInt64DataSet.Add(24L);
            nullableInt64DataSet.Add(26L);
            nullableInt64DataSet.Add(29L);
            nullableInt64DataSet.Add(31L);
            nullableInt64DataSet.Add(null);
            builder.Add(typeof(long?), nullableInt64DataSet.ToImmutable());

            // int? data-set
            var nullableInt32DataSet = ImmutableList.CreateBuilder<int?>();
            nullableInt32DataSet.Add(-25);
            nullableInt32DataSet.Add(null);
            nullableInt32DataSet.Add(-23);
            nullableInt32DataSet.Add(-21);
            nullableInt32DataSet.Add(-18);
            nullableInt32DataSet.Add(-16);
            nullableInt32DataSet.Add(null);
            nullableInt32DataSet.Add(-14);
            nullableInt32DataSet.Add(-11);
            nullableInt32DataSet.Add(-9);
            nullableInt32DataSet.Add(-6);
            nullableInt32DataSet.Add(null);
            nullableInt32DataSet.Add(-4);
            nullableInt32DataSet.Add(-2);
            nullableInt32DataSet.Add(1);
            nullableInt32DataSet.Add(3);
            nullableInt32DataSet.Add(null);
            nullableInt32DataSet.Add(5);
            nullableInt32DataSet.Add(8);
            nullableInt32DataSet.Add(10);
            nullableInt32DataSet.Add(12);
            nullableInt32DataSet.Add(null);
            nullableInt32DataSet.Add(15);
            nullableInt32DataSet.Add(17);
            nullableInt32DataSet.Add(19);
            nullableInt32DataSet.Add(22);
            nullableInt32DataSet.Add(null);
            nullableInt32DataSet.Add(24);
            nullableInt32DataSet.Add(26);
            nullableInt32DataSet.Add(29);
            nullableInt32DataSet.Add(31);
            nullableInt32DataSet.Add(null);
            builder.Add(typeof(int?), nullableInt32DataSet.ToImmutable());

            return builder.ToImmutable();
        }
    }
}
