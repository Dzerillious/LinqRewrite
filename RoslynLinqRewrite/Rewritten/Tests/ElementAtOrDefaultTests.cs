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
        int v211;
        v211 = 0;
        for (; v211 < ArrayItems.Length; v211++)
            if (v211 == 23)
                return ArrayItems[v211];
        return default(int);
    }

    int ArraySelectElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v212;
        v212 = 0;
        for (; v212 < ArrayItems.Length; v212++)
            if (v212 == 23)
                return (ArrayItems[v212] + 20);
        return default(int);
    }

    int ArrayWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v213;
        int v214;
        v214 = 0;
        v213 = 0;
        for (; v213 < ArrayItems.Length; v213++)
        {
            if (!(ArrayItems[v213] > 30))
                continue;
            if (v214 == 23)
                return ArrayItems[v213];
            v214++;
        }

        return default(int);
    }

    int ArraySelectWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v215;
        int v216;
        int v217;
        v217 = 0;
        v215 = 0;
        for (; v215 < ArrayItems.Length; v215++)
        {
            v216 = (ArrayItems[v215] + 30);
            if (!(v216 > 30))
                continue;
            if (v217 == 23)
                return v216;
            v217++;
        }

        return default(int);
    }

    int ArrayElementAtOrDefaultParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v218;
        v218 = 0;
        for (; v218 < ArrayItems.Length; v218++)
            if (v218 == a)
                return ArrayItems[v218];
        return default(int);
    }

    int EnumerableElementAtOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v219;
        int v220;
        v220 = 0;
        v219 = EnumerableItems.GetEnumerator();
        try
        {
            while (v219.MoveNext())
            {
                if (v220 == 23)
                    return v219.Current;
                v220++;
            }
        }
        finally
        {
            v219.Dispose();
        }

        return default(int);
    }
}}