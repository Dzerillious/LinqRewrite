using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ToArrayTests
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
            TestsExtensions.TestEquals(nameof(ArrayToArrayTest), ArrayToArrayTest, ArrayToArrayTestRewritten);
            TestsExtensions.TestEquals(nameof(ListToArrayTest), ListToArrayTest, ListToArrayTestRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListToArrayTest), SimpleListToArrayTest, SimpleListToArrayTestRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableToArrayTest), EnumerableToArrayTest, EnumerableToArrayTestRewritten);

            for (int i = -1; i < 1001; i++)
            {
                TestsExtensions.TestEquals(nameof(ArrayWhereParamToArrayTest) + i, () => ArrayWhereParamToArrayTest(i), () => ArrayWhereParamToArrayTestRewritten(i));
                TestsExtensions.TestEquals(nameof(EnumerableWhereParamToArrayTest) + i, () => EnumerableWhereParamToArrayTest(i), () => EnumerableWhereParamToArrayTestRewritten(i));
                TestsExtensions.TestEquals(nameof(SimpleListWhereParamToArrayTest) + i, () => SimpleListWhereParamToArrayTest(i), () => SimpleListWhereParamToArrayTestRewritten(i));
                TestsExtensions.TestEquals(nameof(ListWhereParamToArrayTest) + i, () => ListWhereParamToArrayTest(i), () => ListWhereParamToArrayTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RangeWhereParamToArrayTest) + i, () => RangeWhereParamToArrayTest(i), () => RangeWhereParamToArrayTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RangeParamToArrayTest) + i, () => RangeParamToArrayTest(i), () => RangeParamToArrayTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RepeatParamToArrayTest) + i, () => RepeatParamToArrayTest(i), () => RepeatParamToArrayTestRewritten(i));
                TestsExtensions.TestEquals(nameof(RepeatWhereParamToArrayTest) + i, () => RepeatWhereParamToArrayTest(i), () => RepeatWhereParamToArrayTestRewritten(i));
            }
        }

        [NoRewrite]
        public IEnumerable<int> ArrayToArrayTest()
        {
            return ArrayItems.ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayToArrayTestRewritten()
        {
            return ArrayItems.ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ListToArrayTest()
        {
            return ListItems.ToArray();
        } //EndMethod

        public IEnumerable<int> ListToArrayTestRewritten()
        {
            return ListItems.ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListToArrayTest()
        {
            return SimpleListItems.ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListToArrayTestRewritten()
        {
            return SimpleListItems.ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableToArrayTest()
        {
            return EnumerableItems.ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableToArrayTestRewritten()
        {
            return EnumerableItems.ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereParamToArrayTest(int offset)
        {
            return ArrayItems.Where(x => x > offset).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayWhereParamToArrayTestRewritten(int offset)
        {
            return ArrayItems.Where(x => x > offset).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableWhereParamToArrayTest(int offset)
        {
            return EnumerableItems.Where(x => x > offset).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableWhereParamToArrayTestRewritten(int offset)
        {
            return EnumerableItems.Where(x => x > offset).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListWhereParamToArrayTest(int offset)
        {
            return SimpleListItems.Where(x => x > offset).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListWhereParamToArrayTestRewritten(int offset)
        {
            return SimpleListItems.Where(x => x > offset).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ListWhereParamToArrayTest(int offset)
        {
            return ListItems.Where(x => x > offset).ToArray();
        } //EndMethod

        public IEnumerable<int> ListWhereParamToArrayTestRewritten(int offset)
        {
            return ListItems.Where(x => x > offset).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeWhereParamToArrayTest(int offset)
        {
            return Enumerable.Range(0, 1000).Where(x => x > offset).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeWhereParamToArrayTestRewritten(int offset)
        {
            return Enumerable.Range(0, 1000).Where(x => x > offset).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeParamToArrayTest(int count)
        {
            return Enumerable.Range(0, count).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeParamToArrayTestRewritten(int count)
        {
            return Enumerable.Range(0, count).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatParamToArrayTest(int count)
        {
            return Enumerable.Repeat(0, count).ToArray();
        } //EndMethod

        public IEnumerable<int> RepeatParamToArrayTestRewritten(int count)
        {
            return Enumerable.Repeat(0, count).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatWhereParamToArrayTest(int offset)
        {
            return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToArray();
        } //EndMethod

        public IEnumerable<int> RepeatWhereParamToArrayTestRewritten(int offset)
        {
            return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToArray();
        } //EndMethod

    }
}