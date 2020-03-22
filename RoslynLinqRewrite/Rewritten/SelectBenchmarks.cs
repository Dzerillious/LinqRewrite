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
        StaticArraySource = GlobalSetup_ProceduralLinq1();
        ArraySource = GlobalSetup_ProceduralLinq2();
        EnumerableSource = GlobalSetup_ProceduralLinq3();
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
        ArraySource.Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3);
    }

    [NoRewrite]
    [Benchmark]
    public void Select8()
    {
        ArraySource.Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).ToArray();
    }

    [NoRewrite]
    [Benchmark]
    public void Select9()
    {
        ArraySource.Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x);
    }

    [NoRewrite]
    [Benchmark]
    public void Select10()
    {
        ArraySource.Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).ToArray();
    }

    [NoRewrite]
    [Benchmark]
    public void Select11()
    {
        ArraySource.Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector);
    }

    [NoRewrite]
    [Benchmark]
    public void Select12()
    {
        ArraySource.Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).ToArray();
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
        EnumerableSource.Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).ToArray();
    }

    [NoRewrite]
    [Benchmark]
    public void Select17()
    {
        EnumerableSource.Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).ToArray();
    }

    [NoRewrite]
    [Benchmark]
    public void Select18()
    {
        ArraySource.Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).ToArray();
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
        StaticArraySource.Select(x => x + 3);
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
        Select1Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select2Rewritten()
    {
        Select2Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select3Rewritten()
    {
        Select3Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select4Rewritten()
    {
        Select4Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select5Rewritten()
    {
        Select5Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select6Rewritten()
    {
        Select6Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select7Rewritten()
    {
        Select7Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select8Rewritten()
    {
        Select8Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select9Rewritten()
    {
        Select9Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select10Rewritten()
    {
        Select10Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select11Rewritten()
    {
        Select11Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select12Rewritten()
    {
        Select12Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select13Rewritten()
    {
        Select13Rewritten_ProceduralLinq1(EnumerableSource);
    }

    [Benchmark]
    public void Select14Rewritten()
    {
        Select14Rewritten_ProceduralLinq1(EnumerableSource);
    }

    [Benchmark]
    public void Select15Rewritten()
    {
        Select15Rewritten_ProceduralLinq1(EnumerableSource);
    }

    [Benchmark]
    public void Select16Rewritten()
    {
        Select16Rewritten_ProceduralLinq1(EnumerableSource);
    }

    [Benchmark]
    public void Select17Rewritten()
    {
        Select17Rewritten_ProceduralLinq1(EnumerableSource);
    }

    [Benchmark]
    public void Select18Rewritten()
    {
        Select18Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select19Rewritten()
    {
        Select19Rewritten_ProceduralLinq1(ArraySource);
    }

    [Benchmark]
    public void Select20Rewritten()
    {
        Select20Rewritten_ProceduralLinq1(StaticArraySource);
    }

    [Benchmark]
    public void Select21Rewritten()
    {
        StaticSelectBenchmarks.Select21Rewritten();
    }

    int[] GlobalSetup_ProceduralLinq1()
    {
        int v0;
        int[] v1;
        v1 = new int[100];
        v0 = 0;
        for (; v0 < 100; v0++)
            v1[v0] = (v0 + 0);
        return v1;
    }

    int[] GlobalSetup_ProceduralLinq2()
    {
        int v2;
        int[] v3;
        v3 = new int[100];
        v2 = 0;
        for (; v2 < 100; v2++)
            v3[v2] = (v2 + 0);
        return v3;
    }

    System.Collections.Generic.IEnumerable<int> GlobalSetup_ProceduralLinq3()
    {
        int v4;
        v4 = 0;
        for (; v4 < 100; v4++)
            yield return (v4 + 0);
    }

    System.Collections.Generic.IEnumerable<int> Select1Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v5;
        v5 = 0;
        for (; v5 < ArraySource.Length; v5++)
            yield return (ArraySource[v5] + 3);
    }

    int[] Select2Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v6;
        int[] v7;
        v7 = new int[ArraySource.Length];
        v6 = 0;
        for (; v6 < ArraySource.Length; v6++)
            v7[v6] = (ArraySource[v6] + 3);
        return v7;
    }

    System.Collections.Generic.IEnumerable<int> Select3Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v8;
        v8 = 0;
        for (; v8 < ArraySource.Length; v8++)
            yield return Selector(ArraySource[v8]);
    }

    int[] Select4Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v9;
        int[] v10;
        v10 = new int[ArraySource.Length];
        v9 = 0;
        for (; v9 < ArraySource.Length; v9++)
            v10[v9] = Selector(ArraySource[v9]);
        return v10;
    }

    System.Collections.Generic.IEnumerable<int[]> Select5Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v11;
        v11 = 0;
        for (; v11 < ArraySource.Length; v11++)
            yield return (new int[10]);
    }

    int[][] Select6Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v12;
        int[][] v13;
        v13 = new int[ArraySource.Length][];
        v12 = 0;
        for (; v12 < ArraySource.Length; v12++)
            v13[v12] = (new int[10]);
        return v13;
    }

    System.Collections.Generic.IEnumerable<int> Select7Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v14;
        v14 = 0;
        for (; v14 < ArraySource.Length; v14++)
            yield return ((((((((((ArraySource[v14] + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3);
    }

    int[] Select8Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v15;
        int[] v16;
        v16 = new int[ArraySource.Length];
        v15 = 0;
        for (; v15 < ArraySource.Length; v15++)
            v16[v15] = ((((((((((ArraySource[v15] + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3);
        return v16;
    }

    System.Collections.Generic.IEnumerable<int> Select9Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v17;
        int v18;
        int v19;
        int v20;
        int v21;
        int v22;
        int v23;
        int v24;
        int v25;
        int v26;
        v17 = 0;
        for (; v17 < ArraySource.Length; v17++)
        {
            v18 = (ArraySource[v17] + ArraySource[v17]);
            v19 = (v18 + v18);
            v20 = (v19 + v19);
            v21 = (v20 + v20);
            v22 = (v21 + v21);
            v23 = (v22 + v22);
            v24 = (v23 + v23);
            v25 = (v24 + v24);
            v26 = (v25 + v25);
            yield return (v26 + v26);
        }
    }

    int[] Select10Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v27;
        int v28;
        int v29;
        int v30;
        int v31;
        int v32;
        int v33;
        int v34;
        int v35;
        int v36;
        int[] v37;
        v37 = new int[ArraySource.Length];
        v27 = 0;
        for (; v27 < ArraySource.Length; v27++)
        {
            v28 = (ArraySource[v27] + ArraySource[v27]);
            v29 = (v28 + v28);
            v30 = (v29 + v29);
            v31 = (v30 + v30);
            v32 = (v31 + v31);
            v33 = (v32 + v32);
            v34 = (v33 + v33);
            v35 = (v34 + v34);
            v36 = (v35 + v35);
            v37[v27] = (v36 + v36);
        }

        return v37;
    }

    System.Collections.Generic.IEnumerable<int> Select11Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v38;
        v38 = 0;
        for (; v38 < ArraySource.Length; v38++)
            yield return Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(ArraySource[v38]))))))))));
    }

    int[] Select12Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v39;
        int[] v40;
        v40 = new int[ArraySource.Length];
        v39 = 0;
        for (; v39 < ArraySource.Length; v39++)
            v40[v39] = Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(ArraySource[v39]))))))))));
        return v40;
    }

    int[] Select13Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v41;
        int v42;
        int v43;
        int[] v44;
        v42 = 0;
        v43 = 8;
        v44 = new int[8];
        v41 = EnumerableSource.GetEnumerator();
        try
        {
            while (v41.MoveNext())
            {
                if (v42 >= v43)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v44, ref v43);
                v44[v42] = (v41.Current + 3);
                v42++;
            }
        }
        finally
        {
            v41.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v44, v42);
    }

    int[] Select14Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v45;
        int v46;
        int v47;
        int[] v48;
        v46 = 0;
        v47 = 8;
        v48 = new int[8];
        v45 = EnumerableSource.GetEnumerator();
        try
        {
            while (v45.MoveNext())
            {
                if (v46 >= v47)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v48, ref v47);
                v48[v46] = Selector(v45.Current);
                v46++;
            }
        }
        finally
        {
            v45.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v48, v46);
    }

    int[][] Select15Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v49;
        int v50;
        int v51;
        int[][] v52;
        v50 = 0;
        v51 = 8;
        v52 = new int[8][];
        v49 = EnumerableSource.GetEnumerator();
        try
        {
            while (v49.MoveNext())
            {
                if (v50 >= v51)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v52, ref v51);
                v52[v50] = (new int[10]);
                v50++;
            }
        }
        finally
        {
            v49.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v52, v50);
    }

    int[] Select16Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v53;
        int v54;
        int v55;
        int[] v56;
        v54 = 0;
        v55 = 8;
        v56 = new int[8];
        v53 = EnumerableSource.GetEnumerator();
        try
        {
            while (v53.MoveNext())
            {
                if (v54 >= v55)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v56, ref v55);
                v56[v54] = ((((((((((v53.Current + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3);
                v54++;
            }
        }
        finally
        {
            v53.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v56, v54);
    }

    int[] Select17Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v57;
        int v58;
        int v59;
        int v60;
        int v61;
        int v62;
        int v63;
        int v64;
        int v65;
        int v66;
        int v67;
        int v68;
        int v69;
        int[] v70;
        v68 = 0;
        v69 = 8;
        v70 = new int[8];
        v57 = EnumerableSource.GetEnumerator();
        try
        {
            while (v57.MoveNext())
            {
                v58 = v57.Current;
                v59 = (v58 + v58);
                v60 = (v59 + v59);
                v61 = (v60 + v60);
                v62 = (v61 + v61);
                v63 = (v62 + v62);
                v64 = (v63 + v63);
                v65 = (v64 + v64);
                v66 = (v65 + v65);
                v67 = (v66 + v66);
                if (v68 >= v69)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v70, ref v69);
                v70[v68] = (v67 + v67);
                v68++;
            }
        }
        finally
        {
            v57.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v70, v68);
    }

    int[] Select18Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v71;
        int[] v72;
        v72 = new int[ArraySource.Length];
        v71 = 0;
        for (; v71 < ArraySource.Length; v71++)
            v72[v71] = Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(ArraySource[v71]))))))))));
        return v72;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> Select19Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v73;
        int[] v74;
        SimpleList<int> v75;
        v74 = new int[ArraySource.Length];
        v73 = 0;
        for (; v73 < ArraySource.Length; v73++)
            v74[v73] = (ArraySource[v73] + 3);
        v75 = new SimpleList<int>();
        v75.Items = v74;
        v75.Count = ArraySource.Length;
        return v75;
    }

    System.Collections.Generic.IEnumerable<int> Select20Rewritten_ProceduralLinq1(int[] StaticArraySource)
    {
        int v76;
        v76 = 0;
        for (; v76 < StaticArraySource.Length; v76++)
            yield return (StaticArraySource[v76] + 3);
    }
}public static class StaticSelectBenchmarks
{
    public static int[] ArraySource = Enumerable.Range(1, 100).ToArray();
    [NoRewrite]
    public static void Select21()
    {
        ArraySource.Select(x => x + 3);
    }

    public static void Select21Rewritten()
    {
        Select21Rewritten_ProceduralLinq1(ArraySource);
    }

    static System.Collections.Generic.IEnumerable<int> Select21Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v77;
        v77 = 0;
        for (; v77 < ArraySource.Length; v77++)
            yield return (ArraySource[v77] + 3);
    }
}}

