using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
public class SkipBenchmarks
{
    public int[] ArraySource;
    public IEnumerable<int> EnumerableSource;
    [GlobalSetup]
    public void GlobalSetup()
    {
        ArraySource = GlobalSetup_ProceduralLinq1();
        EnumerableSource = GlobalSetup_ProceduralLinq2();
    }

    [NoRewrite, Benchmark]
    public void Skip()
    {
        ArraySource.Skip(300);
    } //EndMethod

    [Benchmark]
    public void SkipRewritten()
    {
        SkipRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void SkipToArray()
    {
        ArraySource.Skip(300).ToArray();
    } //EndMethod

    [Benchmark]
    public void SkipToArrayRewritten()
    {
        SkipToArrayRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void SkipMultiple()
    {
        ArraySource.Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50);
    } //EndMethod

    [Benchmark]
    public void SkipMultipleRewritten()
    {
        SkipMultipleRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void SkipMultipleToArray()
    {
        ArraySource.Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).ToArray();
    } //EndMethod

    [Benchmark]
    public void SkipMultipleToArrayRewritten()
    {
        SkipMultipleToArrayRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void EnumerableSkipToArray()
    {
        EnumerableSource.Skip(300).ToArray();
    } //EndMethod

    [Benchmark]
    public void EnumerableSkipToArrayRewritten()
    {
        EnumerableSkipToArrayRewritten_ProceduralLinq1(EnumerableSource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void EnumerableSkipMoreToArray()
    {
        EnumerableSource.Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).Skip(50).ToArray();
    } //EndMethod

    [Benchmark]
    public void EnumerableSkipMoreToArrayRewritten()
    {
        EnumerableSkipMoreToArrayRewritten_ProceduralLinq1(EnumerableSource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void SkipToSimpleList()
    {
        ArraySource.Skip(300).ToSimpleList();
    } //EndMethod

    [Benchmark]
    public void SkipToSimpleListRewritten()
    {
        SkipToSimpleListRewritten_ProceduralLinq1(ArraySource);
    } //EndMethod

    int[] GlobalSetup_ProceduralLinq1()
    {
        int v59;
        int[] v60;
        v60 = new int[1000];
        v59 = 0;
        for (; v59 < 1000; v59++)
            v60[v59] = (v59 + 0);
        return v60;
    }

    System.Collections.Generic.IEnumerable<int> GlobalSetup_ProceduralLinq2()
    {
        int v61;
        v61 = 0;
        for (; v61 < 1000; v61++)
            yield return (v61 + 0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SkipRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v62;
        v62 = (0 + 300);
        for (; v62 < ArraySource.Length; v62++)
            yield return ArraySource[v62];
        yield break;
    }

    int[] SkipToArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v63;
        int[] v64;
        v64 = new int[(ArraySource.Length - 300)];
        System.Array.Copy(ArraySource, (0 + 300), v64, 0, (ArraySource.Length - (0 + 300)));
        return v64;
    }

    System.Collections.Generic.IEnumerable<int> SkipMultipleRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v65;
        v65 = ((((((((((0 + 50) + 50) + 50) + 50) + 50) + 50) + 50) + 50) + 50) + 50);
        for (; v65 < ArraySource.Length; v65++)
            yield return ArraySource[v65];
        yield break;
    }

    int[] SkipMultipleToArrayRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v66;
        int[] v67;
        v67 = new int[((((((((((ArraySource.Length - 50) - 50) - 50) - 50) - 50) - 50) - 50) - 50) - 50) - 50)];
        System.Array.Copy(ArraySource, ((((((((((0 + 50) + 50) + 50) + 50) + 50) + 50) + 50) + 50) + 50) + 50), v67, 0, (ArraySource.Length - ((((((((((0 + 50) + 50) + 50) + 50) + 50) + 50) + 50) + 50) + 50) + 50)));
        return v67;
    }

    int[] EnumerableSkipToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v68;
        int v69;
        int v70;
        int v71;
        int[] v72;
        v68 = EnumerableSource.GetEnumerator();
        v69 = 0;
        v70 = 0;
        v71 = 8;
        v72 = new int[8];
        try
        {
            while (v68.MoveNext())
            {
                if (v69 < 300)
                {
                    v69++;
                    continue;
                }

                if (v70 >= v71)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v72, ref v71);
                v72[v70] = v68.Current;
                v69++;
                v70++;
            }
        }
        finally
        {
            v68.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v72, v70);
    }

    int[] EnumerableSkipMoreToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableSource)
    {
        IEnumerator<int> v73;
        int v74;
        int v75;
        int v76;
        int v77;
        int v78;
        int v79;
        int v80;
        int v81;
        int v82;
        int v83;
        int v84;
        int v85;
        int[] v86;
        v73 = EnumerableSource.GetEnumerator();
        v74 = 0;
        v75 = 0;
        v76 = 0;
        v77 = 0;
        v78 = 0;
        v79 = 0;
        v80 = 0;
        v81 = 0;
        v82 = 0;
        v83 = 0;
        v84 = 0;
        v85 = 8;
        v86 = new int[8];
        try
        {
            while (v73.MoveNext())
            {
                if (v74 < 50)
                {
                    v74++;
                    continue;
                }

                if (v75 < 50)
                {
                    v75++;
                    continue;
                }

                if (v76 < 50)
                {
                    v76++;
                    continue;
                }

                if (v77 < 50)
                {
                    v77++;
                    continue;
                }

                if (v78 < 50)
                {
                    v78++;
                    continue;
                }

                if (v79 < 50)
                {
                    v79++;
                    continue;
                }

                if (v80 < 50)
                {
                    v80++;
                    continue;
                }

                if (v81 < 50)
                {
                    v81++;
                    continue;
                }

                if (v82 < 50)
                {
                    v82++;
                    continue;
                }

                if (v83 < 50)
                {
                    v83++;
                    continue;
                }

                if (v84 >= v85)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v86, ref v85);
                v86[v84] = v73.Current;
                v74++;
                v75++;
                v76++;
                v77++;
                v78++;
                v79++;
                v80++;
                v81++;
                v82++;
                v83++;
                v84++;
            }
        }
        finally
        {
            v73.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v86, v84);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SkipToSimpleListRewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v87;
        int[] v88;
        int v89;
        SimpleList<int> v90;
        v88 = new int[(ArraySource.Length - 300)];
        v89 = 0;
        v87 = (0 + 300);
        for (; v87 < ArraySource.Length; v87++)
        {
            v88[v89] = ArraySource[v87];
            v89++;
        }

        v90 = new SimpleList<int>();
        v90.Items = v88;
        v90.Count = (ArraySource.Length - 300);
        return v90;
    }
}}

