using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class TakeTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int value) => value > 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayTake), ArrayTake, ArrayTakeRewritten);
            TestsExtensions.TestEquals(nameof(ArrayTake0), ArrayTake0, ArrayTake0Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayTakeM1), ArrayTakeM1, ArrayTakeM1Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayTake1000), ArrayTake1000, ArrayTake1000Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayTakeParam), ArrayTakeParam, ArrayTakeParamRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTake), EnumerableTake, EnumerableTakeRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTake0), EnumerableTake0, EnumerableTake0Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTakeM1), EnumerableTakeM1, EnumerableTakeM1Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTake1000), EnumerableTake1000, EnumerableTake1000Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTakeParam), EnumerableTakeParam, EnumerableTakeParamRewritten);
            TestsExtensions.TestEquals(nameof(RangeTake), RangeTake, RangeTakeRewritten);
            TestsExtensions.TestEquals(nameof(RangeTake0), RangeTake0, RangeTake0Rewritten);
            TestsExtensions.TestEquals(nameof(RangeTakeM1), RangeTakeM1, RangeTakeM1Rewritten);
            TestsExtensions.TestEquals(nameof(RangeTake1000), RangeTake1000, RangeTake1000Rewritten);
            TestsExtensions.TestEquals(nameof(RangeTakeParam), RangeTakeParam, RangeTakeParamRewritten);
            TestsExtensions.TestEquals(nameof(RepeatTake), RepeatTake, RepeatTakeRewritten);
            TestsExtensions.TestEquals(nameof(RepeatTake0), RepeatTake0, RepeatTake0Rewritten);
            TestsExtensions.TestEquals(nameof(RepeatTakeM1), RepeatTakeM1, RepeatTakeM1Rewritten);
            TestsExtensions.TestEquals(nameof(RepeatTake1000), RepeatTake1000, RepeatTake1000Rewritten);
            TestsExtensions.TestEquals(nameof(RepeatTakeParam), RepeatTakeParam, RepeatTakeParamRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectTakeToArray), ArraySelectTakeToArray, ArraySelectTakeToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectTakeM1ToArray), ArraySelectTakeM1ToArray, ArraySelectTakeM1ToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereTakeToArray), ArrayWhereTakeToArray, ArrayWhereTakeToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereFalseTakeToArray), ArrayWhereFalseTakeToArray, ArrayWhereFalseTakeToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayTakeToArray), ArrayTakeToArray, ArrayTakeToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTakeToArray), EnumerableTakeToArray, EnumerableTakeToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeTakeToArray), RangeTakeToArray, RangeTakeToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RepeatTakeToArray), RepeatTakeToArray, RepeatTakeToArrayRewritten);
        }

        public IEnumerable<int> ArrayTake()
        {
            return ArrayItems.Take(20);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayTakeRewritten()
        {
            return ArrayItems.Take(20);
        } //EndMethod


        public IEnumerable<int> ArrayTake0()
        {
            return ArrayItems.Take(0);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayTake0Rewritten()
        {
            return ArrayItems.Take(0);
        } //EndMethod


        public IEnumerable<int> ArrayTakeM1()
        {
            return ArrayItems.Take(-1);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayTakeM1Rewritten()
        {
            return ArrayItems.Take(-1);
        } //EndMethod


        public IEnumerable<int> ArrayTake1000()
        {
            return ArrayItems.Take(1000);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayTake1000Rewritten()
        {
            return ArrayItems.Take(1000);
        } //EndMethod


        public IEnumerable<int> ArrayTakeParam()
        {
            var a = 50;
            return ArrayItems.Take(a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayTakeParamRewritten()
        {
            var a = 50;
            return ArrayItems.Take(a);
        } //EndMethod


        public IEnumerable<int> EnumerableTake()
        {
            return EnumerableItems.Take(20);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableTakeRewritten()
        {
            return EnumerableItems.Take(20);
        } //EndMethod


        public IEnumerable<int> EnumerableTake0()
        {
            return EnumerableItems.Take(0);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableTake0Rewritten()
        {
            return EnumerableItems.Take(0);
        } //EndMethod


        public IEnumerable<int> EnumerableTakeM1()
        {
            return EnumerableItems.Take(-1);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableTakeM1Rewritten()
        {
            return EnumerableItems.Take(-1);
        } //EndMethod


        public IEnumerable<int> EnumerableTake1000()
        {
            return EnumerableItems.Take(1000);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableTake1000Rewritten()
        {
            return EnumerableItems.Take(1000);
        } //EndMethod


        public IEnumerable<int> EnumerableTakeParam()
        {
            var a = 50;
            return EnumerableItems.Take(a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableTakeParamRewritten()
        {
            var a = 50;
            return EnumerableItems.Take(a);
        } //EndMethod


        public IEnumerable<int> RangeTake()
        {
            return Enumerable.Range(0, 100).Take(20);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeTakeRewritten()
        {
            return Enumerable.Range(0, 100).Take(20);
        } //EndMethod


        public IEnumerable<int> RangeTake0()
        {
            return Enumerable.Range(0, 100).Take(0);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeTake0Rewritten()
        {
            return Enumerable.Range(0, 100).Take(0);
        } //EndMethod


        public IEnumerable<int> RangeTakeM1()
        {
            return Enumerable.Range(0, 100).Take(-1);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeTakeM1Rewritten()
        {
            return Enumerable.Range(0, 100).Take(-1);
        } //EndMethod


        public IEnumerable<int> RangeTake1000()
        {
            return Enumerable.Range(0, 100).Take(1000);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeTake1000Rewritten()
        {
            return Enumerable.Range(0, 100).Take(1000);
        } //EndMethod


        public IEnumerable<int> RangeTakeParam()
        {
            var a = 50;
            return Enumerable.Range(0, 100).Take(a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeTakeParamRewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).Take(a);
        } //EndMethod


        public IEnumerable<int> RepeatTake()
        {
            return Enumerable.Repeat(0, 100).Take(20);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatTakeRewritten()
        {
            return Enumerable.Repeat(0, 100).Take(20);
        } //EndMethod


        public IEnumerable<int> RepeatTake0()
        {
            return Enumerable.Repeat(0, 100).Take(0);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatTake0Rewritten()
        {
            return Enumerable.Repeat(0, 100).Take(0);
        } //EndMethod


        public IEnumerable<int> RepeatTakeM1()
        {
            return Enumerable.Repeat(0, 100).Take(-1);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatTakeM1Rewritten()
        {
            return Enumerable.Repeat(0, 100).Take(-1);
        } //EndMethod


        public IEnumerable<int> RepeatTake1000()
        {
            return Enumerable.Repeat(0, 100).Take(1000);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatTake1000Rewritten()
        {
            return Enumerable.Repeat(0, 100).Take(1000);
        } //EndMethod


        public IEnumerable<int> RepeatTakeParam()
        {
            var a = 50;
            return Enumerable.Repeat(0, 100).Take(a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatTakeParamRewritten()
        {
            var a = 50;
            return Enumerable.Repeat(0, 100).Take(a);
        } //EndMethod


        public IEnumerable<int> ArraySelectTakeToArray()
        {
            return ArrayItems.Select(x => x + 10).Take(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectTakeToArrayRewritten()
        {
            return ArrayItems.Select(x => x + 10).Take(20).ToArray();
        } //EndMethod


        public IEnumerable<int> ArraySelectTakeM1ToArray()
        {
            var m1 = -1;
            return ArrayItems.Select(x => x + 10).Take(m1).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectTakeM1ToArrayRewritten()
        {
            var m1 = -1;
            return ArrayItems.Select(x => x + 10).Take(m1).ToArray();
        } //EndMethod


        public IEnumerable<int> ArrayWhereTakeToArray()
        {
            return ArrayItems.Where(x => x > 20).Take(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayWhereTakeToArrayRewritten()
        {
            return ArrayItems.Where(x => x > 20).Take(20).ToArray();
        } //EndMethod


        public IEnumerable<int> ArrayWhereFalseTakeToArray()
        {
            return ArrayItems.Where(x => false).Take(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayWhereFalseTakeToArrayRewritten()
        {
            return ArrayItems.Where(x => false).Take(20).ToArray();
        } //EndMethod


        public IEnumerable<int> ArrayTakeToArray()
        {
            return ArrayItems.Take(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayTakeToArrayRewritten()
        {
            return ArrayItems.Take(20).ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableTakeToArray()
        {
            return EnumerableItems.Take(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableTakeToArrayRewritten()
        {
            return EnumerableItems.Take(20).ToArray();
        } //EndMethod


        public IEnumerable<int> RangeTakeToArray()
        {
            return Enumerable.Range(0, 100).Take(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeTakeToArrayRewritten()
        {
            return Enumerable.Range(0, 100).Take(20).ToArray();
        } //EndMethod


        public IEnumerable<int> RepeatTakeToArray()
        {
            return Enumerable.Repeat(0, 100).Take(20).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatTakeToArrayRewritten()
        {
            return Enumerable.Repeat(0, 100).Take(20).ToArray();
        } //EndMethod

    }
}