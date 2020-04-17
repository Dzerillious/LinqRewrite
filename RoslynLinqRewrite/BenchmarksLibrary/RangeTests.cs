using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class RangeTests
    {
        [NoRewrite, Benchmark]
        public void RangeElementAt()
        {
            var res = Enumerable.Range(500, 1000).ElementAt(50);
        }//EndMethod

        [Benchmark]
        public void RangeElementAtRewritten()
        {
            var res = Enumerable.Range(500, 1000).ElementAt(50);
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void RangeSum()
        {
            var res = Enumerable.Range(500, 1000).Sum();
        }//EndMethod

        [Benchmark]
        public void RangeSumRewritten()
        {
            var res = Enumerable.Range(500, 1000).Sum();
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void RangeToArray()
        {
            var res = Enumerable.Range(500, 1000).ToArray();
        }//EndMethod

        [Benchmark]
        public void RangeToArrayRewritten()
        {
            var res = Enumerable.Range(500, 1000).ToArray();
        }//EndMethod
    }
}