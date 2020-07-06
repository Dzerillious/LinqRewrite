using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class OfTypeTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayOfType), ArrayOfType, ArrayOfTypeRewritten);
            TestsExtensions.TestEquals(nameof(ArrayOfType2), ArrayOfType2, ArrayOfType2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayOfType3), ArrayOfType3, ArrayOfType3Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayOfType4), ArrayOfType4, ArrayOfType4Rewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectOfType), ArraySelectOfType, ArraySelectOfTypeRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereOfType), ArrayWhereOfType, ArrayWhereOfTypeRewritten);
            TestsExtensions.TestEquals(nameof(ArrayOfTypeAverage), ArrayOfTypeAverage, ArrayOfTypeAverageRewritten);
            TestsExtensions.TestEquals(nameof(ArrayOfTypeAny), ArrayOfTypeAny, ArrayOfTypeAnyRewritten);
            TestsExtensions.TestEquals(nameof(ArrayOfTypeAggregate), ArrayOfTypeAggregate, ArrayOfTypeAggregateRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableOfType), EnumerableOfType, EnumerableOfTypeRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableOfTypeToArray), EnumerableOfTypeToArray, EnumerableOfTypeToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayOfTypeToArray), ArrayOfTypeToArray, ArrayOfTypeToArrayRewritten);
        }

        public IEnumerable<int> ArrayOfType()
        {
            return ArrayItems.OfType<int>();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayOfTypeRewritten()
        {
            return ArrayItems.OfType<int>();
        } //EndMethod


        public IEnumerable<float> ArrayOfType2()
        {
            return ArrayItems.OfType<float>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<float> ArrayOfType2Rewritten()
        {
            return ArrayItems.OfType<float>();
        } //EndMethod
        
        
        public IEnumerable<double> ArrayOfType3()
        {
            return ArrayItems.OfType<double>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double> ArrayOfType3Rewritten()
        {
            return ArrayItems.OfType<double>();
        } //EndMethod


        public IEnumerable<double?> ArrayOfType4()
        {
            return ArrayItems.OfType<double?>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double?> ArrayOfType4Rewritten()
        {
            return ArrayItems.OfType<double?>();
        } //EndMethod


        public IEnumerable<int> ArraySelectOfType()
        {
            return ArrayItems.Select(x => x + 0.2).OfType<int>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<int> ArraySelectOfTypeRewritten()
        {
            return ArrayItems.Select(x => x + 0.2).OfType<int>();
        } //EndMethod
        
        
        public IEnumerable<double> ArrayWhereOfType()
        {
            return ArrayItems.Where(x => x % 2 == 1).OfType<double>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double> ArrayWhereOfTypeRewritten()
        {
            return ArrayItems.Where(x => x % 2 == 1).OfType<double>();
        } //EndMethod


        public double? ArrayOfTypeAverage()
        {
            return ArrayItems.OfType<double?>().Average();
        } //EndMethod
        
        [LinqRewrite]
		public double? ArrayOfTypeAverageRewritten()
        {
            return ArrayItems.OfType<double?>().Average();
        } //EndMethod


        public bool ArrayOfTypeAny()
        {
            return ArrayItems.OfType<double?>().Any(x => x == null);
        } //EndMethod
        
        [LinqRewrite]
		public bool ArrayOfTypeAnyRewritten()
        {
            return ArrayItems.OfType<double?>().Any(x => x == null);
        } //EndMethod


        public double ArrayOfTypeAggregate()
        {
            return ArrayItems.OfType<double>().Aggregate((x, y) => x * y);
        } //EndMethod
        
        [LinqRewrite]
		public double ArrayOfTypeAggregateRewritten()
        {
            return ArrayItems.OfType<double>().Aggregate((x, y) => x * y);
        } //EndMethod
        
        
        public IEnumerable<double> EnumerableOfType()
        {
            return EnumerableItems.OfType<double>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double> EnumerableOfTypeRewritten()
        {
            return EnumerableItems.OfType<double>();
        } //EndMethod
        
        
        public IEnumerable<double> EnumerableOfTypeToArray()
        {
            return EnumerableItems.OfType<double>().ToArray();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double> EnumerableOfTypeToArrayRewritten()
        {
            return EnumerableItems.OfType<double>().ToArray();
        } //EndMethod
        
        
        public IEnumerable<double> ArrayOfTypeToArray()
        {
            return ArrayItems.OfType<double>().ToArray();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double> ArrayOfTypeToArrayRewritten()
        {
            return ArrayItems.OfType<double>().ToArray();
        } //EndMethod
    }
}