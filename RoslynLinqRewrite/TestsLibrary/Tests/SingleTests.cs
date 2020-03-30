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
            TestsExtensions.TestEquals(nameof(SingleTest), SingleTest, SingleTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSingleTest), EnumerableSingleTest, EnumerableSingleTestRewritten);
            TestsExtensions.TestEquals(nameof(SingleConditionTest), SingleConditionTest, SingleConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(SingleFalseConditionTest), SingleFalseConditionTest, SingleFalseConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(SingleMethodTest), SingleMethodTest, SingleMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(SingleWhereMethodTest), SingleWhereMethodTest, SingleWhereMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(SelectSingleMethodTest), SelectSingleMethodTest, SelectSingleMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeSingleTest), RangeSingleTest, RangeSingleTestRewritten);
            TestsExtensions.TestEquals(nameof(Range1SingleTest), Range1SingleTest, Range1SingleTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeatTest), RangeRepeatTest, RangeRepeatTestRewritten);
            TestsExtensions.TestEquals(nameof(EmptySingleTest), EmptySingleTest, EmptySingleTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctSingleTest), ArrayDistinctSingleTest, ArrayDistinctSingleTestRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleParamTest), ArraySingleParamTest, ArraySingleParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleChangingParamTest), ArraySingleChangingParamTest, ArraySingleChangingParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleUsingSingleTest), ArraySingleUsingSingleTest, ArraySingleUsingSingleTestRewritten);
        }

        [NoRewrite]
        public int SingleTest()
        {
            return ArrayItems.Single();
        } //EndMethod

        public int SingleTestRewritten()
        {
            return ArrayItems.Single();
        } //EndMethod


        [NoRewrite]
        public int EnumerableSingleTest()
        {
            return EnumerableItems.Single();
        } //EndMethod

        public int EnumerableSingleTestRewritten()
        {
            return EnumerableItems.Single();
        } //EndMethod


        [NoRewrite]
        public int SingleConditionTest()
        {
            return ArrayItems.Single(x => x > 30);
        } //EndMethod

        public int SingleConditionTestRewritten()
        {
            return ArrayItems.Single(x => x > 30);
        } //EndMethod


        [NoRewrite]
        public int SingleFalseConditionTest()
        {
            return ArrayItems.Single(x => x > 105);
        } //EndMethod

        public int SingleFalseConditionTestRewritten()
        {
            return ArrayItems.Single(x => x > 105);
        } //EndMethod


        [NoRewrite]
        public int SingleMethodTest()
        {
            return ArrayItems.Single(Predicate);
        } //EndMethod

        public int SingleMethodTestRewritten()
        {
            return ArrayItems.Single(Predicate);
        } //EndMethod


        [NoRewrite]
        public int SingleWhereMethodTest()
        {
            return ArrayItems.Where(x => x > 10).Single();
        } //EndMethod

        public int SingleWhereMethodTestRewritten()
        {
            return ArrayItems.Where(x => x > 10).Single();
        } //EndMethod


        [NoRewrite]
        public int SelectSingleMethodTest()
        {
            return ArrayItems.Select(x => x + 10).Single();
        } //EndMethod

        public int SelectSingleMethodTestRewritten()
        {
            return ArrayItems.Select(x => x + 10).Single();
        } //EndMethod


        [NoRewrite]
        public int RangeSingleTest()
        {
            return Enumerable.Range(0, 100).Single();
        } //EndMethod

        public int RangeSingleTestRewritten()
        {
            return Enumerable.Range(0, 100).Single();
        } //EndMethod


        [NoRewrite]
        public int Range1SingleTest()
        {
            return Enumerable.Range(0, 1).Single();
        } //EndMethod

        public int Range1SingleTestRewritten()
        {
            return Enumerable.Range(0, 1).Single();
        } //EndMethod


        [NoRewrite]
        public int RangeRepeatTest()
        {
            return Enumerable.Repeat(0, 100).Single();
        } //EndMethod

        public int RangeRepeatTestRewritten()
        {
            return Enumerable.Repeat(0, 100).Single();
        } //EndMethod


        [NoRewrite]
        public int EmptySingleTest()
        {
            return Enumerable.Empty<int>().Single();
        } //EndMethod

        public int EmptySingleTestRewritten()
        {
            return Enumerable.Empty<int>().Single();
        } //EndMethod


        [NoRewrite]
        public int ArrayDistinctSingleTest()
        {
            return ArrayItems.Distinct().Single();
        } //EndMethod

        public int ArrayDistinctSingleTestRewritten()
        {
            return ArrayItems.Distinct().Single();
        } //EndMethod


        [NoRewrite]
        public int ArraySingleParamTest()
        {
            var a = 50;
            return ArrayItems.Single(x => x > a);
        } //EndMethod

        public int ArraySingleParamTestRewritten()
        {
            var a = 50;
            return ArrayItems.Single(x => x > a);
        } //EndMethod


        [NoRewrite]
        public int ArraySingleChangingParamTest()
        {
            var a = 100;
            return ArrayItems.Single(x => x > a--);
        } //EndMethod

        public int ArraySingleChangingParamTestRewritten()
        {
            var a = 100;
            return ArrayItems.Single(x => x > a--);
        } //EndMethod


        [NoRewrite]
        public int ArraySingleUsingSingleTest()
        {
            var a = 100;
            return ArrayItems.Single(x => x > ArrayItems.Single(y => y > x));
        } //EndMethod

        public int ArraySingleUsingSingleTestRewritten()
        {
            var a = 100;
            return ArrayItems.Single(x => x > ArrayItems.Single(y => y > x));
        } //EndMethod

    }
}