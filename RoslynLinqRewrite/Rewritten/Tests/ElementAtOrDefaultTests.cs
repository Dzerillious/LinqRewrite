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
        return (ArrayItems.Length) <= 23 ? (ArrayItems[23]) : default(int);
    } //EndMethod

    [NoRewrite]
    public int ArraySelectElementAtOrDefault()
    {
        return ArrayItems.Select(x => x + 20).ElementAtOrDefault(23);
    } //EndMethod

    public int ArraySelectElementAtOrDefaultRewritten()
    {
        return (ArrayItems.Length) <= 23 ? 20 + ArrayItems[23] : default(int);
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
        return (ArrayItems.Length) <= a ? (ArrayItems[a]) : default(int);
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
        return (ArrayItems[20000]);
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

    int ArrayWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v558;
        int v559;
        v559 = 0;
        v558 = (0);
        for (; v558 < (ArrayItems.Length); v558 += 1)
        {
            if (!((((ArrayItems[v558])) > 30)))
                continue;
            if (v559 == 23)
                return ((ArrayItems[v558]));
            v559++;
        }

        return default(int);
    }

    int ArraySelectWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v560;
        int v561;
        int v562;
        v562 = 0;
        v560 = (0);
        for (; v560 < (ArrayItems.Length); v560 += 1)
        {
            v561 = (30 + ArrayItems[v560]);
            if (!(((v561) > 30)))
                continue;
            if (v562 == 23)
                return (v561);
            v562++;
        }

        return default(int);
    }

    int EnumerableElementAtOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v564;
        int v565;
        v564 = EnumerableItems.GetEnumerator();
        v565 = 0;
        try
        {
            while (v564.MoveNext())
            {
                if (v565 == 23)
                    return (v564.Current);
                v565++;
            }
        }
        finally
        {
            v564.Dispose();
        }

        return default(int);
    }

    int ArrayElementAtOrDefaultWhereOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v567;
        int v568;
        v568 = 0;
        v567 = (0);
        for (; v567 < (ArrayItems.Length); v567 += 1)
        {
            if (!((((ArrayItems[v567])) > 10)))
                continue;
            if (v568 == 20000)
                return ((ArrayItems[v567]));
            v568++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }
}}