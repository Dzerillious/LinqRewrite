using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
    public class OfTypeBenchmarks
    {
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
        public void ArrayOfTypeToArray()
        {
            ArraySource.OfType<int>().ToArray();
        }//EndMethod

		[Benchmark]
        public void ArrayOfTypeToArrayRewritten()
        {
            ArraySource.OfType<int>().ToArray();
        }//EndMethod
        
        [NoRewrite, Benchmark]
        public void EnumerableOfTypeToArray()
        {
            EnumerableSource.OfType<int>().ToArray();
        }//EndMethod

		[Benchmark]
        public void EnumerableOfTypeToArrayRewritten()
        {
            EnumerableSource.OfType<int>().ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void ArrayOfTypeToSimpleList()
        {
            ArraySource.OfType<int>().ToSimpleList();
        }//EndMethod

		[Benchmark]
        public void ArrayOfTypeToSimpleListRewritten()
        {
            ArraySource.OfType<int>().ToSimpleList();
        }//EndMethod


        [NoRewrite, Benchmark]
        public void StaticArrayOfTypeToArray()
        {
            StaticArraySource.OfType<int>().ToArray();
        }//EndMethod

		[Benchmark]
        public void StaticArrayOfTypeToArrayRewritten()
        {
            StaticArraySource.OfType<int>().ToArray();
        }//EndMethod


        [NoRewrite, Benchmark]
        public void ArrayUncheckedOfTypeToArray()
        {
            ArraySource.Unchecked().OfType<int>().ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayUncheckedOfTypeToArrayRewritten()
        {
            ArraySource.Unchecked().OfType<int>().ToArray();
        }//EndMethod
    }
}

