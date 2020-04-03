using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ToListTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 1000).ToArray();
    [Datapoints]
    private List<int> ListItems = Enumerable.Range(0, 1000).ToList();
    [Datapoints]
    private SimpleList<int> SimpleListItems = Enumerable.Range(0, 1000).ToSimpleList();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 1000);
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayToListTest), ArrayToListTest, ArrayToListTestRewritten);
        TestsExtensions.TestEquals(nameof(ListToListTest), ListToListTest, ListToListTestRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListToListTest), SimpleListToListTest, SimpleListToListTestRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableToListTest), EnumerableToListTest, EnumerableToListTestRewritten);
        for (int i = -1; i < 1001; i++)
        {
            TestsExtensions.TestEquals(nameof(ArrayWhereParamToListTest) + i, () => ArrayWhereParamToListTest(i), () => ArrayWhereParamToListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(EnumerableWhereParamToListTest) + i, () => EnumerableWhereParamToListTest(i), () => EnumerableWhereParamToListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(SimpleListWhereParamToListTest) + i, () => SimpleListWhereParamToListTest(i), () => SimpleListWhereParamToListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(ListWhereParamToListTest) + i, () => ListWhereParamToListTest(i), () => ListWhereParamToListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RangeWhereParamToListTest) + i, () => RangeWhereParamToListTest(i), () => RangeWhereParamToListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RangeParamToListTest) + i, () => RangeParamToListTest(i), () => RangeParamToListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RepeatParamToListTest) + i, () => RepeatParamToListTest(i), () => RepeatParamToListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RepeatWhereParamToListTest) + i, () => RepeatWhereParamToListTest(i), () => RepeatWhereParamToListTestRewritten(i));
        }
    }

    [NoRewrite]
    public IEnumerable<int> ArrayToListTest()
    {
        return ArrayItems.ToList();
    } //EndMethod

    public IEnumerable<int> ArrayToListTestRewritten()
    {
        return ArrayToListTestRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ListToListTest()
    {
        return ListItems.ToList();
    } //EndMethod

    public IEnumerable<int> ListToListTestRewritten()
    {
        return ListToListTestRewritten_ProceduralLinq1(ListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListToListTest()
    {
        return SimpleListItems.ToList();
    } //EndMethod

    public IEnumerable<int> SimpleListToListTestRewritten()
    {
        return SimpleListToListTestRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableToListTest()
    {
        return EnumerableItems.ToList();
    } //EndMethod

    public IEnumerable<int> EnumerableToListTestRewritten()
    {
        return EnumerableToListTestRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereParamToListTest(int offset)
    {
        return ArrayItems.Where(x => x > offset).ToList();
    } //EndMethod

    public IEnumerable<int> ArrayWhereParamToListTestRewritten(int offset)
    {
        return ArrayWhereParamToListTestRewritten_ProceduralLinq1(offset, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableWhereParamToListTest(int offset)
    {
        return EnumerableItems.Where(x => x > offset).ToList();
    } //EndMethod

    public IEnumerable<int> EnumerableWhereParamToListTestRewritten(int offset)
    {
        return EnumerableWhereParamToListTestRewritten_ProceduralLinq1(offset, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListWhereParamToListTest(int offset)
    {
        return SimpleListItems.Where(x => x > offset).ToList();
    } //EndMethod

    public IEnumerable<int> SimpleListWhereParamToListTestRewritten(int offset)
    {
        return SimpleListWhereParamToListTestRewritten_ProceduralLinq1(offset, SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ListWhereParamToListTest(int offset)
    {
        return ListItems.Where(x => x > offset).ToList();
    } //EndMethod

    public IEnumerable<int> ListWhereParamToListTestRewritten(int offset)
    {
        return ListWhereParamToListTestRewritten_ProceduralLinq1(offset, ListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeWhereParamToListTest(int offset)
    {
        return Enumerable.Range(0, 1000).Where(x => x > offset).ToList();
    } //EndMethod

    public IEnumerable<int> RangeWhereParamToListTestRewritten(int offset)
    {
        return RangeWhereParamToListTestRewritten_ProceduralLinq1(offset);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeParamToListTest(int count)
    {
        return Enumerable.Range(0, count).ToList();
    } //EndMethod

    public IEnumerable<int> RangeParamToListTestRewritten(int count)
    {
        return RangeParamToListTestRewritten_ProceduralLinq1(count);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatParamToListTest(int count)
    {
        return Enumerable.Repeat(0, count).ToList();
    } //EndMethod

    public IEnumerable<int> RepeatParamToListTestRewritten(int count)
    {
        return RepeatParamToListTestRewritten_ProceduralLinq1(count);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatWhereParamToListTest(int offset)
    {
        return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToList();
    } //EndMethod

    public IEnumerable<int> RepeatWhereParamToListTestRewritten(int offset)
    {
        return RepeatWhereParamToListTestRewritten_ProceduralLinq1(offset);
    } //EndMethod

    System.Collections.Generic.List<int> ArrayToListTestRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2383;
        System.Collections.Generic.List<int> v2384;
        v2384 = new System.Collections.Generic.List<int>();
        v2383 = 0;
        for (; v2383 < ArrayItems.Length; v2383++)
            v2384.Add(ArrayItems[v2383]);
        return v2384;
    }

    System.Collections.Generic.List<int> ListToListTestRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v2385;
        int v2386;
        System.Collections.Generic.List<int> v2387;
        v2385 = ListItems.Count;
        v2387 = new System.Collections.Generic.List<int>();
        v2386 = 0;
        for (; v2386 < v2385; v2386++)
            v2387.Add(ListItems[v2386]);
        return v2387;
    }

    System.Collections.Generic.List<int> SimpleListToListTestRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2388;
        System.Collections.Generic.List<int> v2389;
        v2388 = SimpleListItems.GetEnumerator();
        v2389 = new System.Collections.Generic.List<int>();
        try
        {
            while (v2388.MoveNext())
                v2389.Add(v2388.Current);
        }
        finally
        {
            v2388.Dispose();
        }

        return v2389;
    }

    System.Collections.Generic.List<int> EnumerableToListTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2390;
        System.Collections.Generic.List<int> v2391;
        v2390 = EnumerableItems.GetEnumerator();
        v2391 = new System.Collections.Generic.List<int>();
        try
        {
            while (v2390.MoveNext())
                v2391.Add(v2390.Current);
        }
        finally
        {
            v2390.Dispose();
        }

        return v2391;
    }

    System.Collections.Generic.List<int> ArrayWhereParamToListTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2392;
        System.Collections.Generic.List<int> v2393;
        v2393 = new System.Collections.Generic.List<int>();
        v2392 = 0;
        for (; v2392 < ArrayItems.Length; v2392++)
        {
            if (!((ArrayItems[v2392] > offset)))
                continue;
            v2393.Add(ArrayItems[v2392]);
        }

        return v2393;
    }

    System.Collections.Generic.List<int> EnumerableWhereParamToListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2394;
        int v2395;
        System.Collections.Generic.List<int> v2396;
        v2394 = EnumerableItems.GetEnumerator();
        v2396 = new System.Collections.Generic.List<int>();
        try
        {
            while (v2394.MoveNext())
            {
                v2395 = v2394.Current;
                if (!((v2395 > offset)))
                    continue;
                v2396.Add(v2395);
            }
        }
        finally
        {
            v2394.Dispose();
        }

        return v2396;
    }

    System.Collections.Generic.List<int> SimpleListWhereParamToListTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2397;
        int v2398;
        System.Collections.Generic.List<int> v2399;
        v2397 = SimpleListItems.GetEnumerator();
        v2399 = new System.Collections.Generic.List<int>();
        try
        {
            while (v2397.MoveNext())
            {
                v2398 = v2397.Current;
                if (!((v2398 > offset)))
                    continue;
                v2399.Add(v2398);
            }
        }
        finally
        {
            v2397.Dispose();
        }

        return v2399;
    }

    System.Collections.Generic.List<int> ListWhereParamToListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2400;
        int v2401;
        System.Collections.Generic.List<int> v2402;
        v2400 = ListItems.Count;
        v2402 = new System.Collections.Generic.List<int>();
        v2401 = 0;
        for (; v2401 < v2400; v2401++)
        {
            if (!((ListItems[v2401] > offset)))
                continue;
            v2402.Add(ListItems[v2401]);
        }

        return v2402;
    }

    System.Collections.Generic.List<int> RangeWhereParamToListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2403;
        int v2404;
        System.Collections.Generic.List<int> v2405;
        v2405 = new System.Collections.Generic.List<int>();
        v2403 = 0;
        for (; v2403 < 1000; v2403++)
        {
            v2404 = (v2403 + 0);
            if (!((v2404 > offset)))
                continue;
            v2405.Add(v2404);
        }

        return v2405;
    }

    System.Collections.Generic.List<int> RangeParamToListTestRewritten_ProceduralLinq1(int count)
    {
        if (count < 0)
            throw new System.InvalidOperationException("Index out of range");
        int v2406;
        System.Collections.Generic.List<int> v2407;
        v2407 = new System.Collections.Generic.List<int>();
        v2406 = 0;
        for (; v2406 < count; v2406++)
            v2407.Add((v2406 + 0));
        return v2407;
    }

    System.Collections.Generic.List<int> RepeatParamToListTestRewritten_ProceduralLinq1(int count)
    {
        if (count < 0)
            throw new System.InvalidOperationException("Index out of range");
        int v2408;
        System.Collections.Generic.List<int> v2409;
        v2409 = new System.Collections.Generic.List<int>();
        v2408 = 0;
        for (; v2408 < count; v2408++)
            v2409.Add(0);
        return v2409;
    }

    System.Collections.Generic.List<int> RepeatWhereParamToListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2410;
        System.Collections.Generic.List<int> v2411;
        v2411 = new System.Collections.Generic.List<int>();
        v2410 = 0;
        for (; v2410 < 1000; v2410++)
        {
            if (!((v2410 < offset)))
                continue;
            v2411.Add(0);
        }

        return v2411;
    }
}}