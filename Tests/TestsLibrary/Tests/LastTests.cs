using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class LastTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int value) => value > 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(Last), Last, LastRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableLast), EnumerableLast, EnumerableLastRewritten);
            TestsExtensions.TestEquals(nameof(LastCondition), LastCondition, LastConditionRewritten);
            TestsExtensions.TestEquals(nameof(LastFalseCondition), LastFalseCondition, LastFalseConditionRewritten);
            TestsExtensions.TestEquals(nameof(LastMethod), LastMethod, LastMethodRewritten);
            TestsExtensions.TestEquals(nameof(LastWhereMethod), LastWhereMethod, LastWhereMethodRewritten);
            TestsExtensions.TestEquals(nameof(SelectLastMethod), SelectLastMethod, SelectLastMethodRewritten);
            TestsExtensions.TestEquals(nameof(RangeLast), RangeLast, RangeLastRewritten);
            TestsExtensions.TestEquals(nameof(Range1Last), Range1Last, Range1LastRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
            TestsExtensions.TestEquals(nameof(EmptyLast), EmptyLast, EmptyLastRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctLast), ArrayDistinctLast, ArrayDistinctLastRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastParam), ArrayLastParam, ArrayLastParamRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastChangingParam), ArrayLastChangingParam, ArrayLastChangingParamRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastUsingLast), ArrayLastUsingLast, ArrayLastUsingLastRewritten);
        }

        public int Last()
        {
            return ArrayItems.Last();
        } //EndMethod

        [LinqRewrite]
		public int LastRewritten()
        {
            return ArrayItems.Last();
        } //EndMethod


        public int EnumerableLast()
        {
            return EnumerableItems.Last();
        } //EndMethod

        [LinqRewrite]
		public int EnumerableLastRewritten()
        {
            return EnumerableItems.Last();
        } //EndMethod


        public int LastCondition()
        {
            return ArrayItems.Last(x => x > 30);
        } //EndMethod

        [LinqRewrite]
		public int LastConditionRewritten()
        {
            return ArrayItems.Last(x => x > 30);
        } //EndMethod


        public int LastFalseCondition()
        {
            return ArrayItems.Last(x => x > 105);
        } //EndMethod

        [LinqRewrite]
		public int LastFalseConditionRewritten()
        {
            return ArrayItems.Last(x => x > 105);
        } //EndMethod


        public int LastMethod()
        {
            return ArrayItems.Last(Predicate);
        } //EndMethod

        [LinqRewrite]
		public int LastMethodRewritten()
        {
            return ArrayItems.Last(Predicate);
        } //EndMethod


        public int LastWhereMethod()
        {
            return ArrayItems.Where(x => x > 10).Last();
        } //EndMethod

        [LinqRewrite]
		public int LastWhereMethodRewritten()
        {
            return ArrayItems.Where(x => x > 10).Last();
        } //EndMethod


        public int SelectLastMethod()
        {
            return ArrayItems.Select(x => x + 10).Last();
        } //EndMethod

        [LinqRewrite]
		public int SelectLastMethodRewritten()
        {
            return ArrayItems.Select(x => x + 10).Last();
        } //EndMethod


        public int RangeLast()
        {
            return Enumerable.Range(0, 100).Last();
        } //EndMethod

        [LinqRewrite]
		public int RangeLastRewritten()
        {
            return Enumerable.Range(0, 100).Last();
        } //EndMethod


        public int Range1Last()
        {
            return Enumerable.Range(0, 1).Last();
        } //EndMethod

        [LinqRewrite]
		public int Range1LastRewritten()
        {
            return Enumerable.Range(0, 1).Last();
        } //EndMethod


        public int RangeRepeat()
        {
            return Enumerable.Repeat(0, 100).Last();
        } //EndMethod

        [LinqRewrite]
		public int RangeRepeatRewritten()
        {
            return Enumerable.Repeat(0, 100).Last();
        } //EndMethod


        public int EmptyLast()
        {
            return Enumerable.Empty<int>().Last();
        } //EndMethod

        [LinqRewrite]
		public int EmptyLastRewritten()
        {
            return Enumerable.Empty<int>().Last();
        } //EndMethod


        public int ArrayDistinctLast()
        {
            return ArrayItems.Distinct().Last();
        } //EndMethod

        [LinqRewrite]
		public int ArrayDistinctLastRewritten()
        {
            return ArrayItems.Distinct().Last();
        } //EndMethod


        public int ArrayLastParam()
        {
            var a = 50;
            return ArrayItems.Last(x => x > a);
        } //EndMethod

        [LinqRewrite]
		public int ArrayLastParamRewritten()
        {
            var a = 50;
            return ArrayItems.Last(x => x > a);
        } //EndMethod


        public int ArrayLastChangingParam()
        {
            var a = 100;
            return ArrayItems.Last(x => x > a--);
        } //EndMethod

        [LinqRewrite]
		public int ArrayLastChangingParamRewritten()
        {
            var a = 100;
            return ArrayItems.Last(x => x > a--);
        } //EndMethod


        public int ArrayLastUsingLast()
        {
            var a = 100;
            return ArrayItems.Last(x => x > ArrayItems.Last(y => y > x));
        } //EndMethod

        [LinqRewrite]
		public int ArrayLastUsingLastRewritten()
        {
            var a = 100;
            return ArrayItems.Last(x => x > ArrayItems.Last(y => y > x));
        } //EndMethod

    }
}