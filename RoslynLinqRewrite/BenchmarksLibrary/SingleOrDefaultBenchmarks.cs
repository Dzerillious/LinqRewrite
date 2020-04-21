using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
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
            return ArraySource.SingleOrDefault(x => x >= 0);
        }//EndMethod

        [Benchmark]
        public int ArraySingleOrDefaultConditionRewritten()
        {
            return ArraySource.SingleOrDefault(x => x >= 0);
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
            return ArraySource.Where(x => x >= 0).SingleOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereSingleOrDefaultRewritten()
        {
            return ArraySource.Where(x => x >= 0).SingleOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereSingleOrDefaultCondition()
        {
            return ArraySource.Where(x => x >= 0).SingleOrDefault(x => x >= 0);
        }//EndMethod

        [Benchmark]
        public int ArrayWhereSingleOrDefaultConditionRewritten()
        {
            return ArraySource.Where(x => x >= 0).SingleOrDefault(x => x >= 0);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableSingleOrDefaultCondition()
        {
            return EnumerableSource.SingleOrDefault(x => x >= 0);
        }//EndMethod

        [Benchmark]
        public int EnumerableSingleOrDefaultConditionRewritten()
        {
            return EnumerableSource.SingleOrDefault(x => x >= 0);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableSingleOrDefaultNotCondition()
        {
            return EnumerableSource.SingleOrDefault(x => x >= 10);
        }//EndMethod

        [Benchmark]
        public int EnumerableSingleOrDefaultNotConditionRewritten()
        {
            return EnumerableSource.SingleOrDefault(x => x >= 10);
        }//EndMethod
    }
}

