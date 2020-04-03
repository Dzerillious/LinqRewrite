using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ElementAtTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayElementAt), ArrayElementAt, ArrayElementAtRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectElementAt), ArraySelectElementAt, ArraySelectElementAtRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereElementAt), ArrayWhereElementAt, ArrayWhereElementAtRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectWhereElementAt), ArraySelectWhereElementAt, ArraySelectWhereElementAtRewritten);
        TestsExtensions.TestEquals(nameof(ArrayElementAtParam), ArrayElementAtParam, ArrayElementAtParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableElementAt), EnumerableElementAt, EnumerableElementAtRewritten);
        TestsExtensions.TestEquals(nameof(ArrayElementAtOut), ArrayElementAtOut, ArrayElementAtOutRewritten);
        TestsExtensions.TestEquals(nameof(ArrayElementAtWhereOut), ArrayElementAtWhereOut, ArrayElementAtWhereOutRewritten);
    }

    [NoRewrite]
    public int ArrayElementAt()
    {
        return ArrayItems.ElementAt(23);
    } //EndMethod

    public int ArrayElementAtRewritten()
    {
        return ArrayElementAtRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySelectElementAt()
    {
        return ArrayItems.Select(x => x + 20).ElementAt(23);
    } //EndMethod

    public int ArraySelectElementAtRewritten()
    {
        return ArraySelectElementAtRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayWhereElementAt()
    {
        return ArrayItems.Where(x => x > 30).ElementAt(23);
    } //EndMethod

    public int ArrayWhereElementAtRewritten()
    {
        return ArrayWhereElementAtRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArraySelectWhereElementAt()
    {
        return ArrayItems.Select(x => x + 30).Where(x => x > 30).ElementAt(23);
    } //EndMethod

    public int ArraySelectWhereElementAtRewritten()
    {
        return ArraySelectWhereElementAtRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayElementAtParam()
    {
        var a = 23;
        return ArrayItems.ElementAt(a);
    } //EndMethod

    public int ArrayElementAtParamRewritten()
    {
        var a = 23;
        return ArrayElementAtParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int EnumerableElementAt()
    {
        return EnumerableItems.ElementAt(23);
    } //EndMethod

    public int EnumerableElementAtRewritten()
    {
        return EnumerableElementAtRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayElementAtOut()
    {
        return ArrayItems.ElementAt(20000);
    } //EndMethod

    public int ArrayElementAtOutRewritten()
    {
        return ArrayElementAtOutRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayElementAtWhereOut()
    {
        return ArrayItems.Where(x => x > 10).ElementAt(20000);
    } //EndMethod

    public int ArrayElementAtWhereOutRewritten()
    {
        return ArrayElementAtWhereOutRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int ArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v520;
        v520 = 0;
        for (; v520 < ArrayItems.Length; v520++)
            if (v520 == 23)
                return ArrayItems[v520];
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArraySelectElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v521;
        v521 = 0;
        for (; v521 < ArrayItems.Length; v521++)
            if (v521 == 23)
                return (ArrayItems[v521] + 20);
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v522;
        int v523;
        v523 = 0;
        v522 = 0;
        for (; v522 < ArrayItems.Length; v522++)
        {
            if (!((ArrayItems[v522] > 30)))
                continue;
            if (v523 == 23)
                return ArrayItems[v522];
            v523++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArraySelectWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v524;
        int v525;
        int v526;
        v526 = 0;
        v524 = 0;
        for (; v524 < ArrayItems.Length; v524++)
        {
            v525 = (ArrayItems[v524] + 30);
            if (!((v525 > 30)))
                continue;
            if (v526 == 23)
                return v525;
            v526++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v527;
        v527 = 0;
        for (; v527 < ArrayItems.Length; v527++)
            if (v527 == a)
                return ArrayItems[v527];
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int EnumerableElementAtRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v528;
        int v529;
        v528 = EnumerableItems.GetEnumerator();
        v529 = 0;
        try
        {
            while (v528.MoveNext())
            {
                if (v529 == 23)
                    return v528.Current;
                v529++;
            }
        }
        finally
        {
            v528.Dispose();
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v530;
        v530 = 0;
        for (; v530 < ArrayItems.Length; v530++)
            if (v530 == 20000)
                return ArrayItems[v530];
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtWhereOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v531;
        int v532;
        v532 = 0;
        v531 = 0;
        for (; v531 < ArrayItems.Length; v531++)
        {
            if (!((ArrayItems[v531] > 10)))
                continue;
            if (v532 == 20000)
                return ArrayItems[v531];
            v532++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }
}}