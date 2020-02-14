using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SimpleCollections.Tests")]
namespace SimpleCollections.SimpleStack
{
    [Serializable]
    public partial class SimpleStack<T>
    {
        private static readonly T[] Empty = new T[0];
        protected internal T[] Items;
        public int Count;
        
        public T Top
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Items[Count - 1];
        }

        public T Bottom
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Items[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void Push(T item)
        {
            var count = Count + 1;
            if (count >= Items.Length) AddCapacity(count);
            
            Items[Count] = item;
            Count = count;
        }

        [MethodImpl(MethodImplOptions.NoInlining)] 
        public void AddCapacity(int count)
        {
            var newSize = Items.Length * 2;
            if (newSize < 8) newSize = 8;
            
            var items = new T[newSize];
            Array.Copy(Items, 0, items, 0, Items.Length);

            Items = items;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public T Pop() => Items[--Count];
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void UncheckedPush(T item) => Items[Count++] = item;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public bool IsEmpty() => Count == 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void Clear() => Count = 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SimpleStack<T>(T[] array) =>
            new SimpleStack<T>(array);
        
#if NETCORE

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> GetSpan() => new Span<T>(Items, 0, Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<T>(FastStack<T> array) =>
            new Span<T>(array.Items, 0, array.Count);

#endif
    }
}