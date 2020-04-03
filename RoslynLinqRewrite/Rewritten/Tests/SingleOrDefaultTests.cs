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
        IEnumerator<int> v1678;
        int? v1679;
        v1678 = EnumerableItems.GetEnumerator();
        v1679 = null;
        try
        {
            while (v1678.MoveNext())
                if (v1679 == null)
                    v1679 = v1678.Current;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }
        finally
        {
            v1678.Dispose();
        }

        if (v1679 == null)
            return default(int);
        else
            return (int)v1679;
    }

    int SingleOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1680;
        int? v1681;
        v1681 = null;
        v1680 = 0;
        for (; v1680 < ArrayItems.Length; v1680++)
            if ((ArrayItems[v1680] > 30))
                if (v1681 == null)
                    v1681 = ArrayItems[v1680];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1681 == null)
            return default(int);
        else
            return (int)v1681;
    }

    int SingleOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1682;
        int? v1683;
        v1683 = null;
        v1682 = 0;
        for (; v1682 < ArrayItems.Length; v1682++)
            if ((ArrayItems[v1682] > 105))
                if (v1683 == null)
                    v1683 = ArrayItems[v1682];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1683 == null)
            return default(int);
        else
            return (int)v1683;
    }

    int SingleOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1684;
        int? v1685;
        v1685 = null;
        v1684 = 0;
        for (; v1684 < ArrayItems.Length; v1684++)
            if (Predicate(ArrayItems[v1684]))
                if (v1685 == null)
                    v1685 = ArrayItems[v1684];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1685 == null)
            return default(int);
        else
            return (int)v1685;
    }

    int SingleOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1686;
        int? v1687;
        v1687 = null;
        v1686 = 0;
        for (; v1686 < ArrayItems.Length; v1686++)
        {
            if (!((ArrayItems[v1686] > 10)))
                continue;
            if (v1687 == null)
                v1687 = ArrayItems[v1686];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1687 == null)
            return default(int);
        else
            return (int)v1687;
    }

    int SelectSingleOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1688;
        int? v1689;
        v1689 = null;
        v1688 = 0;
        for (; v1688 < ArrayItems.Length; v1688++)
            if (v1689 == null)
                v1689 = (ArrayItems[v1688] + 10);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1689 == null)
            return default(int);
        else
            return (int)v1689;
    }

    int RangeSingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v1690;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1691;
        v1691 = null;
        v1690 = 0;
        for (; v1690 < 100; v1690++)
            if (v1691 == null)
                v1691 = (v1690 + 0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1691 == null)
            return default(int);
        else
            return (int)v1691;
    }

    int Range1SingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v1692;
        if (1 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1693;
        v1693 = null;
        v1692 = 0;
        for (; v1692 < 1; v1692++)
            if (v1693 == null)
                v1693 = (v1692 + 0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1693 == null)
            return default(int);
        else
            return (int)v1693;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1694;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1695;
        v1695 = null;
        v1694 = 0;
        for (; v1694 < 100; v1694++)
            if (v1695 == null)
                v1695 = 0;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1695 == null)
            return default(int);
        else
            return (int)v1695;
    }

    int EmptySingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v1696;
        int? v1697;
        v1697 = null;
        v1696 = 0;
        for (; v1696 < 0; v1696++)
            if (v1697 == null)
                v1697 = default(int);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1697 == null)
            return default(int);
        else
            return (int)v1697;
    }

    int ArrayDistinctSingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1698;
        HashSet<int> v1699;
        int? v1700;
        v1699 = new HashSet<int>();
        v1700 = null;
        v1698 = 0;
        for (; v1698 < ArrayItems.Length; v1698++)
        {
            if (!(v1699.Add(ArrayItems[v1698])))
                continue;
            if (v1700 == null)
                v1700 = ArrayItems[v1698];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1700 == null)
            return default(int);
        else
            return (int)v1700;
    }

    int ArraySingleOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1701;
        int? v1702;
        v1702 = null;
        v1701 = 0;
        for (; v1701 < ArrayItems.Length; v1701++)
            if ((ArrayItems[v1701] > a))
                if (v1702 == null)
                    v1702 = ArrayItems[v1701];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1702 == null)
            return default(int);
        else
            return (int)v1702;
    }

    int ArraySingleOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1703;
        int? v1704;
        v1704 = null;
        v1703 = 0;
        for (; v1703 < ArrayItems.Length; v1703++)
            if ((ArrayItems[v1703] > a--))
                if (v1704 == null)
                    v1704 = ArrayItems[v1703];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1704 == null)
            return default(int);
        else
            return (int)v1704;
    }

    int ArraySingleOrDefaultUsingSingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1705;
        int? v1706;
        v1706 = null;
        v1705 = 0;
        for (; v1705 < ArrayItems.Length; v1705++)
            if ((ArrayItems[v1705] > ArrayItems.SingleOrDefault(y => y > ArrayItems[v1705])))
                if (v1706 == null)
                    v1706 = ArrayItems[v1705];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1706 == null)
            return default(int);
        else
            return (int)v1706;
    }
}}