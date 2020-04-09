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
        int v2847;
        System.Collections.Generic.List<int> v2848;
        v2848 = new System.Collections.Generic.List<int>();
        v2847 = (0);
        for (; v2847 < (ArrayItems.Length); v2847++)
            v2848.Add((ArrayItems[v2847]));
        return v2848;
    }

    System.Collections.Generic.List<int> ListToListTestRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v2850;
        int v2851;
        System.Collections.Generic.List<int> v2852;
        v2850 = ListItems.Count;
        v2852 = new System.Collections.Generic.List<int>();
        v2851 = (0);
        for (; v2851 < (v2850); v2851++)
            v2852.Add((ListItems[v2851]));
        return v2852;
    }

    System.Collections.Generic.List<int> SimpleListToListTestRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2854;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2855;
        int v2856;
        System.Collections.Generic.List<int> v2857;
        v2854 = SimpleListItems.Count;
        v2855 = SimpleListItems;
        v2857 = new System.Collections.Generic.List<int>();
        v2856 = (0);
        for (; v2856 < (v2854); v2856++)
            v2857.Add((v2855[v2856]));
        return v2857;
    }

    System.Collections.Generic.List<int> EnumerableToListTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2858;
        System.Collections.Generic.List<int> v2859;
        v2858 = EnumerableItems.GetEnumerator();
        v2859 = new System.Collections.Generic.List<int>();
        try
        {
            while (v2858.MoveNext())
                v2859.Add((v2858.Current));
        }
        finally
        {
            v2858.Dispose();
        }

        return v2859;
    }

    System.Collections.Generic.List<int> ArrayWhereParamToListTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2860;
        int v2861;
        System.Collections.Generic.List<int> v2862;
        v2862 = new System.Collections.Generic.List<int>();
        v2860 = (0);
        for (; v2860 < (ArrayItems.Length); v2860++)
        {
            v2861 = (ArrayItems[v2860]);
            if (!(((v2861) > offset)))
                continue;
            v2862.Add((v2861));
        }

        return v2862;
    }

    System.Collections.Generic.List<int> EnumerableWhereParamToListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2863;
        int v2864;
        System.Collections.Generic.List<int> v2865;
        v2863 = EnumerableItems.GetEnumerator();
        v2865 = new System.Collections.Generic.List<int>();
        try
        {
            while (v2863.MoveNext())
            {
                v2864 = (v2863.Current);
                if (!(((v2864) > offset)))
                    continue;
                v2865.Add((v2864));
            }
        }
        finally
        {
            v2863.Dispose();
        }

        return v2865;
    }

    System.Collections.Generic.List<int> SimpleListWhereParamToListTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2866;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2867;
        int v2868;
        int v2869;
        System.Collections.Generic.List<int> v2870;
        v2866 = SimpleListItems.Count;
        v2867 = SimpleListItems;
        v2870 = new System.Collections.Generic.List<int>();
        v2868 = (0);
        for (; v2868 < (v2866); v2868++)
        {
            v2869 = (v2867[v2868]);
            if (!(((v2869) > offset)))
                continue;
            v2870.Add((v2869));
        }

        return v2870;
    }

    System.Collections.Generic.List<int> ListWhereParamToListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2871;
        int v2872;
        int v2873;
        System.Collections.Generic.List<int> v2874;
        v2871 = ListItems.Count;
        v2874 = new System.Collections.Generic.List<int>();
        v2872 = (0);
        for (; v2872 < (v2871); v2872++)
        {
            v2873 = (ListItems[v2872]);
            if (!(((v2873) > offset)))
                continue;
            v2874.Add((v2873));
        }

        return v2874;
    }

    System.Collections.Generic.List<int> RangeWhereParamToListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2875;
        int v2876;
        System.Collections.Generic.List<int> v2877;
        v2877 = new System.Collections.Generic.List<int>();
        v2875 = (0);
        for (; v2875 < (1000); v2875++)
        {
            v2876 = (v2875);
            if (!(((v2876) > offset)))
                continue;
            v2877.Add((v2876));
        }

        return v2877;
    }

    System.Collections.Generic.List<int> RangeParamToListTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2878;
        System.Collections.Generic.List<int> v2879;
        v2879 = new System.Collections.Generic.List<int>();
        v2878 = (0);
        for (; v2878 < (count); v2878++)
            v2879.Add((v2878));
        return v2879;
    }

    System.Collections.Generic.List<int> RepeatParamToListTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2880;
        System.Collections.Generic.List<int> v2881;
        v2881 = new System.Collections.Generic.List<int>();
        v2880 = (0);
        for (; v2880 < (count); v2880++)
            v2881.Add((0));
        return v2881;
    }

    System.Collections.Generic.List<int> RepeatWhereParamToListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2882;
        int v2883;
        System.Collections.Generic.List<int> v2884;
        v2884 = new System.Collections.Generic.List<int>();
        v2882 = (0);
        for (; v2882 < (1000); v2882++)
        {
            v2883 = (0);
            if (!((v2882 < offset)))
                continue;
            v2884.Add((v2883));
        }

        return v2884;
    }
}}