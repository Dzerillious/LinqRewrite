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
        int v1707;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1708;
        v1708 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1707 = (0);
            for (; v1707 < (ArrayItems.Length); v1707 += 1)
                if (!((v1708.MoveNext()) && v1708.Current.Equals((ArrayItems[v1707]))))
                    return false;
            if (v1708.MoveNext())
                return false;
        }
        finally
        {
            v1708.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1710;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1711;
        v1711 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        try
        {
            v1710 = (0);
            for (; v1710 < (ArrayItems.Length); v1710 += 1)
                if (!((v1711.MoveNext()) && v1711.Current.Equals((ArrayItems[v1710]))))
                    return false;
            if (v1711.MoveNext())
                return false;
        }
        finally
        {
            v1711.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1713;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1714;
        v1714 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        try
        {
            v1713 = (0);
            for (; v1713 < (ArrayItems.Length); v1713 += 1)
                if (!((v1714.MoveNext()) && v1714.Current.Equals((ArrayItems[v1713]))))
                    return false;
            if (v1714.MoveNext())
                return false;
        }
        finally
        {
            v1714.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1716;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1717;
        v1717 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        try
        {
            v1716 = (0);
            for (; v1716 < (ArrayItems.Length); v1716 += 1)
                if (!((v1717.MoveNext()) && v1717.Current.Equals((ArrayItems[v1716]))))
                    return false;
            if (v1717.MoveNext())
                return false;
        }
        finally
        {
            v1717.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1719;
        v1719 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1720;
        v1720 = SimpleListItems;
        int v1721;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1722;
        v1722 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1721 = (0);
            for (; v1721 < (v1719); v1721 += 1)
                if (!((v1722.MoveNext()) && v1722.Current.Equals((v1720[v1721]))))
                    return false;
            if (v1722.MoveNext())
                return false;
        }
        finally
        {
            v1722.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1724;
        v1724 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1725;
        v1725 = SimpleListItems;
        int v1726;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1727;
        v1727 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        try
        {
            v1726 = (0);
            for (; v1726 < (v1724); v1726 += 1)
                if (!((v1727.MoveNext()) && v1727.Current.Equals((v1725[v1726]))))
                    return false;
            if (v1727.MoveNext())
                return false;
        }
        finally
        {
            v1727.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1729;
        v1729 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1730;
        v1730 = SimpleListItems;
        int v1731;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1732;
        v1732 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        try
        {
            v1731 = (0);
            for (; v1731 < (v1729); v1731 += 1)
                if (!((v1732.MoveNext()) && v1732.Current.Equals((v1730[v1731]))))
                    return false;
            if (v1732.MoveNext())
                return false;
        }
        finally
        {
            v1732.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1734;
        v1734 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1735;
        v1735 = SimpleListItems;
        int v1736;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1737;
        v1737 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        try
        {
            v1736 = (0);
            for (; v1736 < (v1734); v1736 += 1)
                if (!((v1737.MoveNext()) && v1737.Current.Equals((v1735[v1736]))))
                    return false;
            if (v1737.MoveNext())
                return false;
        }
        finally
        {
            v1737.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1738;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1739;
        v1739 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        v1738 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1738.MoveNext())
                    if (!((v1739.MoveNext()) && v1739.Current.Equals((v1738.Current))))
                        return false;
            }
            finally
            {
                v1738.Dispose();
            }

            if (v1739.MoveNext())
                return false;
        }
        finally
        {
            v1739.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1740;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1741;
        v1741 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        v1740 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1740.MoveNext())
                    if (!((v1741.MoveNext()) && v1741.Current.Equals((v1740.Current))))
                        return false;
            }
            finally
            {
                v1740.Dispose();
            }

            if (v1741.MoveNext())
                return false;
        }
        finally
        {
            v1741.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1742;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1743;
        v1743 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        v1742 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1742.MoveNext())
                    if (!((v1743.MoveNext()) && v1743.Current.Equals((v1742.Current))))
                        return false;
            }
            finally
            {
                v1742.Dispose();
            }

            if (v1743.MoveNext())
                return false;
        }
        finally
        {
            v1743.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1744;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1745;
        v1745 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        v1744 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1744.MoveNext())
                    if (!((v1745.MoveNext()) && v1745.Current.Equals((v1744.Current))))
                        return false;
            }
            finally
            {
                v1744.Dispose();
            }

            if (v1745.MoveNext())
                return false;
        }
        finally
        {
            v1745.Dispose();
        }

        return true;
    }

    bool ArraySelectSequenceEqualArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1747;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1748;
        v1748 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1747 = (0);
            for (; v1747 < (ArrayItems.Length); v1747 += 1)
                if (!((v1748.MoveNext()) && v1748.Current.Equals((50 + ArrayItems[v1747]))))
                    return false;
            if (v1748.MoveNext())
                return false;
        }
        finally
        {
            v1748.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1750;
        v1750 = (0);
        for (; v1750 < (ArrayItems2.Length); v1750 += 1)
            yield return (((ArrayItems2[v1750]) + 50));
        yield break;
    }

    bool ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1752;
        if (ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1753;
        v1753 = ((IEnumerable<int>)ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1752 = (0);
            for (; v1752 < (ArrayItems.Length); v1752 += 1)
                if (!((v1753.MoveNext()) && v1753.Current.Equals((50 + ArrayItems[v1752]))))
                    return false;
            if (v1753.MoveNext())
                return false;
        }
        finally
        {
            v1753.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1754;
        v1754 = (0);
        for (; v1754 < (ArrayItems2.Length); v1754 += 1)
        {
            if (!((((ArrayItems2[v1754])) > 50)))
                continue;
            yield return ((ArrayItems2[v1754]));
        }

        yield break;
    }

    bool ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1755;
        if (ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1756;
        v1756 = ((IEnumerable<int>)ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1755 = (0);
            for (; v1755 < (ArrayItems.Length); v1755 += 1)
            {
                if (!((((ArrayItems[v1755])) > 50)))
                    continue;
                if (!((v1756.MoveNext()) && v1756.Current.Equals(((ArrayItems[v1755])))))
                    return false;
            }

            if (v1756.MoveNext())
                return false;
        }
        finally
        {
            v1756.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1757;
        int v1758;
        v1757 = (0);
        for (; v1757 < (ArrayItems2.Length); v1757 += 1)
        {
            v1758 = (((ArrayItems2[v1757]) + 10));
            if (!(((v1758) > 80)))
                continue;
            yield return (v1758);
        }

        yield break;
    }

    bool SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1759;
        int v1760;
        if (SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1761;
        v1761 = ((IEnumerable<int>)SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1759 = (0);
            for (; v1759 < (ArrayItems.Length); v1759 += 1)
            {
                v1760 = (10 + ArrayItems[v1759]);
                if (!(((v1760) > 80)))
                    continue;
                if (!((v1761.MoveNext()) && v1761.Current.Equals((v1760))))
                    return false;
            }

            if (v1761.MoveNext())
                return false;
        }
        finally
        {
            v1761.Dispose();
        }

        return true;
    }

    bool RangeSequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1762;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1763;
        v1763 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1762 = (0);
            for (; v1762 < (100); v1762 += (1))
                if (!((v1763.MoveNext()) && v1763.Current.Equals((20 + v1762))))
                    return false;
            if (v1763.MoveNext())
                return false;
        }
        finally
        {
            v1763.Dispose();
        }

        return true;
    }

    bool RepeatSequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1764;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1765;
        v1765 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1764 = (0);
            for (; v1764 < (100); v1764 += 1)
                if (!((v1765.MoveNext()) && v1765.Current.Equals((20))))
                    return false;
            if (v1765.MoveNext())
                return false;
        }
        finally
        {
            v1765.Dispose();
        }

        return true;
    }

    bool EmptySequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1766;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1767;
        v1767 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1766 = 0;
            if (v1767.MoveNext())
                return false;
        }
        finally
        {
            v1767.Dispose();
        }

        return true;
    }

    bool RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1768;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1769;
        v1769 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1768 = (0);
            for (; v1768 < (ArrayItems.Length); v1768 += 1)
            {
                if (!((false)))
                    continue;
                if (!((v1769.MoveNext()) && v1769.Current.Equals(((ArrayItems[v1768])))))
                    return false;
            }

            if (v1769.MoveNext())
                return false;
        }
        finally
        {
            v1769.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualRangeRewritten_ProceduralLinq1()
    {
        int v1770;
        v1770 = (0);
        for (; v1770 < (260); v1770 += (1))
            yield return (70 + v1770);
        yield break;
    }

    bool ArraySequenceEqualRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1772;
        if (ArraySequenceEqualRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1773;
        v1773 = ((IEnumerable<int>)ArraySequenceEqualRangeRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1772 = (0);
            for (; v1772 < (ArrayItems.Length); v1772 += 1)
                if (!((v1773.MoveNext()) && v1773.Current.Equals((ArrayItems[v1772]))))
                    return false;
            if (v1773.MoveNext())
                return false;
        }
        finally
        {
            v1773.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualRepeatRewritten_ProceduralLinq1()
    {
        int v1774;
        v1774 = (0);
        for (; v1774 < (100); v1774 += 1)
            yield return (70);
        yield break;
    }

    bool ArraySequenceEqualRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1776;
        if (ArraySequenceEqualRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1777;
        v1777 = ((IEnumerable<int>)ArraySequenceEqualRepeatRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1776 = (0);
            for (; v1776 < (ArrayItems.Length); v1776 += 1)
                if (!((v1777.MoveNext()) && v1777.Current.Equals((ArrayItems[v1776]))))
                    return false;
            if (v1777.MoveNext())
                return false;
        }
        finally
        {
            v1777.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1779;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1780;
        v1780 = ((IEnumerable<int>)Enumerable.Empty<int>()).GetEnumerator();
        try
        {
            v1779 = (0);
            for (; v1779 < (ArrayItems.Length); v1779 += 1)
                if (!((v1780.MoveNext()) && v1780.Current.Equals((ArrayItems[v1779]))))
                    return false;
            if (v1780.MoveNext())
                return false;
        }
        finally
        {
            v1780.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1781;
        v1781 = (0);
        for (; v1781 < (ArrayItems2.Length); v1781 += 1)
        {
            if (!((false)))
                continue;
            yield return ((ArrayItems2[v1781]));
        }

        yield break;
    }

    bool ArraySequenceEqualEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1783;
        if (ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1784;
        v1784 = ((IEnumerable<int>)ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1783 = (0);
            for (; v1783 < (ArrayItems.Length); v1783 += 1)
                if (!((v1784.MoveNext()) && v1784.Current.Equals((ArrayItems[v1783]))))
                    return false;
            if (v1784.MoveNext())
                return false;
        }
        finally
        {
            v1784.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualAllRewritten_ProceduralLinq1()
    {
        int v1785;
        v1785 = (0);
        for (; v1785 < (1000); v1785 += (1))
            yield return (v1785);
        yield break;
    }

    bool ArraySequenceEqualAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1787;
        if (ArraySequenceEqualAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1788;
        v1788 = ((IEnumerable<int>)ArraySequenceEqualAllRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1787 = (0);
            for (; v1787 < (ArrayItems.Length); v1787 += 1)
                if (!((v1788.MoveNext()) && v1788.Current.Equals((ArrayItems[v1787]))))
                    return false;
            if (v1788.MoveNext())
                return false;
        }
        finally
        {
            v1788.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1790;
        throw new System.InvalidOperationException("Invalid null object");
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1791;
        HashSet<int> v1792;
        v1792 = new HashSet<int>();
        v1791 = (0);
        for (; v1791 < (ArrayItems.Length); v1791 += 1)
        {
            if (!(v1792.Add(((ArrayItems[v1791])))))
                continue;
            yield return ((ArrayItems[v1791]));
        }

        yield break;
    }

    bool ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1793;
        HashSet<int> v1794;
        if (ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1795;
        v1795 = ((IEnumerable<int>)ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(ArrayItems)).GetEnumerator();
        try
        {
            v1794 = new HashSet<int>();
            v1793 = (0);
            for (; v1793 < (ArrayItems.Length); v1793 += 1)
            {
                if (!(v1794.Add(((ArrayItems[v1793])))))
                    continue;
                if (!((v1795.MoveNext()) && v1795.Current.Equals(((ArrayItems[v1793])))))
                    return false;
            }

            if (v1795.MoveNext())
                return false;
        }
        finally
        {
            v1795.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1796;
        HashSet<int> v1797;
        v1797 = new HashSet<int>(EqualityComparer<int>.Default);
        v1796 = (0);
        for (; v1796 < (ArrayItems.Length); v1796 += 1)
        {
            if (!(v1797.Add(((ArrayItems[v1796])))))
                continue;
            yield return ((ArrayItems[v1796]));
        }

        yield break;
    }

    bool ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1798;
        HashSet<int> v1799;
        if (ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1800;
        v1800 = ((IEnumerable<int>)ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems)).GetEnumerator();
        try
        {
            v1799 = new HashSet<int>(EqualityComparer<int>.Default);
            v1798 = (0);
            for (; v1798 < (ArrayItems.Length); v1798 += 1)
            {
                if (!(v1799.Add(((ArrayItems[v1798])))))
                    continue;
                if (!((v1800.MoveNext()) && v1800.Current.Equals(((ArrayItems[v1798])))))
                    return false;
            }

            if (v1800.MoveNext())
                return false;
        }
        finally
        {
            v1800.Dispose();
        }

        return true;
    }
}}