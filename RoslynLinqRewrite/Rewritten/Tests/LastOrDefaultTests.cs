using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class LastOrDefaultTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(LastOrDefault), LastOrDefault, LastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableLastOrDefault), EnumerableLastOrDefault, EnumerableLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(LastOrDefaultCondition), LastOrDefaultCondition, LastOrDefaultConditionRewritten);
        TestsExtensions.TestEquals(nameof(LastOrDefaultFalseCondition), LastOrDefaultFalseCondition, LastOrDefaultFalseConditionRewritten);
        TestsExtensions.TestEquals(nameof(LastOrDefaultMethod), LastOrDefaultMethod, LastOrDefaultMethodRewritten);
        TestsExtensions.TestEquals(nameof(LastOrDefaultWhereMethod), LastOrDefaultWhereMethod, LastOrDefaultWhereMethodRewritten);
        TestsExtensions.TestEquals(nameof(SelectLastOrDefaultMethod), SelectLastOrDefaultMethod, SelectLastOrDefaultMethodRewritten);
        TestsExtensions.TestEquals(nameof(RangeLastOrDefault), RangeLastOrDefault, RangeLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(Range1LastOrDefault), Range1LastOrDefault, Range1LastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
        TestsExtensions.TestEquals(nameof(EmptyLastOrDefault), EmptyLastOrDefault, EmptyLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctLastOrDefault), ArrayDistinctLastOrDefault, ArrayDistinctLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultParam), ArrayLastOrDefaultParam, ArrayLastOrDefaultParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultChangingParam), ArrayLastOrDefaultChangingParam, ArrayLastOrDefaultChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultUsingLastOrDefault), ArrayLastOrDefaultUsingLastOrDefault, ArrayLastOrDefaultUsingLastOrDefaultRewritten);
    }

    [NoRewrite]
    public int LastOrDefault()
    {
        return ArrayItems.LastOrDefault();
    } //EndMethod

    public int LastOrDefaultRewritten()
    {
        return (ArrayItems.Length) == 0 ? default(int) : ArrayItems[-1 + ArrayItems.Length];
    } //EndMethod

    [NoRewrite]
    public int EnumerableLastOrDefault()
    {
        return EnumerableItems.LastOrDefault();
    } //EndMethod

    public int EnumerableLastOrDefaultRewritten()
    {
        return EnumerableLastOrDefaultRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int LastOrDefaultCondition()
    {
        return ArrayItems.LastOrDefault(x => x > 30);
    } //EndMethod

    public int LastOrDefaultConditionRewritten()
    {
        return LastOrDefaultConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastOrDefaultFalseCondition()
    {
        return ArrayItems.LastOrDefault(x => x > 105);
    } //EndMethod

    public int LastOrDefaultFalseConditionRewritten()
    {
        return LastOrDefaultFalseConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastOrDefaultMethod()
    {
        return ArrayItems.LastOrDefault(Predicate);
    } //EndMethod

    public int LastOrDefaultMethodRewritten()
    {
        return LastOrDefaultMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastOrDefaultWhereMethod()
    {
        return ArrayItems.Where(x => x > 10).LastOrDefault();
    } //EndMethod

    public int LastOrDefaultWhereMethodRewritten()
    {
        return LastOrDefaultWhereMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SelectLastOrDefaultMethod()
    {
        return ArrayItems.Select(x => x + 10).LastOrDefault();
    } //EndMethod

    public int SelectLastOrDefaultMethodRewritten()
    {
        return (ArrayItems.Length) == 0 ? default(int) : 10 + ArrayItems[-1 + ArrayItems.Length];
    } //EndMethod

    [NoRewrite]
    public int RangeLastOrDefault()
    {
        return Enumerable.Range(0, 100).LastOrDefault();
    } //EndMethod

    public int RangeLastOrDefaultRewritten()
    {
        return RangeLastOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int Range1LastOrDefault()
    {
        return Enumerable.Range(0, 1).LastOrDefault();
    } //EndMethod

    public int Range1LastOrDefaultRewritten()
    {
        return Range1LastOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RangeRepeat()
    {
        return Enumerable.Repeat(0, 100).LastOrDefault();
    } //EndMethod

    public int RangeRepeatRewritten()
    {
        return RangeRepeatRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int EmptyLastOrDefault()
    {
        return Enumerable.Empty<int>().LastOrDefault();
    } //EndMethod

    public int EmptyLastOrDefaultRewritten()
    {
        return EmptyLastOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int ArrayDistinctLastOrDefault()
    {
        return ArrayItems.Distinct().LastOrDefault();
    } //EndMethod

    public int ArrayDistinctLastOrDefaultRewritten()
    {
        return ArrayDistinctLastOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastOrDefaultParam()
    {
        var a = 50;
        return ArrayItems.LastOrDefault(x => x > a);
    } //EndMethod

    public int ArrayLastOrDefaultParamRewritten()
    {
        var a = 50;
        return ArrayLastOrDefaultParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastOrDefaultChangingParam()
    {
        var a = 100;
        return ArrayItems.LastOrDefault(x => x > a--);
    } //EndMethod

    public int ArrayLastOrDefaultChangingParamRewritten()
    {
        var a = 100;
        return ArrayLastOrDefaultChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastOrDefaultUsingLastOrDefault()
    {
        var a = 100;
        return ArrayItems.LastOrDefault(x => x > ArrayItems.LastOrDefault(y => y > x));
    } //EndMethod

    public int ArrayLastOrDefaultUsingLastOrDefaultRewritten()
    {
        var a = 100;
        return ArrayLastOrDefaultUsingLastOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int EnumerableLastOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1462;
        int? v1463;
        v1462 = EnumerableItems.GetEnumerator();
        v1463 = null;
        try
        {
            while (v1462.MoveNext())
                v1463 = (v1462.Current);
        }
        finally
        {
            v1462.Dispose();
        }

        if (v1463 == null)
            return default(int);
        else
            return (int)v1463;
    }

    int LastOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1465;
        int? v1466;
        v1466 = null;
        v1465 = (0);
        for (; v1465 < (ArrayItems.Length); v1465++)
            if (((ArrayItems[v1465]) > 30))
                v1466 = (ArrayItems[v1465]);
        if (v1466 == null)
            return default(int);
        else
            return (int)v1466;
    }

    int LastOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1468;
        int? v1469;
        v1469 = null;
        v1468 = (0);
        for (; v1468 < (ArrayItems.Length); v1468++)
            if (((ArrayItems[v1468]) > 105))
                v1469 = (ArrayItems[v1468]);
        if (v1469 == null)
            return default(int);
        else
            return (int)v1469;
    }

    int LastOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1471;
        int? v1472;
        v1472 = null;
        v1471 = (0);
        for (; v1471 < (ArrayItems.Length); v1471++)
            if (Predicate((ArrayItems[v1471])))
                v1472 = (ArrayItems[v1471]);
        if (v1472 == null)
            return default(int);
        else
            return (int)v1472;
    }

    int LastOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1473;
        int v1474;
        int? v1475;
        v1475 = null;
        v1473 = (0);
        for (; v1473 < (ArrayItems.Length); v1473++)
        {
            v1474 = (ArrayItems[v1473]);
            if (!(((v1474) > 10)))
                continue;
            v1475 = (v1474);
        }

        if (v1475 == null)
            return default(int);
        else
            return (int)v1475;
    }

    int RangeLastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1477;
        int? v1478;
        v1478 = null;
        v1477 = (0);
        for (; v1477 < (100); v1477++)
            v1478 = (v1477);
        if (v1478 == null)
            return default(int);
        else
            return (int)v1478;
    }

    int Range1LastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1479;
        int? v1480;
        v1480 = null;
        v1479 = (0);
        for (; v1479 < (1); v1479++)
            v1480 = (v1479);
        if (v1480 == null)
            return default(int);
        else
            return (int)v1480;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1481;
        int? v1482;
        v1482 = null;
        v1481 = (0);
        for (; v1481 < (100); v1481++)
            v1482 = (0);
        if (v1482 == null)
            return default(int);
        else
            return (int)v1482;
    }

    int EmptyLastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1483;
        int? v1484;
        v1483 = 0;
        v1484 = null;
        if (v1484 == null)
            return default(int);
        else
            return (int)v1484;
    }

    int ArrayDistinctLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1485;
        HashSet<int> v1486;
        int v1487;
        int? v1488;
        v1486 = new HashSet<int>();
        v1488 = null;
        v1485 = (0);
        for (; v1485 < (ArrayItems.Length); v1485++)
        {
            v1487 = (ArrayItems[v1485]);
            if (!(v1486.Add((v1487))))
                continue;
            v1488 = (v1487);
        }

        if (v1488 == null)
            return default(int);
        else
            return (int)v1488;
    }

    int ArrayLastOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1490;
        int? v1491;
        v1491 = null;
        v1490 = (0);
        for (; v1490 < (ArrayItems.Length); v1490++)
            if (((ArrayItems[v1490]) > a))
                v1491 = (ArrayItems[v1490]);
        if (v1491 == null)
            return default(int);
        else
            return (int)v1491;
    }

    int ArrayLastOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1492;
        int? v1493;
        v1493 = null;
        v1492 = (0);
        for (; v1492 < (ArrayItems.Length); v1492++)
            if (((ArrayItems[v1492]) > a--))
                v1493 = (ArrayItems[v1492]);
        if (v1493 == null)
            return default(int);
        else
            return (int)v1493;
    }

    int ArrayLastOrDefaultUsingLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1495;
        int? v1496;
        int v1497;
        v1496 = null;
        v1495 = (0);
        for (; v1495 < (ArrayItems.Length); v1495++)
        {
            v1497 = (ArrayItems[v1495]);
            if ((v1497 > ArrayItems.LastOrDefault(y => y > v1497)))
                v1496 = (ArrayItems[v1495]);
        }

        if (v1496 == null)
            return default(int);
        else
            return (int)v1496;
    }
}}