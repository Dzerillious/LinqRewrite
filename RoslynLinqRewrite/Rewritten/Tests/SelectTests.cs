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
    public IEnumerable<int> SelectArray()
    {
        return ArrayItems.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> SelectArrayRewritten()
    {
        return SelectArrayRewritten_ProceduralLinq1(ArrayItems, x => x + 3);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectList()
    {
        return ListItems.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> SelectListRewritten()
    {
        return SelectListRewritten_ProceduralLinq1(ListItems, x => x + 3);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectSimpleList()
    {
        return SimpleListItems.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> SelectSimpleListRewritten()
    {
        return SelectSimpleListRewritten_ProceduralLinq1(SimpleListItems, x => x + 3);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectEnumerable()
    {
        return EnumerableItems.Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> SelectEnumerableRewritten()
    {
        return SelectEnumerableRewritten_ProceduralLinq1(EnumerableItems, x => x + 3);
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
        return SelectStaticArrayRewritten_ProceduralLinq1(StaticArrayItems, x => x + 3);
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
        return SelectRetypeRewritten_ProceduralLinq1(ArrayItems, x => (double)x + 3);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int[]> SelectArrayFromArray()
    {
        return ArrayItems.Select(x => ArrayItems);
    } //EndMethod

    public IEnumerable<int[]> SelectArrayFromArrayRewritten()
    {
        return SelectArrayFromArrayRewritten_ProceduralLinq1(ArrayItems, x => ArrayItems);
    } //EndMethod

    [NoRewrite]
    public static IEnumerable<int> StaticSelect()
    {
        return StaticArrayItems.Select(x => x + 3);
    } //EndMethod

    public static IEnumerable<int> StaticSelectRewritten()
    {
        return StaticSelectRewritten_ProceduralLinq1(StaticArrayItems, x => x + 3);
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
        return SelectParamsRewritten_ProceduralLinq1(a, ArrayItems, x => x + a);
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
        return SelectMultipleParamsRewritten_ProceduralLinq1(a, b, c, d, e, f, g, h, i, ArrayItems, x => x + a + b + c + d + e + f + g + h + i);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MultipleSelect()
    {
        return ArrayItems.Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3).Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> MultipleSelectRewritten()
    {
        return MultipleSelectRewritten_ProceduralLinq1(ArrayItems, x => x + 3, x => x + 3, x => x + 3, x => x + 3, x => x + 3, x => x + 3, x => x + 3, x => x + 3, x => x + 3, x => x + 3);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MultipleSelect2()
    {
        return ArrayItems.Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x).Select(x => x + x);
    } //EndMethod

    public IEnumerable<int> MultipleSelect2Rewritten()
    {
        return MultipleSelect2Rewritten_ProceduralLinq1(ArrayItems, x => x + x, x => x + x, x => x + x, x => x + x, x => x + x, x => x + x, x => x + x, x => x + x, x => x + x, x => x + x);
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
        return ArraySelectIndexRewritten_ProceduralLinq1(ArrayItems, (x, i) => x + i);
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

    System.Collections.Generic.IEnumerable<int> SelectArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1490)
    {
        int v1489;
        v1489 = 0;
        for (; v1489 < ArrayItems.Length; v1489++)
            yield return v1490(ArrayItems[v1489]);
    }

    System.Collections.Generic.IEnumerable<int> SelectListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems, System.Func<int, int> v1493)
    {
        int v1491;
        int v1492;
        v1491 = ListItems.Count;
        v1492 = 0;
        for (; v1492 < v1491; v1492++)
            yield return v1493(ListItems[v1492]);
    }

    System.Collections.Generic.IEnumerable<int> SelectSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems, System.Func<int, int> v1495)
    {
        IEnumerator<int> v1494;
        v1494 = SimpleListItems.GetEnumerator();
        try
        {
            while (v1494.MoveNext())
                yield return v1495(v1494.Current);
        }
        finally
        {
            v1494.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SelectEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, int> v1497)
    {
        IEnumerator<int> v1496;
        v1496 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1496.MoveNext())
                yield return v1497(v1496.Current);
        }
        finally
        {
            v1496.Dispose();
        }
    }

    int[] SelectArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1498;
        int[] v1499;
        v1499 = new int[ArrayItems.Length];
        v1498 = 0;
        for (; v1498 < ArrayItems.Length; v1498++)
            v1499[v1498] = (ArrayItems[v1498] + 3);
        return v1499;
    }

    int[] SelectListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1500;
        int v1501;
        int[] v1502;
        v1500 = ListItems.Count;
        v1502 = new int[v1500];
        v1501 = 0;
        for (; v1501 < v1500; v1501++)
            v1502[v1501] = (ListItems[v1501] + 3);
        return v1502;
    }

    int[] SelectEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1503;
        int v1504;
        int v1505;
        int[] v1506;
        v1503 = EnumerableItems.GetEnumerator();
        v1504 = 0;
        v1505 = 8;
        v1506 = new int[8];
        try
        {
            while (v1503.MoveNext())
            {
                if (v1504 >= v1505)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1506, ref v1505);
                v1506[v1504] = (v1503.Current + 3);
                v1504++;
            }
        }
        finally
        {
            v1503.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1506, v1504);
    }

    int[] SelectSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1507;
        int v1508;
        int v1509;
        int[] v1510;
        v1507 = SimpleListItems.GetEnumerator();
        v1508 = 0;
        v1509 = 8;
        v1510 = new int[8];
        try
        {
            while (v1507.MoveNext())
            {
                if (v1508 >= v1509)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1510, ref v1509);
                v1510[v1508] = (v1507.Current + 3);
                v1508++;
            }
        }
        finally
        {
            v1507.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1510, v1508);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectArrayToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1511;
        int[] v1512;
        SimpleList<int> v1513;
        v1512 = new int[ArrayItems.Length];
        v1511 = 0;
        for (; v1511 < ArrayItems.Length; v1511++)
            v1512[v1511] = (ArrayItems[v1511] + 3);
        v1513 = new SimpleList<int>();
        v1513.Items = v1512;
        v1513.Count = ArrayItems.Length;
        return v1513;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectListToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1514;
        int v1515;
        int[] v1516;
        SimpleList<int> v1517;
        v1514 = ListItems.Count;
        v1516 = new int[v1514];
        v1515 = 0;
        for (; v1515 < v1514; v1515++)
            v1516[v1515] = (ListItems[v1515] + 3);
        v1517 = new SimpleList<int>();
        v1517.Items = v1516;
        v1517.Count = v1514;
        return v1517;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectEnumerableToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1518;
        int v1519;
        int v1520;
        int[] v1521;
        SimpleList<int> v1522;
        v1518 = EnumerableItems.GetEnumerator();
        v1519 = 0;
        v1520 = 8;
        v1521 = new int[8];
        try
        {
            while (v1518.MoveNext())
            {
                if (v1519 >= v1520)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1521, ref v1520);
                v1521[v1519] = (v1518.Current + 3);
                v1519++;
            }
        }
        finally
        {
            v1518.Dispose();
        }

        v1522 = new SimpleList<int>();
        v1522.Items = v1521;
        v1522.Count = v1519;
        return v1522;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectSimpleListToSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1523;
        int v1524;
        int v1525;
        int[] v1526;
        SimpleList<int> v1527;
        v1523 = SimpleListItems.GetEnumerator();
        v1524 = 0;
        v1525 = 8;
        v1526 = new int[8];
        try
        {
            while (v1523.MoveNext())
            {
                if (v1524 >= v1525)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1526, ref v1525);
                v1526[v1524] = (v1523.Current + 3);
                v1524++;
            }
        }
        finally
        {
            v1523.Dispose();
        }

        v1527 = new SimpleList<int>();
        v1527.Items = v1526;
        v1527.Count = v1524;
        return v1527;
    }

    System.Collections.Generic.List<int> SelectArrayToListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1528;
        System.Collections.Generic.List<int> v1529;
        v1529 = new System.Collections.Generic.List<int>();
        v1528 = 0;
        for (; v1528 < ArrayItems.Length; v1528++)
            v1529.Add((ArrayItems[v1528] + 3));
        return v1529;
    }

    System.Collections.Generic.List<int> SelectListToListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v1530;
        int v1531;
        System.Collections.Generic.List<int> v1532;
        v1530 = ListItems.Count;
        v1532 = new System.Collections.Generic.List<int>();
        v1531 = 0;
        for (; v1531 < v1530; v1531++)
            v1532.Add((ListItems[v1531] + 3));
        return v1532;
    }

    System.Collections.Generic.List<int> SelectEnumerableToListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1533;
        System.Collections.Generic.List<int> v1534;
        v1533 = EnumerableItems.GetEnumerator();
        v1534 = new System.Collections.Generic.List<int>();
        try
        {
            while (v1533.MoveNext())
                v1534.Add((v1533.Current + 3));
        }
        finally
        {
            v1533.Dispose();
        }

        return v1534;
    }

    System.Collections.Generic.List<int> SelectSimpleListToListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1535;
        System.Collections.Generic.List<int> v1536;
        v1535 = SimpleListItems.GetEnumerator();
        v1536 = new System.Collections.Generic.List<int>();
        try
        {
            while (v1535.MoveNext())
                v1536.Add((v1535.Current + 3));
        }
        finally
        {
            v1535.Dispose();
        }

        return v1536;
    }

    System.Collections.Generic.IEnumerable<int> SelectStaticArrayRewritten_ProceduralLinq1(int[] StaticArrayItems, System.Func<int, int> v1538)
    {
        int v1537;
        v1537 = 0;
        for (; v1537 < StaticArrayItems.Length; v1537++)
            yield return v1538(StaticArrayItems[v1537]);
    }

    System.Collections.Generic.IEnumerable<double> SelectMethodSelectorRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1539;
        v1539 = 0;
        for (; v1539 < ArrayItems.Length; v1539++)
            yield return Selector(ArrayItems[v1539]);
    }

    System.Collections.Generic.IEnumerable<double> SelectRetypeRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, double> v1541)
    {
        int v1540;
        v1540 = 0;
        for (; v1540 < ArrayItems.Length; v1540++)
            yield return v1541(ArrayItems[v1540]);
    }

    System.Collections.Generic.IEnumerable<int[]> SelectArrayFromArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int[]> v1543)
    {
        int v1542;
        v1542 = 0;
        for (; v1542 < ArrayItems.Length; v1542++)
            yield return v1543(ArrayItems[v1542]);
    }

    static System.Collections.Generic.IEnumerable<int> StaticSelectRewritten_ProceduralLinq1(int[] StaticArrayItems, System.Func<int, int> v1545)
    {
        int v1544;
        v1544 = 0;
        for (; v1544 < StaticArrayItems.Length; v1544++)
            yield return v1545(StaticArrayItems[v1544]);
    }

    System.Collections.Generic.IEnumerable<int> SelectParamsRewritten_ProceduralLinq1(int a, int[] ArrayItems, System.Func<int, int> v1547)
    {
        int v1546;
        v1546 = 0;
        for (; v1546 < ArrayItems.Length; v1546++)
            yield return v1547(ArrayItems[v1546]);
    }

    System.Collections.Generic.IEnumerable<int> SelectMultipleParamsRewritten_ProceduralLinq1(int a, int b, int c, int d, int e, int f, int g, int h, int i, int[] ArrayItems, System.Func<int, int> v1549)
    {
        int v1548;
        v1548 = 0;
        for (; v1548 < ArrayItems.Length; v1548++)
            yield return v1549(ArrayItems[v1548]);
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelectRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1551, System.Func<int, int> v1552, System.Func<int, int> v1553, System.Func<int, int> v1554, System.Func<int, int> v1555, System.Func<int, int> v1556, System.Func<int, int> v1557, System.Func<int, int> v1558, System.Func<int, int> v1559, System.Func<int, int> v1560)
    {
        int v1550;
        v1550 = 0;
        for (; v1550 < ArrayItems.Length; v1550++)
            yield return v1560(v1559(v1558(v1557(v1556(v1555(v1554(v1553(v1552(v1551(ArrayItems[v1550]))))))))));
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelect2Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1562, System.Func<int, int> v1564, System.Func<int, int> v1566, System.Func<int, int> v1568, System.Func<int, int> v1570, System.Func<int, int> v1572, System.Func<int, int> v1574, System.Func<int, int> v1576, System.Func<int, int> v1578, System.Func<int, int> v1580)
    {
        int v1561;
        int v1563;
        int v1565;
        int v1567;
        int v1569;
        int v1571;
        int v1573;
        int v1575;
        int v1577;
        int v1579;
        v1561 = 0;
        for (; v1561 < ArrayItems.Length; v1561++)
        {
            v1563 = v1562(ArrayItems[v1561]);
            v1565 = v1564(v1563);
            v1567 = v1566(v1565);
            v1569 = v1568(v1567);
            v1571 = v1570(v1569);
            v1573 = v1572(v1571);
            v1575 = v1574(v1573);
            v1577 = v1576(v1575);
            v1579 = v1578(v1577);
            yield return v1580(v1579);
        }
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1582)
    {
        int v1581;
        v1581 = 0;
        for (; v1581 < ArrayItems.Length; v1581++)
            yield return v1582(ArrayItems[v1581]);
    }

    int[] SelectChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1583;
        int[] v1584;
        v1584 = new int[ArrayItems.Length];
        v1583 = 0;
        for (; v1583 < ArrayItems.Length; v1583++)
            v1584[v1583] = (ArrayItems[v1583] + a++);
        return v1584;
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParam3Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1586, System.Func<int, int> v1587, System.Func<int, int> v1588, System.Func<int, int> v1589, System.Func<int, int> v1590)
    {
        int v1585;
        v1585 = 0;
        for (; v1585 < ArrayItems.Length; v1585++)
            yield return v1590(v1589(v1588(v1587(v1586(ArrayItems[v1585])))));
    }

    int[] SelectChangingParam4Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1591;
        int[] v1592;
        v1592 = new int[ArrayItems.Length];
        v1591 = 0;
        for (; v1591 < ArrayItems.Length; v1591++)
            v1592[v1591] = (((((ArrayItems[v1591] + a++) + a++) + a++) + a++) + a++);
        return v1592;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIndexRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int, int> v1594)
    {
        int v1593;
        v1593 = 0;
        for (; v1593 < ArrayItems.Length; v1593++)
            yield return v1594(ArrayItems[v1593], v1593);
    }

    int[] ArraySelectIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1595;
        int[] v1596;
        v1596 = new int[ArrayItems.Length];
        v1595 = 0;
        for (; v1595 < ArrayItems.Length; v1595++)
            v1596[v1595] = (ArrayItems[v1595] + v1595);
        return v1596;
    }

    System.Collections.Generic.IEnumerable<double> ArraySelectIndexMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1597;
        v1597 = 0;
        for (; v1597 < ArrayItems.Length; v1597++)
            yield return SelectorIndex(ArrayItems[v1597], v1597);
    }

    double[] ArraySelectIndexMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1598;
        double[] v1599;
        v1599 = new double[ArrayItems.Length];
        v1598 = 0;
        for (; v1598 < ArrayItems.Length; v1598++)
            v1599[v1598] = SelectorIndex(ArrayItems[v1598], v1598);
        return v1599;
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
        return StaticSelectRewritten_ProceduralLinq1(StaticArrayItems, x => x + 3);
    } //EndMethod

    static System.Collections.Generic.IEnumerable<int> StaticSelectRewritten_ProceduralLinq1(int[] StaticArrayItems, System.Func<int, int> v1601)
    {
        int v1600;
        v1600 = 0;
        for (; v1600 < StaticArrayItems.Length; v1600++)
            yield return v1601(StaticArrayItems[v1600]);
    }
}}
