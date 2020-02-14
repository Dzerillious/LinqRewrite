using System;
using System.Runtime.CompilerServices;

namespace SimpleCollections.SimpleList
{
    public partial class SimpleList<T>
    {
        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
                if (Equals(Items[i], item))
                    return i;
            return -1;
        }

        public int IndexOf(Func<T, bool> predicate)
        {
            for (var i = 0; i < Count; i++)
                if (predicate(Items[i]))
                    return i;
            return -1;
        }

        public void ReverseOrder()
        {
            var items = Items;
            var count = Count;
            var reverseI = count - 1;
            
            for (var i = 0; i < count / 2; i++)
            {
                var temp = items[i];
                items[i] = items[reverseI];
                items[reverseI] = temp;
                
                reverseI--;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T First() => Items[0];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T FirstOrDefault() => Count == 0 ? default : Items[0];

        public T FirstOrDefault(Predicate<T> predicate)
        {
            var items = Items;
            var count = Count;
            for (var i = 0; i < count; i++)
                if (predicate(items[i]))
                    return items[i];
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Last() => Items[Count - 1];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T LastOrDefault() => Count == 0 ? default : Items[Count - 1];

        public T LastOrDefault(Predicate<T> predicate)
        {
            var items = Items;
            for (var i = Count - 1; i >= 0; i--)
                if (predicate(items[i]))
                    return items[i];
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Single() => Count == 1 ? Items[0] : throw new Exception("Not single element");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T SingleOrDefault() => Count == 1 ? Items[0] : default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T ElementAtOrDefault(int index)
            => index > Count ? default : Items[index];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Any() => Count > 0;

        public void Sort() => Array.Sort(Items, 0, Count);
    }
}