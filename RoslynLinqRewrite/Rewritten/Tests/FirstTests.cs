using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class FirstTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(First), First, FirstRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableFirst), EnumerableFirst, EnumerableFirstRewritten);
        TestsExtensions.TestEquals(nameof(FirstCondition), FirstCondition, FirstConditionRewritten);
        TestsExtensions.TestEquals(nameof(FirstFalseCondition), FirstFalseCondition, FirstFalseConditionRewritten);
        TestsExtensions.TestEquals(nameof(FirstMethod), FirstMethod, FirstMethodRewritten);
        TestsExtensions.TestEquals(nameof(FirstWhereMethod), FirstWhereMethod, FirstWhereMethodRewritten);
        TestsExtensions.TestEquals(nameof(SelectFirstMethod), SelectFirstMethod, SelectFirstMethodRewritten);
        TestsExtensions.TestEquals(nameof(RangeFirst), RangeFirst, RangeFirstRewritten);
        TestsExtensions.TestEquals(nameof(Range1First), Range1First, Range1FirstRewritten);
        TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
        TestsExtensions.TestEquals(nameof(EmptyFirst), EmptyFirst, EmptyFirstRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctFirst), ArrayDistinctFirst, ArrayDistinctFirstRewritten);
        TestsExtensions.TestEquals(nameof(ArrayFirstParam), ArrayFirstParam, ArrayFirstParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayFirstChangingParam), ArrayFirstChangingParam, ArrayFirstChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayFirstUsingFirst), ArrayFirstUsingFirst, ArrayFirstUsingFirstRewritten);
    }

    [NoRewrite]
    public int First()
    {
        return ArrayItems.First();
    } //EndMethod

    public int FirstRewritten()
    {
        return ArrayItems[0];
    } //EndMethod

    [NoRewrite]
    public int EnumerableFirst()
    {
        return EnumerableItems.First();
    } //EndMethod

    public int EnumerableFirstRewritten()
    {
        return EnumerableFirstRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int FirstCondition()
    {
        return ArrayItems.First(x => x > 30);
    } //EndMethod

    public int FirstConditionRewritten()
    {
        return FirstConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int FirstFalseCondition()
    {
        return ArrayItems.First(x => x > 105);
    } //EndMethod

    public int FirstFalseConditionRewritten()
    {
        return FirstFalseConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int FirstMethod()
    {
        return ArrayItems.First(Predicate);
    } //EndMethod

    public int FirstMethodRewritten()
    {
        return FirstMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int FirstWhereMethod()
    {
        return ArrayItems.Where(x => x > 10).First();
    } //EndMethod

    public int FirstWhereMethodRewritten()
    {
        return FirstWhereMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SelectFirstMethod()
    {
        return ArrayItems.Select(x => x + 10).First();
    } //EndMethod

    public int SelectFirstMethodRewritten()
    {
        return 10 + ArrayItems[0];
    } //EndMethod

    [NoRewrite]
    public int RangeFirst()
    {
        return Enumerable.Range(0, 100).First();
    } //EndMethod

    public int RangeFirstRewritten()
    {
        return RangeFirstRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int Range1First()
    {
        return Enumerable.Range(0, 1).First();
    } //EndMethod

    public int Range1FirstRewritten()
    {
        return Range1FirstRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RangeRepeat()
    {
        return Enumerable.Repeat(0, 100).First();
    } //EndMethod

    public int RangeRepeatRewritten()
    {
        return RangeRepeatRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int EmptyFirst()
    {
        return Enumerable.Empty<int>().First();
    } //EndMethod

    public int EmptyFirstRewritten()
    {
        return EmptyFirstRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int ArrayDistinctFirst()
    {
        return ArrayItems.Distinct().First();
    } //EndMethod

    public int ArrayDistinctFirstRewritten()
    {
        return ArrayDistinctFirstRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayFirstParam()
    {
        var a = 50;
        return ArrayItems.First(x => x > a);
    } //EndMethod

    public int ArrayFirstParamRewritten()
    {
        var a = 50;
        return ArrayFirstParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayFirstChangingParam()
    {
        var a = 100;
        return ArrayItems.First(x => x > a--);
    } //EndMethod

    public int ArrayFirstChangingParamRewritten()
    {
        var a = 100;
        return ArrayFirstChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayFirstUsingFirst()
    {
        var a = 100;
        return ArrayItems.First(x => x > ArrayItems.First(y => y > x));
    } //EndMethod

    public int ArrayFirstUsingFirstRewritten()
    {
        var a = 100;
        return ArrayFirstUsingFirstRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int EnumerableFirstRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1056;
        int v1057;
        v1056 = EnumerableItems.GetEnumerator();
        v1057 = 0;
        try
        {
            while (v1056.MoveNext())
            {
                return (v1056.Current);
                v1057++;
            }
        }
        finally
        {
            v1056.Dispose();
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1059;
        v1059 = (0);
        for (; v1059 < (ArrayItems.Length); v1059++)
            if (((ArrayItems[v1059]) > 30))
                return (ArrayItems[v1059]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1061;
        v1061 = (0);
        for (; v1061 < (ArrayItems.Length); v1061++)
            if (((ArrayItems[v1061]) > 105))
                return (ArrayItems[v1061]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1063;
        v1063 = (0);
        for (; v1063 < (ArrayItems.Length); v1063++)
            if (Predicate((ArrayItems[v1063])))
                return (ArrayItems[v1063]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1064;
        int v1065;
        int v1066;
        v1066 = 0;
        v1064 = (0);
        for (; v1064 < (ArrayItems.Length); v1064++)
        {
            v1065 = (ArrayItems[v1064]);
            if (!(((v1065) > 10)))
                continue;
            return (v1065);
            v1066++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int RangeFirstRewritten_ProceduralLinq1()
    {
        int v1068;
        v1068 = (0);
        for (; v1068 < (100); v1068++)
            return (v1068);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int Range1FirstRewritten_ProceduralLinq1()
    {
        int v1069;
        v1069 = (0);
        for (; v1069 < (1); v1069++)
            return (v1069);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1070;
        v1070 = (0);
        for (; v1070 < (100); v1070++)
            return (0);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int EmptyFirstRewritten_ProceduralLinq1()
    {
        int v1071;
        v1071 = 0;
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayDistinctFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1072;
        HashSet<int> v1073;
        int v1074;
        int v1075;
        v1073 = new HashSet<int>();
        v1075 = 0;
        v1072 = (0);
        for (; v1072 < (ArrayItems.Length); v1072++)
        {
            v1074 = (ArrayItems[v1072]);
            if (!(v1073.Add((v1074))))
                continue;
            return (v1074);
            v1075++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1077;
        v1077 = (0);
        for (; v1077 < (ArrayItems.Length); v1077++)
            if (((ArrayItems[v1077]) > a))
                return (ArrayItems[v1077]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1078;
        v1078 = (0);
        for (; v1078 < (ArrayItems.Length); v1078++)
            if (((ArrayItems[v1078]) > a--))
                return (ArrayItems[v1078]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstUsingFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1080;
        int v1081;
        v1080 = (0);
        for (; v1080 < (ArrayItems.Length); v1080++)
        {
            v1081 = (ArrayItems[v1080]);
            if ((v1081 > ArrayItems.First(y => y > v1081)))
                return (ArrayItems[v1080]);
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }
}}