using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace TestsLibrary.Tests
{
    public class RepeatTests
    {
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(Repeat1), Repeat1, Repeat1Rewritten);
            TestsExtensions.TestEquals(nameof(Repeat2), Repeat2, Repeat2Rewritten);
            TestsExtensions.TestEquals(nameof(Repeat3), Repeat3, Repeat3Rewritten);
            TestsExtensions.TestEquals(nameof(Repeat4), Repeat4, Repeat4Rewritten);
            TestsExtensions.TestEquals(nameof(RepeatToArray), RepeatToArray, RepeatToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RepeatToList), RepeatToList, RepeatToListRewritten);
            TestsExtensions.TestEquals(nameof(RepeatToSimpleList), RepeatToSimpleList, RepeatToSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(RepeatDistinct), RepeatDistinct, RepeatDistinctRewritten);
        }

        [NoRewrite]
        public IEnumerable<int> Repeat1()
        {
            return Enumerable.Repeat(0, 100);
        } //EndMethod

        public IEnumerable<int> Repeat1Rewritten()
        {
            return Enumerable.Repeat(0, 100);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> Repeat2()
        {
            return Enumerable.Repeat(-100, 100);
        } //EndMethod

        public IEnumerable<int> Repeat2Rewritten()
        {
            return Enumerable.Repeat(-100, 100);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> Repeat3()
        {
            return Enumerable.Repeat(0, -100);
        } //EndMethod

        public IEnumerable<int> Repeat3Rewritten()
        {
            return Enumerable.Repeat(0, -100);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> Repeat4()
        {
            return Enumerable.Repeat(123, 23);
        } //EndMethod

        public IEnumerable<int> Repeat4Rewritten()
        {
            return Enumerable.Repeat(123, 23);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatToArray()
        {
            return Enumerable.Repeat(123, 23).ToArray();
        } //EndMethod

        public IEnumerable<int> RepeatToArrayRewritten()
        {
            return Enumerable.Repeat(123, 23).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatToList()
        {
            return Enumerable.Repeat(123, 23).ToList();
        } //EndMethod

        public IEnumerable<int> RepeatToListRewritten()
        {
            return Enumerable.Repeat(123, 23).ToList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatToSimpleList()
        {
            return Enumerable.Repeat(123, 23).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> RepeatToSimpleListRewritten()
        {
            return Enumerable.Repeat(123, 23).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatDistinct()
        {
            return Enumerable.Repeat(123, 23).Distinct();
        } //EndMethod

        public IEnumerable<int> RepeatDistinctRewritten()
        {
            return Enumerable.Repeat(123, 23).Distinct();
        } //EndMethod

    }
}