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
        int v1458;
        v1458 = 0;
        for (; v1458 < NullItems.Length; v1458++)
            yield return (NullItems[v1458] + 3);
    }

    System.Collections.Generic.IEnumerable<int> NullableSelectRewritten_ProceduralLinq1(int[] NullItems)
    {
        int v1459;
        v1459 = 0;
        for (; v1459 < NullItems.Length; v1459++)
            yield return (NullItems[v1459] + 3);
    }

    System.Collections.Generic.IEnumerable<int> SelectArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1460;
        v1460 = 0;
        for (; v1460 < ArrayItems.Length; v1460++)
            yield return (ArrayItems[v1460] + 3);
    }

    System.Collections.Generic.IEnumerable<int> SelectListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1461;
        int v1462;
        v1461 = ListItems.Count;
        v1462 = 0;
        for (; v1462 < v1461; v1462++)
            yield return (ListItems[v1462] + 3);
    }

    System.Collections.Generic.IEnumerable<int> SelectSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1463;
        v1463 = SimpleListItems.GetEnumerator();
        try
        {
            while (v1463.MoveNext())
                yield return (v1463.Current + 3);
        }
        finally
        {
            v1463.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SelectEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1464;
        v1464 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1464.MoveNext())
                yield return (v1464.Current + 3);
        }
        finally
        {
            v1464.Dispose();
        }
    }

    int[] SelectArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1465;
        int[] v1466;
        v1466 = new int[ArrayItems.Length];
        v1465 = 0;
        for (; v1465 < ArrayItems.Length; v1465++)
            v1466[v1465] = (ArrayItems[v1465] + 3);
        return v1466;
    }

    int[] SelectListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1467;
        int v1468;
        int[] v1469;
        v1467 = ListItems.Count;
        v1469 = new int[v1467];
        v1468 = 0;
        for (; v1468 < v1467; v1468++)
            v1469[v1468] = (ListItems[v1468] + 3);
        return v1469;
    }

    int[] SelectEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1470;
        int v1471;
        int v1472;
        int[] v1473;
        v1470 = EnumerableItems.GetEnumerator();
        v1471 = 0;
        v1472 = 8;
        v1473 = new int[8];
        try
        {
            while (v1470.MoveNext())
            {
                if (v1471 >= v1472)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1473, ref v1472);
                v1473[v1471] = (v1470.Current + 3);
                v1471++;
            }
        }
        finally
        {
            v1470.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1473, v1471);
    }

    int[] SelectSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1474;
        int v1475;
        int v1476;
        int[] v1477;
        v1474 = SimpleListItems.GetEnumerator();
        v1475 = 0;
        v1476 = 8;
        v1477 = new int[8];
        try
        {
            while (v1474.MoveNext())
            {
                if (v1475 >= v1476)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1477, ref v1476);
                v1477[v1475] = (v1474.Current + 3);
                v1475++;
            }
        }
        finally
        {
            v1474.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1477, v1475);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectArrayToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1478;
        int[] v1479;
        SimpleList<int> v1480;
        v1479 = new int[ArrayItems.Length];
        v1478 = 0;
        for (; v1478 < ArrayItems.Length; v1478++)
            v1479[v1478] = (ArrayItems[v1478] + 3);
        v1480 = new SimpleList<int>();
        v1480.Items = v1479;
        v1480.Count = ArrayItems.Length;
        return v1480;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectListToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1481;
        int v1482;
        int[] v1483;
        SimpleList<int> v1484;
        v1481 = ListItems.Count;
        v1483 = new int[v1481];
        v1482 = 0;
        for (; v1482 < v1481; v1482++)
            v1483[v1482] = (ListItems[v1482] + 3);
        v1484 = new SimpleList<int>();
        v1484.Items = v1483;
        v1484.Count = v1481;
        return v1484;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectEnumerableToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1485;
        int v1486;
        int v1487;
        int[] v1488;
        SimpleList<int> v1489;
        v1485 = EnumerableItems.GetEnumerator();
        v1486 = 0;
        v1487 = 8;
        v1488 = new int[8];
        try
        {
            while (v1485.MoveNext())
            {
                if (v1486 >= v1487)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1488, ref v1487);
                v1488[v1486] = (v1485.Current + 3);
                v1486++;
            }
        }
        finally
        {
            v1485.Dispose();
        }

        v1489 = new SimpleList<int>();
        v1489.Items = v1488;
        v1489.Count = v1486;
        return v1489;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectSimpleListToSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1490;
        int v1491;
        int v1492;
        int[] v1493;
        SimpleList<int> v1494;
        v1490 = SimpleListItems.GetEnumerator();
        v1491 = 0;
        v1492 = 8;
        v1493 = new int[8];
        try
        {
            while (v1490.MoveNext())
            {
                if (v1491 >= v1492)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1493, ref v1492);
                v1493[v1491] = (v1490.Current + 3);
                v1491++;
            }
        }
        finally
        {
            v1490.Dispose();
        }

        v1494 = new SimpleList<int>();
        v1494.Items = v1493;
        v1494.Count = v1491;
        return v1494;
    }

    System.Collections.Generic.List<int> SelectArrayToListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1495;
        System.Collections.Generic.List<int> v1496;
        v1496 = new System.Collections.Generic.List<int>();
        v1495 = 0;
        for (; v1495 < ArrayItems.Length; v1495++)
            v1496.Add((ArrayItems[v1495] + 3));
        return v1496;
    }

    System.Collections.Generic.List<int> SelectListToListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1497;
        int v1498;
        System.Collections.Generic.List<int> v1499;
        v1497 = ListItems.Count;
        v1499 = new System.Collections.Generic.List<int>();
        v1498 = 0;
        for (; v1498 < v1497; v1498++)
            v1499.Add((ListItems[v1498] + 3));
        return v1499;
    }

    System.Collections.Generic.List<int> SelectEnumerableToListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1500;
        System.Collections.Generic.List<int> v1501;
        v1500 = EnumerableItems.GetEnumerator();
        v1501 = new System.Collections.Generic.List<int>();
        try
        {
            while (v1500.MoveNext())
                v1501.Add((v1500.Current + 3));
        }
        finally
        {
            v1500.Dispose();
        }

        return v1501;
    }

    System.Collections.Generic.List<int> SelectSimpleListToListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1502;
        System.Collections.Generic.List<int> v1503;
        v1502 = SimpleListItems.GetEnumerator();
        v1503 = new System.Collections.Generic.List<int>();
        try
        {
            while (v1502.MoveNext())
                v1503.Add((v1502.Current + 3));
        }
        finally
        {
            v1502.Dispose();
        }

        return v1503;
    }

    System.Collections.Generic.IEnumerable<int> SelectStaticArrayRewritten_ProceduralLinq1(int[] StaticArrayItems)
    {
        int v1504;
        v1504 = 0;
        for (; v1504 < StaticArrayItems.Length; v1504++)
            yield return (StaticArrayItems[v1504] + 3);
    }

    System.Collections.Generic.IEnumerable<double> SelectMethodSelectorRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1505;
        v1505 = 0;
        for (; v1505 < ArrayItems.Length; v1505++)
            yield return Selector(ArrayItems[v1505]);
    }

    System.Collections.Generic.IEnumerable<double> SelectRetypeRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1506;
        v1506 = 0;
        for (; v1506 < ArrayItems.Length; v1506++)
            yield return ((double)ArrayItems[v1506] + 3);
    }

    System.Collections.Generic.IEnumerable<int[]> SelectArrayFromArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1507;
        v1507 = 0;
        for (; v1507 < ArrayItems.Length; v1507++)
            yield return (ArrayItems);
    }

    static System.Collections.Generic.IEnumerable<int> StaticSelectRewritten_ProceduralLinq1(int[] StaticArrayItems)
    {
        int v1508;
        v1508 = 0;
        for (; v1508 < StaticArrayItems.Length; v1508++)
            yield return (StaticArrayItems[v1508] + 3);
    }

    System.Collections.Generic.IEnumerable<int> SelectParamsRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1509;
        v1509 = 0;
        for (; v1509 < ArrayItems.Length; v1509++)
            yield return (ArrayItems[v1509] + a);
    }

    System.Collections.Generic.IEnumerable<int> SelectMultipleParamsRewritten_ProceduralLinq1(int a, int b, int c, int d, int e, int f, int g, int h, int i, int[] ArrayItems)
    {
        int v1510;
        v1510 = 0;
        for (; v1510 < ArrayItems.Length; v1510++)
            yield return (ArrayItems[v1510] + a + b + c + d + e + f + g + h + i);
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelectRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1511;
        v1511 = 0;
        for (; v1511 < ArrayItems.Length; v1511++)
            yield return ((((((((((ArrayItems[v1511] + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3) + 3);
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelect2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1512;
        int v1513;
        int v1514;
        int v1515;
        int v1516;
        int v1517;
        int v1518;
        int v1519;
        int v1520;
        int v1521;
        v1512 = 0;
        for (; v1512 < ArrayItems.Length; v1512++)
        {
            v1513 = (ArrayItems[v1512] + ArrayItems[v1512]);
            v1514 = (v1513 + v1513);
            v1515 = (v1514 + v1514);
            v1516 = (v1515 + v1515);
            v1517 = (v1516 + v1516);
            v1518 = (v1517 + v1517);
            v1519 = (v1518 + v1518);
            v1520 = (v1519 + v1519);
            v1521 = (v1520 + v1520);
            yield return (v1521 + v1521);
        }
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1523)
    {
        int v1522;
        v1522 = 0;
        for (; v1522 < ArrayItems.Length; v1522++)
            yield return v1523(ArrayItems[v1522]);
    }

    int[] SelectChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1524;
        int[] v1525;
        v1525 = new int[ArrayItems.Length];
        v1524 = 0;
        for (; v1524 < ArrayItems.Length; v1524++)
            v1525[v1524] = (ArrayItems[v1524] + a++);
        return v1525;
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParam3Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1527, System.Func<int, int> v1528, System.Func<int, int> v1529, System.Func<int, int> v1530, System.Func<int, int> v1531)
    {
        int v1526;
        v1526 = 0;
        for (; v1526 < ArrayItems.Length; v1526++)
            yield return v1531(v1530(v1529(v1528(v1527(ArrayItems[v1526])))));
    }

    int[] SelectChangingParam4Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1532;
        int[] v1533;
        v1533 = new int[ArrayItems.Length];
        v1532 = 0;
        for (; v1532 < ArrayItems.Length; v1532++)
            v1533[v1532] = (((((ArrayItems[v1532] + a++) + a++) + a++) + a++) + a++);
        return v1533;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIndexRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1534;
        v1534 = 0;
        for (; v1534 < ArrayItems.Length; v1534++)
            yield return (ArrayItems[v1534] + v1534);
    }

    int[] ArraySelectIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1535;
        int[] v1536;
        v1536 = new int[ArrayItems.Length];
        v1535 = 0;
        for (; v1535 < ArrayItems.Length; v1535++)
            v1536[v1535] = (ArrayItems[v1535] + v1535);
        return v1536;
    }

    System.Collections.Generic.IEnumerable<double> ArraySelectIndexMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1537;
        v1537 = 0;
        for (; v1537 < ArrayItems.Length; v1537++)
            yield return SelectorIndex(ArrayItems[v1537], v1537);
    }

    double[] ArraySelectIndexMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1538;
        double[] v1539;
        v1539 = new double[ArrayItems.Length];
        v1538 = 0;
        for (; v1538 < ArrayItems.Length; v1538++)
            v1539[v1538] = SelectorIndex(ArrayItems[v1538], v1538);
        return v1539;
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
        int v1540;
        v1540 = 0;
        for (; v1540 < StaticArrayItems.Length; v1540++)
            yield return (StaticArrayItems[v1540] + 3);
    }
}}
