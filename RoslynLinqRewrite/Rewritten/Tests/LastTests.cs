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
        return ArrayItems[-1 + ArrayItems.Length];
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
        return 10 + ArrayItems[-1 + ArrayItems.Length];
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
        return ArrayLastUsingLastRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    int EnumerableLastRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1336;
        int v1337;
        int? v1338;
        v1336 = EnumerableItems.GetEnumerator();
        v1337 = 0;
        v1338 = null;
        try
        {
            while (v1336.MoveNext())
            {
                v1338 = (v1336.Current);
                v1337++;
            }
        }
        finally
        {
            v1336.Dispose();
        }

        if (v1338 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1338;
    }

    int LastConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1340;
        int? v1341;
        v1341 = null;
        v1340 = (0);
        for (; v1340 < (ArrayItems.Length); v1340 += 1)
            if (((ArrayItems[v1340]) > 30))
                v1341 = (ArrayItems[v1340]);
        if (v1341 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1341;
    }

    int LastFalseConditionRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1343;
        int? v1344;
        v1344 = null;
        v1343 = (0);
        for (; v1343 < (ArrayItems.Length); v1343 += 1)
            if (((ArrayItems[v1343]) > 105))
                v1344 = (ArrayItems[v1343]);
        if (v1344 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1344;
    }

    int LastMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1346;
        int? v1347;
        v1347 = null;
        v1346 = (0);
        for (; v1346 < (ArrayItems.Length); v1346 += 1)
            if (Predicate((ArrayItems[v1346])))
                v1347 = (ArrayItems[v1346]);
        if (v1347 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1347;
    }

    int LastWhereMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1348;
        int v1349;
        int? v1350;
        v1349 = 0;
        v1350 = null;
        v1348 = (0);
        for (; v1348 < (ArrayItems.Length); v1348 += 1)
        {
            if (!((((ArrayItems[v1348])) > 10)))
                continue;
            v1350 = ((ArrayItems[v1348]));
            v1349++;
        }

        if (v1350 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1350;
    }

    int RangeLastRewritten_ProceduralLinq1()
    {
        int v1352;
        int? v1353;
        v1353 = null;
        v1352 = (0);
        for (; v1352 < (100); v1352 += (1))
            v1353 = (v1352);
        if (v1353 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1353;
    }

    int Range1LastRewritten_ProceduralLinq1()
    {
        int v1354;
        int? v1355;
        v1355 = null;
        v1354 = (0);
        for (; v1354 < (1); v1354 += (1))
            v1355 = (v1354);
        if (v1355 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1355;
    }

    int RangeRepeatRewritten_ProceduralLinq1()
    {
        int v1356;
        int? v1357;
        v1357 = null;
        v1356 = (0);
        for (; v1356 < (100); v1356 += 1)
            v1357 = (0);
        if (v1357 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1357;
    }

    int EmptyLastRewritten_ProceduralLinq1()
    {
        int v1358;
        int? v1359;
        v1358 = 0;
        v1359 = null;
        if (v1359 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1359;
    }

    int ArrayDistinctLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1360;
        HashSet<int> v1361;
        int v1362;
        int? v1363;
        v1361 = new HashSet<int>();
        v1362 = 0;
        v1363 = null;
        v1360 = (0);
        for (; v1360 < (ArrayItems.Length); v1360 += 1)
        {
            if (!(v1361.Add(((ArrayItems[v1360])))))
                continue;
            v1363 = ((ArrayItems[v1360]));
            v1362++;
        }

        if (v1363 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1363;
    }

    int ArrayLastParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1365;
        int? v1366;
        v1366 = null;
        v1365 = (0);
        for (; v1365 < (ArrayItems.Length); v1365 += 1)
            if (((ArrayItems[v1365]) > a))
                v1366 = (ArrayItems[v1365]);
        if (v1366 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1366;
    }

    int ArrayLastChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1367;
        int? v1368;
        v1368 = null;
        v1367 = (0);
        for (; v1367 < (ArrayItems.Length); v1367 += 1)
            if (((ArrayItems[v1367]) > a--))
                v1368 = (ArrayItems[v1367]);
        if (v1368 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1368;
    }

    int ArrayLastUsingLastRewritten_ProceduralLinq1(int x, int[] ArrayItems)
    {
        int v1370;
        int? v1371;
        v1371 = null;
        v1370 = (0);
        for (; v1370 < (ArrayItems.Length); v1370 += 1)
            if (((ArrayItems[v1370]) > x))
                v1371 = (ArrayItems[v1370]);
        if (v1371 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1371;
    }

    int ArrayLastUsingLastRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1373;
        int? v1374;
        v1374 = null;
        v1373 = (0);
        for (; v1373 < (ArrayItems.Length); v1373 += 1)
            if (((ArrayItems[v1373]) > ArrayLastUsingLastRewritten_ProceduralLinq1((ArrayItems[v1373]), ArrayItems)))
                v1374 = (ArrayItems[v1373]);
        if (v1374 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1374;
    }
}}