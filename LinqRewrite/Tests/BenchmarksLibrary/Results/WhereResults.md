|                          Method |        Job |       Runtime |    Toolchain | Offset |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------- |----------- |-------------- |------------- |------- |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |     -1 | 2,109.8 ns |  14.66 ns |  13.71 ns |  1.03 |    0.01 | 0.0305 |     - |     - |     136 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     -1 | 2,057.8 ns |  19.10 ns |  17.86 ns |  1.00 |    0.00 | 0.0267 |     - |     - |     112 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |     -1 |   777.2 ns |   2.28 ns |   2.14 ns |  1.45 |    0.00 | 0.0191 |     - |     - |      80 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     -1 |   535.2 ns |   1.45 ns |   1.29 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      80 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |     -1 | 2,080.1 ns |   5.20 ns |   4.34 ns |  1.33 |    0.01 | 0.0458 |     - |     - |     201 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     -1 | 1,567.3 ns |  10.04 ns |   8.90 ns |  1.00 |    0.00 | 0.0477 |     - |     - |     200 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |     -1 |   542.1 ns |  10.74 ns |  11.03 ns |  1.04 |    0.02 | 0.0210 |     - |     - |      88 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     -1 |   522.3 ns |   0.64 ns |   0.53 ns |  1.00 |    0.00 | 0.0210 |     - |     - |      88 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |      0 | 2,089.5 ns |   4.52 ns |   4.00 ns |  1.02 |    0.01 | 0.0305 |     - |     - |     136 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      0 | 2,051.8 ns |  12.00 ns |  11.23 ns |  1.00 |    0.00 | 0.0267 |     - |     - |     112 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |      0 |   775.8 ns |   1.84 ns |   1.72 ns |  1.45 |    0.01 | 0.0191 |     - |     - |      80 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      0 |   535.5 ns |   1.83 ns |   1.71 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      80 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |      0 | 2,073.7 ns |   6.40 ns |   5.34 ns |  1.32 |    0.02 | 0.0458 |     - |     - |     201 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      0 | 1,572.5 ns |  21.32 ns |  17.80 ns |  1.00 |    0.00 | 0.0477 |     - |     - |     200 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |      0 |   528.7 ns |   0.78 ns |   0.65 ns |  1.01 |    0.00 | 0.0210 |     - |     - |      88 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      0 |   522.4 ns |   0.80 ns |   0.67 ns |  1.00 |    0.00 | 0.0210 |     - |     - |      88 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |      1 | 2,108.3 ns |   7.13 ns |   5.95 ns |  0.95 |    0.01 | 0.0420 |     - |     - |     185 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      1 | 2,214.6 ns |  22.04 ns |  18.41 ns |  1.00 |    0.00 | 0.0420 |     - |     - |     184 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |      1 |   780.9 ns |   1.32 ns |   1.10 ns |  1.45 |    0.01 | 0.0210 |     - |     - |      88 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      1 |   540.3 ns |   2.13 ns |   1.99 ns |  1.00 |    0.00 | 0.0210 |     - |     - |      88 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |      1 | 2,081.6 ns |   7.43 ns |   6.95 ns |  1.33 |    0.01 | 0.0458 |     - |     - |     201 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      1 | 1,570.8 ns |  13.52 ns |  11.29 ns |  1.00 |    0.00 | 0.0477 |     - |     - |     200 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |      1 |   532.3 ns |   1.57 ns |   1.39 ns |  0.70 |    0.00 | 0.0210 |     - |     - |      88 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      1 |   765.4 ns |   1.70 ns |   1.51 ns |  1.00 |    0.00 | 0.0210 |     - |     - |      88 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |      2 | 2,108.0 ns |   7.55 ns |   7.06 ns |  0.93 |    0.01 | 0.0420 |     - |     - |     185 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      2 | 2,261.0 ns |  27.43 ns |  22.90 ns |  1.00 |    0.00 | 0.0420 |     - |     - |     184 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |      2 |   781.9 ns |   2.33 ns |   2.18 ns |  1.44 |    0.01 | 0.0210 |     - |     - |      88 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      2 |   543.4 ns |   2.79 ns |   2.47 ns |  1.00 |    0.00 | 0.0210 |     - |     - |      88 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |      2 | 2,079.9 ns |  11.09 ns |   9.26 ns |  1.30 |    0.02 | 0.0458 |     - |     - |     201 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      2 | 1,596.3 ns |  25.23 ns |  23.60 ns |  1.00 |    0.00 | 0.0477 |     - |     - |     200 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |      2 |   532.4 ns |   2.28 ns |   2.13 ns |  1.01 |    0.01 | 0.0210 |     - |     - |      88 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      2 |   526.3 ns |   3.51 ns |   3.28 ns |  1.00 |    0.00 | 0.0210 |     - |     - |      88 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |      5 | 2,137.3 ns |  11.11 ns |   8.68 ns |  0.94 |    0.01 | 0.0610 |     - |     - |     257 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      5 | 2,277.4 ns |  33.77 ns |  29.94 ns |  1.00 |    0.00 | 0.0610 |     - |     - |     256 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |      5 |   785.2 ns |   2.16 ns |   2.02 ns |  1.44 |    0.01 | 0.0248 |     - |     - |     104 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      5 |   545.9 ns |   3.58 ns |   3.18 ns |  1.00 |    0.00 | 0.0248 |     - |     - |     104 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |      5 | 2,093.9 ns |   5.90 ns |   5.23 ns |  1.32 |    0.01 | 0.0458 |     - |     - |     201 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      5 | 1,590.2 ns |  12.79 ns |  10.68 ns |  1.00 |    0.00 | 0.0477 |     - |     - |     200 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |      5 |   534.2 ns |   3.01 ns |   2.81 ns |  1.01 |    0.01 | 0.0210 |     - |     - |      88 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |      5 |   527.7 ns |   1.73 ns |   1.61 ns |  1.00 |    0.00 | 0.0210 |     - |     - |      88 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |     10 | 2,179.8 ns |   8.33 ns |   7.79 ns |  0.95 |    0.01 | 0.0839 |     - |     - |     361 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     10 | 2,304.6 ns |  23.24 ns |  21.74 ns |  1.00 |    0.00 | 0.0763 |     - |     - |     328 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |     10 |   814.0 ns |   1.56 ns |   1.46 ns |  1.41 |    0.00 | 0.0935 |     - |     - |     393 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     10 |   576.5 ns |   1.79 ns |   1.59 ns |  1.00 |    0.00 | 0.0935 |     - |     - |     392 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |     10 | 2,138.6 ns |   6.25 ns |   5.22 ns |  1.31 |    0.01 | 0.0839 |     - |     - |     353 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     10 | 1,634.9 ns |  11.08 ns |   9.25 ns |  1.00 |    0.00 | 0.0839 |     - |     - |     352 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |     10 |   556.2 ns |   2.55 ns |   2.26 ns |  0.70 |    0.00 | 0.0858 |     - |     - |     361 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     10 |   792.2 ns |   1.94 ns |   1.82 ns |  1.00 |    0.00 | 0.0858 |     - |     - |     360 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |     20 | 2,238.3 ns |   6.29 ns |   5.57 ns |  0.97 |    0.01 | 0.1297 |     - |     - |     554 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     20 | 2,305.2 ns |  11.94 ns |   9.97 ns |  1.00 |    0.00 | 0.1221 |     - |     - |     512 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |     20 |   824.5 ns |   2.14 ns |   2.01 ns |  1.39 |    0.01 | 0.1030 |     - |     - |     433 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     20 |   591.9 ns |   2.95 ns |   2.76 ns |  1.00 |    0.00 | 0.1030 |     - |     - |     432 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |     20 | 2,191.5 ns |   7.86 ns |   7.35 ns |  1.28 |    0.02 | 0.0839 |     - |     - |     353 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     20 | 1,708.1 ns |  28.87 ns |  27.00 ns |  1.00 |    0.00 | 0.0839 |     - |     - |     352 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |     20 |   559.8 ns |   1.03 ns |   0.91 ns |  0.70 |    0.00 | 0.0858 |     - |     - |     361 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     20 |   797.6 ns |   2.37 ns |   2.21 ns |  1.00 |    0.00 | 0.0858 |     - |     - |     360 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |     50 | 2,432.9 ns |  10.02 ns |   8.88 ns |  1.21 |    0.01 | 0.2251 |     - |     - |     955 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     50 | 2,008.1 ns |   9.66 ns |   9.04 ns |  1.00 |    0.00 | 0.1869 |     - |     - |     784 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |     50 |   864.5 ns |   1.89 ns |   1.77 ns |  1.35 |    0.00 | 0.1316 |     - |     - |     554 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     50 |   641.8 ns |   1.67 ns |   1.48 ns |  1.00 |    0.00 | 0.1316 |     - |     - |     552 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |     50 | 2,391.8 ns |  11.00 ns |  10.29 ns |  1.26 |    0.01 | 0.2098 |     - |     - |     891 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     50 | 1,896.4 ns |   5.56 ns |   5.20 ns |  1.00 |    0.00 | 0.2117 |     - |     - |     888 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |     50 |   576.5 ns |   2.05 ns |   1.91 ns |  0.71 |    0.00 | 0.0858 |     - |     - |     361 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |     50 |   812.0 ns |   2.47 ns |   2.31 ns |  1.00 |    0.00 | 0.0858 |     - |     - |     360 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |    100 | 2,695.4 ns |  12.60 ns |  11.79 ns |  1.28 |    0.01 | 0.4005 |     - |     - |    1693 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    100 | 2,101.7 ns |  10.10 ns |   8.96 ns |  1.00 |    0.00 | 0.3014 |     - |     - |    1264 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |    100 |   987.8 ns |   2.53 ns |   2.37 ns |  1.28 |    0.01 | 0.4234 |     - |     - |    1781 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    100 |   774.3 ns |   3.25 ns |   2.88 ns |  1.00 |    0.00 | 0.4244 |     - |     - |    1776 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |    100 | 2,586.2 ns |   9.58 ns |   8.96 ns |  1.13 |    0.00 | 0.2098 |     - |     - |     891 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    100 | 2,296.0 ns |   6.34 ns |   4.95 ns |  1.00 |    0.00 | 0.2098 |     - |     - |     888 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |    100 |   668.6 ns |   1.55 ns |   1.29 ns |  0.99 |    0.00 | 0.3300 |     - |     - |    1388 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    100 |   673.0 ns |   2.27 ns |   1.89 ns |  1.00 |    0.00 | 0.3300 |     - |     - |    1384 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |    200 | 3,174.5 ns |  15.88 ns |  14.86 ns |  1.42 |    0.02 | 0.7477 |     - |     - |    3145 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    200 | 2,235.1 ns |  25.24 ns |  23.61 ns |  1.00 |    0.00 | 0.5226 |     - |     - |    2200 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |    200 | 1,129.7 ns |   2.57 ns |   2.28 ns |  1.22 |    0.00 | 0.5188 |     - |     - |    2182 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    200 |   922.7 ns |   1.99 ns |   1.66 ns |  1.00 |    0.00 | 0.5198 |     - |     - |    2176 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |    200 | 3,088.4 ns |  13.24 ns |  11.73 ns |  1.09 |    0.01 | 0.7057 |     - |     - |    2969 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    200 | 2,836.6 ns |  14.24 ns |  13.32 ns |  1.00 |    0.00 | 0.7057 |     - |     - |    2960 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |    200 |   731.6 ns |   1.74 ns |   1.55 ns |  0.78 |    0.00 | 0.3300 |     - |     - |    1388 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    200 |   939.4 ns |   2.08 ns |   1.95 ns |  1.00 |    0.00 | 0.3300 |     - |     - |    1384 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |    500 | 4,509.3 ns |  30.89 ns |  25.79 ns |  1.72 |    0.01 | 1.5259 |     - |     - |    6428 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    500 | 2,618.9 ns |   7.61 ns |   6.75 ns |  1.00 |    0.00 | 1.0834 |     - |     - |    4536 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |    500 | 1,673.3 ns |   4.45 ns |   3.95 ns |  1.07 |    0.00 | 1.7681 |     - |     - |    7423 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    500 | 1,564.2 ns |   4.81 ns |   4.26 ns |  1.00 |    0.00 | 1.7681 |     - |     - |    7400 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |    500 | 4,291.8 ns |  20.61 ns |  18.27 ns |  1.06 |    0.01 | 0.7019 |     - |     - |    2969 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    500 | 4,068.3 ns |  28.07 ns |  21.92 ns |  1.00 |    0.00 | 0.7019 |     - |     - |    2960 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |    500 | 1,069.6 ns |   2.58 ns |   2.28 ns |  0.88 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |    500 | 1,213.9 ns |   4.05 ns |   3.79 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5408 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |   1000 | 6,771.7 ns |  37.78 ns |  33.49 ns |  2.22 |    0.03 | 2.9907 |     - |     - |   12570 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |   1000 | 3,049.9 ns |  40.44 ns |  37.82 ns |  1.00 |    0.00 | 2.0332 |     - |     - |    8512 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |   1000 | 2,098.8 ns |   5.73 ns |   5.36 ns |  0.99 |    0.00 | 1.2817 |     - |     - |    5393 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |   1000 | 2,118.3 ns |   8.24 ns |   7.71 ns |  1.00 |    0.00 | 1.2817 |     - |     - |    5376 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |   1000 | 6,622.2 ns |  25.34 ns |  22.47 ns |  1.02 |    0.02 | 2.6703 |     - |     - |   11219 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |   1000 | 6,475.5 ns | 117.04 ns | 109.48 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11176 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |   1000 | 1,310.9 ns |   2.65 ns |   2.35 ns |  0.97 |    0.01 | 1.2913 |     - |     - |    5424 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |   1000 | 1,347.1 ns |  12.64 ns |  11.83 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5408 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|               ArrayWhereToArray | Job-UNRSHU |      .NET 4.8 |        net48 |   2000 | 6,756.1 ns |  49.25 ns |  43.66 ns |  2.40 |    0.02 | 2.9907 |     - |     - |   12570 B |
|               ArrayWhereToArray | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |   2000 | 2,816.5 ns |  15.48 ns |  13.72 ns |  1.00 |    0.00 | 2.0332 |     - |     - |    8512 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|      ArrayWhereToArrayRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |   2000 | 2,102.1 ns |   7.43 ns |   6.59 ns |  0.99 |    0.00 | 1.2817 |     - |     - |    5393 B |
|      ArrayWhereToArrayRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |   2000 | 2,133.0 ns |   9.44 ns |   8.36 ns |  1.00 |    0.00 | 1.2817 |     - |     - |    5376 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
|          ArrayWhereToSimpleList | Job-UNRSHU |      .NET 4.8 |        net48 |   2000 | 6,623.5 ns |  22.87 ns |  21.40 ns |  0.99 |    0.01 | 2.6703 |     - |     - |   11219 B |
|          ArrayWhereToSimpleList | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |   2000 | 6,699.3 ns |  35.35 ns |  31.33 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11176 B |
|                                 |            |               |              |        |            |           |           |       |         |        |       |       |           |
| ArrayWhereToSimpleListRewritten | Job-UNRSHU |      .NET 4.8 |        net48 |   2000 | 1,316.0 ns |   4.07 ns |   3.61 ns |  0.98 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArrayWhereToSimpleListRewritten | Job-ULSTQK | .NET Core 3.1 | netcoreapp31 |   2000 | 1,337.9 ns |   3.94 ns |   3.49 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5408 B |