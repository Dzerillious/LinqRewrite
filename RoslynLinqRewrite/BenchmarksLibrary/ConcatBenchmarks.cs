using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
    public class ConcatBenchmarks
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
        public void ArrayConcatArrayToArray()
        {
            var res = ArraySource.Concat(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayConcatArrayToArrayRewritten()
        {
            var res = ArraySource.Concat(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereConcatArrayWhereToArray()
        {
            var res = ArraySource.Concat(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereConcatArrayWhereToArrayRewritten()
        {
            var res = ArraySource.Concat(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayConcatEnumerableToArray()
        {
            var res = ArraySource.Concat(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayConcatEnumerableToArrayRewritten()
        {
            var res = ArraySource.Concat(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereConcatEnumerableWhereToArray()
        {
            var res = ArraySource.Concat(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereConcatEnumerableWhereToArrayRewritten()
        {
            var res = ArraySource.Concat(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableConcatArrayToArray()
        {
            var res = EnumerableSource.Concat(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableConcatArrayToArrayRewritten()
        {
            var res = EnumerableSource.Concat(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableWhereConcatArrayWhereToArray()
        {
            var res = EnumerableSource.Concat(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereConcatArrayWhereToArrayRewritten()
        {
            var res = EnumerableSource.Concat(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableConcatEnumerableToArray()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableConcatEnumerableToArrayRewritten()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableWhereConcatEnumerableWhereToArray()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereConcatEnumerableWhereToArrayRewritten()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayConcatArrayToSimpleList()
        {
            var res = ArraySource.Concat(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void ArrayConcatArrayToSimpleListRewritten()
        {
            var res = ArraySource.Concat(ArraySource2).ToSimpleList();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereConcatArrayWhereToSimpleList()
        {
            var res = ArraySource.Concat(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereConcatArrayWhereToSimpleListRewritten()
        {
            var res = ArraySource.Concat(ArraySource2).ToSimpleList();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableConcatEnumerableToSimpleList()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void EnumerableConcatEnumerableToSimpleListRewritten()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableWhereConcatEnumerableWhereToSimpleList()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereConcatEnumerableWhereToSimpleListRewritten()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToSimpleList();
        }//EndMethod
    }
}