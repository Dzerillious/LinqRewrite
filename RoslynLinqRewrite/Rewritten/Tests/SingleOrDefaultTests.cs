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
        return ArrayItems.Length == 1 ? ArrayItems[0] : (ArrayItems.Length) == 0 ? default(int) : throw new System.InvalidOperationException("The sequence contains more than one element.");
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
        return ArrayItems.Length == 1 ? 10 + ArrayItems[0] : (ArrayItems.Length) == 0 ? default(int) : throw new System.InvalidOperationException("The sequence contains more than one element.");
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
        IEnumerator<int> v1999;
        int? v2000;
        v1999 = EnumerableItems.GetEnumerator();
        v2000 = null;
        try
        {
            while (v1999.MoveNext())
                if (v2000 == null)
                    v2000 = (v1999.Current);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }
        finally
        {
            v1999.Dispose();
        }

        if (v2000 == null)
            return default(int);
        else
            return (int)v2000;
    }

    int SingleOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2002;
        int? v2003;
        v2003 = null;
        v2002 = (0);
        for (; v2002 < (ArrayItems.Length); v2002++)
            if (((ArrayItems[v2002]) > 30))
                if (v2003 == null)
                    v2003 = (ArrayItems[v2002]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2003 == null)
            return default(int);
        else
            return (int)v2003;
    }

    int SingleOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2005;
        int? v2006;
        v2006 = null;
        v2005 = (0);
        for (; v2005 < (ArrayItems.Length); v2005++)
            if (((ArrayItems[v2005]) > 105))
                if (v2006 == null)
                    v2006 = (ArrayItems[v2005]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2006 == null)
            return default(int);
        else
            return (int)v2006;
    }

    int SingleOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2008;
        int? v2009;
        v2009 = null;
        v2008 = (0);
        for (; v2008 < (ArrayItems.Length); v2008++)
            if (Predicate((ArrayItems[v2008])))
                if (v2009 == null)
                    v2009 = (ArrayItems[v2008]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2009 == null)
            return default(int);
        else
            return (int)v2009;
    }

    int SingleOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2010;
        int v2011;
        int? v2012;
        v2012 = null;
        v2010 = (0);
        for (; v2010 < (ArrayItems.Length); v2010++)
        {
            v2011 = (ArrayItems[v2010]);
            if (!(((v2011) > 10)))
                continue;
            if (v2012 == null)
                v2012 = (v2011);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2012 == null)
            return default(int);
        else
            return (int)v2012;
    }

    int RangeSingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v2014;
        int? v2015;
        v2015 = null;
        v2014 = (0);
        for (; v2014 < (100); v2014++)
            if (v2015 == null)
                v2015 = (v2014);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2015 == null)
            return default(int);
        else
            return (int)v2015;
    }

    int Range1SingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v2016;
        int? v2017;
        v2017 = null;
        v2016 = (0);
        for (; v2016 < (1); v2016++)
            if (v2017 == null)
                v2017 = (v2016);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2017 == null)
            return default(int);
        else
            return (int)v2017;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v2018;
        int? v2019;
        v2019 = null;
        v2018 = (0);
        for (; v2018 < (100); v2018++)
            if (v2019 == null)
                v2019 = (0);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2019 == null)
            return default(int);
        else
            return (int)v2019;
    }

    int EmptySingleOrDefaultRewritten_ProceduralLinq1()
    {
        int v2020;
        int? v2021;
        v2020 = 0;
        v2021 = null;
        if (v2021 == null)
            return default(int);
        else
            return (int)v2021;
    }

    int ArrayDistinctSingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2022;
        HashSet<int> v2023;
        int v2024;
        int? v2025;
        v2023 = new HashSet<int>();
        v2025 = null;
        v2022 = (0);
        for (; v2022 < (ArrayItems.Length); v2022++)
        {
            v2024 = (ArrayItems[v2022]);
            if (!(v2023.Add((v2024))))
                continue;
            if (v2025 == null)
                v2025 = (v2024);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2025 == null)
            return default(int);
        else
            return (int)v2025;
    }

    int ArraySingleOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2027;
        int? v2028;
        v2028 = null;
        v2027 = (0);
        for (; v2027 < (ArrayItems.Length); v2027++)
            if (((ArrayItems[v2027]) > a))
                if (v2028 == null)
                    v2028 = (ArrayItems[v2027]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2028 == null)
            return default(int);
        else
            return (int)v2028;
    }

    int ArraySingleOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2029;
        int? v2030;
        v2030 = null;
        v2029 = (0);
        for (; v2029 < (ArrayItems.Length); v2029++)
            if (((ArrayItems[v2029]) > a--))
                if (v2030 == null)
                    v2030 = (ArrayItems[v2029]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        if (v2030 == null)
            return default(int);
        else
            return (int)v2030;
    }

    int ArraySingleOrDefaultUsingSingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2032;
        int? v2033;
        int v2034;
        v2033 = null;
        v2032 = (0);
        for (; v2032 < (ArrayItems.Length); v2032++)
        {
            v2034 = (ArrayItems[v2032]);
            if ((v2034 > ArrayItems.SingleOrDefault(y => y > v2034)))
                if (v2033 == null)
                    v2033 = (ArrayItems[v2032]);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2033 == null)
            return default(int);
        else
            return (int)v2033;
    }
}}