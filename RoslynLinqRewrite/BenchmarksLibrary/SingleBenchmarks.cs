using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class SingleBenchmarks
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
        public void ArraySingle()
        {
            var res = ArraySource.Single();
        }//EndMethod

		[Benchmark]
        public void ArraySingleRewritten()
        {
            var res = ArraySource.Single();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySingleCondition()
        {
            var res = ArraySource.Single(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArraySingleConditionRewritten()
        {
            var res = ArraySource.Single(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySelectSingle()
        {
            var res = ArraySource.Select(x => x + 3).Single();
        }//EndMethod

        [Benchmark]
        public void ArraySelectSingleRewritten()
        {
            var res = ArraySource.Select(x => x + 3).Single();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereSingle()
        {
            var res = ArraySource.Where(x => x > 100).Single();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereSingleRewritten()
        {
            var res = ArraySource.Where(x => x > 100).Single();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereSingleCondition()
        {
            var res = ArraySource.Where(x => x > 100).Single(x => x > 200);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereSingleConditionRewritten()
        {
            var res = ArraySource.Where(x => x > 100).Single(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableSingleCondition()
        {
            var res = EnumerableSource.Single(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void EnumerableSingleConditionRewritten()
        {
            var res = EnumerableSource.Single(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableSingleNotCondition()
        {
            var res = EnumerableSource.Single(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public void EnumerableSingleNotConditionRewritten()
        {
            var res = EnumerableSource.Single(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableSingleAllCondition()
        {
            var res = EnumerableSource.Single(x => x > 0);
        }//EndMethod

        [Benchmark]
        public void EnumerableSingleAllConditionRewritten()
        {
            var res = EnumerableSource.Single(x => x > 0);
        }//EndMethod
    }
}

