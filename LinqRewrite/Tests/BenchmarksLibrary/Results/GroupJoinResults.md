|                       Method |        Job |       Runtime |    Toolchain |     Mean |     Error |    StdDev | Ratio |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|----------------------------- |----------- |-------------- |------------- |---------:|----------:|----------:|------:|---------:|--------:|--------:|----------:|
|               ArrayGroupJoin | Job-QYWEUL |      .NET 4.8 |        net48 | 6.013 ms | 0.0302 ms | 0.0282 ms |  1.00 | 164.0625 |       - |       - | 686.17 KB |
|               ArrayGroupJoin | Job-KDUUQD | .NET Core 3.1 | netcoreapp31 | 5.992 ms | 0.0227 ms | 0.0190 ms |  1.00 | 148.4375 |       - |       - | 620.81 KB |
|                              |            |               |              |          |           |           |       |          |         |         |           |
|      ArrayGroupJoinRewritten | Job-QYWEUL |      .NET 4.8 |        net48 | 5.823 ms | 0.0292 ms | 0.0273 ms |  1.00 | 132.8125 |  7.8125 |       - | 570.76 KB |
|      ArrayGroupJoinRewritten | Job-KDUUQD | .NET Core 3.1 | netcoreapp31 | 6.096 ms | 0.0182 ms | 0.0161 ms |  1.05 | 132.8125 |  7.8125 |       - | 569.26 KB |
|                              |            |               |              |          |           |           |       |          |         |         |           |
|          EnumerableGroupJoin | Job-QYWEUL |      .NET 4.8 |        net48 | 5.711 ms | 0.0204 ms | 0.0171 ms |  1.00 | 164.0625 |       - |       - | 686.17 KB |
|          EnumerableGroupJoin | Job-KDUUQD | .NET Core 3.1 | netcoreapp31 | 5.438 ms | 0.0181 ms | 0.0160 ms |  0.95 | 148.4375 |       - |       - |  620.8 KB |
|                              |            |               |              |          |           |           |       |          |         |         |           |
| EnumerableGroupJoinRewritten | Job-QYWEUL |      .NET 4.8 |        net48 | 5.926 ms | 0.0241 ms | 0.0225 ms |  1.00 | 164.0625 | 62.5000 | 39.0625 | 728.68 KB |
| EnumerableGroupJoinRewritten | Job-KDUUQD | .NET Core 3.1 | netcoreapp31 | 5.610 ms | 0.0181 ms | 0.0170 ms |  0.95 | 164.0625 | 39.0625 | 39.0625 | 726.88 KB |