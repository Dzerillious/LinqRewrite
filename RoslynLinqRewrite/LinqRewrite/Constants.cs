using System.Collections.Generic;

namespace LinqRewrite
{
    public static class Constants
    {
        private const string ToDictionary1 = "System.Collections.Generic.IEnumerable<TSource>.ToDictionary<TSource, TKey>(System.Func<TSource, TKey>)";
        private const string ToDictionary2 = "System.Collections.Generic.IEnumerable<TSource>.ToDictionary<TSource, TKey, TElement>(System.Func<TSource, TKey>, System.Func<TSource, TElement>, System.Collections.Generic.IEqualityComparer<TKey>)";
        private const string ToDictionary3 = "System.Collections.Generic.IEnumerable<TSource>.ToDictionary<TSource, TKey, TElement>(System.Func<TSource, TKey>, System.Func<TSource, TElement>)";
        private const string ToDictionary4 = "System.Collections.Generic.IEnumerable<TSource>.ToDictionary<TSource, TKey>(System.Func<TSource, TKey>, System.Collections.Generic.IEqualityComparer<TKey>)";
        
        private const string ToLookup1 = "System.Collections.Generic.IEnumerable<TSource>.ToLookup<TSource, TKey>(System.Func<TSource, TKey>)";
        private const string ToLookup2 = "System.Collections.Generic.IEnumerable<TSource>.ToLookup<TSource, TKey, TElement>(System.Func<TSource, TKey>, System.Func<TSource, TElement>, System.Collections.Generic.IEqualityComparer<TKey>)";
        private const string ToLookup3 = "System.Collections.Generic.IEnumerable<TSource>.ToLookup<TSource, TKey, TElement>(System.Func<TSource, TKey>, System.Func<TSource, TElement>)";
        private const string ToLookup4 = "System.Collections.Generic.IEnumerable<TSource>.ToLookup<TSource, TKey>(System.Func<TSource, TKey>, System.Collections.Generic.IEqualityComparer<TKey>)";
        
        private const string ToArray1 = "System.Collections.Generic.IEnumerable<TSource>.ToArray<TSource>()";
        private const string ToArray2 = "System.Collections.Generic.IEnumerable<T>.ToArray<T>(LinqRewrite.Core.EnlargingCoefficient)";
        private const string ToList1 = "System.Collections.Generic.IEnumerable<TSource>.ToList<TSource>()";
        private const string ToSimpleList1 = "System.Collections.Generic.IEnumerable<T>.ToSimpleList<T>()";
        private const string ToSimpleList2 = "System.Collections.Generic.IEnumerable<T>.ToSimpleList<T>(LinqRewrite.Core.EnlargingCoefficient)";

        private const string Reverse1 = "System.Collections.Generic.IEnumerable<TSource>.Reverse<TSource>()";
        private const string First1 = "System.Collections.Generic.IEnumerable<TSource>.First<TSource>()";
        private const string First2 = "System.Collections.Generic.IEnumerable<TSource>.First<TSource>(System.Func<TSource, bool>)";
        private const string Last1 = "System.Collections.Generic.IEnumerable<TSource>.Last<TSource>()";
        private const string Last2 = "System.Collections.Generic.IEnumerable<TSource>.Last<TSource>(System.Func<TSource, bool>)";
        private const string Single1 = "System.Collections.Generic.IEnumerable<TSource>.Single<TSource>()";
        private const string Single2 = "System.Collections.Generic.IEnumerable<TSource>.Single<TSource>(System.Func<TSource, bool>)";
        private const string FirstOrDefault1 = "System.Collections.Generic.IEnumerable<TSource>.FirstOrDefault<TSource>()";
        private const string FirstOrDefault2 = "System.Collections.Generic.IEnumerable<TSource>.FirstOrDefault<TSource>(System.Func<TSource, bool>)";
        private const string LastOrDefault1 = "System.Collections.Generic.IEnumerable<TSource>.LastOrDefault<TSource>()";
        private const string LastOrDefault2 = "System.Collections.Generic.IEnumerable<TSource>.LastOrDefault<TSource>(System.Func<TSource, bool>)";
        private const string SingleOrDefault1 = "System.Collections.Generic.IEnumerable<TSource>.SingleOrDefault<TSource>()";
        private const string SingleOrDefault2 = "System.Collections.Generic.IEnumerable<TSource>.SingleOrDefault<TSource>(System.Func<TSource, bool>)";

