using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class TakeTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayTake), ArrayTake, ArrayTakeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTake0), ArrayTake0, ArrayTake0Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeM1), ArrayTakeM1, ArrayTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTake1000), ArrayTake1000, ArrayTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeParam), ArrayTakeParam, ArrayTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTake), EnumerableTake, EnumerableTakeRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTake0), EnumerableTake0, EnumerableTake0Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeM1), EnumerableTakeM1, EnumerableTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTake1000), EnumerableTake1000, EnumerableTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeParam), EnumerableTakeParam, EnumerableTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(RangeTake), RangeTake, RangeTakeRewritten);
        TestsExtensions.TestEquals(nameof(RangeTake0), RangeTake0, RangeTake0Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeM1), RangeTakeM1, RangeTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTake1000), RangeTake1000, RangeTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeParam), RangeTakeParam, RangeTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(RepeatTake), RepeatTake, RepeatTakeRewritten);
        TestsExtensions.TestEquals(nameof(RepeatTake0), RepeatTake0, RepeatTake0Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatTakeM1), RepeatTakeM1, RepeatTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatTake1000), RepeatTake1000, RepeatTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatTakeParam), RepeatTakeParam, RepeatTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectTakeToArray), ArraySelectTakeToArray, ArraySelectTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectTakeM1ToArray), ArraySelectTakeM1ToArray, ArraySelectTakeM1ToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereTakeToArray), ArrayWhereTakeToArray, ArrayWhereTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereFalseTakeToArray), ArrayWhereFalseTakeToArray, ArrayWhereFalseTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeToArray), ArrayTakeToArray, ArrayTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeToArray), EnumerableTakeToArray, EnumerableTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeToArray), RangeTakeToArray, RangeTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatTakeToArray), RepeatTakeToArray, RepeatTakeToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayTake()
    {
        return ArrayItems.Take(20);
    } //EndMethod

    public IEnumerable<int> ArrayTakeRewritten()
    {
        return ArrayTakeRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTake0()
    {
        return ArrayItems.Take(0);
    } //EndMethod

    public IEnumerable<int> ArrayTake0Rewritten()
    {
        return ArrayTake0Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeM1()
    {
        return ArrayItems.Take(-1);
    } //EndMethod

    public IEnumerable<int> ArrayTakeM1Rewritten()
    {
        return ArrayTakeM1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTake1000()
    {
        return ArrayItems.Take(1000);
    } //EndMethod

    public IEnumerable<int> ArrayTake1000Rewritten()
    {
        return ArrayTake1000Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeParam()
    {
        var a = 50;
        return ArrayItems.Take(a);
    } //EndMethod

    public IEnumerable<int> ArrayTakeParamRewritten()
    {
        var a = 50;
        return ArrayTakeParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTake()
    {
        return EnumerableItems.Take(20);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeRewritten()
    {
        return EnumerableTakeRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTake0()
    {
        return EnumerableItems.Take(0);
    } //EndMethod

    public IEnumerable<int> EnumerableTake0Rewritten()
    {
        return EnumerableTake0Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeM1()
    {
        return EnumerableItems.Take(-1);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeM1Rewritten()
    {
        return EnumerableTakeM1Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTake1000()
    {
        return EnumerableItems.Take(1000);
    } //EndMethod

    public IEnumerable<int> EnumerableTake1000Rewritten()
    {
        return EnumerableTake1000Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeParam()
    {
        var a = 50;
        return EnumerableItems.Take(a);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeParamRewritten()
    {
        var a = 50;
        return EnumerableTakeParamRewritten_ProceduralLinq1(a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTake()
    {
        return Enumerable.Range(0, 100).Take(20);
    } //EndMethod

    public IEnumerable<int> RangeTakeRewritten()
    {
        return RangeTakeRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTake0()
    {
        return Enumerable.Range(0, 100).Take(0);
    } //EndMethod

    public IEnumerable<int> RangeTake0Rewritten()
    {
        return RangeTake0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeM1()
    {
        return Enumerable.Range(0, 100).Take(-1);
    } //EndMethod

    public IEnumerable<int> RangeTakeM1Rewritten()
    {
        return RangeTakeM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTake1000()
    {
        return Enumerable.Range(0, 100).Take(1000);
    } //EndMethod

    public IEnumerable<int> RangeTake1000Rewritten()
    {
        return RangeTake1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeParam()
    {
        var a = 50;
        return Enumerable.Range(0, 100).Take(a);
    } //EndMethod

    public IEnumerable<int> RangeTakeParamRewritten()
    {
        var a = 50;
        return RangeTakeParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTake()
    {
        return Enumerable.Repeat(0, 100).Take(20);
    } //EndMethod

    public IEnumerable<int> RepeatTakeRewritten()
    {
        return RepeatTakeRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTake0()
    {
        return Enumerable.Repeat(0, 100).Take(0);
    } //EndMethod

    public IEnumerable<int> RepeatTake0Rewritten()
    {
        return RepeatTake0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTakeM1()
    {
        return Enumerable.Repeat(0, 100).Take(-1);
    } //EndMethod

    public IEnumerable<int> RepeatTakeM1Rewritten()
    {
        return RepeatTakeM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTake1000()
    {
        return Enumerable.Repeat(0, 100).Take(1000);
    } //EndMethod

    public IEnumerable<int> RepeatTake1000Rewritten()
    {
        return RepeatTake1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTakeParam()
    {
        var a = 50;
        return Enumerable.Repeat(0, 100).Take(a);
    } //EndMethod

    public IEnumerable<int> RepeatTakeParamRewritten()
    {
        var a = 50;
        return RepeatTakeParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectTakeToArray()
    {
        return ArrayItems.Select(x => x + 10).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectTakeToArrayRewritten()
    {
        return ArraySelectTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectTakeM1ToArray()
    {
        var m1 = -1;
        return ArrayItems.Select(x => x + 10).Take(m1).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectTakeM1ToArrayRewritten()
    {
        var m1 = -1;
        return ArraySelectTakeM1ToArrayRewritten_ProceduralLinq1(m1, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereTakeToArray()
    {
        return ArrayItems.Where(x => x > 20).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereTakeToArrayRewritten()
    {
        return ArrayWhereTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereFalseTakeToArray()
    {
        return ArrayItems.Where(x => false).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereFalseTakeToArrayRewritten()
    {
        return ArrayWhereFalseTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeToArray()
    {
        return ArrayItems.Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeToArrayRewritten()
    {
        return ArrayTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeToArray()
    {
        return EnumerableItems.Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeToArrayRewritten()
    {
        return EnumerableTakeToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeToArray()
    {
        return Enumerable.Range(0, 100).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeToArrayRewritten()
    {
        return RangeTakeToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTakeToArray()
    {
        return Enumerable.Repeat(0, 100).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RepeatTakeToArrayRewritten()
    {
        return RepeatTakeToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayTakeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2441;
        int v2442;
        if (20 > (ArrayItems.Length))
            v2442 = (ArrayItems.Length);
        else
            v2442 = 20;
        v2441 = (0);
        for (; v2441 < (v2442); v2441++)
            yield return (ArrayItems[v2441]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTake0Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2445;
        int v2446;
        if (0 > (ArrayItems.Length))
            v2446 = (ArrayItems.Length);
        else
            v2446 = 0;
        v2445 = (0);
        for (; v2445 < (v2446); v2445++)
            yield return (ArrayItems[v2445]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeM1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2449;
        int v2450;
        if (0 > (ArrayItems.Length))
            v2450 = (ArrayItems.Length);
        else
            v2450 = 0;
        v2449 = (0);
        for (; v2449 < (v2450); v2449++)
            yield return (ArrayItems[v2449]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTake1000Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2453;
        int v2454;
        if (1000 > (ArrayItems.Length))
            v2454 = (ArrayItems.Length);
        else
            v2454 = 1000;
        v2453 = (0);
        for (; v2453 < (v2454); v2453++)
            yield return (ArrayItems[v2453]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2457;
        int v2458;
        if (a < 0)
            v2458 = 0;
        else if (a > (ArrayItems.Length))
            v2458 = (ArrayItems.Length);
        else
            v2458 = a;
        v2457 = (0);
        for (; v2457 < (v2458); v2457++)
            yield return (ArrayItems[v2457]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2459;
        int v2460;
        v2459 = EnumerableItems.GetEnumerator();
        v2460 = 0;
        try
        {
            while (v2459.MoveNext())
            {
                if (v2460 >= 20)
                    break;
                yield return (v2459.Current);
                v2460++;
            }
        }
        finally
        {
            v2459.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTake0Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2461;
        int v2462;
        v2461 = EnumerableItems.GetEnumerator();
        v2462 = 0;
        try
        {
            while (v2461.MoveNext())
            {
                if (v2462 >= 0)
                    break;
                yield return (v2461.Current);
                v2462++;
            }
        }
        finally
        {
            v2461.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeM1Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2463;
        int v2464;
        v2463 = EnumerableItems.GetEnumerator();
        v2464 = 0;
        try
        {
            while (v2463.MoveNext())
            {
                if (v2464 >= 0)
                    break;
                yield return (v2463.Current);
                v2464++;
            }
        }
        finally
        {
            v2463.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTake1000Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2465;
        int v2466;
        v2465 = EnumerableItems.GetEnumerator();
        v2466 = 0;
        try
        {
            while (v2465.MoveNext())
            {
                if (v2466 >= 1000)
                    break;
                yield return (v2465.Current);
                v2466++;
            }
        }
        finally
        {
            v2465.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2467;
        int v2468;
        if (a < 0)
            v2468 = 0;
        else
            v2468 = a;
        int v2469;
        v2467 = EnumerableItems.GetEnumerator();
        v2469 = 0;
        try
        {
            while (v2467.MoveNext())
            {
                if (v2469 >= v2468)
                    break;
                yield return (v2467.Current);
                v2469++;
            }
        }
        finally
        {
            v2467.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeRewritten_ProceduralLinq1()
    {
        int v2470;
        v2470 = (0);
        for (; v2470 < (20); v2470++)
            yield return (v2470);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTake0Rewritten_ProceduralLinq1()
    {
        int v2471;
        v2471 = (0);
        for (; v2471 < (0); v2471++)
            yield return (v2471);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeM1Rewritten_ProceduralLinq1()
    {
        int v2472;
        v2472 = (0);
        for (; v2472 < (0); v2472++)
            yield return (v2472);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTake1000Rewritten_ProceduralLinq1()
    {
        int v2473;
        v2473 = (0);
        for (; v2473 < (100); v2473++)
            yield return (v2473);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeParamRewritten_ProceduralLinq1(int a)
    {
        int v2474;
        int v2475;
        if (a < 0)
            v2475 = 0;
        else if (a > (100))
            v2475 = (100);
        else
            v2475 = a;
        v2474 = (0);
        for (; v2474 < (v2475); v2474++)
            yield return (v2474);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTakeRewritten_ProceduralLinq1()
    {
        int v2476;
        v2476 = (0);
        for (; v2476 < (20); v2476++)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTake0Rewritten_ProceduralLinq1()
    {
        int v2477;
        v2477 = (0);
        for (; v2477 < (0); v2477++)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTakeM1Rewritten_ProceduralLinq1()
    {
        int v2478;
        v2478 = (0);
        for (; v2478 < (0); v2478++)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTake1000Rewritten_ProceduralLinq1()
    {
        int v2479;
        v2479 = (0);
        for (; v2479 < (100); v2479++)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTakeParamRewritten_ProceduralLinq1(int a)
    {
        int v2480;
        int v2481;
        if (a < 0)
            v2481 = 0;
        else if (a > (100))
            v2481 = (100);
        else
            v2481 = a;
        v2480 = (0);
        for (; v2480 < (v2481); v2480++)
            yield return (0);
        yield break;
    }

    int[] ArraySelectTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2484;
        int v2485;
        if (20 > (ArrayItems.Length))
            v2485 = (ArrayItems.Length);
        else
            v2485 = 20;
        int[] v2486;
        int v2487;
        v2486 = new int[(v2485)];
        v2487 = 0;
        v2484 = (0);
        for (; v2484 < (v2485); v2484++)
        {
            v2486[v2487] = (10 + ArrayItems[v2484]);
            v2487++;
        }

        return v2486;
    }

    int[] ArraySelectTakeM1ToArrayRewritten_ProceduralLinq1(int m1, int[] ArrayItems)
    {
        int v2490;
        int v2491;
        if (m1 < 0)
            v2491 = 0;
        else if (m1 > (ArrayItems.Length))
            v2491 = (ArrayItems.Length);
        else
            v2491 = m1;
        int[] v2492;
        int v2493;
        v2492 = new int[(v2491)];
        v2493 = 0;
        v2490 = (0);
        for (; v2490 < (v2491); v2490++)
        {
            v2492[v2493] = (10 + ArrayItems[v2490]);
            v2493++;
        }

        return v2492;
    }

    int[] ArrayWhereTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2494;
        int v2495;
        int v2496;
        int v2497;
        int v2498;
        int v2499;
        int[] v2500;
        v2496 = 0;
        v2497 = 0;
        v2498 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2498 -= (v2498 % 2);
        v2499 = 8;
        v2500 = new int[8];
        v2494 = (0);
        for (; v2494 < (ArrayItems.Length); v2494++)
        {
            v2495 = (ArrayItems[v2494]);
            if (!(((v2495) > 20)))
                continue;
            if (v2496 >= 20)
                break;
            if (v2497 >= v2499)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2500, ref v2498, out v2499);
            v2500[v2497] = (v2495);
            v2496++;
            v2497++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2500, v2497);
    }

    int[] ArrayWhereFalseTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2501;
        int v2502;
        int v2503;
        int v2504;
        int v2505;
        int v2506;
        int[] v2507;
        v2503 = 0;
        v2504 = 0;
        v2505 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2505 -= (v2505 % 2);
        v2506 = 8;
        v2507 = new int[8];
        v2501 = (0);
        for (; v2501 < (ArrayItems.Length); v2501++)
        {
            v2502 = (ArrayItems[v2501]);
            if (!((false)))
                continue;
            if (v2503 >= 20)
                break;
            if (v2504 >= v2506)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2507, ref v2505, out v2506);
            v2507[v2504] = (v2502);
            v2503++;
            v2504++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2507, v2504);
    }

    int[] ArrayTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2510;
        int v2511;
        if (20 > (ArrayItems.Length))
            v2511 = (ArrayItems.Length);
        else
            v2511 = 20;
        int[] v2512;
        v2512 = new int[(v2511)];
        System.Array.Copy(ArrayItems, (0), v2512, 0, (v2511));
        return v2512;
    }

    int[] EnumerableTakeToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2513;
        int v2514;
        int v2515;
        int v2516;
        int[] v2517;
        v2513 = EnumerableItems.GetEnumerator();
        v2514 = 0;
        v2515 = 0;
        v2516 = 8;
        v2517 = new int[8];
        try
        {
            while (v2513.MoveNext())
            {
                if (v2514 >= 20)
                    break;
                if (v2515 >= v2516)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2517, ref v2516);
                v2517[v2515] = (v2513.Current);
                v2514++;
                v2515++;
            }
        }
        finally
        {
            v2513.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2517, v2515);
    }

    int[] RangeTakeToArrayRewritten_ProceduralLinq1()
    {
        int v2518;
        int[] v2519;
        int v2520;
        v2519 = new int[(20)];
        v2520 = 0;
        v2518 = (0);
        for (; v2518 < (20); v2518++)
        {
            v2519[v2520] = (v2518);
            v2520++;
        }

        return v2519;
    }

    int[] RepeatTakeToArrayRewritten_ProceduralLinq1()
    {
        int v2521;
        int[] v2522;
        int v2523;
        v2522 = new int[(20)];
        v2523 = 0;
        v2521 = (0);
        for (; v2521 < (20); v2521++)
        {
            v2522[v2523] = (0);
            v2523++;
        }

        return v2522;
    }
}}