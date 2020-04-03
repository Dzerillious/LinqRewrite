using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class TakeTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayTake), ArrayTake, ArrayTakeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTake0), ArrayTake0, ArrayTake0Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeM1), ArrayTakeM1, ArrayTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTake1000), ArrayTake1000, ArrayTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeParam), ArrayTakeParam, ArrayTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTake), EnumerableTake, EnumerableTakeRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTake0), EnumerableTake0, EnumerableTake0Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeM1), EnumerableTakeM1, EnumerableTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTake1000), EnumerableTake1000, EnumerableTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeParam), EnumerableTakeParam, EnumerableTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(RangeTake), RangeTake, RangeTakeRewritten);
        TestsExtensions.TestEquals(nameof(RangeTake0), RangeTake0, RangeTake0Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeM1), RangeTakeM1, RangeTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTake1000), RangeTake1000, RangeTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeParam), RangeTakeParam, RangeTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(RepeatTake), RepeatTake, RepeatTakeRewritten);
        TestsExtensions.TestEquals(nameof(RepeatTake0), RepeatTake0, RepeatTake0Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatTakeM1), RepeatTakeM1, RepeatTakeM1Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatTake1000), RepeatTake1000, RepeatTake1000Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatTakeParam), RepeatTakeParam, RepeatTakeParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectTakeToArray), ArraySelectTakeToArray, ArraySelectTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectTakeM1ToArray), ArraySelectTakeM1ToArray, ArraySelectTakeM1ToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereTakeToArray), ArrayWhereTakeToArray, ArrayWhereTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereFalseTakeToArray), ArrayWhereFalseTakeToArray, ArrayWhereFalseTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeToArray), ArrayTakeToArray, ArrayTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeToArray), EnumerableTakeToArray, EnumerableTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeToArray), RangeTakeToArray, RangeTakeToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatTakeToArray), RepeatTakeToArray, RepeatTakeToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayTake()
    {
        return ArrayItems.Take(20);
    } //EndMethod

    public IEnumerable<int> ArrayTakeRewritten()
    {
        return ArrayTakeRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTake0()
    {
        return ArrayItems.Take(0);
    } //EndMethod

    public IEnumerable<int> ArrayTake0Rewritten()
    {
        return ArrayTake0Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeM1()
    {
        return ArrayItems.Take(-1);
    } //EndMethod

    public IEnumerable<int> ArrayTakeM1Rewritten()
    {
        return ArrayTakeM1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTake1000()
    {
        return ArrayItems.Take(1000);
    } //EndMethod

    public IEnumerable<int> ArrayTake1000Rewritten()
    {
        return ArrayTake1000Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeParam()
    {
        var a = 50;
        return ArrayItems.Take(a);
    } //EndMethod

    public IEnumerable<int> ArrayTakeParamRewritten()
    {
        var a = 50;
        return ArrayTakeParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTake()
    {
        return EnumerableItems.Take(20);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeRewritten()
    {
        return EnumerableTakeRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTake0()
    {
        return EnumerableItems.Take(0);
    } //EndMethod

    public IEnumerable<int> EnumerableTake0Rewritten()
    {
        return EnumerableTake0Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeM1()
    {
        return EnumerableItems.Take(-1);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeM1Rewritten()
    {
        return EnumerableTakeM1Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTake1000()
    {
        return EnumerableItems.Take(1000);
    } //EndMethod

    public IEnumerable<int> EnumerableTake1000Rewritten()
    {
        return EnumerableTake1000Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeParam()
    {
        var a = 50;
        return EnumerableItems.Take(a);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeParamRewritten()
    {
        var a = 50;
        return EnumerableTakeParamRewritten_ProceduralLinq1(a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTake()
    {
        return Enumerable.Range(0, 100).Take(20);
    } //EndMethod

    public IEnumerable<int> RangeTakeRewritten()
    {
        return RangeTakeRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTake0()
    {
        return Enumerable.Range(0, 100).Take(0);
    } //EndMethod

    public IEnumerable<int> RangeTake0Rewritten()
    {
        return RangeTake0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeM1()
    {
        return Enumerable.Range(0, 100).Take(-1);
    } //EndMethod

    public IEnumerable<int> RangeTakeM1Rewritten()
    {
        return RangeTakeM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTake1000()
    {
        return Enumerable.Range(0, 100).Take(1000);
    } //EndMethod

    public IEnumerable<int> RangeTake1000Rewritten()
    {
        return RangeTake1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeParam()
    {
        var a = 50;
        return Enumerable.Range(0, 100).Take(a);
    } //EndMethod

    public IEnumerable<int> RangeTakeParamRewritten()
    {
        var a = 50;
        return RangeTakeParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTake()
    {
        return Enumerable.Repeat(0, 100).Take(20);
    } //EndMethod

    public IEnumerable<int> RepeatTakeRewritten()
    {
        return RepeatTakeRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTake0()
    {
        return Enumerable.Repeat(0, 100).Take(0);
    } //EndMethod

    public IEnumerable<int> RepeatTake0Rewritten()
    {
        return RepeatTake0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTakeM1()
    {
        return Enumerable.Repeat(0, 100).Take(-1);
    } //EndMethod

    public IEnumerable<int> RepeatTakeM1Rewritten()
    {
        return RepeatTakeM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTake1000()
    {
        return Enumerable.Repeat(0, 100).Take(1000);
    } //EndMethod

    public IEnumerable<int> RepeatTake1000Rewritten()
    {
        return RepeatTake1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTakeParam()
    {
        var a = 50;
        return Enumerable.Repeat(0, 100).Take(a);
    } //EndMethod

    public IEnumerable<int> RepeatTakeParamRewritten()
    {
        var a = 50;
        return RepeatTakeParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectTakeToArray()
    {
        return ArrayItems.Select(x => x + 10).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectTakeToArrayRewritten()
    {
        return ArraySelectTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectTakeM1ToArray()
    {
        var m1 = -1;
        return ArrayItems.Select(x => x + 10).Take(m1).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectTakeM1ToArrayRewritten()
    {
        var m1 = -1;
        return ArraySelectTakeM1ToArrayRewritten_ProceduralLinq1(m1, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereTakeToArray()
    {
        return ArrayItems.Where(x => x > 20).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereTakeToArrayRewritten()
    {
        return ArrayWhereTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereFalseTakeToArray()
    {
        return ArrayItems.Where(x => false).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereFalseTakeToArrayRewritten()
    {
        return ArrayWhereFalseTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeToArray()
    {
        return ArrayItems.Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeToArrayRewritten()
    {
        return ArrayTakeToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeToArray()
    {
        return EnumerableItems.Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeToArrayRewritten()
    {
        return EnumerableTakeToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeToArray()
    {
        return Enumerable.Range(0, 100).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeToArrayRewritten()
    {
        return RangeTakeToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatTakeToArray()
    {
        return Enumerable.Repeat(0, 100).Take(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RepeatTakeToArrayRewritten()
    {
        return RepeatTakeToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayTakeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2022;
        int v2023;
        if (20 < 0)
            v2023 = 0;
        else if (20 > ArrayItems.Length)
            v2023 = ArrayItems.Length;
        else
            v2023 = 20;
        v2022 = 0;
        for (; v2022 < v2023; v2022++)
            yield return ArrayItems[v2022];
    }

    System.Collections.Generic.IEnumerable<int> ArrayTake0Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2024;
        int v2025;
        if (0 < 0)
            v2025 = 0;
        else if (0 > ArrayItems.Length)
            v2025 = ArrayItems.Length;
        else
            v2025 = 0;
        v2024 = 0;
        for (; v2024 < v2025; v2024++)
            yield return ArrayItems[v2024];
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeM1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2026;
        int v2027;
        if (0 < 0)
            v2027 = 0;
        else if (0 > ArrayItems.Length)
            v2027 = ArrayItems.Length;
        else
            v2027 = 0;
        v2026 = 0;
        for (; v2026 < v2027; v2026++)
            yield return ArrayItems[v2026];
    }

    System.Collections.Generic.IEnumerable<int> ArrayTake1000Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2028;
        int v2029;
        if (1000 < 0)
            v2029 = 0;
        else if (1000 > ArrayItems.Length)
            v2029 = ArrayItems.Length;
        else
            v2029 = 1000;
        v2028 = 0;
        for (; v2028 < v2029; v2028++)
            yield return ArrayItems[v2028];
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2030;
        int v2031;
        if (a < 0)
            v2031 = 0;
        else if (a > ArrayItems.Length)
            v2031 = ArrayItems.Length;
        else
            v2031 = a;
        v2030 = 0;
        for (; v2030 < v2031; v2030++)
            yield return ArrayItems[v2030];
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2032;
        int v2033;
        v2032 = EnumerableItems.GetEnumerator();
        v2033 = 0;
        try
        {
            while (v2032.MoveNext())
            {
                if (v2033 >= 20)
                    break;
                yield return v2032.Current;
                v2033++;
            }
        }
        finally
        {
            v2032.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTake0Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2034;
        int v2035;
        v2034 = EnumerableItems.GetEnumerator();
        v2035 = 0;
        try
        {
            while (v2034.MoveNext())
            {
                if (v2035 >= 0)
                    break;
                yield return v2034.Current;
                v2035++;
            }
        }
        finally
        {
            v2034.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeM1Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2036;
        int v2037;
        v2036 = EnumerableItems.GetEnumerator();
        v2037 = 0;
        try
        {
            while (v2036.MoveNext())
            {
                if (v2037 >= 0)
                    break;
                yield return v2036.Current;
                v2037++;
            }
        }
        finally
        {
            v2036.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTake1000Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2038;
        int v2039;
        v2038 = EnumerableItems.GetEnumerator();
        v2039 = 0;
        try
        {
            while (v2038.MoveNext())
            {
                if (v2039 >= 1000)
                    break;
                yield return v2038.Current;
                v2039++;
            }
        }
        finally
        {
            v2038.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2040;
        int v2041;
        v2040 = EnumerableItems.GetEnumerator();
        v2041 = 0;
        try
        {
            while (v2040.MoveNext())
            {
                if (v2041 >= a)
                    break;
                yield return v2040.Current;
                v2041++;
            }
        }
        finally
        {
            v2040.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeRewritten_ProceduralLinq1()
    {
        int v2042;
        int v2043;
        if (20 < 0)
            v2043 = 0;
        else if (20 > 100)
            v2043 = 100;
        else
            v2043 = 20;
        v2042 = 0;
        for (; v2042 < v2043; v2042++)
            yield return (v2042 + 0);
    }

    System.Collections.Generic.IEnumerable<int> RangeTake0Rewritten_ProceduralLinq1()
    {
        int v2044;
        int v2045;
        if (0 < 0)
            v2045 = 0;
        else if (0 > 100)
            v2045 = 100;
        else
            v2045 = 0;
        v2044 = 0;
        for (; v2044 < v2045; v2044++)
            yield return (v2044 + 0);
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeM1Rewritten_ProceduralLinq1()
    {
        int v2046;
        int v2047;
        if (0 < 0)
            v2047 = 0;
        else if (0 > 100)
            v2047 = 100;
        else
            v2047 = 0;
        v2046 = 0;
        for (; v2046 < v2047; v2046++)
            yield return (v2046 + 0);
    }

    System.Collections.Generic.IEnumerable<int> RangeTake1000Rewritten_ProceduralLinq1()
    {
        int v2048;
        int v2049;
        if (1000 < 0)
            v2049 = 0;
        else if (1000 > 100)
            v2049 = 100;
        else
            v2049 = 1000;
        v2048 = 0;
        for (; v2048 < v2049; v2048++)
            yield return (v2048 + 0);
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeParamRewritten_ProceduralLinq1(int a)
    {
        int v2050;
        int v2051;
        if (a < 0)
            v2051 = 0;
        else if (a > 100)
            v2051 = 100;
        else
            v2051 = a;
        v2050 = 0;
        for (; v2050 < v2051; v2050++)
            yield return (v2050 + 0);
    }

    System.Collections.Generic.IEnumerable<int> RepeatTakeRewritten_ProceduralLinq1()
    {
        int v2052;
        int v2053;
        if (20 < 0)
            v2053 = 0;
        else if (20 > 100)
            v2053 = 100;
        else
            v2053 = 20;
        v2052 = 0;
        for (; v2052 < v2053; v2052++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTake0Rewritten_ProceduralLinq1()
    {
        int v2054;
        int v2055;
        if (0 < 0)
            v2055 = 0;
        else if (0 > 100)
            v2055 = 100;
        else
            v2055 = 0;
        v2054 = 0;
        for (; v2054 < v2055; v2054++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTakeM1Rewritten_ProceduralLinq1()
    {
        int v2056;
        int v2057;
        if (0 < 0)
            v2057 = 0;
        else if (0 > 100)
            v2057 = 100;
        else
            v2057 = 0;
        v2056 = 0;
        for (; v2056 < v2057; v2056++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTake1000Rewritten_ProceduralLinq1()
    {
        int v2058;
        int v2059;
        if (1000 < 0)
            v2059 = 0;
        else if (1000 > 100)
            v2059 = 100;
        else
            v2059 = 1000;
        v2058 = 0;
        for (; v2058 < v2059; v2058++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> RepeatTakeParamRewritten_ProceduralLinq1(int a)
    {
        int v2060;
        int v2061;
        if (a < 0)
            v2061 = 0;
        else if (a > 100)
            v2061 = 100;
        else
            v2061 = a;
        v2060 = 0;
        for (; v2060 < v2061; v2060++)
            yield return 0;
    }

    int[] ArraySelectTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2062;
        int v2063;
        if (20 < 0)
            v2063 = 0;
        else if (20 > ArrayItems.Length)
            v2063 = ArrayItems.Length;
        else
            v2063 = 20;
        int[] v2064;
        int v2065;
        v2064 = new int[v2063];
        v2065 = 0;
        v2062 = 0;
        for (; v2062 < v2063; v2062++)
        {
            v2064[v2065] = (ArrayItems[v2062] + 10);
            v2065++;
        }

        return v2064;
    }

    int[] ArraySelectTakeM1ToArrayRewritten_ProceduralLinq1(int m1, int[] ArrayItems)
    {
        int v2066;
        int v2067;
        if (m1 < 0)
            v2067 = 0;
        else if (m1 > ArrayItems.Length)
            v2067 = ArrayItems.Length;
        else
            v2067 = m1;
        int[] v2068;
        int v2069;
        v2068 = new int[v2067];
        v2069 = 0;
        v2066 = 0;
        for (; v2066 < v2067; v2066++)
        {
            v2068[v2069] = (ArrayItems[v2066] + 10);
            v2069++;
        }

        return v2068;
    }

    int[] ArrayWhereTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2070;
        int v2071;
        int v2072;
        int v2073;
        int v2074;
        int[] v2075;
        v2071 = 0;
        v2072 = 0;
        v2073 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2073 -= (v2073 % 2);
        v2074 = 8;
        v2075 = new int[8];
        v2070 = 0;
        for (; v2070 < ArrayItems.Length; v2070++)
        {
            if (!((ArrayItems[v2070] > 20)))
                continue;
            if (v2071 >= 20)
                break;
            if (v2072 >= v2074)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2075, ref v2073, out v2074);
            v2075[v2072] = ArrayItems[v2070];
            v2071++;
            v2072++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2075, v2072);
    }

    int[] ArrayWhereFalseTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2076;
        int v2077;
        int v2078;
        int v2079;
        int v2080;
        int[] v2081;
        v2077 = 0;
        v2078 = 0;
        v2079 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2079 -= (v2079 % 2);
        v2080 = 8;
        v2081 = new int[8];
        v2076 = 0;
        for (; v2076 < ArrayItems.Length; v2076++)
        {
            if (!((false)))
                continue;
            if (v2077 >= 20)
                break;
            if (v2078 >= v2080)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2081, ref v2079, out v2080);
            v2081[v2078] = ArrayItems[v2076];
            v2077++;
            v2078++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2081, v2078);
    }

    int[] ArrayTakeToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2082;
        int v2083;
        if (20 < 0)
            v2083 = 0;
        else if (20 > ArrayItems.Length)
            v2083 = ArrayItems.Length;
        else
            v2083 = 20;
        int[] v2084;
        v2084 = new int[v2083];
        System.Array.Copy(ArrayItems, 0, v2084, 0, (v2083 - 0));
        return v2084;
    }

    int[] EnumerableTakeToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2085;
        int v2086;
        int v2087;
        int v2088;
        int[] v2089;
        v2085 = EnumerableItems.GetEnumerator();
        v2086 = 0;
        v2087 = 0;
        v2088 = 8;
        v2089 = new int[8];
        try
        {
            while (v2085.MoveNext())
            {
                if (v2086 >= 20)
                    break;
                if (v2087 >= v2088)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2089, ref v2088);
                v2089[v2087] = v2085.Current;
                v2086++;
                v2087++;
            }
        }
        finally
        {
            v2085.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2089, v2087);
    }

    int[] RangeTakeToArrayRewritten_ProceduralLinq1()
    {
        int v2090;
        int v2091;
        if (20 < 0)
            v2091 = 0;
        else if (20 > 100)
            v2091 = 100;
        else
            v2091 = 20;
        int[] v2092;
        int v2093;
        v2092 = new int[v2091];
        v2093 = 0;
        v2090 = 0;
        for (; v2090 < v2091; v2090++)
        {
            v2092[v2093] = (v2090 + 0);
            v2093++;
        }

        return v2092;
    }

    int[] RepeatTakeToArrayRewritten_ProceduralLinq1()
    {
        int v2094;
        int v2095;
        if (20 < 0)
            v2095 = 0;
        else if (20 > 100)
            v2095 = 100;
        else
            v2095 = 20;
        int[] v2096;
        int v2097;
        v2096 = new int[v2095];
        v2097 = 0;
        v2094 = 0;
        for (; v2094 < v2095; v2094++)
        {
            v2096[v2097] = 0;
            v2097++;
        }

        return v2096;
    }
}}