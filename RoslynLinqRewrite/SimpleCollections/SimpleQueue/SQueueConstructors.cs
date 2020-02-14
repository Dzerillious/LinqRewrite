using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SimpleCollections.SimpleList;

namespace SimpleCollections.SimpleQueue
{
    public partial class SimpleQueue<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public SimpleQueue()
        {
            Items = Empty;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public SimpleQueue(params T[] items)
        {
            Items = items;
            _tailIndex = items.Length - 1;
            _nextAddIndex = items.Length - 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public SimpleQueue(int capacity)
        {
            Items = new T[capacity];
        }

        public SimpleQueue(Array array)
        {
            var items = new T[array.Length];
            Array.Copy(array, 0, items, 0, array.Length);

            Items = items;
            _tailIndex = array.Length - 1;
            _nextAddIndex = array.Length - 1;
        }

        public SimpleQueue(T[] array, int capacity)
        {
            var items = new T[capacity];
            Array.Copy(array, 0, items, 0, array.Length);
            
            Items = items;
            _tailIndex = array.Length - 1;
            _nextAddIndex = array.Length;
        }

        public SimpleQueue(SimpleList<T> simpleList)
        {
            var items = new T[simpleList.Count];
            Array.Copy(simpleList.Items, 0, items, 0, simpleList.Count);
            
            Items = items;
            _tailIndex = simpleList.Count - 1;
            _nextAddIndex = simpleList.Count - 1;
        }

        public SimpleQueue(SimpleList<T> simpleList, int capacity)
        {
            var items = new T[capacity];
            Array.Copy(simpleList.Items, 0, items, 0, simpleList.Count);
            
            Items = items;
            _tailIndex = capacity - 1;
            _nextAddIndex = capacity - 1;
        }

        public SimpleQueue(ICollection<T> collection)
        {
            var items = new T[collection.Count];
            collection.CopyTo(items, 0);
            
            Items = items;
            _tailIndex = collection.Count - 1;
            _nextAddIndex = collection.Count - 1;
        }

        public SimpleQueue(IEnumerable<T> enumerable)
        {
            Items = new T[8];
            foreach (var value in enumerable)
                Enqueue(value);
        }

        public SimpleQueue(IEnumerable<T> enumerable, int length)
        {
            var array = new T[length];

            var enumerator = enumerable.GetEnumerator();
            for (var i = 0; i < length; i++)
            {
                enumerator.MoveNext();
                array[i] = enumerator.Current;
            }
            enumerator.Dispose();
            Items = array;
            _tailIndex = length - 1;
            _nextAddIndex = length - 1;
        }
    }
}