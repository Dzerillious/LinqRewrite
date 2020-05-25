using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    [MemoryDiagnoser]
    public class LongCountBenchmarks
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
        public long ArrayLongCount()
        {
            return ArraySource.LongCount();
        }//EndMethod

		[Benchmark]
        public long ArrayLongCountRewritten()
        {
            return ArraySource.LongCount();
        }//EndMethod

        [NoRewrite, Benchmark]
        public long ArrayLongCountCondition()
        {
            return ArraySource.LongCount(x => x > 3);
        }//EndMethod

        [Benchmark]
        public long ArrayLongCountConditionRewritten()
        {
            return ArraySource.LongCount(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public long ArraySelectLongCount()
        {
            return ArraySource.Select(x => x + 3).LongCount();
        }//EndMethod

        [Benchmark]
        public long ArraySelectLongCountRewritten()
        {
            return ArraySource.Select(x => x + 3).LongCount();
        }//EndMethod

        [NoRewrite, Benchmark]
        public long ArrayWhereLongCount()
        {
            return ArraySource.Where(x => x > 100).LongCount();
        }//EndMethod

        [Benchmark]
        public long ArrayWhereLongCountRewritten()
        {
            return ArraySource.Where(x => x > 100).LongCount();
        }//EndMethod

        [NoRewrite, Benchmark]
        public long ArrayWhereLongCountCondition()
        {
            return ArraySource.Where(x => x > 100).LongCount(x => x > 200);
        }//EndMethod

        [Benchmark]
        public long ArrayWhereLongCountConditionRewritten()
        {
            return ArraySource.Where(x => x > 100).LongCount(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public long EnumerableLongCountCondition()
        {
            return EnumerableSource.LongCount(x => x > 3);
        }//EndMethod

        [Benchmark]
        public long EnumerableLongCountConditionRewritten()
        {
            return EnumerableSource.LongCount(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public long EnumerableLongCountNotCondition()
        {
            return EnumerableSource.LongCount(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public long EnumerableLongCountNotConditionRewritten()
        {
            return EnumerableSource.LongCount(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public long EnumerableLongCountAllCondition()
        {
            return EnumerableSource.LongCount(x => x > 0);
        }//EndMethod

        [Benchmark]
        public long EnumerableLongCountAllConditionRewritten()
        {
            return EnumerableSource.LongCount(x => x > 0);
        }//EndMethod
    }
}

