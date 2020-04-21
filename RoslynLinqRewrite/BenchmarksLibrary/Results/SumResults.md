|                     Method |         Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |-------------:|------------:|------------:|-------:|------:|------:|----------:|
|                   RangeSum |   4,208.0 ns |    53.53 ns |    50.07 ns | 0.0076 |     - |     - |      40 B |
|          RangeSumRewritten |     804.6 ns |     5.87 ns |     5.49 ns |      - |     - |     - |         - |
|                   ArraySum |   3,797.0 ns |    43.86 ns |    41.03 ns |      - |     - |     - |      20 B |
|          ArraySumRewritten |     561.4 ns |     5.49 ns |     5.13 ns |      - |     - |     - |         - |
|          ArrayCompositeSum | 136,779.0 ns | 1,476.27 ns | 1,380.90 ns | 2.4414 |     - |     - |   10332 B |
| ArrayCompositeSumRewritten |     306.2 ns |     3.54 ns |     3.31 ns |      - |     - |     - |         - |
|              ArrayWhereSum |   3,308.5 ns |    31.38 ns |    29.35 ns | 0.0076 |     - |     - |      32 B |
|     ArrayWhereSumRewritten |     807.7 ns |    10.65 ns |     9.97 ns |      - |     - |     - |         - |
|           ArrayNullableSum |   8,014.9 ns |    54.59 ns |    51.06 ns |      - |     - |     - |      40 B |
|  ArrayNullableSumRewritten |   1,225.5 ns |    11.44 ns |    10.70 ns |      - |     - |     - |         - |
|              EnumerableSum |   4,735.9 ns |    39.19 ns |    36.66 ns |      - |     - |     - |      24 B |
|     EnumerableSumRewritten |   4,172.5 ns |    51.90 ns |    48.55 ns |      - |     - |     - |      24 B |