//using System.Collections.Generic;
//using SimpleCollections.FastList;
//
//namespace SimpleCollections.FastObservableCollection
//{
//    public interface IReadonlyFastObservableCollection<T> : IReadonlyFastList<T>
//    {
//        
//    }
//    
//    public interface IFastObservableCollection<T> : IFastList<T>, IReadonlyFastObservableCollection<T>
//    {
//        void SetDataEmpty();
//
//        void SetDataDefault();
//
//        void SetDataEnum(params T[] items);
//
//        void SetDataEmptyCapacity(int capacity);
//
//        void SetDataEmptyLength(int length);
//
//        void SetDataCopyArray(T[] array);
//
//        void SetDataCopyArrayWithCapacity(T[] array, int capacity);
//
//        void SetDataTakeArray(T[] array);
//
//        void SetDataTakeArrayCount(T[] array, int count);
//
//        void SetDataCopyFastList(FastList<T> fastList);
//
//        void SetDataCopyFastListWithCapacity(FastList<T> fastList, int capacity);
//
//        void SetDataTakeFastList(FastList<T> fastList);
//
//        void SetDataCopyList(ICollection<T> collection);
//
//        void SetDataCopyEnumerable(IEnumerable<T> enumerable);
//
//        void SetDataCopyEnumerable(IEnumerable<T> enumerable, int length);
//
//        void SetDataCopyEnumerableAssumeLength(IEnumerable<T> enumerable, int length);
//
//        void SetDataCopyEnumerableWithCapacity(IEnumerable<T> enumerable, int capacity);
//    }
//}