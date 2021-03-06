﻿using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
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
        
        [Benchmark]
        public int RangeSum()
        {
            return Enumerable.Range(567, 1000).Sum();
        }
        
        [Benchmark, LinqRewrite]
		public int RangeSumRewritten()
        {
            return Enumerable.Range(567, 1000).Sum();
        }
        
        [Benchmark]
        public int ArraySum()
        {
            return ArraySource.Sum();
        }
        
        [Benchmark, LinqRewrite]
		public int ArraySumRewritten()
        {
            return ArraySource.Sum();
        }
        
        [Benchmark]
        public int ArrayCompositeSum()
        {
            var sum = ExtendedLinq.Range(0, ArraySource.Length / 10, 10)
                .Sum(x => ArraySource.Skip(x).Take(10).Sum());
            sum += ArraySource.Skip(ArraySource.Length / 10 * 10).Sum();
            return sum;
        }
        
        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
		public int ArrayCompositeSumRewritten()
        {
            var sum = ExtendedLinq.Range(0, ArraySource.Length / 10, 10)
                .Sum(x => ArraySource.Skip(x).Take(10).Sum());
            sum += ArraySource.Skip(ArraySource.Length / 10 * 10).Sum();
            return sum;
        }
        
        [Benchmark]
        public int ArraySIMDSum()
        {
            var simdLength = Vector<int>.Count;
            var vectorSum = ExtendedLinq.Range(0, ArraySource.Length / simdLength, simdLength)
                .Aggregate(Vector<int>.Zero, (x, y) => Vector.Add(x, new Vector<int>(ArraySource, y)));
            return Enumerable.Range(0, simdLength).Sum(i => vectorSum[i])
                + ArraySource.Skip(ArraySource.Length / simdLength * simdLength).Sum();
        }
        
        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
		public int ArraySIMDSumRewritten()
        {
            var simdLength = Vector<int>.Count;
            Vector<int> vsum = Vector<int>.Zero;
            ExtendedLinq.Range(0, ArraySource.Length / simdLength, simdLength)
                .ForEach(x => vsum = Vector.Add(vsum, new Vector<int>(ArraySource, x)));
            return Enumerable.Range(0, simdLength).Sum(i => vsum[i])
                   + ArraySource.Skip(ArraySource.Length / simdLength * simdLength).Sum();
        }
        
        [Benchmark]
        public int ArrayWhereSum()
        {
            return ArraySource.Where(x => x > 700).Sum();
        }
        
        [Benchmark, LinqRewrite]
		public int ArrayWhereSumRewritten()
        {
            return ArraySource.Where(x => x > 700).Sum();
        }
        
        [Benchmark]
        public int? ArrayNullableSum()
        {
            return ArraySource.Sum(x => x > 700 ? x : (int?)null);
        }
        
        [Benchmark, LinqRewrite]
		public int? ArrayNullableSumRewritten()
        {
            return ArraySource.Sum(x => x > 700 ? x : (int?)null);
        }
        
        [Benchmark]
        public int EnumerableSum()
        {
            return EnumerableSource.Sum();
        }
        
        [Benchmark, LinqRewrite]
		public int EnumerableSumRewritten()
        {
            return EnumerableSource.Sum();
        }
    }
}