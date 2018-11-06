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
    public class CreateEnumerator : AsyncEnumerableTests
    {
        [Fact]
        public void CreateEnumerator_Null()
        {
            AssertThrows<ArgumentNullException>(() => AsyncEnumerable.CreateEnumerator<int>(default(Func<ValueTask<bool>>), () => 3, () => TaskExt.CompletedTask));
        }

        [Fact]
        public void CreateEnumerator_Throws()
        {
            var iter = AsyncEnumerable.CreateEnumerator<int>(() => TaskExt.True, () => 3, () => TaskExt.CompletedTask);

            var enu = (IAsyncEnumerable<int>)iter;

            AssertThrows<NotSupportedException>(() => enu.GetAsyncEnumerator());
        }
    }
}
