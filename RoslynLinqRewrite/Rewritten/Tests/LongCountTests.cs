using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class LongCountTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int i) => i > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayLongCount), ArrayLongCount, ArrayLongCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLongCount2), ArrayLongCount2, ArrayLongCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectLongCount), ArraySelectLongCount, ArraySelectLongCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayLongCount5), ArrayLongCount5, ArrayLongCount5Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableLongCount2), EnumerableLongCount2, EnumerableLongCount2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableLongCount3), EnumerableLongCount3, EnumerableLongCount3Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableLongCount4), EnumerableLongCount4, EnumerableLongCount4Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableLongCount5), EnumerableLongCount5, EnumerableLongCount5Rewritten);
        TestsExtensions.TestEquals(nameof(RangeLongCount), RangeLongCount, RangeLongCountRewritten);
        TestsExtensions.TestEquals(nameof(RangeSelectLongCount), RangeSelectLongCount, RangeSelectLongCountRewritten);
        TestsExtensions.TestEquals(nameof(RangeWhereLongCount), RangeWhereLongCount, RangeWhereLongCountRewritten);
        TestsExtensions.TestEquals(nameof(RangeLongCount2), RangeLongCount2, RangeLongCount2Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatLongCount), RepeatLongCount, RepeatLongCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayMethodLongCount), ArrayMethodLongCount, ArrayMethodLongCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctLongCount), ArrayDistinctLongCount, ArrayDistinctLongCountRewritten);
        TestsExtensions.TestEquals(nameof(EmptyLongCount), EmptyLongCount, EmptyLongCountRewritten);
        TestsExtensions.TestEquals(nameof(EmptyDistinctLongCount), EmptyDistinctLongCount, EmptyDistinctLongCountRewritten);
    }

    [NoRewrite]
    public long ArrayLongCount()
    {
        return ArrayItems.LongCount();
    } //EndMethod

    public long ArrayLongCountRewritten()
    {
        return (long)ArrayItems.Length;
    } //EndMethod=

    [NoRewrite]
    public long ArrayLongCount2()
    {
        return ArrayItems.LongCount(x => x > 3);
    } //EndMethod

    public long ArrayLongCount2Rewritten()
    {
        return ArrayLongCount2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long ArraySelectLongCount()
    {
        return ArrayItems.Select(x => x + 10).LongCount();
    } //EndMethod

    public long ArraySelectLongCountRewritten()
    {
        return (long)ArrayItems.Length;
    } //EndMethod

    [NoRewrite]
    public long ArrayLongCount5()
    {
        return ArrayItems.Where(x => x > 4).LongCount(x => x % 2 == 0);
    } //EndMethod

    public long ArrayLongCount5Rewritten()
    {
        return ArrayLongCount5Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long EnumerableLongCount2()
    {
        return EnumerableItems.LongCount();
    } //EndMethod

    public long EnumerableLongCount2Rewritten()
    {
        return EnumerableLongCount2Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public long EnumerableLongCount3()
    {
        return EnumerableItems.LongCount(x => x > 3);
    } //EndMethod

    public long EnumerableLongCount3Rewritten()
    {
        return EnumerableLongCount3Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public long EnumerableLongCount4()
    {
        return ArrayItems.Select(x => x + 10).LongCount();
    } //EndMethod

    public long EnumerableLongCount4Rewritten()
    {
        return (long)ArrayItems.Length;
    } //EndMethod

    [NoRewrite]
    public long EnumerableLongCount5()
    {
        return ArrayItems.Where(x => x > 4).LongCount(x => x % 2 == 0);
    } //EndMethod

    public long EnumerableLongCount5Rewritten()
    {
        return EnumerableLongCount5Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long RangeLongCount()
    {
        return Enumerable.Range(5, 256).LongCount();
    } //EndMethod

    public long RangeLongCountRewritten()
    {
        return (long)256;
    } //EndMethod

    [NoRewrite]
    public long RangeSelectLongCount()
    {
        return Enumerable.Range(5, 256).Select(x => x + 3).LongCount();
    } //EndMethod

    public long RangeSelectLongCountRewritten()
    {
        return (long)256;
    } //EndMethod

    [NoRewrite]
    public long RangeWhereLongCount()
    {
        return Enumerable.Range(5, 256).Where(x => x > 100).LongCount();
    } //EndMethod

    public long RangeWhereLongCountRewritten()
    {
        return RangeWhereLongCountRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public long RangeLongCount2()
    {
        return Enumerable.Range(5, 256).LongCount(x => x > 100);
    } //EndMethod

    public long RangeLongCount2Rewritten()
    {
        return RangeLongCount2Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public long RepeatLongCount()
    {
        return Enumerable.Repeat(5, 256).LongCount();
    } //EndMethod

    public long RepeatLongCountRewritten()
    {
        return (long)256;
    } //EndMethod

    [NoRewrite]
    public long ArrayMethodLongCount()
    {
        return ArrayItems.LongCount(Predicate);
    } //EndMethod

    public long ArrayMethodLongCountRewritten()
    {
        return ArrayMethodLongCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long ArrayDistinctLongCount()
    {
        return ArrayItems.Distinct().LongCount();
    } //EndMethod

    public long ArrayDistinctLongCountRewritten()
    {
        return ArrayDistinctLongCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long EmptyLongCount()
    {
        return Enumerable.Empty<int>().LongCount();
    } //EndMethod

    public long EmptyLongCountRewritten()
    {
        return (long)0;
    } //EndMethod

    [NoRewrite]
    public long EmptyDistinctLongCount()
    {
        return Enumerable.Empty<int>().Distinct().LongCount();
    } //EndMethod

    public long EmptyDistinctLongCountRewritten()
    {
        return EmptyDistinctLongCountRewritten_ProceduralLinq1();
    } //EndMethod

    long ArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1258;
        long v1259;
        v1259 = 0;
        v1258 = 0;
        for (; v1258 < ArrayItems.Length; v1258++)
        {
            if (!((ArrayItems[v1258] > 3)))
                continue;
            v1259++;
        }

        return v1259;
    }

    long ArrayLongCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1261;
        long v1262;
        v1262 = 0;
        v1261 = 0;
        for (; v1261 < ArrayItems.Length; v1261++)
        {
            if (!((ArrayItems[v1261] > 4)))
                continue;
            if (!((ArrayItems[v1261] % 2 == 0)))
                continue;
            v1262++;
        }

        return v1262;
    }

    long EnumerableLongCount2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1263;
        long v1264;
        v1263 = EnumerableItems.GetEnumerator();
        v1264 = 0;
        try
        {
            while (v1263.MoveNext())
                v1264++;
        }
        finally
        {
            v1263.Dispose();
        }

        return v1264;
    }

    long EnumerableLongCount3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1265;
        long v1266;
        v1265 = EnumerableItems.GetEnumerator();
        v1266 = 0;
        try
        {
            while (v1265.MoveNext())
            {
                if (!((v1265.Current > 3)))
                    continue;
                v1266++;
            }
        }
        finally
        {
            v1265.Dispose();
        }

        return v1266;
    }

    long EnumerableLongCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1268;
        long v1269;
        v1269 = 0;
        v1268 = 0;
        for (; v1268 < ArrayItems.Length; v1268++)
        {
            if (!((ArrayItems[v1268] > 4)))
                continue;
            if (!((ArrayItems[v1268] % 2 == 0)))
                continue;
            v1269++;
        }

        return v1269;
    }

    long RangeWhereLongCountRewritten_ProceduralLinq1()
    {
        int v1272;
        if (256 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int v1273;
        long v1274;
        v1274 = 0;
        v1272 = 0;
        for (; v1272 < 256; v1272++)
        {
            v1273 = (v1272 + 5);
            if (!((v1273 > 100)))
                continue;
            v1274++;
        }

        return v1274;
    }

    long RangeLongCount2Rewritten_ProceduralLinq1()
    {
        int v1275;
        if (256 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        long v1276;
        v1276 = 0;
        v1275 = 0;
        for (; v1275 < 256; v1275++)
        {
            if (!(((v1275 + 5) > 100)))
                continue;
            v1276++;
        }

        return v1276;
    }

    long ArrayMethodLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1278;
        long v1279;
        v1279 = 0;
        v1278 = 0;
        for (; v1278 < ArrayItems.Length; v1278++)
        {
            if (!(Predicate(ArrayItems[v1278])))
                continue;
            v1279++;
        }

        return v1279;
    }

    long ArrayDistinctLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1280;
        HashSet<int> v1281;
        long v1282;
        v1281 = new HashSet<int>();
        v1282 = 0;
        v1280 = 0;
        for (; v1280 < ArrayItems.Length; v1280++)
        {
            if (!(v1281.Add(ArrayItems[v1280])))
                continue;
            v1282++;
        }

        return v1282;
    }

    long EmptyDistinctLongCountRewritten_ProceduralLinq1()
    {
        int v1284;
        HashSet<int> v1285;
        long v1286;
        v1285 = new HashSet<int>();
        v1286 = 0;
        v1284 = 0;
        for (; v1284 < 0; v1284++)
        {
            if (!(v1285.Add(default(int))))
                continue;
            v1286++;
        }

        return v1286;
    }
}}