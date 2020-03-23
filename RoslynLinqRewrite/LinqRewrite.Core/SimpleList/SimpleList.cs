using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LinqRewrite")]
namespace LinqRewrite.Core.SimpleList
{
    [Serializable]
    public partial class SimpleList<T> : IEnumerable<T>
    {
        private static readonly T[] Empty = new T[0];
        public T[] Items;
        public int Count;

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Items[index]; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Items[index] = value;
        }

        [MethodImpl(MethodImplOptions.NoInlining)] 
        public void IncreaseCapacity()
        {
            var newSize = Items.Length * 2;
            if (newSize < 8) newSize = 8;
            
            var items = new T[newSize];
            Array.Copy(Items, 0, items, 0, Items.Length);

            Items = items;
        }
        
        public void SwapItems(int firstIndex, int secondIndex)
        {
            var item = Items[secondIndex];
            Items[secondIndex] = Items[firstIndex];
            Items[firstIndex] = item;
        }
        
        public void MoveItem(int oldIndex, int newIndex)
        {
            var item = Items[oldIndex];
            RemoveAt(oldIndex);
            Insert(newIndex, item);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SimpleList<T> WithCount(int count)
        {
            Count = count;
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SimpleList<T>(T[] array) 
          => new SimpleList<T> {Items = array, Count = array.Length};

        public static SimpleList<T> TakeWithCount(T[] array, int count)
        {
          var simpleList = new SimpleList<T>();
          simpleList.Items = array;
          simpleList.Count = count;
          return simpleList;
        }

#if NETCORE

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> GetSpan() => new Span<T>(Items, 0, Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<T>(FastList<T> array) =>
            new Span<T>(array.Items, 0, array.Count);

#endif
      
      public IEnumerator<T> GetEnumerator()
        => new SimpleListEnumerator(Items, Count);

      IEnumerator IEnumerable.GetEnumerator()
        => new SimpleListEnumerator(Items, Count);

      [Serializable]
      private sealed class SimpleListEnumerator : IEnumerator<T>, ICloneable
      {
          private T[] _array;
          private int _index;
          private int _endIndex;
          private T _current;

          internal SimpleListEnumerator(T[] array, int count)
          {
              _array = array;
              _index = -1;
              _endIndex = count - 1;
          }

          [MethodImpl(MethodImplOptions.AggressiveInlining)]
          public object Clone() => MemberwiseClone();

          public bool MoveNext()
          {
              if (_index == _endIndex) return false; 
              _current = _array[++_index];
              return true;
          }

          public object Current
          {
              [MethodImpl(MethodImplOptions.AggressiveInlining)]
              get => _current;
          }

          [MethodImpl(MethodImplOptions.AggressiveInlining)]
          public void Reset()
          {
              _index = -1;
              _current = default;
          }

          T IEnumerator<T>.Current
          {
              [MethodImpl(MethodImplOptions.AggressiveInlining)]
              get => _current;
          }

          [MethodImpl(MethodImplOptions.AggressiveInlining)]
          public void Dispose() => _array = null;
      }
    }
}