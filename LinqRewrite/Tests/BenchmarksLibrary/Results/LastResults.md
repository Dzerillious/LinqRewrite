|                              Method |        Job |       Runtime |    Toolchain |          Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |----------- |-------------- |------------- |--------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                           ArrayLast | Job-RJGMRU |      .NET 4.8 |        net48 |    27.0226 ns |   0.1056 ns |   0.0988 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                           ArrayLast | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 |    31.1874 ns |   0.6265 ns |   0.5231 ns |  1.15 |    0.02 |      - |     - |     - |         - |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|                  ArrayLastRewritten | Job-RJGMRU |      .NET 4.8 |        net48 |     0.3290 ns |   0.0064 ns |   0.0060 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                  ArrayLastRewritten | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 |     0.3672 ns |   0.0244 ns |   0.0191 ns |  1.12 |    0.06 |      - |     - |     - |         - |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|                  ArrayLastCondition | Job-RJGMRU |      .NET 4.8 |        net48 | 7,945.6777 ns |  37.7232 ns |  33.4407 ns | 1.000 |    0.00 |      - |     - |     - |      32 B |
|                  ArrayLastCondition | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 |    24.6941 ns |   0.5202 ns |   0.8833 ns | 0.003 |    0.00 |      - |     - |     - |         - |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|         ArrayLastConditionRewritten | Job-RJGMRU |      .NET 4.8 |        net48 |   592.4899 ns |   1.8124 ns |   1.6067 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|         ArrayLastConditionRewritten | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 |   598.4677 ns |   8.4429 ns |   7.8975 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|                     ArraySelectLast | Job-RJGMRU |      .NET 4.8 |        net48 | 6,169.9600 ns |  18.3928 ns |  17.2046 ns | 1.000 |    0.00 | 0.0076 |     - |     - |      56 B |
|                     ArraySelectLast | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 |    43.1323 ns |   0.8516 ns |   0.7966 ns | 0.007 |    0.00 | 0.0114 |     - |     - |      48 B |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|            ArraySelectLastRewritten | Job-RJGMRU |      .NET 4.8 |        net48 |     0.3076 ns |   0.0072 ns |   0.0064 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            ArraySelectLastRewritten | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 |     0.2422 ns |   0.0332 ns |   0.0310 ns |  0.80 |    0.10 |      - |     - |     - |         - |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|                      ArrayWhereLast | Job-RJGMRU |      .NET 4.8 |        net48 | 6,277.7720 ns |  15.4359 ns |  13.6836 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      48 B |
|                      ArrayWhereLast | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 | 6,035.4723 ns | 118.2744 ns | 121.4591 ns |  0.96 |    0.02 | 0.0076 |     - |     - |      48 B |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|             ArrayWhereLastRewritten | Job-RJGMRU |      .NET 4.8 |        net48 |   605.2466 ns |   2.1205 ns |   1.9835 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|             ArrayWhereLastRewritten | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 |   608.5453 ns |   9.9252 ns |  10.1925 ns |  1.01 |    0.02 |      - |     - |     - |         - |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|             ArrayWhereLastCondition | Job-RJGMRU |      .NET 4.8 |        net48 | 8,419.9534 ns |  38.7906 ns |  34.3869 ns |  1.00 |    0.00 |      - |     - |     - |      48 B |
|             ArrayWhereLastCondition | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 | 7,958.7112 ns |  25.7242 ns |  24.0625 ns |  0.95 |    0.00 |      - |     - |     - |      48 B |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|    ArrayWhereLastConditionRewritten | Job-RJGMRU |      .NET 4.8 |        net48 |   833.8631 ns |   7.6848 ns |   7.1883 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|    ArrayWhereLastConditionRewritten | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 |   716.4639 ns |   4.0806 ns |   3.6173 ns |  0.86 |    0.01 |      - |     - |     - |         - |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|             EnumerableLastCondition | Job-RJGMRU |      .NET 4.8 |        net48 | 7,373.1570 ns |  23.8124 ns |  21.1091 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|             EnumerableLastCondition | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 | 7,031.8690 ns |  30.3455 ns |  26.9005 ns |  0.95 |    0.00 | 0.0076 |     - |     - |      32 B |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|    EnumerableLastConditionRewritten | Job-RJGMRU |      .NET 4.8 |        net48 | 7,527.4701 ns |  18.9171 ns |  17.6950 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|    EnumerableLastConditionRewritten | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 | 7,013.8777 ns |  24.6026 ns |  21.8096 ns |  0.93 |    0.00 | 0.0076 |     - |     - |      32 B |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|          EnumerableLastNotCondition | Job-RJGMRU |      .NET 4.8 |        net48 |            NA |          NA |          NA |     ? |       ? |      - |     - |     - |         - |
|          EnumerableLastNotCondition | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 |            NA |          NA |          NA |     ? |       ? |      - |     - |     - |         - |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
| EnumerableLastNotConditionRewritten | Job-RJGMRU |      .NET 4.8 |        net48 |            NA |          NA |          NA |     ? |       ? |      - |     - |     - |         - |
| EnumerableLastNotConditionRewritten | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 |            NA |          NA |          NA |     ? |       ? |      - |     - |     - |         - |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
|          EnumerableLastAllCondition | Job-RJGMRU |      .NET 4.8 |        net48 | 7,865.2400 ns | 156.8832 ns | 316.9118 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableLastAllCondition | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 | 7,011.5491 ns |  52.6870 ns |  46.7056 ns |  0.90 |    0.06 | 0.0076 |     - |     - |      32 B |
|                                     |            |               |              |               |             |             |       |         |        |       |       |           |
| EnumerableLastAllConditionRewritten | Job-RJGMRU |      .NET 4.8 |        net48 | 7,918.1689 ns | 156.1559 ns | 213.7479 ns |  1.00 |    0.00 |      - |     - |     - |      32 B |
| EnumerableLastAllConditionRewritten | Job-AFPQSB | .NET Core 3.1 | netcoreapp31 | 7,008.7655 ns |  25.1872 ns |  23.5601 ns |  0.89 |    0.03 | 0.0076 |     - |     - |      32 B |