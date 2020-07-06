using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class AverageBenchmarks
    {
        private int[] ArraySource;
        private IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(456, 654).ToArray();
            EnumerableSource = Enumerable.Range(456, 654);
        }
        
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
        
        [Benchmark, LinqRewrite]
        public double ArrayAverage5()
        {
            return ArraySource.Unchecked().Take(5).Average();
        }
        
        [Benchmark]
        [LinqRewrite]
		public double ArrayAverage5Rewritten()
        {
            return ArraySource.Unchecked().Take(5).Average();
        }
        
        [Benchmark, LinqRewrite]
        public double ArrayAverage10()
        {
            return ArraySource.Unchecked().Take(10).Average();
        }
        
        [Benchmark]
        [LinqRewrite]
		public double ArrayAverage10Rewritten()
        {
            return ArraySource.Unchecked().Take(10).Average();
        }
        
        [Benchmark, LinqRewrite]
        public double ArrayWhereAverage10()
        {
            return ArraySource.Where(x =>  x > 600).Average();
        }
        
        [Benchmark]
        [LinqRewrite]
		public double ArrayWhereAverageRewritten()
        {
            return ArraySource.Where(x =>  x > 600).Average();
        }
        
        [Benchmark, LinqRewrite]
        public double EnumerableAverage()
        {
            return EnumerableSource.Average();
        }
        
        [Benchmark]
        [LinqRewrite]
		public double EnumerableAverageRewritten()
        {
            return EnumerableSource.Average();
        }
        
        [Benchmark, LinqRewrite]
        public double EnumerableUncheckedAverage()
        {
            return EnumerableSource.Unchecked().Average();
        }
        
        [Benchmark]
        [LinqRewrite]
		public double EnumerableUncheckedAverageRewritten()
        {
            return EnumerableSource.Unchecked().Average();
        }
    }
}