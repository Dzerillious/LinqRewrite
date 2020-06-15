using System;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core
{
    public static class EnlargeExtensions
    {
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public static void ArrayCopy<T>(T[] source, int sourceIndex, T[] result, int resultIndex, int count)
        {
            if (count >= 32)
                Array.Copy(source, sourceIndex, result, resultIndex, count);
            else for (int i = 0; i < count; i++)
                result[i + resultIndex] = source[i + sourceIndex];
        }
        
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public static void ArrayCopy<T>(T[] source, T[] result, int resultIndex, int count)
        {
            if (count >= 32)
                Array.Copy(source, 0, result, resultIndex, count);
            else for (int i = 0; i < count; i++)
                result[i + resultIndex] = source[i];
        }
        
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public static void ArrayCopy<T>(T[] source, int sourceIndex, T[] result, int count)
        {
            if (count >= 32)
                Array.Copy(source, sourceIndex, result, 0, count);
            else for (int i = 0; i < count; i++)
                result[i] = source[i + sourceIndex];
        }
        
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public static void ArrayCopy<T>(T[] source, T[] result, int count)
        {
            if (count >= 32)
                Array.Copy(source, 0, result, 0, count);
            else for (int i = 0; i < count; i++)
                result[i] = source[i];
        }
        
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public static void InitializeLogEnlarge<T>(int pow, int length, out int log, out int currentLength, out T[] result)
        {
            log = IntExtensions.Log2((uint)length) - 3;
            log -= log % pow;
            
            currentLength = 8;
            result = new T[8];
        }

#if !NET40
        [MethodImpl(MethodImplOptions.NoInlining)]
#endif 
        public static void LogEnlargeArray<T>(int logConst, int length, ref T[] result, ref int log, out int currentLength)
        {
            log -= logConst;
            currentLength = length >> log;
            
            var newArray = new T[currentLength];
            Array.Copy(result, 0, newArray, 0, result.Length);
            result = newArray;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.NoInlining)]
#endif 
        public static void LogEnlargeReverseArray<T>(int logConst, int length, ref T[] result, ref int log, out int currentLength)
        {
            log -= logConst;
            currentLength = length >> log;
            
            var newArray = new T[currentLength];
            Array.Copy(result, 0, newArray, currentLength - result.Length, result.Length);
            result = newArray;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public static void InitializeLogEnlarge<T>(out int currentLength, out T[] result)
        {
            currentLength = 8;
            result = new T[8];
        }

#if !NET40
        [MethodImpl(MethodImplOptions.NoInlining)]
#endif 
        public static void LogEnlargeArray<T>(int logConst, ref T[] result, ref int currentLength)
        {
            currentLength <<= logConst;
            
            var newArray = new T[currentLength];
            Array.Copy(result, 0, newArray, 0, result.Length);
            result = newArray;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.NoInlining)]
#endif 
        public static void LogEnlargeReverseArray<T>(int logConst, ref T[] result, ref int currentLength)
        {
            currentLength <<= logConst;
            
            var newArray = new T[currentLength];
            Array.Copy(result, 0, newArray, currentLength - result.Length, result.Length);
            result = newArray;
        }
    }
}