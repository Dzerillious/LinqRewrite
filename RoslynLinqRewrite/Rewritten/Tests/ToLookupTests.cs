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
        int v2897;
        int v2898;
        v2897 = (0);
        for (; v2897 < (ArrayItems.Length); v2897++)
        {
            v2898 = (ArrayItems[v2897]);
            if (!(((v2898) > offset)))
                continue;
            yield return (v2898);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableWhereParamToLookupTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2901;
        int v2902;
        v2901 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2901.MoveNext())
            {
                v2902 = (v2901.Current);
                if (!(((v2902) > offset)))
                    continue;
                yield return (v2902);
            }
        }
        finally
        {
            v2901.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListWhereParamToLookupTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2907;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2908;
        int v2909;
        int v2910;
        v2907 = SimpleListItems.Count;
        v2908 = SimpleListItems;
        v2909 = (0);
        for (; v2909 < (v2907); v2909++)
        {
            v2910 = (v2908[v2909]);
            if (!(((v2910) > offset)))
                continue;
            yield return (v2910);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ListWhereParamToLookupTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2914;
        int v2915;
        int v2916;
        v2914 = ListItems.Count;
        v2915 = (0);
        for (; v2915 < (v2914); v2915++)
        {
            v2916 = (ListItems[v2915]);
            if (!(((v2916) > offset)))
                continue;
            yield return (v2916);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeWhereParamToLookupTestRewritten_ProceduralLinq1(int offset)
    {
        int v2919;
        int v2920;
        v2919 = (0);
        for (; v2919 < (1000); v2919++)
        {
            v2920 = (v2919);
            if (!(((v2920) > offset)))
                continue;
            yield return (v2920);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeParamToLookupTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2922;
        v2922 = (0);
        for (; v2922 < (count); v2922++)
            yield return (v2922);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatParamToLookupTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2924;
        v2924 = (0);
        for (; v2924 < (count); v2924++)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatWhereParamToLookupTestRewritten_ProceduralLinq1(int offset)
    {
        int v2927;
        int v2928;
        v2927 = (0);
        for (; v2927 < (1000); v2927++)
        {
            v2928 = (0);
            if (!((v2927 < offset)))
                continue;
            yield return (v2928);
        }

        yield break;
    }
}}