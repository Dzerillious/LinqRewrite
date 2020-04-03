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
        int v1433;
        v1433 = 0;
        for (; v1433 < 100; v1433++)
            yield return (v1433 + 0);
    }

    System.Collections.Generic.IEnumerable<int> Range2Rewritten_ProceduralLinq1()
    {
        int v1434;
        v1434 = 0;
        for (; v1434 < 100; v1434++)
            yield return (v1434 + -100);
    }

    System.Collections.Generic.IEnumerable<int> Range3Rewritten_ProceduralLinq1()
    {
        throw new System.InvalidOperationException("Index out of range");
    }

    System.Collections.Generic.IEnumerable<int> Range4Rewritten_ProceduralLinq1()
    {
        int v1435;
        v1435 = 0;
        for (; v1435 < 23; v1435++)
            yield return (v1435 + 123);
    }

    int[] RangeToArrayRewritten_ProceduralLinq1()
    {
        int v1436;
        int[] v1437;
        v1437 = new int[23];
        v1436 = 0;
        for (; v1436 < 23; v1436++)
            v1437[v1436] = (v1436 + 123);
        return v1437;
    }

    System.Collections.Generic.List<int> RangeToListRewritten_ProceduralLinq1()
    {
        int v1438;
        System.Collections.Generic.List<int> v1439;
        v1439 = new System.Collections.Generic.List<int>();
        v1438 = 0;
        for (; v1438 < 23; v1438++)
            v1439.Add((v1438 + 123));
        return v1439;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RangeToSimpleListRewritten_ProceduralLinq1()
    {
        int v1440;
        int[] v1441;
        SimpleList<int> v1442;
        v1441 = new int[23];
        v1440 = 0;
        for (; v1440 < 23; v1440++)
            v1441[v1440] = (v1440 + 123);
        v1442 = new SimpleList<int>();
        v1442.Items = v1441;
        v1442.Count = 23;
        return v1442;
    }

    System.Collections.Generic.IEnumerable<int> RangeDistinctRewritten_ProceduralLinq1()
    {
        int v1443;
        HashSet<int> v1444;
        int v1445;
        v1444 = new HashSet<int>();
        v1443 = 0;
        for (; v1443 < 23; v1443++)
        {
            v1445 = (v1443 + 123);
            if (!(v1444.Add(v1445)))
                continue;
            yield return v1445;
        }
    }
}}