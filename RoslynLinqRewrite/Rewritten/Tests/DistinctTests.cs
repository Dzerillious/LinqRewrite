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
        int v451;
        HashSet<int> v452;
        v452 = new HashSet<int>();
        v451 = 0;
        for (; v451 < ArrayItems.Length; v451++)
        {
            if (!(v452.Add(ArrayItems[v451])))
                continue;
            yield return ArrayItems[v451];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDefaultComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v453;
        HashSet<int> v454;
        v454 = new HashSet<int>(EqualityComparer<int>.Default);
        v453 = 0;
        for (; v453 < ArrayItems.Length; v453++)
        {
            if (!(v454.Add(ArrayItems[v453])))
                continue;
            yield return ArrayItems[v453];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayStrangeComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v455;
        HashSet<int> v456;
        v456 = new HashSet<int>(new IntStrangeComparer());
        v455 = 0;
        for (; v455 < ArrayItems.Length; v455++)
        {
            if (!(v456.Add(ArrayItems[v455])))
                continue;
            yield return ArrayItems[v455];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayRepeatDistinctRewritten_ProceduralLinq1(int[] RepeatArrayItems)
    {
        int v457;
        HashSet<int> v458;
        v458 = new HashSet<int>();
        v457 = 0;
        for (; v457 < RepeatArrayItems.Length; v457++)
        {
            if (!(v458.Add(RepeatArrayItems[v457])))
                continue;
            yield return RepeatArrayItems[v457];
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableDistinctRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v459;
        HashSet<int> v460;
        int v461;
        v459 = EnumerableItems.GetEnumerator();
        v460 = new HashSet<int>();
        try
        {
            while (v459.MoveNext())
            {
                v461 = v459.Current;
                if (!(v460.Add(v461)))
                    continue;
                yield return v461;
            }
        }
        finally
        {
            v459.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v462;
        HashSet<int> v463;
        int v464;
        v463 = new HashSet<int>();
        v462 = 0;
        for (; v462 < ArrayItems.Length; v462++)
        {
            v464 = (ArrayItems[v462] % 2);
            if (!(v463.Add(v464)))
                continue;
            yield return v464;
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v466)
    {
        int v465;
        HashSet<int> v467;
        int v468;
        v467 = new HashSet<int>();
        v465 = 0;
        for (; v465 < ArrayItems.Length; v465++)
        {
            v468 = v466(ArrayItems[v465]);
            if (!(v467.Add(v468)))
                continue;
            yield return v468;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v469;
        HashSet<int> v470;
        int v471;
        v470 = new HashSet<int>();
        v469 = 0;
        for (; v469 < ArrayItems.Length; v469++)
        {
            if (!((ArrayItems[v469] > 50)))
                continue;
            v471 = (ArrayItems[v469] % 10);
            if (!(v470.Add(v471)))
                continue;
            yield return v471;
        }
    }

    int[] EnumerableDistinctToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v472;
        HashSet<int> v473;
        int v474;
        int v475;
        int v476;
        int[] v477;
        v472 = EnumerableItems.GetEnumerator();
        v473 = new HashSet<int>();
        v475 = 0;
        v476 = 8;
        v477 = new int[8];
        try
        {
            while (v472.MoveNext())
            {
                v474 = v472.Current;
                if (!(v473.Add(v474)))
                    continue;
                if (v475 >= v476)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v477, ref v476);
                v477[v475] = v474;
                v475++;
            }
        }
        finally
        {
            v472.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v477, v475);
    }

    int[] ArrayDistinctToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v478;
        HashSet<int> v479;
        int v480;
        int v481;
        int v482;
        int v483;
        int[] v484;
        v479 = new HashSet<int>();
        v481 = 0;
        v482 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v482 -= (v482 % 2);
        v483 = 8;
        v484 = new int[8];
        v478 = 0;
        for (; v478 < ArrayItems.Length; v478++)
        {
            v480 = (ArrayItems[v478] % 10);
            if (!(v479.Add(v480)))
                continue;
            if (v481 >= v483)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v484, ref v482, out v483);
            v484[v481] = v480;
            v481++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v484, v481);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayDistinctToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v485;
        HashSet<int> v486;
        int v487;
        int v488;
        int v489;
        int v490;
        int[] v491;
        SimpleList<int> v492;
        v486 = new HashSet<int>();
        v488 = 0;
        v489 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v489 -= (v489 % 2);
        v490 = 8;
        v491 = new int[8];
        v485 = 0;
        for (; v485 < ArrayItems.Length; v485++)
        {
            v487 = (ArrayItems[v485] % 10);
            if (!(v486.Add(v487)))
                continue;
            if (v488 >= v490)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v491, ref v489, out v490);
            v491[v488] = v487;
            v488++;
        }

        v492 = new SimpleList<int>();
        v492.Items = v491;
        v492.Count = v488;
        return v492;
    }
}}