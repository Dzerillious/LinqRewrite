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
        int v3063;
        int v3064;
        int v3065;
        int v3066;
        int[] v3067;
        SimpleList<int> v3068;
        v3064 = 0;
        v3065 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3065 -= (v3065 % 2);
        v3066 = 8;
        v3067 = new int[8];
        v3063 = (0);
        for (; v3063 < (ArrayItems.Length); v3063 += 1)
        {
            if (!((((ArrayItems[v3063])) > 500)))
                continue;
            if (v3064 >= v3066)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3067, ref v3065, out v3066);
            v3067[v3064] = ((ArrayItems[v3063]));
            v3064++;
        }

        v3068 = new SimpleList<int>();
        v3068.Items = v3067;
        v3068.Count = v3064;
        return v3068;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3069;
        int v3070;
        int v3071;
        int v3072;
        int v3073;
        int[] v3074;
        SimpleList<int> v3075;
        v3071 = 0;
        v3072 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3072 -= (v3072 % 2);
        v3073 = 8;
        v3074 = new int[8];
        v3069 = (0);
        for (; v3069 < (ArrayItems.Length); v3069 += 1)
        {
            v3070 = (5 + ArrayItems[v3069]);
            if (!(((v3070) > 500)))
                continue;
            if (v3071 >= v3073)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3074, ref v3072, out v3073);
            v3074[v3071] = (v3070);
            v3071++;
        }

        v3075 = new SimpleList<int>();
        v3075.Items = v3074;
        v3075.Count = v3071;
        return v3075;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3076;
        int v3077;
        int v3078;
        int v3079;
        int v3080;
        int[] v3081;
        SimpleList<int> v3082;
        v3078 = 0;
        v3079 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3079 -= (v3079 % 2);
        v3080 = 8;
        v3081 = new int[8];
        v3076 = (0);
        for (; v3076 < (ArrayItems.Length); v3076 += 1)
        {
            v3077 = (5 + ArrayItems[v3076]);
            if (!(((v3077) > 500)))
                continue;
            v3077 = (5 + v3077);
            if (!(((v3077) > 500)))
                continue;
            v3077 = (5 + v3077);
            if (!(((v3077) > 500)))
                continue;
            v3077 = (5 + v3077);
            if (!(((v3077) > 500)))
                continue;
            if (v3078 >= v3080)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3081, ref v3079, out v3080);
            v3081[v3078] = (v3077);
            v3078++;
        }

        v3082 = new SimpleList<int>();
        v3082.Items = v3081;
        v3082.Count = v3078;
        return v3082;
    }

    int[] SelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3083;
        int v3084;
        int v3085;
        int v3086;
        int v3087;
        int[] v3088;
        v3085 = 0;
        v3086 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3086 -= (v3086 % 2);
        v3087 = 8;
        v3088 = new int[8];
        v3083 = (0);
        for (; v3083 < (ArrayItems.Length); v3083 += 1)
        {
            v3084 = (5 + ArrayItems[v3083]);
            if (!(((v3084) > 500)))
                continue;
            if (v3085 >= v3087)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3088, ref v3086, out v3087);
            v3088[v3085] = (v3084);
            v3085++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3088, v3085);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3089;
        int v3090;
        int v3091;
        int v3092;
        int v3093;
        int[] v3094;
        SimpleList<int> v3095;
        v3091 = 0;
        v3092 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3092 -= (v3092 % 2);
        v3093 = 8;
        v3094 = new int[8];
        v3089 = (0);
        for (; v3089 < (ArrayItems.Length); v3089 += 1)
        {
            v3090 = (5 + ArrayItems[v3089]);
            if (!(((v3090) > 500)))
                continue;
            v3090 = (5 + v3090);
            if (!(((v3090) > 500)))
                continue;
            v3090 = (5 + v3090);
            if (!(((v3090) > 500)))
                continue;
            v3090 = (5 + v3090);
            if (!(((v3090) > 500)))
                continue;
            if (v3091 >= v3093)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3094, ref v3092, out v3093);
            v3094[v3091] = (v3090);
            v3091++;
        }

        v3095 = new SimpleList<int>();
        v3095.Items = v3094;
        v3095.Count = v3091;
        return v3095;
    }

    double[] MultipleSelectWhereMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3096;
        double v3097;
        int v3098;
        int v3099;
        int v3100;
        double[] v3101;
        v3098 = 0;
        v3099 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3099 -= (v3099 % 2);
        v3100 = 8;
        v3101 = new double[8];
        v3096 = (0);
        for (; v3096 < (ArrayItems.Length); v3096 += 1)
        {
            v3097 = (Selector((ArrayItems[v3096])));
            if (!(Predicate((v3097))))
                continue;
            v3097 = (Selector((v3097)));
            if (!(Predicate((v3097))))
                continue;
            v3097 = (Selector((v3097)));
            if (!(Predicate((v3097))))
                continue;
            v3097 = (Selector((v3097)));
            if (!(Predicate((v3097))))
                continue;
            if (v3098 >= v3100)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3101, ref v3099, out v3100);
            v3101[v3098] = (v3097);
            v3098++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3101, v3098);
    }

    System.Collections.Generic.IEnumerable<int> ParametrizedWhereRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v3102;
        v3102 = (0);
        for (; v3102 < (ArrayItems.Length); v3102 += 1)
        {
            if (!((((ArrayItems[v3102])) > offset)))
                continue;
            yield return ((ArrayItems[v3102]));
        }

        yield break;
    }

    int[] ParametrizedWhereToArrayRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v3103;
        int v3104;
        int v3105;
        int v3106;
        int[] v3107;
        v3104 = 0;
        v3105 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3105 -= (v3105 % 2);
        v3106 = 8;
        v3107 = new int[8];
        v3103 = (0);
        for (; v3103 < (ArrayItems.Length); v3103 += 1)
        {
            if (!((((ArrayItems[v3103])) > offset)))
                continue;
            if (v3104 >= v3106)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3107, ref v3105, out v3106);
            v3107[v3104] = ((ArrayItems[v3103]));
            v3104++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3107, v3104);
    }

    System.Collections.Generic.IEnumerable<int> WhereChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v3109, System.Func<int, int> v3110)
    {
        int v3108;
        v3108 = (0);
        for (; v3108 < (ArrayItems.Length); v3108 += 1)
        {
            if (!(v3109(((ArrayItems[v3108])))))
                continue;
            yield return (v3110(((ArrayItems[v3108]))));
        }

        yield break;
    }

    int[] WhereChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v3111;
        int v3112;
        int v3113;
        int v3114;
        int[] v3115;
        v3112 = 0;
        v3113 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3113 -= (v3113 % 2);
        v3114 = 8;
        v3115 = new int[8];
        v3111 = (0);
        for (; v3111 < (ArrayItems.Length); v3111 += 1)
        {
            if (!((((ArrayItems[v3111])) > 2 * a)))
                continue;
            if (v3112 >= v3114)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3115, ref v3113, out v3114);
            v3115[v3112] = ((((ArrayItems[v3111])) + a++));
            v3112++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3115, v3112);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> WhereChangingParamToSimpleListRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v3116;
        int v3117;
        int v3118;
        int v3119;
        int[] v3120;
        SimpleList<int> v3121;
        v3117 = 0;
        v3118 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3118 -= (v3118 % 2);
        v3119 = 8;
        v3120 = new int[8];
        v3116 = (0);
        for (; v3116 < (ArrayItems.Length); v3116 += 1)
        {
            if (!((((ArrayItems[v3116])) > 2 * a)))
                continue;
            if (v3117 >= v3119)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3120, ref v3118, out v3119);
            v3120[v3117] = ((((ArrayItems[v3116])) + a++));
            v3117++;
        }

        v3121 = new SimpleList<int>();
        v3121.Items = v3120;
        v3121.Count = v3117;
        return v3121;
    }

    int[] WhereIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3122;
        int v3123;
        int v3124;
        int v3125;
        int[] v3126;
        v3123 = 0;
        v3124 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3124 -= (v3124 % 2);
        v3125 = 8;
        v3126 = new int[8];
        v3122 = (0);
        for (; v3122 < (ArrayItems.Length); v3122 += 1)
        {
            if (!((((ArrayItems[v3122])) > 200 + v3122 / 2)))
                continue;
            if (v3123 >= v3125)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3126, ref v3124, out v3125);
            v3126[v3123] = ((ArrayItems[v3122]));
            v3123++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3126, v3123);
    }
}}