        private const string Count1 = "System.Collections.Generic.IEnumerable<TSource>.Count<TSource>()";
        private const string Count2 = "System.Collections.Generic.IEnumerable<TSource>.Count<TSource>(System.Func<TSource, bool>)";
        private const string LongCount1 = "System.Collections.Generic.IEnumerable<TSource>.LongCount<TSource>()";
        private const string LongCount2 = "System.Collections.Generic.IEnumerable<TSource>.LongCount<TSource>(System.Func<TSource, bool>)";
        private const string Aggregate1 = "System.Collections.Generic.IEnumerable<TSource>.Aggregate<TSource>(System.Func<TSource, TSource, TSource>)";
        private const string Aggregate2 = "System.Collections.Generic.IEnumerable<TSource>.Aggregate<TSource, TAccumulate>(TAccumulate, System.Func<TAccumulate, TSource, TAccumulate>)";
        private const string Aggregate3 = "System.Collections.Generic.IEnumerable<TSource>.Aggregate<TSource, TAccumulate, TResult>(TAccumulate, System.Func<TAccumulate, TSource, TAccumulate>, System.Func<TAccumulate, TResult>)";

        private const string ElementAt1 = "System.Collections.Generic.IEnumerable<TSource>.ElementAt<TSource>(int)";
        private const string ElementAtOrDefault1 = "System.Collections.Generic.IEnumerable<TSource>.ElementAtOrDefault<TSource>(int)";

        private const string Any1 = "System.Collections.Generic.IEnumerable<TSource>.Any<TSource>()";
        private const string Any2 = "System.Collections.Generic.IEnumerable<TSource>.Any<TSource>(System.Func<TSource, bool>)";

        private const string All1 = "System.Collections.Generic.IEnumerable<TSource>.All<TSource>(System.Func<TSource, bool>)";

        private const string Contains1 = "System.Collections.Generic.IEnumerable<TSource>.Contains<TSource>(TSource)";
        private const string Contains2 = "System.Collections.Generic.IEnumerable<TSource>.Contains<TSource>(TSource, System.Collections.Generic.IEqualityComparer<TSource>)";

        private const string ForEach1 = "System.Collections.Generic.List<T>.ForEach(System.Action<T>)";
        public const string ForEach2 = "System.Collections.Generic.IEnumerable<T>.ForEach<T>(System.Action<T>)";
        public const string Unchecked = "System.Collections.Generic.IEnumerable<T>.Unchecked<T>()";
        public const string WithResultSize = "System.Collections.Generic.IEnumerable<T>.WithResultSize<T>(int)";
        public const string WithMaxSize = "System.Collections.Generic.IEnumerable<T>.WithMaxSize<T>(int)";

        private const string Range1 = "System.Linq.Enumerable.Range(int, int)";
        private const string Range2 = "LinqRewrite.Core.ExtendedLinq.Range(int, int, int)";
        private const string Repeat1 = "System.Linq.Enumerable.Repeat<TResult>(TResult, int)";
        private const string Empty1 = "System.Linq.Enumerable.Empty<TResult>()";

        private const string Where1 = "System.Collections.Generic.IEnumerable<TSource>.Where<TSource>(System.Func<TSource, bool>)";
        private const string Where2 = "System.Collections.Generic.IEnumerable<TSource>.Where<TSource>(System.Func<TSource, int, bool>)";
        private const string Select1 = "System.Collections.Generic.IEnumerable<TSource>.Select<TSource, TResult>(System.Func<TSource, TResult>)";
        private const string Select2 = "System.Collections.Generic.IEnumerable<TSource>.Select<TSource, TResult>(System.Func<TSource, int, TResult>)";
        private const string SelectMany1 = "System.Collections.Generic.IEnumerable<TSource>.SelectMany<TSource, TResult>(System.Func<TSource, System.Collections.Generic.IEnumerable<TResult>>)";
        private const string SelectMany2 = "System.Collections.Generic.IEnumerable<TSource>.SelectMany<TSource, TResult>(System.Func<TSource, int, System.Collections.Generic.IEnumerable<TResult>>)";
        private const string SelectMany3 = "System.Collections.Generic.IEnumerable<TSource>.SelectMany<TSource, TCollection, TResult>(System.Func<TSource, System.Collections.Generic.IEnumerable<TCollection>>, System.Func<TSource, TCollection, TResult>)";
        private const string SelectMany4 = "System.Collections.Generic.IEnumerable<TSource>.SelectMany<TSource, TCollection, TResult>(System.Func<TSource, int, System.Collections.Generic.IEnumerable<TCollection>>, System.Func<TSource, TCollection, TResult>)";
                                           
        private const string Cast1 = "System.Collections.IEnumerable.Cast<TResult>()";
        private const string OfType1 = "System.Collections.IEnumerable.OfType<TResult>()";

