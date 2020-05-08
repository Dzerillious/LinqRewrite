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
    public class LinqCompareBenchmarks
    {
        [Params(-1, 0, 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000, 2000)]
        public int ToValue { get; set; } = 10;
        
        public int[] ArraySource;
        private Func<IEnumerable<bool>> _linqOptimizerQuery;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource.Select(x => x + 3).ToArray().GetEnumerator();
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            _linqOptimizerQuery = ArraySource.Where(x => x <= ToValue).Select(x => x > 10).AsQueryExpr().Compile();
        }

        [NoRewrite, Benchmark]
        public void SystemLinq()
        {
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            ArraySource.Where(x => x <= ToValue).Select(x => x > 10).ToArray();
        }//EndMethod

        [Benchmark]
        public void OptimizedLinqRewrite()
        {
            ArraySource.Where(x => x <= ToValue).Select(x => x > 10).ToSimpleList();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ShamanLinqRewrite()
        {
            ShamanLinqRewrite_ProceduralLinq1(ArraySource);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void LinqOptimizer()
        {
            ArraySource.Where(x => x <= ToValue).Select(x => x > 10).AsQueryExpr().Compile()();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void LinqOptimizerWithoutOverhead()
        {
            _linqOptimizerQuery();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void LinqFasterChained()
        {
            ArraySource.WhereF(x => x <= ToValue).SelectF(x => x + 10);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void LinqFasterOptimized()
        {
            ArraySource.WhereSelectF(x => x <= ToValue, x => x + 10);
        }//EndMethod

        [NoRewrite]
        int[] ShamanLinqRewrite_ProceduralLinq1(int[] _linqitems)
        {
            if (_linqitems == null)
                throw new System.ArgumentNullException();
            var _list = new System.Collections.Generic.List<int>();
            for (int _index = 0; _index < _linqitems.Length; _index++)
            {
                var _linqitem = _linqitems[_index];
                if (_linqitem >= ToValue)
                {
                    var _linqitem1 = _linqitem + 10;
                    _list.Add(_linqitem1);
                }
            }
            return _list.ToArray();
        }
    }
}