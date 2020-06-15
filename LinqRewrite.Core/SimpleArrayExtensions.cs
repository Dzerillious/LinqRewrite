using System;
using System.Collections.Generic;

namespace LinqRewrite.Core
{
    public static class SimpleArrayExtensions
    {
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

        public static T[] EnsureFullArray<T>(T[] result, in int current)
        {
            if (result.Length == current) return result;
            var ret = new T[current];
            Array.Copy(result, 0, ret, 0, current);
            return ret;
        }

        public static T[] EnsureFullReversedArray<T>(T[] result, in int current)
        {
            if (result.Length == current) return result;
            var ret = new T[current];
            Array.Copy(result, result.Length - current, ret, 0, current);
            return ret;
        }
    }
}