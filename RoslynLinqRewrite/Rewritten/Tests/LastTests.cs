using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class LastTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(Last), Last, LastRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableLast), EnumerableLast, EnumerableLastRewritten);
        TestsExtensions.TestEquals(nameof(LastCondition), LastCondition, LastConditionRewritten);
        TestsExtensions.TestEquals(nameof(LastFalseCondition), LastFalseCondition, LastFalseConditionRewritten);
        TestsExtensions.TestEquals(nameof(LastMethod), LastMethod, LastMethodRewritten);
        TestsExtensions.TestEquals(nameof(LastWhereMethod), LastWhereMethod, LastWhereMethodRewritten);
        TestsExtensions.TestEquals(nameof(SelectLastMethod), SelectLastMethod, SelectLastMethodRewritten);
        TestsExtensions.TestEquals(nameof(RangeLast), RangeLast, RangeLastRewritten);
        TestsExtensions.TestEquals(nameof(Range1Last), Range1Last, Range1LastRewritten);
        TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
        TestsExtensions.TestEquals(nameof(EmptyLast), EmptyLast, EmptyLastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctLast), ArrayDistinctLast, ArrayDistinctLastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastParam), ArrayLastParam, ArrayLastParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastChangingParam), ArrayLastChangingParam, ArrayLastChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastUsingLast), ArrayLastUsingLast, ArrayLastUsingLastRewritten);
    }

    [NoRewrite]
    public int Last()
    {
        return ArrayItems.Last();
    } //EndMethod

    public int LastRewritten()
    {
        return ArrayItems[-1 + ArrayItems.Length];
    } //EndMethod

    [NoRewrite]
    public int EnumerableLast()
    {
        return EnumerableItems.Last();
    } //EndMethod

    public int EnumerableLastRewritten()
    {
        return EnumerableLastRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int LastCondition()
    {
        return ArrayItems.Last(x => x > 30);
    } //EndMethod

    public int LastConditionRewritten()
    {
        return LastConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastFalseCondition()
    {
        return ArrayItems.Last(x => x > 105);
    } //EndMethod

    public int LastFalseConditionRewritten()
    {
        return LastFalseConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastMethod()
    {
        return ArrayItems.Last(Predicate);
    } //EndMethod

    public int LastMethodRewritten()
    {
        return LastMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastWhereMethod()
    {
        return ArrayItems.Where(x => x > 10).Last();
    } //EndMethod

    public int LastWhereMethodRewritten()
    {
        return LastWhereMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SelectLastMethod()
    {
        return ArrayItems.Select(x => x + 10).Last();
    } //EndMethod

    public int SelectLastMethodRewritten()
    {
        return 10 + ArrayItems[-1 + ArrayItems.Length];
    } //EndMethod

    [NoRewrite]
    public int RangeLast()
    {
        return Enumerable.Range(0, 100).Last();
    } //EndMethod

    public int RangeLastRewritten()
    {
        return RangeLastRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int Range1Last()
    {
        return Enumerable.Range(0, 1).Last();
    } //EndMethod

    public int Range1LastRewritten()
    {
        return Range1LastRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RangeRepeat()
    {
        return Enumerable.Repeat(0, 100).Last();
    } //EndMethod

    public int RangeRepeatRewritten()
    {
        return RangeRepeatRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int EmptyLast()
    {
        return Enumerable.Empty<int>().Last();
    } //EndMethod

    public int EmptyLastRewritten()
    {
        return EmptyLastRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int ArrayDistinctLast()
    {
        return ArrayItems.Distinct().Last();
    } //EndMethod

    public int ArrayDistinctLastRewritten()
    {
        return ArrayDistinctLastRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastParam()
    {
        var a = 50;
        return ArrayItems.Last(x => x > a);
    } //EndMethod

    public int ArrayLastParamRewritten()
    {
        var a = 50;
        return ArrayLastParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastChangingParam()
    {
        var a = 100;
        return ArrayItems.Last(x => x > a--);
    } //EndMethod

    public int ArrayLastChangingParamRewritten()
    {
        var a = 100;
        return ArrayLastChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastUsingLast()
    {
        var a = 100;
        return ArrayItems.Last(x => x > ArrayItems.Last(y => y > x));
    } //EndMethod

    public int ArrayLastUsingLastRewritten()
    {
        var a = 100;
        return ArrayLastUsingLastRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int EnumerableLastRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1499;
        int v1500;
        int? v1501;
        v1499 = EnumerableItems.GetEnumerator();
        v1500 = 0;
        v1501 = null;
        try
        {
            while (v1499.MoveNext())
            {
                v1501 = (v1499.Current);
                v1500++;
            }
        }
        finally
        {
            v1499.Dispose();
        }

        if (v1501 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1501;
    }

    int LastConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1503;
        int? v1504;
        v1504 = null;
        v1503 = (0);
        for (; v1503 < (ArrayItems.Length); v1503++)
            if (((ArrayItems[v1503]) > 30))
                v1504 = (ArrayItems[v1503]);
        if (v1504 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1504;
    }

    int LastFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1506;
        int? v1507;
        v1507 = null;
        v1506 = (0);
        for (; v1506 < (ArrayItems.Length); v1506++)
            if (((ArrayItems[v1506]) > 105))
                v1507 = (ArrayItems[v1506]);
        if (v1507 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1507;
    }

    int LastMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1509;
        int? v1510;
        v1510 = null;
        v1509 = (0);
        for (; v1509 < (ArrayItems.Length); v1509++)
            if (Predicate((ArrayItems[v1509])))
                v1510 = (ArrayItems[v1509]);
        if (v1510 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1510;
    }

    int LastWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1511;
        int v1512;
        int v1513;
        int? v1514;
        v1513 = 0;
        v1514 = null;
        v1511 = (0);
        for (; v1511 < (ArrayItems.Length); v1511++)
        {
            v1512 = (ArrayItems[v1511]);
            if (!(((v1512) > 10)))
                continue;
            v1514 = (v1512);
            v1513++;
        }

        if (v1514 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1514;
    }

    int RangeLastRewritten_ProceduralLinq1()
    {
        int v1516;
        int? v1517;
        v1517 = null;
        v1516 = (0);
        for (; v1516 < (100); v1516++)
            v1517 = (v1516);
        if (v1517 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1517;
    }

    int Range1LastRewritten_ProceduralLinq1()
    {
        int v1518;
        int? v1519;
        v1519 = null;
        v1518 = (0);
        for (; v1518 < (1); v1518++)
            v1519 = (v1518);
        if (v1519 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1519;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1520;
        int? v1521;
        v1521 = null;
        v1520 = (0);
        for (; v1520 < (100); v1520++)
            v1521 = (0);
        if (v1521 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1521;
    }

    int EmptyLastRewritten_ProceduralLinq1()
    {
        int v1522;
        int? v1523;
        v1522 = 0;
        v1523 = null;
        if (v1523 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1523;
    }

    int ArrayDistinctLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1524;
        HashSet<int> v1525;
        int v1526;
        int v1527;
        int? v1528;
        v1525 = new HashSet<int>();
        v1527 = 0;
        v1528 = null;
        v1524 = (0);
        for (; v1524 < (ArrayItems.Length); v1524++)
        {
            v1526 = (ArrayItems[v1524]);
            if (!(v1525.Add((v1526))))
                continue;
            v1528 = (v1526);
            v1527++;
        }

        if (v1528 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1528;
    }

    int ArrayLastParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1530;
        int? v1531;
        v1531 = null;
        v1530 = (0);
        for (; v1530 < (ArrayItems.Length); v1530++)
            if (((ArrayItems[v1530]) > a))
                v1531 = (ArrayItems[v1530]);
        if (v1531 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1531;
    }

    int ArrayLastChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1532;
        int? v1533;
        v1533 = null;
        v1532 = (0);
        for (; v1532 < (ArrayItems.Length); v1532++)
            if (((ArrayItems[v1532]) > a--))
                v1533 = (ArrayItems[v1532]);
        if (v1533 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1533;
    }

    int ArrayLastUsingLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1535;
        int? v1536;
        int v1537;
        v1536 = null;
        v1535 = (0);
        for (; v1535 < (ArrayItems.Length); v1535++)
        {
            v1537 = (ArrayItems[v1535]);
            if ((v1537 > ArrayItems.Last(y => y > v1537)))
                v1536 = (ArrayItems[v1535]);
        }

        if (v1536 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1536;
    }
}}