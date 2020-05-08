|                             Method |        Job |       Runtime |    Toolchain |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------- |----------- |-------------- |------------- |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  ArrayAllCondition | Job-NMWHRO |      .NET 4.8 |        net48 |  15.945 ns | 0.2840 ns | 0.2657 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|                  ArrayAllCondition | Job-TOJKYE | .NET Core 3.1 | netcoreapp31 |  17.415 ns | 0.2556 ns | 0.2391 ns |  1.09 |    0.02 | 0.0076 |     - |     - |      32 B |
|                                    |            |               |              |            |           |           |       |         |        |       |       |           |
|         ArrayAllConditionRewritten | Job-NMWHRO |      .NET 4.8 |        net48 |   1.362 ns | 0.0524 ns | 0.0490 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|         ArrayAllConditionRewritten | Job-TOJKYE | .NET Core 3.1 | netcoreapp31 |   1.291 ns | 0.0450 ns | 0.0399 ns |  0.95 |    0.04 |      - |     - |     - |         - |
|                                    |            |               |              |            |           |           |       |         |        |       |       |           |
|             ArrayWhereAllCondition | Job-NMWHRO |      .NET 4.8 |        net48 | 235.690 ns | 4.2589 ns | 3.9838 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|             ArrayWhereAllCondition | Job-TOJKYE | .NET Core 3.1 | netcoreapp31 | 207.009 ns | 3.9532 ns | 4.2299 ns |  0.88 |    0.02 | 0.0114 |     - |     - |      48 B |
|                                    |            |               |              |            |           |           |       |         |        |       |       |           |
|    ArrayWhereAllConditionRewritten | Job-NMWHRO |      .NET 4.8 |        net48 |  87.225 ns | 1.4741 ns | 1.3788 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|    ArrayWhereAllConditionRewritten | Job-TOJKYE | .NET Core 3.1 | netcoreapp31 |  87.492 ns | 1.5290 ns | 1.4303 ns |  1.00 |    0.02 |      - |     - |     - |         - |
|                                    |            |               |              |            |           |           |       |         |        |       |       |           |
|             EnumerableAllCondition | Job-NMWHRO |      .NET 4.8 |        net48 |  16.330 ns | 0.3072 ns | 0.2873 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|             EnumerableAllCondition | Job-TOJKYE | .NET Core 3.1 | netcoreapp31 |  20.246 ns | 0.4154 ns | 0.4617 ns |  1.24 |    0.04 | 0.0076 |     - |     - |      32 B |
|                                    |            |               |              |            |           |           |       |         |        |       |       |           |
|    EnumerableAllConditionRewritten | Job-NMWHRO |      .NET 4.8 |        net48 |  13.927 ns | 0.2537 ns | 0.2373 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|    EnumerableAllConditionRewritten | Job-TOJKYE | .NET Core 3.1 | netcoreapp31 |  19.450 ns | 0.2867 ns | 0.2541 ns |  1.40 |    0.04 | 0.0076 |     - |     - |      32 B |
|                                    |            |               |              |            |           |           |       |         |        |       |       |           |
|          EnumerableAllNotCondition | Job-NMWHRO |      .NET 4.8 |        net48 |  17.275 ns | 0.2490 ns | 0.2329 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableAllNotCondition | Job-TOJKYE | .NET Core 3.1 | netcoreapp31 |  20.757 ns | 0.1333 ns | 0.1247 ns |  1.20 |    0.02 | 0.0076 |     - |     - |      32 B |
|                                    |            |               |              |            |           |           |       |         |        |       |       |           |
| EnumerableAllNotConditionRewritten | Job-NMWHRO |      .NET 4.8 |        net48 |  13.484 ns | 0.2450 ns | 0.2292 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
| EnumerableAllNotConditionRewritten | Job-TOJKYE | .NET Core 3.1 | netcoreapp31 |  20.507 ns | 0.4223 ns | 0.6056 ns |  1.53 |    0.06 | 0.0076 |     - |     - |      32 B |
|                                    |            |               |              |            |           |           |       |         |        |       |       |           |
|          EnumerableAllAllCondition | Job-NMWHRO |      .NET 4.8 |        net48 |  17.136 ns | 0.2961 ns | 0.2770 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableAllAllCondition | Job-TOJKYE | .NET Core 3.1 | netcoreapp31 |  20.320 ns | 0.3942 ns | 0.3687 ns |  1.19 |    0.03 | 0.0076 |     - |     - |      32 B |
|                                    |            |               |              |            |           |           |       |         |        |       |       |           |
| EnumerableAllAllConditionRewritten | Job-NMWHRO |      .NET 4.8 |        net48 |  13.984 ns | 0.2761 ns | 0.2583 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
| EnumerableAllAllConditionRewritten | Job-TOJKYE | .NET Core 3.1 | netcoreapp31 |  19.877 ns | 0.3040 ns | 0.2844 ns |  1.42 |    0.03 | 0.0076 |     - |     - |      32 B |