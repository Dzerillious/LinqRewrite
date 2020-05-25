using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    [MemoryDiagnoser]
    public class FirstBenchmarks
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
        public int ArrayFirst()
        {
            return ArraySource.First();
        }//EndMethod

		[Benchmark]
        public int ArrayFirstRewritten()
        {
            return ArraySource.First();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayFirstCondition()
        {
            return ArraySource.First(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int ArrayFirstConditionRewritten()
        {
            return ArraySource.First(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArraySelectFirst()
        {
            return ArraySource.Select(x => x + 3).First();
        }//EndMethod

        [Benchmark]
        public int ArraySelectFirstRewritten()
        {
            return ArraySource.Select(x => x + 3).First();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereFirst()
        {
            return ArraySource.Where(x => x > 100).First();
        }//EndMethod

        [Benchmark]
        public int ArrayWhereFirstRewritten()
        {
            return ArraySource.Where(x => x > 100).First();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int ArrayWhereFirstCondition()
        {
            return ArraySource.Where(x => x > 100).First(x => x > 200);
        }//EndMethod

        [Benchmark]
        public int ArrayWhereFirstConditionRewritten()
        {
            return ArraySource.Where(x => x > 100).First(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableFirstCondition()
        {
            return EnumerableSource.First(x => x > 3);
        }//EndMethod

        [Benchmark]
        public int EnumerableFirstConditionRewritten()
        {
            return EnumerableSource.First(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableFirstNotCondition()
        {
            return EnumerableSource.First(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public int EnumerableFirstNotConditionRewritten()
        {
            return EnumerableSource.First(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public int EnumerableFirstAllCondition()
        {
            return EnumerableSource.First(x => x > 0);
        }//EndMethod

        [Benchmark]
        public int EnumerableFirstAllConditionRewritten()
        {
            return EnumerableSource.First(x => x > 0);
        }//EndMethod
    }
}

