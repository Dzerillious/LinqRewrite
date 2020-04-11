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
        int v1547;
        v1547 = (0);
        for (; v1547 < (ArrayItems.Length); v1547 += 1)
        {
            if (!(((ArrayItems[v1547])) is int))
                continue;
            yield return ((int)(object)((ArrayItems[v1547])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<float> ArrayOfType2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1548;
        v1548 = (0);
        for (; v1548 < (ArrayItems.Length); v1548 += 1)
        {
            if (!(((ArrayItems[v1548])) is float))
                continue;
            yield return ((float)(object)((ArrayItems[v1548])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<double> ArrayOfType3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1549;
        v1549 = (0);
        for (; v1549 < (ArrayItems.Length); v1549 += 1)
        {
            if (!(((ArrayItems[v1549])) is double))
                continue;
            yield return ((double)(object)((ArrayItems[v1549])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<double?> ArrayOfType4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1550;
        v1550 = (0);
        for (; v1550 < (ArrayItems.Length); v1550 += 1)
        {
            if (!(((ArrayItems[v1550])) is double? ))
                continue;
            yield return ((double? )(object)((ArrayItems[v1550])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectOfTypeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1551;
        double v1552;
        v1551 = (0);
        for (; v1551 < (ArrayItems.Length); v1551 += 1)
        {
            v1552 = (0.2 + ArrayItems[v1551]);
            if (!((v1552) is int))
                continue;
            yield return ((int)(object)(v1552));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<double> ArrayWhereOfTypeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1553;
        v1553 = (0);
        for (; v1553 < (ArrayItems.Length); v1553 += 1)
        {
            if (!((((ArrayItems[v1553])) % 2 == 1)))
                continue;
            if (!((((ArrayItems[v1553]))) is double))
                continue;
            yield return ((double)(object)(((ArrayItems[v1553]))));
        }

        yield break;
    }

    double? ArrayOfTypeAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1554;
        double v1555;
        double? v1556;
        int v1557;
        v1555 = 0;
        v1557 = 0;
        v1554 = (0);
        for (; v1554 < (ArrayItems.Length); v1554 += 1)
        {
            if (!(((ArrayItems[v1554])) is double? ))
                continue;
            v1556 = ((double? )(object)((ArrayItems[v1554])));
            if (v1556 == null)
                continue;
            v1555 += (double)v1556;
            v1557++;
        }

        return v1557 == 0 ? null : ((double? )v1555 / v1557);
    }

    bool ArrayOfTypeAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1558;
        v1558 = (0);
        for (; v1558 < (ArrayItems.Length); v1558 += 1)
        {
            if (!(((ArrayItems[v1558])) is double? ))
                continue;
            if ((((double? )(object)((ArrayItems[v1558]))) == null))
                return true;
        }

        return false;
    }

    double ArrayOfTypeAggregateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1559;
        int v1560;
        double v1561;
        bool v1562;
        v1560 = 0;
        v1561 = default(double);
        v1562 = true;
        v1559 = (0);
        for (; v1559 < (ArrayItems.Length); v1559 += 1)
        {
            if (!(((ArrayItems[v1559])) is double))
                continue;
            if (v1562)
            {
                v1561 = ((double)(object)((ArrayItems[v1559])));
                v1562 = false;
                continue;
            }
            else
                v1561 = (v1561 * ((double)(object)((ArrayItems[v1559]))));
            v1560++;
        }

        if (v1562)
            throw new System.InvalidOperationException("The sequence did not contain enough elements.");
        return v1561;
    }

    System.Collections.Generic.IEnumerable<double> EnumerableOfTypeRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1563;
        int v1564;
        v1563 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1563.MoveNext())
            {
                v1564 = (v1563.Current);
                if (!((v1564) is double))
                    continue;
                yield return ((double)(object)(v1564));
            }
        }
        finally
        {
            v1563.Dispose();
        }

        yield break;
    }

    double[] EnumerableOfTypeToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1565;
        int v1566;
        int v1567;
        int v1568;
        double[] v1569;
        v1565 = EnumerableItems.GetEnumerator();
        v1567 = 0;
        v1568 = 8;
        v1569 = new double[8];
        try
        {
            while (v1565.MoveNext())
            {
                v1566 = (v1565.Current);
                if (!((v1566) is double))
                    continue;
                if (v1567 >= v1568)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1569, ref v1568);
                v1569[v1567] = ((double)(object)(v1566));
                v1567++;
            }
        }
        finally
        {
            v1565.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1569, v1567);
    }

    double[] ArrayOfTypeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1570;
        int v1571;
        int v1572;
        int v1573;
        double[] v1574;
        v1571 = 0;
        v1572 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v1572 -= (v1572 % 2);
        v1573 = 8;
        v1574 = new double[8];
        v1570 = (0);
        for (; v1570 < (ArrayItems.Length); v1570 += 1)
        {
            if (!(((ArrayItems[v1570])) is double))
                continue;
            if (v1571 >= v1573)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v1574, ref v1572, out v1573);
            v1574[v1571] = ((double)(object)((ArrayItems[v1570])));
            v1571++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1574, v1571);
    }
}}