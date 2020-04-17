using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
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

        [NoRewrite, Benchmark]
        public void ArrayLastOrDefault()
        {
            var res = ArraySource.LastOrDefault();
        }//EndMethod

		[Benchmark]
        public void ArrayLastOrDefaultRewritten()
        {
            var res = ArraySource.LastOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayLastOrDefaultCondition()
        {
            var res = ArraySource.LastOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArrayLastOrDefaultConditionRewritten()
        {
            var res = ArraySource.LastOrDefault(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySelectLastOrDefault()
        {
            var res = ArraySource.Select(x => x + 3).LastOrDefault();
        }//EndMethod

        [Benchmark]
        public void ArraySelectLastOrDefaultRewritten()
        {
            var res = ArraySource.Select(x => x + 3).LastOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereLastOrDefault()
        {
            var res = ArraySource.Where(x => x > 100).LastOrDefault();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereLastOrDefaultRewritten()
        {
            var res = ArraySource.Where(x => x > 100).LastOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereLastOrDefaultCondition()
        {
            var res = ArraySource.Where(x => x > 100).LastOrDefault(x => x > 200);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereLastOrDefaultConditionRewritten()
        {
            var res = ArraySource.Where(x => x > 100).LastOrDefault(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableLastOrDefaultCondition()
        {
            var res = EnumerableSource.LastOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void EnumerableLastOrDefaultConditionRewritten()
        {
            var res = EnumerableSource.LastOrDefault(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableLastOrDefaultNotCondition()
        {
            var res = EnumerableSource.LastOrDefault(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public void EnumerableLastOrDefaultNotConditionRewritten()
        {
            var res = EnumerableSource.LastOrDefault(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableLastOrDefaultAllCondition()
        {
            var res = EnumerableSource.LastOrDefault(x => x > 0);
        }//EndMethod

        [Benchmark]
        public void EnumerableLastOrDefaultAllConditionRewritten()
        {
            var res = EnumerableSource.LastOrDefault(x => x > 0);
        }//EndMethod
    }
}

