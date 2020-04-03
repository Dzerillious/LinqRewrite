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
        TestsExtensions.TestEquals(nameof(EnumerableRangeAverage), EnumerableRangeAverage, EnumerableRangeAverageRewritten);
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

    [NoRewrite]
    public double EnumerableRangeAverage()
    {
        return Enumerable.Range(5, 100).Average();
    } //EndMethod

    public double EnumerableRangeAverageRewritten()
    {
        return EnumerableRangeAverageRewritten_ProceduralLinq1();
    } //EndMethod

    double ArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v58;
        double v59;
        v59 = 0;
        v58 = 0;
        for (; v58 < ArrayItems.Length; v58++)
            v59 += ArrayItems[v58];
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v59 / ArrayItems.Length);
    }

    double ArrayAverage1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v60;
        double v61;
        v61 = 0;
        v60 = 0;
        for (; v60 < ArrayItems.Length; v60++)
            v61 += (ArrayItems[v60] + 3);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v61 / ArrayItems.Length);
    }

    double? ArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v62;
        int v63;
        int? v64;
        int v65;
        v63 = 0;
        v65 = 0;
        v62 = 0;
        for (; v62 < ArrayItems.Length; v62++)
        {
            v64 = (ArrayItems[v62] > 10 ? (int? )null : ArrayItems[v62]);
            if (v64 == null)
                continue;
            v63 += (int)v64;
            v65++;
        }

        return v65 == 0 ? null : ((double? )v63 / v65);
    }

    float ArrayAverage3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v66;
        float v67;
        v67 = 0;
        v66 = 0;
        for (; v66 < ArrayItems.Length; v66++)
            v67 += (ArrayItems[v66] + 5f);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v67 / ArrayItems.Length);
    }

    float? ArrayAverage4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v68;
        float v69;
        float? v70;
        int v71;
        v69 = 0;
        v71 = 0;
        v68 = 0;
        for (; v68 < ArrayItems.Length; v68++)
        {
            v70 = (ArrayItems[v68] > 10 ? (float? )null : ArrayItems[v68]);
            if (v70 == null)
                continue;
            v69 += (float)v70;
            v71++;
        }

        return v71 == 0 ? null : ((float? )v69 / v71);
    }

    double ArrayAverage5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v72;
        double v73;
        v73 = 0;
        v72 = 0;
        for (; v72 < ArrayItems.Length; v72++)
            v73 += (ArrayItems[v72] + 5d);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v73 / ArrayItems.Length);
    }

    double? ArrayAverage6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v74;
        double v75;
        double? v76;
        int v77;
        v75 = 0;
        v77 = 0;
        v74 = 0;
        for (; v74 < ArrayItems.Length; v74++)
        {
            v76 = (ArrayItems[v74] > 10 ? (double? )null : ArrayItems[v74]);
            if (v76 == null)
                continue;
            v75 += (double)v76;
            v77++;
        }

        return v77 == 0 ? null : ((double? )v75 / v77);
    }

    decimal ArrayAverage7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v78;
        decimal v79;
        v79 = 0;
        v78 = 0;
        for (; v78 < ArrayItems.Length; v78++)
            v79 += (ArrayItems[v78] + 5m);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v79 / ArrayItems.Length);
    }

    decimal? ArrayAverage8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v80;
        decimal v81;
        decimal? v82;
        int v83;
        v81 = 0;
        v83 = 0;
        v80 = 0;
        for (; v80 < ArrayItems.Length; v80++)
        {
            v82 = (ArrayItems[v80] > 10 ? (decimal? )null : ArrayItems[v80]);
            if (v82 == null)
                continue;
            v81 += (decimal)v82;
            v83++;
        }

        return v83 == 0 ? null : ((decimal? )v81 / v83);
    }

    double ArrayAverage9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v84;
        double v85;
        v85 = 0;
        v84 = 0;
        for (; v84 < ArrayItems.Length; v84++)
            v85 += (ArrayItems[v84] + 5L);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v85 / ArrayItems.Length);
    }

    double? ArrayAverage10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v86;
        long v87;
        long? v88;
        int v89;
        v87 = 0;
        v89 = 0;
        v86 = 0;
        for (; v86 < ArrayItems.Length; v86++)
        {
            v88 = (ArrayItems[v86] > 10 ? (long? )null : ArrayItems[v86]);
            if (v88 == null)
                continue;
            v87 += (long)v88;
            v89++;
        }

        return v89 == 0 ? null : ((double? )v87 / v89);
    }

    double ArraySelectAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v90;
        double v91;
        v91 = 0;
        v90 = 0;
        for (; v90 < ArrayItems.Length; v90++)
            v91 += (ArrayItems[v90] + 10);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v91 / ArrayItems.Length);
    }

    double ArrayWhereAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v92;
        double v93;
        int v94;
        v93 = 0;
        v94 = 0;
        v92 = 0;
        for (; v92 < ArrayItems.Length; v92++)
        {
            if (!((ArrayItems[v92] % 2 == 0)))
                continue;
            v93 += ArrayItems[v92];
            v94++;
        }

        if (v94 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v93 / v94);
    }

    double? ArrayMethodAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v95;
        double v96;
        double? v97;
        int v98;
        v96 = 0;
        v98 = 0;
        v95 = 0;
        for (; v95 < ArrayItems.Length; v95++)
        {
            v97 = Selector(ArrayItems[v95]);
            if (v97 == null)
                continue;
            v96 += (double)v97;
            v98++;
        }

        return v98 == 0 ? null : ((double? )v96 / v98);
    }

    double EnumerableAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v99;
        double v100;
        int v101;
        v99 = EnumerableItems.GetEnumerator();
        v100 = 0;
        v101 = 0;
        try
        {
            while (v99.MoveNext())
            {
                v100 += v99.Current;
                v101++;
            }
        }
        finally
        {
            v99.Dispose();
        }

        if (v101 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v100 / v101);
    }

    double ArrayMethodAverageChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v102;
        double v103;
        v103 = 0;
        v102 = 0;
        for (; v102 < ArrayItems.Length; v102++)
            v103 += (ArrayItems[v102] + a++);
        if (ArrayItems.Length == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v103 / ArrayItems.Length);
    }

    double? EnumerableNullAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v104;
        int v105;
        int? v106;
        int v107;
        v104 = EnumerableItems.GetEnumerator();
        v105 = 0;
        v107 = 0;
        try
        {
            while (v104.MoveNext())
            {
                v106 = ((int? )null);
                if (v106 == null)
                    continue;
                v105 += (int)v106;
                v107++;
            }
        }
        finally
        {
            v104.Dispose();
        }

        return v107 == 0 ? null : ((double? )v105 / v107);
    }

    double EnumerableEmptyAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v108;
        int v109;
        double v110;
        int v111;
        v108 = EnumerableItems.GetEnumerator();
        v110 = 0;
        v111 = 0;
        try
        {
            while (v108.MoveNext())
            {
                v109 = v108.Current;
                if (!((false)))
                    continue;
                v110 += v109;
                v111++;
            }
        }
        finally
        {
            v108.Dispose();
        }

        if (v111 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v110 / v111);
    }

    double EnumerableRangeAverageRewritten_ProceduralLinq1()
    {
        int v112;
        double v113;
        v113 = 0;
        v112 = 0;
        for (; v112 < 100; v112++)
            v113 += (v112 + 5);
        if (100 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v113 / 100);
    }
}}