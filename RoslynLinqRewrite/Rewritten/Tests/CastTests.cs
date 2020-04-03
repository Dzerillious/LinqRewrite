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
        return ArraySelectCastRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> ArrayWhereCast()
    {
        return ArrayItems.Where(x => x % 2 == 1).Cast<double>();
    } //EndMethod

    public IEnumerable<double> ArrayWhereCastRewritten()
    {
        return ArrayWhereCastRewritten_ProceduralLinq1(ArrayItems);
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
        int v114;
        v114 = 0;
        for (; v114 < ArrayItems.Length; v114++)
            yield return (int)(object)ArrayItems[v114];
    }

    System.Collections.Generic.IEnumerable<float> ArrayCast2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v115;
        v115 = 0;
        for (; v115 < ArrayItems.Length; v115++)
            yield return (float)(object)ArrayItems[v115];
    }

    System.Collections.Generic.IEnumerable<double> ArrayCast3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v116;
        v116 = 0;
        for (; v116 < ArrayItems.Length; v116++)
            yield return (double)(object)ArrayItems[v116];
    }

    System.Collections.Generic.IEnumerable<double?> ArrayCast4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v117;
        v117 = 0;
        for (; v117 < ArrayItems.Length; v117++)
            yield return (double? )(object)ArrayItems[v117];
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectCastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v118;
        v118 = 0;
        for (; v118 < ArrayItems.Length; v118++)
            yield return (int)(object)(ArrayItems[v118] + 0.2);
    }

    System.Collections.Generic.IEnumerable<double> ArrayWhereCastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v119;
        v119 = 0;
        for (; v119 < ArrayItems.Length; v119++)
        {
            if (!((ArrayItems[v119] % 2 == 1)))
                continue;
            yield return (double)(object)ArrayItems[v119];
        }
    }

    double? ArrayCastAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v120;
        double v121;
        double? v122;
        int v123;
        v121 = 0;
        v123 = 0;
        v120 = 0;
        for (; v120 < ArrayItems.Length; v120++)
        {
            v122 = (double? )(object)ArrayItems[v120];
            if (v122 == null)
                continue;
            v121 += (double)v122;
            v123++;
        }

        return v123 == 0 ? null : ((double? )v121 / v123);
    }

    bool ArrayCastAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v124;
        v124 = 0;
        for (; v124 < ArrayItems.Length; v124++)
            if (((double? )(object)ArrayItems[v124] == null))
                return true;
        return false;
    }

    double ArrayCastAggregateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v125;
        double v126;
        bool v127;
        v126 = default(double);
        v127 = true;
        v125 = 0;
        for (; v125 < ArrayItems.Length; v125++)
            if (v127)
            {
                v126 = (double)(object)ArrayItems[v125];
                v127 = false;
                continue;
            }
            else
                v126 = (v126 * (double)(object)ArrayItems[v125]);
        if (v127)
            throw new System.InvalidOperationException("The sequence did not contain valid elements.");
        return v126;
    }

    System.Collections.Generic.IEnumerable<double> EnumerableCastRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v128;
        v128 = EnumerableItems.GetEnumerator();
        try
        {
            while (v128.MoveNext())
                yield return (double)(object)v128.Current;
        }
        finally
        {
            v128.Dispose();
        }
    }

    double[] EnumerableCastToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v129;
        int v130;
        int v131;
        double[] v132;
        v129 = EnumerableItems.GetEnumerator();
        v130 = 0;
        v131 = 8;
        v132 = new double[8];
        try
        {
            while (v129.MoveNext())
            {
                if (v130 >= v131)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v132, ref v131);
                v132[v130] = (double)(object)v129.Current;
                v130++;
            }
        }
        finally
        {
            v129.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v132, v130);
    }

    double[] ArrayCastToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v133;
        double[] v134;
        v134 = new double[ArrayItems.Length];
        v133 = 0;
        for (; v133 < ArrayItems.Length; v133++)
            v134[v133] = (double)(object)ArrayItems[v133];
        return v134;
    }
}}