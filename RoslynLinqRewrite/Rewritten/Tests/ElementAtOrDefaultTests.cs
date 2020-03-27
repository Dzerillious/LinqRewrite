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
        ArrayElementAtOrDefault().TestEquals(nameof(ArrayElementAtOrDefault), ArrayElementAtOrDefaultRewritten());
        ArraySelectElementAtOrDefault().TestEquals(nameof(ArraySelectElementAtOrDefault), ArraySelectElementAtOrDefaultRewritten());
        ArrayWhereElementAtOrDefault().TestEquals(nameof(ArrayWhereElementAtOrDefault), ArrayWhereElementAtOrDefaultRewritten());
        ArraySelectWhereElementAtOrDefault().TestEquals(nameof(ArraySelectWhereElementAtOrDefault), ArraySelectWhereElementAtOrDefaultRewritten());
        ArrayElementAtOrDefaultParam().TestEquals(nameof(ArrayElementAtOrDefaultParam), ArrayElementAtOrDefaultParamRewritten());
        EnumerableElementAtOrDefault().TestEquals(nameof(EnumerableElementAtOrDefault), EnumerableElementAtOrDefaultRewritten());
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

    int ArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v175;
        v175 = 0;
        for (; v175 < ArrayItems.Length; v175++)
            if (v175 == 23)
                return ArrayItems[v175];
        return default(int);
    }

    int ArraySelectElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v176;
        v176 = 0;
        for (; v176 < ArrayItems.Length; v176++)
            if (v176 == 23)
                return (ArrayItems[v176] + 20);
        return default(int);
    }

    int ArrayWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v177;
        int v178;
        v178 = 0;
        v177 = 0;
        for (; v177 < ArrayItems.Length; v177++)
        {
            if (!(ArrayItems[v177] > 30))
                continue;
            if (v178 == 23)
                return ArrayItems[v177];
            v178++;
        }

        return default(int);
    }

    int ArraySelectWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v179;
        int v180;
        int v181;
        v181 = 0;
        v179 = 0;
        for (; v179 < ArrayItems.Length; v179++)
        {
            v180 = (ArrayItems[v179] + 30);
            if (!(v180 > 30))
                continue;
            if (v181 == 23)
                return v180;
            v181++;
        }

        return default(int);
    }

    int ArrayElementAtOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v182;
        v182 = 0;
        for (; v182 < ArrayItems.Length; v182++)
            if (v182 == a)
                return ArrayItems[v182];
        return default(int);
    }

    int EnumerableElementAtOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v183;
        int v184;
        v184 = 0;
        v183 = EnumerableItems.GetEnumerator();
        try
        {
            while (v183.MoveNext())
            {
                if (v184 == 23)
                    return v183.Current;
                v184++;
            }
        }
        finally
        {
            v183.Dispose();
        }

        return default(int);
    }
}}