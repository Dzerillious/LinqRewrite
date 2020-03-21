using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SimpleCollections.Tests")]
namespace LinqRewrite.Core.SimpleList
{
    [Serializable]
    public partial class SimpleList<T> : IEnumerable<T>
    {
        private static readonly T[] Empty = new T[0];
        protected internal T[] Items;
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
        public T[] GetInnerArray() => Items;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SimpleList<T>(T[] array) =>
            new SimpleList<T>(array);
        
#if NETCORE

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> GetSpan() => new Span<T>(Items, 0, Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<T>(FastList<T> array) =>
            new Span<T>(array.Items, 0, array.Count);

#endif
      public IEnumerator<T> GetEnumerator()
        => new ArrayEnumerator(Items, 0, Count);

      IEnumerator IEnumerable.GetEnumerator()
        => new ArrayEnumerator(Items, 0, Count);

        [Serializable]
        private sealed class ArrayEnumerator : IEnumerator<T>, ICloneable
        {
          private Array _array;
          private int _index;
          private int _endIndex;
          private int _startIndex;
          private int[] _indices;
          private bool _complete;
          private T _current;

          internal ArrayEnumerator(Array array, int index, int count)
          {
            _array = array;
            _index = index - 1;
            _startIndex = index;
            _endIndex = index + count;
            _indices = new int[array.Rank];
            int num = 1;
            for (int dimension = 0; dimension < array.Rank; ++dimension)
            {
              _indices[dimension] = array.GetLowerBound(dimension);
              num *= array.GetLength(dimension);
            }
            --_indices[_indices.Length - 1];
            _complete = num == 0;
          }

          private void IncArray()
          {
            int rank = _array.Rank;
            ++_indices[rank - 1];
            for (int dimension1 = rank - 1; dimension1 >= 0; --dimension1)
            {
              if (_indices[dimension1] > _array.GetUpperBound(dimension1))
              {
                if (dimension1 == 0)
                {
                  _complete = true;
                  break;
                }
                for (int dimension2 = dimension1; dimension2 < rank; ++dimension2)
                  _indices[dimension2] = _array.GetLowerBound(dimension2);
                ++_indices[dimension1 - 1];
              }
            }
          }

          public object Clone()
          {
            return MemberwiseClone();
          }

          public bool MoveNext()
          {
            if (_complete)
            {
              _index = _endIndex;
              return false;
            }
            ++_index;
            IncArray();
            return !_complete;
          }

          public object Current
          {
            get
            {
              if (_index < _startIndex)
                throw new InvalidOperationException("Enum not started");
              if (_complete)
                throw new InvalidOperationException("Enum ended");
              return _array.GetValue(_indices);
            }
          }

          public void Reset()
          {
            _index = _startIndex - 1;
            int num = 1;
            for (int dimension = 0; dimension < _array.Rank; ++dimension)
            {
              _indices[dimension] = _array.GetLowerBound(dimension);
              num *= _array.GetLength(dimension);
            }
            _complete = num == 0;
            --_indices[_indices.Length - 1];
          }

          T IEnumerator<T>.Current => _current;

          public void Dispose()
          {
            _array = null;
          }
        }
    }
}