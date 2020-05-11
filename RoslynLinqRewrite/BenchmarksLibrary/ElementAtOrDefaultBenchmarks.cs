using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
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
        
        [NoRewrite, Benchmark]
        public int ArrayElementAtOrDefault()
        {
            return ArraySource.ElementAtOrDefault(50);
        }//EndMethod

        [Benchmark]
        public int ArrayElementAtOrDefaultRewritten()
        {
            return ArraySource.ElementAtOrDefault(50);
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public int ArrayWhereElementAtOrDefault()
        {
            return ArraySource.Where(x => x > 25).ElementAtOrDefault(50);
        }//EndMethod

        [Benchmark]
        public int ArrayWhereElementAtOrDefaultRewritten()
        {
            return ArraySource.Where(x => x > 25).ElementAtOrDefault(50);
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public int EnumerableElementAtOrDefault()
        {
            return EnumerableSource.ElementAtOrDefault(50);
        }//EndMethod

        [Benchmark]
        public int EnumerableElementAtOrDefaultRewritten()
        {
            return EnumerableSource.ElementAtOrDefault(50);
        }//EndMethod
    }
}