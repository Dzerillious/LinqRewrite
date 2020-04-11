using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class IntStrangeComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return x > y;
        }

        public int GetHashCode(int obj)
        {
            return obj;
        }
    }
public class ContainsTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayContains), ArrayContains, ArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(ArrayContains2), ArrayContains2, ArrayContains2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayContains3), ArrayContains3, ArrayContains3Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectContains), ArraySelectContains, ArraySelectContainsRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectContains2), ArraySelectContains2, ArraySelectContains2Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectContains3), ArraySelectContains3, ArraySelectContains3Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereContains), ArrayWhereContains, ArrayWhereContainsRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereContains2), ArrayWhereContains2, ArrayWhereContains2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereContains3), ArrayWhereContains3, ArrayWhereContains3Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableContains), EnumerableContains, EnumerableContainsRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableContains2), EnumerableContains2, EnumerableContains2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableContains3), EnumerableContains3, EnumerableContains3Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableContainsNot), EnumerableContainsNot, EnumerableContainsNotRewritten);
    }

    [NoRewrite]
    public bool ArrayContains()
    {
        return ArrayItems.Contains(23);
    } //EndMethod

    public bool ArrayContainsRewritten()
    {
        return ArrayContainsRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayContains2()
    {
        return ArrayItems.Contains(23, EqualityComparer<int>.Default);
    } //EndMethod

    public bool ArrayContains2Rewritten()
    {
        return ArrayContains2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayContains3()
    {
        return ArrayItems.Contains(23, new IntStrangeComparer());
    } //EndMethod

    public bool ArrayContains3Rewritten()
    {
        return ArrayContains3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySelectContains()
    {
        return ArrayItems.Select(x => x + 5).Contains(23);
    } //EndMethod

    public bool ArraySelectContainsRewritten()
    {
        return ArraySelectContainsRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySelectContains2()
    {
        return ArrayItems.Select(x => x + 5).Contains(23, EqualityComparer<int>.Default);
    } //EndMethod

    public bool ArraySelectContains2Rewritten()
    {
        return ArraySelectContains2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySelectContains3()
    {
        return ArrayItems.Select(x => x + 5).Contains(23, new IntStrangeComparer());
    } //EndMethod

    public bool ArraySelectContains3Rewritten()
    {
        return ArraySelectContains3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayWhereContains()
    {
        return ArrayItems.Where(x => x > 20).Contains(23);
    } //EndMethod

    public bool ArrayWhereContainsRewritten()
    {
        return ArrayWhereContainsRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayWhereContains2()
    {
        return ArrayItems.Where(x => x > 20).Contains(23, EqualityComparer<int>.Default);
    } //EndMethod

    public bool ArrayWhereContains2Rewritten()
    {
        return ArrayWhereContains2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayWhereContains3()
    {
        return ArrayItems.Where(x => x > 20).Contains(23, new IntStrangeComparer());
    } //EndMethod

    public bool ArrayWhereContains3Rewritten()
    {
        return ArrayWhereContains3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableContains()
    {
        return EnumerableItems.Contains(23);
    } //EndMethod

    public bool EnumerableContainsRewritten()
    {
        return EnumerableContainsRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableContains2()
    {
        return EnumerableItems.Contains(23, EqualityComparer<int>.Default);
    } //EndMethod

    public bool EnumerableContains2Rewritten()
    {
        return EnumerableContains2Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableContains3()
    {
        return EnumerableItems.Contains(23, new IntStrangeComparer());
    } //EndMethod

    public bool EnumerableContains3Rewritten()
    {
        return EnumerableContains3Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableContainsNot()
    {
        return EnumerableItems.Contains(20000);
    } //EndMethod

    public bool EnumerableContainsNotRewritten()
    {
        return EnumerableContainsNotRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    bool ArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v456;
        v456 = (0);
        for (; v456 < (ArrayItems.Length); v456 += 1)
            if ((ArrayItems[v456]) == 23)
                return true;
        return false;
    }

    bool ArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v458;
        System.Collections.Generic.EqualityComparer<int> v459;
        v459 = EqualityComparer<int>.Default;
        v458 = (0);
        for (; v458 < (ArrayItems.Length); v458 += 1)
            if (v459.Equals((ArrayItems[v458]), 23))
                return true;
        return false;
    }

    bool ArrayContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v461;
        TestsLibrary.Tests.IntStrangeComparer v462;
        v462 = new IntStrangeComparer();
        v461 = (0);
        for (; v461 < (ArrayItems.Length); v461 += 1)
            if (v462.Equals((ArrayItems[v461]), 23))
                return true;
        return false;
    }

    bool ArraySelectContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v464;
        v464 = (0);
        for (; v464 < (ArrayItems.Length); v464 += 1)
            if ((5 + ArrayItems[v464]) == 23)
                return true;
        return false;
    }

    bool ArraySelectContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v466;
        System.Collections.Generic.EqualityComparer<int> v467;
        v467 = EqualityComparer<int>.Default;
        v466 = (0);
        for (; v466 < (ArrayItems.Length); v466 += 1)
            if (v467.Equals((5 + ArrayItems[v466]), 23))
                return true;
        return false;
    }

    bool ArraySelectContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v469;
        TestsLibrary.Tests.IntStrangeComparer v470;
        v470 = new IntStrangeComparer();
        v469 = (0);
        for (; v469 < (ArrayItems.Length); v469 += 1)
            if (v470.Equals((5 + ArrayItems[v469]), 23))
                return true;
        return false;
    }

    bool ArrayWhereContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v471;
        v471 = (0);
        for (; v471 < (ArrayItems.Length); v471 += 1)
        {
            if (!((((ArrayItems[v471])) > 20)))
                continue;
            if (((ArrayItems[v471])) == 23)
                return true;
        }

        return false;
    }

    bool ArrayWhereContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v472;
        System.Collections.Generic.EqualityComparer<int> v473;
        v473 = EqualityComparer<int>.Default;
        v472 = (0);
        for (; v472 < (ArrayItems.Length); v472 += 1)
        {
            if (!((((ArrayItems[v472])) > 20)))
                continue;
            if (v473.Equals(((ArrayItems[v472])), 23))
                return true;
        }

        return false;
    }

    bool ArrayWhereContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v474;
        TestsLibrary.Tests.IntStrangeComparer v475;
        v475 = new IntStrangeComparer();
        v474 = (0);
        for (; v474 < (ArrayItems.Length); v474 += 1)
        {
            if (!((((ArrayItems[v474])) > 20)))
                continue;
            if (v475.Equals(((ArrayItems[v474])), 23))
                return true;
        }

        return false;
    }

    bool EnumerableContainsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v476;
        v476 = EnumerableItems.GetEnumerator();
        try
        {
            while (v476.MoveNext())
                if ((v476.Current) == 23)
                    return true;
        }
        finally
        {
            v476.Dispose();
        }

        return false;
    }

    bool EnumerableContains2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v477;
        System.Collections.Generic.EqualityComparer<int> v478;
        v478 = EqualityComparer<int>.Default;
        v477 = EnumerableItems.GetEnumerator();
        try
        {
            while (v477.MoveNext())
                if (v478.Equals((v477.Current), 23))
                    return true;
        }
        finally
        {
            v477.Dispose();
        }

        return false;
    }

    bool EnumerableContains3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v479;
        TestsLibrary.Tests.IntStrangeComparer v480;
        v480 = new IntStrangeComparer();
        v479 = EnumerableItems.GetEnumerator();
        try
        {
            while (v479.MoveNext())
                if (v480.Equals((v479.Current), 23))
                    return true;
        }
        finally
        {
            v479.Dispose();
        }

        return false;
    }

    bool EnumerableContainsNotRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v481;
        v481 = EnumerableItems.GetEnumerator();
        try
        {
            while (v481.MoveNext())
                if ((v481.Current) == 20000)
                    return true;
        }
        finally
        {
            v481.Dispose();
        }

        return false;
    }
}}