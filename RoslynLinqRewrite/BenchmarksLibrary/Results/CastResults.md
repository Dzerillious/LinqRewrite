|                                   Method |       Mean |    Error |   StdDev |
|----------------------------------------- |-----------:|---------:|---------:|
|                         ArrayCastToArray |   334.9 ns |  4.66 ns |  3.89 ns |
|                ArrayCastToArrayRewritten |   242.2 ns |  4.03 ns |  3.77 ns |
|                    EnumerableCastToArray | 5,491.9 ns | 88.05 ns | 82.36 ns |
|           EnumerableCastToArrayRewritten | 5,405.6 ns | 67.84 ns | 60.14 ns |
|                    ArrayCastToSimpleList | 5,584.2 ns | 83.99 ns | 78.57 ns |
|           ArrayCastToSimpleListRewritten |   749.3 ns |  9.44 ns |  8.83 ns |
|                   StaticArrayCastToArray |   330.4 ns |  6.37 ns |  6.26 ns |
|          StaticArrayCastToArrayRewritten |   250.7 ns |  3.27 ns |  2.90 ns |
|                ArrayUncheckedCastToArray |   339.5 ns |  2.66 ns |  2.49 ns |
|       ArrayUncheckedCastToArrayRewritten |   241.6 ns |  4.59 ns |  4.29 ns |
|      EnumerableUncheckedCastToSimpleList | 5,514.2 ns | 73.96 ns | 69.19 ns |
| EnumerableUncheckedToSimpleListRewritten | 5,449.3 ns | 92.50 ns | 82.00 ns |