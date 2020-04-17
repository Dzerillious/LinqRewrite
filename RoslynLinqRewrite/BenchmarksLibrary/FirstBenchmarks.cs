using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
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
        public void ArrayFirst()
        {
            var res = ArraySource.First();
        }//EndMethod

		[Benchmark]
        public void ArrayFirstRewritten()
        {
            var res = ArraySource.First();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayFirstCondition()
        {
            var res = ArraySource.First(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArrayFirstConditionRewritten()
        {
            var res = ArraySource.First(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySelectFirst()
        {
            var res = ArraySource.Select(x => x + 3).First();
        }//EndMethod

        [Benchmark]
        public void ArraySelectFirstRewritten()
        {
            var res = ArraySource.Select(x => x + 3).First();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereFirst()
        {
            var res = ArraySource.Where(x => x > 100).First();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereFirstRewritten()
        {
            var res = ArraySource.Where(x => x > 100).First();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereFirstCondition()
        {
            var res = ArraySource.Where(x => x > 100).First(x => x > 200);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereFirstConditionRewritten()
        {
            var res = ArraySource.Where(x => x > 100).First(x => x > 200);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableFirstCondition()
        {
            var res = EnumerableSource.First(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void EnumerableFirstConditionRewritten()
        {
            var res = EnumerableSource.First(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableFirstNotCondition()
        {
            var res = EnumerableSource.First(x => x > 10_000);
        }//EndMethod

        [Benchmark]
        public void EnumerableFirstNotConditionRewritten()
        {
            var res = EnumerableSource.First(x => x > 10_000);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableFirstAllCondition()
        {
            var res = EnumerableSource.First(x => x > 0);
        }//EndMethod

        [Benchmark]
        public void EnumerableFirstAllConditionRewritten()
        {
            var res = EnumerableSource.First(x => x > 0);
        }//EndMethod
    }
}

