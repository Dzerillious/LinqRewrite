using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class SingleBenchmarks
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
        public int ArraySingle()
        {
            return ArraySource.Single();
        }//EndMethod

		[Benchmark]
        public int ArraySingleRewritten()
        {
            return ArraySource.Single();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArraySingleCondition()
        {
            return ArraySource.Single(x => x >= 0);
        }//EndMethod

        [Benchmark]
        public int ArraySingleConditionRewritten()
        {
            return ArraySource.Single(x => x >= 0);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArraySelectSingle()
        {
            return ArraySource.Select(x => x + 3).Single();
        }//EndMethod

        [Benchmark]
        public int ArraySelectSingleRewritten()
        {
            return ArraySource.Select(x => x + 3).Single();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereSingle()
        {
            return ArraySource.Where(x => x >= 0).Single();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereSingleRewritten()
        {
            return ArraySource.Where(x => x >= 0).Single();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereSingleCondition()
        {
            return ArraySource.Where(x => x >= 0).Single(x => x >= 0);
        }//EndMethod

        [Benchmark]
        public int ArrayWhereSingleConditionRewritten()
        {
            return ArraySource.Where(x => x >= 0).Single(x => x >= 0);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableSingleCondition()
        {
            return EnumerableSource.Single(x => x >= 0);
        }//EndMethod

        [Benchmark]
        public int EnumerableSingleConditionRewritten()
        {
            return EnumerableSource.Single(x => x >= 0);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableSingleNotCondition()
        {
            return EnumerableSource.Single(x => x >= 10);
        }//EndMethod

        [Benchmark]
        public int EnumerableSingleNotConditionRewritten()
        {
            return EnumerableSource.Single(x => x >= 10);
        }//EndMethod
    }
}

