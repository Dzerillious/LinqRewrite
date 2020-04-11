using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class DistinctTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private int[] RepeatArrayItems = Enumerable.Repeat(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayDistinct), ArrayDistinct, ArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDefaultComparerDistinct), ArrayDefaultComparerDistinct, ArrayDefaultComparerDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayStrangeComparerDistinct), ArrayStrangeComparerDistinct, ArrayStrangeComparerDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayRepeatDistinct), ArrayRepeatDistinct, ArrayRepeatDistinctRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableDistinct), EnumerableDistinct, EnumerableDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectDistinct), ArraySelectDistinct, ArraySelectDistinctRewritten);
        TestsExtensions.TestEquals(nameof(RepeatArraySelectDistinct), RepeatArraySelectDistinct, RepeatArraySelectDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereSelectDistinct), ArrayWhereSelectDistinct, ArrayWhereSelectDistinctRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableDistinctToArray), EnumerableDistinctToArray, EnumerableDistinctToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctToArray), ArrayDistinctToArray, ArrayDistinctToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctToSimpleList), ArrayDistinctToSimpleList, ArrayDistinctToSimpleListRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayDistinct()
    {
        return ArrayItems.Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctRewritten()
    {
        return ArrayDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDefaultComparerDistinct()
    {
        return ArrayItems.Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayDefaultComparerDistinctRewritten()
    {
        return ArrayDefaultComparerDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayStrangeComparerDistinct()
    {
        return ArrayItems.Distinct(new IntStrangeComparer());
    } //EndMethod

    public IEnumerable<int> ArrayStrangeComparerDistinctRewritten()
    {
        return ArrayStrangeComparerDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayRepeatDistinct()
    {
        return RepeatArrayItems.Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayRepeatDistinctRewritten()
    {
        return ArrayRepeatDistinctRewritten_ProceduralLinq1(RepeatArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableDistinct()
    {
        return EnumerableItems.Distinct();
    } //EndMethod

    public IEnumerable<int> EnumerableDistinctRewritten()
    {
        return EnumerableDistinctRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectDistinct()
    {
        return ArrayItems.Select(x => x % 2).Distinct();
    } //EndMethod

    public IEnumerable<int> ArraySelectDistinctRewritten()
    {
        return ArraySelectDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatArraySelectDistinct()
    {
        var a = 0;
        return ArrayItems.Select(x => x + a++ % 2).Distinct();
    } //EndMethod

    public IEnumerable<int> RepeatArraySelectDistinctRewritten()
    {
        var a = 0;
        return RepeatArraySelectDistinctRewritten_ProceduralLinq1(ArrayItems, x => x + a++ % 2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereSelectDistinct()
    {
        return ArrayItems.Where(x => x > 50).Select(x => x % 10).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayWhereSelectDistinctRewritten()
    {
        return ArrayWhereSelectDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableDistinctToArray()
    {
        return EnumerableItems.Distinct().ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableDistinctToArrayRewritten()
    {
        return EnumerableDistinctToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctToArray()
    {
        return ArrayItems.Select(x => x % 10).Distinct().ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctToArrayRewritten()
    {
        return ArrayDistinctToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctToSimpleList()
    {
        return ArrayItems.Select(x => x % 10).Distinct().ToSimpleList();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctToSimpleListRewritten()
    {
        return ArrayDistinctToSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v514;
        HashSet<int> v515;
        v515 = new HashSet<int>();
        v514 = (0);
        for (; v514 < (ArrayItems.Length); v514 += 1)
        {
            if (!(v515.Add(((ArrayItems[v514])))))
                continue;
            yield return ((ArrayItems[v514]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDefaultComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v516;
        HashSet<int> v517;
        v517 = new HashSet<int>(EqualityComparer<int>.Default);
        v516 = (0);
        for (; v516 < (ArrayItems.Length); v516 += 1)
        {
            if (!(v517.Add(((ArrayItems[v516])))))
                continue;
            yield return ((ArrayItems[v516]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayStrangeComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v518;
        HashSet<int> v519;
        v519 = new HashSet<int>(new IntStrangeComparer());
        v518 = (0);
        for (; v518 < (ArrayItems.Length); v518 += 1)
        {
            if (!(v519.Add(((ArrayItems[v518])))))
                continue;
            yield return ((ArrayItems[v518]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayRepeatDistinctRewritten_ProceduralLinq1(int[] RepeatArrayItems)
    {
        int v520;
        HashSet<int> v521;
        v521 = new HashSet<int>();
        v520 = (0);
        for (; v520 < (RepeatArrayItems.Length); v520 += 1)
        {
            if (!(v521.Add(((RepeatArrayItems[v520])))))
                continue;
            yield return ((RepeatArrayItems[v520]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableDistinctRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v522;
        HashSet<int> v523;
        int v524;
        v522 = EnumerableItems.GetEnumerator();
        v523 = new HashSet<int>();
        try
        {
            while (v522.MoveNext())
            {
                v524 = (v522.Current);
                if (!(v523.Add((v524))))
                    continue;
                yield return (v524);
            }
        }
        finally
        {
            v522.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v525;
        HashSet<int> v526;
        int v527;
        v526 = new HashSet<int>();
        v525 = (0);
        for (; v525 < (ArrayItems.Length); v525 += 1)
        {
            v527 = (((ArrayItems[v525]) % 2));
            if (!(v526.Add((v527))))
                continue;
            yield return (v527);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v529)
    {
        int v528;
        HashSet<int> v530;
        int v531;
        v530 = new HashSet<int>();
        v528 = (0);
        for (; v528 < (ArrayItems.Length); v528 += 1)
        {
            v531 = (v529((ArrayItems[v528])));
            if (!(v530.Add((v531))))
                continue;
            yield return (v531);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v532;
        HashSet<int> v533;
        int v534;
        v533 = new HashSet<int>();
        v532 = (0);
        for (; v532 < (ArrayItems.Length); v532 += 1)
        {
            if (!((((ArrayItems[v532])) > 50)))
                continue;
            v534 = ((((ArrayItems[v532])) % 10));
            if (!(v533.Add((v534))))
                continue;
            yield return (v534);
        }

        yield break;
    }

    int[] EnumerableDistinctToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v535;
        HashSet<int> v536;
        int v537;
        int v538;
        int v539;
        int[] v540;
        v535 = EnumerableItems.GetEnumerator();
        v536 = new HashSet<int>();
        v538 = 0;
        v539 = 8;
        v540 = new int[8];
        try
        {
            while (v535.MoveNext())
            {
                v537 = (v535.Current);
                if (!(v536.Add((v537))))
                    continue;
                if (v538 >= v539)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v540, ref v539);
                v540[v538] = (v537);
                v538++;
            }
        }
        finally
        {
            v535.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v540, v538);
    }

    int[] ArrayDistinctToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v541;
        HashSet<int> v542;
        int v543;
        int v544;
        int v545;
        int v546;
        int[] v547;
        v542 = new HashSet<int>();
        v544 = 0;
        v545 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v545 -= (v545 % 2);
        v546 = 8;
        v547 = new int[8];
        v541 = (0);
        for (; v541 < (ArrayItems.Length); v541 += 1)
        {
            v543 = (((ArrayItems[v541]) % 10));
            if (!(v542.Add((v543))))
                continue;
            if (v544 >= v546)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v547, ref v545, out v546);
            v547[v544] = (v543);
            v544++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v547, v544);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayDistinctToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v548;
        HashSet<int> v549;
        int v550;
        int v551;
        int v552;
        int v553;
        int[] v554;
        SimpleList<int> v555;
        v549 = new HashSet<int>();
        v551 = 0;
        v552 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v552 -= (v552 % 2);
        v553 = 8;
        v554 = new int[8];
        v548 = (0);
        for (; v548 < (ArrayItems.Length); v548 += 1)
        {
            v550 = (((ArrayItems[v548]) % 10));
            if (!(v549.Add((v550))))
                continue;
            if (v551 >= v553)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v554, ref v552, out v553);
            v554[v551] = (v550);
            v551++;
        }

        v555 = new SimpleList<int>();
        v555.Items = v554;
        v555.Count = v551;
        return v555;
    }
}}