|                              Method |         Mean |      Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------:|-----------:|------------:|-------:|------:|------:|----------:|
|                        RangeAverage | 2,963.650 ns | 35.3871 ns |  31.3697 ns | 0.0076 |     - |     - |      40 B |
|                 RangeAverageToArray |   520.900 ns |  9.1796 ns |   7.6654 ns |      - |     - |     - |         - |
|                       ArrayAverage5 |    83.126 ns |  1.6104 ns |   1.5064 ns | 0.0143 |     - |     - |      60 B |
|              ArrayAverage5Rewritten |     1.630 ns |  0.0345 ns |   0.0306 ns |      - |     - |     - |         - |
|                      ArrayAverage10 |   138.764 ns |  2.3767 ns |   2.2232 ns | 0.0143 |     - |     - |      60 B |
|             ArrayAverage10Rewritten |     2.394 ns |  0.2216 ns |   0.1850 ns |      - |     - |     - |         - |
|                 ArrayWhereAverage10 | 3,391.796 ns | 57.4268 ns |  53.7171 ns | 0.0076 |     - |     - |      32 B |
|          ArrayWhereAverageRewritten |   518.578 ns |  8.1229 ns |   7.5981 ns |      - |     - |     - |         - |
|                   EnumerableAverage | 3,227.364 ns | 30.2057 ns |  28.2544 ns | 0.0038 |     - |     - |      24 B |
|          EnumerableAverageRewritten | 2,788.072 ns | 41.7491 ns |  39.0521 ns | 0.0038 |     - |     - |      24 B |
|          EnumerableUncheckedAverage | 3,296.718 ns | 84.3929 ns | 100.4637 ns | 0.0038 |     - |     - |      24 B |
| EnumerableUncheckedAverageRewritten | 2,724.930 ns | 39.9005 ns |  37.3229 ns | 0.0038 |     - |     - |      24 B |