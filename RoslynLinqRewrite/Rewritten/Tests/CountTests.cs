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
        int v484;
        int v485;
        v485 = 0;
        v484 = (0);
        for (; v484 < (ArrayItems.Length); v484 += 1)
        {
            if (!(((ArrayItems[v484]) > 3)))
                continue;
            v485++;
        }

        return v485;
    }

    int ArrayCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v487;
        int v488;
        v488 = 0;
        v487 = (0);
        for (; v487 < (ArrayItems.Length); v487 += 1)
        {
            if (!((((ArrayItems[v487])) > 4)))
                continue;
            if (!((((ArrayItems[v487])) % 2 == 0)))
                continue;
            v488++;
        }

        return v488;
    }

    int EnumerableCount2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v489;
        int v490;
        v489 = EnumerableItems.GetEnumerator();
        v490 = 0;
        try
        {
            while (v489.MoveNext())
                v490++;
        }
        finally
        {
            v489.Dispose();
        }

        return v490;
    }

    int EnumerableCount3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v491;
        int v492;
        v491 = EnumerableItems.GetEnumerator();
        v492 = 0;
        try
        {
            while (v491.MoveNext())
            {
                if (!(((v491.Current) > 3)))
                    continue;
                v492++;
            }
        }
        finally
        {
            v491.Dispose();
        }

        return v492;
    }

    int EnumerableCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v494;
        int v495;
        v495 = 0;
        v494 = (0);
        for (; v494 < (ArrayItems.Length); v494 += 1)
        {
            if (!((((ArrayItems[v494])) > 4)))
                continue;
            if (!((((ArrayItems[v494])) % 2 == 0)))
                continue;
            v495++;
        }

        return v495;
    }

    int RangeCountRewritten_ProceduralLinq1()
    {
        int v496;
        v496 = (0);
        for (; v496 < (256); v496 += (1))
            ;
        return v496;
    }

    int RangeSelectCountRewritten_ProceduralLinq1()
    {
        int v497;
        v497 = (0);
        for (; v497 < (256); v497 += (1))
            ;
        return v497;
    }

    int RangeWhereCountRewritten_ProceduralLinq1()
    {
        int v498;
        int v499;
        int v500;
        v500 = 0;
        v498 = (0);
        for (; v498 < (256); v498 += (1))
        {
            v499 = (5 + v498);
            if (!(((v499) > 100)))
                continue;
            v500++;
        }

        return v500;
    }

    int RangeCount2Rewritten_ProceduralLinq1()
    {
        int v501;
        int v502;
        v502 = 0;
        v501 = (0);
        for (; v501 < (256); v501 += (1))
        {
            if (!(((5 + v501) > 100)))
                continue;
            v502++;
        }

        return v502;
    }

    int RepeatCountRewritten_ProceduralLinq1()
    {
        int v503;
        v503 = (0);
        for (; v503 < (256); v503 += 1)
            ;
        return v503;
    }

    int ArrayMethodCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v505;
        int v506;
        v506 = 0;
        v505 = (0);
        for (; v505 < (ArrayItems.Length); v505 += 1)
        {
            if (!(Predicate((ArrayItems[v505]))))
                continue;
            v506++;
        }

        return v506;
    }

    int ArrayDistinctCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v507;
        HashSet<int> v508;
        int v509;
        v508 = new HashSet<int>();
        v509 = 0;
        v507 = (0);
        for (; v507 < (ArrayItems.Length); v507 += 1)
        {
            if (!(v508.Add(((ArrayItems[v507])))))
                continue;
            v509++;
        }

        return v509;
    }

    int EmptyCountRewritten_ProceduralLinq1()
    {
        int v510;
        v510 = 0;
        return v510;
    }

    int EmptyDistinctCountRewritten_ProceduralLinq1()
    {
        int v511;
        HashSet<int> v512;
        int v513;
        v511 = 0;
        v512 = new HashSet<int>();
        v513 = 0;
        return v513;
    }
}}