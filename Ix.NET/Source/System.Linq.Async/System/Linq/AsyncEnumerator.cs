﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    /// <summary>
    /// Provides a set of extension methods for <see cref="IAsyncEnumerator{T}"/>.
    /// </summary>
    public static class AsyncEnumerator
    {
        /// <summary>
        /// Creates a new enumerator using the specified delegates implementing the members of <see cref="IAsyncEnumerator{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements returned by the enumerator.</typeparam>
        /// <param name="moveNext">The delegate implementing the <see cref="IAsyncEnumerator{T}.MoveNextAsync"/> method.</param>
        /// <param name="current">The delegate implementing the <see cref="IAsyncEnumerator{T}.Current"/> property getter.</param>
        /// <param name="dispose">The delegate implementing the <see cref="IAsyncDisposable.DisposeAsync"/> method.</param>
        /// <returns>A new enumerator instance.</returns>
        public static IAsyncEnumerator<T> Create<T>(Func<ValueTask<bool>> moveNext, Func<T> current, Func<ValueTask> dispose)
        {
            if (moveNext == null)
                throw new ArgumentNullException(nameof(moveNext));

            // Note: Many methods pass null in for the second two params. We're assuming
            // That the caller is responsible and knows what they're doing
            return new AnonymousAsyncIterator<T>(moveNext, current, dispose);
        }

        /// <summary>
        /// Advances the enumerator to the next element in the sequence, returning the result asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements returned by the enumerator.</typeparam>
        /// <param name="source">The enumerator to advance.</param>
        /// <param name="cancellationToken">Cancellation token that can be used to cancel the operation.</param>
        /// <returns>
        /// Task containing the result of the operation: true if the enumerator was successfully advanced
        /// to the next element; false if the enumerator has passed the end of the sequence.
        /// </returns>
        public static ValueTask<bool> MoveNextAsync<T>(this IAsyncEnumerator<T> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            cancellationToken.ThrowIfCancellationRequested();

            return source.MoveNextAsync();
        }

        /// <summary>
        /// Wraps the specified enumerator with an enumerator that checks for cancellation upon every invocation
        /// of the <see cref="IAsyncEnumerator{T}.MoveNextAsync"/> method.
        /// </summary>
        /// <typeparam name="T">The type of the elements returned by the enumerator.</typeparam>
        /// <param name="source">The enumerator to augment with cancellation support.</param>
        /// <param name="cancellationToken">The cancellation token to observe.</param>
        /// <returns>An enumerator that honors cancellation requests.</returns>
        public static IAsyncEnumerator<T> WithCancellation<T>(this IAsyncEnumerator<T> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new AnonymousAsyncIterator<T>(
                moveNext: () =>
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return source.MoveNextAsync();
                },
                currentFunc: () => source.Current,
                dispose: source.DisposeAsync
            );
        }

        /// <summary>
        /// Wraps the specified enumerator in an enumerable.
        /// </summary>
        /// <typeparam name="T">The type of the elements returned by the enumerator.</typeparam>
        /// <param name="source">The enumerator to wrap.</param>
        /// <returns>An enumerable wrapping the specified enumerator.</returns>
        public static IAsyncEnumerable<T> AsEnumerable<T>(this IAsyncEnumerator<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return AsyncEnumerable.CreateEnumerable<T>(() => source);
        }

        internal static IAsyncEnumerator<T> Create<T>(Func<TaskCompletionSource<bool>, ValueTask<bool>> moveNext, Func<T> current, Func<ValueTask> dispose)
        {
            return new AnonymousAsyncIterator<T>(
                async () =>
                {
                    var tcs = new TaskCompletionSource<bool>();

                    return await moveNext(tcs).ConfigureAwait(false);
                },
                current,
                dispose
            );
        }

        private sealed class AnonymousAsyncIterator<T> : AsyncIterator<T>
        {
            private readonly Func<T> currentFunc;
            private readonly Func<ValueTask<bool>> moveNext;
            private Func<ValueTask> dispose;

            public AnonymousAsyncIterator(Func<ValueTask<bool>> moveNext, Func<T> currentFunc, Func<ValueTask> dispose)
            {
                Debug.Assert(moveNext != null);

                this.moveNext = moveNext;
                this.currentFunc = currentFunc;
                this.dispose = dispose;

                // Explicit call to initialize enumerator mode
                GetAsyncEnumerator(default);
            }

            public override AsyncIterator<T> Clone()
            {
                throw new NotSupportedException("AnonymousAsyncIterator cannot be cloned. It is only intended for use as an iterator.");
            }

            public override async ValueTask DisposeAsync()
            {
                var dispose = Interlocked.Exchange(ref this.dispose, null);

                if (dispose != null)
                {
                    await dispose().ConfigureAwait(false);
                }

                await base.DisposeAsync().ConfigureAwait(false);
            }

            protected override async ValueTask<bool> MoveNextCore(CancellationToken cancellationToken)
            {
                switch (state)
                {
                    case AsyncIteratorState.Allocated:
                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        if (await moveNext().ConfigureAwait(false))
                        {
                            current = currentFunc();
                            return true;
                        }

                        await DisposeAsync().ConfigureAwait(false);
                        break;
                }

                return false;
            }
        }
    }
}
