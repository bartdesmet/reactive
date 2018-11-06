﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Linq;
using Xunit;

namespace Tests
{
    public class Return : AsyncEnumerableExTests
    {
        [Fact]
        public void Return1()
        {
            var xs = AsyncEnumerableEx.Return(42);
            HasNext(xs.GetAsyncEnumerator(), 42);
        }
    }
}
