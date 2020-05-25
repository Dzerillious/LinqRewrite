|                                         Method |        Job |       Runtime |    Toolchain |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------------- |----------- |-------------- |------------- |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                       SkipTakeToArrayUnchecked | Job-JWYGLI |      .NET 4.8 |        net48 |    65.786 ns |  0.5299 ns |  0.4957 ns |  1.27 |    0.01 | 0.0497 |     - |     - |     209 B |
|                       SkipTakeToArrayUnchecked | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    51.603 ns |  0.2558 ns |  0.2393 ns |  1.00 |    0.00 | 0.0249 |     - |     - |     104 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|              SkipTakeToArrayUncheckedRewritten | Job-JWYGLI |      .NET 4.8 |        net48 |     2.395 ns |  0.0107 ns |  0.0089 ns |  1.09 |    0.01 | 0.0057 |     - |     - |      24 B |
|              SkipTakeToArrayUncheckedRewritten | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |     2.207 ns |  0.0195 ns |  0.0163 ns |  1.00 |    0.00 | 0.0057 |     - |     - |      24 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                                SkipTakeToArray | Job-JWYGLI |      .NET 4.8 |        net48 |    65.843 ns |  0.2603 ns |  0.2435 ns |  1.28 |    0.01 | 0.0497 |     - |     - |     209 B |
|                                SkipTakeToArray | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    51.341 ns |  0.2420 ns |  0.2264 ns |  1.00 |    0.00 | 0.0249 |     - |     - |     104 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                       SkipTakeToArrayRewritten | Job-JWYGLI |      .NET 4.8 |        net48 |     4.088 ns |  0.0382 ns |  0.0357 ns |  0.99 |    0.01 | 0.0057 |     - |     - |      24 B |
|                       SkipTakeToArrayRewritten | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |     4.145 ns |  0.0339 ns |  0.0283 ns |  1.00 |    0.00 | 0.0057 |     - |     - |      24 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                      SkipTakeToArrayUnchecked1 | Job-JWYGLI |      .NET 4.8 |        net48 |    91.224 ns |  0.4093 ns |  0.3418 ns |  1.46 |    0.01 | 0.0459 |     - |     - |     193 B |
|                      SkipTakeToArrayUnchecked1 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    62.604 ns |  0.2032 ns |  0.1586 ns |  1.00 |    0.00 | 0.0324 |     - |     - |     136 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|             SkipTakeToArrayUncheckedRewritten1 | Job-JWYGLI |      .NET 4.8 |        net48 |     2.614 ns |  0.0180 ns |  0.0160 ns |  0.89 |    0.01 | 0.0077 |     - |     - |      32 B |
|             SkipTakeToArrayUncheckedRewritten1 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |     2.955 ns |  0.0380 ns |  0.0355 ns |  1.00 |    0.00 | 0.0077 |     - |     - |      32 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                               SkipTakeToArray1 | Job-JWYGLI |      .NET 4.8 |        net48 | 4,146.790 ns | 15.7832 ns | 12.3224 ns | 50.71 |    0.28 | 0.0610 |     - |     - |     257 B |
|                               SkipTakeToArray1 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    81.730 ns |  0.4906 ns |  0.4349 ns |  1.00 |    0.00 | 0.0459 |     - |     - |     192 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                      SkipTakeToArrayRewritten1 | Job-JWYGLI |      .NET 4.8 |        net48 |     4.223 ns |  0.0171 ns |  0.0151 ns |  0.91 |    0.01 | 0.0077 |     - |     - |      32 B |
|                      SkipTakeToArrayRewritten1 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |     4.631 ns |  0.0566 ns |  0.0501 ns |  1.00 |    0.00 | 0.0077 |     - |     - |      32 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                     SkipTakeToArrayUnchecked10 | Job-JWYGLI |      .NET 4.8 |        net48 | 2,560.503 ns |  8.9378 ns |  7.9231 ns | 31.29 |    0.16 | 0.0954 |     - |     - |     409 B |
|                     SkipTakeToArrayUnchecked10 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    81.856 ns |  0.3330 ns |  0.2600 ns |  1.00 |    0.00 | 0.0381 |     - |     - |     160 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|            SkipTakeToArrayUncheckedRewritten10 | Job-JWYGLI |      .NET 4.8 |        net48 |     6.440 ns |  0.0332 ns |  0.0277 ns |  0.86 |    0.01 | 0.0153 |     - |     - |      64 B |
|            SkipTakeToArrayUncheckedRewritten10 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |     7.497 ns |  0.0765 ns |  0.0597 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                              SkipTakeToArray10 | Job-JWYGLI |      .NET 4.8 |        net48 | 2,559.896 ns |  3.8136 ns |  3.1845 ns | 30.24 |    0.36 | 0.0954 |     - |     - |     409 B |
|                              SkipTakeToArray10 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    84.553 ns |  0.9987 ns |  0.9342 ns |  1.00 |    0.00 | 0.0381 |     - |     - |     160 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                     SkipTakeToArrayRewritten10 | Job-JWYGLI |      .NET 4.8 |        net48 |    13.510 ns |  0.0355 ns |  0.0332 ns |  0.93 |    0.01 | 0.0153 |     - |     - |      64 B |
|                     SkipTakeToArrayRewritten10 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    14.506 ns |  0.1105 ns |  0.0863 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                     SkipTakeToArrayUnchecked20 | Job-JWYGLI |      .NET 4.8 |        net48 | 2,771.839 ns | 31.1655 ns | 29.1522 ns | 22.92 |    0.24 | 0.1411 |     - |     - |     602 B |
|                     SkipTakeToArrayUnchecked20 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |   121.007 ns |  0.5577 ns |  0.4657 ns |  1.00 |    0.00 | 0.0477 |     - |     - |     200 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|            SkipTakeToArrayUncheckedRewritten20 | Job-JWYGLI |      .NET 4.8 |        net48 |     9.725 ns |  0.0355 ns |  0.0332 ns |  0.86 |    0.01 | 0.0249 |     - |     - |     104 B |
|            SkipTakeToArrayUncheckedRewritten20 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    11.306 ns |  0.0971 ns |  0.0908 ns |  1.00 |    0.00 | 0.0249 |     - |     - |     104 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                              SkipTakeToArray20 | Job-JWYGLI |      .NET 4.8 |        net48 | 4,585.068 ns | 27.7212 ns | 25.9304 ns | 27.46 |    0.18 | 0.1450 |     - |     - |     626 B |
|                              SkipTakeToArray20 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |   166.990 ns |  0.5431 ns |  0.5080 ns |  1.00 |    0.00 | 0.0629 |     - |     - |     264 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                     SkipTakeToArrayRewritten20 | Job-JWYGLI |      .NET 4.8 |        net48 |    18.192 ns |  0.0723 ns |  0.0604 ns |  0.96 |    0.02 | 0.0249 |     - |     - |     104 B |
|                     SkipTakeToArrayRewritten20 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    18.940 ns |  0.2808 ns |  0.2627 ns |  1.00 |    0.00 | 0.0249 |     - |     - |     104 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                    SkipTakeToArrayUnchecked100 | Job-JWYGLI |      .NET 4.8 |        net48 | 5,941.519 ns | 41.7958 ns | 34.9014 ns | 12.47 |    0.07 | 0.4196 |     - |     - |    1765 B |
|                    SkipTakeToArrayUnchecked100 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |   476.052 ns |  2.0726 ns |  1.9387 ns |  1.00 |    0.00 | 0.1392 |     - |     - |     584 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|           SkipTakeToArrayUncheckedRewritten100 | Job-JWYGLI |      .NET 4.8 |        net48 |    95.269 ns |  0.3069 ns |  0.2870 ns |  1.00 |    0.01 | 0.1013 |     - |     - |     425 B |
|           SkipTakeToArrayUncheckedRewritten100 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    95.689 ns |  0.6753 ns |  0.5987 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     424 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                             SkipTakeToArray100 | Job-JWYGLI |      .NET 4.8 |        net48 | 4,108.442 ns | 18.3245 ns | 16.2442 ns | 12.42 |    0.05 | 0.4120 |     - |     - |    1741 B |
|                             SkipTakeToArray100 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |   330.696 ns |  0.5857 ns |  0.4891 ns |  1.00 |    0.00 | 0.1240 |     - |     - |     520 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                    SkipTakeToArrayRewritten100 | Job-JWYGLI |      .NET 4.8 |        net48 |    96.270 ns |  0.2245 ns |  0.2100 ns |  1.01 |    0.01 | 0.1013 |     - |     - |     425 B |
|                    SkipTakeToArrayRewritten100 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    95.135 ns |  0.6482 ns |  0.5747 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     424 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|             EnumerableSkipTakeToArrayUnchecked | Job-JWYGLI |      .NET 4.8 |        net48 |    66.424 ns |  0.0936 ns |  0.0781 ns |  1.63 |    0.01 | 0.0516 |     - |     - |     217 B |
|             EnumerableSkipTakeToArrayUnchecked | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    40.756 ns |  0.1327 ns |  0.1177 ns |  1.00 |    0.00 | 0.0268 |     - |     - |     112 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|    EnumerableSkipTakeToArrayUncheckedRewritten | Job-JWYGLI |      .NET 4.8 |        net48 | 2,956.973 ns |  8.6260 ns |  7.6467 ns |  1.29 |    0.01 | 0.0267 |     - |     - |     112 B |
|    EnumerableSkipTakeToArrayUncheckedRewritten | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,291.583 ns | 14.6680 ns | 12.2484 ns |  1.00 |    0.00 | 0.0267 |     - |     - |     112 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                      EnumerableSkipTakeToArray | Job-JWYGLI |      .NET 4.8 |        net48 |    65.687 ns |  0.1503 ns |  0.1255 ns |  1.66 |    0.01 | 0.0516 |     - |     - |     217 B |
|                      EnumerableSkipTakeToArray | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    39.632 ns |  0.1669 ns |  0.1561 ns |  1.00 |    0.00 | 0.0268 |     - |     - |     112 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|             EnumerableSkipTakeToArrayRewritten | Job-JWYGLI |      .NET 4.8 |        net48 | 2,955.543 ns |  6.5974 ns |  6.1712 ns |  1.08 |    0.00 | 0.0267 |     - |     - |     112 B |
|             EnumerableSkipTakeToArrayRewritten | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,725.975 ns |  7.0114 ns |  6.5585 ns |  1.00 |    0.00 | 0.0267 |     - |     - |     112 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|            EnumerableSkipTakeToArrayUnchecked1 | Job-JWYGLI |      .NET 4.8 |        net48 |    66.658 ns |  0.1489 ns |  0.1320 ns |  1.60 |    0.01 | 0.0516 |     - |     - |     217 B |
|            EnumerableSkipTakeToArrayUnchecked1 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 |    41.728 ns |  0.1215 ns |  0.1015 ns |  1.00 |    0.00 | 0.0268 |     - |     - |     112 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|   EnumerableSkipTakeToArrayUncheckedRewritten1 | Job-JWYGLI |      .NET 4.8 |        net48 | 2,962.657 ns |  6.1532 ns |  5.1382 ns |  1.29 |    0.01 | 0.0267 |     - |     - |     120 B |
|   EnumerableSkipTakeToArrayUncheckedRewritten1 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,301.809 ns | 10.0455 ns |  8.9050 ns |  1.00 |    0.00 | 0.0267 |     - |     - |     120 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                     EnumerableSkipTakeToArray1 | Job-JWYGLI |      .NET 4.8 |        net48 | 7,637.359 ns | 31.0358 ns | 27.5124 ns |  1.18 |    0.01 | 0.0610 |     - |     - |     297 B |
|                     EnumerableSkipTakeToArray1 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 6,483.599 ns | 28.4334 ns | 25.2054 ns |  1.00 |    0.00 | 0.0534 |     - |     - |     232 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|            EnumerableSkipTakeToArrayRewritten1 | Job-JWYGLI |      .NET 4.8 |        net48 | 2,965.313 ns |  7.0047 ns |  6.5522 ns |  1.08 |    0.00 | 0.0267 |     - |     - |     120 B |
|            EnumerableSkipTakeToArrayRewritten1 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,738.850 ns |  9.2074 ns |  7.6886 ns |  1.00 |    0.00 | 0.0267 |     - |     - |     120 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|           EnumerableSkipTakeToArrayUnchecked10 | Job-JWYGLI |      .NET 4.8 |        net48 | 2,947.095 ns | 15.3127 ns | 13.5743 ns |  1.28 |    0.01 | 0.0954 |     - |     - |     409 B |
|           EnumerableSkipTakeToArrayUnchecked10 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,294.967 ns | 14.2145 ns | 11.8697 ns |  1.00 |    0.00 | 0.0839 |     - |     - |     360 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|  EnumerableSkipTakeToArrayUncheckedRewritten10 | Job-JWYGLI |      .NET 4.8 |        net48 | 3,036.166 ns |  7.8026 ns |  7.2986 ns |  1.17 |    0.00 | 0.0725 |     - |     - |     305 B |
|  EnumerableSkipTakeToArrayUncheckedRewritten10 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,593.415 ns |  9.1447 ns |  7.1396 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     304 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                    EnumerableSkipTakeToArray10 | Job-JWYGLI |      .NET 4.8 |        net48 | 2,916.266 ns | 16.2500 ns | 14.4052 ns |  1.18 |    0.01 | 0.0954 |     - |     - |     409 B |
|                    EnumerableSkipTakeToArray10 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,463.675 ns | 10.2832 ns |  8.0284 ns |  1.00 |    0.00 | 0.0839 |     - |     - |     360 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|           EnumerableSkipTakeToArrayRewritten10 | Job-JWYGLI |      .NET 4.8 |        net48 | 3,038.321 ns | 11.0460 ns | 10.3324 ns |  1.08 |    0.00 | 0.0725 |     - |     - |     305 B |
|           EnumerableSkipTakeToArrayRewritten10 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,811.504 ns |  5.9885 ns |  5.3086 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     304 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|           EnumerableSkipTakeToArrayUnchecked20 | Job-JWYGLI |      .NET 4.8 |        net48 | 3,089.158 ns | 16.9426 ns | 15.0192 ns |  1.30 |    0.02 | 0.1411 |     - |     - |     602 B |
|           EnumerableSkipTakeToArrayUnchecked20 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,385.606 ns | 30.0758 ns | 26.6614 ns |  1.00 |    0.00 | 0.1183 |     - |     - |     496 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|  EnumerableSkipTakeToArrayUncheckedRewritten20 | Job-JWYGLI |      .NET 4.8 |        net48 | 3,094.536 ns |  8.5215 ns |  7.1158 ns |  1.28 |    0.00 | 0.0801 |     - |     - |     345 B |
|  EnumerableSkipTakeToArrayUncheckedRewritten20 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,417.386 ns |  6.8622 ns |  5.7303 ns |  1.00 |    0.00 | 0.0801 |     - |     - |     344 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                    EnumerableSkipTakeToArray20 | Job-JWYGLI |      .NET 4.8 |        net48 | 8,145.385 ns | 17.8721 ns | 14.9240 ns |  1.11 |    0.00 | 0.1526 |     - |     - |     666 B |
|                    EnumerableSkipTakeToArray20 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 7,316.249 ns | 24.2114 ns | 18.9027 ns |  1.00 |    0.00 | 0.1297 |     - |     - |     552 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|           EnumerableSkipTakeToArrayRewritten20 | Job-JWYGLI |      .NET 4.8 |        net48 | 3,327.823 ns |  7.0393 ns |  5.4958 ns |  1.36 |    0.00 | 0.0801 |     - |     - |     345 B |
|           EnumerableSkipTakeToArrayRewritten20 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,444.345 ns | 10.3438 ns |  8.6375 ns |  1.00 |    0.00 | 0.0801 |     - |     - |     344 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|          EnumerableSkipTakeToArrayUnchecked100 | Job-JWYGLI |      .NET 4.8 |        net48 | 9,888.833 ns | 34.1887 ns | 28.5491 ns |  1.10 |    0.00 | 0.4272 |     - |     - |    1805 B |
|          EnumerableSkipTakeToArrayUnchecked100 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 8,983.216 ns | 17.4817 ns | 13.6485 ns |  1.00 |    0.00 | 0.2899 |     - |     - |    1240 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
| EnumerableSkipTakeToArrayUncheckedRewritten100 | Job-JWYGLI |      .NET 4.8 |        net48 | 3,563.215 ns |  6.3663 ns |  5.3162 ns |  1.14 |    0.01 | 0.2861 |     - |     - |    1204 B |
| EnumerableSkipTakeToArrayUncheckedRewritten100 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 3,116.028 ns | 38.2709 ns | 35.7987 ns |  1.00 |    0.00 | 0.2861 |     - |     - |    1200 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|                   EnumerableSkipTakeToArray100 | Job-JWYGLI |      .NET 4.8 |        net48 | 4,364.883 ns | 16.3396 ns | 14.4847 ns |  1.55 |    0.01 | 0.4120 |     - |     - |    1741 B |
|                   EnumerableSkipTakeToArray100 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,817.159 ns | 21.2583 ns | 19.8850 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1184 B |
|                                                |            |               |              |              |            |            |       |         |        |       |       |           |
|          EnumerableSkipTakeToArrayRewritten100 | Job-JWYGLI |      .NET 4.8 |        net48 | 3,561.969 ns |  6.4535 ns |  5.7208 ns |  1.22 |    0.02 | 0.2861 |     - |     - |    1204 B |
|          EnumerableSkipTakeToArrayRewritten100 | Job-MSSUNR | .NET Core 3.1 | netcoreapp31 | 2,909.865 ns | 45.5429 ns | 42.6008 ns |  1.00 |    0.00 | 0.2861 |     - |     - |    1200 B |
