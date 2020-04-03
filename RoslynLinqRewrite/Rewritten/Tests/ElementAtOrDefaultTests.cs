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
        int v507;
        v507 = 0;
        for (; v507 < ArrayItems.Length; v507++)
            if (v507 == 23)
                return ArrayItems[v507];
        return default(int);
    }

    int ArraySelectElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v508;
        v508 = 0;
        for (; v508 < ArrayItems.Length; v508++)
            if (v508 == 23)
                return (ArrayItems[v508] + 20);
        return default(int);
    }

    int ArrayWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v509;
        int v510;
        v510 = 0;
        v509 = 0;
        for (; v509 < ArrayItems.Length; v509++)
        {
            if (!((ArrayItems[v509] > 30)))
                continue;
            if (v510 == 23)
                return ArrayItems[v509];
            v510++;
        }

        return default(int);
    }

    int ArraySelectWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v511;
        int v512;
        int v513;
        v513 = 0;
        v511 = 0;
        for (; v511 < ArrayItems.Length; v511++)
        {
            v512 = (ArrayItems[v511] + 30);
            if (!((v512 > 30)))
                continue;
            if (v513 == 23)
                return v512;
            v513++;
        }

        return default(int);
    }

    int ArrayElementAtOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v514;
        v514 = 0;
        for (; v514 < ArrayItems.Length; v514++)
            if (v514 == a)
                return ArrayItems[v514];
        return default(int);
    }

    int EnumerableElementAtOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v515;
        int v516;
        v515 = EnumerableItems.GetEnumerator();
        v516 = 0;
        try
        {
            while (v515.MoveNext())
            {
                if (v516 == 23)
                    return v515.Current;
                v516++;
            }
        }
        finally
        {
            v515.Dispose();
        }

        return default(int);
    }

    int ArrayElementAtOrDefaultOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v517;
        v517 = 0;
        for (; v517 < ArrayItems.Length; v517++)
            if (v517 == 20000)
                return ArrayItems[v517];
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtOrDefaultWhereOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v518;
        int v519;
        v519 = 0;
        v518 = 0;
        for (; v518 < ArrayItems.Length; v518++)
        {
            if (!((ArrayItems[v518] > 10)))
                continue;
            if (v519 == 20000)
                return ArrayItems[v518];
            v519++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }
}}