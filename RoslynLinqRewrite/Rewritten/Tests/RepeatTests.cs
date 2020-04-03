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
        int v1476;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1476 = 0;
        for (; v1476 < 100; v1476++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> Repeat2Rewritten_ProceduralLinq1()
    {
        int v1477;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1477 = 0;
        for (; v1477 < 100; v1477++)
            yield return -100;
    }

    System.Collections.Generic.IEnumerable<int> Repeat3Rewritten_ProceduralLinq1()
    {
        int v1478;
        if (-100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1478 = 0;
        for (; v1478 < -100; v1478++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> Repeat4Rewritten_ProceduralLinq1()
    {
        int v1479;
        if (23 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1479 = 0;
        for (; v1479 < 23; v1479++)
            yield return 123;
    }

    int[] RepeatToArrayRewritten_ProceduralLinq1()
    {
        int v1480;
        if (23 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int[] v1481;
        v1481 = new int[23];
        v1480 = 0;
        for (; v1480 < 23; v1480++)
            v1481[v1480] = 123;
        return v1481;
    }

    System.Collections.Generic.List<int> RepeatToListRewritten_ProceduralLinq1()
    {
        int v1482;
        if (23 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        System.Collections.Generic.List<int> v1483;
        v1483 = new System.Collections.Generic.List<int>();
        v1482 = 0;
        for (; v1482 < 23; v1482++)
            v1483.Add(123);
        return v1483;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RepeatToSimpleListRewritten_ProceduralLinq1()
    {
        int v1484;
        if (23 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int[] v1485;
        SimpleList<int> v1486;
        v1485 = new int[23];
        v1484 = 0;
        for (; v1484 < 23; v1484++)
            v1485[v1484] = 123;
        v1486 = new SimpleList<int>();
        v1486.Items = v1485;
        v1486.Count = 23;
        return v1486;
    }

    System.Collections.Generic.IEnumerable<int> RepeatDistinctRewritten_ProceduralLinq1()
    {
        int v1487;
        if (23 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        HashSet<int> v1488;
        v1488 = new HashSet<int>();
        v1487 = 0;
        for (; v1487 < 23; v1487++)
        {
            if (!(v1488.Add(123)))
                continue;
            yield return 123;
        }
    }
}}