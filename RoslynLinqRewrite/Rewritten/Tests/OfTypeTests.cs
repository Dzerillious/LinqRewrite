using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class OfTypeTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayOfType), ArrayOfType, ArrayOfTypeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayOfType2), ArrayOfType2, ArrayOfType2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayOfType3), ArrayOfType3, ArrayOfType3Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayOfType4), ArrayOfType4, ArrayOfType4Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectOfType), ArraySelectOfType, ArraySelectOfTypeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereOfType), ArrayWhereOfType, ArrayWhereOfTypeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayOfTypeAverage), ArrayOfTypeAverage, ArrayOfTypeAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayOfTypeAny), ArrayOfTypeAny, ArrayOfTypeAnyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayOfTypeAggregate), ArrayOfTypeAggregate, ArrayOfTypeAggregateRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableOfType), EnumerableOfType, EnumerableOfTypeRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableOfTypeToArray), EnumerableOfTypeToArray, EnumerableOfTypeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayOfTypeToArray), ArrayOfTypeToArray, ArrayOfTypeToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayOfType()
    {
        return ArrayItems.OfType<int>();
    } //EndMethod

    public IEnumerable<int> ArrayOfTypeRewritten()
    {
        return ArrayOfTypeRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<float> ArrayOfType2()
    {
        return ArrayItems.OfType<float>();
    } //EndMethod

    public IEnumerable<float> ArrayOfType2Rewritten()
    {
        return ArrayOfType2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> ArrayOfType3()
    {
        return ArrayItems.OfType<double>();
    } //EndMethod

    public IEnumerable<double> ArrayOfType3Rewritten()
    {
        return ArrayOfType3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double?> ArrayOfType4()
    {
        return ArrayItems.OfType<double?>();
    } //EndMethod

    public IEnumerable<double?> ArrayOfType4Rewritten()
    {
        return ArrayOfType4Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectOfType()
    {
        return ArrayItems.Select(x => x + 0.2).OfType<int>();
    } //EndMethod

    public IEnumerable<int> ArraySelectOfTypeRewritten()
    {
        return ArraySelectOfTypeRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> ArrayWhereOfType()
    {
        return ArrayItems.Where(x => x % 2 == 1).OfType<double>();
    } //EndMethod

    public IEnumerable<double> ArrayWhereOfTypeRewritten()
    {
        return ArrayWhereOfTypeRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? ArrayOfTypeAverage()
    {
        return ArrayItems.OfType<double?>().Average();
    } //EndMethod

    public double? ArrayOfTypeAverageRewritten()
    {
        return ArrayOfTypeAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayOfTypeAny()
    {
        return ArrayItems.OfType<double?>().Any(x => x == null);
    } //EndMethod

    public bool ArrayOfTypeAnyRewritten()
    {
        return ArrayOfTypeAnyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayOfTypeAggregate()
    {
        return ArrayItems.OfType<double>().Aggregate((x, y) => x * y);
    } //EndMethod

    public double ArrayOfTypeAggregateRewritten()
    {
        return ArrayOfTypeAggregateRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> EnumerableOfType()
    {
        return EnumerableItems.OfType<double>();
    } //EndMethod

    public IEnumerable<double> EnumerableOfTypeRewritten()
    {
        return EnumerableOfTypeRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> EnumerableOfTypeToArray()
    {
        return EnumerableItems.OfType<double>().ToArray();
    } //EndMethod

    public IEnumerable<double> EnumerableOfTypeToArrayRewritten()
    {
        return EnumerableOfTypeToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> ArrayOfTypeToArray()
    {
        return ArrayItems.OfType<double>().ToArray();
    } //EndMethod

    public IEnumerable<double> ArrayOfTypeToArrayRewritten()
    {
        return ArrayOfTypeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayOfTypeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1406;
        v1406 = 0;
        for (; v1406 < ArrayItems.Length; v1406++)
        {
            if (!(ArrayItems[v1406] is int))
                continue;
            yield return (int)(object)ArrayItems[v1406];
        }
    }

    System.Collections.Generic.IEnumerable<float> ArrayOfType2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1407;
        v1407 = 0;
        for (; v1407 < ArrayItems.Length; v1407++)
        {
            if (!(ArrayItems[v1407] is float))
                continue;
            yield return (float)(object)ArrayItems[v1407];
        }
    }

    System.Collections.Generic.IEnumerable<double> ArrayOfType3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1408;
        v1408 = 0;
        for (; v1408 < ArrayItems.Length; v1408++)
        {
            if (!(ArrayItems[v1408] is double))
                continue;
            yield return (double)(object)ArrayItems[v1408];
        }
    }

    System.Collections.Generic.IEnumerable<double?> ArrayOfType4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1409;
        v1409 = 0;
        for (; v1409 < ArrayItems.Length; v1409++)
        {
            if (!(ArrayItems[v1409] is double? ))
                continue;
            yield return (double? )(object)ArrayItems[v1409];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectOfTypeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1410;
        double v1411;
        v1410 = 0;
        for (; v1410 < ArrayItems.Length; v1410++)
        {
            v1411 = (ArrayItems[v1410] + 0.2);
            if (!(v1411 is int))
                continue;
            yield return (int)(object)v1411;
        }
    }

    System.Collections.Generic.IEnumerable<double> ArrayWhereOfTypeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1412;
        v1412 = 0;
        for (; v1412 < ArrayItems.Length; v1412++)
        {
            if (!((ArrayItems[v1412] % 2 == 1)))
                continue;
            if (!(ArrayItems[v1412] is double))
                continue;
            yield return (double)(object)ArrayItems[v1412];
        }
    }

    double? ArrayOfTypeAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1413;
        double v1414;
        double? v1415;
        int v1416;
        v1414 = 0;
        v1416 = 0;
        v1413 = 0;
        for (; v1413 < ArrayItems.Length; v1413++)
        {
            if (!(ArrayItems[v1413] is double? ))
                continue;
            v1415 = (double? )(object)ArrayItems[v1413];
            if (v1415 == null)
                continue;
            v1414 += (double)v1415;
            v1416++;
        }

        return v1416 == 0 ? null : ((double? )v1414 / v1416);
    }

    bool ArrayOfTypeAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1417;
        v1417 = 0;
        for (; v1417 < ArrayItems.Length; v1417++)
        {
            if (!(ArrayItems[v1417] is double? ))
                continue;
            if (((double? )(object)ArrayItems[v1417] == null))
                return true;
        }

        return false;
    }

    double ArrayOfTypeAggregateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1418;
        double v1419;
        bool v1420;
        v1419 = default(double);
        v1420 = true;
        v1418 = 0;
        for (; v1418 < ArrayItems.Length; v1418++)
        {
            if (!(ArrayItems[v1418] is double))
                continue;
            if (v1420)
            {
                v1419 = (double)(object)ArrayItems[v1418];
                v1420 = false;
                continue;
            }
            else
                v1419 = (v1419 * (double)(object)ArrayItems[v1418]);
        }

        if (v1420)
            throw new System.InvalidOperationException("The sequence did not contain valid elements.");
        return v1419;
    }

    System.Collections.Generic.IEnumerable<double> EnumerableOfTypeRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1421;
        int v1422;
        v1421 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1421.MoveNext())
            {
                v1422 = v1421.Current;
                if (!(v1422 is double))
                    continue;
                yield return (double)(object)v1422;
            }
        }
        finally
        {
            v1421.Dispose();
        }
    }

    double[] EnumerableOfTypeToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1423;
        int v1424;
        int v1425;
        int v1426;
        double[] v1427;
        v1423 = EnumerableItems.GetEnumerator();
        v1425 = 0;
        v1426 = 8;
        v1427 = new double[8];
        try
        {
            while (v1423.MoveNext())
            {
                v1424 = v1423.Current;
                if (!(v1424 is double))
                    continue;
                if (v1425 >= v1426)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1427, ref v1426);
                v1427[v1425] = (double)(object)v1424;
                v1425++;
            }
        }
        finally
        {
            v1423.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1427, v1425);
    }

    double[] ArrayOfTypeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1428;
        int v1429;
        int v1430;
        int v1431;
        double[] v1432;
        v1429 = 0;
        v1430 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1430 -= (v1430 % 2);
        v1431 = 8;
        v1432 = new double[8];
        v1428 = 0;
        for (; v1428 < ArrayItems.Length; v1428++)
        {
            if (!(ArrayItems[v1428] is double))
                continue;
            if (v1429 >= v1431)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1432, ref v1430, out v1431);
            v1432[v1429] = (double)(object)ArrayItems[v1428];
            v1429++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1432, v1429);
    }
}}