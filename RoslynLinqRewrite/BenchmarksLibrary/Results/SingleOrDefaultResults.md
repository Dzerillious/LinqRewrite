|                                         Method |        Job |       Runtime |    Toolchain |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------------- |----------- |-------------- |------------- |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                           ArraySingleOrDefault | Job-SJMYMU |      .NET 4.8 |        net48 | 27.2607 ns | 0.1769 ns | 0.1569 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                           ArraySingleOrDefault | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 | 18.0805 ns | 0.0942 ns | 0.0786 ns |  0.66 |    0.01 |      - |     - |     - |         - |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|                  ArraySingleOrDefaultRewritten | Job-SJMYMU |      .NET 4.8 |        net48 |  0.3710 ns | 0.0072 ns | 0.0057 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                  ArraySingleOrDefaultRewritten | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 |  0.4390 ns | 0.0101 ns | 0.0079 ns |  1.18 |    0.03 |      - |     - |     - |         - |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|                  ArraySingleOrDefaultCondition | Job-SJMYMU |      .NET 4.8 |        net48 | 20.1590 ns | 0.1340 ns | 0.1253 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|                  ArraySingleOrDefaultCondition | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 | 22.3315 ns | 0.1109 ns | 0.0983 ns |  1.11 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|         ArraySingleOrDefaultConditionRewritten | Job-SJMYMU |      .NET 4.8 |        net48 |  2.1028 ns | 0.0115 ns | 0.0102 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|         ArraySingleOrDefaultConditionRewritten | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 |  1.5293 ns | 0.0168 ns | 0.0140 ns |  0.73 |    0.01 |      - |     - |     - |         - |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|                     ArraySelectSingleOrDefault | Job-SJMYMU |      .NET 4.8 |        net48 | 46.4723 ns | 0.2495 ns | 0.2334 ns |  1.00 |    0.00 | 0.0134 |     - |     - |      56 B |
|                     ArraySelectSingleOrDefault | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 | 60.4119 ns | 0.2286 ns | 0.2139 ns |  1.30 |    0.01 | 0.0114 |     - |     - |      48 B |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|            ArraySelectSingleOrDefaultRewritten | Job-SJMYMU |      .NET 4.8 |        net48 |  0.3889 ns | 0.0097 ns | 0.0086 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            ArraySelectSingleOrDefaultRewritten | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 |  0.4401 ns | 0.0263 ns | 0.0246 ns |  1.13 |    0.07 |      - |     - |     - |         - |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|                      ArrayWhereSingleOrDefault | Job-SJMYMU |      .NET 4.8 |        net48 | 45.0494 ns | 0.2285 ns | 0.2138 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|                      ArrayWhereSingleOrDefault | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 | 46.0464 ns | 0.4013 ns | 0.3351 ns |  1.02 |    0.01 | 0.0114 |     - |     - |      48 B |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|             ArrayWhereSingleOrDefaultRewritten | Job-SJMYMU |      .NET 4.8 |        net48 |  1.8375 ns | 0.0169 ns | 0.0150 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|             ArrayWhereSingleOrDefaultRewritten | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 |  1.6413 ns | 0.0081 ns | 0.0071 ns |  0.89 |    0.01 |      - |     - |     - |         - |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|             ArrayWhereSingleOrDefaultCondition | Job-SJMYMU |      .NET 4.8 |        net48 | 42.5870 ns | 0.1721 ns | 0.1526 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|             ArrayWhereSingleOrDefaultCondition | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 | 46.7027 ns | 0.2575 ns | 0.2151 ns |  1.10 |    0.01 | 0.0114 |     - |     - |      48 B |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|    ArrayWhereSingleOrDefaultConditionRewritten | Job-SJMYMU |      .NET 4.8 |        net48 |  1.9149 ns | 0.0120 ns | 0.0107 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|    ArrayWhereSingleOrDefaultConditionRewritten | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 |  1.8486 ns | 0.0100 ns | 0.0088 ns |  0.97 |    0.01 |      - |     - |     - |         - |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|             EnumerableSingleOrDefaultCondition | Job-SJMYMU |      .NET 4.8 |        net48 | 22.3297 ns | 0.1171 ns | 0.1095 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|             EnumerableSingleOrDefaultCondition | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 | 25.6010 ns | 0.1860 ns | 0.1553 ns |  1.15 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|    EnumerableSingleOrDefaultConditionRewritten | Job-SJMYMU |      .NET 4.8 |        net48 | 21.0863 ns | 0.0835 ns | 0.0698 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|    EnumerableSingleOrDefaultConditionRewritten | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 | 23.3133 ns | 0.1360 ns | 0.1136 ns |  1.11 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
|          EnumerableSingleOrDefaultNotCondition | Job-SJMYMU |      .NET 4.8 |        net48 | 22.8512 ns | 0.0876 ns | 0.0776 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableSingleOrDefaultNotCondition | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 | 24.0599 ns | 0.2216 ns | 0.2073 ns |  1.05 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                                |            |               |              |            |           |           |       |         |        |       |       |           |
| EnumerableSingleOrDefaultNotConditionRewritten | Job-SJMYMU |      .NET 4.8 |        net48 | 19.4797 ns | 0.0955 ns | 0.0846 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
| EnumerableSingleOrDefaultNotConditionRewritten | Job-HYTKDQ | .NET Core 3.1 | netcoreapp31 | 21.3120 ns | 0.0880 ns | 0.0780 ns |  1.09 |    0.01 | 0.0076 |     - |     - |      32 B |