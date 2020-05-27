using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class ElementAtBenchmarks
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
        public int ArrayElementAt()
        {
            return ArraySource.ElementAt(50);
        }//EndMethod

        [Benchmark]
        public int ArrayElementAtRewritten()
        {
            return ArraySource.ElementAt(50);
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public int ArrayWhereElementAt()
        {
            return ArraySource.Where(x => x > 25).ElementAt(50);
        }//EndMethod

        [Benchmark]
        public int ArrayWhereElementAtRewritten()
        {
            return ArraySource.Where(x => x > 25).ElementAt(50);
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public int EnumerableElementAt()
        {
            return EnumerableSource.ElementAt(50);
        }//EndMethod

        [Benchmark]
        public int EnumerableElementAtRewritten()
        {
            return EnumerableSource.ElementAt(50);
        }//EndMethod
    }
}