using System;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core.SimpleList
{
    public partial class SimpleList<T>
    {
        public void Enlarge(int desiredCount)
        {
            var items = new T[desiredCount];
            Array.Copy(Items, 0, items, 0, Items.Length);

            Items = items;
            Count = desiredCount;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void EnlargeCapacity(int desiredCapacity)
        {
            var items = new T[desiredCapacity];
            Array.Copy(Items, 0, items, 0, Items.Length);

            Items = items;
        }

        public void Resize(int desiredSize)
        {
            if (desiredSize <= Items.Length)
                Count = desiredSize;
            else
            {
                var items = new T[desiredSize];
                Array.Copy(Items, 0, items, 0, Items.Length);

                Items = items;
                Count = desiredSize;
            }
        }

        public bool Remove(T item)
        {
            var index = -1;
            var items = Items;
            for (var i = 0; i < Count; i++)
                if (items[i].Equals(item))
                    index = i;

            if (index == -1) return false;
            
            var copied = Count - index;
            if (index != Count - 1)
                Array.Copy(items, index + 1, items, index, copied);
            Count--;
            return true;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void RemoveLast() => Count--;

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void RemoveAt(int index)
        {
            if (index != Count - 1)
                Array.Copy(Items, index + 1, Items, index, Count - index);
            Count--;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void RemoveRange(int index, int count)
        {
            if (index + count - Count <= 0) ;
            else if (index + count - Count < count)
            {
                var copied = index + count - Count;
                Array.Copy(Items, index + count, Items, index, copied);
            }
            else Array.Copy(Items, index + count, Items, index, count);
            Count -= count;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void Clear() => Count = 0;
    }
}