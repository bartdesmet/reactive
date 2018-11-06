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
        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> onNext)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (onNext == null)
                throw new ArgumentNullException(nameof(onNext));

            return DoCore(source, onNext: onNext, onError: null, onCompleted: null);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> onNext, Action onCompleted)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (onNext == null)
                throw new ArgumentNullException(nameof(onNext));
            if (onCompleted == null)
                throw new ArgumentNullException(nameof(onCompleted));

            return DoCore(source, onNext: onNext, onError: null, onCompleted: onCompleted);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> onNext, Action<Exception> onError)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (onNext == null)
                throw new ArgumentNullException(nameof(onNext));
            if (onError == null)
                throw new ArgumentNullException(nameof(onError));

            return DoCore(source, onNext: onNext, onError: onError, onCompleted: null);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> onNext, Action<Exception> onError, Action onCompleted)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (onNext == null)
                throw new ArgumentNullException(nameof(onNext));
            if (onError == null)
                throw new ArgumentNullException(nameof(onError));
            if (onCompleted == null)
                throw new ArgumentNullException(nameof(onCompleted));

            return DoCore(source, onNext, onError, onCompleted);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (onNext == null)
                throw new ArgumentNullException(nameof(onNext));

            return DoCore(source, onNext: onNext, onError: null, onCompleted: null);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext, Func<Task> onCompleted)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (onNext == null)
                throw new ArgumentNullException(nameof(onNext));
            if (onCompleted == null)
                throw new ArgumentNullException(nameof(onCompleted));

            return DoCore(source, onNext: onNext, onError: null, onCompleted: onCompleted);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext, Func<Exception, Task> onError)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (onNext == null)
                throw new ArgumentNullException(nameof(onNext));
            if (onError == null)
                throw new ArgumentNullException(nameof(onError));

            return DoCore(source, onNext: onNext, onError: onError, onCompleted: null);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext, Func<Exception, Task> onError, Func<Task> onCompleted)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (onNext == null)
                throw new ArgumentNullException(nameof(onNext));
            if (onError == null)
                throw new ArgumentNullException(nameof(onError));
            if (onCompleted == null)
                throw new ArgumentNullException(nameof(onCompleted));

            return DoCore(source, onNext, onError, onCompleted);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, IObserver<TSource> observer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (observer == null)
                throw new ArgumentNullException(nameof(observer));

            return DoCore(source, new Action<TSource>(observer.OnNext), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted));
        }

        private static IAsyncEnumerable<TSource> DoCore<TSource>(IAsyncEnumerable<TSource> source, Action<TSource> onNext, Action<Exception> onError, Action onCompleted)
        {
            return new DoAsyncIterator<TSource>(source, onNext, onError, onCompleted);
        }

        private static IAsyncEnumerable<TSource> DoCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext, Func<Exception, Task> onError, Func<Task> onCompleted)
        {
            return new DoAsyncIteratorWithTask<TSource>(source, onNext, onError, onCompleted);
        }

        private sealed class DoAsyncIterator<TSource> : AsyncIterator<TSource>
        {
            private readonly Action onCompleted;
            private readonly Action<Exception> onError;
            private readonly Action<TSource> onNext;
            private readonly IAsyncEnumerable<TSource> source;

            private IAsyncEnumerator<TSource> enumerator;

            public DoAsyncIterator(IAsyncEnumerable<TSource> source, Action<TSource> onNext, Action<Exception> onError, Action onCompleted)
            {
                Debug.Assert(source != null);
                Debug.Assert(onNext != null);

                this.source = source;
                this.onNext = onNext;
                this.onError = onError;
                this.onCompleted = onCompleted;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new DoAsyncIterator<TSource>(source, onNext, onError, onCompleted);
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
                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        try
                        {
                            if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                            {
                                current = enumerator.Current;
                                onNext(current);

                                return true;
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            throw;
                        }
                        catch (Exception ex) when (onError != null)
                        {
                            onError(ex);
                            throw;
                        }

                        onCompleted?.Invoke();

                        await DisposeAsync().ConfigureAwait(false);
                        break;
                }

                return false;
            }
        }

        private sealed class DoAsyncIteratorWithTask<TSource> : AsyncIterator<TSource>
        {
            private readonly Func<Task> onCompleted;
            private readonly Func<Exception, Task> onError;
            private readonly Func<TSource, Task> onNext;
            private readonly IAsyncEnumerable<TSource> source;

            private IAsyncEnumerator<TSource> enumerator;

            public DoAsyncIteratorWithTask(IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext, Func<Exception, Task> onError, Func<Task> onCompleted)
            {
                Debug.Assert(source != null);
                Debug.Assert(onNext != null);

                this.source = source;
                this.onNext = onNext;
                this.onError = onError;
                this.onCompleted = onCompleted;
            }

            public override AsyncIterator<TSource> Clone()
            {
                return new DoAsyncIteratorWithTask<TSource>(source, onNext, onError, onCompleted);
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
                        state = AsyncIteratorState.Iterating;
                        goto case AsyncIteratorState.Iterating;

                    case AsyncIteratorState.Iterating:
                        try
                        {
                            if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                            {
                                current = enumerator.Current;
                                await onNext(current).ConfigureAwait(false);

                                return true;
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            throw;
                        }
                        catch (Exception ex) when (onError != null)
                        {
                            await onError(ex).ConfigureAwait(false);
                            throw;
                        }

                        if (onCompleted != null)
                        {
                            await onCompleted().ConfigureAwait(false);
                        }

                        await DisposeAsync().ConfigureAwait(false);
                        break;
                }

                return false;
            }
        }
    }
}
