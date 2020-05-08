using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core
{
    public enum EnlargingCoefficient
    {
        By2, By4, By8
    }
    
    public static class ExtendedLinq
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<int> Range(int min, int size, int step)
            => Enumerable.Range(min, size).Select(x => x * step);
        
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
                action(item);
        }
        
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            var indexer = 0;
            foreach (var item in collection)
                action(item, indexer++);
        }

        public static T[] ToArray<T>(this IEnumerable<T> collection, EnlargingCoefficient coefficient)
        {
            var shift = coefficient switch
            {
                EnlargingCoefficient.By2 => 1,
                EnlargingCoefficient.By4 => 2,
                EnlargingCoefficient.By8 => 3,
                _ => 1
            };
            
            using var enumerator = collection.GetEnumerator();
            var current = 0;
            var currentLength = 8;
            var result = new T[8];
            while (enumerator.MoveNext())
            {
                if (current >= currentLength) EnlargeExtensions.LogEnlargeArray(shift, ref result, ref currentLength);
                result[current] = enumerator.Current;
                current++;
            }
            return SimpleArrayExtensions.EnsureFullArray(result, current);
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