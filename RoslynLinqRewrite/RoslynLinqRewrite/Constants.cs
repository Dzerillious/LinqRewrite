using System.Collections.Generic;

namespace LinqRewrite
{
    public static class Constants
    {
        //public const string ToDictionaryWithKeyMethod = "System.Collections.Generic.IEnumerable<TSource>.ToDictionary<TSource, TKey>(System.Func<TSource, TKey>)";
        public const string ToDictionaryWithKeyValueMethod = "System.Collections.Generic.IEnumerable<TSource>.ToDictionary<TSource, TKey, TElement>(System.Func<TSource, TKey>, System.Func<TSource, TElement>)";
        public const string ToArrayMethod = "System.Collections.Generic.IEnumerable<TSource>.ToArray<TSource>()";
        public const string ToListMethod = "System.Collections.Generic.IEnumerable<TSource>.ToList<TSource>()";
       
        public const string ReverseMethod = "System.Collections.Generic.IEnumerable<TSource>.Reverse<TSource>()";
        public const string FirstMethod = "System.Collections.Generic.IEnumerable<TSource>.First<TSource>()";
        public const string SingleMethod = "System.Collections.Generic.IEnumerable<TSource>.Single<TSource>()";
        public const string LastMethod = "System.Collections.Generic.IEnumerable<TSource>.Last<TSource>()";
        public const string FirstOrDefaultMethod = "System.Collections.Generic.IEnumerable<TSource>.FirstOrDefault<TSource>()";
        public const string SingleOrDefaultMethod = "System.Collections.Generic.IEnumerable<TSource>.SingleOrDefault<TSource>()";
        public const string LastOrDefaultMethod = "System.Collections.Generic.IEnumerable<TSource>.LastOrDefault<TSource>()";
        public const string FirstWithConditionMethod = "System.Collections.Generic.IEnumerable<TSource>.First<TSource>(System.Func<TSource, bool>)";
        public const string SingleWithConditionMethod = "System.Collections.Generic.IEnumerable<TSource>.Single<TSource>(System.Func<TSource, bool>)";
        public const string LastWithConditionMethod = "System.Collections.Generic.IEnumerable<TSource>.Last<TSource>(System.Func<TSource, bool>)";
        public const string FirstOrDefaultWithConditionMethod = "System.Collections.Generic.IEnumerable<TSource>.FirstOrDefault<TSource>(System.Func<TSource, bool>)";
        public const string SingleOrDefaultWithConditionMethod = "System.Collections.Generic.IEnumerable<TSource>.SingleOrDefault<TSource>(System.Func<TSource, bool>)";
        public const string LastOrDefaultWithConditionMethod = "System.Collections.Generic.IEnumerable<TSource>.LastOrDefault<TSource>(System.Func<TSource, bool>)";

        public const string CountMethod = "System.Collections.Generic.IEnumerable<TSource>.Count<TSource>()";
        public const string CountWithConditionMethod = "System.Collections.Generic.IEnumerable<TSource>.Count<TSource>(System.Func<TSource, bool>)";
        public const string LongCountMethod = "System.Collections.Generic.IEnumerable<TSource>.LongCount<TSource>()";
        public const string LongCountWithConditionMethod = "System.Collections.Generic.IEnumerable<TSource>.LongCount<TSource>(System.Func<TSource, bool>)";
        public const string AggregateMethod = "System.Collections.Generic.IEnumerable<TSource>.Aggregate<TSource>(System.Func<TSource, TSource, TSource>)";

        public const string ElementAtMethod = "System.Collections.Generic.IEnumerable<TSource>.ElementAt<TSource>(int)";
        public const string ElementAtOrDefaultMethod = "System.Collections.Generic.IEnumerable<TSource>.ElementAtOrDefault<TSource>(int)";

        public const string AnyMethod = "System.Collections.Generic.IEnumerable<TSource>.Any<TSource>()";
        public const string AnyWithConditionMethod = "System.Collections.Generic.IEnumerable<TSource>.Any<TSource>(System.Func<TSource, bool>)";

