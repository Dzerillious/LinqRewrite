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
            TestsExtensions.TestEquals(nameof(SingleOrDefaultTest), SingleOrDefaultTest, SingleOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSingleOrDefaultTest), EnumerableSingleOrDefaultTest, EnumerableSingleOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(SingleOrDefaultConditionTest), SingleOrDefaultConditionTest, SingleOrDefaultConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(SingleOrDefaultFalseConditionTest), SingleOrDefaultFalseConditionTest, SingleOrDefaultFalseConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(SingleOrDefaultMethodTest), SingleOrDefaultMethodTest, SingleOrDefaultMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(SingleOrDefaultWhereMethodTest), SingleOrDefaultWhereMethodTest, SingleOrDefaultWhereMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(SelectSingleOrDefaultMethodTest), SelectSingleOrDefaultMethodTest, SelectSingleOrDefaultMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeSingleOrDefaultTest), RangeSingleOrDefaultTest, RangeSingleOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(Range1SingleOrDefaultTest), Range1SingleOrDefaultTest, Range1SingleOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeatTest), RangeRepeatTest, RangeRepeatTestRewritten);
            TestsExtensions.TestEquals(nameof(EmptySingleOrDefaultTest), EmptySingleOrDefaultTest, EmptySingleOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctSingleOrDefaultTest), ArrayDistinctSingleOrDefaultTest, ArrayDistinctSingleOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleOrDefaultParamTest), ArraySingleOrDefaultParamTest, ArraySingleOrDefaultParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleOrDefaultChangingParamTest), ArraySingleOrDefaultChangingParamTest, ArraySingleOrDefaultChangingParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArraySingleOrDefaultUsingSingleOrDefaultTest), ArraySingleOrDefaultUsingSingleOrDefaultTest, ArraySingleOrDefaultUsingSingleOrDefaultTestRewritten);
        }

        [NoRewrite]
        public int SingleOrDefaultTest()
        {
            return ArrayItems.SingleOrDefault();
        } //EndMethod

        public int SingleOrDefaultTestRewritten()
        {
            return ArrayItems.SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int EnumerableSingleOrDefaultTest()
        {
            return EnumerableItems.SingleOrDefault();
        } //EndMethod

        public int EnumerableSingleOrDefaultTestRewritten()
        {
            return EnumerableItems.SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int SingleOrDefaultConditionTest()
        {
            return ArrayItems.SingleOrDefault(x => x > 30);
        } //EndMethod

        public int SingleOrDefaultConditionTestRewritten()
        {
            return ArrayItems.SingleOrDefault(x => x > 30);
        } //EndMethod


        [NoRewrite]
        public int SingleOrDefaultFalseConditionTest()
        {
            return ArrayItems.SingleOrDefault(x => x > 105);
        } //EndMethod

        public int SingleOrDefaultFalseConditionTestRewritten()
        {
            return ArrayItems.SingleOrDefault(x => x > 105);
        } //EndMethod


        [NoRewrite]
        public int SingleOrDefaultMethodTest()
        {
            return ArrayItems.SingleOrDefault(Predicate);
        } //EndMethod

        public int SingleOrDefaultMethodTestRewritten()
        {
            return ArrayItems.SingleOrDefault(Predicate);
        } //EndMethod


        [NoRewrite]
        public int SingleOrDefaultWhereMethodTest()
        {
            return ArrayItems.Where(x => x > 10).SingleOrDefault();
        } //EndMethod

        public int SingleOrDefaultWhereMethodTestRewritten()
        {
            return ArrayItems.Where(x => x > 10).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int SelectSingleOrDefaultMethodTest()
        {
            return ArrayItems.Select(x => x + 10).SingleOrDefault();
        } //EndMethod

        public int SelectSingleOrDefaultMethodTestRewritten()
        {
            return ArrayItems.Select(x => x + 10).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int RangeSingleOrDefaultTest()
        {
            return Enumerable.Range(0, 100).SingleOrDefault();
        } //EndMethod

        public int RangeSingleOrDefaultTestRewritten()
        {
            return Enumerable.Range(0, 100).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int Range1SingleOrDefaultTest()
        {
            return Enumerable.Range(0, 1).SingleOrDefault();
        } //EndMethod

        public int Range1SingleOrDefaultTestRewritten()
        {
            return Enumerable.Range(0, 1).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int RangeRepeatTest()
        {
            return Enumerable.Repeat(0, 100).SingleOrDefault();
        } //EndMethod

        public int RangeRepeatTestRewritten()
        {
            return Enumerable.Repeat(0, 100).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int EmptySingleOrDefaultTest()
        {
            return Enumerable.Empty<int>().SingleOrDefault();
        } //EndMethod

        public int EmptySingleOrDefaultTestRewritten()
        {
            return Enumerable.Empty<int>().SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayDistinctSingleOrDefaultTest()
        {
            return ArrayItems.Distinct().SingleOrDefault();
        } //EndMethod

        public int ArrayDistinctSingleOrDefaultTestRewritten()
        {
            return ArrayItems.Distinct().SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArraySingleOrDefaultParamTest()
        {
            var a = 50;
            return ArrayItems.SingleOrDefault(x => x > a);
        } //EndMethod

        public int ArraySingleOrDefaultParamTestRewritten()
        {
            var a = 50;
            return ArrayItems.SingleOrDefault(x => x > a);
        } //EndMethod


        [NoRewrite]
        public int ArraySingleOrDefaultChangingParamTest()
        {
            var a = 100;
            return ArrayItems.SingleOrDefault(x => x > a--);
        } //EndMethod

        public int ArraySingleOrDefaultChangingParamTestRewritten()
        {
            var a = 100;
            return ArrayItems.SingleOrDefault(x => x > a--);
        } //EndMethod


        [NoRewrite]
        public int ArraySingleOrDefaultUsingSingleOrDefaultTest()
        {
            var a = 100;
            return ArrayItems.SingleOrDefault(x => x > ArrayItems.SingleOrDefault(y => y > x));
        } //EndMethod

        public int ArraySingleOrDefaultUsingSingleOrDefaultTestRewritten()
        {
            var a = 100;
            return ArrayItems.SingleOrDefault(x => x > ArrayItems.SingleOrDefault(y => y > x));
        } //EndMethod

    }
}