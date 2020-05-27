using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LinqRewrite")]
namespace LinqRewrite.Core.SimpleList
{
    [Serializable]
    public partial class SimpleList<T> : IList<T>
    {
#if (NET40 || NET45)
        public static readonly T[] Empty = new T[0];
#endif
        public T[] Items;

        public int Count { get; set; }
        public bool IsReadOnly => false;

        public T this[int index]
        {
#if !NET40
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Items[index]; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Items[index] = value;
#else
            get => Items[index]; 
            set => Items[index] = value;
#endif
        }
        
#if !NET40
        [MethodImpl(MethodImplOptions.NoInlining)]
#endif 
        private void IncreaseCapacity()
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
        
        public bool Contains(T item)
        {
            var count = Count;
            var array = Items;
            for (var i = 0; i < count; i++)
                if (array[i].Equals(item))
                    return true;
            return false;
        }

        public int IndexOf(T item)
        {
            var count = Count;
            var array = Items;
            for (var i = 0; i < count; i++)
                if (array[i].Equals(item))
                    return i;
            return -1;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        public static implicit operator SimpleList<T>(T[] array) 
          => new SimpleList<T> {Items = array, Count = array.Length};

#if NETCORE

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> GetSpan() => new Span<T>(Items, 0, Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<T>(FastList<T> array) =>
            new Span<T>(array.Items, 0, array.Count);

#endif
      
      public IEnumerator<T> GetEnumerator()
        => new Enumerator(Items, Count);

      IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator(Items, Count);

      [Serializable]
      public sealed class Enumerator : IEnumerator<T>, ICloneable
      {
          private T[] _array;
          private int _index;
          private int _endIndex;
          private T _current;

          internal Enumerator(T[] array, int count)
          {
              _array = array;
              _index = -1;
              _endIndex = count - 1;
          }
          
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
          public object Clone() => MemberwiseClone();

          public bool MoveNext()
          {
              if (_index == _endIndex) return false; 
              _current = _array[++_index];
              return true;
          }

          public object Current
          {
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
              get => _current;
          }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
          public void Reset()
          {
              _index = -1;
              _current = default;
          }

          T IEnumerator<T>.Current
          {
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
              get => _current;
          }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
          public void Dispose() => _array = null;
      }
    }
}