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
        IEnumerator<int> v1228;
        int? v1229;
        v1228 = EnumerableItems.GetEnumerator();
        v1229 = null;
        try
        {
            while (v1228.MoveNext())
                v1229 = v1228.Current;
        }
        finally
        {
            v1228.Dispose();
        }

        if (v1229 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1229;
    }

    int LastConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1230;
        int? v1231;
        v1231 = null;
        v1230 = 0;
        for (; v1230 < ArrayItems.Length; v1230++)
            if ((ArrayItems[v1230] > 30))
                v1231 = ArrayItems[v1230];
        if (v1231 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1231;
    }

    int LastFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1232;
        int? v1233;
        v1233 = null;
        v1232 = 0;
        for (; v1232 < ArrayItems.Length; v1232++)
            if ((ArrayItems[v1232] > 105))
                v1233 = ArrayItems[v1232];
        if (v1233 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1233;
    }

    int LastMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1234;
        int? v1235;
        v1235 = null;
        v1234 = 0;
        for (; v1234 < ArrayItems.Length; v1234++)
            if (Predicate(ArrayItems[v1234]))
                v1235 = ArrayItems[v1234];
        if (v1235 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1235;
    }

    int LastWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1236;
        int? v1237;
        v1237 = null;
        v1236 = 0;
        for (; v1236 < ArrayItems.Length; v1236++)
        {
            if (!((ArrayItems[v1236] > 10)))
                continue;
            v1237 = ArrayItems[v1236];
        }

        if (v1237 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1237;
    }

    int SelectLastMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1238;
        int? v1239;
        v1239 = null;
        v1238 = 0;
        for (; v1238 < ArrayItems.Length; v1238++)
            v1239 = (ArrayItems[v1238] + 10);
        if (v1239 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1239;
    }

    int RangeLastRewritten_ProceduralLinq1()
    {
        int v1240;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1241;
        v1241 = null;
        v1240 = 0;
        for (; v1240 < 100; v1240++)
            v1241 = (v1240 + 0);
        if (v1241 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1241;
    }

    int Range1LastRewritten_ProceduralLinq1()
    {
        int v1242;
        if (1 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1243;
        v1243 = null;
        v1242 = 0;
        for (; v1242 < 1; v1242++)
            v1243 = (v1242 + 0);
        if (v1243 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1243;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1244;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int? v1245;
        v1245 = null;
        v1244 = 0;
        for (; v1244 < 100; v1244++)
            v1245 = 0;
        if (v1245 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1245;
    }

    int EmptyLastRewritten_ProceduralLinq1()
    {
        int v1246;
        int? v1247;
        v1247 = null;
        v1246 = 0;
        for (; v1246 < 0; v1246++)
            v1247 = default(int);
        if (v1247 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1247;
    }

    int ArrayDistinctLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1248;
        HashSet<int> v1249;
        int? v1250;
        v1249 = new HashSet<int>();
        v1250 = null;
        v1248 = 0;
        for (; v1248 < ArrayItems.Length; v1248++)
        {
            if (!(v1249.Add(ArrayItems[v1248])))
                continue;
            v1250 = ArrayItems[v1248];
        }

        if (v1250 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1250;
    }

    int ArrayLastParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1251;
        int? v1252;
        v1252 = null;
        v1251 = 0;
        for (; v1251 < ArrayItems.Length; v1251++)
            if ((ArrayItems[v1251] > a))
                v1252 = ArrayItems[v1251];
        if (v1252 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1252;
    }

    int ArrayLastChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1253;
        int? v1254;
        v1254 = null;
        v1253 = 0;
        for (; v1253 < ArrayItems.Length; v1253++)
            if ((ArrayItems[v1253] > a--))
                v1254 = ArrayItems[v1253];
        if (v1254 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1254;
    }

    int ArrayLastUsingLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1255;
        int? v1256;
        v1256 = null;
        v1255 = 0;
        for (; v1255 < ArrayItems.Length; v1255++)
            if ((ArrayItems[v1255] > ArrayItems.Last(y => y > ArrayItems[v1255])))
                v1256 = ArrayItems[v1255];
        if (v1256 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1256;
    }
}}