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
        int v496;
        v496 = (0);
        for (; v496 < (ArrayItems.Length); v496++)
            if ((ArrayItems[v496]) == 23)
                return true;
        return false;
    }

    bool ArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v498;
        System.Collections.Generic.EqualityComparer<int> v499;
        v499 = EqualityComparer<int>.Default;
        v498 = (0);
        for (; v498 < (ArrayItems.Length); v498++)
            if (v499.Equals((ArrayItems[v498]), 23))
                return true;
        return false;
    }

    bool ArrayContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v501;
        TestsLibrary.Tests.IntStrangeComparer v502;
        v502 = new IntStrangeComparer();
        v501 = (0);
        for (; v501 < (ArrayItems.Length); v501++)
            if (v502.Equals((ArrayItems[v501]), 23))
                return true;
        return false;
    }

    bool ArraySelectContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v504;
        v504 = (0);
        for (; v504 < (ArrayItems.Length); v504++)
            if ((5 + ArrayItems[v504]) == 23)
                return true;
        return false;
    }

    bool ArraySelectContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v506;
        System.Collections.Generic.EqualityComparer<int> v507;
        v507 = EqualityComparer<int>.Default;
        v506 = (0);
        for (; v506 < (ArrayItems.Length); v506++)
            if (v507.Equals((5 + ArrayItems[v506]), 23))
                return true;
        return false;
    }

    bool ArraySelectContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v509;
        TestsLibrary.Tests.IntStrangeComparer v510;
        v510 = new IntStrangeComparer();
        v509 = (0);
        for (; v509 < (ArrayItems.Length); v509++)
            if (v510.Equals((5 + ArrayItems[v509]), 23))
                return true;
        return false;
    }

    bool ArrayWhereContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v511;
        int v512;
        v511 = (0);
        for (; v511 < (ArrayItems.Length); v511++)
        {
            v512 = (ArrayItems[v511]);
            if (!(((v512) > 20)))
                continue;
            if ((v512) == 23)
                return true;
        }

        return false;
    }

    bool ArrayWhereContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v513;
        int v514;
        System.Collections.Generic.EqualityComparer<int> v515;
        v515 = EqualityComparer<int>.Default;
        v513 = (0);
        for (; v513 < (ArrayItems.Length); v513++)
        {
            v514 = (ArrayItems[v513]);
            if (!(((v514) > 20)))
                continue;
            if (v515.Equals((v514), 23))
                return true;
        }

        return false;
    }

    bool ArrayWhereContains3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v516;
        int v517;
        TestsLibrary.Tests.IntStrangeComparer v518;
        v518 = new IntStrangeComparer();
        v516 = (0);
        for (; v516 < (ArrayItems.Length); v516++)
        {
            v517 = (ArrayItems[v516]);
            if (!(((v517) > 20)))
                continue;
            if (v518.Equals((v517), 23))
                return true;
        }

        return false;
    }

    bool EnumerableContainsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v519;
        v519 = EnumerableItems.GetEnumerator();
        try
        {
            while (v519.MoveNext())
                if ((v519.Current) == 23)
                    return true;
        }
        finally
        {
            v519.Dispose();
        }

        return false;
    }

    bool EnumerableContains2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v520;
        System.Collections.Generic.EqualityComparer<int> v521;
        v520 = EnumerableItems.GetEnumerator();
        v521 = EqualityComparer<int>.Default;
        try
        {
            while (v520.MoveNext())
                if (v521.Equals((v520.Current), 23))
                    return true;
        }
        finally
        {
            v520.Dispose();
        }

        return false;
    }

    bool EnumerableContains3Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v522;
        TestsLibrary.Tests.IntStrangeComparer v523;
        v522 = EnumerableItems.GetEnumerator();
        v523 = new IntStrangeComparer();
        try
        {
            while (v522.MoveNext())
                if (v523.Equals((v522.Current), 23))
                    return true;
        }
        finally
        {
            v522.Dispose();
        }

        return false;
    }

    bool EnumerableContainsNotRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v524;
        v524 = EnumerableItems.GetEnumerator();
        try
        {
            while (v524.MoveNext())
                if ((v524.Current) == 20000)
                    return true;
        }
        finally
        {
            v524.Dispose();
        }

        return false;
    }
}}