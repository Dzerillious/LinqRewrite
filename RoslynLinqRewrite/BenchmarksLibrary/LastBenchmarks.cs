using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
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

        [NoRewrite, Benchmark]
        public void ArrayLast()
        {
            var res = ArraySource.Last();
        }//EndMethod

		[Benchmark]
        public void ArrayLastRewritten()
        {
            var res = ArraySource.Last();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayLastCondition()
        {
            var res = ArraySource.Last(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArrayLastConditionRewritten()
        {
            var res = ArraySource.Last(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySelectLast()
        {
            var res = ArraySource.Select(x => x + 3).Last();
        }//EndMethod

        [Benchmark]
        public void ArraySelectLastRewritten()
        {
            var res = ArraySource.Select(x => x + 3).Last();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereLast()
        {
            var res = ArraySource.Where(x => x > 100).Last();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereLastRewritten()
        {
            var res = ArraySource.Where(x => x > 100).Last();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereLastCondition()
        {
            var res = ArraySource.Where(x => x > 100).Last(x => x > 200);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereLastConditionRewritten()
        {
            var res = ArraySource.Where(x => x > 100).Last(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableLastCondition()
        {
            var res = EnumerableSource.Last(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void EnumerableLastConditionRewritten()
        {
            var res = EnumerableSource.Last(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableLastNotCondition()
        {
            var res = EnumerableSource.Last(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public void EnumerableLastNotConditionRewritten()
        {
            var res = EnumerableSource.Last(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableLastAllCondition()
        {
            var res = EnumerableSource.Last(x => x > 0);
        }//EndMethod

        [Benchmark]
        public void EnumerableLastAllConditionRewritten()
        {
            var res = EnumerableSource.Last(x => x > 0);
        }//EndMethod
    }
}

