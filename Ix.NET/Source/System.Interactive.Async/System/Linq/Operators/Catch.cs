﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerableEx
    {
        public static IAsyncEnumerable<TSource> Catch<TSource, TException>(this IAsyncEnumerable<TSource> source, Func<TException, IAsyncEnumerable<TSource>> handler)
            where TException : Exception
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            return new CatchAsyncIterator<TSource, TException>(source, handler);
        }

        public static IAsyncEnumerable<TSource> Catch<TSource, TException>(this IAsyncEnumerable<TSource> source, Func<TException, Task<IAsyncEnumerable<TSource>>> handler)
            where TException : Exception
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            return new CatchAsyncIteratorWithTask<TSource, TException>(source, handler);
        }

        public static IAsyncEnumerable<TSource> Catch<TSource>(this IEnumerable<IAsyncEnumerable<TSource>> sources)
        {
            if (sources == null)
                throw new ArgumentNullException(nameof(sources));

            return CatchCore(sources);
        }

        public static IAsyncEnumerable<TSource> Catch<TSource>(params IAsyncEnumerable<TSource>[] sources)
        {
            if (sources == null)
                throw new ArgumentNullException(nameof(sources));

            return CatchCore(sources);
        }

        public static IAsyncEnumerable<TSource> Catch<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            return CatchCore(new[] { first, second });
        }

        private static IAsyncEnumerable<TSource> CatchCore<TSource>(IEnumerable<IAsyncEnumerable<TSource>> sources)
        {
            return new CatchAsyncIterator<TSource>(sources);
        }

        private sealed class CatchAsyncIterator<TSource, TException> : AsyncIterator<TSource> where TException : Exception
        {
            private readonly Func<TException, IAsyncEnumerable<TSource>> handler;
            private readonly IAsyncEnumerable<TSource> source;

            private IAsyncEnumerator<TSource> enumerator;
            private bool isDone;

            public CatchAsyncIterator(IAsyncEnumerable<TSource> source, Func<TException, IAsyncEnumerable<TSource>> handler)
            {
                Debug.Assert(source != null);
                Debug.Assert(handler != null);

                this.source = source;
                this.handler = handler;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new CatchAsyncIterator<TSource, TException>(source, handler);
            }

            public override async ValueTask DisposeAsync()
            {
                if (enumerator != null)
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                    enumerator = null;
                }

                await base.DisposeAsync().ConfigureAwait(false);
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        enumerator = source.GetAsyncEnumerator(cancellationToken);
                        isDone = false;

                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        while (true)
                        {
                            if (!isDone)
                            {
                                try
                                {
                                    if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                                    {
                                        current = enumerator.Current;
                                        return true;
                                    }
                                }
                                catch (TException ex)
                                {
                                    // Note: Ideally we'd dipose of the previous enumerator before
                                    // invoking the handler, but we use this order to preserve
                                    // current behavior
                                    var inner = handler(ex);
                                    var err = inner.GetAsyncEnumerator(cancellationToken);

                                    if (enumerator != null)
                                    {
                                        await enumerator.DisposeAsync().ConfigureAwait(false);
                                    }

                                    enumerator = err;
                                    isDone = true;
                                    continue; // loop so we hit the catch state
                                }
                            }

                            if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                            {
                                current = enumerator.Current;
                                return true;
                            }

                            break; // while
                        }

                        break; // case
                }

                await DisposeAsync().ConfigureAwait(false);
                return false;
            }
        }

        private sealed class CatchAsyncIteratorWithTask<TSource, TException> : AsyncIterator<TSource> where TException : Exception
        {
            private readonly Func<TException, Task<IAsyncEnumerable<TSource>>> handler;
            private readonly IAsyncEnumerable<TSource> source;

            private IAsyncEnumerator<TSource> enumerator;
            private bool isDone;

            public CatchAsyncIteratorWithTask(IAsyncEnumerable<TSource> source, Func<TException, Task<IAsyncEnumerable<TSource>>> handler)
            {
                Debug.Assert(source != null);
                Debug.Assert(handler != null);

                this.source = source;
                this.handler = handler;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new CatchAsyncIteratorWithTask<TSource, TException>(source, handler);
            }

            public override async ValueTask DisposeAsync()
            {
                if (enumerator != null)
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                    enumerator = null;
                }

                await base.DisposeAsync().ConfigureAwait(false);
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        enumerator = source.GetAsyncEnumerator(cancellationToken);
                        isDone = false;

                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        while (true)
                        {
                            if (!isDone)
                            {
                                try
                                {
                                    if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                                    {
                                        current = enumerator.Current;
                                        return true;
                                    }
                                }
                                catch (TException ex)
                                {
                                    // Note: Ideally we'd dipose of the previous enumerator before
                                    // invoking the handler, but we use this order to preserve
                                    // current behavior
                                    var inner = await handler(ex).ConfigureAwait(false);
                                    var err = inner.GetAsyncEnumerator(cancellationToken);

                                    if (enumerator != null)
                                    {
                                        await enumerator.DisposeAsync().ConfigureAwait(false);
                                    }

                                    enumerator = err;
                                    isDone = true;
                                    continue; // loop so we hit the catch state
                                }
                            }

                            if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                            {
                                current = enumerator.Current;
                                return true;
                            }

                            break; // while
                        }

                        break; // case
                }

                await DisposeAsync().ConfigureAwait(false);
                return false;
            }
        }

        private sealed class CatchAsyncIterator<TSource> : AsyncIterator<TSource>
        {
            private readonly IEnumerable<IAsyncEnumerable<TSource>> sources;

            private IAsyncEnumerator<TSource> enumerator;
            private ExceptionDispatchInfo error;

            private IEnumerator<IAsyncEnumerable<TSource>> sourcesEnumerator;

            public CatchAsyncIterator(IEnumerable<IAsyncEnumerable<TSource>> sources)
            {
                Debug.Assert(sources != null);

                this.sources = sources;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new CatchAsyncIterator<TSource>(sources);
            }

            public override async ValueTask DisposeAsync()
            {
                if (sourcesEnumerator != null)
                {
                    sourcesEnumerator.Dispose();
                    sourcesEnumerator = null;
                }

                if (enumerator != null)
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                    enumerator = null;
                }

                error = null;

                await base.DisposeAsync().ConfigureAwait(false);
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        sourcesEnumerator = sources.GetEnumerator();

                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        while (true)
                        {
                            if (enumerator == null)
                            {
                                if (!sourcesEnumerator.MoveNext())
                                {
                                    // only throw if we have an error on the last one
                                    error?.Throw();
                                    break; // done, nothing else to do
                                }

                                error = null;
                                enumerator = sourcesEnumerator.Current.GetAsyncEnumerator(cancellationToken);
                            }

                            try
                            {
                                if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                                {
                                    current = enumerator.Current;
                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                // Done with the current one, go to the next
                                await enumerator.DisposeAsync().ConfigureAwait(false);
                                enumerator = null;
                                error = ExceptionDispatchInfo.Capture(ex);
                                continue;
                            }

                            break; // while
                        }

                        break; // case
                }

                await DisposeAsync().ConfigureAwait(false);
                return false;
            }
        }
    }
}
