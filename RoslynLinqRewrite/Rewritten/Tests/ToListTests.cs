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
        int v2574;
        System.Collections.Generic.List<int> v2575;
        v2575 = new System.Collections.Generic.List<int>();
        v2574 = (0);
        for (; v2574 < (ArrayItems.Length); v2574 += 1)
            v2575.Add((ArrayItems[v2574]));
        return v2575;
    }

    System.Collections.Generic.List<int> ListToListTestRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v2577;
        System.Collections.Generic.List<int> v2578;
        int v2579;
        v2579 = (ListItems.Count);
        v2578 = new System.Collections.Generic.List<int>();
        v2577 = (0);
        for (; v2577 < v2579; v2577 += 1)
            v2578.Add((ListItems[v2577]));
        return v2578;
    }

    System.Collections.Generic.List<int> SimpleListToListTestRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2581;
        v2581 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2582;
        v2582 = SimpleListItems;
        int v2583;
        System.Collections.Generic.List<int> v2584;
        v2584 = new System.Collections.Generic.List<int>();
        v2583 = (0);
        for (; v2583 < (v2581); v2583 += 1)
            v2584.Add((v2582[v2583]));
        return v2584;
    }

    System.Collections.Generic.List<int> EnumerableToListTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2585;
        System.Collections.Generic.List<int> v2586;
        v2585 = EnumerableItems.GetEnumerator();
        v2586 = new System.Collections.Generic.List<int>();
        try
        {
            while (v2585.MoveNext())
                v2586.Add((v2585.Current));
        }
        finally
        {
            v2585.Dispose();
        }

        return v2586;
    }

    System.Collections.Generic.List<int> ArrayWhereParamToListTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2587;
        System.Collections.Generic.List<int> v2588;
        v2588 = new System.Collections.Generic.List<int>();
        v2587 = (0);
        for (; v2587 < (ArrayItems.Length); v2587 += 1)
        {
            if (!((((ArrayItems[v2587])) > offset)))
                continue;
            v2588.Add(((ArrayItems[v2587])));
        }

        return v2588;
    }

    System.Collections.Generic.List<int> EnumerableWhereParamToListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2589;
        int v2590;
        System.Collections.Generic.List<int> v2591;
        v2589 = EnumerableItems.GetEnumerator();
        v2591 = new System.Collections.Generic.List<int>();
        try
        {
            while (v2589.MoveNext())
            {
                v2590 = (v2589.Current);
                if (!(((v2590) > offset)))
                    continue;
                v2591.Add((v2590));
            }
        }
        finally
        {
            v2589.Dispose();
        }

        return v2591;
    }

    System.Collections.Generic.List<int> SimpleListWhereParamToListTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2592;
        v2592 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2593;
        v2593 = SimpleListItems;
        int v2594;
        System.Collections.Generic.List<int> v2595;
        v2595 = new System.Collections.Generic.List<int>();
        v2594 = (0);
        for (; v2594 < (v2592); v2594 += 1)
        {
            if (!((((v2593[v2594])) > offset)))
                continue;
            v2595.Add(((v2593[v2594])));
        }

        return v2595;
    }

    System.Collections.Generic.List<int> ListWhereParamToListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2596;
        System.Collections.Generic.List<int> v2597;
        int v2598;
        v2598 = (ListItems.Count);
        v2597 = new System.Collections.Generic.List<int>();
        v2596 = (0);
        for (; v2596 < v2598; v2596 += 1)
        {
            if (!((((ListItems[v2596])) > offset)))
                continue;
            v2597.Add(((ListItems[v2596])));
        }

        return v2597;
    }

    System.Collections.Generic.List<int> RangeWhereParamToListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2599;
        System.Collections.Generic.List<int> v2600;
        v2600 = new System.Collections.Generic.List<int>();
        v2599 = (0);
        for (; v2599 < (1000); v2599 += (1))
        {
            if (!((((v2599)) > offset)))
                continue;
            v2600.Add(((v2599)));
        }

        return v2600;
    }

    System.Collections.Generic.List<int> RangeParamToListTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2601;
        System.Collections.Generic.List<int> v2602;
        v2602 = new System.Collections.Generic.List<int>();
        v2601 = (0);
        for (; v2601 < (count); v2601 += (1))
            v2602.Add((v2601));
        return v2602;
    }

    System.Collections.Generic.List<int> RepeatParamToListTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2603;
        System.Collections.Generic.List<int> v2604;
        v2604 = new System.Collections.Generic.List<int>();
        v2603 = (0);
        for (; v2603 < (count); v2603 += 1)
            v2604.Add((0));
        return v2604;
    }

    System.Collections.Generic.List<int> RepeatWhereParamToListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2605;
        System.Collections.Generic.List<int> v2606;
        v2606 = new System.Collections.Generic.List<int>();
        v2605 = (0);
        for (; v2605 < (1000); v2605 += 1)
        {
            if (!((v2605 < offset)))
                continue;
            v2606.Add(((0)));
        }

        return v2606;
    }
}}