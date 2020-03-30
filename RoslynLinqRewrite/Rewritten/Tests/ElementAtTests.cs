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
        int v221;
        v221 = 0;
        for (; v221 < ArrayItems.Length; v221++)
            if (v221 == 23)
                return ArrayItems[v221];
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArraySelectElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v222;
        v222 = 0;
        for (; v222 < ArrayItems.Length; v222++)
            if (v222 == 23)
                return (ArrayItems[v222] + 20);
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v223;
        int v224;
        v224 = 0;
        v223 = 0;
        for (; v223 < ArrayItems.Length; v223++)
        {
            if (!(ArrayItems[v223] > 30))
                continue;
            if (v224 == 23)
                return ArrayItems[v223];
            v224++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArraySelectWhereElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v225;
        int v226;
        int v227;
        v227 = 0;
        v225 = 0;
        for (; v225 < ArrayItems.Length; v225++)
        {
            v226 = (ArrayItems[v225] + 30);
            if (!(v226 > 30))
                continue;
            if (v227 == 23)
                return v226;
            v227++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayElementAtParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v228;
        v228 = 0;
        for (; v228 < ArrayItems.Length; v228++)
            if (v228 == a)
                return ArrayItems[v228];
        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int EnumerableElementAtRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v229;
        int v230;
        v230 = 0;
        v229 = EnumerableItems.GetEnumerator();
        try
        {
            while (v229.MoveNext())
            {
                if (v230 == 23)
                    return v229.Current;
                v230++;
            }
        }
        finally
        {
            v229.Dispose();
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }
}}