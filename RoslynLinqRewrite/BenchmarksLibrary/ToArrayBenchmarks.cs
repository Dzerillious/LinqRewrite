using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    [MemoryDiagnoser]
    public class ToArrayBenchmarks
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

        [NoRewrite, Benchmark]
        public void ArrayToArray()
        {
            ArraySource.ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayToArrayRewritten()
        {
            ArraySource.ToArray(EnlargingCoefficient.By2);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void RangeToArray()
        {
            Enumerable.Range(0, Offset).ToArray();
        }//EndMethod

        [Benchmark]
        public void RangeToArrayRewritten()
        {
            Enumerable.Range(0, Offset).ToArray(EnlargingCoefficient.By2);
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableToArray()
        {
            EnumerableSource.ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableToArrayBy2Rewritten()
        {
            EnumerableSource.ToArray(EnlargingCoefficient.By2);
        }//EndMethod

        [Benchmark]
        public void EnumerableToArrayBy4Rewritten()
        {
            EnumerableSource.ToArray(EnlargingCoefficient.By4);
        }//EndMethod

        [Benchmark]
        public void EnumerableToArrayBy8Rewritten()
        {
            EnumerableSource.ToArray(EnlargingCoefficient.By8);
        }//EndMethod
    }
}