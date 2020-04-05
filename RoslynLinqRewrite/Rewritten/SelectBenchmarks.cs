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

    [NoRewrite, Benchmark]
    public void ArraySelect()
    {
        ArraySource.Select(x => x + 3);
    } //EndMethod

    [Benchmark]
    public void ArraySelectRewritten()
    {
        ArraySelectRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectToArray()
    {
        ArraySource.Select(x => x + 3).ToArray();
    } //EndMethod

    [Benchmark]
    public void ArraySelectToArrayRewritten()
    {
        ArraySelectToArrayRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectMethod()
    {
        ArraySource.Select(Selector);
    } //EndMethod

    [Benchmark]
    public void ArraySelectMethodRewritten()
    {
        ArraySelectMethodRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectMethodToArray()
    {
        ArraySource.Select(Selector).ToArray();
    } //EndMethod

    [Benchmark]
    public void ArraySelectMethodToArrayRewritten()
    {
        ArraySelectMethodToArrayRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectArray()
    {
        ArraySource.Select(x => new int[10]);
    } //EndMethod

    [Benchmark]
    public void ArraySelectArrayRewritten()
    {
        ArraySelectArrayRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectArrayToArray()
    {
        ArraySource.Select(x => new int[10]).ToArray();
    } //EndMethod

    [Benchmark]
    public void ArraySelectArrayToArrayRewritten()
    {
        ArraySelectArrayToArrayRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectMultiple()
    {
        ArraySource.Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3);
    } //EndMethod

    [Benchmark]
    public void ArraySelectMultipleRewritten()
    {
        ArraySelectMultipleRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectMultipleToArray()
    {
        ArraySource.Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).ToArray();
    } //EndMethod

    [Benchmark]
    public void ArraySelectMultipleToArrayRewritten()
    {
        ArraySelectMultipleToArrayRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectComplexMultiple()
    {
        ArraySource.Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x);
    } //EndMethod

    [Benchmark]
    public void ArraySelectComplexMultipleRewritten()
    {
        ArraySelectComplexMultipleRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectComplexMultipleToArray()
    {
        ArraySource.Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).ToArray();
    } //EndMethod

    [Benchmark]
    public void ArraySelectComplexMultipleToArrayRewritten()
    {
        ArraySelectComplexMultipleToArrayRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectMethodMultiple()
    {
        ArraySource.Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector);
    } //EndMethod

    [Benchmark]
    public void ArraySelectMethodMultipleRewritten()
    {
        ArraySelectMethodMultipleRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectMethodMultipleToArray()
    {
        ArraySource.Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).ToArray();
    } //EndMethod

    [Benchmark]
    public void ArraySelectMethodMultipleToArrayRewritten()
    {
        ArraySelectMethodMultipleToArrayRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void EnumerableSelectToArray()
    {
        EnumerableSource.Select(x => x + 3).ToArray();
    } //EndMethod

    [Benchmark]
    public void EnumerableSelectToArrayRewritten()
    {
        EnumerableSelectToArrayRewritten_ProceduralLinq1(EnumerableSource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void EnumerableSelectMethodToArray()
    {
        EnumerableSource.Select(Selector).ToArray();
    } //EndMethod

    [Benchmark]
    public void EnumerableSelectMethodToArrayRewritten()
    {
        EnumerableSelectMethodToArrayRewritten_ProceduralLinq1(EnumerableSource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void EnumerableSelectArrayToArray()
    {
        EnumerableSource.Select(x => new int[10]).ToArray();
    } //EndMethod

    [Benchmark]
    public void EnumerableSelectArrayToArrayRewritten()
    {
        EnumerableSelectArrayToArrayRewritten_ProceduralLinq1(EnumerableSource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void EnumerableSelectMultipleToArray()
    {
        EnumerableSource.Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).ToArray();
    } //EndMethod

    [Benchmark]
    public void EnumerableSelectMultipleToArrayRewritten()
    {
        EnumerableSelectMultipleToArrayRewritten_ProceduralLinq1(EnumerableSource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void EnumerableSelectComplexMultipleToArray()
    {
        EnumerableSource.Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).ToArray();
    } //EndMethod

    [Benchmark]
    public void EnumerableSelectComplexMultipleToArrayRewritten()
    {
        EnumerableSelectComplexMultipleToArrayRewritten_ProceduralLinq1(EnumerableSource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void EnumerableSelectMethodMultipleToArray()
    {
        ArraySource.Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).Select(Selector).ToArray();
    } //EndMethod

    [Benchmark]
    public void EnumerableSelectMethodMultipleToArrayRewritten()
    {
        EnumerableSelectMethodMultipleToArrayRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectToSimpleList()
    {
        ArraySource.Select(x => x + 3).ToSimpleList();
    } //EndMethod

    [Benchmark]
    public void ArraySelectToSimpleListRewritten()
    {
        ArraySelectToSimpleListRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void StaticArraySelectToArray()
    {
        StaticArraySource.Select(x => x + 3).ToArray();
    } //EndMethod

    [Benchmark]
    public void StaticArraySelectToArrayRewritten()
    {
        StaticArraySelectToArrayRewritten_ProceduralLinq1(StaticArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void StaticClassArraySelectToArray()
    {
        StaticSelectBenchmarks.StaticClassSelectToArray();
    } //EndMethod

    [Benchmark]
    public void StaticClassArraySelectToArrayRewritten()
    {
        StaticSelectBenchmarks.StaticClassSelectToArrayRewritten();
    } //EndMethod

    int[] GlobalSetup_ProceduralLinq1()
    {
        int v4;
        int[] v5;
        v5 = new int[100];
        v4 = 0;
        for (; v4 < 100; v4++)
            v5[v4] = (v4 + 0);
        return v5;
    }

    int[] GlobalSetup_ProceduralLinq2()
    {
        int v6;
        int[] v7;
        v7 = new int[100];
        v6 = 0;
        for (; v6 < 100; v6++)
            v7[v6] = (v6 + 0);
        return v7;
    }

    System.Collections.Generic.IEnumerable<int> GlobalSetup_ProceduralLinq3()
    {
        int v8;
        v8 = 0;
        for (; v8 < 100; v8++)
            yield return (v8 + 0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v9;
        v9 = 0;
        for (; v9 < ArraySource.Length; v9++)
            yield return (ArraySource[v9] + 3);
        yield break;
    }

    int[] ArraySelectToArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v10;
        int[] v11;
        v11 = new int[ArraySource.Length];
        v10 = 0;
        for (; v10 < ArraySource.Length; v10++)
            v11[v10] = (ArraySource[v10] + 3);
        return v11;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectMethodRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v12;
        v12 = 0;
        for (; v12 < ArraySource.Length; v12++)
            yield return Selector(ArraySource[v12]);
        yield break;
    }

    int[] ArraySelectMethodToArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v13;
        int[] v14;
        v14 = new int[ArraySource.Length];
        v13 = 0;
        for (; v13 < ArraySource.Length; v13++)
            v14[v13] = Selector(ArraySource[v13]);
        return v14;
    }

    System.Collections.Generic.IEnumerable<int[]> ArraySelectArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v15;
        v15 = 0;
        for (; v15 < ArraySource.Length; v15++)
            yield return (new int[10]);
        yield break;
    }

    int[][] ArraySelectArrayToArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v16;
        int[][] v17;
        v17 = new int[ArraySource.Length][];
        v16 = 0;
        for (; v16 < ArraySource.Length; v16++)
            v17[v16] = (new int[10]);
        return v17;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectMultipleRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v18;
        v18 = 0;
        for (; v18 < ArraySource.Length; v18++)
            yield return ((((((((((ArraySource[v18] + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3);
        yield break;
    }

    int[] ArraySelectMultipleToArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v19;
        int[] v20;
        v20 = new int[ArraySource.Length];
        v19 = 0;
        for (; v19 < ArraySource.Length; v19++)
            v20[v19] = ((((((((((ArraySource[v19] + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3);
        return v20;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectComplexMultipleRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v21;
        int v22;
        v21 = 0;
        for (; v21 < ArraySource.Length; v21++)
        {
            v22 = (ArraySource[v21] + ArraySource[v21]);
            v22 = (v22 + v22);
            v22 = (v22 + v22);
            v22 = (v22 + v22);
            v22 = (v22 + v22);
            v22 = (v22 + v22);
            v22 = (v22 + v22);
            v22 = (v22 + v22);
            v22 = (v22 + v22);
            yield return (v22 + v22);
        }

        yield break;
    }

    int[] ArraySelectComplexMultipleToArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v23;
        int v24;
        int[] v25;
        v25 = new int[ArraySource.Length];
        v23 = 0;
        for (; v23 < ArraySource.Length; v23++)
        {
            v24 = (ArraySource[v23] + ArraySource[v23]);
            v24 = (v24 + v24);
            v24 = (v24 + v24);
            v24 = (v24 + v24);
            v24 = (v24 + v24);
            v24 = (v24 + v24);
            v24 = (v24 + v24);
            v24 = (v24 + v24);
            v24 = (v24 + v24);
            v25[v23] = (v24 + v24);
        }

        return v25;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectMethodMultipleRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v26;
        v26 = 0;
        for (; v26 < ArraySource.Length; v26++)
            yield return Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(ArraySource[v26]))))))))));
        yield break;
    }

    int[] ArraySelectMethodMultipleToArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v27;
        int[] v28;
        v28 = new int[ArraySource.Length];
        v27 = 0;
        for (; v27 < ArraySource.Length; v27++)
            v28[v27] = Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(ArraySource[v27]))))))))));
        return v28;
    }

    int[] EnumerableSelectToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v29;
        int v30;
        int v31;
        int[] v32;
        v29 = EnumerableSource.GetEnumerator();
        v30 = 0;
        v31 = 8;
        v32 = new int[8];
        try
        {
            while (v29.MoveNext())
            {
                if (v30 >= v31)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v32, ref v31);
                v32[v30] = (v29.Current + 3);
                v30++;
            }
        }
        finally
        {
            v29.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v32, v30);
    }

    int[] EnumerableSelectMethodToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v33;
        int v34;
        int v35;
        int[] v36;
        v33 = EnumerableSource.GetEnumerator();
        v34 = 0;
        v35 = 8;
        v36 = new int[8];
        try
        {
            while (v33.MoveNext())
            {
                if (v34 >= v35)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v36, ref v35);
                v36[v34] = Selector(v33.Current);
                v34++;
            }
        }
        finally
        {
            v33.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v36, v34);
    }

    int[][] EnumerableSelectArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v37;
        int v38;
        int v39;
        int[][] v40;
        v37 = EnumerableSource.GetEnumerator();
        v38 = 0;
        v39 = 8;
        v40 = new int[8][];
        try
        {
            while (v37.MoveNext())
            {
                if (v38 >= v39)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v40, ref v39);
                v40[v38] = (new int[10]);
                v38++;
            }
        }
        finally
        {
            v37.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v40, v38);
    }

    int[] EnumerableSelectMultipleToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v41;
        int v42;
        int v43;
        int[] v44;
        v41 = EnumerableSource.GetEnumerator();
        v42 = 0;
        v43 = 8;
        v44 = new int[8];
        try
        {
            while (v41.MoveNext())
            {
                if (v42 >= v43)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v44, ref v43);
                v44[v42] = ((((((((((v41.Current + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3);
                v42++;
            }
        }
        finally
        {
            v41.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v44, v42);
    }

    int[] EnumerableSelectComplexMultipleToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v45;
        int v46;
        int v47;
        int v48;
        int[] v49;
        v45 = EnumerableSource.GetEnumerator();
        v47 = 0;
        v48 = 8;
        v49 = new int[8];
        try
        {
            while (v45.MoveNext())
            {
                v46 = v45.Current;
                v46 = (v46 + v46);
                v46 = (v46 + v46);
                v46 = (v46 + v46);
                v46 = (v46 + v46);
                v46 = (v46 + v46);
                v46 = (v46 + v46);
                v46 = (v46 + v46);
                v46 = (v46 + v46);
                v46 = (v46 + v46);
                if (v47 >= v48)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v49, ref v48);
                v49[v47] = (v46 + v46);
                v47++;
            }
        }
        finally
        {
            v45.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v49, v47);
    }

    int[] EnumerableSelectMethodMultipleToArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v50;
        int[] v51;
        v51 = new int[ArraySource.Length];
        v50 = 0;
        for (; v50 < ArraySource.Length; v50++)
            v51[v50] = Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(Selector(ArraySource[v50]))))))))));
        return v51;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ArraySelectToSimpleListRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v52;
        int[] v53;
        SimpleList<int> v54;
        v53 = new int[ArraySource.Length];
        v52 = 0;
        for (; v52 < ArraySource.Length; v52++)
            v53[v52] = (ArraySource[v52] + 3);
        v54 = new SimpleList<int>();
        v54.Items = v53;
        v54.Count = ArraySource.Length;
        return v54;
    }

    int[] StaticArraySelectToArrayRewritten_ProceduralLinq1(int[] StaticArraySource)
    {
        int v55;
        int[] v56;
        v56 = new int[StaticArraySource.Length];
        v55 = 0;
        for (; v55 < StaticArraySource.Length; v55++)
            v56[v55] = (StaticArraySource[v55] + 3);
        return v56;
    }
}public static class StaticSelectBenchmarks
{
    public static int[] ArraySource = Enumerable.Range(1, 100).ToArray();
    [NoRewrite]
    public static void StaticClassSelectToArray()
    {
        ArraySource.Select(x => x + 3).ToArray();
        ;
    } //EndMethod

    public static void StaticClassSelectToArrayRewritten()
    {
        StaticClassSelectToArrayRewritten_ProceduralLinq1(ArraySource);
        ;
    } //EndMethod

    static int[] StaticClassSelectToArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v57;
        int[] v58;
        v58 = new int[ArraySource.Length];
        v57 = 0;
        for (; v57 < ArraySource.Length; v57++)
            v58[v57] = (ArraySource[v57] + 3);
        return v58;
    }
}}

