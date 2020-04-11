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
        int v143;
        v143 = (0);
        for (; v143 < (ArrayItems.Length); v143 += 1)
            yield return ((int)(object)(ArrayItems[v143]));
        yield break;
    }

    System.Collections.Generic.IEnumerable<float> ArrayCast2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v145;
        v145 = (0);
        for (; v145 < (ArrayItems.Length); v145 += 1)
            yield return ((float)(object)(ArrayItems[v145]));
        yield break;
    }

    System.Collections.Generic.IEnumerable<double> ArrayCast3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v147;
        v147 = (0);
        for (; v147 < (ArrayItems.Length); v147 += 1)
            yield return ((double)(object)(ArrayItems[v147]));
        yield break;
    }

    System.Collections.Generic.IEnumerable<double?> ArrayCast4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v149;
        v149 = (0);
        for (; v149 < (ArrayItems.Length); v149 += 1)
            yield return ((double? )(object)(ArrayItems[v149]));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectCastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v151;
        v151 = (0);
        for (; v151 < (ArrayItems.Length); v151 += 1)
            yield return ((int)(object)(0.2 + ArrayItems[v151]));
        yield break;
    }

    System.Collections.Generic.IEnumerable<double> ArrayWhereCastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v152;
        v152 = (0);
        for (; v152 < (ArrayItems.Length); v152 += 1)
        {
            if (!((((ArrayItems[v152])) % 2 == 1)))
                continue;
            yield return ((double)(object)((ArrayItems[v152])));
        }

        yield break;
    }

    double? ArrayCastAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v154;
        double v155;
        double? v156;
        int v157;
        v155 = 0;
        v157 = 0;
        v154 = (0);
        for (; v154 < (ArrayItems.Length); v154 += 1)
        {
            v156 = ((double? )(object)(ArrayItems[v154]));
            if (v156 == null)
                continue;
            v155 += (double)v156;
            v157++;
        }

        return v157 == 0 ? null : ((double? )v155 / v157);
    }

    bool ArrayCastAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v159;
        v159 = (0);
        for (; v159 < (ArrayItems.Length); v159 += 1)
            if ((((double? )(object)(ArrayItems[v159])) == null))
                return true;
        return false;
    }

    double ArrayCastAggregateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v161;
        double v162;
        v162 = ArrayItems[0];
        v161 = (1);
        for (; v161 < (ArrayItems.Length); v161 += 1)
            v162 = (v162 * ((double)(object)(ArrayItems[v161])));
        return v162;
    }

    System.Collections.Generic.IEnumerable<double> EnumerableCastRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v163;
        v163 = EnumerableItems.GetEnumerator();
        try
        {
            while (v163.MoveNext())
                yield return ((double)(object)(v163.Current));
        }
        finally
        {
            v163.Dispose();
        }

        yield break;
    }

    double[] EnumerableCastToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v164;
        int v165;
        int v166;
        double[] v167;
        v164 = EnumerableItems.GetEnumerator();
        v165 = 0;
        v166 = 8;
        v167 = new double[8];
        try
        {
            while (v164.MoveNext())
            {
                if (v165 >= v166)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v167, ref v166);
                v167[v165] = ((double)(object)(v164.Current));
                v165++;
            }
        }
        finally
        {
            v164.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v167, v165);
    }

    double[] ArrayCastToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v169;
        double[] v170;
        v170 = new double[(ArrayItems.Length)];
        v169 = (0);
        for (; v169 < (ArrayItems.Length); v169 += 1)
            v170[v169] = ((double)(object)(ArrayItems[v169]));
        return v170;
    }
}}