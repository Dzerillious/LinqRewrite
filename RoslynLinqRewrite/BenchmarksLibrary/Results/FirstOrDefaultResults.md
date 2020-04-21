|                                        Method |          Mean |      Error |     StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |--------------:|-----------:|-----------:|-------:|------:|------:|----------:|
|                           ArrayFirstOrDefault |    36.0484 ns |  0.4412 ns |  0.4127 ns |      - |     - |     - |         - |
|                  ArrayFirstOrDefaultRewritten |     0.1258 ns |  0.0238 ns |  0.0222 ns |      - |     - |     - |         - |
|                  ArrayFirstOrDefaultCondition |    46.4658 ns |  0.5000 ns |  0.4677 ns | 0.0048 |     - |     - |      20 B |
|         ArrayFirstOrDefaultConditionRewritten |     4.9037 ns |  0.0727 ns |  0.0680 ns |      - |     - |     - |         - |
|                     ArraySelectFirstOrDefault |    42.4575 ns |  0.8396 ns |  0.7853 ns | 0.0086 |     - |     - |      36 B |
|            ArraySelectFirstOrDefaultRewritten |     0.1035 ns |  0.0171 ns |  0.0152 ns |      - |     - |     - |         - |
|                      ArrayWhereFirstOrDefault |   334.7900 ns |  4.4881 ns |  4.1981 ns | 0.0076 |     - |     - |      32 B |
|             ArrayWhereFirstOrDefaultRewritten |    91.9534 ns |  1.3320 ns |  1.2460 ns |      - |     - |     - |         - |
|             ArrayWhereFirstOrDefaultCondition | 1,085.5587 ns | 15.6336 ns | 14.6237 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereFirstOrDefaultConditionRewritten |   172.1460 ns |  2.5529 ns |  3.4944 ns |      - |     - |     - |         - |
|             EnumerableFirstOrDefaultCondition |    46.0420 ns |  0.4961 ns |  0.4640 ns | 0.0057 |     - |     - |      24 B |
|    EnumerableFirstOrDefaultConditionRewritten |    42.8853 ns |  0.2342 ns |  0.2076 ns | 0.0057 |     - |     - |      24 B |
|          EnumerableFirstOrDefaultNotCondition | 5,470.1039 ns | 62.5557 ns | 58.5146 ns |      - |     - |     - |      24 B |
| EnumerableFirstOrDefaultNotConditionRewritten | 4,978.0935 ns | 61.9138 ns | 57.9142 ns |      - |     - |     - |      24 B |
|          EnumerableFirstOrDefaultAllCondition |    28.8711 ns |  0.2690 ns |  0.2246 ns | 0.0057 |     - |     - |      24 B |
| EnumerableFirstOrDefaultAllConditionRewritten |    26.4180 ns |  0.2264 ns |  0.2118 ns | 0.0057 |     - |     - |      24 B |