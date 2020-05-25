using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ToListTests
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
            TestsExtensions.TestEquals(nameof(ArrayToListTest), ArrayToListTest, ArrayToListTestRewritten);
            TestsExtensions.TestEquals(nameof(ListToListTest), ListToListTest, ListToListTestRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListToListTest), SimpleListToListTest, SimpleListToListTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableToListTest), EnumerableToListTest, EnumerableToListTestRewritten);

            for (int i = -1; i < 1001; i++)
            {
                TestsExtensions.TestEquals(nameof(ArrayWhereParamToListTest) + i, () => ArrayWhereParamToListTest(i), () => ArrayWhereParamToListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(EnumerableWhereParamToListTest) + i, () => EnumerableWhereParamToListTest(i), () => EnumerableWhereParamToListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(SimpleListWhereParamToListTest) + i, () => SimpleListWhereParamToListTest(i), () => SimpleListWhereParamToListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(ListWhereParamToListTest) + i, () => ListWhereParamToListTest(i), () => ListWhereParamToListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RangeWhereParamToListTest) + i, () => RangeWhereParamToListTest(i), () => RangeWhereParamToListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RangeParamToListTest) + i, () => RangeParamToListTest(i), () => RangeParamToListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RepeatParamToListTest) + i, () => RepeatParamToListTest(i), () => RepeatParamToListTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RepeatWhereParamToListTest) + i, () => RepeatWhereParamToListTest(i), () => RepeatWhereParamToListTestRewritten(i));
            }
        }

        [NoRewrite]
        public IEnumerable<int> ArrayToListTest()
        {
            return ArrayItems.ToList();
        } //EndMethod

        public IEnumerable<int> ArrayToListTestRewritten()
        {
            return ArrayItems.ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ListToListTest()
        {
            return ListItems.ToList();
        } //EndMethod

        public IEnumerable<int> ListToListTestRewritten()
        {
            return ListItems.ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListToListTest()
        {
            return SimpleListItems.ToList();
        } //EndMethod

        public IEnumerable<int> SimpleListToListTestRewritten()
        {
            return SimpleListItems.ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableToListTest()
        {
            return EnumerableItems.ToList();
        } //EndMethod

        public IEnumerable<int> EnumerableToListTestRewritten()
        {
            return EnumerableItems.ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereParamToListTest(int offset)
        {
            return ArrayItems.Where(x => x > offset).ToList();
        } //EndMethod

        public IEnumerable<int> ArrayWhereParamToListTestRewritten(int offset)
        {
            return ArrayItems.Where(x => x > offset).ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableWhereParamToListTest(int offset)
        {
            return EnumerableItems.Where(x => x > offset).ToList();
        } //EndMethod

        public IEnumerable<int> EnumerableWhereParamToListTestRewritten(int offset)
        {
            return EnumerableItems.Where(x => x > offset).ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListWhereParamToListTest(int offset)
        {
            return SimpleListItems.Where(x => x > offset).ToList();
        } //EndMethod

        public IEnumerable<int> SimpleListWhereParamToListTestRewritten(int offset)
        {
            return SimpleListItems.Where(x => x > offset).ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ListWhereParamToListTest(int offset)
        {
            return ListItems.Where(x => x > offset).ToList();
        } //EndMethod

        public IEnumerable<int> ListWhereParamToListTestRewritten(int offset)
        {
            return ListItems.Where(x => x > offset).ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeWhereParamToListTest(int offset)
        {
            return Enumerable.Range(0, 1000).Where(x => x > offset).ToList();
        } //EndMethod

        public IEnumerable<int> RangeWhereParamToListTestRewritten(int offset)
        {
            return Enumerable.Range(0, 1000).Where(x => x > offset).ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeParamToListTest(int count)
        {
            return Enumerable.Range(0, count).ToList();
        } //EndMethod

        public IEnumerable<int> RangeParamToListTestRewritten(int count)
        {
            return Enumerable.Range(0, count).ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatParamToListTest(int count)
        {
            return Enumerable.Repeat(0, count).ToList();
        } //EndMethod

        public IEnumerable<int> RepeatParamToListTestRewritten(int count)
        {
            return Enumerable.Repeat(0, count).ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatWhereParamToListTest(int offset)
        {
            return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToList();
        } //EndMethod

        public IEnumerable<int> RepeatWhereParamToListTestRewritten(int offset)
        {
            return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToList();
        } //EndMethod

    }
}