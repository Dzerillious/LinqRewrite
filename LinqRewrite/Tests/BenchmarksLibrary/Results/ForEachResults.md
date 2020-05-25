|                             Method |        Job |       Runtime |    Toolchain |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------- |----------- |-------------- |------------- |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                    ArrayForEachSum | Job-SAHWOM |      .NET 4.8 |        net48 |  7.142 us | 0.0264 us | 0.0247 us |  1.00 | 0.0229 |     - |     - |     120 B |
|                    ArrayForEachSum | Job-JVDIPI | .NET Core 3.1 | netcoreapp31 |  6.355 us | 0.0365 us | 0.0341 us |  0.89 | 0.0229 |     - |     - |     120 B |
|                                    |            |               |              |           |           |           |       |        |       |       |           |
|           ArrayForEachSumRewritten | Job-SAHWOM |      .NET 4.8 |        net48 |  1.556 us | 0.0075 us | 0.0071 us |  1.00 |      - |     - |     - |         - |
|           ArrayForEachSumRewritten | Job-JVDIPI | .NET Core 3.1 | netcoreapp31 |  1.558 us | 0.0095 us | 0.0088 us |  1.00 |      - |     - |     - |         - |
|                                    |            |               |              |           |           |           |       |        |       |       |           |
|               EnumerableForEachSum | Job-SAHWOM |      .NET 4.8 |        net48 |  7.269 us | 0.0252 us | 0.0236 us |  1.00 | 0.0229 |     - |     - |     120 B |
|               EnumerableForEachSum | Job-JVDIPI | .NET Core 3.1 | netcoreapp31 |  6.587 us | 0.0576 us | 0.0511 us |  0.91 | 0.0229 |     - |     - |     120 B |
|                                    |            |               |              |           |           |           |       |        |       |       |           |
|      EnumerableForEachSumRewritten | Job-SAHWOM |      .NET 4.8 |        net48 |  4.930 us | 0.0154 us | 0.0137 us |  1.00 | 0.0076 |     - |     - |      32 B |
|      EnumerableForEachSumRewritten | Job-JVDIPI | .NET Core 3.1 | netcoreapp31 |  4.970 us | 0.0272 us | 0.0255 us |  1.01 | 0.0076 |     - |     - |      32 B |
|                                    |            |               |              |           |           |           |       |        |       |       |           |
|               ArrayWhereforeachSum | Job-SAHWOM |      .NET 4.8 |        net48 | 10.136 us | 0.0278 us | 0.0246 us |  1.00 | 0.0153 |     - |     - |      88 B |
|               ArrayWhereforeachSum | Job-JVDIPI | .NET Core 3.1 | netcoreapp31 | 11.142 us | 0.0396 us | 0.0351 us |  1.10 | 0.0153 |     - |     - |      88 B |
|                                    |            |               |              |           |           |           |       |        |       |       |           |
|      ArrayWhereforeachSumRewritten | Job-SAHWOM |      .NET 4.8 |        net48 |  5.525 us | 0.0241 us | 0.0226 us |  1.00 | 0.0076 |     - |     - |      48 B |
|      ArrayWhereforeachSumRewritten | Job-JVDIPI | .NET Core 3.1 | netcoreapp31 |  5.003 us | 0.0315 us | 0.0294 us |  0.91 | 0.0076 |     - |     - |      48 B |
|                                    |            |               |              |           |           |           |       |        |       |       |           |
|          EnumerableWhereforeachSum | Job-SAHWOM |      .NET 4.8 |        net48 | 10.125 us | 0.0422 us | 0.0352 us |  1.00 | 0.0153 |     - |     - |      88 B |
|          EnumerableWhereforeachSum | Job-JVDIPI | .NET Core 3.1 | netcoreapp31 | 11.147 us | 0.0411 us | 0.0343 us |  1.10 | 0.0153 |     - |     - |      88 B |
|                                    |            |               |              |           |           |           |       |        |       |       |           |
| EnumerableWhereforeachSumRewritten | Job-SAHWOM |      .NET 4.8 |        net48 | 10.149 us | 0.0434 us | 0.0406 us |  1.00 | 0.0153 |     - |     - |      88 B |
| EnumerableWhereforeachSumRewritten | Job-JVDIPI | .NET Core 3.1 | netcoreapp31 | 10.101 us | 0.0495 us | 0.0463 us |  1.00 | 0.0153 |     - |     - |      88 B |