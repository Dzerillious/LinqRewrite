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
        public int ArraySingleOrDefault()
        {
            return ArraySource.SingleOrDefault();
        }//EndMethod

		[Benchmark]
        public int ArraySingleOrDefaultRewritten()
        {
            return ArraySource.SingleOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArraySingleOrDefaultCondition()
        {
            return ArraySource.SingleOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int ArraySingleOrDefaultConditionRewritten()
        {
            return ArraySource.SingleOrDefault(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArraySelectSingleOrDefault()
        {
            return ArraySource.Select(x => x + 3).SingleOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArraySelectSingleOrDefaultRewritten()
        {
            return ArraySource.Select(x => x + 3).SingleOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereSingleOrDefault()
        {
            return ArraySource.Where(x => x > 100).SingleOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereSingleOrDefaultRewritten()
        {
            return ArraySource.Where(x => x > 100).SingleOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereSingleOrDefaultCondition()
        {
            return ArraySource.Where(x => x > 100).SingleOrDefault(x => x > 200);
        }//EndMethod

        [Benchmark]
        public int ArrayWhereSingleOrDefaultConditionRewritten()
        {
            return ArraySource.Where(x => x > 100).SingleOrDefault(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableSingleOrDefaultCondition()
        {
            return EnumerableSource.SingleOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int EnumerableSingleOrDefaultConditionRewritten()
        {
            return EnumerableSource.SingleOrDefault(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableSingleOrDefaultNotCondition()
        {
            return EnumerableSource.SingleOrDefault(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public int EnumerableSingleOrDefaultNotConditionRewritten()
        {
            return EnumerableSource.SingleOrDefault(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableSingleOrDefaultAllCondition()
        {
            return EnumerableSource.SingleOrDefault(x => x > 0);
        }//EndMethod

        [Benchmark]
        public int EnumerableSingleOrDefaultAllConditionRewritten()
        {
            return EnumerableSource.SingleOrDefault(x => x > 0);
        }//EndMethod
    }
}

