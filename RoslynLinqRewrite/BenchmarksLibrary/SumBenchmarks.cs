﻿using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class SumBenchmarks
    {
        [NoRewrite, Benchmark]
        public int RangeSum()
        {
            return Enumerable.Range(567, 675).Sum();
        }
        
        [Benchmark]
        public int RangeSumRewritten()
        {
            var a = 567;
            var b = 675;
            return Enumerable.Range(a, b).Sum();
        }
    }
}