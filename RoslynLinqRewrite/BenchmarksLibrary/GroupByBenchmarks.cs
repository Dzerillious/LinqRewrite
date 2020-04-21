using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    [MemoryDiagnoser]
    public class GroupByBenchmarks
    {
        private int[] ArraySource;
        private IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(235, 10000).ToArray();
            EnumerableSource = Enumerable.Range(235, 10000);
        }
        
        [NoRewrite]
        [Benchmark]
        public void ArrayGroupBy()
        {
            ArraySource.GroupBy(x => x % 100, (x, y) => y.Sum()).ToArray();
        }
        
        [Benchmark]
        public void ArrayGroupByRewritten()
        {
            ArraySource.GroupBy(x => x % 100, (x, y) => y.Sum()).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void EnumerableGroupBy()
        {
            EnumerableSource.GroupBy(x => x % 100, (x, y) => y.Sum()).ToArray();
        }
        
        [Benchmark]
        public void EnumerableGroupByRewritten()
        {
            EnumerableSource.GroupBy(x => x % 100, (x, y) => y.Sum()).ToArray();
        }
    }
}