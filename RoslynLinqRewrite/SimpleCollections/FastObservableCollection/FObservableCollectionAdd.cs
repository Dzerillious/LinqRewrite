//using System.Collections.Generic;
//using System.Collections.Specialized;
//using SimpleCollections.FastList;
//
//namespace SimpleCollections.FastObservableCollection
//{
//    public partial class FastObservableCollection<T>
//    {
//        public new void Add(T item)
//        {
//            base.Add(item);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, Count - 1));
//        }
//
//        public new void UncheckedAdd(T item)
//        {
//            Items[Count++] = item;;
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, Count - 1));
//        }
//
//        public new void AddRange(T[] items)
//        {
//            var count = Count;
//            base.AddRange(items);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = count + items.Length;
//            var collectionItems = Items;
//            for (var i = count; i < end; i++)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void AddRangeUnchecked(T[] items)
//        {
//            var count = Count;
//            base.AddRangeUnchecked(items);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = count + items.Length;
//            var collectionItems = Items;
//            for (var i = count; i < end; i++)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void AddRange(FastList<T> fastList)
//        {
//            var count = Count;
//            base.AddRange(fastList);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = count + fastList.Count;
//            var collectionItems = Items;
//            for (var i = count; i < end; i++)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void AddRangeUnchecked(FastList<T> fastList)
//        {
//            var count = Count;
//            base.AddRangeUnchecked(fastList);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = count + fastList.Count;
//            var collectionItems = Items;
//            for (var i = count; i < end; i++)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void AddRange(IList<T> list)
//        {
//            var count = Count;
//            base.AddRange(list);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = count + list.Count;
//            var collectionItems = Items;
//            for (var i = count; i < end; i++)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void AddRangeUnchecked(IList<T> list)
//        {
//            var count = Count;
//            base.AddRangeUnchecked(list);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = count + list.Count;
//            var collectionItems = Items;
//            for (var i = count; i < end; i++)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void AddRange(IEnumerable<T> enumerable, int addCount)
//        {
//            var count = Count;
//            base.AddRange(enumerable, addCount);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = count + addCount;
//            var collectionItems = Items;
//            for (var i = count; i < end; i++)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void AddRangeUnchecked(IEnumerable<T> enumerable, int addCount)
//        {
//            var count = Count;
//            base.AddRangeUnchecked(enumerable, addCount);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//
//            var end = count + addCount;
//            var collectionItems = Items;
//            for (var i = count; i < end; i++)
//                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//    }
//}