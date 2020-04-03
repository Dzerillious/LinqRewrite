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
        return ArraySelectDistinctRewritten_ProceduralLinq1(ArrayItems, x => x % 2);
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
        return ArrayWhereSelectDistinctRewritten_ProceduralLinq1(ArrayItems, x => x > 50, x => x % 10);
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
        int v462;
        HashSet<int> v463;
        v463 = new HashSet<int>();
        v462 = 0;
        for (; v462 < ArrayItems.Length; v462++)
        {
            if (!(v463.Add(ArrayItems[v462])))
                continue;
            yield return ArrayItems[v462];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDefaultComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v464;
        HashSet<int> v465;
        v465 = new HashSet<int>(EqualityComparer<int>.Default);
        v464 = 0;
        for (; v464 < ArrayItems.Length; v464++)
        {
            if (!(v465.Add(ArrayItems[v464])))
                continue;
            yield return ArrayItems[v464];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayStrangeComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v466;
        HashSet<int> v467;
        v467 = new HashSet<int>(new IntStrangeComparer());
        v466 = 0;
        for (; v466 < ArrayItems.Length; v466++)
        {
            if (!(v467.Add(ArrayItems[v466])))
                continue;
            yield return ArrayItems[v466];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayRepeatDistinctRewritten_ProceduralLinq1(int[] RepeatArrayItems)
    {
        int v468;
        HashSet<int> v469;
        v469 = new HashSet<int>();
        v468 = 0;
        for (; v468 < RepeatArrayItems.Length; v468++)
        {
            if (!(v469.Add(RepeatArrayItems[v468])))
                continue;
            yield return RepeatArrayItems[v468];
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableDistinctRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v470;
        HashSet<int> v471;
        int v472;
        v470 = EnumerableItems.GetEnumerator();
        v471 = new HashSet<int>();
        try
        {
            while (v470.MoveNext())
            {
                v472 = v470.Current;
                if (!(v471.Add(v472)))
                    continue;
                yield return v472;
            }
        }
        finally
        {
            v470.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v474)
    {
        int v473;
        HashSet<int> v475;
        int v476;
        v475 = new HashSet<int>();
        v473 = 0;
        for (; v473 < ArrayItems.Length; v473++)
        {
            v476 = v474(ArrayItems[v473]);
            if (!(v475.Add(v476)))
                continue;
            yield return v476;
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v478)
    {
        int v477;
        HashSet<int> v479;
        int v480;
        v479 = new HashSet<int>();
        v477 = 0;
        for (; v477 < ArrayItems.Length; v477++)
        {
            v480 = v478(ArrayItems[v477]);
            if (!(v479.Add(v480)))
                continue;
            yield return v480;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v482, System.Func<int, int> v483)
    {
        int v481;
        HashSet<int> v484;
        int v485;
        v484 = new HashSet<int>();
        v481 = 0;
        for (; v481 < ArrayItems.Length; v481++)
        {
            if (!(v482(ArrayItems[v481])))
                continue;
            v485 = v483(ArrayItems[v481]);
            if (!(v484.Add(v485)))
                continue;
            yield return v485;
        }
    }

    int[] EnumerableDistinctToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v486;
        HashSet<int> v487;
        int v488;
        int v489;
        int v490;
        int[] v491;
        v486 = EnumerableItems.GetEnumerator();
        v487 = new HashSet<int>();
        v489 = 0;
        v490 = 8;
        v491 = new int[8];
        try
        {
            while (v486.MoveNext())
            {
                v488 = v486.Current;
                if (!(v487.Add(v488)))
                    continue;
                if (v489 >= v490)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v491, ref v490);
                v491[v489] = v488;
                v489++;
            }
        }
        finally
        {
            v486.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v491, v489);
    }

    int[] ArrayDistinctToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v492;
        HashSet<int> v493;
        int v494;
        int v495;
        int v496;
        int v497;
        int[] v498;
        v493 = new HashSet<int>();
        v495 = 0;
        v496 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v496 -= (v496 % 2);
        v497 = 8;
        v498 = new int[8];
        v492 = 0;
        for (; v492 < ArrayItems.Length; v492++)
        {
            v494 = (ArrayItems[v492] % 10);
            if (!(v493.Add(v494)))
                continue;
            if (v495 >= v497)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v498, ref v496, out v497);
            v498[v495] = v494;
            v495++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v498, v495);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayDistinctToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v499;
        HashSet<int> v500;
        int v501;
        int v502;
        int v503;
        int v504;
        int[] v505;
        SimpleList<int> v506;
        v500 = new HashSet<int>();
        v502 = 0;
        v503 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v503 -= (v503 % 2);
        v504 = 8;
        v505 = new int[8];
        v499 = 0;
        for (; v499 < ArrayItems.Length; v499++)
        {
            v501 = (ArrayItems[v499] % 10);
            if (!(v500.Add(v501)))
                continue;
            if (v502 >= v504)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v505, ref v503, out v504);
            v505[v502] = v501;
            v502++;
        }

        v506 = new SimpleList<int>();
        v506.Items = v505;
        v506.Count = v502;
        return v506;
    }
}}