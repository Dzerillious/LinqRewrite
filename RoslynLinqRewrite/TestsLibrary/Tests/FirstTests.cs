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
            TestsExtensions.TestEquals(nameof(FirstTest), FirstTest, FirstTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableFirstTest), EnumerableFirstTest, EnumerableFirstTestRewritten);
            TestsExtensions.TestEquals(nameof(FirstConditionTest), FirstConditionTest, FirstConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(FirstFalseConditionTest), FirstFalseConditionTest, FirstFalseConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(FirstMethodTest), FirstMethodTest, FirstMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(FirstWhereMethodTest), FirstWhereMethodTest, FirstWhereMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(SelectFirstMethodTest), SelectFirstMethodTest, SelectFirstMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeFirstTest), RangeFirstTest, RangeFirstTestRewritten);
            TestsExtensions.TestEquals(nameof(Range1FirstTest), Range1FirstTest, Range1FirstTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeatTest), RangeRepeatTest, RangeRepeatTestRewritten);
            TestsExtensions.TestEquals(nameof(EmptyFirstTest), EmptyFirstTest, EmptyFirstTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctFirstTest), ArrayDistinctFirstTest, ArrayDistinctFirstTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstParamTest), ArrayFirstParamTest, ArrayFirstParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstChangingParamTest), ArrayFirstChangingParamTest, ArrayFirstChangingParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstUsingFirstTest), ArrayFirstUsingFirstTest, ArrayFirstUsingFirstTestRewritten);
        }

        [NoRewrite]
        public int FirstTest()
        {
            return ArrayItems.First();
        } //EndMethod

        public int FirstTestRewritten()
        {
            return ArrayItems.First();
        } //EndMethod


        [NoRewrite]
        public int EnumerableFirstTest()
        {
            return EnumerableItems.First();
        } //EndMethod

        public int EnumerableFirstTestRewritten()
        {
            return EnumerableItems.First();
        } //EndMethod


        [NoRewrite]
        public int FirstConditionTest()
        {
            return ArrayItems.First(x => x > 30);
        } //EndMethod

        public int FirstConditionTestRewritten()
        {
            return ArrayItems.First(x => x > 30);
        } //EndMethod


        [NoRewrite]
        public int FirstFalseConditionTest()
        {
            return ArrayItems.First(x => x > 105);
        } //EndMethod

        public int FirstFalseConditionTestRewritten()
        {
            return ArrayItems.First(x => x > 105);
        } //EndMethod


        [NoRewrite]
        public int FirstMethodTest()
        {
            return ArrayItems.First(Predicate);
        } //EndMethod

        public int FirstMethodTestRewritten()
        {
            return ArrayItems.First(Predicate);
        } //EndMethod


        [NoRewrite]
        public int FirstWhereMethodTest()
        {
            return ArrayItems.Where(x => x > 10).First();
        } //EndMethod

        public int FirstWhereMethodTestRewritten()
        {
            return ArrayItems.Where(x => x > 10).First();
        } //EndMethod


        [NoRewrite]
        public int SelectFirstMethodTest()
        {
            return ArrayItems.Select(x => x + 10).First();
        } //EndMethod

        public int SelectFirstMethodTestRewritten()
        {
            return ArrayItems.Select(x => x + 10).First();
        } //EndMethod


        [NoRewrite]
        public int RangeFirstTest()
        {
            return Enumerable.Range(0, 100).First();
        } //EndMethod

        public int RangeFirstTestRewritten()
        {
            return Enumerable.Range(0, 100).First();
        } //EndMethod


        [NoRewrite]
        public int Range1FirstTest()
        {
            return Enumerable.Range(0, 1).First();
        } //EndMethod

        public int Range1FirstTestRewritten()
        {
            return Enumerable.Range(0, 1).First();
        } //EndMethod


        [NoRewrite]
        public int RangeRepeatTest()
        {
            return Enumerable.Repeat(0, 100).First();
        } //EndMethod

        public int RangeRepeatTestRewritten()
        {
            return Enumerable.Repeat(0, 100).First();
        } //EndMethod


        [NoRewrite]
        public int EmptyFirstTest()
        {
            return Enumerable.Empty<int>().First();
        } //EndMethod

        public int EmptyFirstTestRewritten()
        {
            return Enumerable.Empty<int>().First();
        } //EndMethod


        [NoRewrite]
        public int ArrayDistinctFirstTest()
        {
            return ArrayItems.Distinct().First();
        } //EndMethod

        public int ArrayDistinctFirstTestRewritten()
        {
            return ArrayItems.Distinct().First();
        } //EndMethod


        [NoRewrite]
        public int ArrayFirstParamTest()
        {
            var a = 50;
            return ArrayItems.First(x => x > a);
        } //EndMethod

        public int ArrayFirstParamTestRewritten()
        {
            var a = 50;
            return ArrayItems.First(x => x > a);
        } //EndMethod


        [NoRewrite]
        public int ArrayFirstChangingParamTest()
        {
            var a = 100;
            return ArrayItems.First(x => x > a--);
        } //EndMethod

        public int ArrayFirstChangingParamTestRewritten()
        {
            var a = 100;
            return ArrayItems.First(x => x > a--);
        } //EndMethod


        [NoRewrite]
        public int ArrayFirstUsingFirstTest()
        {
            var a = 100;
            return ArrayItems.First(x => x > ArrayItems.First(y => y > x));
        } //EndMethod

        public int ArrayFirstUsingFirstTestRewritten()
        {
            var a = 100;
            return ArrayItems.First(x => x > ArrayItems.First(y => y > x));
        } //EndMethod

    }
}