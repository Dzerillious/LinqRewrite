using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class CountBenchmarks
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

        [NoRewrite, Benchmark]
        public void ArrayCount()
        {
            var res = ArraySource.Count();
        }//EndMethod

		[Benchmark]
        public void ArrayCountRewritten()
        {
            var res = ArraySource.Count();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayCountCondition()
        {
            var res = ArraySource.Count(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArrayCountConditionRewritten()
        {
            var res = ArraySource.Count(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySelectCount()
        {
            var res = ArraySource.Select(x => x + 3).Count();
        }//EndMethod

        [Benchmark]
        public void ArraySelectCountRewritten()
        {
            var res = ArraySource.Select(x => x + 3).Count();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereCount()
        {
            var res = ArraySource.Where(x => x > 100).Count();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereCountRewritten()
        {
            var res = ArraySource.Where(x => x > 100).Count();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereCountCondition()
        {
            var res = ArraySource.Where(x => x > 100).Count(x => x > 200);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereCountConditionRewritten()
        {
            var res = ArraySource.Where(x => x > 100).Count(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableCountCondition()
        {
            var res = EnumerableSource.Count(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void EnumerableCountConditionRewritten()
        {
            var res = EnumerableSource.Count(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableCountNotCondition()
        {
            var res = EnumerableSource.Count(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public void EnumerableCountNotConditionRewritten()
        {
            var res = EnumerableSource.Count(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableCountAllCondition()
        {
            var res = EnumerableSource.Count(x => x > 0);
        }//EndMethod

        [Benchmark]
        public void EnumerableCountAllConditionRewritten()
        {
            var res = EnumerableSource.Count(x => x > 0);
        }//EndMethod
    }
}

