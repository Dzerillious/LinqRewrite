|                        Method | Offset |        Mean |       Error |      StdDev |      Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------ |------- |------------:|------------:|------------:|------------:|------:|------:|------:|----------:|
|                  ArrayToArray |      0 |  1,249.3 ns |    30.76 ns |    76.60 ns |  1,200.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |      0 |    958.8 ns |    80.77 ns |   218.38 ns |    900.0 ns |     - |     - |     - |         - |
|                  RangeToArray |      0 |  1,234.6 ns |    69.52 ns |   183.14 ns |  1,200.0 ns |     - |     - |     - |         - |
|         RangeToArrayRewritten |      0 |    769.9 ns |    31.36 ns |    83.72 ns |    800.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |      0 |  1,076.2 ns |    33.00 ns |    88.66 ns |  1,100.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy2Rewritten |      0 |    963.1 ns |    62.44 ns |   167.75 ns |    900.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy4Rewritten |      0 |    922.5 ns |    27.18 ns |    71.11 ns |    900.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy8Rewritten |      0 |    922.8 ns |    23.82 ns |    61.91 ns |    900.0 ns |     - |     - |     - |         - |
|                  ArrayToArray |      1 |  1,527.2 ns |    48.02 ns |   126.50 ns |  1,500.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |      1 |    882.4 ns |    61.25 ns |   165.60 ns |    800.0 ns |     - |     - |     - |         - |
|                  RangeToArray |      1 |  1,334.5 ns |    59.07 ns |   158.68 ns |  1,300.0 ns |     - |     - |     - |         - |
|         RangeToArrayRewritten |      1 |    777.5 ns |    37.47 ns |    98.05 ns |    800.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |      1 |  1,248.2 ns |    41.79 ns |   112.98 ns |  1,200.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy2Rewritten |      1 |  1,053.7 ns |    45.59 ns |   120.90 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy4Rewritten |      1 |  1,033.3 ns |    39.36 ns |   103.68 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy8Rewritten |      1 |  1,048.2 ns |    43.93 ns |   117.25 ns |  1,000.0 ns |     - |     - |     - |         - |
|                  ArrayToArray |      2 |  1,539.0 ns |    46.19 ns |   122.48 ns |  1,500.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |      2 |    891.4 ns |    32.43 ns |    85.44 ns |    900.0 ns |     - |     - |     - |         - |
|                  RangeToArray |      2 |  1,321.7 ns |    44.58 ns |   118.99 ns |  1,300.0 ns |     - |     - |     - |         - |
|         RangeToArrayRewritten |      2 |    753.1 ns |    33.46 ns |    88.16 ns |    700.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |      2 |  1,282.1 ns |    48.74 ns |   130.95 ns |  1,200.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy2Rewritten |      2 |  1,077.4 ns |    54.62 ns |   146.73 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy4Rewritten |      2 |  1,060.2 ns |    40.93 ns |   109.25 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy8Rewritten |      2 |  1,074.4 ns |    45.83 ns |   121.52 ns |  1,050.0 ns |     - |     - |     - |         - |
|                  ArrayToArray |      5 |  1,512.1 ns |    36.28 ns |    79.64 ns |  1,500.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |      5 |    876.7 ns |    43.56 ns |   118.49 ns |    800.0 ns |     - |     - |     - |         - |
|                  RangeToArray |      5 |  1,406.0 ns |    46.20 ns |   123.32 ns |  1,400.0 ns |     - |     - |     - |         - |
|         RangeToArrayRewritten |      5 |    781.7 ns |    40.68 ns |   107.87 ns |    800.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |      5 |  1,410.7 ns |    60.88 ns |   163.56 ns |  1,400.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy2Rewritten |      5 |  1,117.9 ns |    54.87 ns |   147.40 ns |  1,100.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy4Rewritten |      5 |  1,069.8 ns |    41.46 ns |   112.79 ns |  1,000.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy8Rewritten |      5 |  1,146.9 ns |    56.33 ns |   148.40 ns |  1,100.0 ns |     - |     - |     - |         - |
|                  ArrayToArray |     10 |  1,529.6 ns |    40.46 ns |   106.59 ns |  1,500.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |     10 |    876.5 ns |    42.98 ns |   113.22 ns |    900.0 ns |     - |     - |     - |         - |
|                  RangeToArray |     10 |  1,508.3 ns |    51.10 ns |   137.28 ns |  1,500.0 ns |     - |     - |     - |         - |
|         RangeToArrayRewritten |     10 |    785.5 ns |    31.58 ns |    84.29 ns |    800.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |     10 |  1,411.1 ns |    32.13 ns |    61.13 ns |  1,400.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy2Rewritten |     10 |  1,154.7 ns |    43.18 ns |   117.48 ns |  1,100.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy4Rewritten |     10 |  1,171.1 ns |    39.04 ns |   104.22 ns |  1,200.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy8Rewritten |     10 |  1,241.0 ns |    44.19 ns |   117.95 ns |  1,200.0 ns |     - |     - |     - |         - |
|                  ArrayToArray |     20 |  1,573.3 ns |    53.91 ns |   146.67 ns |  1,500.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |     20 |    885.9 ns |    29.74 ns |    80.41 ns |    900.0 ns |     - |     - |     - |         - |
|                  RangeToArray |     20 |  1,579.7 ns |    28.76 ns |    63.73 ns |  1,600.0 ns |     - |     - |     - |         - |
|         RangeToArrayRewritten |     20 |    795.1 ns |    33.36 ns |    87.89 ns |    800.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |     20 |  1,619.5 ns |    52.21 ns |   142.93 ns |  1,600.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy2Rewritten |     20 |  1,277.6 ns |    42.85 ns |   115.86 ns |  1,300.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy4Rewritten |     20 |  1,231.3 ns |    38.78 ns |   103.51 ns |  1,200.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy8Rewritten |     20 |  1,285.1 ns |    57.50 ns |   157.40 ns |  1,200.0 ns |     - |     - |     - |         - |
|                  ArrayToArray |     50 |  1,513.9 ns |    63.95 ns |   166.21 ns |  1,500.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |     50 |    870.7 ns |    50.45 ns |   133.78 ns |    800.0 ns |     - |     - |     - |         - |
|                  RangeToArray |     50 |  1,786.1 ns |    51.81 ns |   134.67 ns |  1,700.0 ns |     - |     - |     - |         - |
|         RangeToArrayRewritten |     50 |    894.0 ns |    59.48 ns |   158.77 ns |    900.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |     50 |  1,757.5 ns |    48.94 ns |   128.06 ns |  1,700.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy2Rewritten |     50 |  1,490.0 ns |    44.93 ns |   117.57 ns |  1,500.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy4Rewritten |     50 |  1,426.3 ns |    50.41 ns |   131.92 ns |  1,400.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy8Rewritten |     50 |  1,377.2 ns |    47.30 ns |   122.94 ns |  1,300.0 ns |     - |     - |     - |         - |
|                  ArrayToArray |    100 |  1,987.0 ns |   320.85 ns |   904.96 ns |  1,500.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |    100 |  1,310.1 ns |   273.97 ns |   803.50 ns |    800.0 ns |     - |     - |     - |         - |
|                  RangeToArray |    100 |  2,673.7 ns |   315.25 ns |   904.51 ns |  2,200.0 ns |     - |     - |     - |         - |
|         RangeToArrayRewritten |    100 |  1,137.4 ns |   205.73 ns |   576.90 ns |    900.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |    100 |  2,606.0 ns |   295.07 ns |   870.02 ns |  2,100.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy2Rewritten |    100 |  2,329.6 ns |   309.11 ns |   901.68 ns |  1,800.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy4Rewritten |    100 |  1,625.0 ns |    38.40 ns |    75.79 ns |  1,600.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy8Rewritten |    100 |  2,223.2 ns |   297.44 ns |   872.34 ns |  1,700.0 ns |     - |     - |     - |         - |
|                  ArrayToArray |    200 |  2,375.8 ns |   348.71 ns | 1,022.71 ns |  1,700.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |    200 |  1,676.9 ns |   376.40 ns | 1,055.47 ns |  1,000.0 ns |     - |     - |     - |         - |
|                  RangeToArray |    200 |  3,021.7 ns |   719.96 ns |   910.52 ns |  2,600.0 ns |     - |     - |     - |         - |
|         RangeToArrayRewritten |    200 |  1,719.4 ns |   318.39 ns |   928.77 ns |  1,250.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |    200 |  2,613.9 ns |    55.69 ns |    93.05 ns |  2,600.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy2Rewritten |    200 |  2,304.4 ns |   145.66 ns |   277.12 ns |  2,200.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy4Rewritten |    200 |  3,031.6 ns |   353.52 ns | 1,031.22 ns |  2,750.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy8Rewritten |    200 |  3,051.0 ns |   360.50 ns | 1,051.58 ns |  2,500.0 ns |     - |     - |     - |         - |
|                  ArrayToArray |    500 |  3,164.6 ns |   467.42 ns | 1,370.86 ns |  3,100.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |    500 |  2,637.4 ns |   510.54 ns | 1,497.32 ns |  2,700.0 ns |     - |     - |     - |         - |
|                  RangeToArray |    500 |  4,053.3 ns |    79.46 ns |    74.32 ns |  4,100.0 ns |     - |     - |     - |         - |
|         RangeToArrayRewritten |    500 |  2,432.0 ns |   400.01 ns | 1,160.51 ns |  2,500.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |    500 |  5,912.2 ns |   468.42 ns | 1,366.41 ns |  5,900.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy2Rewritten |    500 |  5,241.1 ns |   450.27 ns | 1,291.91 ns |  5,200.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy4Rewritten |    500 |  3,480.0 ns |   108.42 ns |   101.42 ns |  3,500.0 ns |     - |     - |     - |         - |
| EnumerableToArrayBy8Rewritten |    500 |  5,027.0 ns |   441.51 ns | 1,301.81 ns |  5,000.0 ns |     - |     - |     - |         - |
|                  ArrayToArray |   1000 |  2,361.2 ns |   314.41 ns |   917.15 ns |  1,800.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |   1000 |  1,706.2 ns |   317.19 ns |   920.24 ns |  1,100.0 ns |     - |     - |     - |         - |
|                  RangeToArray |   1000 |  9,762.1 ns |   514.35 ns | 1,475.77 ns |  9,800.0 ns |     - |     - |     - |   16384 B |
|         RangeToArrayRewritten |   1000 |  1,938.0 ns |   322.75 ns |   951.64 ns |  1,300.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |   1000 |  9,826.4 ns |   664.12 ns | 1,818.03 ns |  9,900.0 ns |     - |     - |     - |   16384 B |
| EnumerableToArrayBy2Rewritten |   1000 |  8,809.1 ns |   489.92 ns | 1,389.81 ns |  8,950.0 ns |     - |     - |     - |   16384 B |
| EnumerableToArrayBy4Rewritten |   1000 |  8,685.1 ns |   550.15 ns | 1,569.60 ns |  8,900.0 ns |     - |     - |     - |   16408 B |
| EnumerableToArrayBy8Rewritten |   1000 |  6,273.3 ns |   102.75 ns |    96.12 ns |  6,300.0 ns |     - |     - |     - |   24600 B |
|                  ArrayToArray |   2000 |  2,388.2 ns |   324.41 ns |   920.28 ns |  1,800.0 ns |     - |     - |     - |         - |
|         ArrayToArrayRewritten |   2000 |  1,582.5 ns |   282.53 ns |   819.68 ns |  1,000.0 ns |     - |     - |     - |         - |
|                  RangeToArray |   2000 | 16,746.4 ns |   966.00 ns | 2,595.10 ns | 17,700.0 ns |     - |     - |     - |   24600 B |
|         RangeToArrayRewritten |   2000 |  2,268.0 ns |   304.48 ns |   883.36 ns |  1,600.0 ns |     - |     - |     - |         - |
|             EnumerableToArray |   2000 | 16,461.2 ns |   989.02 ns | 2,673.86 ns | 16,900.0 ns |     - |     - |     - |   24600 B |
| EnumerableToArrayBy2Rewritten |   2000 | 15,328.9 ns |   982.69 ns | 2,850.95 ns | 16,100.0 ns |     - |     - |     - |   24600 B |
| EnumerableToArrayBy4Rewritten |   2000 | 15,087.2 ns | 1,143.81 ns | 3,111.83 ns | 15,700.0 ns |     - |     - |     - |   24600 B |
| EnumerableToArrayBy8Rewritten |   2000 | 10,921.4 ns |   100.69 ns |    89.26 ns | 10,900.0 ns |     - |     - |     - |   32792 B |