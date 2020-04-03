using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class MaxTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private int Selector(int value) => value + 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(Max1), Max1, Max1Rewritten);
        TestsExtensions.TestEquals(nameof(Max2), Max2, Max2Rewritten);
        TestsExtensions.TestEquals(nameof(Max3), Max3, Max3Rewritten);
        TestsExtensions.TestEquals(nameof(Max4), Max4, Max4Rewritten);
        TestsExtensions.TestEquals(nameof(Max5), Max5, Max5Rewritten);
        TestsExtensions.TestEquals(nameof(Max6), Max6, Max6Rewritten);
        TestsExtensions.TestEquals(nameof(Max7), Max7, Max7Rewritten);
        TestsExtensions.TestEquals(nameof(Max8), Max8, Max8Rewritten);
        TestsExtensions.TestEquals(nameof(Max9), Max9, Max9Rewritten);
        TestsExtensions.TestEquals(nameof(Max10), Max10, Max10Rewritten);
        TestsExtensions.TestEquals(nameof(Max11), Max11, Max11Rewritten);
        TestsExtensions.TestEquals(nameof(Max12), Max12, Max12Rewritten);
        TestsExtensions.TestEquals(nameof(MaxParam), MaxParam, MaxParamRewritten);
        TestsExtensions.TestEquals(nameof(MaxChangingParam), MaxChangingParam, MaxChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(MaxChangingParam2), MaxChangingParam2, MaxChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectMax), SelectMax, SelectMaxRewritten);
        TestsExtensions.TestEquals(nameof(EmptyMax), EmptyMax, EmptyMaxRewritten);
        TestsExtensions.TestEquals(nameof(EmptyMax2), EmptyMax2, EmptyMax2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableMax), EnumerableMax, EnumerableMaxRewritten);
    }

    [NoRewrite]
    public int Max1()
    {
        return ArrayItems.Max();
    } //EndMethod

    public int Max1Rewritten()
    {
        return Max1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int Max2()
    {
        return ArrayItems.Max(x => x + 2);
    } //EndMethod

    public int Max2Rewritten()
    {
        return Max2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public float Max3()
    {
        return ArrayItems.Max(x => x + 2f);
    } //EndMethod

    public float Max3Rewritten()
    {
        return Max3Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double Max4()
    {
        return ArrayItems.Max(x => x + 2d);
    } //EndMethod

    public double Max4Rewritten()
    {
        return Max4Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal Max5()
    {
        return ArrayItems.Max(x => x + 2m);
    } //EndMethod

    public decimal Max5Rewritten()
    {
        return Max5Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? Max6()
    {
        return ArrayItems.Max(x => x > 10 ? (int? )null : x + 2);
    } //EndMethod

    public int? Max6Rewritten()
    {
        return Max6Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public float? Max7()
    {
        return ArrayItems.Max(x => x > 10 ? (float? )null : x + 2);
    } //EndMethod

    public float? Max7Rewritten()
    {
        return Max7Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double? Max8()
    {
        return ArrayItems.Max(x => x > 10 ? (double? )null : x + 2);
    } //EndMethod

    public double? Max8Rewritten()
    {
        return Max8Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal? Max9()
    {
        return ArrayItems.Max(x => x > 10 ? (decimal? )null : x + 2);
    } //EndMethod

    public decimal? Max9Rewritten()
    {
        return Max9Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long Max10()
    {
        return ArrayItems.Max(x => x + 2L);
    } //EndMethod

    public long Max10Rewritten()
    {
        return Max10Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long? Max11()
    {
        return ArrayItems.Max(x => x > 10 ? (long? )null : x + 2);
    } //EndMethod

    public long? Max11Rewritten()
    {
        return Max11Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? Max12()
    {
        return ArrayItems.Max(Selector);
    } //EndMethod

    public int? Max12Rewritten()
    {
        return Max12Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MaxParam()
    {
        var a = 10;
        return ArrayItems.Max(x => x + a);
    } //EndMethod

    public int? MaxParamRewritten()
    {
        var a = 10;
        return MaxParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MaxChangingParam()
    {
        var a = 10;
        return ArrayItems.Max(x => x + a++);
    } //EndMethod

    public int? MaxChangingParamRewritten()
    {
        var a = 10;
        return MaxChangingParamRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? MaxChangingParam2()
    {
        var a = 10;
        return ArrayItems.Max(x => x + a--);
    } //EndMethod

    public int? MaxChangingParam2Rewritten()
    {
        var a = 10;
        return MaxChangingParam2Rewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? SelectMax()
    {
        var a = 10;
        return ArrayItems.Select(x => x + 3).Max();
    } //EndMethod

    public int? SelectMaxRewritten()
    {
        var a = 10;
        return SelectMaxRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? EmptyMax()
    {
        return Enumerable.Empty<int>().Max();
    } //EndMethod

    public int? EmptyMaxRewritten()
    {
        return EmptyMaxRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int? EmptyMax2()
    {
        return ArrayItems.Where(x => false).Max();
    } //EndMethod

    public int? EmptyMax2Rewritten()
    {
        return EmptyMax2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int? EnumerableMax()
    {
        return EnumerableItems.Max();
    } //EndMethod

    public int? EnumerableMaxRewritten()
    {
        return EnumerableMaxRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    int Max1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1287;
        int v1288;
        bool v1289;
        v1288 = -2147483648;
        v1289 = false;
        v1287 = 0;
        for (; v1287 < ArrayItems.Length; v1287++)
        {
            if (ArrayItems[v1287] <= v1288)
                continue;
            v1288 = ArrayItems[v1287];
            v1289 = true;
        }

        if (!(v1289))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1288;
    }

    int Max2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1290;
        int v1291;
        bool v1292;
        int v1293;
        v1291 = -2147483648;
        v1292 = false;
        v1290 = 0;
        for (; v1290 < ArrayItems.Length; v1290++)
        {
            v1293 = (ArrayItems[v1290] + 2);
            if (v1293 <= v1291)
                continue;
            v1291 = v1293;
            v1292 = true;
        }

        if (!(v1292))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1291;
    }

    float Max3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1294;
        float v1295;
        bool v1296;
        float v1297;
        v1295 = -3.4028235E+38F;
        v1296 = false;
        v1294 = 0;
        for (; v1294 < ArrayItems.Length; v1294++)
        {
            v1297 = (ArrayItems[v1294] + 2f);
            if (v1297 <= v1295)
                continue;
            v1295 = v1297;
            v1296 = true;
        }

        if (!(v1296))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1295;
    }

    double Max4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1298;
        double v1299;
        bool v1300;
        double v1301;
        v1299 = -1.7976931348623157E+308;
        v1300 = false;
        v1298 = 0;
        for (; v1298 < ArrayItems.Length; v1298++)
        {
            v1301 = (ArrayItems[v1298] + 2d);
            if (v1301 <= v1299)
                continue;
            v1299 = v1301;
            v1300 = true;
        }

        if (!(v1300))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1299;
    }

    decimal Max5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1302;
        decimal v1303;
        bool v1304;
        decimal v1305;
        v1303 = -79228162514264337593543950335M;
        v1304 = false;
        v1302 = 0;
        for (; v1302 < ArrayItems.Length; v1302++)
        {
            v1305 = (ArrayItems[v1302] + 2m);
            if (v1305 <= v1303)
                continue;
            v1303 = v1305;
            v1304 = true;
        }

        if (!(v1304))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1303;
    }

    int? Max6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1306;
        int v1307;
        bool v1308;
        int? v1309;
        v1307 = -2147483648;
        v1308 = false;
        v1306 = 0;
        for (; v1306 < ArrayItems.Length; v1306++)
        {
            v1309 = (ArrayItems[v1306] > 10 ? (int? )null : ArrayItems[v1306] + 2);
            if ((v1309 == null) || v1309 <= v1307)
                continue;
            v1307 = (int)v1309;
            v1308 = true;
        }

        if (!(v1308))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1307;
    }

    float? Max7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1310;
        float v1311;
        bool v1312;
        float? v1313;
        v1311 = -3.4028235E+38F;
        v1312 = false;
        v1310 = 0;
        for (; v1310 < ArrayItems.Length; v1310++)
        {
            v1313 = (ArrayItems[v1310] > 10 ? (float? )null : ArrayItems[v1310] + 2);
            if ((v1313 == null) || v1313 <= v1311)
                continue;
            v1311 = (float)v1313;
            v1312 = true;
        }

        if (!(v1312))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1311;
    }

    double? Max8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1314;
        double v1315;
        bool v1316;
        double? v1317;
        v1315 = -1.7976931348623157E+308;
        v1316 = false;
        v1314 = 0;
        for (; v1314 < ArrayItems.Length; v1314++)
        {
            v1317 = (ArrayItems[v1314] > 10 ? (double? )null : ArrayItems[v1314] + 2);
            if ((v1317 == null) || v1317 <= v1315)
                continue;
            v1315 = (double)v1317;
            v1316 = true;
        }

        if (!(v1316))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1315;
    }

    decimal? Max9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1318;
        decimal v1319;
        bool v1320;
        decimal? v1321;
        v1319 = -79228162514264337593543950335M;
        v1320 = false;
        v1318 = 0;
        for (; v1318 < ArrayItems.Length; v1318++)
        {
            v1321 = (ArrayItems[v1318] > 10 ? (decimal? )null : ArrayItems[v1318] + 2);
            if ((v1321 == null) || v1321 <= v1319)
                continue;
            v1319 = (decimal)v1321;
            v1320 = true;
        }

        if (!(v1320))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1319;
    }

    long Max10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1322;
        long v1323;
        bool v1324;
        long v1325;
        v1323 = -9223372036854775808L;
        v1324 = false;
        v1322 = 0;
        for (; v1322 < ArrayItems.Length; v1322++)
        {
            v1325 = (ArrayItems[v1322] + 2L);
            if (v1325 <= v1323)
                continue;
            v1323 = v1325;
            v1324 = true;
        }

        if (!(v1324))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1323;
    }

    long? Max11Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1326;
        long v1327;
        bool v1328;
        long? v1329;
        v1327 = -9223372036854775808L;
        v1328 = false;
        v1326 = 0;
        for (; v1326 < ArrayItems.Length; v1326++)
        {
            v1329 = (ArrayItems[v1326] > 10 ? (long? )null : ArrayItems[v1326] + 2);
            if ((v1329 == null) || v1329 <= v1327)
                continue;
            v1327 = (long)v1329;
            v1328 = true;
        }

        if (!(v1328))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1327;
    }

    int Max12Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1330;
        int v1331;
        bool v1332;
        int v1333;
        v1331 = -2147483648;
        v1332 = false;
        v1330 = 0;
        for (; v1330 < ArrayItems.Length; v1330++)
        {
            v1333 = Selector(ArrayItems[v1330]);
            if (v1333 <= v1331)
                continue;
            v1331 = v1333;
            v1332 = true;
        }

        if (!(v1332))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1331;
    }

    int MaxParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1334;
        int v1335;
        bool v1336;
        int v1337;
        v1335 = -2147483648;
        v1336 = false;
        v1334 = 0;
        for (; v1334 < ArrayItems.Length; v1334++)
        {
            v1337 = (ArrayItems[v1334] + a);
            if (v1337 <= v1335)
                continue;
            v1335 = v1337;
            v1336 = true;
        }

        if (!(v1336))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1335;
    }

    int MaxChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1338;
        int v1339;
        bool v1340;
        int v1341;
        v1339 = -2147483648;
        v1340 = false;
        v1338 = 0;
        for (; v1338 < ArrayItems.Length; v1338++)
        {
            v1341 = (ArrayItems[v1338] + a++);
            if (v1341 <= v1339)
                continue;
            v1339 = v1341;
            v1340 = true;
        }

        if (!(v1340))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1339;
    }

    int MaxChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1342;
        int v1343;
        bool v1344;
        int v1345;
        v1343 = -2147483648;
        v1344 = false;
        v1342 = 0;
        for (; v1342 < ArrayItems.Length; v1342++)
        {
            v1345 = (ArrayItems[v1342] + a--);
            if (v1345 <= v1343)
                continue;
            v1343 = v1345;
            v1344 = true;
        }

        if (!(v1344))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1343;
    }

    int SelectMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1346;
        int v1347;
        bool v1348;
        int v1349;
        v1347 = -2147483648;
        v1348 = false;
        v1346 = 0;
        for (; v1346 < ArrayItems.Length; v1346++)
        {
            v1349 = (ArrayItems[v1346] + 3);
            if (v1349 <= v1347)
                continue;
            v1347 = v1349;
            v1348 = true;
        }

        if (!(v1348))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1347;
    }

    int EmptyMaxRewritten_ProceduralLinq1()
    {
        int v1350;
        int v1351;
        bool v1352;
        v1351 = -2147483648;
        v1352 = false;
        v1350 = 0;
        for (; v1350 < 0; v1350++)
        {
            if (default(int) <= v1351)
                continue;
            v1351 = default(int);
            v1352 = true;
        }

        if (!(v1352))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1351;
    }

    int EmptyMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1353;
        int v1354;
        bool v1355;
        v1354 = -2147483648;
        v1355 = false;
        v1353 = 0;
        for (; v1353 < ArrayItems.Length; v1353++)
        {
            if (!((false)))
                continue;
            if (ArrayItems[v1353] <= v1354)
                continue;
            v1354 = ArrayItems[v1353];
            v1355 = true;
        }

        if (!(v1355))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1354;
    }

    int EnumerableMaxRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1356;
        int v1357;
        bool v1358;
        int v1359;
        v1356 = EnumerableItems.GetEnumerator();
        v1357 = -2147483648;
        v1358 = false;
        try
        {
            while (v1356.MoveNext())
            {
                v1359 = v1356.Current;
                if (v1359 <= v1357)
                    continue;
                v1357 = v1359;
                v1358 = true;
            }
        }
        finally
        {
            v1356.Dispose();
        }

        if (!(v1358))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1357;
    }
}}