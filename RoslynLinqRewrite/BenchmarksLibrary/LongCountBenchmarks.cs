using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
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
        public void ArrayLongCount()
        {
            var res = ArraySource.LongCount();
        }//EndMethod

		[Benchmark]
        public void ArrayLongCountRewritten()
        {
            var res = ArraySource.LongCount();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayLongCountCondition()
        {
            var res = ArraySource.LongCount(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArrayLongCountConditionRewritten()
        {
            var res = ArraySource.LongCount(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySelectLongCount()
        {
            var res = ArraySource.Select(x => x + 3).LongCount();
        }//EndMethod

        [Benchmark]
        public void ArraySelectLongCountRewritten()
        {
            var res = ArraySource.Select(x => x + 3).LongCount();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereLongCount()
        {
            var res = ArraySource.Where(x => x > 100).LongCount();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereLongCountRewritten()
        {
            var res = ArraySource.Where(x => x > 100).LongCount();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereLongCountCondition()
        {
            var res = ArraySource.Where(x => x > 100).LongCount(x => x > 200);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereLongCountConditionRewritten()
        {
            var res = ArraySource.Where(x => x > 100).LongCount(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableLongCountCondition()
        {
            var res = EnumerableSource.LongCount(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void EnumerableLongCountConditionRewritten()
        {
            var res = EnumerableSource.LongCount(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableLongCountNotCondition()
        {
            var res = EnumerableSource.LongCount(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public void EnumerableLongCountNotConditionRewritten()
        {
            var res = EnumerableSource.LongCount(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableLongCountAllCondition()
        {
            var res = EnumerableSource.LongCount(x => x > 0);
        }//EndMethod

        [Benchmark]
        public void EnumerableLongCountAllConditionRewritten()
        {
            var res = EnumerableSource.LongCount(x => x > 0);
        }//EndMethod
    }
}

