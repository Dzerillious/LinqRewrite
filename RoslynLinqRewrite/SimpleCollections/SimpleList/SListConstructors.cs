using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SimpleCollections.SimpleList
{
    public partial class SimpleList<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public SimpleList()
        {
            Items = Empty;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public SimpleList(int capacity)
        {
            Items = new T[capacity];
        }

        public SimpleList(T[] array)
        {
            var items = new T[array.Length];
            Array.Copy(array, 0, items, 0, array.Length);

            Items = items;
            Count = array.Length;
        }

        public SimpleList(T[] array, int count)
        {
            var items = new T[count];
            Array.Copy(array, 0, items, 0, count);
            
            Items = items;
            Count = array.Length;
        }

        public SimpleList(SimpleList<T> simpleList)
        {
            var items = new T[simpleList.Count];
            Array.Copy(simpleList.Items, 0, items, 0, simpleList.Count);
            
            Items = items;
            Count = simpleList.Count;
        }

        public SimpleList(SimpleList<T> simpleList, int count)
        {
            var items = new T[count];
            Array.Copy(simpleList.Items, 0, items, 0, simpleList.Count);
            
            Items = items;
            Count = count;
        }

        public SimpleList(ICollection<T> collection)
        {
            var items = new T[collection.Count];
            collection.CopyTo(items, 0);
            
            Items = items;
            Count = collection.Count;
        }

        public SimpleList(IEnumerable<T> enumerable)
        {
            Items = new T[8];
            foreach (var value in enumerable)
                Add(value);
        }

        public SimpleList(IEnumerable<T> enumerable, int count)
        {
            var array = new T[count];

            var enumerator = enumerable.GetEnumerator();
            for (var i = 0; i < count; i++)
            {
                enumerator.MoveNext();
                array[i] = enumerator.Current;
            }
            enumerator.Dispose();
            Items = array;
            Count = count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static SimpleList<T> FromParams(params T[] array) =>
            new SimpleList<T>
            {
                Items = array,
                Count = array.Length
            };
    }
}