        private const string Skip1 = "System.Collections.Generic.IEnumerable<TSource>.Skip<TSource>(int)";
        private const string Take1 = "System.Collections.Generic.IEnumerable<TSource>.Take<TSource>(int)";
        private const string SkipWhile1 = "System.Collections.Generic.IEnumerable<TSource>.SkipWhile<TSource>(System.Func<TSource, bool>)";
        private const string TakeWhile1 = "System.Collections.Generic.IEnumerable<TSource>.TakeWhile<TSource>(System.Func<TSource, bool>)";

        private const string Concat1 = "System.Collections.Generic.IEnumerable<TSource>.Concat<TSource>(System.Collections.Generic.IEnumerable<TSource>)";
        private const string Union1 = "System.Collections.Generic.IEnumerable<TSource>.Union<TSource>(System.Collections.Generic.IEnumerable<TSource>)";
        private const string Union2 = "System.Collections.Generic.IEnumerable<TSource>.Union<TSource>(System.Collections.Generic.IEnumerable<TSource>, System.Collections.Generic.IEqualityComparer<TSource>)";
        private const string Intersect1 = "System.Collections.Generic.IEnumerable<TSource>.Intersect<TSource>(System.Collections.Generic.IEnumerable<TSource>)";
        private const string Intersect2 = "System.Collections.Generic.IEnumerable<TSource>.Intersect<TSource>(System.Collections.Generic.IEnumerable<TSource>, System.Collections.Generic.IEqualityComparer<TSource>)";
        private const string Except1 = "System.Collections.Generic.IEnumerable<TSource>.Except<TSource>(System.Collections.Generic.IEnumerable<TSource>)";
        private const string Except2 = "System.Collections.Generic.IEnumerable<TSource>.Except<TSource>(System.Collections.Generic.IEnumerable<TSource>, System.Collections.Generic.IEqualityComparer<TSource>)";
        private const string Distinct1 = "System.Collections.Generic.IEnumerable<TSource>.Distinct<TSource>()";
        private const string Distinct2 = "System.Collections.Generic.IEnumerable<TSource>.Distinct<TSource>(System.Collections.Generic.IEqualityComparer<TSource>)";

        private const string SequenceEqual1 = "System.Collections.Generic.IEnumerable<TSource>.SequenceEqual<TSource>(System.Collections.Generic.IEnumerable<TSource>)";
        private const string SequenceEqual2 = "System.Collections.Generic.IEnumerable<TSource>.SequenceEqual<TSource>(System.Collections.Generic.IEnumerable<TSource>, System.Collections.Generic.IEqualityComparer<TSource>)";
        private const string Zip1 = "System.Collections.Generic.IEnumerable<TFirst>.Zip<TFirst, TSecond, TResult>(System.Collections.Generic.IEnumerable<TSecond>, System.Func<TFirst, TSecond, TResult>)";
        
        private const string Join1 = "System.Collections.Generic.IEnumerable<TOuter>.Join<TOuter, TInner, TKey, TResult>(System.Collections.Generic.IEnumerable<TInner>, System.Func<TOuter, TKey>, System.Func<TInner, TKey>, System.Func<TOuter, TInner, TResult>)";
        private const string Join2 = "System.Collections.Generic.IEnumerable<TOuter>.Join<TOuter, TInner, TKey, TResult>(System.Collections.Generic.IEnumerable<TInner>, System.Func<TOuter, TKey>, System.Func<TInner, TKey>, System.Func<TOuter, TInner, TResult>, System.Collections.Generic.IEqualityComparer<TKey>)";
        private const string GroupBy1 = "System.Collections.Generic.IEnumerable<TSource>.GroupBy<TSource, TKey, TElement, TResult>(System.Func<TSource, TKey>, System.Func<TSource, TElement>, System.Func<TKey, System.Collections.Generic.IEnumerable<TElement>, TResult>, System.Collections.Generic.IEqualityComparer<TKey>)";
        private const string GroupBy2 = "System.Collections.Generic.IEnumerable<TSource>.GroupBy<TSource, TKey, TElement, TResult>(System.Func<TSource, TKey>, System.Func<TSource, TElement>, System.Func<TKey, System.Collections.Generic.IEnumerable<TElement>, TResult>)";
        private const string GroupBy3 = "System.Collections.Generic.IEnumerable<TSource>.GroupBy<TSource, TKey, TElement>(System.Func<TSource, TKey>, System.Func<TSource, TElement>, System.Collections.Generic.IEqualityComparer<TKey>)";
        private const string GroupBy4 = "System.Collections.Generic.IEnumerable<TSource>.GroupBy<TSource, TKey, TElement>(System.Func<TSource, TKey>, System.Func<TSource, TElement>)";
        private const string GroupBy5 = "System.Collections.Generic.IEnumerable<TSource>.GroupBy<TSource, TKey, TResult>(System.Func<TSource, TKey>, System.Func<TKey, System.Collections.Generic.IEnumerable<TSource>, TResult>, System.Collections.Generic.IEqualityComparer<TKey>)";
        private const string GroupBy6 = "System.Collections.Generic.IEnumerable<TSource>.GroupBy<TSource, TKey, TResult>(System.Func<TSource, TKey>, System.Func<TKey, System.Collections.Generic.IEnumerable<TSource>, TResult>)";
        private const string GroupBy7 = "System.Collections.Generic.IEnumerable<TSource>.GroupBy<TSource, TKey>(System.Func<TSource, TKey>, System.Collections.Generic.IEqualityComparer<TKey>)";
        private const string GroupBy8 = "System.Collections.Generic.IEnumerable<TSource>.GroupBy<TSource, TKey>(System.Func<TSource, TKey>)";
        
