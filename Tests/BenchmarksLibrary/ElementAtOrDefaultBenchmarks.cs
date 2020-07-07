using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class ElementAtOrDefaultBenchmarks
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
        public int ArrayElementAtOrDefault()
        {
            return ArraySource.ElementAtOrDefault(50);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int ArrayElementAtOrDefaultRewritten()
        {
            return ArraySource.ElementAtOrDefault(50);
        }//EndMethod
        
        [Benchmark]
        public int ArrayWhereElementAtOrDefault()
        {
            return ArraySource.Where(x => x > 25).ElementAtOrDefault(50);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int ArrayWhereElementAtOrDefaultRewritten()
        {
            return ArraySource.Where(x => x > 25).ElementAtOrDefault(50);
        }//EndMethod
        
        [Benchmark]
        public int EnumerableElementAtOrDefault()
        {
            return EnumerableSource.ElementAtOrDefault(50);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public int EnumerableElementAtOrDefaultRewritten()
        {
            return EnumerableSource.ElementAtOrDefault(50);
        }//EndMethod
    }
}