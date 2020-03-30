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
            TestsExtensions.TestEquals(nameof(LastTest), LastTest, LastTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableLastTest), EnumerableLastTest, EnumerableLastTestRewritten);
            TestsExtensions.TestEquals(nameof(LastConditionTest), LastConditionTest, LastConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(LastFalseConditionTest), LastFalseConditionTest, LastFalseConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(LastMethodTest), LastMethodTest, LastMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(LastWhereMethodTest), LastWhereMethodTest, LastWhereMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(SelectLastMethodTest), SelectLastMethodTest, SelectLastMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeLastTest), RangeLastTest, RangeLastTestRewritten);
            TestsExtensions.TestEquals(nameof(Range1LastTest), Range1LastTest, Range1LastTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeatTest), RangeRepeatTest, RangeRepeatTestRewritten);
            TestsExtensions.TestEquals(nameof(EmptyLastTest), EmptyLastTest, EmptyLastTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctLastTest), ArrayDistinctLastTest, ArrayDistinctLastTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastParamTest), ArrayLastParamTest, ArrayLastParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastChangingParamTest), ArrayLastChangingParamTest, ArrayLastChangingParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLastUsingLastTest), ArrayLastUsingLastTest, ArrayLastUsingLastTestRewritten);
        }

        [NoRewrite]
        public int LastTest()
        {
            return ArrayItems.Last();
        } //EndMethod

        public int LastTestRewritten()
        {
            return ArrayItems.Last();
        } //EndMethod


        [NoRewrite]
        public int EnumerableLastTest()
        {
            return EnumerableItems.Last();
        } //EndMethod

        public int EnumerableLastTestRewritten()
        {
            return EnumerableItems.Last();
        } //EndMethod


        [NoRewrite]
        public int LastConditionTest()
        {
            return ArrayItems.Last(x => x > 30);
        } //EndMethod

        public int LastConditionTestRewritten()
        {
            return ArrayItems.Last(x => x > 30);
        } //EndMethod


        [NoRewrite]
        public int LastFalseConditionTest()
        {
            return ArrayItems.Last(x => x > 105);
        } //EndMethod

        public int LastFalseConditionTestRewritten()
        {
            return ArrayItems.Last(x => x > 105);
        } //EndMethod


        [NoRewrite]
        public int LastMethodTest()
        {
            return ArrayItems.Last(Predicate);
        } //EndMethod

        public int LastMethodTestRewritten()
        {
            return ArrayItems.Last(Predicate);
        } //EndMethod


        [NoRewrite]
        public int LastWhereMethodTest()
        {
            return ArrayItems.Where(x => x > 10).Last();
        } //EndMethod

        public int LastWhereMethodTestRewritten()
        {
            return ArrayItems.Where(x => x > 10).Last();
        } //EndMethod


        [NoRewrite]
        public int SelectLastMethodTest()
        {
            return ArrayItems.Select(x => x + 10).Last();
        } //EndMethod

        public int SelectLastMethodTestRewritten()
        {
            return ArrayItems.Select(x => x + 10).Last();
        } //EndMethod


        [NoRewrite]
        public int RangeLastTest()
        {
            return Enumerable.Range(0, 100).Last();
        } //EndMethod

        public int RangeLastTestRewritten()
        {
            return Enumerable.Range(0, 100).Last();
        } //EndMethod


        [NoRewrite]
        public int Range1LastTest()
        {
            return Enumerable.Range(0, 1).Last();
        } //EndMethod

        public int Range1LastTestRewritten()
        {
            return Enumerable.Range(0, 1).Last();
        } //EndMethod


        [NoRewrite]
        public int RangeRepeatTest()
        {
            return Enumerable.Repeat(0, 100).Last();
        } //EndMethod

        public int RangeRepeatTestRewritten()
        {
            return Enumerable.Repeat(0, 100).Last();
        } //EndMethod


        [NoRewrite]
        public int EmptyLastTest()
        {
            return Enumerable.Empty<int>().Last();
        } //EndMethod

        public int EmptyLastTestRewritten()
        {
            return Enumerable.Empty<int>().Last();
        } //EndMethod


        [NoRewrite]
        public int ArrayDistinctLastTest()
        {
            return ArrayItems.Distinct().Last();
        } //EndMethod

        public int ArrayDistinctLastTestRewritten()
        {
            return ArrayItems.Distinct().Last();
        } //EndMethod


        [NoRewrite]
        public int ArrayLastParamTest()
        {
            var a = 50;
            return ArrayItems.Last(x => x > a);
        } //EndMethod

        public int ArrayLastParamTestRewritten()
        {
            var a = 50;
            return ArrayItems.Last(x => x > a);
        } //EndMethod


        [NoRewrite]
        public int ArrayLastChangingParamTest()
        {
            var a = 100;
            return ArrayItems.Last(x => x > a--);
        } //EndMethod

        public int ArrayLastChangingParamTestRewritten()
        {
            var a = 100;
            return ArrayItems.Last(x => x > a--);
        } //EndMethod


        [NoRewrite]
        public int ArrayLastUsingLastTest()
        {
            var a = 100;
            return ArrayItems.Last(x => x > ArrayItems.Last(y => y > x));
        } //EndMethod

        public int ArrayLastUsingLastTestRewritten()
        {
            var a = 100;
            return ArrayItems.Last(x => x > ArrayItems.Last(y => y > x));
        } //EndMethod

    }
}