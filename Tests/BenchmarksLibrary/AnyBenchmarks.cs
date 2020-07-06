using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class AnyBenchmarks
    {
        public static int[] StaticArraySource;
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;
        public int Selector(int a) => a + 3;

        [GlobalSetup]
        public void GlobalSetup()
        {
            StaticArraySource = Enumerable.Range(0, 1000).ToArray();
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            EnumerableSource = Enumerable.Range(0, 1000);
        }

        [Benchmark]
        public bool ArrayAny()
        {
            return ArraySource.Any();
        }//EndMethod

		[Benchmark]
        [LinqRewrite]
		public bool ArrayAnyRewritten()
        {
            return ArraySource.Any();
        }//EndMethod

        [Benchmark]
        public bool ArrayAnyCondition()
        {
            return ArraySource.Any(x => x > 3);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public bool ArrayAnyConditionRewritten()
        {
            return ArraySource.Any(x => x > 3);
        }//EndMethod

        [Benchmark]
        public bool ArraySelectAny()
        {
            return ArraySource.Select(x => x + 3).Any();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public bool ArraySelectAnyRewritten()
        {
            return ArraySource.Select(x => x + 3).Any();
        }//EndMethod

        [Benchmark]
        public bool ArrayWhereAny()
        {
            return ArraySource.Where(x => x > 100).Any();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public bool ArrayWhereAnyRewritten()
        {
            return ArraySource.Where(x => x > 100).Any();
        }//EndMethod

        [Benchmark]
        public bool ArrayWhereAnyCondition()
        {
            return ArraySource.Where(x => x > 100).Any(x => x > 200);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public bool ArrayWhereAnyConditionRewritten()
        {
            return ArraySource.Where(x => x > 100).Any(x => x > 200);
        }//EndMethod

        [Benchmark]
        public bool EnumerableAnyCondition()
        {
            return EnumerableSource.Any(x => x > 3);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public bool EnumerableAnyConditionRewritten()
        {
            return EnumerableSource.Any(x => x > 3);
        }//EndMethod

        [Benchmark]
        public bool EnumerableAnyNotCondition()
        {
            return EnumerableSource.Any(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public bool EnumerableAnyNotConditionRewritten()
        {
            return EnumerableSource.Any(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public bool EnumerableAnyAllCondition()
        {
            return EnumerableSource.Any(x => x > 0);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public bool EnumerableAnyAllConditionRewritten()
        {
            return EnumerableSource.Any(x => x > 0);
        }//EndMethod
    }
}

