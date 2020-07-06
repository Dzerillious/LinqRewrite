using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class SkipTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int value) => value > 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArraySkip), ArraySkip, ArraySkipRewritten);
            TestsExtensions.TestEquals(nameof(ArraySkip0), ArraySkip0, ArraySkip0Rewritten);
            TestsExtensions.TestEquals(nameof(ArraySkipM1), ArraySkipM1, ArraySkipM1Rewritten);
            TestsExtensions.TestEquals(nameof(ArraySkip1000), ArraySkip1000, ArraySkip1000Rewritten);
            TestsExtensions.TestEquals(nameof(ArraySkipParam), ArraySkipParam, ArraySkipParamRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkip), EnumerableSkip, EnumerableSkipRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkip0), EnumerableSkip0, EnumerableSkip0Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkipM1), EnumerableSkipM1, EnumerableSkipM1Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkip1000), EnumerableSkip1000, EnumerableSkip1000Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkipParam), EnumerableSkipParam, EnumerableSkipParamRewritten);
            TestsExtensions.TestEquals(nameof(RangeSkip), RangeSkip, RangeSkipRewritten);
            TestsExtensions.TestEquals(nameof(RangeSkip0), RangeSkip0, RangeSkip0Rewritten);
            TestsExtensions.TestEquals(nameof(RangeSkipM1), RangeSkipM1, RangeSkipM1Rewritten);
            TestsExtensions.TestEquals(nameof(RangeSkip1000), RangeSkip1000, RangeSkip1000Rewritten);
            TestsExtensions.TestEquals(nameof(RangeSkipParam), RangeSkipParam, RangeSkipParamRewritten);
            TestsExtensions.TestEquals(nameof(RepeatSkip), RepeatSkip, RepeatSkipRewritten);
            TestsExtensions.TestEquals(nameof(RepeatSkip0), RepeatSkip0, RepeatSkip0Rewritten);
            TestsExtensions.TestEquals(nameof(RepeatSkipM1), RepeatSkipM1, RepeatSkipM1Rewritten);
            TestsExtensions.TestEquals(nameof(RepeatSkip1000), RepeatSkip1000, RepeatSkip1000Rewritten);
            TestsExtensions.TestEquals(nameof(RepeatSkipParam), RepeatSkipParam, RepeatSkipParamRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectSkipToArray), ArraySelectSkipToArray, ArraySelectSkipToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectSkipM1ToArray), ArraySelectSkipM1ToArray, ArraySelectSkipM1ToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereSkipToArray), ArrayWhereSkipToArray, ArrayWhereSkipToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereFalseSkipToArray), ArrayWhereFalseSkipToArray, ArrayWhereFalseSkipToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySkipToArray), ArraySkipToArray, ArraySkipToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkipToArray), EnumerableSkipToArray, EnumerableSkipToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeSkipToArray), RangeSkipToArray, RangeSkipToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RepeatSkipToArray), RepeatSkipToArray, RepeatSkipToArrayRewritten);
        }

        public IEnumerable<int> ArraySkip()
        {
            return ArrayItems.Skip(20);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipRewritten()
        {
            return ArrayItems.Skip(20);
        } //EndMethod


        public IEnumerable<int> ArraySkip0()
        {
            return ArrayItems.Skip(0);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkip0Rewritten()
        {
            return ArrayItems.Skip(0);
        } //EndMethod


        public IEnumerable<int> ArraySkipM1()
        {
            return ArrayItems.Skip(-1);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipM1Rewritten()
        {
            return ArrayItems.Skip(-1);
        } //EndMethod


        public IEnumerable<int> ArraySkip1000()
        {
            return ArrayItems.Skip(1000);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkip1000Rewritten()
        {
            return ArrayItems.Skip(1000);
        } //EndMethod


        public IEnumerable<int> ArraySkipParam()
        {
            var a = 50;
            return ArrayItems.Skip(a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipParamRewritten()
        {
            var a = 50;
            return ArrayItems.Skip(a);
        } //EndMethod


        public IEnumerable<int> EnumerableSkip()
        {
            return EnumerableItems.Skip(20);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipRewritten()
        {
            return EnumerableItems.Skip(20);
        } //EndMethod


        public IEnumerable<int> EnumerableSkip0()
        {
            return EnumerableItems.Skip(0);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkip0Rewritten()
        {
            return EnumerableItems.Skip(0);
        } //EndMethod


        public IEnumerable<int> EnumerableSkipM1()
        {
            return EnumerableItems.Skip(-1);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipM1Rewritten()
        {
            return EnumerableItems.Skip(-1);
        } //EndMethod


        public IEnumerable<int> EnumerableSkip1000()
        {
            return EnumerableItems.Skip(1000);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkip1000Rewritten()
        {
            return EnumerableItems.Skip(1000);
        } //EndMethod


        public IEnumerable<int> EnumerableSkipParam()
        {
            var a = 50;
            return EnumerableItems.Skip(a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipParamRewritten()
        {
            var a = 50;
            return EnumerableItems.Skip(a);
        } //EndMethod


        public IEnumerable<int> RangeSkip()
        {
            return Enumerable.Range(0, 100).Skip(20);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipRewritten()
        {
            return Enumerable.Range(0, 100).Skip(20);
        } //EndMethod


        public IEnumerable<int> RangeSkip0()
        {
            return Enumerable.Range(0, 100).Skip(0);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkip0Rewritten()
        {
            return Enumerable.Range(0, 100).Skip(0);
        } //EndMethod


        public IEnumerable<int> RangeSkipM1()
        {
            return Enumerable.Range(0, 100).Skip(-1);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipM1Rewritten()
        {
            return Enumerable.Range(0, 100).Skip(-1);
        } //EndMethod


        public IEnumerable<int> RangeSkip1000()
        {
            return Enumerable.Range(0, 100).Skip(1000);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkip1000Rewritten()
        {
            return Enumerable.Range(0, 100).Skip(1000);
        } //EndMethod


        public IEnumerable<int> RangeSkipParam()
        {
            var a = 50;
            return Enumerable.Range(0, 100).Skip(a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipParamRewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).Skip(a);
        } //EndMethod


        public IEnumerable<int> RepeatSkip()
        {
            return Enumerable.Repeat(0, 100).Skip(20);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatSkipRewritten()
        {
            return Enumerable.Repeat(0, 100).Skip(20);
        } //EndMethod


        public IEnumerable<int> RepeatSkip0()
        {
            return Enumerable.Repeat(0, 100).Skip(0);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatSkip0Rewritten()
        {
            return Enumerable.Repeat(0, 100).Skip(0);
        } //EndMethod


        public IEnumerable<int> RepeatSkipM1()
        {
            return Enumerable.Repeat(0, 100).Skip(-1);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatSkipM1Rewritten()
        {
            return Enumerable.Repeat(0, 100).Skip(-1);
        } //EndMethod


        public IEnumerable<int> RepeatSkip1000()
        {
            return Enumerable.Repeat(0, 100).Skip(1000);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatSkip1000Rewritten()
        {
            return Enumerable.Repeat(0, 100).Skip(1000);
        } //EndMethod


        public IEnumerable<int> RepeatSkipParam()
        {
            var a = 50;
            return Enumerable.Repeat(0, 100).Skip(a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatSkipParamRewritten()
        {
            var a = 50;
            return Enumerable.Repeat(0, 100).Skip(a);
        } //EndMethod


        public IEnumerable<int> ArraySelectSkipToArray()
        {
            return ArrayItems.Select(x => x + 10).Skip(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectSkipToArrayRewritten()
        {
            return ArrayItems.Select(x => x + 10).Skip(20).ToArray();
        } //EndMethod


        public IEnumerable<int> ArraySelectSkipM1ToArray()
        {
            return ArrayItems.Select(x => x + 10).Skip(-1).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectSkipM1ToArrayRewritten()
        {
            return ArrayItems.Select(x => x + 10).Skip(-1).ToArray();
        } //EndMethod


        public IEnumerable<int> ArrayWhereSkipToArray()
        {
            return ArrayItems.Where(x => x > 20).Skip(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayWhereSkipToArrayRewritten()
        {
            return ArrayItems.Where(x => x > 20).Skip(20).ToArray();
        } //EndMethod


        public IEnumerable<int> ArrayWhereFalseSkipToArray()
        {
            return ArrayItems.Where(x => false).Skip(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayWhereFalseSkipToArrayRewritten()
        {
            return ArrayItems.Where(x => false).Skip(20).ToArray();
        } //EndMethod


        public IEnumerable<int> ArraySkipToArray()
        {
            return ArrayItems.Skip(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipToArrayRewritten()
        {
            return ArrayItems.Skip(20).ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableSkipToArray()
        {
            return EnumerableItems.Skip(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipToArrayRewritten()
        {
            return EnumerableItems.Skip(20).ToArray();
        } //EndMethod


        public IEnumerable<int> RangeSkipToArray()
        {
            return Enumerable.Range(0, 100).Skip(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipToArrayRewritten()
        {
            return Enumerable.Range(0, 100).Skip(20).ToArray();
        } //EndMethod


        public IEnumerable<int> RepeatSkipToArray()
        {
            return Enumerable.Repeat(0, 100).Skip(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatSkipToArrayRewritten()
        {
            return Enumerable.Repeat(0, 100).Skip(20).ToArray();
        } //EndMethod

    }
}