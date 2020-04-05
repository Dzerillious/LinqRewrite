using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class SumBenchmarks
    {
        [NoRewrite]
        [Benchmark]
        public int Select1()
        {
            return Enumerable.Range(567, 675).Sum();
        }
        
        [Benchmark]
        public int Select1Rewritten()
        {
            return (((((567+567)+675)-1)*675)/2);
        }
    }
}