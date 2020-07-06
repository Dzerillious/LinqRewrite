using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class RangeBenchmarks
    {
        [Benchmark]
        public void RangeElementAt()
        {
            var res = Enumerable.Range(500, 1000).ElementAt(50);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void RangeElementAtRewritten()
        {
            var res = Enumerable.Range(500, 1000).ElementAt(50);
        }//EndMethod
        
        [Benchmark]
        public void RangeSum()
        {
            var res = Enumerable.Range(500, 1000).Sum();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void RangeSumRewritten()
        {
            var res = Enumerable.Range(500, 1000).Sum();
        }//EndMethod
        
        [Benchmark]
        public void RangeToArray()
        {
            var res = Enumerable.Range(500, 1000).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void RangeToArrayRewritten()
        {
            var res = Enumerable.Range(500, 1000).ToArray();
        }//EndMethod
    }
}