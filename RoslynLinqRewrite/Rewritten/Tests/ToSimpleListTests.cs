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
        int v2930;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2931;
        int v2932;
        int[] v2933;
        SimpleList<int> v2934;
        v2930 = SimpleListItems.Count;
        v2931 = SimpleListItems;
        v2933 = new int[(v2930)];
        v2932 = (0);
        for (; v2932 < (v2930); v2932++)
            v2933[v2932] = (v2931[v2932]);
        v2934 = new SimpleList<int>();
        v2934.Items = v2933;
        v2934.Count = (v2930);
        return v2934;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> EnumerableToSimpleListTestRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2935;
        int v2936;
        int v2937;
        int[] v2938;
        SimpleList<int> v2939;
        v2935 = EnumerableItems.GetEnumerator();
        v2936 = 0;
        v2937 = 8;
        v2938 = new int[8];
        try
        {
            while (v2935.MoveNext())
            {
                if (v2936 >= v2937)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2938, ref v2937);
                v2938[v2936] = (v2935.Current);
                v2936++;
            }
        }
        finally
        {
            v2935.Dispose();
        }

        v2939 = new SimpleList<int>();
        v2939.Items = v2938;
        v2939.Count = v2936;
        return v2939;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2940;
        int v2941;
        int v2942;
        int v2943;
        int v2944;
        int[] v2945;
        SimpleList<int> v2946;
        v2942 = 0;
        v2943 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2943 -= (v2943 % 2);
        v2944 = 8;
        v2945 = new int[8];
        v2940 = (0);
        for (; v2940 < (ArrayItems.Length); v2940++)
        {
            v2941 = (ArrayItems[v2940]);
            if (!(((v2941) > offset)))
                continue;
            if (v2942 >= v2944)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2945, ref v2943, out v2944);
            v2945[v2942] = (v2941);
            v2942++;
        }

        v2946 = new SimpleList<int>();
        v2946.Items = v2945;
        v2946.Count = v2942;
        return v2946;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> EnumerableWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2947;
        int v2948;
        int v2949;
        int v2950;
        int[] v2951;
        SimpleList<int> v2952;
        v2947 = EnumerableItems.GetEnumerator();
        v2949 = 0;
        v2950 = 8;
        v2951 = new int[8];
        try
        {
            while (v2947.MoveNext())
            {
                v2948 = (v2947.Current);
                if (!(((v2948) > offset)))
                    continue;
                if (v2949 >= v2950)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2951, ref v2950);
                v2951[v2949] = (v2948);
                v2949++;
            }
        }
        finally
        {
            v2947.Dispose();
        }

        v2952 = new SimpleList<int>();
        v2952.Items = v2951;
        v2952.Count = v2949;
        return v2952;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2953;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2954;
        int v2955;
        int v2956;
        int v2957;
        int v2958;
        int v2959;
        int[] v2960;
        SimpleList<int> v2961;
        v2953 = SimpleListItems.Count;
        v2954 = SimpleListItems;
        v2957 = 0;
        v2958 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v2953))) - 3);
        v2958 -= (v2958 % 2);
        v2959 = 8;
        v2960 = new int[8];
        v2955 = (0);
        for (; v2955 < (v2953); v2955++)
        {
            v2956 = (v2954[v2955]);
            if (!(((v2956) > offset)))
                continue;
            if (v2957 >= v2959)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v2953), ref v2960, ref v2958, out v2959);
            v2960[v2957] = (v2956);
            v2957++;
        }

        v2961 = new SimpleList<int>();
        v2961.Items = v2960;
        v2961.Count = v2957;
        return v2961;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ListWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2962;
        int v2963;
        int v2964;
        int v2965;
        int v2966;
        int v2967;
        int[] v2968;
        SimpleList<int> v2969;
        v2962 = ListItems.Count;
        v2965 = 0;
        v2966 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v2962))) - 3);
        v2966 -= (v2966 % 2);
        v2967 = 8;
        v2968 = new int[8];
        v2963 = (0);
        for (; v2963 < (v2962); v2963++)
        {
            v2964 = (ListItems[v2963]);
            if (!(((v2964) > offset)))
                continue;
            if (v2965 >= v2967)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v2962), ref v2968, ref v2966, out v2967);
            v2968[v2965] = (v2964);
            v2965++;
        }

        v2969 = new SimpleList<int>();
        v2969.Items = v2968;
        v2969.Count = v2965;
        return v2969;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RangeWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2970;
        int v2971;
        int v2972;
        int v2973;
        int v2974;
        int[] v2975;
        SimpleList<int> v2976;
        v2972 = 0;
        v2973 = (LinqRewrite.Core.IntExtensions.Log2((uint)((1000))) - 3);
        v2973 -= (v2973 % 2);
        v2974 = 8;
        v2975 = new int[8];
        v2970 = (0);
        for (; v2970 < (1000); v2970++)
        {
            v2971 = (v2970);
            if (!(((v2971) > offset)))
                continue;
            if (v2972 >= v2974)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (1000), ref v2975, ref v2973, out v2974);
            v2975[v2972] = (v2971);
            v2972++;
        }

        v2976 = new SimpleList<int>();
        v2976.Items = v2975;
        v2976.Count = v2972;
        return v2976;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RangeParamToSimpleListTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2977;
        int[] v2978;
        SimpleList<int> v2979;
        v2978 = new int[(count)];
        v2977 = (0);
        for (; v2977 < (count); v2977++)
            v2978[v2977] = (v2977);
        v2979 = new SimpleList<int>();
        v2979.Items = v2978;
        v2979.Count = (count);
        return v2979;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RepeatParamToSimpleListTestRewritten_ProceduralLinq1(int count)
    {
        if (0 > count)
            throw new System.InvalidOperationException("Index out of range");
        int v2980;
        int[] v2981;
        SimpleList<int> v2982;
        v2981 = new int[(count)];
        v2980 = (0);
        for (; v2980 < (count); v2980++)
            v2981[v2980] = (0);
        v2982 = new SimpleList<int>();
        v2982.Items = v2981;
        v2982.Count = (count);
        return v2982;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RepeatWhereParamToSimpleListTestRewritten_ProceduralLinq1(int offset)
    {
        int v2983;
        int v2984;
        int v2985;
        int v2986;
        int v2987;
        int[] v2988;
        SimpleList<int> v2989;
        v2985 = 0;
        v2986 = (LinqRewrite.Core.IntExtensions.Log2((uint)((1000))) - 3);
        v2986 -= (v2986 % 2);
        v2987 = 8;
        v2988 = new int[8];
        v2983 = (0);
        for (; v2983 < (1000); v2983++)
        {
            v2984 = (0);
            if (!((v2983 < offset)))
                continue;
            if (v2985 >= v2987)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (1000), ref v2988, ref v2986, out v2987);
            v2988[v2985] = (v2984);
            v2985++;
        }

        v2989 = new SimpleList<int>();
        v2989.Items = v2988;
        v2989.Count = v2985;
        return v2989;
    }
}}