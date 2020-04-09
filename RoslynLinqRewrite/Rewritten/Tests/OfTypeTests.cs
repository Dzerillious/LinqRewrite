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
        int v1726;
        int v1727;
        v1726 = (0);
        for (; v1726 < (ArrayItems.Length); v1726++)
        {
            v1727 = (ArrayItems[v1726]);
            if (!((v1727) is int))
                continue;
            yield return ((int)(object)(v1727));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<float> ArrayOfType2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1728;
        int v1729;
        v1728 = (0);
        for (; v1728 < (ArrayItems.Length); v1728++)
        {
            v1729 = (ArrayItems[v1728]);
            if (!((v1729) is float))
                continue;
            yield return ((float)(object)(v1729));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<double> ArrayOfType3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1730;
        int v1731;
        v1730 = (0);
        for (; v1730 < (ArrayItems.Length); v1730++)
        {
            v1731 = (ArrayItems[v1730]);
            if (!((v1731) is double))
                continue;
            yield return ((double)(object)(v1731));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<double?> ArrayOfType4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1732;
        int v1733;
        v1732 = (0);
        for (; v1732 < (ArrayItems.Length); v1732++)
        {
            v1733 = (ArrayItems[v1732]);
            if (!((v1733) is double? ))
                continue;
            yield return ((double? )(object)(v1733));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectOfTypeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1734;
        double v1735;
        v1734 = (0);
        for (; v1734 < (ArrayItems.Length); v1734++)
        {
            v1735 = (0.2 + ArrayItems[v1734]);
            if (!((v1735) is int))
                continue;
            yield return ((int)(object)(v1735));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<double> ArrayWhereOfTypeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1736;
        int v1737;
        v1736 = (0);
        for (; v1736 < (ArrayItems.Length); v1736++)
        {
            v1737 = (ArrayItems[v1736]);
            if (!(((v1737) % 2 == 1)))
                continue;
            v1737 = (v1737);
            if (!((v1737) is double))
                continue;
            yield return ((double)(object)(v1737));
        }

        yield break;
    }

    double? ArrayOfTypeAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1738;
        int v1739;
        double v1740;
        double? v1741;
        int v1742;
        v1740 = 0;
        v1742 = 0;
        v1738 = (0);
        for (; v1738 < (ArrayItems.Length); v1738++)
        {
            v1739 = (ArrayItems[v1738]);
            if (!((v1739) is double? ))
                continue;
            v1741 = ((double? )(object)(v1739));
            if (v1741 == null)
                continue;
            v1740 += (double)v1741;
            v1742++;
        }

        return v1742 == 0 ? null : ((double? )v1740 / v1742);
    }

    bool ArrayOfTypeAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1743;
        int v1744;
        v1743 = (0);
        for (; v1743 < (ArrayItems.Length); v1743++)
        {
            v1744 = (ArrayItems[v1743]);
            if (!((v1744) is double? ))
                continue;
            if ((((double? )(object)(v1744)) == null))
                return true;
        }

        return false;
    }

    double ArrayOfTypeAggregateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1745;
        int v1746;
        int v1747;
        double v1748;
        bool v1749;
        v1747 = 0;
        v1748 = default(double);
        v1749 = true;
        v1745 = (0);
        for (; v1745 < (ArrayItems.Length); v1745++)
        {
            v1746 = (ArrayItems[v1745]);
            if (!((v1746) is double))
                continue;
            if (v1749)
            {
                v1748 = ((double)(object)(v1746));
                v1749 = false;
                continue;
            }
            else
                v1748 = (v1748 * ((double)(object)(v1746)));
            v1747++;
        }

        if (v1749)
            throw new System.InvalidOperationException("The sequence did not contain enough elements.");
        return v1748;
    }

    System.Collections.Generic.IEnumerable<double> EnumerableOfTypeRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1750;
        int v1751;
        v1750 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1750.MoveNext())
            {
                v1751 = (v1750.Current);
                if (!((v1751) is double))
                    continue;
                yield return ((double)(object)(v1751));
            }
        }
        finally
        {
            v1750.Dispose();
        }

        yield break;
    }

    double[] EnumerableOfTypeToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1752;
        int v1753;
        int v1754;
        int v1755;
        double[] v1756;
        v1752 = EnumerableItems.GetEnumerator();
        v1754 = 0;
        v1755 = 8;
        v1756 = new double[8];
        try
        {
            while (v1752.MoveNext())
            {
                v1753 = (v1752.Current);
                if (!((v1753) is double))
                    continue;
                if (v1754 >= v1755)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1756, ref v1755);
                v1756[v1754] = ((double)(object)(v1753));
                v1754++;
            }
        }
        finally
        {
            v1752.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1756, v1754);
    }

    double[] ArrayOfTypeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1757;
        int v1758;
        int v1759;
        int v1760;
        int v1761;
        double[] v1762;
        v1759 = 0;
        v1760 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v1760 -= (v1760 % 2);
        v1761 = 8;
        v1762 = new double[8];
        v1757 = (0);
        for (; v1757 < (ArrayItems.Length); v1757++)
        {
            v1758 = (ArrayItems[v1757]);
            if (!((v1758) is double))
                continue;
            if (v1759 >= v1761)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v1762, ref v1760, out v1761);
            v1762[v1759] = ((double)(object)(v1758));
            v1759++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1762, v1759);
    }
}}