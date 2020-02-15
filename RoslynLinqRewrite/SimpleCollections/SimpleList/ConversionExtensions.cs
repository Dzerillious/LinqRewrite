using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SimpleCollections.SimpleList
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
        public static SimpleList<T> ToSimpleList<T>(this IEnumerable<T> enumerable)
            => new SimpleList<T>(enumerable);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static SimpleList<T> ToSimpleList<T>(this IEnumerable<T> enumerable, int length)
            =>new SimpleList<T>(enumerable, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static TSource[] ToArray<TSource>(this SimpleList<TSource> source)
        {
            var array = new TSource[source.Count];
            Array.Copy(source.Items, 0, array, 0, source.Count);
            return array;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static List<TSource> ToList<TSource>(this SimpleList<TSource> source)
            => new List<TSource>(ToArray(source));

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