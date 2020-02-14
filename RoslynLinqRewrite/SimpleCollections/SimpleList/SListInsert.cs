using System;
using System.Collections.Generic;

namespace SimpleCollections.SimpleList
{
    public partial class SimpleList<T>
    {
        public void Insert(int index, T item)
        {
            if (index > Count) throw new IndexOutOfRangeException();
            if (Count + 1 <= Items.Length)
            {
                if (index + 1 < Count)
                    Array.Copy(Items, index, Items, index + 1, Count - index);
                Items[index] = item;
            }
            else
            {
                var newSize = Items.Length * 2;
                var newItems = new T[newSize];

                Array.Copy(Items, 0, newItems, 0, index);
                if (index + 1 < Items.Length)
                    Array.Copy(Items, index, newItems, index + 1, Count - index);
                newItems[index] = item;

                Items = newItems;
            }
            Count++;
        }

        public void InsertUnchecked(int index, T item)
        {
            if (index + 1 < Count)
                Array.Copy(Items, index, Items, index + 1, Count - index);
            Items[index] = item;
            Count++;
        }

        public void InsertRange(int index, T[] items)
        {
            if (index > Count) throw new IndexOutOfRangeException();
            var count = Count + items.Length;
            var continueIndex = index + items.Length;
            var continueCount = count - continueIndex;
            
            if (count <= Items.Length)
            {
                if (continueCount > 0)
                    Array.Copy(Items, index, Items, continueIndex, continueCount);
                Array.Copy(items, 0, Items, index, items.Length);
            }
            else
            {
                var newItems = new T[count];

                Array.Copy(Items, 0, newItems, 0, index);
                if (continueCount > 0)
                    Array.Copy(Items, index, newItems, continueIndex, continueCount);
                Array.Copy(items, 0, newItems, index, items.Length);

                Items = newItems;
            }
            Count += items.Length;
        }

        public void InsertRangeUnchecked(int index, T[] items)
        {
            var continueIndex = index + items.Length;
            var continueCount = Count + items.Length - continueIndex;
                                
            if (continueCount > 0)
                Array.Copy(Items, index, Items, continueIndex, continueCount);
            Array.Copy(items, 0, Items, index, items.Length);
            Count += items.Length;
        }

        public void InsertRange(int index, SimpleList<T> simpleList)
        {
            if (index > Count) throw new IndexOutOfRangeException();
            var count = Count + simpleList.Count;
            var items = simpleList.Items;
            var continueIndex = index + simpleList.Count;
            var continueCount = count - continueIndex;
            
            if (count <= Items.Length)
            {
                if (continueCount > 0)
                    Array.Copy(Items, index, Items, continueIndex, continueCount);
                Array.Copy(items, 0, Items, index, simpleList.Count);
            }
            else
            {
                var newItems = new T[count];

                Array.Copy(Items, 0, newItems, 0, index);
                if (continueCount > 0)
                    Array.Copy(Items, index, newItems, continueIndex, continueCount);
                Array.Copy(items, 0, newItems, index, simpleList.Count);

                Items = newItems;
            }
            Count = count;
        }

        public void InsertRangeUnchecked(int index, SimpleList<T> simpleList)
        {
            var items = simpleList.Items;
            var continueIndex = index + simpleList.Count;
            var continueCount = Count + simpleList.Count - continueIndex;
            if (continueCount > 0)
                Array.Copy(Items, index, Items, continueIndex, continueCount);
            Array.Copy(items, 0, Items, index, simpleList.Count);
            Count += simpleList.Count;
        }

        public void InsertRange(int index, IList<T> list)
        {
            if (index > Count) throw new IndexOutOfRangeException();
            var count = Count + list.Count;
            var continueIndex = index + list.Count;
            var continueCount = count - continueIndex;
            var items = Items;
            
            if (count <= Items.Length)
            {
                if (continueCount > 0)
                    Array.Copy(items, index, items, continueIndex, continueCount);
                for (var i = 0; i < index; i++)
                    items[i + index] = list[i];
            }
            else
            {
                var newItems = new T[count];

                Array.Copy(items, 0, newItems, 0, index);
                if (continueCount > 0)
                    Array.Copy(items, index, newItems, continueIndex, continueCount);
                for (var i = 0; i < index; i++)
                    items[i + index] = list[i];

                Items = newItems;
            }
            Count = count;
        }

        public void InsertRangeUnchecked(int index, IList<T> list)
        {
            var continueIndex = index + list.Count;
            var continueCount = Count + list.Count - continueIndex;
            var items = Items;
            
            if (continueCount > 0)
                Array.Copy(items, index, items, continueIndex, continueCount);
            for (var i = 0; i < index; i++)
                items[i + index] = list[i];
            Count += list.Count;
        }

        public void InsertRange(int index, IEnumerable<T> enumerable, int insertCount)
        {
            if (index > Count) throw new IndexOutOfRangeException();
            var count = Count + insertCount;
            var continueIndex = index + insertCount;
            var continueCount = count - continueIndex;
            var items = Items;
            
            if (count <= Items.Length)
            {
                if (continueCount > 0)
                    Array.Copy(items, index, items, continueIndex, continueCount);

                var j = index;
                foreach (var value in enumerable)
                    items[j++] = value;
            }
            else
            {
                var newItems = new T[count];

                Array.Copy(items, 0, newItems, 0, index);
                if (continueCount > 0)
                    Array.Copy(items, index, newItems, continueIndex, continueCount);

                var j = index;
                foreach (var value in enumerable)
                    newItems[j++] = value;

                Items = newItems;
            }
            Count = count;
        }

        public void InsertRangeUnchecked(int index, IEnumerable<T> enumerable, int count)
        {
            var continueIndex = index + count;
            var continueCount = Count + count - continueIndex;
            var items = Items;
            if (continueCount > 0)
                Array.Copy(items, index, items, continueIndex, continueCount);
            
            var j = index;
            foreach (var value in enumerable)
                items[j++] = value;
            Count += count;
        }
    }
}