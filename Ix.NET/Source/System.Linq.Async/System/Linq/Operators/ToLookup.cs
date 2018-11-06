﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            return ToLookup(source, keySelector, CancellationToken.None);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            return source.ToLookup(keySelector, x => x, EqualityComparer<TKey>.Default, cancellationToken);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TKey>> keySelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            return ToLookup(source, keySelector, CancellationToken.None);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TKey>> keySelector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            return source.ToLookup(keySelector, x => Task.FromResult(x), EqualityComparer<TKey>.Default, cancellationToken);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return ToLookup(source, keySelector, comparer, CancellationToken.None);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return source.ToLookup(keySelector, x => x, comparer, cancellationToken);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TKey>> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return ToLookup(source, keySelector, comparer, CancellationToken.None);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TKey>> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return source.ToLookup(keySelector, x => Task.FromResult(x), comparer, cancellationToken);
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));

            return ToLookup(source, keySelector, elementSelector, CancellationToken.None);
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));

            return source.ToLookup(keySelector, elementSelector, EqualityComparer<TKey>.Default, cancellationToken);
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TKey>> keySelector, Func<TSource, Task<TElement>> elementSelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));

            return ToLookup(source, keySelector, elementSelector, CancellationToken.None);
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TKey>> keySelector, Func<TSource, Task<TElement>> elementSelector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));

            return source.ToLookup(keySelector, elementSelector, EqualityComparer<TKey>.Default, cancellationToken);
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return ToLookup(source, keySelector, elementSelector, comparer, CancellationToken.None);
        }

        public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            var lookup = await Internal.Lookup<TKey, TElement>.CreateAsync(source, keySelector, elementSelector, comparer).ConfigureAwait(false);

            return lookup;
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TKey>> keySelector, Func<TSource, Task<TElement>> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return ToLookup(source, keySelector, elementSelector, comparer, CancellationToken.None);
        }

        public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TKey>> keySelector, Func<TSource, Task<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            var lookup = await Internal.LookupWithTask<TKey, TElement>.CreateAsync(source, keySelector, elementSelector, comparer).ConfigureAwait(false);

            return lookup;
        }
    }
}

// This is internal because System.Linq exposes a public Lookup that we cannot directly use here

namespace System.Linq.Internal
{
    internal class Lookup<TKey, TElement> : ILookup<TKey, TElement>, IAsyncIListProvider<IAsyncGrouping<TKey, TElement>>
    {
        private readonly IEqualityComparer<TKey> _comparer;
        private Grouping<TKey, TElement>[] _groupings;
        private Grouping<TKey, TElement> _lastGrouping;

        private Lookup(IEqualityComparer<TKey> comparer)
        {
            _comparer = comparer ?? EqualityComparer<TKey>.Default;
            _groupings = new Grouping<TKey, TElement>[7];
        }

        public int Count { get; private set; }

        public IEnumerable<TElement> this[TKey key]
        {
            get
            {
                var grouping = GetGrouping(key, create: false);
                if (grouping != null)
                {
                    return grouping;
                }

#if NO_ARRAY_EMPTY
                return EmptyArray<TElement>.Value;
#else
                return Array.Empty<TElement>();
#endif
            }
        }

