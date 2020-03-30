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
        int v133;
        v133 = 0;
        for (; v133 < ArrayItems.Length; v133++)
            if (ArrayItems[v133] == 23)
                return true;
        return false;
    }

    bool ArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v134;
        System.Collections.Generic.EqualityComparer<int> v135;
        v135 = EqualityComparer<int>.Default;
        v134 = 0;
        for (; v134 < ArrayItems.Length; v134++)
            if (v135.Equals(ArrayItems[v134], 23))
                return true;
        return false;
    }

    bool ArrayContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v136;
        TestsLibrary.Tests.IntStrangeComparer v137;
        v137 = new IntStrangeComparer();
        v136 = 0;
        for (; v136 < ArrayItems.Length; v136++)
            if (v137.Equals(ArrayItems[v136], 23))
                return true;
        return false;
    }

    bool ArraySelectContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v138;
        v138 = 0;
        for (; v138 < ArrayItems.Length; v138++)
            if ((ArrayItems[v138] + 5) == 23)
                return true;
        return false;
    }

    bool ArraySelectContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v139;
        System.Collections.Generic.EqualityComparer<int> v140;
        v140 = EqualityComparer<int>.Default;
        v139 = 0;
        for (; v139 < ArrayItems.Length; v139++)
            if (v140.Equals((ArrayItems[v139] + 5), 23))
                return true;
        return false;
    }

    bool ArraySelectContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v141;
        TestsLibrary.Tests.IntStrangeComparer v142;
        v142 = new IntStrangeComparer();
        v141 = 0;
        for (; v141 < ArrayItems.Length; v141++)
            if (v142.Equals((ArrayItems[v141] + 5), 23))
                return true;
        return false;
    }

    bool ArrayWhereContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v143;
        v143 = 0;
        for (; v143 < ArrayItems.Length; v143++)
        {
            if (!(ArrayItems[v143] > 20))
                continue;
            if (ArrayItems[v143] == 23)
                return true;
        }

        return false;
    }

    bool ArrayWhereContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v144;
        System.Collections.Generic.EqualityComparer<int> v145;
        v145 = EqualityComparer<int>.Default;
        v144 = 0;
        for (; v144 < ArrayItems.Length; v144++)
        {
            if (!(ArrayItems[v144] > 20))
                continue;
            if (v145.Equals(ArrayItems[v144], 23))
                return true;
        }

        return false;
    }

    bool ArrayWhereContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v146;
        TestsLibrary.Tests.IntStrangeComparer v147;
        v147 = new IntStrangeComparer();
        v146 = 0;
        for (; v146 < ArrayItems.Length; v146++)
        {
            if (!(ArrayItems[v146] > 20))
                continue;
            if (v147.Equals(ArrayItems[v146], 23))
                return true;
        }

        return false;
    }

    bool EnumerableContainsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v148;
        v148 = EnumerableItems.GetEnumerator();
        try
        {
            while (v148.MoveNext())
                if (v148.Current == 23)
                    return true;
        }
        finally
        {
            v148.Dispose();
        }

        return false;
    }

    bool EnumerableContains2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v149;
        System.Collections.Generic.EqualityComparer<int> v150;
        v150 = EqualityComparer<int>.Default;
        v149 = EnumerableItems.GetEnumerator();
        try
        {
            while (v149.MoveNext())
                if (v150.Equals(v149.Current, 23))
                    return true;
        }
        finally
        {
            v149.Dispose();
        }

        return false;
    }

    bool EnumerableContains3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v151;
        TestsLibrary.Tests.IntStrangeComparer v152;
        v152 = new IntStrangeComparer();
        v151 = EnumerableItems.GetEnumerator();
        try
        {
            while (v151.MoveNext())
                if (v152.Equals(v151.Current, 23))
                    return true;
        }
        finally
        {
            v151.Dispose();
        }

        return false;
    }
}}