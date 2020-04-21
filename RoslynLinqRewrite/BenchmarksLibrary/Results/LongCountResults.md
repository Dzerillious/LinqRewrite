|                                   Method |          Mean |      Error |     StdDev |        Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------- |--------------:|-----------:|-----------:|--------------:|-------:|------:|------:|----------:|
|                           ArrayLongCount | 2,262.9363 ns | 39.3418 ns | 36.8004 ns | 2,264.2813 ns | 0.0038 |     - |     - |      20 B |
|                  ArrayLongCountRewritten |     0.0085 ns |  0.0197 ns |  0.0184 ns |     0.0000 ns |      - |     - |     - |         - |
|                  ArrayLongCountCondition | 5,650.6091 ns | 86.8232 ns | 76.9665 ns | 5,675.8034 ns |      - |     - |     - |      20 B |
|         ArrayLongCountConditionRewritten |   478.7053 ns | 24.3402 ns | 22.7678 ns |   485.0658 ns |      - |     - |     - |         - |
|                     ArraySelectLongCount | 4,190.1227 ns | 53.4960 ns | 50.0402 ns | 4,193.5322 ns | 0.0076 |     - |     - |      36 B |
|            ArraySelectLongCountRewritten |     0.0493 ns |  0.0785 ns |  0.0734 ns |     0.0107 ns |      - |     - |     - |         - |
|                      ArrayWhereLongCount | 3,576.9778 ns | 41.8969 ns | 39.1904 ns | 3,597.4541 ns | 0.0076 |     - |     - |      32 B |
|             ArrayWhereLongCountRewritten |   623.3263 ns |  6.4237 ns |  6.0088 ns |   626.6725 ns |      - |     - |     - |         - |
|             ArrayWhereLongCountCondition | 6,325.7790 ns | 74.5159 ns | 69.7022 ns | 6,357.8697 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereLongCountConditionRewritten |   857.0002 ns |  8.2160 ns |  7.2833 ns |   860.0282 ns |      - |     - |     - |         - |
|             EnumerableLongCountCondition | 5,853.6039 ns | 95.3770 ns | 79.6441 ns | 5,880.9555 ns |      - |     - |     - |      24 B |
|    EnumerableLongCountConditionRewritten | 3,928.3018 ns | 29.0628 ns | 24.2687 ns | 3,934.8251 ns |      - |     - |     - |      24 B |
|          EnumerableLongCountNotCondition | 5,837.1717 ns | 54.2639 ns | 48.1035 ns | 5,855.7201 ns |      - |     - |     - |      24 B |
| EnumerableLongCountNotConditionRewritten | 3,888.7412 ns | 53.4762 ns | 50.0217 ns | 3,893.8175 ns |      - |     - |     - |      24 B |
|          EnumerableLongCountAllCondition | 5,772.2343 ns | 55.2835 ns | 46.1642 ns | 5,766.0255 ns |      - |     - |     - |      24 B |
| EnumerableLongCountAllConditionRewritten | 3,885.8384 ns | 51.1508 ns | 47.8465 ns | 3,906.9859 ns |      - |     - |     - |      24 B |