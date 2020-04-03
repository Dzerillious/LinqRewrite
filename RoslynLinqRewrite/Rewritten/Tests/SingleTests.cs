using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class SingleTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(Single), Single, SingleRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSingle), EnumerableSingle, EnumerableSingleRewritten);
        TestsExtensions.TestEquals(nameof(SingleCondition), SingleCondition, SingleConditionRewritten);
        TestsExtensions.TestEquals(nameof(SingleFalseCondition), SingleFalseCondition, SingleFalseConditionRewritten);
        TestsExtensions.TestEquals(nameof(SingleMethod), SingleMethod, SingleMethodRewritten);
        TestsExtensions.TestEquals(nameof(SingleWhereMethod), SingleWhereMethod, SingleWhereMethodRewritten);
        TestsExtensions.TestEquals(nameof(SelectSingleMethod), SelectSingleMethod, SelectSingleMethodRewritten);
        TestsExtensions.TestEquals(nameof(RangeSingle), RangeSingle, RangeSingleRewritten);
        TestsExtensions.TestEquals(nameof(Range1Single), Range1Single, Range1SingleRewritten);
        TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
        TestsExtensions.TestEquals(nameof(EmptySingle), EmptySingle, EmptySingleRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctSingle), ArrayDistinctSingle, ArrayDistinctSingleRewritten);
        TestsExtensions.TestEquals(nameof(ArraySingleParam), ArraySingleParam, ArraySingleParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySingleChangingParam), ArraySingleChangingParam, ArraySingleChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySingleUsingSingle), ArraySingleUsingSingle, ArraySingleUsingSingleRewritten);
    }

    [NoRewrite]
    public int Single()
    {
        return ArrayItems.Single();
    } //EndMethod

    public int SingleRewritten()
    {
        return ArrayItems.Length == 1 ? ArrayItems[0] : throw new System.InvalidOperationException("The sequence does not contain one element.");
    } //EndMethod

    [NoRewrite]
    public int EnumerableSingle()
    {
        return EnumerableItems.Single();
    } //EndMethod

    public int EnumerableSingleRewritten()
    {
        return EnumerableSingleRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int SingleCondition()
    {
        return ArrayItems.Single(x => x > 30);
    } //EndMethod

    public int SingleConditionRewritten()
    {
        return SingleConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SingleFalseCondition()
    {
        return ArrayItems.Single(x => x > 105);
    } //EndMethod

    public int SingleFalseConditionRewritten()
    {
        return SingleFalseConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SingleMethod()
    {
        return ArrayItems.Single(Predicate);
    } //EndMethod

    public int SingleMethodRewritten()
    {
        return SingleMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SingleWhereMethod()
    {
        return ArrayItems.Where(x => x > 10).Single();
    } //EndMethod

    public int SingleWhereMethodRewritten()
    {
        return SingleWhereMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SelectSingleMethod()
    {
        return ArrayItems.Select(x => x + 10).Single();
    } //EndMethod

    public int SelectSingleMethodRewritten()
    {
        return SelectSingleMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int RangeSingle()
    {
        return Enumerable.Range(0, 100).Single();
    } //EndMethod

    public int RangeSingleRewritten()
    {
        return RangeSingleRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int Range1Single()
    {
        return Enumerable.Range(0, 1).Single();
    } //EndMethod

    public int Range1SingleRewritten()
    {
        return Range1SingleRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RangeRepeat()
    {
        return Enumerable.Repeat(0, 100).Single();
    } //EndMethod

    public int RangeRepeatRewritten()
    {
        return RangeRepeatRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int EmptySingle()
    {
        return Enumerable.Empty<int>().Single();
    } //EndMethod

    public int EmptySingleRewritten()
    {
        return EmptySingleRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int ArrayDistinctSingle()
    {
        return ArrayItems.Distinct().Single();
    } //EndMethod

    public int ArrayDistinctSingleRewritten()
    {
        return ArrayDistinctSingleRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySingleParam()
    {
        var a = 50;
        return ArrayItems.Single(x => x > a);
    } //EndMethod

    public int ArraySingleParamRewritten()
    {
        var a = 50;
        return ArraySingleParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySingleChangingParam()
    {
        var a = 100;
        return ArrayItems.Single(x => x > a--);
    } //EndMethod

    public int ArraySingleChangingParamRewritten()
    {
        var a = 100;
        return ArraySingleChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySingleUsingSingle()
    {
        var a = 100;
        return ArrayItems.Single(x => x > ArrayItems.Single(y => y > x));
    } //EndMethod

    public int ArraySingleUsingSingleRewritten()
    {
        var a = 100;
        return ArraySingleUsingSingleRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int EnumerableSingleRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1642;
        int? v1643;
        v1642 = EnumerableItems.GetEnumerator();
        v1643 = null;
        try
        {
            while (v1642.MoveNext())
                if (v1643 == null)
                    v1643 = v1642.Current;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }
        finally
        {
            v1642.Dispose();
        }

        if (v1643 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1643;
    }

    int SingleConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1644;
        int? v1645;
        v1645 = null;
        v1644 = 0;
        for (; v1644 < ArrayItems.Length; v1644++)
            if ((ArrayItems[v1644] > 30))
                if (v1645 == null)
                    v1645 = ArrayItems[v1644];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1645 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1645;
    }

    int SingleFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1646;
        int? v1647;
        v1647 = null;
        v1646 = 0;
        for (; v1646 < ArrayItems.Length; v1646++)
            if ((ArrayItems[v1646] > 105))
                if (v1647 == null)
                    v1647 = ArrayItems[v1646];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1647 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1647;
    }

    int SingleMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1648;
        int? v1649;
        v1649 = null;
        v1648 = 0;
        for (; v1648 < ArrayItems.Length; v1648++)
            if (Predicate(ArrayItems[v1648]))
                if (v1649 == null)
                    v1649 = ArrayItems[v1648];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1649 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1649;
    }

    int SingleWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1650;
        int? v1651;
        v1651 = null;
        v1650 = 0;
        for (; v1650 < ArrayItems.Length; v1650++)
        {
            if (!((ArrayItems[v1650] > 10)))
                continue;
            if (v1651 == null)
                v1651 = ArrayItems[v1650];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1651 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1651;
    }

    int SelectSingleMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1652;
        int? v1653;
        v1653 = null;
        v1652 = 0;
        for (; v1652 < ArrayItems.Length; v1652++)
            if (v1653 == null)
                v1653 = (ArrayItems[v1652] + 10);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1653 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1653;
    }

    int RangeSingleRewritten_ProceduralLinq1()
    {
        int v1654;
        int? v1655;
        v1655 = null;
        v1654 = 0;
        for (; v1654 < 100; v1654++)
            if (v1655 == null)
                v1655 = (v1654 + 0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1655 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1655;
    }

    int Range1SingleRewritten_ProceduralLinq1()
    {
        int v1656;
        int? v1657;
        v1657 = null;
        v1656 = 0;
        for (; v1656 < 1; v1656++)
            if (v1657 == null)
                v1657 = (v1656 + 0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1657 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1657;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1658;
        int? v1659;
        v1659 = null;
        v1658 = 0;
        for (; v1658 < 100; v1658++)
            if (v1659 == null)
                v1659 = 0;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1659 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1659;
    }

    int EmptySingleRewritten_ProceduralLinq1()
    {
        int v1660;
        int? v1661;
        v1661 = null;
        v1660 = 0;
        for (; v1660 < 0; v1660++)
            if (v1661 == null)
                v1661 = default(int);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1661 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1661;
    }

    int ArrayDistinctSingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1662;
        HashSet<int> v1663;
        int? v1664;
        v1663 = new HashSet<int>();
        v1664 = null;
        v1662 = 0;
        for (; v1662 < ArrayItems.Length; v1662++)
        {
            if (!(v1663.Add(ArrayItems[v1662])))
                continue;
            if (v1664 == null)
                v1664 = ArrayItems[v1662];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1664 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1664;
    }

    int ArraySingleParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1665;
        int? v1666;
        v1666 = null;
        v1665 = 0;
        for (; v1665 < ArrayItems.Length; v1665++)
            if ((ArrayItems[v1665] > a))
                if (v1666 == null)
                    v1666 = ArrayItems[v1665];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1666 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1666;
    }

    int ArraySingleChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1667;
        int? v1668;
        v1668 = null;
        v1667 = 0;
        for (; v1667 < ArrayItems.Length; v1667++)
            if ((ArrayItems[v1667] > a--))
                if (v1668 == null)
                    v1668 = ArrayItems[v1667];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1668 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1668;
    }

    int ArraySingleUsingSingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1669;
        int? v1670;
        v1670 = null;
        v1669 = 0;
        for (; v1669 < ArrayItems.Length; v1669++)
            if ((ArrayItems[v1669] > ArrayItems.Single(y => y > ArrayItems[v1669])))
                if (v1670 == null)
                    v1670 = ArrayItems[v1669];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1670 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1670;
    }
}}