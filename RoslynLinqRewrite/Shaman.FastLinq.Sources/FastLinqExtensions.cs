﻿using System.Collections.Generic;

namespace System.Linq
{
#if FAST_LINQ_EXTENSIONS_PUBLIC
    public static partial class FastLinqExtensions
#else
    internal static class FastLinqExtensions
#endif
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
        public static TSource[] ToArray<TSource>(this TSource[] array)
        {
            var dest = new TSource[array.Length];
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


    }
}
