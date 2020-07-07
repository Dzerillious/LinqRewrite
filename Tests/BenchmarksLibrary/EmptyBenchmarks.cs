using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class EmptyBenchmarks
    {
        [Benchmark]
        public void EmptyToArray()
        {
            var res = Enumerable.Empty<int>().ToArray();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void EmptyToArrayRewritten()
        {
            var res = Enumerable.Empty<int>().ToArray();
        }//EndMethod
        
        [Benchmark]
        public void EmptyWhereToArray()
        {
            var res = Enumerable.Empty<int>().Where(x => x > 5).ToArray();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void EmptyWhereToArrayRewritten()
        {
            var res = Enumerable.Empty<int>().Where(x => x > 5).ToArray();
        }//EndMethod
    }
}