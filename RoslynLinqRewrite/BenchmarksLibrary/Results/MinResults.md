|                    Method |        Job |       Runtime |    Toolchain |        Mean |     Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |----------- |-------------- |------------- |------------:|----------:|---------:|------:|-------:|------:|------:|----------:|
|                  RangeMin | Job-JNWHNZ |      .NET 4.8 |        net48 |  5,264.0 ns |  19.71 ns | 16.46 ns |  1.00 | 0.0076 |     - |     - |      48 B |
|                  RangeMin | Job-IXWVRL | .NET Core 3.1 | netcoreapp31 |  5,193.8 ns |  23.19 ns | 19.36 ns |  0.99 | 0.0076 |     - |     - |      40 B |
|                           |            |               |              |             |           |          |       |        |       |       |           |
|         RangeMinRewritten | Job-JNWHNZ |      .NET 4.8 |        net48 |    882.7 ns |   4.68 ns |  4.15 ns |  1.00 |      - |     - |     - |         - |
|         RangeMinRewritten | Job-IXWVRL | .NET Core 3.1 | netcoreapp31 |    881.8 ns |   3.20 ns |  2.67 ns |  1.00 |      - |     - |     - |         - |
|                           |            |               |              |             |           |          |       |        |       |       |           |
|                  ArrayMin | Job-JNWHNZ |      .NET 4.8 |        net48 |  5,539.9 ns |  15.47 ns | 12.92 ns |  1.00 | 0.0076 |     - |     - |      32 B |
|                  ArrayMin | Job-IXWVRL | .NET Core 3.1 | netcoreapp31 |  5,211.0 ns |  35.88 ns | 31.81 ns |  0.94 | 0.0076 |     - |     - |      32 B |
|                           |            |               |              |             |           |          |       |        |       |       |           |
|         ArrayMinRewritten | Job-JNWHNZ |      .NET 4.8 |        net48 |  1,066.2 ns |   5.93 ns |  4.95 ns |  1.00 |      - |     - |     - |         - |
|         ArrayMinRewritten | Job-IXWVRL | .NET Core 3.1 | netcoreapp31 |    880.3 ns |   2.92 ns |  2.59 ns |  0.83 |      - |     - |     - |         - |
|                           |            |               |              |             |           |          |       |        |       |       |           |
|             ArrayWhereMin | Job-JNWHNZ |      .NET 4.8 |        net48 |  3,524.3 ns |  16.66 ns | 13.91 ns |  1.00 | 0.0114 |     - |     - |      48 B |
|             ArrayWhereMin | Job-IXWVRL | .NET Core 3.1 | netcoreapp31 |  3,558.7 ns |  19.12 ns | 16.95 ns |  1.01 | 0.0114 |     - |     - |      48 B |
|                           |            |               |              |             |           |          |       |        |       |       |           |
|    ArrayWhereMinRewritten | Job-JNWHNZ |      .NET 4.8 |        net48 |  1,089.1 ns |   4.78 ns |  4.47 ns |  1.00 |      - |     - |     - |         - |
|    ArrayWhereMinRewritten | Job-IXWVRL | .NET Core 3.1 | netcoreapp31 |    697.3 ns |   8.54 ns |  7.57 ns |  0.64 |      - |     - |     - |         - |
|                           |            |               |              |             |           |          |       |        |       |       |           |
|          ArrayNullableMin | Job-JNWHNZ |      .NET 4.8 |        net48 | 10,689.1 ns |  31.43 ns | 26.25 ns |  1.00 | 0.0153 |     - |     - |      64 B |
|          ArrayNullableMin | Job-IXWVRL | .NET Core 3.1 | netcoreapp31 | 10,283.8 ns | 104.21 ns | 92.38 ns |  0.96 |      - |     - |     - |      32 B |
|                           |            |               |              |             |           |          |       |        |       |       |           |
| ArrayNullableMinRewritten | Job-JNWHNZ |      .NET 4.8 |        net48 |  1,096.2 ns |   3.46 ns |  3.07 ns |  1.00 |      - |     - |     - |         - |
| ArrayNullableMinRewritten | Job-IXWVRL | .NET Core 3.1 | netcoreapp31 |  1,216.6 ns |   6.45 ns |  5.71 ns |  1.11 |      - |     - |     - |         - |
|                           |            |               |              |             |           |          |       |        |       |       |           |
|             EnumerableMin | Job-JNWHNZ |      .NET 4.8 |        net48 |  5,229.1 ns |  18.63 ns | 17.43 ns |  1.00 | 0.0076 |     - |     - |      32 B |
|             EnumerableMin | Job-IXWVRL | .NET Core 3.1 | netcoreapp31 |  5,454.8 ns |  22.53 ns | 17.59 ns |  1.04 | 0.0076 |     - |     - |      32 B |
|                           |            |               |              |             |           |          |       |        |       |       |           |
|    EnumerableMinRewritten | Job-JNWHNZ |      .NET 4.8 |        net48 |  5,239.2 ns |  21.41 ns | 18.98 ns |  1.00 | 0.0076 |     - |     - |      32 B |
|    EnumerableMinRewritten | Job-IXWVRL | .NET Core 3.1 | netcoreapp31 |  4,686.7 ns |  28.09 ns | 26.28 ns |  0.89 | 0.0076 |     - |     - |      32 B |