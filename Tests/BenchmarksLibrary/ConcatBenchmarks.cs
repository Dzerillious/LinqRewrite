using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
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
        
        [Benchmark]
        public void ArrayConcatArrayToArray()
        {
            var res = ArraySource.Concat(ArraySource2).ToArray();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void ArrayConcatArrayToArrayRewritten()
        {
            var res = ArraySource.Concat(ArraySource2).ToArray();
        }//EndMethod
        
        [Benchmark]
        public void ArrayWhereConcatArrayWhereToArray()
        {
            var res = ArraySource.Where(x => x > 500).Concat(ArraySource2.Where(x => x > 500)).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void ArrayWhereConcatArrayWhereToArrayRewritten()
        {
            var res = ArraySource.Where(x => x > 500).Concat(ArraySource2.Where(x => x > 500)).ToArray();
        }//EndMethod
        
        [Benchmark]
        public void ArrayConcatArrayWhereToArray()
        {
            var res = ArraySource.Concat(ArraySource2).Where(x => x > 500).ToArray();
        }//EndMethod

        [Benchmark]
        [LinqRewrite]
		public void ArrayConcatArrayWhereToArrayRewritten()
        {
            var res = ArraySource.Concat(ArraySource2).Where(x => x > 500).ToArray();
        }//EndMethod
        
        [Benchmark]
        public void ArrayConcatMultipleArrayToArray()
        {
            var res = ArraySource.Concat(ArraySource2).Concat(ArraySource2).Concat(ArraySource2).Concat(ArraySource2).ToArray();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void ArrayConcatMultipleArrayToArrayRewritten()
        {
            var res = ArraySource.Concat(ArraySource2).Concat(ArraySource2).Concat(ArraySource2).Concat(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayConcatEnumerableToArray()
        {
            var res = ArraySource.Concat(EnumerableSource2).ToArray();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void ArrayConcatEnumerableToArrayRewritten()
        {
            var res = ArraySource.Concat(EnumerableSource2).ToArray();
        }//EndMethod
        
        [Benchmark]
        public void ArrayWhereConcatEnumerableWhereToArray()
        {
            var res = ArraySource.Where(x => x > 500).Concat(EnumerableSource2.Where(x => x > 500)).ToArray();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void ArrayWhereConcatEnumerableWhereToArrayRewritten()
        {
            var res = ArraySource.Where(x => x > 500).Concat(EnumerableSource2.Where(x => x > 500)).ToArray();
        }//EndMethod
        
        [Benchmark]
        public void EnumerableConcatArrayToArray()
        {
            var res = EnumerableSource.Concat(ArraySource2).ToArray();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void EnumerableConcatArrayToArrayRewritten()
        {
            var res = EnumerableSource.Concat(ArraySource2).ToArray();
        }//EndMethod
        
        [Benchmark]
        public void EnumerableWhereConcatArrayWhereToArray()
        {
            var res = EnumerableSource.Where(x => x > 500).Concat(ArraySource2).Where(x => x > 500).ToArray();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void EnumerableWhereConcatArrayWhereToArrayRewritten()
        {
            var res = EnumerableSource.Where(x => x > 500).Concat(ArraySource2.Where(x => x > 500)).ToArray();
        }//EndMethod
        
        [Benchmark]
        public void EnumerableConcatEnumerableToArray()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToArray();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void EnumerableConcatEnumerableToArrayRewritten()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToArray();
        }//EndMethod
        
        [Benchmark]
        public void EnumerableWhereConcatEnumerableWhereToArray()
        {
            var res = EnumerableSource.Where(x => x > 500).Concat(EnumerableSource2.Where(x => x > 500)).ToArray();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void EnumerableWhereConcatEnumerableWhereToArrayRewritten()
        {
            var res = EnumerableSource.Where(x => x > 500).Concat(EnumerableSource2.Where(x => x > 500)).ToArray();
        }//EndMethod
        
        [Benchmark]
        public void ArrayConcatArrayToSimpleList()
        {
            var res = ArraySource.Concat(ArraySource2).ToSimpleList();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void ArrayConcatArrayToSimpleListRewritten()
        {
            var res = ArraySource.Concat(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereConcatArrayWhereToSimpleList()
        {
            var res = ArraySource.Where(x => x > 500).Concat(ArraySource2.Where(x => x > 500)).ToSimpleList();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void ArrayWhereConcatArrayWhereToSimpleListRewritten()
        {
            var res = ArraySource.Where(x => x > 500).Concat(ArraySource2.Where(x => x > 500)).ToSimpleList();
        }//EndMethod
        
        [Benchmark]
        public void EnumerableConcatEnumerableToSimpleList()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToSimpleList();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void EnumerableConcatEnumerableToSimpleListRewritten()
        {
            var res = EnumerableSource.Concat(EnumerableSource2).ToSimpleList();
        }//EndMethod
        
        [Benchmark]
        public void EnumerableWhereConcatEnumerableWhereToSimpleList()
        {
            var res = EnumerableSource.Where(x => x > 500).Concat(EnumerableSource2.Where(x => x > 500)).ToSimpleList();
        }//EndMethod
        
        [Benchmark]
        [LinqRewrite]
		public void EnumerableWhereConcatEnumerableWhereToSimpleListRewritten()
        {
            var res = EnumerableSource.Where(x => x > 500).Concat(EnumerableSource2.Where(x => x > 500)).ToSimpleList();
        }//EndMethod
    }
}