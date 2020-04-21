using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
    [MemoryDiagnoser]
    public class UnionBenchmarks
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
        public void ArrayUnionArrayToArray()
        {
            var res = ArraySource.Union(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayUnionArrayToArrayRewritten()
        {
            var res = ArraySource.Union(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereUnionArrayWhereToArray()
        {
            var res = ArraySource.Union(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereUnionArrayWhereToArrayRewritten()
        {
            var res = ArraySource.Union(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayUnionEnumerableToArray()
        {
            var res = ArraySource.Union(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayUnionEnumerableToArrayRewritten()
        {
            var res = ArraySource.Union(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereUnionEnumerableWhereToArray()
        {
            var res = ArraySource.Union(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereUnionEnumerableWhereToArrayRewritten()
        {
            var res = ArraySource.Union(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableUnionArrayToArray()
        {
            var res = EnumerableSource.Union(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableUnionArrayToArrayRewritten()
        {
            var res = EnumerableSource.Union(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableWhereUnionArrayWhereToArray()
        {
            var res = EnumerableSource.Union(ArraySource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereUnionArrayWhereToArrayRewritten()
        {
            var res = EnumerableSource.Union(ArraySource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableUnionEnumerableToArray()
        {
            var res = EnumerableSource.Union(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableUnionEnumerableToArrayRewritten()
        {
            var res = EnumerableSource.Union(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableWhereUnionEnumerableWhereToArray()
        {
            var res = EnumerableSource.Union(EnumerableSource2).ToArray();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereUnionEnumerableWhereToArrayRewritten()
        {
            var res = EnumerableSource.Union(EnumerableSource2).ToArray();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayUnionArrayToSimpleList()
        {
            var res = ArraySource.Union(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void ArrayUnionArrayToSimpleListRewritten()
        {
            var res = ArraySource.Union(ArraySource2).ToSimpleList();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void ArrayWhereUnionArrayWhereToSimpleList()
        {
            var res = ArraySource.Union(ArraySource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void ArrayWhereUnionArrayWhereToSimpleListRewritten()
        {
            var res = ArraySource.Union(ArraySource2).ToSimpleList();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableUnionEnumerableToSimpleList()
        {
            var res = EnumerableSource.Union(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void EnumerableUnionEnumerableToSimpleListRewritten()
        {
            var res = EnumerableSource.Union(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [NoRewrite, Benchmark]
        public void EnumerableWhereUnionEnumerableWhereToSimpleList()
        {
            var res = EnumerableSource.Union(EnumerableSource2).ToSimpleList();
        }//EndMethod

        [Benchmark]
        public void EnumerableWhereUnionEnumerableWhereToSimpleListRewritten()
        {
            var res = EnumerableSource.Union(EnumerableSource2).ToSimpleList();
        }//EndMethod
    }
}