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
        return ArrayItems.Length == 1 ? (ArrayItems[(0)]) : (ArrayItems.Length) == 0 ? default(int) : throw new System.InvalidOperationException("The sequence contains more than one element.");
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
        return ArrayItems.Length == 1 ? 10 + ArrayItems[(0)] : (ArrayItems.Length) == 0 ? default(int) : throw new System.InvalidOperationException("The sequence contains more than one element.");
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
        return ArraySingleOrDefaultUsingSingleOrDefaultRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    int EnumerableSingleOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1802;
        int? v1803;
        v1802 = EnumerableItems.GetEnumerator();
        v1803 = null;
        try
        {
            while (v1802.MoveNext())
                if (v1803 == null)
                    v1803 = (v1802.Current);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }
        finally
        {
            v1802.Dispose();
        }

        if (v1803 == null)
            return default(int);
        else
            return (int)v1803;
    }

    int SingleOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1805;
        int? v1806;
        v1806 = null;
        v1805 = (0);
        for (; v1805 < (ArrayItems.Length); v1805 += 1)
            if (((ArrayItems[v1805]) > 30))
                if (v1806 == null)
                    v1806 = (ArrayItems[v1805]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1806 == null)
            return default(int);
        else
            return (int)v1806;
    }

    int SingleOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1808;
        int? v1809;
        v1809 = null;
        v1808 = (0);
        for (; v1808 < (ArrayItems.Length); v1808 += 1)
            if (((ArrayItems[v1808]) > 105))
                if (v1809 == null)
                    v1809 = (ArrayItems[v1808]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1809 == null)
            return default(int);
        else
            return (int)v1809;
    }

    int SingleOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1811;
        int? v1812;
        v1812 = null;
        v1811 = (0);
        for (; v1811 < (ArrayItems.Length); v1811 += 1)
            if (Predicate((ArrayItems[v1811])))
                if (v1812 == null)
                    v1812 = (ArrayItems[v1811]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1812 == null)
            return default(int);
        else
            return (int)v1812;
    }

    int SingleOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1813;
        int? v1814;
        v1814 = null;
        v1813 = (0);
        for (; v1813 < (ArrayItems.Length); v1813 += 1)
        {
            if (!((((ArrayItems[v1813])) > 10)))
                continue;
            if (v1814 == null)
                v1814 = ((ArrayItems[v1813]));
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1814 == null)
            return default(int);
        else
            return (int)v1814;
    }

    int RangeSingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v1816;
        int? v1817;
        v1817 = null;
        v1816 = (0);
        for (; v1816 < (100); v1816 += (1))
            if (v1817 == null)
                v1817 = (v1816);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1817 == null)
            return default(int);
        else
            return (int)v1817;
    }

    int Range1SingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v1818;
        int? v1819;
        v1819 = null;
        v1818 = (0);
        for (; v1818 < (1); v1818 += (1))
            if (v1819 == null)
                v1819 = (v1818);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1819 == null)
            return default(int);
        else
            return (int)v1819;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1820;
        int? v1821;
        v1821 = null;
        v1820 = (0);
        for (; v1820 < (100); v1820 += 1)
            if (v1821 == null)
                v1821 = (0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1821 == null)
            return default(int);
        else
            return (int)v1821;
    }

    int EmptySingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v1822;
        int? v1823;
        v1822 = 0;
        v1823 = null;
        if (v1823 == null)
            return default(int);
        else
            return (int)v1823;
    }

    int ArrayDistinctSingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1824;
        HashSet<int> v1825;
        int? v1826;
        v1825 = new HashSet<int>();
        v1826 = null;
        v1824 = (0);
        for (; v1824 < (ArrayItems.Length); v1824 += 1)
        {
            if (!(v1825.Add(((ArrayItems[v1824])))))
                continue;
            if (v1826 == null)
                v1826 = ((ArrayItems[v1824]));
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1826 == null)
            return default(int);
        else
            return (int)v1826;
    }

    int ArraySingleOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1828;
        int? v1829;
        v1829 = null;
        v1828 = (0);
        for (; v1828 < (ArrayItems.Length); v1828 += 1)
            if (((ArrayItems[v1828]) > a))
                if (v1829 == null)
                    v1829 = (ArrayItems[v1828]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1829 == null)
            return default(int);
        else
            return (int)v1829;
    }

    int ArraySingleOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1830;
        int? v1831;
        v1831 = null;
        v1830 = (0);
        for (; v1830 < (ArrayItems.Length); v1830 += 1)
            if (((ArrayItems[v1830]) > a--))
                if (v1831 == null)
                    v1831 = (ArrayItems[v1830]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1831 == null)
            return default(int);
        else
            return (int)v1831;
    }

    int ArraySingleOrDefaultUsingSingleOrDefaultRewritten_ProceduralLinq1(int x, int[] ArrayItems)
    {
        int v1833;
        int? v1834;
        v1834 = null;
        v1833 = (0);
        for (; v1833 < (ArrayItems.Length); v1833 += 1)
            if (((ArrayItems[v1833]) > x))
                if (v1834 == null)
                    v1834 = (ArrayItems[v1833]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1834 == null)
            return default(int);
        else
            return (int)v1834;
    }

    int ArraySingleOrDefaultUsingSingleOrDefaultRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1836;
        int? v1837;
        v1837 = null;
        v1836 = (0);
        for (; v1836 < (ArrayItems.Length); v1836 += 1)
            if (((ArrayItems[v1836]) > ArraySingleOrDefaultUsingSingleOrDefaultRewritten_ProceduralLinq1((ArrayItems[v1836]), ArrayItems)))
                if (v1837 == null)
                    v1837 = (ArrayItems[v1836]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1837 == null)
            return default(int);
        else
            return (int)v1837;
    }
}}