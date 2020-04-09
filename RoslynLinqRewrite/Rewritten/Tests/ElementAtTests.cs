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
        return ArrayItems[23];
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
        return ArrayItems[a];
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
        return ArrayItems[20000];
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
        int v624;
        int v625;
        int v626;
        v626 = 0;
        v624 = (0);
        for (; v624 < (ArrayItems.Length); v624++)
        {
            v625 = (ArrayItems[v624]);
            if (!(((v625) > 30)))
                continue;
            if (v626 == 23)
                return (v625);
            v626++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArraySelectWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v627;
        int v628;
        int v629;
        v629 = 0;
        v627 = (0);
        for (; v627 < (ArrayItems.Length); v627++)
        {
            v628 = (30 + ArrayItems[v627]);
            if (!(((v628) > 30)))
                continue;
            if (v629 == 23)
                return (v628);
            v629++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int EnumerableElementAtRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v631;
        int v632;
        v631 = EnumerableItems.GetEnumerator();
        v632 = 0;
        try
        {
            while (v631.MoveNext())
            {
                if (v632 == 23)
                    return (v631.Current);
                v632++;
            }
        }
        finally
        {
            v631.Dispose();
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtWhereOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v634;
        int v635;
        int v636;
        v636 = 0;
        v634 = (0);
        for (; v634 < (ArrayItems.Length); v634++)
        {
            v635 = (ArrayItems[v634]);
            if (!(((v635) > 10)))
                continue;
            if (v636 == 20000)
                return (v635);
            v636++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }
}}