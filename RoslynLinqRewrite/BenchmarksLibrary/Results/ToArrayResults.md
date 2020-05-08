|                        Method |        Job |       Runtime |    Toolchain | Offset |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------ |----------- |-------------- |------------- |------- |------------:|------------:|------------:|------------:|------:|--------:|------:|------:|------:|----------:|
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      0 |  1,412.5 ns |    65.03 ns |   170.16 ns |  1,400.0 ns |  2.82 |    0.30 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      0 |    500.0 ns |     0.00 ns |     0.00 ns |    500.0 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      0 |    701.3 ns |    32.74 ns |    84.51 ns |    700.0 ns |  0.83 |    0.13 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      0 |    865.0 ns |    50.91 ns |   133.22 ns |    800.0 ns |  1.00 |    0.00 |     - |     - |     - |      24 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      0 |  1,417.7 ns |    90.91 ns |   236.30 ns |  1,300.0 ns |  3.23 |    0.67 |     - |     - |     - |    8192 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      0 |    445.5 ns |    19.00 ns |    52.32 ns |    400.0 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      0 |    753.1 ns |    60.94 ns |   160.54 ns |    700.0 ns |  1.42 |    0.32 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      0 |    600.0 ns |     0.00 ns |     0.00 ns |    600.0 ns |  1.00 |    0.00 |     - |     - |     - |      24 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      0 |  1,137.5 ns |    41.85 ns |   109.52 ns |  1,100.0 ns |  1.82 |    0.22 |     - |     - |     - |    8192 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      0 |    633.0 ns |    17.68 ns |    49.56 ns |    600.0 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      0 |    887.2 ns |    19.34 ns |    33.87 ns |    900.0 ns |  0.79 |    0.05 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      0 |  1,132.8 ns |    26.48 ns |    59.78 ns |  1,100.0 ns |  1.00 |    0.00 |     - |     - |     - |      80 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      0 |    837.5 ns |    43.16 ns |   112.93 ns |    800.0 ns |  0.71 |    0.19 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      0 |  1,371.1 ns |   201.88 ns |   562.75 ns |  1,100.0 ns |  1.00 |    0.00 |     - |     - |     - |      80 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      0 |    872.8 ns |    45.71 ns |   120.43 ns |    800.0 ns |  0.76 |    0.11 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      0 |  1,156.5 ns |    27.02 ns |    65.26 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      80 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      1 |  1,492.3 ns |    33.21 ns |    27.74 ns |  1,500.0 ns |  1.18 |    0.05 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      1 |  1,264.1 ns |    29.14 ns |    67.54 ns |  1,300.0 ns |  1.00 |    0.00 |     - |     - |     - |      32 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      1 |    893.6 ns |    45.60 ns |   117.71 ns |    900.0 ns |  1.02 |    0.14 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      1 |    882.5 ns |    29.65 ns |    77.58 ns |    900.0 ns |  1.00 |    0.00 |     - |     - |     - |      32 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      1 |  1,446.7 ns |    30.89 ns |    58.78 ns |  1,400.0 ns |  1.24 |    0.07 |     - |     - |     - |    8192 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      1 |  1,170.3 ns |    27.29 ns |    46.34 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      72 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      1 |    764.3 ns |    46.81 ns |   119.99 ns |    750.0 ns |  1.43 |    0.31 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      1 |    600.0 ns |     0.00 ns |     0.00 ns |    600.0 ns |  1.00 |    0.00 |     - |     - |     - |      32 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      1 |  1,294.9 ns |    80.77 ns |   209.94 ns |  1,200.0 ns |  0.79 |    0.09 |     - |     - |     - |    8192 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      1 |  1,642.3 ns |    36.81 ns |    50.38 ns |  1,600.0 ns |  1.00 |    0.00 |     - |     - |     - |      72 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      1 |    916.7 ns |    26.79 ns |    69.16 ns |    900.0 ns |  0.76 |    0.06 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      1 |  1,200.0 ns |    27.84 ns |    65.63 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      88 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      1 |    934.2 ns |    21.42 ns |    36.95 ns |    950.0 ns |  0.78 |    0.03 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      1 |  1,200.0 ns |     0.00 ns |     0.00 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      88 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      1 |    921.7 ns |    22.31 ns |    53.88 ns |    900.0 ns |  0.82 |    0.06 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      1 |  1,193.3 ns |    27.60 ns |    25.82 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      88 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      2 |  1,505.4 ns |    33.64 ns |    72.41 ns |  1,500.0 ns |  1.18 |    0.08 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      2 |  1,272.7 ns |    29.34 ns |    69.16 ns |  1,300.0 ns |  1.00 |    0.00 |     - |     - |     - |      32 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      2 |    700.0 ns |     0.00 ns |     0.00 ns |    700.0 ns |  0.82 |    0.08 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      2 |    852.4 ns |    28.56 ns |    75.73 ns |    800.0 ns |  1.00 |    0.00 |     - |     - |     - |      32 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      2 |  1,322.0 ns |    30.29 ns |    67.13 ns |  1,300.0 ns |  1.09 |    0.07 |     - |     - |     - |    8192 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      2 |  1,213.2 ns |    27.84 ns |    66.70 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      72 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      2 |    803.7 ns |    48.55 ns |   127.91 ns |    800.0 ns |  1.21 |    0.22 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      2 |    668.0 ns |    18.58 ns |    46.96 ns |    700.0 ns |  1.00 |    0.00 |     - |     - |     - |      32 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      2 |  1,254.5 ns |    29.00 ns |    68.35 ns |  1,250.0 ns |  0.76 |    0.04 |     - |     - |     - |    8192 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      2 |  1,692.3 ns |    33.21 ns |    27.74 ns |  1,700.0 ns |  1.00 |    0.00 |     - |     - |     - |      72 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      2 |    944.9 ns |    37.28 ns |    96.22 ns |    900.0 ns |  0.74 |    0.08 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      2 |  1,269.6 ns |    29.27 ns |    63.01 ns |  1,300.0 ns |  1.00 |    0.00 |     - |     - |     - |      88 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      2 |  1,104.8 ns |   102.33 ns |   273.15 ns |  1,000.0 ns |  0.94 |    0.23 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      2 |  1,170.5 ns |    24.57 ns |    46.15 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      88 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      2 |  1,037.5 ns |    46.85 ns |   122.60 ns |    950.0 ns |  0.88 |    0.11 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      2 |  1,193.8 ns |    25.45 ns |    25.00 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      88 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      5 |  1,485.0 ns |    31.81 ns |    36.63 ns |  1,500.0 ns |  1.24 |    0.05 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      5 |  1,193.8 ns |    25.45 ns |    25.00 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      48 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      5 |    702.6 ns |    24.16 ns |    62.37 ns |    700.0 ns |  0.80 |    0.12 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      5 |    895.0 ns |    50.10 ns |   131.11 ns |    900.0 ns |  1.00 |    0.00 |     - |     - |     - |      48 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      5 |  1,388.9 ns |    30.22 ns |    32.34 ns |  1,400.0 ns |  1.22 |    0.06 |     - |     - |     - |    8192 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      5 |  1,166.1 ns |    26.98 ns |    58.08 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      88 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      5 |    726.9 ns |    44.00 ns |   113.59 ns |    700.0 ns |  1.06 |    0.19 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      5 |    689.9 ns |    23.54 ns |    61.17 ns |    700.0 ns |  1.00 |    0.00 |     - |     - |     - |      48 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |      5 |  1,274.2 ns |    29.13 ns |    44.48 ns |  1,300.0 ns |  0.70 |    0.03 |     - |     - |     - |    8192 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      5 |  1,826.9 ns |    38.97 ns |    53.35 ns |  1,800.0 ns |  1.00 |    0.00 |     - |     - |     - |     144 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      5 |    889.2 ns |    18.54 ns |    31.48 ns |    900.0 ns |  0.73 |    0.05 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      5 |  1,209.5 ns |    27.87 ns |    64.04 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |     104 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      5 |    982.9 ns |    45.05 ns |   119.47 ns |  1,000.0 ns |  0.79 |    0.10 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      5 |  1,256.1 ns |    28.85 ns |    62.73 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |     104 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |      5 |  1,067.5 ns |    56.15 ns |   149.88 ns |  1,000.0 ns |  0.85 |    0.09 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |      5 |  1,246.2 ns |    28.84 ns |    50.50 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |     104 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |     10 |  1,500.0 ns |     0.00 ns |     0.00 ns |  1,500.0 ns |  1.19 |    0.06 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     10 |  1,246.0 ns |    28.66 ns |    57.89 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |      64 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     10 |    875.3 ns |    83.06 ns |   218.82 ns |    800.0 ns |  1.00 |    0.27 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     10 |    882.3 ns |    34.17 ns |    88.81 ns |    900.0 ns |  1.00 |    0.00 |     - |     - |     - |      64 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |     10 |  1,841.1 ns |   227.55 ns |   652.90 ns |  1,500.0 ns |  1.38 |    0.30 |     - |     - |     - |    8192 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     10 |  1,153.0 ns |    27.06 ns |    63.78 ns |  1,100.0 ns |  1.00 |    0.00 |     - |     - |     - |     104 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     10 |    687.0 ns |    17.67 ns |    34.05 ns |    700.0 ns |  0.93 |    0.07 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     10 |    733.3 ns |    22.22 ns |    57.36 ns |    700.0 ns |  1.00 |    0.00 |     - |     - |     - |      64 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |     10 |  1,366.7 ns |    31.19 ns |    57.03 ns |  1,400.0 ns |  0.71 |    0.04 |     - |     - |     - |    8192 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     10 |  1,926.2 ns |    41.94 ns |    76.70 ns |  1,900.0 ns |  1.00 |    0.00 |     - |     - |     - |     216 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     10 |  1,189.2 ns |    39.17 ns |   101.80 ns |  1,150.0 ns |  0.91 |    0.08 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     10 |  1,320.5 ns |    29.81 ns |    52.21 ns |  1,300.0 ns |  1.00 |    0.00 |     - |     - |     - |     208 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     10 |  1,124.7 ns |    66.12 ns |   169.49 ns |  1,100.0 ns |  0.85 |    0.11 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     10 |  1,353.1 ns |    30.84 ns |    61.58 ns |  1,300.0 ns |  1.00 |    0.00 |     - |     - |     - |     272 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     10 |  1,139.2 ns |    60.18 ns |   156.42 ns |  1,100.0 ns |  0.87 |    0.11 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     10 |  1,345.7 ns |    30.76 ns |    50.54 ns |  1,300.0 ns |  1.00 |    0.00 |     - |     - |     - |     400 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |     20 |  1,828.1 ns |   198.93 ns |   551.24 ns |  1,600.0 ns |  1.21 |    0.43 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     20 |  1,725.8 ns |   262.30 ns |   744.09 ns |  1,300.0 ns |  1.00 |    0.00 |     - |     - |     - |     104 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     20 |    969.7 ns |   179.40 ns |   497.13 ns |    800.0 ns |  0.97 |    0.30 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     20 |    875.0 ns |    21.17 ns |    43.72 ns |    900.0 ns |  1.00 |    0.00 |     - |     - |     - |     104 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |     20 |  1,627.3 ns |    34.93 ns |    42.89 ns |  1,650.0 ns |  1.37 |    0.06 |     - |     - |     - |    8192 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     20 |  1,185.3 ns |    22.26 ns |    35.95 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |     144 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     20 |    787.0 ns |    17.67 ns |    34.05 ns |    800.0 ns |  1.10 |    0.12 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     20 |    720.8 ns |    23.96 ns |    61.43 ns |    700.0 ns |  1.00 |    0.00 |     - |     - |     - |     104 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |     20 |  1,565.1 ns |    33.06 ns |    61.27 ns |  1,600.0 ns |  0.65 |    0.03 |     - |     - |     - |    8192 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     20 |  2,406.5 ns |    50.54 ns |    77.18 ns |  2,400.0 ns |  1.00 |    0.00 |     - |     - |     - |     400 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     20 |  1,200.0 ns |     0.00 ns |     0.00 ns |  1,200.0 ns |  0.79 |    0.04 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     20 |  1,512.5 ns |    34.06 ns |    67.24 ns |  1,500.0 ns |  1.00 |    0.00 |     - |     - |     - |     400 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     20 |  1,156.4 ns |    75.08 ns |   193.79 ns |  1,100.0 ns |  0.82 |    0.14 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     20 |  1,437.8 ns |    32.26 ns |    61.38 ns |  1,400.0 ns |  1.00 |    0.00 |     - |     - |     - |     312 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     20 |  1,434.5 ns |   165.01 ns |   443.29 ns |  1,300.0 ns |  0.95 |    0.10 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     20 |  1,361.5 ns |    31.04 ns |    54.36 ns |  1,400.0 ns |  1.00 |    0.00 |     - |     - |     - |     440 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |     50 |  1,545.1 ns |    34.36 ns |    70.18 ns |  1,500.0 ns |  1.28 |    0.10 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     50 |  1,211.4 ns |    28.22 ns |    73.36 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |     224 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     50 |  1,299.0 ns |   248.08 ns |   731.47 ns |    900.0 ns |  1.11 |    0.61 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     50 |  1,304.1 ns |   248.13 ns |   723.81 ns |    900.0 ns |  1.00 |    0.00 |     - |     - |     - |     224 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |     50 |  1,792.3 ns |    33.21 ns |    27.74 ns |  1,800.0 ns |  1.43 |    0.07 |     - |     - |     - |    8192 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     50 |  1,238.6 ns |    28.63 ns |    53.77 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |     264 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     50 |  1,276.3 ns |   254.21 ns |   745.54 ns |    850.0 ns |  1.36 |    0.54 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     50 |    693.1 ns |    17.59 ns |    25.79 ns |    700.0 ns |  1.00 |    0.00 |     - |     - |     - |     224 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |     50 |  1,770.0 ns |    38.64 ns |    68.69 ns |  1,800.0 ns |  0.65 |    0.03 |     - |     - |     - |    8192 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     50 |  2,724.0 ns |    58.34 ns |    77.89 ns |  2,700.0 ns |  1.00 |    0.00 |     - |     - |     - |     672 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     50 |  1,892.7 ns |   259.87 ns |   749.77 ns |  1,500.0 ns |  0.93 |    0.33 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     50 |  1,718.6 ns |    37.70 ns |    69.88 ns |  1,700.0 ns |  1.00 |    0.00 |     - |     - |     - |     800 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     50 |  1,344.4 ns |    30.80 ns |    58.60 ns |  1,300.0 ns |  0.81 |    0.05 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     50 |  1,660.0 ns |    30.81 ns |    74.99 ns |  1,600.0 ns |  1.00 |    0.00 |     - |     - |     - |     968 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |     50 |  1,804.0 ns |   246.21 ns |   722.09 ns |  1,400.0 ns |  0.84 |    0.10 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |     50 |  1,600.0 ns |    31.58 ns |    46.29 ns |  1,600.0 ns |  1.00 |    0.00 |     - |     - |     - |     560 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |    100 |  1,573.2 ns |    35.13 ns |    63.34 ns |  1,600.0 ns |  1.15 |    0.22 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    100 |  1,972.2 ns |   306.03 ns |   887.85 ns |  1,400.0 ns |  1.00 |    0.00 |     - |     - |     - |     424 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    100 |  1,432.3 ns |   271.50 ns |   796.27 ns |    900.0 ns |  1.13 |    0.55 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    100 |    875.0 ns |    21.17 ns |    43.72 ns |    900.0 ns |  1.00 |    0.00 |     - |     - |     - |     424 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |    100 |  2,138.5 ns |    46.56 ns |    63.73 ns |  2,100.0 ns |  1.76 |    0.09 |     - |     - |     - |    8192 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    100 |  1,208.0 ns |    28.00 ns |    56.57 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |     464 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    100 |    796.8 ns |    11.76 ns |    17.96 ns |    800.0 ns |  1.00 |    0.18 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    100 |  1,355.0 ns |   271.77 ns |   801.31 ns |    800.0 ns |  1.00 |    0.00 |     - |     - |     - |     424 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |    100 |  2,044.0 ns |    43.68 ns |    58.31 ns |  2,000.0 ns |  0.67 |    0.02 |     - |     - |     - |    8192 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    100 |  3,036.0 ns |    64.44 ns |    86.02 ns |  3,000.0 ns |  1.00 |    0.00 |     - |     - |     - |    1152 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    100 |  2,342.7 ns |   301.18 ns |   868.97 ns |  1,800.0 ns |  0.86 |    0.10 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    100 |  2,039.3 ns |    43.85 ns |    62.89 ns |  2,000.0 ns |  1.00 |    0.00 |     - |     - |     - |    1536 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    100 |  1,669.6 ns |    37.20 ns |    47.05 ns |  1,700.0 ns |  0.89 |    0.03 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    100 |  1,891.7 ns |    36.97 ns |    28.87 ns |  1,900.0 ns |  1.00 |    0.00 |     - |     - |     - |    1168 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    100 |  2,290.7 ns |   280.91 ns |   814.97 ns |  1,800.0 ns |  0.96 |    0.29 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    100 |  1,946.7 ns |    42.01 ns |    62.88 ns |  1,900.0 ns |  1.00 |    0.00 |     - |     - |     - |    2832 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |    200 |  2,516.0 ns |   340.11 ns |   970.35 ns |  2,900.0 ns |  1.33 |    0.66 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    200 |  2,148.0 ns |   297.14 ns |   876.11 ns |  2,450.0 ns |  1.00 |    0.00 |     - |     - |     - |     824 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    200 |  1,729.5 ns |   302.47 ns |   867.85 ns |  1,700.0 ns |  1.14 |    0.60 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    200 |  1,719.6 ns |   345.32 ns | 1,001.84 ns |  1,000.0 ns |  1.00 |    0.00 |     - |     - |     - |     824 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |    200 |  2,745.8 ns |    55.45 ns |    72.11 ns |  2,700.0 ns |  2.23 |    0.13 |     - |     - |     - |    8192 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    200 |  1,235.4 ns |    28.60 ns |    56.45 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |     864 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    200 |  1,876.5 ns |   309.72 ns |   903.46 ns |  2,400.0 ns |  1.30 |    0.74 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    200 |  1,618.6 ns |   300.05 ns |   870.50 ns |  1,000.0 ns |  1.00 |    0.00 |     - |     - |     - |     824 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |    200 |  2,598.0 ns |    53.49 ns |    71.41 ns |  2,550.0 ns |  0.71 |    0.02 |     - |     - |     - |    8192 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    200 |  3,685.0 ns |    75.99 ns |    87.51 ns |  3,700.0 ns |  1.00 |    0.00 |     - |     - |     - |    2088 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    200 |  3,172.2 ns |   349.42 ns | 1,013.73 ns |  3,600.0 ns |  0.87 |    0.04 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    200 |  2,530.8 ns |    53.76 ns |    73.59 ns |  2,500.0 ns |  1.00 |    0.00 |     - |     - |     - |    2984 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    200 |  2,200.0 ns |    42.41 ns |    47.14 ns |  2,200.0 ns |  0.88 |    0.02 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    200 |  2,515.4 ns |    44.97 ns |    37.55 ns |  2,500.0 ns |  1.00 |    0.00 |     - |     - |     - |    3640 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    200 |  2,155.2 ns |    46.79 ns |    68.59 ns |  2,200.0 ns |  0.91 |    0.04 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    200 |  2,384.6 ns |    44.97 ns |    37.55 ns |  2,400.0 ns |  1.00 |    0.00 |     - |     - |     - |    3232 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |    500 |  1,692.3 ns |    33.21 ns |    27.74 ns |  1,700.0 ns |  1.34 |    0.06 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    500 |  1,278.6 ns |    29.14 ns |    41.79 ns |  1,300.0 ns |  1.00 |    0.00 |     - |     - |     - |    2024 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    500 |  1,969.1 ns |   467.91 ns | 1,357.49 ns |  1,300.0 ns |  0.92 |    0.24 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    500 |    900.0 ns |     0.00 ns |     0.00 ns |    900.0 ns |  1.00 |    0.00 |     - |     - |     - |    2024 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |    500 |  4,547.8 ns |    91.93 ns |   116.27 ns |  4,500.0 ns |  3.09 |    0.43 |     - |     - |     - |    8192 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    500 |  2,943.3 ns |   464.10 ns | 1,346.44 ns |  3,000.0 ns |  1.00 |    0.00 |     - |     - |     - |    2064 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    500 |  2,487.2 ns |   397.32 ns | 1,133.58 ns |  2,600.0 ns |  1.42 |    1.01 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    500 |  1,000.0 ns |     0.00 ns |     0.00 ns |  1,000.0 ns |  1.00 |    0.00 |     - |     - |     - |    2024 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |    500 |  4,257.1 ns |    85.27 ns |    75.59 ns |  4,200.0 ns |  0.78 |    0.02 |     - |     - |     - |    8192 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    500 |  5,442.9 ns |    85.27 ns |    75.59 ns |  5,400.0 ns |  1.00 |    0.00 |     - |     - |     - |    4424 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    500 |  3,814.7 ns |    76.53 ns |    78.59 ns |  3,850.0 ns |  0.93 |    0.02 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    500 |  4,105.3 ns |    70.16 ns |    77.99 ns |  4,100.0 ns |  1.00 |    0.00 |     - |     - |     - |    6256 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    500 |  3,738.5 ns |    77.89 ns |    65.04 ns |  3,700.0 ns |  0.91 |    0.02 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    500 |  4,094.1 ns |    80.53 ns |    82.69 ns |  4,100.0 ns |  1.00 |    0.00 |     - |     - |     - |    4840 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |    500 |  3,621.4 ns |    48.03 ns |    42.58 ns |  3,600.0 ns |  0.92 |    0.02 |     - |     - |     - |    8192 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |    500 |  3,921.4 ns |    65.31 ns |    57.89 ns |  3,900.0 ns |  1.00 |    0.00 |     - |     - |     - |    4432 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |   1000 |  2,246.3 ns |   302.98 ns |   869.31 ns |  1,700.0 ns |  1.21 |    0.63 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   1000 |  2,178.6 ns |   314.09 ns |   916.21 ns |  2,000.0 ns |  1.00 |    0.00 |     - |     - |     - |    4024 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |   1000 |  1,465.0 ns |   273.77 ns |   807.21 ns |    900.0 ns |  1.09 |    0.78 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   1000 |  1,616.3 ns |   291.50 ns |   850.31 ns |  1,000.0 ns |  1.00 |    0.00 |     - |     - |     - |    4024 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |   1000 |  7,775.0 ns |    96.55 ns |    75.38 ns |  7,800.0 ns |  4.89 |    0.11 |     - |     - |     - |   16384 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   1000 |  1,592.3 ns |    33.21 ns |    27.74 ns |  1,600.0 ns |  1.00 |    0.00 |     - |     - |     - |    4064 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |   1000 |  1,792.4 ns |   272.82 ns |   800.14 ns |  1,250.0 ns |  1.00 |    0.06 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   1000 |  1,200.0 ns |     0.00 ns |     0.00 ns |  1,200.0 ns |  1.00 |    0.00 |     - |     - |     - |    4024 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |   1000 |  7,507.7 ns |   142.21 ns |   118.75 ns |  7,500.0 ns |  0.88 |    0.03 |     - |     - |     - |   16384 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   1000 |  8,531.2 ns |   165.10 ns |   162.15 ns |  8,500.0 ns |  1.00 |    0.00 |     - |     - |     - |    8496 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |   1000 |  9,068.1 ns |   667.22 ns | 1,903.60 ns |  9,200.0 ns |  1.03 |    0.25 |     - |     - |     - |   16384 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   1000 |  7,117.4 ns |   113.47 ns |   143.50 ns |  7,100.0 ns |  1.00 |    0.00 |     - |     - |     - |   12376 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |   1000 |  6,616.7 ns |    73.95 ns |    57.74 ns |  6,600.0 ns |  0.95 |    0.02 |     - |     - |     - |   16432 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   1000 |  6,968.2 ns |   118.90 ns |   146.01 ns |  6,950.0 ns |  1.00 |    0.00 |     - |     - |     - |   15056 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |   1000 |  6,716.7 ns |   120.07 ns |    93.74 ns |  6,700.0 ns |  0.87 |    0.14 |     - |     - |     - |   24624 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   1000 |  9,523.9 ns |   649.90 ns | 1,833.05 ns |  9,700.0 ns |  1.00 |    0.00 |     - |     - |     - |   22840 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  ArrayToArray | Job-DGWWMP |      .NET 4.8 |        net48 |   2000 |  2,239.6 ns |   287.46 ns |   829.39 ns |  1,700.0 ns |  1.19 |    0.59 |     - |     - |     - |    8192 B |
|                  ArrayToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   2000 |  2,163.6 ns |   300.64 ns |   881.73 ns |  1,700.0 ns |  1.00 |    0.00 |     - |     - |     - |    8024 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         ArrayToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |   2000 |  1,648.0 ns |   300.56 ns |   876.76 ns |  1,100.0 ns |  1.21 |    0.89 |     - |     - |     - |    8192 B |
|         ArrayToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   2000 |  1,759.6 ns |   312.12 ns |   915.39 ns |  1,100.0 ns |  1.00 |    0.00 |     - |     - |     - |    8024 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|                  RangeToArray | Job-DGWWMP |      .NET 4.8 |        net48 |   2000 | 18,195.9 ns | 1,018.56 ns | 2,971.17 ns | 18,550.0 ns |  6.91 |    1.91 |     - |     - |     - |   32816 B |
|                  RangeToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   2000 |  2,809.5 ns |   310.58 ns |   891.10 ns |  2,500.0 ns |  1.00 |    0.00 |     - |     - |     - |    8064 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|         RangeToArrayRewritten | Job-DGWWMP |      .NET 4.8 |        net48 |   2000 |  2,354.5 ns |   308.27 ns |   904.10 ns |  1,700.0 ns |  1.01 |    0.42 |     - |     - |     - |    8192 B |
|         RangeToArrayRewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   2000 |  2,512.2 ns |   311.45 ns |   908.52 ns |  1,800.0 ns |  1.00 |    0.00 |     - |     - |     - |    8024 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
|             EnumerableToArray | Job-DGWWMP |      .NET 4.8 |        net48 |   2000 | 18,344.3 ns | 1,276.84 ns | 3,516.79 ns | 18,450.0 ns |  1.03 |    0.25 |     - |     - |     - |   32816 B |
|             EnumerableToArray | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   2000 | 18,182.6 ns |   871.10 ns | 2,456.95 ns | 18,950.0 ns |  1.00 |    0.00 |     - |     - |     - |   16616 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy2Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |   2000 | 17,106.2 ns | 1,385.32 ns | 3,838.71 ns | 17,450.0 ns |  1.03 |    0.30 |     - |     - |     - |   32816 B |
| EnumerableToArrayBy2Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   2000 | 17,149.5 ns | 1,141.66 ns | 3,201.33 ns | 17,600.0 ns |  1.00 |    0.00 |     - |     - |     - |   24592 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy4Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |   2000 | 16,055.1 ns |   866.68 ns | 2,401.56 ns | 16,500.0 ns |  1.01 |    0.24 |     - |     - |     - |   24624 B |
| EnumerableToArrayBy4Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   2000 | 16,439.6 ns |   842.33 ns | 2,430.31 ns | 17,100.0 ns |  1.00 |    0.00 |     - |     - |     - |   19056 B |
|                               |            |               |              |        |             |             |             |             |       |         |       |       |       |           |
| EnumerableToArrayBy8Rewritten | Job-DGWWMP |      .NET 4.8 |        net48 |   2000 | 16,276.7 ns |   960.67 ns | 2,613.57 ns | 16,550.0 ns |  1.00 |    0.26 |     - |     - |     - |   32816 B |
| EnumerableToArrayBy8Rewritten | Job-FHSOUJ | .NET Core 3.1 | netcoreapp31 |   2000 | 16,891.7 ns | 1,052.85 ns | 3,037.72 ns | 17,500.0 ns |  1.00 |    0.00 |     - |     - |     - |   26840 B |