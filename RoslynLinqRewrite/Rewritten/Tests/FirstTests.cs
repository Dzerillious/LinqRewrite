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
        IEnumerator<int> v852;
        v852 = EnumerableItems.GetEnumerator();
        try
        {
            while (v852.MoveNext())
                return v852.Current;
        }
        finally
        {
            v852.Dispose();
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v853;
        v853 = 0;
        for (; v853 < ArrayItems.Length; v853++)
            if ((ArrayItems[v853] > 30))
                return ArrayItems[v853];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v854;
        v854 = 0;
        for (; v854 < ArrayItems.Length; v854++)
            if ((ArrayItems[v854] > 105))
                return ArrayItems[v854];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v855;
        v855 = 0;
        for (; v855 < ArrayItems.Length; v855++)
            if (Predicate(ArrayItems[v855]))
                return ArrayItems[v855];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int FirstWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v856;
        v856 = 0;
        for (; v856 < ArrayItems.Length; v856++)
        {
            if (!((ArrayItems[v856] > 10)))
                continue;
            return ArrayItems[v856];
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int RangeFirstRewritten_ProceduralLinq1()
    {
        int v857;
        v857 = 0;
        for (; v857 < 100; v857++)
            return (v857 + 0);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int Range1FirstRewritten_ProceduralLinq1()
    {
        int v858;
        v858 = 0;
        for (; v858 < 1; v858++)
            return (v858 + 0);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v859;
        v859 = 0;
        for (; v859 < 100; v859++)
            return 0;
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int EmptyFirstRewritten_ProceduralLinq1()
    {
        int v860;
        v860 = 0;
        for (; v860 < 0; v860++)
            return default(int);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayDistinctFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v861;
        HashSet<int> v862;
        v862 = new HashSet<int>();
        v861 = 0;
        for (; v861 < ArrayItems.Length; v861++)
        {
            if (!(v862.Add(ArrayItems[v861])))
                continue;
            return ArrayItems[v861];
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v863;
        v863 = 0;
        for (; v863 < ArrayItems.Length; v863++)
            if ((ArrayItems[v863] > a))
                return ArrayItems[v863];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v864;
        v864 = 0;
        for (; v864 < ArrayItems.Length; v864++)
            if ((ArrayItems[v864] > a--))
                return ArrayItems[v864];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayFirstUsingFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v865;
        v865 = 0;
        for (; v865 < ArrayItems.Length; v865++)
            if ((ArrayItems[v865] > ArrayItems.First(y => y > ArrayItems[v865])))
                return ArrayItems[v865];
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }
}}