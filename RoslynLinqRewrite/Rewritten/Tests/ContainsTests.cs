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
        int v400;
        v400 = 0;
        for (; v400 < ArrayItems.Length; v400++)
            if (ArrayItems[v400] == 23)
                return true;
        return false;
    }

    bool ArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v401;
        System.Collections.Generic.EqualityComparer<int> v402;
        v402 = EqualityComparer<int>.Default;
        v401 = 0;
        for (; v401 < ArrayItems.Length; v401++)
            if (v402.Equals(ArrayItems[v401], 23))
                return true;
        return false;
    }

    bool ArrayContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v403;
        TestsLibrary.Tests.IntStrangeComparer v404;
        v404 = new IntStrangeComparer();
        v403 = 0;
        for (; v403 < ArrayItems.Length; v403++)
            if (v404.Equals(ArrayItems[v403], 23))
                return true;
        return false;
    }

    bool ArraySelectContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v405;
        v405 = 0;
        for (; v405 < ArrayItems.Length; v405++)
            if ((ArrayItems[v405] + 5) == 23)
                return true;
        return false;
    }

    bool ArraySelectContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v406;
        System.Collections.Generic.EqualityComparer<int> v407;
        v407 = EqualityComparer<int>.Default;
        v406 = 0;
        for (; v406 < ArrayItems.Length; v406++)
            if (v407.Equals((ArrayItems[v406] + 5), 23))
                return true;
        return false;
    }

    bool ArraySelectContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v408;
        TestsLibrary.Tests.IntStrangeComparer v409;
        v409 = new IntStrangeComparer();
        v408 = 0;
        for (; v408 < ArrayItems.Length; v408++)
            if (v409.Equals((ArrayItems[v408] + 5), 23))
                return true;
        return false;
    }

    bool ArrayWhereContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v410;
        v410 = 0;
        for (; v410 < ArrayItems.Length; v410++)
        {
            if (!((ArrayItems[v410] > 20)))
                continue;
            if (ArrayItems[v410] == 23)
                return true;
        }

        return false;
    }

    bool ArrayWhereContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v411;
        System.Collections.Generic.EqualityComparer<int> v412;
        v412 = EqualityComparer<int>.Default;
        v411 = 0;
        for (; v411 < ArrayItems.Length; v411++)
        {
            if (!((ArrayItems[v411] > 20)))
                continue;
            if (v412.Equals(ArrayItems[v411], 23))
                return true;
        }

        return false;
    }

    bool ArrayWhereContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v413;
        TestsLibrary.Tests.IntStrangeComparer v414;
        v414 = new IntStrangeComparer();
        v413 = 0;
        for (; v413 < ArrayItems.Length; v413++)
        {
            if (!((ArrayItems[v413] > 20)))
                continue;
            if (v414.Equals(ArrayItems[v413], 23))
                return true;
        }

        return false;
    }

    bool EnumerableContainsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v415;
        v415 = EnumerableItems.GetEnumerator();
        try
        {
            while (v415.MoveNext())
                if (v415.Current == 23)
                    return true;
        }
        finally
        {
            v415.Dispose();
        }

        return false;
    }

    bool EnumerableContains2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v416;
        System.Collections.Generic.EqualityComparer<int> v417;
        v416 = EnumerableItems.GetEnumerator();
        v417 = EqualityComparer<int>.Default;
        try
        {
            while (v416.MoveNext())
                if (v417.Equals(v416.Current, 23))
                    return true;
        }
        finally
        {
            v416.Dispose();
        }

        return false;
    }

    bool EnumerableContains3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v418;
        TestsLibrary.Tests.IntStrangeComparer v419;
        v418 = EnumerableItems.GetEnumerator();
        v419 = new IntStrangeComparer();
        try
        {
            while (v418.MoveNext())
                if (v419.Equals(v418.Current, 23))
                    return true;
        }
        finally
        {
            v418.Dispose();
        }

        return false;
    }

    bool EnumerableContainsNotRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v420;
        v420 = EnumerableItems.GetEnumerator();
        try
        {
            while (v420.MoveNext())
                if (v420.Current == 20000)
                    return true;
        }
        finally
        {
            v420.Dispose();
        }

        return false;
    }
}}