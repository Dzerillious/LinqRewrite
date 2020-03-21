using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core.SimpleList
{
    public partial class SimpleList<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void CopyFrom(Array srcArray, int srcIndex, int dstIndex, int length)
        {
            Array.Copy(srcArray, srcIndex, Items, dstIndex, length);
            var count = dstIndex + length;
            Count = Count >= count ? Count : count;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void CopyFrom(SimpleList<T> srcList, int srcIndex, int dstIndex, int length)
        {
            Array.Copy(srcList.Items, srcIndex, Items, dstIndex, length);
            var count = dstIndex + length;
            Count = Count >= count ? Count : count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void CopyFrom(IList<T> srcList, int dstIndex)
        {
            srcList.CopyTo(Items, dstIndex);
            var count = dstIndex + srcList.Count;
            Count = Count >= count ? Count : count;
        }

        public void CopyFrom(IList<T> srcList, int srcIndex, int dstIndex, int length)
        {
            var items = Items;
            for (var i = 0; i < length; i++)
                items[i + dstIndex] = srcList[i + srcIndex];
            
            var count = dstIndex + srcList.Count;
            Count = Count >= count ? Count : count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void CopyFrom(ICollection<T> srcCollection, int dstIndex)
        {
            srcCollection.CopyTo(Items, dstIndex);
            var count = dstIndex + srcCollection.Count;
            Count = Count >= count ? Count : count;
        }

        public void CopyFrom(ICollection<T> srcCollection, int srcIndex, int dstIndex, int length)
        {
            var items = Items;
            var enumerator = srcCollection.GetEnumerator();
            
            for (var i = 0; i < srcIndex; i++)
                enumerator.MoveNext();
            for (var i = 0; i < length; i++)
            {
                enumerator.MoveNext();
                items[i + dstIndex] = enumerator.Current;
            }
            enumerator.Dispose();
            
            var count = dstIndex + srcCollection.Count;
            Count = Count >= count ? Count : count;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void CopyFrom(IEnumerable<T> enumerable, int dstIndex = 0)
        {
            Count = dstIndex;
            foreach (var value in enumerable)
                Add(value);
        }
        
        public void CopyFrom(IEnumerable<T> enumerable, int dstIndex, int length)
        {
            var count = dstIndex + length;
            if (dstIndex + length > Items.Length)
            {
                var tmpItems = new T[dstIndex + length];
                Array.Copy(Items, 0, tmpItems, 0, dstIndex);
                Items = tmpItems;
            }
            Count = Count >= count ? Count : count;

            var items = Items;
            var enumerator = enumerable.GetEnumerator();
            for (var i = 0; i < length; i++)
            {
                enumerator.MoveNext();
                items[i + dstIndex] = enumerator.Current;
            }
            enumerator.Dispose();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void CopyTo(Array array, int index)
            => Array.Copy(Items, 0, array, index, Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void CopyTo(T[] array, int index)
            => Array.Copy(Items, 0, array, index, Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void CopyTo(int srcIndex, Array dstArray, int dstIndex, int length)
            => Array.Copy(Items, srcIndex, dstArray, dstIndex, length);
    }
}