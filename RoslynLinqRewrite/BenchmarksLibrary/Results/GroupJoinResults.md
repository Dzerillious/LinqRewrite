|                       Method |     Mean |     Error |    StdDev |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|----------------------------- |---------:|----------:|----------:|---------:|--------:|--------:|----------:|
|               ArrayGroupJoin | 5.699 ms | 0.0472 ms | 0.0394 ms | 117.1875 |       - |       - | 515.43 KB |
|      ArrayGroupJoinRewritten | 4.969 ms | 0.0606 ms | 0.0567 ms |  93.7500 |       - |       - | 400.25 KB |
|          EnumerableGroupJoin | 4.761 ms | 0.0762 ms | 0.0713 ms | 117.1875 |       - |       - | 515.49 KB |
| EnumerableGroupJoinRewritten | 5.100 ms | 0.0213 ms | 0.0189 ms | 117.1875 | 62.5000 | 39.0625 | 558.17 KB |