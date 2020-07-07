using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class AllBenchmarks
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
        public void ArrayAllCondition()
        {
            var res = ArraySource.All(x => x > 3);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void ArrayAllConditionRewritten()
        {
            var res = ArraySource.All(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereAllCondition()
        {
            var res = ArraySource.Where(x => x > 100).All(x => x > 200);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void ArrayWhereAllConditionRewritten()
        {
            var res = ArraySource.Where(x => x > 100).All(x => x > 200);
        }//EndMethod

        [Benchmark]
        public void EnumerableAllCondition()
        {
            var res = EnumerableSource.All(x => x > 3);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void EnumerableAllConditionRewritten()
        {
            var res = EnumerableSource.All(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void EnumerableAllNotCondition()
        {
            var res = EnumerableSource.All(x => x > 10_000);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void EnumerableAllNotConditionRewritten()
        {
            var res = EnumerableSource.All(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public void EnumerableAllAllCondition()
        {
            var res = EnumerableSource.All(x => x > 0);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void EnumerableAllAllConditionRewritten()
        {
            var res = EnumerableSource.All(x => x > 0);
        }//EndMethod
    }
}