|                             Method |          Mean |       Error |      StdDev |        Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------- |--------------:|------------:|------------:|--------------:|-------:|------:|------:|----------:|
|                           ArrayAny |    16.9141 ns |   0.2112 ns |   0.1976 ns |    16.9359 ns | 0.0048 |     - |     - |      20 B |
|                  ArrayAnyRewritten |     0.0034 ns |   0.0051 ns |   0.0045 ns |     0.0013 ns |      - |     - |     - |         - |
|                  ArrayAnyCondition |    42.0673 ns |   0.7236 ns |   0.6769 ns |    42.3674 ns | 0.0048 |     - |     - |      20 B |
|         ArrayAnyConditionRewritten |     3.5589 ns |   0.0906 ns |   0.0847 ns |     3.6021 ns |      - |     - |     - |         - |
|                     ArraySelectAny |    34.3967 ns |   0.7191 ns |   0.7063 ns |    34.5222 ns | 0.0086 |     - |     - |      36 B |
|            ArraySelectAnyRewritten |     0.0000 ns |   0.0000 ns |   0.0000 ns |     0.0000 ns |      - |     - |     - |         - |
|                      ArrayWhereAny |   281.9452 ns |   5.5784 ns |   7.2534 ns |   285.8863 ns | 0.0076 |     - |     - |      32 B |
|             ArrayWhereAnyRewritten |    67.3179 ns |   1.0885 ns |   0.9649 ns |    67.6527 ns |      - |     - |     - |         - |
|             ArrayWhereAnyCondition | 1,016.1013 ns |  19.3851 ns |  19.0388 ns | 1,006.3563 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereAnyConditionRewritten |   165.2055 ns |   1.6901 ns |   1.4982 ns |   165.6926 ns |      - |     - |     - |         - |
|             EnumerableAnyCondition |    43.4569 ns |   0.7915 ns |   0.7404 ns |    43.8155 ns | 0.0057 |     - |     - |      24 B |
|    EnumerableAnyConditionRewritten |    35.7233 ns |   0.7304 ns |   0.6833 ns |    36.0458 ns | 0.0057 |     - |     - |      24 B |
|          EnumerableAnyNotCondition | 5,242.7982 ns | 101.0011 ns | 120.2347 ns | 5,250.2865 ns |      - |     - |     - |      24 B |
| EnumerableAnyNotConditionRewritten | 3,978.9423 ns |  66.3776 ns |  62.0896 ns | 4,002.0958 ns |      - |     - |     - |      24 B |
|          EnumerableAnyAllCondition |    26.8917 ns |   0.4731 ns |   0.4425 ns |    27.1768 ns | 0.0057 |     - |     - |      24 B |
| EnumerableAnyAllConditionRewritten |    23.2151 ns |   0.4871 ns |   0.5002 ns |    22.8780 ns | 0.0057 |     - |     - |      24 B |