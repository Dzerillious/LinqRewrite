|                                Method |        Job |       Runtime |    Toolchain |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |----------- |-------------- |------------- |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                           ArraySingle | Job-DIQWRQ |      .NET 4.8 |        net48 | 27.0500 ns | 0.0947 ns | 0.0739 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                           ArraySingle | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 | 17.8951 ns | 0.1112 ns | 0.0868 ns |  0.66 |    0.00 |      - |     - |     - |         - |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|                  ArraySingleRewritten | Job-DIQWRQ |      .NET 4.8 |        net48 |  0.3833 ns | 0.0158 ns | 0.0132 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                  ArraySingleRewritten | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 |  0.4463 ns | 0.0116 ns | 0.0103 ns |  1.16 |    0.04 |      - |     - |     - |         - |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|                  ArraySingleCondition | Job-DIQWRQ |      .NET 4.8 |        net48 | 20.4203 ns | 0.0935 ns | 0.0874 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|                  ArraySingleCondition | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 | 22.7942 ns | 0.1337 ns | 0.1185 ns |  1.12 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|         ArraySingleConditionRewritten | Job-DIQWRQ |      .NET 4.8 |        net48 |  2.1284 ns | 0.0138 ns | 0.0115 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|         ArraySingleConditionRewritten | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 |  1.6759 ns | 0.0123 ns | 0.0109 ns |  0.79 |    0.01 |      - |     - |     - |         - |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|                     ArraySelectSingle | Job-DIQWRQ |      .NET 4.8 |        net48 | 44.8105 ns | 0.2067 ns | 0.1933 ns |  1.00 |    0.00 | 0.0134 |     - |     - |      56 B |
|                     ArraySelectSingle | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 | 60.7791 ns | 0.3121 ns | 0.2437 ns |  1.36 |    0.01 | 0.0114 |     - |     - |      48 B |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|            ArraySelectSingleRewritten | Job-DIQWRQ |      .NET 4.8 |        net48 |  0.9380 ns | 0.0116 ns | 0.0102 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            ArraySelectSingleRewritten | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 |  0.4336 ns | 0.0125 ns | 0.0111 ns |  0.46 |    0.01 |      - |     - |     - |         - |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|                      ArrayWhereSingle | Job-DIQWRQ |      .NET 4.8 |        net48 | 44.7373 ns | 0.5411 ns | 0.5062 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|                      ArrayWhereSingle | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 | 45.7165 ns | 0.1986 ns | 0.1551 ns |  1.02 |    0.01 | 0.0114 |     - |     - |      48 B |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|             ArrayWhereSingleRewritten | Job-DIQWRQ |      .NET 4.8 |        net48 |  1.8721 ns | 0.0129 ns | 0.0121 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|             ArrayWhereSingleRewritten | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 |  1.5740 ns | 0.0093 ns | 0.0078 ns |  0.84 |    0.01 |      - |     - |     - |         - |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|             ArrayWhereSingleCondition | Job-DIQWRQ |      .NET 4.8 |        net48 | 42.2252 ns | 0.2156 ns | 0.1800 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|             ArrayWhereSingleCondition | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 | 45.4579 ns | 0.2057 ns | 0.1824 ns |  1.08 |    0.01 | 0.0114 |     - |     - |      48 B |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|    ArrayWhereSingleConditionRewritten | Job-DIQWRQ |      .NET 4.8 |        net48 |  1.9283 ns | 0.0134 ns | 0.0125 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|    ArrayWhereSingleConditionRewritten | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 |  1.6006 ns | 0.0134 ns | 0.0119 ns |  0.83 |    0.01 |      - |     - |     - |         - |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|             EnumerableSingleCondition | Job-DIQWRQ |      .NET 4.8 |        net48 | 22.0354 ns | 0.1202 ns | 0.1125 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|             EnumerableSingleCondition | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 | 25.5701 ns | 0.1788 ns | 0.1585 ns |  1.16 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|    EnumerableSingleConditionRewritten | Job-DIQWRQ |      .NET 4.8 |        net48 | 21.1597 ns | 0.1233 ns | 0.1030 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|    EnumerableSingleConditionRewritten | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 | 23.0008 ns | 0.1260 ns | 0.1117 ns |  1.09 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
|          EnumerableSingleNotCondition | Job-DIQWRQ |      .NET 4.8 |        net48 |         NA |        NA |        NA |     ? |       ? |      - |     - |     - |         - |
|          EnumerableSingleNotCondition | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 |         NA |        NA |        NA |     ? |       ? |      - |     - |     - |         - |
|                                       |            |               |              |            |           |           |       |         |        |       |       |           |
| EnumerableSingleNotConditionRewritten | Job-DIQWRQ |      .NET 4.8 |        net48 |         NA |        NA |        NA |     ? |       ? |      - |     - |     - |         - |
| EnumerableSingleNotConditionRewritten | Job-ERVDZO | .NET Core 3.1 | netcoreapp31 |         NA |        NA |        NA |     ? |       ? |      - |     - |     - |         - |