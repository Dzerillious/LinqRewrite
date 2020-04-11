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
        return (ArrayItems[(0)]);
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
        return 10 + ArrayItems[(0)];
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
        return ArrayFirstUsingFirstRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    int EnumerableFirstRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v941;
        int v942;
        v941 = EnumerableItems.GetEnumerator();
        v942 = 0;
        try
        {
            while (v941.MoveNext())
            {
                return (v941.Current);
                v942++;
            }
        }
        finally
        {
            v941.Dispose();
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v944;
        v944 = (0);
        for (; v944 < (ArrayItems.Length); v944 += 1)
            if (((ArrayItems[v944]) > 30))
                return (ArrayItems[v944]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v946;
        v946 = (0);
        for (; v946 < (ArrayItems.Length); v946 += 1)
            if (((ArrayItems[v946]) > 105))
                return (ArrayItems[v946]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v948;
        v948 = (0);
        for (; v948 < (ArrayItems.Length); v948 += 1)
            if (Predicate((ArrayItems[v948])))
                return (ArrayItems[v948]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v949;
        int v950;
        v950 = 0;
        v949 = (0);
        for (; v949 < (ArrayItems.Length); v949 += 1)
        {
            if (!((((ArrayItems[v949])) > 10)))
                continue;
            return ((ArrayItems[v949]));
            v950++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int RangeFirstRewritten_ProceduralLinq1()
    {
        int v952;
        v952 = (0);
        for (; v952 < (100); v952 += (1))
            return (v952);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int Range1FirstRewritten_ProceduralLinq1()
    {
        int v953;
        v953 = (0);
        for (; v953 < (1); v953 += (1))
            return (v953);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v954;
        v954 = (0);
        for (; v954 < (100); v954 += 1)
            return (0);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int EmptyFirstRewritten_ProceduralLinq1()
    {
        int v955;
        v955 = 0;
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayDistinctFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v956;
        HashSet<int> v957;
        int v958;
        v957 = new HashSet<int>();
        v958 = 0;
        v956 = (0);
        for (; v956 < (ArrayItems.Length); v956 += 1)
        {
            if (!(v957.Add(((ArrayItems[v956])))))
                continue;
            return ((ArrayItems[v956]));
            v958++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v960;
        v960 = (0);
        for (; v960 < (ArrayItems.Length); v960 += 1)
            if (((ArrayItems[v960]) > a))
                return (ArrayItems[v960]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v961;
        v961 = (0);
        for (; v961 < (ArrayItems.Length); v961 += 1)
            if (((ArrayItems[v961]) > a--))
                return (ArrayItems[v961]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstUsingFirstRewritten_ProceduralLinq1(int x, int[] ArrayItems)
    {
        int v963;
        v963 = (0);
        for (; v963 < (ArrayItems.Length); v963 += 1)
            if (((ArrayItems[v963]) > x))
                return (ArrayItems[v963]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstUsingFirstRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v965;
        v965 = (0);
        for (; v965 < (ArrayItems.Length); v965 += 1)
            if (((ArrayItems[v965]) > ArrayFirstUsingFirstRewritten_ProceduralLinq1((ArrayItems[v965]), ArrayItems)))
                return (ArrayItems[v965]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }
}}