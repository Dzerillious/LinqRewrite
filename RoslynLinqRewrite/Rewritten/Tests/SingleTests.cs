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
        return (ArrayItems.Length) == 1 ? (ArrayItems[(0)]) : throw new System.InvalidOperationException("The sequence does not contain one element.");
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
        return (ArrayItems.Length) == 1 ? 10 + ArrayItems[(0)] : throw new System.InvalidOperationException("The sequence does not contain one element.");
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
        return ArraySingleUsingSingleRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    int EnumerableSingleRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1839;
        int? v1840;
        v1839 = EnumerableItems.GetEnumerator();
        v1840 = null;
        try
        {
            while (v1839.MoveNext())
                if (v1840 == null)
                    v1840 = (v1839.Current);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }
        finally
        {
            v1839.Dispose();
        }

        if (v1840 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1840;
    }

    int SingleConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1842;
        int? v1843;
        v1843 = null;
        v1842 = (0);
        for (; v1842 < (ArrayItems.Length); v1842 += 1)
            if (((ArrayItems[v1842]) > 30))
                if (v1843 == null)
                    v1843 = (ArrayItems[v1842]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1843 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1843;
    }

    int SingleFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1845;
        int? v1846;
        v1846 = null;
        v1845 = (0);
        for (; v1845 < (ArrayItems.Length); v1845 += 1)
            if (((ArrayItems[v1845]) > 105))
                if (v1846 == null)
                    v1846 = (ArrayItems[v1845]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1846 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1846;
    }

    int SingleMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1848;
        int? v1849;
        v1849 = null;
        v1848 = (0);
        for (; v1848 < (ArrayItems.Length); v1848 += 1)
            if (Predicate((ArrayItems[v1848])))
                if (v1849 == null)
                    v1849 = (ArrayItems[v1848]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1849 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1849;
    }

    int SingleWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1850;
        int? v1851;
        v1851 = null;
        v1850 = (0);
        for (; v1850 < (ArrayItems.Length); v1850 += 1)
        {
            if (!((((ArrayItems[v1850])) > 10)))
                continue;
            if (v1851 == null)
                v1851 = ((ArrayItems[v1850]));
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1851 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1851;
    }

    int RangeSingleRewritten_ProceduralLinq1()
    {
        int v1853;
        int? v1854;
        v1854 = null;
        v1853 = (0);
        for (; v1853 < (100); v1853 += (1))
            if (v1854 == null)
                v1854 = (v1853);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1854 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1854;
    }

    int Range1SingleRewritten_ProceduralLinq1()
    {
        int v1855;
        int? v1856;
        v1856 = null;
        v1855 = (0);
        for (; v1855 < (1); v1855 += (1))
            if (v1856 == null)
                v1856 = (v1855);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1856 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1856;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1857;
        int? v1858;
        v1858 = null;
        v1857 = (0);
        for (; v1857 < (100); v1857 += 1)
            if (v1858 == null)
                v1858 = (0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1858 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1858;
    }

    int EmptySingleRewritten_ProceduralLinq1()
    {
        int v1859;
        int? v1860;
        v1859 = 0;
        v1860 = null;
        if (v1860 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1860;
    }

    int ArrayDistinctSingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1861;
        HashSet<int> v1862;
        int? v1863;
        v1862 = new HashSet<int>();
        v1863 = null;
        v1861 = (0);
        for (; v1861 < (ArrayItems.Length); v1861 += 1)
        {
            if (!(v1862.Add(((ArrayItems[v1861])))))
                continue;
            if (v1863 == null)
                v1863 = ((ArrayItems[v1861]));
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1863 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1863;
    }

    int ArraySingleParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1865;
        int? v1866;
        v1866 = null;
        v1865 = (0);
        for (; v1865 < (ArrayItems.Length); v1865 += 1)
            if (((ArrayItems[v1865]) > a))
                if (v1866 == null)
                    v1866 = (ArrayItems[v1865]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1866 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1866;
    }

    int ArraySingleChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1867;
        int? v1868;
        v1868 = null;
        v1867 = (0);
        for (; v1867 < (ArrayItems.Length); v1867 += 1)
            if (((ArrayItems[v1867]) > a--))
                if (v1868 == null)
                    v1868 = (ArrayItems[v1867]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1868 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1868;
    }

    int ArraySingleUsingSingleRewritten_ProceduralLinq1(int x, int[] ArrayItems)
    {
        int v1870;
        int? v1871;
        v1871 = null;
        v1870 = (0);
        for (; v1870 < (ArrayItems.Length); v1870 += 1)
            if (((ArrayItems[v1870]) > x))
                if (v1871 == null)
                    v1871 = (ArrayItems[v1870]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1871 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1871;
    }

    int ArraySingleUsingSingleRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1873;
        int? v1874;
        v1874 = null;
        v1873 = (0);
        for (; v1873 < (ArrayItems.Length); v1873 += 1)
            if (((ArrayItems[v1873]) > ArraySingleUsingSingleRewritten_ProceduralLinq1((ArrayItems[v1873]), ArrayItems)))
                if (v1874 == null)
                    v1874 = (ArrayItems[v1873]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v1874 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1874;
    }
}}