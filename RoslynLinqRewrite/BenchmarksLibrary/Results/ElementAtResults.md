|                       Method |        Job |       Runtime |    Toolchain |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |----------- |-------------- |------------- |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|               ArrayElementAt | Job-NTRIFU |      .NET 4.8 |        net48 |  24.8358 ns | 0.1530 ns | 0.1431 ns |  1.00 |      - |     - |     - |         - |
|               ArrayElementAt | Job-LGAMZY | .NET Core 3.1 | netcoreapp31 |  25.5896 ns | 0.0872 ns | 0.0816 ns |  1.03 |      - |     - |     - |         - |
|                              |            |               |              |             |           |           |       |        |       |       |           |
|      ArrayElementAtRewritten | Job-NTRIFU |      .NET 4.8 |        net48 |   0.2605 ns | 0.0085 ns | 0.0080 ns | 1.000 |      - |     - |     - |         - |
|      ArrayElementAtRewritten | Job-LGAMZY | .NET Core 3.1 | netcoreapp31 |   0.0000 ns | 0.0000 ns | 0.0000 ns | 0.000 |      - |     - |     - |         - |
|                              |            |               |              |             |           |           |       |        |       |       |           |
|          ArrayWhereElementAt | Job-NTRIFU |      .NET 4.8 |        net48 | 359.9309 ns | 1.4397 ns | 1.3467 ns |  1.00 | 0.0114 |     - |     - |      48 B |
|          ArrayWhereElementAt | Job-LGAMZY | .NET Core 3.1 | netcoreapp31 | 346.3180 ns | 0.9514 ns | 0.7945 ns |  0.96 | 0.0114 |     - |     - |      48 B |
|                              |            |               |              |             |           |           |       |        |       |       |           |
| ArrayWhereElementAtRewritten | Job-NTRIFU |      .NET 4.8 |        net48 |  58.2615 ns | 0.2340 ns | 0.2189 ns |  1.00 |      - |     - |     - |         - |
| ArrayWhereElementAtRewritten | Job-LGAMZY | .NET Core 3.1 | netcoreapp31 |  56.7767 ns | 0.2082 ns | 0.1947 ns |  0.97 |      - |     - |     - |         - |
|                              |            |               |              |             |           |           |       |        |       |       |           |
|          EnumerableElementAt | Job-NTRIFU |      .NET 4.8 |        net48 | 195.4873 ns | 0.7740 ns | 0.7240 ns |  1.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableElementAt | Job-LGAMZY | .NET Core 3.1 | netcoreapp31 | 167.5396 ns | 0.6787 ns | 0.6348 ns |  0.86 | 0.0076 |     - |     - |      32 B |
|                              |            |               |              |             |           |           |       |        |       |       |           |
| EnumerableElementAtRewritten | Job-NTRIFU |      .NET 4.8 |        net48 | 183.1851 ns | 0.8047 ns | 0.7527 ns |  1.00 | 0.0076 |     - |     - |      32 B |
| EnumerableElementAtRewritten | Job-LGAMZY | .NET Core 3.1 | netcoreapp31 | 167.6229 ns | 1.1077 ns | 1.0362 ns |  0.92 | 0.0076 |     - |     - |      32 B |