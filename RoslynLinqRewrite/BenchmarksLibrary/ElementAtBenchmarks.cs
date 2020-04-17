using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
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
        public void ArrayElementAt()
        {
            var res = ArraySource.ElementAt(50);
        }//EndMethod

        [Benchmark]
        public void ArrayElementAtRewritten()
        {
            var res = ArraySource.ElementAt(50);
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void ArrayWhereElementAt()
        {
            var res = ArraySource.Where(x => x > 25).ElementAt(50);
        }//EndMethod

        [Benchmark]
        public void ArrayWhereElementAtRewritten()
        {
            var res = ArraySource.Where(x => x > 25).ElementAt(50);
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void EnumerableElementAt()
        {
            var res = EnumerableSource.ElementAt(50);
        }//EndMethod

        [Benchmark]
        public void EnumerableElementAtRewritten()
        {
            var res = EnumerableSource.ElementAt(50);
        }//EndMethod
    }
}