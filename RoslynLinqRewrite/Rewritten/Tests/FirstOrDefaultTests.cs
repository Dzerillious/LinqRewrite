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
        return ArrayItems.Length == 0 ? default(int) : ArrayItems[0];
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
        return SelectFirstOrDefaultMethodRewritten_ProceduralLinq1(ArrayItems);
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
        return ArrayFirstOrDefaultUsingFirstOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int EnumerableFirstOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v859;
        v859 = EnumerableItems.GetEnumerator();
        try
        {
            while (v859.MoveNext())
                return v859.Current;
        }
        finally
        {
            v859.Dispose();
        }

        return default(int);
    }

    int FirstOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v860;
        v860 = 0;
        for (; v860 < ArrayItems.Length; v860++)
            if ((ArrayItems[v860] > 30))
                return ArrayItems[v860];
        return default(int);
    }

    int FirstOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v861;
        v861 = 0;
        for (; v861 < ArrayItems.Length; v861++)
            if ((ArrayItems[v861] > 105))
                return ArrayItems[v861];
        return default(int);
    }

    int FirstOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v862;
        v862 = 0;
        for (; v862 < ArrayItems.Length; v862++)
            if (Predicate(ArrayItems[v862]))
                return ArrayItems[v862];
        return default(int);
    }

    int FirstOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v863;
        v863 = 0;
        for (; v863 < ArrayItems.Length; v863++)
        {
            if (!((ArrayItems[v863] > 10)))
                continue;
            return ArrayItems[v863];
        }

        return default(int);
    }

    int SelectFirstOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v864;
        v864 = 0;
        for (; v864 < ArrayItems.Length; v864++)
            return (ArrayItems[v864] + 10);
        return default(int);
    }

    int RangeFirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v865;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v865 = 0;
        for (; v865 < 100; v865++)
            return (v865 + 0);
        return default(int);
    }

    int Range1FirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v866;
        if (1 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v866 = 0;
        for (; v866 < 1; v866++)
            return (v866 + 0);
        return default(int);
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v867;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v867 = 0;
        for (; v867 < 100; v867++)
            return 0;
        return default(int);
    }

    int EmptyFirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v868;
        v868 = 0;
        for (; v868 < 0; v868++)
            return default(int);
        return default(int);
    }

    int ArrayDistinctFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v869;
        HashSet<int> v870;
        v870 = new HashSet<int>();
        v869 = 0;
        for (; v869 < ArrayItems.Length; v869++)
        {
            if (!(v870.Add(ArrayItems[v869])))
                continue;
            return ArrayItems[v869];
        }

        return default(int);
    }

    int ArrayFirstOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v871;
        v871 = 0;
        for (; v871 < ArrayItems.Length; v871++)
            if ((ArrayItems[v871] > a))
                return ArrayItems[v871];
        return default(int);
    }

    int ArrayFirstOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v872;
        v872 = 0;
        for (; v872 < ArrayItems.Length; v872++)
            if ((ArrayItems[v872] > a--))
                return ArrayItems[v872];
        return default(int);
    }

    int ArrayFirstOrDefaultUsingFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v873;
        v873 = 0;
        for (; v873 < ArrayItems.Length; v873++)
            if ((ArrayItems[v873] > ArrayItems.FirstOrDefault(y => y > ArrayItems[v873])))
                return ArrayItems[v873];
        return default(int);
    }
}}