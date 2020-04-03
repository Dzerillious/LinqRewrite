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
        return (ArrayItems[0] + 10);
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
        IEnumerator<int> v875;
        v875 = EnumerableItems.GetEnumerator();
        try
        {
            while (v875.MoveNext())
                return v875.Current;
        }
        finally
        {
            v875.Dispose();
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v876;
        v876 = 0;
        for (; v876 < ArrayItems.Length; v876++)
            if ((ArrayItems[v876] > 30))
                return ArrayItems[v876];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v877;
        v877 = 0;
        for (; v877 < ArrayItems.Length; v877++)
            if ((ArrayItems[v877] > 105))
                return ArrayItems[v877];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v878;
        v878 = 0;
        for (; v878 < ArrayItems.Length; v878++)
            if (Predicate(ArrayItems[v878]))
                return ArrayItems[v878];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v879;
        v879 = 0;
        for (; v879 < ArrayItems.Length; v879++)
        {
            if (!((ArrayItems[v879] > 10)))
                continue;
            return ArrayItems[v879];
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int RangeFirstRewritten_ProceduralLinq1()
    {
        int v880;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v880 = 0;
        for (; v880 < 100; v880++)
            return (v880 + 0);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int Range1FirstRewritten_ProceduralLinq1()
    {
        int v881;
        if (1 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v881 = 0;
        for (; v881 < 1; v881++)
            return (v881 + 0);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v882;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v882 = 0;
        for (; v882 < 100; v882++)
            return 0;
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int EmptyFirstRewritten_ProceduralLinq1()
    {
        int v883;
        v883 = 0;
        for (; v883 < 0; v883++)
            return default(int);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayDistinctFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v884;
        HashSet<int> v885;
        v885 = new HashSet<int>();
        v884 = 0;
        for (; v884 < ArrayItems.Length; v884++)
        {
            if (!(v885.Add(ArrayItems[v884])))
                continue;
            return ArrayItems[v884];
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v886;
        v886 = 0;
        for (; v886 < ArrayItems.Length; v886++)
            if ((ArrayItems[v886] > a))
                return ArrayItems[v886];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v887;
        v887 = 0;
        for (; v887 < ArrayItems.Length; v887++)
            if ((ArrayItems[v887] > a--))
                return ArrayItems[v887];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstUsingFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v888;
        v888 = 0;
        for (; v888 < ArrayItems.Length; v888++)
            if ((ArrayItems[v888] > ArrayItems.First(y => y > ArrayItems[v888])))
                return ArrayItems[v888];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }
}}