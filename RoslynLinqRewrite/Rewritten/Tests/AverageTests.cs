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
        ArrayAverage().TestEquals(nameof(ArrayAverage), ArrayAverageRewritten());
        ArrayAverage1().TestEquals(nameof(ArrayAverage1), ArrayAverage1Rewritten());
        ArrayAverage2().TestEquals(nameof(ArrayAverage2), ArrayAverage2Rewritten());
        ArrayAverage3().TestEquals(nameof(ArrayAverage3), ArrayAverage3Rewritten());
        ArrayAverage4().TestEquals(nameof(ArrayAverage4), ArrayAverage4Rewritten());
        ArrayAverage5().TestEquals(nameof(ArrayAverage5), ArrayAverage5Rewritten());
        ArrayAverage6().TestEquals(nameof(ArrayAverage6), ArrayAverage6Rewritten());
        ArrayAverage7().TestEquals(nameof(ArrayAverage7), ArrayAverage7Rewritten());
        ArrayAverage8().TestEquals(nameof(ArrayAverage8), ArrayAverage8Rewritten());
        ArrayAverage9().TestEquals(nameof(ArrayAverage9), ArrayAverage9Rewritten());
        ArrayAverage10().TestEquals(nameof(ArrayAverage10), ArrayAverage10Rewritten());
        ArraySelectAverage().TestEquals(nameof(ArraySelectAverage), ArraySelectAverageRewritten());
        ArrayWhereAverage().TestEquals(nameof(ArrayWhereAverage), ArrayWhereAverageRewritten());
        ArrayMethodAverage().TestEquals(nameof(ArrayMethodAverage), ArrayMethodAverageRewritten());
        EnumerableAverage().TestEquals(nameof(EnumerableAverage), EnumerableAverageRewritten());
        ArrayMethodAverageChangingParam().TestEquals(nameof(ArrayMethodAverageChangingParam), ArrayMethodAverageChangingParamRewritten());
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

    double ArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v50;
        double v51;
        v51 = 0;
        v50 = 0;
        for (; v50 < ArrayItems.Length; v50++)
            v51 += ArrayItems[v50];
        return (v51 / ArrayItems.Length);
    }

    double ArrayAverage1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v52;
        double v53;
        v53 = 0;
        v52 = 0;
        for (; v52 < ArrayItems.Length; v52++)
            v53 += (ArrayItems[v52] + 3);
        return (v53 / ArrayItems.Length);
    }

    double? ArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v54;
        int v55;
        int? v56;
        int v57;
        v55 = 0;
        v57 = 0;
        v54 = 0;
        for (; v54 < ArrayItems.Length; v54++)
        {
            v56 = (ArrayItems[v54] > 10 ? (int? )null : ArrayItems[v54]);
            if (v56 == null)
                continue;
            v55 += (int)v56;
            v57++;
        }

        return v57 == 0 ? null : ((double? )v55 / v57);
    }

    float ArrayAverage3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v58;
        float v59;
        v59 = 0;
        v58 = 0;
        for (; v58 < ArrayItems.Length; v58++)
            v59 += (ArrayItems[v58] + 5f);
        return (v59 / ArrayItems.Length);
    }

    float? ArrayAverage4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v60;
        float v61;
        float? v62;
        int v63;
        v61 = 0;
        v63 = 0;
        v60 = 0;
        for (; v60 < ArrayItems.Length; v60++)
        {
            v62 = (ArrayItems[v60] > 10 ? (float? )null : ArrayItems[v60]);
            if (v62 == null)
                continue;
            v61 += (float)v62;
            v63++;
        }

        return v63 == 0 ? null : ((float? )v61 / v63);
    }

    double ArrayAverage5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v64;
        double v65;
        v65 = 0;
        v64 = 0;
        for (; v64 < ArrayItems.Length; v64++)
            v65 += (ArrayItems[v64] + 5d);
        return (v65 / ArrayItems.Length);
    }

    double? ArrayAverage6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v66;
        double v67;
        double? v68;
        int v69;
        v67 = 0;
        v69 = 0;
        v66 = 0;
        for (; v66 < ArrayItems.Length; v66++)
        {
            v68 = (ArrayItems[v66] > 10 ? (double? )null : ArrayItems[v66]);
            if (v68 == null)
                continue;
            v67 += (double)v68;
            v69++;
        }

        return v69 == 0 ? null : ((double? )v67 / v69);
    }

    decimal ArrayAverage7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v70;
        decimal v71;
        v71 = 0;
        v70 = 0;
        for (; v70 < ArrayItems.Length; v70++)
            v71 += (ArrayItems[v70] + 5m);
        return (v71 / ArrayItems.Length);
    }

    decimal? ArrayAverage8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v72;
        decimal v73;
        decimal? v74;
        int v75;
        v73 = 0;
        v75 = 0;
        v72 = 0;
        for (; v72 < ArrayItems.Length; v72++)
        {
            v74 = (ArrayItems[v72] > 10 ? (decimal? )null : ArrayItems[v72]);
            if (v74 == null)
                continue;
            v73 += (decimal)v74;
            v75++;
        }

        return v75 == 0 ? null : ((decimal? )v73 / v75);
    }

    double ArrayAverage9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v76;
        double v77;
        v77 = 0;
        v76 = 0;
        for (; v76 < ArrayItems.Length; v76++)
            v77 += (ArrayItems[v76] + 5L);
        return (v77 / ArrayItems.Length);
    }

    double? ArrayAverage10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v78;
        long v79;
        long? v80;
        int v81;
        v79 = 0;
        v81 = 0;
        v78 = 0;
        for (; v78 < ArrayItems.Length; v78++)
        {
            v80 = (ArrayItems[v78] > 10 ? (long? )null : ArrayItems[v78]);
            if (v80 == null)
                continue;
            v79 += (long)v80;
            v81++;
        }

        return v81 == 0 ? null : ((double? )v79 / v81);
    }

    double ArraySelectAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v82;
        double v83;
        v83 = 0;
        v82 = 0;
        for (; v82 < ArrayItems.Length; v82++)
            v83 += (ArrayItems[v82] + 10);
        return (v83 / ArrayItems.Length);
    }

    double ArrayWhereAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v84;
        double v85;
        int v86;
        v85 = 0;
        v86 = 0;
        v84 = 0;
        for (; v84 < ArrayItems.Length; v84++)
        {
            if (!(ArrayItems[v84] % 2 == 0))
                continue;
            v85 += ArrayItems[v84];
            v86++;
        }

        return (v85 / v86);
    }

    double? ArrayMethodAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v87;
        double v88;
        double? v89;
        int v90;
        v88 = 0;
        v90 = 0;
        v87 = 0;
        for (; v87 < ArrayItems.Length; v87++)
        {
            v89 = Selector(ArrayItems[v87]);
            if (v89 == null)
                continue;
            v88 += (double)v89;
            v90++;
        }

        return v90 == 0 ? null : ((double? )v88 / v90);
    }

    double EnumerableAverageRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v91;
        double v92;
        int v93;
        v92 = 0;
        v93 = 0;
        v91 = EnumerableItems.GetEnumerator();
        try
        {
            while (v91.MoveNext())
            {
                v92 += v91.Current;
                v93++;
            }
        }
        finally
        {
            v91.Dispose();
        }

        return (v92 / v93);
    }

    double ArrayMethodAverageChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v94;
        double v95;
        v95 = 0;
        v94 = 0;
        for (; v94 < ArrayItems.Length; v94++)
            v95 += (ArrayItems[v94] + a++);
        return (v95 / ArrayItems.Length);
    }
}}