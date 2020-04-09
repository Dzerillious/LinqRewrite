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
        return (ArrayItems.Length);
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
        return (ArrayItems.Length);
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
        return (ArrayItems.Length);
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
        return RangeCountRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int RangeSelectCount()
    {
        return Enumerable.Range(5, 256).Select(x => x + 3).Count();
    } //EndMethod

    public int RangeSelectCountRewritten()
    {
        return RangeSelectCountRewritten_ProceduralLinq1();
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
        return RepeatCountRewritten_ProceduralLinq1();
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
        return EmptyCountRewritten_ProceduralLinq1();
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
        int v527;
        int v528;
        v528 = 0;
        v527 = (0);
        for (; v527 < (ArrayItems.Length); v527++)
        {
            if (!(((ArrayItems[v527]) > 3)))
                continue;
            v528++;
        }

        return v528;
    }

    int ArrayCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v530;
        int v531;
        int v532;
        v532 = 0;
        v530 = (0);
        for (; v530 < (ArrayItems.Length); v530++)
        {
            v531 = (ArrayItems[v530]);
            if (!(((v531) > 4)))
                continue;
            if (!(((v531) % 2 == 0)))
                continue;
            v532++;
        }

        return v532;
    }

    int EnumerableCount2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v533;
        int v534;
        v533 = EnumerableItems.GetEnumerator();
        v534 = 0;
        try
        {
            while (v533.MoveNext())
                v534++;
        }
        finally
        {
            v533.Dispose();
        }

        return v534;
    }

    int EnumerableCount3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v535;
        int v536;
        v535 = EnumerableItems.GetEnumerator();
        v536 = 0;
        try
        {
            while (v535.MoveNext())
            {
                if (!(((v535.Current) > 3)))
                    continue;
                v536++;
            }
        }
        finally
        {
            v535.Dispose();
        }

        return v536;
    }

    int EnumerableCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v538;
        int v539;
        int v540;
        v540 = 0;
        v538 = (0);
        for (; v538 < (ArrayItems.Length); v538++)
        {
            v539 = (ArrayItems[v538]);
            if (!(((v539) > 4)))
                continue;
            if (!(((v539) % 2 == 0)))
                continue;
            v540++;
        }

        return v540;
    }

    int RangeCountRewritten_ProceduralLinq1()
    {
        int v541;
        v541 = (0);
        for (; v541 < (256); v541++)
            ;
        return v541;
    }

    int RangeSelectCountRewritten_ProceduralLinq1()
    {
        int v542;
        v542 = (0);
        for (; v542 < (256); v542++)
            ;
        return v542;
    }

    int RangeWhereCountRewritten_ProceduralLinq1()
    {
        int v543;
        int v544;
        int v545;
        v545 = 0;
        v543 = (0);
        for (; v543 < (256); v543++)
        {
            v544 = (5 + v543);
            if (!(((v544) > 100)))
                continue;
            v545++;
        }

        return v545;
    }

    int RangeCount2Rewritten_ProceduralLinq1()
    {
        int v546;
        int v547;
        v547 = 0;
        v546 = (0);
        for (; v546 < (256); v546++)
        {
            if (!(((5 + v546) > 100)))
                continue;
            v547++;
        }

        return v547;
    }

    int RepeatCountRewritten_ProceduralLinq1()
    {
        int v548;
        v548 = (0);
        for (; v548 < (256); v548++)
            ;
        return v548;
    }

    int ArrayMethodCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v550;
        int v551;
        v551 = 0;
        v550 = (0);
        for (; v550 < (ArrayItems.Length); v550++)
        {
            if (!(Predicate((ArrayItems[v550]))))
                continue;
            v551++;
        }

        return v551;
    }

    int ArrayDistinctCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v552;
        HashSet<int> v553;
        int v554;
        int v555;
        v553 = new HashSet<int>();
        v555 = 0;
        v552 = (0);
        for (; v552 < (ArrayItems.Length); v552++)
        {
            v554 = (ArrayItems[v552]);
            if (!(v553.Add((v554))))
                continue;
            v555++;
        }

        return v555;
    }

    int EmptyCountRewritten_ProceduralLinq1()
    {
        int v556;
        v556 = 0;
        return v556;
    }

    int EmptyDistinctCountRewritten_ProceduralLinq1()
    {
        int v557;
        HashSet<int> v558;
        int v559;
        int v560;
        v557 = 0;
        v558 = new HashSet<int>();
        v560 = 0;
        return v560;
    }
}}