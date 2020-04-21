|                                                    Method |     Mean |    Error |   StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------------------- |---------:|---------:|---------:|--------:|------:|------:|----------:|
|                                   ArrayExceptArrayToArray | 49.22 us | 0.715 us | 0.669 us | 17.0898 |     - |     - |  70.21 KB |
|                          ArrayExceptArrayToArrayRewritten | 35.00 us | 0.481 us | 0.450 us | 14.4653 |     - |     - |  59.65 KB |
|                         ArrayWhereExceptArrayWhereToArray | 49.49 us | 0.686 us | 0.642 us | 17.0898 |     - |     - |  70.21 KB |
|                ArrayWhereExceptArrayWhereToArrayRewritten | 35.11 us | 0.208 us | 0.173 us | 14.4653 |     - |     - |  59.65 KB |
|                              ArrayExceptEnumerableToArray | 47.79 us | 0.788 us | 0.737 us | 17.0898 |     - |     - |  70.21 KB |
|                     ArrayExceptEnumerableToArrayRewritten | 38.33 us | 0.270 us | 0.240 us | 15.0146 |     - |     - |  61.75 KB |
|                    ArrayWhereExceptEnumerableWhereToArray | 48.72 us | 0.562 us | 0.498 us | 17.0898 |     - |     - |  70.21 KB |
|           ArrayWhereExceptEnumerableWhereToArrayRewritten | 38.36 us | 0.376 us | 0.334 us | 15.0146 |     - |     - |  61.75 KB |
|                              EnumerableExceptArrayToArray | 48.48 us | 0.371 us | 0.329 us | 17.0898 |     - |     - |  70.21 KB |
|                     EnumerableExceptArrayToArrayRewritten | 38.35 us | 0.466 us | 0.435 us | 15.0146 |     - |     - |  61.75 KB |
|                    EnumerableWhereExceptArrayWhereToArray | 47.79 us | 0.597 us | 0.559 us | 17.0898 |     - |     - |  70.21 KB |
|           EnumerableWhereExceptArrayWhereToArrayRewritten | 38.41 us | 0.506 us | 0.473 us | 15.0146 |     - |     - |  61.75 KB |
|                         EnumerableExceptEnumerableToArray | 47.98 us | 0.557 us | 0.465 us | 17.0898 |     - |     - |  70.21 KB |
|                EnumerableExceptEnumerableToArrayRewritten | 40.90 us | 0.398 us | 0.332 us | 15.0146 |     - |     - |   61.8 KB |
|               EnumerableWhereExceptEnumerableWhereToArray | 47.03 us | 0.820 us | 0.767 us | 17.0898 |     - |     - |  70.21 KB |
|      EnumerableWhereExceptEnumerableWhereToArrayRewritten | 41.47 us | 0.500 us | 0.443 us | 15.0146 |     - |     - |   61.8 KB |
|                              ArrayExceptArrayToSimpleList | 48.35 us | 0.894 us | 0.836 us | 16.2964 |     - |     - |  66.86 KB |
|                     ArrayExceptArrayToSimpleListRewritten | 34.48 us | 0.590 us | 0.552 us | 14.4653 |     - |     - |  59.65 KB |
|                    ArrayWhereExceptArrayWhereToSimpleList | 48.12 us | 0.498 us | 0.466 us | 16.2964 |     - |     - |  66.86 KB |
|           ArrayWhereExceptArrayWhereToSimpleListRewritten | 34.52 us | 0.606 us | 0.567 us | 14.4653 |     - |     - |  59.65 KB |
|                    EnumerableExceptEnumerableToSimpleList | 47.60 us | 0.482 us | 0.377 us | 16.2964 |     - |     - |   66.9 KB |
|           EnumerableExceptEnumerableToSimpleListRewritten | 40.92 us | 0.423 us | 0.396 us | 14.5874 |     - |     - |  59.84 KB |
|          EnumerableWhereExceptEnumerableWhereToSimpleList | 47.15 us | 0.577 us | 0.540 us | 16.2964 |     - |     - |   66.9 KB |
| EnumerableWhereExceptEnumerableWhereToSimpleListRewritten | 41.18 us | 0.503 us | 0.470 us | 14.5874 |     - |     - |  59.84 KB |