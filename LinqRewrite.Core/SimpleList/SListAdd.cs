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
            if (Count >= Items.Length) IncreaseCapacity();
            Items[Count++] = item;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void AddUnchecked(T item) => Items[Count++] = item;

        public void AddRange(T[] items)
        {
            var count = Count + items.Length;
            if (count <= Items.Length)
                EnlargeExtensions.ArrayCopy(items, 0, Items, Count, items.Length);
            else
            {
                var newItems = new T[count];

                EnlargeExtensions.ArrayCopy(Items, 0, newItems, 0, Count);
                EnlargeExtensions.ArrayCopy(items, 0, newItems, Count, items.Length);

                Items = newItems;
            }
            Count = count;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void AddRangeUnchecked(T[] items)
        {
            EnlargeExtensions.ArrayCopy(items, 0, Items, Count, items.Length);
            Count += items.Length;
        }

        public void AddRange(SimpleList<T> simpleList)
        {
            var count = Count + simpleList.Count;
            if (count <= Items.Length)
                EnlargeExtensions.ArrayCopy(simpleList.Items, 0, Items, Count, simpleList.Count);
            else
            {
                var newItems = new T[count];

                EnlargeExtensions.ArrayCopy(Items, 0, newItems, 0, Count);
                EnlargeExtensions.ArrayCopy(simpleList.Items, 0, newItems, Count, simpleList.Count);

                Items = newItems;
            }
            Count = count;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void AddRangeUnchecked(SimpleList<T> simpleList)
        {
            EnlargeExtensions.ArrayCopy(simpleList.Items, 0, Items, Count, simpleList.Count);
            Count += simpleList.Count;
        }

        public void AddRange(ICollection<T> items)
        {
            var count = Count + items.Count;
            if (count <= Items.Length)
                items.CopyTo(Items, Count);
            else
            {
                var newItems = new T[count];

                EnlargeExtensions.ArrayCopy(Items, 0, newItems, 0, Count);
                items.CopyTo(newItems, Count);

                Items = newItems;
            }
            Count = count;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public void AddRangeUnchecked(ICollection<T> list)
            => list.CopyTo(Items, 0);

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