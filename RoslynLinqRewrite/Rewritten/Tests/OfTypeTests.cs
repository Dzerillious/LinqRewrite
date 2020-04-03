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
        return ArraySelectOfTypeRewritten_ProceduralLinq1(ArrayItems, x => x + 0.2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> ArrayWhereOfType()
    {
        return ArrayItems.Where(x => x % 2 == 1).OfType<double>();
    } //EndMethod

    public IEnumerable<double> ArrayWhereOfTypeRewritten()
    {
        return ArrayWhereOfTypeRewritten_ProceduralLinq1(ArrayItems, x => x % 2 == 1);
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
        int v1433;
        v1433 = 0;
        for (; v1433 < ArrayItems.Length; v1433++)
        {
            if (!(ArrayItems[v1433] is int))
                continue;
            yield return (int)(object)ArrayItems[v1433];
        }
    }

    System.Collections.Generic.IEnumerable<float> ArrayOfType2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1434;
        v1434 = 0;
        for (; v1434 < ArrayItems.Length; v1434++)
        {
            if (!(ArrayItems[v1434] is float))
                continue;
            yield return (float)(object)ArrayItems[v1434];
        }
    }

    System.Collections.Generic.IEnumerable<double> ArrayOfType3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1435;
        v1435 = 0;
        for (; v1435 < ArrayItems.Length; v1435++)
        {
            if (!(ArrayItems[v1435] is double))
                continue;
            yield return (double)(object)ArrayItems[v1435];
        }
    }

    System.Collections.Generic.IEnumerable<double?> ArrayOfType4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1436;
        v1436 = 0;
        for (; v1436 < ArrayItems.Length; v1436++)
        {
            if (!(ArrayItems[v1436] is double? ))
                continue;
            yield return (double? )(object)ArrayItems[v1436];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectOfTypeRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, double> v1438)
    {
        int v1437;
        double v1439;
        v1437 = 0;
        for (; v1437 < ArrayItems.Length; v1437++)
        {
            v1439 = v1438(ArrayItems[v1437]);
            if (!(v1439 is int))
                continue;
            yield return (int)(object)v1439;
        }
    }

    System.Collections.Generic.IEnumerable<double> ArrayWhereOfTypeRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v1441)
    {
        int v1440;
        v1440 = 0;
        for (; v1440 < ArrayItems.Length; v1440++)
        {
            if (!(v1441(ArrayItems[v1440])))
                continue;
            if (!(ArrayItems[v1440] is double))
                continue;
            yield return (double)(object)ArrayItems[v1440];
        }
    }

    double? ArrayOfTypeAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1442;
        double v1443;
        double? v1444;
        int v1445;
        v1443 = 0;
        v1445 = 0;
        v1442 = 0;
        for (; v1442 < ArrayItems.Length; v1442++)
        {
            if (!(ArrayItems[v1442] is double? ))
                continue;
            v1444 = (double? )(object)ArrayItems[v1442];
            if (v1444 == null)
                continue;
            v1443 += (double)v1444;
            v1445++;
        }

        return v1445 == 0 ? null : ((double? )v1443 / v1445);
    }

    bool ArrayOfTypeAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1446;
        v1446 = 0;
        for (; v1446 < ArrayItems.Length; v1446++)
        {
            if (!(ArrayItems[v1446] is double? ))
                continue;
            if (((double? )(object)ArrayItems[v1446] == null))
                return true;
        }

        return false;
    }

    double ArrayOfTypeAggregateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1447;
        double v1448;
        bool v1449;
        v1448 = default(double);
        v1449 = true;
        v1447 = 0;
        for (; v1447 < ArrayItems.Length; v1447++)
        {
            if (!(ArrayItems[v1447] is double))
                continue;
            if (v1449)
            {
                v1448 = (double)(object)ArrayItems[v1447];
                v1449 = false;
                continue;
            }
            else
                v1448 = (v1448 * (double)(object)ArrayItems[v1447]);
        }

        if (v1449)
            throw new System.InvalidOperationException("The sequence did not contain valid elements.");
        return v1448;
    }

    System.Collections.Generic.IEnumerable<double> EnumerableOfTypeRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1450;
        int v1451;
        v1450 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1450.MoveNext())
            {
                v1451 = v1450.Current;
                if (!(v1451 is double))
                    continue;
                yield return (double)(object)v1451;
            }
        }
        finally
        {
            v1450.Dispose();
        }
    }

    double[] EnumerableOfTypeToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1452;
        int v1453;
        int v1454;
        int v1455;
        double[] v1456;
        v1452 = EnumerableItems.GetEnumerator();
        v1454 = 0;
        v1455 = 8;
        v1456 = new double[8];
        try
        {
            while (v1452.MoveNext())
            {
                v1453 = v1452.Current;
                if (!(v1453 is double))
                    continue;
                if (v1454 >= v1455)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1456, ref v1455);
                v1456[v1454] = (double)(object)v1453;
                v1454++;
            }
        }
        finally
        {
            v1452.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1456, v1454);
    }

    double[] ArrayOfTypeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1457;
        int v1458;
        int v1459;
        int v1460;
        double[] v1461;
        v1458 = 0;
        v1459 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1459 -= (v1459 % 2);
        v1460 = 8;
        v1461 = new double[8];
        v1457 = 0;
        for (; v1457 < ArrayItems.Length; v1457++)
        {
            if (!(ArrayItems[v1457] is double))
                continue;
            if (v1458 >= v1460)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1461, ref v1459, out v1460);
            v1461[v1458] = (double)(object)ArrayItems[v1457];
            v1458++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1461, v1458);
    }
}}