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
        public int ArrayFirstOrDefault()
        {
            return ArraySource.FirstOrDefault();
        }//EndMethod

		[Benchmark]
        public int ArrayFirstOrDefaultRewritten()
        {
            return ArraySource.FirstOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayFirstOrDefaultCondition()
        {
            return ArraySource.FirstOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int ArrayFirstOrDefaultConditionRewritten()
        {
            return ArraySource.FirstOrDefault(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArraySelectFirstOrDefault()
        {
            return ArraySource.Select(x => x + 3).FirstOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArraySelectFirstOrDefaultRewritten()
        {
            return ArraySource.Select(x => x + 3).FirstOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereFirstOrDefault()
        {
            return ArraySource.Where(x => x > 100).FirstOrDefault();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereFirstOrDefaultRewritten()
        {
            return ArraySource.Where(x => x > 100).FirstOrDefault();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereFirstOrDefaultCondition()
        {
            return ArraySource.Where(x => x > 100).FirstOrDefault(x => x > 200);
        }//EndMethod

        [Benchmark]
        public int ArrayWhereFirstOrDefaultConditionRewritten()
        {
            return ArraySource.Where(x => x > 100).FirstOrDefault(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableFirstOrDefaultCondition()
        {
            return EnumerableSource.FirstOrDefault(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int EnumerableFirstOrDefaultConditionRewritten()
        {
            return EnumerableSource.FirstOrDefault(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableFirstOrDefaultNotCondition()
        {
            return EnumerableSource.FirstOrDefault(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public int EnumerableFirstOrDefaultNotConditionRewritten()
        {
            return EnumerableSource.FirstOrDefault(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableFirstOrDefaultAllCondition()
        {
            return EnumerableSource.FirstOrDefault(x => x > 0);
        }//EndMethod

        [Benchmark]
        public int EnumerableFirstOrDefaultAllConditionRewritten()
        {
            return EnumerableSource.FirstOrDefault(x => x > 0);
        }//EndMethod
    }
}

