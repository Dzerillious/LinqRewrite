using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class FirstOrDefaultBenchmarks
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
        public void ArrayFirstOrDefault()
        {
            var res = ArraySource.FirstOrDefault();
        }//EndMethod

		[Benchmark]
        public void ArrayFirstOrDefaultRewritten()
        {
            var res = ArraySource.FirstOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayFirstOrDefaultCondition()
        {
            var res = ArraySource.FirstOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArrayFirstOrDefaultConditionRewritten()
        {
            var res = ArraySource.FirstOrDefault(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySelectFirstOrDefault()
        {
            var res = ArraySource.Select(x => x + 3).FirstOrDefault();
        }//EndMethod

        [Benchmark]
        public void ArraySelectFirstOrDefaultRewritten()
        {
            var res = ArraySource.Select(x => x + 3).FirstOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereFirstOrDefault()
        {
            var res = ArraySource.Where(x => x > 100).FirstOrDefault();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereFirstOrDefaultRewritten()
        {
            var res = ArraySource.Where(x => x > 100).FirstOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereFirstOrDefaultCondition()
        {
            var res = ArraySource.Where(x => x > 100).FirstOrDefault(x => x > 200);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereFirstOrDefaultConditionRewritten()
        {
            var res = ArraySource.Where(x => x > 100).FirstOrDefault(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableFirstOrDefaultCondition()
        {
            var res = EnumerableSource.FirstOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void EnumerableFirstOrDefaultConditionRewritten()
        {
            var res = EnumerableSource.FirstOrDefault(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableFirstOrDefaultNotCondition()
        {
            var res = EnumerableSource.FirstOrDefault(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public void EnumerableFirstOrDefaultNotConditionRewritten()
        {
            var res = EnumerableSource.FirstOrDefault(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableFirstOrDefaultAllCondition()
        {
            var res = EnumerableSource.FirstOrDefault(x => x > 0);
        }//EndMethod

        [Benchmark]
        public void EnumerableFirstOrDefaultAllConditionRewritten()
        {
            var res = EnumerableSource.FirstOrDefault(x => x > 0);
        }//EndMethod
    }
}

