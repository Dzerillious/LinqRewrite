using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class WhereTests
{
    [Datapoints]
    private int[] EnumerableItems = Enumerable.Range(0, 1000).ToArray();
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 1000).ToArray();
    public double Selector(int x) => x + 3;
    public double Selector(double x) => x + 3;
    public bool Predicate(int x) => x > 500;
    public bool Predicate(double x) => x > 500;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayWhereToSimpleList), ArrayWhereToSimpleList, ArrayWhereToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereToSimpleList), SelectWhereToSimpleList, SelectWhereToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(MultipleSelectWhereToSimpleList), MultipleSelectWhereToSimpleList, MultipleSelectWhereToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereToArray), SelectWhereToArray, SelectWhereToArrayRewritten);
        TestsExtensions.TestEquals(nameof(MultipleSelectWhereToArray), MultipleSelectWhereToArray, MultipleSelectWhereToArrayRewritten);
        for (int i = -2; i < 1002; i++)
            TestsExtensions.TestEquals(nameof(ParametrizedWhere) + i, () => ParametrizedWhere(i), () => ParametrizedWhereRewritten(i));
        TestsExtensions.TestEquals(nameof(WhereChangingParam), WhereChangingParam, WhereChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(WhereChangingParamToArray), WhereChangingParamToArray, WhereChangingParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(WhereChangingParamToSimpleList), WhereChangingParamToSimpleList, WhereChangingParamToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(WhereIndexToArray), WhereIndexToArray, WhereIndexToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayWhereToSimpleList()
    {
        return ArrayItems.Where(x => x > 500).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> ArrayWhereToSimpleListRewritten()
    {
        return ArrayWhereToSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectWhereToSimpleList()
    {
        return ArrayItems.Select(x => x + 5).Where(x => x > 500).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SelectWhereToSimpleListRewritten()
    {
        return SelectWhereToSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MultipleSelectWhereToSimpleList()
    {
        return ArrayItems.Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> MultipleSelectWhereToSimpleListRewritten()
    {
        return MultipleSelectWhereToSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectWhereToArray()
    {
        return ArrayItems.Select(x => x + 5).Where(x => x > 500).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectWhereToArrayRewritten()
    {
        return SelectWhereToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MultipleSelectWhereToArray()
    {
        return ArrayItems.Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> MultipleSelectWhereToArrayRewritten()
    {
        return MultipleSelectWhereToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> MultipleSelectMethodWhereToArray()
    {
        return ArrayItems.Select(Selector).Where(Predicate).Select(Selector).Where(Predicate).Select(Selector).Where(Predicate).Select(Selector).Where(Predicate).ToArray();
    } //EndMethod

    public IEnumerable<double> MultipleSelectWhereMethodToArrayRewritten()
    {
        return MultipleSelectWhereMethodToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ParametrizedWhere(int offset)
    {
        return ArrayItems.Where(x => x > offset);
    } //EndMethod

    public IEnumerable<int> ParametrizedWhereRewritten(int offset)
    {
        return ParametrizedWhereRewritten_ProceduralLinq1(offset, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ParametrizedWhereToArray(int offset)
    {
        return ArrayItems.Where(x => x > offset).ToArray();
    } //EndMethod

    public IEnumerable<int> ParametrizedWhereToArrayRewritten(int offset)
    {
        return ParametrizedWhereToArrayRewritten_ProceduralLinq1(offset, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ParametrizedWhereToSimpleList(int offset)
    {
        return ArrayItems.Where(x => x > offset).ToSimpleList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> WhereChangingParam()
    {
        var a = 50;
        return ArrayItems.Where(x => x > 2 * a).Select(x => x + a++);
    } //EndMethod

    public IEnumerable<int> WhereChangingParamRewritten()
    {
        var a = 50;
        return WhereChangingParamRewritten_ProceduralLinq1(ArrayItems, x => x > 2 * a, x => x + a++);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> WhereChangingParamToArray()
    {
        var a = 50;
        return ArrayItems.Where(x => x > 2 * a).Select(x => x + a++).ToArray();
    } //EndMethod

    public IEnumerable<int> WhereChangingParamToArrayRewritten()
    {
        var a = 50;
        return WhereChangingParamToArrayRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> WhereChangingParamToSimpleList()
    {
        var a = 50;
        return ArrayItems.Where(x => x > 2 * a).Select(x => x + a++).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> WhereChangingParamToSimpleListRewritten()
    {
        var a = 50;
        return WhereChangingParamToSimpleListRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> WhereIndexToArray()
    {
        return ArrayItems.Where((x, i) => x > 200 + i / 2).ToArray();
    } //EndMethod

    public IEnumerable<int> WhereIndexToArrayRewritten()
    {
        return WhereIndexToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2830;
        int v2831;
        int v2832;
        int v2833;
        int[] v2834;
        SimpleList<int> v2835;
        v2831 = 0;
        v2832 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2832 -= (v2832 % 2);
        v2833 = 8;
        v2834 = new int[8];
        v2830 = 0;
        for (; v2830 < ArrayItems.Length; v2830++)
        {
            if (!((ArrayItems[v2830] > 500)))
                continue;
            if (v2831 >= v2833)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2834, ref v2832, out v2833);
            v2834[v2831] = ArrayItems[v2830];
            v2831++;
        }

        v2835 = new SimpleList<int>();
        v2835.Items = v2834;
        v2835.Count = v2831;
        return v2835;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2836;
        int v2837;
        int v2838;
        int v2839;
        int v2840;
        int[] v2841;
        SimpleList<int> v2842;
        v2838 = 0;
        v2839 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2839 -= (v2839 % 2);
        v2840 = 8;
        v2841 = new int[8];
        v2836 = 0;
        for (; v2836 < ArrayItems.Length; v2836++)
        {
            v2837 = (ArrayItems[v2836] + 5);
            if (!((v2837 > 500)))
                continue;
            if (v2838 >= v2840)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2841, ref v2839, out v2840);
            v2841[v2838] = v2837;
            v2838++;
        }

        v2842 = new SimpleList<int>();
        v2842.Items = v2841;
        v2842.Count = v2838;
        return v2842;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2843;
        int v2844;
        int v2845;
        int v2846;
        int v2847;
        int v2848;
        int v2849;
        int v2850;
        int[] v2851;
        SimpleList<int> v2852;
        v2848 = 0;
        v2849 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2849 -= (v2849 % 2);
        v2850 = 8;
        v2851 = new int[8];
        v2843 = 0;
        for (; v2843 < ArrayItems.Length; v2843++)
        {
            v2844 = (ArrayItems[v2843] + 5);
            if (!((v2844 > 500)))
                continue;
            v2845 = (v2844 + 5);
            if (!((v2845 > 500)))
                continue;
            v2846 = (v2845 + 5);
            if (!((v2846 > 500)))
                continue;
            v2847 = (v2846 + 5);
            if (!((v2847 > 500)))
                continue;
            if (v2848 >= v2850)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2851, ref v2849, out v2850);
            v2851[v2848] = v2847;
            v2848++;
        }

        v2852 = new SimpleList<int>();
        v2852.Items = v2851;
        v2852.Count = v2848;
        return v2852;
    }

    int[] SelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2853;
        int v2854;
        int v2855;
        int v2856;
        int v2857;
        int[] v2858;
        v2855 = 0;
        v2856 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2856 -= (v2856 % 2);
        v2857 = 8;
        v2858 = new int[8];
        v2853 = 0;
        for (; v2853 < ArrayItems.Length; v2853++)
        {
            v2854 = (ArrayItems[v2853] + 5);
            if (!((v2854 > 500)))
                continue;
            if (v2855 >= v2857)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2858, ref v2856, out v2857);
            v2858[v2855] = v2854;
            v2855++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2858, v2855);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2859;
        int v2860;
        int v2861;
        int v2862;
        int v2863;
        int v2864;
        int v2865;
        int v2866;
        int[] v2867;
        SimpleList<int> v2868;
        v2864 = 0;
        v2865 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2865 -= (v2865 % 2);
        v2866 = 8;
        v2867 = new int[8];
        v2859 = 0;
        for (; v2859 < ArrayItems.Length; v2859++)
        {
            v2860 = (ArrayItems[v2859] + 5);
            if (!((v2860 > 500)))
                continue;
            v2861 = (v2860 + 5);
            if (!((v2861 > 500)))
                continue;
            v2862 = (v2861 + 5);
            if (!((v2862 > 500)))
                continue;
            v2863 = (v2862 + 5);
            if (!((v2863 > 500)))
                continue;
            if (v2864 >= v2866)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2867, ref v2865, out v2866);
            v2867[v2864] = v2863;
            v2864++;
        }

        v2868 = new SimpleList<int>();
        v2868.Items = v2867;
        v2868.Count = v2864;
        return v2868;
    }

    double[] MultipleSelectWhereMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2869;
        double v2870;
        double v2871;
        double v2872;
        double v2873;
        int v2874;
        int v2875;
        int v2876;
        double[] v2877;
        v2874 = 0;
        v2875 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2875 -= (v2875 % 2);
        v2876 = 8;
        v2877 = new double[8];
        v2869 = 0;
        for (; v2869 < ArrayItems.Length; v2869++)
        {
            v2870 = Selector(ArrayItems[v2869]);
            if (!(Predicate(v2870)))
                continue;
            v2871 = Selector(v2870);
            if (!(Predicate(v2871)))
                continue;
            v2872 = Selector(v2871);
            if (!(Predicate(v2872)))
                continue;
            v2873 = Selector(v2872);
            if (!(Predicate(v2873)))
                continue;
            if (v2874 >= v2876)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2877, ref v2875, out v2876);
            v2877[v2874] = v2873;
            v2874++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2877, v2874);
    }

    System.Collections.Generic.IEnumerable<int> ParametrizedWhereRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2878;
        v2878 = 0;
        for (; v2878 < ArrayItems.Length; v2878++)
        {
            if (!((ArrayItems[v2878] > offset)))
                continue;
            yield return ArrayItems[v2878];
        }
    }

    int[] ParametrizedWhereToArrayRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2879;
        int v2880;
        int v2881;
        int v2882;
        int[] v2883;
        v2880 = 0;
        v2881 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2881 -= (v2881 % 2);
        v2882 = 8;
        v2883 = new int[8];
        v2879 = 0;
        for (; v2879 < ArrayItems.Length; v2879++)
        {
            if (!((ArrayItems[v2879] > offset)))
                continue;
            if (v2880 >= v2882)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2883, ref v2881, out v2882);
            v2883[v2880] = ArrayItems[v2879];
            v2880++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2883, v2880);
    }

    System.Collections.Generic.IEnumerable<int> WhereChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2885, System.Func<int, int> v2886)
    {
        int v2884;
        v2884 = 0;
        for (; v2884 < ArrayItems.Length; v2884++)
        {
            if (!(v2885(ArrayItems[v2884])))
                continue;
            yield return v2886(ArrayItems[v2884]);
        }
    }

    int[] WhereChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2887;
        int v2888;
        int v2889;
        int v2890;
        int[] v2891;
        v2888 = 0;
        v2889 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2889 -= (v2889 % 2);
        v2890 = 8;
        v2891 = new int[8];
        v2887 = 0;
        for (; v2887 < ArrayItems.Length; v2887++)
        {
            if (!((ArrayItems[v2887] > 2 * a)))
                continue;
            if (v2888 >= v2890)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2891, ref v2889, out v2890);
            v2891[v2888] = (ArrayItems[v2887] + a++);
            v2888++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2891, v2888);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> WhereChangingParamToSimpleListRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2892;
        int v2893;
        int v2894;
        int v2895;
        int[] v2896;
        SimpleList<int> v2897;
        v2893 = 0;
        v2894 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2894 -= (v2894 % 2);
        v2895 = 8;
        v2896 = new int[8];
        v2892 = 0;
        for (; v2892 < ArrayItems.Length; v2892++)
        {
            if (!((ArrayItems[v2892] > 2 * a)))
                continue;
            if (v2893 >= v2895)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2896, ref v2894, out v2895);
            v2896[v2893] = (ArrayItems[v2892] + a++);
            v2893++;
        }

        v2897 = new SimpleList<int>();
        v2897.Items = v2896;
        v2897.Count = v2893;
        return v2897;
    }

    int[] WhereIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2898;
        int v2899;
        int v2900;
        int v2901;
        int[] v2902;
        v2899 = 0;
        v2900 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2900 -= (v2900 % 2);
        v2901 = 8;
        v2902 = new int[8];
        v2898 = 0;
        for (; v2898 < ArrayItems.Length; v2898++)
        {
            if (!((ArrayItems[v2898] > 200 + v2898 / 2)))
                continue;
            if (v2899 >= v2901)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2902, ref v2900, out v2901);
            v2902[v2899] = ArrayItems[v2898];
            v2899++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2902, v2899);
    }
}}