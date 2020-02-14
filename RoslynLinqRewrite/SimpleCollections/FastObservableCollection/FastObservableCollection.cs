//using System;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;
//using SimpleCollections.FastList;
//
//[assembly: InternalsVisibleTo("SimpleCollections.Tests")]
//namespace SimpleCollections.FastObservableCollection
//{
//    [Serializable]
//    public partial class FastObservableCollection<T> : FastList<T>
//    {
//        private readonly SimpleMonitor _monitor = new SimpleMonitor();
//        
//        public new T this[int index]
//        {
//            get => Items[index];
//            set
//            {
//                var old = Items[index];
//                Items[index] = value;
//                OnPropertyChanged("Item[]");
//                OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, old, value, index));
//            }
//        }
//        
//        public new void UncheckedSet(int index, T value)
//        {
//            var old = Items[index];
//            Items[index] = value;
//            OnPropertyChanged("Item[]");
//            OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, old, value, index));
//        }
//
//        public new void Set(int index, T value)
//        {
//            if (index <= Count) throw new Exception("Index out of range");
//            var old = Items[index];
//            Items[index] = value;
//            OnPropertyChanged("Item[]");
//            OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, old, value, index));
//        }
//        
//        public new void MoveItem(int oldIndex, int newIndex)
//        {
//            var old = Items[oldIndex];
//            base.MoveItem(oldIndex, newIndex);
//            OnPropertyChanged("Item[]");
//            OnItemChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, old, newIndex, oldIndex));
//        }
//
//        public event NotifyCollectionChangedEventHandler CollectionChanged;
//        
//        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count")); 
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
//            
//            if (CollectionChanged == null) return;
//            using (_monitor.Enter())
//                CollectionChanged?.Invoke(this, e);
//        }
//        
//        protected virtual void OnItemChanged(NotifyCollectionChangedEventArgs e)
//        {
//            if (CollectionChanged == null) return;
//            using (_monitor.Enter())
//                CollectionChanged?.Invoke(this, e);
//        }
//
//        private void OnCollectionReset()
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count")); 
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
//            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
//        }
//
//        public event PropertyChangedEventHandler PropertyChanged;
//
//        private void OnPropertyChanged(string propertyName)
//            => OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
//        
//        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
//            => PropertyChanged?.Invoke(this, e);
//
//        protected void CheckReEnter()
//        {
//            if (_monitor.Busy && CollectionChanged != null && CollectionChanged.GetInvocationList().Length > 1)
//                throw new InvalidOperationException("Collection reenter not allowed");
//        }
//        
//        [Serializable]
//        private class SimpleMonitor : IDisposable
//        {
//            private int _busyCount;
//
//            public IDisposable Enter()
//            {
//                ++_busyCount;
//                return this;
//            }
//
//            public void Dispose() => --_busyCount;
//
//            public bool Busy => _busyCount > 0;
//        }
//    }
//}