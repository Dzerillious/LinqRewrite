using System.Collections.Generic;

namespace LinqRewrite
{
    public static class Constants
    {
        public static readonly HashSet<string> MethodsCreateArray = new HashSet<string>
        {
            "Empty", "Range", "Repeat",
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

        public static readonly HashSet<string> RewritableMethods = new HashSet<string>
        {
            "ToDictionary", "ToArray", "ToList", "ToSimpleList",
            
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
            
            "Unchecked", "WithMaxSize", "WithResultSize"
        };

        public const int MaximumSizeForByValStruct = 128 / 8; // eg. two longs, or two references
    }
}