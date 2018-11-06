﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            return first.Intersect(second, EqualityComparer<TSource>.Default);
        }

        public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return new IntersectAsyncIterator<TSource>(first, second, comparer);
        }

        private sealed class IntersectAsyncIterator<TSource> : AsyncIterator<TSource>
        {
            private readonly IEqualityComparer<TSource> comparer;
            private readonly IAsyncEnumerable<TSource> first;
            private readonly IAsyncEnumerable<TSource> second;

            private Task fillSetTask;

            private IAsyncEnumerator<TSource> firstEnumerator;
            private Set<TSource> set;

            private bool setFilled;

            public IntersectAsyncIterator(IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
            {
                Debug.Assert(first != null);
                Debug.Assert(second != null);
                Debug.Assert(comparer != null);

                this.first = first;
                this.second = second;
                this.comparer = comparer;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new IntersectAsyncIterator<TSource>(first, second, comparer);
            }

            public override async ValueTask DisposeAsync()
            {
                if (firstEnumerator != null)
                {
                    await firstEnumerator.DisposeAsync().ConfigureAwait(false);
                    firstEnumerator = null;
                }

                set = null;

                await base.DisposeAsync().ConfigureAwait(false);
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        firstEnumerator = first.GetAsyncEnumerator(cancellationToken);
                        set = new Set<TSource>(comparer);
                        setFilled = false;
                        fillSetTask = FillSet();

                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:

                        bool moveNext;
                        do
                        {
                            if (!setFilled)
                            {
                                // This is here so we don't need to call Task.WhenAll each time after the set is filled
                                var moveNextTask = firstEnumerator.MoveNextAsync();
                                await Task.WhenAll(moveNextTask.AsTask(), fillSetTask).ConfigureAwait(false);
                                setFilled = true;
                                moveNext = moveNextTask.Result;
                            }
                            else
                            {
                                moveNext = await firstEnumerator.MoveNextAsync().ConfigureAwait(false);
                            }

                            if (moveNext)
                            {
                                var item = firstEnumerator.Current;
                                if (set.Remove(item))
                                {
                                    current = item;
                                    return true;
                                }
                            }
                        } while (moveNext);

                        await DisposeAsync().ConfigureAwait(false);
                        break;
                }

                return false;
            }

            private async Task FillSet()
            {
                var array = await second.ToArray().ConfigureAwait(false);
                for (var i = 0; i < array.Length; i++)
                {
                    set.Add(array[i]);
                }
            }
        }
    }
}