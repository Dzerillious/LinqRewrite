|                             Method | Offset |        Mean |     Error |      StdDev |      Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------- |------- |------------:|----------:|------------:|------------:|------:|------:|------:|----------:|
|                  ArrayToSimpleList |      0 |    779.3 ns |  36.59 ns |   100.16 ns |    800.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |      0 |    951.2 ns |  63.61 ns |   168.69 ns |    900.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |      0 |  1,038.1 ns |  37.41 ns |   100.49 ns |  1,000.0 ns |     - |     - |     - |         - |
|         RangeToSimpleListRewritten |      0 |    890.6 ns |  48.30 ns |   130.59 ns |    900.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |      0 |    993.8 ns |  29.00 ns |    76.40 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy2Rewritten |      0 |    994.1 ns |  44.71 ns |   120.86 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy4Rewritten |      0 |    997.6 ns |  37.45 ns |    99.97 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy8Rewritten |      0 |    992.9 ns |  53.78 ns |   145.40 ns |    900.0 ns |     - |     - |     - |         - |
|                  ArrayToSimpleList |      1 |    830.1 ns |  40.42 ns |   107.90 ns |    800.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |      1 |    946.3 ns |  34.65 ns |    91.89 ns |    900.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |      1 |  1,016.5 ns |  26.68 ns |    72.12 ns |  1,000.0 ns |     - |     - |     - |         - |
|         RangeToSimpleListRewritten |      1 |    891.8 ns |  41.63 ns |   112.56 ns |    900.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |      1 |  1,021.4 ns |  44.41 ns |   119.31 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy2Rewritten |      1 |    998.8 ns |  29.09 ns |    76.64 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy4Rewritten |      1 |  1,022.4 ns |  34.42 ns |    93.06 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy8Rewritten |      1 |    983.3 ns |  42.79 ns |   114.95 ns |  1,000.0 ns |     - |     - |     - |         - |
|                  ArrayToSimpleList |      2 |    848.2 ns |  45.46 ns |   121.34 ns |    800.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |      2 |    973.2 ns |  37.96 ns |   100.68 ns |  1,000.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |      2 |  1,035.4 ns |  24.67 ns |    64.13 ns |  1,000.0 ns |     - |     - |     - |         - |
|         RangeToSimpleListRewritten |      2 |    910.6 ns |  44.22 ns |   119.55 ns |    900.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |      2 |  1,051.8 ns |  36.71 ns |    97.98 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy2Rewritten |      2 |  1,031.0 ns |  42.06 ns |   112.98 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy4Rewritten |      2 |  1,076.5 ns |  54.04 ns |   146.10 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy8Rewritten |      2 |  1,047.0 ns |  60.62 ns |   161.80 ns |  1,000.0 ns |     - |     - |     - |         - |
|                  ArrayToSimpleList |      5 |    855.3 ns |  42.52 ns |   114.96 ns |    800.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |      5 |    946.3 ns |  41.56 ns |   110.21 ns |    900.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |      5 |  1,096.3 ns |  44.52 ns |   118.06 ns |  1,100.0 ns |     - |     - |     - |         - |
|         RangeToSimpleListRewritten |      5 |    909.6 ns |  47.03 ns |   125.54 ns |    900.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |      5 |  1,090.7 ns |  42.05 ns |   114.41 ns |  1,100.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy2Rewritten |      5 |  1,054.2 ns |  42.72 ns |   114.02 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy4Rewritten |      5 |  1,042.5 ns |  35.86 ns |    93.83 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy8Rewritten |      5 |  1,053.7 ns |  38.94 ns |   103.27 ns |  1,000.0 ns |     - |     - |     - |         - |
|                  ArrayToSimpleList |     10 |    825.3 ns |  29.74 ns |    79.39 ns |    800.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |     10 |    966.7 ns |  33.36 ns |    89.62 ns |    950.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |     10 |  1,326.5 ns |  51.37 ns |   137.12 ns |  1,300.0 ns |     - |     - |     - |         - |
|         RangeToSimpleListRewritten |     10 |    887.8 ns |  34.75 ns |    92.15 ns |    900.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |     10 |  1,286.4 ns |  56.54 ns |   148.96 ns |  1,200.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy2Rewritten |     10 |  1,222.0 ns |  32.47 ns |    86.10 ns |  1,200.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy4Rewritten |     10 |  1,275.3 ns |  44.91 ns |   121.41 ns |  1,200.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy8Rewritten |     10 |  1,304.8 ns |  54.54 ns |   145.59 ns |  1,300.0 ns |     - |     - |     - |         - |
|                  ArrayToSimpleList |     20 |    852.9 ns |  36.03 ns |    98.64 ns |    800.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |     20 |    967.1 ns |  28.45 ns |    75.45 ns |  1,000.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |     20 |  1,337.8 ns |  36.35 ns |    96.40 ns |  1,300.0 ns |     - |     - |     - |         - |
|         RangeToSimpleListRewritten |     20 |    895.3 ns |  41.51 ns |   112.23 ns |    900.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |     20 |  1,272.0 ns |  37.60 ns |    99.72 ns |  1,300.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy2Rewritten |     20 |  1,328.6 ns |  55.89 ns |   150.16 ns |  1,300.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy4Rewritten |     20 |  1,304.9 ns |  52.63 ns |   139.58 ns |  1,300.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy8Rewritten |     20 |  1,304.8 ns |  73.99 ns |   197.49 ns |  1,200.0 ns |     - |     - |     - |         - |
|                  ArrayToSimpleList |     50 |    801.2 ns |  30.30 ns |    79.83 ns |    800.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |     50 |    969.1 ns |  42.29 ns |   111.40 ns |    900.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |     50 |  1,551.3 ns |  42.99 ns |   112.50 ns |  1,500.0 ns |     - |     - |     - |         - |
|         RangeToSimpleListRewritten |     50 |    955.0 ns |  43.80 ns |   114.63 ns |    900.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |     50 |  1,501.2 ns |  51.80 ns |   136.47 ns |  1,500.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy2Rewritten |     50 |  1,464.6 ns |  44.38 ns |   103.73 ns |  1,400.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy4Rewritten |     50 |  1,487.7 ns |  54.14 ns |   142.64 ns |  1,400.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy8Rewritten |     50 |  1,423.2 ns |  37.15 ns |    98.51 ns |  1,400.0 ns |     - |     - |     - |         - |
|                  ArrayToSimpleList |    100 |    869.6 ns |  88.07 ns |   228.91 ns |    800.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |    100 |  1,349.0 ns | 256.28 ns |   739.42 ns |  1,000.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |    100 |  2,324.7 ns | 316.93 ns |   919.47 ns |  1,800.0 ns |     - |     - |     - |         - |
|         RangeToSimpleListRewritten |    100 |  1,288.2 ns | 229.09 ns |   649.89 ns |  1,000.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |    100 |  2,079.8 ns | 259.79 ns |   741.20 ns |  1,700.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy2Rewritten |    100 |  2,240.2 ns | 273.35 ns |   793.02 ns |  1,800.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy4Rewritten |    100 |  1,693.3 ns |  37.60 ns |    84.10 ns |  1,700.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy8Rewritten |    100 |  1,708.2 ns |  38.02 ns |    75.93 ns |  1,700.0 ns |     - |     - |     - |         - |
|                  ArrayToSimpleList |    200 |  1,753.5 ns | 333.24 ns |   977.33 ns |  1,100.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |    200 |  1,705.1 ns | 325.63 ns |   949.89 ns |  1,000.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |    200 |  3,209.5 ns | 345.70 ns |   991.89 ns |  2,600.0 ns |     - |     - |     - |         - |
|         RangeToSimpleListRewritten |    200 |  1,780.6 ns | 294.19 ns |   858.15 ns |  1,400.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |    200 |  3,127.1 ns | 355.83 ns | 1,026.64 ns |  2,500.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy2Rewritten |    200 |  2,353.8 ns | 190.77 ns |   261.12 ns |  2,300.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy4Rewritten |    200 |  2,200.0 ns |  56.46 ns |   104.65 ns |  2,200.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy8Rewritten |    200 |  2,990.4 ns | 376.63 ns | 1,074.54 ns |  2,300.0 ns |     - |     - |     - |         - |
|                  ArrayToSimpleList |    500 |  2,460.2 ns | 434.93 ns | 1,268.71 ns |  2,500.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |    500 |  2,429.3 ns | 372.50 ns | 1,092.48 ns |  2,500.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |    500 |  5,293.5 ns | 475.61 ns | 1,349.22 ns |  5,300.0 ns |     - |     - |     - |         - |
|         RangeToSimpleListRewritten |    500 |  2,658.2 ns | 437.85 ns | 1,277.23 ns |  2,700.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |    500 |  3,458.3 ns |  65.95 ns |    51.49 ns |  3,500.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy2Rewritten |    500 |  3,620.0 ns |  72.38 ns |    83.35 ns |  3,600.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy4Rewritten |    500 |  5,208.6 ns | 464.19 ns | 1,316.84 ns |  5,200.0 ns |     - |     - |     - |         - |
| EnumerableToSimpleListBy8Rewritten |    500 |  3,475.0 ns |  69.56 ns |    68.31 ns |  3,500.0 ns |     - |     - |     - |         - |
|                  ArrayToSimpleList |   1000 |  1,641.4 ns | 298.09 ns |   874.24 ns |  1,000.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |   1000 |  1,747.5 ns | 332.17 ns |   974.19 ns |  1,200.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |   1000 |  6,670.6 ns | 127.73 ns |   131.17 ns |  6,700.0 ns |     - |     - |     - |   16408 B |
|         RangeToSimpleListRewritten |   1000 |  1,971.7 ns | 291.20 ns |   854.05 ns |  1,400.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |   1000 |  8,746.8 ns | 566.28 ns | 1,615.63 ns |  8,900.0 ns |     - |     - |     - |   16408 B |
| EnumerableToSimpleListBy2Rewritten |   1000 |  8,719.8 ns | 506.46 ns | 1,461.26 ns |  9,000.0 ns |     - |     - |     - |   16384 B |
| EnumerableToSimpleListBy4Rewritten |   1000 |  6,135.7 ns |  94.97 ns |    84.19 ns |  6,100.0 ns |     - |     - |     - |   16408 B |
| EnumerableToSimpleListBy8Rewritten |   1000 |  9,010.9 ns | 708.44 ns | 1,998.16 ns |  9,100.0 ns |     - |     - |     - |   24600 B |
|                  ArrayToSimpleList |   2000 |  1,668.4 ns | 307.98 ns |   898.41 ns |  1,050.0 ns |     - |     - |     - |         - |
|         ArrayToSimpleListRewritten |   2000 |  1,759.2 ns | 285.58 ns |   833.06 ns |  1,200.0 ns |     - |     - |     - |         - |
|                  RangeToSimpleList |   2000 | 13,656.3 ns | 806.72 ns | 2,208.37 ns | 13,600.0 ns |     - |     - |     - |   16408 B |
|         RangeToSimpleListRewritten |   2000 |  2,395.9 ns | 310.29 ns |   900.22 ns |  1,800.0 ns |     - |     - |     - |         - |
|             EnumerableToSimpleList |   2000 | 10,492.3 ns | 158.13 ns |   132.05 ns | 10,500.0 ns |     - |     - |     - |   16408 B |
| EnumerableToSimpleListBy2Rewritten |   2000 | 11,406.7 ns | 788.15 ns |   737.24 ns | 11,200.0 ns |     - |     - |     - |   24600 B |
| EnumerableToSimpleListBy4Rewritten |   2000 | 10,440.0 ns | 119.87 ns |   112.12 ns | 10,500.0 ns |     - |     - |     - |   16408 B |
| EnumerableToSimpleListBy8Rewritten |   2000 | 14,321.6 ns | 922.20 ns | 2,675.48 ns | 15,100.0 ns |     - |     - |     - |   24600 B |