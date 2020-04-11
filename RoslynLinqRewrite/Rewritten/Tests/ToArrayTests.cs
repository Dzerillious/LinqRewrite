using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ToArrayTests
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
        TestsExtensions.TestEquals(nameof(ArrayToArrayTest), ArrayToArrayTest, ArrayToArrayTestRewritten);
        TestsExtensions.TestEquals(nameof(ListToArrayTest), ListToArrayTest, ListToArrayTestRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListToArrayTest), SimpleListToArrayTest, SimpleListToArrayTestRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableToArrayTest), EnumerableToArrayTest, EnumerableToArrayTestRewritten);
        for (int i = -1; i < 1001; i++)
        {
            TestsExtensions.TestEquals(nameof(ArrayWhereParamToArrayTest) + i, () => ArrayWhereParamToArrayTest(i), () => ArrayWhereParamToArrayTestRewritten(i));
            TestsExtensions.TestEquals(nameof(EnumerableWhereParamToArrayTest) + i, () => EnumerableWhereParamToArrayTest(i), () => EnumerableWhereParamToArrayTestRewritten(i));
            TestsExtensions.TestEquals(nameof(SimpleListWhereParamToArrayTest) + i, () => SimpleListWhereParamToArrayTest(i), () => SimpleListWhereParamToArrayTestRewritten(i));
            TestsExtensions.TestEquals(nameof(ListWhereParamToArrayTest) + i, () => ListWhereParamToArrayTest(i), () => ListWhereParamToArrayTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RangeWhereParamToArrayTest) + i, () => RangeWhereParamToArrayTest(i), () => RangeWhereParamToArrayTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RangeParamToArrayTest) + i, () => RangeParamToArrayTest(i), () => RangeParamToArrayTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RepeatParamToArrayTest) + i, () => RepeatParamToArrayTest(i), () => RepeatParamToArrayTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RepeatWhereParamToArrayTest) + i, () => RepeatWhereParamToArrayTest(i), () => RepeatWhereParamToArrayTestRewritten(i));
        }
    }

    [NoRewrite]
    public IEnumerable<int> ArrayToArrayTest()
    {
        return ArrayItems.ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayToArrayTestRewritten()
    {
        return ArrayToArrayTestRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ListToArrayTest()
    {
        return ListItems.ToArray();
    } //EndMethod

    public IEnumerable<int> ListToArrayTestRewritten()
    {
        return ListItems.ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListToArrayTest()
    {
        return SimpleListItems.ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListToArrayTestRewritten()
    {
        return SimpleListItems.ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableToArrayTest()
    {
        return EnumerableItems.ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableToArrayTestRewritten()
    {
        return EnumerableToArrayTestRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereParamToArrayTest(int offset)
    {
        return ArrayItems.Where(x => x > offset).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereParamToArrayTestRewritten(int offset)
    {
        return ArrayWhereParamToArrayTestRewritten_ProceduralLinq1(offset, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableWhereParamToArrayTest(int offset)
    {
        return EnumerableItems.Where(x => x > offset).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableWhereParamToArrayTestRewritten(int offset)
    {
        return EnumerableWhereParamToArrayTestRewritten_ProceduralLinq1(offset, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListWhereParamToArrayTest(int offset)
    {
        return SimpleListItems.Where(x => x > offset).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListWhereParamToArrayTestRewritten(int offset)
    {
        return SimpleListWhereParamToArrayTestRewritten_ProceduralLinq1(offset, SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ListWhereParamToArrayTest(int offset)
    {
        return ListItems.Where(x => x > offset).ToArray();
    } //EndMethod

    public IEnumerable<int> ListWhereParamToArrayTestRewritten(int offset)
    {
        return ListWhereParamToArrayTestRewritten_ProceduralLinq1(offset, ListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeWhereParamToArrayTest(int offset)
    {
        return Enumerable.Range(0, 1000).Where(x => x > offset).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeWhereParamToArrayTestRewritten(int offset)
    {
        return RangeWhereParamToArrayTestRewritten_ProceduralLinq1(offset);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeParamToArrayTest(int count)
    {
        return Enumerable.Range(0, count).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeParamToArrayTestRewritten(int count)
    {
        return RangeParamToArrayTestRewritten_ProceduralLinq1(count);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatParamToArrayTest(int count)
    {
        return Enumerable.Repeat(0, count).ToArray();
    } //EndMethod

    public IEnumerable<int> RepeatParamToArrayTestRewritten(int count)
    {
        return RepeatParamToArrayTestRewritten_ProceduralLinq1(count);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatWhereParamToArrayTest(int offset)
    {
        return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToArray();
    } //EndMethod

    public IEnumerable<int> RepeatWhereParamToArrayTestRewritten(int offset)
    {
        return RepeatWhereParamToArrayTestRewritten_ProceduralLinq1(offset);
    } //EndMethod

    int[] ArrayToArrayTestRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2501;
        int[] v2502;
        v2502 = new int[(ArrayItems.Length)];
        System.Array.Copy(ArrayItems, (0), v2502, 0, (ArrayItems.Length));
        return v2502;
    }

    int[] EnumerableToArrayTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2503;
        int v2504;
        int v2505;
        int[] v2506;
        v2503 = EnumerableItems.GetEnumerator();
        v2504 = 0;
        v2505 = 8;
        v2506 = new int[8];
        try
        {
            while (v2503.MoveNext())
            {
                if (v2504 >= v2505)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2506, ref v2505);
                v2506[v2504] = (v2503.Current);
                v2504++;
            }
        }
        finally
        {
            v2503.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2506, v2504);
    }

    int[] ArrayWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2507;
        int v2508;
        int v2509;
        int v2510;
        int[] v2511;
        v2508 = 0;
        v2509 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2509 -= (v2509 % 2);
        v2510 = 8;
        v2511 = new int[8];
        v2507 = (0);
        for (; v2507 < (ArrayItems.Length); v2507 += 1)
        {
            if (!((((ArrayItems[v2507])) > offset)))
                continue;
            if (v2508 >= v2510)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2511, ref v2509, out v2510);
            v2511[v2508] = ((ArrayItems[v2507]));
            v2508++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2511, v2508);
    }

    int[] EnumerableWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2512;
        int v2513;
        int v2514;
        int v2515;
        int[] v2516;
        v2512 = EnumerableItems.GetEnumerator();
        v2514 = 0;
        v2515 = 8;
        v2516 = new int[8];
        try
        {
            while (v2512.MoveNext())
            {
                v2513 = (v2512.Current);
                if (!(((v2513) > offset)))
                    continue;
                if (v2514 >= v2515)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2516, ref v2515);
                v2516[v2514] = (v2513);
                v2514++;
            }
        }
        finally
        {
            v2512.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2516, v2514);
    }

    int[] SimpleListWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2517;
        v2517 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2518;
        v2518 = SimpleListItems;
        int v2519;
        int v2520;
        int v2521;
        int v2522;
        int[] v2523;
        v2520 = 0;
        v2521 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v2517))) - 3);
        v2521 -= (v2521 % 2);
        v2522 = 8;
        v2523 = new int[8];
        v2519 = (0);
        for (; v2519 < (v2517); v2519 += 1)
        {
            if (!((((v2518[v2519])) > offset)))
                continue;
            if (v2520 >= v2522)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v2517), ref v2523, ref v2521, out v2522);
            v2523[v2520] = ((v2518[v2519]));
            v2520++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2523, v2520);
    }

    int[] ListWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2524;
        int v2525;
        int v2526;
        int v2527;
        int[] v2528;
        int v2529;
        v2529 = (ListItems.Count);
        v2525 = 0;
        v2526 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ListItems.Count))) - 3);
        v2526 -= (v2526 % 2);
        v2527 = 8;
        v2528 = new int[8];
        v2524 = (0);
        for (; v2524 < v2529; v2524 += 1)
        {
            if (!((((ListItems[v2524])) > offset)))
                continue;
            if (v2525 >= v2527)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ListItems.Count), ref v2528, ref v2526, out v2527);
            v2528[v2525] = ((ListItems[v2524]));
            v2525++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2528, v2525);
    }

    int[] RangeWhereParamToArrayTestRewritten_ProceduralLinq1(int offset)
    {
        int v2530;
        int v2531;
        int v2532;
        int v2533;
        int[] v2534;
        v2531 = 0;
        v2532 = (LinqRewrite.Core.IntExtensions.Log2((uint)((1000))) - 3);
        v2532 -= (v2532 % 2);
        v2533 = 8;
        v2534 = new int[8];
        v2530 = (0);
        for (; v2530 < (1000); v2530 += (1))
        {
            if (!((((v2530)) > offset)))
                continue;
            if (v2531 >= v2533)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (1000), ref v2534, ref v2532, out v2533);
            v2534[v2531] = ((v2530));
            v2531++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2534, v2531);
    }

    int[] RangeParamToArrayTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2535;
        int[] v2536;
        v2536 = new int[(count)];
        v2535 = (0);
        for (; v2535 < (count); v2535 += (1))
            v2536[v2535] = (v2535);
        return v2536;
    }

    int[] RepeatParamToArrayTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2537;
        int[] v2538;
        v2538 = new int[(count)];
        v2537 = (0);
        for (; v2537 < (count); v2537 += 1)
            v2538[v2537] = (0);
        return v2538;
    }

    int[] RepeatWhereParamToArrayTestRewritten_ProceduralLinq1(int offset)
    {
        int v2539;
        int v2540;
        int v2541;
        int v2542;
        int[] v2543;
        v2540 = 0;
        v2541 = (LinqRewrite.Core.IntExtensions.Log2((uint)((1000))) - 3);
        v2541 -= (v2541 % 2);
        v2542 = 8;
        v2543 = new int[8];
        v2539 = (0);
        for (; v2539 < (1000); v2539 += 1)
        {
            if (!((v2539 < offset)))
                continue;
            if (v2540 >= v2542)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (1000), ref v2543, ref v2541, out v2542);
            v2543[v2540] = ((0));
            v2540++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2543, v2540);
    }
}}