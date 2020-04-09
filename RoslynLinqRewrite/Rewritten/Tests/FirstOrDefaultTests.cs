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
        return ArrayItems.Length == 0 ? default(int) : 10 + ArrayItems[0];
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
        IEnumerator<int> v1032;
        v1032 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1032.MoveNext())
                return (v1032.Current);
        }
        finally
        {
            v1032.Dispose();
        }

        return default(int);
    }

    int FirstOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1034;
        v1034 = (0);
        for (; v1034 < (ArrayItems.Length); v1034++)
            if (((ArrayItems[v1034]) > 30))
                return (ArrayItems[v1034]);
        return default(int);
    }

    int FirstOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1036;
        v1036 = (0);
        for (; v1036 < (ArrayItems.Length); v1036++)
            if (((ArrayItems[v1036]) > 105))
                return (ArrayItems[v1036]);
        return default(int);
    }

    int FirstOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1038;
        v1038 = (0);
        for (; v1038 < (ArrayItems.Length); v1038++)
            if (Predicate((ArrayItems[v1038])))
                return (ArrayItems[v1038]);
        return default(int);
    }

    int FirstOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1039;
        int v1040;
        v1039 = (0);
        for (; v1039 < (ArrayItems.Length); v1039++)
        {
            v1040 = (ArrayItems[v1039]);
            if (!(((v1040) > 10)))
                continue;
            return (v1040);
        }

        return default(int);
    }

    int RangeFirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v1042;
        v1042 = (0);
        for (; v1042 < (100); v1042++)
            return (v1042);
        return default(int);
    }

    int Range1FirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v1043;
        v1043 = (0);
        for (; v1043 < (1); v1043++)
            return (v1043);
        return default(int);
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1044;
        v1044 = (0);
        for (; v1044 < (100); v1044++)
            return (0);
        return default(int);
    }

    int EmptyFirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v1045;
        v1045 = 0;
        return default(int);
    }

    int ArrayDistinctFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1046;
        HashSet<int> v1047;
        int v1048;
        v1047 = new HashSet<int>();
        v1046 = (0);
        for (; v1046 < (ArrayItems.Length); v1046++)
        {
            v1048 = (ArrayItems[v1046]);
            if (!(v1047.Add((v1048))))
                continue;
            return (v1048);
        }

        return default(int);
    }

    int ArrayFirstOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1050;
        v1050 = (0);
        for (; v1050 < (ArrayItems.Length); v1050++)
            if (((ArrayItems[v1050]) > a))
                return (ArrayItems[v1050]);
        return default(int);
    }

    int ArrayFirstOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1051;
        v1051 = (0);
        for (; v1051 < (ArrayItems.Length); v1051++)
            if (((ArrayItems[v1051]) > a--))
                return (ArrayItems[v1051]);
        return default(int);
    }

    int ArrayFirstOrDefaultUsingFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1053;
        int v1054;
        v1053 = (0);
        for (; v1053 < (ArrayItems.Length); v1053++)
        {
            v1054 = (ArrayItems[v1053]);
            if ((v1054 > ArrayItems.FirstOrDefault(y => y > v1054)))
                return (ArrayItems[v1053]);
        }

        return default(int);
    }
}}