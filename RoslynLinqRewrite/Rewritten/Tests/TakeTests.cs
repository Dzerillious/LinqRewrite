using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class TakeTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayTake), ArrayTake, ArrayTakeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTake0), ArrayTake0, ArrayTake0Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeM1), ArrayTakeM1, ArrayTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTake1000), ArrayTake1000, ArrayTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeParam), ArrayTakeParam, ArrayTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTake), EnumerableTake, EnumerableTakeRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTake0), EnumerableTake0, EnumerableTake0Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeM1), EnumerableTakeM1, EnumerableTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTake1000), EnumerableTake1000, EnumerableTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeParam), EnumerableTakeParam, EnumerableTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(RangeTake), RangeTake, RangeTakeRewritten);
        TestsExtensions.TestEquals(nameof(RangeTake0), RangeTake0, RangeTake0Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeM1), RangeTakeM1, RangeTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTake1000), RangeTake1000, RangeTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeParam), RangeTakeParam, RangeTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(RepeatTake), RepeatTake, RepeatTakeRewritten);
        TestsExtensions.TestEquals(nameof(RepeatTake0), RepeatTake0, RepeatTake0Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatTakeM1), RepeatTakeM1, RepeatTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatTake1000), RepeatTake1000, RepeatTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatTakeParam), RepeatTakeParam, RepeatTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectTakeToArray), ArraySelectTakeToArray, ArraySelectTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectTakeM1ToArray), ArraySelectTakeM1ToArray, ArraySelectTakeM1ToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereTakeToArray), ArrayWhereTakeToArray, ArrayWhereTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereFalseTakeToArray), ArrayWhereFalseTakeToArray, ArrayWhereFalseTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeToArray), ArrayTakeToArray, ArrayTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeToArray), EnumerableTakeToArray, EnumerableTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeToArray), RangeTakeToArray, RangeTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatTakeToArray), RepeatTakeToArray, RepeatTakeToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayTake()
    {
        return ArrayItems.Take(20);
    } //EndMethod

    public IEnumerable<int> ArrayTakeRewritten()
    {
        return ArrayTakeRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTake0()
    {
        return ArrayItems.Take(0);
    } //EndMethod

    public IEnumerable<int> ArrayTake0Rewritten()
    {
        return ArrayTake0Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeM1()
    {
        return ArrayItems.Take(-1);
    } //EndMethod

    public IEnumerable<int> ArrayTakeM1Rewritten()
    {
        return ArrayTakeM1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTake1000()
    {
        return ArrayItems.Take(1000);
    } //EndMethod

    public IEnumerable<int> ArrayTake1000Rewritten()
    {
        return ArrayTake1000Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeParam()
    {
        var a = 50;
        return ArrayItems.Take(a);
    } //EndMethod

    public IEnumerable<int> ArrayTakeParamRewritten()
    {
        var a = 50;
        return ArrayTakeParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTake()
    {
        return EnumerableItems.Take(20);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeRewritten()
    {
        return EnumerableTakeRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTake0()
    {
        return EnumerableItems.Take(0);
    } //EndMethod

    public IEnumerable<int> EnumerableTake0Rewritten()
    {
        return EnumerableTake0Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeM1()
    {
        return EnumerableItems.Take(-1);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeM1Rewritten()
    {
        return EnumerableTakeM1Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTake1000()
    {
        return EnumerableItems.Take(1000);
    } //EndMethod

    public IEnumerable<int> EnumerableTake1000Rewritten()
    {
        return EnumerableTake1000Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeParam()
    {
        var a = 50;
        return EnumerableItems.Take(a);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeParamRewritten()
    {
        var a = 50;
        return EnumerableTakeParamRewritten_ProceduralLinq1(a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTake()
    {
        return Enumerable.Range(0, 100).Take(20);
    } //EndMethod

    public IEnumerable<int> RangeTakeRewritten()
    {
        return RangeTakeRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTake0()
    {
        return Enumerable.Range(0, 100).Take(0);
    } //EndMethod

    public IEnumerable<int> RangeTake0Rewritten()
    {
        return RangeTake0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeM1()
    {
        return Enumerable.Range(0, 100).Take(-1);
    } //EndMethod

    public IEnumerable<int> RangeTakeM1Rewritten()
    {
        return RangeTakeM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTake1000()
    {
        return Enumerable.Range(0, 100).Take(1000);
    } //EndMethod

    public IEnumerable<int> RangeTake1000Rewritten()
    {
        return RangeTake1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeParam()
    {
        var a = 50;
        return Enumerable.Range(0, 100).Take(a);
    } //EndMethod

    public IEnumerable<int> RangeTakeParamRewritten()
    {
        var a = 50;
        return RangeTakeParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTake()
    {
        return Enumerable.Repeat(0, 100).Take(20);
    } //EndMethod

    public IEnumerable<int> RepeatTakeRewritten()
    {
        return RepeatTakeRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTake0()
    {
        return Enumerable.Repeat(0, 100).Take(0);
    } //EndMethod

    public IEnumerable<int> RepeatTake0Rewritten()
    {
        return RepeatTake0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTakeM1()
    {
        return Enumerable.Repeat(0, 100).Take(-1);
    } //EndMethod

    public IEnumerable<int> RepeatTakeM1Rewritten()
    {
        return RepeatTakeM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTake1000()
    {
        return Enumerable.Repeat(0, 100).Take(1000);
    } //EndMethod

    public IEnumerable<int> RepeatTake1000Rewritten()
    {
        return RepeatTake1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTakeParam()
    {
        var a = 50;
        return Enumerable.Repeat(0, 100).Take(a);
    } //EndMethod

    public IEnumerable<int> RepeatTakeParamRewritten()
    {
        var a = 50;
        return RepeatTakeParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectTakeToArray()
    {
        return ArrayItems.Select(x => x + 10).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectTakeToArrayRewritten()
    {
        return ArraySelectTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectTakeM1ToArray()
    {
        var m1 = -1;
        return ArrayItems.Select(x => x + 10).Take(m1).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectTakeM1ToArrayRewritten()
    {
        var m1 = -1;
        return ArraySelectTakeM1ToArrayRewritten_ProceduralLinq1(m1, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereTakeToArray()
    {
        return ArrayItems.Where(x => x > 20).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereTakeToArrayRewritten()
    {
        return ArrayWhereTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereFalseTakeToArray()
    {
        return ArrayItems.Where(x => false).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereFalseTakeToArrayRewritten()
    {
        return ArrayWhereFalseTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeToArray()
    {
        return ArrayItems.Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeToArrayRewritten()
    {
        return ArrayTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeToArray()
    {
        return EnumerableItems.Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeToArrayRewritten()
    {
        return EnumerableTakeToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeToArray()
    {
        return Enumerable.Range(0, 100).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeToArrayRewritten()
    {
        return RangeTakeToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTakeToArray()
    {
        return Enumerable.Repeat(0, 100).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RepeatTakeToArrayRewritten()
    {
        return RepeatTakeToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayTakeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2206;
        int v2207;
        if (20 > (ArrayItems.Length))
            v2207 = (ArrayItems.Length);
        else
            v2207 = 20;
        v2206 = (0);
        for (; v2206 < (v2207); v2206 += 1)
            yield return (ArrayItems[v2206]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTake0Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2210;
        int v2211;
        if (0 > (ArrayItems.Length))
            v2211 = (ArrayItems.Length);
        else
            v2211 = 0;
        v2210 = (0);
        for (; v2210 < (v2211); v2210 += 1)
            yield return (ArrayItems[v2210]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeM1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2214;
        int v2215;
        if (0 > (ArrayItems.Length))
            v2215 = (ArrayItems.Length);
        else
            v2215 = 0;
        v2214 = (0);
        for (; v2214 < (v2215); v2214 += 1)
            yield return (ArrayItems[v2214]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTake1000Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2218;
        int v2219;
        if (1000 > (ArrayItems.Length))
            v2219 = (ArrayItems.Length);
        else
            v2219 = 1000;
        v2218 = (0);
        for (; v2218 < (v2219); v2218 += 1)
            yield return (ArrayItems[v2218]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2222;
        int v2223;
        if (a < 0)
            v2223 = 0;
        else if (a > (ArrayItems.Length))
            v2223 = (ArrayItems.Length);
        else
            v2223 = a;
        v2222 = (0);
        for (; v2222 < (v2223); v2222 += 1)
            yield return (ArrayItems[v2222]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2224;
        int v2225;
        v2224 = EnumerableItems.GetEnumerator();
        v2225 = 0;
        try
        {
            while (v2224.MoveNext())
            {
                if (v2225 >= 20)
                    break;
                yield return (v2224.Current);
                v2225++;
            }
        }
        finally
        {
            v2224.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTake0Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2226;
        int v2227;
        v2226 = EnumerableItems.GetEnumerator();
        v2227 = 0;
        try
        {
            while (v2226.MoveNext())
            {
                if (v2227 >= 0)
                    break;
                yield return (v2226.Current);
                v2227++;
            }
        }
        finally
        {
            v2226.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeM1Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2228;
        int v2229;
        v2228 = EnumerableItems.GetEnumerator();
        v2229 = 0;
        try
        {
            while (v2228.MoveNext())
            {
                if (v2229 >= 0)
                    break;
                yield return (v2228.Current);
                v2229++;
            }
        }
        finally
        {
            v2228.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTake1000Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2230;
        int v2231;
        v2230 = EnumerableItems.GetEnumerator();
        v2231 = 0;
        try
        {
            while (v2230.MoveNext())
            {
                if (v2231 >= 1000)
                    break;
                yield return (v2230.Current);
                v2231++;
            }
        }
        finally
        {
            v2230.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2232;
        int v2233;
        if (a < 0)
            v2233 = 0;
        else
            v2233 = a;
        int v2234;
        v2232 = EnumerableItems.GetEnumerator();
        v2234 = 0;
        try
        {
            while (v2232.MoveNext())
            {
                if (v2234 >= v2233)
                    break;
                yield return (v2232.Current);
                v2234++;
            }
        }
        finally
        {
            v2232.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeRewritten_ProceduralLinq1()
    {
        int v2235;
        int v2236;
        if (20 > (100))
            v2236 = (100);
        else
            v2236 = 20;
        v2235 = (0);
        for (; v2235 < (v2236); v2235 += (1))
            yield return (v2235);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTake0Rewritten_ProceduralLinq1()
    {
        int v2237;
        int v2238;
        if (0 > (100))
            v2238 = (100);
        else
            v2238 = 0;
        v2237 = (0);
        for (; v2237 < (v2238); v2237 += (1))
            yield return (v2237);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeM1Rewritten_ProceduralLinq1()
    {
        int v2239;
        int v2240;
        if (0 > (100))
            v2240 = (100);
        else
            v2240 = 0;
        v2239 = (0);
        for (; v2239 < (v2240); v2239 += (1))
            yield return (v2239);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTake1000Rewritten_ProceduralLinq1()
    {
        int v2241;
        int v2242;
        if (1000 > (100))
            v2242 = (100);
        else
            v2242 = 1000;
        v2241 = (0);
        for (; v2241 < (v2242); v2241 += (1))
            yield return (v2241);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeParamRewritten_ProceduralLinq1(int a)
    {
        int v2243;
        int v2244;
        if (a < 0)
            v2244 = 0;
        else if (a > (100))
            v2244 = (100);
        else
            v2244 = a;
        v2243 = (0);
        for (; v2243 < (v2244); v2243 += (1))
            yield return (v2243);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTakeRewritten_ProceduralLinq1()
    {
        int v2245;
        int v2246;
        if (20 > (100))
            v2246 = (100);
        else
            v2246 = 20;
        v2245 = (0);
        for (; v2245 < (v2246); v2245 += 1)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTake0Rewritten_ProceduralLinq1()
    {
        int v2247;
        int v2248;
        if (0 > (100))
            v2248 = (100);
        else
            v2248 = 0;
        v2247 = (0);
        for (; v2247 < (v2248); v2247 += 1)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTakeM1Rewritten_ProceduralLinq1()
    {
        int v2249;
        int v2250;
        if (0 > (100))
            v2250 = (100);
        else
            v2250 = 0;
        v2249 = (0);
        for (; v2249 < (v2250); v2249 += 1)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTake1000Rewritten_ProceduralLinq1()
    {
        int v2251;
        int v2252;
        if (1000 > (100))
            v2252 = (100);
        else
            v2252 = 1000;
        v2251 = (0);
        for (; v2251 < (v2252); v2251 += 1)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTakeParamRewritten_ProceduralLinq1(int a)
    {
        int v2253;
        int v2254;
        if (a < 0)
            v2254 = 0;
        else if (a > (100))
            v2254 = (100);
        else
            v2254 = a;
        v2253 = (0);
        for (; v2253 < (v2254); v2253 += 1)
            yield return (0);
        yield break;
    }

    int[] ArraySelectTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2257;
        int v2258;
        if (20 > (ArrayItems.Length))
            v2258 = (ArrayItems.Length);
        else
            v2258 = 20;
        int[] v2259;
        int v2260;
        v2259 = new int[(v2258)];
        v2260 = 0;
        v2257 = (0);
        for (; v2257 < (v2258); v2257 += 1)
        {
            v2259[v2260] = (10 + ArrayItems[v2257]);
            v2260++;
        }

        return v2259;
    }

    int[] ArraySelectTakeM1ToArrayRewritten_ProceduralLinq1(int m1, int[] ArrayItems)
    {
        int v2263;
        int v2264;
        if (m1 < 0)
            v2264 = 0;
        else if (m1 > (ArrayItems.Length))
            v2264 = (ArrayItems.Length);
        else
            v2264 = m1;
        int[] v2265;
        int v2266;
        v2265 = new int[(v2264)];
        v2266 = 0;
        v2263 = (0);
        for (; v2263 < (v2264); v2263 += 1)
        {
            v2265[v2266] = (10 + ArrayItems[v2263]);
            v2266++;
        }

        return v2265;
    }

    int[] ArrayWhereTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2267;
        int v2268;
        int v2269;
        int v2270;
        int v2271;
        int[] v2272;
        v2268 = 0;
        v2269 = 0;
        v2270 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2270 -= (v2270 % 2);
        v2271 = 8;
        v2272 = new int[8];
        v2267 = (0);
        for (; v2267 < (ArrayItems.Length); v2267 += 1)
        {
            if (!((((ArrayItems[v2267])) > 20)))
                continue;
            if (v2268 >= 20)
                break;
            if (v2269 >= v2271)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2272, ref v2270, out v2271);
            v2272[v2269] = ((ArrayItems[v2267]));
            v2268++;
            v2269++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2272, v2269);
    }

    int[] ArrayWhereFalseTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2273;
        int v2274;
        int v2275;
        int v2276;
        int v2277;
        int[] v2278;
        v2274 = 0;
        v2275 = 0;
        v2276 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2276 -= (v2276 % 2);
        v2277 = 8;
        v2278 = new int[8];
        v2273 = (0);
        for (; v2273 < (ArrayItems.Length); v2273 += 1)
        {
            if (!((false)))
                continue;
            if (v2274 >= 20)
                break;
            if (v2275 >= v2277)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2278, ref v2276, out v2277);
            v2278[v2275] = ((ArrayItems[v2273]));
            v2274++;
            v2275++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2278, v2275);
    }

    int[] ArrayTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2281;
        int v2282;
        if (20 > (ArrayItems.Length))
            v2282 = (ArrayItems.Length);
        else
            v2282 = 20;
        int[] v2283;
        v2283 = new int[(v2282)];
        System.Array.Copy(ArrayItems, (0), v2283, 0, (v2282));
        return v2283;
    }

    int[] EnumerableTakeToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2284;
        int v2285;
        int v2286;
        int v2287;
        int[] v2288;
        v2284 = EnumerableItems.GetEnumerator();
        v2285 = 0;
        v2286 = 0;
        v2287 = 8;
        v2288 = new int[8];
        try
        {
            while (v2284.MoveNext())
            {
                if (v2285 >= 20)
                    break;
                if (v2286 >= v2287)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2288, ref v2287);
                v2288[v2286] = (v2284.Current);
                v2285++;
                v2286++;
            }
        }
        finally
        {
            v2284.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2288, v2286);
    }

    int[] RangeTakeToArrayRewritten_ProceduralLinq1()
    {
        int v2289;
        int v2290;
        if (20 > (100))
            v2290 = (100);
        else
            v2290 = 20;
        int[] v2291;
        int v2292;
        v2291 = new int[(v2290)];
        v2292 = 0;
        v2289 = (0);
        for (; v2289 < (v2290); v2289 += (1))
        {
            v2291[v2292] = (v2289);
            v2292++;
        }

        return v2291;
    }

    int[] RepeatTakeToArrayRewritten_ProceduralLinq1()
    {
        int v2293;
        int v2294;
        if (20 > (100))
            v2294 = (100);
        else
            v2294 = 20;
        int[] v2295;
        int v2296;
        v2295 = new int[(v2294)];
        v2296 = 0;
        v2293 = (0);
        for (; v2293 < (v2294); v2293 += 1)
        {
            v2295[v2296] = (0);
            v2296++;
        }

        return v2295;
    }
}}