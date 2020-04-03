using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class FirstTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int value) => value > 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(First), First, FirstRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableFirst), EnumerableFirst, EnumerableFirstRewritten);
            TestsExtensions.TestEquals(nameof(FirstCondition), FirstCondition, FirstConditionRewritten);
            TestsExtensions.TestEquals(nameof(FirstFalseCondition), FirstFalseCondition, FirstFalseConditionRewritten);
            TestsExtensions.TestEquals(nameof(FirstMethod), FirstMethod, FirstMethodRewritten);
            TestsExtensions.TestEquals(nameof(FirstWhereMethod), FirstWhereMethod, FirstWhereMethodRewritten);
            TestsExtensions.TestEquals(nameof(SelectFirstMethod), SelectFirstMethod, SelectFirstMethodRewritten);
            TestsExtensions.TestEquals(nameof(RangeFirst), RangeFirst, RangeFirstRewritten);
            TestsExtensions.TestEquals(nameof(Range1First), Range1First, Range1FirstRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
            TestsExtensions.TestEquals(nameof(EmptyFirst), EmptyFirst, EmptyFirstRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctFirst), ArrayDistinctFirst, ArrayDistinctFirstRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstParam), ArrayFirstParam, ArrayFirstParamRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstChangingParam), ArrayFirstChangingParam, ArrayFirstChangingParamRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstUsingFirst), ArrayFirstUsingFirst, ArrayFirstUsingFirstRewritten);
        }

        [NoRewrite]
        public int First()
        {
            return ArrayItems.First();
        } //EndMethod

        public int FirstRewritten()
        {
            return ArrayItems.First();
        } //EndMethod


        [NoRewrite]
        public int EnumerableFirst()
        {
            return EnumerableItems.First();
        } //EndMethod

        public int EnumerableFirstRewritten()
        {
            return EnumerableItems.First();
        } //EndMethod


        [NoRewrite]
        public int FirstCondition()
        {
            return ArrayItems.First(x => x > 30);
        } //EndMethod

        public int FirstConditionRewritten()
        {
            return ArrayItems.First(x => x > 30);
        } //EndMethod


        [NoRewrite]
        public int FirstFalseCondition()
        {
            return ArrayItems.First(x => x > 105);
        } //EndMethod

        public int FirstFalseConditionRewritten()
        {
            return ArrayItems.First(x => x > 105);
        } //EndMethod


        [NoRewrite]
        public int FirstMethod()
        {
            return ArrayItems.First(Predicate);
        } //EndMethod

        public int FirstMethodRewritten()
        {
            return ArrayItems.First(Predicate);
        } //EndMethod


        [NoRewrite]
        public int FirstWhereMethod()
        {
            return ArrayItems.Where(x => x > 10).First();
        } //EndMethod

        public int FirstWhereMethodRewritten()
        {
            return ArrayItems.Where(x => x > 10).First();
        } //EndMethod


        [NoRewrite]
        public int SelectFirstMethod()
        {
            return ArrayItems.Select(x => x + 10).First();
        } //EndMethod

        public int SelectFirstMethodRewritten()
        {
            return ArrayItems.Select(x => x + 10).First();
        } //EndMethod


        [NoRewrite]
        public int RangeFirst()
        {
            return Enumerable.Range(0, 100).First();
        } //EndMethod

        public int RangeFirstRewritten()
        {
            return Enumerable.Range(0, 100).First();
        } //EndMethod


        [NoRewrite]
        public int Range1First()
        {
            return Enumerable.Range(0, 1).First();
        } //EndMethod

        public int Range1FirstRewritten()
        {
            return Enumerable.Range(0, 1).First();
        } //EndMethod


        [NoRewrite]
        public int RangeRepeat()
        {
            return Enumerable.Repeat(0, 100).First();
        } //EndMethod

        public int RangeRepeatRewritten()
        {
            return Enumerable.Repeat(0, 100).First();
        } //EndMethod


        [NoRewrite]
        public int EmptyFirst()
        {
            return Enumerable.Empty<int>().First();
        } //EndMethod

        public int EmptyFirstRewritten()
        {
            return Enumerable.Empty<int>().First();
        } //EndMethod


        [NoRewrite]
        public int ArrayDistinctFirst()
        {
            return ArrayItems.Distinct().First();
        } //EndMethod

        public int ArrayDistinctFirstRewritten()
        {
            return ArrayItems.Distinct().First();
        } //EndMethod


        [NoRewrite]
        public int ArrayFirstParam()
        {
            var a = 50;
            return ArrayItems.First(x => x > a);
        } //EndMethod

        public int ArrayFirstParamRewritten()
        {
            var a = 50;
            return ArrayItems.First(x => x > a);
        } //EndMethod


        [NoRewrite]
        public int ArrayFirstChangingParam()
        {
            var a = 100;
            return ArrayItems.First(x => x > a--);
        } //EndMethod

        public int ArrayFirstChangingParamRewritten()
        {
            var a = 100;
            return ArrayItems.First(x => x > a--);
        } //EndMethod


        [NoRewrite]
        public int ArrayFirstUsingFirst()
        {
            var a = 100;
            return ArrayItems.First(x => x > ArrayItems.First(y => y > x));
        } //EndMethod

        public int ArrayFirstUsingFirstRewritten()
        {
            var a = 100;
            return ArrayItems.First(x => x > ArrayItems.First(y => y > x));
        } //EndMethod

    }
}