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
        ArrayContains().TestEquals(nameof(ArrayContains), ArrayContainsRewritten());
        ArrayContains2().TestEquals(nameof(ArrayContains2), ArrayContains2Rewritten());
        ArrayContains3().TestEquals(nameof(ArrayContains3), ArrayContains3Rewritten());
        ArraySelectContains().TestEquals(nameof(ArraySelectContains), ArraySelectContainsRewritten());
        ArraySelectContains2().TestEquals(nameof(ArraySelectContains2), ArraySelectContains2Rewritten());
        ArraySelectContains3().TestEquals(nameof(ArraySelectContains3), ArraySelectContains3Rewritten());
        ArrayWhereContains().TestEquals(nameof(ArrayWhereContains), ArrayWhereContainsRewritten());
        ArrayWhereContains2().TestEquals(nameof(ArrayWhereContains2), ArrayWhereContains2Rewritten());
        ArrayWhereContains3().TestEquals(nameof(ArrayWhereContains3), ArrayWhereContains3Rewritten());
        EnumerableContains().TestEquals(nameof(EnumerableContains), EnumerableContainsRewritten());
        EnumerableContains2().TestEquals(nameof(EnumerableContains2), EnumerableContains2Rewritten());
        EnumerableContains3().TestEquals(nameof(EnumerableContains3), EnumerableContains3Rewritten());
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

    bool ArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v97;
        v97 = 0;
        for (; v97 < ArrayItems.Length; v97++)
            if (ArrayItems[v97] == 23)
                return true;
        return false;
    }

    bool ArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v98;
        System.Collections.Generic.EqualityComparer<int> v99;
        v99 = EqualityComparer<int>.Default;
        v98 = 0;
        for (; v98 < ArrayItems.Length; v98++)
            if (v99.Equals(ArrayItems[v98], 23))
                return true;
        return false;
    }

    bool ArrayContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v100;
        TestsLibrary.Tests.IntStrangeComparer v101;
        v101 = new IntStrangeComparer();
        v100 = 0;
        for (; v100 < ArrayItems.Length; v100++)
            if (v101.Equals(ArrayItems[v100], 23))
                return true;
        return false;
    }

    bool ArraySelectContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v102;
        v102 = 0;
        for (; v102 < ArrayItems.Length; v102++)
            if ((ArrayItems[v102] + 5) == 23)
                return true;
        return false;
    }

    bool ArraySelectContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v103;
        System.Collections.Generic.EqualityComparer<int> v104;
        v104 = EqualityComparer<int>.Default;
        v103 = 0;
        for (; v103 < ArrayItems.Length; v103++)
            if (v104.Equals((ArrayItems[v103] + 5), 23))
                return true;
        return false;
    }

    bool ArraySelectContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v105;
        TestsLibrary.Tests.IntStrangeComparer v106;
        v106 = new IntStrangeComparer();
        v105 = 0;
        for (; v105 < ArrayItems.Length; v105++)
            if (v106.Equals((ArrayItems[v105] + 5), 23))
                return true;
        return false;
    }

    bool ArrayWhereContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v107;
        v107 = 0;
        for (; v107 < ArrayItems.Length; v107++)
        {
            if (!(ArrayItems[v107] > 20))
                continue;
            if (ArrayItems[v107] == 23)
                return true;
        }

        return false;
    }

    bool ArrayWhereContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v108;
        System.Collections.Generic.EqualityComparer<int> v109;
        v109 = EqualityComparer<int>.Default;
        v108 = 0;
        for (; v108 < ArrayItems.Length; v108++)
        {
            if (!(ArrayItems[v108] > 20))
                continue;
            if (v109.Equals(ArrayItems[v108], 23))
                return true;
        }

        return false;
    }

    bool ArrayWhereContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v110;
        TestsLibrary.Tests.IntStrangeComparer v111;
        v111 = new IntStrangeComparer();
        v110 = 0;
        for (; v110 < ArrayItems.Length; v110++)
        {
            if (!(ArrayItems[v110] > 20))
                continue;
            if (v111.Equals(ArrayItems[v110], 23))
                return true;
        }

        return false;
    }

    bool EnumerableContainsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v112;
        v112 = EnumerableItems.GetEnumerator();
        try
        {
            while (v112.MoveNext())
                if (v112.Current == 23)
                    return true;
        }
        finally
        {
            v112.Dispose();
        }

        return false;
    }

    bool EnumerableContains2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v113;
        System.Collections.Generic.EqualityComparer<int> v114;
        v114 = EqualityComparer<int>.Default;
        v113 = EnumerableItems.GetEnumerator();
        try
        {
            while (v113.MoveNext())
                if (v114.Equals(v113.Current, 23))
                    return true;
        }
        finally
        {
            v113.Dispose();
        }

        return false;
    }

    bool EnumerableContains3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v115;
        TestsLibrary.Tests.IntStrangeComparer v116;
        v116 = new IntStrangeComparer();
        v115 = EnumerableItems.GetEnumerator();
        try
        {
            while (v115.MoveNext())
                if (v116.Equals(v115.Current, 23))
                    return true;
        }
        finally
        {
            v115.Dispose();
        }

        return false;
    }
}}