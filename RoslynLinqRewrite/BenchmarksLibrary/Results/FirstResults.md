|                               Method |          Mean |      Error |    StdDev |        Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------- |--------------:|-----------:|----------:|--------------:|-------:|------:|------:|----------:|
|                           ArrayFirst |    35.4141 ns |  0.4222 ns | 0.3949 ns |    35.4706 ns |      - |     - |     - |         - |
|                  ArrayFirstRewritten |     0.0100 ns |  0.0056 ns | 0.0047 ns |     0.0086 ns |      - |     - |     - |         - |
|                  ArrayFirstCondition |    46.1100 ns |  0.4155 ns | 0.3886 ns |    46.1798 ns | 0.0048 |     - |     - |      20 B |
|         ArrayFirstConditionRewritten |     4.9004 ns |  0.0420 ns | 0.0393 ns |     4.8919 ns |      - |     - |     - |         - |
|                     ArraySelectFirst |    42.5719 ns |  0.4006 ns | 0.3747 ns |    42.6635 ns | 0.0086 |     - |     - |      36 B |
|            ArraySelectFirstRewritten |     0.0023 ns |  0.0038 ns | 0.0035 ns |     0.0000 ns |      - |     - |     - |         - |
|                      ArrayWhereFirst |   304.8009 ns |  2.4474 ns | 2.2893 ns |   303.9936 ns | 0.0076 |     - |     - |      32 B |
|             ArrayWhereFirstRewritten |    91.9108 ns |  0.9268 ns | 0.8670 ns |    92.0767 ns |      - |     - |     - |         - |
|             ArrayWhereFirstCondition | 1,044.9438 ns | 10.1209 ns | 9.4671 ns | 1,046.5311 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereFirstConditionRewritten |   204.9888 ns |  3.9849 ns | 3.9137 ns |   205.2108 ns |      - |     - |     - |         - |
|             EnumerableFirstCondition |    48.0865 ns |  0.4257 ns | 0.3982 ns |    48.2290 ns | 0.0057 |     - |     - |      24 B |
|    EnumerableFirstConditionRewritten |    39.4829 ns |  0.3455 ns | 0.3232 ns |    39.4861 ns | 0.0057 |     - |     - |      24 B |
|          EnumerableFirstNotCondition |            NA |         NA |        NA |            NA |      - |     - |     - |         - |
| EnumerableFirstNotConditionRewritten |            NA |         NA |        NA |            NA |      - |     - |     - |         - |
|          EnumerableFirstAllCondition |    29.2819 ns |  0.2712 ns | 0.2537 ns |    29.3207 ns | 0.0057 |     - |     - |      24 B |
| EnumerableFirstAllConditionRewritten |    26.4992 ns |  0.2120 ns | 0.1983 ns |    26.5280 ns | 0.0057 |     - |     - |      24 B |