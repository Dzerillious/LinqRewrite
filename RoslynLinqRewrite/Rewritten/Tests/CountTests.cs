using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class CountTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int i) => i > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayCount), ArrayCount, ArrayCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayCount2), ArrayCount2, ArrayCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectCount), ArraySelectCount, ArraySelectCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayCount5), ArrayCount5, ArrayCount5Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableCount2), EnumerableCount2, EnumerableCount2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableCount3), EnumerableCount3, EnumerableCount3Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableCount4), EnumerableCount4, EnumerableCount4Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableCount5), EnumerableCount5, EnumerableCount5Rewritten);
        TestsExtensions.TestEquals(nameof(RangeCount), RangeCount, RangeCountRewritten);
        TestsExtensions.TestEquals(nameof(RangeSelectCount), RangeSelectCount, RangeSelectCountRewritten);
        TestsExtensions.TestEquals(nameof(RangeWhereCount), RangeWhereCount, RangeWhereCountRewritten);
        TestsExtensions.TestEquals(nameof(RangeCount2), RangeCount2, RangeCount2Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatCount), RepeatCount, RepeatCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayMethodCount), ArrayMethodCount, ArrayMethodCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctCount), ArrayDistinctCount, ArrayDistinctCountRewritten);
        TestsExtensions.TestEquals(nameof(EmptyCount), EmptyCount, EmptyCountRewritten);
        TestsExtensions.TestEquals(nameof(EmptyDistinctCount), EmptyDistinctCount, EmptyDistinctCountRewritten);
    }

    [NoRewrite]
    public int ArrayCount()
    {
        return ArrayItems.Count();
    } //EndMethod

    public int ArrayCountRewritten()
    {
        return ArrayItems.Length;
    } //EndMethod=

    [NoRewrite]
    public int ArrayCount2()
    {
        return ArrayItems.Count(x => x > 3);
    } //EndMethod

    public int ArrayCount2Rewritten()
    {
        return ArrayCount2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySelectCount()
    {
        return ArrayItems.Select(x => x + 10).Count();
    } //EndMethod

    public int ArraySelectCountRewritten()
    {
        return ArrayItems.Length;
    } //EndMethod

    [NoRewrite]
    public int ArrayCount5()
    {
        return ArrayItems.Where(x => x > 4).Count(x => x % 2 == 0);
    } //EndMethod

    public int ArrayCount5Rewritten()
    {
        return ArrayCount5Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int EnumerableCount2()
    {
        return EnumerableItems.Count();
    } //EndMethod

    public int EnumerableCount2Rewritten()
    {
        return EnumerableCount2Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int EnumerableCount3()
    {
        return EnumerableItems.Count(x => x > 3);
    } //EndMethod

    public int EnumerableCount3Rewritten()
    {
        return EnumerableCount3Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int EnumerableCount4()
    {
        return ArrayItems.Select(x => x + 10).Count();
    } //EndMethod

    public int EnumerableCount4Rewritten()
    {
        return ArrayItems.Length;
    } //EndMethod

    [NoRewrite]
    public int EnumerableCount5()
    {
        return ArrayItems.Where(x => x > 4).Count(x => x % 2 == 0);
    } //EndMethod

    public int EnumerableCount5Rewritten()
    {
        return EnumerableCount5Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int RangeCount()
    {
        return Enumerable.Range(5, 256).Count();
    } //EndMethod

    public int RangeCountRewritten()
    {
        return 256;
    } //EndMethod

    [NoRewrite]
    public int RangeSelectCount()
    {
        return Enumerable.Range(5, 256).Select(x => x + 3).Count();
    } //EndMethod

    public int RangeSelectCountRewritten()
    {
        return 256;
    } //EndMethod

    [NoRewrite]
    public int RangeWhereCount()
    {
        return Enumerable.Range(5, 256).Where(x => x > 100).Count();
    } //EndMethod

    public int RangeWhereCountRewritten()
    {
        return RangeWhereCountRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RangeCount2()
    {
        return Enumerable.Range(5, 256).Count(x => x > 100);
    } //EndMethod

    public int RangeCount2Rewritten()
    {
        return RangeCount2Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RepeatCount()
    {
        return Enumerable.Repeat(5, 256).Count();
    } //EndMethod

    public int RepeatCountRewritten()
    {
        return 256;
    } //EndMethod

    [NoRewrite]
    public int ArrayMethodCount()
    {
        return ArrayItems.Count(Predicate);
    } //EndMethod

    public int ArrayMethodCountRewritten()
    {
        return ArrayMethodCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayDistinctCount()
    {
        return ArrayItems.Distinct().Count();
    } //EndMethod

    public int ArrayDistinctCountRewritten()
    {
        return ArrayDistinctCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int EmptyCount()
    {
        return Enumerable.Empty<int>().Count();
    } //EndMethod

    public int EmptyCountRewritten()
    {
        return 0;
    } //EndMethod

    [NoRewrite]
    public int EmptyDistinctCount()
    {
        return Enumerable.Empty<int>().Distinct().Count();
    } //EndMethod

    public int EmptyDistinctCountRewritten()
    {
        return EmptyDistinctCountRewritten_ProceduralLinq1();
    } //EndMethod

    int ArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v422;
        int v423;
        v423 = 0;
        v422 = 0;
        for (; v422 < ArrayItems.Length; v422++)
        {
            if (!((ArrayItems[v422] > 3)))
                continue;
            v423++;
        }

        return v423;
    }

    int ArrayCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v425;
        int v426;
        v426 = 0;
        v425 = 0;
        for (; v425 < ArrayItems.Length; v425++)
        {
            if (!((ArrayItems[v425] > 4)))
                continue;
            if (!((ArrayItems[v425] % 2 == 0)))
                continue;
            v426++;
        }

        return v426;
    }

    int EnumerableCount2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v427;
        int v428;
        v427 = EnumerableItems.GetEnumerator();
        v428 = 0;
        try
        {
            while (v427.MoveNext())
                v428++;
        }
        finally
        {
            v427.Dispose();
        }

        return v428;
    }

    int EnumerableCount3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v429;
        int v430;
        v429 = EnumerableItems.GetEnumerator();
        v430 = 0;
        try
        {
            while (v429.MoveNext())
            {
                if (!((v429.Current > 3)))
                    continue;
                v430++;
            }
        }
        finally
        {
            v429.Dispose();
        }

        return v430;
    }

    int EnumerableCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v432;
        int v433;
        v433 = 0;
        v432 = 0;
        for (; v432 < ArrayItems.Length; v432++)
        {
            if (!((ArrayItems[v432] > 4)))
                continue;
            if (!((ArrayItems[v432] % 2 == 0)))
                continue;
            v433++;
        }

        return v433;
    }

    int RangeWhereCountRewritten_ProceduralLinq1()
    {
        int v436;
        int v437;
        int v438;
        v438 = 0;
        v436 = 0;
        for (; v436 < 256; v436++)
        {
            v437 = (v436 + 5);
            if (!((v437 > 100)))
                continue;
            v438++;
        }

        return v438;
    }

    int RangeCount2Rewritten_ProceduralLinq1()
    {
        int v439;
        int v440;
        v440 = 0;
        v439 = 0;
        for (; v439 < 256; v439++)
        {
            if (!(((v439 + 5) > 100)))
                continue;
            v440++;
        }

        return v440;
    }

    int ArrayMethodCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v442;
        int v443;
        v443 = 0;
        v442 = 0;
        for (; v442 < ArrayItems.Length; v442++)
        {
            if (!(Predicate(ArrayItems[v442])))
                continue;
            v443++;
        }

        return v443;
    }

    int ArrayDistinctCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v444;
        HashSet<int> v445;
        int v446;
        v445 = new HashSet<int>();
        v446 = 0;
        v444 = 0;
        for (; v444 < ArrayItems.Length; v444++)
        {
            if (!(v445.Add(ArrayItems[v444])))
                continue;
            v446++;
        }

        return v446;
    }

    int EmptyDistinctCountRewritten_ProceduralLinq1()
    {
        int v448;
        HashSet<int> v449;
        int v450;
        v449 = new HashSet<int>();
        v450 = 0;
        v448 = 0;
        for (; v448 < 0; v448++)
        {
            if (!(v449.Add(default(int))))
                continue;
            v450++;
        }

        return v450;
    }
}}