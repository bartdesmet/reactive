﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static Task<TSource[]> ToArray<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return ToArray(source, CancellationToken.None);
        }

        public static Task<TSource[]> ToArray<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source is IAsyncIListProvider<TSource> arrayProvider)
                return arrayProvider.ToArrayAsync(cancellationToken);

            return AsyncEnumerableHelpers.ToArray(source, cancellationToken);
        }
    }
}
