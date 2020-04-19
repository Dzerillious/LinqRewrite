|                     Method |         Mean |       Error |      StdDev |
|--------------------------- |-------------:|------------:|------------:|
|                   RangeSum |   4,179.4 ns |    16.29 ns |    15.24 ns |
|          RangeSumRewritten |     801.8 ns |     5.78 ns |     5.41 ns | x5
|                   ArraySum |   3,776.5 ns |    41.32 ns |    38.65 ns |
|          ArraySumRewritten |     365.4 ns |     3.80 ns |     3.56 ns | x10
|          ArrayCompositeSum | 135,608.9 ns | 1,084.51 ns | 1,014.45 ns |
| ArrayCompositeSumRewritten |     307.1 ns |     2.36 ns |     2.09 ns | x400
|              ArrayWhereSum |   3,317.8 ns |    36.68 ns |    34.31 ns |
|     ArrayWhereSumRewritten |     578.9 ns |     6.02 ns |     5.63 ns | x6
|           ArrayNullableSum |   7,956.5 ns |    45.77 ns |    42.81 ns |
|  ArrayNullableSumRewritten |   1,217.7 ns |     9.71 ns |     9.08 ns | x6
|              EnumerableSum |   4,690.2 ns |    43.37 ns |    40.57 ns |
|     EnumerableSumRewritten |   4,168.8 ns |    60.54 ns |    56.63 ns | x1.1