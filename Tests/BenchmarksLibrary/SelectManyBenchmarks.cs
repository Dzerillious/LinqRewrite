using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class SelectManyBenchmarks
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
        public void RangeSelectMany()
        {
            var res = Enumerable.Range(500, 1000).SelectMany(x => Enumerable.Range(500, 1000)).ToArray();
        }//EndMethod

        [Benchmark]
        public void RangeSelectManyRewritten()
        {
            var res = Enumerable.Range(500, 1000).SelectMany(x => Enumerable.Range(500, 1000)).ToArray();
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void ArraySelectMany()
        {
            var res = ArraySource.SelectMany(x => ArraySource).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArraySelectManyRewritten()
        {
            var res = ArraySource.SelectMany(x => ArraySource).ToArray();
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void EnumerableSelectMany()
        {
            var res = EnumerableSource.SelectMany(x => EnumerableSource).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableSelectManyRewritten()
        {
            var res = EnumerableSource.SelectMany(x => EnumerableSource).ToArray();
        }//EndMethod
    }
}