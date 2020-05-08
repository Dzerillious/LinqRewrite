|                   Method |        Job |       Runtime |    Toolchain |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |-------------- |------------- |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          RepeatElementAt | Job-GAIYIL |      .NET 4.8 |        net48 |   184.48 ns |  0.817 ns |  0.765 ns |  1.00 | 0.0114 |     - |     - |      48 B |
|          RepeatElementAt | Job-EWIHQA | .NET Core 3.1 | netcoreapp31 |    14.57 ns |  0.145 ns |  0.136 ns |  0.08 | 0.0076 |     - |     - |      32 B |
|                          |            |               |              |             |           |           |       |        |       |       |           |
| RepeatElementAtRewritten | Job-GAIYIL |      .NET 4.8 |        net48 |    32.51 ns |  0.216 ns |  0.192 ns |  1.00 |      - |     - |     - |         - |
| RepeatElementAtRewritten | Job-EWIHQA | .NET Core 3.1 | netcoreapp31 |    18.76 ns |  0.150 ns |  0.140 ns |  0.58 |      - |     - |     - |         - |
|                          |            |               |              |             |           |           |       |        |       |       |           |
|                RepeatSum | Job-GAIYIL |      .NET 4.8 |        net48 | 5,257.94 ns | 23.940 ns | 22.393 ns |  1.00 | 0.0076 |     - |     - |      48 B |
|                RepeatSum | Job-EWIHQA | .NET Core 3.1 | netcoreapp31 | 4,076.70 ns | 17.116 ns | 15.173 ns |  0.78 | 0.0076 |     - |     - |      32 B |
|                          |            |               |              |             |           |           |       |        |       |       |           |
|       RepeatSumRewritten | Job-GAIYIL |      .NET 4.8 |        net48 |   590.26 ns |  2.734 ns |  2.423 ns |  1.00 |      - |     - |     - |         - |
|       RepeatSumRewritten | Job-EWIHQA | .NET Core 3.1 | netcoreapp31 |   298.32 ns |  0.915 ns |  0.811 ns |  0.51 |      - |     - |     - |         - |
|                          |            |               |              |             |           |           |       |        |       |       |           |
|            RepeatToArray | Job-GAIYIL |      .NET 4.8 |        net48 | 6,598.93 ns | 21.019 ns | 19.661 ns |  1.00 | 2.9755 |     - |     - |   12503 B |
|            RepeatToArray | Job-EWIHQA | .NET Core 3.1 | netcoreapp31 |   613.05 ns |  2.765 ns |  2.451 ns |  0.09 | 0.9689 |     - |     - |    4056 B |
|                          |            |               |              |             |           |           |       |        |       |       |           |
|   RepeatToArrayRewritten | Job-GAIYIL |      .NET 4.8 |        net48 |   588.66 ns |  3.348 ns |  2.795 ns |  1.00 | 0.9613 |     - |     - |    4037 B |
|   RepeatToArrayRewritten | Job-EWIHQA | .NET Core 3.1 | netcoreapp31 |   613.72 ns |  5.211 ns |  4.874 ns |  1.04 | 0.9613 |     - |     - |    4024 B |