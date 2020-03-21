using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LinqRewrite.Core.SimpleList
{
    public partial class SimpleList<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void Take(T[] array)
        {
            Items = array;
            Count = array.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void Take(SimpleList<T> simpleList)
        {
            Items = simpleList.Items;
            Count = simpleList.Count;
        }
        
        public void Take(IList<T> list)
        {
            var count = list.Count;
            if (count > Items.Length)
                Items = new T[count];
            
            Count = count;
            list.CopyTo(Items, 0);
        }
        
        public void Take(ICollection<T> collection)
        {
            var count = collection.Count;
            if (count > Items.Length)
                Items = new T[count];
            
            Count = count;
            collection.CopyTo(Items, 0);
        }
        
        public void Take(IEnumerable<T> enumerable, int count)
        {
            if (count > Items.Length)
                Items = new T[count];
            
            var enumerator = enumerable.GetEnumerator();
            for (var i = 0; i < count; i++)
            {
                enumerator.MoveNext();
                Items[i] = enumerator.Current;
            }
            enumerator.Dispose();
            Count = count;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public void Take(IEnumerable<T> enumerable)
        {
            Count = 0;
            foreach (var item in enumerable)
                Add(item);
        }
    }
}