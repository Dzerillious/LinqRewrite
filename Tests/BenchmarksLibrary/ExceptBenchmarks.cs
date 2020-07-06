using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
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

        [Benchmark]
        public void ArrayExceptArrayToArray()
        {
            var res = ArraySource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void ArrayExceptArrayToArrayRewritten()
        {
            var res = ArraySource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereExceptArrayWhereToArray()
        {
            var res = ArraySource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void ArrayWhereExceptArrayWhereToArrayRewritten()
        {
            var res = ArraySource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayExceptEnumerableToArray()
        {
            var res = ArraySource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void ArrayExceptEnumerableToArrayRewritten()
        {
            var res = ArraySource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereExceptEnumerableWhereToArray()
        {
            var res = ArraySource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void ArrayWhereExceptEnumerableWhereToArrayRewritten()
        {
            var res = ArraySource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableExceptArrayToArray()
        {
            var res = EnumerableSource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void EnumerableExceptArrayToArrayRewritten()
        {
            var res = EnumerableSource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereExceptArrayWhereToArray()
        {
            var res = EnumerableSource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void EnumerableWhereExceptArrayWhereToArrayRewritten()
        {
            var res = EnumerableSource.Except(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableExceptEnumerableToArray()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void EnumerableExceptEnumerableToArrayRewritten()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereExceptEnumerableWhereToArray()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void EnumerableWhereExceptEnumerableWhereToArrayRewritten()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayExceptArrayToSimpleList()
        {
            var res = ArraySource.Except(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void ArrayExceptArrayToSimpleListRewritten()
        {
            var res = ArraySource.Except(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereExceptArrayWhereToSimpleList()
        {
            var res = ArraySource.Except(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void ArrayWhereExceptArrayWhereToSimpleListRewritten()
        {
            var res = ArraySource.Except(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void EnumerableExceptEnumerableToSimpleList()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void EnumerableExceptEnumerableToSimpleListRewritten()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereExceptEnumerableWhereToSimpleList()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void EnumerableWhereExceptEnumerableWhereToSimpleListRewritten()
        {
            var res = EnumerableSource.Except(EnumerableSource2).ToSimpleList();
        }//EndMethod
    }
}