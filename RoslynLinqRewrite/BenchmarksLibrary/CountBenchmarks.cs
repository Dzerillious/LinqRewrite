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
        public int ArrayCount()
        {
            return ArraySource.Count();
        }//EndMethod

		[Benchmark]
        public int ArrayCountRewritten()
        {
            return ArraySource.Count();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayCountCondition()
        {
            return ArraySource.Count(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int ArrayCountConditionRewritten()
        {
            return ArraySource.Count(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArraySelectCount()
        {
            return ArraySource.Select(x => x + 3).Count();
        }//EndMethod

        [Benchmark]
        public int ArraySelectCountRewritten()
        {
            return ArraySource.Select(x => x + 3).Count();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereCount()
        {
            return ArraySource.Where(x => x > 100).Count();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereCountRewritten()
        {
            return ArraySource.Where(x => x > 100).Count();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereCountCondition()
        {
            return ArraySource.Where(x => x > 100).Count(x => x > 200);
        }//EndMethod

        [Benchmark]
        public int ArrayWhereCountConditionRewritten()
        {
            return ArraySource.Where(x => x > 100).Count(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableCountCondition()
        {
            return EnumerableSource.Count(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int EnumerableCountConditionRewritten()
        {
            return EnumerableSource.Count(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableCountNotCondition()
        {
            return EnumerableSource.Count(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public int EnumerableCountNotConditionRewritten()
        {
            return EnumerableSource.Count(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableCountAllCondition()
        {
            return EnumerableSource.Count(x => x > 0);
        }//EndMethod

        [Benchmark]
        public int EnumerableCountAllConditionRewritten()
        {
            return EnumerableSource.Count(x => x > 0);
        }//EndMethod
    }
}

