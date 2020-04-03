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
        int v411;
        v411 = 0;
        for (; v411 < ArrayItems.Length; v411++)
            if (ArrayItems[v411] == 23)
                return true;
        return false;
    }

    bool ArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v412;
        System.Collections.Generic.EqualityComparer<int> v413;
        v413 = EqualityComparer<int>.Default;
        v412 = 0;
        for (; v412 < ArrayItems.Length; v412++)
            if (v413.Equals(ArrayItems[v412], 23))
                return true;
        return false;
    }

    bool ArrayContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v414;
        TestsLibrary.Tests.IntStrangeComparer v415;
        v415 = new IntStrangeComparer();
        v414 = 0;
        for (; v414 < ArrayItems.Length; v414++)
            if (v415.Equals(ArrayItems[v414], 23))
                return true;
        return false;
    }

    bool ArraySelectContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v416;
        v416 = 0;
        for (; v416 < ArrayItems.Length; v416++)
            if ((ArrayItems[v416] + 5) == 23)
                return true;
        return false;
    }

    bool ArraySelectContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v417;
        System.Collections.Generic.EqualityComparer<int> v418;
        v418 = EqualityComparer<int>.Default;
        v417 = 0;
        for (; v417 < ArrayItems.Length; v417++)
            if (v418.Equals((ArrayItems[v417] + 5), 23))
                return true;
        return false;
    }

    bool ArraySelectContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v419;
        TestsLibrary.Tests.IntStrangeComparer v420;
        v420 = new IntStrangeComparer();
        v419 = 0;
        for (; v419 < ArrayItems.Length; v419++)
            if (v420.Equals((ArrayItems[v419] + 5), 23))
                return true;
        return false;
    }

    bool ArrayWhereContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v421;
        v421 = 0;
        for (; v421 < ArrayItems.Length; v421++)
        {
            if (!((ArrayItems[v421] > 20)))
                continue;
            if (ArrayItems[v421] == 23)
                return true;
        }

        return false;
    }

    bool ArrayWhereContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v422;
        System.Collections.Generic.EqualityComparer<int> v423;
        v423 = EqualityComparer<int>.Default;
        v422 = 0;
        for (; v422 < ArrayItems.Length; v422++)
        {
            if (!((ArrayItems[v422] > 20)))
                continue;
            if (v423.Equals(ArrayItems[v422], 23))
                return true;
        }

        return false;
    }

    bool ArrayWhereContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v424;
        TestsLibrary.Tests.IntStrangeComparer v425;
        v425 = new IntStrangeComparer();
        v424 = 0;
        for (; v424 < ArrayItems.Length; v424++)
        {
            if (!((ArrayItems[v424] > 20)))
                continue;
            if (v425.Equals(ArrayItems[v424], 23))
                return true;
        }

        return false;
    }

    bool EnumerableContainsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v426;
        v426 = EnumerableItems.GetEnumerator();
        try
        {
            while (v426.MoveNext())
                if (v426.Current == 23)
                    return true;
        }
        finally
        {
            v426.Dispose();
        }

        return false;
    }

    bool EnumerableContains2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v427;
        System.Collections.Generic.EqualityComparer<int> v428;
        v427 = EnumerableItems.GetEnumerator();
        v428 = EqualityComparer<int>.Default;
        try
        {
            while (v427.MoveNext())
                if (v428.Equals(v427.Current, 23))
                    return true;
        }
        finally
        {
            v427.Dispose();
        }

        return false;
    }

    bool EnumerableContains3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v429;
        TestsLibrary.Tests.IntStrangeComparer v430;
        v429 = EnumerableItems.GetEnumerator();
        v430 = new IntStrangeComparer();
        try
        {
            while (v429.MoveNext())
                if (v430.Equals(v429.Current, 23))
                    return true;
        }
        finally
        {
            v429.Dispose();
        }

        return false;
    }

    bool EnumerableContainsNotRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v431;
        v431 = EnumerableItems.GetEnumerator();
        try
        {
            while (v431.MoveNext())
                if (v431.Current == 20000)
                    return true;
        }
        finally
        {
            v431.Dispose();
        }

        return false;
    }
}}