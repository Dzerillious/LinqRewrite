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
        IEnumerator<int> v1708;
        int? v1709;
        v1708 = EnumerableItems.GetEnumerator();
        v1709 = null;
        try
        {
            while (v1708.MoveNext())
                if (v1709 == null)
                    v1709 = v1708.Current;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }
        finally
        {
            v1708.Dispose();
        }

        if (v1709 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1709;
    }

    int SingleConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1710;
        int? v1711;
        v1711 = null;
        v1710 = 0;
        for (; v1710 < ArrayItems.Length; v1710++)
            if ((ArrayItems[v1710] > 30))
                if (v1711 == null)
                    v1711 = ArrayItems[v1710];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1711 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1711;
    }

    int SingleFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1712;
        int? v1713;
        v1713 = null;
        v1712 = 0;
        for (; v1712 < ArrayItems.Length; v1712++)
            if ((ArrayItems[v1712] > 105))
                if (v1713 == null)
                    v1713 = ArrayItems[v1712];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1713 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1713;
    }

    int SingleMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1714;
        int? v1715;
        v1715 = null;
        v1714 = 0;
        for (; v1714 < ArrayItems.Length; v1714++)
            if (Predicate(ArrayItems[v1714]))
                if (v1715 == null)
                    v1715 = ArrayItems[v1714];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1715 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1715;
    }

    int SingleWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1716;
        int? v1717;
        v1717 = null;
        v1716 = 0;
        for (; v1716 < ArrayItems.Length; v1716++)
        {
            if (!((ArrayItems[v1716] > 10)))
                continue;
            if (v1717 == null)
                v1717 = ArrayItems[v1716];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1717 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1717;
    }

    int SelectSingleMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1718;
        int? v1719;
        v1719 = null;
        v1718 = 0;
        for (; v1718 < ArrayItems.Length; v1718++)
            if (v1719 == null)
                v1719 = (ArrayItems[v1718] + 10);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1719 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1719;
    }

    int RangeSingleRewritten_ProceduralLinq1()
    {
        int v1720;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1721;
        v1721 = null;
        v1720 = 0;
        for (; v1720 < 100; v1720++)
            if (v1721 == null)
                v1721 = (v1720 + 0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1721 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1721;
    }

    int Range1SingleRewritten_ProceduralLinq1()
    {
        int v1722;
        if (1 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1723;
        v1723 = null;
        v1722 = 0;
        for (; v1722 < 1; v1722++)
            if (v1723 == null)
                v1723 = (v1722 + 0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1723 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1723;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1724;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1725;
        v1725 = null;
        v1724 = 0;
        for (; v1724 < 100; v1724++)
            if (v1725 == null)
                v1725 = 0;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1725 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1725;
    }

    int EmptySingleRewritten_ProceduralLinq1()
    {
        int v1726;
        int? v1727;
        v1727 = null;
        v1726 = 0;
        for (; v1726 < 0; v1726++)
            if (v1727 == null)
                v1727 = default(int);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1727 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1727;
    }

    int ArrayDistinctSingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1728;
        HashSet<int> v1729;
        int? v1730;
        v1729 = new HashSet<int>();
        v1730 = null;
        v1728 = 0;
        for (; v1728 < ArrayItems.Length; v1728++)
        {
            if (!(v1729.Add(ArrayItems[v1728])))
                continue;
            if (v1730 == null)
                v1730 = ArrayItems[v1728];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1730 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1730;
    }

    int ArraySingleParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1731;
        int? v1732;
        v1732 = null;
        v1731 = 0;
        for (; v1731 < ArrayItems.Length; v1731++)
            if ((ArrayItems[v1731] > a))
                if (v1732 == null)
                    v1732 = ArrayItems[v1731];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1732 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1732;
    }

    int ArraySingleChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1733;
        int? v1734;
        v1734 = null;
        v1733 = 0;
        for (; v1733 < ArrayItems.Length; v1733++)
            if ((ArrayItems[v1733] > a--))
                if (v1734 == null)
                    v1734 = ArrayItems[v1733];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1734 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1734;
    }

    int ArraySingleUsingSingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1735;
        int? v1736;
        v1736 = null;
        v1735 = 0;
        for (; v1735 < ArrayItems.Length; v1735++)
            if ((ArrayItems[v1735] > ArrayItems.Single(y => y > ArrayItems[v1735])))
                if (v1736 == null)
                    v1736 = ArrayItems[v1735];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1736 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1736;
    }
}}