using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
    public class LastBenchmarks
    {
        public static int[] StaticArraySource;
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;
        public SimpleList<int> SimpleListSource;
        public int Selector(int a) => a + 3;

        [GlobalSetup]
        public void GlobalSetup()
        {
            StaticArraySource = Enumerable.Range(0, 1000).ToArray();
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            EnumerableSource = Enumerable.Range(0, 1000);
            SimpleListSource = Enumerable.Range(0, 1000).ToSimpleList();
        }

        [Benchmark]
        public void SimpleListLast()
        {
            var res = SimpleListSource.Last();
        }//EndMethod

        [Benchmark]
        public void SimpleListLast2()
        {
            var res = SimpleListSource.Last(x => x > 5);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayLast()
        {
            var res = ArraySource.Last();
        }//EndMethod

        [Benchmark]
        public void ArrayLastRewritten()
        {
            var res = ArraySource.Last();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayLastCondition()
        {
            var res = ArraySource.Last(x => x > 3);
        }//EndMethod

        [Benchmark]
        public void ArrayLastRewrittenCondition()
        {
            var res = ArraySource.Last(x => x > 3);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArraySelectLast()
        {
            var res = ArraySource.Select(x => x + 3).Last();
        }//EndMethod

        [Benchmark]
        public void ArraySelectLastRewritten()
        {
            var res = ArraySource.Select(x => x + 3).Last();
        }//EndMethod

    }
}