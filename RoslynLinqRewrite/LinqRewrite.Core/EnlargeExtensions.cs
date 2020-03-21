using System;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core
{
    public static class EnlargeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InitializeLogEnlarge<T>(int pow, int length, out int log, out int currentLength, out T[] result)
        {
            log = IntExtensions.Log2((uint)length) - 3;
            log -= log % pow;
            
            currentLength = 8;
            result = new T[8];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void LogEnlargeArray<T>(int logConst, int length, ref T[] result, ref int log, out int currentLength)
        {
            log -= logConst;
            currentLength = length >> log;
            
            var newArray = new T[currentLength];
            Array.Copy(result, 0, newArray, 0, result.Length);
            result = newArray;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void LogEnlargeReverseArray<T>(int logConst, int length, ref T[] result, ref int log, out int currentLength)
        {
            log -= logConst;
            currentLength = length >> log;
            
            var newArray = new T[currentLength];
            Array.Copy(result, 0, newArray, currentLength - result.Length, result.Length);
            result = newArray;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InitializeLogEnlarge<T>(out int currentLength, out T[] result)
        {
            currentLength = 8;
            result = new T[8];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void LogEnlargeArray<T>(int logConst, ref T[] result, ref int currentLength)
        {
            currentLength <<= logConst;
            
            var newArray = new T[currentLength];
            Array.Copy(result, 0, newArray, 0, result.Length);
            result = newArray;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void LogEnlargeReverseArray<T>(int logConst, ref T[] result, ref int currentLength)
        {
            currentLength <<= logConst;
            
            var newArray = new T[currentLength];
            Array.Copy(result, 0, newArray, currentLength - result.Length, result.Length);
            result = newArray;
        }
    }
}