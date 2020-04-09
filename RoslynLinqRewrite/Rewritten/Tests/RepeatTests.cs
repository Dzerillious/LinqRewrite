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
        int v1776;
        v1776 = (0);
        for (; v1776 < (100); v1776++)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> Repeat2Rewritten_ProceduralLinq1()
    {
        int v1777;
        v1777 = (0);
        for (; v1777 < (100); v1777++)
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
        int v1778;
        v1778 = (0);
        for (; v1778 < (23); v1778++)
            yield return (123);
        yield break;
    }

    int[] RepeatToArrayRewritten_ProceduralLinq1()
    {
        int v1779;
        int[] v1780;
        v1780 = new int[(23)];
        v1779 = (0);
        for (; v1779 < (23); v1779++)
            v1780[v1779] = (123);
        return v1780;
    }

    System.Collections.Generic.List<int> RepeatToListRewritten_ProceduralLinq1()
    {
        int v1781;
        System.Collections.Generic.List<int> v1782;
        v1782 = new System.Collections.Generic.List<int>();
        v1781 = (0);
        for (; v1781 < (23); v1781++)
            v1782.Add((123));
        return v1782;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RepeatToSimpleListRewritten_ProceduralLinq1()
    {
        int v1783;
        int[] v1784;
        SimpleList<int> v1785;
        v1784 = new int[(23)];
        v1783 = (0);
        for (; v1783 < (23); v1783++)
            v1784[v1783] = (123);
        v1785 = new SimpleList<int>();
        v1785.Items = v1784;
        v1785.Count = (23);
        return v1785;
    }

    System.Collections.Generic.IEnumerable<int> RepeatDistinctRewritten_ProceduralLinq1()
    {
        int v1786;
        HashSet<int> v1787;
        int v1788;
        v1787 = new HashSet<int>();
        v1786 = (0);
        for (; v1786 < (23); v1786++)
        {
            v1788 = (123);
            if (!(v1787.Add((v1788))))
                continue;
            yield return (v1788);
        }

        yield break;
    }
}}