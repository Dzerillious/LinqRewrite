using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace TestsLibrary.Tests
{
    public class EmptyTests
    {
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(Empty), Empty, EmptyRewritten);
            TestsExtensions.TestEquals(nameof(EmptyToArray), EmptyToArray, EmptyToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EmptyToList), EmptyToList, EmptyToListRewritten);
            TestsExtensions.TestEquals(nameof(EmptyToSimpleList), EmptyToSimpleList, EmptyToSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(EmptySelect), EmptySelect, EmptySelectRewritten);
            TestsExtensions.TestEquals(nameof(EmptyWhere), EmptyWhere, EmptyWhereRewritten);
            TestsExtensions.TestEquals(nameof(EmptyDistinct), EmptyDistinct, EmptyDistinctRewritten);
            TestsExtensions.TestEquals(nameof(EmptyCount), EmptyCount, EmptyCountRewritten);
            TestsExtensions.TestEquals(nameof(EmptyContains), EmptyContains, EmptyContainsRewritten);
            TestsExtensions.TestEquals(nameof(EmptyCast), EmptyCast, EmptyCastRewritten);
            TestsExtensions.TestEquals(nameof(EmptyAny), EmptyAny, EmptyAnyRewritten);
            TestsExtensions.TestEquals(nameof(EmptyAggregateDefault), EmptyAggregateDefault, EmptyAggregateDefaultRewritten);
            TestsExtensions.TestEquals(nameof(EmptyAggregate), EmptyAggregate, EmptyAggregateRewritten);
            TestsExtensions.TestEquals(nameof(EmptyAverage), EmptyAverage, EmptyAverageRewritten);
        }

        public IEnumerable<int> Empty()
        {
            return Enumerable.Empty<int>();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EmptyRewritten()
        {
            return Enumerable.Empty<int>();
        } //EndMethod


        public IEnumerable<int> EmptyToArray()
        {
            return Enumerable.Empty<int>().ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EmptyToArrayRewritten()
        {
            return Enumerable.Empty<int>().ToArray();
        } //EndMethod


        public IEnumerable<int> EmptyToList()
        {
            return Enumerable.Empty<int>().ToList();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EmptyToListRewritten()
        {
            return Enumerable.Empty<int>().ToList();
        } //EndMethod


        public IEnumerable<int> EmptyToSimpleList()
        {
            return Enumerable.Empty<int>().ToSimpleList();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EmptyToSimpleListRewritten()
        {
            return Enumerable.Empty<int>().ToSimpleList();
        } //EndMethod


        public IEnumerable<int> EmptySelect()
        {
            return Enumerable.Empty<int>().Select(x => x + 3);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EmptySelectRewritten()
        {
            return Enumerable.Empty<int>().Select(x => x + 3);
        } //EndMethod


        public IEnumerable<int> EmptyWhere()
        {
            return Enumerable.Empty<int>().Where(x => x > 3);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EmptyWhereRewritten()
        {
            return Enumerable.Empty<int>().Where(x => x > 3);
        } //EndMethod


        public IEnumerable<int> EmptyDistinct()
        {
            return Enumerable.Empty<int>().Distinct();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EmptyDistinctRewritten()
        {
            return Enumerable.Empty<int>().Distinct();
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


        public bool EmptyContains()
        {
            return Enumerable.Empty<int>().Contains(23);
        } //EndMethod

        [LinqRewrite]
		public bool EmptyContainsRewritten()
        {
            return Enumerable.Empty<int>().Contains(23);
        } //EndMethod


        public IEnumerable<float> EmptyCast()
        {
            return Enumerable.Empty<int>().Cast<float>();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<float> EmptyCastRewritten()
        {
            return Enumerable.Empty<int>().Cast<float>();
        } //EndMethod


        public bool EmptyAny()
        {
            return Enumerable.Empty<int>().Any();
        } //EndMethod

        [LinqRewrite]
		public bool EmptyAnyRewritten()
        {
            return Enumerable.Empty<int>().Any();
        } //EndMethod


        public double EmptyAggregateDefault()
        {
            return Enumerable.Empty<int>().Aggregate(1.0, (x, y) => x + y);
        } //EndMethod

        [LinqRewrite]
		public double EmptyAggregateDefaultRewritten()
        {
            return Enumerable.Empty<int>().Aggregate(1.0, (x, y) => x + y);
        } //EndMethod


        public double EmptyAggregate()
        {
            return Enumerable.Empty<int>().Aggregate((x, y) => x + y);
        } //EndMethod

        [LinqRewrite]
		public double EmptyAggregateRewritten()
        {
            return Enumerable.Empty<int>().Aggregate((x, y) => x + y);
        } //EndMethod


        public double EmptyAverage()
        {
            return Enumerable.Empty<int>().Average();
        } //EndMethod

        [LinqRewrite]
		public double EmptyAverageRewritten()
        {
            return Enumerable.Empty<int>().Average();
        } //EndMethod

    }
}