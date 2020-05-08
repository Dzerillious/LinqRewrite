|                              Method |        Job |       Runtime |    Toolchain | Offset |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |----------- |-------------- |------------- |------- |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |     -1 | 12,674.7 ns |  28.49 ns |  26.65 ns |  1.00 |    0.00 | 3.0060 |     - |     - |   12624 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     -1 | 11,331.4 ns |  41.34 ns |  36.64 ns |  0.89 |    0.00 | 2.0599 |     - |     - |    8664 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |     -1 |  2,296.4 ns |   8.26 ns |   7.32 ns |  1.00 |    0.00 | 1.2817 |     - |     - |    5393 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     -1 |  2,331.6 ns |  14.62 ns |  13.67 ns |  1.02 |    0.01 | 1.2817 |     - |     - |    5376 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |     -1 | 12,741.7 ns | 142.00 ns | 125.88 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11267 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     -1 | 11,302.5 ns |  27.96 ns |  23.34 ns |  0.89 |    0.01 | 2.6703 |     - |     - |   11232 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |     -1 |  1,825.1 ns |  18.44 ns |  17.25 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     -1 |  1,536.8 ns |   8.80 ns |   8.24 ns |  0.84 |    0.01 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |      0 | 12,702.3 ns |  44.39 ns |  39.35 ns |  1.00 |    0.00 | 3.0060 |     - |     - |   12624 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      0 | 11,299.3 ns |  40.60 ns |  37.98 ns |  0.89 |    0.00 | 2.0599 |     - |     - |    8664 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |      0 |  2,280.7 ns |   8.28 ns |   6.91 ns |  1.00 |    0.00 | 1.2817 |     - |     - |    5393 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      0 |  2,380.9 ns |  11.59 ns |  10.85 ns |  1.04 |    0.01 | 1.2817 |     - |     - |    5376 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |      0 | 12,764.0 ns | 110.01 ns |  97.52 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11267 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      0 | 11,595.8 ns |  49.83 ns |  44.17 ns |  0.91 |    0.01 | 2.6703 |     - |     - |   11232 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |      0 |  1,833.8 ns |  13.57 ns |  11.33 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      0 |  1,534.0 ns |   6.75 ns |   6.32 ns |  0.84 |    0.01 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |      1 | 12,681.6 ns |  72.35 ns |  67.67 ns |  1.00 |    0.00 | 3.0060 |     - |     - |   12624 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      1 | 11,484.8 ns |  36.61 ns |  34.24 ns |  0.91 |    0.00 | 2.0599 |     - |     - |    8664 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |      1 |  2,608.1 ns |  11.53 ns |  10.78 ns |  1.00 |    0.00 | 2.2469 |     - |     - |    9428 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      1 |  2,645.9 ns |  13.58 ns |  11.34 ns |  1.01 |    0.01 | 2.2469 |     - |     - |    9400 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |      1 | 12,635.9 ns |  36.50 ns |  34.14 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11267 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      1 | 11,285.0 ns |  83.91 ns |  78.49 ns |  0.89 |    0.01 | 2.6703 |     - |     - |   11232 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |      1 |  1,820.8 ns |   5.50 ns |   5.14 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      1 |  1,541.8 ns |   9.69 ns |   9.07 ns |  0.85 |    0.01 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |      2 | 12,675.3 ns |  55.81 ns |  52.20 ns |  1.00 |    0.00 | 2.9907 |     - |     - |   12616 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      2 | 11,403.1 ns | 110.39 ns | 103.26 ns |  0.90 |    0.01 | 2.0599 |     - |     - |    8656 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |      2 |  2,592.5 ns |  12.01 ns |  11.24 ns |  1.00 |    0.00 | 2.2430 |     - |     - |    9424 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      2 |  2,652.6 ns |  10.20 ns |   9.54 ns |  1.02 |    0.01 | 2.2430 |     - |     - |    9392 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |      2 | 12,612.1 ns |  55.30 ns |  51.73 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11267 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      2 | 11,380.8 ns |  42.52 ns |  39.78 ns |  0.90 |    0.00 | 2.6703 |     - |     - |   11232 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |      2 |  1,829.9 ns |  11.16 ns |  10.44 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      2 |  1,541.2 ns |   8.47 ns |   7.93 ns |  0.84 |    0.01 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |      5 | 12,696.4 ns |  60.11 ns |  56.23 ns |  1.00 |    0.00 | 2.9907 |     - |     - |   12608 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      5 | 11,441.8 ns | 118.79 ns | 105.30 ns |  0.90 |    0.01 | 2.0599 |     - |     - |    8648 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |      5 |  2,557.0 ns |  12.13 ns |  11.34 ns |  1.00 |    0.00 | 2.2392 |     - |     - |    9413 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      5 |  2,636.1 ns |  18.64 ns |  16.52 ns |  1.03 |    0.01 | 2.2392 |     - |     - |    9384 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |      5 | 12,661.2 ns | 111.43 ns | 104.23 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11267 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      5 | 11,349.2 ns |  37.72 ns |  33.44 ns |  0.90 |    0.01 | 2.6703 |     - |     - |   11232 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |      5 |  1,828.2 ns |   5.91 ns |   5.24 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |      5 |  1,537.8 ns |   7.99 ns |   7.47 ns |  0.84 |    0.00 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |     10 | 12,671.7 ns |  44.87 ns |  41.97 ns |  1.00 |    0.00 | 2.9907 |     - |     - |   12584 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     10 | 11,441.3 ns |  45.45 ns |  40.29 ns |  0.90 |    0.00 | 2.0599 |     - |     - |    8624 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |     10 |  2,559.7 ns |   9.39 ns |   8.79 ns |  1.00 |    0.00 | 2.2354 |     - |     - |    9392 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     10 |  2,597.9 ns |  12.56 ns |  11.13 ns |  1.02 |    0.01 | 2.2354 |     - |     - |    9360 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |     10 | 12,631.7 ns |  61.11 ns |  54.18 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11267 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     10 | 11,611.9 ns | 105.29 ns |  87.92 ns |  0.92 |    0.01 | 2.6703 |     - |     - |   11232 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |     10 |  1,809.2 ns |   7.15 ns |   6.34 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     10 |  1,547.4 ns |   6.39 ns |   5.97 ns |  0.85 |    0.00 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |     20 | 12,605.8 ns |  53.48 ns |  47.41 ns |  1.00 |    0.00 | 2.9755 |     - |     - |   12547 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     20 | 11,266.5 ns |  51.80 ns |  45.92 ns |  0.89 |    0.00 | 2.0447 |     - |     - |    8584 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |     20 |  2,526.8 ns |  17.01 ns |  15.91 ns |  1.00 |    0.00 | 2.2240 |     - |     - |    9350 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     20 |  2,548.9 ns |  18.66 ns |  17.46 ns |  1.01 |    0.01 | 2.2240 |     - |     - |    9320 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |     20 | 12,613.3 ns |  66.07 ns |  61.80 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11267 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     20 | 11,550.3 ns |  82.69 ns |  77.35 ns |  0.92 |    0.01 | 2.6703 |     - |     - |   11232 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |     20 |  1,809.5 ns |   7.88 ns |   7.37 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     20 |  1,519.2 ns |   5.88 ns |   5.22 ns |  0.84 |    0.00 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |     50 | 12,497.9 ns |  69.07 ns |  61.23 ns |  1.00 |    0.00 | 2.9449 |     - |     - |   12422 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     50 | 11,251.7 ns |  45.44 ns |  42.50 ns |  0.90 |    0.01 | 2.0142 |     - |     - |    8464 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |     50 |  2,472.7 ns |   9.60 ns |   8.98 ns |  1.00 |    0.00 | 2.1973 |     - |     - |    9227 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     50 |  2,486.6 ns |  20.30 ns |  18.99 ns |  1.01 |    0.01 | 2.1973 |     - |     - |    9200 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |     50 | 12,484.2 ns |  49.70 ns |  46.49 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11267 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     50 | 11,090.3 ns |  47.24 ns |  41.88 ns |  0.89 |    0.00 | 2.6703 |     - |     - |   11232 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |     50 |  1,797.1 ns |   8.56 ns |   7.15 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |     50 |  1,545.4 ns |  11.88 ns |  11.11 ns |  0.86 |    0.01 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |    100 | 12,408.6 ns | 101.83 ns |  95.25 ns |  1.00 |    0.00 | 2.8992 |     - |     - |   12222 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    100 | 10,884.3 ns |  88.42 ns |  82.71 ns |  0.88 |    0.01 | 1.9684 |     - |     - |    8264 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |    100 |  2,424.8 ns |  15.64 ns |  14.63 ns |  1.00 |    0.00 | 2.1477 |     - |     - |    9029 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    100 |  2,395.8 ns |  12.49 ns |  11.07 ns |  0.99 |    0.01 | 2.1477 |     - |     - |    9000 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |    100 | 12,460.3 ns | 201.75 ns | 207.18 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11267 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    100 | 10,449.1 ns |  55.49 ns |  49.19 ns |  0.84 |    0.02 | 2.6703 |     - |     - |   11232 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |    100 |  1,745.4 ns |   6.86 ns |   6.42 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    100 |  1,521.9 ns |   8.48 ns |   7.93 ns |  0.87 |    0.01 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |    200 | 11,984.9 ns |  64.46 ns |  60.29 ns |  1.00 |    0.00 | 2.8076 |     - |     - |   11820 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    200 | 10,354.6 ns |  40.56 ns |  35.96 ns |  0.86 |    0.00 | 1.8768 |     - |     - |    7864 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |    200 |  2,252.8 ns |   9.60 ns |   8.98 ns |  1.00 |    0.00 | 2.0523 |     - |     - |    8629 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    200 |  2,264.3 ns |   5.76 ns |   4.50 ns |  1.00 |    0.00 | 2.0523 |     - |     - |    8600 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |    200 | 11,940.9 ns |  68.49 ns |  64.06 ns |  1.00 |    0.00 | 2.6703 |     - |     - |   11267 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    200 | 10,480.6 ns |  50.51 ns |  39.44 ns |  0.88 |    0.01 | 2.6703 |     - |     - |   11232 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |    200 |  1,652.5 ns |   8.98 ns |   7.96 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    200 |  1,435.9 ns |   6.09 ns |   5.69 ns |  0.87 |    0.01 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |    500 | 10,626.7 ns |  39.32 ns |  36.78 ns |  1.00 |    0.00 | 1.5411 |     - |     - |    6484 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    500 |  9,126.7 ns |  55.73 ns |  52.13 ns |  0.86 |    0.01 | 1.0834 |     - |     - |    4592 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |    500 |  1,763.3 ns |   8.71 ns |   8.15 ns |  1.00 |    0.00 | 1.7681 |     - |     - |    7423 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    500 |  1,779.5 ns |   9.19 ns |   7.68 ns |  1.01 |    0.01 | 1.7681 |     - |     - |    7400 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |    500 | 10,304.2 ns |  48.47 ns |  45.34 ns |  1.00 |    0.00 | 0.7172 |     - |     - |    3026 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    500 |  8,698.1 ns |  51.00 ns |  47.70 ns |  0.84 |    0.01 | 0.7172 |     - |     - |    3016 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |    500 |  1,392.8 ns |   6.82 ns |   6.38 ns |  1.00 |    0.00 | 1.2913 |     - |     - |    5424 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |    500 |  1,254.0 ns |   5.65 ns |   5.01 ns |  0.90 |    0.01 | 1.2913 |     - |     - |    5408 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |   1000 |  8,260.0 ns |  49.58 ns |  46.38 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     193 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |   1000 |  5,937.2 ns |  27.09 ns |  25.34 ns |  0.72 |    0.00 | 0.0381 |     - |     - |     168 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |   1000 |    628.9 ns |   1.29 ns |   1.20 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      80 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |   1000 |    630.3 ns |   2.43 ns |   2.15 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      80 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |   1000 |  7,668.6 ns |  26.25 ns |  23.27 ns |  1.00 |    0.00 | 0.0610 |     - |     - |     257 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |   1000 |  6,235.5 ns |  31.65 ns |  29.60 ns |  0.81 |    0.00 | 0.0610 |     - |     - |     256 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |   1000 |    625.1 ns |   2.73 ns |   2.55 ns |  1.00 |    0.00 | 0.0210 |     - |     - |      88 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |   1000 |    900.2 ns |   2.61 ns |   2.44 ns |  1.44 |    0.01 | 0.0210 |     - |     - |      88 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|               ArraySkipWhileToArray | Job-BZVGXF |      .NET 4.8 |        net48 |   2000 |  8,247.8 ns |  36.41 ns |  34.06 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     193 B |
|               ArraySkipWhileToArray | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |   2000 |  5,944.7 ns |  25.88 ns |  24.21 ns |  0.72 |    0.01 | 0.0381 |     - |     - |     168 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|      ArraySkipWhileToArrayRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |   2000 |    629.0 ns |   3.60 ns |   3.37 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      80 B |
|      ArraySkipWhileToArrayRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |   2000 |    629.6 ns |   3.11 ns |   2.91 ns |  1.00 |    0.01 | 0.0191 |     - |     - |      80 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
|          ArraySkipWhileToSimpleList | Job-BZVGXF |      .NET 4.8 |        net48 |   2000 |  7,660.7 ns |  32.90 ns |  30.77 ns |  1.00 |    0.00 | 0.0610 |     - |     - |     257 B |
|          ArraySkipWhileToSimpleList | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |   2000 |  6,226.2 ns |  29.36 ns |  27.46 ns |  0.81 |    0.00 | 0.0610 |     - |     - |     256 B |
|                                     |            |               |              |        |             |           |           |       |         |        |       |       |           |
| ArraySkipWhileToSimpleListRewritten | Job-BZVGXF |      .NET 4.8 |        net48 |   2000 |    626.1 ns |   2.89 ns |   2.56 ns |  1.00 |    0.00 | 0.0210 |     - |     - |      88 B |
| ArraySkipWhileToSimpleListRewritten | Job-ZQUWXJ | .NET Core 3.1 | netcoreapp31 |   2000 |    897.3 ns |   3.74 ns |   3.12 ns |  1.43 |    0.01 | 0.0210 |     - |     - |      88 B |