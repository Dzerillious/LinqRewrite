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
        int v433;
        int v434;
        v434 = 0;
        v433 = 0;
        for (; v433 < ArrayItems.Length; v433++)
        {
            if (!((ArrayItems[v433] > 3)))
                continue;
            v434++;
        }

        return v434;
    }

    int ArrayCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v436;
        int v437;
        v437 = 0;
        v436 = 0;
        for (; v436 < ArrayItems.Length; v436++)
        {
            if (!((ArrayItems[v436] > 4)))
                continue;
            if (!((ArrayItems[v436] % 2 == 0)))
                continue;
            v437++;
        }

        return v437;
    }

    int EnumerableCount2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v438;
        int v439;
        v438 = EnumerableItems.GetEnumerator();
        v439 = 0;
        try
        {
            while (v438.MoveNext())
                v439++;
        }
        finally
        {
            v438.Dispose();
        }

        return v439;
    }

    int EnumerableCount3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v440;
        int v441;
        v440 = EnumerableItems.GetEnumerator();
        v441 = 0;
        try
        {
            while (v440.MoveNext())
            {
                if (!((v440.Current > 3)))
                    continue;
                v441++;
            }
        }
        finally
        {
            v440.Dispose();
        }

        return v441;
    }

    int EnumerableCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v443;
        int v444;
        v444 = 0;
        v443 = 0;
        for (; v443 < ArrayItems.Length; v443++)
        {
            if (!((ArrayItems[v443] > 4)))
                continue;
            if (!((ArrayItems[v443] % 2 == 0)))
                continue;
            v444++;
        }

        return v444;
    }

    int RangeWhereCountRewritten_ProceduralLinq1()
    {
        int v447;
        if (256 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int v448;
        int v449;
        v449 = 0;
        v447 = 0;
        for (; v447 < 256; v447++)
        {
            v448 = (v447 + 5);
            if (!((v448 > 100)))
                continue;
            v449++;
        }

        return v449;
    }

    int RangeCount2Rewritten_ProceduralLinq1()
    {
        int v450;
        if (256 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int v451;
        v451 = 0;
        v450 = 0;
        for (; v450 < 256; v450++)
        {
            if (!(((v450 + 5) > 100)))
                continue;
            v451++;
        }

        return v451;
    }

    int ArrayMethodCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v453;
        int v454;
        v454 = 0;
        v453 = 0;
        for (; v453 < ArrayItems.Length; v453++)
        {
            if (!(Predicate(ArrayItems[v453])))
                continue;
            v454++;
        }

        return v454;
    }

    int ArrayDistinctCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v455;
        HashSet<int> v456;
        int v457;
        v456 = new HashSet<int>();
        v457 = 0;
        v455 = 0;
        for (; v455 < ArrayItems.Length; v455++)
        {
            if (!(v456.Add(ArrayItems[v455])))
                continue;
            v457++;
        }

        return v457;
    }

    int EmptyDistinctCountRewritten_ProceduralLinq1()
    {
        int v459;
        HashSet<int> v460;
        int v461;
        v460 = new HashSet<int>();
        v461 = 0;
        v459 = 0;
        for (; v459 < 0; v459++)
        {
            if (!(v460.Add(default(int))))
                continue;
            v461++;
        }

        return v461;
    }
}}