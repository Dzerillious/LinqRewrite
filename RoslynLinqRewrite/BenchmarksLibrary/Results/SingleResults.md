|                                Method |       Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |-----------:|----------:|----------:|-------:|------:|------:|----------:|
|                           ArraySingle | 34.9697 ns | 0.4149 ns | 0.3881 ns |      - |     - |     - |         - |
|                  ArraySingleRewritten |  0.2041 ns | 0.0313 ns | 0.0293 ns |      - |     - |     - |         - |
|                  ArraySingleCondition | 23.6519 ns | 0.2284 ns | 0.2137 ns | 0.0048 |     - |     - |      20 B |
|         ArraySingleConditionRewritten |  1.8330 ns | 0.0318 ns | 0.0298 ns |      - |     - |     - |         - |
|                     ArraySelectSingle | 46.8659 ns | 0.5878 ns | 0.5498 ns | 0.0086 |     - |     - |      36 B |
|            ArraySelectSingleRewritten |  0.4484 ns | 0.0184 ns | 0.0154 ns |      - |     - |     - |         - |
|                      ArrayWhereSingle | 45.9019 ns | 0.5900 ns | 0.5519 ns | 0.0076 |     - |     - |      32 B |
|             ArrayWhereSingleRewritten |  1.8285 ns | 0.0460 ns | 0.0431 ns |      - |     - |     - |         - |
|             ArrayWhereSingleCondition | 42.7750 ns | 0.6723 ns | 0.5960 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereSingleConditionRewritten |  1.9621 ns | 0.0395 ns | 0.0369 ns |      - |     - |     - |         - |
|             EnumerableSingleCondition | 24.2914 ns | 0.3647 ns | 0.3412 ns | 0.0057 |     - |     - |      24 B |
|    EnumerableSingleConditionRewritten | 24.6937 ns | 0.2392 ns | 0.1998 ns | 0.0057 |     - |     - |      24 B |
|          EnumerableSingleNotCondition |         NA |        NA |        NA |      - |     - |     - |         - |
| EnumerableSingleNotConditionRewritten |         NA |        NA |        NA |      - |     - |     - |         - |