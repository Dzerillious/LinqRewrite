using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class ZipBenchmarks
    {
        private int[] ArraySource;
        private IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(235, 10000).ToArray();
            EnumerableSource = Enumerable.Range(235, 10000);
        }
        
        [NoRewrite]
        [Benchmark]
        public void ArrayZip()
        {
            ArraySource.Zip(ArraySource, (x, y) => x + y).ToArray();
        }
        
        [Benchmark]
        public void ArrayZipRewritten()
        {
            ArraySource.Zip(ArraySource, (x, y) => x + y).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void EnumerableZip()
        {
            EnumerableSource.Zip(EnumerableSource, (x, y) => x + y).ToArray();
        }
        
        [Benchmark]
        public void EnumerableZipRewritten()
        {
            EnumerableSource.Zip(EnumerableSource, (x, y) => x + y).ToArray();
        }
    }
}