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
        int v1602;
        IEnumerator<int> v1603;
        v1603 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1602 = 0;
            for (; v1602 < ArrayItems.Length; v1602++)
                if (!((v1603.MoveNext()) && v1603.Current.Equals(ArrayItems[v1602])))
                    return false;
            if (v1603.MoveNext())
                return false;
        }
        finally
        {
            v1603.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1604;
        IEnumerator<int> v1605;
        v1605 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        try
        {
            v1604 = 0;
            for (; v1604 < ArrayItems.Length; v1604++)
                if (!((v1605.MoveNext()) && v1605.Current.Equals(ArrayItems[v1604])))
                    return false;
            if (v1605.MoveNext())
                return false;
        }
        finally
        {
            v1605.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1606;
        IEnumerator<int> v1607;
        v1607 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        try
        {
            v1606 = 0;
            for (; v1606 < ArrayItems.Length; v1606++)
                if (!((v1607.MoveNext()) && v1607.Current.Equals(ArrayItems[v1606])))
                    return false;
            if (v1607.MoveNext())
                return false;
        }
        finally
        {
            v1607.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1608;
        IEnumerator<int> v1609;
        v1609 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        try
        {
            v1608 = 0;
            for (; v1608 < ArrayItems.Length; v1608++)
                if (!((v1609.MoveNext()) && v1609.Current.Equals(ArrayItems[v1608])))
                    return false;
            if (v1609.MoveNext())
                return false;
        }
        finally
        {
            v1609.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1610;
        IEnumerator<int> v1611;
        v1611 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        v1610 = SimpleListItems.GetEnumerator();
        try
        {
            try
            {
                while (v1610.MoveNext())
                    if (!((v1611.MoveNext()) && v1611.Current.Equals(v1610.Current)))
                        return false;
            }
            finally
            {
                v1610.Dispose();
            }

            if (v1611.MoveNext())
                return false;
        }
        finally
        {
            v1611.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1612;
        IEnumerator<int> v1613;
        v1613 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        v1612 = SimpleListItems.GetEnumerator();
        try
        {
            try
            {
                while (v1612.MoveNext())
                    if (!((v1613.MoveNext()) && v1613.Current.Equals(v1612.Current)))
                        return false;
            }
            finally
            {
                v1612.Dispose();
            }

            if (v1613.MoveNext())
                return false;
        }
        finally
        {
            v1613.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1614;
        IEnumerator<int> v1615;
        v1615 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        v1614 = SimpleListItems.GetEnumerator();
        try
        {
            try
            {
                while (v1614.MoveNext())
                    if (!((v1615.MoveNext()) && v1615.Current.Equals(v1614.Current)))
                        return false;
            }
            finally
            {
                v1614.Dispose();
            }

            if (v1615.MoveNext())
                return false;
        }
        finally
        {
            v1615.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1616;
        IEnumerator<int> v1617;
        v1617 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        v1616 = SimpleListItems.GetEnumerator();
        try
        {
            try
            {
                while (v1616.MoveNext())
                    if (!((v1617.MoveNext()) && v1617.Current.Equals(v1616.Current)))
                        return false;
            }
            finally
            {
                v1616.Dispose();
            }

            if (v1617.MoveNext())
                return false;
        }
        finally
        {
            v1617.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1618;
        IEnumerator<int> v1619;
        v1619 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        v1618 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1618.MoveNext())
                    if (!((v1619.MoveNext()) && v1619.Current.Equals(v1618.Current)))
                        return false;
            }
            finally
            {
                v1618.Dispose();
            }

            if (v1619.MoveNext())
                return false;
        }
        finally
        {
            v1619.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1620;
        IEnumerator<int> v1621;
        v1621 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        v1620 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1620.MoveNext())
                    if (!((v1621.MoveNext()) && v1621.Current.Equals(v1620.Current)))
                        return false;
            }
            finally
            {
                v1620.Dispose();
            }

            if (v1621.MoveNext())
                return false;
        }
        finally
        {
            v1621.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1622;
        IEnumerator<int> v1623;
        v1623 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        v1622 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1622.MoveNext())
                    if (!((v1623.MoveNext()) && v1623.Current.Equals(v1622.Current)))
                        return false;
            }
            finally
            {
                v1622.Dispose();
            }

            if (v1623.MoveNext())
                return false;
        }
        finally
        {
            v1623.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1624;
        IEnumerator<int> v1625;
        v1625 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        v1624 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1624.MoveNext())
                    if (!((v1625.MoveNext()) && v1625.Current.Equals(v1624.Current)))
                        return false;
            }
            finally
            {
                v1624.Dispose();
            }

            if (v1625.MoveNext())
                return false;
        }
        finally
        {
            v1625.Dispose();
        }

        return true;
    }

    bool ArraySelectSequenceEqualArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1626;
        IEnumerator<int> v1627;
        v1627 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1626 = 0;
            for (; v1626 < ArrayItems.Length; v1626++)
                if (!((v1627.MoveNext()) && v1627.Current.Equals((ArrayItems[v1626] + 50))))
                    return false;
            if (v1627.MoveNext())
                return false;
        }
        finally
        {
            v1627.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, int> v1629)
    {
        int v1628;
        v1628 = 0;
        for (; v1628 < ArrayItems2.Length; v1628++)
            yield return v1629(ArrayItems2[v1628]);
    }

    bool ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1630;
        IEnumerator<int> v1631;
        v1631 = ((IEnumerable<int>)ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(ArrayItems2, x => x + 50)).GetEnumerator();
        try
        {
            v1630 = 0;
            for (; v1630 < ArrayItems.Length; v1630++)
                if (!((v1631.MoveNext()) && v1631.Current.Equals((ArrayItems[v1630] + 50))))
                    return false;
            if (v1631.MoveNext())
                return false;
        }
        finally
        {
            v1631.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, bool> v1633)
    {
        int v1632;
        v1632 = 0;
        for (; v1632 < ArrayItems2.Length; v1632++)
        {
            if (!(v1633(ArrayItems2[v1632])))
                continue;
            yield return ArrayItems2[v1632];
        }
    }

    bool ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1634;
        IEnumerator<int> v1635;
        v1635 = ((IEnumerable<int>)ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(ArrayItems2, x => x > 50)).GetEnumerator();
        try
        {
            v1634 = 0;
            for (; v1634 < ArrayItems.Length; v1634++)
            {
                if (!((ArrayItems[v1634] > 50)))
                    continue;
                if (!((v1635.MoveNext()) && v1635.Current.Equals(ArrayItems[v1634])))
                    return false;
            }

            if (v1635.MoveNext())
                return false;
        }
        finally
        {
            v1635.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, int> v1637, System.Func<int, bool> v1639)
    {
        int v1636;
        int v1638;
        v1636 = 0;
        for (; v1636 < ArrayItems2.Length; v1636++)
        {
            v1638 = v1637(ArrayItems2[v1636]);
            if (!(v1639(v1638)))
                continue;
            yield return v1638;
        }
    }

    bool SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1640;
        int v1641;
        IEnumerator<int> v1642;
        v1642 = ((IEnumerable<int>)SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(ArrayItems2, x => x + 10, x => x > 80)).GetEnumerator();
        try
        {
            v1640 = 0;
            for (; v1640 < ArrayItems.Length; v1640++)
            {
                v1641 = (ArrayItems[v1640] + 10);
                if (!((v1641 > 80)))
                    continue;
                if (!((v1642.MoveNext()) && v1642.Current.Equals(v1641)))
                    return false;
            }

            if (v1642.MoveNext())
                return false;
        }
        finally
        {
            v1642.Dispose();
        }

        return true;
    }

    bool RangeSequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1643;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        IEnumerator<int> v1644;
        v1644 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1643 = 0;
            for (; v1643 < 100; v1643++)
                if (!((v1644.MoveNext()) && v1644.Current.Equals((v1643 + 20))))
                    return false;
            if (v1644.MoveNext())
                return false;
        }
        finally
        {
            v1644.Dispose();
        }

        return true;
    }

    bool RepeatSequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1645;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        IEnumerator<int> v1646;
        v1646 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1645 = 0;
            for (; v1645 < 100; v1645++)
                if (!((v1646.MoveNext()) && v1646.Current.Equals(20)))
                    return false;
            if (v1646.MoveNext())
                return false;
        }
        finally
        {
            v1646.Dispose();
        }

        return true;
    }

    bool EmptySequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1647;
        IEnumerator<int> v1648;
        v1648 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1647 = 0;
            for (; v1647 < 0; v1647++)
                if (!((v1648.MoveNext()) && v1648.Current.Equals(default(int))))
                    return false;
            if (v1648.MoveNext())
                return false;
        }
        finally
        {
            v1648.Dispose();
        }

        return true;
    }

    bool RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1649;
        IEnumerator<int> v1650;
        v1650 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1649 = 0;
            for (; v1649 < ArrayItems.Length; v1649++)
            {
                if (!((false)))
                    continue;
                if (!((v1650.MoveNext()) && v1650.Current.Equals(ArrayItems[v1649])))
                    return false;
            }

            if (v1650.MoveNext())
                return false;
        }
        finally
        {
            v1650.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualRangeRewritten_ProceduralLinq1()
    {
        int v1651;
        if (260 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1651 = 0;
        for (; v1651 < 260; v1651++)
            yield return (v1651 + 70);
    }

    bool ArraySequenceEqualRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1652;
        IEnumerator<int> v1653;
        v1653 = ((IEnumerable<int>)ArraySequenceEqualRangeRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1652 = 0;
            for (; v1652 < ArrayItems.Length; v1652++)
                if (!((v1653.MoveNext()) && v1653.Current.Equals(ArrayItems[v1652])))
                    return false;
            if (v1653.MoveNext())
                return false;
        }
        finally
        {
            v1653.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualRepeatRewritten_ProceduralLinq1()
    {
        int v1654;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1654 = 0;
        for (; v1654 < 100; v1654++)
            yield return 70;
    }

    bool ArraySequenceEqualRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1655;
        IEnumerator<int> v1656;
        v1656 = ((IEnumerable<int>)ArraySequenceEqualRepeatRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1655 = 0;
            for (; v1655 < ArrayItems.Length; v1655++)
                if (!((v1656.MoveNext()) && v1656.Current.Equals(ArrayItems[v1655])))
                    return false;
            if (v1656.MoveNext())
                return false;
        }
        finally
        {
            v1656.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1657;
        IEnumerator<int> v1658;
        v1658 = ((IEnumerable<int>)Enumerable.Empty<int>()).GetEnumerator();
        try
        {
            v1657 = 0;
            for (; v1657 < ArrayItems.Length; v1657++)
                if (!((v1658.MoveNext()) && v1658.Current.Equals(ArrayItems[v1657])))
                    return false;
            if (v1658.MoveNext())
                return false;
        }
        finally
        {
            v1658.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, bool> v1660)
    {
        int v1659;
        v1659 = 0;
        for (; v1659 < ArrayItems2.Length; v1659++)
        {
            if (!(v1660(ArrayItems2[v1659])))
                continue;
            yield return ArrayItems2[v1659];
        }
    }

    bool ArraySequenceEqualEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1661;
        IEnumerator<int> v1662;
        v1662 = ((IEnumerable<int>)ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(ArrayItems2, x => false)).GetEnumerator();
        try
        {
            v1661 = 0;
            for (; v1661 < ArrayItems.Length; v1661++)
                if (!((v1662.MoveNext()) && v1662.Current.Equals(ArrayItems[v1661])))
                    return false;
            if (v1662.MoveNext())
                return false;
        }
        finally
        {
            v1662.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualAllRewritten_ProceduralLinq1()
    {
        int v1663;
        if (1000 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1663 = 0;
        for (; v1663 < 1000; v1663++)
            yield return (v1663 + 0);
    }

    bool ArraySequenceEqualAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1664;
        IEnumerator<int> v1665;
        v1665 = ((IEnumerable<int>)ArraySequenceEqualAllRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1664 = 0;
            for (; v1664 < ArrayItems.Length; v1664++)
                if (!((v1665.MoveNext()) && v1665.Current.Equals(ArrayItems[v1664])))
                    return false;
            if (v1665.MoveNext())
                return false;
        }
        finally
        {
            v1665.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1666;
        throw new System.InvalidOperationException("Collection was null");
        v1666 = 0;
        for (; v1666 < ArrayItems.Length; v1666++)
            ;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1667;
        HashSet<int> v1668;
        v1668 = new HashSet<int>();
        v1667 = 0;
        for (; v1667 < ArrayItems.Length; v1667++)
        {
            if (!(v1668.Add(ArrayItems[v1667])))
                continue;
            yield return ArrayItems[v1667];
        }
    }

    bool ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1669;
        HashSet<int> v1670;
        IEnumerator<int> v1671;
        v1671 = ((IEnumerable<int>)ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(ArrayItems)).GetEnumerator();
        try
        {
            v1670 = new HashSet<int>();
            v1669 = 0;
            for (; v1669 < ArrayItems.Length; v1669++)
            {
                if (!(v1670.Add(ArrayItems[v1669])))
                    continue;
                if (!((v1671.MoveNext()) && v1671.Current.Equals(ArrayItems[v1669])))
                    return false;
            }

            if (v1671.MoveNext())
                return false;
        }
        finally
        {
            v1671.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1672;
        HashSet<int> v1673;
        v1673 = new HashSet<int>(EqualityComparer<int>.Default);
        v1672 = 0;
        for (; v1672 < ArrayItems.Length; v1672++)
        {
            if (!(v1673.Add(ArrayItems[v1672])))
                continue;
            yield return ArrayItems[v1672];
        }
    }

    bool ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1674;
        HashSet<int> v1675;
        IEnumerator<int> v1676;
        v1676 = ((IEnumerable<int>)ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems)).GetEnumerator();
        try
        {
            v1675 = new HashSet<int>(EqualityComparer<int>.Default);
            v1674 = 0;
            for (; v1674 < ArrayItems.Length; v1674++)
            {
                if (!(v1675.Add(ArrayItems[v1674])))
                    continue;
                if (!((v1676.MoveNext()) && v1676.Current.Equals(ArrayItems[v1674])))
                    return false;
            }

            if (v1676.MoveNext())
                return false;
        }
        finally
        {
            v1676.Dispose();
        }

        return true;
    }
}}