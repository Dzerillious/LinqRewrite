|                      Method |     Mean |    Error |   StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |---------:|---------:|---------:|--------:|------:|------:|----------:|
|               ArrayDistinct | 25.21 us | 0.403 us | 0.377 us | 10.7422 |     - |     - |   44.1 KB |
|      ArrayDistinctRewritten | 22.40 us | 0.387 us | 0.362 us | 15.1367 |     - |     - |  62.29 KB |
|          EnumerableDistinct | 24.78 us | 0.445 us | 0.416 us | 10.7422 |     - |     - |  44.13 KB |
| EnumerableDistinctRewritten | 25.32 us | 0.395 us | 0.370 us | 17.4866 |     - |     - |  71.75 KB |