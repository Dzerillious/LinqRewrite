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
        ArrayElementAt().TestEquals(nameof(ArrayElementAt), ArrayElementAtRewritten());
        ArraySelectElementAt().TestEquals(nameof(ArraySelectElementAt), ArraySelectElementAtRewritten());
        ArrayWhereElementAt().TestEquals(nameof(ArrayWhereElementAt), ArrayWhereElementAtRewritten());
        ArraySelectWhereElementAt().TestEquals(nameof(ArraySelectWhereElementAt), ArraySelectWhereElementAtRewritten());
        ArrayElementAtParam().TestEquals(nameof(ArrayElementAtParam), ArrayElementAtParamRewritten());
        EnumerableElementAt().TestEquals(nameof(EnumerableElementAt), EnumerableElementAtRewritten());
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

    int ArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v185;
        v185 = 0;
        for (; v185 < ArrayItems.Length; v185++)
            if (v185 == 23)
                return ArrayItems[v185];
        throw new System.InvalidOperationException("The sequence did not enough elements.");
    }

    int ArraySelectElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v186;
        v186 = 0;
        for (; v186 < ArrayItems.Length; v186++)
            if (v186 == 23)
                return (ArrayItems[v186] + 20);
        throw new System.InvalidOperationException("The sequence did not enough elements.");
    }

    int ArrayWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v187;
        int v188;
        v188 = 0;
        v187 = 0;
        for (; v187 < ArrayItems.Length; v187++)
        {
            if (!(ArrayItems[v187] > 30))
                continue;
            if (v188 == 23)
                return ArrayItems[v187];
            v188++;
        }

        throw new System.InvalidOperationException("The sequence did not enough elements.");
    }

    int ArraySelectWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v189;
        int v190;
        int v191;
        v191 = 0;
        v189 = 0;
        for (; v189 < ArrayItems.Length; v189++)
        {
            v190 = (ArrayItems[v189] + 30);
            if (!(v190 > 30))
                continue;
            if (v191 == 23)
                return v190;
            v191++;
        }

        throw new System.InvalidOperationException("The sequence did not enough elements.");
    }

    int ArrayElementAtParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v192;
        v192 = 0;
        for (; v192 < ArrayItems.Length; v192++)
            if (v192 == a)
                return ArrayItems[v192];
        throw new System.InvalidOperationException("The sequence did not enough elements.");
    }

    int EnumerableElementAtRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v193;
        int v194;
        v194 = 0;
        v193 = EnumerableItems.GetEnumerator();
        try
        {
            while (v193.MoveNext())
            {
                if (v194 == 23)
                    return v193.Current;
                v194++;
            }
        }
        finally
        {
            v193.Dispose();
        }

        throw new System.InvalidOperationException("The sequence did not enough elements.");
    }
}}