        public const string AllWithConditionMethod = "System.Collections.Generic.IEnumerable<TSource>.All<TSource>(System.Func<TSource, bool>)";

        public const string ContainsMethod = "System.Collections.Generic.IEnumerable<TSource>.Contains<TSource>(TSource)";
        public const string ContainsEqualityMethod = "System.Collections.Generic.IEnumerable<TSource>.Contains<TSource>(TSource, System.Collections.Generic.IEqualityComparer<TSource>)";

        public const string ListForEachMethod = "System.Collections.Generic.List<T>.ForEach(System.Action<T>)";
        public const string EnumerableForEachMethod = "System.Collections.Generic.IEnumerable<T>.ForEach<T>(System.Action<T>)";
        
        public const string RangeMethod = "System.Linq.Enumerable.Range(int, int)";
        public const string RepeatMethod = "System.Linq.Enumerable.Repeat<TResult>(TResult, int)";

        public const string WhereMethod = "System.Collections.Generic.IEnumerable<TSource>.Where<TSource>(System.Func<TSource, bool>)";
        public const string WhereIMethod = "System.Collections.Generic.IEnumerable<TSource>.Where<TSource>(System.Func<TSource, int, bool>)";
        public const string SelectMethod = "System.Collections.Generic.IEnumerable<TSource>.Select<TSource, TResult>(System.Func<TSource, TResult>)";
        public const string SelectIMethod = "System.Collections.Generic.IEnumerable<TSource>.Select<TSource, TResult>(System.Func<TSource, int, TResult>)";
        
        public const string CastMethod = "System.Collections.IEnumerable.Cast<TResult>()";
        public const string OfTypeMethod = "System.Collections.IEnumerable.OfType<TResult>()";

        public const string SkipMethod = "System.Collections.Generic.IEnumerable<TSource>.Skip<TSource>(int)";
        public const string TakeMethod = "System.Collections.Generic.IEnumerable<TSource>.Take<TSource>(int)";
        public const string SkipWhileMethod = "System.Collections.Generic.IEnumerable<TSource>.SkipWhile<TSource>(System.Func<TSource, bool>)";
        public const string TakeWhileMethod = "System.Collections.Generic.IEnumerable<TSource>.TakeWhile<TSource>(System.Func<TSource, bool>)";
        
        public const string SimpleListPrefix = "SimpleCollections.SimpleList.SimpleList";
        public const string ListPrefix = "System.Collections.Generic.List";
        public const string IEnumerablePrefix = "System.Collections.Generic.IEnumerable";

        public const string ConcatMethod = "System.Collections.Generic.IEnumerable<TSource>.Concat<TSource>(System.Collections.Generic.IEnumerable<TSource>)";
        
        public const string GlobalIndexerVariable = "__i";

        public static readonly HashSet<string> KnownMethods = new HashSet<string>
        {
            ToDictionaryWithKeyValueMethod, ToArrayMethod, ToListMethod, ReverseMethod, 
            
            FirstMethod, SingleMethod, LastMethod,
            FirstOrDefaultMethod, SingleOrDefaultMethod, LastOrDefaultMethod,
            FirstWithConditionMethod, SingleWithConditionMethod, LastWithConditionMethod,
            FirstOrDefaultWithConditionMethod, SingleOrDefaultWithConditionMethod, LastOrDefaultWithConditionMethod,
            
            CountMethod, CountWithConditionMethod, LongCountMethod, LongCountWithConditionMethod,
            AggregateMethod,
            
            ElementAtMethod, ElementAtOrDefaultMethod,
            
            AnyMethod, AnyWithConditionMethod, AllWithConditionMethod,
            
            ContainsMethod, ContainsEqualityMethod,
            
            ListForEachMethod,
            
            SelectMethod, SelectIMethod, WhereMethod, WhereIMethod, CastMethod, OfTypeMethod,
            
            RangeMethod, RepeatMethod,
            
            SkipMethod, SkipWhileMethod, TakeMethod, TakeWhileMethod,
            
            ConcatMethod,
            
            EnumerableForEachMethod
        };

        public const int MaximumSizeForByValStruct = 128 / 8; // eg. two longs, or two references
    }
}