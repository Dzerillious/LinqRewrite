|                               Method |          Mean |       Error |      StdDev |        Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------- |--------------:|------------:|------------:|--------------:|-------:|------:|------:|----------:|
|                           ArrayCount |    33.0144 ns |   0.6708 ns |   0.6589 ns |    33.2190 ns |      - |     - |     - |         - |
|                  ArrayCountRewritten |     0.0040 ns |   0.0059 ns |   0.0056 ns |     0.0014 ns |      - |     - |     - |         - |
|                  ArrayCountCondition | 5,398.7331 ns |  99.0791 ns |  92.6786 ns | 5,436.6032 ns |      - |     - |     - |      20 B |
|         ArrayCountConditionRewritten |   540.8117 ns |   6.6805 ns |   6.2489 ns |   543.3935 ns |      - |     - |     - |         - |
|                     ArraySelectCount | 3,991.6409 ns |  71.5784 ns |  66.9544 ns | 3,950.4944 ns | 0.0076 |     - |     - |      36 B |
|            ArraySelectCountRewritten |     0.0034 ns |   0.0055 ns |   0.0052 ns |     0.0000 ns |      - |     - |     - |         - |
|                      ArrayWhereCount | 3,920.9424 ns |  69.5276 ns |  65.0362 ns | 3,952.0847 ns | 0.0076 |     - |     - |      32 B |
|             ArrayWhereCountRewritten |   590.4720 ns |  11.3845 ns |  11.1811 ns |   590.7279 ns |      - |     - |     - |         - |
|             ArrayWhereCountCondition | 6,379.6579 ns | 126.4031 ns | 145.5660 ns | 6,391.3761 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereCountConditionRewritten |   800.8579 ns |  11.3082 ns |  10.5777 ns |   807.3773 ns |      - |     - |     - |         - |
|             EnumerableCountCondition | 5,340.9522 ns |  88.6681 ns |  78.6020 ns | 5,369.8528 ns |      - |     - |     - |      24 B |
|    EnumerableCountConditionRewritten | 4,235.6914 ns |  83.1275 ns |  77.7575 ns | 4,224.0906 ns |      - |     - |     - |      24 B |
|          EnumerableCountNotCondition | 5,813.6725 ns |  94.7817 ns |  88.6589 ns | 5,860.4736 ns |      - |     - |     - |      24 B |
| EnumerableCountNotConditionRewritten | 4,967.3271 ns |  73.8149 ns |  69.0465 ns | 4,927.1103 ns |      - |     - |     - |      24 B |
|          EnumerableCountAllCondition | 5,318.1973 ns |  81.9439 ns |  76.6504 ns | 5,337.9967 ns |      - |     - |     - |      24 B |
| EnumerableCountAllConditionRewritten | 4,249.5113 ns |  76.8207 ns |  71.8582 ns | 4,265.5354 ns |      - |     - |     - |      24 B |