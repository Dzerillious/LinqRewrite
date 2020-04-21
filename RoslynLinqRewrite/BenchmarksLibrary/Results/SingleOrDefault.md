|                                         Method |       Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------------- |-----------:|----------:|----------:|-------:|------:|------:|----------:|
|                           ArraySingleOrDefault | 35.1656 ns | 0.5472 ns | 0.4851 ns |      - |     - |     - |         - |
|                  ArraySingleOrDefaultRewritten |  0.4095 ns | 0.0277 ns | 0.0259 ns |      - |     - |     - |         - |
|                  ArraySingleOrDefaultCondition | 24.0439 ns | 0.2244 ns | 0.1989 ns | 0.0048 |     - |     - |      20 B |
|         ArraySingleOrDefaultConditionRewritten |  2.1535 ns | 0.0335 ns | 0.0297 ns |      - |     - |     - |         - |
|                     ArraySelectSingleOrDefault | 46.0163 ns | 0.5313 ns | 0.4970 ns | 0.0086 |     - |     - |      36 B |
|            ArraySelectSingleOrDefaultRewritten |  0.4320 ns | 0.0229 ns | 0.0214 ns |      - |     - |     - |         - |
|                      ArrayWhereSingleOrDefault | 45.5129 ns | 0.6396 ns | 0.5983 ns | 0.0076 |     - |     - |      32 B |
|             ArrayWhereSingleOrDefaultRewritten |  2.1116 ns | 0.0471 ns | 0.0441 ns |      - |     - |     - |         - |
|             ArrayWhereSingleOrDefaultCondition | 43.4119 ns | 0.4965 ns | 0.4644 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereSingleOrDefaultConditionRewritten |  2.1548 ns | 0.0402 ns | 0.0336 ns |      - |     - |     - |         - |
|             EnumerableSingleOrDefaultCondition | 24.6020 ns | 0.3106 ns | 0.2753 ns | 0.0057 |     - |     - |      24 B |
|    EnumerableSingleOrDefaultConditionRewritten | 24.8458 ns | 0.2744 ns | 0.2432 ns | 0.0057 |     - |     - |      24 B |
|          EnumerableSingleOrDefaultNotCondition | 24.7830 ns | 0.3928 ns | 0.3674 ns | 0.0057 |     - |     - |      24 B |
| EnumerableSingleOrDefaultNotConditionRewritten | 23.1939 ns | 0.3977 ns | 0.3720 ns | 0.0057 |     - |     - |      24 B |