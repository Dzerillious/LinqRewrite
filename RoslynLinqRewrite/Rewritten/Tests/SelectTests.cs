using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class SelectTests
{
    [Datapoints]
    private int[] NullItems = null;
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private static int[] StaticArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private List<int> ListItems = Enumerable.Range(0, 100).ToList();
    [Datapoints]
    private SimpleList<int> SimpleListItems = Enumerable.Range(0, 100).ToSimpleList();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public double Selector(int x) => x + 3;
    public double SelectorIndex(int x, int i) => x + i;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(NullSelect), NullSelect, NullSelectRewritten);
        TestsExtensions.TestEquals(nameof(NullableSelect), NullableSelect, NullableSelectRewritten);
        TestsExtensions.TestEquals(nameof(SelectArray), SelectArray, SelectArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectList), SelectList, SelectListRewritten);
        TestsExtensions.TestEquals(nameof(SelectSimpleList), SelectSimpleList, SelectSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectEnumerable), SelectEnumerable, SelectEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(SelectArrayToArray), SelectArrayToArray, SelectArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectListToArray), SelectListToArray, SelectListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectEnumerableToArray), SelectEnumerableToArray, SelectEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectSimpleListToArray), SelectSimpleListToArray, SelectSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectArrayToSimpleList), SelectArrayToSimpleList, SelectArrayToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectListToSimpleList), SelectListToSimpleList, SelectListToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectEnumerableToSimpleList), SelectEnumerableToSimpleList, SelectEnumerableToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectSimpleListToSimpleList), SelectSimpleListToSimpleList, SelectSimpleListToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectArrayToList), SelectArrayToList, SelectArrayToListRewritten);
        TestsExtensions.TestEquals(nameof(SelectListToList), SelectListToList, SelectListToListRewritten);
        TestsExtensions.TestEquals(nameof(SelectEnumerableToList), SelectEnumerableToList, SelectEnumerableToListRewritten);
        TestsExtensions.TestEquals(nameof(SelectSimpleListToList), SelectSimpleListToList, SelectSimpleListToListRewritten);
        TestsExtensions.TestEquals(nameof(SelectStaticArray), SelectStaticArray, SelectStaticArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectMethodSelector), SelectMethodSelector, SelectMethodSelectorRewritten);
        TestsExtensions.TestEquals(nameof(SelectRetype), SelectRetype, SelectRetypeRewritten);
        TestsExtensions.TestEquals(nameof(SelectArrayFromArray), SelectArrayFromArray, SelectArrayFromArrayRewritten);
        TestsExtensions.TestEquals(nameof(StaticSelect), StaticSelect, StaticSelectRewritten);
        TestsExtensions.TestEquals(nameof(StaticClassSelect), StaticClassSelect, StaticClassSelectRewritten);
        TestsExtensions.TestEquals(nameof(SelectParams), SelectParams, SelectParamsRewritten);
        TestsExtensions.TestEquals(nameof(SelectMultipleParams), SelectMultipleParams, SelectMultipleParamsRewritten);
        TestsExtensions.TestEquals(nameof(MultipleSelect), MultipleSelect, MultipleSelectRewritten);
        TestsExtensions.TestEquals(nameof(MultipleSelect2), MultipleSelect2, MultipleSelect2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectChangingParam), SelectChangingParam, SelectChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(SelectChangingParam2), SelectChangingParam2, SelectChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectChangingParam3), SelectChangingParam3, SelectChangingParam3Rewritten);
        TestsExtensions.TestEquals(nameof(SelectChangingParam4), SelectChangingParam4, SelectChangingParam4Rewritten);
        TestsExtensions.TestEquals(nameof(StaticSelect), StaticSelect, StaticSelectRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectIndex), ArraySelectIndex, ArraySelectIndexRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectIndexToArray), ArraySelectIndexToArray, ArraySelectIndexToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectIndexMethodToArray), ArraySelectIndexMethodToArray, ArraySelectIndexMethodToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectIndexMethod), ArraySelectIndexMethod, ArraySelectIndexMethodRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> NullSelect()
    {
        return NullItems.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> NullSelectRewritten()
    {
        return NullSelectRewritten_ProceduralLinq1(NullItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> NullableSelect()
    {
        return NullItems?.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> NullableSelectRewritten()
    {
        return NullItems == null ? default(System.Collections.Generic.IEnumerable<int>) : NullableSelectRewritten_ProceduralLinq1(NullItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectArray()
    {
        return ArrayItems.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> SelectArrayRewritten()
    {
        return SelectArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectList()
    {
        return ListItems.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> SelectListRewritten()
    {
        return SelectListRewritten_ProceduralLinq1(ListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectSimpleList()
    {
        return SimpleListItems.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> SelectSimpleListRewritten()
    {
        return SelectSimpleListRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectEnumerable()
    {
        return EnumerableItems.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> SelectEnumerableRewritten()
    {
        return SelectEnumerableRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectArrayToArray()
    {
        return ArrayItems.Select(x => x + 3).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectArrayToArrayRewritten()
    {
        return SelectArrayToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectListToArray()
    {
        return ListItems.Select(x => x + 3).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectListToArrayRewritten()
    {
        return SelectListToArrayRewritten_ProceduralLinq1(ListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectEnumerableToArray()
    {
        return EnumerableItems.Select(x => x + 3).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectEnumerableToArrayRewritten()
    {
        return SelectEnumerableToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectSimpleListToArray()
    {
        return SimpleListItems.Select(x => x + 3).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectSimpleListToArrayRewritten()
    {
        return SelectSimpleListToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectArrayToSimpleList()
    {
        return ArrayItems.Select(x => x + 3).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SelectArrayToSimpleListRewritten()
    {
        return SelectArrayToSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectListToSimpleList()
    {
        return ListItems.Select(x => x + 3).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SelectListToSimpleListRewritten()
    {
        return SelectListToSimpleListRewritten_ProceduralLinq1(ListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectEnumerableToSimpleList()
    {
        return EnumerableItems.Select(x => x + 3).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SelectEnumerableToSimpleListRewritten()
    {
        return SelectEnumerableToSimpleListRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectSimpleListToSimpleList()
    {
        return SimpleListItems.Select(x => x + 3).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SelectSimpleListToSimpleListRewritten()
    {
        return SelectSimpleListToSimpleListRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectArrayToList()
    {
        return ArrayItems.Select(x => x + 3).ToList();
    } //EndMethod

    public IEnumerable<int> SelectArrayToListRewritten()
    {
        return SelectArrayToListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectListToList()
    {
        return ListItems.Select(x => x + 3).ToList();
    } //EndMethod

    public IEnumerable<int> SelectListToListRewritten()
    {
        return SelectListToListRewritten_ProceduralLinq1(ListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectEnumerableToList()
    {
        return EnumerableItems.Select(x => x + 3).ToList();
    } //EndMethod

    public IEnumerable<int> SelectEnumerableToListRewritten()
    {
        return SelectEnumerableToListRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectSimpleListToList()
    {
        return SimpleListItems.Select(x => x + 3).ToList();
    } //EndMethod

    public IEnumerable<int> SelectSimpleListToListRewritten()
    {
        return SelectSimpleListToListRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectStaticArray()
    {
        return StaticArrayItems.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> SelectStaticArrayRewritten()
    {
        return SelectStaticArrayRewritten_ProceduralLinq1(StaticArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> SelectMethodSelector()
    {
        return ArrayItems.Select(Selector);
    } //EndMethod

    public IEnumerable<double> SelectMethodSelectorRewritten()
    {
        return SelectMethodSelectorRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> SelectRetype()
    {
        return ArrayItems.Select(x => (double)x + 3);
    } //EndMethod

    public IEnumerable<double> SelectRetypeRewritten()
    {
        return SelectRetypeRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int[]> SelectArrayFromArray()
    {
        return ArrayItems.Select(x => ArrayItems);
    } //EndMethod

    public IEnumerable<int[]> SelectArrayFromArrayRewritten()
    {
        return SelectArrayFromArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public static IEnumerable<int> StaticSelect()
    {
        return StaticArrayItems.Select(x => x + 3);
    } //EndMethod

    public static IEnumerable<int> StaticSelectRewritten()
    {
        return StaticSelectRewritten_ProceduralLinq1(StaticArrayItems);
    } //EndMethod

    [NoRewrite]
    public static IEnumerable<int> StaticClassSelect()
    {
        return StaticSelectTests.StaticSelect();
    } //EndMethod

    public static IEnumerable<int> StaticClassSelectRewritten()
    {
        return StaticSelectTests.StaticSelectRewritten();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectParams()
    {
        var a = 5;
        return ArrayItems.Select(x => x + a);
    } //EndMethod

    public IEnumerable<int> SelectParamsRewritten()
    {
        var a = 5;
        return SelectParamsRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectMultipleParams()
    {
        var a = 5;
        var b = 8;
        var c = 10;
        var d = 15;
        var e = 21;
        var f = 28;
        var g = 35;
        var h = 42;
        var i = 49;
        return ArrayItems.Select(x => x + a + b + c + d + e + f + g + h + i);
    } //EndMethod

    public IEnumerable<int> SelectMultipleParamsRewritten()
    {
        var a = 5;
        var b = 8;
        var c = 10;
        var d = 15;
        var e = 21;
        var f = 28;
        var g = 35;
        var h = 42;
        var i = 49;
        return SelectMultipleParamsRewritten_ProceduralLinq1(a, b, c, d, e, f, g, h, i, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MultipleSelect()
    {
        return ArrayItems.Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> MultipleSelectRewritten()
    {
        return MultipleSelectRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MultipleSelect2()
    {
        return ArrayItems.Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x);
    } //EndMethod

    public IEnumerable<int> MultipleSelect2Rewritten()
    {
        return MultipleSelect2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectChangingParam()
    {
        var a = 0;
        return ArrayItems.Select(x => x + a++);
    } //EndMethod

    public IEnumerable<int> SelectChangingParamRewritten()
    {
        var a = 0;
        return SelectChangingParamRewritten_ProceduralLinq1(ArrayItems, x => x + a++);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectChangingParam2()
    {
        var a = 0;
        return ArrayItems.Select(x => x + a++).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectChangingParam2Rewritten()
    {
        var a = 0;
        return SelectChangingParam2Rewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectChangingParam3()
    {
        var a = 0;
        return ArrayItems.Select(x => x + a++).Select(x => x + a++).Select(x => x + a++).Select(x => x + a++).Select(x => x + a++);
    } //EndMethod

    public IEnumerable<int> SelectChangingParam3Rewritten()
    {
        var a = 0;
        return SelectChangingParam3Rewritten_ProceduralLinq1(ArrayItems, x => x + a++, x => x + a++, x => x + a++, x => x + a++, x => x + a++);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectChangingParam4()
    {
        var a = 0;
        return ArrayItems.Select(x => x + a++).Select(x => x + a++).Select(x => x + a++).Select(x => x + a++).Select(x => x + a++).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectChangingParam4Rewritten()
    {
        var a = 0;
        return SelectChangingParam4Rewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectIndex()
    {
        return ArrayItems.Select((x, i) => x + i);
    } //EndMethod

    public IEnumerable<int> ArraySelectIndexRewritten()
    {
        return ArraySelectIndexRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectIndexToArray()
    {
        return ArrayItems.Select((x, i) => x + i).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectIndexToArrayRewritten()
    {
        return ArraySelectIndexToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> ArraySelectIndexMethod()
    {
        return ArrayItems.Select(SelectorIndex);
    } //EndMethod

    public IEnumerable<double> ArraySelectIndexMethodRewritten()
    {
        return ArraySelectIndexMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> ArraySelectIndexMethodToArray()
    {
        return ArrayItems.Select(SelectorIndex).ToArray();
    } //EndMethod

    public IEnumerable<double> ArraySelectIndexMethodToArrayRewritten()
    {
        return ArraySelectIndexMethodToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> NullSelectRewritten_ProceduralLinq1(int[] NullItems)
    {
        int v1601;
        v1601 = (0);
        for (; v1601 < (NullItems.Length); v1601 += 1)
            yield return (3 + NullItems[v1601]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> NullableSelectRewritten_ProceduralLinq1(int[] NullItems)
    {
        int v1603;
        v1603 = (0);
        for (; v1603 < (NullItems.Length); v1603 += 1)
            yield return (3 + NullItems[v1603]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1605;
        v1605 = (0);
        for (; v1605 < (ArrayItems.Length); v1605 += 1)
            yield return (3 + ArrayItems[v1605]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1607;
        int v1608;
        v1608 = (ListItems.Count);
        v1607 = (0);
        for (; v1607 < v1608; v1607 += 1)
            yield return (3 + ListItems[v1607]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1610;
        v1610 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1611;
        v1611 = SimpleListItems;
        int v1612;
        v1612 = (0);
        for (; v1612 < (v1610); v1612 += 1)
            yield return (((v1611[v1612]) + 3));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1613;
        v1613 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1613.MoveNext())
                yield return (3 + v1613.Current);
        }
        finally
        {
            v1613.Dispose();
        }

        yield break;
    }

    int[] SelectArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1615;
        int[] v1616;
        v1616 = new int[(ArrayItems.Length)];
        v1615 = (0);
        for (; v1615 < (ArrayItems.Length); v1615 += 1)
            v1616[v1615] = (3 + ArrayItems[v1615]);
        return v1616;
    }

    int[] SelectListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1618;
        int[] v1619;
        int v1620;
        v1620 = (ListItems.Count);
        v1619 = new int[(ListItems.Count)];
        v1618 = (0);
        for (; v1618 < v1620; v1618 += 1)
            v1619[v1618] = (3 + ListItems[v1618]);
        return v1619;
    }

    int[] SelectEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1621;
        int v1622;
        int v1623;
        int[] v1624;
        v1621 = EnumerableItems.GetEnumerator();
        v1622 = 0;
        v1623 = 8;
        v1624 = new int[8];
        try
        {
            while (v1621.MoveNext())
            {
                if (v1622 >= v1623)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1624, ref v1623);
                v1624[v1622] = (3 + v1621.Current);
                v1622++;
            }
        }
        finally
        {
            v1621.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1624, v1622);
    }

    int[] SelectSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1626;
        v1626 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1627;
        v1627 = SimpleListItems;
        int v1628;
        int[] v1629;
        v1629 = new int[(v1626)];
        v1628 = (0);
        for (; v1628 < (v1626); v1628 += 1)
            v1629[v1628] = (((v1627[v1628]) + 3));
        return v1629;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectArrayToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1631;
        int[] v1632;
        SimpleList<int> v1633;
        v1632 = new int[(ArrayItems.Length)];
        v1631 = (0);
        for (; v1631 < (ArrayItems.Length); v1631 += 1)
            v1632[v1631] = (3 + ArrayItems[v1631]);
        v1633 = new SimpleList<int>();
        v1633.Items = v1632;
        v1633.Count = (ArrayItems.Length);
        return v1633;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectListToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1635;
        int[] v1636;
        SimpleList<int> v1637;
        int v1638;
        v1638 = (ListItems.Count);
        v1636 = new int[(ListItems.Count)];
        v1635 = (0);
        for (; v1635 < v1638; v1635 += 1)
            v1636[v1635] = (3 + ListItems[v1635]);
        v1637 = new SimpleList<int>();
        v1637.Items = v1636;
        v1637.Count = (ListItems.Count);
        return v1637;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectEnumerableToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1639;
        int v1640;
        int v1641;
        int[] v1642;
        SimpleList<int> v1643;
        v1639 = EnumerableItems.GetEnumerator();
        v1640 = 0;
        v1641 = 8;
        v1642 = new int[8];
        try
        {
            while (v1639.MoveNext())
            {
                if (v1640 >= v1641)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1642, ref v1641);
                v1642[v1640] = (3 + v1639.Current);
                v1640++;
            }
        }
        finally
        {
            v1639.Dispose();
        }

        v1643 = new SimpleList<int>();
        v1643.Items = v1642;
        v1643.Count = v1640;
        return v1643;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectSimpleListToSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1645;
        v1645 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1646;
        v1646 = SimpleListItems;
        int v1647;
        int[] v1648;
        SimpleList<int> v1649;
        v1648 = new int[(v1645)];
        v1647 = (0);
        for (; v1647 < (v1645); v1647 += 1)
            v1648[v1647] = (((v1646[v1647]) + 3));
        v1649 = new SimpleList<int>();
        v1649.Items = v1648;
        v1649.Count = (v1645);
        return v1649;
    }

    System.Collections.Generic.List<int> SelectArrayToListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1651;
        System.Collections.Generic.List<int> v1652;
        v1652 = new System.Collections.Generic.List<int>();
        v1651 = (0);
        for (; v1651 < (ArrayItems.Length); v1651 += 1)
            v1652.Add((3 + ArrayItems[v1651]));
        return v1652;
    }

    System.Collections.Generic.List<int> SelectListToListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1654;
        System.Collections.Generic.List<int> v1655;
        int v1656;
        v1656 = (ListItems.Count);
        v1655 = new System.Collections.Generic.List<int>();
        v1654 = (0);
        for (; v1654 < v1656; v1654 += 1)
            v1655.Add((3 + ListItems[v1654]));
        return v1655;
    }

    System.Collections.Generic.List<int> SelectEnumerableToListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1657;
        System.Collections.Generic.List<int> v1658;
        v1657 = EnumerableItems.GetEnumerator();
        v1658 = new System.Collections.Generic.List<int>();
        try
        {
            while (v1657.MoveNext())
                v1658.Add((3 + v1657.Current));
        }
        finally
        {
            v1657.Dispose();
        }

        return v1658;
    }

    System.Collections.Generic.List<int> SelectSimpleListToListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1660;
        v1660 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1661;
        v1661 = SimpleListItems;
        int v1662;
        System.Collections.Generic.List<int> v1663;
        v1663 = new System.Collections.Generic.List<int>();
        v1662 = (0);
        for (; v1662 < (v1660); v1662 += 1)
            v1663.Add((((v1661[v1662]) + 3)));
        return v1663;
    }

    System.Collections.Generic.IEnumerable<int> SelectStaticArrayRewritten_ProceduralLinq1(int[] StaticArrayItems)
    {
        int v1665;
        v1665 = (0);
        for (; v1665 < (StaticArrayItems.Length); v1665 += 1)
            yield return (3 + StaticArrayItems[v1665]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<double> SelectMethodSelectorRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1667;
        v1667 = (0);
        for (; v1667 < (ArrayItems.Length); v1667 += 1)
            yield return (Selector((ArrayItems[v1667])));
        yield break;
    }

    System.Collections.Generic.IEnumerable<double> SelectRetypeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1669;
        v1669 = (0);
        for (; v1669 < (ArrayItems.Length); v1669 += 1)
            yield return (((double)(ArrayItems[v1669]) + 3));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int[]> SelectArrayFromArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1671;
        v1671 = (0);
        for (; v1671 < (ArrayItems.Length); v1671 += 1)
            yield return ((ArrayItems));
        yield break;
    }

    static System.Collections.Generic.IEnumerable<int> StaticSelectRewritten_ProceduralLinq1(int[] StaticArrayItems)
    {
        int v1673;
        v1673 = (0);
        for (; v1673 < (StaticArrayItems.Length); v1673 += 1)
            yield return (3 + StaticArrayItems[v1673]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectParamsRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1675;
        v1675 = (0);
        for (; v1675 < (ArrayItems.Length); v1675 += 1)
            yield return (ArrayItems[v1675] + a);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectMultipleParamsRewritten_ProceduralLinq1(int a, int b, int c, int d, int e, int f, int g, int h, int i, int[] ArrayItems)
    {
        int v1677;
        v1677 = (0);
        for (; v1677 < (ArrayItems.Length); v1677 += 1)
            yield return (ArrayItems[v1677] + i + a + b + c + d + e + f + g + h);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelectRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1679;
        v1679 = (0);
        for (; v1679 < (ArrayItems.Length); v1679 += 1)
            yield return (30 + ArrayItems[v1679]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelect2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1681;
        v1681 = (0);
        for (; v1681 < (ArrayItems.Length); v1681 += 1)
            yield return (1024 * ArrayItems[v1681]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1683)
    {
        int v1682;
        v1682 = (0);
        for (; v1682 < (ArrayItems.Length); v1682 += 1)
            yield return (v1683((ArrayItems[v1682])));
        yield break;
    }

    int[] SelectChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1684;
        int[] v1685;
        v1685 = new int[(ArrayItems.Length)];
        v1684 = (0);
        for (; v1684 < (ArrayItems.Length); v1684 += 1)
            v1685[v1684] = (((ArrayItems[v1684]) + a++));
        return v1685;
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParam3Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1687, System.Func<int, int> v1688, System.Func<int, int> v1689, System.Func<int, int> v1690, System.Func<int, int> v1691)
    {
        int v1686;
        v1686 = (0);
        for (; v1686 < (ArrayItems.Length); v1686 += 1)
            yield return (v1691((v1690((v1689((v1688((v1687((ArrayItems[v1686])))))))))));
        yield break;
    }

    int[] SelectChangingParam4Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1692;
        int[] v1693;
        v1693 = new int[(ArrayItems.Length)];
        v1692 = (0);
        for (; v1692 < (ArrayItems.Length); v1692 += 1)
            v1693[v1692] = (((((((((((ArrayItems[v1692]) + a++)) + a++)) + a++)) + a++)) + a++));
        return v1693;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIndexRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1695;
        v1695 = (0);
        for (; v1695 < (ArrayItems.Length); v1695 += 1)
            yield return (ArrayItems[v1695] + v1695);
        yield break;
    }

    int[] ArraySelectIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1697;
        int[] v1698;
        v1698 = new int[(ArrayItems.Length)];
        v1697 = (0);
        for (; v1697 < (ArrayItems.Length); v1697 += 1)
            v1698[v1697] = (ArrayItems[v1697] + v1697);
        return v1698;
    }

    System.Collections.Generic.IEnumerable<double> ArraySelectIndexMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1700;
        v1700 = (0);
        for (; v1700 < (ArrayItems.Length); v1700 += 1)
            yield return (SelectorIndex((ArrayItems[v1700]), v1700));
        yield break;
    }

    double[] ArraySelectIndexMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1702;
        double[] v1703;
        v1703 = new double[(ArrayItems.Length)];
        v1702 = (0);
        for (; v1702 < (ArrayItems.Length); v1702 += 1)
            v1703[v1702] = (SelectorIndex((ArrayItems[v1702]), v1702));
        return v1703;
    }
}public static class StaticSelectTests
{
    [Datapoints]
    private static int[] StaticArrayItems = Enumerable.Range(0, 100).ToArray();
    [NoRewrite]
    public static IEnumerable<int> StaticSelect()
    {
        return StaticArrayItems.Select(x => x + 3);
    } //EndMethod

    public static IEnumerable<int> StaticSelectRewritten()
    {
        return StaticSelectRewritten_ProceduralLinq1(StaticArrayItems);
    } //EndMethod

    static System.Collections.Generic.IEnumerable<int> StaticSelectRewritten_ProceduralLinq1(int[] StaticArrayItems)
    {
        int v1705;
        v1705 = (0);
        for (; v1705 < (StaticArrayItems.Length); v1705 += 1)
            yield return (3 + StaticArrayItems[v1705]);
        yield break;
    }
}}
