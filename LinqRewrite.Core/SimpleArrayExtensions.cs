using System;
using System.Collections.Generic;

namespace LinqRewrite.Core
{
    public static class SimpleArrayExtensions
    {
        public static void EnlargeArray<T>(ref T[] array, int length)
        {
            var result = new T[length];
            EnlargeExtensions.ArrayCopy(array, 0, result, 0, array.Length);
            array = result;
        }
        
        public static void EnlargeArray<T>(ref T[] array)
        {
            var length = array.Length >= 8 ? array.Length * 2 : 8;
            var result = new T[length];
            EnlargeExtensions.ArrayCopy(array, 0, result, 0, array.Length);
            array = result;
        }
        
        public static T[] AppendRange<T>(this T[] array, T[] appended)
        {
            var result = new T[array.Length + appended.Length];
            EnlargeExtensions.ArrayCopy(array, 0, result, 0, array.Length);
            EnlargeExtensions.ArrayCopy(appended, 0, result, array.Length, appended.Length);
            return result;
        }

        public static T[] AppendRange<T>(this T[] array, IEnumerable<T> appended, int count)
        {
            var result = new T[array.Length + count];
            EnlargeExtensions.ArrayCopy(array, 0, result, 0, array.Length);

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
            EnlargeExtensions.ArrayCopy(array, 0, result, 0, index);
            EnlargeExtensions.ArrayCopy(inserted, 0, result, index, inserted.Length);
            EnlargeExtensions.ArrayCopy(array, index, result, index + inserted.Length, array.Length - index);
            return result;
        }

        public static T[] InsertRange<T>(this T[] array, int index, IEnumerable<T> inserted, int count)
        {
            var result = new T[array.Length + count];
            EnlargeExtensions.ArrayCopy(array, 0, result, count, index);

            var enumerator = inserted.GetEnumerator();
            var end = index + count;
            for (var i = index; i < end; i++)
            {
                enumerator.MoveNext();
                result[i] = enumerator.Current;
            }
            enumerator.Dispose();

            EnlargeExtensions.ArrayCopy(array, end, result, count, array.Length - index);
            return result;
        }

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
            EnlargeExtensions.ArrayCopy(result, 0, ret, 0, current);
            return ret;
        }

        public static T[] EnsureFullReversedArray<T>(T[] result, in int current)
        {
            if (result.Length == current) return result;
            var ret = new T[current];
            EnlargeExtensions.ArrayCopy(result, result.Length - current, ret, 0, current);
            return ret;
        }
    }
}