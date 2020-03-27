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
            ArrayAverage().TestEquals(nameof(ArrayAverage), ArrayAverageRewritten());        
            ArrayAverage1().TestEquals(nameof(ArrayAverage1), ArrayAverage1Rewritten());        
            ArrayAverage2().TestEquals(nameof(ArrayAverage2), ArrayAverage2Rewritten());        
            ArrayAverage3().TestEquals(nameof(ArrayAverage3), ArrayAverage3Rewritten());        
            ArrayAverage4().TestEquals(nameof(ArrayAverage4), ArrayAverage4Rewritten());        
            ArrayAverage5().TestEquals(nameof(ArrayAverage5), ArrayAverage5Rewritten());        
            ArrayAverage6().TestEquals(nameof(ArrayAverage6), ArrayAverage6Rewritten());        
            ArrayAverage7().TestEquals(nameof(ArrayAverage7), ArrayAverage7Rewritten());        
            ArrayAverage8().TestEquals(nameof(ArrayAverage8), ArrayAverage8Rewritten());        
            ArrayAverage9().TestEquals(nameof(ArrayAverage9), ArrayAverage9Rewritten());        
            ArrayAverage10().TestEquals(nameof(ArrayAverage10), ArrayAverage10Rewritten());        
            ArraySelectAverage().TestEquals(nameof(ArraySelectAverage), ArraySelectAverageRewritten());        
            ArrayWhereAverage().TestEquals(nameof(ArrayWhereAverage), ArrayWhereAverageRewritten());        
            ArrayMethodAverage().TestEquals(nameof(ArrayMethodAverage), ArrayMethodAverageRewritten());        
            EnumerableAverage().TestEquals(nameof(EnumerableAverage), EnumerableAverageRewritten());        
            ArrayMethodAverageChangingParam().TestEquals(nameof(ArrayMethodAverageChangingParam), ArrayMethodAverageChangingParamRewritten());
        }
        
        [NoRewrite]
        public double ArrayAverage()
        {
            return ArrayItems.Average();
        } //EndMethod
        
        public double ArrayAverageRewritten()
        {
            return ArrayItems.Average();
        } //EndMethod

        
        [NoRewrite]
        public double ArrayAverage1()
        {
            return ArrayItems.Average(x => x + 3);
        } //EndMethod
        
        public double ArrayAverage1Rewritten()
        {
            return ArrayItems.Average(x => x + 3);
        } //EndMethod
        
        
        [NoRewrite]
        public double? ArrayAverage2()
        {
            return ArrayItems.Average(x => x > 10 ? (int?)null: x);
        } //EndMethod
        
        public double? ArrayAverage2Rewritten()
        {
            return ArrayItems.Average(x => x > 10 ? (int?)null: x);
        } //EndMethod
        
        
        [NoRewrite]
        public double ArrayAverage3()
        {
            return ArrayItems.Average(x => x + 5f);
        } //EndMethod
        
        public double ArrayAverage3Rewritten()
        {
            return ArrayItems.Average(x => x + 5f);
        } //EndMethod
        
        
        [NoRewrite]
        public double? ArrayAverage4()
        {
            return ArrayItems.Average(x => x > 10 ? (float?)null: x);
        } //EndMethod
        
        public double? ArrayAverage4Rewritten()
        {
            return ArrayItems.Average(x => x > 10 ? (float?)null: x);
        } //EndMethod
        
        
        [NoRewrite]
        public double ArrayAverage5()
        {
            return ArrayItems.Average(x => x + 5d);
        } //EndMethod
        
        public double ArrayAverage5Rewritten()
        {
            return ArrayItems.Average(x => x + 5d);
        } //EndMethod
        
        
        [NoRewrite]
        public double? ArrayAverage6()
        {
            return ArrayItems.Average(x => x > 10 ? (double?)null: x);
        } //EndMethod
        
        public double? ArrayAverage6Rewritten()
        {
            return ArrayItems.Average(x => x > 10 ? (double?)null: x);
        } //EndMethod
        
        
        [NoRewrite]
        public decimal ArrayAverage7()
        {
            return ArrayItems.Average(x => x + 5m);
        } //EndMethod
        
        public decimal ArrayAverage7Rewritten()
        {
            return ArrayItems.Average(x => x + 5m);
        } //EndMethod
        
        
        [NoRewrite]
        public decimal? ArrayAverage8()
        {
            return ArrayItems.Average(x => x > 10 ? (decimal?)null: x);
        } //EndMethod
        
        public decimal? ArrayAverage8Rewritten()
        {
            return ArrayItems.Average(x => x > 10 ? (decimal?)null: x);
        } //EndMethod
        
        
        [NoRewrite]
        public double ArrayAverage9()
        {
            return ArrayItems.Average(x => x + 5L);
        } //EndMethod
        
        public double ArrayAverage9Rewritten()
        {
            return ArrayItems.Average(x => x + 5L);
        } //EndMethod
        
        
        [NoRewrite]
        public double? ArrayAverage10()
        {
            return ArrayItems.Average(x => x > 10 ? (long?)null: x);
        } //EndMethod
        
        public double? ArrayAverage10Rewritten()
        {
            return ArrayItems.Average(x => x > 10 ? (long?)null: x);
        } //EndMethod
        
        
        [NoRewrite]
        public double ArraySelectAverage()
        {
            return ArrayItems.Select(x => x + 10).Average();
        } //EndMethod
        
        public double ArraySelectAverageRewritten()
        {
            return ArrayItems.Select(x => x + 10).Average();
        } //EndMethod
        
        
        [NoRewrite]
        public double ArrayWhereAverage()
        {
            return ArrayItems.Where(x => x % 2 == 0).Average();
        } //EndMethod
        
        public double ArrayWhereAverageRewritten()
        {
            return ArrayItems.Where(x => x % 2 == 0).Average();
        } //EndMethod
        
        
        [NoRewrite]
        public double? ArrayMethodAverage()
        {
            return ArrayItems.Average(Selector);
        } //EndMethod
        
        public double? ArrayMethodAverageRewritten()
        {
            return ArrayItems.Average(Selector);
        } //EndMethod
        
        
        [NoRewrite]
        public double EnumerableAverage()
        {
            return EnumerableItems.Average();
        } //EndMethod
        
        public double EnumerableAverageRewritten()
        {
            return EnumerableItems.Average();
        } //EndMethod
        
        
        [NoRewrite]
        public double? ArrayMethodAverageChangingParam()
        {
            var a = 5;
            return ArrayItems.Average(x => x + a++);
        } //EndMethod
        
        public double? ArrayMethodAverageChangingParamRewritten()
        {
            var a = 5;
            return ArrayItems.Average(x => x + a++);
        } //EndMethod

    }
}