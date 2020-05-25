|                  Method |        Job |       Runtime |    Toolchain |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |----------- |-------------- |------------- |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          RangeElementAt | Job-XIDZQI |      .NET 4.8 |        net48 |   195.14 ns |  1.086 ns |  1.015 ns |  1.00 | 0.0114 |     - |     - |      48 B |
|          RangeElementAt | Job-ASVANJ | .NET Core 3.1 | netcoreapp31 |    17.66 ns |  0.216 ns |  0.192 ns |  0.09 | 0.0095 |     - |     - |      40 B |
|                         |            |               |              |             |           |           |       |        |       |       |           |
| RangeElementAtRewritten | Job-XIDZQI |      .NET 4.8 |        net48 |    31.82 ns |  0.163 ns |  0.153 ns |  1.00 |      - |     - |     - |         - |
| RangeElementAtRewritten | Job-ASVANJ | .NET Core 3.1 | netcoreapp31 |    18.53 ns |  0.083 ns |  0.065 ns |  0.58 |      - |     - |     - |         - |
|                         |            |               |              |             |           |           |       |        |       |       |           |
|                RangeSum | Job-XIDZQI |      .NET 4.8 |        net48 | 5,553.51 ns | 27.851 ns | 24.689 ns |  1.00 | 0.0076 |     - |     - |      48 B |
|                RangeSum | Job-ASVANJ | .NET Core 3.1 | netcoreapp31 | 4,410.31 ns | 21.009 ns | 17.543 ns |  0.79 | 0.0076 |     - |     - |      40 B |
|                         |            |               |              |             |           |           |       |        |       |       |           |
|       RangeSumRewritten | Job-XIDZQI |      .NET 4.8 |        net48 |   840.65 ns |  2.306 ns |  1.926 ns |  1.00 |      - |     - |     - |         - |
|       RangeSumRewritten | Job-ASVANJ | .NET Core 3.1 | netcoreapp31 |   840.55 ns |  3.948 ns |  3.297 ns |  1.00 |      - |     - |     - |         - |
|                         |            |               |              |             |           |           |       |        |       |       |           |
|            RangeToArray | Job-XIDZQI |      .NET 4.8 |        net48 | 6,869.08 ns | 28.485 ns | 25.252 ns |  1.00 | 2.9755 |     - |     - |   12503 B |
|            RangeToArray | Job-ASVANJ | .NET Core 3.1 | netcoreapp31 |   630.21 ns |  4.881 ns |  4.566 ns |  0.09 | 0.9708 |     - |     - |    4064 B |
|                         |            |               |              |             |           |           |       |        |       |       |           |
|   RangeToArrayRewritten | Job-XIDZQI |      .NET 4.8 |        net48 |   621.38 ns |  2.553 ns |  2.263 ns |  1.00 | 0.9613 |     - |     - |    4037 B |
|   RangeToArrayRewritten | Job-ASVANJ | .NET Core 3.1 | netcoreapp31 |   746.75 ns |  6.884 ns |  5.749 ns |  1.20 | 0.9613 |     - |     - |    4024 B |