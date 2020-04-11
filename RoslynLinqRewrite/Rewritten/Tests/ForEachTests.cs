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
        int v967;
        v967 = (0);
        for (; v967 < (ArrayItems.Length); v967 += 1)
            _ = 3;
    }

    void EnumerableForEachRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v968;
        v968 = EnumerableItems.GetEnumerator();
        try
        {
            while (v968.MoveNext())
                _ = 3;
        }
        finally
        {
            v968.Dispose();
        }
    }

    void NullForEachRewritten_ProceduralLinq1(int[] NullItems)
    {
        int v970;
        v970 = (0);
        for (; v970 < (NullItems.Length); v970 += 1)
            _ = 3;
    }

    void NullableForEachRewritten_ProceduralLinq1(int[] NullItems)
    {
        int v972;
        if (NullItems == null)
            return;
        v972 = (0);
        for (; v972 < (NullItems.Length); v972 += 1)
            _ = 3;
    }

    void ArrayChangingParamsForEachRewritten_ProceduralLinq1(ref int a, int[] NullItems)
    {
        int v973;
        v973 = (0);
        for (; v973 < (NullItems.Length); v973 += 1)
            a++;
    }
}}