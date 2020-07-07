using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using Nessos.LinqOptimizer.CSharp;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class LinqCompareSkipTakeBenchmarks
    {
        [Params(0, 1, 2, 5, 10, 20, 50, 100)]
        public int ToValue { get; set; } = 10;
        
        public int[] ArraySource;
        private Func<IEnumerable<int>> _linqOptimizerQuery;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            _linqOptimizerQuery = ArraySource.AsQueryExpr().Skip(ToValue).Take(ToValue).Compile();
        }

        [Benchmark]
        public void SystemLinq()
        {
            ArraySource.Skip(ToValue).Take(ToValue).ToArray();
        }//EndMethod

        [Benchmark, LinqRewrite]
        public void OptimizedLinqRewrite()
        {
            ArraySource.Skip(ToValue).Take(ToValue).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void LinqOptimizer()
        {
            ArraySource.Skip(ToValue).Take(ToValue).AsQueryExpr().Compile()();
        }//EndMethod

        [Benchmark]
        public void LinqOptimizerWithoutOverhead()
        {
            _linqOptimizerQuery();
        }//EndMethod

        [Benchmark]
        public void LinqFasterChained()
        {
            ArraySource.SkipF(ToValue).TakeF(ToValue);
        }//EndMethod
    }
}