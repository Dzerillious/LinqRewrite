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
        int v1333;
        int v1334;
        bool v1335;
        v1334 = 2147483647;
        v1335 = false;
        v1333 = 0;
        for (; v1333 < ArrayItems.Length; v1333++)
        {
            if (ArrayItems[v1333] >= v1334)
                continue;
            v1334 = ArrayItems[v1333];
            v1335 = true;
        }

        if (!(v1335))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1334;
    }

    int Min2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1336;
        int v1337;
        bool v1338;
        int v1339;
        v1337 = 2147483647;
        v1338 = false;
        v1336 = 0;
        for (; v1336 < ArrayItems.Length; v1336++)
        {
            v1339 = (ArrayItems[v1336] + 2);
            if (v1339 >= v1337)
                continue;
            v1337 = v1339;
            v1338 = true;
        }

        if (!(v1338))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1337;
    }

    float Min3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1340;
        float v1341;
        bool v1342;
        float v1343;
        v1341 = 3.4028235E+38F;
        v1342 = false;
        v1340 = 0;
        for (; v1340 < ArrayItems.Length; v1340++)
        {
            v1343 = (ArrayItems[v1340] + 2f);
            if (v1343 >= v1341)
                continue;
            v1341 = v1343;
            v1342 = true;
        }

        if (!(v1342))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1341;
    }

    double Min4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1344;
        double v1345;
        bool v1346;
        double v1347;
        v1345 = 1.7976931348623157E+308;
        v1346 = false;
        v1344 = 0;
        for (; v1344 < ArrayItems.Length; v1344++)
        {
            v1347 = (ArrayItems[v1344] + 2d);
            if (v1347 >= v1345)
                continue;
            v1345 = v1347;
            v1346 = true;
        }

        if (!(v1346))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1345;
    }

    decimal Min5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1348;
        decimal v1349;
        bool v1350;
        decimal v1351;
        v1349 = 79228162514264337593543950335M;
        v1350 = false;
        v1348 = 0;
        for (; v1348 < ArrayItems.Length; v1348++)
        {
            v1351 = (ArrayItems[v1348] + 2m);
            if (v1351 >= v1349)
                continue;
            v1349 = v1351;
            v1350 = true;
        }

        if (!(v1350))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1349;
    }

    int? Min6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1352;
        int v1353;
        bool v1354;
        int? v1355;
        v1353 = 2147483647;
        v1354 = false;
        v1352 = 0;
        for (; v1352 < ArrayItems.Length; v1352++)
        {
            v1355 = (ArrayItems[v1352] > 10 ? (int? )null : ArrayItems[v1352] + 2);
            if ((v1355 == null) || v1355 >= v1353)
                continue;
            v1353 = (int)v1355;
            v1354 = true;
        }

        if (!(v1354))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1353;
    }

    float? Min7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1356;
        float v1357;
        bool v1358;
        float? v1359;
        v1357 = 3.4028235E+38F;
        v1358 = false;
        v1356 = 0;
        for (; v1356 < ArrayItems.Length; v1356++)
        {
            v1359 = (ArrayItems[v1356] > 10 ? (float? )null : ArrayItems[v1356] + 2);
            if ((v1359 == null) || v1359 >= v1357)
                continue;
            v1357 = (float)v1359;
            v1358 = true;
        }

        if (!(v1358))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1357;
    }

    double? Min8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1360;
        double v1361;
        bool v1362;
        double? v1363;
        v1361 = 1.7976931348623157E+308;
        v1362 = false;
        v1360 = 0;
        for (; v1360 < ArrayItems.Length; v1360++)
        {
            v1363 = (ArrayItems[v1360] > 10 ? (double? )null : ArrayItems[v1360] + 2);
            if ((v1363 == null) || v1363 >= v1361)
                continue;
            v1361 = (double)v1363;
            v1362 = true;
        }

        if (!(v1362))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1361;
    }

    decimal? Min9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1364;
        decimal v1365;
        bool v1366;
        decimal? v1367;
        v1365 = 79228162514264337593543950335M;
        v1366 = false;
        v1364 = 0;
        for (; v1364 < ArrayItems.Length; v1364++)
        {
            v1367 = (ArrayItems[v1364] > 10 ? (decimal? )null : ArrayItems[v1364] + 2);
            if ((v1367 == null) || v1367 >= v1365)
                continue;
            v1365 = (decimal)v1367;
            v1366 = true;
        }

        if (!(v1366))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1365;
    }

    long Min10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1368;
        long v1369;
        bool v1370;
        long v1371;
        v1369 = 9223372036854775807L;
        v1370 = false;
        v1368 = 0;
        for (; v1368 < ArrayItems.Length; v1368++)
        {
            v1371 = (ArrayItems[v1368] + 2L);
            if (v1371 >= v1369)
                continue;
            v1369 = v1371;
            v1370 = true;
        }

        if (!(v1370))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1369;
    }

    long? Min11Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1372;
        long v1373;
        bool v1374;
        long? v1375;
        v1373 = 9223372036854775807L;
        v1374 = false;
        v1372 = 0;
        for (; v1372 < ArrayItems.Length; v1372++)
        {
            v1375 = (ArrayItems[v1372] > 10 ? (long? )null : ArrayItems[v1372] + 2);
            if ((v1375 == null) || v1375 >= v1373)
                continue;
            v1373 = (long)v1375;
            v1374 = true;
        }

        if (!(v1374))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1373;
    }

    int Min12Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1376;
        int v1377;
        bool v1378;
        int v1379;
        v1377 = 2147483647;
        v1378 = false;
        v1376 = 0;
        for (; v1376 < ArrayItems.Length; v1376++)
        {
            v1379 = Selector(ArrayItems[v1376]);
            if (v1379 >= v1377)
                continue;
            v1377 = v1379;
            v1378 = true;
        }

        if (!(v1378))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1377;
    }

    int MinParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1380;
        int v1381;
        bool v1382;
        int v1383;
        v1381 = 2147483647;
        v1382 = false;
        v1380 = 0;
        for (; v1380 < ArrayItems.Length; v1380++)
        {
            v1383 = (ArrayItems[v1380] + a);
            if (v1383 >= v1381)
                continue;
            v1381 = v1383;
            v1382 = true;
        }

        if (!(v1382))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1381;
    }

    int MinChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1384;
        int v1385;
        bool v1386;
        int v1387;
        v1385 = 2147483647;
        v1386 = false;
        v1384 = 0;
        for (; v1384 < ArrayItems.Length; v1384++)
        {
            v1387 = (ArrayItems[v1384] + a++);
            if (v1387 >= v1385)
                continue;
            v1385 = v1387;
            v1386 = true;
        }

        if (!(v1386))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1385;
    }

    int MinChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1388;
        int v1389;
        bool v1390;
        int v1391;
        v1389 = 2147483647;
        v1390 = false;
        v1388 = 0;
        for (; v1388 < ArrayItems.Length; v1388++)
        {
            v1391 = (ArrayItems[v1388] + a--);
            if (v1391 >= v1389)
                continue;
            v1389 = v1391;
            v1390 = true;
        }

        if (!(v1390))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1389;
    }

    int SelectMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1392;
        int v1393;
        bool v1394;
        int v1395;
        v1393 = 2147483647;
        v1394 = false;
        v1392 = 0;
        for (; v1392 < ArrayItems.Length; v1392++)
        {
            v1395 = (ArrayItems[v1392] + 3);
            if (v1395 >= v1393)
                continue;
            v1393 = v1395;
            v1394 = true;
        }

        if (!(v1394))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1393;
    }

    int EmptyMinRewritten_ProceduralLinq1()
    {
        int v1396;
        int v1397;
        bool v1398;
        v1397 = 2147483647;
        v1398 = false;
        v1396 = 0;
        for (; v1396 < 0; v1396++)
        {
            if (default(int) >= v1397)
                continue;
            v1397 = default(int);
            v1398 = true;
        }

        if (!(v1398))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1397;
    }

    int EmptyMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1399;
        int v1400;
        bool v1401;
        v1400 = 2147483647;
        v1401 = false;
        v1399 = 0;
        for (; v1399 < ArrayItems.Length; v1399++)
        {
            if (!((false)))
                continue;
            if (ArrayItems[v1399] >= v1400)
                continue;
            v1400 = ArrayItems[v1399];
            v1401 = true;
        }

        if (!(v1401))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1400;
    }

    int EnumerableMinRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1402;
        int v1403;
        bool v1404;
        int v1405;
        v1402 = EnumerableItems.GetEnumerator();
        v1403 = 2147483647;
        v1404 = false;
        try
        {
            while (v1402.MoveNext())
            {
                v1405 = v1402.Current;
                if (v1405 >= v1403)
                    continue;
                v1403 = v1405;
                v1404 = true;
            }
        }
        finally
        {
            v1402.Dispose();
        }

        if (!(v1404))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1403;
    }
}}