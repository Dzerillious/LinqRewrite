|                         Method |        Job |       Runtime |    Toolchain |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |----------- |-------------- |------------- |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                 RangeAggregate | Job-STXZOS |      .NET 4.8 |        net48 | 4,377.2489 ns | 71.7760 ns | 63.6275 ns | 1.00 |    0.00 | 0.0076 |     - |     - |      48 B |
|                 RangeAggregate | Job-LQJVDY | .NET Core 3.1 | netcoreapp31 | 3,567.6497 ns | 64.2638 ns | 60.1124 ns | 0.81 |    0.02 | 0.0076 |     - |     - |      40 B |
|                                |            |               |              |               |            |            |      |         |        |       |       |           |
|        RangeAggregateRewritten | Job-STXZOS |      .NET 4.8 |        net48 |   559.2316 ns | 10.9890 ns | 13.4955 ns | 1.00 |    0.00 |      - |     - |     - |         - |
|        RangeAggregateRewritten | Job-LQJVDY | .NET Core 3.1 | netcoreapp31 |   520.2760 ns |  8.7112 ns |  8.1484 ns | 0.93 |    0.03 |      - |     - |     - |         - |
|                                |            |               |              |               |            |            |      |         |        |       |       |           |
|                ArrayAggregate5 | Job-STXZOS |      .NET 4.8 |        net48 |    88.4570 ns |  1.6215 ns |  1.4374 ns | 1.00 |    0.00 | 0.0229 |     - |     - |      96 B |
|                ArrayAggregate5 | Job-LQJVDY | .NET Core 3.1 | netcoreapp31 |    96.3980 ns |  1.2436 ns |  1.0384 ns | 1.09 |    0.02 | 0.0114 |     - |     - |      48 B |
|                                |            |               |              |               |            |            |      |         |        |       |       |           |
|       ArrayAggregate5Rewritten | Job-STXZOS |      .NET 4.8 |        net48 |     0.9614 ns |  0.0496 ns |  0.0509 ns | 1.00 |    0.00 |      - |     - |     - |         - |
|       ArrayAggregate5Rewritten | Job-LQJVDY | .NET Core 3.1 | netcoreapp31 |     1.0096 ns |  0.0370 ns |  0.0328 ns | 1.05 |    0.07 |      - |     - |     - |         - |
|                                |            |               |              |               |            |            |      |         |        |       |       |           |
|               ArrayAggregate10 | Job-STXZOS |      .NET 4.8 |        net48 |   156.2676 ns |  2.8113 ns |  2.6296 ns | 1.00 |    0.00 | 0.0229 |     - |     - |      96 B |
|               ArrayAggregate10 | Job-LQJVDY | .NET Core 3.1 | netcoreapp31 |   143.8560 ns |  0.5919 ns |  0.5536 ns | 0.92 |    0.02 | 0.0114 |     - |     - |      48 B |
|                                |            |               |              |               |            |            |      |         |        |       |       |           |
|      ArrayAggregate10Rewritten | Job-STXZOS |      .NET 4.8 |        net48 |     1.8411 ns |  0.0595 ns |  0.0556 ns | 1.00 |    0.00 |      - |     - |     - |         - |
|      ArrayAggregate10Rewritten | Job-LQJVDY | .NET Core 3.1 | netcoreapp31 |     1.8222 ns |  0.0605 ns |  0.0566 ns | 0.99 |    0.04 |      - |     - |     - |         - |
|                                |            |               |              |               |            |            |      |         |        |       |       |           |
|          ArrayWhereAggregate10 | Job-STXZOS |      .NET 4.8 |        net48 | 4,362.5538 ns | 60.0532 ns | 56.1738 ns | 1.00 |    0.00 | 0.0076 |     - |     - |      48 B |
|          ArrayWhereAggregate10 | Job-LQJVDY | .NET Core 3.1 | netcoreapp31 | 4,105.5161 ns | 45.3248 ns | 37.8483 ns | 0.94 |    0.01 | 0.0076 |     - |     - |      48 B |
|                                |            |               |              |               |            |            |      |         |        |       |       |           |
|   ArrayWhereAggregateRewritten | Job-STXZOS |      .NET 4.8 |        net48 |   498.9397 ns |  8.9272 ns |  8.3505 ns | 1.00 |    0.00 |      - |     - |     - |         - |
|   ArrayWhereAggregateRewritten | Job-LQJVDY | .NET Core 3.1 | netcoreapp31 |   612.8470 ns |  9.0413 ns |  8.4572 ns | 1.23 |    0.03 |      - |     - |     - |         - |
|                                |            |               |              |               |            |            |      |         |        |       |       |           |
|            EnumerableAggregate | Job-STXZOS |      .NET 4.8 |        net48 | 3,963.8744 ns | 66.9193 ns | 62.5963 ns | 1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|            EnumerableAggregate | Job-LQJVDY | .NET Core 3.1 | netcoreapp31 | 4,049.2663 ns | 80.1552 ns | 74.9772 ns | 1.02 |    0.02 | 0.0076 |     - |     - |      32 B |
|                                |            |               |              |               |            |            |      |         |        |       |       |           |
|   EnumerableAggregateRewritten | Job-STXZOS |      .NET 4.8 |        net48 | 3,465.6146 ns | 34.0595 ns | 31.8593 ns | 1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|   EnumerableAggregateRewritten | Job-LQJVDY | .NET Core 3.1 | netcoreapp31 | 3,868.5870 ns | 77.1770 ns | 72.1914 ns | 1.12 |    0.02 | 0.0076 |     - |     - |      32 B |