using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class RepeatBenchmarks
    {
        [Benchmark]
        public void RepeatElementAt()
        {
            var res = Enumerable.Repeat(500, 1000).ElementAt(50);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void RepeatElementAtRewritten()
        {
            var res = Enumerable.Repeat(500, 1000).ElementAt(50);
        }//EndMethod
        
        [Benchmark]
        public void RepeatSum()
        {
            var res = Enumerable.Repeat(500, 1000).Sum();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void RepeatSumRewritten()
        {
            var res = Enumerable.Repeat(500, 1000).Sum();
        }//EndMethod
        
        [Benchmark]
        public void RepeatToArray()
        {
            var res = Enumerable.Repeat(500, 1000).ToArray();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void RepeatToArrayRewritten()
        {
            var res = Enumerable.Repeat(500, 1000).ToArray();
        }//EndMethod
    }
}