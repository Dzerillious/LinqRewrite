using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class FirstBenchmarks
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
        public int ArrayFirst()
        {
            return ArraySource.First();
        }//EndMethod

		[Benchmark]
        [LinqRewrite]
		public int ArrayFirstRewritten()
        {
            return ArraySource.First();
        }//EndMethod

        [Benchmark]
        public int ArrayFirstCondition()
        {
            return ArraySource.First(x => x > 3);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int ArrayFirstConditionRewritten()
        {
            return ArraySource.First(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int ArraySelectFirst()
        {
            return ArraySource.Select(x => x + 3).First();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int ArraySelectFirstRewritten()
        {
            return ArraySource.Select(x => x + 3).First();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereFirst()
        {
            return ArraySource.Where(x => x > 100).First();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int ArrayWhereFirstRewritten()
        {
            return ArraySource.Where(x => x > 100).First();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereFirstCondition()
        {
            return ArraySource.Where(x => x > 100).First(x => x > 200);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int ArrayWhereFirstConditionRewritten()
        {
            return ArraySource.Where(x => x > 100).First(x => x > 200);
        }//EndMethod

        [Benchmark]
        public int EnumerableFirstCondition()
        {
            return EnumerableSource.First(x => x > 3);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int EnumerableFirstConditionRewritten()
        {
            return EnumerableSource.First(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int EnumerableFirstNotCondition()
        {
            return EnumerableSource.First(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int EnumerableFirstNotConditionRewritten()
        {
            return EnumerableSource.First(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public int EnumerableFirstAllCondition()
        {
            return EnumerableSource.First(x => x > 0);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int EnumerableFirstAllConditionRewritten()
        {
            return EnumerableSource.First(x => x > 0);
        }//EndMethod
    }
}

