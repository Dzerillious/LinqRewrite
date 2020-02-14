using System.Runtime.CompilerServices;

namespace SimpleCollections.SimpleList
{
    public static class FListLinq
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static bool IsNullOrEmpty<T>(this SimpleList<T> list)
            => list == null || list.Count == 0;

        public static T[] SkipTakeSimple<T>(this SimpleList<T> list, int skip, int take)
        {
            var result = new T[take];
            for (var i = 0; i < take; i++)
                result[i] = list[i + skip];
            return result;
        }
    }
}