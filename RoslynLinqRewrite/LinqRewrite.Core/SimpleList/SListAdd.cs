using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core.SimpleList
{
    public partial class SimpleList<T>
    {
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void Add(T item)
        {
            var count = Count + 1;
            if (count >= Items.Length) IncreaseCapacity();
            
            Items[Count] = item;
            Count = count;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void AddUnchecked(T item) => Items[Count++] = item;

        public void AddRange(T[] items)
        {
            var count = Count + items.Length;
            if (count <= Items.Length)
                Array.Copy(items, 0, Items, Count, items.Length);
            else
            {
                var newItems = new T[count];

                Array.Copy(Items, 0, newItems, 0, Count);
                Array.Copy(items, 0, newItems, Count, items.Length);

                Items = newItems;
            }
            Count = count;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void AddRangeUnchecked(T[] items)
        {
            Array.Copy(items, 0, Items, Count, items.Length);
            Count += items.Length;
        }

        public void AddRange(SimpleList<T> simpleList)
        {
            var count = Count + simpleList.Count;
            if (count <= Items.Length)
                Array.Copy(simpleList.Items, 0, Items, Count, simpleList.Count);
            else
            {
                var newItems = new T[count];

                Array.Copy(Items, 0, newItems, 0, Count);
                Array.Copy(simpleList.Items, 0, newItems, Count, simpleList.Count);

                Items = newItems;
            }
            Count = count;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void AddRangeUnchecked(SimpleList<T> simpleList)
        {
            Array.Copy(simpleList.Items, 0, Items, Count, simpleList.Count);
            Count += simpleList.Count;
        }

        public void AddRange(IList<T> items)
        {
            var count = Count + items.Count;
            if (count <= Items.Length)
                CopyFrom(items, 0, count, items.Count);
            else
            {
                var newItems = new T[count];

                Array.Copy(Items, 0, newItems, 0, Count);
                CopyFrom(items, 0, count, items.Count);

                Items = newItems;
            }
            Count = count;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void AddRangeUnchecked(IList<T> list)
            => CopyFrom(list, 0, Count, list.Count);

        public void AddRange(ICollection<T> items)
        {
            var count = Count + items.Count;
            if (count <= Items.Length)
                CopyFrom(items, 0, count, items.Count);
            else
            {
                var newItems = new T[count];

                Array.Copy(Items, 0, newItems, 0, Count);
                CopyFrom(items, 0, count, items.Count);

                Items = newItems;
            }
            Count = count;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void AddRangeUnchecked(ICollection<T> list)
            => CopyFrom(list, 0, Count, list.Count);

        public void AddRange(IEnumerable<T> enumerable, int addCount)
        {
            var count = Count + addCount;
            if (count <= Items.Length)
                CopyFrom(enumerable, count);
            else
            {
                var newItems = new T[count];

                Array.Copy(Items, 0, newItems, 0, Count);
                CopyFrom(enumerable, count);

                Items = newItems;
            }
            Count = count;
        }

        public void AddRangeUnchecked(IEnumerable<T> enumerable, int addCount)
        {
            var j = Count;
            var items = Items;
            
            foreach (var item in enumerable)
                items[j++] = item;
            Count += addCount;
        }

        public void AddRange(IEnumerable<T> enumerable)
        {
            foreach (var value in enumerable)
                Add(value);
        }

        public void AddRangeUnchecked(IEnumerable<T> enumerable)
        {
            foreach (var value in enumerable)
                AddUnchecked(value);
        }
    }
}