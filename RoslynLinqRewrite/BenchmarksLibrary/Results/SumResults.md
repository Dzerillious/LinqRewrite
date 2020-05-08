
|                     Method |        Job |       Runtime |    Toolchain |         Mean |     Error |    StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |----------- |-------------- |------------- |-------------:|----------:|----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                   RangeSum | Job-KWRTWA |      .NET 4.8 |        net48 |   4,818.3 ns |  52.79 ns |  49.38 ns |   4,816.0 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      48 B |
|                   RangeSum | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |   3,521.3 ns |   7.43 ns |   6.59 ns |   3,519.6 ns |  0.73 |    0.01 | 0.0076 |     - |     - |      40 B |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
|          RangeSumRewritten | Job-KWRTWA |      .NET 4.8 |        net48 |     716.8 ns |   1.16 ns |   1.03 ns |     717.1 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          RangeSumRewritten | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |     717.6 ns |   1.82 ns |   1.70 ns |     716.9 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
|                   ArraySum | Job-KWRTWA |      .NET 4.8 |        net48 |   4,499.2 ns |  20.22 ns |  18.92 ns |   4,491.8 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|                   ArraySum | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |   3,740.7 ns |   5.71 ns |   5.06 ns |   3,740.4 ns |  0.83 |    0.00 | 0.0076 |     - |     - |      32 B |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
|          ArraySumRewritten | Job-KWRTWA |      .NET 4.8 |        net48 |     528.8 ns |   2.86 ns |   2.53 ns |     528.1 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ArraySumRewritten | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |     526.8 ns |   1.02 ns |   0.90 ns |     526.6 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
|          ArrayCompositeSum | Job-KWRTWA |      .NET 4.8 |        net48 | 149,912.8 ns | 892.25 ns | 834.61 ns | 149,775.8 ns |  1.00 |    0.00 | 3.9063 |     - |     - |   16602 B |
|          ArrayCompositeSum | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |  16,152.5 ns |  68.66 ns |  60.86 ns |  16,135.3 ns |  0.11 |    0.00 | 2.3499 |     - |     - |    9888 B |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
| ArrayCompositeSumRewritten | Job-KWRTWA |      .NET 4.8 |        net48 |     314.2 ns |   0.66 ns |   0.62 ns |     314.2 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ArrayCompositeSumRewritten | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |     316.1 ns |   0.88 ns |   0.83 ns |     315.7 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
|              ArrayWhereSum | Job-KWRTWA |      .NET 4.8 |        net48 |   3,085.2 ns |  15.84 ns |  14.04 ns |   3,085.1 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|              ArrayWhereSum | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |   2,660.2 ns |   6.74 ns |   5.97 ns |   2,659.2 ns |  0.86 |    0.00 | 0.0114 |     - |     - |      48 B |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
|     ArrayWhereSumRewritten | Job-KWRTWA |      .NET 4.8 |        net48 |     522.7 ns |   3.24 ns |   2.87 ns |     521.8 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ArrayWhereSumRewritten | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |     520.6 ns |   1.99 ns |   1.86 ns |     519.9 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
|           ArrayNullableSum | Job-KWRTWA |      .NET 4.8 |        net48 |   9,062.2 ns | 159.09 ns | 132.85 ns |   9,000.2 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|           ArrayNullableSum | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |   9,058.6 ns | 149.72 ns | 125.02 ns |   9,071.4 ns |  1.00 |    0.02 |      - |     - |     - |      32 B |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
|  ArrayNullableSumRewritten | Job-KWRTWA |      .NET 4.8 |        net48 |   1,027.0 ns |  12.92 ns |  11.46 ns |   1,025.3 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|  ArrayNullableSumRewritten | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |     944.6 ns |   3.43 ns |   2.87 ns |     944.6 ns |  0.92 |    0.01 |      - |     - |     - |         - |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
|              EnumerableSum | Job-KWRTWA |      .NET 4.8 |        net48 |   4,005.7 ns |   9.48 ns |   7.92 ns |   4,004.4 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|              EnumerableSum | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |   4,698.3 ns | 107.88 ns | 311.27 ns |   4,726.6 ns |  1.04 |    0.11 | 0.0076 |     - |     - |      32 B |
|                            |            |               |              |              |           |           |              |       |         |        |       |       |           |
|     EnumerableSumRewritten | Job-KWRTWA |      .NET 4.8 |        net48 |   4,257.1 ns |   9.73 ns |   9.10 ns |   4,254.4 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|     EnumerableSumRewritten | Job-FAHDAQ | .NET Core 3.1 | netcoreapp31 |   4,427.0 ns |  88.52 ns | 203.40 ns |   4,358.4 ns |  1.09 |    0.05 | 0.0076 |     - |     - |      32 B |