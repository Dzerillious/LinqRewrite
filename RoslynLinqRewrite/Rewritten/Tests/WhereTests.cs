using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class WhereTests
{
    [Datapoints]
    private int[] EnumerableItems = Enumerable.Range(0, 1000).ToArray();
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 1000).ToArray();
    public double Selector(int x) => x + 3;
    public double Selector(double x) => x + 3;
    public bool Predicate(int x) => x > 500;
    public bool Predicate(double x) => x > 500;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayWhereToSimpleList), ArrayWhereToSimpleList, ArrayWhereToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereToSimpleList), SelectWhereToSimpleList, SelectWhereToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(MultipleSelectWhereToSimpleList), MultipleSelectWhereToSimpleList, MultipleSelectWhereToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereToArray), SelectWhereToArray, SelectWhereToArrayRewritten);
        TestsExtensions.TestEquals(nameof(MultipleSelectWhereToArray), MultipleSelectWhereToArray, MultipleSelectWhereToArrayRewritten);
        for (int i = -2; i < 1002; i++)
            TestsExtensions.TestEquals(nameof(ParametrizedWhere) + i, () => ParametrizedWhere(i), () => ParametrizedWhereRewritten(i));
        for (int i = -2; i < 1002; i++)
            TestsExtensions.TestEquals(nameof(ParametrizedWhereToArray) + i, () => ParametrizedWhereToArray(i), () => ParametrizedWhereToArrayRewritten(i));
        for (int i = -2; i < 1002; i++)
            TestsExtensions.TestEquals(nameof(ParametrizedEnumerableWhereToArray) + i, () => ParametrizedEnumerableWhereToArray(i), () => ParametrizedEnumerableWhereToArrayRewritten(i));
        for (int i = -2; i < 1002; i++)
            TestsExtensions.TestEquals(nameof(ParametrizedWhereToSimpleList) + i, () => ParametrizedWhereToSimpleList(i), () => ParametrizedWhereToSimpleListRewritten(i));
        TestsExtensions.TestEquals(nameof(WhereChangingParam), WhereChangingParam, WhereChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(WhereChangingParamToArray), WhereChangingParamToArray, WhereChangingParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(WhereChangingParamToSimpleList), WhereChangingParamToSimpleList, WhereChangingParamToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(WhereIndexToArray), WhereIndexToArray, WhereIndexToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayWhereToSimpleList()
    {
        return ArrayItems.Where(x => x > 500).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> ArrayWhereToSimpleListRewritten()
    {
        return ArrayWhereToSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectWhereToSimpleList()
    {
        return ArrayItems.Select(x => x + 5).Where(x => x > 500).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SelectWhereToSimpleListRewritten()
    {
        return SelectWhereToSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MultipleSelectWhereToSimpleList()
    {
        return ArrayItems.Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> MultipleSelectWhereToSimpleListRewritten()
    {
        return MultipleSelectWhereToSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectWhereToArray()
    {
        return ArrayItems.Select(x => x + 5).Where(x => x > 500).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectWhereToArrayRewritten()
    {
        return SelectWhereToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MultipleSelectWhereToArray()
    {
        return ArrayItems.Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).Select(x => x + 5).Where(x => x > 500).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> MultipleSelectWhereToArrayRewritten()
    {
        return MultipleSelectWhereToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<double> MultipleSelectMethodWhereToArray()
    {
        return ArrayItems.Select(Selector).Where(Predicate).Select(Selector).Where(Predicate).Select(Selector).Where(Predicate).Select(Selector).Where(Predicate).ToArray();
    } //EndMethod

    public IEnumerable<double> MultipleSelectWhereMethodToArrayRewritten()
    {
        return MultipleSelectWhereMethodToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ParametrizedWhere(int offset)
    {
        return ArrayItems.Where(x => x > offset);
    } //EndMethod

    public IEnumerable<int> ParametrizedWhereRewritten(int offset)
    {
        return ParametrizedWhereRewritten_ProceduralLinq1(offset, ArrayItems, x => x > offset);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ParametrizedWhereToArray(int offset)
    {
        return ArrayItems.Where(x => x > offset).ToArray();
    } //EndMethod

    public IEnumerable<int> ParametrizedWhereToArrayRewritten(int offset)
    {
        return ParametrizedWhereToArrayRewritten_ProceduralLinq1(offset, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ParametrizedWhereToSimpleList(int offset)
    {
        return ArrayItems.Where(x => x > offset).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> ParametrizedWhereToSimpleListRewritten(int offset)
    {
        return ParametrizedWhereToSimpleListRewritten_ProceduralLinq1(offset, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ParametrizedEnumerableWhereToArray(int offset)
    {
        return EnumerableItems.Where(x => x > offset).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> ParametrizedEnumerableWhereToArrayRewritten(int offset)
    {
        return ParametrizedEnumerableWhereToArrayRewritten_ProceduralLinq1(offset, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> WhereChangingParam()
    {
        var a = 50;
        return ArrayItems.Where(x => x > 2 * a).Select(x => x + a++);
    } //EndMethod

    public IEnumerable<int> WhereChangingParamRewritten()
    {
        var a = 50;
        return WhereChangingParamRewritten_ProceduralLinq1(ArrayItems, x => x > 2 * a, x => x + a++);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> WhereChangingParamToArray()
    {
        var a = 50;
        return ArrayItems.Where(x => x > 2 * a).Select(x => x + a++).ToArray();
    } //EndMethod

    public IEnumerable<int> WhereChangingParamToArrayRewritten()
    {
        var a = 50;
        return WhereChangingParamToArrayRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> WhereChangingParamToSimpleList()
    {
        var a = 50;
        return ArrayItems.Where(x => x > 2 * a).Select(x => x + a++).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> WhereChangingParamToSimpleListRewritten()
    {
        var a = 50;
        return WhereChangingParamToSimpleListRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> WhereIndexToArray()
    {
        return ArrayItems.Where((x, i) => x > 200 + i / 2).ToArray();
    } //EndMethod

    public IEnumerable<int> WhereIndexToArrayRewritten()
    {
        return WhereIndexToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v362;
        int v363;
        int v364;
        int v365;
        int[] v366;
        SimpleList<int> v367;
        v363 = 0;
        v364 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v364 -= (v364 % 2);
        v365 = 8;
        v366 = new int[8];
        v362 = 0;
        for (; v362 < ArrayItems.Length; v362++)
        {
            if (!(ArrayItems[v362] > 500))
                continue;
            if (v363 >= v365)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v366, ref v364, out v365);
            v366[v363] = ArrayItems[v362];
            v363++;
        }

        v367 = new SimpleList<int>();
        v367.Items = v366;
        v367.Count = v363;
        return v367;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v368;
        int v369;
        int v370;
        int v371;
        int v372;
        int[] v373;
        SimpleList<int> v374;
        v370 = 0;
        v371 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v371 -= (v371 % 2);
        v372 = 8;
        v373 = new int[8];
        v368 = 0;
        for (; v368 < ArrayItems.Length; v368++)
        {
            v369 = (ArrayItems[v368] + 5);
            if (!(v369 > 500))
                continue;
            if (v370 >= v372)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v373, ref v371, out v372);
            v373[v370] = v369;
            v370++;
        }

        v374 = new SimpleList<int>();
        v374.Items = v373;
        v374.Count = v370;
        return v374;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v375;
        int v376;
        int v377;
        int v378;
        int v379;
        int v380;
        int v381;
        int v382;
        int[] v383;
        SimpleList<int> v384;
        v380 = 0;
        v381 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v381 -= (v381 % 2);
        v382 = 8;
        v383 = new int[8];
        v375 = 0;
        for (; v375 < ArrayItems.Length; v375++)
        {
            v376 = (ArrayItems[v375] + 5);
            if (!(v376 > 500))
                continue;
            v377 = (v376 + 5);
            if (!(v377 > 500))
                continue;
            v378 = (v377 + 5);
            if (!(v378 > 500))
                continue;
            v379 = (v378 + 5);
            if (!(v379 > 500))
                continue;
            if (v380 >= v382)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v383, ref v381, out v382);
            v383[v380] = v379;
            v380++;
        }

        v384 = new SimpleList<int>();
        v384.Items = v383;
        v384.Count = v380;
        return v384;
    }

    int[] SelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v385;
        int v386;
        int v387;
        int v388;
        int v389;
        int[] v390;
        v387 = 0;
        v388 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v388 -= (v388 % 2);
        v389 = 8;
        v390 = new int[8];
        v385 = 0;
        for (; v385 < ArrayItems.Length; v385++)
        {
            v386 = (ArrayItems[v385] + 5);
            if (!(v386 > 500))
                continue;
            if (v387 >= v389)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v390, ref v388, out v389);
            v390[v387] = v386;
            v387++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v390, v387);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v391;
        int v392;
        int v393;
        int v394;
        int v395;
        int v396;
        int v397;
        int v398;
        int[] v399;
        SimpleList<int> v400;
        v396 = 0;
        v397 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v397 -= (v397 % 2);
        v398 = 8;
        v399 = new int[8];
        v391 = 0;
        for (; v391 < ArrayItems.Length; v391++)
        {
            v392 = (ArrayItems[v391] + 5);
            if (!(v392 > 500))
                continue;
            v393 = (v392 + 5);
            if (!(v393 > 500))
                continue;
            v394 = (v393 + 5);
            if (!(v394 > 500))
                continue;
            v395 = (v394 + 5);
            if (!(v395 > 500))
                continue;
            if (v396 >= v398)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v399, ref v397, out v398);
            v399[v396] = v395;
            v396++;
        }

        v400 = new SimpleList<int>();
        v400.Items = v399;
        v400.Count = v396;
        return v400;
    }

    double[] MultipleSelectWhereMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v401;
        double v402;
        double v403;
        double v404;
        double v405;
        int v406;
        int v407;
        int v408;
        double[] v409;
        v406 = 0;
        v407 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v407 -= (v407 % 2);
        v408 = 8;
        v409 = new double[8];
        v401 = 0;
        for (; v401 < ArrayItems.Length; v401++)
        {
            v402 = Selector(ArrayItems[v401]);
            if (!Predicate(v402))
                continue;
            v403 = Selector(v402);
            if (!Predicate(v403))
                continue;
            v404 = Selector(v403);
            if (!Predicate(v404))
                continue;
            v405 = Selector(v404);
            if (!Predicate(v405))
                continue;
            if (v406 >= v408)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v409, ref v407, out v408);
            v409[v406] = v405;
            v406++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v409, v406);
    }

    System.Collections.Generic.IEnumerable<int> ParametrizedWhereRewritten_ProceduralLinq1(int offset, int[] ArrayItems, System.Func<int, bool> v411)
    {
        int v410;
        v410 = 0;
        for (; v410 < ArrayItems.Length; v410++)
        {
            if (!v411(ArrayItems[v410]))
                continue;
            yield return ArrayItems[v410];
        }
    }

    int[] ParametrizedWhereToArrayRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v412;
        int v413;
        int v414;
        int v415;
        int[] v416;
        v413 = 0;
        v414 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v414 -= (v414 % 2);
        v415 = 8;
        v416 = new int[8];
        v412 = 0;
        for (; v412 < ArrayItems.Length; v412++)
        {
            if (!(ArrayItems[v412] > offset))
                continue;
            if (v413 >= v415)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v416, ref v414, out v415);
            v416[v413] = ArrayItems[v412];
            v413++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v416, v413);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ParametrizedWhereToSimpleListRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v417;
        int v418;
        int v419;
        int v420;
        int[] v421;
        SimpleList<int> v422;
        v418 = 0;
        v419 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v419 -= (v419 % 2);
        v420 = 8;
        v421 = new int[8];
        v417 = 0;
        for (; v417 < ArrayItems.Length; v417++)
        {
            if (!(ArrayItems[v417] > offset))
                continue;
            if (v418 >= v420)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v421, ref v419, out v420);
            v421[v418] = ArrayItems[v417];
            v418++;
        }

        v422 = new SimpleList<int>();
        v422.Items = v421;
        v422.Count = v418;
        return v422;
    }

    int[] ParametrizedEnumerableWhereToArrayRewritten_ProceduralLinq1(int offset, int[] EnumerableItems)
    {
        int v423;
        int v424;
        int v425;
        int v426;
        int[] v427;
        v424 = 0;
        v425 = (LinqRewrite.Core.IntExtensions.Log2((uint)EnumerableItems.Length) - 3);
        v425 -= (v425 % 2);
        v426 = 8;
        v427 = new int[8];
        v423 = 0;
        for (; v423 < EnumerableItems.Length; v423++)
        {
            if (!(EnumerableItems[v423] > offset))
                continue;
            if (v424 >= v426)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, EnumerableItems.Length, ref v427, ref v425, out v426);
            v427[v424] = EnumerableItems[v423];
            v424++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v427, v424);
    }

    System.Collections.Generic.IEnumerable<int> WhereChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v429, System.Func<int, int> v430)
    {
        int v428;
        v428 = 0;
        for (; v428 < ArrayItems.Length; v428++)
        {
            if (!v429(ArrayItems[v428]))
                continue;
            yield return v430(ArrayItems[v428]);
        }
    }

    int[] WhereChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v431;
        int v432;
        int v433;
        int v434;
        int[] v435;
        v432 = 0;
        v433 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v433 -= (v433 % 2);
        v434 = 8;
        v435 = new int[8];
        v431 = 0;
        for (; v431 < ArrayItems.Length; v431++)
        {
            if (!(ArrayItems[v431] > 2 * a))
                continue;
            if (v432 >= v434)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v435, ref v433, out v434);
            v435[v432] = (ArrayItems[v431] + a++);
            v432++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v435, v432);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> WhereChangingParamToSimpleListRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v436;
        int v437;
        int v438;
        int v439;
        int[] v440;
        SimpleList<int> v441;
        v437 = 0;
        v438 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v438 -= (v438 % 2);
        v439 = 8;
        v440 = new int[8];
        v436 = 0;
        for (; v436 < ArrayItems.Length; v436++)
        {
            if (!(ArrayItems[v436] > 2 * a))
                continue;
            if (v437 >= v439)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v440, ref v438, out v439);
            v440[v437] = (ArrayItems[v436] + a++);
            v437++;
        }

        v441 = new SimpleList<int>();
        v441.Items = v440;
        v441.Count = v437;
        return v441;
    }

    int[] WhereIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v442;
        int v443;
        int v444;
        int v445;
        int[] v446;
        v443 = 0;
        v444 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v444 -= (v444 % 2);
        v445 = 8;
        v446 = new int[8];
        v442 = 0;
        for (; v442 < ArrayItems.Length; v442++)
        {
            if (!(ArrayItems[v442] > 200 + v442 / 2))
                continue;
            if (v443 >= v445)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v446, ref v444, out v445);
            v446[v443] = ArrayItems[v442];
            v443++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v446, v443);
    }
}}