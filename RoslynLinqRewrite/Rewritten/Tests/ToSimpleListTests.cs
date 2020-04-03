using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ToSimpleListTests
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
        TestsExtensions.TestEquals(nameof(ArrayToSimpleListTest), ArrayToSimpleListTest, ArrayToSimpleListTestRewritten);
        TestsExtensions.TestEquals(nameof(ListToSimpleListTest), ListToSimpleListTest, ListToSimpleListTestRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListToSimpleListTest), SimpleListToSimpleListTest, SimpleListToSimpleListTestRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableToSimpleListTest), EnumerableToSimpleListTest, EnumerableToSimpleListTestRewritten);
        for (int i = -1; i < 1001; i++)
        {
            TestsExtensions.TestEquals(nameof(ArrayWhereParamToSimpleListTest) + i, () => ArrayWhereParamToSimpleListTest(i), () => ArrayWhereParamToSimpleListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(EnumerableWhereParamToSimpleListTest) + i, () => EnumerableWhereParamToSimpleListTest(i), () => EnumerableWhereParamToSimpleListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(SimpleListWhereParamToSimpleListTest) + i, () => SimpleListWhereParamToSimpleListTest(i), () => SimpleListWhereParamToSimpleListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(ListWhereParamToSimpleListTest) + i, () => ListWhereParamToSimpleListTest(i), () => ListWhereParamToSimpleListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RangeWhereParamToSimpleListTest) + i, () => RangeWhereParamToSimpleListTest(i), () => RangeWhereParamToSimpleListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RangeParamToSimpleListTest) + i, () => RangeParamToSimpleListTest(i), () => RangeParamToSimpleListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RepeatParamToSimpleListTest) + i, () => RepeatParamToSimpleListTest(i), () => RepeatParamToSimpleListTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RepeatWhereParamToSimpleListTest) + i, () => RepeatWhereParamToSimpleListTest(i), () => RepeatWhereParamToSimpleListTestRewritten(i));
        }
    }

    [NoRewrite]
    public IEnumerable<int> ArrayToSimpleListTest()
    {
        return ArrayItems.ToSimpleList();
    } //EndMethod

    public IEnumerable<int> ArrayToSimpleListTestRewritten()
    {
        return ArrayItems.ToSimpleList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ListToSimpleListTest()
    {
        return ListItems.ToSimpleList();
    } //EndMethod

    public IEnumerable<int> ListToSimpleListTestRewritten()
    {
        return ListItems.ToSimpleList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListToSimpleListTest()
    {
        return SimpleListItems.ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SimpleListToSimpleListTestRewritten()
    {
        return SimpleListToSimpleListTestRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableToSimpleListTest()
    {
        return EnumerableItems.ToSimpleList();
    } //EndMethod

    public IEnumerable<int> EnumerableToSimpleListTestRewritten()
    {
        return EnumerableToSimpleListTestRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereParamToSimpleListTest(int offset)
    {
        return ArrayItems.Where(x => x > offset).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> ArrayWhereParamToSimpleListTestRewritten(int offset)
    {
        return ArrayWhereParamToSimpleListTestRewritten_ProceduralLinq1(offset, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableWhereParamToSimpleListTest(int offset)
    {
        return EnumerableItems.Where(x => x > offset).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> EnumerableWhereParamToSimpleListTestRewritten(int offset)
    {
        return EnumerableWhereParamToSimpleListTestRewritten_ProceduralLinq1(offset, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListWhereParamToSimpleListTest(int offset)
    {
        return SimpleListItems.Where(x => x > offset).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SimpleListWhereParamToSimpleListTestRewritten(int offset)
    {
        return SimpleListWhereParamToSimpleListTestRewritten_ProceduralLinq1(offset, SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ListWhereParamToSimpleListTest(int offset)
    {
        return ListItems.Where(x => x > offset).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> ListWhereParamToSimpleListTestRewritten(int offset)
    {
        return ListWhereParamToSimpleListTestRewritten_ProceduralLinq1(offset, ListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeWhereParamToSimpleListTest(int offset)
    {
        return Enumerable.Range(0, 1000).Where(x => x > offset).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> RangeWhereParamToSimpleListTestRewritten(int offset)
    {
        return RangeWhereParamToSimpleListTestRewritten_ProceduralLinq1(offset);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeParamToSimpleListTest(int count)
    {
        return Enumerable.Range(0, count).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> RangeParamToSimpleListTestRewritten(int count)
    {
        return RangeParamToSimpleListTestRewritten_ProceduralLinq1(count);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatParamToSimpleListTest(int count)
    {
        return Enumerable.Repeat(0, count).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> RepeatParamToSimpleListTestRewritten(int count)
    {
        return RepeatParamToSimpleListTestRewritten_ProceduralLinq1(count);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatWhereParamToSimpleListTest(int offset)
    {
        return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> RepeatWhereParamToSimpleListTestRewritten(int offset)
    {
        return RepeatWhereParamToSimpleListTestRewritten_ProceduralLinq1(offset);
    } //EndMethod

    LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListToSimpleListTestRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2436;
        int v2437;
        int v2438;
        int[] v2439;
        SimpleList<int> v2440;
        v2436 = SimpleListItems.GetEnumerator();
        v2437 = 0;
        v2438 = 8;
        v2439 = new int[8];
        try
        {
            while (v2436.MoveNext())
            {
                if (v2437 >= v2438)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2439, ref v2438);
                v2439[v2437] = v2436.Current;
                v2437++;
            }
        }
        finally
        {
            v2436.Dispose();
        }

        v2440 = new SimpleList<int>();
        v2440.Items = v2439;
        v2440.Count = v2437;
        return v2440;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> EnumerableToSimpleListTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2441;
        int v2442;
        int v2443;
        int[] v2444;
        SimpleList<int> v2445;
        v2441 = EnumerableItems.GetEnumerator();
        v2442 = 0;
        v2443 = 8;
        v2444 = new int[8];
        try
        {
            while (v2441.MoveNext())
            {
                if (v2442 >= v2443)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2444, ref v2443);
                v2444[v2442] = v2441.Current;
                v2442++;
            }
        }
        finally
        {
            v2441.Dispose();
        }

        v2445 = new SimpleList<int>();
        v2445.Items = v2444;
        v2445.Count = v2442;
        return v2445;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2446;
        int v2447;
        int v2448;
        int v2449;
        int[] v2450;
        SimpleList<int> v2451;
        v2447 = 0;
        v2448 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2448 -= (v2448 % 2);
        v2449 = 8;
        v2450 = new int[8];
        v2446 = 0;
        for (; v2446 < ArrayItems.Length; v2446++)
        {
            if (!((ArrayItems[v2446] > offset)))
                continue;
            if (v2447 >= v2449)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2450, ref v2448, out v2449);
            v2450[v2447] = ArrayItems[v2446];
            v2447++;
        }

        v2451 = new SimpleList<int>();
        v2451.Items = v2450;
        v2451.Count = v2447;
        return v2451;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> EnumerableWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2452;
        int v2453;
        int v2454;
        int v2455;
        int[] v2456;
        SimpleList<int> v2457;
        v2452 = EnumerableItems.GetEnumerator();
        v2454 = 0;
        v2455 = 8;
        v2456 = new int[8];
        try
        {
            while (v2452.MoveNext())
            {
                v2453 = v2452.Current;
                if (!((v2453 > offset)))
                    continue;
                if (v2454 >= v2455)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2456, ref v2455);
                v2456[v2454] = v2453;
                v2454++;
            }
        }
        finally
        {
            v2452.Dispose();
        }

        v2457 = new SimpleList<int>();
        v2457.Items = v2456;
        v2457.Count = v2454;
        return v2457;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2458;
        int v2459;
        int v2460;
        int v2461;
        int[] v2462;
        SimpleList<int> v2463;
        v2458 = SimpleListItems.GetEnumerator();
        v2460 = 0;
        v2461 = 8;
        v2462 = new int[8];
        try
        {
            while (v2458.MoveNext())
            {
                v2459 = v2458.Current;
                if (!((v2459 > offset)))
                    continue;
                if (v2460 >= v2461)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2462, ref v2461);
                v2462[v2460] = v2459;
                v2460++;
            }
        }
        finally
        {
            v2458.Dispose();
        }

        v2463 = new SimpleList<int>();
        v2463.Items = v2462;
        v2463.Count = v2460;
        return v2463;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ListWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2464;
        int v2465;
        int v2466;
        int v2467;
        int v2468;
        int[] v2469;
        SimpleList<int> v2470;
        v2464 = ListItems.Count;
        v2466 = 0;
        v2467 = (LinqRewrite.Core.IntExtensions.Log2((uint)v2464) - 3);
        v2467 -= (v2467 % 2);
        v2468 = 8;
        v2469 = new int[8];
        v2465 = 0;
        for (; v2465 < v2464; v2465++)
        {
            if (!((ListItems[v2465] > offset)))
                continue;
            if (v2466 >= v2468)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, v2464, ref v2469, ref v2467, out v2468);
            v2469[v2466] = ListItems[v2465];
            v2466++;
        }

        v2470 = new SimpleList<int>();
        v2470.Items = v2469;
        v2470.Count = v2466;
        return v2470;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RangeWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2471;
        int v2472;
        int v2473;
        int v2474;
        int v2475;
        int[] v2476;
        SimpleList<int> v2477;
        v2473 = 0;
        v2474 = (LinqRewrite.Core.IntExtensions.Log2((uint)1000) - 3);
        v2474 -= (v2474 % 2);
        v2475 = 8;
        v2476 = new int[8];
        v2471 = 0;
        for (; v2471 < 1000; v2471++)
        {
            v2472 = (v2471 + 0);
            if (!((v2472 > offset)))
                continue;
            if (v2473 >= v2475)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 1000, ref v2476, ref v2474, out v2475);
            v2476[v2473] = v2472;
            v2473++;
        }

        v2477 = new SimpleList<int>();
        v2477.Items = v2476;
        v2477.Count = v2473;
        return v2477;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RangeParamToSimpleListTestRewritten_ProceduralLinq1(int count)
    {
        if (count < 0)
            throw new System.InvalidOperationException("Index out of range");
        int v2478;
        int[] v2479;
        SimpleList<int> v2480;
        v2479 = new int[count];
        v2478 = 0;
        for (; v2478 < count; v2478++)
            v2479[v2478] = (v2478 + 0);
        v2480 = new SimpleList<int>();
        v2480.Items = v2479;
        v2480.Count = count;
        return v2480;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RepeatParamToSimpleListTestRewritten_ProceduralLinq1(int count)
    {
        if (count < 0)
            throw new System.InvalidOperationException("Index out of range");
        int v2481;
        int[] v2482;
        SimpleList<int> v2483;
        v2482 = new int[count];
        v2481 = 0;
        for (; v2481 < count; v2481++)
            v2482[v2481] = 0;
        v2483 = new SimpleList<int>();
        v2483.Items = v2482;
        v2483.Count = count;
        return v2483;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RepeatWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2484;
        int v2485;
        int v2486;
        int v2487;
        int[] v2488;
        SimpleList<int> v2489;
        v2485 = 0;
        v2486 = (LinqRewrite.Core.IntExtensions.Log2((uint)1000) - 3);
        v2486 -= (v2486 % 2);
        v2487 = 8;
        v2488 = new int[8];
        v2484 = 0;
        for (; v2484 < 1000; v2484++)
        {
            if (!((v2484 < offset)))
                continue;
            if (v2485 >= v2487)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 1000, ref v2488, ref v2486, out v2487);
            v2488[v2485] = 0;
            v2485++;
        }

        v2489 = new SimpleList<int>();
        v2489.Items = v2488;
        v2489.Count = v2485;
        return v2489;
    }
}}