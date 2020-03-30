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
            TestsExtensions.TestEquals(nameof(FirstOrDefaultTest), FirstOrDefaultTest, FirstOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableFirstOrDefaultTest), EnumerableFirstOrDefaultTest, EnumerableFirstOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(FirstOrDefaultConditionTest), FirstOrDefaultConditionTest, FirstOrDefaultConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(FirstOrDefaultFalseConditionTest), FirstOrDefaultFalseConditionTest, FirstOrDefaultFalseConditionTestRewritten);
            TestsExtensions.TestEquals(nameof(FirstOrDefaultMethodTest), FirstOrDefaultMethodTest, FirstOrDefaultMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(FirstOrDefaultWhereMethodTest), FirstOrDefaultWhereMethodTest, FirstOrDefaultWhereMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(SelectFirstOrDefaultMethodTest), SelectFirstOrDefaultMethodTest, SelectFirstOrDefaultMethodTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeFirstOrDefaultTest), RangeFirstOrDefaultTest, RangeFirstOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(Range1FirstOrDefaultTest), Range1FirstOrDefaultTest, Range1FirstOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(RangeRepeatTest), RangeRepeatTest, RangeRepeatTestRewritten);
            TestsExtensions.TestEquals(nameof(EmptyFirstOrDefaultTest), EmptyFirstOrDefaultTest, EmptyFirstOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctFirstOrDefaultTest), ArrayDistinctFirstOrDefaultTest, ArrayDistinctFirstOrDefaultTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstOrDefaultParamTest), ArrayFirstOrDefaultParamTest, ArrayFirstOrDefaultParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstOrDefaultChangingParamTest), ArrayFirstOrDefaultChangingParamTest, ArrayFirstOrDefaultChangingParamTestRewritten);
            TestsExtensions.TestEquals(nameof(ArrayFirstOrDefaultUsingFirstOrDefaultTest), ArrayFirstOrDefaultUsingFirstOrDefaultTest, ArrayFirstOrDefaultUsingFirstOrDefaultTestRewritten);
        }

        [NoRewrite]
        public int FirstOrDefaultTest()
        {
            return ArrayItems.FirstOrDefault();
        } //EndMethod

        public int FirstOrDefaultTestRewritten()
        {
            return ArrayItems.FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int EnumerableFirstOrDefaultTest()
        {
            return EnumerableItems.FirstOrDefault();
        } //EndMethod

        public int EnumerableFirstOrDefaultTestRewritten()
        {
            return EnumerableItems.FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int FirstOrDefaultConditionTest()
        {
            return ArrayItems.FirstOrDefault(x => x > 30);
        } //EndMethod

        public int FirstOrDefaultConditionTestRewritten()
        {
            return ArrayItems.FirstOrDefault(x => x > 30);
        } //EndMethod


        [NoRewrite]
        public int FirstOrDefaultFalseConditionTest()
        {
            return ArrayItems.FirstOrDefault(x => x > 105);
        } //EndMethod

        public int FirstOrDefaultFalseConditionTestRewritten()
        {
            return ArrayItems.FirstOrDefault(x => x > 105);
        } //EndMethod


        [NoRewrite]
        public int FirstOrDefaultMethodTest()
        {
            return ArrayItems.FirstOrDefault(Predicate);
        } //EndMethod

        public int FirstOrDefaultMethodTestRewritten()
        {
            return ArrayItems.FirstOrDefault(Predicate);
        } //EndMethod


        [NoRewrite]
        public int FirstOrDefaultWhereMethodTest()
        {
            return ArrayItems.Where(x => x > 10).FirstOrDefault();
        } //EndMethod

        public int FirstOrDefaultWhereMethodTestRewritten()
        {
            return ArrayItems.Where(x => x > 10).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int SelectFirstOrDefaultMethodTest()
        {
            return ArrayItems.Select(x => x + 10).FirstOrDefault();
        } //EndMethod

        public int SelectFirstOrDefaultMethodTestRewritten()
        {
            return ArrayItems.Select(x => x + 10).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int RangeFirstOrDefaultTest()
        {
            return Enumerable.Range(0, 100).FirstOrDefault();
        } //EndMethod

        public int RangeFirstOrDefaultTestRewritten()
        {
            return Enumerable.Range(0, 100).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int Range1FirstOrDefaultTest()
        {
            return Enumerable.Range(0, 1).FirstOrDefault();
        } //EndMethod

        public int Range1FirstOrDefaultTestRewritten()
        {
            return Enumerable.Range(0, 1).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int RangeRepeatTest()
        {
            return Enumerable.Repeat(0, 100).FirstOrDefault();
        } //EndMethod

        public int RangeRepeatTestRewritten()
        {
            return Enumerable.Repeat(0, 100).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int EmptyFirstOrDefaultTest()
        {
            return Enumerable.Empty<int>().FirstOrDefault();
        } //EndMethod

        public int EmptyFirstOrDefaultTestRewritten()
        {
            return Enumerable.Empty<int>().FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayDistinctFirstOrDefaultTest()
        {
            return ArrayItems.Distinct().FirstOrDefault();
        } //EndMethod

        public int ArrayDistinctFirstOrDefaultTestRewritten()
        {
            return ArrayItems.Distinct().FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayFirstOrDefaultParamTest()
        {
            var a = 50;
            return ArrayItems.FirstOrDefault(x => x > a);
        } //EndMethod

        public int ArrayFirstOrDefaultParamTestRewritten()
        {
            var a = 50;
            return ArrayItems.FirstOrDefault(x => x > a);
        } //EndMethod


        [NoRewrite]
        public int ArrayFirstOrDefaultChangingParamTest()
        {
            var a = 100;
            return ArrayItems.FirstOrDefault(x => x > a--);
        } //EndMethod

        public int ArrayFirstOrDefaultChangingParamTestRewritten()
        {
            var a = 100;
            return ArrayItems.FirstOrDefault(x => x > a--);
        } //EndMethod


        [NoRewrite]
        public int ArrayFirstOrDefaultUsingFirstOrDefaultTest()
        {
            var a = 100;
            return ArrayItems.FirstOrDefault(x => x > ArrayItems.FirstOrDefault(y => y > x));
        } //EndMethod

        public int ArrayFirstOrDefaultUsingFirstOrDefaultTestRewritten()
        {
            var a = 100;
            return ArrayItems.FirstOrDefault(x => x > ArrayItems.FirstOrDefault(y => y > x));
        } //EndMethod

    }
}