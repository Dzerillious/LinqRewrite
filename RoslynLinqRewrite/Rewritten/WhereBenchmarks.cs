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
        StaticArraySource = GlobalSetup_ProceduralLinq1();
        ArraySource = GlobalSetup_ProceduralLinq2();
        EnumerableSource = GlobalSetup_ProceduralLinq3();
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

    int[] GlobalSetup_ProceduralLinq1()
    {
        int v91;
        int[] v92;
        v92 = new int[100];
        v91 = 0;
        for (; v91 < 100; v91++)
            v92[v91] = (v91 + 0);
        return v92;
    }

    int[] GlobalSetup_ProceduralLinq2()
    {
        int v93;
        int[] v94;
        v94 = new int[100];
        v93 = 0;
        for (; v93 < 100; v93++)
            v94[v93] = (v93 + 0);
        return v94;
    }

    System.Collections.Generic.IEnumerable<int> GlobalSetup_ProceduralLinq3()
    {
        int v95;
        v95 = 0;
        for (; v95 < 100; v95++)
            yield return (v95 + 0);
        yield break;
    }

    int[] Select1Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v96;
        int v97;
        int v98;
        int v99;
        int[] v100;
        v97 = 0;
        v98 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArraySource.Length) - 3);
        v98 -= (v98 % 2);
        v99 = 8;
        v100 = new int[8];
        v96 = 0;
        for (; v96 < ArraySource.Length; v96++)
        {
            if (!((ArraySource[v96] > 1)))
                continue;
            if (v97 >= v99)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArraySource.Length, ref v100, ref v98, out v99);
            v100[v97] = ArraySource[v96];
            v97++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v100, v97);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> Select2Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v101;
        int v102;
        int v103;
        int v104;
        int[] v105;
        SimpleList<int> v106;
        v102 = 0;
        v103 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArraySource.Length) - 3);
        v103 -= (v103 % 2);
        v104 = 8;
        v105 = new int[8];
        v101 = 0;
        for (; v101 < ArraySource.Length; v101++)
        {
            if (!((ArraySource[v101] > 1)))
                continue;
            if (v102 >= v104)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArraySource.Length, ref v105, ref v103, out v104);
            v105[v102] = ArraySource[v101];
            v102++;
        }

        v106 = new SimpleList<int>();
        v106.Items = v105;
        v106.Count = v102;
        return v106;
    }

    int[] Select3Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v107;
        int v108;
        int v109;
        int v110;
        int[] v111;
        v108 = 0;
        v109 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArraySource.Length) - 3);
        v109 -= (v109 % 2);
        v110 = 8;
        v111 = new int[8];
        v107 = 0;
        for (; v107 < ArraySource.Length; v107++)
        {
            if (!((ArraySource[v107] > 500)))
                continue;
            if (v108 >= v110)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArraySource.Length, ref v111, ref v109, out v110);
            v111[v108] = ArraySource[v107];
            v108++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v111, v108);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> Select4Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v112;
        int v113;
        int v114;
        int v115;
        int[] v116;
        SimpleList<int> v117;
        v113 = 0;
        v114 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArraySource.Length) - 3);
        v114 -= (v114 % 2);
        v115 = 8;
        v116 = new int[8];
        v112 = 0;
        for (; v112 < ArraySource.Length; v112++)
        {
            if (!((ArraySource[v112] > 500)))
                continue;
            if (v113 >= v115)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArraySource.Length, ref v116, ref v114, out v115);
            v116[v113] = ArraySource[v112];
            v113++;
        }

        v117 = new SimpleList<int>();
        v117.Items = v116;
        v117.Count = v113;
        return v117;
    }

    int[] Select5Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v118;
        int v119;
        int v120;
        int v121;
        int[] v122;
        v119 = 0;
        v120 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArraySource.Length) - 3);
        v120 -= (v120 % 2);
        v121 = 8;
        v122 = new int[8];
        v118 = 0;
        for (; v118 < ArraySource.Length; v118++)
        {
            if (!((ArraySource[v118] > 1000)))
                continue;
            if (v119 >= v121)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArraySource.Length, ref v122, ref v120, out v121);
            v122[v119] = ArraySource[v118];
            v119++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v122, v119);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> Select6Rewritten_ProceduralLinq1(int[] ArraySource)
    {
        int v123;
        int v124;
        int v125;
        int v126;
        int[] v127;
        SimpleList<int> v128;
        v124 = 0;
        v125 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArraySource.Length) - 3);
        v125 -= (v125 % 2);
        v126 = 8;
        v127 = new int[8];
        v123 = 0;
        for (; v123 < ArraySource.Length; v123++)
        {
            if (!((ArraySource[v123] > 1000)))
                continue;
            if (v124 >= v126)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArraySource.Length, ref v127, ref v125, out v126);
            v127[v124] = ArraySource[v123];
            v124++;
        }

        v128 = new SimpleList<int>();
        v128.Items = v127;
        v128.Count = v124;
        return v128;
    }
}}