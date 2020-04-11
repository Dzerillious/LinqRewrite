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
        int v2545;
        System.Collections.Generic.Dictionary<int, int> v2546;
        v2546 = new System.Collections.Generic.Dictionary<int, int>();
        v2545 = (0);
        for (; v2545 < (ArrayItems.Length); v2545 += 1)
            v2546.Add(((ArrayItems[v2545])), ((ArrayItems[v2545])));
        return v2546;
    }

    System.Collections.Generic.Dictionary<int, int> ListToDictionaryTestRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v2548;
        System.Collections.Generic.Dictionary<int, int> v2549;
        int v2550;
        v2550 = (ListItems.Count);
        v2549 = new System.Collections.Generic.Dictionary<int, int>();
        v2548 = (0);
        for (; v2548 < v2550; v2548 += 1)
            v2549.Add(((ListItems[v2548])), ((ListItems[v2548])));
        return v2549;
    }

    System.Collections.Generic.Dictionary<int, int> EnumerableToDictionaryTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2551;
        System.Collections.Generic.Dictionary<int, int> v2552;
        v2551 = EnumerableItems.GetEnumerator();
        v2552 = new System.Collections.Generic.Dictionary<int, int>();
        try
        {
            while (v2551.MoveNext())
                v2552.Add(((v2551.Current)), ((v2551.Current)));
        }
        finally
        {
            v2551.Dispose();
        }

        return v2552;
    }

    System.Collections.Generic.Dictionary<int, int> ArrayWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2553;
        System.Collections.Generic.Dictionary<int, int> v2554;
        v2554 = new System.Collections.Generic.Dictionary<int, int>();
        v2553 = (0);
        for (; v2553 < (ArrayItems.Length); v2553 += 1)
        {
            if (!((((ArrayItems[v2553])) > offset)))
                continue;
            v2554.Add((((ArrayItems[v2553]))), (((ArrayItems[v2553]))));
        }

        return v2554;
    }

    System.Collections.Generic.Dictionary<int, int> EnumerableWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2555;
        int v2556;
        System.Collections.Generic.Dictionary<int, int> v2557;
        v2555 = EnumerableItems.GetEnumerator();
        v2557 = new System.Collections.Generic.Dictionary<int, int>();
        try
        {
            while (v2555.MoveNext())
            {
                v2556 = (v2555.Current);
                if (!(((v2556) > offset)))
                    continue;
                v2557.Add(((v2556)), ((v2556)));
            }
        }
        finally
        {
            v2555.Dispose();
        }

        return v2557;
    }

    System.Collections.Generic.Dictionary<int, int> SimpleListWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2558;
        v2558 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2559;
        v2559 = SimpleListItems;
        int v2560;
        System.Collections.Generic.Dictionary<int, int> v2561;
        v2561 = new System.Collections.Generic.Dictionary<int, int>();
        v2560 = (0);
        for (; v2560 < (v2558); v2560 += 1)
        {
            if (!((((v2559[v2560])) > offset)))
                continue;
            v2561.Add((((v2559[v2560]))), (((v2559[v2560]))));
        }

        return v2561;
    }

    System.Collections.Generic.Dictionary<int, int> ListWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2562;
        System.Collections.Generic.Dictionary<int, int> v2563;
        int v2564;
        v2564 = (ListItems.Count);
        v2563 = new System.Collections.Generic.Dictionary<int, int>();
        v2562 = (0);
        for (; v2562 < v2564; v2562 += 1)
        {
            if (!((((ListItems[v2562])) > offset)))
                continue;
            v2563.Add((((ListItems[v2562]))), (((ListItems[v2562]))));
        }

        return v2563;
    }

    System.Collections.Generic.Dictionary<int, int> RangeWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset)
    {
        int v2565;
        System.Collections.Generic.Dictionary<int, int> v2566;
        v2566 = new System.Collections.Generic.Dictionary<int, int>();
        v2565 = (0);
        for (; v2565 < (1000); v2565 += (1))
        {
            if (!((((v2565)) > offset)))
                continue;
            v2566.Add((((v2565))), (((v2565))));
        }

        return v2566;
    }

    System.Collections.Generic.Dictionary<int, int> RangeParamToDictionaryTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2567;
        System.Collections.Generic.Dictionary<int, int> v2568;
        v2568 = new System.Collections.Generic.Dictionary<int, int>();
        v2567 = (0);
        for (; v2567 < (count); v2567 += (1))
            v2568.Add(((v2567)), ((v2567)));
        return v2568;
    }

    System.Collections.Generic.Dictionary<int, int> RepeatParamToDictionaryTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2569;
        System.Collections.Generic.Dictionary<int, int> v2570;
        v2570 = new System.Collections.Generic.Dictionary<int, int>();
        v2569 = (0);
        for (; v2569 < (count); v2569 += 1)
            v2570.Add(((0)), ((0)));
        return v2570;
    }

    System.Collections.Generic.Dictionary<int, int> RepeatWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset)
    {
        int v2571;
        System.Collections.Generic.Dictionary<int, int> v2572;
        v2572 = new System.Collections.Generic.Dictionary<int, int>();
        v2571 = (0);
        for (; v2571 < (1000); v2571 += 1)
        {
            if (!((v2571 < offset)))
                continue;
            v2572.Add((((0))), (((0))));
        }

        return v2572;
    }
}}