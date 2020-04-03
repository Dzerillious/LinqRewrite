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
        int v1231;
        long v1232;
        v1232 = 0;
        v1231 = 0;
        for (; v1231 < ArrayItems.Length; v1231++)
        {
            if (!((ArrayItems[v1231] > 3)))
                continue;
            v1232++;
        }

        return v1232;
    }

    long ArrayLongCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1234;
        long v1235;
        v1235 = 0;
        v1234 = 0;
        for (; v1234 < ArrayItems.Length; v1234++)
        {
            if (!((ArrayItems[v1234] > 4)))
                continue;
            if (!((ArrayItems[v1234] % 2 == 0)))
                continue;
            v1235++;
        }

        return v1235;
    }

    long EnumerableLongCount2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1236;
        long v1237;
        v1236 = EnumerableItems.GetEnumerator();
        v1237 = 0;
        try
        {
            while (v1236.MoveNext())
                v1237++;
        }
        finally
        {
            v1236.Dispose();
        }

        return v1237;
    }

    long EnumerableLongCount3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1238;
        long v1239;
        v1238 = EnumerableItems.GetEnumerator();
        v1239 = 0;
        try
        {
            while (v1238.MoveNext())
            {
                if (!((v1238.Current > 3)))
                    continue;
                v1239++;
            }
        }
        finally
        {
            v1238.Dispose();
        }

        return v1239;
    }

    long EnumerableLongCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1241;
        long v1242;
        v1242 = 0;
        v1241 = 0;
        for (; v1241 < ArrayItems.Length; v1241++)
        {
            if (!((ArrayItems[v1241] > 4)))
                continue;
            if (!((ArrayItems[v1241] % 2 == 0)))
                continue;
            v1242++;
        }

        return v1242;
    }

    long RangeWhereLongCountRewritten_ProceduralLinq1()
    {
        int v1245;
        int v1246;
        long v1247;
        v1247 = 0;
        v1245 = 0;
        for (; v1245 < 256; v1245++)
        {
            v1246 = (v1245 + 5);
            if (!((v1246 > 100)))
                continue;
            v1247++;
        }

        return v1247;
    }

    long RangeLongCount2Rewritten_ProceduralLinq1()
    {
        int v1248;
        long v1249;
        v1249 = 0;
        v1248 = 0;
        for (; v1248 < 256; v1248++)
        {
            if (!(((v1248 + 5) > 100)))
                continue;
            v1249++;
        }

        return v1249;
    }

    long ArrayMethodLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1251;
        long v1252;
        v1252 = 0;
        v1251 = 0;
        for (; v1251 < ArrayItems.Length; v1251++)
        {
            if (!(Predicate(ArrayItems[v1251])))
                continue;
            v1252++;
        }

        return v1252;
    }

    long ArrayDistinctLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1253;
        HashSet<int> v1254;
        long v1255;
        v1254 = new HashSet<int>();
        v1255 = 0;
        v1253 = 0;
        for (; v1253 < ArrayItems.Length; v1253++)
        {
            if (!(v1254.Add(ArrayItems[v1253])))
                continue;
            v1255++;
        }

        return v1255;
    }

    long EmptyDistinctLongCountRewritten_ProceduralLinq1()
    {
        int v1257;
        HashSet<int> v1258;
        long v1259;
        v1258 = new HashSet<int>();
        v1259 = 0;
        v1257 = 0;
        for (; v1257 < 0; v1257++)
        {
            if (!(v1258.Add(default(int))))
                continue;
            v1259++;
        }

        return v1259;
    }
}}