using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class SkipTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArraySkip), ArraySkip, ArraySkipRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkip0), ArraySkip0, ArraySkip0Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipM1), ArraySkipM1, ArraySkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkip1000), ArraySkip1000, ArraySkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipParam), ArraySkipParam, ArraySkipParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkip), EnumerableSkip, EnumerableSkipRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkip0), EnumerableSkip0, EnumerableSkip0Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipM1), EnumerableSkipM1, EnumerableSkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkip1000), EnumerableSkip1000, EnumerableSkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipParam), EnumerableSkipParam, EnumerableSkipParamRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkip), RangeSkip, RangeSkipRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkip0), RangeSkip0, RangeSkip0Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipM1), RangeSkipM1, RangeSkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkip1000), RangeSkip1000, RangeSkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipParam), RangeSkipParam, RangeSkipParamRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkip), RepeatSkip, RepeatSkipRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkip0), RepeatSkip0, RepeatSkip0Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkipM1), RepeatSkipM1, RepeatSkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkip1000), RepeatSkip1000, RepeatSkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkipParam), RepeatSkipParam, RepeatSkipParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSkipToArray), ArraySelectSkipToArray, ArraySelectSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSkipM1ToArray), ArraySelectSkipM1ToArray, ArraySelectSkipM1ToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereSkipToArray), ArrayWhereSkipToArray, ArrayWhereSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereFalseSkipToArray), ArrayWhereFalseSkipToArray, ArrayWhereFalseSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipToArray), ArraySkipToArray, ArraySkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipToArray), EnumerableSkipToArray, EnumerableSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipToArray), RangeSkipToArray, RangeSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkipToArray), RepeatSkipToArray, RepeatSkipToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArraySkip()
    {
        return ArrayItems.Skip(20);
    } //EndMethod

    public IEnumerable<int> ArraySkipRewritten()
    {
        return ArraySkipRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkip0()
    {
        return ArrayItems.Skip(0);
    } //EndMethod

    public IEnumerable<int> ArraySkip0Rewritten()
    {
        return ArraySkip0Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipM1()
    {
        return ArrayItems.Skip(-1);
    } //EndMethod

    public IEnumerable<int> ArraySkipM1Rewritten()
    {
        return ArraySkipM1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkip1000()
    {
        return ArrayItems.Skip(1000);
    } //EndMethod

    public IEnumerable<int> ArraySkip1000Rewritten()
    {
        return ArraySkip1000Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipParam()
    {
        var a = 50;
        return ArrayItems.Skip(a);
    } //EndMethod

    public IEnumerable<int> ArraySkipParamRewritten()
    {
        var a = 50;
        return ArraySkipParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkip()
    {
        return EnumerableItems.Skip(20);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipRewritten()
    {
        return EnumerableSkipRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkip0()
    {
        return EnumerableItems.Skip(0);
    } //EndMethod

    public IEnumerable<int> EnumerableSkip0Rewritten()
    {
        return EnumerableSkip0Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipM1()
    {
        return EnumerableItems.Skip(-1);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipM1Rewritten()
    {
        return EnumerableSkipM1Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkip1000()
    {
        return EnumerableItems.Skip(1000);
    } //EndMethod

    public IEnumerable<int> EnumerableSkip1000Rewritten()
    {
        return EnumerableSkip1000Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipParam()
    {
        var a = 50;
        return EnumerableItems.Skip(a);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipParamRewritten()
    {
        var a = 50;
        return EnumerableSkipParamRewritten_ProceduralLinq1(a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkip()
    {
        return Enumerable.Range(0, 100).Skip(20);
    } //EndMethod

    public IEnumerable<int> RangeSkipRewritten()
    {
        return RangeSkipRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkip0()
    {
        return Enumerable.Range(0, 100).Skip(0);
    } //EndMethod

    public IEnumerable<int> RangeSkip0Rewritten()
    {
        return RangeSkip0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipM1()
    {
        return Enumerable.Range(0, 100).Skip(-1);
    } //EndMethod

    public IEnumerable<int> RangeSkipM1Rewritten()
    {
        return RangeSkipM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkip1000()
    {
        return Enumerable.Range(0, 100).Skip(1000);
    } //EndMethod

    public IEnumerable<int> RangeSkip1000Rewritten()
    {
        return RangeSkip1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipParam()
    {
        var a = 50;
        return Enumerable.Range(0, 100).Skip(a);
    } //EndMethod

    public IEnumerable<int> RangeSkipParamRewritten()
    {
        var a = 50;
        return RangeSkipParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkip()
    {
        return Enumerable.Repeat(0, 100).Skip(20);
    } //EndMethod

    public IEnumerable<int> RepeatSkipRewritten()
    {
        return RepeatSkipRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkip0()
    {
        return Enumerable.Repeat(0, 100).Skip(0);
    } //EndMethod

    public IEnumerable<int> RepeatSkip0Rewritten()
    {
        return RepeatSkip0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkipM1()
    {
        return Enumerable.Repeat(0, 100).Skip(-1);
    } //EndMethod

    public IEnumerable<int> RepeatSkipM1Rewritten()
    {
        return RepeatSkipM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkip1000()
    {
        return Enumerable.Repeat(0, 100).Skip(1000);
    } //EndMethod

    public IEnumerable<int> RepeatSkip1000Rewritten()
    {
        return RepeatSkip1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkipParam()
    {
        var a = 50;
        return Enumerable.Repeat(0, 100).Skip(a);
    } //EndMethod

    public IEnumerable<int> RepeatSkipParamRewritten()
    {
        var a = 50;
        return RepeatSkipParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectSkipToArray()
    {
        return ArrayItems.Select(x => x + 10).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectSkipToArrayRewritten()
    {
        return ArraySelectSkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectSkipM1ToArray()
    {
        return ArrayItems.Select(x => x + 10).Skip(-1).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectSkipM1ToArrayRewritten()
    {
        return ArraySelectSkipM1ToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereSkipToArray()
    {
        return ArrayItems.Where(x => x > 20).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereSkipToArrayRewritten()
    {
        return ArrayWhereSkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereFalseSkipToArray()
    {
        return ArrayItems.Where(x => false).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereFalseSkipToArrayRewritten()
    {
        return ArrayWhereFalseSkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipToArray()
    {
        return ArrayItems.Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipToArrayRewritten()
    {
        return ArraySkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipToArray()
    {
        return EnumerableItems.Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipToArrayRewritten()
    {
        return EnumerableSkipToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipToArray()
    {
        return Enumerable.Range(0, 100).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipToArrayRewritten()
    {
        return RangeSkipToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkipToArray()
    {
        return Enumerable.Repeat(0, 100).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RepeatSkipToArrayRewritten()
    {
        return RepeatSkipToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArraySkipRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1876;
        v1876 = (20);
        for (; v1876 < (ArrayItems.Length); v1876 += 1)
            yield return (ArrayItems[v1876]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkip0Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1878;
        v1878 = (0);
        for (; v1878 < (ArrayItems.Length); v1878 += 1)
            yield return (ArrayItems[v1878]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipM1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1880;
        v1880 = (0);
        for (; v1880 < (ArrayItems.Length); v1880 += 1)
            yield return (ArrayItems[v1880]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkip1000Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1882;
        v1882 = (1000);
        for (; v1882 < (ArrayItems.Length); v1882 += 1)
            yield return (ArrayItems[v1882]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1885;
        int v1886;
        v1886 = a < 0 ? a : 0;
        v1886 = a;
        v1885 = (v1886);
        for (; v1885 < (ArrayItems.Length); v1885 += 1)
            yield return (ArrayItems[v1885]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1887;
        int v1888;
        v1887 = EnumerableItems.GetEnumerator();
        v1888 = 0;
        try
        {
            while (v1887.MoveNext())
            {
                if (v1888 < 20)
                {
                    v1888++;
                    continue;
                }

                yield return (v1887.Current);
                v1888++;
            }
        }
        finally
        {
            v1887.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkip0Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1889;
        int v1890;
        v1889 = EnumerableItems.GetEnumerator();
        v1890 = 0;
        try
        {
            while (v1889.MoveNext())
            {
                if (v1890 < 0)
                {
                    v1890++;
                    continue;
                }

                yield return (v1889.Current);
                v1890++;
            }
        }
        finally
        {
            v1889.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipM1Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1891;
        v1891 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1891.MoveNext())
                yield return (v1891.Current);
        }
        finally
        {
            v1891.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkip1000Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1892;
        int v1893;
        v1892 = EnumerableItems.GetEnumerator();
        v1893 = 0;
        try
        {
            while (v1892.MoveNext())
            {
                if (v1893 < 1000)
                {
                    v1893++;
                    continue;
                }

                yield return (v1892.Current);
                v1893++;
            }
        }
        finally
        {
            v1892.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1894;
        int v1895;
        v1894 = EnumerableItems.GetEnumerator();
        v1895 = 0;
        try
        {
            while (v1894.MoveNext())
            {
                if (v1895 < a)
                {
                    v1895++;
                    continue;
                }

                yield return (v1894.Current);
                v1895++;
            }
        }
        finally
        {
            v1894.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipRewritten_ProceduralLinq1()
    {
        int v1896;
        v1896 = (20);
        for (; v1896 < (100); v1896 += (1))
            yield return (v1896);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkip0Rewritten_ProceduralLinq1()
    {
        int v1897;
        v1897 = (0);
        for (; v1897 < (100); v1897 += (1))
            yield return (v1897);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipM1Rewritten_ProceduralLinq1()
    {
        int v1898;
        v1898 = (0);
        for (; v1898 < (100); v1898 += (1))
            yield return (v1898);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkip1000Rewritten_ProceduralLinq1()
    {
        int v1899;
        v1899 = (1000);
        for (; v1899 < (100); v1899 += (1))
            yield return (v1899);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipParamRewritten_ProceduralLinq1(int a)
    {
        int v1900;
        int v1901;
        v1901 = a < 0 ? a : 0;
        v1901 = a;
        v1900 = (v1901);
        for (; v1900 < (100); v1900 += (1))
            yield return (v1900);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkipRewritten_ProceduralLinq1()
    {
        int v1902;
        v1902 = (20);
        for (; v1902 < (100); v1902 += 1)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkip0Rewritten_ProceduralLinq1()
    {
        int v1903;
        v1903 = (0);
        for (; v1903 < (100); v1903 += 1)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkipM1Rewritten_ProceduralLinq1()
    {
        int v1904;
        v1904 = (0);
        for (; v1904 < (100); v1904 += 1)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkip1000Rewritten_ProceduralLinq1()
    {
        int v1905;
        v1905 = (1000);
        for (; v1905 < (100); v1905 += 1)
            yield return (0);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkipParamRewritten_ProceduralLinq1(int a)
    {
        int v1906;
        int v1907;
        v1907 = a < 0 ? a : 0;
        v1907 = a;
        v1906 = (v1907);
        for (; v1906 < (100); v1906 += 1)
            yield return (0);
        yield break;
    }

    int[] ArraySelectSkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1909;
        int[] v1910;
        int v1911;
        v1910 = new int[(-20 + ArrayItems.Length)];
        v1911 = 0;
        v1909 = (20);
        for (; v1909 < (ArrayItems.Length); v1909 += 1)
        {
            v1910[v1911] = (10 + ArrayItems[v1909]);
            v1911++;
        }

        return v1910;
    }

    int[] ArraySelectSkipM1ToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1913;
        int[] v1914;
        v1914 = new int[(ArrayItems.Length)];
        v1913 = (0);
        for (; v1913 < (ArrayItems.Length); v1913 += 1)
            v1914[v1913] = (10 + ArrayItems[v1913]);
        return v1914;
    }

    int[] ArrayWhereSkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1915;
        int v1916;
        int v1917;
        int v1918;
        int v1919;
        int[] v1920;
        v1916 = 0;
        v1917 = 0;
        v1918 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v1918 -= (v1918 % 2);
        v1919 = 8;
        v1920 = new int[8];
        v1915 = (0);
        for (; v1915 < (ArrayItems.Length); v1915 += 1)
        {
            if (!((((ArrayItems[v1915])) > 20)))
                continue;
            if (v1916 < 20)
            {
                v1916++;
                continue;
            }

            if (v1917 >= v1919)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v1920, ref v1918, out v1919);
            v1920[v1917] = ((ArrayItems[v1915]));
            v1916++;
            v1917++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1920, v1917);
    }

    int[] ArrayWhereFalseSkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1921;
        int v1922;
        int v1923;
        int v1924;
        int v1925;
        int[] v1926;
        v1922 = 0;
        v1923 = 0;
        v1924 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v1924 -= (v1924 % 2);
        v1925 = 8;
        v1926 = new int[8];
        v1921 = (0);
        for (; v1921 < (ArrayItems.Length); v1921 += 1)
        {
            if (!((false)))
                continue;
            if (v1922 < 20)
            {
                v1922++;
                continue;
            }

            if (v1923 >= v1925)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v1926, ref v1924, out v1925);
            v1926[v1923] = ((ArrayItems[v1921]));
            v1922++;
            v1923++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1926, v1923);
    }

    int[] ArraySkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1928;
        int[] v1929;
        v1929 = new int[(-20 + ArrayItems.Length)];
        System.Array.Copy(ArrayItems, (20), v1929, 0, (-20 + ArrayItems.Length));
        return v1929;
    }

    int[] EnumerableSkipToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1930;
        int v1931;
        int v1932;
        int v1933;
        int[] v1934;
        v1930 = EnumerableItems.GetEnumerator();
        v1931 = 0;
        v1932 = 0;
        v1933 = 8;
        v1934 = new int[8];
        try
        {
            while (v1930.MoveNext())
            {
                if (v1931 < 20)
                {
                    v1931++;
                    continue;
                }

                if (v1932 >= v1933)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1934, ref v1933);
                v1934[v1932] = (v1930.Current);
                v1931++;
                v1932++;
            }
        }
        finally
        {
            v1930.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1934, v1932);
    }

    int[] RangeSkipToArrayRewritten_ProceduralLinq1()
    {
        int v1935;
        int[] v1936;
        int v1937;
        v1936 = new int[(80)];
        v1937 = 0;
        v1935 = (20);
        for (; v1935 < (100); v1935 += (1))
        {
            v1936[v1937] = (v1935);
            v1937++;
        }

        return v1936;
    }

    int[] RepeatSkipToArrayRewritten_ProceduralLinq1()
    {
        int v1938;
        int[] v1939;
        int v1940;
        v1939 = new int[(80)];
        v1940 = 0;
        v1938 = (20);
        for (; v1938 < (100); v1938 += 1)
        {
            v1939[v1940] = (0);
            v1940++;
        }

        return v1939;
    }
}}