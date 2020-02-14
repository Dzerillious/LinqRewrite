using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SimpleCollections.Tests")]
namespace SimpleCollections.SimpleList
{
    [Serializable]
    public partial class SimpleList<T>
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
    }
}