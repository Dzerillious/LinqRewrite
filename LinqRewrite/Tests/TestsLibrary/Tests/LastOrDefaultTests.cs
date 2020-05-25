using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class LastOrDefaultTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int value) => value > 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(LastOrDefault), LastOrDefault, LastOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableLastOrDefault), EnumerableLastOrDefault, EnumerableLastOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(LastOrDefaultCondition), LastOrDefaultCondition, LastOrDefaultConditionRewritten);
            TestsExtensions.TestEquals(nameof(LastOrDefaultFalseCondition), LastOrDefaultFalseCondition, LastOrDefaultFalseConditionRewritten);
            TestsExtensions.TestEquals(nameof(LastOrDefaultMethod), LastOrDefaultMethod, LastOrDefaultMethodRewritten);
            TestsExtensions.TestEquals(nameof(LastOrDefaultWhereMethod), LastOrDefaultWhereMethod, LastOrDefaultWhereMethodRewritten);
            TestsExtensions.TestEquals(nameof(SelectLastOrDefaultMethod), SelectLastOrDefaultMethod, SelectLastOrDefaultMethodRewritten);
            TestsExtensions.TestEquals(nameof(RangeLastOrDefault), RangeLastOrDefault, RangeLastOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(Range1LastOrDefault), Range1LastOrDefault, Range1LastOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
            TestsExtensions.TestEquals(nameof(EmptyLastOrDefault), EmptyLastOrDefault, EmptyLastOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctLastOrDefault), ArrayDistinctLastOrDefault, ArrayDistinctLastOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultParam), ArrayLastOrDefaultParam, ArrayLastOrDefaultParamRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultChangingParam), ArrayLastOrDefaultChangingParam, ArrayLastOrDefaultChangingParamRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultUsingLastOrDefault), ArrayLastOrDefaultUsingLastOrDefault, ArrayLastOrDefaultUsingLastOrDefaultRewritten);
        }

        [NoRewrite]
        public int LastOrDefault()
        {
            return ArrayItems.LastOrDefault();
        } //EndMethod

        public int LastOrDefaultRewritten()
        {
            return ArrayItems.LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int EnumerableLastOrDefault()
        {
            return EnumerableItems.LastOrDefault();
        } //EndMethod

        public int EnumerableLastOrDefaultRewritten()
        {
            return EnumerableItems.LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int LastOrDefaultCondition()
        {
            return ArrayItems.LastOrDefault(x => x > 30);
        } //EndMethod

        public int LastOrDefaultConditionRewritten()
        {
            return ArrayItems.LastOrDefault(x => x > 30);
        } //EndMethod


        [NoRewrite]
        public int LastOrDefaultFalseCondition()
        {
            return ArrayItems.LastOrDefault(x => x > 105);
        } //EndMethod

        public int LastOrDefaultFalseConditionRewritten()
        {
            return ArrayItems.LastOrDefault(x => x > 105);
        } //EndMethod


        [NoRewrite]
        public int LastOrDefaultMethod()
        {
            return ArrayItems.LastOrDefault(Predicate);
        } //EndMethod

        public int LastOrDefaultMethodRewritten()
        {
            return ArrayItems.LastOrDefault(Predicate);
        } //EndMethod


        [NoRewrite]
        public int LastOrDefaultWhereMethod()
        {
            return ArrayItems.Where(x => x > 10).LastOrDefault();
        } //EndMethod

        public int LastOrDefaultWhereMethodRewritten()
        {
            return ArrayItems.Where(x => x > 10).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int SelectLastOrDefaultMethod()
        {
            return ArrayItems.Select(x => x + 10).LastOrDefault();
        } //EndMethod

        public int SelectLastOrDefaultMethodRewritten()
        {
            return ArrayItems.Select(x => x + 10).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int RangeLastOrDefault()
        {
            return Enumerable.Range(0, 100).LastOrDefault();
        } //EndMethod

        public int RangeLastOrDefaultRewritten()
        {
            return Enumerable.Range(0, 100).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int Range1LastOrDefault()
        {
            return Enumerable.Range(0, 1).LastOrDefault();
        } //EndMethod

        public int Range1LastOrDefaultRewritten()
        {
            return Enumerable.Range(0, 1).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int RangeRepeat()
        {
            return Enumerable.Repeat(0, 100).LastOrDefault();
        } //EndMethod

        public int RangeRepeatRewritten()
        {
            return Enumerable.Repeat(0, 100).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int EmptyLastOrDefault()
        {
            return Enumerable.Empty<int>().LastOrDefault();
        } //EndMethod

        public int EmptyLastOrDefaultRewritten()
        {
            return Enumerable.Empty<int>().LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayDistinctLastOrDefault()
        {
            return ArrayItems.Distinct().LastOrDefault();
        } //EndMethod

        public int ArrayDistinctLastOrDefaultRewritten()
        {
            return ArrayItems.Distinct().LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayLastOrDefaultParam()
        {
            var a = 50;
            return ArrayItems.LastOrDefault(x => x > a);
        } //EndMethod

        public int ArrayLastOrDefaultParamRewritten()
        {
            var a = 50;
            return ArrayItems.LastOrDefault(x => x > a);
        } //EndMethod


        [NoRewrite]
        public int ArrayLastOrDefaultChangingParam()
        {
            var a = 100;
            return ArrayItems.LastOrDefault(x => x > a--);
        } //EndMethod

        public int ArrayLastOrDefaultChangingParamRewritten()
        {
            var a = 100;
            return ArrayItems.LastOrDefault(x => x > a--);
        } //EndMethod


        [NoRewrite]
        public int ArrayLastOrDefaultUsingLastOrDefault()
        {
            var a = 100;
            return ArrayItems.LastOrDefault(x => x > ArrayItems.LastOrDefault(y => y > x));
        } //EndMethod

        public int ArrayLastOrDefaultUsingLastOrDefaultRewritten()
        {
            var a = 100;
            return ArrayItems.LastOrDefault(x => x > ArrayItems.LastOrDefault(y => y > x));
        } //EndMethod

    }
}