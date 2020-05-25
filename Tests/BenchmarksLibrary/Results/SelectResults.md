|                                          Method |        Job |       Runtime |    Toolchain |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------------------------------ |----------- |-------------- |------------- |--------------:|------------:|------------:|------:|--------:|--------:|-------:|------:|----------:|
|                                     ArraySelect | Job-HLFTQK |      .NET 4.8 |        net48 |     18.494 ns |   0.1016 ns |   0.0901 ns |  1.00 |    0.00 |  0.0134 |      - |     - |      56 B |
|                                     ArraySelect | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |     32.332 ns |   0.1946 ns |   0.1725 ns |  1.75 |    0.01 |  0.0114 |      - |     - |      48 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                            ArraySelectRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |      6.778 ns |   0.0360 ns |   0.0337 ns |  1.00 |    0.00 |  0.0115 |      - |     - |      48 B |
|                            ArraySelectRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |     11.236 ns |   0.1273 ns |   0.1191 ns |  1.66 |    0.02 |  0.0115 |      - |     - |      48 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                              ArraySelectToArray | Job-HLFTQK |      .NET 4.8 |        net48 |  9,389.125 ns |  55.1953 ns |  48.9292 ns |  1.00 |    0.00 |  2.9755 |      - |     - |   12514 B |
|                              ArraySelectToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |  2,282.905 ns |  13.9232 ns |  12.3426 ns |  0.24 |    0.00 |  0.9727 |      - |     - |    4072 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                     ArraySelectToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |    741.460 ns |   6.9878 ns |   6.1945 ns |  1.00 |    0.00 |  0.9613 |      - |     - |    4037 B |
|                     ArraySelectToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    743.461 ns |   8.6663 ns |   8.1064 ns |  1.00 |    0.02 |  0.9613 |      - |     - |    4024 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                               ArraySelectMethod | Job-HLFTQK |      .NET 4.8 |        net48 |     23.830 ns |   0.1271 ns |   0.1127 ns |  1.00 |    0.00 |  0.0287 |      - |     - |     120 B |
|                               ArraySelectMethod | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |     38.618 ns |   0.3059 ns |   0.2861 ns |  1.62 |    0.02 |  0.0268 |      - |     - |     112 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                      ArraySelectMethodRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |     10.271 ns |   0.0600 ns |   0.0532 ns |  1.00 |    0.00 |  0.0134 |      - |     - |      56 B |
|                      ArraySelectMethodRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |     14.749 ns |   0.2318 ns |   0.2168 ns |  1.44 |    0.02 |  0.0134 |      - |     - |      56 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                        ArraySelectMethodToArray | Job-HLFTQK |      .NET 4.8 |        net48 |  9,396.887 ns |  28.3903 ns |  25.1673 ns |  1.00 |    0.00 |  2.9907 |      - |     - |   12576 B |
|                        ArraySelectMethodToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |  2,295.036 ns |  20.4884 ns |  18.1624 ns |  0.24 |    0.00 |  0.9880 |      - |     - |    4136 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|               ArraySelectMethodToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |    750.130 ns |   2.6689 ns |   2.3659 ns |  1.00 |    0.00 |  0.9613 |      - |     - |    4037 B |
|               ArraySelectMethodToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    742.592 ns |   4.8919 ns |   3.8193 ns |  0.99 |    0.01 |  0.9613 |      - |     - |    4024 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                                ArraySelectArray | Job-HLFTQK |      .NET 4.8 |        net48 |     19.279 ns |   0.0816 ns |   0.0724 ns |  1.00 |    0.00 |  0.0153 |      - |     - |      64 B |
|                                ArraySelectArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |     44.076 ns |   0.7590 ns |   0.7099 ns |  2.29 |    0.04 |  0.0114 |      - |     - |      48 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                       ArraySelectArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |      6.949 ns |   0.0325 ns |   0.0272 ns |  1.00 |    0.00 |  0.0134 |      - |     - |      56 B |
|                       ArraySelectArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |     11.428 ns |   0.0923 ns |   0.0864 ns |  1.65 |    0.01 |  0.0134 |      - |     - |      56 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                         ArraySelectArrayToArray | Job-HLFTQK |      .NET 4.8 |        net48 | 31,874.664 ns | 251.1587 ns | 209.7289 ns |  1.00 |    0.00 | 21.1792 |      - |     - |   88918 B |
|                         ArraySelectArrayToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 | 14,720.371 ns | 131.1432 ns | 122.6714 ns |  0.46 |    0.01 | 17.2272 | 0.0458 |     - |   72072 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                ArraySelectArrayToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 | 13,679.866 ns | 211.1049 ns | 187.1390 ns |  1.00 |    0.00 | 17.2119 | 0.0153 |     - |   72236 B |
|                ArraySelectArrayToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 | 11,876.428 ns | 103.2270 ns |  91.5080 ns |  0.87 |    0.01 | 17.2119 | 0.0153 |     - |   72024 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                             ArraySelectMultiple | Job-HLFTQK |      .NET 4.8 |        net48 |    447.134 ns |   2.4617 ns |   2.1823 ns |  1.00 |    0.00 |  0.3405 |      - |     - |    1428 B |
|                             ArraySelectMultiple | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    440.463 ns |   1.9473 ns |   1.7263 ns |  0.99 |    0.01 |  0.3209 |      - |     - |    1344 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                    ArraySelectMultipleRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |      6.615 ns |   0.0354 ns |   0.0296 ns |  1.00 |    0.00 |  0.0115 |      - |     - |      48 B |
|                    ArraySelectMultipleRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |     12.226 ns |   0.1297 ns |   0.1593 ns |  1.84 |    0.02 |  0.0115 |      - |     - |      48 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                      ArraySelectMultipleToArray | Job-HLFTQK |      .NET 4.8 |        net48 | 42,189.070 ns | 173.8306 ns | 381.5625 ns |  1.00 |    0.00 |  3.2959 |      - |     - |   13885 B |
|                      ArraySelectMultipleToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 | 30,783.243 ns | 460.8277 ns | 359.7840 ns |  0.73 |    0.01 |  1.2817 |      - |     - |    5368 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|             ArraySelectMultipleToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |    747.559 ns |   3.7418 ns |   3.5000 ns |  1.00 |    0.00 |  0.9613 |      - |     - |    4037 B |
|             ArraySelectMultipleToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    751.247 ns |   4.8825 ns |   4.5671 ns |  1.00 |    0.01 |  0.9613 |      - |     - |    4024 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                      ArraySelectComplexMultiple | Job-HLFTQK |      .NET 4.8 |        net48 |    447.693 ns |   2.4081 ns |   2.2525 ns |  1.00 |    0.00 |  0.3405 |      - |     - |    1428 B |
|                      ArraySelectComplexMultiple | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    441.962 ns |   1.7637 ns |   1.5635 ns |  0.99 |    0.01 |  0.3209 |      - |     - |    1344 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|             ArraySelectComplexMultipleRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |      6.693 ns |   0.0334 ns |   0.0312 ns |  1.00 |    0.00 |  0.0115 |      - |     - |      48 B |
|             ArraySelectComplexMultipleRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |     11.428 ns |   0.1343 ns |   0.1256 ns |  1.71 |    0.02 |  0.0115 |      - |     - |      48 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|               ArraySelectComplexMultipleToArray | Job-HLFTQK |      .NET 4.8 |        net48 | 41,665.953 ns | 231.0036 ns | 216.0809 ns |  1.00 |    0.00 |  3.2959 |      - |     - |   13885 B |
|               ArraySelectComplexMultipleToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 | 31,533.609 ns | 573.0130 ns | 507.9611 ns |  0.76 |    0.01 |  1.2817 |      - |     - |    5368 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|      ArraySelectComplexMultipleToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |    736.991 ns |   3.0281 ns |   2.6843 ns |  1.00 |    0.00 |  0.9613 |      - |     - |    4037 B |
|      ArraySelectComplexMultipleToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    756.760 ns |   5.6330 ns |   5.2691 ns |  1.03 |    0.01 |  0.9613 |      - |     - |    4024 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                       ArraySelectMethodMultiple | Job-HLFTQK |      .NET 4.8 |        net48 |    484.626 ns |   2.2512 ns |   1.8799 ns |  1.00 |    0.00 |  0.4930 |      - |     - |    2070 B |
|                       ArraySelectMethodMultiple | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    493.023 ns |   4.3750 ns |   4.0924 ns |  1.02 |    0.01 |  0.4740 |      - |     - |    1984 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|              ArraySelectMethodMultipleRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |     10.217 ns |   0.0795 ns |   0.0705 ns |  1.00 |    0.00 |  0.0134 |      - |     - |      56 B |
|              ArraySelectMethodMultipleRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |     15.594 ns |   0.3440 ns |   0.5148 ns |  1.50 |    0.06 |  0.0134 |      - |     - |      56 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                ArraySelectMethodMultipleToArray | Job-HLFTQK |      .NET 4.8 |        net48 | 40,619.478 ns | 249.2643 ns | 208.1470 ns |  1.00 |    0.00 |  3.4180 |      - |     - |   14528 B |
|                ArraySelectMethodMultipleToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 | 31,492.473 ns | 245.0998 ns | 217.2746 ns |  0.77 |    0.01 |  1.4038 |      - |     - |    6009 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|       ArraySelectMethodMultipleToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |    744.034 ns |   3.4678 ns |   3.0741 ns |  1.00 |    0.00 |  0.9613 |      - |     - |    4037 B |
|       ArraySelectMethodMultipleToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    749.643 ns |  14.1332 ns |  13.2202 ns |  1.01 |    0.02 |  0.9613 |      - |     - |    4024 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                         EnumerableSelectToArray | Job-HLFTQK |      .NET 4.8 |        net48 | 13,266.014 ns |  62.7066 ns |  58.6558 ns |  1.00 |    0.00 |  2.9755 |      - |     - |   12551 B |
|                         EnumerableSelectToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |  7,443.297 ns |  35.4993 ns |  31.4692 ns |  0.56 |    0.00 |  2.0447 |      - |     - |    8584 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                EnumerableSelectToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |  6,472.759 ns |  16.8795 ns |  15.7891 ns |  1.00 |    0.00 |  3.6011 |      - |     - |   15139 B |
|                EnumerableSelectToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |  5,999.157 ns |  49.0827 ns |  43.5105 ns |  0.93 |    0.01 |  3.6011 |      - |     - |   15088 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                   EnumerableSelectMethodToArray | Job-HLFTQK |      .NET 4.8 |        net48 | 14,337.789 ns |  45.5066 ns |  42.5669 ns |  1.00 |    0.00 |  2.9907 |      - |     - |   12616 B |
|                   EnumerableSelectMethodToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |  7,776.002 ns |  85.1705 ns |  79.6686 ns |  0.54 |    0.01 |  2.0599 |      - |     - |    8648 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|          EnumerableSelectMethodToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |  6,496.423 ns |  25.4894 ns |  21.2848 ns |  1.00 |    0.00 |  3.6011 |      - |     - |   15139 B |
|          EnumerableSelectMethodToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |  5,998.965 ns |  23.8912 ns |  21.1789 ns |  0.92 |    0.00 |  3.6011 |      - |     - |   15088 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                    EnumerableSelectArrayToArray | Job-HLFTQK |      .NET 4.8 |        net48 | 37,631.558 ns | 186.0637 ns | 174.0441 ns |  1.00 |    0.00 | 21.1792 |      - |     - |   88950 B |
|                    EnumerableSelectArrayToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 | 23,635.576 ns | 297.8942 ns | 278.6504 ns |  0.63 |    0.01 | 19.2871 | 0.0305 |     - |   80696 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|           EnumerableSelectArrayToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 | 18,755.548 ns | 120.4568 ns | 100.5869 ns |  1.00 |    0.00 | 22.4609 |      - |     - |   94253 B |
|           EnumerableSelectArrayToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 | 16,848.619 ns |  94.3463 ns |  83.6355 ns |  0.90 |    0.01 | 22.4609 | 0.1831 |     - |   94000 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                 EnumerableSelectMultipleToArray | Job-HLFTQK |      .NET 4.8 |        net48 | 45,031.389 ns | 875.1604 ns | 683.2677 ns |  1.00 |    0.00 |  3.2959 |      - |     - |   13995 B |
|                 EnumerableSelectMultipleToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 | 36,096.697 ns | 182.1900 ns | 261.2914 ns |  0.80 |    0.01 |  2.3193 |      - |     - |    9952 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|        EnumerableSelectMultipleToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |  6,553.878 ns |  78.4142 ns |  73.3487 ns |  1.00 |    0.00 |  3.6011 |      - |     - |   15139 B |
|        EnumerableSelectMultipleToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |  6,047.741 ns |  57.0007 ns |  53.3185 ns |  0.92 |    0.02 |  3.6011 |      - |     - |   15088 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|          EnumerableSelectComplexMultipleToArray | Job-HLFTQK |      .NET 4.8 |        net48 | 44,565.529 ns | 273.1021 ns | 242.0979 ns |  1.00 |    0.00 |  3.2959 |      - |     - |   13995 B |
|          EnumerableSelectComplexMultipleToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 | 35,887.676 ns | 200.1032 ns | 167.0952 ns |  0.81 |    0.01 |  2.3193 |      - |     - |    9952 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
| EnumerableSelectComplexMultipleToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |  6,276.032 ns |  32.5523 ns |  28.8567 ns |  1.00 |    0.00 |  3.6011 |      - |     - |   15139 B |
| EnumerableSelectComplexMultipleToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |  6,002.818 ns |  38.2126 ns |  31.9093 ns |  0.96 |    0.01 |  3.6011 |      - |     - |   15088 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|           EnumerableSelectMethodMultipleToArray | Job-HLFTQK |      .NET 4.8 |        net48 | 40,733.826 ns | 297.3037 ns | 278.0980 ns |  1.00 |    0.00 |  3.4180 |      - |     - |   14528 B |
|           EnumerableSelectMethodMultipleToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 | 30,331.778 ns | 163.9227 ns | 136.8829 ns |  0.74 |    0.00 |  1.4038 |      - |     - |    6008 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|  EnumerableSelectMethodMultipleToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |    750.302 ns |   3.6790 ns |   3.2613 ns |  1.00 |    0.00 |  0.9613 |      - |     - |    4037 B |
|  EnumerableSelectMethodMultipleToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    752.014 ns |   8.8844 ns |   7.8758 ns |  1.00 |    0.01 |  0.9613 |      - |     - |    4024 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                         ArraySelectToSimpleList | Job-HLFTQK |      .NET 4.8 |        net48 |  7,243.671 ns |  41.2141 ns |  34.4157 ns |  1.00 |    0.00 |  2.6550 |      - |     - |   11160 B |
|                         ArraySelectToSimpleList | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |  8,155.287 ns |  43.6806 ns |  36.4753 ns |  1.13 |    0.01 |  2.6398 |      - |     - |   11112 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                ArraySelectToSimpleListRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |    748.141 ns |   3.7269 ns |   3.4861 ns |  1.00 |    0.00 |  0.9689 |      - |     - |    4068 B |
|                ArraySelectToSimpleListRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    750.016 ns |   6.7984 ns |   6.3592 ns |  1.00 |    0.01 |  0.9689 |      - |     - |    4056 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                        StaticArraySelectToArray | Job-HLFTQK |      .NET 4.8 |        net48 |  9,397.294 ns |  71.8268 ns |  59.9786 ns |  1.00 |    0.00 |  2.9755 |      - |     - |   12514 B |
|                        StaticArraySelectToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |  1,994.589 ns |  20.1288 ns |  17.8437 ns |  0.21 |    0.00 |  0.9727 |      - |     - |    4072 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|               StaticArraySelectToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |    747.677 ns |   3.7973 ns |   3.3662 ns |  1.00 |    0.00 |  0.9613 |      - |     - |    4037 B |
|               StaticArraySelectToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    742.672 ns |   5.1335 ns |   4.8019 ns |  0.99 |    0.01 |  0.9613 |      - |     - |    4024 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|                   StaticClassArraySelectToArray | Job-HLFTQK |      .NET 4.8 |        net48 |  1,159.256 ns |  16.1220 ns |  14.2917 ns |  1.00 |    0.00 |  0.3891 |      - |     - |    1637 B |
|                   StaticClassArraySelectToArray | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |    273.549 ns |   1.3773 ns |   1.2883 ns |  0.24 |    0.00 |  0.1125 |      - |     - |     472 B |
|                                                 |            |               |              |               |             |             |       |         |         |        |       |           |
|          StaticClassArraySelectToArrayRewritten | Job-HLFTQK |      .NET 4.8 |        net48 |     83.959 ns |   0.4303 ns |   0.4025 ns |  1.00 |    0.00 |  0.1013 |      - |     - |     425 B |
|          StaticClassArraySelectToArrayRewritten | Job-GPUBUY | .NET Core 3.1 | netcoreapp31 |     86.948 ns |   1.3416 ns |   1.1893 ns |  1.04 |    0.02 |  0.1013 |      - |     - |     424 B |