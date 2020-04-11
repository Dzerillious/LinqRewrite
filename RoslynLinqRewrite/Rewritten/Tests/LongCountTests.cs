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
        return (long)(ArrayItems.Length);
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
        return (long)(ArrayItems.Length);
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
        return (long)(ArrayItems.Length);
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
        return RangeLongCountRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public long RangeSelectLongCount()
    {
        return Enumerable.Range(5, 256).Select(x => x + 3).LongCount();
    } //EndMethod

    public long RangeSelectLongCountRewritten()
    {
        return RangeSelectLongCountRewritten_ProceduralLinq1();
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
        return RepeatLongCountRewritten_ProceduralLinq1();
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
        return EmptyLongCountRewritten_ProceduralLinq1();
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
        int v1377;
        long v1378;
        v1378 = 0;
        v1377 = (0);
        for (; v1377 < (ArrayItems.Length); v1377 += 1)
        {
            if (!(((ArrayItems[v1377]) > 3)))
                continue;
            v1378++;
        }

        return v1378;
    }

    long ArrayLongCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1380;
        long v1381;
        v1381 = 0;
        v1380 = (0);
        for (; v1380 < (ArrayItems.Length); v1380 += 1)
        {
            if (!((((ArrayItems[v1380])) > 4)))
                continue;
            if (!((((ArrayItems[v1380])) % 2 == 0)))
                continue;
            v1381++;
        }

        return v1381;
    }

    long EnumerableLongCount2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1382;
        long v1383;
        v1382 = EnumerableItems.GetEnumerator();
        v1383 = 0;
        try
        {
            while (v1382.MoveNext())
                v1383++;
        }
        finally
        {
            v1382.Dispose();
        }

        return v1383;
    }

    long EnumerableLongCount3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1384;
        long v1385;
        v1384 = EnumerableItems.GetEnumerator();
        v1385 = 0;
        try
        {
            while (v1384.MoveNext())
            {
                if (!(((v1384.Current) > 3)))
                    continue;
                v1385++;
            }
        }
        finally
        {
            v1384.Dispose();
        }

        return v1385;
    }

    long EnumerableLongCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1387;
        long v1388;
        v1388 = 0;
        v1387 = (0);
        for (; v1387 < (ArrayItems.Length); v1387 += 1)
        {
            if (!((((ArrayItems[v1387])) > 4)))
                continue;
            if (!((((ArrayItems[v1387])) % 2 == 0)))
                continue;
            v1388++;
        }

        return v1388;
    }

    long RangeLongCountRewritten_ProceduralLinq1()
    {
        int v1389;
        v1389 = (0);
        for (; v1389 < (256); v1389 += (1))
            ;
        return v1389;
    }

    long RangeSelectLongCountRewritten_ProceduralLinq1()
    {
        int v1390;
        v1390 = (0);
        for (; v1390 < (256); v1390 += (1))
            ;
        return v1390;
    }

    long RangeWhereLongCountRewritten_ProceduralLinq1()
    {
        int v1391;
        int v1392;
        long v1393;
        v1393 = 0;
        v1391 = (0);
        for (; v1391 < (256); v1391 += (1))
        {
            v1392 = (5 + v1391);
            if (!(((v1392) > 100)))
                continue;
            v1393++;
        }

        return v1393;
    }

    long RangeLongCount2Rewritten_ProceduralLinq1()
    {
        int v1394;
        long v1395;
        v1395 = 0;
        v1394 = (0);
        for (; v1394 < (256); v1394 += (1))
        {
            if (!(((5 + v1394) > 100)))
                continue;
            v1395++;
        }

        return v1395;
    }

    long RepeatLongCountRewritten_ProceduralLinq1()
    {
        int v1396;
        v1396 = (0);
        for (; v1396 < (256); v1396 += 1)
            ;
        return v1396;
    }

    long ArrayMethodLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1398;
        long v1399;
        v1399 = 0;
        v1398 = (0);
        for (; v1398 < (ArrayItems.Length); v1398 += 1)
        {
            if (!(Predicate((ArrayItems[v1398]))))
                continue;
            v1399++;
        }

        return v1399;
    }

    long ArrayDistinctLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1400;
        HashSet<int> v1401;
        long v1402;
        v1401 = new HashSet<int>();
        v1402 = 0;
        v1400 = (0);
        for (; v1400 < (ArrayItems.Length); v1400 += 1)
        {
            if (!(v1401.Add(((ArrayItems[v1400])))))
                continue;
            v1402++;
        }

        return v1402;
    }

    long EmptyLongCountRewritten_ProceduralLinq1()
    {
        int v1403;
        v1403 = 0;
        return v1403;
    }

    long EmptyDistinctLongCountRewritten_ProceduralLinq1()
    {
        int v1404;
        HashSet<int> v1405;
        long v1406;
        v1404 = 0;
        v1405 = new HashSet<int>();
        v1406 = 0;
        return v1406;
    }
}}