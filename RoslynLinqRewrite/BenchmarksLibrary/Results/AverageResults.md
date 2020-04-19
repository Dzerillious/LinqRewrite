|                              Method |         Mean |      Error |     StdDev |
|------------------------------------ |-------------:|-----------:|-----------:|
|                        RangeAverage | 3,160.764 ns | 34.3906 ns | 32.1690 ns |
|                 RangeAverageToArray |   555.360 ns |  4.0770 ns |  3.6141 ns |
|                       ArrayAverage5 |    89.737 ns |  1.0994 ns |  1.0284 ns |
|              ArrayAverage5Rewritten |     1.671 ns |  0.1175 ns |  0.0981 ns |
|                      ArrayAverage10 |   149.966 ns |  1.2370 ns |  1.0966 ns |
|             ArrayAverage10Rewritten |     2.681 ns |  0.1526 ns |  0.1353 ns |
|                 ArrayWhereAverage10 | 3,648.581 ns | 15.7476 ns | 13.9598 ns |
|          ArrayWhereAverageRewritten |   553.350 ns |  3.2918 ns |  2.7488 ns |
|                   EnumerableAverage | 3,471.250 ns | 22.4633 ns | 21.0122 ns |
|          EnumerableAverageRewritten | 3,006.325 ns | 14.7348 ns | 13.0620 ns |
|          EnumerableUncheckedAverage | 3,462.169 ns | 18.8938 ns | 17.6733 ns |
| EnumerableUncheckedAverageRewritten | 2,954.170 ns | 12.7333 ns |  9.9413 ns |