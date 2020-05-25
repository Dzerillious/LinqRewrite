using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class DistinctTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private int[] RepeatArrayItems = Enumerable.Repeat(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayDistinct), ArrayDistinct, ArrayDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDefaultComparerDistinct), ArrayDefaultComparerDistinct, ArrayDefaultComparerDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayStrangeComparerDistinct), ArrayStrangeComparerDistinct, ArrayStrangeComparerDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayRepeatDistinct), ArrayRepeatDistinct, ArrayRepeatDistinctRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableDistinct), EnumerableDistinct, EnumerableDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectDistinct), ArraySelectDistinct, ArraySelectDistinctRewritten);
            TestsExtensions.TestEquals(nameof(RepeatArraySelectDistinct), RepeatArraySelectDistinct, RepeatArraySelectDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereSelectDistinct), ArrayWhereSelectDistinct, ArrayWhereSelectDistinctRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableDistinctToArray), EnumerableDistinctToArray, EnumerableDistinctToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctToArray), ArrayDistinctToArray, ArrayDistinctToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctToSimpleList), ArrayDistinctToSimpleList, ArrayDistinctToSimpleListRewritten);
        }

        [NoRewrite]
        public IEnumerable<int> ArrayDistinct()
        {
            return ArrayItems.Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayDistinctRewritten()
        {
            return ArrayItems.Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDefaultComparerDistinct()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayDefaultComparerDistinctRewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayStrangeComparerDistinct()
        {
            return ArrayItems.Distinct(new IntStrangeComparer());
        } //EndMethod

        public IEnumerable<int> ArrayStrangeComparerDistinctRewritten()
        {
            return ArrayItems.Distinct(new IntStrangeComparer());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayRepeatDistinct()
        {
            return RepeatArrayItems.Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayRepeatDistinctRewritten()
        {
            return RepeatArrayItems.Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableDistinct()
        {
            return EnumerableItems.Distinct();
        } //EndMethod

        public IEnumerable<int> EnumerableDistinctRewritten()
        {
            return EnumerableItems.Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectDistinct()
        {
            return ArrayItems.Select(x => x % 2).Distinct();
        } //EndMethod

        public IEnumerable<int> ArraySelectDistinctRewritten()
        {
            return ArrayItems.Select(x => x % 2).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatArraySelectDistinct()
        {
            var a = 0;
            return ArrayItems.Select(x => x + a++ % 2).Distinct();
        } //EndMethod

        public IEnumerable<int> RepeatArraySelectDistinctRewritten()
        {
            var a = 0;
            return ArrayItems.Select(x => x + a++ % 2).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereSelectDistinct()
        {
            return ArrayItems.Where(x => x > 50).Select(x => x % 10).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayWhereSelectDistinctRewritten()
        {
            return ArrayItems.Where(x => x > 50).Select(x => x % 10).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableDistinctToArray()
        {
            return EnumerableItems.Distinct().ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableDistinctToArrayRewritten()
        {
            return EnumerableItems.Distinct().ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctToArray()
        {
            return ArrayItems.Select(x => x % 10).Distinct().ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayDistinctToArrayRewritten()
        {
            return ArrayItems.Select(x => x % 10).Distinct().ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctToSimpleList()
        {
            return ArrayItems.Select(x => x % 10).Distinct().ToSimpleList();
        } //EndMethod

        public IEnumerable<int> ArrayDistinctToSimpleListRewritten()
        {
            return ArrayItems.Select(x => x % 10).Distinct().ToSimpleList();
        } //EndMethod

    }
}