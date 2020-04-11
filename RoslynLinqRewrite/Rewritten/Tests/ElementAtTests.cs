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
        return (ArrayItems[23]);
    } //EndMethod

    [NoRewrite]
    public int ArraySelectElementAt()
    {
        return ArrayItems.Select(x => x + 20).ElementAt(23);
    } //EndMethod

    public int ArraySelectElementAtRewritten()
    {
        return 20 + ArrayItems[23];
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
        return (ArrayItems[a]);
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
        return (ArrayItems[20000]);
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

    int ArrayWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v571;
        int v572;
        v572 = 0;
        v571 = (0);
        for (; v571 < (ArrayItems.Length); v571 += 1)
        {
            if (!((((ArrayItems[v571])) > 30)))
                continue;
            if (v572 == 23)
                return ((ArrayItems[v571]));
            v572++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArraySelectWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v573;
        int v574;
        int v575;
        v575 = 0;
        v573 = (0);
        for (; v573 < (ArrayItems.Length); v573 += 1)
        {
            v574 = (30 + ArrayItems[v573]);
            if (!(((v574) > 30)))
                continue;
            if (v575 == 23)
                return (v574);
            v575++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int EnumerableElementAtRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v577;
        int v578;
        v577 = EnumerableItems.GetEnumerator();
        v578 = 0;
        try
        {
            while (v577.MoveNext())
            {
                if (v578 == 23)
                    return (v577.Current);
                v578++;
            }
        }
        finally
        {
            v577.Dispose();
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtWhereOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v580;
        int v581;
        v581 = 0;
        v580 = (0);
        for (; v580 < (ArrayItems.Length); v580 += 1)
        {
            if (!((((ArrayItems[v580])) > 10)))
                continue;
            if (v581 == 20000)
                return ((ArrayItems[v580]));
            v581++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }
}}