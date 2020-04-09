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
        return (ArrayItems.Length) == 1 ? ArrayItems[0] : throw new System.InvalidOperationException("The sequence does not contain one element.");
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
        return (ArrayItems.Length) == 1 ? 10 + ArrayItems[0] : throw new System.InvalidOperationException("The sequence does not contain one element.");
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
        IEnumerator<int> v2036;
        int? v2037;
        v2036 = EnumerableItems.GetEnumerator();
        v2037 = null;
        try
        {
            while (v2036.MoveNext())
                if (v2037 == null)
                    v2037 = (v2036.Current);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }
        finally
        {
            v2036.Dispose();
        }

        if (v2037 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2037;
    }

    int SingleConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2039;
        int? v2040;
        v2040 = null;
        v2039 = (0);
        for (; v2039 < (ArrayItems.Length); v2039++)
            if (((ArrayItems[v2039]) > 30))
                if (v2040 == null)
                    v2040 = (ArrayItems[v2039]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2040 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2040;
    }

    int SingleFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2042;
        int? v2043;
        v2043 = null;
        v2042 = (0);
        for (; v2042 < (ArrayItems.Length); v2042++)
            if (((ArrayItems[v2042]) > 105))
                if (v2043 == null)
                    v2043 = (ArrayItems[v2042]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2043 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2043;
    }

    int SingleMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2045;
        int? v2046;
        v2046 = null;
        v2045 = (0);
        for (; v2045 < (ArrayItems.Length); v2045++)
            if (Predicate((ArrayItems[v2045])))
                if (v2046 == null)
                    v2046 = (ArrayItems[v2045]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2046 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2046;
    }

    int SingleWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2047;
        int v2048;
        int? v2049;
        v2049 = null;
        v2047 = (0);
        for (; v2047 < (ArrayItems.Length); v2047++)
        {
            v2048 = (ArrayItems[v2047]);
            if (!(((v2048) > 10)))
                continue;
            if (v2049 == null)
                v2049 = (v2048);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2049 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2049;
    }

    int RangeSingleRewritten_ProceduralLinq1()
    {
        int v2051;
        int? v2052;
        v2052 = null;
        v2051 = (0);
        for (; v2051 < (100); v2051++)
            if (v2052 == null)
                v2052 = (v2051);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2052 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2052;
    }

    int Range1SingleRewritten_ProceduralLinq1()
    {
        int v2053;
        int? v2054;
        v2054 = null;
        v2053 = (0);
        for (; v2053 < (1); v2053++)
            if (v2054 == null)
                v2054 = (v2053);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2054 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2054;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v2055;
        int? v2056;
        v2056 = null;
        v2055 = (0);
        for (; v2055 < (100); v2055++)
            if (v2056 == null)
                v2056 = (0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2056 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2056;
    }

    int EmptySingleRewritten_ProceduralLinq1()
    {
        int v2057;
        int? v2058;
        v2057 = 0;
        v2058 = null;
        if (v2058 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2058;
    }

    int ArrayDistinctSingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2059;
        HashSet<int> v2060;
        int v2061;
        int? v2062;
        v2060 = new HashSet<int>();
        v2062 = null;
        v2059 = (0);
        for (; v2059 < (ArrayItems.Length); v2059++)
        {
            v2061 = (ArrayItems[v2059]);
            if (!(v2060.Add((v2061))))
                continue;
            if (v2062 == null)
                v2062 = (v2061);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2062 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2062;
    }

    int ArraySingleParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2064;
        int? v2065;
        v2065 = null;
        v2064 = (0);
        for (; v2064 < (ArrayItems.Length); v2064++)
            if (((ArrayItems[v2064]) > a))
                if (v2065 == null)
                    v2065 = (ArrayItems[v2064]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2065 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2065;
    }

    int ArraySingleChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2066;
        int? v2067;
        v2067 = null;
        v2066 = (0);
        for (; v2066 < (ArrayItems.Length); v2066++)
            if (((ArrayItems[v2066]) > a--))
                if (v2067 == null)
                    v2067 = (ArrayItems[v2066]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2067 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2067;
    }

    int ArraySingleUsingSingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2069;
        int? v2070;
        int v2071;
        v2070 = null;
        v2069 = (0);
        for (; v2069 < (ArrayItems.Length); v2069++)
        {
            v2071 = (ArrayItems[v2069]);
            if ((v2071 > ArrayItems.Single(y => y > v2071)))
                if (v2070 == null)
                    v2070 = (ArrayItems[v2069]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2070 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2070;
    }
}}