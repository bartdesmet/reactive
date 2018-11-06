﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerableEx
    {
        public static IAsyncEnumerable<TSource> Expand<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TSource>> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return new ExpandAsyncIterator<TSource>(source, selector);
        }

        public static IAsyncEnumerable<TSource> Expand<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IAsyncEnumerable<TSource>>> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return new ExpandAsyncIteratorWithTask<TSource>(source, selector);
        }

        private sealed class ExpandAsyncIterator<TSource> : AsyncIterator<TSource>
        {
            private readonly Func<TSource, IAsyncEnumerable<TSource>> selector;
            private readonly IAsyncEnumerable<TSource> source;

            private IAsyncEnumerator<TSource> enumerator;

            private Queue<IAsyncEnumerable<TSource>> queue;

            public ExpandAsyncIterator(IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TSource>> selector)
            {
                Debug.Assert(source != null);
                Debug.Assert(selector != null);

                this.source = source;
                this.selector = selector;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new ExpandAsyncIterator<TSource>(source, selector);
            }

            public override async ValueTask DisposeAsync()
            {
                if (enumerator != null)
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                    enumerator = null;
                }

                queue = null;

                await base.DisposeAsync().ConfigureAwait(false);
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        queue = new Queue<IAsyncEnumerable<TSource>>();
                        queue.Enqueue(source);

                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        while (true)
                        {
                            if (enumerator == null)
                            {
                                if (queue.Count > 0)
                                {
                                    var src = queue.Dequeue();

                                    if (enumerator != null)
                                    {
                                        await enumerator.DisposeAsync().ConfigureAwait(false);
                                    }

                                    enumerator = src.GetAsyncEnumerator(cancellationToken);

                                    continue; // loop
                                }

                                break; // while
                            }

                            if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                            {
                                var item = enumerator.Current;
                                var next = selector(item);
                                queue.Enqueue(next);
                                current = item;
                                return true;
                            }

                            await enumerator.DisposeAsync().ConfigureAwait(false);
                            enumerator = null;
                        }

                        break; // case
                }

                await DisposeAsync().ConfigureAwait(false);
                return false;
            }
        }

        private sealed class ExpandAsyncIteratorWithTask<TSource> : AsyncIterator<TSource>
        {
            private readonly Func<TSource, Task<IAsyncEnumerable<TSource>>> selector;
            private readonly IAsyncEnumerable<TSource> source;

            private IAsyncEnumerator<TSource> enumerator;

            private Queue<IAsyncEnumerable<TSource>> queue;

            public ExpandAsyncIteratorWithTask(IAsyncEnumerable<TSource> source, Func<TSource, Task<IAsyncEnumerable<TSource>>> selector)
            {
                Debug.Assert(source != null);
                Debug.Assert(selector != null);

                this.source = source;
                this.selector = selector;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new ExpandAsyncIteratorWithTask<TSource>(source, selector);
            }

            public override async ValueTask DisposeAsync()
            {
                if (enumerator != null)
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                    enumerator = null;
                }

                queue = null;

                await base.DisposeAsync().ConfigureAwait(false);
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        queue = new Queue<IAsyncEnumerable<TSource>>();
                        queue.Enqueue(source);

                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        while (true)
                        {
                            if (enumerator == null)
                            {
                                if (queue.Count > 0)
                                {
                                    var src = queue.Dequeue();

                                    if (enumerator != null)
                                    {
                                        await enumerator.DisposeAsync().ConfigureAwait(false);
                                    }

                                    enumerator = src.GetAsyncEnumerator(cancellationToken);

                                    continue; // loop
                                }

                                break; // while
                            }

                            if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                            {
                                var item = enumerator.Current;
                                var next = await selector(item).ConfigureAwait(false);
                                queue.Enqueue(next);
                                current = item;
                                return true;
                            }

                            await enumerator.DisposeAsync().ConfigureAwait(false);
                            enumerator = null;
                        }

                        break; // case
                }

                await DisposeAsync().ConfigureAwait(false);
                return false;
            }
        }
    }
}
