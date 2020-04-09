using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class AverageBenchmarks
    {
        private int[] Items = Enumerable.Range(0, 100).ToArray();
        //
        // [NoRewrite]
        // [Benchmark]
        // public double RangeAverage()
        // {
        //     return Enumerable.Range(567, 675).Average();
        // }
        //
        // [Benchmark]
        // public double RangeAverageToArray()
        // {
        //     return Enumerable.Range(567, 675).Average();
        // }
        //
        // [NoRewrite]
        // [Benchmark]
        // public double ArrayAverage()
        // {
        //     return Items.Unchecked().Take(10).Average();
        // }
        //
        // [Benchmark]
        // public double ArrayAverageRewritten()
        // {
        //     return Items.Unchecked().Take(10).Average();
        // }
        
        // [NoRewrite]
        // [Benchmark]
        // public double ArrayAverage1()
        // {
        //     return Items.Unchecked().Take(10).Aggregate(100, (x, y) => x + y);
        // }
        
        [Benchmark]
        public double ArrayAverageRewritten2()
        {
            var sum = 0;
            Enumerable.Range(0, Items.Length / 10).ForEach(x =>
            {
                sum += Items.Unchecked().Skip(x).Take(10).Sum();
            });
            return sum;
        }
    }
}