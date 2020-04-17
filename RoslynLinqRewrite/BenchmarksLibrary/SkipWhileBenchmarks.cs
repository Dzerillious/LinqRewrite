using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
    public class SkipWhileBenchmarks
    {
        [Params(-1, 0, 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000, 2000)]
        public int Offset { get; set; } = 10;
        
        public static int[] StaticArraySource;
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            StaticArraySource = Enumerable.Range(0, 1000).ToArray();
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            EnumerableSource = Enumerable.Range(0, 1000);
        }

        [NoRewrite, Benchmark]
        public void ArraySkipWhileToArray()
        {
            ArraySource.SkipWhile(x => x < Offset).ToArray();
        }//EndMethod

		[Benchmark]
        public void ArraySkipWhileToArrayRewritten()
        {
            ArraySource.SkipWhile(x => x < Offset).ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void ArraySkipWhileToSimpleList()
        {
            ArraySource.SkipWhile(x => x < Offset).ToSimpleList();
        }//EndMethod

		[Benchmark]
        public void ArraySkipWhileToSimpleListRewritten()
        {
            ArraySource.SkipWhile(x => x < Offset).ToSimpleList();
        }//EndMethod

    }
}