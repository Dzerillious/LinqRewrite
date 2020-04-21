using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    [MemoryDiagnoser]
    public class ContainsBenchmarks
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
        public bool ArrayContains50()
        {
            return ArraySource.Contains(50);
        }//EndMethod

		[Benchmark]
        public bool ArrayContains50Rewritten()
        {
            return ArraySource.Contains(50);
        }//EndMethod

        [NoRewrite, Benchmark]
        public bool ArrayContains900Condition()
        {
            return ArraySource.Contains(900);
        }//EndMethod

        [Benchmark]
        public bool ArrayContains900ConditionRewritten()
        {
            return ArraySource.Contains(900);
        }//EndMethod

        [NoRewrite, Benchmark]
        public bool ArraySelectContains()
        {
            return ArraySource.Select(x => x + 3).Contains(200);
        }//EndMethod

        [Benchmark]
        public bool ArraySelectContainsRewritten()
        {
            return ArraySource.Select(x => x + 3).Contains(200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public bool ArrayWhereContains()
        {
            return ArraySource.Where(x => x > 100).Contains(50);
        }//EndMethod

        [Benchmark]
        public bool ArrayWhereContainsRewritten()
        {
            return ArraySource.Where(x => x > 100).Contains(50);
        }//EndMethod

        [NoRewrite, Benchmark]
        public bool ArrayWhereContains900()
        {
            return ArraySource.Where(x => x > 100).Contains(900);
        }//EndMethod

        [Benchmark]
        public bool ArrayWhereContains900Rewritten()
        {
            return ArraySource.Where(x => x > 100).Contains(900);
        }//EndMethod

        [NoRewrite, Benchmark]
        public bool EnumerableContainsNotCondition()
        {
            return EnumerableSource.Contains(10000);
        }//EndMethod

        [Benchmark]
        public bool EnumerableContainsNotConditionRewritten()
        {
            return EnumerableSource.Contains(10000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public bool EnumerableContainsAllCondition()
        {
            return EnumerableSource.Contains(50);
        }//EndMethod

        [Benchmark]
        public bool EnumerableContainsAllConditionRewritten()
        {
            return EnumerableSource.Contains(50);
        }//EndMethod
    }
}

