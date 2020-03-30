using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class AverageTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public double? Selector(int x) => x + 5;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayAverage), ArrayAverage, ArrayAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayAverage1), ArrayAverage1, ArrayAverage1Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayAverage2), ArrayAverage2, ArrayAverage2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayAverage3), ArrayAverage3, ArrayAverage3Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayAverage4), ArrayAverage4, ArrayAverage4Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayAverage5), ArrayAverage5, ArrayAverage5Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayAverage6), ArrayAverage6, ArrayAverage6Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayAverage7), ArrayAverage7, ArrayAverage7Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayAverage8), ArrayAverage8, ArrayAverage8Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayAverage9), ArrayAverage9, ArrayAverage9Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayAverage10), ArrayAverage10, ArrayAverage10Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectAverage), ArraySelectAverage, ArraySelectAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereAverage), ArrayWhereAverage, ArrayWhereAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayMethodAverage), ArrayMethodAverage, ArrayMethodAverageRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableAverage), EnumerableAverage, EnumerableAverageRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableEmptyAverage), EnumerableEmptyAverage, EnumerableEmptyAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayMethodAverageChangingParam), ArrayMethodAverageChangingParam, ArrayMethodAverageChangingParamRewritten);
    }

    [NoRewrite]
    public double ArrayAverage()
    {
        return ArrayItems.Average();
    } //EndMethod

    public double ArrayAverageRewritten()
    {
        return ArrayAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayAverage1()
    {
        return ArrayItems.Average(x => x + 3);
    } //EndMethod

    public double ArrayAverage1Rewritten()
    {
        return ArrayAverage1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? ArrayAverage2()
    {
        return ArrayItems.Average(x => x > 10 ? (int? )null : x);
    } //EndMethod

    public double? ArrayAverage2Rewritten()
    {
        return ArrayAverage2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayAverage3()
    {
        return ArrayItems.Average(x => x + 5f);
    } //EndMethod

    public double ArrayAverage3Rewritten()
    {
        return ArrayAverage3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? ArrayAverage4()
    {
        return ArrayItems.Average(x => x > 10 ? (float? )null : x);
    } //EndMethod

    public double? ArrayAverage4Rewritten()
    {
        return ArrayAverage4Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayAverage5()
    {
        return ArrayItems.Average(x => x + 5d);
    } //EndMethod

    public double ArrayAverage5Rewritten()
    {
        return ArrayAverage5Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? ArrayAverage6()
    {
        return ArrayItems.Average(x => x > 10 ? (double? )null : x);
    } //EndMethod

    public double? ArrayAverage6Rewritten()
    {
        return ArrayAverage6Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal ArrayAverage7()
    {
        return ArrayItems.Average(x => x + 5m);
    } //EndMethod

    public decimal ArrayAverage7Rewritten()
    {
        return ArrayAverage7Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal? ArrayAverage8()
    {
        return ArrayItems.Average(x => x > 10 ? (decimal? )null : x);
    } //EndMethod

    public decimal? ArrayAverage8Rewritten()
    {
        return ArrayAverage8Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayAverage9()
    {
        return ArrayItems.Average(x => x + 5L);
    } //EndMethod

    public double ArrayAverage9Rewritten()
    {
        return ArrayAverage9Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? ArrayAverage10()
    {
        return ArrayItems.Average(x => x > 10 ? (long? )null : x);
    } //EndMethod

    public double? ArrayAverage10Rewritten()
    {
        return ArrayAverage10Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArraySelectAverage()
    {
        return ArrayItems.Select(x => x + 10).Average();
    } //EndMethod

    public double ArraySelectAverageRewritten()
    {
        return ArraySelectAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayWhereAverage()
    {
        return ArrayItems.Where(x => x % 2 == 0).Average();
    } //EndMethod

    public double ArrayWhereAverageRewritten()
    {
        return ArrayWhereAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? ArrayMethodAverage()
    {
        return ArrayItems.Average(Selector);
    } //EndMethod

    public double? ArrayMethodAverageRewritten()
    {
        return ArrayMethodAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double EnumerableAverage()
    {
        return EnumerableItems.Average();
    } //EndMethod

    public double EnumerableAverageRewritten()
    {
        return EnumerableAverageRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public double? ArrayMethodAverageChangingParam()
    {
        var a = 5;
        return ArrayItems.Average(x => x + a++);
    } //EndMethod

    public double? ArrayMethodAverageChangingParamRewritten()
    {
        var a = 5;
        return ArrayMethodAverageChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? EnumerableNullAverage()
    {
        return EnumerableItems.Average(x => (int? )null);
    } //EndMethod

    public double? EnumerableNullAverageRewritten()
    {
        return EnumerableNullAverageRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public double EnumerableEmptyAverage()
    {
        return EnumerableItems.Where(x => false).Average();
    } //EndMethod

    public double EnumerableEmptyAverageRewritten()
    {
        return EnumerableEmptyAverageRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    double ArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v56;
        double v57;
        v57 = 0;
        v56 = 0;
        for (; v56 < ArrayItems.Length; v56++)
            v57 += ArrayItems[v56];
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v57 / ArrayItems.Length);
    }

    double ArrayAverage1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v58;
        double v59;
        v59 = 0;
        v58 = 0;
        for (; v58 < ArrayItems.Length; v58++)
            v59 += (ArrayItems[v58] + 3);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v59 / ArrayItems.Length);
    }

    double? ArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v60;
        int v61;
        int? v62;
        int v63;
        v61 = 0;
        v63 = 0;
        v60 = 0;
        for (; v60 < ArrayItems.Length; v60++)
        {
            v62 = (ArrayItems[v60] > 10 ? (int? )null : ArrayItems[v60]);
            if (v62 == null)
                continue;
            v61 += (int)v62;
            v63++;
        }

        return v63 == 0 ? null : ((double? )v61 / v63);
    }

    float ArrayAverage3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v64;
        float v65;
        v65 = 0;
        v64 = 0;
        for (; v64 < ArrayItems.Length; v64++)
            v65 += (ArrayItems[v64] + 5f);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v65 / ArrayItems.Length);
    }

    float? ArrayAverage4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v66;
        float v67;
        float? v68;
        int v69;
        v67 = 0;
        v69 = 0;
        v66 = 0;
        for (; v66 < ArrayItems.Length; v66++)
        {
            v68 = (ArrayItems[v66] > 10 ? (float? )null : ArrayItems[v66]);
            if (v68 == null)
                continue;
            v67 += (float)v68;
            v69++;
        }

        return v69 == 0 ? null : ((float? )v67 / v69);
    }

    double ArrayAverage5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v70;
        double v71;
        v71 = 0;
        v70 = 0;
        for (; v70 < ArrayItems.Length; v70++)
            v71 += (ArrayItems[v70] + 5d);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v71 / ArrayItems.Length);
    }

    double? ArrayAverage6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v72;
        double v73;
        double? v74;
        int v75;
        v73 = 0;
        v75 = 0;
        v72 = 0;
        for (; v72 < ArrayItems.Length; v72++)
        {
            v74 = (ArrayItems[v72] > 10 ? (double? )null : ArrayItems[v72]);
            if (v74 == null)
                continue;
            v73 += (double)v74;
            v75++;
        }

        return v75 == 0 ? null : ((double? )v73 / v75);
    }

    decimal ArrayAverage7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v76;
        decimal v77;
        v77 = 0;
        v76 = 0;
        for (; v76 < ArrayItems.Length; v76++)
            v77 += (ArrayItems[v76] + 5m);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v77 / ArrayItems.Length);
    }

    decimal? ArrayAverage8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v78;
        decimal v79;
        decimal? v80;
        int v81;
        v79 = 0;
        v81 = 0;
        v78 = 0;
        for (; v78 < ArrayItems.Length; v78++)
        {
            v80 = (ArrayItems[v78] > 10 ? (decimal? )null : ArrayItems[v78]);
            if (v80 == null)
                continue;
            v79 += (decimal)v80;
            v81++;
        }

        return v81 == 0 ? null : ((decimal? )v79 / v81);
    }

    double ArrayAverage9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v82;
        double v83;
        v83 = 0;
        v82 = 0;
        for (; v82 < ArrayItems.Length; v82++)
            v83 += (ArrayItems[v82] + 5L);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v83 / ArrayItems.Length);
    }

    double? ArrayAverage10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v84;
        long v85;
        long? v86;
        int v87;
        v85 = 0;
        v87 = 0;
        v84 = 0;
        for (; v84 < ArrayItems.Length; v84++)
        {
            v86 = (ArrayItems[v84] > 10 ? (long? )null : ArrayItems[v84]);
            if (v86 == null)
                continue;
            v85 += (long)v86;
            v87++;
        }

        return v87 == 0 ? null : ((double? )v85 / v87);
    }

    double ArraySelectAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v88;
        double v89;
        v89 = 0;
        v88 = 0;
        for (; v88 < ArrayItems.Length; v88++)
            v89 += (ArrayItems[v88] + 10);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v89 / ArrayItems.Length);
    }

    double ArrayWhereAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v90;
        double v91;
        int v92;
        v91 = 0;
        v92 = 0;
        v90 = 0;
        for (; v90 < ArrayItems.Length; v90++)
        {
            if (!(ArrayItems[v90] % 2 == 0))
                continue;
            v91 += ArrayItems[v90];
            v92++;
        }

        if (v92 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v91 / v92);
    }

    double? ArrayMethodAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v93;
        double v94;
        double? v95;
        int v96;
        v94 = 0;
        v96 = 0;
        v93 = 0;
        for (; v93 < ArrayItems.Length; v93++)
        {
            v95 = Selector(ArrayItems[v93]);
            if (v95 == null)
                continue;
            v94 += (double)v95;
            v96++;
        }

        return v96 == 0 ? null : ((double? )v94 / v96);
    }

    double EnumerableAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v97;
        double v98;
        int v99;
        v98 = 0;
        v99 = 0;
        v97 = EnumerableItems.GetEnumerator();
        try
        {
            while (v97.MoveNext())
            {
                v98 += v97.Current;
                v99++;
            }
        }
        finally
        {
            v97.Dispose();
        }

        if (v99 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v98 / v99);
    }

    double ArrayMethodAverageChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v100;
        double v101;
        v101 = 0;
        v100 = 0;
        for (; v100 < ArrayItems.Length; v100++)
            v101 += (ArrayItems[v100] + a++);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v101 / ArrayItems.Length);
    }

    double? EnumerableNullAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v102;
        int v103;
        int? v104;
        int v105;
        v103 = 0;
        v105 = 0;
        v102 = EnumerableItems.GetEnumerator();
        try
        {
            while (v102.MoveNext())
            {
                v104 = ((int? )null);
                if (v104 == null)
                    continue;
                v103 += (int)v104;
                v105++;
            }
        }
        finally
        {
            v102.Dispose();
        }

        return v105 == 0 ? null : ((double? )v103 / v105);
    }

    double EnumerableEmptyAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v106;
        int v107;
        double v108;
        int v109;
        v108 = 0;
        v109 = 0;
        v106 = EnumerableItems.GetEnumerator();
        try
        {
            while (v106.MoveNext())
            {
                v107 = v106.Current;
                if (!(false))
                    continue;
                v108 += v107;
                v109++;
            }
        }
        finally
        {
            v106.Dispose();
        }

        if (v109 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v108 / v109);
    }
}}