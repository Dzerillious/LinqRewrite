using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class CastBenchmarks
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
        public void ArrayCastToArray()
        {
            ArraySource.Cast<B>().ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArrayCastToArrayRewritten()
        {
            ArraySource.Cast<B>().ToArray();
        }//EndMethod

        
        [Benchmark]
        public void EnumerableCastToArray()
        {
            EnumerableSource.Cast<B>().ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void EnumerableCastToArrayRewritten()
        {
            EnumerableSource.Cast<B>().ToArray();
        }//EndMethod

        
        [Benchmark]
        public void ArrayCastToSimpleList()
        {
            ArraySource.Cast<B>().ToSimpleList();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArrayCastToSimpleListRewritten()
        {
            ArraySource.Cast<B>().ToSimpleList();
        }//EndMethod


        [Benchmark]
        public void StaticArrayCastToArray()
        {
            StaticArraySource.Cast<B>().ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void StaticArrayCastToArrayRewritten()
        {
            StaticArraySource.Cast<B>().ToArray();
        }//EndMethod


        [Benchmark]
        public void ArrayUncheckedCastToArray()
        {
            ArraySource.Unchecked().Cast<B>().ToArray();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void ArrayUncheckedCastToArrayRewritten()
        {
            ArraySource.Unchecked().Cast<B>().ToArray();
        }//EndMethod

        
        [Benchmark]
        public void EnumerableUncheckedCastToSimpleList()
        {
            EnumerableSource.Cast<B>().ToArray();
        }//EndMethod

        [Benchmark, LinqRewrite]
		public void EnumerableUncheckedToSimpleListRewritten()
        {
            EnumerableSource.Cast<B>().ToArray();
        }//EndMethod
    }
}

