|                                   Method |        Job |       Runtime |    Toolchain |          Mean |      Error |     StdDev |        Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------- |----------- |-------------- |------------- |--------------:|-----------:|-----------:|--------------:|------:|--------:|-------:|------:|------:|----------:|
|                           ArrayLongCount | Job-ATTYZI |      .NET 4.8 |        net48 | 2,798.4010 ns |  8.7301 ns |  7.2900 ns | 2,797.6633 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|                           ArrayLongCount | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 2,373.2238 ns | 12.3413 ns | 11.5441 ns | 2,377.1442 ns |  0.85 |    0.00 | 0.0076 |     - |     - |      32 B |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|                  ArrayLongCountRewritten | Job-ATTYZI |      .NET 4.8 |        net48 |     0.0003 ns |  0.0008 ns |  0.0007 ns |     0.0000 ns |     ? |       ? |      - |     - |     - |         - |
|                  ArrayLongCountRewritten | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 |     0.0087 ns |  0.0059 ns |  0.0055 ns |     0.0079 ns |     ? |       ? |      - |     - |     - |         - |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|                  ArrayLongCountCondition | Job-ATTYZI |      .NET 4.8 |        net48 | 6,694.3142 ns | 28.0785 ns | 24.8909 ns | 6,697.9877 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|                  ArrayLongCountCondition | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 5,851.1009 ns | 30.4012 ns | 25.3863 ns | 5,850.8842 ns |  0.87 |    0.00 | 0.0076 |     - |     - |      32 B |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|         ArrayLongCountConditionRewritten | Job-ATTYZI |      .NET 4.8 |        net48 |   589.6925 ns |  1.8977 ns |  1.6823 ns |   589.7724 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|         ArrayLongCountConditionRewritten | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 |   589.6175 ns |  2.6845 ns |  2.0958 ns |   589.8783 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|                     ArraySelectLongCount | Job-ATTYZI |      .NET 4.8 |        net48 | 4,963.0193 ns | 19.9924 ns | 18.7009 ns | 4,966.0851 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      56 B |
|                     ArraySelectLongCount | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 4,745.3269 ns | 38.9787 ns | 36.4607 ns | 4,729.6940 ns |  0.96 |    0.01 | 0.0076 |     - |     - |      48 B |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|            ArraySelectLongCountRewritten | Job-ATTYZI |      .NET 4.8 |        net48 |     0.0000 ns |  0.0000 ns |  0.0000 ns |     0.0000 ns |     ? |       ? |      - |     - |     - |         - |
|            ArraySelectLongCountRewritten | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 |     0.0015 ns |  0.0025 ns |  0.0021 ns |     0.0002 ns |     ? |       ? |      - |     - |     - |         - |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|                      ArrayWhereLongCount | Job-ATTYZI |      .NET 4.8 |        net48 | 4,450.8390 ns | 15.9306 ns | 12.4375 ns | 4,451.1730 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      48 B |
|                      ArrayWhereLongCount | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 4,208.3421 ns | 22.9881 ns | 21.5031 ns | 4,206.3889 ns |  0.95 |    0.00 | 0.0076 |     - |     - |      48 B |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|             ArrayWhereLongCountRewritten | Job-ATTYZI |      .NET 4.8 |        net48 |   643.6327 ns |  1.5381 ns |  1.4388 ns |   643.6509 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|             ArrayWhereLongCountRewritten | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 |   645.9490 ns |  1.8856 ns |  1.6715 ns |   646.0511 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|             ArrayWhereLongCountCondition | Job-ATTYZI |      .NET 4.8 |        net48 | 7,140.7764 ns | 27.3828 ns | 21.3787 ns | 7,145.7439 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      48 B |
|             ArrayWhereLongCountCondition | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 7,364.9713 ns | 41.2522 ns | 36.5690 ns | 7,353.6308 ns |  1.03 |    0.00 | 0.0076 |     - |     - |      48 B |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|    ArrayWhereLongCountConditionRewritten | Job-ATTYZI |      .NET 4.8 |        net48 |   697.0069 ns |  2.6023 ns |  2.4342 ns |   697.6380 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|    ArrayWhereLongCountConditionRewritten | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 |   622.9010 ns |  1.7884 ns |  1.6729 ns |   622.8264 ns |  0.89 |    0.00 |      - |     - |     - |         - |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|             EnumerableLongCountCondition | Job-ATTYZI |      .NET 4.8 |        net48 | 6,376.9725 ns | 22.8768 ns | 17.8607 ns | 6,377.8725 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|             EnumerableLongCountCondition | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 6,423.2227 ns | 28.3605 ns | 25.1408 ns | 6,418.0984 ns |  1.01 |    0.00 | 0.0076 |     - |     - |      32 B |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|    EnumerableLongCountConditionRewritten | Job-ATTYZI |      .NET 4.8 |        net48 | 5,507.7889 ns | 19.8944 ns | 16.6127 ns | 5,509.0908 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|    EnumerableLongCountConditionRewritten | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 4,988.2160 ns | 14.5994 ns | 12.9420 ns | 4,989.8453 ns |  0.91 |    0.00 | 0.0076 |     - |     - |      32 B |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|          EnumerableLongCountNotCondition | Job-ATTYZI |      .NET 4.8 |        net48 | 6,985.8786 ns | 28.2082 ns | 26.3860 ns | 6,990.9492 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableLongCountNotCondition | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 6,877.7871 ns | 40.4038 ns | 35.8169 ns | 6,878.6369 ns |  0.99 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
| EnumerableLongCountNotConditionRewritten | Job-ATTYZI |      .NET 4.8 |        net48 | 5,525.1520 ns | 26.1403 ns | 23.1727 ns | 5,526.8452 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
| EnumerableLongCountNotConditionRewritten | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 4,970.0804 ns | 12.2585 ns | 10.2364 ns | 4,967.3115 ns |  0.90 |    0.00 | 0.0076 |     - |     - |      32 B |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
|          EnumerableLongCountAllCondition | Job-ATTYZI |      .NET 4.8 |        net48 | 6,698.9622 ns | 24.9009 ns | 20.7934 ns | 6,697.6337 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableLongCountAllCondition | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 6,774.1408 ns | 51.2153 ns | 47.9068 ns | 6,757.4074 ns |  1.01 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                          |            |               |              |               |            |            |               |       |         |        |       |       |           |
| EnumerableLongCountAllConditionRewritten | Job-ATTYZI |      .NET 4.8 |        net48 | 5,516.9389 ns | 15.2478 ns | 12.7326 ns | 5,520.0043 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
| EnumerableLongCountAllConditionRewritten | Job-NKDXTN | .NET Core 3.1 | netcoreapp31 | 4,684.0780 ns | 15.5291 ns | 12.9675 ns | 4,687.6312 ns |  0.85 |    0.00 | 0.0076 |     - |     - |      32 B |