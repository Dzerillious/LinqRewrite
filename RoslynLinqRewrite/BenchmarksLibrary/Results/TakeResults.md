|                                     Method |        Job |       Runtime |    Toolchain |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------------- |----------- |-------------- |------------- |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                       TakeToArrayUnchecked | Job-ADHTJE |      .NET 4.8 |        net48 |    56.694 ns | 0.1378 ns | 0.1221 ns |  1.78 |    0.01 | 0.0344 |     - |     - |     144 B |
|                       TakeToArrayUnchecked | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    31.884 ns | 0.1658 ns | 0.1551 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|              TakeToArrayUncheckedRewritten | Job-ADHTJE |      .NET 4.8 |        net48 |     2.324 ns | 0.0103 ns | 0.0092 ns |  1.06 |    0.01 | 0.0057 |     - |     - |      24 B |
|              TakeToArrayUncheckedRewritten | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |     2.194 ns | 0.0240 ns | 0.0224 ns |  1.00 |    0.00 | 0.0057 |     - |     - |      24 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                                TakeToArray | Job-ADHTJE |      .NET 4.8 |        net48 |    56.513 ns | 0.6873 ns | 0.6092 ns |  1.68 |    0.09 | 0.0344 |     - |     - |     144 B |
|                                TakeToArray | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    34.595 ns | 0.7116 ns | 1.2463 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                       TakeToArrayRewritten | Job-ADHTJE |      .NET 4.8 |        net48 |     3.762 ns | 0.0164 ns | 0.0146 ns |  0.95 |    0.01 | 0.0057 |     - |     - |      24 B |
|                       TakeToArrayRewritten | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |     3.974 ns | 0.0236 ns | 0.0220 ns |  1.00 |    0.00 | 0.0057 |     - |     - |      24 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                      TakeToArrayUnchecked1 | Job-ADHTJE |      .NET 4.8 |        net48 |    92.100 ns | 0.4443 ns | 0.3710 ns |  1.47 |    0.01 | 0.0459 |     - |     - |     193 B |
|                      TakeToArrayUnchecked1 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    62.681 ns | 0.2320 ns | 0.1938 ns |  1.00 |    0.00 | 0.0324 |     - |     - |     136 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|             TakeToArrayUncheckedRewritten1 | Job-ADHTJE |      .NET 4.8 |        net48 |     2.621 ns | 0.0140 ns | 0.0131 ns |  0.90 |    0.01 | 0.0077 |     - |     - |      32 B |
|             TakeToArrayUncheckedRewritten1 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |     2.916 ns | 0.0232 ns | 0.0206 ns |  1.00 |    0.00 | 0.0077 |     - |     - |      32 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                               TakeToArray1 | Job-ADHTJE |      .NET 4.8 |        net48 |    91.185 ns | 0.5036 ns | 0.4464 ns |  1.45 |    0.01 | 0.0459 |     - |     - |     193 B |
|                               TakeToArray1 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    62.660 ns | 0.1630 ns | 0.1361 ns |  1.00 |    0.00 | 0.0324 |     - |     - |     136 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                      TakeToArrayRewritten1 | Job-ADHTJE |      .NET 4.8 |        net48 |     4.148 ns | 0.0263 ns | 0.0219 ns |  0.90 |    0.01 | 0.0077 |     - |     - |      32 B |
|                      TakeToArrayRewritten1 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |     4.602 ns | 0.0310 ns | 0.0275 ns |  1.00 |    0.00 | 0.0077 |     - |     - |      32 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                     TakeToArrayUnchecked10 | Job-ADHTJE |      .NET 4.8 |        net48 |   197.194 ns | 0.7443 ns | 0.6598 ns |  3.01 |    0.02 | 0.0823 |     - |     - |     345 B |
|                     TakeToArrayUnchecked10 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    65.605 ns | 0.3843 ns | 0.3209 ns |  1.00 |    0.00 | 0.0267 |     - |     - |     112 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|            TakeToArrayUncheckedRewritten10 | Job-ADHTJE |      .NET 4.8 |        net48 |     6.396 ns | 0.0379 ns | 0.0354 ns |  0.87 |    0.01 | 0.0153 |     - |     - |      64 B |
|            TakeToArrayUncheckedRewritten10 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |     7.341 ns | 0.0470 ns | 0.0439 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                              TakeToArray10 | Job-ADHTJE |      .NET 4.8 |        net48 |   194.072 ns | 0.9448 ns | 0.7890 ns |  2.97 |    0.02 | 0.0823 |     - |     - |     345 B |
|                              TakeToArray10 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    65.381 ns | 0.2839 ns | 0.2517 ns |  1.00 |    0.00 | 0.0267 |     - |     - |     112 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                     TakeToArrayRewritten10 | Job-ADHTJE |      .NET 4.8 |        net48 |    13.987 ns | 0.3050 ns | 0.3132 ns |  0.97 |    0.02 | 0.0153 |     - |     - |      64 B |
|                     TakeToArrayRewritten10 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    14.406 ns | 0.1262 ns | 0.1054 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                     TakeToArrayUnchecked20 | Job-ADHTJE |      .NET 4.8 |        net48 |   327.468 ns | 2.5474 ns | 2.1272 ns |  3.41 |    0.04 | 0.1278 |     - |     - |     538 B |
|                     TakeToArrayUnchecked20 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    96.080 ns | 0.8265 ns | 0.7327 ns |  1.00 |    0.00 | 0.0362 |     - |     - |     152 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|            TakeToArrayUncheckedRewritten20 | Job-ADHTJE |      .NET 4.8 |        net48 |     9.996 ns | 0.0492 ns | 0.0460 ns |  0.89 |    0.01 | 0.0249 |     - |     - |     104 B |
|            TakeToArrayUncheckedRewritten20 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    11.178 ns | 0.1294 ns | 0.1211 ns |  1.00 |    0.00 | 0.0249 |     - |     - |     104 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                              TakeToArray20 | Job-ADHTJE |      .NET 4.8 |        net48 |   367.668 ns | 2.3303 ns | 2.0657 ns |  2.59 |    0.01 | 0.1335 |     - |     - |     562 B |
|                              TakeToArray20 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   142.125 ns | 0.5783 ns | 0.5127 ns |  1.00 |    0.00 | 0.0496 |     - |     - |     208 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                     TakeToArrayRewritten20 | Job-ADHTJE |      .NET 4.8 |        net48 |    18.034 ns | 0.0409 ns | 0.0341 ns |  0.96 |    0.00 | 0.0249 |     - |     - |     104 B |
|                     TakeToArrayRewritten20 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    18.736 ns | 0.0677 ns | 0.0528 ns |  1.00 |    0.00 | 0.0249 |     - |     - |     104 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                    TakeToArrayUnchecked100 | Job-ADHTJE |      .NET 4.8 |        net48 | 1,377.875 ns | 6.2301 ns | 5.5228 ns |  3.24 |    0.02 | 0.4044 |     - |     - |    1701 B |
|                    TakeToArrayUnchecked100 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   425.839 ns | 1.2984 ns | 1.0842 ns |  1.00 |    0.00 | 0.1259 |     - |     - |     528 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|           TakeToArrayUncheckedRewritten100 | Job-ADHTJE |      .NET 4.8 |        net48 |    85.216 ns | 0.1732 ns | 0.1447 ns |  1.00 |    0.01 | 0.1013 |     - |     - |     425 B |
|           TakeToArrayUncheckedRewritten100 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    84.897 ns | 0.7229 ns | 0.6762 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                             TakeToArray100 | Job-ADHTJE |      .NET 4.8 |        net48 | 1,257.381 ns | 7.3999 ns | 6.5598 ns |  4.35 |    0.05 | 0.3986 |     - |     - |    1677 B |
|                             TakeToArray100 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   289.359 ns | 3.1282 ns | 2.9261 ns |  1.00 |    0.00 | 0.1125 |     - |     - |     472 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                    TakeToArrayRewritten100 | Job-ADHTJE |      .NET 4.8 |        net48 |    85.675 ns | 0.3219 ns | 0.3011 ns |  1.01 |    0.01 | 0.1013 |     - |     - |     425 B |
|                    TakeToArrayRewritten100 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    84.985 ns | 0.6203 ns | 0.5802 ns |  1.00 |    0.00 | 0.1013 |     - |     - |     424 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|             EnumerableTakeToArrayUnchecked | Job-ADHTJE |      .NET 4.8 |        net48 |    57.539 ns | 0.1142 ns | 0.1012 ns |  2.52 |    0.01 | 0.0363 |     - |     - |     152 B |
|             EnumerableTakeToArrayUnchecked | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    22.829 ns | 0.0985 ns | 0.0769 ns |  1.00 |    0.00 | 0.0134 |     - |     - |      56 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|    EnumerableTakeToArrayUncheckedRewritten | Job-ADHTJE |      .NET 4.8 |        net48 |    31.378 ns | 0.1104 ns | 0.0979 ns |  1.08 |    0.02 | 0.0268 |     - |     - |     112 B |
|    EnumerableTakeToArrayUncheckedRewritten | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    29.048 ns | 0.5626 ns | 0.5262 ns |  1.00 |    0.00 | 0.0268 |     - |     - |     112 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                      EnumerableTakeToArray | Job-ADHTJE |      .NET 4.8 |        net48 |    57.747 ns | 0.2456 ns | 0.2178 ns |  2.47 |    0.01 | 0.0362 |     - |     - |     152 B |
|                      EnumerableTakeToArray | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    23.423 ns | 0.0941 ns | 0.0834 ns |  1.00 |    0.00 | 0.0134 |     - |     - |      56 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|             EnumerableTakeToArrayRewritten | Job-ADHTJE |      .NET 4.8 |        net48 |    30.878 ns | 0.1251 ns | 0.1170 ns |  1.13 |    0.01 | 0.0268 |     - |     - |     112 B |
|             EnumerableTakeToArrayRewritten | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    27.225 ns | 0.1311 ns | 0.1162 ns |  1.00 |    0.00 | 0.0268 |     - |     - |     112 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|            EnumerableTakeToArrayUnchecked1 | Job-ADHTJE |      .NET 4.8 |        net48 |    57.483 ns | 0.2480 ns | 0.2320 ns |  2.50 |    0.01 | 0.0362 |     - |     - |     152 B |
|            EnumerableTakeToArrayUnchecked1 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    22.952 ns | 0.1035 ns | 0.0917 ns |  1.00 |    0.00 | 0.0134 |     - |     - |      56 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|   EnumerableTakeToArrayUncheckedRewritten1 | Job-ADHTJE |      .NET 4.8 |        net48 |    40.771 ns | 0.1234 ns | 0.0964 ns |  1.12 |    0.01 | 0.0287 |     - |     - |     120 B |
|   EnumerableTakeToArrayUncheckedRewritten1 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    36.371 ns | 0.2308 ns | 0.2159 ns |  1.00 |    0.00 | 0.0287 |     - |     - |     120 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                     EnumerableTakeToArray1 | Job-ADHTJE |      .NET 4.8 |        net48 |   107.805 ns | 0.5086 ns | 0.4508 ns |  0.97 |    0.01 | 0.0554 |     - |     - |     233 B |
|                     EnumerableTakeToArray1 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   110.864 ns | 0.3947 ns | 0.3499 ns |  1.00 |    0.00 | 0.0421 |     - |     - |     176 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|            EnumerableTakeToArrayRewritten1 | Job-ADHTJE |      .NET 4.8 |        net48 |    41.131 ns | 0.1397 ns | 0.1167 ns |  1.09 |    0.01 | 0.0287 |     - |     - |     120 B |
|            EnumerableTakeToArrayRewritten1 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    37.648 ns | 0.1534 ns | 0.1435 ns |  1.00 |    0.00 | 0.0287 |     - |     - |     120 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|           EnumerableTakeToArrayUnchecked10 | Job-ADHTJE |      .NET 4.8 |        net48 |   191.610 ns | 1.2741 ns | 1.1295 ns |  1.10 |    0.01 | 0.0823 |     - |     - |     345 B |
|           EnumerableTakeToArrayUnchecked10 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   174.158 ns | 1.0703 ns | 0.8356 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     304 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|  EnumerableTakeToArrayUncheckedRewritten10 | Job-ADHTJE |      .NET 4.8 |        net48 |   103.394 ns | 0.2318 ns | 0.2055 ns |  1.03 |    0.00 | 0.0726 |     - |     - |     305 B |
|  EnumerableTakeToArrayUncheckedRewritten10 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   100.108 ns | 0.3244 ns | 0.2875 ns |  1.00 |    0.00 | 0.0726 |     - |     - |     304 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                    EnumerableTakeToArray10 | Job-ADHTJE |      .NET 4.8 |        net48 |   195.784 ns | 0.9766 ns | 0.8657 ns |  1.10 |    0.01 | 0.0823 |     - |     - |     345 B |
|                    EnumerableTakeToArray10 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   177.563 ns | 2.3057 ns | 2.1568 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     304 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|           EnumerableTakeToArrayRewritten10 | Job-ADHTJE |      .NET 4.8 |        net48 |   108.791 ns | 0.2755 ns | 0.2577 ns |  1.09 |    0.00 | 0.0726 |     - |     - |     305 B |
|           EnumerableTakeToArrayRewritten10 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |    99.968 ns | 0.3576 ns | 0.2986 ns |  1.00 |    0.00 | 0.0726 |     - |     - |     304 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|           EnumerableTakeToArrayUnchecked20 | Job-ADHTJE |      .NET 4.8 |        net48 |   313.831 ns | 1.9779 ns | 1.5442 ns |  1.17 |    0.01 | 0.1278 |     - |     - |     538 B |
|           EnumerableTakeToArrayUnchecked20 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   267.950 ns | 3.3911 ns | 3.0061 ns |  1.00 |    0.00 | 0.1049 |     - |     - |     440 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|  EnumerableTakeToArrayUncheckedRewritten20 | Job-ADHTJE |      .NET 4.8 |        net48 |   159.845 ns | 0.2221 ns | 0.1854 ns |  1.02 |    0.00 | 0.0823 |     - |     - |     345 B |
|  EnumerableTakeToArrayUncheckedRewritten20 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   156.849 ns | 0.7532 ns | 0.5880 ns |  1.00 |    0.00 | 0.0823 |     - |     - |     344 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                    EnumerableTakeToArray20 | Job-ADHTJE |      .NET 4.8 |        net48 |   526.058 ns | 0.8184 ns | 0.6834 ns |  1.27 |    0.00 | 0.1431 |     - |     - |     602 B |
|                    EnumerableTakeToArray20 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   414.961 ns | 1.9059 ns | 1.6895 ns |  1.00 |    0.00 | 0.1183 |     - |     - |     496 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|           EnumerableTakeToArrayRewritten20 | Job-ADHTJE |      .NET 4.8 |        net48 |   159.959 ns | 0.5032 ns | 0.4202 ns |  1.04 |    0.00 | 0.0823 |     - |     - |     345 B |
|           EnumerableTakeToArrayRewritten20 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   154.218 ns | 0.4598 ns | 0.4076 ns |  1.00 |    0.00 | 0.0823 |     - |     - |     344 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|          EnumerableTakeToArrayUnchecked100 | Job-ADHTJE |      .NET 4.8 |        net48 | 1,873.488 ns | 5.3138 ns | 4.4373 ns |  1.35 |    0.00 | 0.4139 |     - |     - |    1741 B |
|          EnumerableTakeToArrayUnchecked100 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 | 1,386.404 ns | 3.2603 ns | 2.7225 ns |  1.00 |    0.00 | 0.2823 |     - |     - |    1184 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
| EnumerableTakeToArrayUncheckedRewritten100 | Job-ADHTJE |      .NET 4.8 |        net48 |   619.557 ns | 3.7294 ns | 3.4885 ns |  1.03 |    0.01 | 0.2861 |     - |     - |    1204 B |
| EnumerableTakeToArrayUncheckedRewritten100 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   603.951 ns | 2.7452 ns | 2.2924 ns |  1.00 |    0.00 | 0.2861 |     - |     - |    1200 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|                   EnumerableTakeToArray100 | Job-ADHTJE |      .NET 4.8 |        net48 | 1,198.712 ns | 4.5532 ns | 4.2591 ns |  1.59 |    0.01 | 0.3986 |     - |     - |    1677 B |
|                   EnumerableTakeToArray100 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   755.608 ns | 2.9623 ns | 2.7709 ns |  1.00 |    0.00 | 0.2689 |     - |     - |    1128 B |
|                                            |            |               |              |              |           |           |       |         |        |       |       |           |
|          EnumerableTakeToArrayRewritten100 | Job-ADHTJE |      .NET 4.8 |        net48 |   614.596 ns | 1.3399 ns | 1.1878 ns |  1.05 |    0.00 | 0.2861 |     - |     - |    1204 B |
|          EnumerableTakeToArrayRewritten100 | Job-MWVBCO | .NET Core 3.1 | netcoreapp31 |   583.010 ns | 3.2742 ns | 2.7341 ns |  1.00 |    0.00 | 0.2861 |     - |     - |    1200 B |