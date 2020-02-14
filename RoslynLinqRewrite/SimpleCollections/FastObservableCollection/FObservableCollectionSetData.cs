//using System;
//using System.Collections.Generic;
//using SimpleCollections.FastList;
//
//namespace SimpleCollections.FastObservableCollection
//{
//    public partial class FastObservableCollection<T>
//    {
//        public void SetDataEmpty()
//        {
//            Items = new T[0];
//            Count = 0;
//            Length = 0;
//            OnCollectionReset();
//        }
//
//        public void SetDataDefault()
//        {
//            Items = new T[8];
//            Length = 8;
//            Count = 0;
//            OnCollectionReset();
//        }
//
//        public void SetDataEnum(params T[] items)
//        {
//            Items = items;
//            Length = items.Length;
//            Count = items.Length;
//            OnCollectionReset();
//        }
//
//        public void SetDataEmptyCapacity(int capacity)
//        {
//            Items = new T[capacity];
//            Length = capacity;
//            Count = 0;
//            OnCollectionReset();
//        }
//
//        public void SetDataEmptyLength(int length)
//        {
//            Items = new T[length];
//            Length = length;
//            Count = length;
//            OnCollectionReset();
//        }
//
//        public void SetDataCopyArray(T[] array)
//        {
//            var length = array.Length;
//            var items = new T[length];
//            Array.Copy(array, 0, items, 0, length);
//
//            Items = new T[length];
//            Length = length;
//            Count = length;
//            OnCollectionReset();
//        }
//
//        public void SetDataCopyArrayWithCapacity(T[] array, int capacity)
//        {
//            var length = array.Length;
//            var items = new T[capacity];
//            Array.Copy(array, 0, items, 0, length);
//
//            Items = new T[capacity];
//            Length = capacity;
//            Count = length;
//            OnCollectionReset();
//        }
//
//        public void SetDataTakeArray(T[] array)
//        {
//            Items = array;
//            Length = array.Length;
//            Count = array.Length;
//            OnCollectionReset();
//        }
//
//        public void SetDataTakeArrayCount(T[] array, int count)
//        {
//            Items = array;
//            Length = array.Length;
//            Count = count;
//            OnCollectionReset();
//        }
//
//        public void SetDataCopyFastList(FastList<T> fastList)
//        {
//            var length = fastList.Count;
//            var items = new T[length];
//            Array.Copy(fastList.Items, 0, items, 0, length);
//
//            Items = new T[length];
//            Length = length;
//            Count = length;
//            OnCollectionReset();
//        }
//
//        public void SetDataCopyFastListWithCapacity(FastList<T> fastList, int capacity)
//        {
//            var items = new T[capacity];
//            Array.Copy(fastList.Items, 0, items, 0, fastList.Count);
//
//            Items = new T[capacity];
//            Length = capacity;
//            Count = fastList.Count;
//            OnCollectionReset();
//        }
//
//        public void SetDataTakeFastList(FastList<T> fastList)
//        {
//            Items = fastList.Items;
//            Length = fastList.Count;
//            Count = fastList.Count;
//            OnCollectionReset();
//        }
//
//        public void SetDataCopyList(ICollection<T> collection)
//        {
//            var count = collection.Count;
//            var items = new T[count];
//            collection.CopyTo(items, 0);
//
//            Items = new T[count];
//            Length = count;
//            Count = count;
//            OnCollectionReset();
//        }
//
//        public void SetDataCopyEnumerable(IEnumerable<T> enumerable)
//        {
//            Items = new T[8];
//            Length = 8;
//            Count = 0;
//
//            foreach (var value in enumerable)
//                Add(value);
//            OnCollectionReset();
//        }
//
//        public void SetDataCopyEnumerable(IEnumerable<T> enumerable, int length)
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
//            Items = array;
//            Length = length;
//            Count = length;
//            OnCollectionReset();
//        }
//
//        public void SetDataCopyEnumerableAssumeLength(IEnumerable<T> enumerable, int length)
//        {
//            var count = length;
//            Items = new T[count];
//            Length = count;
//            Count = 0;
//
//            foreach (var value in enumerable)
//                Add(value);
//            OnCollectionReset();
//        }
//
//        public void SetDataCopyEnumerableWithCapacity(IEnumerable<T> enumerable, int capacity)
//        {
//            var count = capacity;
//            Items = new T[count];
//            Length = count;
//            Count = 0;
//
//            var j = 0;
//            foreach (var value in enumerable)
//                Items[j++] = value;
//            Count = j;
//            OnCollectionReset();
//        }
//    }
//}