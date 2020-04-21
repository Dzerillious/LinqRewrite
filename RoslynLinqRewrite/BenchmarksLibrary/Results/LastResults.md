|                              Method |          Mean |      Error |     StdDev |        Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |--------------:|-----------:|-----------:|--------------:|-------:|------:|------:|----------:|
|                           ArrayLast |    35.8971 ns |  0.3115 ns |  0.2914 ns |    35.9888 ns |      - |     - |     - |         - |
|                  ArrayLastRewritten |     0.0017 ns |  0.0055 ns |  0.0052 ns |     0.0000 ns |      - |     - |     - |         - |
|                  ArrayLastCondition | 5,722.5597 ns | 84.1457 ns | 78.7099 ns | 5,725.3132 ns |      - |     - |     - |      20 B |
|         ArrayLastConditionRewritten |   559.1139 ns |  7.0561 ns |  6.6003 ns |   562.6087 ns |      - |     - |     - |         - |
|                     ArraySelectLast | 5,671.6662 ns | 37.8040 ns | 33.5122 ns | 5,676.6087 ns | 0.0076 |     - |     - |      36 B |
|            ArraySelectLastRewritten |     0.0884 ns |  0.0182 ns |  0.0170 ns |     0.0898 ns |      - |     - |     - |         - |
|                      ArrayWhereLast | 5,079.3659 ns | 60.9553 ns | 57.0176 ns | 5,060.6297 ns | 0.0076 |     - |     - |      32 B |
|             ArrayWhereLastRewritten |   605.3821 ns |  4.5796 ns |  4.2837 ns |   605.2052 ns |      - |     - |     - |         - |
|             ArrayWhereLastCondition | 6,764.8432 ns | 68.8582 ns | 64.4100 ns | 6,743.9465 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereLastConditionRewritten |   657.8110 ns |  5.5886 ns |  4.9541 ns |   658.5941 ns |      - |     - |     - |         - |
|             EnumerableLastCondition | 5,798.6705 ns | 76.2563 ns | 63.6774 ns | 5,774.1013 ns |      - |     - |     - |      24 B |
|    EnumerableLastConditionRewritten | 5,306.2133 ns | 70.0429 ns | 65.5182 ns | 5,327.3041 ns |      - |     - |     - |      24 B |
|          EnumerableLastNotCondition |            NA |         NA |         NA |            NA |      - |     - |     - |         - |
| EnumerableLastNotConditionRewritten |            NA |         NA |         NA |            NA |      - |     - |     - |         - |
|          EnumerableLastAllCondition | 5,827.0221 ns | 54.6771 ns | 51.1450 ns | 5,839.0537 ns |      - |     - |     - |      24 B |
| EnumerableLastAllConditionRewritten | 5,295.8104 ns | 78.0247 ns | 72.9844 ns | 5,304.8687 ns |      - |     - |     - |      24 B |