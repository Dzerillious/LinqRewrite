using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class SingleTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int value) => value > 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(Single), Single, SingleRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSingle), EnumerableSingle, EnumerableSingleRewritten);
            TestsExtensions.TestEquals(nameof(SingleCondition), SingleCondition, SingleConditionRewritten);
            TestsExtensions.TestEquals(nameof(SingleFalseCondition), SingleFalseCondition, SingleFalseConditionRewritten);
            TestsExtensions.TestEquals(nameof(SingleMethod), SingleMethod, SingleMethodRewritten);
            TestsExtensions.TestEquals(nameof(SingleWhereMethod), SingleWhereMethod, SingleWhereMethodRewritten);
            TestsExtensions.TestEquals(nameof(SelectSingleMethod), SelectSingleMethod, SelectSingleMethodRewritten);
            TestsExtensions.TestEquals(nameof(RangeSingle), RangeSingle, RangeSingleRewritten);
            TestsExtensions.TestEquals(nameof(Range1Single), Range1Single, Range1SingleRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
            TestsExtensions.TestEquals(nameof(EmptySingle), EmptySingle, EmptySingleRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctSingle), ArrayDistinctSingle, ArrayDistinctSingleRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleParam), ArraySingleParam, ArraySingleParamRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleChangingParam), ArraySingleChangingParam, ArraySingleChangingParamRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleUsingSingle), ArraySingleUsingSingle, ArraySingleUsingSingleRewritten);
        }

        public int Single()
        {
            return ArrayItems.Single();
        } //EndMethod

        [LinqRewrite]
		public int SingleRewritten()
        {
            return ArrayItems.Single();
        } //EndMethod


        public int EnumerableSingle()
        {
            return EnumerableItems.Single();
        } //EndMethod

        [LinqRewrite]
		public int EnumerableSingleRewritten()
        {
            return EnumerableItems.Single();
        } //EndMethod


        public int SingleCondition()
        {
            return ArrayItems.Single(x => x > 30);
        } //EndMethod

        [LinqRewrite]
		public int SingleConditionRewritten()
        {
            return ArrayItems.Single(x => x > 30);
        } //EndMethod


        public int SingleFalseCondition()
        {
            return ArrayItems.Single(x => x > 105);
        } //EndMethod

        [LinqRewrite]
		public int SingleFalseConditionRewritten()
        {
            return ArrayItems.Single(x => x > 105);
        } //EndMethod


        public int SingleMethod()
        {
            return ArrayItems.Single(Predicate);
        } //EndMethod

        [LinqRewrite]
		public int SingleMethodRewritten()
        {
            return ArrayItems.Single(Predicate);
        } //EndMethod


        public int SingleWhereMethod()
        {
            return ArrayItems.Where(x => x > 10).Single();
        } //EndMethod

        [LinqRewrite]
		public int SingleWhereMethodRewritten()
        {
            return ArrayItems.Where(x => x > 10).Single();
        } //EndMethod


        public int SelectSingleMethod()
        {
            return ArrayItems.Select(x => x + 10).Single();
        } //EndMethod

        [LinqRewrite]
		public int SelectSingleMethodRewritten()
        {
            return ArrayItems.Select(x => x + 10).Single();
        } //EndMethod


        public int RangeSingle()
        {
            return Enumerable.Range(0, 100).Single();
        } //EndMethod

        [LinqRewrite]
		public int RangeSingleRewritten()
        {
            return Enumerable.Range(0, 100).Single();
        } //EndMethod


        public int Range1Single()
        {
            return Enumerable.Range(0, 1).Single();
        } //EndMethod

        [LinqRewrite]
		public int Range1SingleRewritten()
        {
            return Enumerable.Range(0, 1).Single();
        } //EndMethod


        public int RangeRepeat()
        {
            return Enumerable.Repeat(0, 100).Single();
        } //EndMethod

        [LinqRewrite]
		public int RangeRepeatRewritten()
        {
            return Enumerable.Repeat(0, 100).Single();
        } //EndMethod


        public int EmptySingle()
        {
            return Enumerable.Empty<int>().Single();
        } //EndMethod

        [LinqRewrite]
		public int EmptySingleRewritten()
        {
            return Enumerable.Empty<int>().Single();
        } //EndMethod


        public int ArrayDistinctSingle()
        {
            return ArrayItems.Distinct().Single();
        } //EndMethod

        [LinqRewrite]
		public int ArrayDistinctSingleRewritten()
        {
            return ArrayItems.Distinct().Single();
        } //EndMethod


        public int ArraySingleParam()
        {
            var a = 50;
            return ArrayItems.Single(x => x > a);
        } //EndMethod

        [LinqRewrite]
		public int ArraySingleParamRewritten()
        {
            var a = 50;
            return ArrayItems.Single(x => x > a);
        } //EndMethod


        public int ArraySingleChangingParam()
        {
            var a = 100;
            return ArrayItems.Single(x => x > a--);
        } //EndMethod

        [LinqRewrite]
		public int ArraySingleChangingParamRewritten()
        {
            var a = 100;
            return ArrayItems.Single(x => x > a--);
        } //EndMethod


        public int ArraySingleUsingSingle()
        {
            var a = 100;
            return ArrayItems.Single(x => x > ArrayItems.Single(y => y > x));
        } //EndMethod

        [LinqRewrite]
		public int ArraySingleUsingSingleRewritten()
        {
            var a = 100;
            return ArrayItems.Single(x => x > ArrayItems.Single(y => y > x));
        } //EndMethod

    }
}