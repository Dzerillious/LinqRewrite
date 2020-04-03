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
        return EnumerableItems.ToArray();
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
        int[] v2319;
        v2319 = new int[ArrayItems.Length];
        System.Array.Copy(ArrayItems, 0, v2319, 0, ArrayItems.Length);
        return v2319;
    }

    int[] ArrayWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v2320;
        int v2321;
        int v2322;
        int v2323;
        int[] v2324;
        v2321 = 0;
        v2322 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2322 -= (v2322 % 2);
        v2323 = 8;
        v2324 = new int[8];
        v2320 = 0;
        for (; v2320 < ArrayItems.Length; v2320++)
        {
            if (!((ArrayItems[v2320] > offset)))
                continue;
            if (v2321 >= v2323)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2324, ref v2322, out v2323);
            v2324[v2321] = ArrayItems[v2320];
            v2321++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2324, v2321);
    }

    int[] EnumerableWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2325;
        int v2326;
        int v2327;
        int v2328;
        int[] v2329;
        v2325 = EnumerableItems.GetEnumerator();
        v2327 = 0;
        v2328 = 8;
        v2329 = new int[8];
        try
        {
            while (v2325.MoveNext())
            {
                v2326 = v2325.Current;
                if (!((v2326 > offset)))
                    continue;
                if (v2327 >= v2328)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2329, ref v2328);
                v2329[v2327] = v2326;
                v2327++;
            }
        }
        finally
        {
            v2325.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2329, v2327);
    }

    int[] SimpleListWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2330;
        int v2331;
        int v2332;
        int v2333;
        int[] v2334;
        v2330 = SimpleListItems.GetEnumerator();
        v2332 = 0;
        v2333 = 8;
        v2334 = new int[8];
        try
        {
            while (v2330.MoveNext())
            {
                v2331 = v2330.Current;
                if (!((v2331 > offset)))
                    continue;
                if (v2332 >= v2333)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2334, ref v2333);
                v2334[v2332] = v2331;
                v2332++;
            }
        }
        finally
        {
            v2330.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2334, v2332);
    }

    int[] ListWhereParamToArrayTestRewritten_ProceduralLinq1(int offset, System.Collections.Generic.List<int> ListItems)
    {
        int v2335;
        int v2336;
        int v2337;
        int v2338;
        int v2339;
        int[] v2340;
        v2335 = ListItems.Count;
        v2337 = 0;
        v2338 = (LinqRewrite.Core.IntExtensions.Log2((uint)v2335) - 3);
        v2338 -= (v2338 % 2);
        v2339 = 8;
        v2340 = new int[8];
        v2336 = 0;
        for (; v2336 < v2335; v2336++)
        {
            if (!((ListItems[v2336] > offset)))
                continue;
            if (v2337 >= v2339)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, v2335, ref v2340, ref v2338, out v2339);
            v2340[v2337] = ListItems[v2336];
            v2337++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2340, v2337);
    }

    int[] RangeWhereParamToArrayTestRewritten_ProceduralLinq1(int offset)
    {
        int v2341;
        int v2342;
        int v2343;
        int v2344;
        int v2345;
        int[] v2346;
        v2343 = 0;
        v2344 = (LinqRewrite.Core.IntExtensions.Log2((uint)1000) - 3);
        v2344 -= (v2344 % 2);
        v2345 = 8;
        v2346 = new int[8];
        v2341 = 0;
        for (; v2341 < 1000; v2341++)
        {
            v2342 = (v2341 + 0);
            if (!((v2342 > offset)))
                continue;
            if (v2343 >= v2345)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 1000, ref v2346, ref v2344, out v2345);
            v2346[v2343] = v2342;
            v2343++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2346, v2343);
    }

    int[] RangeParamToArrayTestRewritten_ProceduralLinq1(int count)
    {
        if (count < 0)
            throw new System.InvalidOperationException("Index out of range");
        int v2347;
        int[] v2348;
        v2348 = new int[count];
        v2347 = 0;
        for (; v2347 < count; v2347++)
            v2348[v2347] = (v2347 + 0);
        return v2348;
    }

    int[] RepeatParamToArrayTestRewritten_ProceduralLinq1(int count)
    {
        if (count < 0)
            throw new System.InvalidOperationException("Index out of range");
        int v2349;
        int[] v2350;
        v2350 = new int[count];
        v2349 = 0;
        for (; v2349 < count; v2349++)
            v2350[v2349] = 0;
        return v2350;
    }

    int[] RepeatWhereParamToArrayTestRewritten_ProceduralLinq1(int offset)
    {
        int v2351;
        int v2352;
        int v2353;
        int v2354;
        int[] v2355;
        v2352 = 0;
        v2353 = (LinqRewrite.Core.IntExtensions.Log2((uint)1000) - 3);
        v2353 -= (v2353 % 2);
        v2354 = 8;
        v2355 = new int[8];
        v2351 = 0;
        for (; v2351 < 1000; v2351++)
        {
            if (!((v2351 < offset)))
                continue;
            if (v2352 >= v2354)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 1000, ref v2355, ref v2353, out v2354);
            v2355[v2352] = 0;
            v2352++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2355, v2352);
    }
}}