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

    System.Collections.Generic.IEnumerable<int> ArraySelectCastRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, double> v119)
    {
        int v118;
        v118 = 0;
        for (; v118 < ArrayItems.Length; v118++)
            yield return (int)(object)v119(ArrayItems[v118]);
    }

    System.Collections.Generic.IEnumerable<double> ArrayWhereCastRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v121)
    {
        int v120;
        v120 = 0;
        for (; v120 < ArrayItems.Length; v120++)
        {
            if (!(v121(ArrayItems[v120])))
                continue;
            yield return (double)(object)ArrayItems[v120];
        }
    }

    double? ArrayCastAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v122;
        double v123;
        double? v124;
        int v125;
        v123 = 0;
        v125 = 0;
        v122 = 0;
        for (; v122 < ArrayItems.Length; v122++)
        {
            v124 = (double? )(object)ArrayItems[v122];
            if (v124 == null)
                continue;
            v123 += (double)v124;
            v125++;
        }

        return v125 == 0 ? null : ((double? )v123 / v125);
    }

    bool ArrayCastAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v126;
        v126 = 0;
        for (; v126 < ArrayItems.Length; v126++)
            if (((double? )(object)ArrayItems[v126] == null))
                return true;
        return false;
    }

    double ArrayCastAggregateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v127;
        double v128;
        bool v129;
        v128 = default(double);
        v129 = true;
        v127 = 0;
        for (; v127 < ArrayItems.Length; v127++)
            if (v129)
            {
                v128 = (double)(object)ArrayItems[v127];
                v129 = false;
                continue;
            }
            else
                v128 = (v128 * (double)(object)ArrayItems[v127]);
        if (v129)
            throw new System.InvalidOperationException("The sequence did not contain valid elements.");
        return v128;
    }

    System.Collections.Generic.IEnumerable<double> EnumerableCastRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v130;
        v130 = EnumerableItems.GetEnumerator();
        try
        {
            while (v130.MoveNext())
                yield return (double)(object)v130.Current;
        }
        finally
        {
            v130.Dispose();
        }
    }

    double[] EnumerableCastToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v131;
        int v132;
        int v133;
        double[] v134;
        v131 = EnumerableItems.GetEnumerator();
        v132 = 0;
        v133 = 8;
        v134 = new double[8];
        try
        {
            while (v131.MoveNext())
            {
                if (v132 >= v133)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v134, ref v133);
                v134[v132] = (double)(object)v131.Current;
                v132++;
            }
        }
        finally
        {
            v131.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v134, v132);
    }

    double[] ArrayCastToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v135;
        double[] v136;
        v136 = new double[ArrayItems.Length];
        v135 = 0;
        for (; v135 < ArrayItems.Length; v135++)
            v136[v135] = (double)(object)ArrayItems[v135];
        return v136;
    }
}}