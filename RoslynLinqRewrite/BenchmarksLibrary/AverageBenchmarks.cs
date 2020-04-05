using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class AverageBenchmarks
    {
        private int[] Items = Enumerable.Range(0, 100).ToArray();
        
        [NoRewrite]
        [Benchmark]
        public double RangeAverage()
        {
            return Enumerable.Range(567, 675).Average();
        }
        
        [Benchmark]
        public double RangeAverageToArray()
        {
            return Enumerable.Range(567, 675).Average();
        }
        
        [NoRewrite]
        [Benchmark]
        public double ArrayAverage()
        {
            return Items.Average();
        }
        
        [Benchmark]
        public double ArrayAverageRewritten()
        {
            return Items.Average();
        }
    }
}