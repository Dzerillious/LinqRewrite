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
        return ParametrizedWhereRewritten_ProceduralLinq1(offset, ArrayItems);
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
        int v3368;
        int v3369;
        int v3370;
        int v3371;
        int v3372;
        int[] v3373;
        SimpleList<int> v3374;
        v3370 = 0;
        v3371 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3371 -= (v3371 % 2);
        v3372 = 8;
        v3373 = new int[8];
        v3368 = (0);
        for (; v3368 < (ArrayItems.Length); v3368++)
        {
            v3369 = (ArrayItems[v3368]);
            if (!(((v3369) > 500)))
                continue;
            if (v3370 >= v3372)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3373, ref v3371, out v3372);
            v3373[v3370] = (v3369);
            v3370++;
        }

        v3374 = new SimpleList<int>();
        v3374.Items = v3373;
        v3374.Count = v3370;
        return v3374;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> SelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3375;
        int v3376;
        int v3377;
        int v3378;
        int v3379;
        int[] v3380;
        SimpleList<int> v3381;
        v3377 = 0;
        v3378 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3378 -= (v3378 % 2);
        v3379 = 8;
        v3380 = new int[8];
        v3375 = (0);
        for (; v3375 < (ArrayItems.Length); v3375++)
        {
            v3376 = (5 + ArrayItems[v3375]);
            if (!(((v3376) > 500)))
                continue;
            if (v3377 >= v3379)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3380, ref v3378, out v3379);
            v3380[v3377] = (v3376);
            v3377++;
        }

        v3381 = new SimpleList<int>();
        v3381.Items = v3380;
        v3381.Count = v3377;
        return v3381;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3382;
        int v3383;
        int v3384;
        int v3385;
        int v3386;
        int[] v3387;
        SimpleList<int> v3388;
        v3384 = 0;
        v3385 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3385 -= (v3385 % 2);
        v3386 = 8;
        v3387 = new int[8];
        v3382 = (0);
        for (; v3382 < (ArrayItems.Length); v3382++)
        {
            v3383 = (5 + ArrayItems[v3382]);
            if (!(((v3383) > 500)))
                continue;
            v3383 = (5 + v3383);
            if (!(((v3383) > 500)))
                continue;
            v3383 = (5 + v3383);
            if (!(((v3383) > 500)))
                continue;
            v3383 = (5 + v3383);
            if (!(((v3383) > 500)))
                continue;
            if (v3384 >= v3386)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3387, ref v3385, out v3386);
            v3387[v3384] = (v3383);
            v3384++;
        }

        v3388 = new SimpleList<int>();
        v3388.Items = v3387;
        v3388.Count = v3384;
        return v3388;
    }

    int[] SelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3389;
        int v3390;
        int v3391;
        int v3392;
        int v3393;
        int[] v3394;
        v3391 = 0;
        v3392 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3392 -= (v3392 % 2);
        v3393 = 8;
        v3394 = new int[8];
        v3389 = (0);
        for (; v3389 < (ArrayItems.Length); v3389++)
        {
            v3390 = (5 + ArrayItems[v3389]);
            if (!(((v3390) > 500)))
                continue;
            if (v3391 >= v3393)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3394, ref v3392, out v3393);
            v3394[v3391] = (v3390);
            v3391++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3394, v3391);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> MultipleSelectWhereToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3395;
        int v3396;
        int v3397;
        int v3398;
        int v3399;
        int[] v3400;
        SimpleList<int> v3401;
        v3397 = 0;
        v3398 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3398 -= (v3398 % 2);
        v3399 = 8;
        v3400 = new int[8];
        v3395 = (0);
        for (; v3395 < (ArrayItems.Length); v3395++)
        {
            v3396 = (5 + ArrayItems[v3395]);
            if (!(((v3396) > 500)))
                continue;
            v3396 = (5 + v3396);
            if (!(((v3396) > 500)))
                continue;
            v3396 = (5 + v3396);
            if (!(((v3396) > 500)))
                continue;
            v3396 = (5 + v3396);
            if (!(((v3396) > 500)))
                continue;
            if (v3397 >= v3399)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3400, ref v3398, out v3399);
            v3400[v3397] = (v3396);
            v3397++;
        }

        v3401 = new SimpleList<int>();
        v3401.Items = v3400;
        v3401.Count = v3397;
        return v3401;
    }

    double[] MultipleSelectWhereMethodToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3402;
        double v3403;
        int v3404;
        int v3405;
        int v3406;
        double[] v3407;
        v3404 = 0;
        v3405 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3405 -= (v3405 % 2);
        v3406 = 8;
        v3407 = new double[8];
        v3402 = (0);
        for (; v3402 < (ArrayItems.Length); v3402++)
        {
            v3403 = (Selector((ArrayItems[v3402])));
            if (!(Predicate((v3403))))
                continue;
            v3403 = (Selector((v3403)));
            if (!(Predicate((v3403))))
                continue;
            v3403 = (Selector((v3403)));
            if (!(Predicate((v3403))))
                continue;
            v3403 = (Selector((v3403)));
            if (!(Predicate((v3403))))
                continue;
            if (v3404 >= v3406)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3407, ref v3405, out v3406);
            v3407[v3404] = (v3403);
            v3404++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3407, v3404);
    }

    System.Collections.Generic.IEnumerable<int> ParametrizedWhereRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v3408;
        int v3409;
        v3408 = (0);
        for (; v3408 < (ArrayItems.Length); v3408++)
        {
            v3409 = (ArrayItems[v3408]);
            if (!(((v3409) > offset)))
                continue;
            yield return (v3409);
        }

        yield break;
    }

    int[] ParametrizedWhereToArrayRewritten_ProceduralLinq1(int offset, int[] ArrayItems)
    {
        int v3410;
        int v3411;
        int v3412;
        int v3413;
        int v3414;
        int[] v3415;
        v3412 = 0;
        v3413 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3413 -= (v3413 % 2);
        v3414 = 8;
        v3415 = new int[8];
        v3410 = (0);
        for (; v3410 < (ArrayItems.Length); v3410++)
        {
            v3411 = (ArrayItems[v3410]);
            if (!(((v3411) > offset)))
                continue;
            if (v3412 >= v3414)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3415, ref v3413, out v3414);
            v3415[v3412] = (v3411);
            v3412++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3415, v3412);
    }

    System.Collections.Generic.IEnumerable<int> WhereChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v3418, System.Func<int, int> v3419)
    {
        int v3416;
        int v3417;
        v3416 = (0);
        for (; v3416 < (ArrayItems.Length); v3416++)
        {
            v3417 = (ArrayItems[v3416]);
            if (!(v3418((v3417))))
                continue;
            yield return (v3419((v3417)));
        }

        yield break;
    }

    int[] WhereChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v3420;
        int v3421;
        int v3422;
        int v3423;
        int v3424;
        int[] v3425;
        v3422 = 0;
        v3423 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3423 -= (v3423 % 2);
        v3424 = 8;
        v3425 = new int[8];
        v3420 = (0);
        for (; v3420 < (ArrayItems.Length); v3420++)
        {
            v3421 = (ArrayItems[v3420]);
            if (!(((v3421) > 2 * a)))
                continue;
            if (v3422 >= v3424)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3425, ref v3423, out v3424);
            v3425[v3422] = (((v3421) + a++));
            v3422++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3425, v3422);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> WhereChangingParamToSimpleListRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v3426;
        int v3427;
        int v3428;
        int v3429;
        int v3430;
        int[] v3431;
        SimpleList<int> v3432;
        v3428 = 0;
        v3429 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3429 -= (v3429 % 2);
        v3430 = 8;
        v3431 = new int[8];
        v3426 = (0);
        for (; v3426 < (ArrayItems.Length); v3426++)
        {
            v3427 = (ArrayItems[v3426]);
            if (!(((v3427) > 2 * a)))
                continue;
            if (v3428 >= v3430)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3431, ref v3429, out v3430);
            v3431[v3428] = (((v3427) + a++));
            v3428++;
        }

        v3432 = new SimpleList<int>();
        v3432.Items = v3431;
        v3432.Count = v3428;
        return v3432;
    }

    int[] WhereIndexToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3433;
        int v3434;
        int v3435;
        int v3436;
        int v3437;
        int[] v3438;
        v3435 = 0;
        v3436 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v3436 -= (v3436 % 2);
        v3437 = 8;
        v3438 = new int[8];
        v3433 = (0);
        for (; v3433 < (ArrayItems.Length); v3433++)
        {
            v3434 = (ArrayItems[v3433]);
            if (!(((v3434) > 200 + v3433 / 2)))
                continue;
            if (v3435 >= v3437)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v3438, ref v3436, out v3437);
            v3438[v3435] = (v3434);
            v3435++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3438, v3435);
    }
}}