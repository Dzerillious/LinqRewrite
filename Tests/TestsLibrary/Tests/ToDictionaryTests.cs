using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ToDictionaryTests
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
            TestsExtensions.TestEquals(nameof(ArrayToDictionaryTest), ArrayToDictionaryTest, ArrayToDictionaryTestRewritten);
            TestsExtensions.TestEquals(nameof(ListToDictionaryTest), ListToDictionaryTest, ListToDictionaryTestRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListToDictionaryTest), SimpleListToDictionaryTest, SimpleListToDictionaryTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableToDictionaryTest), EnumerableToDictionaryTest, EnumerableToDictionaryTestRewritten);

            for (int i = -1; i < 1001; i++)
            {
                TestsExtensions.TestEquals(nameof(ArrayWhereParamToDictionaryTest) + i, () => ArrayWhereParamToDictionaryTest(i), () => ArrayWhereParamToDictionaryTestRewritten(i));
                TestsExtensions.TestEquals(nameof(EnumerableWhereParamToDictionaryTest) + i, () => EnumerableWhereParamToDictionaryTest(i), () => EnumerableWhereParamToDictionaryTestRewritten(i));
                TestsExtensions.TestEquals(nameof(SimpleListWhereParamToDictionaryTest) + i, () => SimpleListWhereParamToDictionaryTest(i), () => SimpleListWhereParamToDictionaryTestRewritten(i));
                TestsExtensions.TestEquals(nameof(ListWhereParamToDictionaryTest) + i, () => ListWhereParamToDictionaryTest(i), () => ListWhereParamToDictionaryTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RangeWhereParamToDictionaryTest) + i, () => RangeWhereParamToDictionaryTest(i), () => RangeWhereParamToDictionaryTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RangeParamToDictionaryTest) + i, () => RangeParamToDictionaryTest(i), () => RangeParamToDictionaryTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RepeatParamToDictionaryTest) + i, () => RepeatParamToDictionaryTest(i), () => RepeatParamToDictionaryTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RepeatWhereParamToDictionaryTest) + i, () => RepeatWhereParamToDictionaryTest(i), () => RepeatWhereParamToDictionaryTestRewritten(i));
            }
        }

        public Dictionary<int, int> ArrayToDictionaryTest()
        {
            return ArrayItems.ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> ArrayToDictionaryTestRewritten()
        {
            return ArrayItems.ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> ListToDictionaryTest()
        {
            return ListItems.ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> ListToDictionaryTestRewritten()
        {
            return ListItems.ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> SimpleListToDictionaryTest()
        {
            return SimpleListItems.ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> SimpleListToDictionaryTestRewritten()
        {
            return SimpleListItems.ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> EnumerableToDictionaryTest()
        {
            return EnumerableItems.ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> EnumerableToDictionaryTestRewritten()
        {
            return EnumerableItems.ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> ArrayWhereParamToDictionaryTest(int offset)
        {
            return ArrayItems.Where(x => x > offset).ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> ArrayWhereParamToDictionaryTestRewritten(int offset)
        {
            return ArrayItems.Where(x => x > offset).ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> EnumerableWhereParamToDictionaryTest(int offset)
        {
            return EnumerableItems.Where(x => x > offset).ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> EnumerableWhereParamToDictionaryTestRewritten(int offset)
        {
            return EnumerableItems.Where(x => x > offset).ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> SimpleListWhereParamToDictionaryTest(int offset)
        {
            return SimpleListItems.Where(x => x > offset).ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> SimpleListWhereParamToDictionaryTestRewritten(int offset)
        {
            return SimpleListItems.Where(x => x > offset).ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> ListWhereParamToDictionaryTest(int offset)
        {
            return ListItems.Where(x => x > offset).ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> ListWhereParamToDictionaryTestRewritten(int offset)
        {
            return ListItems.Where(x => x > offset).ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> RangeWhereParamToDictionaryTest(int offset)
        {
            return Enumerable.Range(0, 1000).Where(x => x > offset).ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> RangeWhereParamToDictionaryTestRewritten(int offset)
        {
            return Enumerable.Range(0, 1000).Where(x => x > offset).ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> RangeParamToDictionaryTest(int count)
        {
            return Enumerable.Range(0, count).ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> RangeParamToDictionaryTestRewritten(int count)
        {
            return Enumerable.Range(0, count).ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> RepeatParamToDictionaryTest(int count)
        {
            return Enumerable.Repeat(0, count).ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> RepeatParamToDictionaryTestRewritten(int count)
        {
            return Enumerable.Repeat(0, count).ToDictionary(x => x, x => x);
        } //EndMethod


        public Dictionary<int, int> RepeatWhereParamToDictionaryTest(int offset)
        {
            return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToDictionary(x => x, x => x);
        } //EndMethod

        [LinqRewrite]
		public Dictionary<int, int> RepeatWhereParamToDictionaryTestRewritten(int offset)
        {
            return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToDictionary(x => x, x => x);
        } //EndMethod

    }
}