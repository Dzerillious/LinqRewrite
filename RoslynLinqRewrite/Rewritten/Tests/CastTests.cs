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
        int v154;
        v154 = (0);
        for (; v154 < (ArrayItems.Length); v154++)
            yield return ((int)(object)(ArrayItems[v154]));
        yield break;
    }

    System.Collections.Generic.IEnumerable<float> ArrayCast2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v156;
        v156 = (0);
        for (; v156 < (ArrayItems.Length); v156++)
            yield return ((float)(object)(ArrayItems[v156]));
        yield break;
    }

    System.Collections.Generic.IEnumerable<double> ArrayCast3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v158;
        v158 = (0);
        for (; v158 < (ArrayItems.Length); v158++)
            yield return ((double)(object)(ArrayItems[v158]));
        yield break;
    }

    System.Collections.Generic.IEnumerable<double?> ArrayCast4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v160;
        v160 = (0);
        for (; v160 < (ArrayItems.Length); v160++)
            yield return ((double? )(object)(ArrayItems[v160]));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectCastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v162;
        v162 = (0);
        for (; v162 < (ArrayItems.Length); v162++)
            yield return ((int)(object)(0.2 + ArrayItems[v162]));
        yield break;
    }

    System.Collections.Generic.IEnumerable<double> ArrayWhereCastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v163;
        int v164;
        v163 = (0);
        for (; v163 < (ArrayItems.Length); v163++)
        {
            v164 = (ArrayItems[v163]);
            if (!(((v164) % 2 == 1)))
                continue;
            yield return ((double)(object)(v164));
        }

        yield break;
    }

    double? ArrayCastAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v166;
        double v167;
        double? v168;
        int v169;
        v167 = 0;
        v169 = 0;
        v166 = (0);
        for (; v166 < (ArrayItems.Length); v166++)
        {
            v168 = ((double? )(object)(ArrayItems[v166]));
            if (v168 == null)
                continue;
            v167 += (double)v168;
            v169++;
        }

        return v169 == 0 ? null : ((double? )v167 / v169);
    }

    bool ArrayCastAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v171;
        v171 = (0);
        for (; v171 < (ArrayItems.Length); v171++)
            if ((((double? )(object)(ArrayItems[v171])) == null))
                return true;
        return false;
    }

    double ArrayCastAggregateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v173;
        double v174;
        v174 = ArrayItems[0];
        v173 = (1);
        for (; v173 < (ArrayItems.Length); v173++)
            v174 = (v174 * ((double)(object)(ArrayItems[v173])));
        return v174;
    }

    System.Collections.Generic.IEnumerable<double> EnumerableCastRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v175;
        v175 = EnumerableItems.GetEnumerator();
        try
        {
            while (v175.MoveNext())
                yield return ((double)(object)(v175.Current));
        }
        finally
        {
            v175.Dispose();
        }

        yield break;
    }

    double[] EnumerableCastToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v176;
        int v177;
        int v178;
        double[] v179;
        v176 = EnumerableItems.GetEnumerator();
        v177 = 0;
        v178 = 8;
        v179 = new double[8];
        try
        {
            while (v176.MoveNext())
            {
                if (v177 >= v178)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v179, ref v178);
                v179[v177] = ((double)(object)(v176.Current));
                v177++;
            }
        }
        finally
        {
            v176.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v179, v177);
    }

    double[] ArrayCastToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v181;
        double[] v182;
        v182 = new double[(ArrayItems.Length)];
        v181 = (0);
        for (; v181 < (ArrayItems.Length); v181++)
            v182[v181] = ((double)(object)(ArrayItems[v181]));
        return v182;
    }
}}