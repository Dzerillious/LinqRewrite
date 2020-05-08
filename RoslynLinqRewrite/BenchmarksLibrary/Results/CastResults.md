|                                   Method |        Job |       Runtime |    Toolchain |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------------------------- |----------- |-------------- |------------- |------------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
|                         ArrayCastToArray | Job-LCKCXH |      .NET 4.8 |        net48 |    772.2 ns |  14.65 ns |  12.99 ns |  1.00 |    0.00 |  1.9150 |      - |     - |   7.86 KB |
|                         ArrayCastToArray | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 |    740.2 ns |  14.41 ns |  20.20 ns |  0.96 |    0.02 |  1.9150 |      - |     - |   7.84 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
|                ArrayCastToArrayRewritten | Job-LCKCXH |      .NET 4.8 |        net48 |  3,255.2 ns |  62.38 ns |  58.35 ns |  1.00 |    0.00 |  1.9150 |      - |     - |   7.86 KB |
|                ArrayCastToArrayRewritten | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 |    656.3 ns |  12.98 ns |  15.94 ns |  0.20 |    0.01 |  1.9150 |      - |     - |   7.84 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
|                    EnumerableCastToArray | Job-LCKCXH |      .NET 4.8 |        net48 | 19,845.1 ns | 232.99 ns | 206.54 ns |  1.00 |    0.00 | 11.6272 |      - |     - |  47.63 KB |
|                    EnumerableCastToArray | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 | 14,529.3 ns | 289.48 ns | 415.16 ns |  0.73 |    0.02 |  9.7046 |      - |     - |   39.7 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
|           EnumerableCastToArrayRewritten | Job-LCKCXH |      .NET 4.8 |        net48 | 13,385.5 ns | 187.69 ns | 175.56 ns |  1.00 |    0.00 | 12.8937 |      - |     - |  52.87 KB |
|           EnumerableCastToArrayRewritten | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 | 15,446.4 ns | 306.36 ns | 536.57 ns |  1.16 |    0.04 | 12.8784 | 1.2817 |     - |  52.74 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
|                    ArrayCastToSimpleList | Job-LCKCXH |      .NET 4.8 |        net48 |  9,207.8 ns |  73.99 ns |  65.59 ns |  1.00 |    0.00 |  5.2490 |      - |     - |  21.55 KB |
|                    ArrayCastToSimpleList | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 |  9,263.2 ns | 170.68 ns | 285.16 ns |  1.01 |    0.03 |  5.2490 |      - |     - |  21.49 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
|           ArrayCastToSimpleListRewritten | Job-LCKCXH |      .NET 4.8 |        net48 |  3,145.4 ns |  26.15 ns |  21.84 ns |  1.00 |    0.00 |  1.9226 |      - |     - |   7.89 KB |
|           ArrayCastToSimpleListRewritten | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 |    570.8 ns |  10.25 ns |  13.68 ns |  0.18 |    0.00 |  1.9226 |      - |     - |   7.87 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
|                   StaticArrayCastToArray | Job-LCKCXH |      .NET 4.8 |        net48 |    770.5 ns |  11.09 ns |  10.38 ns |  1.00 |    0.00 |  1.9150 |      - |     - |   7.86 KB |
|                   StaticArrayCastToArray | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 |    644.8 ns |  12.71 ns |  13.05 ns |  0.84 |    0.02 |  1.9150 |      - |     - |   7.84 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
|          StaticArrayCastToArrayRewritten | Job-LCKCXH |      .NET 4.8 |        net48 |  3,275.2 ns |  62.57 ns |  66.95 ns |  1.00 |    0.00 |  1.9150 |      - |     - |   7.86 KB |
|          StaticArrayCastToArrayRewritten | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 |    568.0 ns |  11.25 ns |  11.56 ns |  0.17 |    0.01 |  1.9150 |      - |     - |   7.84 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
|                ArrayUncheckedCastToArray | Job-LCKCXH |      .NET 4.8 |        net48 |    766.2 ns |   7.34 ns |   6.13 ns |  1.00 |    0.00 |  1.9150 |      - |     - |   7.86 KB |
|                ArrayUncheckedCastToArray | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 |    639.2 ns |  11.02 ns |   9.21 ns |  0.83 |    0.01 |  1.9150 |      - |     - |   7.84 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
|       ArrayUncheckedCastToArrayRewritten | Job-LCKCXH |      .NET 4.8 |        net48 |    672.3 ns |  11.52 ns |  13.71 ns |  1.00 |    0.00 |  1.9150 |      - |     - |   7.86 KB |
|       ArrayUncheckedCastToArrayRewritten | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 |    571.7 ns |  11.31 ns |  16.93 ns |  0.85 |    0.04 |  1.9150 |      - |     - |   7.84 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
|      EnumerableUncheckedCastToSimpleList | Job-LCKCXH |      .NET 4.8 |        net48 | 21,643.8 ns | 423.32 ns | 395.98 ns |  1.00 |    0.00 | 11.6272 |      - |     - |  47.63 KB |
|      EnumerableUncheckedCastToSimpleList | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 | 13,203.0 ns | 187.18 ns | 156.31 ns |  0.61 |    0.01 |  9.7046 |      - |     - |   39.7 KB |
|                                          |            |               |              |             |           |           |       |         |         |        |       |           |
| EnumerableUncheckedToSimpleListRewritten | Job-LCKCXH |      .NET 4.8 |        net48 | 13,369.8 ns | 217.34 ns | 203.30 ns |  1.00 |    0.00 | 12.8937 |      - |     - |  52.87 KB |
| EnumerableUncheckedToSimpleListRewritten | Job-IGFXQV | .NET Core 3.1 | netcoreapp31 | 13,090.8 ns | 260.51 ns | 300.00 ns |  0.97 |    0.03 | 12.8937 | 1.2817 |     - |  52.74 KB |