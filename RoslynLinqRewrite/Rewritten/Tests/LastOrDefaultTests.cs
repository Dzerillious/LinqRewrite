using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class LastOrDefaultTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(LastOrDefault), LastOrDefault, LastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableLastOrDefault), EnumerableLastOrDefault, EnumerableLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(LastOrDefaultCondition), LastOrDefaultCondition, LastOrDefaultConditionRewritten);
        TestsExtensions.TestEquals(nameof(LastOrDefaultFalseCondition), LastOrDefaultFalseCondition, LastOrDefaultFalseConditionRewritten);
        TestsExtensions.TestEquals(nameof(LastOrDefaultMethod), LastOrDefaultMethod, LastOrDefaultMethodRewritten);
        TestsExtensions.TestEquals(nameof(LastOrDefaultWhereMethod), LastOrDefaultWhereMethod, LastOrDefaultWhereMethodRewritten);
        TestsExtensions.TestEquals(nameof(SelectLastOrDefaultMethod), SelectLastOrDefaultMethod, SelectLastOrDefaultMethodRewritten);
        TestsExtensions.TestEquals(nameof(RangeLastOrDefault), RangeLastOrDefault, RangeLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(Range1LastOrDefault), Range1LastOrDefault, Range1LastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
        TestsExtensions.TestEquals(nameof(EmptyLastOrDefault), EmptyLastOrDefault, EmptyLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctLastOrDefault), ArrayDistinctLastOrDefault, ArrayDistinctLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultParam), ArrayLastOrDefaultParam, ArrayLastOrDefaultParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultChangingParam), ArrayLastOrDefaultChangingParam, ArrayLastOrDefaultChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastOrDefaultUsingLastOrDefault), ArrayLastOrDefaultUsingLastOrDefault, ArrayLastOrDefaultUsingLastOrDefaultRewritten);
    }

    [NoRewrite]
    public int LastOrDefault()
    {
        return ArrayItems.LastOrDefault();
    } //EndMethod

    public int LastOrDefaultRewritten()
    {
        return ArrayItems.Length == 0 ? default(int) : ArrayItems[(ArrayItems.Length - 1)];
    } //EndMethod

    [NoRewrite]
    public int EnumerableLastOrDefault()
    {
        return EnumerableItems.LastOrDefault();
    } //EndMethod

    public int EnumerableLastOrDefaultRewritten()
    {
        return EnumerableLastOrDefaultRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int LastOrDefaultCondition()
    {
        return ArrayItems.LastOrDefault(x => x > 30);
    } //EndMethod

    public int LastOrDefaultConditionRewritten()
    {
        return LastOrDefaultConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastOrDefaultFalseCondition()
    {
        return ArrayItems.LastOrDefault(x => x > 105);
    } //EndMethod

    public int LastOrDefaultFalseConditionRewritten()
    {
        return LastOrDefaultFalseConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastOrDefaultMethod()
    {
        return ArrayItems.LastOrDefault(Predicate);
    } //EndMethod

    public int LastOrDefaultMethodRewritten()
    {
        return LastOrDefaultMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastOrDefaultWhereMethod()
    {
        return ArrayItems.Where(x => x > 10).LastOrDefault();
    } //EndMethod

    public int LastOrDefaultWhereMethodRewritten()
    {
        return LastOrDefaultWhereMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SelectLastOrDefaultMethod()
    {
        return ArrayItems.Select(x => x + 10).LastOrDefault();
    } //EndMethod

    public int SelectLastOrDefaultMethodRewritten()
    {
        return SelectLastOrDefaultMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int RangeLastOrDefault()
    {
        return Enumerable.Range(0, 100).LastOrDefault();
    } //EndMethod

    public int RangeLastOrDefaultRewritten()
    {
        return RangeLastOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int Range1LastOrDefault()
    {
        return Enumerable.Range(0, 1).LastOrDefault();
    } //EndMethod

    public int Range1LastOrDefaultRewritten()
    {
        return Range1LastOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RangeRepeat()
    {
        return Enumerable.Repeat(0, 100).LastOrDefault();
    } //EndMethod

    public int RangeRepeatRewritten()
    {
        return RangeRepeatRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int EmptyLastOrDefault()
    {
        return Enumerable.Empty<int>().LastOrDefault();
    } //EndMethod

    public int EmptyLastOrDefaultRewritten()
    {
        return EmptyLastOrDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int ArrayDistinctLastOrDefault()
    {
        return ArrayItems.Distinct().LastOrDefault();
    } //EndMethod

    public int ArrayDistinctLastOrDefaultRewritten()
    {
        return ArrayDistinctLastOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastOrDefaultParam()
    {
        var a = 50;
        return ArrayItems.LastOrDefault(x => x > a);
    } //EndMethod

    public int ArrayLastOrDefaultParamRewritten()
    {
        var a = 50;
        return ArrayLastOrDefaultParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastOrDefaultChangingParam()
    {
        var a = 100;
        return ArrayItems.LastOrDefault(x => x > a--);
    } //EndMethod

    public int ArrayLastOrDefaultChangingParamRewritten()
    {
        var a = 100;
        return ArrayLastOrDefaultChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastOrDefaultUsingLastOrDefault()
    {
        var a = 100;
        return ArrayItems.LastOrDefault(x => x > ArrayItems.LastOrDefault(y => y > x));
    } //EndMethod

    public int ArrayLastOrDefaultUsingLastOrDefaultRewritten()
    {
        var a = 100;
        return ArrayLastOrDefaultUsingLastOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int EnumerableLastOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1198;
        int? v1199;
        v1198 = EnumerableItems.GetEnumerator();
        v1199 = null;
        try
        {
            while (v1198.MoveNext())
                v1199 = v1198.Current;
        }
        finally
        {
            v1198.Dispose();
        }

        if (v1199 == null)
            return default(int);
        else
            return (int)v1199;
    }

    int LastOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1200;
        int? v1201;
        v1201 = null;
        v1200 = 0;
        for (; v1200 < ArrayItems.Length; v1200++)
            if ((ArrayItems[v1200] > 30))
                v1201 = ArrayItems[v1200];
        if (v1201 == null)
            return default(int);
        else
            return (int)v1201;
    }

    int LastOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1202;
        int? v1203;
        v1203 = null;
        v1202 = 0;
        for (; v1202 < ArrayItems.Length; v1202++)
            if ((ArrayItems[v1202] > 105))
                v1203 = ArrayItems[v1202];
        if (v1203 == null)
            return default(int);
        else
            return (int)v1203;
    }

    int LastOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1204;
        int? v1205;
        v1205 = null;
        v1204 = 0;
        for (; v1204 < ArrayItems.Length; v1204++)
            if (Predicate(ArrayItems[v1204]))
                v1205 = ArrayItems[v1204];
        if (v1205 == null)
            return default(int);
        else
            return (int)v1205;
    }

    int LastOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1206;
        int? v1207;
        v1207 = null;
        v1206 = 0;
        for (; v1206 < ArrayItems.Length; v1206++)
        {
            if (!((ArrayItems[v1206] > 10)))
                continue;
            v1207 = ArrayItems[v1206];
        }

        if (v1207 == null)
            return default(int);
        else
            return (int)v1207;
    }

    int SelectLastOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1208;
        int? v1209;
        v1209 = null;
        v1208 = 0;
        for (; v1208 < ArrayItems.Length; v1208++)
            v1209 = (ArrayItems[v1208] + 10);
        if (v1209 == null)
            return default(int);
        else
            return (int)v1209;
    }

    int RangeLastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1210;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1211;
        v1211 = null;
        v1210 = 0;
        for (; v1210 < 100; v1210++)
            v1211 = (v1210 + 0);
        if (v1211 == null)
            return default(int);
        else
            return (int)v1211;
    }

    int Range1LastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1212;
        if (1 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1213;
        v1213 = null;
        v1212 = 0;
        for (; v1212 < 1; v1212++)
            v1213 = (v1212 + 0);
        if (v1213 == null)
            return default(int);
        else
            return (int)v1213;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1214;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1215;
        v1215 = null;
        v1214 = 0;
        for (; v1214 < 100; v1214++)
            v1215 = 0;
        if (v1215 == null)
            return default(int);
        else
            return (int)v1215;
    }

    int EmptyLastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1216;
        int? v1217;
        v1217 = null;
        v1216 = 0;
        for (; v1216 < 0; v1216++)
            v1217 = default(int);
        if (v1217 == null)
            return default(int);
        else
            return (int)v1217;
    }

    int ArrayDistinctLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1218;
        HashSet<int> v1219;
        int? v1220;
        v1219 = new HashSet<int>();
        v1220 = null;
        v1218 = 0;
        for (; v1218 < ArrayItems.Length; v1218++)
        {
            if (!(v1219.Add(ArrayItems[v1218])))
                continue;
            v1220 = ArrayItems[v1218];
        }

        if (v1220 == null)
            return default(int);
        else
            return (int)v1220;
    }

    int ArrayLastOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1221;
        int? v1222;
        v1222 = null;
        v1221 = 0;
        for (; v1221 < ArrayItems.Length; v1221++)
            if ((ArrayItems[v1221] > a))
                v1222 = ArrayItems[v1221];
        if (v1222 == null)
            return default(int);
        else
            return (int)v1222;
    }

    int ArrayLastOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1223;
        int? v1224;
        v1224 = null;
        v1223 = 0;
        for (; v1223 < ArrayItems.Length; v1223++)
            if ((ArrayItems[v1223] > a--))
                v1224 = ArrayItems[v1223];
        if (v1224 == null)
            return default(int);
        else
            return (int)v1224;
    }

    int ArrayLastOrDefaultUsingLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1225;
        int? v1226;
        v1226 = null;
        v1225 = 0;
        for (; v1225 < ArrayItems.Length; v1225++)
            if ((ArrayItems[v1225] > ArrayItems.LastOrDefault(y => y > ArrayItems[v1225])))
                v1226 = ArrayItems[v1225];
        if (v1226 == null)
            return default(int);
        else
            return (int)v1226;
    }
}}