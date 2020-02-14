using System;
using System.Runtime.CompilerServices;
using SimpleCollections.SimpleList;

[assembly: InternalsVisibleTo("SimpleCollections.Tests")]
namespace SimpleCollections.SimpleQueue
{
    [Serializable]
    public partial class SimpleQueue<T>
    {
        private static readonly T[] Empty = new T[0];
        protected internal T[] Items;
        private int _headIndex;
        private int _tailIndex = -1;
        private int _nextAddIndex;
        private int _next2Index = 1;

        public T Head => Items[_headIndex];
        public T Tail => Items[_tailIndex];

        public bool IsEmpty() => _headIndex == _nextAddIndex;
        public bool IsFull() => _headIndex == _next2Index;
        
        public void Enqueue(T item)
        {
            _tailIndex = _nextAddIndex;
            _nextAddIndex = _next2Index;
            if (++_next2Index >= Items.Length) _next2Index = 0;
            if (_headIndex == _next2Index) EnlargeQueue(Items.Length * 2);
            Items[_tailIndex] = item;
        }

        public void NotCheckedEnqueue(T item)
        {
            _tailIndex = _nextAddIndex;
            _nextAddIndex = _next2Index;
            if (++_next2Index >= Items.Length) _next2Index = 0;
            Items[_tailIndex] = item;
        }

        public void EnlargeQueue(int desiredSize)
        {
            if (desiredSize < 8) desiredSize = 8;
            var items = new T[desiredSize];
            var length = Items.Length;
            var toEnd = length - _headIndex;
            
            Array.Copy(Items, _headIndex, items, 0, toEnd);
            Array.Copy(Items, 0, items, toEnd, _headIndex);

            _headIndex = 0;
            Items = items;

            _tailIndex = length - 2;
            _nextAddIndex = length - 1;
            _next2Index = length;
        }

        public void Clear()
        {
            _headIndex = 0;
            _tailIndex = -1;
            _next2Index = 1;
            _nextAddIndex = 0;
        }

        public T Dequeue()
        {
            var result = Items[_headIndex];
            if (++_headIndex >= Items.Length) _headIndex = 0;
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SimpleQueue<T>(T[] array) =>
            new SimpleQueue<T>(array);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SimpleQueue<T>(SimpleList<T> list) =>
            new SimpleQueue<T>(list);
    }
}