using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core.SimpleList
{
    public static class ToSimpleListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SimpleList<T> TakeSimpleList<T>(this T[] array) 
            => new SimpleList<T>
            {
                Items = array,
                Count = array.Length
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SimpleList<T> TakeSimpleList<T>(this T[] array, int count)
            => new SimpleList<T>
            {
                Items = array,
                Count = count
            };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SimpleList<T> TakeSimpleList<T>(this SimpleList<T> list) 
            => new SimpleList<T>
            {
                Items = list.Items,
                Count = list.Count
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static SimpleList<T> ToSimpleList<T>(this T[] array)
            => new SimpleList<T>(array);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static SimpleList<T> ToSimpleList<T>(this ICollection<T> list)
            => new SimpleList<T>(list);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static SimpleList<T> ToSimpleList<T>(this IEnumerable<T> enumerable, EnlargingCoefficient coefficient = EnlargingCoefficient.By4)
        {
            var shift = coefficient switch
            {
                EnlargingCoefficient.By2 => 1,
                EnlargingCoefficient.By4 => 2,
                EnlargingCoefficient.By8 => 3,
                _ => 1
            };
            
            using var enumerator = enumerable.GetEnumerator();
            var current = 0;
            var currentLength = 8;
            var result = new T[8];
            while (enumerator.MoveNext())
            {
                if (current >= currentLength) EnlargeExtensions.LogEnlargeArray(shift, ref result, ref currentLength);
                result[current] = enumerator.Current;
                current++;
            }
            var simpleList = new SimpleList<T>();
            simpleList.Items = result;
            simpleList.Count = current;
            return simpleList;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static TSource[] ToArray<TSource>(this SimpleList<TSource> source)
        {
            var array = new TSource[source.Count];
            Array.Copy(source.Items, 0, array, 0, source.Count);
            return array;
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
            this SimpleList<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            var dict = new Dictionary<TKey, TSource>();
            for (var i = 0; i < source.Count; i++)
                dict[keySelector(source[i])] = source[i];
            return dict;
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
          this SimpleList<TSource> source,
          Func<TSource, TKey> keySelector,
          IEqualityComparer<TKey> comparer)
        {
            var dict = new Dictionary<TKey, TSource>(comparer);
            for (var i = 0; i < source.Count; i++)
                dict[keySelector(source[i])] = source[i];
            return dict;
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
          this SimpleList<TSource> source,
          Func<TSource, TKey> keySelector,
          Func<TSource, TElement> elementSelector)
        {
            var dict = new Dictionary<TKey, TElement>();
            for (var i = 0; i < source.Count; i++)
                dict[keySelector(source[i])] = elementSelector(source[i]);
            return dict;
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
          this SimpleList<TSource> source,
          Func<TSource, TKey> keySelector,
          Func<TSource, TElement> elementSelector,
          IEqualityComparer<TKey> comparer)
        {
            var dict = new Dictionary<TKey, TElement>(comparer);
            for (var i = 0; i < source.Count; i++)
                dict[keySelector(source[i])] = elementSelector(source[i]);
            return dict;
        }
    }
}