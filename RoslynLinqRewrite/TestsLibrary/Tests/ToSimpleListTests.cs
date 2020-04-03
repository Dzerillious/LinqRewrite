using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ToSimpleListTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 1000).ToArray();
        [Datapoints]
        private List<int> ListItems = Enumerable.Range(0, 1000).ToList();
        [Datapoints]
        private SimpleList<int> SimpleListItems = Enumerable.Range(0, 1000).ToSimpleList();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 1000);
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayToSimpleListTest), ArrayToSimpleListTest, ArrayToSimpleListTestRewritten);
            TestsExtensions.TestEquals(nameof(ListToSimpleListTest), ListToSimpleListTest, ListToSimpleListTestRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListToSimpleListTest), SimpleListToSimpleListTest, SimpleListToSimpleListTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableToSimpleListTest), EnumerableToSimpleListTest, EnumerableToSimpleListTestRewritten);

            for (int i = -1; i < 1001; i++)
            {
                TestsExtensions.TestEquals(nameof(ArrayWhereParamToSimpleListTest) + i, () => ArrayWhereParamToSimpleListTest(i), () => ArrayWhereParamToSimpleListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(EnumerableWhereParamToSimpleListTest) + i, () => EnumerableWhereParamToSimpleListTest(i), () => EnumerableWhereParamToSimpleListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(SimpleListWhereParamToSimpleListTest) + i, () => SimpleListWhereParamToSimpleListTest(i), () => SimpleListWhereParamToSimpleListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(ListWhereParamToSimpleListTest) + i, () => ListWhereParamToSimpleListTest(i), () => ListWhereParamToSimpleListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RangeWhereParamToSimpleListTest) + i, () => RangeWhereParamToSimpleListTest(i), () => RangeWhereParamToSimpleListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RangeParamToSimpleListTest) + i, () => RangeParamToSimpleListTest(i), () => RangeParamToSimpleListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RepeatParamToSimpleListTest) + i, () => RepeatParamToSimpleListTest(i), () => RepeatParamToSimpleListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RepeatWhereParamToSimpleListTest) + i, () => RepeatWhereParamToSimpleListTest(i), () => RepeatWhereParamToSimpleListTestRewritten(i));
            }
        }

        [NoRewrite]
        public IEnumerable<int> ArrayToSimpleListTest()
        {
            return ArrayItems.ToSimpleList();
        } //EndMethod

        public IEnumerable<int> ArrayToSimpleListTestRewritten()
        {
            return ArrayItems.ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ListToSimpleListTest()
        {
            return ListItems.ToSimpleList();
        } //EndMethod

        public IEnumerable<int> ListToSimpleListTestRewritten()
        {
            return ListItems.ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListToSimpleListTest()
        {
            return SimpleListItems.ToSimpleList();
        } //EndMethod

        public IEnumerable<int> SimpleListToSimpleListTestRewritten()
        {
            return SimpleListItems.ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableToSimpleListTest()
        {
            return EnumerableItems.ToSimpleList();
        } //EndMethod

        public IEnumerable<int> EnumerableToSimpleListTestRewritten()
        {
            return EnumerableItems.ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereParamToSimpleListTest(int offset)
        {
            return ArrayItems.Where(x => x > offset).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> ArrayWhereParamToSimpleListTestRewritten(int offset)
        {
            return ArrayItems.Where(x => x > offset).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableWhereParamToSimpleListTest(int offset)
        {
            return EnumerableItems.Where(x => x > offset).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> EnumerableWhereParamToSimpleListTestRewritten(int offset)
        {
            return EnumerableItems.Where(x => x > offset).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListWhereParamToSimpleListTest(int offset)
        {
            return SimpleListItems.Where(x => x > offset).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> SimpleListWhereParamToSimpleListTestRewritten(int offset)
        {
            return SimpleListItems.Where(x => x > offset).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ListWhereParamToSimpleListTest(int offset)
        {
            return ListItems.Where(x => x > offset).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> ListWhereParamToSimpleListTestRewritten(int offset)
        {
            return ListItems.Where(x => x > offset).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeWhereParamToSimpleListTest(int offset)
        {
            return Enumerable.Range(0, 1000).Where(x => x > offset).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> RangeWhereParamToSimpleListTestRewritten(int offset)
        {
            return Enumerable.Range(0, 1000).Where(x => x > offset).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeParamToSimpleListTest(int count)
        {
            return Enumerable.Range(0, count).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> RangeParamToSimpleListTestRewritten(int count)
        {
            return Enumerable.Range(0, count).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatParamToSimpleListTest(int count)
        {
            return Enumerable.Repeat(0, count).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> RepeatParamToSimpleListTestRewritten(int count)
        {
            return Enumerable.Repeat(0, count).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatWhereParamToSimpleListTest(int offset)
        {
            return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> RepeatWhereParamToSimpleListTestRewritten(int offset)
        {
            return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToSimpleList();
        } //EndMethod

    }
}