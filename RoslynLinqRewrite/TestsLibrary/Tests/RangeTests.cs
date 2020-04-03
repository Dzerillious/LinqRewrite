using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace TestsLibrary.Tests
{
    public class RangeTests
    {
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(Range1), Range1, Range1Rewritten);
            TestsExtensions.TestEquals(nameof(Range2), Range2, Range2Rewritten);
            TestsExtensions.TestEquals(nameof(Range3), Range3, Range3Rewritten);
            TestsExtensions.TestEquals(nameof(Range4), Range4, Range4Rewritten);
            TestsExtensions.TestEquals(nameof(RangeToArray), RangeToArray, RangeToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeToList), RangeToList, RangeToListRewritten);
            TestsExtensions.TestEquals(nameof(RangeToSimpleList), RangeToSimpleList, RangeToSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(RangeDistinct), RangeDistinct, RangeDistinctRewritten);
        }

        [NoRewrite]
        public IEnumerable<int> Range1()
        {
            return Enumerable.Range(0, 100);
        } //EndMethod

        public IEnumerable<int> Range1Rewritten()
        {
            return Enumerable.Range(0, 100);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> Range2()
        {
            return Enumerable.Range(-100, 100);
        } //EndMethod

        public IEnumerable<int> Range2Rewritten()
        {
            return Enumerable.Range(-100, 100);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> Range3()
        {
            return Enumerable.Range(0, -100);
        } //EndMethod

        public IEnumerable<int> Range3Rewritten()
        {
            return Enumerable.Range(0, -100);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> Range4()
        {
            return Enumerable.Range(123, 23);
        } //EndMethod

        public IEnumerable<int> Range4Rewritten()
        {
            return Enumerable.Range(123, 23);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeToArray()
        {
            return Enumerable.Range(123, 23).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeToArrayRewritten()
        {
            return Enumerable.Range(123, 23).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeToList()
        {
            return Enumerable.Range(123, 23).ToList();
        } //EndMethod

        public IEnumerable<int> RangeToListRewritten()
        {
            return Enumerable.Range(123, 23).ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeToSimpleList()
        {
            return Enumerable.Range(123, 23).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> RangeToSimpleListRewritten()
        {
            return Enumerable.Range(123, 23).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeDistinct()
        {
            return Enumerable.Range(123, 23).Distinct();
        } //EndMethod

        public IEnumerable<int> RangeDistinctRewritten()
        {
            return Enumerable.Range(123, 23).Distinct();
        } //EndMethod

    }
}