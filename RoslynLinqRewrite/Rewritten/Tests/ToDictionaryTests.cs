using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ToDictionaryTests
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
        TestsExtensions.TestEquals(nameof(ArrayToDictionaryTest), ArrayToDictionaryTest, ArrayToDictionaryTestRewritten);
        TestsExtensions.TestEquals(nameof(ListToDictionaryTest), ListToDictionaryTest, ListToDictionaryTestRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListToDictionaryTest), SimpleListToDictionaryTest, SimpleListToDictionaryTestRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableToDictionaryTest), EnumerableToDictionaryTest, EnumerableToDictionaryTestRewritten);
        for (int i = -1; i < 1001; i++)
        {
            TestsExtensions.TestEquals(nameof(ArrayWhereParamToDictionaryTest) + i, () => ArrayWhereParamToDictionaryTest(i), () => ArrayWhereParamToDictionaryTestRewritten(i));
            TestsExtensions.TestEquals(nameof(EnumerableWhereParamToDictionaryTest) + i, () => EnumerableWhereParamToDictionaryTest(i), () => EnumerableWhereParamToDictionaryTestRewritten(i));
            TestsExtensions.TestEquals(nameof(SimpleListWhereParamToDictionaryTest) + i, () => SimpleListWhereParamToDictionaryTest(i), () => SimpleListWhereParamToDictionaryTestRewritten(i));
            TestsExtensions.TestEquals(nameof(ListWhereParamToDictionaryTest) + i, () => ListWhereParamToDictionaryTest(i), () => ListWhereParamToDictionaryTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RangeWhereParamToDictionaryTest) + i, () => RangeWhereParamToDictionaryTest(i), () => RangeWhereParamToDictionaryTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RangeParamToDictionaryTest) + i, () => RangeParamToDictionaryTest(i), () => RangeParamToDictionaryTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RepeatParamToDictionaryTest) + i, () => RepeatParamToDictionaryTest(i), () => RepeatParamToDictionaryTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RepeatWhereParamToDictionaryTest) + i, () => RepeatWhereParamToDictionaryTest(i), () => RepeatWhereParamToDictionaryTestRewritten(i));
        }
    }

    [NoRewrite]
    public Dictionary<int, int> ArrayToDictionaryTest()
    {
        return ArrayItems.ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> ArrayToDictionaryTestRewritten()
    {
        return ArrayToDictionaryTestRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> ListToDictionaryTest()
    {
        return ListItems.ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> ListToDictionaryTestRewritten()
    {
        return ListToDictionaryTestRewritten_ProceduralLinq1(ListItems);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> SimpleListToDictionaryTest()
    {
        return SimpleListItems.ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> SimpleListToDictionaryTestRewritten()
    {
        return SimpleListItems.ToDictionary(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> EnumerableToDictionaryTest()
    {
        return EnumerableItems.ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> EnumerableToDictionaryTestRewritten()
    {
        return EnumerableToDictionaryTestRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> ArrayWhereParamToDictionaryTest(int offset)
    {
        return ArrayItems.Where(x => x > offset).ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> ArrayWhereParamToDictionaryTestRewritten(int offset)
    {
        return ArrayWhereParamToDictionaryTestRewritten_ProceduralLinq1(offset, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> EnumerableWhereParamToDictionaryTest(int offset)
    {
        return EnumerableItems.Where(x => x > offset).ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> EnumerableWhereParamToDictionaryTestRewritten(int offset)
    {
        return EnumerableWhereParamToDictionaryTestRewritten_ProceduralLinq1(offset, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> SimpleListWhereParamToDictionaryTest(int offset)
    {
        return SimpleListItems.Where(x => x > offset).ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> SimpleListWhereParamToDictionaryTestRewritten(int offset)
    {
        return SimpleListWhereParamToDictionaryTestRewritten_ProceduralLinq1(offset, SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> ListWhereParamToDictionaryTest(int offset)
    {
        return ListItems.Where(x => x > offset).ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> ListWhereParamToDictionaryTestRewritten(int offset)
    {
        return ListWhereParamToDictionaryTestRewritten_ProceduralLinq1(offset, ListItems);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> RangeWhereParamToDictionaryTest(int offset)
    {
        return Enumerable.Range(0, 1000).Where(x => x > offset).ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> RangeWhereParamToDictionaryTestRewritten(int offset)
    {
        return RangeWhereParamToDictionaryTestRewritten_ProceduralLinq1(offset);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> RangeParamToDictionaryTest(int count)
    {
        return Enumerable.Range(0, count).ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> RangeParamToDictionaryTestRewritten(int count)
    {
        return RangeParamToDictionaryTestRewritten_ProceduralLinq1(count);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> RepeatParamToDictionaryTest(int count)
    {
        return Enumerable.Repeat(0, count).ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> RepeatParamToDictionaryTestRewritten(int count)
    {
        return RepeatParamToDictionaryTestRewritten_ProceduralLinq1(count);
    } //EndMethod

    [NoRewrite]
    public Dictionary<int, int> RepeatWhereParamToDictionaryTest(int offset)
    {
        return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToDictionary(x => x, x => x);
    } //EndMethod

    public Dictionary<int, int> RepeatWhereParamToDictionaryTestRewritten(int offset)
    {
        return RepeatWhereParamToDictionaryTestRewritten_ProceduralLinq1(offset);
    } //EndMethod

    System.Collections.Generic.Dictionary<int, int> ArrayToDictionaryTestRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2356;
        System.Collections.Generic.Dictionary<int, int> v2357;
        v2357 = new System.Collections.Generic.Dictionary<int, int>();
        v2356 = 0;
        for (; v2356 < ArrayItems.Length; v2356++)
            v2357.Add((ArrayItems[v2356]), (ArrayItems[v2356]));
        return v2357;
    }

    System.Collections.Generic.Dictionary<int, int> ListToDictionaryTestRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v2358;
        int v2359;
        System.Collections.Generic.Dictionary<int, int> v2360;
        v2358 = ListItems.Count;
        v2360 = new System.Collections.Generic.Dictionary<int, int>();
        v2359 = 0;
        for (; v2359 < v2358; v2359++)
            v2360.Add((ListItems[v2359]), (ListItems[v2359]));
        return v2360;
    }

    System.Collections.Generic.Dictionary<int, int> EnumerableToDictionaryTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2361;
        System.Collections.Generic.Dictionary<int, int> v2362;
        v2361 = EnumerableItems.GetEnumerator();
        v2362 = new System.Collections.Generic.Dictionary<int, int>();
        try
        {
            while (v2361.MoveNext())
                v2362.Add((v2361.Current), (v2361.Current));
        }
        finally
        {
            v2361.Dispose();
        }

        return v2362;
    }

    System.Collections.Generic.Dictionary<int, int> ArrayWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2363;
        System.Collections.Generic.Dictionary<int, int> v2364;
        v2364 = new System.Collections.Generic.Dictionary<int, int>();
        v2363 = 0;
        for (; v2363 < ArrayItems.Length; v2363++)
        {
            if (!((ArrayItems[v2363] > offset)))
                continue;
            v2364.Add((ArrayItems[v2363]), (ArrayItems[v2363]));
        }

        return v2364;
    }

    System.Collections.Generic.Dictionary<int, int> EnumerableWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2365;
        int v2366;
        System.Collections.Generic.Dictionary<int, int> v2367;
        v2365 = EnumerableItems.GetEnumerator();
        v2367 = new System.Collections.Generic.Dictionary<int, int>();
        try
        {
            while (v2365.MoveNext())
            {
                v2366 = v2365.Current;
                if (!((v2366 > offset)))
                    continue;
                v2367.Add((v2366), (v2366));
            }
        }
        finally
        {
            v2365.Dispose();
        }

        return v2367;
    }

    System.Collections.Generic.Dictionary<int, int> SimpleListWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2368;
        int v2369;
        System.Collections.Generic.Dictionary<int, int> v2370;
        v2368 = SimpleListItems.GetEnumerator();
        v2370 = new System.Collections.Generic.Dictionary<int, int>();
        try
        {
            while (v2368.MoveNext())
            {
                v2369 = v2368.Current;
                if (!((v2369 > offset)))
                    continue;
                v2370.Add((v2369), (v2369));
            }
        }
        finally
        {
            v2368.Dispose();
        }

        return v2370;
    }

    System.Collections.Generic.Dictionary<int, int> ListWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2371;
        int v2372;
        System.Collections.Generic.Dictionary<int, int> v2373;
        v2371 = ListItems.Count;
        v2373 = new System.Collections.Generic.Dictionary<int, int>();
        v2372 = 0;
        for (; v2372 < v2371; v2372++)
        {
            if (!((ListItems[v2372] > offset)))
                continue;
            v2373.Add((ListItems[v2372]), (ListItems[v2372]));
        }

        return v2373;
    }

    System.Collections.Generic.Dictionary<int, int> RangeWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset)
    {
        int v2374;
        int v2375;
        System.Collections.Generic.Dictionary<int, int> v2376;
        v2376 = new System.Collections.Generic.Dictionary<int, int>();
        v2374 = 0;
        for (; v2374 < 1000; v2374++)
        {
            v2375 = (v2374 + 0);
            if (!((v2375 > offset)))
                continue;
            v2376.Add((v2375), (v2375));
        }

        return v2376;
    }

    System.Collections.Generic.Dictionary<int, int> RangeParamToDictionaryTestRewritten_ProceduralLinq1(int count)
    {
        if (count < 0)
            throw new System.InvalidOperationException("Index out of range");
        int v2377;
        System.Collections.Generic.Dictionary<int, int> v2378;
        v2378 = new System.Collections.Generic.Dictionary<int, int>();
        v2377 = 0;
        for (; v2377 < count; v2377++)
            v2378.Add(((v2377 + 0)), ((v2377 + 0)));
        return v2378;
    }

    System.Collections.Generic.Dictionary<int, int> RepeatParamToDictionaryTestRewritten_ProceduralLinq1(int count)
    {
        if (count < 0)
            throw new System.InvalidOperationException("Index out of range");
        int v2379;
        System.Collections.Generic.Dictionary<int, int> v2380;
        v2380 = new System.Collections.Generic.Dictionary<int, int>();
        v2379 = 0;
        for (; v2379 < count; v2379++)
            v2380.Add((0), (0));
        return v2380;
    }

    System.Collections.Generic.Dictionary<int, int> RepeatWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset)
    {
        int v2381;
        System.Collections.Generic.Dictionary<int, int> v2382;
        v2382 = new System.Collections.Generic.Dictionary<int, int>();
        v2381 = 0;
        for (; v2381 < 1000; v2381++)
        {
            if (!((v2381 < offset)))
                continue;
            v2382.Add((0), (0));
        }

        return v2382;
    }
}}