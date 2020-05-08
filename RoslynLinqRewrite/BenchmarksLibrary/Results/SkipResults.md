|                                     Method |        Job |       Runtime |    Toolchain |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------------- |----------- |-------------- |------------- |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                       SkipToArrayUnchecked | Job-CLADVR |      .NET 4.8 |        net48 |  6,253.58 ns | 22.433 ns | 20.984 ns |  1.00 |    0.00 | 0.4044 |     - |     - |    1701 B |
|                       SkipToArrayUnchecked | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |    519.36 ns |  2.937 ns |  2.452 ns |  0.08 |    0.00 | 0.1259 |     - |     - |     528 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|              SkipToArrayUncheckedRewritten | Job-CLADVR |      .NET 4.8 |        net48 |     93.33 ns |  0.336 ns |  0.298 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     425 B |
|              SkipToArrayUncheckedRewritten | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |     93.93 ns |  0.894 ns |  0.836 ns |  1.01 |    0.01 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                                SkipToArray | Job-CLADVR |      .NET 4.8 |        net48 |  6,278.27 ns | 35.521 ns | 31.489 ns |  1.00 |    0.00 | 0.4044 |     - |     - |    1701 B |
|                                SkipToArray | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |    515.22 ns |  2.426 ns |  2.150 ns |  0.08 |    0.00 | 0.1259 |     - |     - |     528 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                       SkipToArrayRewritten | Job-CLADVR |      .NET 4.8 |        net48 |     93.58 ns |  0.387 ns |  0.343 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     425 B |
|                       SkipToArrayRewritten | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |     94.27 ns |  1.565 ns |  1.464 ns |  1.01 |    0.01 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                      SkipToArrayUnchecked1 | Job-CLADVR |      .NET 4.8 |        net48 |  8,142.36 ns | 23.259 ns | 20.619 ns |  1.00 |    0.00 | 2.9755 |     - |     - |   12514 B |
|                      SkipToArrayUnchecked1 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  1,982.15 ns | 13.541 ns | 12.666 ns |  0.24 |    0.00 | 0.9727 |     - |     - |    4072 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|             SkipToArrayUncheckedRewritten1 | Job-CLADVR |      .NET 4.8 |        net48 |     93.74 ns |  0.446 ns |  0.395 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     425 B |
|             SkipToArrayUncheckedRewritten1 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |     93.45 ns |  0.575 ns |  0.538 ns |  1.00 |    0.01 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                               SkipToArray1 | Job-CLADVR |      .NET 4.8 |        net48 |  6,334.44 ns | 26.083 ns | 21.780 ns |  1.00 |    0.00 | 0.4044 |     - |     - |    1701 B |
|                               SkipToArray1 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |    589.27 ns |  3.165 ns |  2.805 ns |  0.09 |    0.00 | 0.1259 |     - |     - |     528 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                      SkipToArrayRewritten1 | Job-CLADVR |      .NET 4.8 |        net48 |     93.39 ns |  0.208 ns |  0.195 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     425 B |
|                      SkipToArrayRewritten1 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |     93.61 ns |  0.853 ns |  0.798 ns |  1.00 |    0.01 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                     SkipToArrayUnchecked10 | Job-CLADVR |      .NET 4.8 |        net48 |  4,047.31 ns | 22.999 ns | 19.206 ns |  1.00 |    0.00 | 0.3967 |     - |     - |    1677 B |
|                     SkipToArrayUnchecked10 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |    342.84 ns |  0.847 ns |  0.751 ns |  0.08 |    0.00 | 0.1125 |     - |     - |     472 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|            SkipToArrayUncheckedRewritten10 | Job-CLADVR |      .NET 4.8 |        net48 |     48.08 ns |  0.281 ns |  0.263 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     425 B |
|            SkipToArrayUncheckedRewritten10 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |     46.78 ns |  0.412 ns |  0.365 ns |  0.97 |    0.01 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                              SkipToArray10 | Job-CLADVR |      .NET 4.8 |        net48 |  4,157.73 ns | 16.910 ns | 14.120 ns |  1.00 |    0.00 | 0.3967 |     - |     - |    1677 B |
|                              SkipToArray10 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |    344.86 ns |  3.944 ns |  3.689 ns |  0.08 |    0.00 | 0.1125 |     - |     - |     472 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                     SkipToArrayRewritten10 | Job-CLADVR |      .NET 4.8 |        net48 |     44.37 ns |  0.201 ns |  0.168 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     425 B |
|                     SkipToArrayRewritten10 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |     47.02 ns |  0.578 ns |  0.483 ns |  1.06 |    0.01 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                     SkipToArrayUnchecked20 | Job-CLADVR |      .NET 4.8 |        net48 |  4,042.31 ns | 23.054 ns | 20.437 ns |  1.00 |    0.00 | 0.3967 |     - |     - |    1677 B |
|                     SkipToArrayUnchecked20 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |    342.75 ns |  1.560 ns |  1.459 ns |  0.08 |    0.00 | 0.1125 |     - |     - |     472 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|            SkipToArrayUncheckedRewritten20 | Job-CLADVR |      .NET 4.8 |        net48 |     44.96 ns |  0.188 ns |  0.167 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     425 B |
|            SkipToArrayUncheckedRewritten20 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |     46.59 ns |  0.523 ns |  0.490 ns |  1.04 |    0.01 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                              SkipToArray20 | Job-CLADVR |      .NET 4.8 |        net48 |  6,268.74 ns | 17.184 ns | 14.350 ns |  1.00 |    0.00 | 0.4044 |     - |     - |    1701 B |
|                              SkipToArray20 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |    513.06 ns |  3.286 ns |  2.913 ns |  0.08 |    0.00 | 0.1259 |     - |     - |     528 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                     SkipToArrayRewritten20 | Job-CLADVR |      .NET 4.8 |        net48 |     93.45 ns |  1.163 ns |  1.088 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     425 B |
|                     SkipToArrayRewritten20 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |     93.26 ns |  0.875 ns |  0.731 ns |  1.00 |    0.02 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                    SkipToArrayUnchecked100 | Job-CLADVR |      .NET 4.8 |        net48 |  6,280.45 ns | 27.540 ns | 24.414 ns |  1.00 |    0.00 | 0.4044 |     - |     - |    1701 B |
|                    SkipToArrayUnchecked100 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |    544.94 ns |  4.177 ns |  3.703 ns |  0.09 |    0.00 | 0.1259 |     - |     - |     528 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|           SkipToArrayUncheckedRewritten100 | Job-CLADVR |      .NET 4.8 |        net48 |     92.58 ns |  0.562 ns |  0.525 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     425 B |
|           SkipToArrayUncheckedRewritten100 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |     93.92 ns |  0.790 ns |  0.739 ns |  1.01 |    0.01 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                             SkipToArray100 | Job-CLADVR |      .NET 4.8 |        net48 |  4,046.44 ns | 19.177 ns | 17.000 ns |  1.00 |    0.00 | 0.3967 |     - |     - |    1677 B |
|                             SkipToArray100 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |    345.09 ns |  1.375 ns |  1.286 ns |  0.09 |    0.00 | 0.1125 |     - |     - |     472 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                    SkipToArrayRewritten100 | Job-CLADVR |      .NET 4.8 |        net48 |     93.37 ns |  0.564 ns |  0.527 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     425 B |
|                    SkipToArrayRewritten100 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |     93.54 ns |  1.418 ns |  1.326 ns |  1.00 |    0.01 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|             EnumerableSkipToArrayUnchecked | Job-CLADVR |      .NET 4.8 |        net48 | 10,872.05 ns | 39.569 ns | 37.013 ns |  1.00 |    0.00 | 0.4120 |     - |     - |    1741 B |
|             EnumerableSkipToArrayUnchecked | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  9,893.11 ns | 34.647 ns | 28.932 ns |  0.91 |    0.00 | 0.3052 |     - |     - |    1296 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|    EnumerableSkipToArrayUncheckedRewritten | Job-CLADVR |      .NET 4.8 |        net48 |  4,249.53 ns | 27.188 ns | 25.431 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1204 B |
|    EnumerableSkipToArrayUncheckedRewritten | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,981.27 ns | 18.283 ns | 16.207 ns |  0.94 |    0.00 | 0.2823 |     - |     - |    1200 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                      EnumerableSkipToArray | Job-CLADVR |      .NET 4.8 |        net48 | 10,890.79 ns | 37.932 ns | 35.481 ns |  1.00 |    0.00 | 0.4120 |     - |     - |    1741 B |
|                      EnumerableSkipToArray | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  9,771.58 ns | 54.887 ns | 45.833 ns |  0.90 |    0.01 | 0.3052 |     - |     - |    1296 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|             EnumerableSkipToArrayRewritten | Job-CLADVR |      .NET 4.8 |        net48 |  3,943.92 ns | 20.591 ns | 19.261 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1204 B |
|             EnumerableSkipToArrayRewritten | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,682.67 ns | 13.281 ns | 11.090 ns |  0.93 |    0.00 | 0.2861 |     - |     - |    1200 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|            EnumerableSkipToArrayUnchecked1 | Job-CLADVR |      .NET 4.8 |        net48 | 10,908.97 ns | 66.832 ns | 62.515 ns |  1.00 |    0.00 | 0.4120 |     - |     - |    1741 B |
|            EnumerableSkipToArrayUnchecked1 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  9,412.26 ns | 55.767 ns | 46.568 ns |  0.86 |    0.01 | 0.3052 |     - |     - |    1296 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|   EnumerableSkipToArrayUncheckedRewritten1 | Job-CLADVR |      .NET 4.8 |        net48 |  4,241.56 ns | 17.699 ns | 16.556 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1204 B |
|   EnumerableSkipToArrayUncheckedRewritten1 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,972.09 ns | 21.273 ns | 18.858 ns |  0.94 |    0.01 | 0.2823 |     - |     - |    1200 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                     EnumerableSkipToArray1 | Job-CLADVR |      .NET 4.8 |        net48 | 10,912.38 ns | 52.283 ns | 46.347 ns |  1.00 |    0.00 | 0.4120 |     - |     - |    1741 B |
|                     EnumerableSkipToArray1 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  9,408.14 ns | 31.424 ns | 26.240 ns |  0.86 |    0.00 | 0.3052 |     - |     - |    1296 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|            EnumerableSkipToArrayRewritten1 | Job-CLADVR |      .NET 4.8 |        net48 |  3,958.43 ns | 16.132 ns | 15.090 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1204 B |
|            EnumerableSkipToArrayRewritten1 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,948.85 ns | 52.361 ns | 48.979 ns |  1.00 |    0.01 | 0.2823 |     - |     - |    1200 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|           EnumerableSkipToArrayUnchecked10 | Job-CLADVR |      .NET 4.8 |        net48 |  4,332.39 ns | 23.948 ns | 18.697 ns |  1.00 |    0.00 | 0.3967 |     - |     - |    1677 B |
|           EnumerableSkipToArrayUnchecked10 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,568.27 ns | 15.259 ns | 12.742 ns |  0.82 |    0.00 | 0.2937 |     - |     - |    1240 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|  EnumerableSkipToArrayUncheckedRewritten10 | Job-CLADVR |      .NET 4.8 |        net48 |  4,553.85 ns | 16.872 ns | 14.956 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1204 B |
|  EnumerableSkipToArrayUncheckedRewritten10 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  4,019.05 ns | 45.408 ns | 42.474 ns |  0.88 |    0.01 | 0.2823 |     - |     - |    1200 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                    EnumerableSkipToArray10 | Job-CLADVR |      .NET 4.8 |        net48 |  4,552.07 ns | 14.461 ns | 12.819 ns |  1.00 |    0.00 | 0.3967 |     - |     - |    1677 B |
|                    EnumerableSkipToArray10 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,569.87 ns | 17.374 ns | 14.508 ns |  0.78 |    0.00 | 0.2937 |     - |     - |    1240 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|           EnumerableSkipToArrayRewritten10 | Job-CLADVR |      .NET 4.8 |        net48 |  4,253.20 ns | 17.815 ns | 15.792 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1204 B |
|           EnumerableSkipToArrayRewritten10 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,661.14 ns | 12.711 ns | 11.890 ns |  0.86 |    0.00 | 0.2861 |     - |     - |    1200 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|           EnumerableSkipToArrayUnchecked20 | Job-CLADVR |      .NET 4.8 |        net48 |  4,334.55 ns | 14.772 ns | 13.095 ns |  1.00 |    0.00 | 0.3967 |     - |     - |    1677 B |
|           EnumerableSkipToArrayUnchecked20 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  4,146.66 ns | 21.627 ns | 20.230 ns |  0.96 |    0.01 | 0.2899 |     - |     - |    1240 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|  EnumerableSkipToArrayUncheckedRewritten20 | Job-CLADVR |      .NET 4.8 |        net48 |  4,538.71 ns | 14.355 ns | 13.428 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1204 B |
|  EnumerableSkipToArrayUncheckedRewritten20 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,680.02 ns |  9.531 ns |  8.449 ns |  0.81 |    0.00 | 0.2861 |     - |     - |    1200 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                    EnumerableSkipToArray20 | Job-CLADVR |      .NET 4.8 |        net48 | 10,900.74 ns | 73.950 ns | 69.173 ns |  1.00 |    0.00 | 0.4120 |     - |     - |    1741 B |
|                    EnumerableSkipToArray20 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 | 10,041.66 ns | 33.353 ns | 31.199 ns |  0.92 |    0.01 | 0.3052 |     - |     - |    1296 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|           EnumerableSkipToArrayRewritten20 | Job-CLADVR |      .NET 4.8 |        net48 |  3,955.16 ns | 11.771 ns |  9.829 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1204 B |
|           EnumerableSkipToArrayRewritten20 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,899.20 ns | 14.791 ns | 11.548 ns |  0.99 |    0.00 | 0.2823 |     - |     - |    1200 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|          EnumerableSkipToArrayUnchecked100 | Job-CLADVR |      .NET 4.8 |        net48 | 10,916.87 ns | 54.144 ns | 47.997 ns |  1.00 |    0.00 | 0.4120 |     - |     - |    1741 B |
|          EnumerableSkipToArrayUnchecked100 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 | 10,385.32 ns | 76.283 ns | 71.356 ns |  0.95 |    0.01 | 0.3052 |     - |     - |    1296 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
| EnumerableSkipToArrayUncheckedRewritten100 | Job-CLADVR |      .NET 4.8 |        net48 |  4,245.48 ns | 14.003 ns | 13.098 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1204 B |
| EnumerableSkipToArrayUncheckedRewritten100 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,986.18 ns | 39.723 ns | 35.213 ns |  0.94 |    0.01 | 0.2823 |     - |     - |    1200 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                   EnumerableSkipToArray100 | Job-CLADVR |      .NET 4.8 |        net48 |  4,326.23 ns | 12.623 ns | 11.190 ns |  1.00 |    0.00 | 0.3967 |     - |     - |    1677 B |
|                   EnumerableSkipToArray100 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,578.49 ns | 13.207 ns | 11.707 ns |  0.83 |    0.00 | 0.2937 |     - |     - |    1240 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|          EnumerableSkipToArrayRewritten100 | Job-CLADVR |      .NET 4.8 |        net48 |  4,237.54 ns | 23.739 ns | 21.044 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1204 B |
|          EnumerableSkipToArrayRewritten100 | Job-CKRDEU | .NET Core 3.1 | netcoreapp31 |  3,981.33 ns | 15.516 ns | 14.514 ns |  0.94 |    0.01 | 0.2823 |     - |     - |    1200 B |