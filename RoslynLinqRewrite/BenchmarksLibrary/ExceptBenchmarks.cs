using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
    public class ExceptBenchmarks
    {
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;
        public int[] ArraySource2;
        public IEnumerable<int> EnumerableSource2;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            EnumerableSource = Enumerable.Range(0, 1000);
            ArraySource2 = Enumerable.Range(500, 1000).ToArray();
            EnumerableSource2 = Enumerable.Range(500, 1000);
        }

        [NoRewrite, Benchmark]
        public void ArrayExceptArrayToArray()
        {
            var res = ArraySource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayExceptArrayToArrayRewritten()
        {
            var res = ArraySource.Except(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereExceptArrayWhereToArray()
        {
            var res = ArraySource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereExceptArrayWhereToArrayRewritten()
        {
            var res = ArraySource.Except(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayExceptEnumerableToArray()
        {
            var res = ArraySource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayExceptEnumerableToArrayRewritten()
        {
            var res = ArraySource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereExceptEnumerableWhereToArray()
        {
            var res = ArraySource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereExceptEnumerableWhereToArrayRewritten()
        {
            var res = ArraySource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableExceptArrayToArray()
        {
            var res = EnumerableSource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableExceptArrayToArrayRewritten()
        {
            var res = EnumerableSource.Except(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableWhereExceptArrayWhereToArray()
        {
            var res = EnumerableSource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereExceptArrayWhereToArrayRewritten()
        {
            var res = EnumerableSource.Except(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableExceptEnumerableToArray()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableExceptEnumerableToArrayRewritten()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableWhereExceptEnumerableWhereToArray()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereExceptEnumerableWhereToArrayRewritten()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayExceptArrayToSimpleList()
        {
            var res = ArraySource.Except(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void ArrayExceptArrayToSimpleListRewritten()
        {
            var res = ArraySource.Except(ArraySource2).ToSimpleList();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereExceptArrayWhereToSimpleList()
        {
            var res = ArraySource.Except(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereExceptArrayWhereToSimpleListRewritten()
        {
            var res = ArraySource.Except(ArraySource2).ToSimpleList();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableExceptEnumerableToSimpleList()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void EnumerableExceptEnumerableToSimpleListRewritten()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableWhereExceptEnumerableWhereToSimpleList()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereExceptEnumerableWhereToSimpleListRewritten()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToSimpleList();
        }//EndMethod
    }
}