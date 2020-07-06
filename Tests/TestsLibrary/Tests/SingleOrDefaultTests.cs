using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class SingleOrDefaultTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int value) => value > 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(SingleOrDefault), SingleOrDefault, SingleOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSingleOrDefault), EnumerableSingleOrDefault, EnumerableSingleOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(SingleOrDefaultCondition), SingleOrDefaultCondition, SingleOrDefaultConditionRewritten);
            TestsExtensions.TestEquals(nameof(SingleOrDefaultFalseCondition), SingleOrDefaultFalseCondition, SingleOrDefaultFalseConditionRewritten);
            TestsExtensions.TestEquals(nameof(SingleOrDefaultMethod), SingleOrDefaultMethod, SingleOrDefaultMethodRewritten);
            TestsExtensions.TestEquals(nameof(SingleOrDefaultWhereMethod), SingleOrDefaultWhereMethod, SingleOrDefaultWhereMethodRewritten);
            TestsExtensions.TestEquals(nameof(SelectSingleOrDefaultMethod), SelectSingleOrDefaultMethod, SelectSingleOrDefaultMethodRewritten);
            TestsExtensions.TestEquals(nameof(RangeSingleOrDefault), RangeSingleOrDefault, RangeSingleOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(Range1SingleOrDefault), Range1SingleOrDefault, Range1SingleOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
            TestsExtensions.TestEquals(nameof(EmptySingleOrDefault), EmptySingleOrDefault, EmptySingleOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctSingleOrDefault), ArrayDistinctSingleOrDefault, ArrayDistinctSingleOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleOrDefaultParam), ArraySingleOrDefaultParam, ArraySingleOrDefaultParamRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleOrDefaultChangingParam), ArraySingleOrDefaultChangingParam, ArraySingleOrDefaultChangingParamRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleOrDefaultUsingSingleOrDefault), ArraySingleOrDefaultUsingSingleOrDefault, ArraySingleOrDefaultUsingSingleOrDefaultRewritten);
        }

        public int SingleOrDefault()
        {
            return ArrayItems.SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int SingleOrDefaultRewritten()
        {
            return ArrayItems.SingleOrDefault();
        } //EndMethod


        public int EnumerableSingleOrDefault()
        {
            return EnumerableItems.SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int EnumerableSingleOrDefaultRewritten()
        {
            return EnumerableItems.SingleOrDefault();
        } //EndMethod


        public int SingleOrDefaultCondition()
        {
            return ArrayItems.SingleOrDefault(x => x > 30);
        } //EndMethod

        [LinqRewrite]
		public int SingleOrDefaultConditionRewritten()
        {
            return ArrayItems.SingleOrDefault(x => x > 30);
        } //EndMethod


        public int SingleOrDefaultFalseCondition()
        {
            return ArrayItems.SingleOrDefault(x => x > 105);
        } //EndMethod

        [LinqRewrite]
		public int SingleOrDefaultFalseConditionRewritten()
        {
            return ArrayItems.SingleOrDefault(x => x > 105);
        } //EndMethod


        public int SingleOrDefaultMethod()
        {
            return ArrayItems.SingleOrDefault(Predicate);
        } //EndMethod

        [LinqRewrite]
		public int SingleOrDefaultMethodRewritten()
        {
            return ArrayItems.SingleOrDefault(Predicate);
        } //EndMethod


        public int SingleOrDefaultWhereMethod()
        {
            return ArrayItems.Where(x => x > 10).SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int SingleOrDefaultWhereMethodRewritten()
        {
            return ArrayItems.Where(x => x > 10).SingleOrDefault();
        } //EndMethod


        public int SelectSingleOrDefaultMethod()
        {
            return ArrayItems.Select(x => x + 10).SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int SelectSingleOrDefaultMethodRewritten()
        {
            return ArrayItems.Select(x => x + 10).SingleOrDefault();
        } //EndMethod


        public int RangeSingleOrDefault()
        {
            return Enumerable.Range(0, 100).SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int RangeSingleOrDefaultRewritten()
        {
            return Enumerable.Range(0, 100).SingleOrDefault();
        } //EndMethod


        public int Range1SingleOrDefault()
        {
            return Enumerable.Range(0, 1).SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int Range1SingleOrDefaultRewritten()
        {
            return Enumerable.Range(0, 1).SingleOrDefault();
        } //EndMethod


        public int RangeRepeat()
        {
            return Enumerable.Repeat(0, 100).SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int RangeRepeatRewritten()
        {
            return Enumerable.Repeat(0, 100).SingleOrDefault();
        } //EndMethod


        public int EmptySingleOrDefault()
        {
            return Enumerable.Empty<int>().SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int EmptySingleOrDefaultRewritten()
        {
            return Enumerable.Empty<int>().SingleOrDefault();
        } //EndMethod


        public int ArrayDistinctSingleOrDefault()
        {
            return ArrayItems.Distinct().SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int ArrayDistinctSingleOrDefaultRewritten()
        {
            return ArrayItems.Distinct().SingleOrDefault();
        } //EndMethod


        public int ArraySingleOrDefaultParam()
        {
            var a = 50;
            return ArrayItems.SingleOrDefault(x => x > a);
        } //EndMethod

        [LinqRewrite]
		public int ArraySingleOrDefaultParamRewritten()
        {
            var a = 50;
            return ArrayItems.SingleOrDefault(x => x > a);
        } //EndMethod


        public int ArraySingleOrDefaultChangingParam()
        {
            var a = 100;
            return ArrayItems.SingleOrDefault(x => x > a--);
        } //EndMethod

        [LinqRewrite]
		public int ArraySingleOrDefaultChangingParamRewritten()
        {
            var a = 100;
            return ArrayItems.SingleOrDefault(x => x > a--);
        } //EndMethod


        public int ArraySingleOrDefaultUsingSingleOrDefault()
        {
            var a = 100;
            return ArrayItems.SingleOrDefault(x => x > ArrayItems.SingleOrDefault(y => y > x));
        } //EndMethod

        [LinqRewrite]
		public int ArraySingleOrDefaultUsingSingleOrDefaultRewritten()
        {
            var a = 100;
            return ArrayItems.SingleOrDefault(x => x > ArrayItems.SingleOrDefault(y => y > x));
        } //EndMethod

    }
}