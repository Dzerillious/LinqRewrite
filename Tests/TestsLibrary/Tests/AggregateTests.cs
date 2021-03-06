﻿using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class AggregateTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 1000).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 1000);
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(AggregateSum), AggregateSum, AggregateSumRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableAggregateSum), EnumerableAggregateSum, EnumerableAggregateSumRewritten);
            TestsExtensions.TestEquals(nameof(AggregateCount), AggregateCount, AggregateCountRewritten);
            TestsExtensions.TestEquals(nameof(AggregateEma), AggregateEma, AggregateEmaRewritten);
            TestsExtensions.TestEquals(nameof(AggregateDoubleSum), AggregateDoubleSum, AggregateDoubleSumRewritten);
            TestsExtensions.TestEquals(nameof(AggregateDoubleEma), AggregateDoubleEma, AggregateDoubleEmaRewritten);
            TestsExtensions.TestEquals(nameof(AggregateDoubleFactorial), AggregateDoubleFactorial, AggregateDoubleFactorialRewritten);
            TestsExtensions.TestEquals(nameof(AggregateDoubleAverage), AggregateDoubleAverage, AggregateDoubleAverageRewritten);
            TestsExtensions.TestEquals(nameof(AggregateDoubleAverageSelected), AggregateDoubleAverageSelected, AggregateDoubleAverageSelectedRewritten);
            TestsExtensions.TestEquals(nameof(AggregateDoubleAverageWhere), AggregateDoubleAverageWhere, AggregateDoubleAverageWhereRewritten);
            TestsExtensions.TestEquals(nameof(AggregateRangeSum), AggregateRangeSum, AggregateRangeSumRewritten);
            TestsExtensions.TestEquals(nameof(AggregateRangeFactorial0), AggregateRangeFactorial0, AggregateRangeFactorial0Rewritten);
            TestsExtensions.TestEquals(nameof(AggregateRangeFactorial20), AggregateRangeFactorial20, AggregateRangeFactorial20Rewritten);
            TestsExtensions.TestEquals(nameof(AggregateRangeFactorial100), AggregateRangeFactorial100, AggregateRangeFactorial100Rewritten);
            TestsExtensions.TestEquals(nameof(AggregateEmpty), AggregateEmpty, AggregateEmptyRewritten);
            TestsExtensions.TestEquals(nameof(AggregateEmptyDefault), AggregateEmptyDefault, AggregateEmptyDefaultRewritten);
            TestsExtensions.TestEquals(nameof(AggregateNull), AggregateNull, AggregateNullRewritten);
        }
        
        public int AggregateSum()
        {
            return ArrayItems.Aggregate((x, y) => x + y);
        } //EndMethod
        
        [LinqRewrite]
		public int AggregateSumRewritten()
        {
            return ArrayItems.Aggregate((x, y) => x + y);
        } //EndMethod
        
        
        public int EnumerableAggregateSum()
        {
            return EnumerableItems.Aggregate((x, y) => x + y);
        } //EndMethod
        
        [LinqRewrite]
		public int EnumerableAggregateSumRewritten()
        {
            return EnumerableItems.Aggregate((x, y) => x + y);
        } //EndMethod
        
        
        public int AggregateCount()
        {
            return ArrayItems.Aggregate((x, y) => x + 1);
        } //EndMethod
        
        [LinqRewrite]
		public int AggregateCountRewritten()
        {
            return ArrayItems.Aggregate((x, y) => x + 1);
        } //EndMethod
        
        
        public int AggregateEma()
        {
            return ArrayItems.Aggregate((x, y) => (x + y) / 2);
        } //EndMethod
        
        [LinqRewrite]
		public int AggregateEmaRewritten()
        {
            return ArrayItems.Aggregate((x, y) => (x + y) / 2);
        } //EndMethod
        
        
        public double AggregateDoubleSum()
        {
            return ArrayItems.Aggregate(0.0, (x, y) => x + y);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateDoubleSumRewritten()
        {
            return ArrayItems.Aggregate(0.0, (x, y) => x + y);
        } //EndMethod
        
        
        public double AggregateDoubleEma()
        {
            return ArrayItems.Aggregate(0.0, (x, y) => (x + y) / 2);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateDoubleEmaRewritten()
        {
            return ArrayItems.Aggregate(0.0, (x, y) => (x + y) / 2);
        } //EndMethod
        
        
        public double AggregateDoubleFactorial()
        {
            return ArrayItems.Aggregate(1.0, (x, y) => x * y);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateDoubleFactorialRewritten()
        {
            return ArrayItems.Aggregate(1.0, (x, y) => x * y);
        } //EndMethod
        
        
        public double AggregateDoubleAverage()
        {
            return ArrayItems.Aggregate(0.0, (x, y) => x + y, x => x / ArrayItems.Length);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateDoubleAverageRewritten()
        {
            return ArrayItems.Aggregate(0.0, (x, y) => x + y, x => x / ArrayItems.Length);
        } //EndMethod
        
        
        public double AggregateDoubleAverageSelected()
        {
            return ArrayItems.Select(x => x + 5).Aggregate(0.0, (x, y) => x + y, x => x / ArrayItems.Length);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateDoubleAverageSelectedRewritten()
        {
            return ArrayItems.Select(x => x + 5).Aggregate(0.0, (x, y) => x + y, x => x / ArrayItems.Length);
        } //EndMethod
        
        
        public double AggregateDoubleAverageWhere()
        {
            return ArrayItems.Where(x => x % 2 == 0).Aggregate(0.0, (x, y) => x + y, x => x / ArrayItems.Length);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateDoubleAverageWhereRewritten()
        {
            return ArrayItems.Where(x => x % 2 == 0).Aggregate(0.0, (x, y) => x + y, x => x / ArrayItems.Length);
        } //EndMethod
        
        
        public int AggregateRangeSum()
        {
            return Enumerable.Range(0, 100).Aggregate((x, y) => x + y);
        } //EndMethod
        
        [LinqRewrite]
		public int AggregateRangeSumRewritten()
        {
            return Enumerable.Range(0, 100).Aggregate((x, y) => x + y);
        } //EndMethod
        
        
        public double AggregateRangeFactorial0()
        {
            return Enumerable.Range(0, 100).Aggregate(1.0, (x, y) => x * y);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateRangeFactorial0Rewritten()
        {
            return Enumerable.Range(0, 100).Aggregate(1.0, (x, y) => x * y);
        } //EndMethod
        
        
        public double AggregateRangeFactorial20()
        {
            return Enumerable.Range(1, 20).Aggregate(1.0, (x, y) => x * y);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateRangeFactorial20Rewritten()
        {
            return Enumerable.Range(1, 20).Aggregate(1.0, (x, y) => x * y);
        } //EndMethod
        
        
        public double AggregateRangeFactorial100()
        {
            return Enumerable.Range(1, 100).Aggregate(1.0, (x, y) => x * y);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateRangeFactorial100Rewritten()
        {
            return Enumerable.Range(1, 100).Aggregate(1.0, (x, y) => x * y);
        } //EndMethod
        
        
        public double AggregateEmptyDefault()
        {
            return ArrayItems.Where(x => false).Aggregate(1.0, (x, y) => x + y);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateEmptyDefaultRewritten()
        {
            return ArrayItems.Where(x => false).Aggregate(1.0, (x, y) => x + y);
        } //EndMethod
        
        
        public double AggregateEmpty()
        {
            return ArrayItems.Where(x => false).Aggregate((x, y) => x + y);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateEmptyRewritten()
        {
            return ArrayItems.Where(x => false).Aggregate((x, y) => x + y);
        } //EndMethod
        
        
        public double AggregateNull()
        {
            return ArrayItems.Aggregate(null);
        } //EndMethod
        
        [LinqRewrite]
		public double AggregateNullRewritten()
        {
            return ArrayItems.Aggregate(null);
        } //EndMethod
    }
}