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
        int v2764;
        int[] v2765;
        v2765 = new int[(ArrayItems.Length)];
        System.Array.Copy(ArrayItems, (0), v2765, 0, (ArrayItems.Length));
        return v2765;
    }

    int[] EnumerableToArrayTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2766;
        int v2767;
        int v2768;
        int[] v2769;
        v2766 = EnumerableItems.GetEnumerator();
        v2767 = 0;
        v2768 = 8;
        v2769 = new int[8];
        try
        {
            while (v2766.MoveNext())
            {
                if (v2767 >= v2768)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2769, ref v2768);
                v2769[v2767] = (v2766.Current);
                v2767++;
            }
        }
        finally
        {
            v2766.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2769, v2767);
    }

    int[] ArrayWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2770;
        int v2771;
        int v2772;
        int v2773;
        int v2774;
        int[] v2775;
        v2772 = 0;
        v2773 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2773 -= (v2773 % 2);
        v2774 = 8;
        v2775 = new int[8];
        v2770 = (0);
        for (; v2770 < (ArrayItems.Length); v2770++)
        {
            v2771 = (ArrayItems[v2770]);
            if (!(((v2771) > offset)))
                continue;
            if (v2772 >= v2774)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2775, ref v2773, out v2774);
            v2775[v2772] = (v2771);
            v2772++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2775, v2772);
    }

    int[] EnumerableWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2776;
        int v2777;
        int v2778;
        int v2779;
        int[] v2780;
        v2776 = EnumerableItems.GetEnumerator();
        v2778 = 0;
        v2779 = 8;
        v2780 = new int[8];
        try
        {
            while (v2776.MoveNext())
            {
                v2777 = (v2776.Current);
                if (!(((v2777) > offset)))
                    continue;
                if (v2778 >= v2779)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2780, ref v2779);
                v2780[v2778] = (v2777);
                v2778++;
            }
        }
        finally
        {
            v2776.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2780, v2778);
    }

    int[] SimpleListWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2781;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2782;
        int v2783;
        int v2784;
        int v2785;
        int v2786;
        int v2787;
        int[] v2788;
        v2781 = SimpleListItems.Count;
        v2782 = SimpleListItems;
        v2785 = 0;
        v2786 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v2781))) - 3);
        v2786 -= (v2786 % 2);
        v2787 = 8;
        v2788 = new int[8];
        v2783 = (0);
        for (; v2783 < (v2781); v2783++)
        {
            v2784 = (v2782[v2783]);
            if (!(((v2784) > offset)))
                continue;
            if (v2785 >= v2787)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v2781), ref v2788, ref v2786, out v2787);
            v2788[v2785] = (v2784);
            v2785++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2788, v2785);
    }

    int[] ListWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2789;
        int v2790;
        int v2791;
        int v2792;
        int v2793;
        int v2794;
        int[] v2795;
        v2789 = ListItems.Count;
        v2792 = 0;
        v2793 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v2789))) - 3);
        v2793 -= (v2793 % 2);
        v2794 = 8;
        v2795 = new int[8];
        v2790 = (0);
        for (; v2790 < (v2789); v2790++)
        {
            v2791 = (ListItems[v2790]);
            if (!(((v2791) > offset)))
                continue;
            if (v2792 >= v2794)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v2789), ref v2795, ref v2793, out v2794);
            v2795[v2792] = (v2791);
            v2792++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2795, v2792);
    }

    int[] RangeWhereParamToArrayTestRewritten_ProceduralLinq1(int offset)
    {
        int v2796;
        int v2797;
        int v2798;
        int v2799;
        int v2800;
        int[] v2801;
        v2798 = 0;
        v2799 = (LinqRewrite.Core.IntExtensions.Log2((uint)((1000))) - 3);
        v2799 -= (v2799 % 2);
        v2800 = 8;
        v2801 = new int[8];
        v2796 = (0);
        for (; v2796 < (1000); v2796++)
        {
            v2797 = (v2796);
            if (!(((v2797) > offset)))
                continue;
            if (v2798 >= v2800)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (1000), ref v2801, ref v2799, out v2800);
            v2801[v2798] = (v2797);
            v2798++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2801, v2798);
    }

    int[] RangeParamToArrayTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2802;
        int[] v2803;
        v2803 = new int[(count)];
        v2802 = (0);
        for (; v2802 < (count); v2802++)
            v2803[v2802] = (v2802);
        return v2803;
    }

    int[] RepeatParamToArrayTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2804;
        int[] v2805;
        v2805 = new int[(count)];
        v2804 = (0);
        for (; v2804 < (count); v2804++)
            v2805[v2804] = (0);
        return v2805;
    }

    int[] RepeatWhereParamToArrayTestRewritten_ProceduralLinq1(int offset)
    {
        int v2806;
        int v2807;
        int v2808;
        int v2809;
        int v2810;
        int[] v2811;
        v2808 = 0;
        v2809 = (LinqRewrite.Core.IntExtensions.Log2((uint)((1000))) - 3);
        v2809 -= (v2809 % 2);
        v2810 = 8;
        v2811 = new int[8];
        v2806 = (0);
        for (; v2806 < (1000); v2806++)
        {
            v2807 = (0);
            if (!((v2806 < offset)))
                continue;
            if (v2808 >= v2810)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (1000), ref v2811, ref v2809, out v2810);
            v2811[v2808] = (v2807);
            v2808++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2811, v2808);
    }
}}