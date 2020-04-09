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
        int v1540;
        long v1541;
        v1541 = 0;
        v1540 = (0);
        for (; v1540 < (ArrayItems.Length); v1540++)
        {
            if (!(((ArrayItems[v1540]) > 3)))
                continue;
            v1541++;
        }

        return v1541;
    }

    long ArrayLongCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1543;
        int v1544;
        long v1545;
        v1545 = 0;
        v1543 = (0);
        for (; v1543 < (ArrayItems.Length); v1543++)
        {
            v1544 = (ArrayItems[v1543]);
            if (!(((v1544) > 4)))
                continue;
            if (!(((v1544) % 2 == 0)))
                continue;
            v1545++;
        }

        return v1545;
    }

    long EnumerableLongCount2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1546;
        long v1547;
        v1546 = EnumerableItems.GetEnumerator();
        v1547 = 0;
        try
        {
            while (v1546.MoveNext())
                v1547++;
        }
        finally
        {
            v1546.Dispose();
        }

        return v1547;
    }

    long EnumerableLongCount3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1548;
        long v1549;
        v1548 = EnumerableItems.GetEnumerator();
        v1549 = 0;
        try
        {
            while (v1548.MoveNext())
            {
                if (!(((v1548.Current) > 3)))
                    continue;
                v1549++;
            }
        }
        finally
        {
            v1548.Dispose();
        }

        return v1549;
    }

    long EnumerableLongCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1551;
        int v1552;
        long v1553;
        v1553 = 0;
        v1551 = (0);
        for (; v1551 < (ArrayItems.Length); v1551++)
        {
            v1552 = (ArrayItems[v1551]);
            if (!(((v1552) > 4)))
                continue;
            if (!(((v1552) % 2 == 0)))
                continue;
            v1553++;
        }

        return v1553;
    }

    long RangeLongCountRewritten_ProceduralLinq1()
    {
        int v1554;
        v1554 = (0);
        for (; v1554 < (256); v1554++)
            ;
        return v1554;
    }

    long RangeSelectLongCountRewritten_ProceduralLinq1()
    {
        int v1555;
        v1555 = (0);
        for (; v1555 < (256); v1555++)
            ;
        return v1555;
    }

    long RangeWhereLongCountRewritten_ProceduralLinq1()
    {
        int v1556;
        int v1557;
        long v1558;
        v1558 = 0;
        v1556 = (0);
        for (; v1556 < (256); v1556++)
        {
            v1557 = (5 + v1556);
            if (!(((v1557) > 100)))
                continue;
            v1558++;
        }

        return v1558;
    }

    long RangeLongCount2Rewritten_ProceduralLinq1()
    {
        int v1559;
        long v1560;
        v1560 = 0;
        v1559 = (0);
        for (; v1559 < (256); v1559++)
        {
            if (!(((5 + v1559) > 100)))
                continue;
            v1560++;
        }

        return v1560;
    }

    long RepeatLongCountRewritten_ProceduralLinq1()
    {
        int v1561;
        v1561 = (0);
        for (; v1561 < (256); v1561++)
            ;
        return v1561;
    }

    long ArrayMethodLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1563;
        long v1564;
        v1564 = 0;
        v1563 = (0);
        for (; v1563 < (ArrayItems.Length); v1563++)
        {
            if (!(Predicate((ArrayItems[v1563]))))
                continue;
            v1564++;
        }

        return v1564;
    }

    long ArrayDistinctLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1565;
        HashSet<int> v1566;
        int v1567;
        long v1568;
        v1566 = new HashSet<int>();
        v1568 = 0;
        v1565 = (0);
        for (; v1565 < (ArrayItems.Length); v1565++)
        {
            v1567 = (ArrayItems[v1565]);
            if (!(v1566.Add((v1567))))
                continue;
            v1568++;
        }

        return v1568;
    }

    long EmptyLongCountRewritten_ProceduralLinq1()
    {
        int v1569;
        v1569 = 0;
        return v1569;
    }

    long EmptyDistinctLongCountRewritten_ProceduralLinq1()
    {
        int v1570;
        HashSet<int> v1571;
        int v1572;
        long v1573;
        v1570 = 0;
        v1571 = new HashSet<int>();
        v1573 = 0;
        return v1573;
    }
}}