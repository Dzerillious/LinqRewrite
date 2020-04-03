using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class MinTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private int Selector(int value) => value + 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(Min1), Min1, Min1Rewritten);
        TestsExtensions.TestEquals(nameof(Min2), Min2, Min2Rewritten);
        TestsExtensions.TestEquals(nameof(Min3), Min3, Min3Rewritten);
        TestsExtensions.TestEquals(nameof(Min4), Min4, Min4Rewritten);
        TestsExtensions.TestEquals(nameof(Min5), Min5, Min5Rewritten);
        TestsExtensions.TestEquals(nameof(Min6), Min6, Min6Rewritten);
        TestsExtensions.TestEquals(nameof(Min7), Min7, Min7Rewritten);
        TestsExtensions.TestEquals(nameof(Min8), Min8, Min8Rewritten);
        TestsExtensions.TestEquals(nameof(Min9), Min9, Min9Rewritten);
        TestsExtensions.TestEquals(nameof(Min10), Min10, Min10Rewritten);
        TestsExtensions.TestEquals(nameof(Min11), Min11, Min11Rewritten);
        TestsExtensions.TestEquals(nameof(Min12), Min12, Min12Rewritten);
        TestsExtensions.TestEquals(nameof(MinParam), MinParam, MinParamRewritten);
        TestsExtensions.TestEquals(nameof(MinChangingParam), MinChangingParam, MinChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(MinChangingParam2), MinChangingParam2, MinChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectMin), SelectMin, SelectMinRewritten);
        TestsExtensions.TestEquals(nameof(EmptyMin), EmptyMin, EmptyMinRewritten);
        TestsExtensions.TestEquals(nameof(EmptyMin2), EmptyMin2, EmptyMin2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableMin), EnumerableMin, EnumerableMinRewritten);
    }

    [NoRewrite]
    public int Min1()
    {
        return ArrayItems.Min();
    } //EndMethod

    public int Min1Rewritten()
    {
        return Min1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int Min2()
    {
        return ArrayItems.Min(x => x + 2);
    } //EndMethod

    public int Min2Rewritten()
    {
        return Min2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public float Min3()
    {
        return ArrayItems.Min(x => x + 2f);
    } //EndMethod

    public float Min3Rewritten()
    {
        return Min3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double Min4()
    {
        return ArrayItems.Min(x => x + 2d);
    } //EndMethod

    public double Min4Rewritten()
    {
        return Min4Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal Min5()
    {
        return ArrayItems.Min(x => x + 2m);
    } //EndMethod

    public decimal Min5Rewritten()
    {
        return Min5Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? Min6()
    {
        return ArrayItems.Min(x => x > 10 ? (int? )null : x + 2);
    } //EndMethod

    public int? Min6Rewritten()
    {
        return Min6Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public float? Min7()
    {
        return ArrayItems.Min(x => x > 10 ? (float? )null : x + 2);
    } //EndMethod

    public float? Min7Rewritten()
    {
        return Min7Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? Min8()
    {
        return ArrayItems.Min(x => x > 10 ? (double? )null : x + 2);
    } //EndMethod

    public double? Min8Rewritten()
    {
        return Min8Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal? Min9()
    {
        return ArrayItems.Min(x => x > 10 ? (decimal? )null : x + 2);
    } //EndMethod

    public decimal? Min9Rewritten()
    {
        return Min9Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long Min10()
    {
        return ArrayItems.Min(x => x + 2L);
    } //EndMethod

    public long Min10Rewritten()
    {
        return Min10Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long? Min11()
    {
        return ArrayItems.Min(x => x > 10 ? (long? )null : x + 2);
    } //EndMethod

    public long? Min11Rewritten()
    {
        return Min11Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? Min12()
    {
        return ArrayItems.Min(Selector);
    } //EndMethod

    public int? Min12Rewritten()
    {
        return Min12Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MinParam()
    {
        var a = 10;
        return ArrayItems.Min(x => x + a);
    } //EndMethod

    public int? MinParamRewritten()
    {
        var a = 10;
        return MinParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MinChangingParam()
    {
        var a = 10;
        return ArrayItems.Min(x => x + a++);
    } //EndMethod

    public int? MinChangingParamRewritten()
    {
        var a = 10;
        return MinChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MinChangingParam2()
    {
        var a = 10;
        return ArrayItems.Min(x => x + a--);
    } //EndMethod

    public int? MinChangingParam2Rewritten()
    {
        var a = 10;
        return MinChangingParam2Rewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? SelectMin()
    {
        var a = 10;
        return ArrayItems.Select(x => x + 3).Min();
    } //EndMethod

    public int? SelectMinRewritten()
    {
        var a = 10;
        return SelectMinRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? EmptyMin()
    {
        return Enumerable.Empty<int>().Min();
    } //EndMethod

    public int? EmptyMinRewritten()
    {
        return EmptyMinRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int? EmptyMin2()
    {
        return ArrayItems.Where(x => false).Min();
    } //EndMethod

    public int? EmptyMin2Rewritten()
    {
        return EmptyMin2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? EnumerableMin()
    {
        return EnumerableItems.Min();
    } //EndMethod

    public int? EnumerableMinRewritten()
    {
        return EnumerableMinRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    int Min1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1360;
        int v1361;
        bool v1362;
        v1361 = 2147483647;
        v1362 = false;
        v1360 = 0;
        for (; v1360 < ArrayItems.Length; v1360++)
        {
            if (ArrayItems[v1360] >= v1361)
                continue;
            v1361 = ArrayItems[v1360];
            v1362 = true;
        }

        if (!(v1362))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1361;
    }

    int Min2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1363;
        int v1364;
        bool v1365;
        int v1366;
        v1364 = 2147483647;
        v1365 = false;
        v1363 = 0;
        for (; v1363 < ArrayItems.Length; v1363++)
        {
            v1366 = (ArrayItems[v1363] + 2);
            if (v1366 >= v1364)
                continue;
            v1364 = v1366;
            v1365 = true;
        }

        if (!(v1365))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1364;
    }

    float Min3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1367;
        float v1368;
        bool v1369;
        float v1370;
        v1368 = 3.4028235E+38F;
        v1369 = false;
        v1367 = 0;
        for (; v1367 < ArrayItems.Length; v1367++)
        {
            v1370 = (ArrayItems[v1367] + 2f);
            if (v1370 >= v1368)
                continue;
            v1368 = v1370;
            v1369 = true;
        }

        if (!(v1369))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1368;
    }

    double Min4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1371;
        double v1372;
        bool v1373;
        double v1374;
        v1372 = 1.7976931348623157E+308;
        v1373 = false;
        v1371 = 0;
        for (; v1371 < ArrayItems.Length; v1371++)
        {
            v1374 = (ArrayItems[v1371] + 2d);
            if (v1374 >= v1372)
                continue;
            v1372 = v1374;
            v1373 = true;
        }

        if (!(v1373))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1372;
    }

    decimal Min5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1375;
        decimal v1376;
        bool v1377;
        decimal v1378;
        v1376 = 79228162514264337593543950335M;
        v1377 = false;
        v1375 = 0;
        for (; v1375 < ArrayItems.Length; v1375++)
        {
            v1378 = (ArrayItems[v1375] + 2m);
            if (v1378 >= v1376)
                continue;
            v1376 = v1378;
            v1377 = true;
        }

        if (!(v1377))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1376;
    }

    int? Min6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1379;
        int v1380;
        bool v1381;
        int? v1382;
        v1380 = 2147483647;
        v1381 = false;
        v1379 = 0;
        for (; v1379 < ArrayItems.Length; v1379++)
        {
            v1382 = (ArrayItems[v1379] > 10 ? (int? )null : ArrayItems[v1379] + 2);
            if ((v1382 == null) || v1382 >= v1380)
                continue;
            v1380 = (int)v1382;
            v1381 = true;
        }

        if (!(v1381))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1380;
    }

    float? Min7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1383;
        float v1384;
        bool v1385;
        float? v1386;
        v1384 = 3.4028235E+38F;
        v1385 = false;
        v1383 = 0;
        for (; v1383 < ArrayItems.Length; v1383++)
        {
            v1386 = (ArrayItems[v1383] > 10 ? (float? )null : ArrayItems[v1383] + 2);
            if ((v1386 == null) || v1386 >= v1384)
                continue;
            v1384 = (float)v1386;
            v1385 = true;
        }

        if (!(v1385))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1384;
    }

    double? Min8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1387;
        double v1388;
        bool v1389;
        double? v1390;
        v1388 = 1.7976931348623157E+308;
        v1389 = false;
        v1387 = 0;
        for (; v1387 < ArrayItems.Length; v1387++)
        {
            v1390 = (ArrayItems[v1387] > 10 ? (double? )null : ArrayItems[v1387] + 2);
            if ((v1390 == null) || v1390 >= v1388)
                continue;
            v1388 = (double)v1390;
            v1389 = true;
        }

        if (!(v1389))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1388;
    }

    decimal? Min9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1391;
        decimal v1392;
        bool v1393;
        decimal? v1394;
        v1392 = 79228162514264337593543950335M;
        v1393 = false;
        v1391 = 0;
        for (; v1391 < ArrayItems.Length; v1391++)
        {
            v1394 = (ArrayItems[v1391] > 10 ? (decimal? )null : ArrayItems[v1391] + 2);
            if ((v1394 == null) || v1394 >= v1392)
                continue;
            v1392 = (decimal)v1394;
            v1393 = true;
        }

        if (!(v1393))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1392;
    }

    long Min10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1395;
        long v1396;
        bool v1397;
        long v1398;
        v1396 = 9223372036854775807L;
        v1397 = false;
        v1395 = 0;
        for (; v1395 < ArrayItems.Length; v1395++)
        {
            v1398 = (ArrayItems[v1395] + 2L);
            if (v1398 >= v1396)
                continue;
            v1396 = v1398;
            v1397 = true;
        }

        if (!(v1397))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1396;
    }

    long? Min11Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1399;
        long v1400;
        bool v1401;
        long? v1402;
        v1400 = 9223372036854775807L;
        v1401 = false;
        v1399 = 0;
        for (; v1399 < ArrayItems.Length; v1399++)
        {
            v1402 = (ArrayItems[v1399] > 10 ? (long? )null : ArrayItems[v1399] + 2);
            if ((v1402 == null) || v1402 >= v1400)
                continue;
            v1400 = (long)v1402;
            v1401 = true;
        }

        if (!(v1401))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1400;
    }

    int Min12Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1403;
        int v1404;
        bool v1405;
        int v1406;
        v1404 = 2147483647;
        v1405 = false;
        v1403 = 0;
        for (; v1403 < ArrayItems.Length; v1403++)
        {
            v1406 = Selector(ArrayItems[v1403]);
            if (v1406 >= v1404)
                continue;
            v1404 = v1406;
            v1405 = true;
        }

        if (!(v1405))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1404;
    }

    int MinParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1407;
        int v1408;
        bool v1409;
        int v1410;
        v1408 = 2147483647;
        v1409 = false;
        v1407 = 0;
        for (; v1407 < ArrayItems.Length; v1407++)
        {
            v1410 = (ArrayItems[v1407] + a);
            if (v1410 >= v1408)
                continue;
            v1408 = v1410;
            v1409 = true;
        }

        if (!(v1409))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1408;
    }

    int MinChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1411;
        int v1412;
        bool v1413;
        int v1414;
        v1412 = 2147483647;
        v1413 = false;
        v1411 = 0;
        for (; v1411 < ArrayItems.Length; v1411++)
        {
            v1414 = (ArrayItems[v1411] + a++);
            if (v1414 >= v1412)
                continue;
            v1412 = v1414;
            v1413 = true;
        }

        if (!(v1413))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1412;
    }

    int MinChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1415;
        int v1416;
        bool v1417;
        int v1418;
        v1416 = 2147483647;
        v1417 = false;
        v1415 = 0;
        for (; v1415 < ArrayItems.Length; v1415++)
        {
            v1418 = (ArrayItems[v1415] + a--);
            if (v1418 >= v1416)
                continue;
            v1416 = v1418;
            v1417 = true;
        }

        if (!(v1417))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1416;
    }

    int SelectMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1419;
        int v1420;
        bool v1421;
        int v1422;
        v1420 = 2147483647;
        v1421 = false;
        v1419 = 0;
        for (; v1419 < ArrayItems.Length; v1419++)
        {
            v1422 = (ArrayItems[v1419] + 3);
            if (v1422 >= v1420)
                continue;
            v1420 = v1422;
            v1421 = true;
        }

        if (!(v1421))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1420;
    }

    int EmptyMinRewritten_ProceduralLinq1()
    {
        int v1423;
        int v1424;
        bool v1425;
        v1424 = 2147483647;
        v1425 = false;
        v1423 = 0;
        for (; v1423 < 0; v1423++)
        {
            if (default(int) >= v1424)
                continue;
            v1424 = default(int);
            v1425 = true;
        }

        if (!(v1425))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1424;
    }

    int EmptyMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1426;
        int v1427;
        bool v1428;
        v1427 = 2147483647;
        v1428 = false;
        v1426 = 0;
        for (; v1426 < ArrayItems.Length; v1426++)
        {
            if (!((false)))
                continue;
            if (ArrayItems[v1426] >= v1427)
                continue;
            v1427 = ArrayItems[v1426];
            v1428 = true;
        }

        if (!(v1428))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1427;
    }

    int EnumerableMinRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1429;
        int v1430;
        bool v1431;
        int v1432;
        v1429 = EnumerableItems.GetEnumerator();
        v1430 = 2147483647;
        v1431 = false;
        try
        {
            while (v1429.MoveNext())
            {
                v1432 = v1429.Current;
                if (v1432 >= v1430)
                    continue;
                v1430 = v1432;
                v1431 = true;
            }
        }
        finally
        {
            v1429.Dispose();
        }

        if (!(v1431))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1430;
    }
}}