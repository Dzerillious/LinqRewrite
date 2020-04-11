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
        int v2642;
        v2642 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2643;
        v2643 = SimpleListItems;
        int v2644;
        int[] v2645;
        SimpleList<int> v2646;
        v2645 = new int[(v2642)];
        v2644 = (0);
        for (; v2644 < (v2642); v2644 += 1)
            v2645[v2644] = (v2643[v2644]);
        v2646 = new SimpleList<int>();
        v2646.Items = v2645;
        v2646.Count = (v2642);
        return v2646;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> EnumerableToSimpleListTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2647;
        int v2648;
        int v2649;
        int[] v2650;
        SimpleList<int> v2651;
        v2647 = EnumerableItems.GetEnumerator();
        v2648 = 0;
        v2649 = 8;
        v2650 = new int[8];
        try
        {
            while (v2647.MoveNext())
            {
                if (v2648 >= v2649)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2650, ref v2649);
                v2650[v2648] = (v2647.Current);
                v2648++;
            }
        }
        finally
        {
            v2647.Dispose();
        }

        v2651 = new SimpleList<int>();
        v2651.Items = v2650;
        v2651.Count = v2648;
        return v2651;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2652;
        int v2653;
        int v2654;
        int v2655;
        int[] v2656;
        SimpleList<int> v2657;
        v2653 = 0;
        v2654 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2654 -= (v2654 % 2);
        v2655 = 8;
        v2656 = new int[8];
        v2652 = (0);
        for (; v2652 < (ArrayItems.Length); v2652 += 1)
        {
            if (!((((ArrayItems[v2652])) > offset)))
                continue;
            if (v2653 >= v2655)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2656, ref v2654, out v2655);
            v2656[v2653] = ((ArrayItems[v2652]));
            v2653++;
        }

        v2657 = new SimpleList<int>();
        v2657.Items = v2656;
        v2657.Count = v2653;
        return v2657;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> EnumerableWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2658;
        int v2659;
        int v2660;
        int v2661;
        int[] v2662;
        SimpleList<int> v2663;
        v2658 = EnumerableItems.GetEnumerator();
        v2660 = 0;
        v2661 = 8;
        v2662 = new int[8];
        try
        {
            while (v2658.MoveNext())
            {
                v2659 = (v2658.Current);
                if (!(((v2659) > offset)))
                    continue;
                if (v2660 >= v2661)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2662, ref v2661);
                v2662[v2660] = (v2659);
                v2660++;
            }
        }
        finally
        {
            v2658.Dispose();
        }

        v2663 = new SimpleList<int>();
        v2663.Items = v2662;
        v2663.Count = v2660;
        return v2663;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2664;
        v2664 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2665;
        v2665 = SimpleListItems;
        int v2666;
        int v2667;
        int v2668;
        int v2669;
        int[] v2670;
        SimpleList<int> v2671;
        v2667 = 0;
        v2668 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v2664))) - 3);
        v2668 -= (v2668 % 2);
        v2669 = 8;
        v2670 = new int[8];
        v2666 = (0);
        for (; v2666 < (v2664); v2666 += 1)
        {
            if (!((((v2665[v2666])) > offset)))
                continue;
            if (v2667 >= v2669)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v2664), ref v2670, ref v2668, out v2669);
            v2670[v2667] = ((v2665[v2666]));
            v2667++;
        }

        v2671 = new SimpleList<int>();
        v2671.Items = v2670;
        v2671.Count = v2667;
        return v2671;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ListWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2672;
        int v2673;
        int v2674;
        int v2675;
        int[] v2676;
        SimpleList<int> v2677;
        int v2678;
        v2678 = (ListItems.Count);
        v2673 = 0;
        v2674 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ListItems.Count))) - 3);
        v2674 -= (v2674 % 2);
        v2675 = 8;
        v2676 = new int[8];
        v2672 = (0);
        for (; v2672 < v2678; v2672 += 1)
        {
            if (!((((ListItems[v2672])) > offset)))
                continue;
            if (v2673 >= v2675)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ListItems.Count), ref v2676, ref v2674, out v2675);
            v2676[v2673] = ((ListItems[v2672]));
            v2673++;
        }

        v2677 = new SimpleList<int>();
        v2677.Items = v2676;
        v2677.Count = v2673;
        return v2677;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RangeWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2679;
        int v2680;
        int v2681;
        int v2682;
        int[] v2683;
        SimpleList<int> v2684;
        v2680 = 0;
        v2681 = (LinqRewrite.Core.IntExtensions.Log2((uint)((1000))) - 3);
        v2681 -= (v2681 % 2);
        v2682 = 8;
        v2683 = new int[8];
        v2679 = (0);
        for (; v2679 < (1000); v2679 += (1))
        {
            if (!((((v2679)) > offset)))
                continue;
            if (v2680 >= v2682)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (1000), ref v2683, ref v2681, out v2682);
            v2683[v2680] = ((v2679));
            v2680++;
        }

        v2684 = new SimpleList<int>();
        v2684.Items = v2683;
        v2684.Count = v2680;
        return v2684;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RangeParamToSimpleListTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2685;
        int[] v2686;
        SimpleList<int> v2687;
        v2686 = new int[(count)];
        v2685 = (0);
        for (; v2685 < (count); v2685 += (1))
            v2686[v2685] = (v2685);
        v2687 = new SimpleList<int>();
        v2687.Items = v2686;
        v2687.Count = (count);
        return v2687;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RepeatParamToSimpleListTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2688;
        int[] v2689;
        SimpleList<int> v2690;
        v2689 = new int[(count)];
        v2688 = (0);
        for (; v2688 < (count); v2688 += 1)
            v2689[v2688] = (0);
        v2690 = new SimpleList<int>();
        v2690.Items = v2689;
        v2690.Count = (count);
        return v2690;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RepeatWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2691;
        int v2692;
        int v2693;
        int v2694;
        int[] v2695;
        SimpleList<int> v2696;
        v2692 = 0;
        v2693 = (LinqRewrite.Core.IntExtensions.Log2((uint)((1000))) - 3);
        v2693 -= (v2693 % 2);
        v2694 = 8;
        v2695 = new int[8];
        v2691 = (0);
        for (; v2691 < (1000); v2691 += 1)
        {
            if (!((v2691 < offset)))
                continue;
            if (v2692 >= v2694)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (1000), ref v2695, ref v2693, out v2694);
            v2695[v2692] = ((0));
            v2692++;
        }

        v2696 = new SimpleList<int>();
        v2696.Items = v2695;
        v2696.Count = v2692;
        return v2696;
    }
}}