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
        return (ArrayItems.Length) == 0 ? default(int) : ArrayItems[-1 + ArrayItems.Length];
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
        return (ArrayItems.Length) == 0 ? default(int) : 10 + ArrayItems[-1 + ArrayItems.Length];
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
        return ArrayLastOrDefaultUsingLastOrDefaultRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    int EnumerableLastOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1299;
        int? v1300;
        v1299 = EnumerableItems.GetEnumerator();
        v1300 = null;
        try
        {
            while (v1299.MoveNext())
                v1300 = (v1299.Current);
        }
        finally
        {
            v1299.Dispose();
        }

        if (v1300 == null)
            return default(int);
        else
            return (int)v1300;
    }

    int LastOrDefaultConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1302;
        int? v1303;
        v1303 = null;
        v1302 = (0);
        for (; v1302 < (ArrayItems.Length); v1302 += 1)
            if (((ArrayItems[v1302]) > 30))
                v1303 = (ArrayItems[v1302]);
        if (v1303 == null)
            return default(int);
        else
            return (int)v1303;
    }

    int LastOrDefaultFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1305;
        int? v1306;
        v1306 = null;
        v1305 = (0);
        for (; v1305 < (ArrayItems.Length); v1305 += 1)
            if (((ArrayItems[v1305]) > 105))
                v1306 = (ArrayItems[v1305]);
        if (v1306 == null)
            return default(int);
        else
            return (int)v1306;
    }

    int LastOrDefaultMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1308;
        int? v1309;
        v1309 = null;
        v1308 = (0);
        for (; v1308 < (ArrayItems.Length); v1308 += 1)
            if (Predicate((ArrayItems[v1308])))
                v1309 = (ArrayItems[v1308]);
        if (v1309 == null)
            return default(int);
        else
            return (int)v1309;
    }

    int LastOrDefaultWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1310;
        int? v1311;
        v1311 = null;
        v1310 = (0);
        for (; v1310 < (ArrayItems.Length); v1310 += 1)
        {
            if (!((((ArrayItems[v1310])) > 10)))
                continue;
            v1311 = ((ArrayItems[v1310]));
        }

        if (v1311 == null)
            return default(int);
        else
            return (int)v1311;
    }

    int RangeLastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1313;
        int? v1314;
        v1314 = null;
        v1313 = (0);
        for (; v1313 < (100); v1313 += (1))
            v1314 = (v1313);
        if (v1314 == null)
            return default(int);
        else
            return (int)v1314;
    }

    int Range1LastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1315;
        int? v1316;
        v1316 = null;
        v1315 = (0);
        for (; v1315 < (1); v1315 += (1))
            v1316 = (v1315);
        if (v1316 == null)
            return default(int);
        else
            return (int)v1316;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1317;
        int? v1318;
        v1318 = null;
        v1317 = (0);
        for (; v1317 < (100); v1317 += 1)
            v1318 = (0);
        if (v1318 == null)
            return default(int);
        else
            return (int)v1318;
    }

    int EmptyLastOrDefaultRewritten_ProceduralLinq1()
    {
        int v1319;
        int? v1320;
        v1319 = 0;
        v1320 = null;
        if (v1320 == null)
            return default(int);
        else
            return (int)v1320;
    }

    int ArrayDistinctLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1321;
        HashSet<int> v1322;
        int? v1323;
        v1322 = new HashSet<int>();
        v1323 = null;
        v1321 = (0);
        for (; v1321 < (ArrayItems.Length); v1321 += 1)
        {
            if (!(v1322.Add(((ArrayItems[v1321])))))
                continue;
            v1323 = ((ArrayItems[v1321]));
        }

        if (v1323 == null)
            return default(int);
        else
            return (int)v1323;
    }

    int ArrayLastOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1325;
        int? v1326;
        v1326 = null;
        v1325 = (0);
        for (; v1325 < (ArrayItems.Length); v1325 += 1)
            if (((ArrayItems[v1325]) > a))
                v1326 = (ArrayItems[v1325]);
        if (v1326 == null)
            return default(int);
        else
            return (int)v1326;
    }

    int ArrayLastOrDefaultChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1327;
        int? v1328;
        v1328 = null;
        v1327 = (0);
        for (; v1327 < (ArrayItems.Length); v1327 += 1)
            if (((ArrayItems[v1327]) > a--))
                v1328 = (ArrayItems[v1327]);
        if (v1328 == null)
            return default(int);
        else
            return (int)v1328;
    }

    int ArrayLastOrDefaultUsingLastOrDefaultRewritten_ProceduralLinq1(int x, int[] ArrayItems)
    {
        int v1330;
        int? v1331;
        v1331 = null;
        v1330 = (0);
        for (; v1330 < (ArrayItems.Length); v1330 += 1)
            if (((ArrayItems[v1330]) > x))
                v1331 = (ArrayItems[v1330]);
        if (v1331 == null)
            return default(int);
        else
            return (int)v1331;
    }

    int ArrayLastOrDefaultUsingLastOrDefaultRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1333;
        int? v1334;
        v1334 = null;
        v1333 = (0);
        for (; v1333 < (ArrayItems.Length); v1333 += 1)
            if (((ArrayItems[v1333]) > ArrayLastOrDefaultUsingLastOrDefaultRewritten_ProceduralLinq1((ArrayItems[v1333]), ArrayItems)))
                v1334 = (ArrayItems[v1333]);
        if (v1334 == null)
            return default(int);
        else
            return (int)v1334;
    }
}}