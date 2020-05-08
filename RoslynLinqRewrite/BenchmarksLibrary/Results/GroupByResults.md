|                     Method |        Job |       Runtime |    Toolchain |     Mean |   Error |  StdDev | Ratio |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------------------- |----------- |-------------- |------------- |---------:|--------:|--------:|------:|--------:|-------:|------:|----------:|
|               ArrayGroupBy | Job-ZUWAHC |      .NET 4.8 |        net48 | 308.8 us | 2.02 us | 1.79 us |  1.00 | 41.9922 |      - |     - | 173.01 KB |
|               ArrayGroupBy | Job-ZDKJGP | .NET Core 3.1 | netcoreapp31 | 258.9 us | 0.98 us | 0.87 us |  0.84 | 41.5039 | 1.4648 |     - | 171.31 KB |
|                            |            |               |              |          |         |         |       |         |        |       |           |
|      ArrayGroupByRewritten | Job-ZUWAHC |      .NET 4.8 |        net48 | 231.7 us | 1.91 us | 1.70 us |  1.00 | 31.7383 | 0.9766 |     - | 130.98 KB |
|      ArrayGroupByRewritten | Job-ZDKJGP | .NET Core 3.1 | netcoreapp31 | 215.2 us | 1.38 us | 1.29 us |  0.93 | 31.7383 | 1.4648 |     - | 130.59 KB |
|                            |            |               |              |          |         |         |       |         |        |       |           |
|          EnumerableGroupBy | Job-ZUWAHC |      .NET 4.8 |        net48 | 302.2 us | 1.78 us | 1.67 us |  1.00 | 41.9922 |      - |     - | 173.01 KB |
|          EnumerableGroupBy | Job-ZDKJGP | .NET Core 3.1 | netcoreapp31 | 266.3 us | 1.26 us | 1.18 us |  0.88 | 41.5039 | 1.4648 |     - | 171.31 KB |
|                            |            |               |              |          |         |         |       |         |        |       |           |
| EnumerableGroupByRewritten | Job-ZUWAHC |      .NET 4.8 |        net48 | 289.9 us | 1.21 us | 1.07 us |  1.00 | 31.7383 | 0.9766 |     - | 131.01 KB |
| EnumerableGroupByRewritten | Job-ZDKJGP | .NET Core 3.1 | netcoreapp31 | 276.2 us | 1.32 us | 1.23 us |  0.95 | 31.7383 | 0.9766 |     - | 130.63 KB |