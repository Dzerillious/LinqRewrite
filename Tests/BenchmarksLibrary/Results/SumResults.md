|                     Method |         Mean |       Error |      StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |-------------:|------------:|------------:|-------:|------:|------:|----------:|
|                   RangeSum |   5,155.4 ns |    65.32 ns |    54.54 ns | 0.0076 |     - |     - |      48 B |
|          RangeSumRewritten |     765.1 ns |    15.30 ns |    14.31 ns |      - |     - |     - |         - |
|                   ArraySum |   4,471.3 ns |    70.83 ns |    66.26 ns | 0.0076 |     - |     - |      32 B |
|          ArraySumRewritten |     562.5 ns |     8.62 ns |     8.07 ns |      - |     - |     - |         - |
|          ArrayCompositeSum | 160,626.1 ns | 2,349.34 ns | 2,197.57 ns | 3.9063 |     - |     - |   16570 B |
| ArrayCompositeSumRewritten |     444.3 ns |     7.76 ns |     7.26 ns |      - |     - |     - |         - |
|               ArraySIMDSum |   4,724.0 ns |    38.62 ns |    34.24 ns | 0.1373 |     - |     - |     594 B |
|      ArraySIMDSumRewritten |     327.6 ns |     3.88 ns |     3.63 ns |      - |     - |     - |         - |
|              ArrayWhereSum |   3,101.5 ns |    58.40 ns |    54.63 ns | 0.0114 |     - |     - |      48 B |
|     ArrayWhereSumRewritten |     851.7 ns |    16.91 ns |    15.82 ns |      - |     - |     - |         - |
|           ArrayNullableSum |   9,581.8 ns |    75.22 ns |    70.37 ns | 0.0153 |     - |     - |      64 B |
|  ArrayNullableSumRewritten |   1,105.0 ns |    19.16 ns |    17.92 ns |      - |     - |     - |         - |
|              EnumerableSum |   4,694.3 ns |    92.62 ns |   184.97 ns | 0.0076 |     - |     - |      32 B |
|     EnumerableSumRewritten |   4,688.3 ns |    89.06 ns |   102.56 ns | 0.0076 |     - |     - |      32 B |

|                     Method |        Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |------------:|----------:|----------:|-------:|------:|------:|----------:|
|                   RangeSum |  4,157.6 ns |  62.63 ns |  55.52 ns | 0.0076 |     - |     - |      40 B |
|          RangeSumRewritten |    802.2 ns |  11.02 ns |  10.31 ns |      - |     - |     - |         - |
|                   ArraySum |  4,421.5 ns |  79.01 ns |  73.90 ns | 0.0076 |     - |     - |      32 B |
|          ArraySumRewritten |    581.9 ns |   5.43 ns |   4.81 ns |      - |     - |     - |         - |
|          ArrayCompositeSum | 17,479.7 ns | 265.63 ns | 248.47 ns | 2.3499 |     - |     - |    9888 B |
| ArrayCompositeSumRewritten |    552.0 ns |   6.02 ns |   5.63 ns |      - |     - |     - |         - |
|               ArraySIMDSum |  1,180.6 ns |  22.58 ns |  21.12 ns | 0.1068 |     - |     - |     448 B |
|      ArraySIMDSumRewritten |    276.8 ns |   3.15 ns |   2.95 ns |      - |     - |     - |         - |
|              ArrayWhereSum |  3,243.9 ns |  64.45 ns |  68.96 ns | 0.0114 |     - |     - |      48 B |
|     ArrayWhereSumRewritten |    888.7 ns |  12.90 ns |  12.06 ns |      - |     - |     - |         - |
|           ArrayNullableSum |  9,770.3 ns |  92.77 ns |  77.47 ns |      - |     - |     - |      32 B |
|  ArrayNullableSumRewritten |  1,037.0 ns |  14.16 ns |  11.06 ns |      - |     - |     - |         - |
|              EnumerableSum |  4,729.9 ns |  31.90 ns |  28.28 ns | 0.0076 |     - |     - |      32 B |
|     EnumerableSumRewritten |  4,711.0 ns |  28.55 ns |  26.71 ns | 0.0076 |     - |     - |      32 B |