        public bool Contains(TKey key)
        {
            return GetGrouping(key, create: false) != null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    yield return g;
                } while (g != _lastGrouping);
            }
        }

        public IEnumerable<TResult> ApplyResultSelector<TResult>(Func<TKey, IAsyncEnumerable<TElement>, TResult> resultSelector)
        {
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    g.Trim();

                    var result = resultSelector(g._key, g._elements.ToAsyncEnumerable());
                    yield return result;
                } while (g != _lastGrouping);
            }
        }

        internal static async Task<Lookup<TKey, TElement>> CreateAsync<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.Assert(source != null);
            Debug.Assert(keySelector != null);
            Debug.Assert(elementSelector != null);

            var lookup = new Lookup<TKey, TElement>(comparer);

            var enu = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await enu.MoveNextAsync().ConfigureAwait(false))
                {
                    var key = keySelector(enu.Current);
                    var group = lookup.GetGrouping(key, create: true);

                    var element = elementSelector(enu.Current);
                    group.Add(element);
                }
            }
            finally
            {
                await enu.DisposeAsync().ConfigureAwait(false);
            }

            return lookup;
        }

        internal static async Task<Lookup<TKey, TElement>> CreateAsync(IAsyncEnumerable<TElement> source, Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.Assert(source != null);
            Debug.Assert(keySelector != null);

            var lookup = new Lookup<TKey, TElement>(comparer);

            var enu = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await enu.MoveNextAsync().ConfigureAwait(false))
                {
                    var key = keySelector(enu.Current);
                    lookup.GetGrouping(key, create: true).Add(enu.Current);
                }
            }
            finally
            {
                await enu.DisposeAsync().ConfigureAwait(false);
            }

            return lookup;
        }

        internal static async Task<Lookup<TKey, TElement>> CreateForJoinAsync(IAsyncEnumerable<TElement> source, Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            var lookup = new Lookup<TKey, TElement>(comparer);

            var enu = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await enu.MoveNextAsync().ConfigureAwait(false))
                {
                    var key = keySelector(enu.Current);
                    if (key != null)
                    {
                        lookup.GetGrouping(key, create: true).Add(enu.Current);
                    }
                }
            }
            finally
            {
                await enu.DisposeAsync().ConfigureAwait(false);
            }

            return lookup;
        }

        internal Grouping<TKey, TElement> GetGrouping(TKey key, bool create)
        {
            var hashCode = InternalGetHashCode(key);
            for (var g = _groupings[hashCode % _groupings.Length]; g != null; g = g._hashNext)
            {
                if (g._hashCode == hashCode && _comparer.Equals(g._key, key))
                {
                    return g;
                }
            }

            if (create)
            {
                if (Count == _groupings.Length)
                {
                    Resize();
                }

                var index = hashCode % _groupings.Length;
                var g = new Grouping<TKey, TElement>
                {
                    _key = key,
                    _hashCode = hashCode,
                    _elements = new TElement[1],
                    _hashNext = _groupings[index]
                };
                _groupings[index] = g;
                if (_lastGrouping == null)
                {
                    g._next = g;
                }
                else
                {
                    g._next = _lastGrouping._next;
                    _lastGrouping._next = g;
                }

                _lastGrouping = g;
                Count++;
                return g;
            }

            return null;
        }

        internal int InternalGetHashCode(TKey key)
        {
            // Handle comparer implementations that throw when passed null
            return (key == null) ? 0 : _comparer.GetHashCode(key) & 0x7FFFFFFF;
        }

        internal TResult[] ToArray<TResult>(Func<TKey, IAsyncEnumerable<TElement>, TResult> resultSelector)
        {
            var array = new TResult[Count];
            var index = 0;
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    g.Trim();
                    array[index] = resultSelector(g._key, g._elements.ToAsyncEnumerable());
                    ++index;
                } while (g != _lastGrouping);
            }

            return array;
        }

        internal List<TResult> ToList<TResult>(Func<TKey, IAsyncEnumerable<TElement>, TResult> resultSelector)
        {
            var list = new List<TResult>(Count);
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    g.Trim();

                    var result = resultSelector(g._key, g._elements.ToAsyncEnumerable());
                    list.Add(result);
                } while (g != _lastGrouping);
            }

            return list;
        }

        private void Resize()
        {
            var newSize = checked((Count * 2) + 1);
            var newGroupings = new Grouping<TKey, TElement>[newSize];
            var g = _lastGrouping;
            do
            {
                g = g._next;
                var index = g._hashCode % newSize;
                g._hashNext = newGroupings[index];
                newGroupings[index] = g;
            } while (g != _lastGrouping);

            _groupings = newGroupings;
        }

        public Task<int> GetCountAsync(bool onlyIfCheap, CancellationToken cancellationToken)
        {
            return Task.FromResult(Count);
        }

        IAsyncEnumerator<IAsyncGrouping<TKey, TElement>> IAsyncEnumerable<IAsyncGrouping<TKey, TElement>>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return Enumerable.Cast<IAsyncGrouping<TKey, TElement>>(this).ToAsyncEnumerable().GetAsyncEnumerator(cancellationToken);
        }

        Task<List<IAsyncGrouping<TKey, TElement>>> IAsyncIListProvider<IAsyncGrouping<TKey, TElement>>.ToListAsync(CancellationToken cancellationToken)
        {
            var list = new List<IAsyncGrouping<TKey, TElement>>(Count);
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    list.Add(g);
                }
                while (g != _lastGrouping);
            }

            return Task.FromResult(list);
        }

        Task<IAsyncGrouping<TKey, TElement>[]> IAsyncIListProvider<IAsyncGrouping<TKey, TElement>>.ToArrayAsync(CancellationToken cancellationToken)
        {
            var array = new IAsyncGrouping<TKey, TElement>[Count];
            var index = 0;
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    array[index] = g;
                    ++index;
                }
                while (g != _lastGrouping);
            }

            return Task.FromResult(array);
        }
    }

    internal class LookupWithTask<TKey, TElement> : ILookup<TKey, TElement>, IAsyncIListProvider<IAsyncGrouping<TKey, TElement>>
    {
        private readonly IEqualityComparer<TKey> _comparer;
        private Grouping<TKey, TElement>[] _groupings;
        private Grouping<TKey, TElement> _lastGrouping;

        private LookupWithTask(IEqualityComparer<TKey> comparer)
        {
            _comparer = comparer ?? EqualityComparer<TKey>.Default;
            _groupings = new Grouping<TKey, TElement>[7];
        }

        public int Count { get; private set; }

        public IEnumerable<TElement> this[TKey key]
        {
            get
            {
                var grouping = GetGrouping(key, create: false);
                if (grouping != null)
                {
                    return grouping;
                }

#if NO_ARRAY_EMPTY
                return EmptyArray<TElement>.Value;
#else
                return Array.Empty<TElement>();
#endif
            }
        }

        public bool Contains(TKey key)
        {
            return GetGrouping(key, create: false) != null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    yield return g;
                } while (g != _lastGrouping);
            }
        }

        internal static async Task<LookupWithTask<TKey, TElement>> CreateAsync<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, Task<TKey>> keySelector, Func<TSource, Task<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.Assert(source != null);
            Debug.Assert(keySelector != null);
            Debug.Assert(elementSelector != null);

            var lookup = new LookupWithTask<TKey, TElement>(comparer);

            var enu = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await enu.MoveNextAsync().ConfigureAwait(false))
                {
                    var key = await keySelector(enu.Current).ConfigureAwait(false);
                    var group = lookup.GetGrouping(key, create: true);

                    var element = await elementSelector(enu.Current).ConfigureAwait(false);
                    group.Add(element);
                }
            }
            finally
            {
                await enu.DisposeAsync().ConfigureAwait(false);
            }

            return lookup;
        }

        internal static async Task<LookupWithTask<TKey, TElement>> CreateAsync(IAsyncEnumerable<TElement> source, Func<TElement, Task<TKey>> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default(CancellationToken))
        {
            Debug.Assert(source != null);
            Debug.Assert(keySelector != null);

            var lookup = new LookupWithTask<TKey, TElement>(comparer);

            var enu = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await enu.MoveNextAsync().ConfigureAwait(false))
                {
                    var key = await keySelector(enu.Current).ConfigureAwait(false);
                    lookup.GetGrouping(key, create: true).Add(enu.Current);
                }
            }
            finally
            {
                await enu.DisposeAsync().ConfigureAwait(false);
            }

            return lookup;
        }

        internal static async Task<LookupWithTask<TKey, TElement>> CreateForJoinAsync(IAsyncEnumerable<TElement> source, Func<TElement, Task<TKey>> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            var lookup = new LookupWithTask<TKey, TElement>(comparer);

            var enu = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await enu.MoveNextAsync().ConfigureAwait(false))
                {
                    var key = await keySelector(enu.Current).ConfigureAwait(false);
                    if (key != null)
                    {
                        lookup.GetGrouping(key, create: true).Add(enu.Current);
                    }
                }
            }
            finally
            {
                await enu.DisposeAsync().ConfigureAwait(false);
            }

            return lookup;
        }

        internal Grouping<TKey, TElement> GetGrouping(TKey key, bool create)
        {
            var hashCode = InternalGetHashCode(key);
            for (var g = _groupings[hashCode % _groupings.Length]; g != null; g = g._hashNext)
            {
                if (g._hashCode == hashCode && _comparer.Equals(g._key, key))
                {
                    return g;
                }
            }

            if (create)
            {
                if (Count == _groupings.Length)
                {
                    Resize();
                }

                var index = hashCode % _groupings.Length;
                var g = new Grouping<TKey, TElement>
                {
                    _key = key,
                    _hashCode = hashCode,
                    _elements = new TElement[1],
                    _hashNext = _groupings[index]
                };
                _groupings[index] = g;
                if (_lastGrouping == null)
                {
                    g._next = g;
                }
                else
                {
                    g._next = _lastGrouping._next;
                    _lastGrouping._next = g;
                }

                _lastGrouping = g;
                Count++;
                return g;
            }

            return null;
        }

        internal int InternalGetHashCode(TKey key)
        {
            // Handle comparer implementations that throw when passed null
            return (key == null) ? 0 : _comparer.GetHashCode(key) & 0x7FFFFFFF;
        }

        internal async Task<TResult[]> ToArray<TResult>(Func<TKey, IAsyncEnumerable<TElement>, Task<TResult>> resultSelector)
        {
            var array = new TResult[Count];
            var index = 0;
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    g.Trim();
                    array[index] = await resultSelector(g._key, g._elements.ToAsyncEnumerable()).ConfigureAwait(false);
                    ++index;
                } while (g != _lastGrouping);
            }

            return array;
        }

        internal async Task<List<TResult>> ToList<TResult>(Func<TKey, IAsyncEnumerable<TElement>, Task<TResult>> resultSelector)
        {
            var list = new List<TResult>(Count);
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    g.Trim();

                    var result = await resultSelector(g._key, g._elements.ToAsyncEnumerable()).ConfigureAwait(false);
                    list.Add(result);
                } while (g != _lastGrouping);
            }

            return list;
        }

        private void Resize()
        {
            var newSize = checked((Count * 2) + 1);
            var newGroupings = new Grouping<TKey, TElement>[newSize];
            var g = _lastGrouping;
            do
            {
                g = g._next;
                var index = g._hashCode % newSize;
                g._hashNext = newGroupings[index];
                newGroupings[index] = g;
            } while (g != _lastGrouping);

            _groupings = newGroupings;
        }

        public Task<int> GetCountAsync(bool onlyIfCheap, CancellationToken cancellationToken)
        {
            return Task.FromResult(Count);
        }

        IAsyncEnumerator<IAsyncGrouping<TKey, TElement>> IAsyncEnumerable<IAsyncGrouping<TKey, TElement>>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return Enumerable.Cast<IAsyncGrouping<TKey, TElement>>(this).ToAsyncEnumerable().GetAsyncEnumerator(cancellationToken);
        }

        Task<List<IAsyncGrouping<TKey, TElement>>> IAsyncIListProvider<IAsyncGrouping<TKey, TElement>>.ToListAsync(CancellationToken cancellationToken)
        {
            var list = new List<IAsyncGrouping<TKey, TElement>>(Count);
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    list.Add(g);
                }
                while (g != _lastGrouping);
            }

            return Task.FromResult(list);
        }

        Task<IAsyncGrouping<TKey, TElement>[]> IAsyncIListProvider<IAsyncGrouping<TKey, TElement>>.ToArrayAsync(CancellationToken cancellationToken)
        {
            var array = new IAsyncGrouping<TKey, TElement>[Count];
            var index = 0;
            var g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;
                    array[index] = g;
                    ++index;
                }
                while (g != _lastGrouping);
            }

            return Task.FromResult(array);
        }
    }
}
