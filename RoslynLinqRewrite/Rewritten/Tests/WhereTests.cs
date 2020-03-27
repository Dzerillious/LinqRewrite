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
        ArrayWhereToSimpleList().TestEquals(nameof(ArrayWhereToSimpleList), ArrayWhereToSimpleListRewritten());
        SelectWhereToSimpleList().TestEquals(nameof(SelectWhereToSimpleList), SelectWhereToSimpleListRewritten());
        MultipleSelectWhereToSimpleList().TestEquals(nameof(MultipleSelectWhereToSimpleList), MultipleSelectWhereToSimpleListRewritten());
        SelectWhereToArray().TestEquals(nameof(SelectWhereToArray), SelectWhereToArrayRewritten());
        MultipleSelectWhereToArray().TestEquals(nameof(MultipleSelectWhereToArray), MultipleSelectWhereToArrayRewritten());
        for (int i = -2; i < 1002; i++)
            ParametrizedWhere(i).TestEquals(nameof(ParametrizedWhere) + i, ParametrizedWhereRewritten(i));
        for (int i = -2; i < 1002; i++)
            ParametrizedWhereToArray(i).TestEquals(nameof(ParametrizedWhereToArray) + i, ParametrizedWhereToArrayRewritten(i));
        for (int i = -2; i < 1002; i++)
            ParametrizedEnumerableWhereToArray(i).TestEquals(nameof(ParametrizedEnumerableWhereToArray) + i, ParametrizedEnumerableWhereToArrayRewritten(i));
        for (int i = -2; i < 1002; i++)
            ParametrizedWhereToSimpleList(i).TestEquals(nameof(ParametrizedWhereToSimpleList) + i, ParametrizedWhereToSimpleListRewritten(i));
        WhereChangingParam().TestEquals(nameof(WhereChangingParam), WhereChangingParamRewritten());
        WhereChangingParamToArray().TestEquals(nameof(WhereChangingParamToArray), WhereChangingParamToArrayRewritten());
        WhereChangingParamToSimpleList().TestEquals(nameof(WhereChangingParamToSimpleList), WhereChangingParamToSimpleListRewritten());
        WhereIndexToArray().TestEquals(nameof(WhereIndexToArray), WhereIndexToArrayRewritten());
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
        int v308;
        int v309;
        int v310;
        int v311;
        int[] v312;
        SimpleList<int> v313;
        v309 = 0;
        v310 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v310 -= (v310 % 2);
        v311 = 8;
        v312 = new int[8];
        v308 = 0;
        for (; v308 < ArrayItems.Length; v308++)
        {
            if (!(ArrayItems[v308] > 500))
                continue;
            if (v309 >= v311)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v312, ref v310, out v311);
            v312[v309] = ArrayItems[v308];
            v309++;
        }

        v313 = new SimpleList<int>();
        v313.Items = v312;
        v313.Count = v309;
        return v313;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v314;
        int v315;
        int v316;
        int v317;
        int v318;
        int[] v319;
        SimpleList<int> v320;
        v316 = 0;
        v317 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v317 -= (v317 % 2);
        v318 = 8;
        v319 = new int[8];
        v314 = 0;
        for (; v314 < ArrayItems.Length; v314++)
        {
            v315 = (ArrayItems[v314] + 5);
            if (!(v315 > 500))
                continue;
            if (v316 >= v318)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v319, ref v317, out v318);
            v319[v316] = v315;
            v316++;
        }

        v320 = new SimpleList<int>();
        v320.Items = v319;
        v320.Count = v316;
        return v320;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v321;
        int v322;
        int v323;
        int v324;
        int v325;
        int v326;
        int v327;
        int v328;
        int[] v329;
        SimpleList<int> v330;
        v326 = 0;
        v327 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v327 -= (v327 % 2);
        v328 = 8;
        v329 = new int[8];
        v321 = 0;
        for (; v321 < ArrayItems.Length; v321++)
        {
            v322 = (ArrayItems[v321] + 5);
            if (!(v322 > 500))
                continue;
            v323 = (v322 + 5);
            if (!(v323 > 500))
                continue;
            v324 = (v323 + 5);
            if (!(v324 > 500))
                continue;
            v325 = (v324 + 5);
            if (!(v325 > 500))
                continue;
            if (v326 >= v328)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v329, ref v327, out v328);
            v329[v326] = v325;
            v326++;
        }

        v330 = new SimpleList<int>();
        v330.Items = v329;
        v330.Count = v326;
        return v330;
    }

    int[] SelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v331;
        int v332;
        int v333;
        int v334;
        int v335;
        int[] v336;
        v333 = 0;
        v334 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v334 -= (v334 % 2);
        v335 = 8;
        v336 = new int[8];
        v331 = 0;
        for (; v331 < ArrayItems.Length; v331++)
        {
            v332 = (ArrayItems[v331] + 5);
            if (!(v332 > 500))
                continue;
            if (v333 >= v335)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v336, ref v334, out v335);
            v336[v333] = v332;
            v333++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v336, v333);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v337;
        int v338;
        int v339;
        int v340;
        int v341;
        int v342;
        int v343;
        int v344;
        int[] v345;
        SimpleList<int> v346;
        v342 = 0;
        v343 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v343 -= (v343 % 2);
        v344 = 8;
        v345 = new int[8];
        v337 = 0;
        for (; v337 < ArrayItems.Length; v337++)
        {
            v338 = (ArrayItems[v337] + 5);
            if (!(v338 > 500))
                continue;
            v339 = (v338 + 5);
            if (!(v339 > 500))
                continue;
            v340 = (v339 + 5);
            if (!(v340 > 500))
                continue;
            v341 = (v340 + 5);
            if (!(v341 > 500))
                continue;
            if (v342 >= v344)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v345, ref v343, out v344);
            v345[v342] = v341;
            v342++;
        }

        v346 = new SimpleList<int>();
        v346.Items = v345;
        v346.Count = v342;
        return v346;
    }

    double[] MultipleSelectWhereMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v347;
        double v348;
        double v349;
        double v350;
        double v351;
        int v352;
        int v353;
        int v354;
        double[] v355;
        v352 = 0;
        v353 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v353 -= (v353 % 2);
        v354 = 8;
        v355 = new double[8];
        v347 = 0;
        for (; v347 < ArrayItems.Length; v347++)
        {
            v348 = Selector(ArrayItems[v347]);
            if (!Predicate(v348))
                continue;
            v349 = Selector(v348);
            if (!Predicate(v349))
                continue;
            v350 = Selector(v349);
            if (!Predicate(v350))
                continue;
            v351 = Selector(v350);
            if (!Predicate(v351))
                continue;
            if (v352 >= v354)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v355, ref v353, out v354);
            v355[v352] = v351;
            v352++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v355, v352);
    }

    System.Collections.Generic.IEnumerable<int> ParametrizedWhereRewritten_ProceduralLinq1(int offset, int[] ArrayItems, System.Func<int, bool> v357)
    {
        int v356;
        v356 = 0;
        for (; v356 < ArrayItems.Length; v356++)
        {
            if (!v357(ArrayItems[v356]))
                continue;
            yield return ArrayItems[v356];
        }
    }

    int[] ParametrizedWhereToArrayRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v358;
        int v359;
        int v360;
        int v361;
        int[] v362;
        v359 = 0;
        v360 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v360 -= (v360 % 2);
        v361 = 8;
        v362 = new int[8];
        v358 = 0;
        for (; v358 < ArrayItems.Length; v358++)
        {
            if (!(ArrayItems[v358] > offset))
                continue;
            if (v359 >= v361)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v362, ref v360, out v361);
            v362[v359] = ArrayItems[v358];
            v359++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v362, v359);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ParametrizedWhereToSimpleListRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v363;
        int v364;
        int v365;
        int v366;
        int[] v367;
        SimpleList<int> v368;
        v364 = 0;
        v365 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v365 -= (v365 % 2);
        v366 = 8;
        v367 = new int[8];
        v363 = 0;
        for (; v363 < ArrayItems.Length; v363++)
        {
            if (!(ArrayItems[v363] > offset))
                continue;
            if (v364 >= v366)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v367, ref v365, out v366);
            v367[v364] = ArrayItems[v363];
            v364++;
        }

        v368 = new SimpleList<int>();
        v368.Items = v367;
        v368.Count = v364;
        return v368;
    }

    int[] ParametrizedEnumerableWhereToArrayRewritten_ProceduralLinq1(int offset, int[] EnumerableItems)
    {
        int v369;
        int v370;
        int v371;
        int v372;
        int[] v373;
        v370 = 0;
        v371 = (LinqRewrite.Core.IntExtensions.Log2((uint)EnumerableItems.Length) - 3);
        v371 -= (v371 % 2);
        v372 = 8;
        v373 = new int[8];
        v369 = 0;
        for (; v369 < EnumerableItems.Length; v369++)
        {
            if (!(EnumerableItems[v369] > offset))
                continue;
            if (v370 >= v372)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, EnumerableItems.Length, ref v373, ref v371, out v372);
            v373[v370] = EnumerableItems[v369];
            v370++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v373, v370);
    }

    System.Collections.Generic.IEnumerable<int> WhereChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v375, System.Func<int, int> v376)
    {
        int v374;
        v374 = 0;
        for (; v374 < ArrayItems.Length; v374++)
        {
            if (!v375(ArrayItems[v374]))
                continue;
            yield return v376(ArrayItems[v374]);
        }
    }

    int[] WhereChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v377;
        int v378;
        int v379;
        int v380;
        int[] v381;
        v378 = 0;
        v379 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v379 -= (v379 % 2);
        v380 = 8;
        v381 = new int[8];
        v377 = 0;
        for (; v377 < ArrayItems.Length; v377++)
        {
            if (!(ArrayItems[v377] > 2 * a))
                continue;
            if (v378 >= v380)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v381, ref v379, out v380);
            v381[v378] = (ArrayItems[v377] + a++);
            v378++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v381, v378);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> WhereChangingParamToSimpleListRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v382;
        int v383;
        int v384;
        int v385;
        int[] v386;
        SimpleList<int> v387;
        v383 = 0;
        v384 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v384 -= (v384 % 2);
        v385 = 8;
        v386 = new int[8];
        v382 = 0;
        for (; v382 < ArrayItems.Length; v382++)
        {
            if (!(ArrayItems[v382] > 2 * a))
                continue;
            if (v383 >= v385)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v386, ref v384, out v385);
            v386[v383] = (ArrayItems[v382] + a++);
            v383++;
        }

        v387 = new SimpleList<int>();
        v387.Items = v386;
        v387.Count = v383;
        return v387;
    }

    int[] WhereIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v388;
        int v389;
        int v390;
        int v391;
        int[] v392;
        v389 = 0;
        v390 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v390 -= (v390 % 2);
        v391 = 8;
        v392 = new int[8];
        v388 = 0;
        for (; v388 < ArrayItems.Length; v388++)
        {
            if (!(ArrayItems[v388] > 200 + v388 / 2))
                continue;
            if (v389 >= v391)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v392, ref v390, out v391);
            v392[v389] = ArrayItems[v388];
            v389++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v392, v389);
    }
}}