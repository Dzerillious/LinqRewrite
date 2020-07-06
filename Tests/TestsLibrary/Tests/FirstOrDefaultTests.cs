using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class FirstOrDefaultTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int value) => value > 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(FirstOrDefault), FirstOrDefault, FirstOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableFirstOrDefault), EnumerableFirstOrDefault, EnumerableFirstOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(FirstOrDefaultCondition), FirstOrDefaultCondition, FirstOrDefaultConditionRewritten);
            TestsExtensions.TestEquals(nameof(FirstOrDefaultFalseCondition), FirstOrDefaultFalseCondition, FirstOrDefaultFalseConditionRewritten);
            TestsExtensions.TestEquals(nameof(FirstOrDefaultMethod), FirstOrDefaultMethod, FirstOrDefaultMethodRewritten);
            TestsExtensions.TestEquals(nameof(FirstOrDefaultWhereMethod), FirstOrDefaultWhereMethod, FirstOrDefaultWhereMethodRewritten);
            TestsExtensions.TestEquals(nameof(SelectFirstOrDefaultMethod), SelectFirstOrDefaultMethod, SelectFirstOrDefaultMethodRewritten);
            TestsExtensions.TestEquals(nameof(RangeFirstOrDefault), RangeFirstOrDefault, RangeFirstOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(Range1FirstOrDefault), Range1FirstOrDefault, Range1FirstOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
            TestsExtensions.TestEquals(nameof(EmptyFirstOrDefault), EmptyFirstOrDefault, EmptyFirstOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctFirstOrDefault), ArrayDistinctFirstOrDefault, ArrayDistinctFirstOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstOrDefaultParam), ArrayFirstOrDefaultParam, ArrayFirstOrDefaultParamRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstOrDefaultChangingParam), ArrayFirstOrDefaultChangingParam, ArrayFirstOrDefaultChangingParamRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstOrDefaultUsingFirstOrDefault), ArrayFirstOrDefaultUsingFirstOrDefault, ArrayFirstOrDefaultUsingFirstOrDefaultRewritten);
        }

        public int FirstOrDefault()
        {
            return ArrayItems.FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int FirstOrDefaultRewritten()
        {
            return ArrayItems.FirstOrDefault();
        } //EndMethod


        public int EnumerableFirstOrDefault()
        {
            return EnumerableItems.FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int EnumerableFirstOrDefaultRewritten()
        {
            return EnumerableItems.FirstOrDefault();
        } //EndMethod


        public int FirstOrDefaultCondition()
        {
            return ArrayItems.FirstOrDefault(x => x > 30);
        } //EndMethod

        [LinqRewrite]
		public int FirstOrDefaultConditionRewritten()
        {
            return ArrayItems.FirstOrDefault(x => x > 30);
        } //EndMethod


        public int FirstOrDefaultFalseCondition()
        {
            return ArrayItems.FirstOrDefault(x => x > 105);
        } //EndMethod

        [LinqRewrite]
		public int FirstOrDefaultFalseConditionRewritten()
        {
            return ArrayItems.FirstOrDefault(x => x > 105);
        } //EndMethod


        public int FirstOrDefaultMethod()
        {
            return ArrayItems.FirstOrDefault(Predicate);
        } //EndMethod

        [LinqRewrite]
		public int FirstOrDefaultMethodRewritten()
        {
            return ArrayItems.FirstOrDefault(Predicate);
        } //EndMethod


        public int FirstOrDefaultWhereMethod()
        {
            return ArrayItems.Where(x => x > 10).FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int FirstOrDefaultWhereMethodRewritten()
        {
            return ArrayItems.Where(x => x > 10).FirstOrDefault();
        } //EndMethod


        public int SelectFirstOrDefaultMethod()
        {
            return ArrayItems.Select(x => x + 10).FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int SelectFirstOrDefaultMethodRewritten()
        {
            return ArrayItems.Select(x => x + 10).FirstOrDefault();
        } //EndMethod


        public int RangeFirstOrDefault()
        {
            return Enumerable.Range(0, 100).FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int RangeFirstOrDefaultRewritten()
        {
            return Enumerable.Range(0, 100).FirstOrDefault();
        } //EndMethod


        public int Range1FirstOrDefault()
        {
            return Enumerable.Range(0, 1).FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int Range1FirstOrDefaultRewritten()
        {
            return Enumerable.Range(0, 1).FirstOrDefault();
        } //EndMethod


        public int RangeRepeat()
        {
            return Enumerable.Repeat(0, 100).FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int RangeRepeatRewritten()
        {
            return Enumerable.Repeat(0, 100).FirstOrDefault();
        } //EndMethod


        public int EmptyFirstOrDefault()
        {
            return Enumerable.Empty<int>().FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int EmptyFirstOrDefaultRewritten()
        {
            return Enumerable.Empty<int>().FirstOrDefault();
        } //EndMethod


        public int ArrayDistinctFirstOrDefault()
        {
            return ArrayItems.Distinct().FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int ArrayDistinctFirstOrDefaultRewritten()
        {
            return ArrayItems.Distinct().FirstOrDefault();
        } //EndMethod


        public int ArrayFirstOrDefaultParam()
        {
            var a = 50;
            return ArrayItems.FirstOrDefault(x => x > a);
        } //EndMethod

        [LinqRewrite]
		public int ArrayFirstOrDefaultParamRewritten()
        {
            var a = 50;
            return ArrayItems.FirstOrDefault(x => x > a);
        } //EndMethod


        public int ArrayFirstOrDefaultChangingParam()
        {
            var a = 100;
            return ArrayItems.FirstOrDefault(x => x > a--);
        } //EndMethod

        [LinqRewrite]
		public int ArrayFirstOrDefaultChangingParamRewritten()
        {
            var a = 100;
            return ArrayItems.FirstOrDefault(x => x > a--);
        } //EndMethod


        public int ArrayFirstOrDefaultUsingFirstOrDefault()
        {
            var a = 100;
            return ArrayItems.FirstOrDefault(x => x > ArrayItems.FirstOrDefault(y => y > x));
        } //EndMethod

        [LinqRewrite]
		public int ArrayFirstOrDefaultUsingFirstOrDefaultRewritten()
        {
            var a = 100;
            return ArrayItems.FirstOrDefault(x => x > ArrayItems.FirstOrDefault(y => y > x));
        } //EndMethod

    }
}