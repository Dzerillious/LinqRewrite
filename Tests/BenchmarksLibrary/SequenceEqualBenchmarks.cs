using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class SequenceEqualBenchmarks
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
        public bool ArraySequenceEqualArray()
        {
            return ArraySource.SequenceEqual(ArraySource2);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public bool ArraySequenceEqualArrayRewritten()
        {
            return ArraySource.SequenceEqual(ArraySource2);
        }//EndMethod

        [Benchmark]
        public bool ArrayWhereSequenceEqualArrayWhere()
        {
            return ArraySource.SequenceEqual(ArraySource2);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public bool ArrayWhereSequenceEqualArrayWhereRewritten()
        {
            return ArraySource.SequenceEqual(ArraySource2);
        }//EndMethod

        [Benchmark]
        public bool ArraySequenceEqualEnumerable()
        {
            return ArraySource.SequenceEqual(EnumerableSource2);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public bool ArraySequenceEqualEnumerableRewritten()
        {
            return ArraySource.SequenceEqual(EnumerableSource2);
        }//EndMethod

        [Benchmark]
        public bool ArrayWhereSequenceEqualEnumerableWhere()
        {
            return ArraySource.SequenceEqual(EnumerableSource2);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public bool ArrayWhereSequenceEqualEnumerableWhereRewritten()
        {
            return ArraySource.SequenceEqual(EnumerableSource2);
        }//EndMethod

        [Benchmark]
        public bool EnumerableSequenceEqualArray()
        {
            return EnumerableSource.SequenceEqual(ArraySource2);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public bool EnumerableSequenceEqualArrayRewritten()
        {
            return EnumerableSource.SequenceEqual(ArraySource2);
        }//EndMethod

        [Benchmark]
        public bool EnumerableWhereSequenceEqualArrayWhere()
        {
            return EnumerableSource.SequenceEqual(ArraySource2);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public bool EnumerableWhereSequenceEqualArrayWhereRewritten()
        {
            return EnumerableSource.SequenceEqual(ArraySource2);
        }//EndMethod

        [Benchmark]
        public bool EnumerableSequenceEqualEnumerable()
        {
            return EnumerableSource.SequenceEqual(EnumerableSource2);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public bool EnumerableSequenceEqualEnumerableRewritten()
        {
            return EnumerableSource.SequenceEqual(EnumerableSource2);
        }//EndMethod

        [Benchmark]
        public bool EnumerableWhereSequenceEqualEnumerableWhere()
        {
            return EnumerableSource.SequenceEqual(EnumerableSource2);
        }//EndMethod

        [Benchmark, LinqRewrite]
		public bool EnumerableWhereSequenceEqualEnumerableWhereRewritten()
        {
            return EnumerableSource.SequenceEqual(EnumerableSource2);
        }//EndMethod
    }
}