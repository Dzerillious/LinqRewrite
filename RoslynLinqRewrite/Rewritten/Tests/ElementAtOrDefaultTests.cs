using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ElementAtOrDefaultOrDefaultTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayElementAtOrDefault), ArrayElementAtOrDefault, ArrayElementAtOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectElementAtOrDefault), ArraySelectElementAtOrDefault, ArraySelectElementAtOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereElementAtOrDefault), ArrayWhereElementAtOrDefault, ArrayWhereElementAtOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectWhereElementAtOrDefault), ArraySelectWhereElementAtOrDefault, ArraySelectWhereElementAtOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayElementAtOrDefaultParam), ArrayElementAtOrDefaultParam, ArrayElementAtOrDefaultParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableElementAtOrDefault), EnumerableElementAtOrDefault, EnumerableElementAtOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayElementAtOrDefaultOut), ArrayElementAtOrDefaultOut, ArrayElementAtOrDefaultOutRewritten);
        TestsExtensions.TestEquals(nameof(ArrayElementAtOrDefaultWhereOut), ArrayElementAtOrDefaultWhereOut, ArrayElementAtOrDefaultWhereOutRewritten);
    }

    [NoRewrite]
    public int ArrayElementAtOrDefault()
    {
        return ArrayItems.ElementAtOrDefault(23);
    } //EndMethod

    public int ArrayElementAtOrDefaultRewritten()
    {
        return ArrayElementAtOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySelectElementAtOrDefault()
    {
        return ArrayItems.Select(x => x + 20).ElementAtOrDefault(23);
    } //EndMethod

    public int ArraySelectElementAtOrDefaultRewritten()
    {
        return ArraySelectElementAtOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayWhereElementAtOrDefault()
    {
        return ArrayItems.Where(x => x > 30).ElementAtOrDefault(23);
    } //EndMethod

    public int ArrayWhereElementAtOrDefaultRewritten()
    {
        return ArrayWhereElementAtOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySelectWhereElementAtOrDefault()
    {
        return ArrayItems.Select(x => x + 30).Where(x => x > 30).ElementAtOrDefault(23);
    } //EndMethod

    public int ArraySelectWhereElementAtOrDefaultRewritten()
    {
        return ArraySelectWhereElementAtOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayElementAtOrDefaultParam()
    {
        var a = 23;
        return ArrayItems.ElementAtOrDefault(a);
    } //EndMethod

    public int ArrayElementAtOrDefaultParamRewritten()
    {
        var a = 23;
        return ArrayElementAtOrDefaultParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int EnumerableElementAtOrDefault()
    {
        return EnumerableItems.ElementAtOrDefault(23);
    } //EndMethod

    public int EnumerableElementAtOrDefaultRewritten()
    {
        return EnumerableElementAtOrDefaultRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayElementAtOrDefaultOut()
    {
        return ArrayItems.ElementAt(20000);
    } //EndMethod

    public int ArrayElementAtOrDefaultOutRewritten()
    {
        return ArrayElementAtOrDefaultOutRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayElementAtOrDefaultWhereOut()
    {
        return ArrayItems.Where(x => x > 10).ElementAt(20000);
    } //EndMethod

    public int ArrayElementAtOrDefaultWhereOutRewritten()
    {
        return ArrayElementAtOrDefaultWhereOutRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int ArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v493;
        v493 = 0;
        for (; v493 < ArrayItems.Length; v493++)
            if (v493 == 23)
                return ArrayItems[v493];
        return default(int);
    }

    int ArraySelectElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v494;
        v494 = 0;
        for (; v494 < ArrayItems.Length; v494++)
            if (v494 == 23)
                return (ArrayItems[v494] + 20);
        return default(int);
    }

    int ArrayWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v495;
        int v496;
        v496 = 0;
        v495 = 0;
        for (; v495 < ArrayItems.Length; v495++)
        {
            if (!((ArrayItems[v495] > 30)))
                continue;
            if (v496 == 23)
                return ArrayItems[v495];
            v496++;
        }

        return default(int);
    }

    int ArraySelectWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v497;
        int v498;
        int v499;
        v499 = 0;
        v497 = 0;
        for (; v497 < ArrayItems.Length; v497++)
        {
            v498 = (ArrayItems[v497] + 30);
            if (!((v498 > 30)))
                continue;
            if (v499 == 23)
                return v498;
            v499++;
        }

        return default(int);
    }

    int ArrayElementAtOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v500;
        v500 = 0;
        for (; v500 < ArrayItems.Length; v500++)
            if (v500 == a)
                return ArrayItems[v500];
        return default(int);
    }

    int EnumerableElementAtOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v501;
        int v502;
        v501 = EnumerableItems.GetEnumerator();
        v502 = 0;
        try
        {
            while (v501.MoveNext())
            {
                if (v502 == 23)
                    return v501.Current;
                v502++;
            }
        }
        finally
        {
            v501.Dispose();
        }

        return default(int);
    }

    int ArrayElementAtOrDefaultOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v503;
        v503 = 0;
        for (; v503 < ArrayItems.Length; v503++)
            if (v503 == 20000)
                return ArrayItems[v503];
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtOrDefaultWhereOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v504;
        int v505;
        v505 = 0;
        v504 = 0;
        for (; v504 < ArrayItems.Length; v504++)
        {
            if (!((ArrayItems[v504] > 10)))
                continue;
            if (v505 == 20000)
                return ArrayItems[v504];
            v505++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }
}}