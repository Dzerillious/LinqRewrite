// |            Method |         Mean |      Error |     StdDev |
// |------------------ |-------------:|-----------:|-----------:|
// |           Select1 |    16.490 ns |  0.3010 ns |  0.2815 ns |
// |           Select2 |   923.054 ns |  5.4813 ns |  5.1272 ns |
// |           Select3 |    19.646 ns |  0.2869 ns |  0.2396 ns |
// |           Select4 |   948.310 ns | 12.0865 ns | 11.3057 ns |
// |           Select5 |    17.094 ns |  0.2567 ns |  0.2401 ns |
// |           Select6 | 3,442.870 ns | 48.4995 ns | 45.3665 ns |
// |           Select7 |   386.058 ns |  3.4987 ns |  3.2727 ns |
// |           Select8 | 4,725.674 ns | 69.5056 ns | 65.0155 ns |
// |           Select9 |   384.046 ns |  5.5193 ns |  5.1627 ns |
// |          Select10 | 4,753.910 ns | 63.6624 ns | 56.4351 ns |
// |          Select11 |   412.332 ns |  6.8113 ns |  6.3713 ns |
// |          Select12 | 4,471.375 ns | 60.1310 ns | 56.2466 ns |
// |          Select13 | 1,459.116 ns | 27.6795 ns | 31.8758 ns |
// |          Select14 | 1,390.123 ns | 25.9921 ns | 24.3130 ns |
// |          Select15 | 4,281.991 ns | 38.2896 ns | 35.8162 ns |
// |          Select16 | 5,046.499 ns | 98.5238 ns | 87.3388 ns |
// |          Select17 | 5,027.425 ns | 83.4463 ns | 73.9730 ns |
// |          Select18 | 4,522.842 ns | 70.8840 ns | 59.1913 ns |
// |  Select1Rewritten |     5.824 ns |  0.1338 ns |  0.1251 ns |
// |  Select2Rewritten |    79.497 ns |  1.3094 ns |  1.2248 ns |
// |  Select3Rewritten |     9.045 ns |  0.1160 ns |  0.1029 ns |
// |  Select4Rewritten |    79.871 ns |  1.1760 ns |  1.1001 ns |
// |  Select5Rewritten |     5.783 ns |  0.1380 ns |  0.1291 ns |
// |  Select6Rewritten | 1,475.414 ns | 26.4873 ns | 24.7762 ns |
// |  Select7Rewritten |     5.907 ns |  0.1144 ns |  0.1070 ns |
// |  Select8Rewritten |    79.271 ns |  1.1172 ns |  1.0450 ns |
// |  Select9Rewritten |     5.841 ns |  0.1017 ns |  0.0951 ns |
// | Select10Rewritten |   187.909 ns |  3.1657 ns |  2.9612 ns |
// | Select11Rewritten |     8.848 ns |  0.1678 ns |  0.1570 ns |
// | Select12Rewritten |   143.173 ns |  2.1880 ns |  2.0467 ns |
// | Select13Rewritten |   599.020 ns | 11.1283 ns | 10.4094 ns |
// | Select14Rewritten |   606.290 ns |  5.0545 ns |  4.7280 ns |
// | Select15Rewritten | 1,987.653 ns | 36.1564 ns | 33.8207 ns |
// | Select16Rewritten |   598.948 ns | 10.7671 ns | 10.0716 ns |
// | Select17Rewritten |   671.481 ns | 10.9307 ns | 10.2246 ns |
// | Select18Rewritten |   143.900 ns |  1.9064 ns |  1.7832 ns |

using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class SelectBenchmarks
    {
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;
        public int Selector(int a) => a + 3;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(0, 100).ToArray();
            EnumerableSource = Enumerable.Range(0, 100);
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
    }
}

