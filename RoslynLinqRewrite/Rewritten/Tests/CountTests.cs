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
    public void RunTests()
    {
        ArrayCount().TestEquals(nameof(ArrayCount), ArrayCountRewritten());
        ArrayCount2().TestEquals(nameof(ArrayCount2), ArrayCount2Rewritten());
        ArrayCount3().TestEquals(nameof(ArrayCount3), ArrayCount3Rewritten());
        ArrayCount4().TestEquals(nameof(ArrayCount4), ArrayCount4Rewritten());
        ArrayCount5().TestEquals(nameof(ArrayCount5), ArrayCount5Rewritten());
        EnumerableCount2().TestEquals(nameof(EnumerableCount2), EnumerableCount2Rewritten());
        EnumerableCount3().TestEquals(nameof(EnumerableCount3), EnumerableCount3Rewritten());
        EnumerableCount4().TestEquals(nameof(EnumerableCount4), EnumerableCount4Rewritten());
        EnumerableCount5().TestEquals(nameof(EnumerableCount5), EnumerableCount5Rewritten());
    }

    [NoRewrite]
    public int ArrayCount()
    {
        return ArrayItems.Length;
    } //EndMethod

    public int ArrayCountRewritten()
    {
        return ArrayItems.Length;
    } //EndMethod

    [NoRewrite]
    public int ArrayCount2()
    {
        return ArrayItems.Count();
    } //EndMethod

    public int ArrayCount2Rewritten()
    {
        return ArrayItems.Length;
    } //EndMethod

    [NoRewrite]
    public int ArrayCount3()
    {
        return ArrayItems.Count(x => x > 3);
    } //EndMethod

    public int ArrayCount3Rewritten()
    {
        return ArrayCount3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayCount4()
    {
        return ArrayItems.Select(x => x + 10).Count();
    } //EndMethod

    public int ArrayCount4Rewritten()
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

    int ArrayCount3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v118;
        int v119;
        v119 = 0;
        v118 = 0;
        for (; v118 < ArrayItems.Length; v118++)
        {
            if (!(ArrayItems[v118] > 3))
                continue;
            v119++;
        }

        return v119;
    }

    int ArrayCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v121;
        int v122;
        v122 = 0;
        v121 = 0;
        for (; v121 < ArrayItems.Length; v121++)
        {
            if (!(ArrayItems[v121] > 4))
                continue;
            if (!(ArrayItems[v121] % 2 == 0))
                continue;
            v122++;
        }

        return v122;
    }

    int EnumerableCount2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v123;
        int v124;
        v124 = 0;
        v123 = EnumerableItems.GetEnumerator();
        try
        {
            while (v123.MoveNext())
                v124++;
        }
        finally
        {
            v123.Dispose();
        }

        return v124;
    }

    int EnumerableCount3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v125;
        int v126;
        v126 = 0;
        v125 = EnumerableItems.GetEnumerator();
        try
        {
            while (v125.MoveNext())
            {
                if (!(v125.Current > 3))
                    continue;
                v126++;
            }
        }
        finally
        {
            v125.Dispose();
        }

        return v126;
    }

    int EnumerableCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v128;
        int v129;
        v129 = 0;
        v128 = 0;
        for (; v128 < ArrayItems.Length; v128++)
        {
            if (!(ArrayItems[v128] > 4))
                continue;
            if (!(ArrayItems[v128] % 2 == 0))
                continue;
            v129++;
        }

        return v129;
    }
}}