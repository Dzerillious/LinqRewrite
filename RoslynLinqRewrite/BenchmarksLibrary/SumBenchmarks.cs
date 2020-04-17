using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class SumBenchmarks
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
        public int RangeSum()
        {
            return Enumerable.Range(567, 1000).Sum();
        }
        
        [Benchmark]
        public int RangeSumRewritten()
        {
            return Enumerable.Range(567, 1000).Sum();
        }
        
        [NoRewrite, Benchmark]
        public int ArraySum()
        {
            return ArraySource.Sum();
        }
        
        [Benchmark]
        public int ArraySumRewritten()
        {
            return ArraySource.Sum();
        }
        
        [NoRewrite, Benchmark]
        public int ArrayWhereSum()
        {
            return ArraySource.Where(x => x > 700).Sum();
        }
        
        [Benchmark]
        public int ArrayWhereSumRewritten()
        {
            return ArraySource.Where(x => x > 700).Sum();
        }
        
        [NoRewrite, Benchmark]
        public int? ArrayNullableSum()
        {
            return ArraySource.Sum(x => x > 700 ? x : (int?)null);
        }
        
        [Benchmark]
        public int? ArrayNullableSumRewritten()
        {
            return ArraySource.Sum(x => x > 700 ? x : (int?)null);
        }
        
        [NoRewrite, Benchmark]
        public int EnumerableSum()
        {
            return EnumerableSource.Sum();
        }
        
        [Benchmark]
        public int EnumerableSumRewritten()
        {
            return EnumerableSource.Sum();
        }
    }
}