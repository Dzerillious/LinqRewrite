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
        int v1446;
        v1446 = 0;
        for (; v1446 < 100; v1446++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> Repeat2Rewritten_ProceduralLinq1()
    {
        int v1447;
        v1447 = 0;
        for (; v1447 < 100; v1447++)
            yield return -100;
    }

    System.Collections.Generic.IEnumerable<int> Repeat3Rewritten_ProceduralLinq1()
    {
        throw new System.InvalidOperationException("Index out of range");
    }

    System.Collections.Generic.IEnumerable<int> Repeat4Rewritten_ProceduralLinq1()
    {
        int v1448;
        v1448 = 0;
        for (; v1448 < 23; v1448++)
            yield return 123;
    }

    int[] RepeatToArrayRewritten_ProceduralLinq1()
    {
        int v1449;
        int[] v1450;
        v1450 = new int[23];
        v1449 = 0;
        for (; v1449 < 23; v1449++)
            v1450[v1449] = 123;
        return v1450;
    }

    System.Collections.Generic.List<int> RepeatToListRewritten_ProceduralLinq1()
    {
        int v1451;
        System.Collections.Generic.List<int> v1452;
        v1452 = new System.Collections.Generic.List<int>();
        v1451 = 0;
        for (; v1451 < 23; v1451++)
            v1452.Add(123);
        return v1452;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> RepeatToSimpleListRewritten_ProceduralLinq1()
    {
        int v1453;
        int[] v1454;
        SimpleList<int> v1455;
        v1454 = new int[23];
        v1453 = 0;
        for (; v1453 < 23; v1453++)
            v1454[v1453] = 123;
        v1455 = new SimpleList<int>();
        v1455.Items = v1454;
        v1455.Count = 23;
        return v1455;
    }

    System.Collections.Generic.IEnumerable<int> RepeatDistinctRewritten_ProceduralLinq1()
    {
        int v1456;
        HashSet<int> v1457;
        v1457 = new HashSet<int>();
        v1456 = 0;
        for (; v1456 < 23; v1456++)
        {
            if (!(v1457.Add(123)))
                continue;
            yield return 123;
        }
    }
}}