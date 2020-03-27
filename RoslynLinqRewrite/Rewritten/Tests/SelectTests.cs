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
        SelectArray().TestEquals(nameof(SelectArray), SelectArrayRewritten());
        SelectList().TestEquals(nameof(SelectList), SelectListRewritten());
        SelectSimpleList().TestEquals(nameof(SelectSimpleList), SelectSimpleListRewritten());
        SelectEnumerable().TestEquals(nameof(SelectEnumerable), SelectEnumerableRewritten());
        SelectArrayToArray().TestEquals(nameof(SelectArrayToArray), SelectArrayToArrayRewritten());
        SelectListToArray().TestEquals(nameof(SelectListToArray), SelectListToArrayRewritten());
        SelectEnumerableToArray().TestEquals(nameof(SelectEnumerableToArray), SelectEnumerableToArrayRewritten());
        SelectSimpleListToArray().TestEquals(nameof(SelectSimpleListToArray), SelectSimpleListToArrayRewritten());
        SelectArrayToSimpleList().TestEquals(nameof(SelectArrayToSimpleList), SelectArrayToSimpleListRewritten());
        SelectListToSimpleList().TestEquals(nameof(SelectListToSimpleList), SelectListToSimpleListRewritten());
        SelectEnumerableToSimpleList().TestEquals(nameof(SelectEnumerableToSimpleList), SelectEnumerableToSimpleListRewritten());
        SelectSimpleListToSimpleList().TestEquals(nameof(SelectSimpleListToSimpleList), SelectSimpleListToSimpleListRewritten());
        SelectArrayToList().TestEquals(nameof(SelectArrayToList), SelectArrayToListRewritten());
        SelectListToList().TestEquals(nameof(SelectListToList), SelectListToListRewritten());
        SelectEnumerableToList().TestEquals(nameof(SelectEnumerableToList), SelectEnumerableToListRewritten());
        SelectSimpleListToList().TestEquals(nameof(SelectSimpleListToList), SelectSimpleListToListRewritten());
        SelectStaticArray().TestEquals(nameof(SelectStaticArray), SelectStaticArrayRewritten());
        SelectMethodSelector().TestEquals(nameof(SelectMethodSelector), SelectMethodSelectorRewritten());
        SelectRetype().TestEquals(nameof(SelectRetype), SelectRetypeRewritten());
        SelectArrayFromArray().TestEquals(nameof(SelectArrayFromArray), SelectArrayFromArrayRewritten());
        StaticSelect().TestEquals(nameof(StaticSelect), StaticSelectRewritten());
        StaticClassSelect().TestEquals(nameof(StaticClassSelect), StaticClassSelectRewritten());
        SelectParams().TestEquals(nameof(SelectParams), SelectParamsRewritten());
        SelectMultipleParams().TestEquals(nameof(SelectMultipleParams), SelectMultipleParamsRewritten());
        MultipleSelect().TestEquals(nameof(MultipleSelect), MultipleSelectRewritten());
        MultipleSelect2().TestEquals(nameof(MultipleSelect2), MultipleSelect2Rewritten());
        SelectChangingParam().TestEquals(nameof(SelectChangingParam), SelectChangingParamRewritten());
        SelectChangingParam2().TestEquals(nameof(SelectChangingParam2), SelectChangingParam2Rewritten());
        SelectChangingParam3().TestEquals(nameof(SelectChangingParam3), SelectChangingParam3Rewritten());
        SelectChangingParam4().TestEquals(nameof(SelectChangingParam4), SelectChangingParam4Rewritten());
        StaticSelect().TestEquals(nameof(StaticSelect), StaticSelectRewritten());
        ArraySelectIndex().TestEquals(nameof(ArraySelectIndex), ArraySelectIndexRewritten());
        ArraySelectIndexToArray().TestEquals(nameof(ArraySelectIndexToArray), ArraySelectIndexToArrayRewritten());
        ArraySelectIndexMethodToArray().TestEquals(nameof(ArraySelectIndexMethodToArray), ArraySelectIndexMethodToArrayRewritten());
        ArraySelectIndexMethod().TestEquals(nameof(ArraySelectIndexMethod), ArraySelectIndexMethodRewritten());
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

    System.Collections.Generic.IEnumerable<int> SelectArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v196)
    {
        int v195;
        v195 = 0;
        for (; v195 < ArrayItems.Length; v195++)
            yield return v196(ArrayItems[v195]);
    }

    System.Collections.Generic.IEnumerable<int> SelectListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems, System.Func<int, int> v199)
    {
        int v197;
        int v198;
        v197 = ListItems.Count;
        v198 = 0;
        for (; v198 < v197; v198++)
            yield return v199(ListItems[v198]);
    }

    System.Collections.Generic.IEnumerable<int> SelectSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems, System.Func<int, int> v201)
    {
        IEnumerator<int> v200;
        v200 = SimpleListItems.GetEnumerator();
        try
        {
            while (v200.MoveNext())
                yield return v201(v200.Current);
        }
        finally
        {
            v200.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SelectEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, int> v203)
    {
        IEnumerator<int> v202;
        v202 = EnumerableItems.GetEnumerator();
        try
        {
            while (v202.MoveNext())
                yield return v203(v202.Current);
        }
        finally
        {
            v202.Dispose();
        }
    }

    int[] SelectArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v204;
        int[] v205;
        v205 = new int[ArrayItems.Length];
        v204 = 0;
        for (; v204 < ArrayItems.Length; v204++)
            v205[v204] = (ArrayItems[v204] + 3);
        return v205;
    }

    int[] SelectListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v206;
        int v207;
        int[] v208;
        v206 = ListItems.Count;
        v208 = new int[v206];
        v207 = 0;
        for (; v207 < v206; v207++)
            v208[v207] = (ListItems[v207] + 3);
        return v208;
    }

    int[] SelectEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v209;
        int v210;
        int v211;
        int[] v212;
        v210 = 0;
        v211 = 8;
        v212 = new int[8];
        v209 = EnumerableItems.GetEnumerator();
        try
        {
            while (v209.MoveNext())
            {
                if (v210 >= v211)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v212, ref v211);
                v212[v210] = (v209.Current + 3);
                v210++;
            }
        }
        finally
        {
            v209.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v212, v210);
    }

    int[] SelectSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v213;
        int v214;
        int v215;
        int[] v216;
        v214 = 0;
        v215 = 8;
        v216 = new int[8];
        v213 = SimpleListItems.GetEnumerator();
        try
        {
            while (v213.MoveNext())
            {
                if (v214 >= v215)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v216, ref v215);
                v216[v214] = (v213.Current + 3);
                v214++;
            }
        }
        finally
        {
            v213.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v216, v214);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectArrayToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v217;
        int[] v218;
        SimpleList<int> v219;
        v218 = new int[ArrayItems.Length];
        v217 = 0;
        for (; v217 < ArrayItems.Length; v217++)
            v218[v217] = (ArrayItems[v217] + 3);
        v219 = new SimpleList<int>();
        v219.Items = v218;
        v219.Count = ArrayItems.Length;
        return v219;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectListToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v220;
        int v221;
        int[] v222;
        SimpleList<int> v223;
        v220 = ListItems.Count;
        v222 = new int[v220];
        v221 = 0;
        for (; v221 < v220; v221++)
            v222[v221] = (ListItems[v221] + 3);
        v223 = new SimpleList<int>();
        v223.Items = v222;
        v223.Count = v220;
        return v223;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectEnumerableToSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v224;
        int v225;
        int v226;
        int[] v227;
        SimpleList<int> v228;
        v225 = 0;
        v226 = 8;
        v227 = new int[8];
        v224 = EnumerableItems.GetEnumerator();
        try
        {
            while (v224.MoveNext())
            {
                if (v225 >= v226)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v227, ref v226);
                v227[v225] = (v224.Current + 3);
                v225++;
            }
        }
        finally
        {
            v224.Dispose();
        }

        v228 = new SimpleList<int>();
        v228.Items = v227;
        v228.Count = v225;
        return v228;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectSimpleListToSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v229;
        int v230;
        int v231;
        int[] v232;
        SimpleList<int> v233;
        v230 = 0;
        v231 = 8;
        v232 = new int[8];
        v229 = SimpleListItems.GetEnumerator();
        try
        {
            while (v229.MoveNext())
            {
                if (v230 >= v231)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v232, ref v231);
                v232[v230] = (v229.Current + 3);
                v230++;
            }
        }
        finally
        {
            v229.Dispose();
        }

        v233 = new SimpleList<int>();
        v233.Items = v232;
        v233.Count = v230;
        return v233;
    }

    System.Collections.Generic.List<int> SelectArrayToListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v234;
        System.Collections.Generic.List<int> v235;
        v235 = new System.Collections.Generic.List<int>();
        v234 = 0;
        for (; v234 < ArrayItems.Length; v234++)
            v235.Add((ArrayItems[v234] + 3));
        return v235;
    }

    System.Collections.Generic.List<int> SelectListToListRewritten_ProceduralLinq1(System.Collections.Generic.List<int> ListItems)
    {
        int v236;
        int v237;
        System.Collections.Generic.List<int> v238;
        v236 = ListItems.Count;
        v238 = new System.Collections.Generic.List<int>();
        v237 = 0;
        for (; v237 < v236; v237++)
            v238.Add((ListItems[v237] + 3));
        return v238;
    }

    System.Collections.Generic.List<int> SelectEnumerableToListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v239;
        System.Collections.Generic.List<int> v240;
        v240 = new System.Collections.Generic.List<int>();
        v239 = EnumerableItems.GetEnumerator();
        try
        {
            while (v239.MoveNext())
                v240.Add((v239.Current + 3));
        }
        finally
        {
            v239.Dispose();
        }

        return v240;
    }

    System.Collections.Generic.List<int> SelectSimpleListToListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v241;
        System.Collections.Generic.List<int> v242;
        v242 = new System.Collections.Generic.List<int>();
        v241 = SimpleListItems.GetEnumerator();
        try
        {
            while (v241.MoveNext())
                v242.Add((v241.Current + 3));
        }
        finally
        {
            v241.Dispose();
        }

        return v242;
    }

    System.Collections.Generic.IEnumerable<int> SelectStaticArrayRewritten_ProceduralLinq1(int[] StaticArrayItems, System.Func<int, int> v244)
    {
        int v243;
        v243 = 0;
        for (; v243 < StaticArrayItems.Length; v243++)
            yield return v244(StaticArrayItems[v243]);
    }

    System.Collections.Generic.IEnumerable<double> SelectMethodSelectorRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v245;
        v245 = 0;
        for (; v245 < ArrayItems.Length; v245++)
            yield return Selector(ArrayItems[v245]);
    }

    System.Collections.Generic.IEnumerable<double> SelectRetypeRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, double> v247)
    {
        int v246;
        v246 = 0;
        for (; v246 < ArrayItems.Length; v246++)
            yield return v247(ArrayItems[v246]);
    }

    System.Collections.Generic.IEnumerable<int[]> SelectArrayFromArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int[]> v249)
    {
        int v248;
        v248 = 0;
        for (; v248 < ArrayItems.Length; v248++)
            yield return v249(ArrayItems[v248]);
    }

    static System.Collections.Generic.IEnumerable<int> StaticSelectRewritten_ProceduralLinq1(int[] StaticArrayItems, System.Func<int, int> v251)
    {
        int v250;
        v250 = 0;
        for (; v250 < StaticArrayItems.Length; v250++)
            yield return v251(StaticArrayItems[v250]);
    }

    System.Collections.Generic.IEnumerable<int> SelectParamsRewritten_ProceduralLinq1(int a, int[] ArrayItems, System.Func<int, int> v253)
    {
        int v252;
        v252 = 0;
        for (; v252 < ArrayItems.Length; v252++)
            yield return v253(ArrayItems[v252]);
    }

    System.Collections.Generic.IEnumerable<int> SelectMultipleParamsRewritten_ProceduralLinq1(int a, int b, int c, int d, int e, int f, int g, int h, int i, int[] ArrayItems, System.Func<int, int> v255)
    {
        int v254;
        v254 = 0;
        for (; v254 < ArrayItems.Length; v254++)
            yield return v255(ArrayItems[v254]);
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelectRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v257, System.Func<int, int> v258, System.Func<int, int> v259, System.Func<int, int> v260, System.Func<int, int> v261, System.Func<int, int> v262, System.Func<int, int> v263, System.Func<int, int> v264, System.Func<int, int> v265, System.Func<int, int> v266)
    {
        int v256;
        v256 = 0;
        for (; v256 < ArrayItems.Length; v256++)
            yield return v266(v265(v264(v263(v262(v261(v260(v259(v258(v257(ArrayItems[v256]))))))))));
    }

    System.Collections.Generic.IEnumerable<int> MultipleSelect2Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v268, System.Func<int, int> v270, System.Func<int, int> v272, System.Func<int, int> v274, System.Func<int, int> v276, System.Func<int, int> v278, System.Func<int, int> v280, System.Func<int, int> v282, System.Func<int, int> v284, System.Func<int, int> v286)
    {
        int v267;
        int v269;
        int v271;
        int v273;
        int v275;
        int v277;
        int v279;
        int v281;
        int v283;
        int v285;
        v267 = 0;
        for (; v267 < ArrayItems.Length; v267++)
        {
            v269 = v268(ArrayItems[v267]);
            v271 = v270(v269);
            v273 = v272(v271);
            v275 = v274(v273);
            v277 = v276(v275);
            v279 = v278(v277);
            v281 = v280(v279);
            v283 = v282(v281);
            v285 = v284(v283);
            yield return v286(v285);
        }
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v288)
    {
        int v287;
        v287 = 0;
        for (; v287 < ArrayItems.Length; v287++)
            yield return v288(ArrayItems[v287]);
    }

    int[] SelectChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v289;
        int[] v290;
        v290 = new int[ArrayItems.Length];
        v289 = 0;
        for (; v289 < ArrayItems.Length; v289++)
            v290[v289] = (ArrayItems[v289] + a++);
        return v290;
    }

    System.Collections.Generic.IEnumerable<int> SelectChangingParam3Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v292, System.Func<int, int> v293, System.Func<int, int> v294, System.Func<int, int> v295, System.Func<int, int> v296)
    {
        int v291;
        v291 = 0;
        for (; v291 < ArrayItems.Length; v291++)
            yield return v296(v295(v294(v293(v292(ArrayItems[v291])))));
    }

    int[] SelectChangingParam4Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v297;
        int[] v298;
        v298 = new int[ArrayItems.Length];
        v297 = 0;
        for (; v297 < ArrayItems.Length; v297++)
            v298[v297] = (((((ArrayItems[v297] + a++) + a++) + a++) + a++) + a++);
        return v298;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIndexRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int, int> v300)
    {
        int v299;
        v299 = 0;
        for (; v299 < ArrayItems.Length; v299++)
            yield return v300(ArrayItems[v299], v299);
    }

    int[] ArraySelectIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v301;
        int[] v302;
        v302 = new int[ArrayItems.Length];
        v301 = 0;
        for (; v301 < ArrayItems.Length; v301++)
            v302[v301] = (ArrayItems[v301] + v301);
        return v302;
    }

    System.Collections.Generic.IEnumerable<double> ArraySelectIndexMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v303;
        v303 = 0;
        for (; v303 < ArrayItems.Length; v303++)
            yield return SelectorIndex(ArrayItems[v303], v303);
    }

    double[] ArraySelectIndexMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v304;
        double[] v305;
        v305 = new double[ArrayItems.Length];
        v304 = 0;
        for (; v304 < ArrayItems.Length; v304++)
            v305[v304] = SelectorIndex(ArrayItems[v304], v304);
        return v305;
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

    static System.Collections.Generic.IEnumerable<int> StaticSelectRewritten_ProceduralLinq1(int[] StaticArrayItems, System.Func<int, int> v307)
    {
        int v306;
        v306 = 0;
        for (; v306 < StaticArrayItems.Length; v306++)
            yield return v307(StaticArrayItems[v306]);
    }
}}
