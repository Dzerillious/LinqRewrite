using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class MaxTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private int Selector(int value) => value + 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(Max1), Max1, Max1Rewritten);
        TestsExtensions.TestEquals(nameof(Max2), Max2, Max2Rewritten);
        TestsExtensions.TestEquals(nameof(Max3), Max3, Max3Rewritten);
        TestsExtensions.TestEquals(nameof(Max4), Max4, Max4Rewritten);
        TestsExtensions.TestEquals(nameof(Max5), Max5, Max5Rewritten);
        TestsExtensions.TestEquals(nameof(Max6), Max6, Max6Rewritten);
        TestsExtensions.TestEquals(nameof(Max7), Max7, Max7Rewritten);
        TestsExtensions.TestEquals(nameof(Max8), Max8, Max8Rewritten);
        TestsExtensions.TestEquals(nameof(Max9), Max9, Max9Rewritten);
        TestsExtensions.TestEquals(nameof(Max10), Max10, Max10Rewritten);
        TestsExtensions.TestEquals(nameof(Max11), Max11, Max11Rewritten);
        TestsExtensions.TestEquals(nameof(Max12), Max12, Max12Rewritten);
        TestsExtensions.TestEquals(nameof(MaxParam), MaxParam, MaxParamRewritten);
        TestsExtensions.TestEquals(nameof(MaxChangingParam), MaxChangingParam, MaxChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(MaxChangingParam2), MaxChangingParam2, MaxChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectMax), SelectMax, SelectMaxRewritten);
        TestsExtensions.TestEquals(nameof(EmptyMax), EmptyMax, EmptyMaxRewritten);
        TestsExtensions.TestEquals(nameof(EmptyMax2), EmptyMax2, EmptyMax2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableMax), EnumerableMax, EnumerableMaxRewritten);
    }

    [NoRewrite]
    public int Max1()
    {
        return ArrayItems.Max();
    } //EndMethod

    public int Max1Rewritten()
    {
        return Max1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int Max2()
    {
        return ArrayItems.Max(x => x + 2);
    } //EndMethod

    public int Max2Rewritten()
    {
        return Max2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public float Max3()
    {
        return ArrayItems.Max(x => x + 2f);
    } //EndMethod

    public float Max3Rewritten()
    {
        return Max3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double Max4()
    {
        return ArrayItems.Max(x => x + 2d);
    } //EndMethod

    public double Max4Rewritten()
    {
        return Max4Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal Max5()
    {
        return ArrayItems.Max(x => x + 2m);
    } //EndMethod

    public decimal Max5Rewritten()
    {
        return Max5Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? Max6()
    {
        return ArrayItems.Max(x => x > 10 ? (int? )null : x + 2);
    } //EndMethod

    public int? Max6Rewritten()
    {
        return Max6Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public float? Max7()
    {
        return ArrayItems.Max(x => x > 10 ? (float? )null : x + 2);
    } //EndMethod

    public float? Max7Rewritten()
    {
        return Max7Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? Max8()
    {
        return ArrayItems.Max(x => x > 10 ? (double? )null : x + 2);
    } //EndMethod

    public double? Max8Rewritten()
    {
        return Max8Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal? Max9()
    {
        return ArrayItems.Max(x => x > 10 ? (decimal? )null : x + 2);
    } //EndMethod

    public decimal? Max9Rewritten()
    {
        return Max9Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long Max10()
    {
        return ArrayItems.Max(x => x + 2L);
    } //EndMethod

    public long Max10Rewritten()
    {
        return Max10Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long? Max11()
    {
        return ArrayItems.Max(x => x > 10 ? (long? )null : x + 2);
    } //EndMethod

    public long? Max11Rewritten()
    {
        return Max11Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? Max12()
    {
        return ArrayItems.Max(Selector);
    } //EndMethod

    public int? Max12Rewritten()
    {
        return Max12Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MaxParam()
    {
        var a = 10;
        return ArrayItems.Max(x => x + a);
    } //EndMethod

    public int? MaxParamRewritten()
    {
        var a = 10;
        return MaxParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MaxChangingParam()
    {
        var a = 10;
        return ArrayItems.Max(x => x + a++);
    } //EndMethod

    public int? MaxChangingParamRewritten()
    {
        var a = 10;
        return MaxChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MaxChangingParam2()
    {
        var a = 10;
        return ArrayItems.Max(x => x + a--);
    } //EndMethod

    public int? MaxChangingParam2Rewritten()
    {
        var a = 10;
        return MaxChangingParam2Rewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? SelectMax()
    {
        var a = 10;
        return ArrayItems.Select(x => x + 3).Max();
    } //EndMethod

    public int? SelectMaxRewritten()
    {
        var a = 10;
        return SelectMaxRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? EmptyMax()
    {
        return Enumerable.Empty<int>().Max();
    } //EndMethod

    public int? EmptyMaxRewritten()
    {
        return EmptyMaxRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int? EmptyMax2()
    {
        return ArrayItems.Where(x => false).Max();
    } //EndMethod

    public int? EmptyMax2Rewritten()
    {
        return EmptyMax2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? EnumerableMax()
    {
        return EnumerableItems.Max();
    } //EndMethod

    public int? EnumerableMaxRewritten()
    {
        return EnumerableMaxRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    int Max1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1575;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1576;
        int v1577;
        v1576 = -2147483648;
        v1575 = (0);
        for (; v1575 < (ArrayItems.Length); v1575++)
        {
            v1577 = (ArrayItems[v1575]);
            if (v1577 <= v1576)
                continue;
            v1576 = v1577;
        }

        return v1576;
    }

    int Max2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1579;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1580;
        int v1581;
        v1580 = -2147483648;
        v1579 = (0);
        for (; v1579 < (ArrayItems.Length); v1579++)
        {
            v1581 = ((ArrayItems[v1579]) + 2);
            if (v1581 <= v1580)
                continue;
            v1580 = v1581;
        }

        return v1580;
    }

    float Max3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1583;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        float v1584;
        float v1585;
        v1584 = -3.4028235E+38F;
        v1583 = (0);
        for (; v1583 < (ArrayItems.Length); v1583++)
        {
            v1585 = ((ArrayItems[v1583]) + 2f);
            if (v1585 <= v1584)
                continue;
            v1584 = v1585;
        }

        return v1584;
    }

    double Max4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1587;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        double v1588;
        double v1589;
        v1588 = -1.7976931348623157E+308;
        v1587 = (0);
        for (; v1587 < (ArrayItems.Length); v1587++)
        {
            v1589 = ((ArrayItems[v1587]) + 2d);
            if (v1589 <= v1588)
                continue;
            v1588 = v1589;
        }

        return v1588;
    }

    decimal Max5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1591;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        decimal v1592;
        decimal v1593;
        v1592 = -79228162514264337593543950335M;
        v1591 = (0);
        for (; v1591 < (ArrayItems.Length); v1591++)
        {
            v1593 = ((ArrayItems[v1591]) + 2m);
            if (v1593 <= v1592)
                continue;
            v1592 = v1593;
        }

        return v1592;
    }

    int? Max6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1595;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1596;
        int v1597;
        int? v1598;
        v1596 = -2147483648;
        v1595 = (0);
        for (; v1595 < (ArrayItems.Length); v1595++)
        {
            v1597 = (ArrayItems[v1595]);
            v1598 = (v1597 > 10 ? (int? )null : v1597 + 2);
            if ((v1598 == null) || v1598 <= v1596)
                continue;
            v1596 = (int)v1598;
        }

        return v1596;
    }

    float? Max7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1600;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        float v1601;
        int v1602;
        float? v1603;
        v1601 = -3.4028235E+38F;
        v1600 = (0);
        for (; v1600 < (ArrayItems.Length); v1600++)
        {
            v1602 = (ArrayItems[v1600]);
            v1603 = (v1602 > 10 ? (float? )null : v1602 + 2);
            if ((v1603 == null) || v1603 <= v1601)
                continue;
            v1601 = (float)v1603;
        }

        return v1601;
    }

    double? Max8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1605;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        double v1606;
        int v1607;
        double? v1608;
        v1606 = -1.7976931348623157E+308;
        v1605 = (0);
        for (; v1605 < (ArrayItems.Length); v1605++)
        {
            v1607 = (ArrayItems[v1605]);
            v1608 = (v1607 > 10 ? (double? )null : v1607 + 2);
            if ((v1608 == null) || v1608 <= v1606)
                continue;
            v1606 = (double)v1608;
        }

        return v1606;
    }

    decimal? Max9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1610;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        decimal v1611;
        int v1612;
        decimal? v1613;
        v1611 = -79228162514264337593543950335M;
        v1610 = (0);
        for (; v1610 < (ArrayItems.Length); v1610++)
        {
            v1612 = (ArrayItems[v1610]);
            v1613 = (v1612 > 10 ? (decimal? )null : v1612 + 2);
            if ((v1613 == null) || v1613 <= v1611)
                continue;
            v1611 = (decimal)v1613;
        }

        return v1611;
    }

    long Max10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1615;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        long v1616;
        long v1617;
        v1616 = -9223372036854775808L;
        v1615 = (0);
        for (; v1615 < (ArrayItems.Length); v1615++)
        {
            v1617 = ((ArrayItems[v1615]) + 2L);
            if (v1617 <= v1616)
                continue;
            v1616 = v1617;
        }

        return v1616;
    }

    long? Max11Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1619;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        long v1620;
        int v1621;
        long? v1622;
        v1620 = -9223372036854775808L;
        v1619 = (0);
        for (; v1619 < (ArrayItems.Length); v1619++)
        {
            v1621 = (ArrayItems[v1619]);
            v1622 = (v1621 > 10 ? (long? )null : v1621 + 2);
            if ((v1622 == null) || v1622 <= v1620)
                continue;
            v1620 = (long)v1622;
        }

        return v1620;
    }

    int Max12Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1624;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1625;
        int v1626;
        v1625 = -2147483648;
        v1624 = (0);
        for (; v1624 < (ArrayItems.Length); v1624++)
        {
            v1626 = Selector((ArrayItems[v1624]));
            if (v1626 <= v1625)
                continue;
            v1625 = v1626;
        }

        return v1625;
    }

    int MaxParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1628;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1629;
        int v1630;
        v1629 = -2147483648;
        v1628 = (0);
        for (; v1628 < (ArrayItems.Length); v1628++)
        {
            v1630 = ((ArrayItems[v1628]) + a);
            if (v1630 <= v1629)
                continue;
            v1629 = v1630;
        }

        return v1629;
    }

    int MaxChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1631;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1632;
        int v1633;
        v1632 = -2147483648;
        v1631 = (0);
        for (; v1631 < (ArrayItems.Length); v1631++)
        {
            v1633 = ((ArrayItems[v1631]) + a++);
            if (v1633 <= v1632)
                continue;
            v1632 = v1633;
        }

        return v1632;
    }

    int MaxChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1634;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1635;
        int v1636;
        v1635 = -2147483648;
        v1634 = (0);
        for (; v1634 < (ArrayItems.Length); v1634++)
        {
            v1636 = ((ArrayItems[v1634]) + a--);
            if (v1636 <= v1635)
                continue;
            v1635 = v1636;
        }

        return v1635;
    }

    int SelectMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1638;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1639;
        int v1640;
        v1639 = -2147483648;
        v1638 = (0);
        for (; v1638 < (ArrayItems.Length); v1638++)
        {
            v1640 = (3 + ArrayItems[v1638]);
            if (v1640 <= v1639)
                continue;
            v1639 = v1640;
        }

        return v1639;
    }

    int EmptyMaxRewritten_ProceduralLinq1()
    {
        int v1641;
        throw new System.InvalidOperationException("Index out of range");
        v1641 = 0;
    }

    int EmptyMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1642;
        int v1643;
        int v1644;
        int v1645;
        v1644 = 0;
        v1645 = -2147483648;
        v1642 = (0);
        for (; v1642 < (ArrayItems.Length); v1642++)
        {
            v1643 = (ArrayItems[v1642]);
            if (!((false)))
                continue;
            v1643 = (v1643);
            if (v1643 <= v1645)
                continue;
            v1645 = v1643;
            v1644++;
        }

        if (1 > v1644)
            throw new System.InvalidOperationException("Index out of range");
        return v1645;
    }

    int EnumerableMaxRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1646;
        int v1647;
        int v1648;
        int v1649;
        v1646 = EnumerableItems.GetEnumerator();
        v1647 = 0;
        v1648 = -2147483648;
        try
        {
            while (v1646.MoveNext())
            {
                v1649 = (v1646.Current);
                if (v1649 <= v1648)
                    continue;
                v1648 = v1649;
                v1647++;
            }
        }
        finally
        {
            v1646.Dispose();
        }

        if (1 > v1647)
            throw new System.InvalidOperationException("Index out of range");
        return v1648;
    }
}}