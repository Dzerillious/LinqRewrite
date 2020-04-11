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
        int v74;
        double v75;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v75 = 0;
        v74 = (0);
        for (; v74 < (ArrayItems.Length); v74 += 1)
            v75 += (ArrayItems[v74]);
        return (v75 / (ArrayItems.Length));
    }

    double ArrayAverage1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v77;
        double v78;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v78 = 0;
        v77 = (0);
        for (; v77 < (ArrayItems.Length); v77 += 1)
            v78 += ((ArrayItems[v77]) + 3);
        return (v78 / (ArrayItems.Length));
    }

    double? ArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v80;
        int v81;
        int? v82;
        int v83;
        v81 = 0;
        v83 = 0;
        v80 = (0);
        for (; v80 < (ArrayItems.Length); v80 += 1)
        {
            v82 = ((ArrayItems[v80]) > 10 ? (int? )null : (ArrayItems[v80]));
            if (v82 == null)
                continue;
            v81 += (int)v82;
            v83++;
        }

        return v83 == 0 ? null : ((double? )v81 / v83);
    }

    float ArrayAverage3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v85;
        float v86;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v86 = 0;
        v85 = (0);
        for (; v85 < (ArrayItems.Length); v85 += 1)
            v86 += ((ArrayItems[v85]) + 5f);
        return (v86 / (ArrayItems.Length));
    }

    float? ArrayAverage4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v88;
        float v89;
        float? v90;
        int v91;
        v89 = 0;
        v91 = 0;
        v88 = (0);
        for (; v88 < (ArrayItems.Length); v88 += 1)
        {
            v90 = ((ArrayItems[v88]) > 10 ? (float? )null : (ArrayItems[v88]));
            if (v90 == null)
                continue;
            v89 += (float)v90;
            v91++;
        }

        return v91 == 0 ? null : ((float? )v89 / v91);
    }

    double ArrayAverage5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v93;
        double v94;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v94 = 0;
        v93 = (0);
        for (; v93 < (ArrayItems.Length); v93 += 1)
            v94 += ((ArrayItems[v93]) + 5d);
        return (v94 / (ArrayItems.Length));
    }

    double? ArrayAverage6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v96;
        double v97;
        double? v98;
        int v99;
        v97 = 0;
        v99 = 0;
        v96 = (0);
        for (; v96 < (ArrayItems.Length); v96 += 1)
        {
            v98 = ((ArrayItems[v96]) > 10 ? (double? )null : (ArrayItems[v96]));
            if (v98 == null)
                continue;
            v97 += (double)v98;
            v99++;
        }

        return v99 == 0 ? null : ((double? )v97 / v99);
    }

    decimal ArrayAverage7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v101;
        decimal v102;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v102 = 0;
        v101 = (0);
        for (; v101 < (ArrayItems.Length); v101 += 1)
            v102 += ((ArrayItems[v101]) + 5m);
        return (v102 / (ArrayItems.Length));
    }

    decimal? ArrayAverage8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v104;
        decimal v105;
        decimal? v106;
        int v107;
        v105 = 0;
        v107 = 0;
        v104 = (0);
        for (; v104 < (ArrayItems.Length); v104 += 1)
        {
            v106 = ((ArrayItems[v104]) > 10 ? (decimal? )null : (ArrayItems[v104]));
            if (v106 == null)
                continue;
            v105 += (decimal)v106;
            v107++;
        }

        return v107 == 0 ? null : ((decimal? )v105 / v107);
    }

    double ArrayAverage9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v109;
        double v110;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v110 = 0;
        v109 = (0);
        for (; v109 < (ArrayItems.Length); v109 += 1)
            v110 += ((ArrayItems[v109]) + 5L);
        return (v110 / (ArrayItems.Length));
    }

    double? ArrayAverage10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v112;
        long v113;
        long? v114;
        int v115;
        v113 = 0;
        v115 = 0;
        v112 = (0);
        for (; v112 < (ArrayItems.Length); v112 += 1)
        {
            v114 = ((ArrayItems[v112]) > 10 ? (long? )null : (ArrayItems[v112]));
            if (v114 == null)
                continue;
            v113 += (long)v114;
            v115++;
        }

        return v115 == 0 ? null : ((double? )v113 / v115);
    }

    double ArraySelectAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v117;
        double v118;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v118 = 0;
        v117 = (0);
        for (; v117 < (ArrayItems.Length); v117 += 1)
            v118 += (10 + ArrayItems[v117]);
        return (v118 / (ArrayItems.Length));
    }

    double ArrayWhereAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v119;
        double v120;
        int v121;
        v120 = 0;
        v121 = 0;
        v119 = (0);
        for (; v119 < (ArrayItems.Length); v119 += 1)
        {
            if (!((((ArrayItems[v119])) % 2 == 0)))
                continue;
            v120 += ((ArrayItems[v119]));
            v121++;
        }

        if (1 > v121)
            throw new System.InvalidOperationException("Index out of range");
        return (v120 / v121);
    }

    double? ArrayMethodAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v123;
        double v124;
        double? v125;
        int v126;
        v124 = 0;
        v126 = 0;
        v123 = (0);
        for (; v123 < (ArrayItems.Length); v123 += 1)
        {
            v125 = Selector((ArrayItems[v123]));
            if (v125 == null)
                continue;
            v124 += (double)v125;
            v126++;
        }

        return v126 == 0 ? null : ((double? )v124 / v126);
    }

    double EnumerableAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v127;
        double v128;
        int v129;
        v127 = EnumerableItems.GetEnumerator();
        v128 = 0;
        v129 = 0;
        try
        {
            while (v127.MoveNext())
            {
                v128 += (v127.Current);
                v129++;
            }
        }
        finally
        {
            v127.Dispose();
        }

        if (1 > v129)
            throw new System.InvalidOperationException("Index out of range");
        return (v128 / v129);
    }

    double ArrayMethodAverageChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v130;
        double v131;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v131 = 0;
        v130 = (0);
        for (; v130 < (ArrayItems.Length); v130 += 1)
            v131 += ((ArrayItems[v130]) + a++);
        return (v131 / (ArrayItems.Length));
    }

    double? EnumerableNullAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v132;
        int v133;
        int? v134;
        int v135;
        v132 = EnumerableItems.GetEnumerator();
        v133 = 0;
        v135 = 0;
        try
        {
            while (v132.MoveNext())
            {
                v134 = ((int? )null);
                if (v134 == null)
                    continue;
                v133 += (int)v134;
                v135++;
            }
        }
        finally
        {
            v132.Dispose();
        }

        return v135 == 0 ? null : ((double? )v133 / v135);
    }

    double EnumerableEmptyAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v136;
        int v137;
        double v138;
        int v139;
        v136 = EnumerableItems.GetEnumerator();
        v138 = 0;
        v139 = 0;
        try
        {
            while (v136.MoveNext())
            {
                v137 = (v136.Current);
                if (!((false)))
                    continue;
                v138 += (v137);
                v139++;
            }
        }
        finally
        {
            v136.Dispose();
        }

        if (1 > v139)
            throw new System.InvalidOperationException("Index out of range");
        return (v138 / v139);
    }

    double EnumerableRangeAverageRewritten_ProceduralLinq1()
    {
        int v140;
        double v141;
        if (1 > (100))
            throw new System.InvalidOperationException("Index out of range");
        v141 = 0;
        v140 = (0);
        for (; v140 < (100); v140 += (1))
            v141 += (5 + v140);
        return (v141 / (100));
    }
}}