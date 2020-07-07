using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class OfTypeBenchmarks
    {
        public class A {}
        public class B : A {}
        
        public static A[] StaticArraySource;
        public A[] ArraySource;
        public IEnumerable<A> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            StaticArraySource = Enumerable.Repeat(new B(), 1000).ToArray();
            ArraySource = Enumerable.Repeat(new B(), 1000).ToArray();
            EnumerableSource = Enumerable.Repeat(new B(), 1000);
        }


        [Benchmark]
        public void ArrayOfTypeToArray()
        {
            ArraySource.OfType<B>().ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArrayOfTypeToArrayRewritten()
        {
            ArraySource.OfType<B>().ToArray();
        }//EndMethod

        
        [Benchmark]
        public void EnumerableOfTypeToArray()
        {
            EnumerableSource.OfType<B>().ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void EnumerableOfTypeToArrayRewritten()
        {
            EnumerableSource.OfType<B>().ToArray();
        }//EndMethod

        
        [Benchmark]
        public void ArrayOfTypeToSimpleList()
        {
            ArraySource.OfType<B>().ToSimpleList();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArrayOfTypeToSimpleListRewritten()
        {
            ArraySource.OfType<B>().ToSimpleList();
        }//EndMethod


        [Benchmark]
        public void StaticArrayOfTypeToArray()
        {
            StaticArraySource.OfType<B>().ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void StaticArrayOfTypeToArrayRewritten()
        {
            StaticArraySource.OfType<B>().ToArray();
        }//EndMethod


        [Benchmark]
        public void ArrayUncheckedOfTypeToArray()
        {
            ArraySource.Unchecked().OfType<B>().ToArray();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void ArrayUncheckedOfTypeToArrayRewritten()
        {
            ArraySource.Unchecked().OfType<B>().ToArray();
        }//EndMethod

        
        [Benchmark]
        public void EnumerableUncheckedOfTypeToSimpleList()
        {
            EnumerableSource.OfType<B>().ToArray();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void EnumerableUncheckedToSimpleListRewritten()
        {
            EnumerableSource.OfType<B>().ToArray();
        }//EndMethod
    }
}

