using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class ForEachBenchmarks
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
        public int ArrayForEachSum()
        {
            var sum = 0;
            ArraySource.ForEach(x => sum += x);
            return sum;
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int ArrayForEachSumRewritten()
        {
            var sum = 0;
            ArraySource.ForEach(x => sum += x);
            return sum;
        }//EndMethod

        [Benchmark]
        public int EnumerableForEachSum()
        {
            var sum = 0;
            EnumerableSource.ForEach(x => sum += x);
            return sum;
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int EnumerableForEachSumRewritten()
        {
            var sum = 0;
            EnumerableSource.ForEach(x => sum += x);
            return sum;
        }//EndMethod

        [Benchmark]
        public int ArrayWhereforeachSum()
        {
            var sum = 0;
            foreach (var i in EnumerableSource.Where(x => x > 3))
            {
                sum += i;
            }
            return sum;
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int ArrayWhereforeachSumRewritten()
        {
            var sum = 0;
            foreach (var i in ArraySource.Where(x => x > 3))
            {
                sum += i;
            }
            return sum;
        }//EndMethod

        [Benchmark]
        public int EnumerableWhereforeachSum()
        {
            var sum = 0;
            foreach (var i in EnumerableSource.Where(x => x > 3))
            {
                sum += i;
            }
            return sum;
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public int EnumerableWhereforeachSumRewritten()
        {
            var sum = 0;
            foreach (var i in EnumerableSource.Where(x => x > 3))
            {
                sum += i;
            }
            return sum;
        }//EndMethod
    }
}