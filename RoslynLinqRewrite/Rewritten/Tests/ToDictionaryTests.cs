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
        int v2813;
        System.Collections.Generic.Dictionary<int, int> v2814;
        v2814 = new System.Collections.Generic.Dictionary<int, int>();
        v2813 = (0);
        for (; v2813 < (ArrayItems.Length); v2813++)
            v2814.Add(((ArrayItems[v2813])), ((ArrayItems[v2813])));
        return v2814;
    }

    System.Collections.Generic.Dictionary<int, int> ListToDictionaryTestRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v2816;
        int v2817;
        System.Collections.Generic.Dictionary<int, int> v2818;
        v2816 = ListItems.Count;
        v2818 = new System.Collections.Generic.Dictionary<int, int>();
        v2817 = (0);
        for (; v2817 < (v2816); v2817++)
            v2818.Add(((ListItems[v2817])), ((ListItems[v2817])));
        return v2818;
    }

    System.Collections.Generic.Dictionary<int, int> EnumerableToDictionaryTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2819;
        System.Collections.Generic.Dictionary<int, int> v2820;
        v2819 = EnumerableItems.GetEnumerator();
        v2820 = new System.Collections.Generic.Dictionary<int, int>();
        try
        {
            while (v2819.MoveNext())
                v2820.Add(((v2819.Current)), ((v2819.Current)));
        }
        finally
        {
            v2819.Dispose();
        }

        return v2820;
    }

    System.Collections.Generic.Dictionary<int, int> ArrayWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2821;
        int v2822;
        System.Collections.Generic.Dictionary<int, int> v2823;
        v2823 = new System.Collections.Generic.Dictionary<int, int>();
        v2821 = (0);
        for (; v2821 < (ArrayItems.Length); v2821++)
        {
            v2822 = (ArrayItems[v2821]);
            if (!(((v2822) > offset)))
                continue;
            v2823.Add(((v2822)), ((v2822)));
        }

        return v2823;
    }

    System.Collections.Generic.Dictionary<int, int> EnumerableWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2824;
        int v2825;
        System.Collections.Generic.Dictionary<int, int> v2826;
        v2824 = EnumerableItems.GetEnumerator();
        v2826 = new System.Collections.Generic.Dictionary<int, int>();
        try
        {
            while (v2824.MoveNext())
            {
                v2825 = (v2824.Current);
                if (!(((v2825) > offset)))
                    continue;
                v2826.Add(((v2825)), ((v2825)));
            }
        }
        finally
        {
            v2824.Dispose();
        }

        return v2826;
    }

    System.Collections.Generic.Dictionary<int, int> SimpleListWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2827;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2828;
        int v2829;
        int v2830;
        System.Collections.Generic.Dictionary<int, int> v2831;
        v2827 = SimpleListItems.Count;
        v2828 = SimpleListItems;
        v2831 = new System.Collections.Generic.Dictionary<int, int>();
        v2829 = (0);
        for (; v2829 < (v2827); v2829++)
        {
            v2830 = (v2828[v2829]);
            if (!(((v2830) > offset)))
                continue;
            v2831.Add(((v2830)), ((v2830)));
        }

        return v2831;
    }

    System.Collections.Generic.Dictionary<int, int> ListWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2832;
        int v2833;
        int v2834;
        System.Collections.Generic.Dictionary<int, int> v2835;
        v2832 = ListItems.Count;
        v2835 = new System.Collections.Generic.Dictionary<int, int>();
        v2833 = (0);
        for (; v2833 < (v2832); v2833++)
        {
            v2834 = (ListItems[v2833]);
            if (!(((v2834) > offset)))
                continue;
            v2835.Add(((v2834)), ((v2834)));
        }

        return v2835;
    }

    System.Collections.Generic.Dictionary<int, int> RangeWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset)
    {
        int v2836;
        int v2837;
        System.Collections.Generic.Dictionary<int, int> v2838;
        v2838 = new System.Collections.Generic.Dictionary<int, int>();
        v2836 = (0);
        for (; v2836 < (1000); v2836++)
        {
            v2837 = (v2836);
            if (!(((v2837) > offset)))
                continue;
            v2838.Add(((v2837)), ((v2837)));
        }

        return v2838;
    }

    System.Collections.Generic.Dictionary<int, int> RangeParamToDictionaryTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2839;
        System.Collections.Generic.Dictionary<int, int> v2840;
        v2840 = new System.Collections.Generic.Dictionary<int, int>();
        v2839 = (0);
        for (; v2839 < (count); v2839++)
            v2840.Add(((v2839)), ((v2839)));
        return v2840;
    }

    System.Collections.Generic.Dictionary<int, int> RepeatParamToDictionaryTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2841;
        System.Collections.Generic.Dictionary<int, int> v2842;
        v2842 = new System.Collections.Generic.Dictionary<int, int>();
        v2841 = (0);
        for (; v2841 < (count); v2841++)
            v2842.Add(((0)), ((0)));
        return v2842;
    }

    System.Collections.Generic.Dictionary<int, int> RepeatWhereParamToDictionaryTestRewritten_ProceduralLinq1(int offset)
    {
        int v2843;
        int v2844;
        System.Collections.Generic.Dictionary<int, int> v2845;
        v2845 = new System.Collections.Generic.Dictionary<int, int>();
        v2843 = (0);
        for (; v2843 < (1000); v2843++)
        {
            v2844 = (0);
            if (!((v2843 < offset)))
                continue;
            v2845.Add(((v2844)), ((v2844)));
        }

        return v2845;
    }
}}