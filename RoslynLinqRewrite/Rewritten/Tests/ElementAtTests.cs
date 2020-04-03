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
        int v506;
        v506 = 0;
        for (; v506 < ArrayItems.Length; v506++)
            if (v506 == 23)
                return ArrayItems[v506];
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArraySelectElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v507;
        v507 = 0;
        for (; v507 < ArrayItems.Length; v507++)
            if (v507 == 23)
                return (ArrayItems[v507] + 20);
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v508;
        int v509;
        v509 = 0;
        v508 = 0;
        for (; v508 < ArrayItems.Length; v508++)
        {
            if (!((ArrayItems[v508] > 30)))
                continue;
            if (v509 == 23)
                return ArrayItems[v508];
            v509++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArraySelectWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v510;
        int v511;
        int v512;
        v512 = 0;
        v510 = 0;
        for (; v510 < ArrayItems.Length; v510++)
        {
            v511 = (ArrayItems[v510] + 30);
            if (!((v511 > 30)))
                continue;
            if (v512 == 23)
                return v511;
            v512++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v513;
        if (a < 0)
            throw new System.InvalidOperationException("Index out of range");
        v513 = 0;
        for (; v513 < ArrayItems.Length; v513++)
            if (v513 == a)
                return ArrayItems[v513];
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int EnumerableElementAtRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v514;
        int v515;
        v514 = EnumerableItems.GetEnumerator();
        v515 = 0;
        try
        {
            while (v514.MoveNext())
            {
                if (v515 == 23)
                    return v514.Current;
                v515++;
            }
        }
        finally
        {
            v514.Dispose();
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v516;
        v516 = 0;
        for (; v516 < ArrayItems.Length; v516++)
            if (v516 == 20000)
                return ArrayItems[v516];
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtWhereOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v517;
        int v518;
        v518 = 0;
        v517 = 0;
        for (; v517 < ArrayItems.Length; v517++)
        {
            if (!((ArrayItems[v517] > 10)))
                continue;
            if (v518 == 20000)
                return ArrayItems[v517];
            v518++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }
}}