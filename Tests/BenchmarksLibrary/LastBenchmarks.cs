using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class LastBenchmarks
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
        public int ArrayLast()
        {
            return ArraySource.Last();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public int ArrayLastRewritten()
        {
            return ArraySource.Last();
        }//EndMethod

        [Benchmark]
        public int ArrayLastCondition()
        {
            return ArraySource.Last(x => x > 3);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int ArrayLastConditionRewritten()
        {
            return ArraySource.Last(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int ArraySelectLast()
        {
            return ArraySource.Select(x => x + 3).Last();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int ArraySelectLastRewritten()
        {
            return ArraySource.Select(x => x + 3).Last();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereLast()
        {
            return ArraySource.Where(x => x > 100).Last();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int ArrayWhereLastRewritten()
        {
            return ArraySource.Where(x => x > 100).Last();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereLastCondition()
        {
            return ArraySource.Where(x => x > 100).Last(x => x > 200);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int ArrayWhereLastConditionRewritten()
        {
            return ArraySource.Where(x => x > 100).Last(x => x > 200);
        }//EndMethod

        [Benchmark]
        public int EnumerableLastCondition()
        {
            return EnumerableSource.Last(x => x > 3);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int EnumerableLastConditionRewritten()
        {
            return EnumerableSource.Last(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int EnumerableLastNotCondition()
        {
            return EnumerableSource.Last(x => x > 10_000);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int EnumerableLastNotConditionRewritten()
        {
            return EnumerableSource.Last(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public int EnumerableLastAllCondition()
        {
            return EnumerableSource.Last(x => x > 0);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int EnumerableLastAllConditionRewritten()
        {
            return EnumerableSource.Last(x => x > 0);
        }//EndMethod
    }
}

