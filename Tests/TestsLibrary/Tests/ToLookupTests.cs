using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ToLookupTests
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
            TestsExtensions.TestEquals(nameof(ArrayToLookupTest), ArrayToLookupTest, ArrayToLookupTestRewritten);
            TestsExtensions.TestEquals(nameof(ListToLookupTest), ListToLookupTest, ListToLookupTestRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListToLookupTest), SimpleListToLookupTest, SimpleListToLookupTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableToLookupTest), EnumerableToLookupTest, EnumerableToLookupTestRewritten);

            for (int i = -1; i < 1001; i++)
            {
                TestsExtensions.TestEquals(nameof(ArrayWhereParamToLookupTest) + i, () => ArrayWhereParamToLookupTest(i), () => ArrayWhereParamToLookupTestRewritten(i));
                TestsExtensions.TestEquals(nameof(EnumerableWhereParamToLookupTest) + i, () => EnumerableWhereParamToLookupTest(i), () => EnumerableWhereParamToLookupTestRewritten(i));
                TestsExtensions.TestEquals(nameof(SimpleListWhereParamToLookupTest) + i, () => SimpleListWhereParamToLookupTest(i), () => SimpleListWhereParamToLookupTestRewritten(i));
                TestsExtensions.TestEquals(nameof(ListWhereParamToLookupTest) + i, () => ListWhereParamToLookupTest(i), () => ListWhereParamToLookupTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RangeWhereParamToLookupTest) + i, () => RangeWhereParamToLookupTest(i), () => RangeWhereParamToLookupTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RangeParamToLookupTest) + i, () => RangeParamToLookupTest(i), () => RangeParamToLookupTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RepeatParamToLookupTest) + i, () => RepeatParamToLookupTest(i), () => RepeatParamToLookupTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RepeatWhereParamToLookupTest) + i, () => RepeatWhereParamToLookupTest(i), () => RepeatWhereParamToLookupTestRewritten(i));
            }
        }

        public ILookup<int, int> ArrayToLookupTest()
        {
            return ArrayItems.ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> ArrayToLookupTestRewritten()
        {
            return ArrayItems.ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> ListToLookupTest()
        {
            return ListItems.ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> ListToLookupTestRewritten()
        {
            return ListItems.ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> SimpleListToLookupTest()
        {
            return SimpleListItems.ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> SimpleListToLookupTestRewritten()
        {
            return SimpleListItems.ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> EnumerableToLookupTest()
        {
            return EnumerableItems.ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> EnumerableToLookupTestRewritten()
        {
            return EnumerableItems.ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> ArrayWhereParamToLookupTest(int offset)
        {
            return ArrayItems.Where(x => x > offset).ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> ArrayWhereParamToLookupTestRewritten(int offset)
        {
            return ArrayItems.Where(x => x > offset).ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> EnumerableWhereParamToLookupTest(int offset)
        {
            return EnumerableItems.Where(x => x > offset).ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> EnumerableWhereParamToLookupTestRewritten(int offset)
        {
            return EnumerableItems.Where(x => x > offset).ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> SimpleListWhereParamToLookupTest(int offset)
        {
            return SimpleListItems.Where(x => x > offset).ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> SimpleListWhereParamToLookupTestRewritten(int offset)
        {
            return SimpleListItems.Where(x => x > offset).ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> ListWhereParamToLookupTest(int offset)
        {
            return ListItems.Where(x => x > offset).ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> ListWhereParamToLookupTestRewritten(int offset)
        {
            return ListItems.Where(x => x > offset).ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> RangeWhereParamToLookupTest(int offset)
        {
            return Enumerable.Range(0, 1000).Where(x => x > offset).ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> RangeWhereParamToLookupTestRewritten(int offset)
        {
            return Enumerable.Range(0, 1000).Where(x => x > offset).ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> RangeParamToLookupTest(int count)
        {
            return Enumerable.Range(0, count).ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> RangeParamToLookupTestRewritten(int count)
        {
            return Enumerable.Range(0, count).ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> RepeatParamToLookupTest(int count)
        {
            return Enumerable.Repeat(0, count).ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> RepeatParamToLookupTestRewritten(int count)
        {
            return Enumerable.Repeat(0, count).ToLookup(x => x, x => x);
        } //EndMethod


        public ILookup<int, int> RepeatWhereParamToLookupTest(int offset)
        {
            return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToLookup(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public ILookup<int, int> RepeatWhereParamToLookupTestRewritten(int offset)
        {
            return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToLookup(x => x, x => x);
        } //EndMethod

    }
}