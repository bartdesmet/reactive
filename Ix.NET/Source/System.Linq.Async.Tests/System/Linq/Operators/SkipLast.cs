﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class SkipLast : AsyncEnumerableTests
    {
        [Fact]
        public void SkipLast_Null()
        {
            AssertThrows<ArgumentNullException>(() => AsyncEnumerable.SkipLast(default(IAsyncEnumerable<int>), 5));
        }

        [Fact]
        public void SkipLast1()
        {
            var xs = new[] { 1, 2, 3, 4 }.ToAsyncEnumerable().SkipLast(2);

            var e = xs.GetAsyncEnumerator();
            HasNext(e, 1);
            HasNext(e, 2);
            NoNext(e);
        }

        [Fact]
        public void SkipLast2()
        {
            var xs = new[] { 1, 2, 3, 4 }.ToAsyncEnumerable().SkipLast(5);

            var e = xs.GetAsyncEnumerator();
            NoNext(e);
        }

        [Fact]
        public async Task SkipLast3()
        {
            var xs = new[] { 1, 2, 3, 4 }.ToAsyncEnumerable().SkipLast(2);

            await SequenceIdentity(xs);
        }

        [Fact]
        public void SkipLast4()
        {
            var xs = new[] { 1, 2, 3, 4 }.ToAsyncEnumerable().SkipLast(0);

            var e = xs.GetAsyncEnumerator();

            HasNext(e, 1);
            HasNext(e, 2);
            HasNext(e, 3);
            HasNext(e, 4);
            NoNext(e);
        }
    }
}
