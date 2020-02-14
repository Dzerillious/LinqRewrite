using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SimpleCollections.SimpleList;

namespace SimpleCollections.SimpleStack
{
    public partial class SimpleStack<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public SimpleStack()
        {
            Items = Empty;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public SimpleStack(params T[] items)
        {
            Items = items;
            Count = items.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public SimpleStack(int capacity)
        {
            Items = new T[capacity];
        }

        public SimpleStack(Array array)
        {
            var items = new T[array.Length];
            Array.Copy(array, 0, items, 0, array.Length);

            Items = items;
            Count = array.Length;
        }

        public SimpleStack(T[] array, int count)
        {
            var items = new T[count];
            Array.Copy(array, 0, items, 0, array.Length);
            
            Items = items;
            Count = array.Length;
        }

        public SimpleStack(SimpleList<T> simpleList)
        {
            var items = new T[simpleList.Count];
            Array.Copy(simpleList.Items, 0, items, 0, simpleList.Count);
            
            Items = items;
            Count = simpleList.Count;
        }

        public SimpleStack(SimpleList<T> simpleList, int count)
        {
            var items = new T[count];
            Array.Copy(simpleList.Items, 0, items, 0, simpleList.Count);
            
            Items = items;
            Count = count;
        }

        public SimpleStack(ICollection<T> collection)
        {
            var items = new T[collection.Count];
            collection.CopyTo(items, 0);
            
            Items = items;
            Count = collection.Count;
        }

        public SimpleStack(IEnumerable<T> enumerable)
        {
            Items = new T[8];
            foreach (var value in enumerable)
                Push(value);
        }

        public SimpleStack(IEnumerable<T> enumerable, int count)
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
    }
}