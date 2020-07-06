using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class AverageTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public double? Selector(int x) => x + 5;

        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayAverage), ArrayAverage, ArrayAverageRewritten);
            TestsExtensions.TestEquals(nameof(ArrayAverage1), ArrayAverage1, ArrayAverage1Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayAverage2), ArrayAverage2, ArrayAverage2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayAverage3), ArrayAverage3, ArrayAverage3Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayAverage4), ArrayAverage4, ArrayAverage4Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayAverage5), ArrayAverage5, ArrayAverage5Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayAverage6), ArrayAverage6, ArrayAverage6Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayAverage7), ArrayAverage7, ArrayAverage7Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayAverage8), ArrayAverage8, ArrayAverage8Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayAverage9), ArrayAverage9, ArrayAverage9Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayAverage10), ArrayAverage10, ArrayAverage10Rewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectAverage), ArraySelectAverage, ArraySelectAverageRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereAverage), ArrayWhereAverage, ArrayWhereAverageRewritten);
            TestsExtensions.TestEquals(nameof(ArrayMethodAverage), ArrayMethodAverage, ArrayMethodAverageRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableAverage), EnumerableAverage, EnumerableAverageRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableEmptyAverage), EnumerableEmptyAverage, EnumerableEmptyAverageRewritten);
            TestsExtensions.TestEquals(nameof(ArrayMethodAverageChangingParam), ArrayMethodAverageChangingParam, ArrayMethodAverageChangingParamRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableRangeAverage), EnumerableRangeAverage, EnumerableRangeAverageRewritten);
        }
        
        public double ArrayAverage()
        {
            return ArrayItems.Average();
        } //EndMethod
        
        [LinqRewrite]
		public double ArrayAverageRewritten()
        {
            return ArrayItems.Average();
        } //EndMethod

        
        public double ArrayAverage1()
        {
            return ArrayItems.Average(x => x + 3);
        } //EndMethod
        
        [LinqRewrite]
		public double ArrayAverage1Rewritten()
        {
            return ArrayItems.Average(x => x + 3);
        } //EndMethod
        
        
        public double? ArrayAverage2()
        {
            return ArrayItems.Average(x => x > 10 ? (int?)null: x);
        } //EndMethod
        
        [LinqRewrite]
		public double? ArrayAverage2Rewritten()
        {
            return ArrayItems.Average(x => x > 10 ? (int?)null: x);
        } //EndMethod
        
        
        public double ArrayAverage3()
        {
            return ArrayItems.Average(x => x + 5f);
        } //EndMethod
        
        [LinqRewrite]
		public double ArrayAverage3Rewritten()
        {
            return ArrayItems.Average(x => x + 5f);
        } //EndMethod
        
        
        public double? ArrayAverage4()
        {
            return ArrayItems.Average(x => x > 10 ? (float?)null: x);
        } //EndMethod
        
        [LinqRewrite]
		public double? ArrayAverage4Rewritten()
        {
            return ArrayItems.Average(x => x > 10 ? (float?)null: x);
        } //EndMethod
        
        
        public double ArrayAverage5()
        {
            return ArrayItems.Average(x => x + 5d);
        } //EndMethod
        
        [LinqRewrite]
		public double ArrayAverage5Rewritten()
        {
            return ArrayItems.Average(x => x + 5d);
        } //EndMethod
        
        
        public double? ArrayAverage6()
        {
            return ArrayItems.Average(x => x > 10 ? (double?)null: x);
        } //EndMethod
        
        [LinqRewrite]
		public double? ArrayAverage6Rewritten()
        {
            return ArrayItems.Average(x => x > 10 ? (double?)null: x);
        } //EndMethod
        
        
        public decimal ArrayAverage7()
        {
            return ArrayItems.Average(x => x + 5m);
        } //EndMethod
        
        [LinqRewrite]
		public decimal ArrayAverage7Rewritten()
        {
            return ArrayItems.Average(x => x + 5m);
        } //EndMethod
        
        
        public decimal? ArrayAverage8()
        {
            return ArrayItems.Average(x => x > 10 ? (decimal?)null: x);
        } //EndMethod
        
        [LinqRewrite]
		public decimal? ArrayAverage8Rewritten()
        {
            return ArrayItems.Average(x => x > 10 ? (decimal?)null: x);
        } //EndMethod
        
        
        public double ArrayAverage9()
        {
            return ArrayItems.Average(x => x + 5L);
        } //EndMethod
        
        [LinqRewrite]
		public double ArrayAverage9Rewritten()
        {
            return ArrayItems.Average(x => x + 5L);
        } //EndMethod
        
        
        public double? ArrayAverage10()
        {
            return ArrayItems.Average(x => x > 10 ? (long?)null: x);
        } //EndMethod
        
        [LinqRewrite]
		public double? ArrayAverage10Rewritten()
        {
            return ArrayItems.Average(x => x > 10 ? (long?)null: x);
        } //EndMethod
        
        
        public double ArraySelectAverage()
        {
            return ArrayItems.Select(x => x + 10).Average();
        } //EndMethod
        
        [LinqRewrite]
		public double ArraySelectAverageRewritten()
        {
            return ArrayItems.Select(x => x + 10).Average();
        } //EndMethod
        
        
        public double ArrayWhereAverage()
        {
            return ArrayItems.Where(x => x % 2 == 0).Average();
        } //EndMethod
        
        [LinqRewrite]
		public double ArrayWhereAverageRewritten()
        {
            return ArrayItems.Where(x => x % 2 == 0).Average();
        } //EndMethod
        
        
        public double? ArrayMethodAverage()
        {
            return ArrayItems.Average(Selector);
        } //EndMethod
        
        [LinqRewrite]
		public double? ArrayMethodAverageRewritten()
        {
            return ArrayItems.Average(Selector);
        } //EndMethod
        
        
        public double EnumerableAverage()
        {
            return EnumerableItems.Average();
        } //EndMethod
        
        [LinqRewrite]
		public double EnumerableAverageRewritten()
        {
            return EnumerableItems.Average();
        } //EndMethod
        
        
        public double? ArrayMethodAverageChangingParam()
        {
            var a = 5;
            return ArrayItems.Average(x => x + a++);
        } //EndMethod
        
        [LinqRewrite]
		public double? ArrayMethodAverageChangingParamRewritten()
        {
            var a = 5;
            return ArrayItems.Average(x => x + a++);
        } //EndMethod
        
        
        public double? EnumerableNullAverage()
        {
            return EnumerableItems.Average(x => (int?)null);
        } //EndMethod
        
        [LinqRewrite]
		public double? EnumerableNullAverageRewritten()
        {
            return EnumerableItems.Average(x => (int?)null);
        } //EndMethod
        
        
        public double EnumerableEmptyAverage()
        {
            return EnumerableItems.Where(x => false).Average();
        } //EndMethod
        
        [LinqRewrite]
		public double EnumerableEmptyAverageRewritten()
        {
            return EnumerableItems.Where(x => false).Average();
        } //EndMethod
        
        
        public double EnumerableRangeAverage()
        {
            return Enumerable.Range(5, 100).Average();
        } //EndMethod
        
        [LinqRewrite]
		public double EnumerableRangeAverageRewritten()
        {
            return Enumerable.Range(5, 100).Average();
        } //EndMethod

    }
}