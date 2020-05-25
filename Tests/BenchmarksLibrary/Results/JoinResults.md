|                  Method |        Job |       Runtime |    Toolchain |     Mean |    Error |   StdDev | Ratio |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|------------------------ |----------- |-------------- |------------- |---------:|---------:|---------:|------:|---------:|---------:|---------:|----------:|
|               ArrayJoin | Job-RMHLDN |      .NET 4.8 |        net48 | 14.99 ms | 0.157 ms | 0.147 ms |  1.00 | 984.3750 | 984.3750 | 984.3750 |  11.94 MB |
|               ArrayJoin | Job-YNAHLP | .NET Core 3.1 | netcoreapp31 | 10.61 ms | 0.075 ms | 0.071 ms |  0.71 | 796.8750 | 796.8750 | 796.8750 |   7.94 MB |
|                         |            |               |              |          |          |          |       |          |          |          |           |
|      ArrayJoinRewritten | Job-RMHLDN |      .NET 4.8 |        net48 | 11.60 ms | 0.048 ms | 0.045 ms |  1.00 | 609.3750 | 484.3750 | 484.3750 |  14.99 MB |
|      ArrayJoinRewritten | Job-YNAHLP | .NET Core 3.1 | netcoreapp31 | 10.32 ms | 0.035 ms | 0.033 ms |  0.89 | 609.3750 | 500.0000 | 484.3750 |  14.99 MB |
|                         |            |               |              |          |          |          |       |          |          |          |           |
|          EnumerableJoin | Job-RMHLDN |      .NET 4.8 |        net48 | 15.02 ms | 0.092 ms | 0.082 ms |  1.00 | 984.3750 | 984.3750 | 984.3750 |  11.94 MB |
|          EnumerableJoin | Job-YNAHLP | .NET Core 3.1 | netcoreapp31 | 10.27 ms | 0.049 ms | 0.046 ms |  0.68 | 796.8750 | 796.8750 | 796.8750 |   7.94 MB |
|                         |            |               |              |          |          |          |       |          |          |          |           |
| EnumerableJoinRewritten | Job-RMHLDN |      .NET 4.8 |        net48 | 13.34 ms | 0.045 ms | 0.042 ms |  1.00 | 609.3750 | 484.3750 | 484.3750 |  14.99 MB |
| EnumerableJoinRewritten | Job-YNAHLP | .NET Core 3.1 | netcoreapp31 | 12.21 ms | 0.051 ms | 0.045 ms |  0.92 | 609.3750 | 500.0000 | 484.3750 |  14.99 MB |