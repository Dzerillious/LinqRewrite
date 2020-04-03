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
        return ParametrizedWhereRewritten_ProceduralLinq1(offset, ArrayItems, x => x > offset);
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
        int v2086;
        int v2087;
        int v2088;
        int v2089;
        int[] v2090;
        SimpleList<int> v2091;
        v2087 = 0;
        v2088 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2088 -= (v2088 % 2);
        v2089 = 8;
        v2090 = new int[8];
        v2086 = 0;
        for (; v2086 < ArrayItems.Length; v2086++)
        {
            if (!((ArrayItems[v2086] > 500)))
                continue;
            if (v2087 >= v2089)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2090, ref v2088, out v2089);
            v2090[v2087] = ArrayItems[v2086];
            v2087++;
        }

        v2091 = new SimpleList<int>();
        v2091.Items = v2090;
        v2091.Count = v2087;
        return v2091;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2092;
        int v2093;
        int v2094;
        int v2095;
        int v2096;
        int[] v2097;
        SimpleList<int> v2098;
        v2094 = 0;
        v2095 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2095 -= (v2095 % 2);
        v2096 = 8;
        v2097 = new int[8];
        v2092 = 0;
        for (; v2092 < ArrayItems.Length; v2092++)
        {
            v2093 = (ArrayItems[v2092] + 5);
            if (!((v2093 > 500)))
                continue;
            if (v2094 >= v2096)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2097, ref v2095, out v2096);
            v2097[v2094] = v2093;
            v2094++;
        }

        v2098 = new SimpleList<int>();
        v2098.Items = v2097;
        v2098.Count = v2094;
        return v2098;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2099;
        int v2100;
        int v2101;
        int v2102;
        int v2103;
        int v2104;
        int v2105;
        int v2106;
        int[] v2107;
        SimpleList<int> v2108;
        v2104 = 0;
        v2105 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2105 -= (v2105 % 2);
        v2106 = 8;
        v2107 = new int[8];
        v2099 = 0;
        for (; v2099 < ArrayItems.Length; v2099++)
        {
            v2100 = (ArrayItems[v2099] + 5);
            if (!((v2100 > 500)))
                continue;
            v2101 = (v2100 + 5);
            if (!((v2101 > 500)))
                continue;
            v2102 = (v2101 + 5);
            if (!((v2102 > 500)))
                continue;
            v2103 = (v2102 + 5);
            if (!((v2103 > 500)))
                continue;
            if (v2104 >= v2106)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2107, ref v2105, out v2106);
            v2107[v2104] = v2103;
            v2104++;
        }

        v2108 = new SimpleList<int>();
        v2108.Items = v2107;
        v2108.Count = v2104;
        return v2108;
    }

    int[] SelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2109;
        int v2110;
        int v2111;
        int v2112;
        int v2113;
        int[] v2114;
        v2111 = 0;
        v2112 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2112 -= (v2112 % 2);
        v2113 = 8;
        v2114 = new int[8];
        v2109 = 0;
        for (; v2109 < ArrayItems.Length; v2109++)
        {
            v2110 = (ArrayItems[v2109] + 5);
            if (!((v2110 > 500)))
                continue;
            if (v2111 >= v2113)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2114, ref v2112, out v2113);
            v2114[v2111] = v2110;
            v2111++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2114, v2111);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2115;
        int v2116;
        int v2117;
        int v2118;
        int v2119;
        int v2120;
        int v2121;
        int v2122;
        int[] v2123;
        SimpleList<int> v2124;
        v2120 = 0;
        v2121 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2121 -= (v2121 % 2);
        v2122 = 8;
        v2123 = new int[8];
        v2115 = 0;
        for (; v2115 < ArrayItems.Length; v2115++)
        {
            v2116 = (ArrayItems[v2115] + 5);
            if (!((v2116 > 500)))
                continue;
            v2117 = (v2116 + 5);
            if (!((v2117 > 500)))
                continue;
            v2118 = (v2117 + 5);
            if (!((v2118 > 500)))
                continue;
            v2119 = (v2118 + 5);
            if (!((v2119 > 500)))
                continue;
            if (v2120 >= v2122)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2123, ref v2121, out v2122);
            v2123[v2120] = v2119;
            v2120++;
        }

        v2124 = new SimpleList<int>();
        v2124.Items = v2123;
        v2124.Count = v2120;
        return v2124;
    }

    double[] MultipleSelectWhereMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2125;
        double v2126;
        double v2127;
        double v2128;
        double v2129;
        int v2130;
        int v2131;
        int v2132;
        double[] v2133;
        v2130 = 0;
        v2131 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2131 -= (v2131 % 2);
        v2132 = 8;
        v2133 = new double[8];
        v2125 = 0;
        for (; v2125 < ArrayItems.Length; v2125++)
        {
            v2126 = Selector(ArrayItems[v2125]);
            if (!(Predicate(v2126)))
                continue;
            v2127 = Selector(v2126);
            if (!(Predicate(v2127)))
                continue;
            v2128 = Selector(v2127);
            if (!(Predicate(v2128)))
                continue;
            v2129 = Selector(v2128);
            if (!(Predicate(v2129)))
                continue;
            if (v2130 >= v2132)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2133, ref v2131, out v2132);
            v2133[v2130] = v2129;
            v2130++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2133, v2130);
    }

    System.Collections.Generic.IEnumerable<int> ParametrizedWhereRewritten_ProceduralLinq1(int offset, int[] ArrayItems, System.Func<int, bool> v2135)
    {
        int v2134;
        v2134 = 0;
        for (; v2134 < ArrayItems.Length; v2134++)
        {
            if (!(v2135(ArrayItems[v2134])))
                continue;
            yield return ArrayItems[v2134];
        }
    }

    int[] ParametrizedWhereToArrayRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2136;
        int v2137;
        int v2138;
        int v2139;
        int[] v2140;
        v2137 = 0;
        v2138 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2138 -= (v2138 % 2);
        v2139 = 8;
        v2140 = new int[8];
        v2136 = 0;
        for (; v2136 < ArrayItems.Length; v2136++)
        {
            if (!((ArrayItems[v2136] > offset)))
                continue;
            if (v2137 >= v2139)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2140, ref v2138, out v2139);
            v2140[v2137] = ArrayItems[v2136];
            v2137++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2140, v2137);
    }

    System.Collections.Generic.IEnumerable<int> WhereChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2142, System.Func<int, int> v2143)
    {
        int v2141;
        v2141 = 0;
        for (; v2141 < ArrayItems.Length; v2141++)
        {
            if (!(v2142(ArrayItems[v2141])))
                continue;
            yield return v2143(ArrayItems[v2141]);
        }
    }

    int[] WhereChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2144;
        int v2145;
        int v2146;
        int v2147;
        int[] v2148;
        v2145 = 0;
        v2146 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2146 -= (v2146 % 2);
        v2147 = 8;
        v2148 = new int[8];
        v2144 = 0;
        for (; v2144 < ArrayItems.Length; v2144++)
        {
            if (!((ArrayItems[v2144] > 2 * a)))
                continue;
            if (v2145 >= v2147)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2148, ref v2146, out v2147);
            v2148[v2145] = (ArrayItems[v2144] + a++);
            v2145++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2148, v2145);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> WhereChangingParamToSimpleListRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2149;
        int v2150;
        int v2151;
        int v2152;
        int[] v2153;
        SimpleList<int> v2154;
        v2150 = 0;
        v2151 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2151 -= (v2151 % 2);
        v2152 = 8;
        v2153 = new int[8];
        v2149 = 0;
        for (; v2149 < ArrayItems.Length; v2149++)
        {
            if (!((ArrayItems[v2149] > 2 * a)))
                continue;
            if (v2150 >= v2152)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2153, ref v2151, out v2152);
            v2153[v2150] = (ArrayItems[v2149] + a++);
            v2150++;
        }

        v2154 = new SimpleList<int>();
        v2154.Items = v2153;
        v2154.Count = v2150;
        return v2154;
    }

    int[] WhereIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2155;
        int v2156;
        int v2157;
        int v2158;
        int[] v2159;
        v2156 = 0;
        v2157 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2157 -= (v2157 % 2);
        v2158 = 8;
        v2159 = new int[8];
        v2155 = 0;
        for (; v2155 < ArrayItems.Length; v2155++)
        {
            if (!((ArrayItems[v2155] > 200 + v2155 / 2)))
                continue;
            if (v2156 >= v2158)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2159, ref v2157, out v2158);
            v2159[v2156] = ArrayItems[v2155];
            v2156++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2159, v2156);
    }
}}