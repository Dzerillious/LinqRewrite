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
        int v1575;
        v1575 = (0);
        for (; v1575 < (100); v1575 += (1))
            yield return (v1575);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> Range2Rewritten_ProceduralLinq1()
    {
        int v1576;
        v1576 = (0);
        for (; v1576 < (100); v1576 += (1))
            yield return (-100 + v1576);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> Range3Rewritten_ProceduralLinq1()
    {
        throw new System.InvalidOperationException("Index out of range");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> Range4Rewritten_ProceduralLinq1()
    {
        int v1577;
        v1577 = (0);
        for (; v1577 < (23); v1577 += (1))
            yield return (123 + v1577);
        yield break;
    }

    int[] RangeToArrayRewritten_ProceduralLinq1()
    {
        int v1578;
        int[] v1579;
        v1579 = new int[(23)];
        v1578 = (0);
        for (; v1578 < (23); v1578 += (1))
            v1579[v1578] = (123 + v1578);
        return v1579;
    }

    System.Collections.Generic.List<int> RangeToListRewritten_ProceduralLinq1()
    {
        int v1580;
        System.Collections.Generic.List<int> v1581;
        v1581 = new System.Collections.Generic.List<int>();
        v1580 = (0);
        for (; v1580 < (23); v1580 += (1))
            v1581.Add((123 + v1580));
        return v1581;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RangeToSimpleListRewritten_ProceduralLinq1()
    {
        int v1582;
        int[] v1583;
        SimpleList<int> v1584;
        v1583 = new int[(23)];
        v1582 = (0);
        for (; v1582 < (23); v1582 += (1))
            v1583[v1582] = (123 + v1582);
        v1584 = new SimpleList<int>();
        v1584.Items = v1583;
        v1584.Count = (23);
        return v1584;
    }

    System.Collections.Generic.IEnumerable<int> RangeDistinctRewritten_ProceduralLinq1()
    {
        int v1585;
        HashSet<int> v1586;
        int v1587;
        v1586 = new HashSet<int>();
        v1585 = (0);
        for (; v1585 < (23); v1585 += (1))
        {
            v1587 = (123 + v1585);
            if (!(v1586.Add((v1587))))
                continue;
            yield return (v1587);
        }

        yield break;
    }
}}