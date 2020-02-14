using System;
using System.Collections.Generic;

namespace SimpleCollections
{
    public static class SimpleCollectionExtensions
    {
        public static T[] AppendRange<T>(this ICollection<T> collection, T[] appended)
        {
            var result = new T[collection.Count + appended.Length];
            collection.CopyTo(result, 0);
            Array.Copy(appended, 0, result, collection.Count, appended.Length);
            return result;
        }

        public static T[] AppendRange<T>(this ICollection<T> collection, IList<T> appended)
        {
            var count = collection.Count;
            var result = new T[count + appended.Count];

            collection.CopyTo(result, 0);
            for (var i = 0; i < appended.Count; i++)
                result[count + i] = appended[i];

            return result;
        }
    }
}