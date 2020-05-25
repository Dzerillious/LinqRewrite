|                                   Method |        Job |       Runtime |    Toolchain |      Mean |     Error |    StdDev | Ratio |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------------------------- |----------- |-------------- |------------- |----------:|----------:|----------:|------:|--------:|-------:|------:|----------:|
|                       ArrayOfTypeToArray | Job-YEPKZP |      .NET 4.8 |        net48 | 51.579 us | 0.2367 us | 0.2214 us |  1.00 |  5.8594 |      - |     - |  24.19 KB |
|                       ArrayOfTypeToArray | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 | 30.809 us | 0.1591 us | 0.1242 us |  0.60 |  3.9673 |      - |     - |   16.3 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
|              ArrayOfTypeToArrayRewritten | Job-YEPKZP |      .NET 4.8 |        net48 |  5.656 us | 0.0281 us | 0.0249 us |  1.00 |  2.5406 |      - |     - |  10.44 KB |
|              ArrayOfTypeToArrayRewritten | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 |  5.389 us | 0.0301 us | 0.0267 us |  0.95 |  2.5406 |      - |     - |  10.41 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
|                  EnumerableOfTypeToArray | Job-YEPKZP |      .NET 4.8 |        net48 | 37.018 us | 0.3398 us | 0.3179 us |  1.00 | 11.5967 |      - |     - |  47.69 KB |
|                  EnumerableOfTypeToArray | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 | 24.509 us | 0.2012 us | 0.1680 us |  0.66 |  9.7046 |      - |     - |  39.75 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
|         EnumerableOfTypeToArrayRewritten | Job-YEPKZP |      .NET 4.8 |        net48 | 15.000 us | 0.0881 us | 0.0781 us |  1.00 | 12.8937 |      - |     - |  52.87 KB |
|         EnumerableOfTypeToArrayRewritten | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 | 15.738 us | 0.1843 us | 0.1634 us |  1.05 | 12.8784 |      - |     - |  52.74 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
|                  ArrayOfTypeToSimpleList | Job-YEPKZP |      .NET 4.8 |        net48 | 38.713 us | 0.1737 us | 0.1625 us |  1.00 |  5.2490 |      - |     - |  21.61 KB |
|                  ArrayOfTypeToSimpleList | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 | 30.314 us | 0.1156 us | 0.0965 us |  0.78 |  5.2490 |      - |     - |  21.55 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
|         ArrayOfTypeToSimpleListRewritten | Job-YEPKZP |      .NET 4.8 |        net48 |  5.400 us | 0.0242 us | 0.0202 us |  1.00 |  2.5482 |      - |     - |  10.47 KB |
|         ArrayOfTypeToSimpleListRewritten | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 |  5.515 us | 0.0390 us | 0.0326 us |  1.02 |  2.5482 |      - |     - |  10.44 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
|                 StaticArrayOfTypeToArray | Job-YEPKZP |      .NET 4.8 |        net48 | 52.395 us | 0.1048 us | 0.0818 us |  1.00 |  5.8594 |      - |     - |  24.19 KB |
|                 StaticArrayOfTypeToArray | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 | 30.957 us | 0.1640 us | 0.1454 us |  0.59 |  3.9673 |      - |     - |   16.3 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
|        StaticArrayOfTypeToArrayRewritten | Job-YEPKZP |      .NET 4.8 |        net48 |  5.203 us | 0.0169 us | 0.0158 us |  1.00 |  2.5406 |      - |     - |  10.44 KB |
|        StaticArrayOfTypeToArrayRewritten | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 |  5.416 us | 0.0397 us | 0.0352 us |  1.04 |  2.5406 |      - |     - |  10.41 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
|              ArrayUncheckedOfTypeToArray | Job-YEPKZP |      .NET 4.8 |        net48 | 55.183 us | 0.2145 us | 0.2006 us |  1.00 |  5.8594 |      - |     - |  24.19 KB |
|              ArrayUncheckedOfTypeToArray | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 | 31.983 us | 0.1973 us | 0.1846 us |  0.58 |  3.9673 |      - |     - |  16.31 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
|     ArrayUncheckedOfTypeToArrayRewritten | Job-YEPKZP |      .NET 4.8 |        net48 |  5.683 us | 0.0257 us | 0.0201 us |  1.00 |  2.5406 |      - |     - |  10.44 KB |
|     ArrayUncheckedOfTypeToArrayRewritten | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 |  5.394 us | 0.0552 us | 0.0516 us |  0.95 |  2.5406 |      - |     - |  10.41 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
|    EnumerableUncheckedOfTypeToSimpleList | Job-YEPKZP |      .NET 4.8 |        net48 | 38.696 us | 0.4301 us | 0.3591 us |  1.00 | 11.5967 |      - |     - |  47.69 KB |
|    EnumerableUncheckedOfTypeToSimpleList | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 | 24.328 us | 0.1294 us | 0.1211 us |  0.63 |  9.7046 |      - |     - |  39.75 KB |
|                                          |            |               |              |           |           |           |       |         |        |       |           |
| EnumerableUncheckedToSimpleListRewritten | Job-YEPKZP |      .NET 4.8 |        net48 | 15.049 us | 0.0670 us | 0.0594 us |  1.00 | 12.8937 |      - |     - |  52.87 KB |
| EnumerableUncheckedToSimpleListRewritten | Job-EKEVHB | .NET Core 3.1 | netcoreapp31 | 15.534 us | 0.0679 us | 0.0602 us |  1.03 | 12.8784 | 0.5493 |     - |  52.74 KB |