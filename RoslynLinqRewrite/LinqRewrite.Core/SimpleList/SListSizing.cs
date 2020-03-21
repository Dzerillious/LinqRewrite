using System;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core.SimpleList
{
    public partial class SimpleList<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void Reduce(int count) => Count = count;

        public void Enlarge(int desiredCount)
        {
            var items = new T[desiredCount];
            Array.Copy(Items, 0, items, 0, Items.Length);

            Items = items;
            Count = desiredCount;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
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
            Array.Copy(items, index, items, index - 1, Count - index - 1);
            Count--;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void RemoveLast() => Count--;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void RemoveAt(int index)
        {
            if (index == 0) Array.Copy(Items, 1, Items, 0, Count - 1);
            else Array.Copy(Items, index, Items, index - 1, Count - index - 1);
            Count--;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void RemoveRange(int index, int count)
        {
            Array.Copy(Items, index, Items, index - count, Count - index - count);
            Count -= count;
        }

        public void ResizeEmptyReduce(int desiredSize)
        {
            if (desiredSize <= Items.Length)
            {
                Count = desiredSize;
                var items = Items;
                
                var def = default(T);
                var length = Items.Length;
                for (var i = desiredSize; i < length; i++)
                    items[i] = def;
            }
            else
            {
                var items = new T[desiredSize];
                Array.Copy(Items, 0, items, 0, Items.Length);

                Items = items;
                Count = desiredSize;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void MakeEmptyAt(int index)
        {
            Array.Copy(Items, index, Items, index - 1, Count - index - 1);
            Count--;
            Items[Count] = default;
        }

        public bool MakeEmpty(T item)
        {
            var index = -1;
            var items = Items;
            for (var i = 0; i < Count; i++)
                if (items[i].Equals(item))
                    index = i;

            if (index == -1) return false;
            Array.Copy(items, index, items, index - 1, Count - index - 1);
            Count--;
            items[Count] = default;
            return true;
        }

        public void MakeEmptyRange(int index, int count)
        {
            var items = Items;
            Array.Copy(items, index, items, index - count, Count - index - count);
            Count -= count;
            for (var i = 0; i < count; i++)
                items[Count - i] = default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void MakeDefault()
        {
            Items = new T[8];
            Count = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void MakeEmpty()
        {
            Items = new T[0];
            Count = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void MakeEmptyWithCount(int count)
        {
            Items = new T[count];
            Count = count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void MakeEmptyWithCapacity(int capacity)
        {
            Items = new T[capacity];
            Count = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void Clear() => Count = 0;
    }
}