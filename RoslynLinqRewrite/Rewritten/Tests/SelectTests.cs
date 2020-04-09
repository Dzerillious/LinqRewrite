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
        int v1790;
        v1790 = (0);
        for (; v1790 < (NullItems.Length); v1790++)
            yield return (3 + NullItems[v1790]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> NullableSelectRewritten_ProceduralLinq1(int[] NullItems)
    {
        int v1792;
        v1792 = (0);
        for (; v1792 < (NullItems.Length); v1792++)
            yield return (3 + NullItems[v1792]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1794;
        v1794 = (0);
        for (; v1794 < (ArrayItems.Length); v1794++)
            yield return (3 + ArrayItems[v1794]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1796;
        int v1797;
        v1796 = ListItems.Count;
        v1797 = (0);
        for (; v1797 < (v1796); v1797++)
            yield return (3 + ListItems[v1797]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1799;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1800;
        int v1801;
        v1799 = SimpleListItems.Count;
        v1800 = SimpleListItems;
        v1801 = (0);
        for (; v1801 < (v1799); v1801++)
            yield return (((v1800[v1801]) + 3));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1802;
        v1802 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1802.MoveNext())
                yield return (3 + v1802.Current);
        }
        finally
        {
            v1802.Dispose();
        }

        yield break;
    }

    int[] SelectArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1804;
        int[] v1805;
        v1805 = new int[(ArrayItems.Length)];
        v1804 = (0);
        for (; v1804 < (ArrayItems.Length); v1804++)
            v1805[v1804] = (3 + ArrayItems[v1804]);
        return v1805;
    }

    int[] SelectListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1807;
        int v1808;
        int[] v1809;
        v1807 = ListItems.Count;
        v1809 = new int[(v1807)];
        v1808 = (0);
        for (; v1808 < (v1807); v1808++)
            v1809[v1808] = (3 + ListItems[v1808]);
        return v1809;
    }

    int[] SelectEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1810;
        int v1811;
        int v1812;
        int[] v1813;
        v1810 = EnumerableItems.GetEnumerator();
        v1811 = 0;
        v1812 = 8;
        v1813 = new int[8];
        try
        {
            while (v1810.MoveNext())
            {
                if (v1811 >= v1812)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1813, ref v1812);
                v1813[v1811] = (3 + v1810.Current);
                v1811++;
            }
        }
        finally
        {
            v1810.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1813, v1811);
    }

    int[] SelectSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1815;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1816;
        int v1817;
        int[] v1818;
        v1815 = SimpleListItems.Count;
        v1816 = SimpleListItems;
        v1818 = new int[(v1815)];
        v1817 = (0);
        for (; v1817 < (v1815); v1817++)
            v1818[v1817] = (((v1816[v1817]) + 3));
        return v1818;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectArrayToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1820;
        int[] v1821;
        SimpleList<int> v1822;
        v1821 = new int[(ArrayItems.Length)];
        v1820 = (0);
        for (; v1820 < (ArrayItems.Length); v1820++)
            v1821[v1820] = (3 + ArrayItems[v1820]);
        v1822 = new SimpleList<int>();
        v1822.Items = v1821;
        v1822.Count = (ArrayItems.Length);
        return v1822;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectListToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1824;
        int v1825;
        int[] v1826;
        SimpleList<int> v1827;
        v1824 = ListItems.Count;
        v1826 = new int[(v1824)];
        v1825 = (0);
        for (; v1825 < (v1824); v1825++)
            v1826[v1825] = (3 + ListItems[v1825]);
        v1827 = new SimpleList<int>();
        v1827.Items = v1826;
        v1827.Count = (v1824);
        return v1827;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectEnumerableToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1828;
        int v1829;
        int v1830;
        int[] v1831;
        SimpleList<int> v1832;
        v1828 = EnumerableItems.GetEnumerator();
        v1829 = 0;
        v1830 = 8;
        v1831 = new int[8];
        try
        {
            while (v1828.MoveNext())
            {
                if (v1829 >= v1830)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1831, ref v1830);
                v1831[v1829] = (3 + v1828.Current);
                v1829++;
            }
        }
        finally
        {
            v1828.Dispose();
        }

        v1832 = new SimpleList<int>();
        v1832.Items = v1831;
        v1832.Count = v1829;
        return v1832;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectSimpleListToSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1834;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1835;
        int v1836;
        int[] v1837;
        SimpleList<int> v1838;
        v1834 = SimpleListItems.Count;
        v1835 = SimpleListItems;
        v1837 = new int[(v1834)];
        v1836 = (0);
        for (; v1836 < (v1834); v1836++)
            v1837[v1836] = (((v1835[v1836]) + 3));
        v1838 = new SimpleList<int>();
        v1838.Items = v1837;
        v1838.Count = (v1834);
        return v1838;
    }

    System.Collections.Generic.List<int> SelectArrayToListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1840;
        System.Collections.Generic.List<int> v1841;
        v1841 = new System.Collections.Generic.List<int>();
        v1840 = (0);
        for (; v1840 < (ArrayItems.Length); v1840++)
            v1841.Add((3 + ArrayItems[v1840]));
        return v1841;
    }

    System.Collections.Generic.List<int> SelectListToListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1843;
        int v1844;
        System.Collections.Generic.List<int> v1845;
        v1843 = ListItems.Count;
        v1845 = new System.Collections.Generic.List<int>();
        v1844 = (0);
        for (; v1844 < (v1843); v1844++)
            v1845.Add((3 + ListItems[v1844]));
        return v1845;
    }

    System.Collections.Generic.List<int> SelectEnumerableToListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1846;
        System.Collections.Generic.List<int> v1847;
        v1846 = EnumerableItems.GetEnumerator();
        v1847 = new System.Collections.Generic.List<int>();
        try
        {
            while (v1846.MoveNext())
                v1847.Add((3 + v1846.Current));
        }
        finally
        {
            v1846.Dispose();
        }

        return v1847;
    }

    System.Collections.Generic.List<int> SelectSimpleListToListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1849;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1850;
        int v1851;
        System.Collections.Generic.List<int> v1852;
        v1849 = SimpleListItems.Count;
        v1850 = SimpleListItems;
        v1852 = new System.Collections.Generic.List<int>();
        v1851 = (0);
        for (; v1851 < (v1849); v1851++)
            v1852.Add((((v1850[v1851]) + 3)));
        return v1852;
    }

    System.Collections.Generic.IEnumerable<int> SelectStaticArrayRewritten_ProceduralLinq1(int[] StaticArrayItems)
    {
        int v1854;
        v1854 = (0);
        for (; v1854 < (StaticArrayItems.Length); v1854++)
            yield return (3 + StaticArrayItems[v1854]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<double> SelectMethodSelectorRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1856;
        v1856 = (0);
        for (; v1856 < (ArrayItems.Length); v1856++)
            yield return (Selector((ArrayItems[v1856])));
        yield break;
    }

    System.Collections.Generic.IEnumerable<double> SelectRetypeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1858;
        v1858 = (0);
        for (; v1858 < (ArrayItems.Length); v1858++)
            yield return (((double)(ArrayItems[v1858]) + 3));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int[]> SelectArrayFromArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1860;
        v1860 = (0);
        for (; v1860 < (ArrayItems.Length); v1860++)
            yield return (ArrayItems);
        yield break;
    }

    static System.Collections.Generic.IEnumerable<int> StaticSelectRewritten_ProceduralLinq1(int[] StaticArrayItems)
    {
        int v1862;
        v1862 = (0);
        for (; v1862 < (StaticArrayItems.Length); v1862++)
            yield return (3 + StaticArrayItems[v1862]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectParamsRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1864;
        v1864 = (0);
        for (; v1864 < (ArrayItems.Length); v1864++)
            yield return (ArrayItems[v1864] + a);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectMultipleParamsRewritten_ProceduralLinq1(int a, int b, int c, int d, int e, int f, int g, int h, int i, int[] ArrayItems)
    {
        int v1866;
        v1866 = (0);
        for (; v1866 < (ArrayItems.Length); v1866++)
            yield return (ArrayItems[v1866] + i + a + b + c + d + e + f + g + h);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelectRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1868;
        v1868 = (0);
        for (; v1868 < (ArrayItems.Length); v1868++)
            yield return (30 + ArrayItems[v1868]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelect2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1870;
        v1870 = (0);
        for (; v1870 < (ArrayItems.Length); v1870++)
            yield return (1024 * ArrayItems[v1870]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1872)
    {
        int v1871;
        v1871 = (0);
        for (; v1871 < (ArrayItems.Length); v1871++)
            yield return (v1872((ArrayItems[v1871])));
        yield break;
    }

    int[] SelectChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1873;
        int[] v1874;
        v1874 = new int[(ArrayItems.Length)];
        v1873 = (0);
        for (; v1873 < (ArrayItems.Length); v1873++)
            v1874[v1873] = (((ArrayItems[v1873]) + a++));
        return v1874;
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParam3Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1876, System.Func<int, int> v1877, System.Func<int, int> v1878, System.Func<int, int> v1879, System.Func<int, int> v1880)
    {
        int v1875;
        v1875 = (0);
        for (; v1875 < (ArrayItems.Length); v1875++)
            yield return (v1880((v1879((v1878((v1877((v1876((ArrayItems[v1875])))))))))));
        yield break;
    }

    int[] SelectChangingParam4Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1881;
        int[] v1882;
        v1882 = new int[(ArrayItems.Length)];
        v1881 = (0);
        for (; v1881 < (ArrayItems.Length); v1881++)
            v1882[v1881] = (((((((((((ArrayItems[v1881]) + a++)) + a++)) + a++)) + a++)) + a++));
        return v1882;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIndexRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1884;
        v1884 = (0);
        for (; v1884 < (ArrayItems.Length); v1884++)
            yield return (ArrayItems[v1884] + v1884);
        yield break;
    }

    int[] ArraySelectIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1886;
        int[] v1887;
        v1887 = new int[(ArrayItems.Length)];
        v1886 = (0);
        for (; v1886 < (ArrayItems.Length); v1886++)
            v1887[v1886] = (ArrayItems[v1886] + v1886);
        return v1887;
    }

    System.Collections.Generic.IEnumerable<double> ArraySelectIndexMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1889;
        v1889 = (0);
        for (; v1889 < (ArrayItems.Length); v1889++)
            yield return (SelectorIndex((ArrayItems[v1889]), v1889));
        yield break;
    }

    double[] ArraySelectIndexMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1891;
        double[] v1892;
        v1892 = new double[(ArrayItems.Length)];
        v1891 = (0);
        for (; v1891 < (ArrayItems.Length); v1891++)
            v1892[v1891] = (SelectorIndex((ArrayItems[v1891]), v1891));
        return v1892;
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
        int v1894;
        v1894 = (0);
        for (; v1894 < (StaticArrayItems.Length); v1894++)
            yield return (3 + StaticArrayItems[v1894]);
        yield break;
    }
}}
