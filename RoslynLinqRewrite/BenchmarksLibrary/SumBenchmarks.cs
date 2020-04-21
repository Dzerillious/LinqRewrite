using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    [MemoryDiagnoser]
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
        public int ArrayCompositeSum()
        {
            var sum = ExtendedLinq.Range(0, ArraySource.Length / 10, 10).Sum(x => ArraySource.Unchecked().Skip(x).Take(10).Sum());
            sum += ArraySource.Unchecked().Skip(ArraySource.Length / 10 * 10).Take(ArraySource.Length % 10).Sum();
            return sum;
        }
        
        [Benchmark]
        public int ArrayCompositeSumRewritten()
        {
            var sum = ExtendedLinq.Range(0, ArraySource.Length / 10, 10).Sum(x => ArraySource.Unchecked().Skip(x).Take(10).Sum());
            sum += ArraySource.Unchecked().Skip(ArraySource.Length / 10 * 10).Take(ArraySource.Length % 10).Sum();
            return sum;
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