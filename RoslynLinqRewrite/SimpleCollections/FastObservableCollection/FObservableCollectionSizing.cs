//using System;
//using System.Collections.Specialized;
//
//namespace SimpleCollections.FastObservableCollection
//{
//    public partial class FastObservableCollection<T>
//    {
//        public new void Reduce(int count)
//        {
//            var items = Items;
//            for (var i = Count - 1; i >= count; i--)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, items[i], i));
//            
//            Count = count;
//        }
//
//        public new void Enlarge(int count)
//        {
//            var items = new T[count];
//            Array.Copy(Items, 0, items, 0, Length);
//
//            for (var i = Count; i < count; i++)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, default, i));
//            
//            Items = items;
//            Length = count;
//            Count = count;
//        }
//
//        public new void EnlargeCapacity(int capacity)
//        {
//            var items = new T[capacity];
//            Array.Copy(Items, 0, items, 0, Length);
//
//            Items = items;
//            Length = capacity;
//        }
//
//        public new void Resize(int desiredSize)
//        {
//            if (desiredSize <= Length)
//            {
//                var items = Items;
//                for (var i = Count - 1; i >= desiredSize; i--)
//                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, items[i], i));
//                
//                Count = desiredSize;
//            }
//            else
//            {
//                var items = new T[desiredSize];
//                Array.Copy(Items, 0, items, 0, Length);
//
//                Items = items;
//                Length = desiredSize;
//                Count = desiredSize;
//            }
//        }
//
//        public new bool Remove(T item)
//        {
//            var index = -1;
//            var items = Items;
//            for (var i = 0; i < Count; i++)
//                if (items[i].Equals(item))
//                    index = i;
//
//            if (index == -1) return false;
//            var old = items[index];
//            Array.Copy(items, index, items, index - 1, Count - index - 1);
//            Count--;
//            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, old, index));
//            return true;
//        }
//
//        public new void RemoveLast()
//        {
//            var old = Items[Count - 1];
//            Count--;
//            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, old, Count));
//        }
//
//        public new void RemoveAt(int index)
//        {
//            var old = Items[index];
//            if (index == 0) Array.Copy(Items, 1, Items, 0, Count - 1);
//            else Array.Copy(Items, index, Items, index - 1, Count - index - 1);
//            Count--;
//            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, old, index));
//        }
//
//        public new void RemoveRange(int index, int count)
//        {
//            var oldItems = SkipTakeFastList(index, count);
//            Array.Copy(Items, index, Items, index - count, Count - index - count);
//            Count -= count;
//            
//            for (var i = 0; i < count; i++)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItems[i], i + index));
//        }
//
//        public new void ResizeEmptyReduce(int desiredSize)
//        {
//            if (desiredSize <= Length)
//            {
//                Count = desiredSize;
//                var items = Items;
//                for (var i = desiredSize; i < Length; i++)
//                {
//                    var old = items[i];
//                    items[i] = default;
//                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, old, i));
//                }
//            }
//            else
//            {
//                var items = new T[desiredSize];
//                Array.Copy(Items, 0, items, 0, Length);
//
//                Items = items;
//                Length = desiredSize;
//                Count = desiredSize;
//            }
//        }
//
//        public new void MakeEmptyAt(int index)
//        {
//            var old = Items[Count];
//            Array.Copy(Items, index, Items, index - 1, Count - index - 1);
//            Count--;
//            Items[Count] = default;
//            
//            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, old, index));
//        }
//
//        public new bool MakeEmpty(T item)
//        {
//            var index = -1;
//            var items = Items;
//            for (var i = 0; i < Count; i++)
//                if (items[i].Equals(item))
//                    index = i;
//
//            if (index == -1) return false;
//            var old = items[index];
//            Array.Copy(items, index, items, index - 1, Count - index - 1);
//            Count--;
//            items[Count] = default;
//            
//            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, old, index));
//            return true;
//        }
//
//        public new void MakeEmptyRange(int index, int count)
//        {
//            var items = Items;
//            Array.Copy(items, index, items, index - count, Count - index - count);
//            Count -= count;
//            for (var i = 0; i < count; i++)
//            {
//                var old = items[Count - i];
//                items[Count - i] = default;
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, old, Count - i));
//            } 
//        }
//
//        public new void MakeDefault()
//        {
//            Items = new T[8];
//            Length = 8;
//            Count = 0;
//            OnCollectionReset();
//        }
//
//        public new void MakeEmpty()
//        {
//            Items = new T[0];
//            Length = 0;
//            Count = 0;
//            OnCollectionReset();
//        }
//
//        public new void MakeEmptyWithCount(int count)
//        {
//            Items = new T[count];
//            Count = count;
//            Length = count;
//            OnCollectionReset();
//        }
//
//        public new void MakeEmptyWithCapacity(int capacity)
//        {
//            Items = new T[capacity];
//            Length = capacity;
//            Count = 0;
//            OnCollectionReset();
//        }
//
//        public new void Clear()
//        {
//            Count = 0;
//            OnCollectionReset();
//        }
//    }
//}