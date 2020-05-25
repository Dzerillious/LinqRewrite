|                    Method |        Job |       Runtime |    Toolchain |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |----------- |-------------- |------------- |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                  RangeMax | Job-XVIOWE |      .NET 4.8 |        net48 |  7,873.0 ns | 43.99 ns | 41.15 ns |  1.00 |      - |     - |     - |      48 B |
|                  RangeMax | Job-LSTLAA | .NET Core 3.1 | netcoreapp31 |  4,405.2 ns | 18.12 ns | 16.06 ns |  0.56 | 0.0076 |     - |     - |      40 B |
|                           |            |               |              |             |          |          |       |        |       |       |           |
|         RangeMaxRewritten | Job-XVIOWE |      .NET 4.8 |        net48 |    589.3 ns |  3.56 ns |  2.97 ns |  1.00 |      - |     - |     - |         - |
|         RangeMaxRewritten | Job-LSTLAA | .NET Core 3.1 | netcoreapp31 |    400.0 ns |  4.85 ns |  4.30 ns |  0.68 |      - |     - |     - |         - |
|                           |            |               |              |             |          |          |       |        |       |       |           |
|                  ArrayMax | Job-XVIOWE |      .NET 4.8 |        net48 |  6,437.8 ns | 20.16 ns | 15.74 ns |  1.00 | 0.0076 |     - |     - |      32 B |
|                  ArrayMax | Job-LSTLAA | .NET Core 3.1 | netcoreapp31 |  4,376.6 ns | 17.90 ns | 15.86 ns |  0.68 | 0.0076 |     - |     - |      32 B |
|                           |            |               |              |             |          |          |       |        |       |       |           |
|         ArrayMaxRewritten | Job-XVIOWE |      .NET 4.8 |        net48 |    447.4 ns |  1.81 ns |  1.69 ns |  1.00 |      - |     - |     - |         - |
|         ArrayMaxRewritten | Job-LSTLAA | .NET Core 3.1 | netcoreapp31 |    446.7 ns |  1.39 ns |  1.08 ns |  1.00 |      - |     - |     - |         - |
|                           |            |               |              |             |          |          |       |        |       |       |           |
|             ArrayWhereMax | Job-XVIOWE |      .NET 4.8 |        net48 |  3,953.1 ns | 14.89 ns | 11.62 ns |  1.00 | 0.0076 |     - |     - |      48 B |
|             ArrayWhereMax | Job-LSTLAA | .NET Core 3.1 | netcoreapp31 |  3,130.3 ns |  9.06 ns |  8.03 ns |  0.79 | 0.0114 |     - |     - |      48 B |
|                           |            |               |              |             |          |          |       |        |       |       |           |
|    ArrayWhereMaxRewritten | Job-XVIOWE |      .NET 4.8 |        net48 |    933.6 ns |  3.74 ns |  3.32 ns |  1.00 |      - |     - |     - |         - |
|    ArrayWhereMaxRewritten | Job-LSTLAA | .NET Core 3.1 | netcoreapp31 |    600.5 ns |  2.28 ns |  2.13 ns |  0.64 |      - |     - |     - |         - |
|                           |            |               |              |             |          |          |       |        |       |       |           |
|          ArrayNullableMax | Job-XVIOWE |      .NET 4.8 |        net48 | 10,826.6 ns | 31.67 ns | 28.07 ns |  1.00 | 0.0153 |     - |     - |      64 B |
|          ArrayNullableMax | Job-LSTLAA | .NET Core 3.1 | netcoreapp31 | 10,166.8 ns | 28.71 ns | 25.45 ns |  0.94 |      - |     - |     - |      32 B |
|                           |            |               |              |             |          |          |       |        |       |       |           |
| ArrayNullableMaxRewritten | Job-XVIOWE |      .NET 4.8 |        net48 |  1,109.8 ns |  7.49 ns |  6.64 ns |  1.00 |      - |     - |     - |         - |
| ArrayNullableMaxRewritten | Job-LSTLAA | .NET Core 3.1 | netcoreapp31 |  1,162.9 ns |  5.71 ns |  5.06 ns |  1.05 |      - |     - |     - |         - |
|                           |            |               |              |             |          |          |       |        |       |       |           |
|             EnumerableMax | Job-XVIOWE |      .NET 4.8 |        net48 |  6,434.7 ns | 22.08 ns | 19.57 ns |  1.00 | 0.0076 |     - |     - |      32 B |
|             EnumerableMax | Job-LSTLAA | .NET Core 3.1 | netcoreapp31 |  4,671.4 ns | 37.08 ns | 30.96 ns |  0.73 | 0.0076 |     - |     - |      32 B |
|                           |            |               |              |             |          |          |       |        |       |       |           |
|    EnumerableMaxRewritten | Job-XVIOWE |      .NET 4.8 |        net48 |  5,231.0 ns | 20.45 ns | 19.13 ns |  1.00 | 0.0076 |     - |     - |      32 B |
|    EnumerableMaxRewritten | Job-LSTLAA | .NET Core 3.1 | netcoreapp31 |  4,679.3 ns | 22.43 ns | 19.89 ns |  0.89 | 0.0076 |     - |     - |      32 B |