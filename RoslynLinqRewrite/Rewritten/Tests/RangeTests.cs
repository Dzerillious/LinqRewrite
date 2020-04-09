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
        int v1763;
        v1763 = (0);
        for (; v1763 < (100); v1763++)
            yield return (v1763);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> Range2Rewritten_ProceduralLinq1()
    {
        int v1764;
        v1764 = (0);
        for (; v1764 < (100); v1764++)
            yield return (-100 + v1764);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> Range3Rewritten_ProceduralLinq1()
    {
        throw new System.InvalidOperationException("Index out of range");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> Range4Rewritten_ProceduralLinq1()
    {
        int v1765;
        v1765 = (0);
        for (; v1765 < (23); v1765++)
            yield return (123 + v1765);
        yield break;
    }

    int[] RangeToArrayRewritten_ProceduralLinq1()
    {
        int v1766;
        int[] v1767;
        v1767 = new int[(23)];
        v1766 = (0);
        for (; v1766 < (23); v1766++)
            v1767[v1766] = (123 + v1766);
        return v1767;
    }

    System.Collections.Generic.List<int> RangeToListRewritten_ProceduralLinq1()
    {
        int v1768;
        System.Collections.Generic.List<int> v1769;
        v1769 = new System.Collections.Generic.List<int>();
        v1768 = (0);
        for (; v1768 < (23); v1768++)
            v1769.Add((123 + v1768));
        return v1769;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RangeToSimpleListRewritten_ProceduralLinq1()
    {
        int v1770;
        int[] v1771;
        SimpleList<int> v1772;
        v1771 = new int[(23)];
        v1770 = (0);
        for (; v1770 < (23); v1770++)
            v1771[v1770] = (123 + v1770);
        v1772 = new SimpleList<int>();
        v1772.Items = v1771;
        v1772.Count = (23);
        return v1772;
    }

    System.Collections.Generic.IEnumerable<int> RangeDistinctRewritten_ProceduralLinq1()
    {
        int v1773;
        HashSet<int> v1774;
        int v1775;
        v1774 = new HashSet<int>();
        v1773 = (0);
        for (; v1773 < (23); v1773++)
        {
            v1775 = (123 + v1773);
            if (!(v1774.Add((v1775))))
                continue;
            yield return (v1775);
        }

        yield break;
    }
}}