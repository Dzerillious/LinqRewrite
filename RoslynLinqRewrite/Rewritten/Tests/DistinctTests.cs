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
        int v561;
        HashSet<int> v562;
        int v563;
        v562 = new HashSet<int>();
        v561 = (0);
        for (; v561 < (ArrayItems.Length); v561++)
        {
            v563 = (ArrayItems[v561]);
            if (!(v562.Add((v563))))
                continue;
            yield return (v563);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDefaultComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v564;
        HashSet<int> v565;
        int v566;
        v565 = new HashSet<int>(EqualityComparer<int>.Default);
        v564 = (0);
        for (; v564 < (ArrayItems.Length); v564++)
        {
            v566 = (ArrayItems[v564]);
            if (!(v565.Add((v566))))
                continue;
            yield return (v566);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayStrangeComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v567;
        HashSet<int> v568;
        int v569;
        v568 = new HashSet<int>(new IntStrangeComparer());
        v567 = (0);
        for (; v567 < (ArrayItems.Length); v567++)
        {
            v569 = (ArrayItems[v567]);
            if (!(v568.Add((v569))))
                continue;
            yield return (v569);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayRepeatDistinctRewritten_ProceduralLinq1(int[] RepeatArrayItems)
    {
        int v570;
        HashSet<int> v571;
        int v572;
        v571 = new HashSet<int>();
        v570 = (0);
        for (; v570 < (RepeatArrayItems.Length); v570++)
        {
            v572 = (RepeatArrayItems[v570]);
            if (!(v571.Add((v572))))
                continue;
            yield return (v572);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableDistinctRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v573;
        HashSet<int> v574;
        int v575;
        v573 = EnumerableItems.GetEnumerator();
        v574 = new HashSet<int>();
        try
        {
            while (v573.MoveNext())
            {
                v575 = (v573.Current);
                if (!(v574.Add((v575))))
                    continue;
                yield return (v575);
            }
        }
        finally
        {
            v573.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v576;
        HashSet<int> v577;
        int v578;
        v577 = new HashSet<int>();
        v576 = (0);
        for (; v576 < (ArrayItems.Length); v576++)
        {
            v578 = (((ArrayItems[v576]) % 2));
            if (!(v577.Add((v578))))
                continue;
            yield return (v578);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v580)
    {
        int v579;
        HashSet<int> v581;
        int v582;
        v581 = new HashSet<int>();
        v579 = (0);
        for (; v579 < (ArrayItems.Length); v579++)
        {
            v582 = (v580((ArrayItems[v579])));
            if (!(v581.Add((v582))))
                continue;
            yield return (v582);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v583;
        int v584;
        HashSet<int> v585;
        v585 = new HashSet<int>();
        v583 = (0);
        for (; v583 < (ArrayItems.Length); v583++)
        {
            v584 = (ArrayItems[v583]);
            if (!(((v584) > 50)))
                continue;
            v584 = (((v584) % 10));
            if (!(v585.Add((v584))))
                continue;
            yield return (v584);
        }

        yield break;
    }

    int[] EnumerableDistinctToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v586;
        HashSet<int> v587;
        int v588;
        int v589;
        int v590;
        int[] v591;
        v586 = EnumerableItems.GetEnumerator();
        v587 = new HashSet<int>();
        v589 = 0;
        v590 = 8;
        v591 = new int[8];
        try
        {
            while (v586.MoveNext())
            {
                v588 = (v586.Current);
                if (!(v587.Add((v588))))
                    continue;
                if (v589 >= v590)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v591, ref v590);
                v591[v589] = (v588);
                v589++;
            }
        }
        finally
        {
            v586.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v591, v589);
    }

    int[] ArrayDistinctToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v592;
        HashSet<int> v593;
        int v594;
        int v595;
        int v596;
        int v597;
        int[] v598;
        v593 = new HashSet<int>();
        v595 = 0;
        v596 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v596 -= (v596 % 2);
        v597 = 8;
        v598 = new int[8];
        v592 = (0);
        for (; v592 < (ArrayItems.Length); v592++)
        {
            v594 = (((ArrayItems[v592]) % 10));
            if (!(v593.Add((v594))))
                continue;
            if (v595 >= v597)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v598, ref v596, out v597);
            v598[v595] = (v594);
            v595++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v598, v595);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayDistinctToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v599;
        HashSet<int> v600;
        int v601;
        int v602;
        int v603;
        int v604;
        int[] v605;
        SimpleList<int> v606;
        v600 = new HashSet<int>();
        v602 = 0;
        v603 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v603 -= (v603 % 2);
        v604 = 8;
        v605 = new int[8];
        v599 = (0);
        for (; v599 < (ArrayItems.Length); v599++)
        {
            v601 = (((ArrayItems[v599]) % 10));
            if (!(v600.Add((v601))))
                continue;
            if (v602 >= v604)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v605, ref v603, out v604);
            v605[v602] = (v601);
            v602++;
        }

        v606 = new SimpleList<int>();
        v606.Items = v605;
        v606.Count = v602;
        return v606;
    }
}}