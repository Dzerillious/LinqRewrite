using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class SelectBenchmarks
    {
        public static int[] StaticArraySource;
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;
        public int Selector(int a) => a + 3;

        [GlobalSetup]
        public void GlobalSetup()
        {
            StaticArraySource = Enumerable.Range(0, 1000).ToArray();
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            EnumerableSource = Enumerable.Range(0, 1000);
            var _ = StaticSelectBenchmarks.ArraySource;
        }

        [Benchmark]
        public void ArraySelect()
        {
            ArraySource.Select(x => x + 3);
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectRewritten()
        {
            ArraySource.Select(x => x + 3);
        }//EndMethod


        [Benchmark]
        public void ArraySelectToArray()
        {
            ArraySource.Select(x => x + 3).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectToArrayRewritten()
        {
            ArraySource.Select(x => x + 3).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectMethod()
        {
            ArraySource.Select(Selector);
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectMethodRewritten()
        {
            ArraySource.Select(Selector);
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectMethodToArray()
        {
            ArraySource.Select(Selector).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectMethodToArrayRewritten()
        {
            ArraySource.Select(Selector).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectArray()
        {
            ArraySource.Select(x => new int[10]);
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectArrayRewritten()
        {
            ArraySource.Select(x => new int[10]);
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectArrayToArray()
        {
            ArraySource.Select(x => new int[10]).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectArrayToArrayRewritten()
        {
            ArraySource.Select(x => new int[10]).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectMultiple()
        {
            ArraySource.Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3);
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectMultipleRewritten()
        {
            ArraySource.Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3);
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectMultipleToArray()
        {
            ArraySource.Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectMultipleToArrayRewritten()
        {
            ArraySource.Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectComplexMultiple()
        {
            ArraySource.Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x);
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectComplexMultipleRewritten()
        {
            ArraySource.Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x);
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectComplexMultipleToArray()
        {
            ArraySource.Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectComplexMultipleToArrayRewritten()
        {
            ArraySource.Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectMethodMultiple()
        {
            ArraySource.Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector);
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectMethodMultipleRewritten()
        {
            ArraySource.Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector);
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectMethodMultipleToArray()
        {
            ArraySource.Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectMethodMultipleToArrayRewritten()
        {
            ArraySource.Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void EnumerableSelectToArray()
        {
            EnumerableSource.Select(x => x + 3).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void EnumerableSelectToArrayRewritten()
        {
            EnumerableSource.Select(x => x + 3).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void EnumerableSelectMethodToArray()
        {
            EnumerableSource.Select(Selector).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void EnumerableSelectMethodToArrayRewritten()
        {
            EnumerableSource.Select(Selector).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void EnumerableSelectArrayToArray()
        {
            EnumerableSource.Select(x => new int[10]).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void EnumerableSelectArrayToArrayRewritten()
        {
            EnumerableSource.Select(x => new int[10]).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void EnumerableSelectMultipleToArray()
        {
            EnumerableSource.Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void EnumerableSelectMultipleToArrayRewritten()
        {
            EnumerableSource.Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void EnumerableSelectComplexMultipleToArray()
        {
            EnumerableSource.Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void EnumerableSelectComplexMultipleToArrayRewritten()
        {
            EnumerableSource.Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void EnumerableSelectMethodMultipleToArray()
        {
            ArraySource.Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void EnumerableSelectMethodMultipleToArrayRewritten()
        {
            ArraySource.Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector)
                .Select(Selector).ToArray();
        }//EndMethod

        
        [Benchmark]
        public void ArraySelectToSimpleList()
        {
            ArraySource.Select(x => x + 3).ToSimpleList();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void ArraySelectToSimpleListRewritten()
        {
            ArraySource.Select(x => x + 3).ToSimpleList();
        }//EndMethod


        [Benchmark]
        public void StaticArraySelectToArray()
        {
            StaticArraySource.Select(x => x + 3).ToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void StaticArraySelectToArrayRewritten()
        {
            StaticArraySource.Select(x => x + 3).ToArray();
        }//EndMethod


        [Benchmark]
        public void StaticClassArraySelectToArray()
        {
            StaticSelectBenchmarks.StaticClassSelectToArray();
        }//EndMethod

		[Benchmark, LinqRewrite]
		public void StaticClassArraySelectToArrayRewritten()
        {
            StaticSelectBenchmarks.StaticClassSelectToArrayRewritten();
        }//EndMethod

    }
    
    public static class StaticSelectBenchmarks
    {
        public static int[] ArraySource = Enumerable.Range(1, 100).ToArray();

        public static void StaticClassSelectToArray()
        {
            ArraySource.Select(x => x + 3).ToArray();;
        }//EndMethod

        [LinqRewrite]
		public static void StaticClassSelectToArrayRewritten()
        {
            ArraySource.Select(x => x + 3).ToArray();;
        }//EndMethod
    }
}

