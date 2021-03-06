using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class JoinBenchmarks
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
        public void ArrayJoin()
        {
            ArraySource.Join(ArraySource, x => x % 100, x => x % 100, (x, y) => x + y).ToArray();
        }
        
        [Benchmark, LinqRewrite]
		public void ArrayJoinRewritten()
        {
            ArraySource.Join(ArraySource, x => x % 100, x => x % 100, (x, y) => x + y).ToArray();
        }
        
        [Benchmark]
        public void EnumerableJoin()
        {
            EnumerableSource.Join(EnumerableSource, x => x % 100, x => x % 100, (x, y) => x + y).ToArray();
        }
        
        [Benchmark, LinqRewrite]
		public void EnumerableJoinRewritten()
        {
            EnumerableSource.Join(EnumerableSource, x => x % 100, x => x % 100, (x, y) => x + y).ToArray();
        }
    }
}