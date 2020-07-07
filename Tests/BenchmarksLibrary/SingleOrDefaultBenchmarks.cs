using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class SingleOrDefaultBenchmarks
    {
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(0, 1).ToArray();
            EnumerableSource = Enumerable.Range(0, 1);
        }

        [Benchmark]
        public int ArraySingleOrDefault()
        {
            return ArraySource.SingleOrDefault();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public int ArraySingleOrDefaultRewritten()
        {
            return ArraySource.SingleOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArraySingleOrDefaultCondition()
        {
            return ArraySource.SingleOrDefault(x => x >= 0);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int ArraySingleOrDefaultConditionRewritten()
        {
            return ArraySource.SingleOrDefault(x => x >= 0);
        }//EndMethod

        [Benchmark]
        public int ArraySelectSingleOrDefault()
        {
            return ArraySource.Select(x => x + 3).SingleOrDefault();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int ArraySelectSingleOrDefaultRewritten()
        {
            return ArraySource.Select(x => x + 3).SingleOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereSingleOrDefault()
        {
            return ArraySource.Where(x => x >= 0).SingleOrDefault();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int ArrayWhereSingleOrDefaultRewritten()
        {
            return ArraySource.Where(x => x >= 0).SingleOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereSingleOrDefaultCondition()
        {
            return ArraySource.Where(x => x >= 0).SingleOrDefault(x => x >= 0);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int ArrayWhereSingleOrDefaultConditionRewritten()
        {
            return ArraySource.Where(x => x >= 0).SingleOrDefault(x => x >= 0);
        }//EndMethod

        [Benchmark]
        public int EnumerableSingleOrDefaultCondition()
        {
            return EnumerableSource.SingleOrDefault(x => x >= 0);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int EnumerableSingleOrDefaultConditionRewritten()
        {
            return EnumerableSource.SingleOrDefault(x => x >= 0);
        }//EndMethod

        [Benchmark]
        public int EnumerableSingleOrDefaultNotCondition()
        {
            return EnumerableSource.SingleOrDefault(x => x >= 10);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int EnumerableSingleOrDefaultNotConditionRewritten()
        {
            return EnumerableSource.SingleOrDefault(x => x >= 10);
        }//EndMethod
    }
}

