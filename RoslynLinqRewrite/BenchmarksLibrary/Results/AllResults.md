|                             Method |       Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------- |-----------:|----------:|----------:|-------:|------:|------:|----------:|
|                  ArrayAllCondition |  19.920 ns | 0.3619 ns | 0.3385 ns | 0.0048 |     - |     - |      20 B |
|         ArrayAllConditionRewritten |   1.121 ns | 0.0145 ns | 0.0136 ns |      - |     - |     - |         - |
|             ArrayWhereAllCondition | 318.050 ns | 4.7879 ns | 4.4786 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereAllConditionRewritten |  65.222 ns | 1.1171 ns | 1.0450 ns |      - |     - |     - |         - |
|             EnumerableAllCondition |  20.046 ns | 0.2090 ns | 0.1853 ns | 0.0057 |     - |     - |      24 B |
|    EnumerableAllConditionRewritten |  18.019 ns | 0.3249 ns | 0.3039 ns | 0.0057 |     - |     - |      24 B |
|          EnumerableAllNotCondition |  19.596 ns | 0.3561 ns | 0.3331 ns | 0.0057 |     - |     - |      24 B |
| EnumerableAllNotConditionRewritten |  18.040 ns | 0.3072 ns | 0.2723 ns | 0.0057 |     - |     - |      24 B |
|          EnumerableAllAllCondition |  19.886 ns | 0.2942 ns | 0.2608 ns | 0.0057 |     - |     - |      24 B |
| EnumerableAllAllConditionRewritten |  17.867 ns | 0.3246 ns | 0.3037 ns | 0.0057 |     - |     - |      24 B |