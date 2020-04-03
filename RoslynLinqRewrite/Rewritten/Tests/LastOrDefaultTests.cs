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
        IEnumerator<int> v1171;
        int? v1172;
        v1171 = EnumerableItems.GetEnumerator();
        v1172 = null;
        try
        {
            while (v1171.MoveNext())
                v1172 = v1171.Current;
        }
        finally
        {
            v1171.Dispose();
        }

        if (v1172 == null)
            return default(int);
        else
            return (int)v1172;
    }

    int LastOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1173;
        int? v1174;
        v1174 = null;
        v1173 = 0;
        for (; v1173 < ArrayItems.Length; v1173++)
            if ((ArrayItems[v1173] > 30))
                v1174 = ArrayItems[v1173];
        if (v1174 == null)
            return default(int);
        else
            return (int)v1174;
    }

    int LastOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1175;
        int? v1176;
        v1176 = null;
        v1175 = 0;
        for (; v1175 < ArrayItems.Length; v1175++)
            if ((ArrayItems[v1175] > 105))
                v1176 = ArrayItems[v1175];
        if (v1176 == null)
            return default(int);
        else
            return (int)v1176;
    }

    int LastOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1177;
        int? v1178;
        v1178 = null;
        v1177 = 0;
        for (; v1177 < ArrayItems.Length; v1177++)
            if (Predicate(ArrayItems[v1177]))
                v1178 = ArrayItems[v1177];
        if (v1178 == null)
            return default(int);
        else
            return (int)v1178;
    }

    int LastOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1179;
        int? v1180;
        v1180 = null;
        v1179 = 0;
        for (; v1179 < ArrayItems.Length; v1179++)
        {
            if (!((ArrayItems[v1179] > 10)))
                continue;
            v1180 = ArrayItems[v1179];
        }

        if (v1180 == null)
            return default(int);
        else
            return (int)v1180;
    }

    int SelectLastOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1181;
        int? v1182;
        v1182 = null;
        v1181 = 0;
        for (; v1181 < ArrayItems.Length; v1181++)
            v1182 = (ArrayItems[v1181] + 10);
        if (v1182 == null)
            return default(int);
        else
            return (int)v1182;
    }

    int RangeLastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1183;
        int? v1184;
        v1184 = null;
        v1183 = 0;
        for (; v1183 < 100; v1183++)
            v1184 = (v1183 + 0);
        if (v1184 == null)
            return default(int);
        else
            return (int)v1184;
    }

    int Range1LastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1185;
        int? v1186;
        v1186 = null;
        v1185 = 0;
        for (; v1185 < 1; v1185++)
            v1186 = (v1185 + 0);
        if (v1186 == null)
            return default(int);
        else
            return (int)v1186;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1187;
        int? v1188;
        v1188 = null;
        v1187 = 0;
        for (; v1187 < 100; v1187++)
            v1188 = 0;
        if (v1188 == null)
            return default(int);
        else
            return (int)v1188;
    }

    int EmptyLastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1189;
        int? v1190;
        v1190 = null;
        v1189 = 0;
        for (; v1189 < 0; v1189++)
            v1190 = default(int);
        if (v1190 == null)
            return default(int);
        else
            return (int)v1190;
    }

    int ArrayDistinctLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1191;
        HashSet<int> v1192;
        int? v1193;
        v1192 = new HashSet<int>();
        v1193 = null;
        v1191 = 0;
        for (; v1191 < ArrayItems.Length; v1191++)
        {
            if (!(v1192.Add(ArrayItems[v1191])))
                continue;
            v1193 = ArrayItems[v1191];
        }

        if (v1193 == null)
            return default(int);
        else
            return (int)v1193;
    }

    int ArrayLastOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1194;
        int? v1195;
        v1195 = null;
        v1194 = 0;
        for (; v1194 < ArrayItems.Length; v1194++)
            if ((ArrayItems[v1194] > a))
                v1195 = ArrayItems[v1194];
        if (v1195 == null)
            return default(int);
        else
            return (int)v1195;
    }

    int ArrayLastOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1196;
        int? v1197;
        v1197 = null;
        v1196 = 0;
        for (; v1196 < ArrayItems.Length; v1196++)
            if ((ArrayItems[v1196] > a--))
                v1197 = ArrayItems[v1196];
        if (v1197 == null)
            return default(int);
        else
            return (int)v1197;
    }

    int ArrayLastOrDefaultUsingLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1198;
        int? v1199;
        v1199 = null;
        v1198 = 0;
        for (; v1198 < ArrayItems.Length; v1198++)
            if ((ArrayItems[v1198] > ArrayItems.LastOrDefault(y => y > ArrayItems[v1198])))
                v1199 = ArrayItems[v1198];
        if (v1199 == null)
            return default(int);
        else
            return (int)v1199;
    }
}}