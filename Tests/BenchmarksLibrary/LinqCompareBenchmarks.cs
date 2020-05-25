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

        [NoRewrite, Benchmark]
        public int SystemLinqSum()
        {
            return ArraySource.Sum();
        }//EndMethod

        [Benchmark]
        public int OptimizedLinqRewriteSum()
        {
            return ArraySource.Sum();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void LinqOptimizerWithoutOverheadSum()
        {
            _linqOptimizerSumQuery();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void LinqFasterChainedSum()
        {
            ArraySource.SumF();
        }//EndMethod

        [NoRewrite, Benchmark]
        public int SystemLinqFirst()
        {
            return ArraySource.First();
        }//EndMethod

        [Benchmark]
        public int OptimizedLinqRewriteFirst()
        {
            return ArraySource.First();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void LinqFasterChainedFirst()
        {
            ArraySource.FirstF();
        }//EndMethod
    }
}