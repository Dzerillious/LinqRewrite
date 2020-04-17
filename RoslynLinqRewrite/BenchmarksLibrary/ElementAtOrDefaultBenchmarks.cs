using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class ElementAtOrDefaultBenchmarks
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
        public void ArrayElementAtOrDefault()
        {
            var res = ArraySource.ElementAtOrDefault(50);
        }//EndMethod

        [Benchmark]
        public void ArrayElementAtOrDefaultRewritten()
        {
            var res = ArraySource.ElementAtOrDefault(50);
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void ArrayWhereElementAtOrDefault()
        {
            var res = ArraySource.Where(x => x > 25).ElementAtOrDefault(50);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereElementAtOrDefaultRewritten()
        {
            var res = ArraySource.Where(x => x > 25).ElementAtOrDefault(50);
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void EnumerableElementAtOrDefault()
        {
            var res = EnumerableSource.ElementAtOrDefault(50);
        }//EndMethod

        [Benchmark]
        public void EnumerableElementAtOrDefaultRewritten()
        {
            var res = EnumerableSource.ElementAtOrDefault(50);
        }//EndMethod
    }
}