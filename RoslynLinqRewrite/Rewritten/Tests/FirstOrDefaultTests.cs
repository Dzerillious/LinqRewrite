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
        IEnumerator<int> v836;
        v836 = EnumerableItems.GetEnumerator();
        try
        {
            while (v836.MoveNext())
                return v836.Current;
        }
        finally
        {
            v836.Dispose();
        }

        return default(int);
    }

    int FirstOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v837;
        v837 = 0;
        for (; v837 < ArrayItems.Length; v837++)
            if ((ArrayItems[v837] > 30))
                return ArrayItems[v837];
        return default(int);
    }

    int FirstOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v838;
        v838 = 0;
        for (; v838 < ArrayItems.Length; v838++)
            if ((ArrayItems[v838] > 105))
                return ArrayItems[v838];
        return default(int);
    }

    int FirstOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v839;
        v839 = 0;
        for (; v839 < ArrayItems.Length; v839++)
            if (Predicate(ArrayItems[v839]))
                return ArrayItems[v839];
        return default(int);
    }

    int FirstOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v840;
        v840 = 0;
        for (; v840 < ArrayItems.Length; v840++)
        {
            if (!((ArrayItems[v840] > 10)))
                continue;
            return ArrayItems[v840];
        }

        return default(int);
    }

    int SelectFirstOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v841;
        v841 = 0;
        for (; v841 < ArrayItems.Length; v841++)
            return (ArrayItems[v841] + 10);
        return default(int);
    }

    int RangeFirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v842;
        v842 = 0;
        for (; v842 < 100; v842++)
            return (v842 + 0);
        return default(int);
    }

    int Range1FirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v843;
        v843 = 0;
        for (; v843 < 1; v843++)
            return (v843 + 0);
        return default(int);
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v844;
        v844 = 0;
        for (; v844 < 100; v844++)
            return 0;
        return default(int);
    }

    int EmptyFirstOrDefaultRewritten_ProceduralLinq1()
    {
        int v845;
        v845 = 0;
        for (; v845 < 0; v845++)
            return default(int);
        return default(int);
    }

    int ArrayDistinctFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v846;
        HashSet<int> v847;
        v847 = new HashSet<int>();
        v846 = 0;
        for (; v846 < ArrayItems.Length; v846++)
        {
            if (!(v847.Add(ArrayItems[v846])))
                continue;
            return ArrayItems[v846];
        }

        return default(int);
    }

    int ArrayFirstOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v848;
        v848 = 0;
        for (; v848 < ArrayItems.Length; v848++)
            if ((ArrayItems[v848] > a))
                return ArrayItems[v848];
        return default(int);
    }

    int ArrayFirstOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v849;
        v849 = 0;
        for (; v849 < ArrayItems.Length; v849++)
            if ((ArrayItems[v849] > a--))
                return ArrayItems[v849];
        return default(int);
    }

    int ArrayFirstOrDefaultUsingFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v850;
        v850 = 0;
        for (; v850 < ArrayItems.Length; v850++)
            if ((ArrayItems[v850] > ArrayItems.FirstOrDefault(y => y > ArrayItems[v850])))
                return ArrayItems[v850];
        return default(int);
    }
}}