//using System;
//using System.Collections.Generic;
//using SimpleCollections.FastList;
//
//namespace SimpleCollections.FastObservableCollection
//{
//    public partial class FastObservableCollection<T>
//    {
//        protected FastObservableCollection() {}
//
//        public new static FastObservableCollection<T> Dummy()
//            => new FastObservableCollection<T>();
//
//        public new static FastObservableCollection<T> Empty()
//            => new FastObservableCollection<T>
//            {
//                Items = new T[0]
//            };
//
//        public new static FastObservableCollection<T> Default()
//            => new FastObservableCollection<T>
//            {
//                Items = new T[8],
//                Length = 8
//            };
//
//        public new static FastObservableCollection<T> Enum(params T[] items)
//            => new FastObservableCollection<T>
//            {
//                Items = items,
//                Length = items.Length,
//                Count = items.Length
//            };
//
//        public new static FastObservableCollection<T> CapacityList(int capacity) =>
//            new FastObservableCollection<T>
//            {
//                Items = new T[capacity],
//                Length = capacity
//            };
//
//        public new static FastObservableCollection<T> LengthList(int length) =>
//            new FastObservableCollection<T>
//            {
//                Items = new T[length],
//                Length = length,
//                Count = length
//            };
//
//        public new static FastObservableCollection<T> CopyArray(T[] array)
//        {
//            var length = array.Length;
//            var items = new T[length];
//            Array.Copy(array, 0, items, 0, length);
//            
//            return new FastObservableCollection<T>
//            {
//                Items = items,
//                Length = length,
//                Count = length
//            };
//        }
//
//        public new static FastObservableCollection<T> CopyArrayWithCapacity(T[] array, int capacity)
//        {
//            var length = array.Length;
//            var items = new T[capacity];
//            Array.Copy(array, 0, items, 0, length);
//            
//            return new FastObservableCollection<T>
//            {
//                Items = items,
//                Length = capacity,
//                Count = length
//            };
//        }
//
//        public new static FastObservableCollection<T> TakeArray(T[] array)
//            => new FastObservableCollection<T>
//            {
//                Items = array, 
//                Length = array.Length, 
//                Count = array.Length
//            };
//
//        public new static FastObservableCollection<T> TakeArrayCount(T[] array, int count)
//            => new FastObservableCollection<T>
//            {
//                Items = array, 
//                Length = array.Length, 
//                Count = count
//            };
//
//        public new static FastObservableCollection<T> CopyFastList(FastList<T> fastList)
//        {
//            var length = fastList.Count;
//            var items = new T[length];
//            Array.Copy(fastList.Items, 0, items, 0, length);
//            
//            return new FastObservableCollection<T>
//            {
//                Items = items,
//                Length = length,
//                Count = length
//            };
//        }
//
//        public new static FastObservableCollection<T> CopyFastListWithCapacity(FastList<T> fastList, int capacity)
//        {
//            var items = new T[capacity];
//            Array.Copy(fastList.Items, 0, items, 0, fastList.Count);
//            
//            return new FastObservableCollection<T>
//            {
//                Items = items,
//                Length = capacity,
//                Count = fastList.Count
//            };
//        }
//
//        public new static FastObservableCollection<T> TakeFastList(FastList<T> fastList)
//            => new FastObservableCollection<T>
//            {
//                Items = fastList.Items, 
//                Length = fastList.Count, 
//                Count = fastList.Count
//            };
//
//        public new static FastObservableCollection<T> CopyList(ICollection<T> collection)
//        {
//            var count = collection.Count;
//            var items = new T[count];
//            collection.CopyTo(items, 0);
//            
//            return new FastObservableCollection<T>
//            {
//                Items = items,
//                Length = count,
//                Count = count
//            };
//        }
//
//        public new static FastObservableCollection<T> CopyEnumerable(IEnumerable<T> enumerable)
//        {
//            var list = new FastObservableCollection<T>
//            {
//                Items = new T[8],
//                Length = 8
//            };
//
//            foreach (var value in enumerable)
//                list.Add(value);
//            return list;
//        }
//
//        public new static FastObservableCollection<T> CopyEnumerable(IEnumerable<T> enumerable, int length)
//        {
//            var array = new T[length];
//
//            var enumerator = enumerable.GetEnumerator();
//            for (var i = 0; i < length; i++)
//            {
//                enumerator.MoveNext();
//                array[i] = enumerator.Current;
//            }
//            enumerator.Dispose();
//            
//            return new FastObservableCollection<T>
//            {
//                Items = array,
//                Length = length,
//                Count = length
//            };
//        }
//
//        public new static FastObservableCollection<T> CopyEnumerableAssumeLength(IEnumerable<T> enumerable, int length)
//        {
//            var count = length;
//            var list = new FastObservableCollection<T>
//            {
//                Items = new T[count],
//                Length = count
//            };
//
//            foreach (var value in enumerable)
//                list.Add(value);
//            return list;
//        }
//
//        public new static FastObservableCollection<T> CopyEnumerableWithCapacity(IEnumerable<T> enumerable, int capacity)
//        {
//            var items = new T[capacity];
//
//            var j = 0;
//            foreach (var value in enumerable)
//                items[j++] = value;
//            
//            return new FastObservableCollection<T>
//            {
//                Items = items,
//                Length = capacity,
//                Count = j
//            };
//        }
//    }
//}