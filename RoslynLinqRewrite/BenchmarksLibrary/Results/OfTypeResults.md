|                                   Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------- |----------:|----------:|----------:|----------:|-------:|------:|------:|----------:|
|                       ArrayOfTypeToArray | 49.976 us | 0.2479 us | 0.2319 us | 49.970 us | 2.9297 |     - |     - |  12.08 KB |
|              ArrayOfTypeToArrayRewritten |  6.609 us | 0.0591 us | 0.0553 us |  6.627 us | 1.2665 |     - |     - |   5.21 KB |
|                  EnumerableOfTypeToArray | 36.856 us | 1.0558 us | 2.4471 us | 35.832 us | 5.7983 |     - |     - |  23.82 KB |
|         EnumerableOfTypeToArrayRewritten | 13.628 us | 0.1807 us | 0.1690 us | 13.680 us | 6.4392 |     - |     - |  26.41 KB |
|                  ArrayOfTypeToSimpleList | 40.326 us | 0.6123 us | 0.5727 us | 40.387 us | 2.6245 |     - |     - |  10.81 KB |
|         ArrayOfTypeToSimpleListRewritten |  6.937 us | 0.0809 us | 0.0757 us |  6.970 us | 1.2741 |     - |     - |   5.23 KB |
|                 StaticArrayOfTypeToArray | 49.408 us | 0.6861 us | 0.6082 us | 49.286 us | 2.9297 |     - |     - |  12.08 KB |
|        StaticArrayOfTypeToArrayRewritten |  6.551 us | 0.0924 us | 0.0864 us |  6.569 us | 1.2665 |     - |     - |   5.21 KB |
|              ArrayUncheckedOfTypeToArray | 52.414 us | 0.4729 us | 0.4192 us | 52.489 us | 2.9297 |     - |     - |  12.08 KB |
|     ArrayUncheckedOfTypeToArrayRewritten |  6.620 us | 0.1177 us | 0.1101 us |  6.621 us | 1.2665 |     - |     - |   5.21 KB |
|    EnumerableUncheckedOfTypeToSimpleList | 35.227 us | 0.4505 us | 0.3994 us | 35.293 us | 5.7983 |     - |     - |  23.82 KB |
| EnumerableUncheckedToSimpleListRewritten | 13.696 us | 0.2316 us | 0.2053 us | 13.721 us | 6.4392 |     - |     - |  26.41 KB |