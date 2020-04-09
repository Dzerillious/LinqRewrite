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
        return (ArrayItems.Length) <= 23 ? ArrayItems[23] : default(int);
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
        return (ArrayItems.Length) <= a ? ArrayItems[a] : default(int);
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
        return ArrayItems[20000];
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
        int v609;
        int v610;
        int v611;
        v611 = 0;
        v609 = (0);
        for (; v609 < (ArrayItems.Length); v609++)
        {
            v610 = (ArrayItems[v609]);
            if (!(((v610) > 30)))
                continue;
            if (v611 == 23)
                return (v610);
            v611++;
        }

        return default(int);
    }

    int ArraySelectWhereElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v612;
        int v613;
        int v614;
        v614 = 0;
        v612 = (0);
        for (; v612 < (ArrayItems.Length); v612++)
        {
            v613 = (30 + ArrayItems[v612]);
            if (!(((v613) > 30)))
                continue;
            if (v614 == 23)
                return (v613);
            v614++;
        }

        return default(int);
    }

    int EnumerableElementAtOrDefaultRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v616;
        int v617;
        v616 = EnumerableItems.GetEnumerator();
        v617 = 0;
        try
        {
            while (v616.MoveNext())
            {
                if (v617 == 23)
                    return (v616.Current);
                v617++;
            }
        }
        finally
        {
            v616.Dispose();
        }

        return default(int);
    }

    int ArrayElementAtOrDefaultWhereOutRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v619;
        int v620;
        int v621;
        v621 = 0;
        v619 = (0);
        for (; v619 < (ArrayItems.Length); v619++)
        {
            v620 = (ArrayItems[v619]);
            if (!(((v620) > 10)))
                continue;
            if (v621 == 20000)
                return (v620);
            v621++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }
}}