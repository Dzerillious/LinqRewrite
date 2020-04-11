using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace TestsLibrary.Tests
{
public class RepeatTests
{
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(Repeat1), Repeat1, Repeat1Rewritten);
        TestsExtensions.TestEquals(nameof(Repeat2), Repeat2, Repeat2Rewritten);
        TestsExtensions.TestEquals(nameof(Repeat3), Repeat3, Repeat3Rewritten);
        TestsExtensions.TestEquals(nameof(Repeat4), Repeat4, Repeat4Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatToArray), RepeatToArray, RepeatToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatToList), RepeatToList, RepeatToListRewritten);
        TestsExtensions.TestEquals(nameof(RepeatToSimpleList), RepeatToSimpleList, RepeatToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(RepeatDistinct), RepeatDistinct, RepeatDistinctRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> Repeat1()
    {
        return Enumerable.Repeat(0, 100);
    } //EndMethod

    public IEnumerable<int> Repeat1Rewritten()
    {
        return Repeat1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> Repeat2()
    {
        return Enumerable.Repeat(-100, 100);
    } //EndMethod

    public IEnumerable<int> Repeat2Rewritten()
    {
        return Repeat2Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> Repeat3()
    {
        return Enumerable.Repeat(0, -100);
    } //EndMethod

    public IEnumerable<int> Repeat3Rewritten()
    {
        return Repeat3Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> Repeat4()
    {
        return Enumerable.Repeat(123, 23);
    } //EndMethod

    public IEnumerable<int> Repeat4Rewritten()
    {
        return Repeat4Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatToArray()
    {
        return Enumerable.Repeat(123, 23).ToArray();
    } //EndMethod

    public IEnumerable<int> RepeatToArrayRewritten()
    {
        return RepeatToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatToList()
    {
        return Enumerable.Repeat(123, 23).ToList();
    } //EndMethod

    public IEnumerable<int> RepeatToListRewritten()
    {
        return RepeatToListRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatToSimpleList()
    {
        return Enumerable.Repeat(123, 23).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> RepeatToSimpleListRewritten()
    {
        return RepeatToSimpleListRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatDistinct()
    {
        return Enumerable.Repeat(123, 23).Distinct();
    } //EndMethod

    public IEnumerable<int> RepeatDistinctRewritten()
    {
        return RepeatDistinctRewritten_ProceduralLinq1();
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> Repeat1Rewritten_ProceduralLinq1()
    {
        int v1588;
        v1588 = (0);
        for (; v1588 < (100); v1588 += 1)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> Repeat2Rewritten_ProceduralLinq1()
    {
        int v1589;
        v1589 = (0);
        for (; v1589 < (100); v1589 += 1)
            yield return (-100);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> Repeat3Rewritten_ProceduralLinq1()
    {
        throw new System.InvalidOperationException("Index out of range");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> Repeat4Rewritten_ProceduralLinq1()
    {
        int v1590;
        v1590 = (0);
        for (; v1590 < (23); v1590 += 1)
            yield return (123);
        yield break;
    }

    int[] RepeatToArrayRewritten_ProceduralLinq1()
    {
        int v1591;
        int[] v1592;
        v1592 = new int[(23)];
        v1591 = (0);
        for (; v1591 < (23); v1591 += 1)
            v1592[v1591] = (123);
        return v1592;
    }

    System.Collections.Generic.List<int> RepeatToListRewritten_ProceduralLinq1()
    {
        int v1593;
        System.Collections.Generic.List<int> v1594;
        v1594 = new System.Collections.Generic.List<int>();
        v1593 = (0);
        for (; v1593 < (23); v1593 += 1)
            v1594.Add((123));
        return v1594;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RepeatToSimpleListRewritten_ProceduralLinq1()
    {
        int v1595;
        int[] v1596;
        SimpleList<int> v1597;
        v1596 = new int[(23)];
        v1595 = (0);
        for (; v1595 < (23); v1595 += 1)
            v1596[v1595] = (123);
        v1597 = new SimpleList<int>();
        v1597.Items = v1596;
        v1597.Count = (23);
        return v1597;
    }

    System.Collections.Generic.IEnumerable<int> RepeatDistinctRewritten_ProceduralLinq1()
    {
        int v1598;
        HashSet<int> v1599;
        v1599 = new HashSet<int>();
        v1598 = (0);
        for (; v1598 < (23); v1598 += 1)
        {
            if (!(v1599.Add(((123)))))
                continue;
            yield return ((123));
        }

        yield break;
    }
}}