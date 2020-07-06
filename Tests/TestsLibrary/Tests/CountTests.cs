using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class CountTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int i) => i > 50;

        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayCount), ArrayCount, ArrayCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayCount2), ArrayCount2, ArrayCount2Rewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectCount), ArraySelectCount, ArraySelectCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayCount5), ArrayCount5, ArrayCount5Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableCount2), EnumerableCount2, EnumerableCount2Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableCount3), EnumerableCount3, EnumerableCount3Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableCount4), EnumerableCount4, EnumerableCount4Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableCount5), EnumerableCount5, EnumerableCount5Rewritten);
            TestsExtensions.TestEquals(nameof(RangeCount), RangeCount, RangeCountRewritten);
            TestsExtensions.TestEquals(nameof(RangeSelectCount), RangeSelectCount, RangeSelectCountRewritten);
            TestsExtensions.TestEquals(nameof(RangeWhereCount), RangeWhereCount, RangeWhereCountRewritten);
            TestsExtensions.TestEquals(nameof(RangeCount2), RangeCount2, RangeCount2Rewritten);
            TestsExtensions.TestEquals(nameof(RepeatCount), RepeatCount, RepeatCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayMethodCount), ArrayMethodCount, ArrayMethodCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctCount), ArrayDistinctCount, ArrayDistinctCountRewritten);
            TestsExtensions.TestEquals(nameof(EmptyCount), EmptyCount, EmptyCountRewritten);
            TestsExtensions.TestEquals(nameof(EmptyDistinctCount), EmptyDistinctCount, EmptyDistinctCountRewritten);
        }

        public int ArrayCount()
        {
            return ArrayItems.Count();
        } //EndMethod

        [LinqRewrite]
		public int ArrayCountRewritten()
        {
            return ArrayItems.Count();
        } //EndMethod=


        public int ArrayCount2()
        {
            return ArrayItems.Count(x => x > 3);
        } //EndMethod

        [LinqRewrite]
		public int ArrayCount2Rewritten()
        {
            return ArrayItems.Count(x => x > 3);
        } //EndMethod


        public int ArraySelectCount()
        {
            return ArrayItems.Select(x => x + 10).Count();
        } //EndMethod

        [LinqRewrite]
		public int ArraySelectCountRewritten()
        {
            return ArrayItems.Select(x => x + 10).Count();
        } //EndMethod


        public int ArrayCount5()
        {
            return ArrayItems.Where(x => x > 4).Count(x => x % 2 == 0);
        } //EndMethod

        [LinqRewrite]
		public int ArrayCount5Rewritten()
        {
            return ArrayItems.Where(x => x > 4).Count(x => x % 2 == 0);
        } //EndMethod


        public int EnumerableCount2()
        {
            return EnumerableItems.Count();
        } //EndMethod

        [LinqRewrite]
		public int EnumerableCount2Rewritten()
        {
            return EnumerableItems.Count();
        } //EndMethod


        public int EnumerableCount3()
        {
            return EnumerableItems.Count(x => x > 3);
        } //EndMethod

        [LinqRewrite]
		public int EnumerableCount3Rewritten()
        {
            return EnumerableItems.Count(x => x > 3);
        } //EndMethod


        public int EnumerableCount4()
        {
            return ArrayItems.Select(x => x + 10).Count();
        } //EndMethod

        [LinqRewrite]
		public int EnumerableCount4Rewritten()
        {
            return ArrayItems.Select(x => x + 10).Count();
        } //EndMethod


        public int EnumerableCount5()
        {
            return ArrayItems.Where(x => x > 4).Count(x => x % 2 == 0);
        } //EndMethod

        [LinqRewrite]
		public int EnumerableCount5Rewritten()
        {
            return ArrayItems.Where(x => x > 4).Count(x => x % 2 == 0);
        } //EndMethod


        public int RangeCount()
        {
            return Enumerable.Range(5, 256).Count();
        } //EndMethod

        [LinqRewrite]
		public int RangeCountRewritten()
        {
            return Enumerable.Range(5, 256).Count();
        } //EndMethod


        public int RangeSelectCount()
        {
            return Enumerable.Range(5, 256).Select(x => x + 3).Count();
        } //EndMethod

        [LinqRewrite]
		public int RangeSelectCountRewritten()
        {
            return Enumerable.Range(5, 256).Select(x => x + 3).Count();
        } //EndMethod


        public int RangeWhereCount()
        {
            return Enumerable.Range(5, 256).Where(x => x > 100).Count();
        } //EndMethod

        [LinqRewrite]
		public int RangeWhereCountRewritten()
        {
            return Enumerable.Range(5, 256).Where(x => x > 100).Count();
        } //EndMethod


        public int RangeCount2()
        {
            return Enumerable.Range(5, 256).Count(x => x > 100);
        } //EndMethod

        [LinqRewrite]
		public int RangeCount2Rewritten()
        {
            return Enumerable.Range(5, 256).Count(x => x > 100);
        } //EndMethod


        public int RepeatCount()
        {
            return Enumerable.Repeat(5, 256).Count();
        } //EndMethod

        [LinqRewrite]
		public int RepeatCountRewritten()
        {
            return Enumerable.Repeat(5, 256).Count();
        } //EndMethod


        public int ArrayMethodCount()
        {
            return ArrayItems.Count(Predicate);
        } //EndMethod

        [LinqRewrite]
		public int ArrayMethodCountRewritten()
        {
            return ArrayItems.Count(Predicate);
        } //EndMethod


        public int ArrayDistinctCount()
        {
            return ArrayItems.Distinct().Count();
        } //EndMethod

        [LinqRewrite]
		public int ArrayDistinctCountRewritten()
        {
            return ArrayItems.Distinct().Count();
        } //EndMethod


        public int EmptyCount()
        {
            return Enumerable.Empty<int>().Count();
        } //EndMethod

        [LinqRewrite]
		public int EmptyCountRewritten()
        {
            return Enumerable.Empty<int>().Count();
        } //EndMethod


        public int EmptyDistinctCount()
        {
            return Enumerable.Empty<int>().Distinct().Count();
        } //EndMethod

        [LinqRewrite]
		public int EmptyDistinctCountRewritten()
        {
            return Enumerable.Empty<int>().Distinct().Count();
        } //EndMethod

    }
}