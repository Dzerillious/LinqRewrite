using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class AnyBenchmarks
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
        public void ArrayAny()
        {
            var res = ArraySource.Any();
        }//EndMethod

		[Benchmark]
        public void ArrayAnyRewritten()
        {
            var res = ArraySource.Any();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayAnyCondition()
        {
            var res = ArraySource.Any(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArrayAnyConditionRewritten()
        {
            var res = ArraySource.Any(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySelectAny()
        {
            var res = ArraySource.Select(x => x + 3).Any();
        }//EndMethod

        [Benchmark]
        public void ArraySelectAnyRewritten()
        {
            var res = ArraySource.Select(x => x + 3).Any();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereAny()
        {
            var res = ArraySource.Where(x => x > 100).Any();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereAnyRewritten()
        {
            var res = ArraySource.Where(x => x > 100).Any();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereAnyCondition()
        {
            var res = ArraySource.Where(x => x > 100).Any(x => x > 200);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereAnyConditionRewritten()
        {
            var res = ArraySource.Where(x => x > 100).Any(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableAnyCondition()
        {
            var res = EnumerableSource.Any(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void EnumerableAnyConditionRewritten()
        {
            var res = EnumerableSource.Any(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableAnyNotCondition()
        {
            var res = EnumerableSource.Any(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public void EnumerableAnyNotConditionRewritten()
        {
            var res = EnumerableSource.Any(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableAnyAllCondition()
        {
            var res = EnumerableSource.Any(x => x > 0);
        }//EndMethod

        [Benchmark]
        public void EnumerableAnyAllConditionRewritten()
        {
            var res = EnumerableSource.Any(x => x > 0);
        }//EndMethod
    }
}

