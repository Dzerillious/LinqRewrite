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
            StaticArraySource = Enumerable.Range(0, 100).ToArray();
            ArraySource = Enumerable.Range(0, 100).ToArray();
            EnumerableSource = Enumerable.Range(0, 100);
            var _ = StaticSelectBenchmarks.ArraySource;
        }

        [NoRewrite]
        [Benchmark]
        public void Select1()
        {
            ArraySource.Select(x => x + 3);
        }

        [NoRewrite]
        [Benchmark]
        public void Select2()
        {
            ArraySource.Select(x => x + 3).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select3()
        {
            ArraySource.Select(Selector);
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select4()
        {
            ArraySource.Select(Selector).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select5()
        {
            ArraySource.Select(x => new int[10]);
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select6()
        {
            ArraySource.Select(x => new int[10]).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select7()
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
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select8()
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
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select9()
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
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select10()
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
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select11()
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
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select12()
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
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select13()
        {
            EnumerableSource.Select(x => x + 3).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select14()
        {
            EnumerableSource.Select(Selector).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select15()
        {
            EnumerableSource.Select(x => new int[10]).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select16()
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
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select17()
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
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select18()
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
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select19()
        {
            ArraySource.Select(x => x + 3).ToSimpleList();
        }

        [NoRewrite]
        [Benchmark]
        public void Select20()
        {
            StaticArraySource.Select(x => x + 3).ToArray();;
        }

        [NoRewrite]
        [Benchmark]
        public void Select21()
        {
            StaticSelectBenchmarks.Select21();
        }
        
        [Benchmark]
        public void Select1Rewritten()
        {
            ArraySource.Select(x => x + 3);
        }
        
        [Benchmark]
        public void Select2Rewritten()
        {
            ArraySource.Select(x => x + 3).ToArray();
        }
        
        [Benchmark]
        public void Select3Rewritten()
        {
            ArraySource.Select(Selector);
        }
        
        [Benchmark]
        public void Select4Rewritten()
        {
            ArraySource.Select(Selector).ToArray();
        }
        
        [Benchmark]
        public void Select5Rewritten()
        {
            ArraySource.Select(x => new int[10]);
        }
        
        [Benchmark]
        public void Select6Rewritten()
        {
            ArraySource.Select(x => new int[10]).ToArray();
        }
        
        [Benchmark]
        public void Select7Rewritten()
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
        }
        
        [Benchmark]
        public void Select8Rewritten()
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
        }
        
        [Benchmark]
        public void Select9Rewritten()
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
        }
        
        [Benchmark]
        public void Select10Rewritten()
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
        }
        
        [Benchmark]
        public void Select11Rewritten()
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
        }
        
        [Benchmark]
        public void Select12Rewritten()
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
        }
        
        [Benchmark]
        public void Select13Rewritten()
        {
            EnumerableSource.Select(x => x + 3).ToArray();
        }
        
        [Benchmark]
        public void Select14Rewritten()
        {
            EnumerableSource.Select(Selector).ToArray();
        }
        
        [Benchmark]
        public void Select15Rewritten()
        {
            EnumerableSource.Select(x => new int[10]).ToArray();
        }
        
        [Benchmark]
        public void Select16Rewritten()
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
        }
        
        [Benchmark]
        public void Select17Rewritten()
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
        }
        
        [Benchmark]
        public void Select18Rewritten()
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
        }
        
        [Benchmark]
        public void Select19Rewritten()
        {
            ArraySource.Select(x => x + 3).ToSimpleList();
        }

        [Benchmark]
        public void Select20Rewritten()
        {
            StaticArraySource.Select(x => x + 3).ToArray();;
        }

        [Benchmark]
        public void Select21Rewritten()
        {
            StaticSelectBenchmarks.Select21Rewritten();
        }
    }
    
    public static class StaticSelectBenchmarks
    {
        public static int[] ArraySource = Enumerable.Range(1, 100).ToArray();

        [NoRewrite]
        public static void Select21()
        {
            ArraySource.Select(x => x + 3).ToArray();;
        }

        public static void Select21Rewritten()
        {
            ArraySource.Select(x => x + 3).ToArray();;
        }
    }
}

