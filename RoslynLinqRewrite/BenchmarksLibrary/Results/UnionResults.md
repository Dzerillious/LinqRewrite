|                                                   Method |     Mean |    Error |   StdDev |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------------------------------------------------- |---------:|---------:|---------:|--------:|-------:|------:|----------:|
|                                   ArrayUnionArrayToArray | 50.86 us | 0.560 us | 0.524 us | 20.9961 |      - |     - |  86.19 KB |
|                          ArrayUnionArrayToArrayRewritten | 38.24 us | 0.396 us | 0.351 us | 17.8223 |      - |     - |   73.3 KB |
|                         ArrayWhereUnionArrayWhereToArray | 50.68 us | 0.620 us | 0.580 us | 20.9961 |      - |     - |  86.19 KB |
|                ArrayWhereUnionArrayWhereToArrayRewritten | 38.07 us | 0.450 us | 0.421 us | 17.8223 |      - |     - |   73.3 KB |
|                              ArrayUnionEnumerableToArray | 50.38 us | 0.498 us | 0.465 us | 20.9961 |      - |     - |  86.19 KB |
|                     ArrayUnionEnumerableToArrayRewritten | 40.98 us | 0.381 us | 0.356 us | 17.9443 | 0.0610 |     - |  73.74 KB |
|                    ArrayWhereUnionEnumerableWhereToArray | 50.19 us | 0.589 us | 0.551 us | 20.9961 |      - |     - |  86.19 KB |
|           ArrayWhereUnionEnumerableWhereToArrayRewritten | 41.00 us | 0.472 us | 0.441 us | 17.9443 | 0.0610 |     - |  73.74 KB |
|                              EnumerableUnionArrayToArray | 50.48 us | 0.674 us | 0.631 us | 20.9961 |      - |     - |  86.19 KB |
|                     EnumerableUnionArrayToArrayRewritten | 39.94 us | 0.307 us | 0.287 us | 17.9443 | 0.0610 |     - |  73.74 KB |
|                    EnumerableWhereUnionArrayWhereToArray | 50.83 us | 0.447 us | 0.418 us | 20.9961 |      - |     - |  86.19 KB |
|           EnumerableWhereUnionArrayWhereToArrayRewritten | 39.84 us | 0.304 us | 0.285 us | 17.9443 | 0.0610 |     - |  73.74 KB |
|                         EnumerableUnionEnumerableToArray | 50.05 us | 0.654 us | 0.580 us | 20.9961 |      - |     - |  86.19 KB |
|                EnumerableUnionEnumerableToArrayRewritten | 43.76 us | 0.454 us | 0.402 us | 17.9443 | 0.0610 |     - |  73.74 KB |
|               EnumerableWhereUnionEnumerableWhereToArray | 49.85 us | 0.393 us | 0.368 us | 20.9961 |      - |     - |  86.19 KB |
|      EnumerableWhereUnionEnumerableWhereToArrayRewritten | 43.28 us | 0.279 us | 0.233 us | 17.9443 | 0.0610 |     - |  73.74 KB |
|                              ArrayUnionArrayToSimpleList | 49.02 us | 0.936 us | 0.830 us | 18.1274 |      - |     - |   74.9 KB |
|                     ArrayUnionArrayToSimpleListRewritten | 37.63 us | 0.538 us | 0.503 us | 16.3574 |      - |     - |  67.41 KB |
|                    ArrayWhereUnionArrayWhereToSimpleList | 48.09 us | 0.427 us | 0.356 us | 18.1274 |      - |     - |   74.9 KB |
|           ArrayWhereUnionArrayWhereToSimpleListRewritten | 37.71 us | 0.445 us | 0.372 us | 16.3574 |      - |     - |  67.41 KB |
|                    EnumerableUnionEnumerableToSimpleList | 48.18 us | 0.521 us | 0.487 us | 18.1274 |      - |     - |   74.9 KB |
|           EnumerableUnionEnumerableToSimpleListRewritten | 43.13 us | 0.608 us | 0.569 us | 16.4795 | 0.0610 |     - |  67.91 KB |
|          EnumerableWhereUnionEnumerableWhereToSimpleList | 47.84 us | 0.259 us | 0.229 us | 18.1274 |      - |     - |   74.9 KB |
| EnumerableWhereUnionEnumerableWhereToSimpleListRewritten | 43.15 us | 0.413 us | 0.366 us | 16.4795 | 0.0610 |     - |  67.91 KB |