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
        int v1408;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1409;
        v1409 = -2147483648;
        v1408 = (0);
        for (; v1408 < (ArrayItems.Length); v1408 += 1)
        {
            if ((ArrayItems[v1408]) <= v1409)
                continue;
            v1409 = (ArrayItems[v1408]);
        }

        return v1409;
    }

    int Max2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1411;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1412;
        int v1413;
        v1412 = -2147483648;
        v1411 = (0);
        for (; v1411 < (ArrayItems.Length); v1411 += 1)
        {
            v1413 = ((ArrayItems[v1411]) + 2);
            if (v1413 <= v1412)
                continue;
            v1412 = v1413;
        }

        return v1412;
    }

    float Max3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1415;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        float v1416;
        float v1417;
        v1416 = -3.4028235E+38F;
        v1415 = (0);
        for (; v1415 < (ArrayItems.Length); v1415 += 1)
        {
            v1417 = ((ArrayItems[v1415]) + 2f);
            if (v1417 <= v1416)
                continue;
            v1416 = v1417;
        }

        return v1416;
    }

    double Max4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1419;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        double v1420;
        double v1421;
        v1420 = -1.7976931348623157E+308;
        v1419 = (0);
        for (; v1419 < (ArrayItems.Length); v1419 += 1)
        {
            v1421 = ((ArrayItems[v1419]) + 2d);
            if (v1421 <= v1420)
                continue;
            v1420 = v1421;
        }

        return v1420;
    }

    decimal Max5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1423;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        decimal v1424;
        decimal v1425;
        v1424 = -79228162514264337593543950335M;
        v1423 = (0);
        for (; v1423 < (ArrayItems.Length); v1423 += 1)
        {
            v1425 = ((ArrayItems[v1423]) + 2m);
            if (v1425 <= v1424)
                continue;
            v1424 = v1425;
        }

        return v1424;
    }

    int? Max6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1427;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1428;
        int? v1429;
        v1428 = -2147483648;
        v1427 = (0);
        for (; v1427 < (ArrayItems.Length); v1427 += 1)
        {
            v1429 = ((ArrayItems[v1427]) > 10 ? (int? )null : (ArrayItems[v1427]) + 2);
            if ((v1429 == null) || v1429 <= v1428)
                continue;
            v1428 = (int)v1429;
        }

        return v1428;
    }

    float? Max7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1431;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        float v1432;
        float? v1433;
        v1432 = -3.4028235E+38F;
        v1431 = (0);
        for (; v1431 < (ArrayItems.Length); v1431 += 1)
        {
            v1433 = ((ArrayItems[v1431]) > 10 ? (float? )null : (ArrayItems[v1431]) + 2);
            if ((v1433 == null) || v1433 <= v1432)
                continue;
            v1432 = (float)v1433;
        }

        return v1432;
    }

    double? Max8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1435;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        double v1436;
        double? v1437;
        v1436 = -1.7976931348623157E+308;
        v1435 = (0);
        for (; v1435 < (ArrayItems.Length); v1435 += 1)
        {
            v1437 = ((ArrayItems[v1435]) > 10 ? (double? )null : (ArrayItems[v1435]) + 2);
            if ((v1437 == null) || v1437 <= v1436)
                continue;
            v1436 = (double)v1437;
        }

        return v1436;
    }

    decimal? Max9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1439;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        decimal v1440;
        decimal? v1441;
        v1440 = -79228162514264337593543950335M;
        v1439 = (0);
        for (; v1439 < (ArrayItems.Length); v1439 += 1)
        {
            v1441 = ((ArrayItems[v1439]) > 10 ? (decimal? )null : (ArrayItems[v1439]) + 2);
            if ((v1441 == null) || v1441 <= v1440)
                continue;
            v1440 = (decimal)v1441;
        }

        return v1440;
    }

    long Max10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1443;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        long v1444;
        long v1445;
        v1444 = -9223372036854775808L;
        v1443 = (0);
        for (; v1443 < (ArrayItems.Length); v1443 += 1)
        {
            v1445 = ((ArrayItems[v1443]) + 2L);
            if (v1445 <= v1444)
                continue;
            v1444 = v1445;
        }

        return v1444;
    }

    long? Max11Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1447;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        long v1448;
        long? v1449;
        v1448 = -9223372036854775808L;
        v1447 = (0);
        for (; v1447 < (ArrayItems.Length); v1447 += 1)
        {
            v1449 = ((ArrayItems[v1447]) > 10 ? (long? )null : (ArrayItems[v1447]) + 2);
            if ((v1449 == null) || v1449 <= v1448)
                continue;
            v1448 = (long)v1449;
        }

        return v1448;
    }

    int Max12Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1451;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1452;
        int v1453;
        v1452 = -2147483648;
        v1451 = (0);
        for (; v1451 < (ArrayItems.Length); v1451 += 1)
        {
            v1453 = Selector((ArrayItems[v1451]));
            if (v1453 <= v1452)
                continue;
            v1452 = v1453;
        }

        return v1452;
    }

    int MaxParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1455;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1456;
        int v1457;
        v1456 = -2147483648;
        v1455 = (0);
        for (; v1455 < (ArrayItems.Length); v1455 += 1)
        {
            v1457 = ((ArrayItems[v1455]) + a);
            if (v1457 <= v1456)
                continue;
            v1456 = v1457;
        }

        return v1456;
    }

    int MaxChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1458;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1459;
        int v1460;
        v1459 = -2147483648;
        v1458 = (0);
        for (; v1458 < (ArrayItems.Length); v1458 += 1)
        {
            v1460 = ((ArrayItems[v1458]) + a++);
            if (v1460 <= v1459)
                continue;
            v1459 = v1460;
        }

        return v1459;
    }

    int MaxChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1461;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1462;
        int v1463;
        v1462 = -2147483648;
        v1461 = (0);
        for (; v1461 < (ArrayItems.Length); v1461 += 1)
        {
            v1463 = ((ArrayItems[v1461]) + a--);
            if (v1463 <= v1462)
                continue;
            v1462 = v1463;
        }

        return v1462;
    }

    int SelectMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1465;
        if (1 > (ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v1466;
        int v1467;
        v1466 = -2147483648;
        v1465 = (0);
        for (; v1465 < (ArrayItems.Length); v1465 += 1)
        {
            v1467 = (3 + ArrayItems[v1465]);
            if (v1467 <= v1466)
                continue;
            v1466 = v1467;
        }

        return v1466;
    }

    int EmptyMaxRewritten_ProceduralLinq1()
    {
        int v1468;
        if (1 > (0))
            throw new System.InvalidOperationException("Index out of range");
        int v1469;
        v1468 = 0;
        v1469 = -2147483648;
        return v1469;
    }

    int EmptyMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1470;
        int v1471;
        int v1472;
        v1471 = 0;
        v1472 = -2147483648;
        v1470 = (0);
        for (; v1470 < (ArrayItems.Length); v1470 += 1)
        {
            if (!((false)))
                continue;
            if (((ArrayItems[v1470])) <= v1472)
                continue;
            v1472 = ((ArrayItems[v1470]));
            v1471++;
        }

        if (1 > v1471)
            throw new System.InvalidOperationException("Index out of range");
        return v1472;
    }

    int EnumerableMaxRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1473;
        int v1474;
        int v1475;
        int v1476;
        v1473 = EnumerableItems.GetEnumerator();
        v1474 = 0;
        v1475 = -2147483648;
        try
        {
            while (v1473.MoveNext())
            {
                v1476 = (v1473.Current);
                if (v1476 <= v1475)
                    continue;
                v1475 = v1476;
                v1474++;
            }
        }
        finally
        {
            v1473.Dispose();
        }

        if (1 > v1474)
            throw new System.InvalidOperationException("Index out of range");
        return v1475;
    }
}}