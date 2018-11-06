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
        public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (source is AsyncIterator<TSource> iterator)
            {
                return iterator.Where(predicate);
            }

            // TODO: Can we add array/list optimizations here, does it make sense?
            return new WhereEnumerableAsyncIterator<TSource>(source, predicate);
        }

        public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return new WhereEnumerableWithIndexAsyncIterator<TSource>(source, predicate);
        }

        public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if (source is AsyncIterator<TSource> iterator)
            {
                return iterator.Where(predicate);
            }

            // TODO: Can we add array/list optimizations here, does it make sense?
            return new WhereEnumerableAsyncIteratorWithTask<TSource>(source, predicate);
        }

        public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return new WhereEnumerableWithIndexAsyncIteratorWithTask<TSource>(source, predicate);
        }

        private static Func<TSource, bool> CombinePredicates<TSource>(Func<TSource, bool> predicate1, Func<TSource, bool> predicate2)
        {
            return x => predicate1(x) && predicate2(x);
        }

        private static Func<TSource, Task<bool>> CombinePredicates<TSource>(Func<TSource, Task<bool>> predicate1, Func<TSource, Task<bool>> predicate2)
        {
            return async x => await predicate1(x).ConfigureAwait(false) && await predicate2(x).ConfigureAwait(false);
        }

        internal sealed class WhereEnumerableAsyncIterator<TSource> : AsyncIterator<TSource>
        {
            private readonly Func<TSource, bool> predicate;
            private readonly IAsyncEnumerable<TSource> source;
            private IAsyncEnumerator<TSource> enumerator;

            public WhereEnumerableAsyncIterator(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                Debug.Assert(source != null);
                Debug.Assert(predicate != null);

                this.source = source;
                this.predicate = predicate;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new WhereEnumerableAsyncIterator<TSource>(source, predicate);
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

            public override IAsyncEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
            {
                return new WhereSelectEnumerableAsyncIterator<TSource, TResult>(source, predicate, selector);
            }

            public override IAsyncEnumerable<TSource> Where(Func<TSource, bool> predicate)
            {
                return new WhereEnumerableAsyncIterator<TSource>(source, CombinePredicates(this.predicate, predicate));
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        enumerator = source.GetAsyncEnumerator(cancellationToken);
                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            var item = enumerator.Current;
                            if (predicate(item))
                            {
                                current = item;
                                return true;
                            }
                        }

                        await DisposeAsync().ConfigureAwait(false);
                        break;
                }

                return false;
            }
        }

        internal sealed class WhereEnumerableWithIndexAsyncIterator<TSource> : AsyncIterator<TSource>
        {
            private readonly Func<TSource, int, bool> predicate;
            private readonly IAsyncEnumerable<TSource> source;

            private IAsyncEnumerator<TSource> enumerator;
            private int index;

            public WhereEnumerableWithIndexAsyncIterator(IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
            {
                Debug.Assert(source != null);
                Debug.Assert(predicate != null);

                this.source = source;
                this.predicate = predicate;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new WhereEnumerableWithIndexAsyncIterator<TSource>(source, predicate);
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
                        index = -1;
                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            checked
                            {
                                index++;
                            }
                            var item = enumerator.Current;
                            if (predicate(item, index))
                            {
                                current = item;
                                return true;
                            }
                        }

                        await DisposeAsync().ConfigureAwait(false);
                        break;
                }

                return false;
            }
        }

        internal sealed class WhereEnumerableAsyncIteratorWithTask<TSource> : AsyncIterator<TSource>
        {
            private readonly Func<TSource, Task<bool>> predicate;
            private readonly IAsyncEnumerable<TSource> source;
            private IAsyncEnumerator<TSource> enumerator;

            public WhereEnumerableAsyncIteratorWithTask(IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
            {
                Debug.Assert(source != null);
                Debug.Assert(predicate != null);

                this.source = source;
                this.predicate = predicate;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new WhereEnumerableAsyncIteratorWithTask<TSource>(source, predicate);
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

            public override IAsyncEnumerable<TSource> Where(Func<TSource, Task<bool>> predicate)
            {
                return new WhereEnumerableAsyncIteratorWithTask<TSource>(source, CombinePredicates(this.predicate, predicate));
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        enumerator = source.GetAsyncEnumerator(cancellationToken);
                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            var item = enumerator.Current;
                            if (await predicate(item).ConfigureAwait(false))
                            {
                                current = item;
                                return true;
                            }
                        }

                        await DisposeAsync().ConfigureAwait(false);
                        break;
                }

                return false;
            }
        }

        internal sealed class WhereEnumerableWithIndexAsyncIteratorWithTask<TSource> : AsyncIterator<TSource>
        {
            private readonly Func<TSource, int, Task<bool>> predicate;
            private readonly IAsyncEnumerable<TSource> source;

            private IAsyncEnumerator<TSource> enumerator;
            private int index;

            public WhereEnumerableWithIndexAsyncIteratorWithTask(IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
            {
                Debug.Assert(source != null);
                Debug.Assert(predicate != null);

                this.source = source;
                this.predicate = predicate;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new WhereEnumerableWithIndexAsyncIteratorWithTask<TSource>(source, predicate);
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
                        index = -1;
                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            checked
                            {
                                index++;
                            }
                            var item = enumerator.Current;
                            if (await predicate(item, index).ConfigureAwait(false))
                            {
                                current = item;
                                return true;
                            }
                        }

                        await DisposeAsync().ConfigureAwait(false);
                        break;
                }

                return false;
            }
        }

        internal sealed class WhereSelectEnumerableAsyncIterator<TSource, TResult> : AsyncIterator<TResult>
        {
            private readonly Func<TSource, bool> predicate;
            private readonly Func<TSource, TResult> selector;
            private readonly IAsyncEnumerable<TSource> source;

            private IAsyncEnumerator<TSource> enumerator;

            public WhereSelectEnumerableAsyncIterator(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
            {
                Debug.Assert(source != null);
                Debug.Assert(predicate != null);
                Debug.Assert(selector != null);

                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            public override AsyncIterator<TResult> Clone()
            {
                return new WhereSelectEnumerableAsyncIterator<TSource, TResult>(source, predicate, selector);
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

            public override IAsyncEnumerable<TResult1> Select<TResult1>(Func<TResult, TResult1> selector)
            {
                return new WhereSelectEnumerableAsyncIterator<TSource, TResult1>(source, predicate, CombineSelectors(this.selector, selector));
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        enumerator = source.GetAsyncEnumerator(cancellationToken);
                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            var item = enumerator.Current;
                            if (predicate(item))
                            {
                                current = selector(item);
                                return true;
                            }
                        }

                        await DisposeAsync().ConfigureAwait(false);
                        break;
                }

                return false;
            }
        }
    }
}
