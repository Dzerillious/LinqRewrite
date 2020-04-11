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
        int v1478;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1479;
        v1479 = 2147483647;
        v1478 = (0);
        for (; v1478 < (ArrayItems.Length); v1478 += 1)
        {
            if ((ArrayItems[v1478]) >= v1479)
                continue;
            v1479 = (ArrayItems[v1478]);
        }

        return v1479;
    }

    int Min2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1481;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1482;
        int v1483;
        v1482 = 2147483647;
        v1481 = (0);
        for (; v1481 < (ArrayItems.Length); v1481 += 1)
        {
            v1483 = ((ArrayItems[v1481]) + 2);
            if (v1483 >= v1482)
                continue;
            v1482 = v1483;
        }

        return v1482;
    }

    float Min3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1485;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        float v1486;
        float v1487;
        v1486 = 3.4028235E+38F;
        v1485 = (0);
        for (; v1485 < (ArrayItems.Length); v1485 += 1)
        {
            v1487 = ((ArrayItems[v1485]) + 2f);
            if (v1487 >= v1486)
                continue;
            v1486 = v1487;
        }

        return v1486;
    }

    double Min4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1489;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        double v1490;
        double v1491;
        v1490 = 1.7976931348623157E+308;
        v1489 = (0);
        for (; v1489 < (ArrayItems.Length); v1489 += 1)
        {
            v1491 = ((ArrayItems[v1489]) + 2d);
            if (v1491 >= v1490)
                continue;
            v1490 = v1491;
        }

        return v1490;
    }

    decimal Min5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1493;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        decimal v1494;
        decimal v1495;
        v1494 = 79228162514264337593543950335M;
        v1493 = (0);
        for (; v1493 < (ArrayItems.Length); v1493 += 1)
        {
            v1495 = ((ArrayItems[v1493]) + 2m);
            if (v1495 >= v1494)
                continue;
            v1494 = v1495;
        }

        return v1494;
    }

    int? Min6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1497;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1498;
        int? v1499;
        v1498 = 2147483647;
        v1497 = (0);
        for (; v1497 < (ArrayItems.Length); v1497 += 1)
        {
            v1499 = ((ArrayItems[v1497]) > 10 ? (int? )null : (ArrayItems[v1497]) + 2);
            if ((v1499 == null) || v1499 >= v1498)
                continue;
            v1498 = (int)v1499;
        }

        return v1498;
    }

    float? Min7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1501;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        float v1502;
        float? v1503;
        v1502 = 3.4028235E+38F;
        v1501 = (0);
        for (; v1501 < (ArrayItems.Length); v1501 += 1)
        {
            v1503 = ((ArrayItems[v1501]) > 10 ? (float? )null : (ArrayItems[v1501]) + 2);
            if ((v1503 == null) || v1503 >= v1502)
                continue;
            v1502 = (float)v1503;
        }

        return v1502;
    }

    double? Min8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1505;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        double v1506;
        double? v1507;
        v1506 = 1.7976931348623157E+308;
        v1505 = (0);
        for (; v1505 < (ArrayItems.Length); v1505 += 1)
        {
            v1507 = ((ArrayItems[v1505]) > 10 ? (double? )null : (ArrayItems[v1505]) + 2);
            if ((v1507 == null) || v1507 >= v1506)
                continue;
            v1506 = (double)v1507;
        }

        return v1506;
    }

    decimal? Min9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1509;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        decimal v1510;
        decimal? v1511;
        v1510 = 79228162514264337593543950335M;
        v1509 = (0);
        for (; v1509 < (ArrayItems.Length); v1509 += 1)
        {
            v1511 = ((ArrayItems[v1509]) > 10 ? (decimal? )null : (ArrayItems[v1509]) + 2);
            if ((v1511 == null) || v1511 >= v1510)
                continue;
            v1510 = (decimal)v1511;
        }

        return v1510;
    }

    long Min10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1513;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        long v1514;
        long v1515;
        v1514 = 9223372036854775807L;
        v1513 = (0);
        for (; v1513 < (ArrayItems.Length); v1513 += 1)
        {
            v1515 = ((ArrayItems[v1513]) + 2L);
            if (v1515 >= v1514)
                continue;
            v1514 = v1515;
        }

        return v1514;
    }

    long? Min11Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1517;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        long v1518;
        long? v1519;
        v1518 = 9223372036854775807L;
        v1517 = (0);
        for (; v1517 < (ArrayItems.Length); v1517 += 1)
        {
            v1519 = ((ArrayItems[v1517]) > 10 ? (long? )null : (ArrayItems[v1517]) + 2);
            if ((v1519 == null) || v1519 >= v1518)
                continue;
            v1518 = (long)v1519;
        }

        return v1518;
    }

    int Min12Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1521;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1522;
        int v1523;
        v1522 = 2147483647;
        v1521 = (0);
        for (; v1521 < (ArrayItems.Length); v1521 += 1)
        {
            v1523 = Selector((ArrayItems[v1521]));
            if (v1523 >= v1522)
                continue;
            v1522 = v1523;
        }

        return v1522;
    }

    int MinParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1525;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1526;
        int v1527;
        v1526 = 2147483647;
        v1525 = (0);
        for (; v1525 < (ArrayItems.Length); v1525 += 1)
        {
            v1527 = ((ArrayItems[v1525]) + a);
            if (v1527 >= v1526)
                continue;
            v1526 = v1527;
        }

        return v1526;
    }

    int MinChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1528;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1529;
        int v1530;
        v1529 = 2147483647;
        v1528 = (0);
        for (; v1528 < (ArrayItems.Length); v1528 += 1)
        {
            v1530 = ((ArrayItems[v1528]) + a++);
            if (v1530 >= v1529)
                continue;
            v1529 = v1530;
        }

        return v1529;
    }

    int MinChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1531;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1532;
        int v1533;
        v1532 = 2147483647;
        v1531 = (0);
        for (; v1531 < (ArrayItems.Length); v1531 += 1)
        {
            v1533 = ((ArrayItems[v1531]) + a--);
            if (v1533 >= v1532)
                continue;
            v1532 = v1533;
        }

        return v1532;
    }

    int SelectMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1535;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1536;
        int v1537;
        v1536 = 2147483647;
        v1535 = (0);
        for (; v1535 < (ArrayItems.Length); v1535 += 1)
        {
            v1537 = (3 + ArrayItems[v1535]);
            if (v1537 >= v1536)
                continue;
            v1536 = v1537;
        }

        return v1536;
    }

    int EmptyMinRewritten_ProceduralLinq1()
    {
        int v1538;
        if (1 > (0))
            throw new System.InvalidOperationException("Index out of range");
        int v1539;
        v1538 = 0;
        v1539 = 2147483647;
        return v1539;
    }

    int EmptyMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1540;
        int v1541;
        int v1542;
        v1541 = 0;
        v1542 = 2147483647;
        v1540 = (0);
        for (; v1540 < (ArrayItems.Length); v1540 += 1)
        {
            if (!((false)))
                continue;
            if (((ArrayItems[v1540])) >= v1542)
                continue;
            v1542 = ((ArrayItems[v1540]));
            v1541++;
        }

        if (1 > v1541)
            throw new System.InvalidOperationException("Index out of range");
        return v1542;
    }

    int EnumerableMinRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1543;
        int v1544;
        int v1545;
        int v1546;
        v1543 = EnumerableItems.GetEnumerator();
        v1544 = 0;
        v1545 = 2147483647;
        try
        {
            while (v1543.MoveNext())
            {
                v1546 = (v1543.Current);
                if (v1546 >= v1545)
                    continue;
                v1545 = v1546;
                v1544++;
            }
        }
        finally
        {
            v1543.Dispose();
        }

        if (1 > v1544)
            throw new System.InvalidOperationException("Index out of range");
        return v1545;
    }
}}