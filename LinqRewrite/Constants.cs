using System.Collections.Immutable;

namespace LinqRewrite
{
    public static class Constants
    {
        public static int MinArraySize = 8;
        public static int MinArraySizeLog = 3;
        public static int SimpleRewriteMaxSimpleElements = 20;
        public static int SimpleRewriteMaxMediumElements = 10;
        public static int SimpleRewriteMaxFewElements = 5;
        public static int VariablesPeek = 10_000;
        
        public static readonly ImmutableHashSet<string> MethodsCreateArray = ImmutableHashSet.Create(
            "Empty", "Range", "Repeat"
        );

        public static readonly ImmutableHashSet<string> MethodsModifyingEnumeration = ImmutableHashSet.Create(
            "Concat", "Distinct", "Except", "GroupBy",
            "GroupJoin", "Intersect", "Join", "OfType",
            "SkipWhile", "TakeWhile", "Union", "Where", "Zip",
            "SelectMany"
            /*"OrderBy",*//*"OrderByDescending"*//*"ThenByDescending"*//*"ThenByDescending"*/
        );

        public static readonly ImmutableHashSet<string> MethodsWithResult = ImmutableHashSet.Create(
            "Aggregate", "All", "Any", "Average",
            "Contains", "Count", "ElementAt", "ElementAtOrDefault",
            "First", "FirstOrDefault", "ForEach", "Last", "LastOrDefault",
            "LongCount", "Max", "Min", "SequenceEqual",
            "Single", "SingleOrDefault", "Sum", "ToArray",
            "ToDictionary", "ToList", /*"ToLookup",*/ "ToSimpleList"
        );

        public static readonly ImmutableHashSet<string> RewritableMethods = ImmutableHashSet.Create(
            "ToDictionary", "ToArray", "ToList", "ToSimpleList", /*"ToLookup",*/

            "First", "FirstOrDefault", "Last", "LastOrDefault",
            "Single", "SingleOrDefault", "ElementAt", "ElementAtOrDefault",

            "Count", "LongCount", "Sum", "Average",
            "Max", "Min", "Aggregate",

            "Any", "All", "Contains",

            "ForEach",

            "Select", "Where", "Cast", "OfType", "SelectMany",
            "Skip", "SkipWhile", "Take", "TakeWhile", "Reverse",

            "Concat", "Union", "Except", "Intersect", "Distinct",

            "SequenceEqual", "Zip",

            "Join", "GroupBy", "GroupJoin",

            "Range", "Repeat", "Empty",

            "Unchecked"
            /*"OrderBy",*/ /*"OrderByDescending"*/ /*"ThenByDescending"*/ /*"ThenByDescending"*/ /*"DefaultIfEmpty"*/
        );

        public const int MaximumSizeForByValStruct = 128 / 8; // eg. two longs, or two references
    }
}