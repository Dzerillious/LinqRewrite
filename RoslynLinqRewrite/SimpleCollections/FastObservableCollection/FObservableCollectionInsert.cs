//using System.Collections.Generic;
//using System.Collections.Specialized;
//using SimpleCollections.FastList;
//
//namespace SimpleCollections.FastObservableCollection
//{
//    public partial class FastObservableCollection<T>
//    {
//        public new void Insert(int index, T item)
//        {
//            CheckReEnter();
//            base.Insert(index, item);
//            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
//        }
//
//        public new void UncheckedInsert(int index, T item)
//        {
//            CheckReEnter();
//            base.UncheckedInsert(index, item);
//            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
//        }
//
//        public new void InsertRange(int index, T[] items)
//        {
//            CheckReEnter();
//            base.InsertRange(index, items);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = index + items.Length;
//            var collectionItems = Items;
//            for (var i = index; i < end; i++)
//                OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void InsertRangeUnchecked(int index, T[] items)
//        {
//            CheckReEnter();
//            base.InsertRangeUnchecked(index, items);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = index + items.Length;
//            var collectionItems = Items;
//            for (var i = index; i < end; i++)
//                OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void InsertRange(int index, FastList<T> fastList)
//        {
//            CheckReEnter();
//            base.InsertRange(index, fastList);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = index + fastList.Count;
//            var collectionItems = Items;
//            for (var i = index; i < end; i++)
//                OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void InsertRangeUnchecked(int index, FastList<T> fastList)
//        {
//            CheckReEnter();
//            base.InsertRangeUnchecked(index, fastList);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = index + fastList.Count;
//            var collectionItems = Items;
//            for (var i = index; i < end; i++)
//                OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void InsertRange(int index, IList<T> list)
//        {
//            CheckReEnter();
//            base.InsertRange(index, list);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = index + list.Count;
//            var collectionItems = Items;
//            for (var i = index; i < end; i++)
//                OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void InsertRangeUnchecked(int index, IList<T> list)
//        {
//            CheckReEnter();
//            base.InsertRangeUnchecked(index, list);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = index + list.Count;
//            var collectionItems = Items;
//            for (var i = index; i < end; i++)
//                OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void InsertRange(int index, IEnumerable<T> enumerable, int insertCount)
//        {
//            CheckReEnter();
//            base.InsertRange(index, enumerable, insertCount);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = index + insertCount;
//            var collectionItems = Items;
//            for (var i = index; i < end; i++)
//                OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//
//        public new void InsertRangeUnchecked(int index, IEnumerable<T> enumerable, int count)
//        {
//            CheckReEnter();
//            base.InsertRangeUnchecked(index, enumerable, count);
//            OnPropertyChanged("Count");
//            OnPropertyChanged("Item[]");
//            
//            var end = index + count;
//            var collectionItems = Items;
//            for (var i = index; i < end; i++)
//                OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collectionItems[i], i));
//        }
//    }
//}