using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class SingleOrDefaultBenchmarks
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
        public void ArraySingleOrDefault()
        {
            var res = ArraySource.SingleOrDefault();
        }//EndMethod

		[Benchmark]
        public void ArraySingleOrDefaultRewritten()
        {
            var res = ArraySource.SingleOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySingleOrDefaultCondition()
        {
            var res = ArraySource.SingleOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArraySingleOrDefaultConditionRewritten()
        {
            var res = ArraySource.SingleOrDefault(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySelectSingleOrDefault()
        {
            var res = ArraySource.Select(x => x + 3).SingleOrDefault();
        }//EndMethod

        [Benchmark]
        public void ArraySelectSingleOrDefaultRewritten()
        {
            var res = ArraySource.Select(x => x + 3).SingleOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereSingleOrDefault()
        {
            var res = ArraySource.Where(x => x > 100).SingleOrDefault();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereSingleOrDefaultRewritten()
        {
            var res = ArraySource.Where(x => x > 100).SingleOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereSingleOrDefaultCondition()
        {
            var res = ArraySource.Where(x => x > 100).SingleOrDefault(x => x > 200);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereSingleOrDefaultConditionRewritten()
        {
            var res = ArraySource.Where(x => x > 100).SingleOrDefault(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableSingleOrDefaultCondition()
        {
            var res = EnumerableSource.SingleOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void EnumerableSingleOrDefaultConditionRewritten()
        {
            var res = EnumerableSource.SingleOrDefault(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableSingleOrDefaultNotCondition()
        {
            var res = EnumerableSource.SingleOrDefault(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public void EnumerableSingleOrDefaultNotConditionRewritten()
        {
            var res = EnumerableSource.SingleOrDefault(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableSingleOrDefaultAllCondition()
        {
            var res = EnumerableSource.SingleOrDefault(x => x > 0);
        }//EndMethod

        [Benchmark]
        public void EnumerableSingleOrDefaultAllConditionRewritten()
        {
            var res = EnumerableSource.SingleOrDefault(x => x > 0);
        }//EndMethod
    }
}

