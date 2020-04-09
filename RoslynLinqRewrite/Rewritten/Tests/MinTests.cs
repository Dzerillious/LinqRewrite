using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class MinTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private int Selector(int value) => value + 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(Min1), Min1, Min1Rewritten);
        TestsExtensions.TestEquals(nameof(Min2), Min2, Min2Rewritten);
        TestsExtensions.TestEquals(nameof(Min3), Min3, Min3Rewritten);
        TestsExtensions.TestEquals(nameof(Min4), Min4, Min4Rewritten);
        TestsExtensions.TestEquals(nameof(Min5), Min5, Min5Rewritten);
        TestsExtensions.TestEquals(nameof(Min6), Min6, Min6Rewritten);
        TestsExtensions.TestEquals(nameof(Min7), Min7, Min7Rewritten);
        TestsExtensions.TestEquals(nameof(Min8), Min8, Min8Rewritten);
        TestsExtensions.TestEquals(nameof(Min9), Min9, Min9Rewritten);
        TestsExtensions.TestEquals(nameof(Min10), Min10, Min10Rewritten);
        TestsExtensions.TestEquals(nameof(Min11), Min11, Min11Rewritten);
        TestsExtensions.TestEquals(nameof(Min12), Min12, Min12Rewritten);
        TestsExtensions.TestEquals(nameof(MinParam), MinParam, MinParamRewritten);
        TestsExtensions.TestEquals(nameof(MinChangingParam), MinChangingParam, MinChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(MinChangingParam2), MinChangingParam2, MinChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectMin), SelectMin, SelectMinRewritten);
        TestsExtensions.TestEquals(nameof(EmptyMin), EmptyMin, EmptyMinRewritten);
        TestsExtensions.TestEquals(nameof(EmptyMin2), EmptyMin2, EmptyMin2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableMin), EnumerableMin, EnumerableMinRewritten);
    }

    [NoRewrite]
    public int Min1()
    {
        return ArrayItems.Min();
    } //EndMethod

    public int Min1Rewritten()
    {
        return Min1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int Min2()
    {
        return ArrayItems.Min(x => x + 2);
    } //EndMethod

    public int Min2Rewritten()
    {
        return Min2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public float Min3()
    {
        return ArrayItems.Min(x => x + 2f);
    } //EndMethod

    public float Min3Rewritten()
    {
        return Min3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double Min4()
    {
        return ArrayItems.Min(x => x + 2d);
    } //EndMethod

    public double Min4Rewritten()
    {
        return Min4Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal Min5()
    {
        return ArrayItems.Min(x => x + 2m);
    } //EndMethod

    public decimal Min5Rewritten()
    {
        return Min5Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? Min6()
    {
        return ArrayItems.Min(x => x > 10 ? (int? )null : x + 2);
    } //EndMethod

    public int? Min6Rewritten()
    {
        return Min6Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public float? Min7()
    {
        return ArrayItems.Min(x => x > 10 ? (float? )null : x + 2);
    } //EndMethod

    public float? Min7Rewritten()
    {
        return Min7Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? Min8()
    {
        return ArrayItems.Min(x => x > 10 ? (double? )null : x + 2);
    } //EndMethod

    public double? Min8Rewritten()
    {
        return Min8Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal? Min9()
    {
        return ArrayItems.Min(x => x > 10 ? (decimal? )null : x + 2);
    } //EndMethod

    public decimal? Min9Rewritten()
    {
        return Min9Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long Min10()
    {
        return ArrayItems.Min(x => x + 2L);
    } //EndMethod

    public long Min10Rewritten()
    {
        return Min10Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long? Min11()
    {
        return ArrayItems.Min(x => x > 10 ? (long? )null : x + 2);
    } //EndMethod

    public long? Min11Rewritten()
    {
        return Min11Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? Min12()
    {
        return ArrayItems.Min(Selector);
    } //EndMethod

    public int? Min12Rewritten()
    {
        return Min12Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MinParam()
    {
        var a = 10;
        return ArrayItems.Min(x => x + a);
    } //EndMethod

    public int? MinParamRewritten()
    {
        var a = 10;
        return MinParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MinChangingParam()
    {
        var a = 10;
        return ArrayItems.Min(x => x + a++);
    } //EndMethod

    public int? MinChangingParamRewritten()
    {
        var a = 10;
        return MinChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MinChangingParam2()
    {
        var a = 10;
        return ArrayItems.Min(x => x + a--);
    } //EndMethod

    public int? MinChangingParam2Rewritten()
    {
        var a = 10;
        return MinChangingParam2Rewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? SelectMin()
    {
        var a = 10;
        return ArrayItems.Select(x => x + 3).Min();
    } //EndMethod

    public int? SelectMinRewritten()
    {
        var a = 10;
        return SelectMinRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? EmptyMin()
    {
        return Enumerable.Empty<int>().Min();
    } //EndMethod

    public int? EmptyMinRewritten()
    {
        return EmptyMinRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int? EmptyMin2()
    {
        return ArrayItems.Where(x => false).Min();
    } //EndMethod

    public int? EmptyMin2Rewritten()
    {
        return EmptyMin2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? EnumerableMin()
    {
        return EnumerableItems.Min();
    } //EndMethod

    public int? EnumerableMinRewritten()
    {
        return EnumerableMinRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    int Min1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1651;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1652;
        int v1653;
        v1652 = 2147483647;
        v1651 = (0);
        for (; v1651 < (ArrayItems.Length); v1651++)
        {
            v1653 = (ArrayItems[v1651]);
            if (v1653 >= v1652)
                continue;
            v1652 = v1653;
        }

        return v1652;
    }

    int Min2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1655;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1656;
        int v1657;
        v1656 = 2147483647;
        v1655 = (0);
        for (; v1655 < (ArrayItems.Length); v1655++)
        {
            v1657 = ((ArrayItems[v1655]) + 2);
            if (v1657 >= v1656)
                continue;
            v1656 = v1657;
        }

        return v1656;
    }

    float Min3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1659;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        float v1660;
        float v1661;
        v1660 = 3.4028235E+38F;
        v1659 = (0);
        for (; v1659 < (ArrayItems.Length); v1659++)
        {
            v1661 = ((ArrayItems[v1659]) + 2f);
            if (v1661 >= v1660)
                continue;
            v1660 = v1661;
        }

        return v1660;
    }

    double Min4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1663;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        double v1664;
        double v1665;
        v1664 = 1.7976931348623157E+308;
        v1663 = (0);
        for (; v1663 < (ArrayItems.Length); v1663++)
        {
            v1665 = ((ArrayItems[v1663]) + 2d);
            if (v1665 >= v1664)
                continue;
            v1664 = v1665;
        }

        return v1664;
    }

    decimal Min5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1667;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        decimal v1668;
        decimal v1669;
        v1668 = 79228162514264337593543950335M;
        v1667 = (0);
        for (; v1667 < (ArrayItems.Length); v1667++)
        {
            v1669 = ((ArrayItems[v1667]) + 2m);
            if (v1669 >= v1668)
                continue;
            v1668 = v1669;
        }

        return v1668;
    }

    int? Min6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1671;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1672;
        int v1673;
        int? v1674;
        v1672 = 2147483647;
        v1671 = (0);
        for (; v1671 < (ArrayItems.Length); v1671++)
        {
            v1673 = (ArrayItems[v1671]);
            v1674 = (v1673 > 10 ? (int? )null : v1673 + 2);
            if ((v1674 == null) || v1674 >= v1672)
                continue;
            v1672 = (int)v1674;
        }

        return v1672;
    }

    float? Min7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1676;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        float v1677;
        int v1678;
        float? v1679;
        v1677 = 3.4028235E+38F;
        v1676 = (0);
        for (; v1676 < (ArrayItems.Length); v1676++)
        {
            v1678 = (ArrayItems[v1676]);
            v1679 = (v1678 > 10 ? (float? )null : v1678 + 2);
            if ((v1679 == null) || v1679 >= v1677)
                continue;
            v1677 = (float)v1679;
        }

        return v1677;
    }

    double? Min8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1681;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        double v1682;
        int v1683;
        double? v1684;
        v1682 = 1.7976931348623157E+308;
        v1681 = (0);
        for (; v1681 < (ArrayItems.Length); v1681++)
        {
            v1683 = (ArrayItems[v1681]);
            v1684 = (v1683 > 10 ? (double? )null : v1683 + 2);
            if ((v1684 == null) || v1684 >= v1682)
                continue;
            v1682 = (double)v1684;
        }

        return v1682;
    }

    decimal? Min9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1686;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        decimal v1687;
        int v1688;
        decimal? v1689;
        v1687 = 79228162514264337593543950335M;
        v1686 = (0);
        for (; v1686 < (ArrayItems.Length); v1686++)
        {
            v1688 = (ArrayItems[v1686]);
            v1689 = (v1688 > 10 ? (decimal? )null : v1688 + 2);
            if ((v1689 == null) || v1689 >= v1687)
                continue;
            v1687 = (decimal)v1689;
        }

        return v1687;
    }

    long Min10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1691;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        long v1692;
        long v1693;
        v1692 = 9223372036854775807L;
        v1691 = (0);
        for (; v1691 < (ArrayItems.Length); v1691++)
        {
            v1693 = ((ArrayItems[v1691]) + 2L);
            if (v1693 >= v1692)
                continue;
            v1692 = v1693;
        }

        return v1692;
    }

    long? Min11Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1695;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        long v1696;
        int v1697;
        long? v1698;
        v1696 = 9223372036854775807L;
        v1695 = (0);
        for (; v1695 < (ArrayItems.Length); v1695++)
        {
            v1697 = (ArrayItems[v1695]);
            v1698 = (v1697 > 10 ? (long? )null : v1697 + 2);
            if ((v1698 == null) || v1698 >= v1696)
                continue;
            v1696 = (long)v1698;
        }

        return v1696;
    }

    int Min12Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1700;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1701;
        int v1702;
        v1701 = 2147483647;
        v1700 = (0);
        for (; v1700 < (ArrayItems.Length); v1700++)
        {
            v1702 = Selector((ArrayItems[v1700]));
            if (v1702 >= v1701)
                continue;
            v1701 = v1702;
        }

        return v1701;
    }

    int MinParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1704;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1705;
        int v1706;
        v1705 = 2147483647;
        v1704 = (0);
        for (; v1704 < (ArrayItems.Length); v1704++)
        {
            v1706 = ((ArrayItems[v1704]) + a);
            if (v1706 >= v1705)
                continue;
            v1705 = v1706;
        }

        return v1705;
    }

    int MinChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1707;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1708;
        int v1709;
        v1708 = 2147483647;
        v1707 = (0);
        for (; v1707 < (ArrayItems.Length); v1707++)
        {
            v1709 = ((ArrayItems[v1707]) + a++);
            if (v1709 >= v1708)
                continue;
            v1708 = v1709;
        }

        return v1708;
    }

    int MinChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1710;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1711;
        int v1712;
        v1711 = 2147483647;
        v1710 = (0);
        for (; v1710 < (ArrayItems.Length); v1710++)
        {
            v1712 = ((ArrayItems[v1710]) + a--);
            if (v1712 >= v1711)
                continue;
            v1711 = v1712;
        }

        return v1711;
    }

    int SelectMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1714;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1715;
        int v1716;
        v1715 = 2147483647;
        v1714 = (0);
        for (; v1714 < (ArrayItems.Length); v1714++)
        {
            v1716 = (3 + ArrayItems[v1714]);
            if (v1716 >= v1715)
                continue;
            v1715 = v1716;
        }

        return v1715;
    }

    int EmptyMinRewritten_ProceduralLinq1()
    {
        int v1717;
        throw new System.InvalidOperationException("Index out of range");
        v1717 = 0;
    }

    int EmptyMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1718;
        int v1719;
        int v1720;
        int v1721;
        v1720 = 0;
        v1721 = 2147483647;
        v1718 = (0);
        for (; v1718 < (ArrayItems.Length); v1718++)
        {
            v1719 = (ArrayItems[v1718]);
            if (!((false)))
                continue;
            v1719 = (v1719);
            if (v1719 >= v1721)
                continue;
            v1721 = v1719;
            v1720++;
        }

        if (1 > v1720)
            throw new System.InvalidOperationException("Index out of range");
        return v1721;
    }

    int EnumerableMinRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1722;
        int v1723;
        int v1724;
        int v1725;
        v1722 = EnumerableItems.GetEnumerator();
        v1723 = 0;
        v1724 = 2147483647;
        try
        {
            while (v1722.MoveNext())
            {
                v1725 = (v1722.Current);
                if (v1725 >= v1724)
                    continue;
                v1724 = v1725;
                v1723++;
            }
        }
        finally
        {
            v1722.Dispose();
        }

        if (1 > v1723)
            throw new System.InvalidOperationException("Index out of range");
        return v1724;
    }
}}