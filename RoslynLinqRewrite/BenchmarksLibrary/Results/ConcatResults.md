|                                                    Method |         Mean |       Error |      StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------------------- |-------------:|------------:|------------:|--------:|------:|------:|----------:|
|                                   ArrayConcatArrayToArray |  19,890.3 ns |   142.34 ns |   133.14 ns |  5.8594 |     - |     - |  24.05 KB |
|                          ArrayConcatArrayToArrayRewritten |     476.6 ns |     9.27 ns |    11.73 ns |  1.9112 |     - |     - |   7.85 KB | x42
|                         ArrayWhereConcatArrayWhereToArray |  17,222.7 ns |   321.58 ns |   300.81 ns |  5.3711 |     - |     - |  22.11 KB |
|                ArrayWhereConcatArrayWhereToArrayRewritten |   6,735.7 ns |   120.41 ns |   112.63 ns |  4.0588 |     - |     - |  16.67 KB | x2.7
|                              ArrayConcatArrayWhereToArray |  26,653.1 ns |   482.13 ns |   450.98 ns |  5.3711 |     - |     - |  22.11 KB |
|                     ArrayConcatArrayWhereToArrayRewritten |   4,102.4 ns |    61.85 ns |    54.83 ns |  3.9520 |     - |     - |  16.22 KB | x8
|                           ArrayConcatMultipleArrayToArray | 105,859.5 ns | 1,340.95 ns | 1,119.75 ns | 20.3857 |     - |     - |  84.12 KB |
|                  ArrayConcatMultipleArrayToArrayRewritten |   1,014.0 ns |    17.01 ns |    15.91 ns |  4.7607 |     - |     - |  19.55 KB | x104
|                              ArrayConcatEnumerableToArray |  19,749.0 ns |   310.56 ns |   290.49 ns |  5.8594 |     - |     - |  24.05 KB |
|                     ArrayConcatEnumerableToArrayRewritten |   5,762.5 ns |   101.61 ns |    95.05 ns |  6.6833 |     - |     - |  27.45 KB | x3.6
|                    ArrayWhereConcatEnumerableWhereToArray |  21,422.1 ns |   338.11 ns |   316.26 ns |  5.4016 |     - |     - |  22.14 KB |
|           ArrayWhereConcatEnumerableWhereToArrayRewritten |  11,371.6 ns |   203.36 ns |   190.22 ns |  4.0588 |     - |     - |   16.7 KB | x2
|                              EnumerableConcatArrayToArray |  19,777.1 ns |   354.19 ns |   331.31 ns |  5.8594 |     - |     - |  24.05 KB |
|                     EnumerableConcatArrayToArrayRewritten |   7,873.6 ns |   142.51 ns |   133.31 ns |  4.5319 |     - |     - |   18.6 KB | x2.5
|                    EnumerableWhereConcatArrayWhereToArray |  31,367.3 ns |   513.02 ns |   479.88 ns |  5.3711 |     - |     - |  22.15 KB |
|           EnumerableWhereConcatArrayWhereToArrayRewritten |  10,510.2 ns |   199.42 ns |   186.54 ns |  4.0588 |     - |     - |   16.7 KB | x3
|                         EnumerableConcatEnumerableToArray |  20,040.0 ns |   347.73 ns |   325.27 ns |  5.8594 |     - |     - |  24.06 KB |
|                EnumerableConcatEnumerableToArrayRewritten |   9,679.0 ns |   178.50 ns |   166.97 ns |  4.5319 |     - |     - |  18.64 KB | x2
|               EnumerableWhereConcatEnumerableWhereToArray |  26,723.1 ns |   444.82 ns |   416.09 ns |  5.4016 |     - |     - |  22.15 KB |
|      EnumerableWhereConcatEnumerableWhereToArrayRewritten |  15,431.8 ns |   244.83 ns |   229.02 ns |  4.0588 |     - |     - |  16.72 KB | x1.3
|                              ArrayConcatArrayToSimpleList |  19,415.0 ns |   218.89 ns |   194.04 ns |  2.6245 |     - |     - |  10.83 KB |
|                     ArrayConcatArrayToSimpleListRewritten |     465.9 ns |     5.34 ns |     4.46 ns |  1.9155 |     - |     - |   7.86 KB | x42
|                    ArrayWhereConcatArrayWhereToSimpleList |  17,880.0 ns |   304.59 ns |   284.91 ns |  2.6245 |     - |     - |  10.86 KB |
|           ArrayWhereConcatArrayWhereToSimpleListRewritten |   7,200.3 ns |   115.98 ns |   108.49 ns |  2.6321 |     - |     - |  10.81 KB | x2.3
|                    EnumerableConcatEnumerableToSimpleList |  20,427.1 ns |   326.62 ns |   305.52 ns |  2.6245 |     - |     - |  10.84 KB |
|           EnumerableConcatEnumerableToSimpleListRewritten |  10,313.7 ns |   161.75 ns |   135.07 ns |  2.6245 |     - |     - |   10.8 KB | x2
|          EnumerableWhereConcatEnumerableWhereToSimpleList |  26,472.4 ns |   522.53 ns |   488.78 ns |  2.6550 |     - |     - |   10.9 KB |
| EnumerableWhereConcatEnumerableWhereToSimpleListRewritten |  15,381.5 ns |   234.40 ns |   219.26 ns |  2.6398 |     - |     - |  10.87 KB | x1.6