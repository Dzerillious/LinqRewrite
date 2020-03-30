using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class CastTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayCast), ArrayCast, ArrayCastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayCast2), ArrayCast2, ArrayCast2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayCast3), ArrayCast3, ArrayCast3Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayCast4), ArrayCast4, ArrayCast4Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectCast), ArraySelectCast, ArraySelectCastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereCast), ArrayWhereCast, ArrayWhereCastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayCastAverage), ArrayCastAverage, ArrayCastAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayCastAny), ArrayCastAny, ArrayCastAnyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayCastAggregate), ArrayCastAggregate, ArrayCastAggregateRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableCast), EnumerableCast, EnumerableCastRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableCastToArray), EnumerableCastToArray, EnumerableCastToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayCastToArray), ArrayCastToArray, ArrayCastToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayCast()
    {
        return ArrayItems.Cast<int>();
    } //EndMethod

    public IEnumerable<int> ArrayCastRewritten()
    {
        return ArrayCastRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<float> ArrayCast2()
    {
        return ArrayItems.Cast<float>();
    } //EndMethod

    public IEnumerable<float> ArrayCast2Rewritten()
    {
        return ArrayCast2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> ArrayCast3()
    {
        return ArrayItems.Cast<double>();
    } //EndMethod

    public IEnumerable<double> ArrayCast3Rewritten()
    {
        return ArrayCast3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double?> ArrayCast4()
    {
        return ArrayItems.Cast<double?>();
    } //EndMethod

    public IEnumerable<double?> ArrayCast4Rewritten()
    {
        return ArrayCast4Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectCast()
    {
        return ArrayItems.Select(x => x + 0.2).Cast<int>();
    } //EndMethod

    public IEnumerable<int> ArraySelectCastRewritten()
    {
        return ArraySelectCastRewritten_ProceduralLinq1(ArrayItems, x => x + 0.2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> ArrayWhereCast()
    {
        return ArrayItems.Where(x => x % 2 == 1).Cast<double>();
    } //EndMethod

    public IEnumerable<double> ArrayWhereCastRewritten()
    {
        return ArrayWhereCastRewritten_ProceduralLinq1(ArrayItems, x => x % 2 == 1);
    } //EndMethod

    [NoRewrite]
    public double? ArrayCastAverage()
    {
        return ArrayItems.Cast<double?>().Average();
    } //EndMethod

    public double? ArrayCastAverageRewritten()
    {
        return ArrayCastAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayCastAny()
    {
        return ArrayItems.Cast<double?>().Any(x => x == null);
    } //EndMethod

    public bool ArrayCastAnyRewritten()
    {
        return ArrayCastAnyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayCastAggregate()
    {
        return ArrayItems.Cast<double>().Aggregate((x, y) => x * y);
    } //EndMethod

    public double ArrayCastAggregateRewritten()
    {
        return ArrayCastAggregateRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> EnumerableCast()
    {
        return EnumerableItems.Cast<double>();
    } //EndMethod

    public IEnumerable<double> EnumerableCastRewritten()
    {
        return EnumerableCastRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> EnumerableCastToArray()
    {
        return EnumerableItems.Cast<double>().ToArray();
    } //EndMethod

    public IEnumerable<double> EnumerableCastToArrayRewritten()
    {
        return EnumerableCastToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> ArrayCastToArray()
    {
        return ArrayItems.Cast<double>().ToArray();
    } //EndMethod

    public IEnumerable<double> ArrayCastToArrayRewritten()
    {
        return ArrayCastToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayCastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v110;
        v110 = 0;
        for (; v110 < ArrayItems.Length; v110++)
            yield return (int)ArrayItems[v110];
    }

    System.Collections.Generic.IEnumerable<float> ArrayCast2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v111;
        v111 = 0;
        for (; v111 < ArrayItems.Length; v111++)
            yield return (float)ArrayItems[v111];
    }

    System.Collections.Generic.IEnumerable<double> ArrayCast3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v112;
        v112 = 0;
        for (; v112 < ArrayItems.Length; v112++)
            yield return (double)ArrayItems[v112];
    }

    System.Collections.Generic.IEnumerable<double?> ArrayCast4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v113;
        v113 = 0;
        for (; v113 < ArrayItems.Length; v113++)
            yield return (double? )ArrayItems[v113];
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectCastRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, double> v115)
    {
        int v114;
        v114 = 0;
        for (; v114 < ArrayItems.Length; v114++)
            yield return (int)v115(ArrayItems[v114]);
    }

    System.Collections.Generic.IEnumerable<double> ArrayWhereCastRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v117)
    {
        int v116;
        v116 = 0;
        for (; v116 < ArrayItems.Length; v116++)
        {
            if (!v117(ArrayItems[v116]))
                continue;
            yield return (double)ArrayItems[v116];
        }
    }

    double? ArrayCastAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v118;
        double v119;
        double? v120;
        int v121;
        v119 = 0;
        v121 = 0;
        v118 = 0;
        for (; v118 < ArrayItems.Length; v118++)
        {
            v120 = (double? )ArrayItems[v118];
            if (v120 == null)
                continue;
            v119 += (double)v120;
            v121++;
        }

        return v121 == 0 ? null : ((double? )v119 / v121);
    }

    bool ArrayCastAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v122;
        v122 = 0;
        for (; v122 < ArrayItems.Length; v122++)
            if (((double? )ArrayItems[v122] == null))
                return true;
        return false;
    }

    double ArrayCastAggregateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v123;
        double v124;
        bool v125;
        v124 = default(double);
        v125 = true;
        v123 = 0;
        for (; v123 < ArrayItems.Length; v123++)
            if (v125)
            {
                v124 = (double)ArrayItems[v123];
                v125 = false;
                continue;
            }
            else
                v124 = (v124 * (double)ArrayItems[v123]);
        if (v125)
            throw new System.InvalidOperationException("The sequence did not contain valid elements.");
        return v124;
    }

    System.Collections.Generic.IEnumerable<double> EnumerableCastRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v126;
        v126 = EnumerableItems.GetEnumerator();
        try
        {
            while (v126.MoveNext())
                yield return (double)v126.Current;
        }
        finally
        {
            v126.Dispose();
        }
    }

    double[] EnumerableCastToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v127;
        int v128;
        int v129;
        double[] v130;
        v128 = 0;
        v129 = 8;
        v130 = new double[8];
        v127 = EnumerableItems.GetEnumerator();
        try
        {
            while (v127.MoveNext())
            {
                if (v128 >= v129)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v130, ref v129);
                v130[v128] = (double)v127.Current;
                v128++;
            }
        }
        finally
        {
            v127.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v130, v128);
    }

    double[] ArrayCastToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v131;
        double[] v132;
        v132 = new double[ArrayItems.Length];
        v131 = 0;
        for (; v131 < ArrayItems.Length; v131++)
            v132[v131] = (double)ArrayItems[v131];
        return v132;
    }
}}