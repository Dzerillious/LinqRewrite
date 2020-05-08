|                 Method |        Job |       Runtime |    Toolchain |      Mean |    Error |   StdDev | Ratio |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|----------------------- |----------- |-------------- |------------- |----------:|---------:|---------:|------:|--------:|--------:|--------:|----------:|
|               ArrayZip | Job-HPIMNX |      .NET 4.8 |        net48 | 164.38 us | 1.295 us | 1.211 us |  1.12 | 40.7715 |  0.2441 |       - | 167.95 KB |
|               ArrayZip | Job-HFRHQX | .NET Core 3.1 | netcoreapp31 | 147.36 us | 0.653 us | 0.579 us |  1.00 | 25.1465 |  2.9297 |       - | 103.85 KB |
|                        |            |               |              |           |          |          |       |         |         |         |           |
|      ArrayZipRewritten | Job-HPIMNX |      .NET 4.8 |        net48 |  53.38 us | 0.117 us | 0.103 us |  1.37 |  9.5215 |       - |       - |  39.19 KB |
|      ArrayZipRewritten | Job-HFRHQX | .NET Core 3.1 | netcoreapp31 |  38.97 us | 0.220 us | 0.195 us |  1.00 |  9.5215 |       - |       - |  39.12 KB |
|                        |            |               |              |           |          |          |       |         |         |         |           |
|          EnumerableZip | Job-HPIMNX |      .NET 4.8 |        net48 | 156.64 us | 0.290 us | 0.242 us |  1.02 | 40.7715 |  0.2441 |       - | 167.95 KB |
|          EnumerableZip | Job-HFRHQX | .NET Core 3.1 | netcoreapp31 | 153.62 us | 1.830 us | 1.712 us |  1.00 | 25.1465 |  2.9297 |       - | 103.85 KB |
|                        |            |               |              |           |          |          |       |         |         |         |           |
| EnumerableZipRewritten | Job-HPIMNX |      .NET 4.8 |        net48 | 115.21 us | 0.413 us | 0.387 us |  0.98 | 41.6260 | 41.6260 | 41.6260 | 210.23 KB |
| EnumerableZipRewritten | Job-HFRHQX | .NET Core 3.1 | netcoreapp31 | 117.67 us | 0.384 us | 0.359 us |  1.00 | 41.6260 | 41.6260 | 41.6260 | 209.97 KB |