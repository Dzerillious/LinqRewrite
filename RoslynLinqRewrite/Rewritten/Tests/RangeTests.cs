using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace TestsLibrary.Tests
{
public class RangeTests
{
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(Range1), Range1, Range1Rewritten);
        TestsExtensions.TestEquals(nameof(Range2), Range2, Range2Rewritten);
        TestsExtensions.TestEquals(nameof(Range3), Range3, Range3Rewritten);
        TestsExtensions.TestEquals(nameof(Range4), Range4, Range4Rewritten);
        TestsExtensions.TestEquals(nameof(RangeToArray), RangeToArray, RangeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeToList), RangeToList, RangeToListRewritten);
        TestsExtensions.TestEquals(nameof(RangeToSimpleList), RangeToSimpleList, RangeToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(RangeDistinct), RangeDistinct, RangeDistinctRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> Range1()
    {
        return Enumerable.Range(0, 100);
    } //EndMethod

    public IEnumerable<int> Range1Rewritten()
    {
        return Range1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> Range2()
    {
        return Enumerable.Range(-100, 100);
    } //EndMethod

    public IEnumerable<int> Range2Rewritten()
    {
        return Range2Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> Range3()
    {
        return Enumerable.Range(0, -100);
    } //EndMethod

    public IEnumerable<int> Range3Rewritten()
    {
        return Range3Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> Range4()
    {
        return Enumerable.Range(123, 23);
    } //EndMethod

    public IEnumerable<int> Range4Rewritten()
    {
        return Range4Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeToArray()
    {
        return Enumerable.Range(123, 23).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeToArrayRewritten()
    {
        return RangeToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeToList()
    {
        return Enumerable.Range(123, 23).ToList();
    } //EndMethod

    public IEnumerable<int> RangeToListRewritten()
    {
        return RangeToListRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeToSimpleList()
    {
        return Enumerable.Range(123, 23).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> RangeToSimpleListRewritten()
    {
        return RangeToSimpleListRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeDistinct()
    {
        return Enumerable.Range(123, 23).Distinct();
    } //EndMethod

    public IEnumerable<int> RangeDistinctRewritten()
    {
        return RangeDistinctRewritten_ProceduralLinq1();
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> Range1Rewritten_ProceduralLinq1()
    {
        int v1462;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1462 = 0;
        for (; v1462 < 100; v1462++)
            yield return (v1462 + 0);
    }

    System.Collections.Generic.IEnumerable<int> Range2Rewritten_ProceduralLinq1()
    {
        int v1463;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1463 = 0;
        for (; v1463 < 100; v1463++)
            yield return (v1463 + -100);
    }

    System.Collections.Generic.IEnumerable<int> Range3Rewritten_ProceduralLinq1()
    {
        int v1464;
        if (-100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1464 = 0;
        for (; v1464 < -100; v1464++)
            yield return (v1464 + 0);
    }

    System.Collections.Generic.IEnumerable<int> Range4Rewritten_ProceduralLinq1()
    {
        int v1465;
        if (23 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1465 = 0;
        for (; v1465 < 23; v1465++)
            yield return (v1465 + 123);
    }

    int[] RangeToArrayRewritten_ProceduralLinq1()
    {
        int v1466;
        if (23 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int[] v1467;
        v1467 = new int[23];
        v1466 = 0;
        for (; v1466 < 23; v1466++)
            v1467[v1466] = (v1466 + 123);
        return v1467;
    }

    System.Collections.Generic.List<int> RangeToListRewritten_ProceduralLinq1()
    {
        int v1468;
        if (23 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        System.Collections.Generic.List<int> v1469;
        v1469 = new System.Collections.Generic.List<int>();
        v1468 = 0;
        for (; v1468 < 23; v1468++)
            v1469.Add((v1468 + 123));
        return v1469;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RangeToSimpleListRewritten_ProceduralLinq1()
    {
        int v1470;
        if (23 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int[] v1471;
        SimpleList<int> v1472;
        v1471 = new int[23];
        v1470 = 0;
        for (; v1470 < 23; v1470++)
            v1471[v1470] = (v1470 + 123);
        v1472 = new SimpleList<int>();
        v1472.Items = v1471;
        v1472.Count = 23;
        return v1472;
    }

    System.Collections.Generic.IEnumerable<int> RangeDistinctRewritten_ProceduralLinq1()
    {
        int v1473;
        if (23 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        HashSet<int> v1474;
        int v1475;
        v1474 = new HashSet<int>();
        v1473 = 0;
        for (; v1473 < 23; v1473++)
        {
            v1475 = (v1473 + 123);
            if (!(v1474.Add(v1475)))
                continue;
            yield return v1475;
        }
    }
}}