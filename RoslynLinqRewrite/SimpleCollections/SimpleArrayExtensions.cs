using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SimpleCollections
{
    public static class FastArrayExtensions
    {
        public static TSource Single<TSource>(this TSource[] array)
        {
            if (array.Length > 1) throw new InvalidOperationException("Sequence contains more than one element");
            return array[0];
        }
        public static TSource Single<TSource>(this List<TSource> array)
        {
            if (array.Count > 1) throw new InvalidOperationException("Sequence contains more than one element");
            return array[0];
        }
        public static TSource First<TSource>(this TSource[] array) => array[0];

        public static TSource First<TSource>(this List<TSource> array) => array[0];

        public static TSource First<TSource>(this TSource[] array, Func<TSource, bool> condition)
        {
            for (var i = 0; i < array.Length; i++)
                if (condition(array[i])) return array[i];
            
            throw new InvalidOperationException("No items match the specified search criteria.");
        }

        public static TSource First<TSource>(this List<TSource> array, Func<TSource, bool> condition)
        {
            var len = array.Count;
            for (var i = 0; i < len; i++)
                if (condition(array[i])) return array[i];
            
            throw new InvalidOperationException("No items match the specified search criteria.");
        }
        public static TSource FirstOrDefault<TSource>(this TSource[] array, Func<TSource, bool> condition)
        {
            for (var i = 0; i < array.Length; i++)
                if (condition(array[i])) return array[i];
            
            return default;
        }
        public static TSource FirstOrDefault<TSource>(this List<TSource> array, Func<TSource, bool> condition)
        {
            var len = array.Count;
            for (var i = 0; i < len; i++)
                if (condition(array[i])) return array[i];
            
            return default;
        }

        public static bool Contains(this string str, char ch) 
            => str.IndexOf(ch) != -1;

        public static TSource FirstOrDefault<TSource>(this TSource[] array)
            => array.Length == 0 ? default : array[0];

        public static TSource FirstOrDefault<TSource>(this List<TSource> array)
            => array.Count == 0 ? default : array[0];

        public static TSource SingleOrDefault<TSource>(this TSource[] array)
        {
            if (array.Length > 1) throw new InvalidOperationException("Sequence contains more than one element");
            return array.Length == 0 ? default : array[0];
        }

        public static TSource SingleOrDefault<TSource>(this List<TSource> array)
        {
            if (array.Count > 1) throw new InvalidOperationException("Sequence contains more than one element");
            return array.Count == 0 ? default : array[0];
        }
        public static TSource Last<TSource>(this List<TSource> array)
            => array[array.Count - 1];

        public static TSource Last<TSource>(this TSource[] array)
            => array[array.Length - 1];

        public static TSource LastOrDefault<TSource>(this List<TSource> array)
            => array.Count == 0 ? default : array[array.Count - 1];

        public static TSource LastOrDefault<TSource>(this TSource[] array)
            => array.Length == 0 ? default : array[array.Length - 1];

        public static bool Any<TSource>(this TSource[] array, Func<TSource, bool> condition)
        {
            for (var i = 0; i < array.Length; i++)
                if (condition(array[i])) return true;
            return false;
        }
        public static bool Any<TSource>(this List<TSource> array)
            => array.Count != 0;

        public static bool Any<TSource>(this TSource[] array)
            => array.Length != 0;

        public static bool Any<TSource>(this List<TSource> array, Func<TSource, bool> condition)
        {
            var len = array.Count;
            for (var i = 0; i < len; i++)
                if (condition(array[i])) return true;
            
            return false;
        }
        public static bool All<TSource>(this TSource[] array, Func<TSource, bool> condition)
        {
            for (var i = 0; i < array.Length; i++)
                if (!condition(array[i])) return false;
            
            return true;
        }
        public static bool All<TSource>(this List<TSource> array, Func<TSource, bool> condition)
        {
            var len = array.Count;
            for (var i = 0; i < len; i++)
                if (!condition(array[i])) return false;
            
            return true;
        }
        public static TSource[] ToArray<TSource>(this List<TSource> array)
        {
            var len = array.Count;
            var dest = new TSource[len];
            for (var i = 0; i < dest.Length; i++)
                dest[i] = array[i];
                
            return dest;
        }
        
        public static List<TSource> ToList<TSource>(this List<TSource> array)
        {
            var len = array.Count;
            var dest = new List<TSource>(len);
            for (var i = 0; i < len; i++)
                dest.Add(array[i]);
                
            return dest;
        }
        public static List<TSource> ToList<TSource>(this TSource[] array)
        {
            var dest = new List<TSource>(array.Length);
            for (var i = 0; i < array.Length; i++)
                dest.Add(array[i]);
            
            return dest;
        }
        
        public static void EnlargeArray<T>(ref T[] array, int length)
        {
            var result = new T[length];
            Array.Copy(array, 0, result, 0, array.Length);
            array = result;
        }
        
        public static void EnlargeArray<T>(ref T[] array)
        {
            var length = array.Length >= 8 ? array.Length * 2 : 8;
            var result = new T[length];
            Array.Copy(array, 0, result, 0, array.Length);
            array = result;
        }
        
        public static T[] AppendRange<T>(this T[] array, T[] appended)
        {
            var result = new T[array.Length + appended.Length];
            Array.Copy(array, 0, result, 0, array.Length);
            Array.Copy(appended, 0, result, array.Length, appended.Length);
            return result;
        }

        public static T[] AppendRange<T>(this T[] array, IEnumerable<T> appended, int count)
        {
            var result = new T[array.Length + count];
            Array.Copy(array, 0, result, 0, array.Length);

            var enumerator = appended.GetEnumerator();
            var end = array.Length + count;
            for (var i = array.Length; i < end; i++)
            {
                enumerator.MoveNext();
                result[i] = enumerator.Current;
            }

            enumerator.Dispose();
            return result;
        }

        public static T[] InsertRange<T>(this T[] array, int index, T[] inserted)
        {
            var result = new T[array.Length + inserted.Length];
            Array.Copy(array, 0, result, 0, index);
            Array.Copy(inserted, 0, result, index, inserted.Length);
            Array.Copy(array, index, result, index + inserted.Length, array.Length - index);
            return result;
        }

        public static T[] InsertRange<T>(this T[] array, int index, IEnumerable<T> inserted, int count)
        {
            var result = new T[array.Length + count];
            Array.Copy(array, 0, result, count, index);

            var enumerator = inserted.GetEnumerator();
            var end = index + count;
            for (var i = index; i < end; i++)
            {
                enumerator.MoveNext();
                result[i] = enumerator.Current;
            }
            enumerator.Dispose();

            Array.Copy(array, end, result, count, array.Length - index);
            return result;
        }

        public static void ReverseOrder<T>(this T[] array)
        {
            var result = new T[array.Length];
            var length = array.Length;
            var reverseIndex = length - 1;

            for (var i = 0; i < length; i++)
            {
                var temp = array[i];
                result[i] = result[reverseIndex];
                result[reverseIndex] = temp;
                reverseIndex--;
            }
        }

        public static T[] ToArray<T>(this T[] array)
        {
            var result = new T[array.Length];
            Array.Copy(array, 0, result, 0, array.Length);
            return result;
        }

        public static T[] ToArray<T>(this IEnumerable<T> enumerable, int count)
        {
            var result = new T[count];

            var j = 0;
            foreach (var value in enumerable)
                result[j++] = value;

            return result;
        }

        public static T[] ToArray<T>(this ICollection<T> list)
        {
            var result = new T[list.Count];
            list.CopyTo(result, 0);
            return result;
        }
        
        public static int IndexOf<T>(IList<T> list, T item)
        {
            for (var i = 0; i < list.Count; i++)
                if (Equals(list[i], item))
                    return i;
            return -1;
        }

        public static int IndexOf<T>(IList<T> list, Func<T, bool> predicate)
        {
            for (var i = 0; i < list.Count; i++)
                if (predicate(list[i]))
                    return i;
            return -1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this T[] array)
            => array == null || array.Length == 0;

        public static T[] Repeat<T>(this T item, int size)
        {
            var result = new T[size];
            for (var i = 0; i < size; i++)
                result[i] = item;
            return result;
        }
        
        public static int[] Range(this int start, int count)
        {
            var result = new int[count];
            for (var i = 0; i < count; i++)
                result[i] = i + start;
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T First<T>(this IList<T> array)
            => array[0];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FirstOrDefault<T>(this IList<T> array)
            => array.Count == 0 ? default : array[0];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Last<T>(this IList<T> array)
            => array[array.Count - 1];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefault<T>(this IList<T> array)
            => array.Count == 0 ? default : array[array.Count - 1];

        public static void Fill<T>(ref T[] result, T item, int size)
        {
            if (result == null || size != result.Length)
                result = new T[size];

            for (var i = 0; i < size; i++)
                result[i] = item;
        }

        public static T[] EnsureFullArray<T>(T[] result, in int current)
        {
            if (result.Length == current) return result;
            var ret = new T[current];
            Array.Copy(result, 0, ret, 0, current);
            return ret;
        }
    }
}