|                                   Method |        Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------- |------------:|----------:|----------:|-------:|------:|------:|----------:|
|                         ArrayCastToArray |    608.3 ns |   3.20 ns |   3.00 ns | 0.9575 |     - |     - |   3.93 KB |
|                ArrayCastToArrayRewritten |  4,200.4 ns |  35.94 ns |  31.86 ns | 0.9537 |     - |     - |   3.93 KB |
|                    EnumerableCastToArray | 19,486.2 ns | 195.44 ns | 173.25 ns | 5.7983 |     - |     - |  23.79 KB |
|           EnumerableCastToArrayRewritten | 13,671.6 ns | 224.79 ns | 210.27 ns | 6.4392 |     - |     - |  26.41 KB |
|                    ArrayCastToSimpleList |  9,095.5 ns |  96.83 ns |  90.57 ns | 2.6245 |     - |     - |  10.77 KB |
|           ArrayCastToSimpleListRewritten |  4,399.6 ns |  44.19 ns |  41.34 ns | 0.9613 |     - |     - |   3.94 KB |
|                   StaticArrayCastToArray |    600.2 ns |   9.83 ns |   8.72 ns | 0.9575 |     - |     - |   3.93 KB |
|          StaticArrayCastToArrayRewritten |  4,180.6 ns |  78.53 ns |  73.46 ns | 0.9537 |     - |     - |   3.93 KB |
|                ArrayUncheckedCastToArray |    602.8 ns |   6.76 ns |   6.32 ns | 0.9575 |     - |     - |   3.93 KB |
|       ArrayUncheckedCastToArrayRewritten |  4,166.3 ns |  62.25 ns |  58.23 ns | 0.9537 |     - |     - |   3.93 KB |
|      EnumerableUncheckedCastToSimpleList | 18,666.5 ns | 210.02 ns | 196.45 ns | 5.7983 |     - |     - |  23.79 KB |
| EnumerableUncheckedToSimpleListRewritten | 13,702.0 ns | 238.27 ns | 222.88 ns | 6.4392 |     - |     - |  26.41 KB |