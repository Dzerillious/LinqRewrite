using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
    public class WhereBenchmarks
    {
        public static int[] StaticArraySource;
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            StaticArraySource = Enumerable.Range(0, 100).ToArray();
            ArraySource = Enumerable.Range(0, 100).ToArray();
            EnumerableSource = Enumerable.Range(0, 100);
        }

        [NoRewrite]
        [Benchmark]
        public void Select1()
        {
            ArraySource.Where(x => x > 1).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select2()
        {
            ArraySource.Where(x => x > 1).ToSimpleList();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select3()
        {
            ArraySource.Where(x => x > 500).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select4()
        {
            ArraySource.Where(x => x > 500).ToSimpleList();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select5()
        {
            ArraySource.Where(x => x > 1000).ToArray();
        }
        
        [NoRewrite]
        [Benchmark]
        public void Select6()
        {
            ArraySource.Where(x => x > 1000).ToSimpleList();
        }
        
        [Benchmark]
        public void Select1Rewritten()
        {
            ArraySource.Where(x => x > 1).ToArray();
        }
        
        [Benchmark]
        public void Select2Rewritten()
        {
            ArraySource.Where(x => x > 1).ToSimpleList();
        }
        
        [Benchmark]
        public void Select3Rewritten()
        {
            ArraySource.Where(x => x > 500).ToArray();
        }
        
        [Benchmark]
        public void Select4Rewritten()
        {
            ArraySource.Where(x => x > 500).ToSimpleList();
        }
        
        [Benchmark]
        public void Select5Rewritten()
        {
            ArraySource.Where(x => x > 1000).ToArray();
        }
        
        [Benchmark]
        public void Select6Rewritten()
        {
            ArraySource.Where(x => x > 1000).ToSimpleList();
        }
    }
}