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
        public double ArrayAverage5()
        {
            return ArraySource.Unchecked().Take(5).Average();
        }
        
        [Benchmark]
        public double ArrayAverage5Rewritten()
        {
            return ArraySource.Unchecked().Take(5).Average();
        }
        
        [NoRewrite]
        [Benchmark]
        public double ArrayAverage10()
        {
            return ArraySource.Unchecked().Take(10).Average();
        }
        
        [Benchmark]
        public double ArrayAverage10Rewritten()
        {
            return ArraySource.Unchecked().Take(10).Average();
        }
        
        [NoRewrite]
        [Benchmark]
        public double ArrayWhereAverage10()
        {
            return ArraySource.Where(x =>  x > 600).Average();
        }
        
        [Benchmark]
        public double ArrayWhereAverageRewritten()
        {
            return ArraySource.Where(x =>  x > 600).Average();
        }
        
        [NoRewrite]
        [Benchmark]
        public double EnumerableAverage()
        {
            return EnumerableSource.Average();
        }
        
        [Benchmark]
        public double EnumerableAverageRewritten()
        {
            return EnumerableSource.Average();
        }
        
        [NoRewrite]
        [Benchmark]
        public double EnumerableUncheckedAverage()
        {
            return EnumerableSource.Unchecked().Average();
        }
        
        [Benchmark]
        public double EnumerableUncheckedAverageRewritten()
        {
            return EnumerableSource.Unchecked().Average();
        }
    }
}