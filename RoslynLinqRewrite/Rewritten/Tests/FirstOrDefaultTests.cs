using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class FirstOrDefaultTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(FirstOrDefault), FirstOrDefault, FirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableFirstOrDefault), EnumerableFirstOrDefault, EnumerableFirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(FirstOrDefaultCondition), FirstOrDefaultCondition, FirstOrDefaultConditionRewritten);
        TestsExtensions.TestEquals(nameof(FirstOrDefaultFalseCondition), FirstOrDefaultFalseCondition, FirstOrDefaultFalseConditionRewritten);
        TestsExtensions.TestEquals(nameof(FirstOrDefaultMethod), FirstOrDefaultMethod, FirstOrDefaultMethodRewritten);
        TestsExtensions.TestEquals(nameof(FirstOrDefaultWhereMethod), FirstOrDefaultWhereMethod, FirstOrDefaultWhereMethodRewritten);
        TestsExtensions.TestEquals(nameof(SelectFirstOrDefaultMethod), SelectFirstOrDefaultMethod, SelectFirstOrDefaultMethodRewritten);
        TestsExtensions.TestEquals(nameof(RangeFirstOrDefault), RangeFirstOrDefault, RangeFirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(Range1FirstOrDefault), Range1FirstOrDefault, Range1FirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
        TestsExtensions.TestEquals(nameof(EmptyFirstOrDefault), EmptyFirstOrDefault, EmptyFirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctFirstOrDefault), ArrayDistinctFirstOrDefault, ArrayDistinctFirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayFirstOrDefaultParam), ArrayFirstOrDefaultParam, ArrayFirstOrDefaultParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayFirstOrDefaultChangingParam), ArrayFirstOrDefaultChangingParam, ArrayFirstOrDefaultChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayFirstOrDefaultUsingFirstOrDefault), ArrayFirstOrDefaultUsingFirstOrDefault, ArrayFirstOrDefaultUsingFirstOrDefaultRewritten);
    }

    [NoRewrite]
    public int FirstOrDefault()
    {
        return ArrayItems.FirstOrDefault();
    } //EndMethod

    public int FirstOrDefaultRewritten()
    {
        return ArrayItems.Length == 0 ? default(int) : (ArrayItems[(0)]);
    } //EndMethod

    [NoRewrite]
    public int EnumerableFirstOrDefault()
    {
        return EnumerableItems.FirstOrDefault();
    } //EndMethod

    public int EnumerableFirstOrDefaultRewritten()
    {
        return EnumerableFirstOrDefaultRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int FirstOrDefaultCondition()
    {
        return ArrayItems.FirstOrDefault(x => x > 30);
    } //EndMethod

    public int FirstOrDefaultConditionRewritten()
    {
        return FirstOrDefaultConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int FirstOrDefaultFalseCondition()
    {
        return ArrayItems.FirstOrDefault(x => x > 105);
    } //EndMethod

    public int FirstOrDefaultFalseConditionRewritten()
    {
        return FirstOrDefaultFalseConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int FirstOrDefaultMethod()
    {
        return ArrayItems.FirstOrDefault(Predicate);
    } //EndMethod

    public int FirstOrDefaultMethodRewritten()
    {
        return FirstOrDefaultMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int FirstOrDefaultWhereMethod()
    {
        return ArrayItems.Where(x => x > 10).FirstOrDefault();
    } //EndMethod

    public int FirstOrDefaultWhereMethodRewritten()
    {
        return FirstOrDefaultWhereMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SelectFirstOrDefaultMethod()
    {
        return ArrayItems.Select(x => x + 10).FirstOrDefault();
    } //EndMethod

    public int SelectFirstOrDefaultMethodRewritten()
    {
        return ArrayItems.Length == 0 ? default(int) : 10 + ArrayItems[(0)];
    } //EndMethod

    [NoRewrite]
    public int RangeFirstOrDefault()
    {
        return Enumerable.Range(0, 100).FirstOrDefault();
    } //EndMethod

    public int RangeFirstOrDefaultRewritten()
    {
        return RangeFirstOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int Range1FirstOrDefault()
    {
        return Enumerable.Range(0, 1).FirstOrDefault();
    } //EndMethod

    public int Range1FirstOrDefaultRewritten()
    {
        return Range1FirstOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RangeRepeat()
    {
        return Enumerable.Repeat(0, 100).FirstOrDefault();
    } //EndMethod

    public int RangeRepeatRewritten()
    {
        return RangeRepeatRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int EmptyFirstOrDefault()
    {
        return Enumerable.Empty<int>().FirstOrDefault();
    } //EndMethod

    public int EmptyFirstOrDefaultRewritten()
    {
        return EmptyFirstOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int ArrayDistinctFirstOrDefault()
    {
        return ArrayItems.Distinct().FirstOrDefault();
    } //EndMethod

    public int ArrayDistinctFirstOrDefaultRewritten()
    {
        return ArrayDistinctFirstOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayFirstOrDefaultParam()
    {
        var a = 50;
        return ArrayItems.FirstOrDefault(x => x > a);
    } //EndMethod

    public int ArrayFirstOrDefaultParamRewritten()
    {
        var a = 50;
        return ArrayFirstOrDefaultParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayFirstOrDefaultChangingParam()
    {
        var a = 100;
        return ArrayItems.FirstOrDefault(x => x > a--);
    } //EndMethod

    public int ArrayFirstOrDefaultChangingParamRewritten()
    {
        var a = 100;
        return ArrayFirstOrDefaultChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayFirstOrDefaultUsingFirstOrDefault()
    {
        var a = 100;
        return ArrayItems.FirstOrDefault(x => x > ArrayItems.FirstOrDefault(y => y > x));
    } //EndMethod

    public int ArrayFirstOrDefaultUsingFirstOrDefaultRewritten()
    {
        var a = 100;
        return ArrayFirstOrDefaultUsingFirstOrDefaultRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    int EnumerableFirstOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v918;
        v918 = EnumerableItems.GetEnumerator();
        try
        {
            while (v918.MoveNext())
                return (v918.Current);
        }
        finally
        {
            v918.Dispose();
        }

        return default(int);
    }

    int FirstOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v920;
        v920 = (0);
        for (; v920 < (ArrayItems.Length); v920 += 1)
            if (((ArrayItems[v920]) > 30))
                return (ArrayItems[v920]);
        return default(int);
    }

    int FirstOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v922;
        v922 = (0);
        for (; v922 < (ArrayItems.Length); v922 += 1)
            if (((ArrayItems[v922]) > 105))
                return (ArrayItems[v922]);
        return default(int);
    }

    int FirstOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v924;
        v924 = (0);
        for (; v924 < (ArrayItems.Length); v924 += 1)
            if (Predicate((ArrayItems[v924])))
                return (ArrayItems[v924]);
        return default(int);
    }

    int FirstOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v925;
        v925 = (0);
        for (; v925 < (ArrayItems.Length); v925 += 1)
        {
            if (!((((ArrayItems[v925])) > 10)))
                continue;
            return ((ArrayItems[v925]));
        }

        return default(int);
    }

    int RangeFirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v927;
        v927 = (0);
        for (; v927 < (100); v927 += (1))
            return (v927);
        return default(int);
    }

    int Range1FirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v928;
        v928 = (0);
        for (; v928 < (1); v928 += (1))
            return (v928);
        return default(int);
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v929;
        v929 = (0);
        for (; v929 < (100); v929 += 1)
            return (0);
        return default(int);
    }

    int EmptyFirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v930;
        v930 = 0;
        return default(int);
    }

    int ArrayDistinctFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v931;
        HashSet<int> v932;
        v932 = new HashSet<int>();
        v931 = (0);
        for (; v931 < (ArrayItems.Length); v931 += 1)
        {
            if (!(v932.Add(((ArrayItems[v931])))))
                continue;
            return ((ArrayItems[v931]));
        }

        return default(int);
    }

    int ArrayFirstOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v934;
        v934 = (0);
        for (; v934 < (ArrayItems.Length); v934 += 1)
            if (((ArrayItems[v934]) > a))
                return (ArrayItems[v934]);
        return default(int);
    }

    int ArrayFirstOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v935;
        v935 = (0);
        for (; v935 < (ArrayItems.Length); v935 += 1)
            if (((ArrayItems[v935]) > a--))
                return (ArrayItems[v935]);
        return default(int);
    }

    int ArrayFirstOrDefaultUsingFirstOrDefaultRewritten_ProceduralLinq1(int x, int[] ArrayItems)
    {
        int v937;
        v937 = (0);
        for (; v937 < (ArrayItems.Length); v937 += 1)
            if (((ArrayItems[v937]) > x))
                return (ArrayItems[v937]);
        return default(int);
    }

    int ArrayFirstOrDefaultUsingFirstOrDefaultRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v939;
        v939 = (0);
        for (; v939 < (ArrayItems.Length); v939 += 1)
            if (((ArrayItems[v939]) > ArrayFirstOrDefaultUsingFirstOrDefaultRewritten_ProceduralLinq1((ArrayItems[v939]), ArrayItems)))
                return (ArrayItems[v939]);
        return default(int);
    }
}}