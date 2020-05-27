using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class MinBenchmarks
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
        public int RangeMin()
        {
            return Enumerable.Range(567, 1000).Min();
        }
        
        [Benchmark]
        public int RangeMinRewritten()
        {
            return Enumerable.Range(567, 1000).Min();
        }
        
        [NoRewrite, Benchmark]
        public int ArrayMin()
        {
            return ArraySource.Min();
        }
        
        [Benchmark]
        public int ArrayMinRewritten()
        {
            return ArraySource.Min();
        }
        
        [NoRewrite, Benchmark]
        public int ArrayWhereMin()
        {
            return ArraySource.Where(x => x > 700).Min();
        }
        
        [Benchmark]
        public int ArrayWhereMinRewritten()
        {
            return ArraySource.Where(x => x > 700).Min();
        }
        
        [NoRewrite, Benchmark]
        public int? ArrayNullableMin()
        {
            return ArraySource.Min(x => x > 700 ? x : (int?)null);
        }
        
        [Benchmark]
        public int? ArrayNullableMinRewritten()
        {
            return ArraySource.Min(x => x > 700 ? x : (int?)null);
        }
        
        [NoRewrite, Benchmark]
        public int EnumerableMin()
        {
            return EnumerableSource.Min();
        }
        
        [Benchmark]
        public int EnumerableMinRewritten()
        {
            return EnumerableSource.Min();
        }
    }
}