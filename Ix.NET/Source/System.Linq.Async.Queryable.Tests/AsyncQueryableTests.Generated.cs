﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class AsyncQueryableExTests
    {
        [Fact]
        public void Aggregate1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, int>>)), ane => ane.ParamName == "accumulator");

            var res = AsyncQueryable.Aggregate<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, Task<int>>>)), ane => ane.ParamName == "accumulator");

            var res = AsyncQueryable.Aggregate<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, int>>), CancellationToken.None), ane => ane.ParamName == "accumulator");

            var res = AsyncQueryable.Aggregate<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "accumulator");

            var res = AsyncQueryable.Aggregate<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int>(default(IAsyncQueryable<int>), 1, (int arg0, int arg1) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, default(Expression<Func<int, int, int>>)), ane => ane.ParamName == "accumulator");

            var res = AsyncQueryable.Aggregate<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int>(default(IAsyncQueryable<int>), 1, (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, default(Expression<Func<int, int, Task<int>>>)), ane => ane.ParamName == "accumulator");

            var res = AsyncQueryable.Aggregate<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate7()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int>(default(IAsyncQueryable<int>), 1, (int arg0, int arg1) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, default(Expression<Func<int, int, int>>), CancellationToken.None), ane => ane.ParamName == "accumulator");

            var res = AsyncQueryable.Aggregate<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate8()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int>(default(IAsyncQueryable<int>), 1, (int arg0, int arg1) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, default(Expression<Func<int, int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "accumulator");

            var res = AsyncQueryable.Aggregate<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate9()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(default(IAsyncQueryable<int>), 1, (int arg0, int arg1) => default(int), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, default(Expression<Func<int, int, int>>), (int arg0) => default(int)), ane => ane.ParamName == "accumulator");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(int), default(Expression<Func<int, int>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(int), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate10()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(default(IAsyncQueryable<int>), 1, (int arg0, int arg1) => default(Task<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, default(Expression<Func<int, int, Task<int>>>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "accumulator");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(Task<int>), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(Task<int>), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate11()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(default(IAsyncQueryable<int>), 1, (int arg0, int arg1) => default(int), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, default(Expression<Func<int, int, int>>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "accumulator");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(int), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(int), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Aggregate12()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(default(IAsyncQueryable<int>), 1, (int arg0, int arg1) => default(Task<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, default(Expression<Func<int, int, Task<int>>>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "accumulator");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(Task<int>), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.Aggregate<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, (int arg0, int arg1) => default(Task<int>), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void All1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.All<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.All<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.All<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void All2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.All<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.All<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.All<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void All3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.All<int>(default(IAsyncQueryable<int>), (int arg0) => true, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.All<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.All<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void All4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.All<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.All<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.All<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Any1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Any<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Any<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Any2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Any<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Any<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Any3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Any<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Any<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Any<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Any4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Any<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Any<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Any<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Any5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Any<int>(default(IAsyncQueryable<int>), (int arg0) => true, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Any<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Any<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Any6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Any<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Any<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Any<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Append1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Append<int>(default(IAsyncQueryable<int>), 1), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Append<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Average1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<double>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new double[] { default(double) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<decimal>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new decimal[] { default(decimal) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<int?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new int?[] { default(int?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<long?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new long?[] { default(long?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<float?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new float?[] { default(float?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<double?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new double?[] { default(double?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average7()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<decimal?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new decimal?[] { default(decimal?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average8()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average9()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<long>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new long[] { default(long) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average10()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<float>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new float[] { default(float) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average11()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<float>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new float[] { default(float) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average12()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<double>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new double[] { default(double) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average13()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<decimal>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new decimal[] { default(decimal) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average14()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<int?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new int?[] { default(int?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average15()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<long?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new long?[] { default(long?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average16()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<float?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new float?[] { default(float?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average17()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<double?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new double?[] { default(double?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average18()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<decimal?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new decimal?[] { default(decimal?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average19()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average20()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average(default(IAsyncQueryable<long>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Average(new long[] { default(long) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average21()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(float)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(float));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average22()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average23()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(double)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(double));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average24()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average25()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(decimal)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(decimal));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average26()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average27()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average28()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average29()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<long>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<long>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average30()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average31()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<float>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<float>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average32()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average33()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<double>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<double>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average34()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average35()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<decimal>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<decimal>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average36()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average37()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average38()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average39()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(long)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(long));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average40()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average41()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(float), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(float), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average42()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average43()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(double), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(double), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average44()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average45()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(decimal), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(decimal), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average46()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average47()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average48()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average49()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<long>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<long>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average50()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average51()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<float>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<float>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average52()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average53()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<double>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<double>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average54()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average55()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<decimal>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<decimal>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average56()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average57()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average58()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average59()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(long), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(long), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Average60()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Average<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Cast1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Cast<int>(default(IAsyncQueryable<object>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Cast<int>(new object[] { default(object) }.ToAsyncEnumerable().AsAsyncQueryable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Concat1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Concat<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable()), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Concat<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>)), ane => ane.ParamName == "second");

            var res = AsyncQueryable.Concat<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Contains1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Contains<int>(default(IAsyncQueryable<int>), 1), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Contains<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Contains2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Contains<int>(default(IAsyncQueryable<int>), 1, CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Contains<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Contains3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Contains<int>(default(IAsyncQueryable<int>), 1, EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Contains<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.Contains<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Contains4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Contains<int>(default(IAsyncQueryable<int>), 1, EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Contains<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.Contains<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Count1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Count<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Count<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Count2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Count<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Count<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Count3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Count<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Count<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Count<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Count4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Count<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Count<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Count<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Count5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Count<int>(default(IAsyncQueryable<int>), (int arg0) => true, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Count<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Count<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Count6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Count<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Count<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Count<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void DefaultIfEmpty1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.DefaultIfEmpty<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.DefaultIfEmpty<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void DefaultIfEmpty2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.DefaultIfEmpty<int>(default(IAsyncQueryable<int>), 1), ane => ane.ParamName == "source");

            var res = AsyncQueryable.DefaultIfEmpty<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Distinct1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Distinct<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Distinct<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Distinct2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Distinct<int>(default(IAsyncQueryable<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Distinct<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.Distinct<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void ElementAt1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ElementAt<int>(default(IAsyncQueryable<int>), 1), ane => ane.ParamName == "source");

            var res = AsyncQueryable.ElementAt<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ElementAt2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ElementAt<int>(default(IAsyncQueryable<int>), 1, CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.ElementAt<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ElementAtOrDefault1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ElementAtOrDefault<int>(default(IAsyncQueryable<int>), 1), ane => ane.ParamName == "source");

            var res = AsyncQueryable.ElementAtOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ElementAtOrDefault2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ElementAtOrDefault<int>(default(IAsyncQueryable<int>), 1, CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.ElementAtOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Except1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Except<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable()), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Except<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>)), ane => ane.ParamName == "second");

            var res = AsyncQueryable.Except<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Except2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Except<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), EqualityComparer<int>.Default), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Except<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "second");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Except<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.Except<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void First1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.First<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.First<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void First2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.First<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.First<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void First3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.First<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.First<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.First<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void First4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.First<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.First<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.First<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void First5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.First<int>(default(IAsyncQueryable<int>), (int arg0) => true, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.First<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.First<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void First6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.First<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.First<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.First<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void FirstOrDefault1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.FirstOrDefault<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.FirstOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void FirstOrDefault2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.FirstOrDefault<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.FirstOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void FirstOrDefault3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.FirstOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.FirstOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.FirstOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void FirstOrDefault4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.FirstOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.FirstOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.FirstOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void FirstOrDefault5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.FirstOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => true, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.FirstOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.FirstOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void FirstOrDefault6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.FirstOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.FirstOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.FirstOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void GroupBy1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.GroupBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.GroupBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.GroupBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.GroupBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "elementSelector");

            var res = AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int)), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>)), ane => ane.ParamName == "elementSelector");

            var res = AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy7()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0, IAsyncEnumerable<int> arg1) => default(int)), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, IAsyncEnumerable<int>, int>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy8()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>)), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, IAsyncEnumerable<int>, Task<int>>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy9()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), EqualityComparer<int>.Default), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy10()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>), EqualityComparer<int>.Default), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy11()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, IAsyncEnumerable<int>, int>>), EqualityComparer<int>.Default), ane => ane.ParamName == "resultSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy12()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, IAsyncEnumerable<int>, Task<int>>>), EqualityComparer<int>.Default), ane => ane.ParamName == "resultSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.GroupBy<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy13()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int)), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>), (int arg0, IAsyncEnumerable<int> arg1) => default(int)), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), default(Expression<Func<int, IAsyncEnumerable<int>, int>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy14()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>)), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>)), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(Expression<Func<int, IAsyncEnumerable<int>, Task<int>>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy15()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), default(Expression<Func<int, IAsyncEnumerable<int>, int>>), EqualityComparer<int>.Default), ane => ane.ParamName == "resultSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupBy16()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(Expression<Func<int, IAsyncEnumerable<int>, Task<int>>>), EqualityComparer<int>.Default), ane => ane.ParamName == "resultSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.GroupBy<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupJoin1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int)), ane => ane.ParamName == "outer");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int)), ane => ane.ParamName == "inner");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, int>>), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int)), ane => ane.ParamName == "outerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), default(Expression<Func<int, int>>), (int arg0, IAsyncEnumerable<int> arg1) => default(int)), ane => ane.ParamName == "innerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), default(Expression<Func<int, IAsyncEnumerable<int>, int>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupJoin2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>)), ane => ane.ParamName == "outer");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>)), ane => ane.ParamName == "inner");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>)), ane => ane.ParamName == "outerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>)), ane => ane.ParamName == "innerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(Expression<Func<int, IAsyncEnumerable<int>, Task<int>>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupJoin3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "outer");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "inner");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, int>>), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "outerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), default(Expression<Func<int, int>>), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "innerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), default(Expression<Func<int, IAsyncEnumerable<int>, int>>), EqualityComparer<int>.Default), ane => ane.ParamName == "resultSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, IAsyncEnumerable<int> arg1) => default(int), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void GroupJoin4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "outer");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "inner");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "outerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "innerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(Expression<Func<int, IAsyncEnumerable<int>, Task<int>>>), EqualityComparer<int>.Default), ane => ane.ParamName == "resultSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.GroupJoin<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, IAsyncEnumerable<int> arg1) => default(Task<int>), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Intersect1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Intersect<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable()), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Intersect<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>)), ane => ane.ParamName == "second");

            var res = AsyncQueryable.Intersect<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Intersect2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Intersect<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), EqualityComparer<int>.Default), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Intersect<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "second");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Intersect<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.Intersect<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Join1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "outer");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), (int arg0) => default(int), (int arg0) => default(int), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "inner");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, int>>), (int arg0) => default(int), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "outerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), default(Expression<Func<int, int>>), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "innerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), default(Expression<Func<int, int, int>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, int arg1) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Join2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "outer");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "inner");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "outerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "innerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(Expression<Func<int, int, Task<int>>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, int arg1) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Join3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, int arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "outer");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), (int arg0) => default(int), (int arg0) => default(int), (int arg0, int arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "inner");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, int>>), (int arg0) => default(int), (int arg0, int arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "outerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), default(Expression<Func<int, int>>), (int arg0, int arg1) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "innerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), default(Expression<Func<int, int, int>>), EqualityComparer<int>.Default), ane => ane.ParamName == "resultSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, int arg1) => default(int), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(int), (int arg0) => default(int), (int arg0, int arg1) => default(int), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Join4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, int arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "outer");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, int arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "inner");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), (int arg0, int arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "outerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), (int arg0, int arg1) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "innerKeySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(Expression<Func<int, int, Task<int>>>), EqualityComparer<int>.Default), ane => ane.ParamName == "resultSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, int arg1) => default(Task<int>), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.Join<int, int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), (int arg0, int arg1) => default(Task<int>), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Last1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Last<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Last<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Last2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Last<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Last<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Last3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Last<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Last<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Last<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Last4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Last<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Last<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Last<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Last5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Last<int>(default(IAsyncQueryable<int>), (int arg0) => true, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Last<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Last<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Last6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Last<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Last<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Last<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LastOrDefault1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LastOrDefault<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.LastOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LastOrDefault2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LastOrDefault<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.LastOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LastOrDefault3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LastOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LastOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.LastOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LastOrDefault4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LastOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LastOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.LastOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LastOrDefault5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LastOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => true, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LastOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.LastOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LastOrDefault6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LastOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LastOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.LastOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LongCount1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LongCount<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.LongCount<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LongCount2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LongCount<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.LongCount<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LongCount3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LongCount<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LongCount<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.LongCount<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LongCount4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LongCount<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LongCount<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.LongCount<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LongCount5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LongCount<int>(default(IAsyncQueryable<int>), (int arg0) => true, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LongCount<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.LongCount<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void LongCount6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LongCount<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.LongCount<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.LongCount<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<long>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new long[] { default(long) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<float>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new float[] { default(float) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<double>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new double[] { default(double) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<decimal>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new decimal[] { default(decimal) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<int?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new int?[] { default(int?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max7()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<long?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new long?[] { default(long?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max8()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<float?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new float?[] { default(float?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max9()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<double?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new double?[] { default(double?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max10()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<decimal?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new decimal?[] { default(decimal?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max11()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max12()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<long>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new long[] { default(long) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max13()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<float>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new float[] { default(float) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max14()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<double>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new double[] { default(double) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max15()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<decimal>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new decimal[] { default(decimal) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max16()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<int?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new int?[] { default(int?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max17()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<long?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new long?[] { default(long?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max18()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<float?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new float?[] { default(float?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max19()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<double?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new double?[] { default(double?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max20()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max(default(IAsyncQueryable<decimal?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max(new decimal?[] { default(decimal?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max21()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max22()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max23()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<decimal>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<decimal>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max24()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max25()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max26()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max27()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(long)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(long));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max28()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max29()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(float)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(float));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max30()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max31()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(double)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(double));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max32()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max33()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(decimal)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(decimal));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max34()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max35()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max36()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max37()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<long>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<long>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max38()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max39()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<float>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<float>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max40()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max41()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<double>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<double>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max42()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max43()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<decimal>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<decimal>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max44()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max45()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max46()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max47()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(long), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(long), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max48()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max49()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(float), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(float), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max50()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max51()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(double), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(double), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max52()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max53()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(decimal), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(decimal), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max54()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max55()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max56()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max57()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<long>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<long>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max58()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max59()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<float>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<float>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max60()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max61()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<double>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<double>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max62()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max63()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max64()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max65()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Max66()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Max<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Max<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<decimal?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new decimal?[] { default(decimal?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<long>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new long[] { default(long) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<float>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new float[] { default(float) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<double>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new double[] { default(double) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<decimal>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new decimal[] { default(decimal) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min7()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<int?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new int?[] { default(int?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min8()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<long?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new long?[] { default(long?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min9()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<float?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new float?[] { default(float?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min10()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<double?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new double?[] { default(double?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min11()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<decimal?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new decimal?[] { default(decimal?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min12()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min13()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<long>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new long[] { default(long) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min14()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<float>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new float[] { default(float) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min15()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<double>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new double[] { default(double) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min16()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<decimal>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new decimal[] { default(decimal) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min17()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<int?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new int?[] { default(int?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min18()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<long?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new long?[] { default(long?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min19()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<float?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new float?[] { default(float?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min20()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min(default(IAsyncQueryable<double?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min(new double?[] { default(double?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min21()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min22()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min23()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<decimal>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<decimal>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min24()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min25()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min26()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min27()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(long)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(long));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min28()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min29()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(float)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(float));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min30()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min31()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(double)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(double));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min32()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min33()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(decimal)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(decimal));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min34()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min35()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min36()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min37()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<long>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<long>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min38()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min39()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<float>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<float>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min40()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min41()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<double>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<double>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min42()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min43()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<decimal>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<decimal>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min44()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min45()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min46()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min47()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(long), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(long), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min48()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min49()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(float), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(float), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min50()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min51()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(double), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(double), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min52()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min53()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(decimal), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(decimal), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min54()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min55()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min56()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min57()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<long>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<long>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min58()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min59()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<float>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<float>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min60()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min61()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<double>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<double>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min62()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min63()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min64()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min65()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Min66()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Min<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Min<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void OfType1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OfType<int>(default(IAsyncQueryable<object>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.OfType<int>(new object[] { default(object) }.ToAsyncEnumerable().AsAsyncQueryable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void OrderBy1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderBy<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.OrderBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
        }

        [Fact]
        public void OrderBy2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderBy<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.OrderBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
        }

        [Fact]
        public void OrderBy3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderBy<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), Comparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), Comparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(IComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.OrderBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), Comparer<int>.Default);
        }

        [Fact]
        public void OrderBy4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderBy<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), Comparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), Comparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(IComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.OrderBy<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), Comparer<int>.Default);
        }

        [Fact]
        public void OrderByDescending1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderByDescending<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderByDescending<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.OrderByDescending<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
        }

        [Fact]
        public void OrderByDescending2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderByDescending<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderByDescending<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.OrderByDescending<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
        }

        [Fact]
        public void OrderByDescending3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderByDescending<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), Comparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderByDescending<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), Comparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderByDescending<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(IComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.OrderByDescending<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), Comparer<int>.Default);
        }

        [Fact]
        public void OrderByDescending4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderByDescending<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), Comparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderByDescending<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), Comparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.OrderByDescending<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(IComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.OrderByDescending<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), Comparer<int>.Default);
        }

        [Fact]
        public void Prepend1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Prepend<int>(default(IAsyncQueryable<int>), 1), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Prepend<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Reverse1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Reverse<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Reverse<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Select1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Select<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Select<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Select<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Select2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Select<int, int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Select<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, int>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Select<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Select3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Select<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Select<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Select<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Select4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Select<int, int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Select<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, Task<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Select<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SelectMany1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int>(default(IAsyncQueryable<int>), (int arg0) => new int[] { default(int) }.ToAsyncEnumerable()), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, IAsyncEnumerable<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.SelectMany<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => new int[] { default(int) }.ToAsyncEnumerable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SelectMany2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<IAsyncEnumerable<int>>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<IAsyncEnumerable<int>>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.SelectMany<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<IAsyncEnumerable<int>>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SelectMany3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => new int[] { default(int) }.ToAsyncEnumerable()), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, IAsyncEnumerable<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.SelectMany<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => new int[] { default(int) }.ToAsyncEnumerable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SelectMany4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(Task<IAsyncEnumerable<int>>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, Task<IAsyncEnumerable<int>>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.SelectMany<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(Task<IAsyncEnumerable<int>>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SelectMany5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => new int[] { default(int) }.ToAsyncEnumerable(), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, IAsyncEnumerable<int>>>), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "selector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, int, int>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => new int[] { default(int) }.ToAsyncEnumerable(), (int arg0, int arg1) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SelectMany6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<IAsyncEnumerable<int>>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<IAsyncEnumerable<int>>>>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "selector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<IAsyncEnumerable<int>>), default(Expression<Func<int, int, Task<int>>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<IAsyncEnumerable<int>>), (int arg0, int arg1) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SelectMany7()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => new int[] { default(int) }.ToAsyncEnumerable(), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, IAsyncEnumerable<int>>>), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "selector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, int, int>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => new int[] { default(int) }.ToAsyncEnumerable(), (int arg0, int arg1) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SelectMany8()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(Task<IAsyncEnumerable<int>>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, Task<IAsyncEnumerable<int>>>>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "selector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(Task<IAsyncEnumerable<int>>), default(Expression<Func<int, int, Task<int>>>)), ane => ane.ParamName == "resultSelector");

            var res = AsyncQueryable.SelectMany<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(Task<IAsyncEnumerable<int>>), (int arg0, int arg1) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SequenceEqual1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SequenceEqual<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable()), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SequenceEqual<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>)), ane => ane.ParamName == "second");

            var res = AsyncQueryable.SequenceEqual<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void SequenceEqual2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SequenceEqual<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), CancellationToken.None), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SequenceEqual<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), CancellationToken.None), ane => ane.ParamName == "second");

            var res = AsyncQueryable.SequenceEqual<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void SequenceEqual3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SequenceEqual<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), EqualityComparer<int>.Default), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SequenceEqual<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "second");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SequenceEqual<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.SequenceEqual<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void SequenceEqual4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SequenceEqual<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SequenceEqual<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "second");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SequenceEqual<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.SequenceEqual<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Single1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Single<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Single<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Single2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Single<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Single<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Single3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Single<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Single<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Single<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Single4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Single<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Single<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Single<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Single5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Single<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Single<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Single<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Single6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Single<int>(default(IAsyncQueryable<int>), (int arg0) => true, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Single<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Single<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void SingleOrDefault1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SingleOrDefault<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.SingleOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void SingleOrDefault2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SingleOrDefault<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.SingleOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void SingleOrDefault3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SingleOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SingleOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.SingleOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void SingleOrDefault4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SingleOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SingleOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.SingleOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void SingleOrDefault5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SingleOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => true, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SingleOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.SingleOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void SingleOrDefault6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SingleOrDefault<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SingleOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>), CancellationToken.None), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.SingleOrDefault<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Skip1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Skip<int>(default(IAsyncQueryable<int>), 1), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Skip<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SkipLast1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SkipLast<int>(default(IAsyncQueryable<int>), 1), ane => ane.ParamName == "source");

            var res = AsyncQueryable.SkipLast<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SkipWhile1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SkipWhile<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SkipWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.SkipWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SkipWhile2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SkipWhile<int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SkipWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.SkipWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => true);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SkipWhile3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SkipWhile<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SkipWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.SkipWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void SkipWhile4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SkipWhile<int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.SkipWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.SkipWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(Task<bool>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Sum1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<float?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new float?[] { default(float?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<double?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new double?[] { default(double?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<decimal?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new decimal?[] { default(decimal?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<long>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new long[] { default(long) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<float>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new float[] { default(float) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum7()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<double>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new double[] { default(double) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum8()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<decimal>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new decimal[] { default(decimal) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum9()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<int?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new int?[] { default(int?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum10()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<long?>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new long?[] { default(long?) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum11()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<float?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new float?[] { default(float?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum12()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<double?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new double?[] { default(double?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum13()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<decimal?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new decimal?[] { default(decimal?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum14()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum15()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<long>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new long[] { default(long) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum16()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<float>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new float[] { default(float) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum17()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<double>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new double[] { default(double) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum18()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<decimal>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new decimal[] { default(decimal) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum19()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<int?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new int?[] { default(int?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum20()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum(default(IAsyncQueryable<long?>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Sum(new long?[] { default(long?) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum21()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<float>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<float>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum22()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum23()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<double>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<double>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum24()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum25()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<decimal>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<decimal>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum26()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum27()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum28()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum29()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(long)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(long));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum30()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum31()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(float)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(float));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum32()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum33()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(double)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(double));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum34()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum35()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(decimal)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(decimal));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum36()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum37()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum38()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum39()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<long>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long?>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<long>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum40()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long?>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long?>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long?>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum41()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum42()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<float>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<float>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum43()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum44()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<double>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<double>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum45()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum46()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<decimal>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<decimal>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum47()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum48()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum49()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum50()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(long), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(long), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum51()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<long>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<long>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<long>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum52()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(float), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, float>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(float), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum53()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<float>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<float>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<float>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum54()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(double), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, double>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(double), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum55()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<double>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<double>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<double>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum56()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(decimal), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, decimal>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(decimal), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum57()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<decimal>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<decimal>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<decimal>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum58()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum59()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int?>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int?>>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int?>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Sum60()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(default(IAsyncQueryable<int>), (int arg0) => default(Nullable<long>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, long?>>), CancellationToken.None), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Sum<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Nullable<long>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Take1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Take<int>(default(IAsyncQueryable<int>), 1), ane => ane.ParamName == "source");

            var res = AsyncQueryable.Take<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void TakeLast1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.TakeLast<int>(default(IAsyncQueryable<int>), 1), ane => ane.ParamName == "source");

            var res = AsyncQueryable.TakeLast<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), 1);
            // TODO: investigate test hang
        }

        [Fact]
        public void TakeWhile1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.TakeWhile<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.TakeWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.TakeWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void TakeWhile2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.TakeWhile<int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.TakeWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.TakeWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => true);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void TakeWhile3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.TakeWhile<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.TakeWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.TakeWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void TakeWhile4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.TakeWhile<int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.TakeWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.TakeWhile<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(Task<bool>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void ThenBy1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenBy<int, int>(default(IOrderedAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenBy<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), default(Expression<Func<int, int>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ThenBy<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(int));
        }

        [Fact]
        public void ThenBy2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenBy<int, int>(default(IOrderedAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenBy<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ThenBy<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(Task<int>));
        }

        [Fact]
        public void ThenBy3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenBy<int, int>(default(IOrderedAsyncQueryable<int>), (int arg0) => default(int), Comparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenBy<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), default(Expression<Func<int, int>>), Comparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenBy<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(int), default(IComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ThenBy<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(int), Comparer<int>.Default);
        }

        [Fact]
        public void ThenBy4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenBy<int, int>(default(IOrderedAsyncQueryable<int>), (int arg0) => default(Task<int>), Comparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenBy<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), default(Expression<Func<int, Task<int>>>), Comparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenBy<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(Task<int>), default(IComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ThenBy<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(Task<int>), Comparer<int>.Default);
        }

        [Fact]
        public void ThenByDescending1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenByDescending<int, int>(default(IOrderedAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenByDescending<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), default(Expression<Func<int, int>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ThenByDescending<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(int));
        }

        [Fact]
        public void ThenByDescending2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenByDescending<int, int>(default(IOrderedAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenByDescending<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ThenByDescending<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(Task<int>));
        }

        [Fact]
        public void ThenByDescending3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenByDescending<int, int>(default(IOrderedAsyncQueryable<int>), (int arg0) => default(int), Comparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenByDescending<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), default(Expression<Func<int, int>>), Comparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenByDescending<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(int), default(IComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ThenByDescending<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(int), Comparer<int>.Default);
        }

        [Fact]
        public void ThenByDescending4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenByDescending<int, int>(default(IOrderedAsyncQueryable<int>), (int arg0) => default(Task<int>), Comparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenByDescending<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), default(Expression<Func<int, Task<int>>>), Comparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ThenByDescending<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(Task<int>), default(IComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ThenByDescending<int, int>(new int[0].ToAsyncEnumerable().AsAsyncQueryable().OrderBy(x => x), (int arg0) => default(Task<int>), Comparer<int>.Default);
        }

        [Fact]
        public void ToArray1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToArray<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.ToArray<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToArray2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToArray<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.ToArray<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary7()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary8()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToDictionary<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary9()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int)), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>)), ane => ane.ParamName == "elementSelector");

            var res = AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary10()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "elementSelector");

            var res = AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary11()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "elementSelector");

            var res = AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary12()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "elementSelector");

            var res = AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary13()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>), EqualityComparer<int>.Default), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary14()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), EqualityComparer<int>.Default), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary15()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToDictionary16()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToDictionary<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToHashSet1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToHashSet<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.ToHashSet<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToHashSet2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToHashSet<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.ToHashSet<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToHashSet3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToHashSet<int>(default(IAsyncQueryable<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToHashSet<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToHashSet<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToHashSet4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToHashSet<int>(default(IAsyncQueryable<int>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToHashSet<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToHashSet<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToList1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToList<int>(default(IAsyncQueryable<int>)), ane => ane.ParamName == "source");

            var res = AsyncQueryable.ToList<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable());
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToList2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToList<int>(default(IAsyncQueryable<int>), CancellationToken.None), ane => ane.ParamName == "source");

            var res = AsyncQueryable.ToList<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "keySelector");

            var res = AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup5()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup6()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup7()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup8()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToLookup<int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup9()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int)), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>)), ane => ane.ParamName == "elementSelector");

            var res = AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup10()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>)), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>)), ane => ane.ParamName == "elementSelector");

            var res = AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>));
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup11()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int), CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>), CancellationToken.None), ane => ane.ParamName == "elementSelector");

            var res = AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup12()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), CancellationToken.None), ane => ane.ParamName == "elementSelector");

            var res = AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup13()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>), EqualityComparer<int>.Default), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup14()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), EqualityComparer<int>.Default), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup15()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(int), (int arg0) => default(int), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int>>), (int arg0) => default(int), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), default(Expression<Func<int, int>>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(int), (int arg0) => default(int), EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void ToLookup16()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<int>>>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "keySelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), default(Expression<Func<int, Task<int>>>), EqualityComparer<int>.Default, CancellationToken.None), ane => ane.ParamName == "elementSelector");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), default(IEqualityComparer<int>), CancellationToken.None), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.ToLookup<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<int>), (int arg0) => default(Task<int>), EqualityComparer<int>.Default, CancellationToken.None);
            AssertEx.SucceedOrFailProper(() => res.Wait());
        }

        [Fact]
        public void Union1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Union<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable()), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Union<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>)), ane => ane.ParamName == "second");

            var res = AsyncQueryable.Union<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable());
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Union2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Union<int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), EqualityComparer<int>.Default), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Union<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), EqualityComparer<int>.Default), ane => ane.ParamName == "second");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Union<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(IEqualityComparer<int>)), ane => ane.ParamName == "comparer");

            var res = AsyncQueryable.Union<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), EqualityComparer<int>.Default);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Where1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Where<int>(default(IAsyncQueryable<int>), (int arg0) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Where<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Where<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => true);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Where2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Where<int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => true), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Where<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, bool>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Where<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => true);
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Where3()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Where<int>(default(IAsyncQueryable<int>), (int arg0) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Where<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Where<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0) => default(Task<bool>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Where4()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Where<int>(default(IAsyncQueryable<int>), (int arg0, int arg1) => default(Task<bool>)), ane => ane.ParamName == "source");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Where<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(Expression<Func<int, int, Task<bool>>>)), ane => ane.ParamName == "predicate");

            var res = AsyncQueryable.Where<int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), (int arg0, int arg1) => default(Task<bool>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Zip1()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Zip<int, int, int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Zip<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), (int arg0, int arg1) => default(int)), ane => ane.ParamName == "second");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Zip<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, int, int>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Zip<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0, int arg1) => default(int));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

        [Fact]
        public void Zip2()
        {
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Zip<int, int, int>(default(IAsyncQueryable<int>), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "first");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Zip<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), default(IAsyncEnumerable<int>), (int arg0, int arg1) => default(Task<int>)), ane => ane.ParamName == "second");
            AssertEx.Throws<ArgumentNullException>(() => AsyncQueryable.Zip<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), default(Expression<Func<int, int, Task<int>>>)), ane => ane.ParamName == "selector");

            var res = AsyncQueryable.Zip<int, int, int>(new int[] { default(int) }.ToAsyncEnumerable().AsAsyncQueryable(), new int[] { default(int) }.ToAsyncEnumerable(), (int arg0, int arg1) => default(Task<int>));
            var task = res.ForEachAsync(_ => { });
            AssertEx.SucceedOrFailProper(() => task.Wait());
        }

    }
}