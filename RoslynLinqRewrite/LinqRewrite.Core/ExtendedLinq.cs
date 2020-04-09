using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core
{
    public static class ExtendedLinq
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
                action(item);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> Unchecked<T>(this IEnumerable<T> collection)
            => collection;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> WithResultSize<T>(this IEnumerable<T> collection, int size)
            => collection;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> WithMaxSize<T>(this IEnumerable<T> collection, int size)
            => collection;
    }
}