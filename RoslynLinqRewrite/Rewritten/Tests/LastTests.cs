using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class LastTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(Last), Last, LastRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableLast), EnumerableLast, EnumerableLastRewritten);
        TestsExtensions.TestEquals(nameof(LastCondition), LastCondition, LastConditionRewritten);
        TestsExtensions.TestEquals(nameof(LastFalseCondition), LastFalseCondition, LastFalseConditionRewritten);
        TestsExtensions.TestEquals(nameof(LastMethod), LastMethod, LastMethodRewritten);
        TestsExtensions.TestEquals(nameof(LastWhereMethod), LastWhereMethod, LastWhereMethodRewritten);
        TestsExtensions.TestEquals(nameof(SelectLastMethod), SelectLastMethod, SelectLastMethodRewritten);
        TestsExtensions.TestEquals(nameof(RangeLast), RangeLast, RangeLastRewritten);
        TestsExtensions.TestEquals(nameof(Range1Last), Range1Last, Range1LastRewritten);
        TestsExtensions.TestEquals(nameof(RangeRepeat), RangeRepeat, RangeRepeatRewritten);
        TestsExtensions.TestEquals(nameof(EmptyLast), EmptyLast, EmptyLastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctLast), ArrayDistinctLast, ArrayDistinctLastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastParam), ArrayLastParam, ArrayLastParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastChangingParam), ArrayLastChangingParam, ArrayLastChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLastUsingLast), ArrayLastUsingLast, ArrayLastUsingLastRewritten);
    }

    [NoRewrite]
    public int Last()
    {
        return ArrayItems.Last();
    } //EndMethod

    public int LastRewritten()
    {
        return ArrayItems[(ArrayItems.Length - 1)];
    } //EndMethod

    [NoRewrite]
    public int EnumerableLast()
    {
        return EnumerableItems.Last();
    } //EndMethod

    public int EnumerableLastRewritten()
    {
        return EnumerableLastRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int LastCondition()
    {
        return ArrayItems.Last(x => x > 30);
    } //EndMethod

    public int LastConditionRewritten()
    {
        return LastConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastFalseCondition()
    {
        return ArrayItems.Last(x => x > 105);
    } //EndMethod

    public int LastFalseConditionRewritten()
    {
        return LastFalseConditionRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastMethod()
    {
        return ArrayItems.Last(Predicate);
    } //EndMethod

    public int LastMethodRewritten()
    {
        return LastMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int LastWhereMethod()
    {
        return ArrayItems.Where(x => x > 10).Last();
    } //EndMethod

    public int LastWhereMethodRewritten()
    {
        return LastWhereMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int SelectLastMethod()
    {
        return ArrayItems.Select(x => x + 10).Last();
    } //EndMethod

    public int SelectLastMethodRewritten()
    {
        return SelectLastMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int RangeLast()
    {
        return Enumerable.Range(0, 100).Last();
    } //EndMethod

    public int RangeLastRewritten()
    {
        return RangeLastRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int Range1Last()
    {
        return Enumerable.Range(0, 1).Last();
    } //EndMethod

    public int Range1LastRewritten()
    {
        return Range1LastRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RangeRepeat()
    {
        return Enumerable.Repeat(0, 100).Last();
    } //EndMethod

    public int RangeRepeatRewritten()
    {
        return RangeRepeatRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int EmptyLast()
    {
        return Enumerable.Empty<int>().Last();
    } //EndMethod

    public int EmptyLastRewritten()
    {
        return EmptyLastRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int ArrayDistinctLast()
    {
        return ArrayItems.Distinct().Last();
    } //EndMethod

    public int ArrayDistinctLastRewritten()
    {
        return ArrayDistinctLastRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastParam()
    {
        var a = 50;
        return ArrayItems.Last(x => x > a);
    } //EndMethod

    public int ArrayLastParamRewritten()
    {
        var a = 50;
        return ArrayLastParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastChangingParam()
    {
        var a = 100;
        return ArrayItems.Last(x => x > a--);
    } //EndMethod

    public int ArrayLastChangingParamRewritten()
    {
        var a = 100;
        return ArrayLastChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayLastUsingLast()
    {
        var a = 100;
        return ArrayItems.Last(x => x > ArrayItems.Last(y => y > x));
    } //EndMethod

    public int ArrayLastUsingLastRewritten()
    {
        var a = 100;
        return ArrayLastUsingLastRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int EnumerableLastRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1201;
        int? v1202;
        v1201 = EnumerableItems.GetEnumerator();
        v1202 = null;
        try
        {
            while (v1201.MoveNext())
                v1202 = v1201.Current;
        }
        finally
        {
            v1201.Dispose();
        }

        if (v1202 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1202;
    }

    int LastConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1203;
        int? v1204;
        v1204 = null;
        v1203 = 0;
        for (; v1203 < ArrayItems.Length; v1203++)
            if ((ArrayItems[v1203] > 30))
                v1204 = ArrayItems[v1203];
        if (v1204 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1204;
    }

    int LastFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1205;
        int? v1206;
        v1206 = null;
        v1205 = 0;
        for (; v1205 < ArrayItems.Length; v1205++)
            if ((ArrayItems[v1205] > 105))
                v1206 = ArrayItems[v1205];
        if (v1206 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1206;
    }

    int LastMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1207;
        int? v1208;
        v1208 = null;
        v1207 = 0;
        for (; v1207 < ArrayItems.Length; v1207++)
            if (Predicate(ArrayItems[v1207]))
                v1208 = ArrayItems[v1207];
        if (v1208 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1208;
    }

    int LastWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1209;
        int? v1210;
        v1210 = null;
        v1209 = 0;
        for (; v1209 < ArrayItems.Length; v1209++)
        {
            if (!((ArrayItems[v1209] > 10)))
                continue;
            v1210 = ArrayItems[v1209];
        }

        if (v1210 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1210;
    }

    int SelectLastMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1211;
        int? v1212;
        v1212 = null;
        v1211 = 0;
        for (; v1211 < ArrayItems.Length; v1211++)
            v1212 = (ArrayItems[v1211] + 10);
        if (v1212 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1212;
    }

    int RangeLastRewritten_ProceduralLinq1()
    {
        int v1213;
        int? v1214;
        v1214 = null;
        v1213 = 0;
        for (; v1213 < 100; v1213++)
            v1214 = (v1213 + 0);
        if (v1214 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1214;
    }

    int Range1LastRewritten_ProceduralLinq1()
    {
        int v1215;
        int? v1216;
        v1216 = null;
        v1215 = 0;
        for (; v1215 < 1; v1215++)
            v1216 = (v1215 + 0);
        if (v1216 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1216;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1217;
        int? v1218;
        v1218 = null;
        v1217 = 0;
        for (; v1217 < 100; v1217++)
            v1218 = 0;
        if (v1218 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1218;
    }

    int EmptyLastRewritten_ProceduralLinq1()
    {
        int v1219;
        int? v1220;
        v1220 = null;
        v1219 = 0;
        for (; v1219 < 0; v1219++)
            v1220 = default(int);
        if (v1220 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1220;
    }

    int ArrayDistinctLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1221;
        HashSet<int> v1222;
        int? v1223;
        v1222 = new HashSet<int>();
        v1223 = null;
        v1221 = 0;
        for (; v1221 < ArrayItems.Length; v1221++)
        {
            if (!(v1222.Add(ArrayItems[v1221])))
                continue;
            v1223 = ArrayItems[v1221];
        }

        if (v1223 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1223;
    }

    int ArrayLastParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1224;
        int? v1225;
        v1225 = null;
        v1224 = 0;
        for (; v1224 < ArrayItems.Length; v1224++)
            if ((ArrayItems[v1224] > a))
                v1225 = ArrayItems[v1224];
        if (v1225 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1225;
    }

    int ArrayLastChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1226;
        int? v1227;
        v1227 = null;
        v1226 = 0;
        for (; v1226 < ArrayItems.Length; v1226++)
            if ((ArrayItems[v1226] > a--))
                v1227 = ArrayItems[v1226];
        if (v1227 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1227;
    }

    int ArrayLastUsingLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1228;
        int? v1229;
        v1229 = null;
        v1228 = 0;
        for (; v1228 < ArrayItems.Length; v1228++)
            if ((ArrayItems[v1228] > ArrayItems.Last(y => y > ArrayItems[v1228])))
                v1229 = ArrayItems[v1228];
        if (v1229 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1229;
    }
}}