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
        int v1260;
        int v1261;
        bool v1262;
        v1261 = -2147483648;
        v1262 = false;
        v1260 = 0;
        for (; v1260 < ArrayItems.Length; v1260++)
        {
            if (ArrayItems[v1260] <= v1261)
                continue;
            v1261 = ArrayItems[v1260];
            v1262 = true;
        }

        if (!(v1262))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1261;
    }

    int Max2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1263;
        int v1264;
        bool v1265;
        int v1266;
        v1264 = -2147483648;
        v1265 = false;
        v1263 = 0;
        for (; v1263 < ArrayItems.Length; v1263++)
        {
            v1266 = (ArrayItems[v1263] + 2);
            if (v1266 <= v1264)
                continue;
            v1264 = v1266;
            v1265 = true;
        }

        if (!(v1265))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1264;
    }

    float Max3Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1267;
        float v1268;
        bool v1269;
        float v1270;
        v1268 = -3.4028235E+38F;
        v1269 = false;
        v1267 = 0;
        for (; v1267 < ArrayItems.Length; v1267++)
        {
            v1270 = (ArrayItems[v1267] + 2f);
            if (v1270 <= v1268)
                continue;
            v1268 = v1270;
            v1269 = true;
        }

        if (!(v1269))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1268;
    }

    double Max4Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1271;
        double v1272;
        bool v1273;
        double v1274;
        v1272 = -1.7976931348623157E+308;
        v1273 = false;
        v1271 = 0;
        for (; v1271 < ArrayItems.Length; v1271++)
        {
            v1274 = (ArrayItems[v1271] + 2d);
            if (v1274 <= v1272)
                continue;
            v1272 = v1274;
            v1273 = true;
        }

        if (!(v1273))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1272;
    }

    decimal Max5Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1275;
        decimal v1276;
        bool v1277;
        decimal v1278;
        v1276 = -79228162514264337593543950335M;
        v1277 = false;
        v1275 = 0;
        for (; v1275 < ArrayItems.Length; v1275++)
        {
            v1278 = (ArrayItems[v1275] + 2m);
            if (v1278 <= v1276)
                continue;
            v1276 = v1278;
            v1277 = true;
        }

        if (!(v1277))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1276;
    }

    int? Max6Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1279;
        int v1280;
        bool v1281;
        int? v1282;
        v1280 = -2147483648;
        v1281 = false;
        v1279 = 0;
        for (; v1279 < ArrayItems.Length; v1279++)
        {
            v1282 = (ArrayItems[v1279] > 10 ? (int? )null : ArrayItems[v1279] + 2);
            if ((v1282 == null) || v1282 <= v1280)
                continue;
            v1280 = (int)v1282;
            v1281 = true;
        }

        if (!(v1281))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1280;
    }

    float? Max7Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1283;
        float v1284;
        bool v1285;
        float? v1286;
        v1284 = -3.4028235E+38F;
        v1285 = false;
        v1283 = 0;
        for (; v1283 < ArrayItems.Length; v1283++)
        {
            v1286 = (ArrayItems[v1283] > 10 ? (float? )null : ArrayItems[v1283] + 2);
            if ((v1286 == null) || v1286 <= v1284)
                continue;
            v1284 = (float)v1286;
            v1285 = true;
        }

        if (!(v1285))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1284;
    }

    double? Max8Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1287;
        double v1288;
        bool v1289;
        double? v1290;
        v1288 = -1.7976931348623157E+308;
        v1289 = false;
        v1287 = 0;
        for (; v1287 < ArrayItems.Length; v1287++)
        {
            v1290 = (ArrayItems[v1287] > 10 ? (double? )null : ArrayItems[v1287] + 2);
            if ((v1290 == null) || v1290 <= v1288)
                continue;
            v1288 = (double)v1290;
            v1289 = true;
        }

        if (!(v1289))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1288;
    }

    decimal? Max9Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1291;
        decimal v1292;
        bool v1293;
        decimal? v1294;
        v1292 = -79228162514264337593543950335M;
        v1293 = false;
        v1291 = 0;
        for (; v1291 < ArrayItems.Length; v1291++)
        {
            v1294 = (ArrayItems[v1291] > 10 ? (decimal? )null : ArrayItems[v1291] + 2);
            if ((v1294 == null) || v1294 <= v1292)
                continue;
            v1292 = (decimal)v1294;
            v1293 = true;
        }

        if (!(v1293))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1292;
    }

    long Max10Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1295;
        long v1296;
        bool v1297;
        long v1298;
        v1296 = -9223372036854775808L;
        v1297 = false;
        v1295 = 0;
        for (; v1295 < ArrayItems.Length; v1295++)
        {
            v1298 = (ArrayItems[v1295] + 2L);
            if (v1298 <= v1296)
                continue;
            v1296 = v1298;
            v1297 = true;
        }

        if (!(v1297))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1296;
    }

    long? Max11Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1299;
        long v1300;
        bool v1301;
        long? v1302;
        v1300 = -9223372036854775808L;
        v1301 = false;
        v1299 = 0;
        for (; v1299 < ArrayItems.Length; v1299++)
        {
            v1302 = (ArrayItems[v1299] > 10 ? (long? )null : ArrayItems[v1299] + 2);
            if ((v1302 == null) || v1302 <= v1300)
                continue;
            v1300 = (long)v1302;
            v1301 = true;
        }

        if (!(v1301))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1300;
    }

    int Max12Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1303;
        int v1304;
        bool v1305;
        int v1306;
        v1304 = -2147483648;
        v1305 = false;
        v1303 = 0;
        for (; v1303 < ArrayItems.Length; v1303++)
        {
            v1306 = Selector(ArrayItems[v1303]);
            if (v1306 <= v1304)
                continue;
            v1304 = v1306;
            v1305 = true;
        }

        if (!(v1305))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1304;
    }

    int MaxParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1307;
        int v1308;
        bool v1309;
        int v1310;
        v1308 = -2147483648;
        v1309 = false;
        v1307 = 0;
        for (; v1307 < ArrayItems.Length; v1307++)
        {
            v1310 = (ArrayItems[v1307] + a);
            if (v1310 <= v1308)
                continue;
            v1308 = v1310;
            v1309 = true;
        }

        if (!(v1309))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1308;
    }

    int MaxChangingParamRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1311;
        int v1312;
        bool v1313;
        int v1314;
        v1312 = -2147483648;
        v1313 = false;
        v1311 = 0;
        for (; v1311 < ArrayItems.Length; v1311++)
        {
            v1314 = (ArrayItems[v1311] + a++);
            if (v1314 <= v1312)
                continue;
            v1312 = v1314;
            v1313 = true;
        }

        if (!(v1313))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1312;
    }

    int MaxChangingParam2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1315;
        int v1316;
        bool v1317;
        int v1318;
        v1316 = -2147483648;
        v1317 = false;
        v1315 = 0;
        for (; v1315 < ArrayItems.Length; v1315++)
        {
            v1318 = (ArrayItems[v1315] + a--);
            if (v1318 <= v1316)
                continue;
            v1316 = v1318;
            v1317 = true;
        }

        if (!(v1317))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1316;
    }

    int SelectMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1319;
        int v1320;
        bool v1321;
        int v1322;
        v1320 = -2147483648;
        v1321 = false;
        v1319 = 0;
        for (; v1319 < ArrayItems.Length; v1319++)
        {
            v1322 = (ArrayItems[v1319] + 3);
            if (v1322 <= v1320)
                continue;
            v1320 = v1322;
            v1321 = true;
        }

        if (!(v1321))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1320;
    }

    int EmptyMaxRewritten_ProceduralLinq1()
    {
        int v1323;
        int v1324;
        bool v1325;
        v1324 = -2147483648;
        v1325 = false;
        v1323 = 0;
        for (; v1323 < 0; v1323++)
        {
            if (default(int) <= v1324)
                continue;
            v1324 = default(int);
            v1325 = true;
        }

        if (!(v1325))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1324;
    }

    int EmptyMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1326;
        int v1327;
        bool v1328;
        v1327 = -2147483648;
        v1328 = false;
        v1326 = 0;
        for (; v1326 < ArrayItems.Length; v1326++)
        {
            if (!((false)))
                continue;
            if (ArrayItems[v1326] <= v1327)
                continue;
            v1327 = ArrayItems[v1326];
            v1328 = true;
        }

        if (!(v1328))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1327;
    }

    int EnumerableMaxRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1329;
        int v1330;
        bool v1331;
        int v1332;
        v1329 = EnumerableItems.GetEnumerator();
        v1330 = -2147483648;
        v1331 = false;
        try
        {
            while (v1329.MoveNext())
            {
                v1332 = v1329.Current;
                if (v1332 <= v1330)
                    continue;
                v1330 = v1332;
                v1331 = true;
            }
        }
        finally
        {
            v1329.Dispose();
        }

        if (!(v1331))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1330;
    }
}}