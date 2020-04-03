using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class SingleOrDefaultTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(SingleOrDefault), SingleOrDefault, SingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSingleOrDefault), EnumerableSingleOrDefault, EnumerableSingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(SingleOrDefaultCondition), SingleOrDefaultCondition, SingleOrDefaultConditionRewritten);
        TestsExtensions.TestEquals(nameof(SingleOrDefaultFalseCondition), SingleOrDefaultFalseCondition, SingleOrDefaultFalseConditionRewritten);
        TestsExtensions.TestEquals(nameof(SingleOrDefaultMethod), SingleOrDefaultMethod, SingleOrDefaultMethodRewritten);
        TestsExtensions.TestEquals(nameof(SingleOrDefaultWhereMethod), SingleOrDefaultWhereMethod, SingleOrDefaultWhereMethodRewritten);
        TestsExtensions.TestEquals(nameof(SelectSingleOrDefaultMethod), SelectSingleOrDefaultMethod, SelectSingleOrDefaultMethodRewritten);
        TestsExtensions.TestEquals(nameof(RangeSingleOrDefault), RangeSingleOrDefault, RangeSingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(Range1SingleOrDefault), Range1SingleOrDefault, Range1SingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
        TestsExtensions.TestEquals(nameof(EmptySingleOrDefault), EmptySingleOrDefault, EmptySingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctSingleOrDefault), ArrayDistinctSingleOrDefault, ArrayDistinctSingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArraySingleOrDefaultParam), ArraySingleOrDefaultParam, ArraySingleOrDefaultParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySingleOrDefaultChangingParam), ArraySingleOrDefaultChangingParam, ArraySingleOrDefaultChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySingleOrDefaultUsingSingleOrDefault), ArraySingleOrDefaultUsingSingleOrDefault, ArraySingleOrDefaultUsingSingleOrDefaultRewritten);
    }

    [NoRewrite]
    public int SingleOrDefault()
    {
        return ArrayItems.SingleOrDefault();
    } //EndMethod

    public int SingleOrDefaultRewritten()
    {
        return ArrayItems.Length == 1 ? ArrayItems[0] : ArrayItems.Length == 0 ? default(int) : throw new System.InvalidOperationException("The sequence contains more than one element.");
    } //EndMethod

    [NoRewrite]
    public int EnumerableSingleOrDefault()
    {
        return EnumerableItems.SingleOrDefault();
    } //EndMethod

    public int EnumerableSingleOrDefaultRewritten()
    {
        return EnumerableSingleOrDefaultRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int SingleOrDefaultCondition()
    {
        return ArrayItems.SingleOrDefault(x => x > 30);
    } //EndMethod

    public int SingleOrDefaultConditionRewritten()
    {
        return SingleOrDefaultConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SingleOrDefaultFalseCondition()
    {
        return ArrayItems.SingleOrDefault(x => x > 105);
    } //EndMethod

    public int SingleOrDefaultFalseConditionRewritten()
    {
        return SingleOrDefaultFalseConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SingleOrDefaultMethod()
    {
        return ArrayItems.SingleOrDefault(Predicate);
    } //EndMethod

    public int SingleOrDefaultMethodRewritten()
    {
        return SingleOrDefaultMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SingleOrDefaultWhereMethod()
    {
        return ArrayItems.Where(x => x > 10).SingleOrDefault();
    } //EndMethod

    public int SingleOrDefaultWhereMethodRewritten()
    {
        return SingleOrDefaultWhereMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SelectSingleOrDefaultMethod()
    {
        return ArrayItems.Select(x => x + 10).SingleOrDefault();
    } //EndMethod

    public int SelectSingleOrDefaultMethodRewritten()
    {
        return SelectSingleOrDefaultMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int RangeSingleOrDefault()
    {
        return Enumerable.Range(0, 100).SingleOrDefault();
    } //EndMethod

    public int RangeSingleOrDefaultRewritten()
    {
        return RangeSingleOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int Range1SingleOrDefault()
    {
        return Enumerable.Range(0, 1).SingleOrDefault();
    } //EndMethod

    public int Range1SingleOrDefaultRewritten()
    {
        return Range1SingleOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RangeRepeat()
    {
        return Enumerable.Repeat(0, 100).SingleOrDefault();
    } //EndMethod

    public int RangeRepeatRewritten()
    {
        return RangeRepeatRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int EmptySingleOrDefault()
    {
        return Enumerable.Empty<int>().SingleOrDefault();
    } //EndMethod

    public int EmptySingleOrDefaultRewritten()
    {
        return EmptySingleOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int ArrayDistinctSingleOrDefault()
    {
        return ArrayItems.Distinct().SingleOrDefault();
    } //EndMethod

    public int ArrayDistinctSingleOrDefaultRewritten()
    {
        return ArrayDistinctSingleOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySingleOrDefaultParam()
    {
        var a = 50;
        return ArrayItems.SingleOrDefault(x => x > a);
    } //EndMethod

    public int ArraySingleOrDefaultParamRewritten()
    {
        var a = 50;
        return ArraySingleOrDefaultParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySingleOrDefaultChangingParam()
    {
        var a = 100;
        return ArrayItems.SingleOrDefault(x => x > a--);
    } //EndMethod

    public int ArraySingleOrDefaultChangingParamRewritten()
    {
        var a = 100;
        return ArraySingleOrDefaultChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySingleOrDefaultUsingSingleOrDefault()
    {
        var a = 100;
        return ArrayItems.SingleOrDefault(x => x > ArrayItems.SingleOrDefault(y => y > x));
    } //EndMethod

    public int ArraySingleOrDefaultUsingSingleOrDefaultRewritten()
    {
        var a = 100;
        return ArraySingleOrDefaultUsingSingleOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int EnumerableSingleOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1612;
        int? v1613;
        v1612 = EnumerableItems.GetEnumerator();
        v1613 = null;
        try
        {
            while (v1612.MoveNext())
                if (v1613 == null)
                    v1613 = v1612.Current;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }
        finally
        {
            v1612.Dispose();
        }

        if (v1613 == null)
            return default(int);
        else
            return (int)v1613;
    }

    int SingleOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1614;
        int? v1615;
        v1615 = null;
        v1614 = 0;
        for (; v1614 < ArrayItems.Length; v1614++)
            if ((ArrayItems[v1614] > 30))
                if (v1615 == null)
                    v1615 = ArrayItems[v1614];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1615 == null)
            return default(int);
        else
            return (int)v1615;
    }

    int SingleOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1616;
        int? v1617;
        v1617 = null;
        v1616 = 0;
        for (; v1616 < ArrayItems.Length; v1616++)
            if ((ArrayItems[v1616] > 105))
                if (v1617 == null)
                    v1617 = ArrayItems[v1616];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1617 == null)
            return default(int);
        else
            return (int)v1617;
    }

    int SingleOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1618;
        int? v1619;
        v1619 = null;
        v1618 = 0;
        for (; v1618 < ArrayItems.Length; v1618++)
            if (Predicate(ArrayItems[v1618]))
                if (v1619 == null)
                    v1619 = ArrayItems[v1618];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1619 == null)
            return default(int);
        else
            return (int)v1619;
    }

    int SingleOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1620;
        int? v1621;
        v1621 = null;
        v1620 = 0;
        for (; v1620 < ArrayItems.Length; v1620++)
        {
            if (!((ArrayItems[v1620] > 10)))
                continue;
            if (v1621 == null)
                v1621 = ArrayItems[v1620];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1621 == null)
            return default(int);
        else
            return (int)v1621;
    }

    int SelectSingleOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1622;
        int? v1623;
        v1623 = null;
        v1622 = 0;
        for (; v1622 < ArrayItems.Length; v1622++)
            if (v1623 == null)
                v1623 = (ArrayItems[v1622] + 10);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1623 == null)
            return default(int);
        else
            return (int)v1623;
    }

    int RangeSingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v1624;
        int? v1625;
        v1625 = null;
        v1624 = 0;
        for (; v1624 < 100; v1624++)
            if (v1625 == null)
                v1625 = (v1624 + 0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1625 == null)
            return default(int);
        else
            return (int)v1625;
    }

    int Range1SingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v1626;
        int? v1627;
        v1627 = null;
        v1626 = 0;
        for (; v1626 < 1; v1626++)
            if (v1627 == null)
                v1627 = (v1626 + 0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1627 == null)
            return default(int);
        else
            return (int)v1627;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1628;
        int? v1629;
        v1629 = null;
        v1628 = 0;
        for (; v1628 < 100; v1628++)
            if (v1629 == null)
                v1629 = 0;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1629 == null)
            return default(int);
        else
            return (int)v1629;
    }

    int EmptySingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v1630;
        int? v1631;
        v1631 = null;
        v1630 = 0;
        for (; v1630 < 0; v1630++)
            if (v1631 == null)
                v1631 = default(int);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1631 == null)
            return default(int);
        else
            return (int)v1631;
    }

    int ArrayDistinctSingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1632;
        HashSet<int> v1633;
        int? v1634;
        v1633 = new HashSet<int>();
        v1634 = null;
        v1632 = 0;
        for (; v1632 < ArrayItems.Length; v1632++)
        {
            if (!(v1633.Add(ArrayItems[v1632])))
                continue;
            if (v1634 == null)
                v1634 = ArrayItems[v1632];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1634 == null)
            return default(int);
        else
            return (int)v1634;
    }

    int ArraySingleOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1635;
        int? v1636;
        v1636 = null;
        v1635 = 0;
        for (; v1635 < ArrayItems.Length; v1635++)
            if ((ArrayItems[v1635] > a))
                if (v1636 == null)
                    v1636 = ArrayItems[v1635];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1636 == null)
            return default(int);
        else
            return (int)v1636;
    }

    int ArraySingleOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1637;
        int? v1638;
        v1638 = null;
        v1637 = 0;
        for (; v1637 < ArrayItems.Length; v1637++)
            if ((ArrayItems[v1637] > a--))
                if (v1638 == null)
                    v1638 = ArrayItems[v1637];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1638 == null)
            return default(int);
        else
            return (int)v1638;
    }

    int ArraySingleOrDefaultUsingSingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1639;
        int? v1640;
        v1640 = null;
        v1639 = 0;
        for (; v1639 < ArrayItems.Length; v1639++)
            if ((ArrayItems[v1639] > ArrayItems.SingleOrDefault(y => y > ArrayItems[v1639])))
                if (v1640 == null)
                    v1640 = ArrayItems[v1639];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1640 == null)
            return default(int);
        else
            return (int)v1640;
    }
}}