using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ForEachTests
{
    [Datapoints]
    private int[] NullItems = null;
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayForEach), ArrayForEach, ArrayForEachRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableForEach), EnumerableForEach, EnumerableForEachRewritten);
        TestsExtensions.TestEquals(nameof(NullForEach), NullForEach, NullForEachRewritten);
        TestsExtensions.TestEquals(nameof(NullableForEach), NullableForEach, NullableForEachRewritten);
        TestsExtensions.TestEquals(nameof(ArrayChangingParamsForEach), ArrayChangingParamsForEach, ArrayChangingParamsForEachRewritten);
    }

    [NoRewrite]
    public int ArrayForEach()
    {
        ArrayItems.ForEach(x => _ = 3);
        return 0;
    } //EndMethod

    public int ArrayForEachRewritten()
    {
        ArrayForEachRewritten_ProceduralLinq1(ArrayItems);
        return 0;
    } //EndMethod

    [NoRewrite]
    public int EnumerableForEach()
    {
        EnumerableItems.ForEach(x => _ = 3);
        return 0;
    } //EndMethod

    public int EnumerableForEachRewritten()
    {
        EnumerableForEachRewritten_ProceduralLinq1(EnumerableItems);
        return 0;
    } //EndMethod

    [NoRewrite]
    public int NullForEach()
    {
        NullItems.ForEach(x => _ = 3);
        return 0;
    } //EndMethod

    public int NullForEachRewritten()
    {
        NullForEachRewritten_ProceduralLinq1(NullItems);
        return 0;
    } //EndMethod

    [NoRewrite]
    public int NullableForEach()
    {
        NullItems?.ForEach(x => _ = 3);
        return 0;
    } //EndMethod

    public int NullableForEachRewritten()
    {
        NullableForEachRewritten_ProceduralLinq1(NullItems);
        return 0;
    } //EndMethod

    [NoRewrite]
    public int ArrayChangingParamsForEach()
    {
        var a = 0;
        NullItems.ForEach(x => a++);
        return a;
    } //EndMethod

    public int ArrayChangingParamsForEachRewritten()
    {
        var a = 0;
        ArrayChangingParamsForEachRewritten_ProceduralLinq1(ref a, NullItems);
        return a;
    } //EndMethod

    void ArrayForEachRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1083;
        v1083 = (0);
        for (; v1083 < (ArrayItems.Length); v1083++)
            _ = 3;
    }

    void EnumerableForEachRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1084;
        v1084 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1084.MoveNext())
                _ = 3;
        }
        finally
        {
            v1084.Dispose();
        }
    }

    void NullForEachRewritten_ProceduralLinq1(int[] NullItems)
    {
        int v1086;
        v1086 = (0);
        for (; v1086 < (NullItems.Length); v1086++)
            _ = 3;
    }

    void NullableForEachRewritten_ProceduralLinq1(int[] NullItems)
    {
        int v1088;
        if (NullItems == null)
            return;
        v1088 = (0);
        for (; v1088 < (NullItems.Length); v1088++)
            _ = 3;
    }

    void ArrayChangingParamsForEachRewritten_ProceduralLinq1(ref int a, int[] NullItems)
    {
        int v1089;
        v1089 = (0);
        for (; v1089 < (NullItems.Length); v1089++)
            a++;
    }
}}