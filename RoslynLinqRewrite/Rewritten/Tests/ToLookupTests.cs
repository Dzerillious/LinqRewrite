using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ToLookupTests
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
        TestsExtensions.TestEquals(nameof(ArrayToLookupTest), ArrayToLookupTest, ArrayToLookupTestRewritten);
        TestsExtensions.TestEquals(nameof(ListToLookupTest), ListToLookupTest, ListToLookupTestRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListToLookupTest), SimpleListToLookupTest, SimpleListToLookupTestRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableToLookupTest), EnumerableToLookupTest, EnumerableToLookupTestRewritten);
        for (int i = -1; i < 1001; i++)
        {
            TestsExtensions.TestEquals(nameof(ArrayWhereParamToLookupTest) + i, () => ArrayWhereParamToLookupTest(i), () => ArrayWhereParamToLookupTestRewritten(i));
            TestsExtensions.TestEquals(nameof(EnumerableWhereParamToLookupTest) + i, () => EnumerableWhereParamToLookupTest(i), () => EnumerableWhereParamToLookupTestRewritten(i));
            TestsExtensions.TestEquals(nameof(SimpleListWhereParamToLookupTest) + i, () => SimpleListWhereParamToLookupTest(i), () => SimpleListWhereParamToLookupTestRewritten(i));
            TestsExtensions.TestEquals(nameof(ListWhereParamToLookupTest) + i, () => ListWhereParamToLookupTest(i), () => ListWhereParamToLookupTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RangeWhereParamToLookupTest) + i, () => RangeWhereParamToLookupTest(i), () => RangeWhereParamToLookupTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RangeParamToLookupTest) + i, () => RangeParamToLookupTest(i), () => RangeParamToLookupTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RepeatParamToLookupTest) + i, () => RepeatParamToLookupTest(i), () => RepeatParamToLookupTestRewritten(i));
            TestsExtensions.TestEquals(nameof(RepeatWhereParamToLookupTest) + i, () => RepeatWhereParamToLookupTest(i), () => RepeatWhereParamToLookupTestRewritten(i));
        }
    }

    [NoRewrite]
    public ILookup<int, int> ArrayToLookupTest()
    {
        return ArrayItems.ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> ArrayToLookupTestRewritten()
    {
        return ArrayItems.ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> ListToLookupTest()
    {
        return ListItems.ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> ListToLookupTestRewritten()
    {
        return ListItems.ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> SimpleListToLookupTest()
    {
        return SimpleListItems.ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> SimpleListToLookupTestRewritten()
    {
        return SimpleListItems.ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> EnumerableToLookupTest()
    {
        return EnumerableItems.ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> EnumerableToLookupTestRewritten()
    {
        return EnumerableItems.ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> ArrayWhereParamToLookupTest(int offset)
    {
        return ArrayItems.Where(x => x > offset).ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> ArrayWhereParamToLookupTestRewritten(int offset)
    {
        return ArrayWhereParamToLookupTestRewritten_ProceduralLinq1(offset, ArrayItems).ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> EnumerableWhereParamToLookupTest(int offset)
    {
        return EnumerableItems.Where(x => x > offset).ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> EnumerableWhereParamToLookupTestRewritten(int offset)
    {
        return EnumerableWhereParamToLookupTestRewritten_ProceduralLinq1(offset, EnumerableItems).ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> SimpleListWhereParamToLookupTest(int offset)
    {
        return SimpleListItems.Where(x => x > offset).ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> SimpleListWhereParamToLookupTestRewritten(int offset)
    {
        return SimpleListWhereParamToLookupTestRewritten_ProceduralLinq1(offset, SimpleListItems).ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> ListWhereParamToLookupTest(int offset)
    {
        return ListItems.Where(x => x > offset).ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> ListWhereParamToLookupTestRewritten(int offset)
    {
        return ListWhereParamToLookupTestRewritten_ProceduralLinq1(offset, ListItems).ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> RangeWhereParamToLookupTest(int offset)
    {
        return Enumerable.Range(0, 1000).Where(x => x > offset).ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> RangeWhereParamToLookupTestRewritten(int offset)
    {
        return RangeWhereParamToLookupTestRewritten_ProceduralLinq1(offset).ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> RangeParamToLookupTest(int count)
    {
        return Enumerable.Range(0, count).ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> RangeParamToLookupTestRewritten(int count)
    {
        return RangeParamToLookupTestRewritten_ProceduralLinq1(count).ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> RepeatParamToLookupTest(int count)
    {
        return Enumerable.Repeat(0, count).ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> RepeatParamToLookupTestRewritten(int count)
    {
        return RepeatParamToLookupTestRewritten_ProceduralLinq1(count).ToLookup(x => x, x => x);
    } //EndMethod

    [NoRewrite]
    public ILookup<int, int> RepeatWhereParamToLookupTest(int offset)
    {
        return Enumerable.Repeat(0, 1000).Where((x, i) => i < offset).ToLookup(x => x, x => x);
    } //EndMethod

    public ILookup<int, int> RepeatWhereParamToLookupTestRewritten(int offset)
    {
        return RepeatWhereParamToLookupTestRewritten_ProceduralLinq1(offset).ToLookup(x => x, x => x);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayWhereParamToLookupTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2618;
        v2618 = (0);
        for (; v2618 < (ArrayItems.Length); v2618 += 1)
        {
            if (!((((ArrayItems[v2618])) > offset)))
                continue;
            yield return ((ArrayItems[v2618]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableWhereParamToLookupTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2621;
        int v2622;
        v2621 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2621.MoveNext())
            {
                v2622 = (v2621.Current);
                if (!(((v2622) > offset)))
                    continue;
                yield return (v2622);
            }
        }
        finally
        {
            v2621.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListWhereParamToLookupTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2626;
        v2626 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2627;
        v2627 = SimpleListItems;
        int v2628;
        v2628 = (0);
        for (; v2628 < (v2626); v2628 += 1)
        {
            if (!((((v2627[v2628])) > offset)))
                continue;
            yield return ((v2627[v2628]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ListWhereParamToLookupTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2631;
        int v2632;
        v2632 = (ListItems.Count);
        v2631 = (0);
        for (; v2631 < v2632; v2631 += 1)
        {
            if (!((((ListItems[v2631])) > offset)))
                continue;
            yield return ((ListItems[v2631]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeWhereParamToLookupTestRewritten_ProceduralLinq1(int offset)
    {
        int v2634;
        v2634 = (0);
        for (; v2634 < (1000); v2634 += (1))
        {
            if (!((((v2634)) > offset)))
                continue;
            yield return ((v2634));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeParamToLookupTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2636;
        v2636 = (0);
        for (; v2636 < (count); v2636 += (1))
            yield return (v2636);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatParamToLookupTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2638;
        v2638 = (0);
        for (; v2638 < (count); v2638 += 1)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatWhereParamToLookupTestRewritten_ProceduralLinq1(int offset)
    {
        int v2640;
        v2640 = (0);
        for (; v2640 < (1000); v2640 += 1)
        {
            if (!((v2640 < offset)))
                continue;
            yield return ((0));
        }

        yield break;
    }
}}