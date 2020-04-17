using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
    public class CastBenchmarks
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
        public void ArrayCast()
        {
            ArraySource.Cast<int>();
        }//EndMethod

		[Benchmark]
        public void ArrayCastRewritten()
        {
            ArraySource.Cast<int>();
        }//EndMethod


        [NoRewrite, Benchmark]
        public void ArrayCastToArray()
        {
            ArraySource.Cast<int>().ToArray();
        }//EndMethod

		[Benchmark]
        public void ArrayCastToArrayRewritten()
        {
            ArraySource.Cast<int>().ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void ArrayCastArrayToArray()
        {
            ArraySource.Cast<int>().ToArray();
        }//EndMethod

		[Benchmark]
        public void ArrayCastArrayToArrayRewritten()
        {
            ArraySource.Cast<int>().ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void EnumerableCastToArray()
        {
            EnumerableSource.Cast<int>().ToArray();
        }//EndMethod

		[Benchmark]
        public void EnumerableCastToArrayRewritten()
        {
            EnumerableSource.Cast<int>().ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void EnumerableCastArrayToArray()
        {
            EnumerableSource.Cast<int>().ToArray();
        }//EndMethod

		[Benchmark]
        public void EnumerableCastArrayToArrayRewritten()
        {
            EnumerableSource.Cast<int>().ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void ArrayCastToSimpleList()
        {
            ArraySource.Cast<int>().ToSimpleList();
        }//EndMethod

		[Benchmark]
        public void ArrayCastToSimpleListRewritten()
        {
            ArraySource.Cast<int>().ToSimpleList();
        }//EndMethod


        [NoRewrite, Benchmark]
        public void StaticArrayCastToArray()
        {
            StaticArraySource.Cast<int>().ToArray();
        }//EndMethod

		[Benchmark]
        public void StaticArrayCastToArrayRewritten()
        {
            StaticArraySource.Cast<int>().ToArray();
        }//EndMethod


        [NoRewrite, Benchmark]
        public void ArrayUncheckedCastToArray()
        {
            ArraySource.Unchecked().Cast<int>().ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayUncheckedCastToArrayRewritten()
        {
            ArraySource.Unchecked().Cast<int>().ToArray();
        }//EndMethod
    }
}

