using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class LastOrDefaultBenchmarks
    {
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            EnumerableSource = Enumerable.Range(0, 1000);
        }

        [Benchmark]
        public int ArrayLastOrDefault()
        {
            return ArraySource.LastOrDefault();
        }//EndMethod

		[Benchmark]
        [LinqRewrite]
		public int ArrayLastOrDefaultRewritten()
        {
            return ArraySource.LastOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArrayLastOrDefaultCondition()
        {
            return ArraySource.LastOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int ArrayLastOrDefaultConditionRewritten()
        {
            return ArraySource.LastOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int ArraySelectLastOrDefault()
        {
            return ArraySource.Select(x => x + 3).LastOrDefault();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int ArraySelectLastOrDefaultRewritten()
        {
            return ArraySource.Select(x => x + 3).LastOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereLastOrDefault()
        {
            return ArraySource.Where(x => x > 100).LastOrDefault();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int ArrayWhereLastOrDefaultRewritten()
        {
            return ArraySource.Where(x => x > 100).LastOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereLastOrDefaultCondition()
        {
            return ArraySource.Where(x => x > 100).LastOrDefault(x => x > 200);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int ArrayWhereLastOrDefaultConditionRewritten()
        {
            return ArraySource.Where(x => x > 100).LastOrDefault(x => x > 200);
        }//EndMethod

        [Benchmark]
        public int EnumerableLastOrDefaultCondition()
        {
            return EnumerableSource.LastOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int EnumerableLastOrDefaultConditionRewritten()
        {
            return EnumerableSource.LastOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int EnumerableLastOrDefaultNotCondition()
        {
            return EnumerableSource.LastOrDefault(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int EnumerableLastOrDefaultNotConditionRewritten()
        {
            return EnumerableSource.LastOrDefault(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public int EnumerableLastOrDefaultAllCondition()
        {
            return EnumerableSource.LastOrDefault(x => x > 0);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int EnumerableLastOrDefaultAllConditionRewritten()
        {
            return EnumerableSource.LastOrDefault(x => x > 0);
        }//EndMethod
    }
}

