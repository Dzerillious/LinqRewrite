using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class ToSimpleListBenchmarks
    {
        [Params(0, 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000, 2000)]
        public int Offset { get; set; } = 10;
        
        public static int[] StaticArraySource;
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;

        [IterationSetup]
        public void IterationSetup()
        {
            StaticArraySource = Enumerable.Range(0, Offset).ToArray();
            ArraySource = Enumerable.Range(0, Offset).ToArray();
            EnumerableSource = Enumerable.Range(0, Offset);
        }

        [Benchmark]
        public void ArrayToSimpleList()
        {
            ArraySource.ToSimpleList();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void ArrayToSimpleListRewritten()
        {
            ArraySource.ToSimpleList(EnlargingCoefficient.By2);
        }//EndMethod

        [Benchmark]
        public void RangeToSimpleList()
        {
            Enumerable.Range(0, Offset).ToSimpleList();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void RangeToSimpleListRewritten()
        {
            Enumerable.Range(0, Offset).ToSimpleList(EnlargingCoefficient.By2);
        }//EndMethod

        [Benchmark]
        public void EnumerableToSimpleList()
        {
            EnumerableSource.ToSimpleList();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void EnumerableToSimpleListBy2Rewritten()
        {
            EnumerableSource.ToSimpleList(EnlargingCoefficient.By2);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void EnumerableToSimpleListBy4Rewritten()
        {
            EnumerableSource.ToSimpleList(EnlargingCoefficient.By4);
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void EnumerableToSimpleListBy8Rewritten()
        {
            EnumerableSource.ToSimpleList(EnlargingCoefficient.By8);
        }//EndMethod
    }
}