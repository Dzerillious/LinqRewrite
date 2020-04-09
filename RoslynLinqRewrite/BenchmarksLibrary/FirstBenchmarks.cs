using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
    public class FirstBenchmarks
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
        public void ArrayFirstRewrittenCondition()
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

    }
}

