using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class MaxBenchmarks
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
        public int RangeMax()
        {
            return Enumerable.Range(567, 1000).Max();
        }
        
        [Benchmark]
        public int RangeMaxRewritten()
        {
            return Enumerable.Range(567, 1000).Max();
        }
        
        [NoRewrite, Benchmark]
        public int ArrayMax()
        {
            return ArraySource.Max();
        }
        
        [Benchmark]
        public int ArrayMaxRewritten()
        {
            return ArraySource.Max();
        }
        
        [NoRewrite, Benchmark]
        public int ArrayWhereMax()
        {
            return ArraySource.Where(x => x > 700).Max();
        }
        
        [Benchmark]
        public int ArrayWhereMaxRewritten()
        {
            return ArraySource.Where(x => x > 700).Max();
        }
        
        [NoRewrite, Benchmark]
        public int? ArrayNullableMax()
        {
            return ArraySource.Max(x => x > 700 ? x : (int?)null);
        }
        
        [Benchmark]
        public int? ArrayNullableMaxRewritten()
        {
            return ArraySource.Max(x => x > 700 ? x : (int?)null);
        }
        
        [NoRewrite, Benchmark]
        public int EnumerableMax()
        {
            return EnumerableSource.Max();
        }
        
        [Benchmark]
        public int EnumerableMaxRewritten()
        {
            return EnumerableSource.Max();
        }
    }
}