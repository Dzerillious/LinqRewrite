|                       Method |          Mean |      Error |     StdDev |        Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |--------------:|-----------:|-----------:|--------------:|-------:|------:|------:|----------:|
|               RangeAggregate | 3,910.0525 ns | 58.5492 ns | 54.7670 ns | 3,939.3372 ns | 0.0076 |     - |     - |      40 B |
|        RangeAggregateToArray |   520.0923 ns |  9.3918 ns |  8.7851 ns |   523.9392 ns |      - |     - |     - |         - |
|              ArrayAggregate5 |    83.3060 ns |  1.7348 ns |  1.6228 ns |    82.1855 ns | 0.0143 |     - |     - |      60 B |
|     ArrayAggregate5Rewritten |     0.1387 ns |  0.1277 ns |  0.1194 ns |     0.2023 ns |      - |     - |     - |         - |
|             ArrayAggregate10 |   143.3690 ns |  2.5127 ns |  2.3504 ns |   145.1286 ns | 0.0143 |     - |     - |      60 B |
|    ArrayAggregate10Rewritten |     1.5046 ns |  0.2460 ns |  0.2301 ns |     1.6254 ns |      - |     - |     - |         - |
|        ArrayWhereAggregate10 | 3,991.9947 ns | 77.7834 ns | 72.7586 ns | 4,002.2079 ns | 0.0076 |     - |     - |      32 B |
| ArrayWhereAggregateRewritten |   370.4125 ns |  6.3201 ns |  5.9119 ns |   372.8033 ns |      - |     - |     - |         - |
|          EnumerableAggregate | 3,726.2383 ns | 55.8328 ns | 52.2260 ns | 3,703.0865 ns |      - |     - |     - |      24 B |
| EnumerableAggregateRewritten | 2,904.6535 ns | 57.5971 ns | 68.5653 ns | 2,927.9686 ns | 0.0038 |     - |     - |      24 B |