using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
    public class WhereBenchmarks
    {
        public static int[] StaticArraySource;
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;
        [Params(0, 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000)]
        public int Offset { get; set; } = 10;

        [GlobalSetup]
        public void GlobalSetup()
        {
            StaticArraySource = Enumerable.Range(0, 100).ToArray();
            ArraySource = Enumerable.Range(0, 100).ToArray();
            EnumerableSource = Enumerable.Range(0, 100);
        }

        [NoRewrite, Benchmark]
        public void ArrayWhereToArray()
        {
            ArraySource.Where(x => x < Offset).ToArray();
        }//EndMethod

		[Benchmark]
        public void ArrayWhereToArrayRewritten()
        {
            ArraySource.Where(x => x < Offset).ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void ArrayWhereToSimpleList()
        {
            ArraySource.Where(x => x < Offset).ToSimpleList();
        }//EndMethod

		[Benchmark]
        public void ArrayWhereToSimpleListRewritten()
        {
            ArraySource.Where(x => x < Offset).ToSimpleList();
        }//EndMethod

    }
}