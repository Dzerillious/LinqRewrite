using System;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core.SimpleList
{
    public partial class SimpleList<T>
    {
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void CopyTo(Array array, int index)
            => Array.Copy(Items, 0, array, index, Count);

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void CopyTo(T[] array, int index)
            => Array.Copy(Items, 0, array, index, Count);

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void CopyTo(int srcIndex, Array dstArray, int dstIndex, int length)
            => Array.Copy(Items, srcIndex, dstArray, dstIndex, length);
    }
}