        private const string GroupJoin1 = "System.Collections.Generic.IEnumerable<TOuter>.GroupJoin<TOuter, TInner, TKey, TResult>(System.Collections.Generic.IEnumerable<TInner>, System.Func<TOuter, TKey>, System.Func<TInner, TKey>, System.Func<TOuter, System.Collections.Generic.IEnumerable<TInner>, TResult>)";

        public const string ListPrefix = "System.Collections.Generic.List";
        public const string SimpleListPrefix = "LinqRewrite.Core.SimpleList.SimpleList<int>";

        public static readonly HashSet<string> MethodsCreateArray = new HashSet<string>
        {
            "Empty", "Range", "Repeat",
        };

        public static readonly HashSet<string> MethodsSimplyRewritable = new HashSet<string>
        {
            "Any", "Count", "ElementAt", "ElementAtOrDefault",
            "First", "FirstOrDefault", "Last", "LastOrDefault",
            "LongCount", "Single", "SingleOrDefault"
        };

        public static readonly HashSet<string> MethodsModifyingEnumeration = new HashSet<string>
        {
            "Concat", "Distinct", "Except", "GroupBy",
            "GroupJoin", "Intersect", "Join", "OfType",
            "SkipWhile", "TakeWhile", "Union", "Where", "Zip",
        };

        public static readonly HashSet<string> MethodsWithResult = new HashSet<string>
        {
            "Aggregate", "All", "Any", "Average",
            "Contains", "Count", "ElementAt", "ElementAtOrDefault",
            "First", "FirstOrDefault", "ForEach", "Last", "LastOrDefault",
            "LongCount", "Max", "Min", "SequenceEqual",
            "Single", "SingleOrDefault", "Sum", "ToArray",
            "ToDictionary", "ToList", "ToLookup", "ToSimpleList"
        };

        public static readonly HashSet<string> KnownMethods = new HashSet<string>
        {
            ToDictionary1, ToDictionary2, ToDictionary3, ToDictionary4,
            ToLookup1, ToLookup2, ToLookup3, ToLookup4,
            ToArray1, ToArray2, ToList1, ToSimpleList1, ToSimpleList2,
            Reverse1, 
            
            First1, First2, FirstOrDefault1, FirstOrDefault2, 
            Last1, Last2, LastOrDefault1, LastOrDefault2,
            Single1, Single2, SingleOrDefault1, SingleOrDefault2,
            
            Count1, Count2, LongCount1, LongCount2,
            Aggregate1, Aggregate2, Aggregate3,
            
            ElementAt1, ElementAtOrDefault1,
            
            Any1, Any2, All1,
            
            Contains1, Contains2,
            
            ForEach1, ForEach2,
            
            Select1, Select2, Where1, Where2, Cast1, OfType1,
            SelectMany1, SelectMany2, SelectMany3, SelectMany4,
            
            Range1, Range2, Repeat1, Empty1,
            
            Skip1, SkipWhile1, Take1, TakeWhile1,
            
            Concat1, Union1, Union2, Except1, Except2, Intersect1, Intersect2, Distinct1, Distinct2,
            
            
            SequenceEqual1, SequenceEqual2, Zip1,
            
            Join1, Join2, 
            GroupBy1, GroupBy2, GroupBy3, GroupBy4, GroupBy5, GroupBy6, GroupBy7, GroupBy8,
            GroupJoin1,
            
            Unchecked, WithMaxSize, WithResultSize
        };

        public const int MaximumSizeForByValStruct = 128 / 8; // eg. two longs, or two references
    }
}