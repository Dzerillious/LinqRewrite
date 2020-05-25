using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class LongCountTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int i) => i > 50;

        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayLongCount), ArrayLongCount, ArrayLongCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLongCount2), ArrayLongCount2, ArrayLongCount2Rewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectLongCount), ArraySelectLongCount, ArraySelectLongCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayLongCount5), ArrayLongCount5, ArrayLongCount5Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableLongCount2), EnumerableLongCount2, EnumerableLongCount2Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableLongCount3), EnumerableLongCount3, EnumerableLongCount3Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableLongCount4), EnumerableLongCount4, EnumerableLongCount4Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableLongCount5), EnumerableLongCount5, EnumerableLongCount5Rewritten);
            TestsExtensions.TestEquals(nameof(RangeLongCount), RangeLongCount, RangeLongCountRewritten);
            TestsExtensions.TestEquals(nameof(RangeSelectLongCount), RangeSelectLongCount, RangeSelectLongCountRewritten);
            TestsExtensions.TestEquals(nameof(RangeWhereLongCount), RangeWhereLongCount, RangeWhereLongCountRewritten);
            TestsExtensions.TestEquals(nameof(RangeLongCount2), RangeLongCount2, RangeLongCount2Rewritten);
            TestsExtensions.TestEquals(nameof(RepeatLongCount), RepeatLongCount, RepeatLongCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayMethodLongCount), ArrayMethodLongCount, ArrayMethodLongCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctLongCount), ArrayDistinctLongCount, ArrayDistinctLongCountRewritten);
            TestsExtensions.TestEquals(nameof(EmptyLongCount), EmptyLongCount, EmptyLongCountRewritten);
            TestsExtensions.TestEquals(nameof(EmptyDistinctLongCount), EmptyDistinctLongCount, EmptyDistinctLongCountRewritten);
        }

        [NoRewrite]
        public long ArrayLongCount()
        {
            return ArrayItems.LongCount();
        } //EndMethod

        public long ArrayLongCountRewritten()
        {
            return ArrayItems.LongCount();
        } //EndMethod=


        [NoRewrite]
        public long ArrayLongCount2()
        {
            return ArrayItems.LongCount(x => x > 3);
        } //EndMethod

        public long ArrayLongCount2Rewritten()
        {
            return ArrayItems.LongCount(x => x > 3);
        } //EndMethod


        [NoRewrite]
        public long ArraySelectLongCount()
        {
            return ArrayItems.Select(x => x + 10).LongCount();
        } //EndMethod

        public long ArraySelectLongCountRewritten()
        {
            return ArrayItems.Select(x => x + 10).LongCount();
        } //EndMethod


        [NoRewrite]
        public long ArrayLongCount5()
        {
            return ArrayItems.Where(x => x > 4).LongCount(x => x % 2 == 0);
        } //EndMethod

        public long ArrayLongCount5Rewritten()
        {
            return ArrayItems.Where(x => x > 4).LongCount(x => x % 2 == 0);
        } //EndMethod


        [NoRewrite]
        public long EnumerableLongCount2()
        {
            return EnumerableItems.LongCount();
        } //EndMethod

        public long EnumerableLongCount2Rewritten()
        {
            return EnumerableItems.LongCount();
        } //EndMethod


        [NoRewrite]
        public long EnumerableLongCount3()
        {
            return EnumerableItems.LongCount(x => x > 3);
        } //EndMethod

        public long EnumerableLongCount3Rewritten()
        {
            return EnumerableItems.LongCount(x => x > 3);
        } //EndMethod


        [NoRewrite]
        public long EnumerableLongCount4()
        {
            return ArrayItems.Select(x => x + 10).LongCount();
        } //EndMethod

        public long EnumerableLongCount4Rewritten()
        {
            return ArrayItems.Select(x => x + 10).LongCount();
        } //EndMethod


        [NoRewrite]
        public long EnumerableLongCount5()
        {
            return ArrayItems.Where(x => x > 4).LongCount(x => x % 2 == 0);
        } //EndMethod

        public long EnumerableLongCount5Rewritten()
        {
            return ArrayItems.Where(x => x > 4).LongCount(x => x % 2 == 0);
        } //EndMethod


        [NoRewrite]
        public long RangeLongCount()
        {
            return Enumerable.Range(5, 256).LongCount();
        } //EndMethod

        public long RangeLongCountRewritten()
        {
            return Enumerable.Range(5, 256).LongCount();
        } //EndMethod


        [NoRewrite]
        public long RangeSelectLongCount()
        {
            return Enumerable.Range(5, 256).Select(x => x + 3).LongCount();
        } //EndMethod

        public long RangeSelectLongCountRewritten()
        {
            return Enumerable.Range(5, 256).Select(x => x + 3).LongCount();
        } //EndMethod


        [NoRewrite]
        public long RangeWhereLongCount()
        {
            return Enumerable.Range(5, 256).Where(x => x > 100).LongCount();
        } //EndMethod

        public long RangeWhereLongCountRewritten()
        {
            return Enumerable.Range(5, 256).Where(x => x > 100).LongCount();
        } //EndMethod


        [NoRewrite]
        public long RangeLongCount2()
        {
            return Enumerable.Range(5, 256).LongCount(x => x > 100);
        } //EndMethod

        public long RangeLongCount2Rewritten()
        {
            return Enumerable.Range(5, 256).LongCount(x => x > 100);
        } //EndMethod


        [NoRewrite]
        public long RepeatLongCount()
        {
            return Enumerable.Repeat(5, 256).LongCount();
        } //EndMethod

        public long RepeatLongCountRewritten()
        {
            return Enumerable.Repeat(5, 256).LongCount();
        } //EndMethod


        [NoRewrite]
        public long ArrayMethodLongCount()
        {
            return ArrayItems.LongCount(Predicate);
        } //EndMethod

        public long ArrayMethodLongCountRewritten()
        {
            return ArrayItems.LongCount(Predicate);
        } //EndMethod


        [NoRewrite]
        public long ArrayDistinctLongCount()
        {
            return ArrayItems.Distinct().LongCount();
        } //EndMethod

        public long ArrayDistinctLongCountRewritten()
        {
            return ArrayItems.Distinct().LongCount();
        } //EndMethod


        [NoRewrite]
        public long EmptyLongCount()
        {
            return Enumerable.Empty<int>().LongCount();
        } //EndMethod

        public long EmptyLongCountRewritten()
        {
            return Enumerable.Empty<int>().LongCount();
        } //EndMethod


        [NoRewrite]
        public long EmptyDistinctLongCount()
        {
            return Enumerable.Empty<int>().Distinct().LongCount();
        } //EndMethod

        public long EmptyDistinctLongCountRewritten()
        {
            return Enumerable.Empty<int>().Distinct().LongCount();
        } //EndMethod

    }
}