using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using LinqRewrite.Core;
using Nessos.LinqOptimizer.CSharp;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class LinqCompareBenchmarks
    {
        public int[] ArraySource;
        private Func<int> _linqOptimizerSumQuery;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            _linqOptimizerSumQuery = ArraySource.AsQueryExpr().Sum().Compile();
        }

        [Benchmark]
        public int SystemLinqSum()
        {
            return ArraySource.Sum();
        }//EndMethod

        [Benchmark, LinqRewrite]
        public int OptimizedLinqRewriteSum()
        {
            return ArraySource.Sum();
        }//EndMethod

        [Benchmark]
        public void LinqOptimizerWithoutOverheadSum()
        {
            _linqOptimizerSumQuery();
        }//EndMethod

        [Benchmark]
        public void LinqFasterChainedSum()
        {
            ArraySource.SumF();
        }//EndMethod

        [Benchmark]
        public int SystemLinqFirst()
        {
            return ArraySource.First();
        }//EndMethod

        [Benchmark, LinqRewrite]
        public int OptimizedLinqRewriteFirst()
        {
            return ArraySource.First();
        }//EndMethod

        [Benchmark]
        public void LinqFasterChainedFirst()
        {
            ArraySource.FirstF();
        }//EndMethod
    }
}