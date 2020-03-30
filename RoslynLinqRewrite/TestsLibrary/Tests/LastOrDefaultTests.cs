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
            TestsExtensions.TestEquals(nameof(LastOrDefaultTest), LastOrDefaultTest, LastOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableLastOrDefaultTest), EnumerableLastOrDefaultTest, EnumerableLastOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(LastOrDefaultConditionTest), LastOrDefaultConditionTest, LastOrDefaultConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(LastOrDefaultFalseConditionTest), LastOrDefaultFalseConditionTest, LastOrDefaultFalseConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(LastOrDefaultMethodTest), LastOrDefaultMethodTest, LastOrDefaultMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(LastOrDefaultWhereMethodTest), LastOrDefaultWhereMethodTest, LastOrDefaultWhereMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(SelectLastOrDefaultMethodTest), SelectLastOrDefaultMethodTest, SelectLastOrDefaultMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeLastOrDefaultTest), RangeLastOrDefaultTest, RangeLastOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(Range1LastOrDefaultTest), Range1LastOrDefaultTest, Range1LastOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeatTest), RangeRepeatTest, RangeRepeatTestRewritten);
            TestsExtensions.TestEquals(nameof(EmptyLastOrDefaultTest), EmptyLastOrDefaultTest, EmptyLastOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctLastOrDefaultTest), ArrayDistinctLastOrDefaultTest, ArrayDistinctLastOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultParamTest), ArrayLastOrDefaultParamTest, ArrayLastOrDefaultParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultChangingParamTest), ArrayLastOrDefaultChangingParamTest, ArrayLastOrDefaultChangingParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultUsingLastOrDefaultTest), ArrayLastOrDefaultUsingLastOrDefaultTest, ArrayLastOrDefaultUsingLastOrDefaultTestRewritten);
        }

        [NoRewrite]
        public int LastOrDefaultTest()
        {
            return ArrayItems.LastOrDefault();
        } //EndMethod

        public int LastOrDefaultTestRewritten()
        {
            return ArrayItems.LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int EnumerableLastOrDefaultTest()
        {
            return EnumerableItems.LastOrDefault();
        } //EndMethod

        public int EnumerableLastOrDefaultTestRewritten()
        {
            return EnumerableItems.LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int LastOrDefaultConditionTest()
        {
            return ArrayItems.LastOrDefault(x => x > 30);
        } //EndMethod

        public int LastOrDefaultConditionTestRewritten()
        {
            return ArrayItems.LastOrDefault(x => x > 30);
        } //EndMethod


        [NoRewrite]
        public int LastOrDefaultFalseConditionTest()
        {
            return ArrayItems.LastOrDefault(x => x > 105);
        } //EndMethod

        public int LastOrDefaultFalseConditionTestRewritten()
        {
            return ArrayItems.LastOrDefault(x => x > 105);
        } //EndMethod


        [NoRewrite]
        public int LastOrDefaultMethodTest()
        {
            return ArrayItems.LastOrDefault(Predicate);
        } //EndMethod

        public int LastOrDefaultMethodTestRewritten()
        {
            return ArrayItems.LastOrDefault(Predicate);
        } //EndMethod


        [NoRewrite]
        public int LastOrDefaultWhereMethodTest()
        {
            return ArrayItems.Where(x => x > 10).LastOrDefault();
        } //EndMethod

        public int LastOrDefaultWhereMethodTestRewritten()
        {
            return ArrayItems.Where(x => x > 10).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int SelectLastOrDefaultMethodTest()
        {
            return ArrayItems.Select(x => x + 10).LastOrDefault();
        } //EndMethod

        public int SelectLastOrDefaultMethodTestRewritten()
        {
            return ArrayItems.Select(x => x + 10).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int RangeLastOrDefaultTest()
        {
            return Enumerable.Range(0, 100).LastOrDefault();
        } //EndMethod

        public int RangeLastOrDefaultTestRewritten()
        {
            return Enumerable.Range(0, 100).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int Range1LastOrDefaultTest()
        {
            return Enumerable.Range(0, 1).LastOrDefault();
        } //EndMethod

        public int Range1LastOrDefaultTestRewritten()
        {
            return Enumerable.Range(0, 1).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int RangeRepeatTest()
        {
            return Enumerable.Repeat(0, 100).LastOrDefault();
        } //EndMethod

        public int RangeRepeatTestRewritten()
        {
            return Enumerable.Repeat(0, 100).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int EmptyLastOrDefaultTest()
        {
            return Enumerable.Empty<int>().LastOrDefault();
        } //EndMethod

        public int EmptyLastOrDefaultTestRewritten()
        {
            return Enumerable.Empty<int>().LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayDistinctLastOrDefaultTest()
        {
            return ArrayItems.Distinct().LastOrDefault();
        } //EndMethod

        public int ArrayDistinctLastOrDefaultTestRewritten()
        {
            return ArrayItems.Distinct().LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayLastOrDefaultParamTest()
        {
            var a = 50;
            return ArrayItems.LastOrDefault(x => x > a);
        } //EndMethod

        public int ArrayLastOrDefaultParamTestRewritten()
        {
            var a = 50;
            return ArrayItems.LastOrDefault(x => x > a);
        } //EndMethod


        [NoRewrite]
        public int ArrayLastOrDefaultChangingParamTest()
        {
            var a = 100;
            return ArrayItems.LastOrDefault(x => x > a--);
        } //EndMethod

        public int ArrayLastOrDefaultChangingParamTestRewritten()
        {
            var a = 100;
            return ArrayItems.LastOrDefault(x => x > a--);
        } //EndMethod


        [NoRewrite]
        public int ArrayLastOrDefaultUsingLastOrDefaultTest()
        {
            var a = 100;
            return ArrayItems.LastOrDefault(x => x > ArrayItems.LastOrDefault(y => y > x));
        } //EndMethod

        public int ArrayLastOrDefaultUsingLastOrDefaultTestRewritten()
        {
            var a = 100;
            return ArrayItems.LastOrDefault(x => x > ArrayItems.LastOrDefault(y => y > x));
        } //EndMethod

    }
}