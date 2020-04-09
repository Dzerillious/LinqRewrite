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
        int v79;
        double v80;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v80 = 0;
        v79 = (0);
        for (; v79 < (ArrayItems.Length); v79++)
            v80 += (ArrayItems[v79]);
        return (v80 / (ArrayItems.Length));
    }

    double ArrayAverage1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v82;
        double v83;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v83 = 0;
        v82 = (0);
        for (; v82 < (ArrayItems.Length); v82++)
            v83 += ((ArrayItems[v82]) + 3);
        return (v83 / (ArrayItems.Length));
    }

    double? ArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v85;
        int v86;
        int v87;
        int? v88;
        int v89;
        v87 = 0;
        v89 = 0;
        v85 = (0);
        for (; v85 < (ArrayItems.Length); v85++)
        {
            v86 = (ArrayItems[v85]);
            v88 = (v86 > 10 ? (int? )null : v86);
            if (v88 == null)
                continue;
            v87 += (int)v88;
            v89++;
        }

        return v89 == 0 ? null : ((double? )v87 / v89);
    }

    float ArrayAverage3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v91;
        float v92;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v92 = 0;
        v91 = (0);
        for (; v91 < (ArrayItems.Length); v91++)
            v92 += ((ArrayItems[v91]) + 5f);
        return (v92 / (ArrayItems.Length));
    }

    float? ArrayAverage4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v94;
        int v95;
        float v96;
        float? v97;
        int v98;
        v96 = 0;
        v98 = 0;
        v94 = (0);
        for (; v94 < (ArrayItems.Length); v94++)
        {
            v95 = (ArrayItems[v94]);
            v97 = (v95 > 10 ? (float? )null : v95);
            if (v97 == null)
                continue;
            v96 += (float)v97;
            v98++;
        }

        return v98 == 0 ? null : ((float? )v96 / v98);
    }

    double ArrayAverage5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v100;
        double v101;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v101 = 0;
        v100 = (0);
        for (; v100 < (ArrayItems.Length); v100++)
            v101 += ((ArrayItems[v100]) + 5d);
        return (v101 / (ArrayItems.Length));
    }

    double? ArrayAverage6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v103;
        int v104;
        double v105;
        double? v106;
        int v107;
        v105 = 0;
        v107 = 0;
        v103 = (0);
        for (; v103 < (ArrayItems.Length); v103++)
        {
            v104 = (ArrayItems[v103]);
            v106 = (v104 > 10 ? (double? )null : v104);
            if (v106 == null)
                continue;
            v105 += (double)v106;
            v107++;
        }

        return v107 == 0 ? null : ((double? )v105 / v107);
    }

    decimal ArrayAverage7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v109;
        decimal v110;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v110 = 0;
        v109 = (0);
        for (; v109 < (ArrayItems.Length); v109++)
            v110 += ((ArrayItems[v109]) + 5m);
        return (v110 / (ArrayItems.Length));
    }

    decimal? ArrayAverage8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v112;
        int v113;
        decimal v114;
        decimal? v115;
        int v116;
        v114 = 0;
        v116 = 0;
        v112 = (0);
        for (; v112 < (ArrayItems.Length); v112++)
        {
            v113 = (ArrayItems[v112]);
            v115 = (v113 > 10 ? (decimal? )null : v113);
            if (v115 == null)
                continue;
            v114 += (decimal)v115;
            v116++;
        }

        return v116 == 0 ? null : ((decimal? )v114 / v116);
    }

    double ArrayAverage9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v118;
        double v119;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v119 = 0;
        v118 = (0);
        for (; v118 < (ArrayItems.Length); v118++)
            v119 += ((ArrayItems[v118]) + 5L);
        return (v119 / (ArrayItems.Length));
    }

    double? ArrayAverage10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v121;
        int v122;
        long v123;
        long? v124;
        int v125;
        v123 = 0;
        v125 = 0;
        v121 = (0);
        for (; v121 < (ArrayItems.Length); v121++)
        {
            v122 = (ArrayItems[v121]);
            v124 = (v122 > 10 ? (long? )null : v122);
            if (v124 == null)
                continue;
            v123 += (long)v124;
            v125++;
        }

        return v125 == 0 ? null : ((double? )v123 / v125);
    }

    double ArraySelectAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v127;
        double v128;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v128 = 0;
        v127 = (0);
        for (; v127 < (ArrayItems.Length); v127++)
            v128 += (10 + ArrayItems[v127]);
        return (v128 / (ArrayItems.Length));
    }

    double ArrayWhereAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v129;
        int v130;
        double v131;
        int v132;
        v131 = 0;
        v132 = 0;
        v129 = (0);
        for (; v129 < (ArrayItems.Length); v129++)
        {
            v130 = (ArrayItems[v129]);
            if (!(((v130) % 2 == 0)))
                continue;
            v131 += (v130);
            v132++;
        }

        if (1 > v132)
            throw new System.InvalidOperationException("Index out of range");
        return (v131 / v132);
    }

    double? ArrayMethodAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v134;
        double v135;
        double? v136;
        int v137;
        v135 = 0;
        v137 = 0;
        v134 = (0);
        for (; v134 < (ArrayItems.Length); v134++)
        {
            v136 = Selector((ArrayItems[v134]));
            if (v136 == null)
                continue;
            v135 += (double)v136;
            v137++;
        }

        return v137 == 0 ? null : ((double? )v135 / v137);
    }

    double EnumerableAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v138;
        double v139;
        int v140;
        v138 = EnumerableItems.GetEnumerator();
        v139 = 0;
        v140 = 0;
        try
        {
            while (v138.MoveNext())
            {
                v139 += (v138.Current);
                v140++;
            }
        }
        finally
        {
            v138.Dispose();
        }

        if (1 > v140)
            throw new System.InvalidOperationException("Index out of range");
        return (v139 / v140);
    }

    double ArrayMethodAverageChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v141;
        double v142;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v142 = 0;
        v141 = (0);
        for (; v141 < (ArrayItems.Length); v141++)
            v142 += ((ArrayItems[v141]) + a++);
        return (v142 / (ArrayItems.Length));
    }

    double? EnumerableNullAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v143;
        int v144;
        int? v145;
        int v146;
        v143 = EnumerableItems.GetEnumerator();
        v144 = 0;
        v146 = 0;
        try
        {
            while (v143.MoveNext())
            {
                v145 = ((int? )null);
                if (v145 == null)
                    continue;
                v144 += (int)v145;
                v146++;
            }
        }
        finally
        {
            v143.Dispose();
        }

        return v146 == 0 ? null : ((double? )v144 / v146);
    }

    double EnumerableEmptyAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v147;
        int v148;
        double v149;
        int v150;
        v147 = EnumerableItems.GetEnumerator();
        v149 = 0;
        v150 = 0;
        try
        {
            while (v147.MoveNext())
            {
                v148 = (v147.Current);
                if (!((false)))
                    continue;
                v149 += (v148);
                v150++;
            }
        }
        finally
        {
            v147.Dispose();
        }

        if (1 > v150)
            throw new System.InvalidOperationException("Index out of range");
        return (v149 / v150);
    }

    double EnumerableRangeAverageRewritten_ProceduralLinq1()
    {
        int v151;
        double v152;
        v152 = 0;
        v151 = (0);
        for (; v151 < (100); v151++)
            v152 += (5 + v151);
        return (v152 / (100));
    }
}}