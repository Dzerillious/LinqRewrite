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
        TestsExtensions.TestEquals(nameof(ArrayCount), ArrayCount, ArrayCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayCount2), ArrayCount2, ArrayCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayCount3), ArrayCount3, ArrayCount3Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayCount4), ArrayCount4, ArrayCount4Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayCount5), ArrayCount5, ArrayCount5Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableCount2), EnumerableCount2, EnumerableCount2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableCount3), EnumerableCount3, EnumerableCount3Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableCount4), EnumerableCount4, EnumerableCount4Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableCount5), EnumerableCount5, EnumerableCount5Rewritten);
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
        int v154;
        int v155;
        v155 = 0;
        v154 = 0;
        for (; v154 < ArrayItems.Length; v154++)
        {
            if (!(ArrayItems[v154] > 3))
                continue;
            v155++;
        }

        return v155;
    }

    int ArrayCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v157;
        int v158;
        v158 = 0;
        v157 = 0;
        for (; v157 < ArrayItems.Length; v157++)
        {
            if (!(ArrayItems[v157] > 4))
                continue;
            if (!(ArrayItems[v157] % 2 == 0))
                continue;
            v158++;
        }

        return v158;
    }

    int EnumerableCount2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v159;
        int v160;
        v160 = 0;
        v159 = EnumerableItems.GetEnumerator();
        try
        {
            while (v159.MoveNext())
                v160++;
        }
        finally
        {
            v159.Dispose();
        }

        return v160;
    }

    int EnumerableCount3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v161;
        int v162;
        v162 = 0;
        v161 = EnumerableItems.GetEnumerator();
        try
        {
            while (v161.MoveNext())
            {
                if (!(v161.Current > 3))
                    continue;
                v162++;
            }
        }
        finally
        {
            v161.Dispose();
        }

        return v162;
    }

    int EnumerableCount5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v164;
        int v165;
        v165 = 0;
        v164 = 0;
        for (; v164 < ArrayItems.Length; v164++)
        {
            if (!(ArrayItems[v164] > 4))
                continue;
            if (!(ArrayItems[v164] % 2 == 0))
                continue;
            v165++;
        }

        return v165;
    }
}}