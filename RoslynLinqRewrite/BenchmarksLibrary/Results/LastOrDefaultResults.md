|                                       Method |          Mean |       Error |     StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------------- |--------------:|------------:|-----------:|-------:|------:|------:|----------:|
|                           ArrayLastOrDefault |    35.9533 ns |   0.3010 ns |  0.2514 ns |      - |     - |     - |         - |
|                  ArrayLastOrDefaultRewritten |     0.1061 ns |   0.0114 ns |  0.0106 ns |      - |     - |     - |         - |
|                  ArrayLastOrDefaultCondition | 5,821.9655 ns |  85.6726 ns | 80.1382 ns |      - |     - |     - |      20 B |
|         ArrayLastOrDefaultConditionRewritten |   562.9855 ns |   3.8248 ns |  3.5777 ns |      - |     - |     - |         - |
|                     ArraySelectLastOrDefault | 5,881.6574 ns |  63.3663 ns | 59.2729 ns | 0.0076 |     - |     - |      36 B |
|            ArraySelectLastOrDefaultRewritten |     0.1026 ns |   0.0190 ns |  0.0148 ns |      - |     - |     - |         - |
|                      ArrayWhereLastOrDefault | 4,990.0145 ns |  75.9215 ns | 71.0171 ns | 0.0076 |     - |     - |      32 B |
|             ArrayWhereLastOrDefaultRewritten |   593.4689 ns |   7.5098 ns |  7.0247 ns |      - |     - |     - |         - |
|             ArrayWhereLastOrDefaultCondition | 6,798.4361 ns | 100.1996 ns | 93.7268 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereLastOrDefaultConditionRewritten |   680.1503 ns |   6.7771 ns |  6.3393 ns |      - |     - |     - |         - |
|             EnumerableLastOrDefaultCondition | 5,684.7757 ns | 100.8000 ns | 94.2883 ns |      - |     - |     - |      24 B |
|    EnumerableLastOrDefaultConditionRewritten | 5,832.8033 ns |  69.2854 ns | 64.8096 ns |      - |     - |     - |      24 B |
|          EnumerableLastOrDefaultNotCondition | 5,884.9659 ns |  71.8795 ns | 67.2361 ns |      - |     - |     - |      24 B |
| EnumerableLastOrDefaultNotConditionRewritten | 4,445.6717 ns |  69.0263 ns | 64.5673 ns |      - |     - |     - |      24 B |
|          EnumerableLastOrDefaultAllCondition | 5,685.3053 ns |  63.4159 ns | 52.9551 ns |      - |     - |     - |      24 B |
| EnumerableLastOrDefaultAllConditionRewritten | 5,832.1490 ns |  56.4348 ns | 50.0280 ns |      - |     - |     - |      24 B |