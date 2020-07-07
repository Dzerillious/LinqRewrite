using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class GroupJoinBenchmarks
    {
        private int[] ArraySource;
        private IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(235, 10000).ToArray();
            EnumerableSource = Enumerable.Range(235, 10000);
        }
        
        [Benchmark]
        public void ArrayGroupJoin()
        {
            ArraySource.GroupJoin(ArraySource, x => x % 100, x => x % 100, (x, y) => y.Sum()).ToArray();
        }
        
        [Benchmark, LinqRewrite]
		public void ArrayGroupJoinRewritten()
        {
            ArraySource.GroupJoin(ArraySource, x => x % 100, x => x % 100, (x, y) => y.Sum()).ToArray();
        }
        
        [Benchmark]
        public void EnumerableGroupJoin()
        {
            EnumerableSource.GroupJoin(EnumerableSource, x => x % 100, x => x % 100, (x, y) => y.Sum()).ToArray();
        }
        
        [Benchmark, LinqRewrite]
		public void EnumerableGroupJoinRewritten()
        {
            EnumerableSource.GroupJoin(EnumerableSource, x => x % 100, x => x % 100, (x, y) => y.Sum()).ToArray();
        }
    }
}