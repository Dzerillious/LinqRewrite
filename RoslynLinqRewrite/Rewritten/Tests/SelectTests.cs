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

    System.Collections.Generic.IEnumerable<int> SelectArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v250)
    {
        int v249;
        v249 = 0;
        for (; v249 < ArrayItems.Length; v249++)
            yield return v250(ArrayItems[v249]);
    }

    System.Collections.Generic.IEnumerable<int> SelectListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems, System.Func<int, int> v253)
    {
        int v251;
        int v252;
        v251 = ListItems.Count;
        v252 = 0;
        for (; v252 < v251; v252++)
            yield return v253(ListItems[v252]);
    }

    System.Collections.Generic.IEnumerable<int> SelectSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems, System.Func<int, int> v255)
    {
        IEnumerator<int> v254;
        v254 = SimpleListItems.GetEnumerator();
        try
        {
            while (v254.MoveNext())
                yield return v255(v254.Current);
        }
        finally
        {
            v254.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SelectEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, int> v257)
    {
        IEnumerator<int> v256;
        v256 = EnumerableItems.GetEnumerator();
        try
        {
            while (v256.MoveNext())
                yield return v257(v256.Current);
        }
        finally
        {
            v256.Dispose();
        }
    }

    int[] SelectArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v258;
        int[] v259;
        v259 = new int[ArrayItems.Length];
        v258 = 0;
        for (; v258 < ArrayItems.Length; v258++)
            v259[v258] = (ArrayItems[v258] + 3);
        return v259;
    }

    int[] SelectListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v260;
        int v261;
        int[] v262;
        v260 = ListItems.Count;
        v262 = new int[v260];
        v261 = 0;
        for (; v261 < v260; v261++)
            v262[v261] = (ListItems[v261] + 3);
        return v262;
    }

    int[] SelectEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v263;
        int v264;
        int v265;
        int[] v266;
        v264 = 0;
        v265 = 8;
        v266 = new int[8];
        v263 = EnumerableItems.GetEnumerator();
        try
        {
            while (v263.MoveNext())
            {
                if (v264 >= v265)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v266, ref v265);
                v266[v264] = (v263.Current + 3);
                v264++;
            }
        }
        finally
        {
            v263.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v266, v264);
    }

    int[] SelectSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v267;
        int v268;
        int v269;
        int[] v270;
        v268 = 0;
        v269 = 8;
        v270 = new int[8];
        v267 = SimpleListItems.GetEnumerator();
        try
        {
            while (v267.MoveNext())
            {
                if (v268 >= v269)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v270, ref v269);
                v270[v268] = (v267.Current + 3);
                v268++;
            }
        }
        finally
        {
            v267.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v270, v268);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectArrayToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v271;
        int[] v272;
        SimpleList<int> v273;
        v272 = new int[ArrayItems.Length];
        v271 = 0;
        for (; v271 < ArrayItems.Length; v271++)
            v272[v271] = (ArrayItems[v271] + 3);
        v273 = new SimpleList<int>();
        v273.Items = v272;
        v273.Count = ArrayItems.Length;
        return v273;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectListToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v274;
        int v275;
        int[] v276;
        SimpleList<int> v277;
        v274 = ListItems.Count;
        v276 = new int[v274];
        v275 = 0;
        for (; v275 < v274; v275++)
            v276[v275] = (ListItems[v275] + 3);
        v277 = new SimpleList<int>();
        v277.Items = v276;
        v277.Count = v274;
        return v277;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectEnumerableToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v278;
        int v279;
        int v280;
        int[] v281;
        SimpleList<int> v282;
        v279 = 0;
        v280 = 8;
        v281 = new int[8];
        v278 = EnumerableItems.GetEnumerator();
        try
        {
            while (v278.MoveNext())
            {
                if (v279 >= v280)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v281, ref v280);
                v281[v279] = (v278.Current + 3);
                v279++;
            }
        }
        finally
        {
            v278.Dispose();
        }

        v282 = new SimpleList<int>();
        v282.Items = v281;
        v282.Count = v279;
        return v282;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectSimpleListToSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v283;
        int v284;
        int v285;
        int[] v286;
        SimpleList<int> v287;
        v284 = 0;
        v285 = 8;
        v286 = new int[8];
        v283 = SimpleListItems.GetEnumerator();
        try
        {
            while (v283.MoveNext())
            {
                if (v284 >= v285)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v286, ref v285);
                v286[v284] = (v283.Current + 3);
                v284++;
            }
        }
        finally
        {
            v283.Dispose();
        }

        v287 = new SimpleList<int>();
        v287.Items = v286;
        v287.Count = v284;
        return v287;
    }

    System.Collections.Generic.List<int> SelectArrayToListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v288;
        System.Collections.Generic.List<int> v289;
        v289 = new System.Collections.Generic.List<int>();
        v288 = 0;
        for (; v288 < ArrayItems.Length; v288++)
            v289.Add((ArrayItems[v288] + 3));
        return v289;
    }

    System.Collections.Generic.List<int> SelectListToListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v290;
        int v291;
        System.Collections.Generic.List<int> v292;
        v290 = ListItems.Count;
        v292 = new System.Collections.Generic.List<int>();
        v291 = 0;
        for (; v291 < v290; v291++)
            v292.Add((ListItems[v291] + 3));
        return v292;
    }

    System.Collections.Generic.List<int> SelectEnumerableToListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v293;
        System.Collections.Generic.List<int> v294;
        v294 = new System.Collections.Generic.List<int>();
        v293 = EnumerableItems.GetEnumerator();
        try
        {
            while (v293.MoveNext())
                v294.Add((v293.Current + 3));
        }
        finally
        {
            v293.Dispose();
        }

        return v294;
    }

    System.Collections.Generic.List<int> SelectSimpleListToListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v295;
        System.Collections.Generic.List<int> v296;
        v296 = new System.Collections.Generic.List<int>();
        v295 = SimpleListItems.GetEnumerator();
        try
        {
            while (v295.MoveNext())
                v296.Add((v295.Current + 3));
        }
        finally
        {
            v295.Dispose();
        }

        return v296;
    }

    System.Collections.Generic.IEnumerable<int> SelectStaticArrayRewritten_ProceduralLinq1(int[] StaticArrayItems, System.Func<int, int> v298)
    {
        int v297;
        v297 = 0;
        for (; v297 < StaticArrayItems.Length; v297++)
            yield return v298(StaticArrayItems[v297]);
    }

    System.Collections.Generic.IEnumerable<double> SelectMethodSelectorRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v299;
        v299 = 0;
        for (; v299 < ArrayItems.Length; v299++)
            yield return Selector(ArrayItems[v299]);
    }

    System.Collections.Generic.IEnumerable<double> SelectRetypeRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, double> v301)
    {
        int v300;
        v300 = 0;
        for (; v300 < ArrayItems.Length; v300++)
            yield return v301(ArrayItems[v300]);
    }

    System.Collections.Generic.IEnumerable<int[]> SelectArrayFromArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int[]> v303)
    {
        int v302;
        v302 = 0;
        for (; v302 < ArrayItems.Length; v302++)
            yield return v303(ArrayItems[v302]);
    }

    static System.Collections.Generic.IEnumerable<int> StaticSelectRewritten_ProceduralLinq1(int[] StaticArrayItems, System.Func<int, int> v305)
    {
        int v304;
        v304 = 0;
        for (; v304 < StaticArrayItems.Length; v304++)
            yield return v305(StaticArrayItems[v304]);
    }

    System.Collections.Generic.IEnumerable<int> SelectParamsRewritten_ProceduralLinq1(int a, int[] ArrayItems, System.Func<int, int> v307)
    {
        int v306;
        v306 = 0;
        for (; v306 < ArrayItems.Length; v306++)
            yield return v307(ArrayItems[v306]);
    }

    System.Collections.Generic.IEnumerable<int> SelectMultipleParamsRewritten_ProceduralLinq1(int a, int b, int c, int d, int e, int f, int g, int h, int i, int[] ArrayItems, System.Func<int, int> v309)
    {
        int v308;
        v308 = 0;
        for (; v308 < ArrayItems.Length; v308++)
            yield return v309(ArrayItems[v308]);
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelectRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v311, System.Func<int, int> v312, System.Func<int, int> v313, System.Func<int, int> v314, System.Func<int, int> v315, System.Func<int, int> v316, System.Func<int, int> v317, System.Func<int, int> v318, System.Func<int, int> v319, System.Func<int, int> v320)
    {
        int v310;
        v310 = 0;
        for (; v310 < ArrayItems.Length; v310++)
            yield return v320(v319(v318(v317(v316(v315(v314(v313(v312(v311(ArrayItems[v310]))))))))));
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelect2Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v322, System.Func<int, int> v324, System.Func<int, int> v326, System.Func<int, int> v328, System.Func<int, int> v330, System.Func<int, int> v332, System.Func<int, int> v334, System.Func<int, int> v336, System.Func<int, int> v338, System.Func<int, int> v340)
    {
        int v321;
        int v323;
        int v325;
        int v327;
        int v329;
        int v331;
        int v333;
        int v335;
        int v337;
        int v339;
        v321 = 0;
        for (; v321 < ArrayItems.Length; v321++)
        {
            v323 = v322(ArrayItems[v321]);
            v325 = v324(v323);
            v327 = v326(v325);
            v329 = v328(v327);
            v331 = v330(v329);
            v333 = v332(v331);
            v335 = v334(v333);
            v337 = v336(v335);
            v339 = v338(v337);
            yield return v340(v339);
        }
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v342)
    {
        int v341;
        v341 = 0;
        for (; v341 < ArrayItems.Length; v341++)
            yield return v342(ArrayItems[v341]);
    }

    int[] SelectChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v343;
        int[] v344;
        v344 = new int[ArrayItems.Length];
        v343 = 0;
        for (; v343 < ArrayItems.Length; v343++)
            v344[v343] = (ArrayItems[v343] + a++);
        return v344;
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParam3Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v346, System.Func<int, int> v347, System.Func<int, int> v348, System.Func<int, int> v349, System.Func<int, int> v350)
    {
        int v345;
        v345 = 0;
        for (; v345 < ArrayItems.Length; v345++)
            yield return v350(v349(v348(v347(v346(ArrayItems[v345])))));
    }

    int[] SelectChangingParam4Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v351;
        int[] v352;
        v352 = new int[ArrayItems.Length];
        v351 = 0;
        for (; v351 < ArrayItems.Length; v351++)
            v352[v351] = (((((ArrayItems[v351] + a++) + a++) + a++) + a++) + a++);
        return v352;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIndexRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int, int> v354)
    {
        int v353;
        v353 = 0;
        for (; v353 < ArrayItems.Length; v353++)
            yield return v354(ArrayItems[v353], v353);
    }

    int[] ArraySelectIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v355;
        int[] v356;
        v356 = new int[ArrayItems.Length];
        v355 = 0;
        for (; v355 < ArrayItems.Length; v355++)
            v356[v355] = (ArrayItems[v355] + v355);
        return v356;
    }

    System.Collections.Generic.IEnumerable<double> ArraySelectIndexMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v357;
        v357 = 0;
        for (; v357 < ArrayItems.Length; v357++)
            yield return SelectorIndex(ArrayItems[v357], v357);
    }

    double[] ArraySelectIndexMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v358;
        double[] v359;
        v359 = new double[ArrayItems.Length];
        v358 = 0;
        for (; v358 < ArrayItems.Length; v358++)
            v359[v358] = SelectorIndex(ArrayItems[v358], v358);
        return v359;
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

    static System.Collections.Generic.IEnumerable<int> StaticSelectRewritten_ProceduralLinq1(int[] StaticArrayItems, System.Func<int, int> v361)
    {
        int v360;
        v360 = 0;
        for (; v360 < StaticArrayItems.Length; v360++)
            yield return v361(StaticArrayItems[v360]);
    }
}}
