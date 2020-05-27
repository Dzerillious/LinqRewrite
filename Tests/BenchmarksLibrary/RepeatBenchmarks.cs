using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class RepeatBenchmarks
    {
        [NoRewrite, Benchmark]
        public void RepeatElementAt()
        {
            var res = Enumerable.Repeat(500, 1000).ElementAt(50);
        }//EndMethod

        [Benchmark]
        public void RepeatElementAtRewritten()
        {
            var res = Enumerable.Repeat(500, 1000).ElementAt(50);
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void RepeatSum()
        {
            var res = Enumerable.Repeat(500, 1000).Sum();
        }//EndMethod

        [Benchmark]
        public void RepeatSumRewritten()
        {
            var res = Enumerable.Repeat(500, 1000).Sum();
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void RepeatToArray()
        {
            var res = Enumerable.Repeat(500, 1000).ToArray();
        }//EndMethod

        [Benchmark]
        public void RepeatToArrayRewritten()
        {
            var res = Enumerable.Repeat(500, 1000).ToArray();
        }//EndMethod
    }
}