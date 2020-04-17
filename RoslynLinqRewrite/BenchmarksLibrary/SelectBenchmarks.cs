using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
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

        [NoRewrite, Benchmark]
        public void ArraySelect()
        {
            ArraySource.Select(x => x + 3);
        }//EndMethod

		[Benchmark]
        public void ArraySelectRewritten()
        {
            ArraySource.Select(x => x + 3);
        }//EndMethod


        [NoRewrite, Benchmark]
        public void ArraySelectToArray()
        {
            ArraySource.Select(x => x + 3).ToArray();
        }//EndMethod

		[Benchmark]
        public void ArraySelectToArrayRewritten()
        {
            ArraySource.Select(x => x + 3).ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void ArraySelectMethod()
        {
            ArraySource.Select(Selector);
        }//EndMethod

		[Benchmark]
        public void ArraySelectMethodRewritten()
        {
            ArraySource.Select(Selector);
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void ArraySelectMethodToArray()
        {
            ArraySource.Select(Selector).ToArray();
        }//EndMethod

		[Benchmark]
        public void ArraySelectMethodToArrayRewritten()
        {
            ArraySource.Select(Selector).ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void ArraySelectArray()
        {
            ArraySource.Select(x => new int[10]);
        }//EndMethod

		[Benchmark]
        public void ArraySelectArrayRewritten()
        {
            ArraySource.Select(x => new int[10]);
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void ArraySelectArrayToArray()
        {
            ArraySource.Select(x => new int[10]).ToArray();
        }//EndMethod

		[Benchmark]
        public void ArraySelectArrayToArrayRewritten()
        {
            ArraySource.Select(x => new int[10]).ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
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

		[Benchmark]
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

        
        [NoRewrite, Benchmark]
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

		[Benchmark]
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

        
        [NoRewrite, Benchmark]
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

		[Benchmark]
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

        
        [NoRewrite, Benchmark]
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

		[Benchmark]
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

        
        [NoRewrite, Benchmark]
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

		[Benchmark]
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

        
        [NoRewrite, Benchmark]
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

		[Benchmark]
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

        
        [NoRewrite, Benchmark]
        public void EnumerableSelectToArray()
        {
            EnumerableSource.Select(x => x + 3).ToArray();
        }//EndMethod

		[Benchmark]
        public void EnumerableSelectToArrayRewritten()
        {
            EnumerableSource.Select(x => x + 3).ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void EnumerableSelectMethodToArray()
        {
            EnumerableSource.Select(Selector).ToArray();
        }//EndMethod

		[Benchmark]
        public void EnumerableSelectMethodToArrayRewritten()
        {
            EnumerableSource.Select(Selector).ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
        public void EnumerableSelectArrayToArray()
        {
            EnumerableSource.Select(x => new int[10]).ToArray();
        }//EndMethod

		[Benchmark]
        public void EnumerableSelectArrayToArrayRewritten()
        {
            EnumerableSource.Select(x => new int[10]).ToArray();
        }//EndMethod

        
        [NoRewrite, Benchmark]
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

		[Benchmark]
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

        
        [NoRewrite, Benchmark]
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

		[Benchmark]
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

        
        [NoRewrite, Benchmark]
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

		[Benchmark]
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

        
        [NoRewrite, Benchmark]
        public void ArraySelectToSimpleList()
        {
            ArraySource.Select(x => x + 3).ToSimpleList();
        }//EndMethod

		[Benchmark]
        public void ArraySelectToSimpleListRewritten()
        {
            ArraySource.Select(x => x + 3).ToSimpleList();
        }//EndMethod


        [NoRewrite, Benchmark]
        public void StaticArraySelectToArray()
        {
            StaticArraySource.Select(x => x + 3).ToArray();
        }//EndMethod

		[Benchmark]
        public void StaticArraySelectToArrayRewritten()
        {
            StaticArraySource.Select(x => x + 3).ToArray();
        }//EndMethod


        [NoRewrite, Benchmark]
        public void StaticClassArraySelectToArray()
        {
            StaticSelectBenchmarks.StaticClassSelectToArray();
        }//EndMethod

		[Benchmark]
        public void StaticClassArraySelectToArrayRewritten()
        {
            StaticSelectBenchmarks.StaticClassSelectToArrayRewritten();
        }//EndMethod

    }
    
    public static class StaticSelectBenchmarks
    {
        public static int[] ArraySource = Enumerable.Range(1, 100).ToArray();

        [NoRewrite]
        public static void StaticClassSelectToArray()
        {
            ArraySource.Select(x => x + 3).ToArray();;
        }//EndMethod

        public static void StaticClassSelectToArrayRewritten()
        {
            ArraySource.Select(x => x + 3).ToArray();;
        }//EndMethod
    }
}

