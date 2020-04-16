using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class GroupByBenchmarks
    {
        private int[] Items = Enumerable.Range(235, 10000).ToArray();
        
        [NoRewrite]
        [Benchmark]
        public void RangeAverage()
        {
            Items.GroupBy(x => x % 100, (x, y) => y.Sum()).ToArray();
        }
        
        [Benchmark]
        public void RangeAverageToArray()
        {
            Items.GroupBy(x => x % 100, (x, y) => y.Sum()).ToArray();
        }
    }
}