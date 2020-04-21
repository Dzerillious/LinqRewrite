|                                  Method |        Mean |      Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------- |------------:|-----------:|----------:|-------:|------:|------:|----------:|
|                         ArrayContains50 |    64.26 ns |   0.997 ns |  0.933 ns |      - |     - |     - |         - |
|                ArrayContains50Rewritten |    41.98 ns |   0.545 ns |  0.455 ns |      - |     - |     - |         - |
|               ArrayContains900Condition |   427.03 ns |   2.948 ns |  2.462 ns |      - |     - |     - |         - |
|      ArrayContains900ConditionRewritten |   507.72 ns |   5.385 ns |  5.037 ns |      - |     - |     - |         - |
|                     ArraySelectContains | 1,522.52 ns |  12.894 ns | 12.061 ns | 0.0076 |     - |     - |      36 B |
|            ArraySelectContainsRewritten |   121.22 ns |   1.699 ns |  1.590 ns |      - |     - |     - |         - |
|                      ArrayWhereContains | 6,498.42 ns | 100.829 ns | 94.315 ns | 0.0076 |     - |     - |      32 B |
|             ArrayWhereContainsRewritten |   580.57 ns |   6.883 ns |  6.102 ns |      - |     - |     - |         - |
|                   ArrayWhereContains900 | 5,868.33 ns |  74.496 ns | 62.207 ns | 0.0076 |     - |     - |      32 B |
|          ArrayWhereContains900Rewritten |   956.04 ns |  20.991 ns | 19.635 ns |      - |     - |     - |         - |
|          EnumerableContainsNotCondition | 6,819.05 ns |  95.973 ns | 89.773 ns |      - |     - |     - |      24 B |
| EnumerableContainsNotConditionRewritten | 4,136.36 ns |  67.178 ns | 62.839 ns |      - |     - |     - |      24 B |
|          EnumerableContainsAllCondition |   385.52 ns |   6.028 ns |  5.344 ns | 0.0057 |     - |     - |      24 B |
| EnumerableContainsAllConditionRewritten |   233.53 ns |   3.844 ns |  3.408 ns | 0.0057 |     - |     - |      24 B |