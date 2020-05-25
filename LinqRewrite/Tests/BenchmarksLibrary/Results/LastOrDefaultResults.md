|                                       Method |        Job |       Runtime |    Toolchain |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------------- |----------- |-------------- |------------- |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                           ArrayLastOrDefault | Job-HELHLV |      .NET 4.8 |        net48 |    27.9312 ns |  0.1470 ns |  0.1375 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                           ArrayLastOrDefault | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 |    28.8457 ns |  0.1354 ns |  0.1200 ns |  1.03 |    0.01 |      - |     - |     - |         - |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|                  ArrayLastOrDefaultRewritten | Job-HELHLV |      .NET 4.8 |        net48 |     0.3193 ns |  0.0064 ns |  0.0060 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                  ArrayLastOrDefaultRewritten | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 |     0.2263 ns |  0.0097 ns |  0.0086 ns |  0.71 |    0.03 |      - |     - |     - |         - |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|                  ArrayLastOrDefaultCondition | Job-HELHLV |      .NET 4.8 |        net48 | 7,017.5147 ns | 20.7638 ns | 19.4225 ns | 1.000 |    0.00 | 0.0076 |     - |     - |      32 B |
|                  ArrayLastOrDefaultCondition | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 |    23.4298 ns |  0.1118 ns |  0.0991 ns | 0.003 |    0.00 |      - |     - |     - |         - |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|         ArrayLastOrDefaultConditionRewritten | Job-HELHLV |      .NET 4.8 |        net48 |   592.2592 ns |  2.6672 ns |  2.3644 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|         ArrayLastOrDefaultConditionRewritten | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 |   585.2090 ns |  2.9172 ns |  2.7287 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|                     ArraySelectLastOrDefault | Job-HELHLV |      .NET 4.8 |        net48 | 6,183.4825 ns | 21.5863 ns | 20.1918 ns | 1.000 |    0.00 | 0.0076 |     - |     - |      56 B |
|                     ArraySelectLastOrDefault | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 |    39.8219 ns |  0.4547 ns |  0.4253 ns | 0.006 |    0.00 | 0.0114 |     - |     - |      48 B |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|            ArraySelectLastOrDefaultRewritten | Job-HELHLV |      .NET 4.8 |        net48 |     0.3510 ns |  0.0146 ns |  0.0129 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            ArraySelectLastOrDefaultRewritten | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 |     0.2248 ns |  0.0115 ns |  0.0102 ns |  0.64 |    0.04 |      - |     - |     - |         - |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|                      ArrayWhereLastOrDefault | Job-HELHLV |      .NET 4.8 |        net48 | 6,274.1010 ns | 19.5465 ns | 17.3274 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      48 B |
|                      ArrayWhereLastOrDefault | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 | 6,016.3363 ns | 18.4982 ns | 16.3982 ns |  0.96 |    0.00 | 0.0076 |     - |     - |      48 B |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|             ArrayWhereLastOrDefaultRewritten | Job-HELHLV |      .NET 4.8 |        net48 |   630.4028 ns |  1.5890 ns |  1.2406 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|             ArrayWhereLastOrDefaultRewritten | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 |   594.7787 ns |  2.5503 ns |  2.2607 ns |  0.94 |    0.00 |      - |     - |     - |         - |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|             ArrayWhereLastOrDefaultCondition | Job-HELHLV |      .NET 4.8 |        net48 | 7,896.9874 ns | 34.7546 ns | 32.5095 ns |  1.00 |    0.00 |      - |     - |     - |      48 B |
|             ArrayWhereLastOrDefaultCondition | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 | 7,447.7495 ns | 31.1138 ns | 27.5816 ns |  0.94 |    0.00 | 0.0076 |     - |     - |      48 B |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|    ArrayWhereLastOrDefaultConditionRewritten | Job-HELHLV |      .NET 4.8 |        net48 |   623.1074 ns |  2.1428 ns |  2.0044 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|    ArrayWhereLastOrDefaultConditionRewritten | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 |   662.4698 ns |  6.6697 ns |  6.2388 ns |  1.06 |    0.01 |      - |     - |     - |         - |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|             EnumerableLastOrDefaultCondition | Job-HELHLV |      .NET 4.8 |        net48 | 6,994.1436 ns | 35.1260 ns | 31.1383 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|             EnumerableLastOrDefaultCondition | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 | 6,728.5819 ns | 33.7888 ns | 29.9529 ns |  0.96 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|    EnumerableLastOrDefaultConditionRewritten | Job-HELHLV |      .NET 4.8 |        net48 | 6,731.9581 ns | 33.4390 ns | 27.9231 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|    EnumerableLastOrDefaultConditionRewritten | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 | 6,704.0595 ns | 30.8333 ns | 27.3329 ns |  1.00 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|          EnumerableLastOrDefaultNotCondition | Job-HELHLV |      .NET 4.8 |        net48 | 7,294.0769 ns | 25.1377 ns | 22.2839 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableLastOrDefaultNotCondition | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 | 6,465.2240 ns | 64.8178 ns | 60.6306 ns |  0.89 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
| EnumerableLastOrDefaultNotConditionRewritten | Job-HELHLV |      .NET 4.8 |        net48 | 5,249.9153 ns | 17.5825 ns | 15.5864 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
| EnumerableLastOrDefaultNotConditionRewritten | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 | 4,681.3891 ns | 25.5974 ns | 21.3750 ns |  0.89 |    0.00 | 0.0076 |     - |     - |      32 B |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
|          EnumerableLastOrDefaultAllCondition | Job-HELHLV |      .NET 4.8 |        net48 | 6,985.5054 ns | 18.2040 ns | 17.0281 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableLastOrDefaultAllCondition | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 | 6,721.3184 ns | 18.8649 ns | 15.7530 ns |  0.96 |    0.00 | 0.0076 |     - |     - |      32 B |
|                                              |            |               |              |               |            |            |       |         |        |       |       |           |
| EnumerableLastOrDefaultAllConditionRewritten | Job-HELHLV |      .NET 4.8 |        net48 | 6,703.6093 ns | 28.4460 ns | 26.6084 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
| EnumerableLastOrDefaultAllConditionRewritten | Job-BXXJUA | .NET Core 3.1 | netcoreapp31 | 6,418.5341 ns | 28.7739 ns | 25.5073 ns |  0.96 |    0.01 | 0.0076 |     - |     - |      32 B |