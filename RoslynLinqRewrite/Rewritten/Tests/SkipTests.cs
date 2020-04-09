using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class SkipTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArraySkip), ArraySkip, ArraySkipRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkip0), ArraySkip0, ArraySkip0Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipM1), ArraySkipM1, ArraySkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkip1000), ArraySkip1000, ArraySkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipParam), ArraySkipParam, ArraySkipParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkip), EnumerableSkip, EnumerableSkipRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkip0), EnumerableSkip0, EnumerableSkip0Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipM1), EnumerableSkipM1, EnumerableSkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkip1000), EnumerableSkip1000, EnumerableSkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipParam), EnumerableSkipParam, EnumerableSkipParamRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkip), RangeSkip, RangeSkipRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkip0), RangeSkip0, RangeSkip0Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipM1), RangeSkipM1, RangeSkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkip1000), RangeSkip1000, RangeSkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipParam), RangeSkipParam, RangeSkipParamRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkip), RepeatSkip, RepeatSkipRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkip0), RepeatSkip0, RepeatSkip0Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkipM1), RepeatSkipM1, RepeatSkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkip1000), RepeatSkip1000, RepeatSkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkipParam), RepeatSkipParam, RepeatSkipParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSkipToArray), ArraySelectSkipToArray, ArraySelectSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSkipM1ToArray), ArraySelectSkipM1ToArray, ArraySelectSkipM1ToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereSkipToArray), ArrayWhereSkipToArray, ArrayWhereSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereFalseSkipToArray), ArrayWhereFalseSkipToArray, ArrayWhereFalseSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipToArray), ArraySkipToArray, ArraySkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipToArray), EnumerableSkipToArray, EnumerableSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipToArray), RangeSkipToArray, RangeSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkipToArray), RepeatSkipToArray, RepeatSkipToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArraySkip()
    {
        return ArrayItems.Skip(20);
    } //EndMethod

    public IEnumerable<int> ArraySkipRewritten()
    {
        return ArraySkipRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkip0()
    {
        return ArrayItems.Skip(0);
    } //EndMethod

    public IEnumerable<int> ArraySkip0Rewritten()
    {
        return ArraySkip0Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipM1()
    {
        return ArrayItems.Skip(-1);
    } //EndMethod

    public IEnumerable<int> ArraySkipM1Rewritten()
    {
        return ArraySkipM1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkip1000()
    {
        return ArrayItems.Skip(1000);
    } //EndMethod

    public IEnumerable<int> ArraySkip1000Rewritten()
    {
        return ArraySkip1000Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipParam()
    {
        var a = 50;
        return ArrayItems.Skip(a);
    } //EndMethod

    public IEnumerable<int> ArraySkipParamRewritten()
    {
        var a = 50;
        return ArraySkipParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkip()
    {
        return EnumerableItems.Skip(20);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipRewritten()
    {
        return EnumerableSkipRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkip0()
    {
        return EnumerableItems.Skip(0);
    } //EndMethod

    public IEnumerable<int> EnumerableSkip0Rewritten()
    {
        return EnumerableSkip0Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipM1()
    {
        return EnumerableItems.Skip(-1);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipM1Rewritten()
    {
        return EnumerableSkipM1Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkip1000()
    {
        return EnumerableItems.Skip(1000);
    } //EndMethod

    public IEnumerable<int> EnumerableSkip1000Rewritten()
    {
        return EnumerableSkip1000Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipParam()
    {
        var a = 50;
        return EnumerableItems.Skip(a);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipParamRewritten()
    {
        var a = 50;
        return EnumerableSkipParamRewritten_ProceduralLinq1(a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkip()
    {
        return Enumerable.Range(0, 100).Skip(20);
    } //EndMethod

    public IEnumerable<int> RangeSkipRewritten()
    {
        return RangeSkipRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkip0()
    {
        return Enumerable.Range(0, 100).Skip(0);
    } //EndMethod

    public IEnumerable<int> RangeSkip0Rewritten()
    {
        return RangeSkip0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipM1()
    {
        return Enumerable.Range(0, 100).Skip(-1);
    } //EndMethod

    public IEnumerable<int> RangeSkipM1Rewritten()
    {
        return RangeSkipM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkip1000()
    {
        return Enumerable.Range(0, 100).Skip(1000);
    } //EndMethod

    public IEnumerable<int> RangeSkip1000Rewritten()
    {
        return RangeSkip1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipParam()
    {
        var a = 50;
        return Enumerable.Range(0, 100).Skip(a);
    } //EndMethod

    public IEnumerable<int> RangeSkipParamRewritten()
    {
        var a = 50;
        return RangeSkipParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkip()
    {
        return Enumerable.Repeat(0, 100).Skip(20);
    } //EndMethod

    public IEnumerable<int> RepeatSkipRewritten()
    {
        return RepeatSkipRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkip0()
    {
        return Enumerable.Repeat(0, 100).Skip(0);
    } //EndMethod

    public IEnumerable<int> RepeatSkip0Rewritten()
    {
        return RepeatSkip0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkipM1()
    {
        return Enumerable.Repeat(0, 100).Skip(-1);
    } //EndMethod

    public IEnumerable<int> RepeatSkipM1Rewritten()
    {
        return RepeatSkipM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkip1000()
    {
        return Enumerable.Repeat(0, 100).Skip(1000);
    } //EndMethod

    public IEnumerable<int> RepeatSkip1000Rewritten()
    {
        return RepeatSkip1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkipParam()
    {
        var a = 50;
        return Enumerable.Repeat(0, 100).Skip(a);
    } //EndMethod

    public IEnumerable<int> RepeatSkipParamRewritten()
    {
        var a = 50;
        return RepeatSkipParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectSkipToArray()
    {
        return ArrayItems.Select(x => x + 10).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectSkipToArrayRewritten()
    {
        return ArraySelectSkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectSkipM1ToArray()
    {
        return ArrayItems.Select(x => x + 10).Skip(-1).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectSkipM1ToArrayRewritten()
    {
        return ArraySelectSkipM1ToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereSkipToArray()
    {
        return ArrayItems.Where(x => x > 20).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereSkipToArrayRewritten()
    {
        return ArrayWhereSkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereFalseSkipToArray()
    {
        return ArrayItems.Where(x => false).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereFalseSkipToArrayRewritten()
    {
        return ArrayWhereFalseSkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipToArray()
    {
        return ArrayItems.Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipToArrayRewritten()
    {
        return ArraySkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipToArray()
    {
        return EnumerableItems.Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipToArrayRewritten()
    {
        return EnumerableSkipToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipToArray()
    {
        return Enumerable.Range(0, 100).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipToArrayRewritten()
    {
        return RangeSkipToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkipToArray()
    {
        return Enumerable.Repeat(0, 100).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RepeatSkipToArrayRewritten()
    {
        return RepeatSkipToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArraySkipRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2073;
        v2073 = (20);
        for (; v2073 < (ArrayItems.Length); v2073++)
            yield return (ArrayItems[v2073]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkip0Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2075;
        v2075 = (0);
        for (; v2075 < (ArrayItems.Length); v2075++)
            yield return (ArrayItems[v2075]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipM1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2077;
        v2077 = (0);
        for (; v2077 < (ArrayItems.Length); v2077++)
            yield return (ArrayItems[v2077]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkip1000Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2079;
        v2079 = (1000);
        for (; v2079 < (ArrayItems.Length); v2079++)
            yield return (ArrayItems[v2079]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2082;
        int v2083;
        v2083 = a < 0 ? a : 0;
        v2083 = a;
        v2082 = (v2083);
        for (; v2082 < (ArrayItems.Length); v2082++)
            yield return (ArrayItems[v2082]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2084;
        int v2085;
        v2084 = EnumerableItems.GetEnumerator();
        v2085 = 0;
        try
        {
            while (v2084.MoveNext())
            {
                if (v2085 < 20)
                {
                    v2085++;
                    continue;
                }

                yield return (v2084.Current);
                v2085++;
            }
        }
        finally
        {
            v2084.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkip0Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2086;
        int v2087;
        v2086 = EnumerableItems.GetEnumerator();
        v2087 = 0;
        try
        {
            while (v2086.MoveNext())
            {
                if (v2087 < 0)
                {
                    v2087++;
                    continue;
                }

                yield return (v2086.Current);
                v2087++;
            }
        }
        finally
        {
            v2086.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipM1Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2088;
        v2088 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2088.MoveNext())
                yield return (v2088.Current);
        }
        finally
        {
            v2088.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkip1000Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2089;
        int v2090;
        v2089 = EnumerableItems.GetEnumerator();
        v2090 = 0;
        try
        {
            while (v2089.MoveNext())
            {
                if (v2090 < 1000)
                {
                    v2090++;
                    continue;
                }

                yield return (v2089.Current);
                v2090++;
            }
        }
        finally
        {
            v2089.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2091;
        int v2092;
        v2091 = EnumerableItems.GetEnumerator();
        v2092 = 0;
        try
        {
            while (v2091.MoveNext())
            {
                if (v2092 < a)
                {
                    v2092++;
                    continue;
                }

                yield return (v2091.Current);
                v2092++;
            }
        }
        finally
        {
            v2091.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipRewritten_ProceduralLinq1()
    {
        int v2093;
        v2093 = (20);
        for (; v2093 < (100); v2093++)
            yield return (v2093);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkip0Rewritten_ProceduralLinq1()
    {
        int v2094;
        v2094 = (0);
        for (; v2094 < (100); v2094++)
            yield return (v2094);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipM1Rewritten_ProceduralLinq1()
    {
        int v2095;
        v2095 = (0);
        for (; v2095 < (100); v2095++)
            yield return (v2095);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkip1000Rewritten_ProceduralLinq1()
    {
        int v2096;
        v2096 = (1000);
        for (; v2096 < (100); v2096++)
            yield return (v2096);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipParamRewritten_ProceduralLinq1(int a)
    {
        int v2097;
        int v2098;
        v2098 = a < 0 ? a : 0;
        v2098 = a;
        v2097 = (v2098);
        for (; v2097 < (100); v2097++)
            yield return (v2097);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkipRewritten_ProceduralLinq1()
    {
        int v2099;
        v2099 = (20);
        for (; v2099 < (100); v2099++)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkip0Rewritten_ProceduralLinq1()
    {
        int v2100;
        v2100 = (0);
        for (; v2100 < (100); v2100++)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkipM1Rewritten_ProceduralLinq1()
    {
        int v2101;
        v2101 = (0);
        for (; v2101 < (100); v2101++)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkip1000Rewritten_ProceduralLinq1()
    {
        int v2102;
        v2102 = (1000);
        for (; v2102 < (100); v2102++)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkipParamRewritten_ProceduralLinq1(int a)
    {
        int v2103;
        int v2104;
        v2104 = a < 0 ? a : 0;
        v2104 = a;
        v2103 = (v2104);
        for (; v2103 < (100); v2103++)
            yield return (0);
        yield break;
    }

    int[] ArraySelectSkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2106;
        int[] v2107;
        int v2108;
        v2107 = new int[(-20 + ArrayItems.Length)];
        v2108 = 0;
        v2106 = (20);
        for (; v2106 < (ArrayItems.Length); v2106++)
        {
            v2107[v2108] = (10 + ArrayItems[v2106]);
            v2108++;
        }

        return v2107;
    }

    int[] ArraySelectSkipM1ToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2110;
        int[] v2111;
        v2111 = new int[(ArrayItems.Length)];
        v2110 = (0);
        for (; v2110 < (ArrayItems.Length); v2110++)
            v2111[v2110] = (10 + ArrayItems[v2110]);
        return v2111;
    }

    int[] ArrayWhereSkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2112;
        int v2113;
        int v2114;
        int v2115;
        int v2116;
        int v2117;
        int[] v2118;
        v2114 = 0;
        v2115 = 0;
        v2116 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2116 -= (v2116 % 2);
        v2117 = 8;
        v2118 = new int[8];
        v2112 = (0);
        for (; v2112 < (ArrayItems.Length); v2112++)
        {
            v2113 = (ArrayItems[v2112]);
            if (!(((v2113) > 20)))
                continue;
            if (v2114 < 20)
            {
                v2114++;
                continue;
            }

            if (v2115 >= v2117)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2118, ref v2116, out v2117);
            v2118[v2115] = (v2113);
            v2114++;
            v2115++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2118, v2115);
    }

    int[] ArrayWhereFalseSkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2119;
        int v2120;
        int v2121;
        int v2122;
        int v2123;
        int v2124;
        int[] v2125;
        v2121 = 0;
        v2122 = 0;
        v2123 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2123 -= (v2123 % 2);
        v2124 = 8;
        v2125 = new int[8];
        v2119 = (0);
        for (; v2119 < (ArrayItems.Length); v2119++)
        {
            v2120 = (ArrayItems[v2119]);
            if (!((false)))
                continue;
            if (v2121 < 20)
            {
                v2121++;
                continue;
            }

            if (v2122 >= v2124)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2125, ref v2123, out v2124);
            v2125[v2122] = (v2120);
            v2121++;
            v2122++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2125, v2122);
    }

    int[] ArraySkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2127;
        int[] v2128;
        v2128 = new int[(-20 + ArrayItems.Length)];
        System.Array.Copy(ArrayItems, (20), v2128, 0, (-20 + ArrayItems.Length));
        return v2128;
    }

    int[] EnumerableSkipToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2129;
        int v2130;
        int v2131;
        int v2132;
        int[] v2133;
        v2129 = EnumerableItems.GetEnumerator();
        v2130 = 0;
        v2131 = 0;
        v2132 = 8;
        v2133 = new int[8];
        try
        {
            while (v2129.MoveNext())
            {
                if (v2130 < 20)
                {
                    v2130++;
                    continue;
                }

                if (v2131 >= v2132)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2133, ref v2132);
                v2133[v2131] = (v2129.Current);
                v2130++;
                v2131++;
            }
        }
        finally
        {
            v2129.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2133, v2131);
    }

    int[] RangeSkipToArrayRewritten_ProceduralLinq1()
    {
        int v2134;
        int[] v2135;
        int v2136;
        v2135 = new int[(80)];
        v2136 = 0;
        v2134 = (20);
        for (; v2134 < (100); v2134++)
        {
            v2135[v2136] = (v2134);
            v2136++;
        }

        return v2135;
    }

    int[] RepeatSkipToArrayRewritten_ProceduralLinq1()
    {
        int v2137;
        int[] v2138;
        int v2139;
        v2138 = new int[(80)];
        v2139 = 0;
        v2137 = (20);
        for (; v2137 < (100); v2137++)
        {
            v2138[v2139] = (0);
            v2139++;
        }

        return v2138;
    }
}}