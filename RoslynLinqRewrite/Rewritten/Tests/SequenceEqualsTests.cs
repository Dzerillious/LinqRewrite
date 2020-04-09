using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class SequenceEqualTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private int[] ArrayItems2 = Enumerable.Range(30, 130).ToArray();
    [Datapoints]
    private SimpleList<int> SimpleListItems = Enumerable.Range(10, 110).ToSimpleList();
    [Datapoints]
    private SimpleList<int> SimpleListItems2 = Enumerable.Range(40, 140).ToSimpleList();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(20, 120);
    [Datapoints]
    private IEnumerable<int> EnumerableItems2 = Enumerable.Range(50, 150);
    private IEnumerable<int> MethodEnumerable()
    {
        for (int i = 25; i < 125; i++)
        {
            yield return i;
        }
    }

    private IEnumerable<int> MethodEnumerable2()
    {
        for (int i = 55; i < 155; i++)
        {
            yield return i;
        }
    }

    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualArray), ArraySequenceEqualArray, ArraySequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualSimpleList), ArraySequenceEqualSimpleList, ArraySequenceEqualSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualEnumerable), ArraySequenceEqualEnumerable, ArraySequenceEqualEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualMethod), ArraySequenceEqualMethod, ArraySequenceEqualMethodRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualArray), SimpleListSequenceEqualArray, SimpleListSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualSimpleList), SimpleListSequenceEqualSimpleList, SimpleListSequenceEqualSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualEnumerable), SimpleListSequenceEqualEnumerable, SimpleListSequenceEqualEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualMethod), SimpleListSequenceEqualMethod, SimpleListSequenceEqualMethodRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualArray), EnumerableSequenceEqualArray, EnumerableSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualSimpleList), EnumerableSequenceEqualSimpleList, EnumerableSequenceEqualSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualEnumerable), EnumerableSequenceEqualEnumerable, EnumerableSequenceEqualEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualMethod), EnumerableSequenceEqualMethod, EnumerableSequenceEqualMethodRewritten);
        TestsExtensions.TestEquals(nameof(MethodSequenceEqualArray), MethodSequenceEqualArray, MethodSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(MethodSequenceEqualSimpleList), MethodSequenceEqualSimpleList, MethodSequenceEqualSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(MethodSequenceEqualEnumerable), MethodSequenceEqualEnumerable, MethodSequenceEqualEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(MethodSequenceEqualMethod), MethodSequenceEqualMethod, MethodSequenceEqualMethodRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSequenceEqualArray), ArraySelectSequenceEqualArray, ArraySelectSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSequenceEqualArraySelect), ArraySelectSequenceEqualArraySelect, ArraySelectSequenceEqualArraySelectRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereSequenceEqualArrayWhere), ArrayWhereSequenceEqualArrayWhere, ArrayWhereSequenceEqualArrayWhereRewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereArraySequenceEqualSelectWhereArray), SelectWhereArraySequenceEqualSelectWhereArray, SelectWhereArraySequenceEqualSelectWhereArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSequenceEqualArray), RangeSequenceEqualArray, RangeSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSequenceEqualArray), RepeatSequenceEqualArray, RepeatSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(EmptySequenceEqualArray), EmptySequenceEqualArray, EmptySequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeEmpty2Array), RangeEmpty2Array, RangeEmpty2ArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualRange), ArraySequenceEqualRange, ArraySequenceEqualRangeRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualRepeat), ArraySequenceEqualRepeat, ArraySequenceEqualRepeatRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualEmpty), ArraySequenceEqualEmpty, ArraySequenceEqualEmptyRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualEmpty2), ArraySequenceEqualEmpty2, ArraySequenceEqualEmpty2Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualAll), ArraySequenceEqualAll, ArraySequenceEqualAllRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualNull), ArraySequenceEqualNull, ArraySequenceEqualNullRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctSequenceEqualArrayDistinct), ArrayDistinctSequenceEqualArrayDistinct, ArrayDistinctSequenceEqualArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctSequenceEqualArrayDistinct2), ArrayDistinctSequenceEqualArrayDistinct, ArrayDistinctSequenceEqualArrayDistinct2Rewritten);
    }

    [NoRewrite]
    public bool ArraySequenceEqualArray()
    {
        return ArrayItems.SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool ArraySequenceEqualArrayRewritten()
    {
        return ArraySequenceEqualArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualSimpleList()
    {
        return ArrayItems.SequenceEqual(SimpleListItems2);
    } //EndMethod

    public bool ArraySequenceEqualSimpleListRewritten()
    {
        return ArraySequenceEqualSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualEnumerable()
    {
        return ArrayItems.SequenceEqual(EnumerableItems2);
    } //EndMethod

    public bool ArraySequenceEqualEnumerableRewritten()
    {
        return ArraySequenceEqualEnumerableRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualMethod()
    {
        return ArrayItems.SequenceEqual(MethodEnumerable2());
    } //EndMethod

    public bool ArraySequenceEqualMethodRewritten()
    {
        return ArraySequenceEqualMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool SimpleListSequenceEqualArray()
    {
        return SimpleListItems.SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool SimpleListSequenceEqualArrayRewritten()
    {
        return SimpleListSequenceEqualArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public bool SimpleListSequenceEqualSimpleList()
    {
        return SimpleListItems.SequenceEqual(SimpleListItems2);
    } //EndMethod

    public bool SimpleListSequenceEqualSimpleListRewritten()
    {
        return SimpleListSequenceEqualSimpleListRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public bool SimpleListSequenceEqualEnumerable()
    {
        return SimpleListItems.SequenceEqual(EnumerableItems2);
    } //EndMethod

    public bool SimpleListSequenceEqualEnumerableRewritten()
    {
        return SimpleListSequenceEqualEnumerableRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public bool SimpleListSequenceEqualMethod()
    {
        return SimpleListItems.SequenceEqual(MethodEnumerable2());
    } //EndMethod

    public bool SimpleListSequenceEqualMethodRewritten()
    {
        return SimpleListSequenceEqualMethodRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableSequenceEqualArray()
    {
        return EnumerableItems.SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool EnumerableSequenceEqualArrayRewritten()
    {
        return EnumerableSequenceEqualArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableSequenceEqualSimpleList()
    {
        return EnumerableItems.SequenceEqual(SimpleListItems2);
    } //EndMethod

    public bool EnumerableSequenceEqualSimpleListRewritten()
    {
        return EnumerableSequenceEqualSimpleListRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableSequenceEqualEnumerable()
    {
        return EnumerableItems.SequenceEqual(EnumerableItems2);
    } //EndMethod

    public bool EnumerableSequenceEqualEnumerableRewritten()
    {
        return EnumerableSequenceEqualEnumerableRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableSequenceEqualMethod()
    {
        return EnumerableItems.SequenceEqual(MethodEnumerable2());
    } //EndMethod

    public bool EnumerableSequenceEqualMethodRewritten()
    {
        return EnumerableSequenceEqualMethodRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool MethodSequenceEqualArray()
    {
        return MethodEnumerable().SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool MethodSequenceEqualArrayRewritten()
    {
        return MethodEnumerable().SequenceEqual(ArrayItems2);
    } //EndMethod

    [NoRewrite]
    public bool MethodSequenceEqualSimpleList()
    {
        return MethodEnumerable().SequenceEqual(SimpleListItems2);
    } //EndMethod

    public bool MethodSequenceEqualSimpleListRewritten()
    {
        return MethodEnumerable().SequenceEqual(SimpleListItems2);
    } //EndMethod

    [NoRewrite]
    public bool MethodSequenceEqualEnumerable()
    {
        return MethodEnumerable().SequenceEqual(EnumerableItems2);
    } //EndMethod

    public bool MethodSequenceEqualEnumerableRewritten()
    {
        return MethodEnumerable().SequenceEqual(EnumerableItems2);
    } //EndMethod

    [NoRewrite]
    public bool MethodSequenceEqualMethod()
    {
        return MethodEnumerable().SequenceEqual(MethodEnumerable2());
    } //EndMethod

    public bool MethodSequenceEqualMethodRewritten()
    {
        return MethodEnumerable().SequenceEqual(MethodEnumerable2());
    } //EndMethod

    [NoRewrite]
    public bool ArraySelectSequenceEqualArray()
    {
        return ArrayItems.Select(x => x + 50).SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool ArraySelectSequenceEqualArrayRewritten()
    {
        return ArraySelectSequenceEqualArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySelectSequenceEqualArraySelect()
    {
        return ArrayItems.Select(x => x + 50).SequenceEqual(ArrayItems2.Select(x => x + 50));
    } //EndMethod

    public bool ArraySelectSequenceEqualArraySelectRewritten()
    {
        return ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayWhereSequenceEqualArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).SequenceEqual(ArrayItems2.Where(x => x > 50));
    } //EndMethod

    public bool ArrayWhereSequenceEqualArrayWhereRewritten()
    {
        return ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool SelectWhereArraySequenceEqualSelectWhereArray()
    {
        return ArrayItems.Select(x => x + 10).Where(x => x > 80).SequenceEqual(ArrayItems2.Select(x => x + 10).Where(x => x > 80));
    } //EndMethod

    public bool SelectWhereArraySequenceEqualSelectWhereArrayRewritten()
    {
        return SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool RangeSequenceEqualArray()
    {
        return Enumerable.Range(20, 100).SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool RangeSequenceEqualArrayRewritten()
    {
        return RangeSequenceEqualArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public bool RepeatSequenceEqualArray()
    {
        return Enumerable.Repeat(20, 100).SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool RepeatSequenceEqualArrayRewritten()
    {
        return RepeatSequenceEqualArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public bool EmptySequenceEqualArray()
    {
        return Enumerable.Empty<int>().SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool EmptySequenceEqualArrayRewritten()
    {
        return EmptySequenceEqualArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public bool RangeEmpty2Array()
    {
        return ArrayItems.Where(x => false).SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool RangeEmpty2ArrayRewritten()
    {
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualRange()
    {
        return ArrayItems.SequenceEqual(Enumerable.Range(70, 260));
    } //EndMethod

    public bool ArraySequenceEqualRangeRewritten()
    {
        return ArraySequenceEqualRangeRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualRepeat()
    {
        return ArrayItems.SequenceEqual(Enumerable.Repeat(70, 100));
    } //EndMethod

    public bool ArraySequenceEqualRepeatRewritten()
    {
        return ArraySequenceEqualRepeatRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualEmpty()
    {
        return ArrayItems.SequenceEqual(Enumerable.Empty<int>());
    } //EndMethod

    public bool ArraySequenceEqualEmptyRewritten()
    {
        return ArraySequenceEqualEmptyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualEmpty2()
    {
        return ArrayItems.SequenceEqual(ArrayItems2.Where(x => false));
    } //EndMethod

    public bool ArraySequenceEqualEmpty2Rewritten()
    {
        return ArraySequenceEqualEmpty2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualAll()
    {
        return ArrayItems.SequenceEqual(Enumerable.Range(0, 1000));
    } //EndMethod

    public bool ArraySequenceEqualAllRewritten()
    {
        return ArraySequenceEqualAllRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualNull()
    {
        return ArrayItems.SequenceEqual(null);
    } //EndMethod

    public bool ArraySequenceEqualNullRewritten()
    {
        return ArraySequenceEqualNullRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayDistinctSequenceEqualArrayDistinct()
    {
        return ArrayItems.Distinct().SequenceEqual(ArrayItems.Distinct());
    } //EndMethod

    public bool ArrayDistinctSequenceEqualArrayDistinctRewritten()
    {
        return ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayDistinctSequenceEqualArrayDistinct2()
    {
        return ArrayItems.Distinct(EqualityComparer<int>.Default).SequenceEqual(ArrayItems.Distinct(EqualityComparer<int>.Default));
    } //EndMethod

    public bool ArrayDistinctSequenceEqualArrayDistinct2Rewritten()
    {
        return ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    bool ArraySequenceEqualArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1896;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1897;
        v1897 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1896 = (0);
            for (; v1896 < (ArrayItems.Length); v1896++)
                if (!((v1897.MoveNext()) && v1897.Current.Equals((ArrayItems[v1896]))))
                    return false;
            if (v1897.MoveNext())
                return false;
        }
        finally
        {
            v1897.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1899;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1900;
        v1900 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        try
        {
            v1899 = (0);
            for (; v1899 < (ArrayItems.Length); v1899++)
                if (!((v1900.MoveNext()) && v1900.Current.Equals((ArrayItems[v1899]))))
                    return false;
            if (v1900.MoveNext())
                return false;
        }
        finally
        {
            v1900.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1902;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1903;
        v1903 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        try
        {
            v1902 = (0);
            for (; v1902 < (ArrayItems.Length); v1902++)
                if (!((v1903.MoveNext()) && v1903.Current.Equals((ArrayItems[v1902]))))
                    return false;
            if (v1903.MoveNext())
                return false;
        }
        finally
        {
            v1903.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1905;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1906;
        v1906 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        try
        {
            v1905 = (0);
            for (; v1905 < (ArrayItems.Length); v1905++)
                if (!((v1906.MoveNext()) && v1906.Current.Equals((ArrayItems[v1905]))))
                    return false;
            if (v1906.MoveNext())
                return false;
        }
        finally
        {
            v1906.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1908;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1909;
        int v1910;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1911;
        v1911 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1908 = SimpleListItems.Count;
            v1909 = SimpleListItems;
            v1910 = (0);
            for (; v1910 < (v1908); v1910++)
                if (!((v1911.MoveNext()) && v1911.Current.Equals((v1909[v1910]))))
                    return false;
            if (v1911.MoveNext())
                return false;
        }
        finally
        {
            v1911.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1913;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1914;
        int v1915;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1916;
        v1916 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        try
        {
            v1913 = SimpleListItems.Count;
            v1914 = SimpleListItems;
            v1915 = (0);
            for (; v1915 < (v1913); v1915++)
                if (!((v1916.MoveNext()) && v1916.Current.Equals((v1914[v1915]))))
                    return false;
            if (v1916.MoveNext())
                return false;
        }
        finally
        {
            v1916.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1918;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1919;
        int v1920;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1921;
        v1921 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        try
        {
            v1918 = SimpleListItems.Count;
            v1919 = SimpleListItems;
            v1920 = (0);
            for (; v1920 < (v1918); v1920++)
                if (!((v1921.MoveNext()) && v1921.Current.Equals((v1919[v1920]))))
                    return false;
            if (v1921.MoveNext())
                return false;
        }
        finally
        {
            v1921.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1923;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1924;
        int v1925;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1926;
        v1926 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        try
        {
            v1923 = SimpleListItems.Count;
            v1924 = SimpleListItems;
            v1925 = (0);
            for (; v1925 < (v1923); v1925++)
                if (!((v1926.MoveNext()) && v1926.Current.Equals((v1924[v1925]))))
                    return false;
            if (v1926.MoveNext())
                return false;
        }
        finally
        {
            v1926.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1927;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1928;
        v1928 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        v1927 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1927.MoveNext())
                    if (!((v1928.MoveNext()) && v1928.Current.Equals((v1927.Current))))
                        return false;
            }
            finally
            {
                v1927.Dispose();
            }

            if (v1928.MoveNext())
                return false;
        }
        finally
        {
            v1928.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1929;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1930;
        v1930 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        v1929 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1929.MoveNext())
                    if (!((v1930.MoveNext()) && v1930.Current.Equals((v1929.Current))))
                        return false;
            }
            finally
            {
                v1929.Dispose();
            }

            if (v1930.MoveNext())
                return false;
        }
        finally
        {
            v1930.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1931;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1932;
        v1932 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        v1931 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1931.MoveNext())
                    if (!((v1932.MoveNext()) && v1932.Current.Equals((v1931.Current))))
                        return false;
            }
            finally
            {
                v1931.Dispose();
            }

            if (v1932.MoveNext())
                return false;
        }
        finally
        {
            v1932.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1933;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1934;
        v1934 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        v1933 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1933.MoveNext())
                    if (!((v1934.MoveNext()) && v1934.Current.Equals((v1933.Current))))
                        return false;
            }
            finally
            {
                v1933.Dispose();
            }

            if (v1934.MoveNext())
                return false;
        }
        finally
        {
            v1934.Dispose();
        }

        return true;
    }

    bool ArraySelectSequenceEqualArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1936;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1937;
        v1937 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1936 = (0);
            for (; v1936 < (ArrayItems.Length); v1936++)
                if (!((v1937.MoveNext()) && v1937.Current.Equals((50 + ArrayItems[v1936]))))
                    return false;
            if (v1937.MoveNext())
                return false;
        }
        finally
        {
            v1937.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1939;
        v1939 = (0);
        for (; v1939 < (ArrayItems2.Length); v1939++)
            yield return (((ArrayItems2[v1939]) + 50));
        yield break;
    }

    bool ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1941;
        if (ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1942;
        v1942 = ((IEnumerable<int>)ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1941 = (0);
            for (; v1941 < (ArrayItems.Length); v1941++)
                if (!((v1942.MoveNext()) && v1942.Current.Equals((50 + ArrayItems[v1941]))))
                    return false;
            if (v1942.MoveNext())
                return false;
        }
        finally
        {
            v1942.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1943;
        int v1944;
        v1943 = (0);
        for (; v1943 < (ArrayItems2.Length); v1943++)
        {
            v1944 = (ArrayItems2[v1943]);
            if (!(((v1944) > 50)))
                continue;
            yield return (v1944);
        }

        yield break;
    }

    bool ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1945;
        int v1946;
        if (ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1947;
        v1947 = ((IEnumerable<int>)ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1945 = (0);
            for (; v1945 < (ArrayItems.Length); v1945++)
            {
                v1946 = (ArrayItems[v1945]);
                if (!(((v1946) > 50)))
                    continue;
                if (!((v1947.MoveNext()) && v1947.Current.Equals((v1946))))
                    return false;
            }

            if (v1947.MoveNext())
                return false;
        }
        finally
        {
            v1947.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1948;
        int v1949;
        v1948 = (0);
        for (; v1948 < (ArrayItems2.Length); v1948++)
        {
            v1949 = (((ArrayItems2[v1948]) + 10));
            if (!(((v1949) > 80)))
                continue;
            yield return (v1949);
        }

        yield break;
    }

    bool SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1950;
        int v1951;
        if (SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1952;
        v1952 = ((IEnumerable<int>)SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1950 = (0);
            for (; v1950 < (ArrayItems.Length); v1950++)
            {
                v1951 = (10 + ArrayItems[v1950]);
                if (!(((v1951) > 80)))
                    continue;
                if (!((v1952.MoveNext()) && v1952.Current.Equals((v1951))))
                    return false;
            }

            if (v1952.MoveNext())
                return false;
        }
        finally
        {
            v1952.Dispose();
        }

        return true;
    }

    bool RangeSequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1953;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1954;
        v1954 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1953 = (0);
            for (; v1953 < (100); v1953++)
                if (!((v1954.MoveNext()) && v1954.Current.Equals((20 + v1953))))
                    return false;
            if (v1954.MoveNext())
                return false;
        }
        finally
        {
            v1954.Dispose();
        }

        return true;
    }

    bool RepeatSequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1955;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1956;
        v1956 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1955 = (0);
            for (; v1955 < (100); v1955++)
                if (!((v1956.MoveNext()) && v1956.Current.Equals((20))))
                    return false;
            if (v1956.MoveNext())
                return false;
        }
        finally
        {
            v1956.Dispose();
        }

        return true;
    }

    bool EmptySequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1957;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1958;
        v1958 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1957 = 0;
            if (v1958.MoveNext())
                return false;
        }
        finally
        {
            v1958.Dispose();
        }

        return true;
    }

    bool RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1959;
        int v1960;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1961;
        v1961 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1959 = (0);
            for (; v1959 < (ArrayItems.Length); v1959++)
            {
                v1960 = (ArrayItems[v1959]);
                if (!((false)))
                    continue;
                if (!((v1961.MoveNext()) && v1961.Current.Equals((v1960))))
                    return false;
            }

            if (v1961.MoveNext())
                return false;
        }
        finally
        {
            v1961.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualRangeRewritten_ProceduralLinq1()
    {
        int v1962;
        v1962 = (0);
        for (; v1962 < (260); v1962++)
            yield return (70 + v1962);
        yield break;
    }

    bool ArraySequenceEqualRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1964;
        if (ArraySequenceEqualRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1965;
        v1965 = ((IEnumerable<int>)ArraySequenceEqualRangeRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1964 = (0);
            for (; v1964 < (ArrayItems.Length); v1964++)
                if (!((v1965.MoveNext()) && v1965.Current.Equals((ArrayItems[v1964]))))
                    return false;
            if (v1965.MoveNext())
                return false;
        }
        finally
        {
            v1965.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualRepeatRewritten_ProceduralLinq1()
    {
        int v1966;
        v1966 = (0);
        for (; v1966 < (100); v1966++)
            yield return (70);
        yield break;
    }

    bool ArraySequenceEqualRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1968;
        if (ArraySequenceEqualRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1969;
        v1969 = ((IEnumerable<int>)ArraySequenceEqualRepeatRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1968 = (0);
            for (; v1968 < (ArrayItems.Length); v1968++)
                if (!((v1969.MoveNext()) && v1969.Current.Equals((ArrayItems[v1968]))))
                    return false;
            if (v1969.MoveNext())
                return false;
        }
        finally
        {
            v1969.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1971;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1972;
        v1972 = ((IEnumerable<int>)Enumerable.Empty<int>()).GetEnumerator();
        try
        {
            v1971 = (0);
            for (; v1971 < (ArrayItems.Length); v1971++)
                if (!((v1972.MoveNext()) && v1972.Current.Equals((ArrayItems[v1971]))))
                    return false;
            if (v1972.MoveNext())
                return false;
        }
        finally
        {
            v1972.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1973;
        int v1974;
        v1973 = (0);
        for (; v1973 < (ArrayItems2.Length); v1973++)
        {
            v1974 = (ArrayItems2[v1973]);
            if (!((false)))
                continue;
            yield return (v1974);
        }

        yield break;
    }

    bool ArraySequenceEqualEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1976;
        if (ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1977;
        v1977 = ((IEnumerable<int>)ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1976 = (0);
            for (; v1976 < (ArrayItems.Length); v1976++)
                if (!((v1977.MoveNext()) && v1977.Current.Equals((ArrayItems[v1976]))))
                    return false;
            if (v1977.MoveNext())
                return false;
        }
        finally
        {
            v1977.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualAllRewritten_ProceduralLinq1()
    {
        int v1978;
        v1978 = (0);
        for (; v1978 < (1000); v1978++)
            yield return (v1978);
        yield break;
    }

    bool ArraySequenceEqualAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1980;
        if (ArraySequenceEqualAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1981;
        v1981 = ((IEnumerable<int>)ArraySequenceEqualAllRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1980 = (0);
            for (; v1980 < (ArrayItems.Length); v1980++)
                if (!((v1981.MoveNext()) && v1981.Current.Equals((ArrayItems[v1980]))))
                    return false;
            if (v1981.MoveNext())
                return false;
        }
        finally
        {
            v1981.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1983;
        throw new System.InvalidOperationException("Invalid null object");
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1984;
        HashSet<int> v1985;
        int v1986;
        v1985 = new HashSet<int>();
        v1984 = (0);
        for (; v1984 < (ArrayItems.Length); v1984++)
        {
            v1986 = (ArrayItems[v1984]);
            if (!(v1985.Add((v1986))))
                continue;
            yield return (v1986);
        }

        yield break;
    }

    bool ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1987;
        HashSet<int> v1988;
        int v1989;
        if (ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1990;
        v1990 = ((IEnumerable<int>)ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(ArrayItems)).GetEnumerator();
        try
        {
            v1988 = new HashSet<int>();
            v1987 = (0);
            for (; v1987 < (ArrayItems.Length); v1987++)
            {
                v1989 = (ArrayItems[v1987]);
                if (!(v1988.Add((v1989))))
                    continue;
                if (!((v1990.MoveNext()) && v1990.Current.Equals((v1989))))
                    return false;
            }

            if (v1990.MoveNext())
                return false;
        }
        finally
        {
            v1990.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1991;
        HashSet<int> v1992;
        int v1993;
        v1992 = new HashSet<int>(EqualityComparer<int>.Default);
        v1991 = (0);
        for (; v1991 < (ArrayItems.Length); v1991++)
        {
            v1993 = (ArrayItems[v1991]);
            if (!(v1992.Add((v1993))))
                continue;
            yield return (v1993);
        }

        yield break;
    }

    bool ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1994;
        HashSet<int> v1995;
        int v1996;
        if (ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1997;
        v1997 = ((IEnumerable<int>)ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems)).GetEnumerator();
        try
        {
            v1995 = new HashSet<int>(EqualityComparer<int>.Default);
            v1994 = (0);
            for (; v1994 < (ArrayItems.Length); v1994++)
            {
                v1996 = (ArrayItems[v1994]);
                if (!(v1995.Add((v1996))))
                    continue;
                if (!((v1997.MoveNext()) && v1997.Current.Equals((v1996))))
                    return false;
            }

            if (v1997.MoveNext())
                return false;
        }
        finally
        {
            v1997.Dispose();
        }

        return true;
    }
}}