using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class AverageBenchmarks
    {
        private int[] Items = new int[0];
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
        //
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
            ExtendedLinq.Range(0, Items.Length / 10, 10).ForEach(x => sum += Items.Unchecked().Skip(x).Take(10).Sum());
            sum += Items.Unchecked().Skip(Items.Length - Items.Length % 10).Take(Items.Length % 10).Sum();
            return sum;
        }
        
        // [Benchmark]
        // public double ArrayAverageRewritten3()
        // {
        //     var sum = ExtendedLinq.Range(0, Items.Length / 5, 5).Sum(x => Items.Unchecked().Skip(x).Take(5).Sum());
        //     sum += Items.Unchecked().Skip(Items.Length - Items.Length % 5).Take(Items.Length % 5).Sum();
        //     return sum;
        // }
    }
}