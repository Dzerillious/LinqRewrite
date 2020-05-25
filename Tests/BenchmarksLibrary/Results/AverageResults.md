|                              Method |        Job |       Runtime |    Toolchain |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |----------- |-------------- |------------- |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                        RangeAverage | Job-UPZPUJ |      .NET 4.8 |        net48 | 3,444.163 ns | 43.9174 ns | 38.9317 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|                        RangeAverage | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 | 2,705.639 ns | 53.1631 ns | 49.7288 ns |  0.78 |    0.02 | 0.0076 |     - |     - |      40 B |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
|                 RangeAverageToArray | Job-UPZPUJ |      .NET 4.8 |        net48 |   697.593 ns | 10.9645 ns |  9.7198 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 RangeAverageToArray | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 |   696.843 ns |  6.1063 ns |  5.7119 ns |  1.00 |    0.02 |      - |     - |     - |         - |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
|                       ArrayAverage5 | Job-UPZPUJ |      .NET 4.8 |        net48 |    85.099 ns |  1.6659 ns |  1.5583 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      96 B |
|                       ArrayAverage5 | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 |    88.025 ns |  1.5477 ns |  1.4477 ns |  1.03 |    0.03 | 0.0114 |     - |     - |      48 B |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
|              ArrayAverage5Rewritten | Job-UPZPUJ |      .NET 4.8 |        net48 |     1.512 ns |  0.0542 ns |  0.0507 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ArrayAverage5Rewritten | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 |     1.520 ns |  0.0515 ns |  0.0457 ns |  1.01 |    0.05 |      - |     - |     - |         - |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
|                      ArrayAverage10 | Job-UPZPUJ |      .NET 4.8 |        net48 |   147.238 ns |  2.7680 ns |  2.7185 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      96 B |
|                      ArrayAverage10 | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 |   137.201 ns |  2.6698 ns |  2.4974 ns |  0.93 |    0.02 | 0.0114 |     - |     - |      48 B |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
|             ArrayAverage10Rewritten | Job-UPZPUJ |      .NET 4.8 |        net48 |     2.730 ns |  0.0707 ns |  0.0661 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|             ArrayAverage10Rewritten | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 |     2.643 ns |  0.0685 ns |  0.0641 ns |  0.97 |    0.04 |      - |     - |     - |         - |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
|                 ArrayWhereAverage10 | Job-UPZPUJ |      .NET 4.8 |        net48 | 3,426.096 ns | 60.0293 ns | 56.1515 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|                 ArrayWhereAverage10 | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 | 3,264.495 ns | 58.0833 ns | 54.3311 ns |  0.95 |    0.03 | 0.0114 |     - |     - |      48 B |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
|          ArrayWhereAverageRewritten | Job-UPZPUJ |      .NET 4.8 |        net48 |   625.351 ns | 10.5587 ns |  9.8766 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ArrayWhereAverageRewritten | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 |   613.840 ns | 10.6869 ns |  9.9965 ns |  0.98 |    0.02 |      - |     - |     - |         - |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
|                   EnumerableAverage | Job-UPZPUJ |      .NET 4.8 |        net48 | 2,899.819 ns | 13.4505 ns | 11.2318 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|                   EnumerableAverage | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 | 2,957.524 ns | 50.9242 ns | 47.6345 ns |  1.02 |    0.02 | 0.0076 |     - |     - |      32 B |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
|          EnumerableAverageRewritten | Job-UPZPUJ |      .NET 4.8 |        net48 | 3,296.014 ns | 58.8426 ns | 55.0414 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableAverageRewritten | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 | 2,783.142 ns | 45.4670 ns | 42.5299 ns |  0.84 |    0.02 | 0.0076 |     - |     - |      32 B |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
|          EnumerableUncheckedAverage | Job-UPZPUJ |      .NET 4.8 |        net48 | 2,984.333 ns | 27.1291 ns | 25.3765 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableUncheckedAverage | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 | 2,975.151 ns | 42.6345 ns | 39.8804 ns |  1.00 |    0.02 | 0.0076 |     - |     - |      32 B |
|                                     |            |               |              |              |            |            |       |         |        |       |       |           |
| EnumerableUncheckedAverageRewritten | Job-UPZPUJ |      .NET 4.8 |        net48 | 2,785.091 ns | 47.1108 ns | 44.0675 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
| EnumerableUncheckedAverageRewritten | Job-OEOHOH | .NET Core 3.1 | netcoreapp31 | 2,775.684 ns | 50.7868 ns | 47.5060 ns |  1.00 |    0.03 | 0.0076 |     - |     - |      32 B |