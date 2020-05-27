using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class DistinctBenchmarks
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
        public void ArrayDistinct()
        {
            var res = ArraySource.Distinct().ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayDistinctRewritten()
        {
            var res = ArraySource.Distinct().ToArray();
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void EnumerableDistinct()
        {
            var res = EnumerableSource.Distinct().ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableDistinctRewritten()
        {
            var res = EnumerableSource.Distinct().ToArray();
        }//EndMethod
    }
}