using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class ToArrayBenchmarks
    {
        [Params(0, 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000, 2000)]
        public int Offset { get; set; } = 10;
        
        public static int[] StaticArraySource;
        public int[] ArraySource;

        public IEnumerable<int> EnumerableSource()
        {
            for (int i = 0; i < Offset; i++)
                yield return i;
        }

        [IterationSetup]
        public void IterationSetup()
        {
            StaticArraySource = Enumerable.Range(0, Offset).ToArray();
            ArraySource = Enumerable.Range(0, Offset).ToArray();
        }

        [Benchmark]
        public void ArrayToArray()
        {
            ArraySource.ToArray();
        }//EndMethod
        
        [Benchmark, LinqRewrite]
		public void ArrayToArrayRewritten()
        {
            ArraySource.ToArray(EnlargingCoefficient.By2);
        }//EndMethod
        
        [Benchmark]
        public void RangeToArray()
        {
            Enumerable.Range(0, Offset).ToArray();
        }//EndMethod
        
        [Benchmark, LinqRewrite]
		public void RangeToArrayRewritten()
        {
            Enumerable.Range(0, Offset).ToArray(EnlargingCoefficient.By2);
        }//EndMethod

        [Benchmark]
        public void EnumerableToArray()
        {
            EnumerableSource().ToArray();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void EnumerableToArrayBy2Rewritten()
        {
            EnumerableSource().ToArray(EnlargingCoefficient.By2);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void EnumerableToArrayBy4Rewritten()
        {
            EnumerableSource().ToArray(EnlargingCoefficient.By4);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void EnumerableToArrayBy8Rewritten()
        {
            EnumerableSource().ToArray(EnlargingCoefficient.By8);
        }//EndMethod
    }
}