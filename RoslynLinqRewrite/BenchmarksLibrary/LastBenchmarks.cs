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
        public int ArrayLast()
        {
            return ArraySource.Last();
        }//EndMethod

		[Benchmark]
        public int ArrayLastRewritten()
        {
            return ArraySource.Last();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayLastCondition()
        {
            return ArraySource.Last(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int ArrayLastConditionRewritten()
        {
            return ArraySource.Last(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArraySelectLast()
        {
            return ArraySource.Select(x => x + 3).Last();
        }//EndMethod

        [Benchmark]
        public int ArraySelectLastRewritten()
        {
            return ArraySource.Select(x => x + 3).Last();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereLast()
        {
            return ArraySource.Where(x => x > 100).Last();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereLastRewritten()
        {
            return ArraySource.Where(x => x > 100).Last();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereLastCondition()
        {
            return ArraySource.Where(x => x > 100).Last(x => x > 200);
        }//EndMethod

        [Benchmark]
        public int ArrayWhereLastConditionRewritten()
        {
            return ArraySource.Where(x => x > 100).Last(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableLastCondition()
        {
            return EnumerableSource.Last(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int EnumerableLastConditionRewritten()
        {
            return EnumerableSource.Last(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableLastNotCondition()
        {
            return EnumerableSource.Last(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public int EnumerableLastNotConditionRewritten()
        {
            return EnumerableSource.Last(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableLastAllCondition()
        {
            return EnumerableSource.Last(x => x > 0);
        }//EndMethod

        [Benchmark]
        public int EnumerableLastAllConditionRewritten()
        {
            return EnumerableSource.Last(x => x > 0);
        }//EndMethod
    }
}

